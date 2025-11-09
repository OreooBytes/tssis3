Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO

Public Class StockReports
    Inherits Form

    ' ==============================
    '       VARIABLES
    ' ==============================
    Private dt As New DataTable()
    Private Const CornerRadius As Integer = 10
    Private printDoc As New PrintDocument()
    Private printPageNumber As Integer = 1
    Private reportTitle As String = "Stock Report"
    Private totalPages As Integer = 1 ' Global variable para sa pagination


    ' ==============================
    '       CONSTRUCTOR
    ' ==============================
    Public Sub New()
        InitializeComponent()
        If Not Me.DesignMode Then
            ApplyRoundedCorners()
            AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage
        End If
    End Sub

    ' ==============================
    '       FORM LOAD
    ' ==============================
    Private Sub StockReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            SetupStockGrid()
            LoadStockReports()
        End If
        ApplyRoundedCorners()

        ' ===== DataGridView =====
        dgvStock.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== TextBox =====
        txtSearch.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== Buttons =====
        btnincrease.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnDecrease.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnExportToCSV.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnExportToPDF.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== Labels / HtmlLabels =====
        lblPage.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' Initial load
        LoadStockReports()



        lblTotalStocks.Text = "0"
        lblLowStocks.Text = "0"
        lblOutOfStock.Text = "0"

        ' Load initial stock report
        LoadStockReports()

        ' Start timer for real-time stock summary updates
        tmrStockSummary.Interval = 1000 ' 1 second
        tmrStockSummary.Enabled = True
        AddHandler tmrStockSummary.Tick, AddressOf tmrStockSummary_Tick


    End Sub

    ' ==============================
    '       DATA GRID SETUP
    ' ==============================
    Private Sub SetupStockGrid()
        With dgvStock
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 25
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub


    Private Sub FormatColumns()
        If dgvStock.Columns.Contains("id") Then dgvStock.Columns("id").Visible = False
        If dgvStock.Columns.Contains("BatchNumber") Then dgvStock.Columns("BatchNumber").FillWeight = 150 : dgvStock.Columns("BatchNumber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        If dgvStock.Columns.Contains("BarcodeID") Then dgvStock.Columns("BarcodeID").FillWeight = 100 : dgvStock.Columns("BarcodeID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        If dgvStock.Columns.Contains("Supplier") Then dgvStock.Columns("Supplier").FillWeight = 120 : dgvStock.Columns("Supplier").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        If dgvStock.Columns.Contains("ProductName") Then dgvStock.Columns("ProductName").FillWeight = 150 : dgvStock.Columns("ProductName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        If dgvStock.Columns.Contains("Quantity") Then dgvStock.Columns("Quantity").FillWeight = 70 : dgvStock.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        If dgvStock.Columns.Contains("WholesalePrice") Then dgvStock.Columns("WholesalePrice").FillWeight = 80 : dgvStock.Columns("WholesalePrice").DefaultCellStyle.Format = "N2"
        If dgvStock.Columns.Contains("CostPrice") Then dgvStock.Columns("CostPrice").FillWeight = 80 : dgvStock.Columns("CostPrice").DefaultCellStyle.Format = "N2"
        If dgvStock.Columns.Contains("UnitPrice") Then dgvStock.Columns("UnitPrice").FillWeight = 80 : dgvStock.Columns("UnitPrice").DefaultCellStyle.Format = "N2"
        If dgvStock.Columns.Contains("ExpirationDate") Then
            dgvStock.Columns("ExpirationDate").FillWeight = 100
            dgvStock.Columns("ExpirationDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvStock.Columns("ExpirationDate").DefaultCellStyle.Format = "yyyy-MM-dd"
        End If
        If dgvStock.Columns.Contains("CriticalLevel") Then dgvStock.Columns("CriticalLevel").FillWeight = 90
    End Sub

    Private currentPage As Integer = 1 ' Start with the first page
    Private recordsPerPage As Integer = 30 ' Define how many records to show per page


    Private WithEvents tmrStockSummary As New Timer()

    Private Sub LoadStockReports()
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' ===== Get total record count =====
                Dim countQuery As String = "
SELECT COUNT(*) 
FROM deliveries d
LEFT JOIN supplier s ON d.SupplierID = s.SupplierID
LEFT JOIN inventory i ON d.BarcodeID = i.BarcodeID
LEFT JOIN product p ON d.BarcodeID = p.BarcodeID"
                Dim totalRecords As Integer
                Using cmd As New MySqlCommand(countQuery, conn)
                    totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' ===== Calculate total pages =====
                totalPages = Math.Ceiling(totalRecords / CSng(recordsPerPage))

                ' ===== Get paginated data =====
                Dim query As String = "
SELECT 
    MIN(d.id) AS id,
    d.BatchNumber,
    d.BarcodeID AS BarcodeID,
    s.CompanyName AS Supplier,
    d.ProductName,
    SUM(d.RemainingQty) AS RemainingQty,
    p.WholesalePrice,
    AVG(d.CostPrice) AS CostPrice,
    AVG(d.UnitPrice) AS UnitPrice,
    CASE 
        WHEN d.ExpirationDate IS NULL OR d.ExpirationDate = '0000-00-00' THEN 'No Expiration'
        ELSE DATE_FORMAT(d.ExpirationDate, '%Y-%m-%d')
    END AS ExpirationDate,
    i.CriticalLevel
FROM deliveries d
LEFT JOIN supplier s ON d.SupplierID = s.SupplierID
LEFT JOIN inventory i ON d.BarcodeID = i.BarcodeID
LEFT JOIN product p ON d.BarcodeID = p.BarcodeID
GROUP BY d.BarcodeID, s.CompanyName, d.ProductName, p.WholesalePrice, i.CriticalLevel, d.ExpirationDate, d.BatchNumber
ORDER BY d.ProductName ASC
LIMIT @Offset, @Limit"

                Dim offset As Integer = (currentPage - 1) * recordsPerPage

                dt.Clear()
                Using adapter As New MySqlDataAdapter(query, conn)
                    adapter.SelectCommand.Parameters.AddWithValue("@Offset", offset)
                    adapter.SelectCommand.Parameters.AddWithValue("@Limit", recordsPerPage)
                    adapter.Fill(dt)
                End Using

                ' ===== Update pagination label =====
                lblPage.Text = $"Page {currentPage} / {totalPages}"

                ' ===== Bind DataGridView =====
                dgvStock.DataSource = dt
                FormatColumns()

                ' Hide unnecessary columns
                If dgvStock.Columns.Contains("BarcodeID") Then dgvStock.Columns("BarcodeID").Visible = False
                If dgvStock.Columns.Contains("WholesalePrice") Then dgvStock.Columns("WholesalePrice").Visible = False
                If dgvStock.Columns.Contains("CriticalLevel") Then dgvStock.Columns("CriticalLevel").Visible = False

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading stock reports: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tmrStockSummary_Tick(sender As Object, e As EventArgs)
        UpdateStockSummary()
    End Sub


    Private Sub UpdateStockSummary()
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' Query calculates total, low stock, and out-of-stock based on product and deliveries
                Dim summaryQuery As String = "
                SELECT
                    SUM(IFNULL(d.totalQty, 0)) AS TotalRemainingQty,
                    SUM(CASE WHEN IFNULL(d.totalQty,0) <= p.CriticalLevel AND IFNULL(d.totalQty,0) > 0 THEN 1 ELSE 0 END) AS LowStocks,
                    SUM(CASE WHEN IFNULL(d.totalQty,0) = 0 THEN 1 ELSE 0 END) AS OutOfStock
                FROM product p
                LEFT JOIN (
                    SELECT 
                        BarcodeID,
                        SUM(RemainingQty) AS totalQty
                    FROM deliveries
                    GROUP BY BarcodeID
                ) d ON p.BarcodeID = d.BarcodeID
            "

                Using summaryCmd As New MySqlCommand(summaryQuery, conn)
                    Using reader As MySqlDataReader = summaryCmd.ExecuteReader()
                        If reader.Read() Then
                            lblTotalStocks.Text = If(IsDBNull(reader("TotalRemainingQty")), "0", reader("TotalRemainingQty").ToString())
                            lblLowStocks.Text = If(IsDBNull(reader("LowStocks")), "0", reader("LowStocks").ToString())
                            lblOutOfStock.Text = If(IsDBNull(reader("OutOfStock")), "0", reader("OutOfStock").ToString())
                        Else
                            lblTotalStocks.Text = "0"
                            lblLowStocks.Text = "0"
                            lblOutOfStock.Text = "0"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Optional: log error
        End Try
    End Sub











    ' ==============================
    '       ROUNDED CORNERS
    ' ==============================
    Private Sub ApplyRoundedCorners()
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90)
        path.AddLine(CornerRadius, 0, Me.Width - CornerRadius, 0)
        path.AddArc(Me.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90)
        path.AddLine(Me.Width, CornerRadius, Me.Width, Me.Height - CornerRadius)
        path.AddArc(Me.Width - CornerRadius, Me.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90)
        path.AddLine(Me.Width - CornerRadius, Me.Height, CornerRadius, Me.Height)
        path.AddArc(0, Me.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90)
        path.AddLine(0, Me.Height - CornerRadius, 0, CornerRadius)
        path.CloseFigure()
        Me.Region = New Region(path)
        Me.Invalidate()
    End Sub

    ' ==============================
    '       EXPORT TO PDF
    ' ==============================
    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' ✅ Apply A4 every time before preview
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
            printDoc.DefaultPageSettings.Margins = New Margins(50, 50, 50, 50)
            printDoc.DefaultPageSettings.Landscape = False

            ' Create the PrintPreviewDialog instance
            Using preview As New PrintPreviewDialog()
                preview.Document = printDoc
                preview.Width = 1000
                preview.Height = 800

                ' Center the PrintPreviewDialog on the screen
                preview.StartPosition = FormStartPosition.CenterScreen

                ' Show the preview dialog
                preview.ShowDialog()
            End Using

            ' Now exporting to PDF
            Using sfd As New SaveFileDialog()
                sfd.Filter = "PDF Files|*.pdf"
                sfd.Title = "Save Stock Report as PDF"
                sfd.FileName = reportTitle.Replace(" ", "_") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"

                If sfd.ShowDialog() = DialogResult.OK Then
                    printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF"
                    printDoc.PrinterSettings.PrintToFile = True
                    printDoc.PrinterSettings.PrintFileName = sfd.FileName
                    printDoc.PrintController = New StandardPrintController()

                    ' ✅ Apply A4 before printing to PDF
                    printDoc.DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
                    printDoc.Print()

                    MessageBox.Show("Report saved to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LogAuditTrail(SessionData.role, SessionData.fullName, $"Exported {reportTitle} to PDF: {sfd.FileName}")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to export PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' ==============================
    '       EXPORT TO CSV
    ' ==============================
    Private Sub btnExportToCSV_Click(sender As Object, e As EventArgs) Handles btnExportToCSV.Click
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Using sfd As New SaveFileDialog()
                sfd.Filter = "CSV Files (*.csv)|*.csv"
                sfd.Title = "Save Stock Report as CSV"
                sfd.FileName = reportTitle.Replace(" ", "_") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Using sw As New StreamWriter(sfd.FileName)
                        ' Header
                        For i As Integer = 0 To dt.Columns.Count - 1
                            sw.Write(dt.Columns(i).ColumnName)
                            If i < dt.Columns.Count - 1 Then sw.Write(",")
                        Next
                        sw.WriteLine()

                        ' Rows
                        For Each row As DataRow In dt.Rows
                            For i As Integer = 0 To dt.Columns.Count - 1
                                Dim value As String = row(i).ToString()
                                If value.Contains(",") Then value = $"""{value}"""
                                sw.Write(value)
                                If i < dt.Columns.Count - 1 Then sw.Write(",")
                            Next
                            sw.WriteLine()
                        Next
                    End Using

                    MessageBox.Show("Stock Report exported to CSV successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LogAuditTrail(SessionData.role, SessionData.fullName, $"Exported {reportTitle} to CSV: {sfd.FileName}")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to export CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' ===== PRINT PAGE =====

    Private rowsPerPage As Integer = 30 ' <-- adjustable per page

    ' ==============================
    '       PRINT PAGE LOGIC
    ' ==============================
    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs)
        ' ===== DETERMINE SOURCE =====
        Dim sourceTable As DataTable = TryCast(dgvStock.DataSource, DataTable)

        ' Ensure there is data to print
        If sourceTable Is Nothing OrElse sourceTable.Rows.Count = 0 Then
            MessageBox.Show("No data available to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' ===== FONTS =====
        Dim storeFont As New Font("Arial", 15, FontStyle.Bold)
        Dim addressFont As New Font("Arial", 11)
        Dim titleFont As New Font("Arial", 13, FontStyle.Bold)
        Dim headerFont As New Font("Arial", 9, FontStyle.Bold)
        Dim cellFont As New Font("Arial", 9)
        Dim footerFont As New Font("Arial", 9)

        ' ===== HEADER =====
        Dim yPos As Single = e.MarginBounds.Top
        Dim centerX As Single = e.MarginBounds.Left + (e.MarginBounds.Width / 2)

        ' Store Name
        Dim storeName As String = "TALLER STORE"
        Dim textWidth As Single = e.Graphics.MeasureString(storeName, storeFont).Width
        e.Graphics.DrawString(storeName, storeFont, Brushes.Black, centerX - textWidth / 2, yPos)
        yPos += storeFont.GetHeight() + 5

        ' Address
        Dim addr1 As String = "G326+XM6, Rd. 11, Maguindanao St"
        textWidth = e.Graphics.MeasureString(addr1, addressFont).Width
        e.Graphics.DrawString(addr1, addressFont, Brushes.Black, centerX - textWidth / 2, yPos)
        yPos += addressFont.GetHeight() + 2

        Dim addr2 As String = "Prk. 3 Brgy, Taguig, Metro Manila"
        textWidth = e.Graphics.MeasureString(addr2, addressFont).Width
        e.Graphics.DrawString(addr2, addressFont, Brushes.Black, centerX - textWidth / 2, yPos)
        yPos += addressFont.GetHeight() + 15

        ' Report Title
        Dim reportTitle As String = "STOCK REPORT"
        textWidth = e.Graphics.MeasureString(reportTitle, titleFont).Width
        e.Graphics.DrawString(reportTitle, titleFont, Brushes.Black, centerX - textWidth / 2, yPos)
        yPos += titleFont.GetHeight() + 20

        ' ===== TABLE HEADERS =====
        Dim colWidths() As Single = {170, 140, 120, 100, 75, 75, 100}
        ' Replace Quantity with RemainingQty
        Dim headers() As String = {"BatchNumber", "Supplier", "ProductName", "RemainingQty", "CostPrice", "UnitPrice", "ExpirationDate"}

        ' Total width of all columns
        Dim totalTableWidth As Single = colWidths.Sum()
        ' Center the table horizontally
        Dim startX As Single = e.MarginBounds.Left + ((e.MarginBounds.Width - totalTableWidth) / 2)

        ' Draw the header row
        Dim colX As Single = startX
        Dim rowHeight As Single = 28
        For i As Integer = 0 To headers.Length - 1
            Dim headerTextWidth As Single = e.Graphics.MeasureString(headers(i), headerFont).Width
            Dim headerCenterX As Single = colX + (colWidths(i) / 2) - (headerTextWidth / 2)

            e.Graphics.FillRectangle(Brushes.LightGray, colX, yPos, colWidths(i), rowHeight)
            e.Graphics.DrawRectangle(Pens.Black, colX, yPos, colWidths(i), rowHeight)
            e.Graphics.DrawString(headers(i), headerFont, Brushes.Black, headerCenterX, yPos + 6)

            colX += colWidths(i)
        Next
        yPos += rowHeight

        ' ===== PRINT ROWS =====
        Dim rowsPerPage As Integer = 30
        Dim startRow As Integer = (printPageNumber - 1) * rowsPerPage
        Dim endRow As Integer = Math.Min(startRow + rowsPerPage, sourceTable.Rows.Count)

        For i As Integer = startRow To endRow - 1
            colX = startX
            For j As Integer = 0 To headers.Length - 1
                Dim cellValue As Object = sourceTable.Rows(i)(headers(j))
                Dim cellText As String = ""

                ' Format numeric and date columns
                If headers(j).ToLower().Contains("price") AndAlso IsNumeric(cellValue) Then
                    cellText = Format(CDec(cellValue), "0.00")
                ElseIf headers(j).ToLower().Contains("remainingqty") AndAlso IsNumeric(cellValue) Then
                    cellText = Format(CDec(cellValue), "#,##0")
                ElseIf headers(j).ToLower().Contains("expiration") AndAlso IsDate(cellValue) Then
                    cellText = Format(CDate(cellValue), "yyyy-MM-dd")
                Else
                    cellText = If(cellValue IsNot Nothing, cellValue.ToString(), "")
                End If

                Dim cellTextWidth As Single = e.Graphics.MeasureString(cellText, cellFont).Width
                Dim cellCenterX As Single = colX + (colWidths(j) / 2) - (cellTextWidth / 2)
                e.Graphics.FillRectangle(Brushes.White, colX, yPos, colWidths(j), rowHeight)
                e.Graphics.DrawRectangle(Pens.Black, colX, yPos, colWidths(j), rowHeight)
                e.Graphics.DrawString(cellText, cellFont, Brushes.Black, cellCenterX, yPos + 6)

                colX += colWidths(j)
            Next
            yPos += rowHeight
        Next

        ' ===== FOOTER =====
        e.Graphics.DrawString($"Page {printPageNumber} of {totalPages}", footerFont, Brushes.Black, e.MarginBounds.Left, e.PageBounds.Bottom - 40)

        ' ===== PAGINATION =====
        printPageNumber += 1
        e.HasMorePages = (startRow + rowsPerPage < sourceTable.Rows.Count)
        If Not e.HasMorePages Then
            printPageNumber = 1
        End If
    End Sub



    ' ==============================
    '       AUDIT LOG HELPER
    ' ==============================
    Private Sub LogAuditTrail(ByVal role As String, ByVal fullName As String, ByVal action As String)
        Try
            Using connection As New MySqlConnection(connectionstring)
                connection.Open()
                Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@Role, @FullName, @Action, @Form, @Date)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@Action", action)
                    cmd.Parameters.AddWithValue("@Form", "Stock Report")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==============================
    '       SEARCH FILTER
    ' ==============================
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' Get the search text and prepare a temporary table
        Dim searchText As String = txtSearch.Text.Trim().ToLower()
        Dim tempTable As DataTable = dt.Clone()

        ' If search text is empty, show the full data and reset row styles
        If String.IsNullOrEmpty(searchText) Then
            For Each row As DataRow In dt.Rows
                tempTable.ImportRow(row)
            Next
            dgvStock.DataSource = tempTable

            ' Reset row styles when the search box is cleared
            For Each row As DataGridViewRow In dgvStock.Rows
                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.SelectionBackColor = Color.White ' Remove the orange highlight
                row.DefaultCellStyle.SelectionForeColor = Color.Black
            Next
            Return
        End If

        ' Filter the rows using LINQ based on the search text
        Dim filteredRows = dt.AsEnumerable().Where(Function(r) _
        r("BarcodeID").ToString().ToLower().Contains(searchText) OrElse
        r("Supplier").ToString().ToLower().Contains(searchText) OrElse
        r("ProductName").ToString().ToLower().Contains(searchText)
    )

        ' Add the filtered rows to the temporary table
        For Each row In filteredRows
            tempTable.ImportRow(row)
        Next

        ' Bind the filtered data to the DataGridView
        dgvStock.DataSource = tempTable

        ' Apply custom row colors for filtered data
        For Each row As DataGridViewRow In dgvStock.Rows
            row.DefaultCellStyle.BackColor = Color.LightYellow
            row.DefaultCellStyle.SelectionBackColor = Color.Orange ' Reapply the orange highlight
            row.DefaultCellStyle.SelectionForeColor = Color.Black
        Next
    End Sub



    ' ==============================
    '       PAGINATION BUTTON HANDLERS
    ' ==============================
    Private Sub btnDecrease_Click(sender As Object, e As EventArgs) Handles btnDecrease.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadStockReports() ' Reload data for the previous page
        End If
    End Sub

    Private Sub btnIncrease_Click(sender As Object, e As EventArgs) Handles btnincrease.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadStockReports() ' Reload data for the next page
        End If
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




        ' === OPTIONAL: CENTER THE FORM ON SCREEN ===
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

End Class
