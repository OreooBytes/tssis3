Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ExpirationReports
    ' ===== CONTROLS =====
    ' cmbMonths, cmbStatus, dgvExpiration, lblPage
    ' btnDecrease, btnIncrease, btnExportToPDF, btnExportToCSV

    ' ===== PAGINATION & PRINT =====
    Private printPageNumber As Integer = 1
    Private rowsPerPage As Integer = 30
    Private totalPages As Integer = 0
    Private totalRecords As Integer = 0
    Private printData As DataTable
    Private reportTitle As String = "Expiration Tracking Report"
    Private WithEvents printDoc As New PrintDocument()

    Private Const CornerRadius As Integer = 10 ' fixed radius

    ' === Apply Rounded Corners ===
    Private Sub ApplyRoundedCorners()
        Dim path As New GraphicsPath()
        path.StartFigure()

        ' Top-left
        path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90)
        ' Top edge
        path.AddLine(CornerRadius, 0, Me.Width - CornerRadius, 0)
        ' Top-right
        path.AddArc(Me.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90)
        ' Right edge
        path.AddLine(Me.Width, CornerRadius, Me.Width, Me.Height - CornerRadius)
        ' Bottom-right
        path.AddArc(Me.Width - CornerRadius, Me.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90)
        ' Bottom edge
        path.AddLine(Me.Width - CornerRadius, Me.Height, CornerRadius, Me.Height)
        ' Bottom-left
        path.AddArc(0, Me.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90)
        ' Left edge
        path.AddLine(0, Me.Height - CornerRadius, 0, CornerRadius)

        path.CloseFigure()
        Me.Region = New Region(path)
        Me.Invalidate()
    End Sub

    ' ===== FORM LOAD =====
    Private Sub ExpirationReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMonths()
        LoadStatus()
        cmbMonths.SelectedIndex = 0
        cmbStatus.SelectedIndex = 0
        LoadData()
        SetupDataGridView()

        ' Setup row coloring
        AddHandler dgvExpiration.CellFormatting, AddressOf dgvExpiration_CellFormatting


        ' Limitahan ang dropdown sa 12 items
        cmbMonths.MaxDropDownItems = 13

        ' ===== TextBox =====
        txtSearch.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== ComboBox =====
        cmbStatus.Font = New Font("Outfit", 9, FontStyle.Regular)
        cmbMonths.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== Buttons =====
        btnincrease.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnDecrease.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnExportToCSV.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnExportToPDF.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnPulledItems.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== Labels / HtmlLabels =====
        lblPage.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblmonths.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblStatus.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== DataGridView =====
        dgvExpiration.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' Initial load
        LoadData(False)

        '' ===== Dynamic Timer Setup =====
        expirationTimer.Interval = 1000 ' 1 second (pwede mong baguhin)
        expirationTimer.Start()

        lblExpired.Text = "0"
        lblValid.Text = "0"
        lblNonExpiring.Text = "0"






    End Sub

    ' ===== CONDITIONAL ROW COLORING =====
    Private Sub dgvExpiration_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvExpiration.CellFormatting
        If dgvExpiration.Rows(e.RowIndex).IsNewRow Then Return

        Dim row As DataGridViewRow = dgvExpiration.Rows(e.RowIndex)
        Dim expDateObj = row.Cells("ExpirationDate").Value

        ' Default color
        Dim bgColor As Color = Color.White
        Dim fgColor As Color = Color.Black

        If expDateObj IsNot Nothing AndAlso IsDate(expDateObj) Then
            Dim expDate As Date = CDate(expDateObj)
            Dim today As Date = Date.Today

            ' Conditional colors
            If expDate < today Then
                bgColor = Color.FromArgb(255, 199, 206) ' light red
            ElseIf expDate <= today.AddDays(30) Then
                bgColor = Color.FromArgb(255, 235, 156) ' light yellow
            Else
                bgColor = Color.FromArgb(198, 239, 206) ' light green
            End If
        End If

        ' Apply color
        row.DefaultCellStyle.BackColor = bgColor
        row.DefaultCellStyle.ForeColor = fgColor
        row.DefaultCellStyle.SelectionBackColor = bgColor ' important!
        row.DefaultCellStyle.SelectionForeColor = fgColor
    End Sub



    Private Sub SetupDataGridView()
        With dgvExpiration
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 30
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Plain default rows
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowsDefaultCellStyle.BackColor = Color.White
            .RowsDefaultCellStyle.ForeColor = Color.Black
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Black

            ' ===== Add Pull Out Button Column (if not exists) =====
            If .Columns("PullOut") Is Nothing Then
                Dim btnColumn As New DataGridViewButtonColumn()
                btnColumn.Name = "PullOut"
                btnColumn.HeaderText = "Action"
                btnColumn.Text = "Pull Out"
                btnColumn.UseColumnTextForButtonValue = True
                btnColumn.FlatStyle = FlatStyle.Standard
                btnColumn.Width = 80

                ' Center align header text
                btnColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns.Add(btnColumn)
            End If

        End With
    End Sub

    ' ===== LOAD MONTH COMBO =====
    Private Sub LoadMonths()
        cmbMonths.Items.Clear()
        cmbMonths.Items.Add("All")
        For i As Integer = 1 To 12
            cmbMonths.Items.Add(New DateTime(2000, i, 1).ToString("MMMM"))
        Next
    End Sub

    ' ===== LOAD STATUS COMBO =====
    Private Sub LoadStatus()
        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("All")
        cmbStatus.Items.Add("Valid")
        cmbStatus.Items.Add("Expired")
        cmbStatus.Items.Add("Near Expiration")
        cmbStatus.Items.Add("Without Expiration") ' <-- bagong item
        cmbStatus.SelectedIndex = 0
    End Sub


    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        printPageNumber = 1
        LoadData()
    End Sub

    Private Sub cmbMonths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonths.SelectedIndexChanged
        printPageNumber = 1
        LoadData()
    End Sub

    Private WithEvents expirationTimer As New Timer

    Private Sub expirationTimer_Tick(sender As Object, e As EventArgs) Handles expirationTimer.Tick
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' Collect currently visible rows (skip new/empty rows)
                Dim batchBarcodeList As New List(Of String)
                For Each row As DataGridViewRow In dgvExpiration.Rows
                    If Not row.IsNewRow Then
                        batchBarcodeList.Add($"'{row.Cells("BatchNumber").Value}_{row.Cells("BarcodeID").Value}'")
                    End If
                Next

                If batchBarcodeList.Count = 0 Then Return

                ' Query only RemainingQty for visible rows
                Dim query As String = $"
                SELECT d.BatchNumber, d.BarcodeID, SUM(d.RemainingQty) AS RemainingQty
                FROM deliveries d
                WHERE CONCAT(d.BatchNumber, '_', d.BarcodeID) IN ({String.Join(",", batchBarcodeList)})
                GROUP BY d.BatchNumber, d.BarcodeID"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        ' Map key -> RemainingQty
                        Dim remainingDict As New Dictionary(Of String, Decimal)
                        While reader.Read()
                            Dim key As String = $"{reader("BatchNumber")}_{reader("BarcodeID")}"
                            remainingDict(key) = Convert.ToDecimal(reader("RemainingQty"))
                        End While

                        ' Update only visible cells if value has changed (prevents flicker)
                        For Each row As DataGridViewRow In dgvExpiration.Rows
                            If row.IsNewRow Then Continue For

                            Dim key As String = $"{row.Cells("BatchNumber").Value}_{row.Cells("BarcodeID").Value}"
                            If remainingDict.ContainsKey(key) Then
                                Dim newQty As Decimal = remainingDict(key)
                                Dim oldQty As Decimal = If(IsDBNull(row.Cells("RemainingQty").Value), 0, Convert.ToDecimal(row.Cells("RemainingQty").Value))

                                ' Update only if different
                                If oldQty <> newQty Then
                                    row.Cells("RemainingQty").Value = newQty
                                End If
                            End If
                        Next
                    End Using
                End Using
            End Using

        Catch ex As Exception
            ' Optional: log error; do not interrupt timer
        End Try
    End Sub

    Private Sub formload1(sender As Object, e As EventArgs) Handles MyBase.Shown
        CountStatusFromGrid()
    End Sub



    ' ===== LOAD DATA =====
    Private Sub LoadData(Optional showNoDataMessage As Boolean = True)
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()



                ' ======== AUTO UPDATE EXPIRATION BASED ON product.Expiration ========
                Dim autoUpdateQuery As String = "
UPDATE deliveries d
JOIN product p ON d.BarcodeID = p.BarcodeID
SET 
    d.OriginalExpirationDate = CASE
        WHEN p.Expiration = 'No Expiration' AND d.ExpirationDate <> '0000-00-00' THEN d.ExpirationDate
        ELSE d.OriginalExpirationDate
    END,
    d.ExpirationDate = CASE
        WHEN p.Expiration = 'No Expiration' THEN '0000-00-00'
        WHEN p.Expiration = 'With Expiration' 
             AND (d.ExpirationDate IS NULL OR d.ExpirationDate = '0000-00-00') 
             AND d.OriginalExpirationDate IS NOT NULL 
        THEN d.OriginalExpirationDate
        ELSE d.ExpirationDate
    END"
                Using autoCmd As New MySqlCommand(autoUpdateQuery, conn)
                    autoCmd.ExecuteNonQuery()
                End Using

                ' ===== Base query =====
                Dim queryBase As String = "
FROM deliveries d
LEFT JOIN supplier s ON d.SupplierID = s.SupplierID
WHERE 1=1"

                Dim cmd As New MySqlCommand() With {.Connection = conn}

                ' ===== Month filter =====
                If cmbMonths.SelectedIndex > 0 Then
                    queryBase &= " AND MONTH(d.ExpirationDate) = @Month"
                    cmd.Parameters.AddWithValue("@Month", cmbMonths.SelectedIndex + 1)
                End If

                ' ===== Status filter =====
                Dim selectedStatus As String = cmbStatus.SelectedItem?.ToString()
                If Not String.IsNullOrEmpty(selectedStatus) Then
                    Select Case selectedStatus
                        Case "Expired"
                            queryBase &= " AND d.ExpirationDate < CURDATE() AND d.ExpirationDate <> '0000-00-00'"
                        Case "Near Expiration"
                            queryBase &= " AND d.ExpirationDate BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)"
                        Case "Valid"
                            queryBase &= " AND d.ExpirationDate > DATE_ADD(CURDATE(), INTERVAL 30 DAY)"
                        Case "Without Expiration"
                            queryBase &= " AND (d.ExpirationDate IS NULL OR d.ExpirationDate = '0000-00-00')"
                    End Select
                End If

                ' ===== Get total records (hide zero RemainingQty using HAVING) =====
                Dim countQuery As String = "
SELECT COUNT(*) 
FROM (
    SELECT d.BatchNumber, 
           d.BarcodeID, 
           d.ProductName, 
           COALESCE(s.CompanyName, 'N/A') AS Supplier,
           SUM(d.RemainingQty) AS RemainingQty
    " & queryBase & "
    GROUP BY d.BatchNumber, d.BarcodeID, d.ProductName, Supplier
    HAVING SUM(d.RemainingQty) > 0
) AS grouped"

                Dim countCmd As New MySqlCommand(countQuery, conn)
                countCmd.Parameters.AddRange(cmd.Parameters.Cast(Of MySqlParameter).ToArray())
                totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
                totalPages = Math.Max(Math.Ceiling(totalRecords / rowsPerPage), 1)

                ' ===== Paginated data query =====
                Dim offset As Integer = (printPageNumber - 1) * rowsPerPage
                Dim pageQuery As String = "
SELECT d.BatchNumber,
    COALESCE(s.CompanyName, 'N/A') AS Supplier,
    d.BarcodeID,
    d.ProductName,
    SUM(d.RemainingQty) AS RemainingQty,
    CASE 
        WHEN d.ExpirationDate IS NULL 
             OR d.ExpirationDate = '' 
             OR d.ExpirationDate = '0000-00-00' 
        THEN 'No Expiration' 
        ELSE DATE_FORMAT(MIN(d.ExpirationDate), '%Y-%m-%d') 
    END AS ExpirationDate
" & queryBase & "
GROUP BY d.BatchNumber, d.BarcodeID, d.ProductName, Supplier
HAVING SUM(d.RemainingQty) > 0
ORDER BY MIN(d.ExpirationDate) ASC
LIMIT @RowsPerPage OFFSET @Offset"

                cmd.CommandText = pageQuery
                cmd.Parameters.AddWithValue("@RowsPerPage", rowsPerPage)
                cmd.Parameters.AddWithValue("@Offset", offset)

                ' ===== Fill DataGridView =====
                Dim dtPage As New DataTable()
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dtPage)
                    dgvExpiration.DataSource = dtPage
                End Using

                ' ===== Full data for printing =====
                Dim fullCmd As New MySqlCommand("
SELECT d.BatchNumber,
    COALESCE(s.CompanyName, 'N/A') AS Supplier,
    d.BarcodeID,
    d.ProductName,
    SUM(d.RemainingQty) AS RemainingQty,
    CASE 
        WHEN d.ExpirationDate IS NULL 
             OR d.ExpirationDate = '' 
             OR d.ExpirationDate = '0000-00-00'
        THEN 'No Expiration'
        ELSE DATE_FORMAT(MIN(d.ExpirationDate), '%Y/%m/%d')
    END AS ExpirationDate
" & queryBase & "
GROUP BY d.BatchNumber, d.BarcodeID, d.ProductName, Supplier
HAVING SUM(d.RemainingQty) > 0
ORDER BY MIN(d.ExpirationDate) ASC", conn)

                fullCmd.Parameters.AddRange(cmd.Parameters.Cast(Of MySqlParameter).ToArray())

                Dim dtFull As New DataTable()
                Using adapterFull As New MySqlDataAdapter(fullCmd)
                    adapterFull.Fill(dtFull)
                    printData = dtFull
                End Using

                ' ===== Update pagination label =====
                lblPage.Text = $"Page {printPageNumber} / {totalPages}"

                ' ===== Remove default formatting =====
                If dgvExpiration.Columns.Contains("ExpirationDate") Then
                    dgvExpiration.Columns("ExpirationDate").DefaultCellStyle.Format = ""
                End If

                ' ===== Highlight rows =====
                dgvExpiration.ClearSelection()
                ApplyRowColors()


            End Using

        Catch ex As Exception
            If showNoDataMessage Then
                MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub CountStatusFromGrid()

        Dim expiredCount As Integer = 0
        Dim validCount As Integer = 0
        Dim nonExpiringCount As Integer = 0

        Dim today As Date = Date.Today

        Dim dt As DataTable = TryCast(dgvExpiration.DataSource, DataTable)
        If dt Is Nothing Then Exit Sub

        For Each row As DataRow In dt.Rows

            Dim remainingQty As Decimal = 0D
            If Not Decimal.TryParse(row("RemainingQty").ToString(), remainingQty) Then Continue For
            If remainingQty <= 0 Then Continue For

            Dim expText As String = row("ExpirationDate").ToString().Trim()

            ' ✅ If No Expiration → treat as VALID
            If String.IsNullOrEmpty(expText) _
        OrElse expText = "No Expiration" _
        OrElse expText = "0000-00-00" Then

                nonExpiringCount += 1   ' optional kung gusto mo pa rin i-display
                validCount += 1         ' automatic valid
                Continue For
            End If

            Dim expDate As Date
            If Date.TryParse(expText, expDate) Then

                If expDate < today Then
                    expiredCount += 1

                Else
                    validCount += 1     ' lahat ng hindi expired = valid
                End If

            End If

        Next

        lblExpired.Text = expiredCount.ToString()
        lblValid.Text = validCount.ToString()
        lblNonExpiring.Text = nonExpiringCount.ToString()

    End Sub










    ' ====== HELPER METHOD ======
    Private Sub HighlightInvalidDates()
        Try
            For Each row As DataGridViewRow In dgvExpiration.Rows
                If row.Cells("ExpirationDate") IsNot Nothing Then
                    Dim expVal As String = row.Cells("ExpirationDate").Value?.ToString().Trim()

                    ' Highlight blank cells as light green
                    If String.IsNullOrEmpty(expVal) Then
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#afcbcb") ' Light green
                        row.DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If
            Next
        Catch
            ' Ignore errors if DataGridView is empty
        End Try
    End Sub


    Private Sub ApplyRowColors()
        If dgvExpiration Is Nothing OrElse dgvExpiration.Rows.Count = 0 Then Return

        For Each row As DataGridViewRow In dgvExpiration.Rows
            If row.IsNewRow Then Continue For

            Dim expDateObj = row.Cells("ExpirationDate").Value
            Dim bgColor As Color = Color.White
            Dim fgColor As Color = Color.Black

            ' === HANDLE NULL, EMPTY, OR "0000-00-00" ===
            If expDateObj Is Nothing OrElse String.IsNullOrEmpty(expDateObj.ToString().Trim()) OrElse expDateObj.ToString().Trim() = "0000-00-00" Then
                ' No expiration = light green
                bgColor = ColorTranslator.FromHtml("#afcbcb")

            ElseIf IsDate(expDateObj) Then
                Dim expDate As Date = CDate(expDateObj)
                Dim today As Date = Date.Today

                If expDate < today Then
                    ' Expired = light red
                    bgColor = Color.FromArgb(255, 199, 206)
                ElseIf expDate <= today.AddDays(30) Then
                    ' Near Expiration = light yellow
                    bgColor = Color.FromArgb(255, 235, 156)
                Else
                    ' Valid = light greenish
                    bgColor = Color.FromArgb(198, 239, 206)
                End If
            End If

            ' === Apply colors ===
            row.DefaultCellStyle.BackColor = bgColor
            row.DefaultCellStyle.ForeColor = fgColor
            row.DefaultCellStyle.SelectionBackColor = bgColor
            row.DefaultCellStyle.SelectionForeColor = fgColor
        Next
    End Sub





    ' ===== PAGINATION BUTTONS =====
    Private Sub btnIncrease_Click(sender As Object, e As EventArgs) Handles btnincrease.Click
        If printPageNumber < totalPages Then
            printPageNumber += 1
            LoadData(False)
        End If
    End Sub

    Private Sub btnDecrease_Click(sender As Object, e As EventArgs) Handles btnDecrease.Click
        If printPageNumber > 1 Then
            printPageNumber -= 1
            LoadData(False)
        End If
    End Sub

    ' ===== PRINT DOCUMENT =====
    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        ' ===== Determine source =====
        Dim sourceTable As DataTable

        If String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            ' No search → use full printData
            If printData Is Nothing OrElse printData.Rows.Count = 0 Then
                e.HasMorePages = False
                Return
            End If
            sourceTable = printData
        Else
            ' Search active → use current DataGridView rows
            If dgvExpiration Is Nothing OrElse dgvExpiration.Rows.Count = 0 Then
                e.HasMorePages = False
                Return
            End If
            ' Convert dgv rows to DataTable
            sourceTable = New DataTable()
            For Each col As DataGridViewColumn In dgvExpiration.Columns
                sourceTable.Columns.Add(col.Name)
            Next
            For Each row As DataGridViewRow In dgvExpiration.Rows
                If row.IsNewRow Then Continue For
                Dim dr As DataRow = sourceTable.NewRow()
                For i As Integer = 0 To dgvExpiration.Columns.Count - 1
                    dr(i) = row.Cells(i).Value
                Next
                sourceTable.Rows.Add(dr)
            Next
        End If

        ' ===== FONTS =====
        Dim storeFont As New Font("Arial", 15, FontStyle.Bold)
        Dim addressFont As New Font("Arial", 11)
        Dim titleFont As New Font("Arial", 13, FontStyle.Bold)
        Dim dgvHeaderFont As New Font("Arial", 9, FontStyle.Bold)
        Dim dgvCellFont As New Font("Arial", 9)
        Dim footerFont As New Font("Arial", 9)

        ' ===== HEADER =====
        Dim yPos As Single = e.MarginBounds.Top
        Dim centerX As Single = e.MarginBounds.Left + (e.MarginBounds.Width / 2)

        ' Store Name
        Dim textWidth As Single = e.Graphics.MeasureString("TALLER STORE", storeFont).Width
        e.Graphics.DrawString("TALLER STORE", storeFont, Brushes.Black, centerX - (textWidth / 2), yPos)
        yPos += storeFont.GetHeight() + 6

        ' Address
        Dim addr1 As String = "G326+XM6, Rd. 11, Maguindanao St"
        textWidth = e.Graphics.MeasureString(addr1, addressFont).Width
        e.Graphics.DrawString(addr1, addressFont, Brushes.Black, centerX - (textWidth / 2), yPos)
        yPos += addressFont.GetHeight() + 2

        Dim addr2 As String = "Prk. 3 Brgy, Taguig, Metro Manila"
        textWidth = e.Graphics.MeasureString(addr2, addressFont).Width
        e.Graphics.DrawString(addr2, addressFont, Brushes.Black, centerX - (textWidth / 2), yPos)
        yPos += addressFont.GetHeight() + 25

        ' Report Title
        textWidth = e.Graphics.MeasureString(reportTitle, titleFont).Width
        e.Graphics.DrawString(reportTitle, titleFont, Brushes.Black, centerX - (textWidth / 2), yPos)
        yPos += titleFont.GetHeight() + 40

        ' ===== STATUS & MONTH =====
        If String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            Dim combinedText As String = "Status: " & cmbStatus.Text & " | Month: " & cmbMonths.Text
            Dim statusFont As New Font("Arial", 10, FontStyle.Bold)
            Dim combinedX As Single = e.MarginBounds.Left - 30
            e.Graphics.DrawString(combinedText, statusFont, Brushes.Black, combinedX, yPos)
            yPos += statusFont.GetHeight() + 5
        End If

        ' ===== TABLE HEADERS =====
        Dim colWidths() As Single = {180, 160, 150, 150, 100, 100}
        Dim headers() As String = {"Batch No", "Supplier", "BarcodeID", "Product Name", "Remaining Qty", "Expiration"}
        Dim totalTableWidth As Single = colWidths.Sum()
        Dim startX As Single = e.MarginBounds.Left + ((e.MarginBounds.Width - totalTableWidth) / 2)

        ' Draw header row
        Dim colX As Single = startX
        Dim rowHeight As Single = 28
        For i As Integer = 0 To headers.Length - 1
            ' Calculate the header text's width to center it
            Dim headerTextWidth As Single = e.Graphics.MeasureString(headers(i), dgvHeaderFont).Width
            Dim headerCenterX As Single = colX + (colWidths(i) / 2) - (headerTextWidth / 2)

            e.Graphics.FillRectangle(Brushes.LightGray, colX, yPos, colWidths(i), rowHeight)
            e.Graphics.DrawRectangle(Pens.Black, colX, yPos, colWidths(i), rowHeight)
            e.Graphics.DrawString(headers(i), dgvHeaderFont, Brushes.Black, headerCenterX, yPos + 6)
            colX += colWidths(i)
        Next
        yPos += rowHeight

        ' ===== PRINT ROWS (30 per page) =====
        Dim itemsPerPage As Integer = 30
        Dim startRow As Integer = (printPageNumber - 1) * itemsPerPage
        Dim endRow As Integer = Math.Min(startRow + itemsPerPage, sourceTable.Rows.Count)

        For i As Integer = startRow To endRow - 1
            colX = startX
            Dim expDateObj = sourceTable.Rows(i)("ExpirationDate")

            ' --- Row background based on expiration
            Dim rowBrush As Brush = Brushes.White
            Dim disposeBrush As Boolean = False

            If expDateObj IsNot Nothing AndAlso IsDate(expDateObj) Then
                Dim expDate As Date = CDate(expDateObj)
                Dim today As Date = Date.Today

                If expDate < today Then
                    rowBrush = New SolidBrush(Color.FromArgb(255, 199, 206)) ' Expired
                    disposeBrush = True
                ElseIf expDate <= today.AddDays(30) Then
                    rowBrush = New SolidBrush(Color.FromArgb(255, 235, 156)) ' Expiring soon
                    disposeBrush = True
                Else
                    rowBrush = New SolidBrush(Color.FromArgb(198, 239, 206)) ' Safe
                    disposeBrush = True
                End If
            End If

            ' Draw cells (center text)
            For j As Integer = 0 To headers.Length - 1
                Dim cellValue As Object = sourceTable.Rows(i)(j)
                Dim cellText As String = ""

                ' Format qty
                If headers(j).ToLower().Contains("qty") AndAlso IsNumeric(cellValue) Then
                    cellText = Format(CDec(cellValue), "#,##0")
                    ' Format expiration date to "yyyy-MM-dd"
                ElseIf headers(j).ToLower().Contains("expiration") AndAlso IsDate(cellValue) Then
                    cellText = Format(CDate(cellValue), "yyyy-MM-dd")
                Else
                    cellText = If(cellValue IsNot Nothing, cellValue.ToString(), "")
                End If

                ' Calculate the text width to center it in the cell
                Dim cellTextWidth As Single = e.Graphics.MeasureString(cellText, dgvCellFont).Width
                Dim cellCenterX As Single = colX + (colWidths(j) / 2) - (cellTextWidth / 2)

                e.Graphics.FillRectangle(rowBrush, colX, yPos, colWidths(j), rowHeight)
                e.Graphics.DrawRectangle(Pens.Black, colX, yPos, colWidths(j), rowHeight)
                e.Graphics.DrawString(cellText, dgvCellFont, Brushes.Black, cellCenterX, yPos + 6)
                colX += colWidths(j)
            Next

            ' Dispose only if dynamically created
            If disposeBrush Then CType(rowBrush, SolidBrush).Dispose()
            yPos += rowHeight
        Next

        ' ===== FOOTER =====
        e.Graphics.DrawString($"Page {printPageNumber} of {Math.Ceiling(sourceTable.Rows.Count / itemsPerPage)}",
              footerFont, Brushes.Black, e.MarginBounds.Left, e.PageBounds.Bottom - 40)

        ' ===== PAGINATION =====
        printPageNumber += 1
        e.HasMorePages = (printPageNumber <= Math.Ceiling(sourceTable.Rows.Count / itemsPerPage))
        If Not e.HasMorePages Then printPageNumber = 1
    End Sub







    ' ===== EXPORT TO PDF =====
    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click

        ' Ensure there is data to print
        If printData Is Nothing OrElse printData.Rows.Count = 0 Then
            MessageBox.Show("No data available to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Reset page number
        printPageNumber = 1
        reportTitle = "Product Expiration Report"

        ' Configure page settings
        printDoc.DefaultPageSettings.PaperSize = New Printing.PaperSize("A4", 827, 1169)
        printDoc.DefaultPageSettings.Landscape = False
        printDoc.DefaultPageSettings.Margins = New Margins(50, 50, 50, 50)

        ' ===== 1. Show Print Preview =====
        Using preview As New PrintPreviewDialog()
            preview.Document = printDoc
            preview.Width = 1000
            preview.Height = 800

            ' Center the PrintPreviewDialog on the screen
            preview.StartPosition = FormStartPosition.CenterScreen  ' <--- Added line


            preview.ShowDialog()
        End Using

        ' ===== 2. Save As PDF =====
        Using sfd As New SaveFileDialog()
            sfd.Filter = "PDF Files|*.pdf"
            sfd.Title = "Save report as PDF"
            sfd.FileName = "ProductExpirationReport_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    ' Use Microsoft Print to PDF
                    printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF"
                    printDoc.PrinterSettings.PrintToFile = True
                    printDoc.PrinterSettings.PrintFileName = sfd.FileName

                    ' Avoid extra print dialog
                    printDoc.PrintController = New Printing.StandardPrintController()

                    ' Print to PDF
                    printDoc.Print()

                    ' Show success message first
                    MessageBox.Show("Report saved to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' --- AUDIT TRAIL ---
                    LogAuditTrail(SessionData.role, SessionData.fullName, $"Exported Product Expiration Report to PDF: {sfd.FileName}")

                Catch ex As Exception
                    MessageBox.Show("Failed to export PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub





    ' ===== EXPORT TO CSV =====
    Private Sub btnExportToCSV_Click(sender As Object, e As EventArgs) Handles btnExportToCSV.Click
        ' Ensure there is data to export
        If printData Is Nothing OrElse printData.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv"
            sfd.Title = "Save report as CSV"
            sfd.FileName = "ProductExpirationReport_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Using sw As New StreamWriter(sfd.FileName)
                        ' Write header
                        For i As Integer = 0 To printData.Columns.Count - 1
                            sw.Write(printData.Columns(i).ColumnName)
                            If i < printData.Columns.Count - 1 Then sw.Write(",")
                        Next
                        sw.WriteLine()

                        ' Write rows
                        For Each row As DataRow In printData.Rows
                            For i As Integer = 0 To printData.Columns.Count - 1
                                Dim value As String = row(i).ToString()

                                ' Format expiration date without time
                                If printData.Columns(i).ColumnName.ToLower().Contains("expiration") AndAlso IsDate(value) Then
                                    value = Format(CDate(value), "yyyy-MM-dd")
                                End If

                                sw.Write(value)
                                If i < printData.Columns.Count - 1 Then sw.Write(",")
                            Next
                            sw.WriteLine()
                        Next
                    End Using

                    ' Show success message first
                    MessageBox.Show("CSV Exported Successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' --- AUDIT TRAIL ---
                    LogAuditTrail(SessionData.role, SessionData.fullName, $"Exported Product Expiration Report to CSV: {sfd.FileName}")

                Catch ex As Exception
                    MessageBox.Show("Failed to export CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    ' At the top of your form
    Private WithEvents highlightTimer As New Timer


    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' --- Ensure DataGridView and printData exist ---
        If dgvExpiration Is Nothing OrElse printData Is Nothing Then Return

        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        ' Enable or disable ComboBoxes based on search text
        Dim hasSearchText As Boolean = Not String.IsNullOrEmpty(searchText)
        cmbMonths.Enabled = Not hasSearchText
        cmbStatus.Enabled = Not hasSearchText

        ' If search is empty, show full data
        If Not hasSearchText Then
            dgvExpiration.DataSource = If(printData IsNot Nothing, printData.Copy(), Nothing)
            ApplyRowColors()
            Return
        End If

        ' Filter using DataView
        Dim dv As New DataView(printData)
        dv.RowFilter = String.Format(
        "ISNULL(ProductName,'') LIKE '%{0}%' OR ISNULL(Supplier,'') LIKE '%{0}%' OR ISNULL(BarcodeID,'') LIKE '%{0}%'",
        searchText.Replace("'", "''")
    )

        ' Bind filtered data
        dgvExpiration.DataSource = dv.ToTable()

        ' Apply row colors
        ApplyRowColors()
    End Sub





    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === DEFAULT COLORS & IMAGES ===
        btnDecrease.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnDecrease.ForeColor = Color.White
        btnDecrease.Image = My.Resources.icons8_less_than_50_normal ' normal icon

        btnincrease.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnincrease.ForeColor = Color.White
        btnincrease.Image = My.Resources.icons8_greater_than_50_normal ' normal icon

        btnExportToPDF.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnExportToPDF.ForeColor = Color.White
        btnExportToPDF.Image = My.Resources.icons8_pdf_30 ' normal icon

        btnExportToCSV.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnExportToCSV.ForeColor = Color.White
        btnExportToCSV.Image = My.Resources.icons8_csv_30 ' normal icon

        btnPulledItems.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnPulledItems.ForeColor = Color.White
        btnPulledItems.Image = My.Resources.icons8_open_box_30_normal  ' normal icon


        ' === HOVER EFFECTS FOR Decrease / Increase ===
        AddHandler btnDecrease.MouseEnter, Sub()
                                               btnDecrease.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                               btnDecrease.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                               btnDecrease.Image = My.Resources.icons8_less_than_50_hindi ' hover icon
                                           End Sub

        AddHandler btnDecrease.MouseLeave, Sub()
                                               btnDecrease.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                               btnDecrease.ForeColor = Color.White
                                               btnDecrease.Image = My.Resources.icons8_less_than_50_normal ' back to normal
                                           End Sub


        ' === HOVER EFFECTS FOR btnSort ===
        AddHandler btnincrease.MouseEnter, Sub()
                                               btnincrease.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                               btnincrease.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                               btnincrease.Image = My.Resources.icons8_greater_than_50_hindi ' hover icon
                                           End Sub

        AddHandler btnincrease.MouseLeave, Sub()
                                               btnincrease.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                               btnincrease.ForeColor = Color.White
                                               btnincrease.Image = My.Resources.icons8_greater_than_50_normal ' normal icon
                                           End Sub

        ''' === HOVER EFFECTS FOR PDF / CSV  ===

        ' PDF
        AddHandler btnExportToPDF.MouseEnter, Sub()
                                                  btnExportToPDF.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                  btnExportToPDF.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                  btnExportToPDF.Image = My.Resources.icons8_pdf_30_hindi ' hover icon
                                              End Sub

        AddHandler btnExportToPDF.MouseLeave, Sub()
                                                  btnExportToPDF.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                  btnExportToPDF.ForeColor = Color.White
                                                  btnExportToPDF.Image = My.Resources.icons8_pdf_30 ' normal icon
                                              End Sub
        ' CSV
        AddHandler btnExportToCSV.MouseEnter, Sub()
                                                  btnExportToCSV.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                  btnExportToCSV.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                  btnExportToCSV.Image = My.Resources.icons8_csv_30_hindi ' hover icon


                                              End Sub

        AddHandler btnExportToCSV.MouseLeave, Sub()
                                                  btnExportToCSV.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                  btnExportToCSV.ForeColor = Color.White
                                                  btnExportToCSV.Image = My.Resources.icons8_csv_30 ' normal icon
                                              End Sub

        AddHandler btnPulledItems.MouseEnter, Sub()
                                                  btnPulledItems.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                  btnPulledItems.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                  btnPulledItems.Image = My.Resources.icons8_open_box_30_hindi ' hover icon


                                              End Sub

        AddHandler btnPulledItems.MouseLeave, Sub()
                                                  btnPulledItems.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                  btnPulledItems.ForeColor = Color.White
                                                  btnPulledItems.Image = My.Resources.icons8_open_box_30_normal ' normal icon
                                              End Sub




        ' === OPTIONAL: CENTER THE FORM ON SCREEN ===
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    ' === Audit Trail  ===
    Private Sub LogAuditTrail(ByVal role As String, ByVal fullName As String, ByVal action As String)
        Try
            Using connection As New MySqlConnection(connectionstring)
                connection.Open()
                Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) " &
                                      "VALUES (@Role, @FullName, @Action, @Form, @Date)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@Action", action)
                    cmd.Parameters.AddWithValue("@Form", "Expiration Report")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== Pull Out =====

    Private Sub dgvExpiration_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpiration.CellContentClick
        ' Only trigger on PullOut button click
        If e.RowIndex < 0 OrElse dgvExpiration.Columns(e.ColumnIndex).Name <> "PullOut" Then Return

        ' Step 1: Access permission
        Using accessForm As New AccessPermission()
            If accessForm.ShowDialog() <> DialogResult.OK OrElse
               (SessionData.role <> "Admin" AndAlso SessionData.role <> "SuperAdmin") Then
                MessageBox.Show("Access denied or login cancelled.", "Permission Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End Using

        ' Step 2: Fetch row values safely
        Dim row As DataGridViewRow = dgvExpiration.Rows(e.RowIndex)
        Dim batchNumber As String = If(row.Cells("BatchNumber")?.Value?.ToString(), "")
        Dim barcode As String = If(row.Cells("BarcodeID")?.Value?.ToString(), "")
        Dim productName As String = If(row.Cells("ProductName")?.Value?.ToString(), "")
        Dim supplier As String = If(dgvExpiration.Columns.Contains("Supplier") AndAlso row.Cells("Supplier")?.Value IsNot Nothing,
                                    row.Cells("Supplier").Value.ToString(), "")
        Dim remainingQty As Integer = If(IsNumeric(row.Cells("RemainingQty")?.Value), CInt(row.Cells("RemainingQty").Value), 0)

        ' Handle ExpirationDate safely, even if missing or text like "No Expiration"
        Dim expirationDate As Date
        Dim expValue = row.Cells("ExpirationDate")?.Value
        If expValue Is Nothing OrElse String.IsNullOrWhiteSpace(expValue.ToString()) OrElse Not IsDate(expValue) Then
            expirationDate = Date.MinValue
        Else
            expirationDate = CDate(expValue)
        End If


        Dim productImage As Image = Nothing

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT ProductImage FROM product WHERE BarcodeID=@barcode LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("@barcode", barcode)
                    Dim result As Object = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Dim imgBytes() As Byte = TryCast(result, Byte())
                        If imgBytes IsNot Nothing AndAlso imgBytes.Length > 0 Then
                            Using ms As New IO.MemoryStream(imgBytes)
                                productImage = Image.FromStream(ms)
                            End Using
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Optional: log error
        End Try

        ' If no image from DB, use default from resources
        If productImage Is Nothing Then
            productImage = My.Resources.noprodcutimage
        End If

        ' Step 3: Extra values
        Dim pulledBy As String = SessionData.fullName
        Dim pullOutDate As DateTime = DateTime.Now

        ' Step 4: Open PullOut form and assign values
        Using pullForm As New PullOut()
            pullForm.lblBatchNumberValue.Text = batchNumber
            pullForm.lblBarcodeValue.Text = barcode
            pullForm.lblProductNameValue.Text = productName
            pullForm.lblSupplierValue.Text = supplier
            pullForm.lblRemainingQtyValue.Text = remainingQty.ToString()

            ' Display expiration date or "No Expiration"
            If expirationDate = Date.MinValue Then
                pullForm.lblExpirationDateValue.Text = "No Expiration"
            Else
                pullForm.lblExpirationDateValue.Text = expirationDate.ToShortDateString()
            End If

            pullForm.lblPulledByValue.Text = pulledBy
            pullForm.lblPullOutDateValue.Text = pullOutDate.ToString("yyyy-MM-dd HH:mm:ss")

            ' Assign image to PictureBox
            pullForm.pbProduct.Image = productImage
            pullForm.pbProduct.SizeMode = PictureBoxSizeMode.Zoom  ' optional, for better display

            ' Initialize Reason ComboBox safely
            If pullForm.cmbReason.Items.Count > 0 Then
                pullForm.cmbReason.SelectedIndex = 0
            End If

            ' Show form
            If pullForm.ShowDialog() = DialogResult.OK Then
                ' Remove row safely from DataGridView
                If TypeOf dgvExpiration.DataSource Is DataTable Then
                    Dim dt As DataTable = CType(dgvExpiration.DataSource, DataTable)
                    dt.Rows(e.RowIndex).Delete()
                Else
                    dgvExpiration.Rows.RemoveAt(e.RowIndex)
                End If

                MessageBox.Show("Item successfully pulled out.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using

    End Sub

    Private Sub btnPulledItems_Click(sender As Object, e As EventArgs) Handles btnPulledItems.Click
        Dim viewpullout As New ViewPullout
        viewpullout.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then
                CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            End If
            Me.Close()
        End If
    End Sub
End Class

