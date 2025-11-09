Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Timers


Public Class SaleReport

    ' ===== Pagination =====
    Private currentPage As Integer = 1
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 1

    Private printData As DataTable
    Private reportTitle As String = "Daily Sales Report"
    Private WithEvents printDoc As New Printing.PrintDocument()


    Private isFirstLoad As Boolean = True
    Private isUpdatingDates As Boolean = False


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
    Private Sub SaleReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpStart.Value = DateTime.Now
        dtpEnd.Value = DateTime.Now
        dtpEnd.Visible = True

        SetupDataGridView()
        UpdateDateLabel()
        LoadSalesReport()

        isFirstLoad = False
        Me.StartPosition = FormStartPosition.CenterScreen

        dtpStart.FillColor = ColorTranslator.FromHtml("#0B2447")
        dtpEnd.FillColor = ColorTranslator.FromHtml("#0B2447")

        ' ===== DataGridView =====
        dgvAllReports.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== ComboBox =====
        cmbReportType.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== DateTimePickers =====
        dtpStart.Font = New Font("Outfit", 9, FontStyle.Regular)
        dtpEnd.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== Buttons =====
        btnExportToPDF.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnExportToCSV.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnincrease.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnDecrease.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== Labels / HtmlLabels =====
        Guna2HtmlLabel1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Guna2HtmlLabel2.Font = New Font("Outfit", 9, FontStyle.Bold)
        Guna2HtmlLabel3.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblPeriod.Font = New Font("Outfit", 17, FontStyle.Bold)
        lblDate.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblPage.Font = New Font("Outfit", 9, FontStyle.Bold)


        LoadTotalSalesAndProfit()
        dynamicTimer.AutoReset = True
        dynamicTimer.Enabled = True


    End Sub

    ' ===== UPDATE LABEL =====
    Private Sub UpdateDateLabel()
        Dim dayDifference As Integer = (dtpEnd.Value.Date - dtpStart.Value.Date).Days
        Dim periodText As String = If(dayDifference = 0, "Daily Sales",
                                      If(dayDifference >= 7 AndAlso dayDifference < 30, "Weekly Sales",
                                      If(dayDifference >= 30 AndAlso dayDifference < 365, "Monthly Sales",
                                      If(dayDifference >= 365, "Yearly Sales", "Sales Summary"))))
        lblPeriod.Text = periodText
        reportTitle = periodText & " Report"

        If dtpStart.Value.Date = dtpEnd.Value.Date Then
            lblDate.Text = dtpStart.Value.ToString("MMMM dd, yyyy")
        Else
            lblDate.Text = $"{dtpStart.Value:MMMM dd, yyyy} - {dtpEnd.Value:MMMM dd, yyyy}"
        End If

        lblPage.Text = $"Page {currentPage} / {totalPages}"
    End Sub


    '' ===== Declare Timer at class level =====
    Private WithEvents dynamicTimer As New Timers.Timer(1000) ' 2 seconds interval (adjustable)

    Private lastTotalSales As Decimal = -1D
    Private lastTotalProfit As Decimal = -1D


    ' ===== LOAD SALES DATA =====
    Private Sub LoadSalesReport(Optional showNoSalesMessage As Boolean = True)
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' ===== Format start and end datetimes =====
                Dim startDate As String = dtpStart.Value.ToString("yyyy-MM-dd 00:00:00")
                Dim endDate As String = dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59")

                ' ===== Count total records =====
                Dim countQuery As String = "SELECT COUNT(*) FROM sales s " &
                                       "JOIN sales_items si ON s.SaleID = si.SaleID " &
                                       "WHERE s.SaleDate BETWEEN @StartDate AND @EndDate"
                Using cmdCount As New MySqlCommand(countQuery, conn)
                    cmdCount.Parameters.AddWithValue("@StartDate", startDate)
                    cmdCount.Parameters.AddWithValue("@EndDate", endDate)
                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar())
                    totalPages = Math.Max(Math.Ceiling(totalRecords / rowsPerPage), 1)
                End Using

                ' ===== Paginated data =====
                Dim offset As Integer = (currentPage - 1) * rowsPerPage
                Dim query As String = "SELECT s.ReceiptNo, s.TransactionNo, " &
                                  "IFNULL(DATE_FORMAT(s.SaleDate, '%Y-%m-%d %h:%i:%s %p'), '') AS SaleDate, " &
                                  "s.Cashier, si.ProductName, si.Quantity, " &
                                  "si.TotalPrice, si.SaleType " &
                                  "FROM sales s " &
                                  "JOIN sales_items si ON s.SaleID = si.SaleID " &
                                  "WHERE s.SaleDate BETWEEN @StartDate AND @EndDate " &
                                  "ORDER BY s.SaleDate ASC " &
                                  "LIMIT @RowsPerPage OFFSET @Offset"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StartDate", startDate)
                    cmd.Parameters.AddWithValue("@EndDate", endDate)
                    cmd.Parameters.AddWithValue("@RowsPerPage", rowsPerPage)
                    cmd.Parameters.AddWithValue("@Offset", offset)

                    Dim dt As New DataTable()
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        dgvAllReports.DataSource = dt
                    End Using
                End Using

                ' ===== Set column widths =====
                If dgvAllReports.Columns.Contains("ReceiptNo") Then dgvAllReports.Columns("ReceiptNo").Width = 120
                If dgvAllReports.Columns.Contains("TransactionNo") Then dgvAllReports.Columns("TransactionNo").Width = 120
                If dgvAllReports.Columns.Contains("SaleDate") Then dgvAllReports.Columns("SaleDate").Width = 150
                If dgvAllReports.Columns.Contains("ProductName") Then dgvAllReports.Columns("ProductName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                ' Hide the columns BarcodeID and UnitPrice in the DataGridView
                If dgvAllReports.Columns.Contains("BarcodeID") Then dgvAllReports.Columns("BarcodeID").Visible = False
                If dgvAllReports.Columns.Contains("UnitPrice") Then dgvAllReports.Columns("UnitPrice").Visible = False
                If dgvAllReports.Columns.Contains("SaleType") Then dgvAllReports.Columns("SaleType").Visible = False


                ' ===== Load full dataset for printing =====
                Dim fullQuery As String = "SELECT s.ReceiptNo, s.TransactionNo, " &
                                      "IFNULL(DATE_FORMAT(s.SaleDate, '%Y-%m-%d %h:%i:%s %p'), '') AS SaleDate, " &
                                      "s.Cashier, si.ProductName, si.Quantity, " &
                                      "si.TotalPrice, si.SaleType " &
                                      "FROM sales s " &
                                      "JOIN sales_items si ON s.SaleID = si.SaleID " &
                                      "WHERE s.SaleDate BETWEEN @StartDate AND @EndDate " &
                                      "ORDER BY s.SaleDate ASC"

                Using cmdFull As New MySqlCommand(fullQuery, conn)
                    cmdFull.Parameters.AddWithValue("@StartDate", startDate)
                    cmdFull.Parameters.AddWithValue("@EndDate", endDate)

                    Dim dtFull As New DataTable()
                    Using adapterFull As New MySqlDataAdapter(cmdFull)
                        adapterFull.Fill(dtFull)
                        printData = dtFull
                    End Using
                End Using


                ' ===== Update pagination label =====
                lblPage.Text = $"Page {currentPage} / {totalPages}"


            End Using
        Catch ex As Exception
            If showNoSalesMessage Then
                MessageBox.Show("Error loading sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub dynamicTimer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles dynamicTimer.Elapsed
        CheckForSalesChanges()
    End Sub

    Private Sub CheckForSalesChanges()
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                Dim query As String = "
                    SELECT 
                        IFNULL(SUM(si.TotalPrice), 0) AS TotalSales
                    FROM sales s
                    JOIN sales_items si ON s.SaleID = si.SaleID"

                Using cmd As New MySqlCommand(query, conn)
                    Dim newTotal As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())

                    ' Check if total changed
                    If newTotal <> lastTotalSales Then
                        lastTotalSales = newTotal
                        ' Invoke UI update safely
                        Me.Invoke(Sub()
                                      lblTotalSales.Text = " " & newTotal.ToString("N2")
                                  End Sub)
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' optional: log or ignore minor errors
        End Try
    End Sub

    Private Sub LoadTotalSalesAndProfit()
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' ===== Total Sales =====
                Dim salesQuery As String = "
                SELECT IFNULL(SUM(si.TotalPrice), 0) AS TotalSales
                FROM sales s
                JOIN sales_items si ON s.SaleID = si.SaleID;
            "

                Dim totalSales As Decimal
                Using cmd As New MySqlCommand(salesQuery, conn)
                    totalSales = Convert.ToDecimal(cmd.ExecuteScalar())
                    lblTotalSales.Text = totalSales.ToString("N2")
                    lastTotalSales = totalSales
                End Using

                ' ===== Total Profit =====
                Dim profitQuery As String = "
                SELECT IFNULL(SUM(si.Quantity * (si.UnitPrice - d.CostPrice)), 0) AS TotalProfit
                FROM sales_items si
                JOIN (
                    SELECT BarcodeID, AVG(CostPrice) AS CostPrice
                    FROM deliveries
                    GROUP BY BarcodeID
                ) d ON si.BarcodeID = d.BarcodeID;
            "

                Dim totalProfit As Decimal
                Using cmd As New MySqlCommand(profitQuery, conn)
                    totalProfit = Convert.ToDecimal(cmd.ExecuteScalar())
                    lblTotalProfit.Text = totalProfit.ToString("N2")
                End Using

            End Using
        Catch ex As Exception
            lblTotalSales.Text = "0.00"
            lblTotalProfit.Text = "0.00"
        End Try
    End Sub













    ' ===== SETUP DATAGRIDVIEW =====
    Private Sub SetupDataGridView()
        With dgvAllReports
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 35
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    ' ===== DATE CHANGE EVENTS =====
    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        If isUpdatingDates Then Return
        isUpdatingDates = True
        currentPage = 1
        UpdateDateLabel()
        LoadSalesReport(False)
        isUpdatingDates = False
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        If isUpdatingDates Then Return
        isUpdatingDates = True
        UpdateDateLabel()
        LoadSalesReport(False)
        isUpdatingDates = False
    End Sub

    ' ===== PAGINATION =====
    Private Sub btnDecrease_Click(sender As Object, e As EventArgs) Handles btnDecrease.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadSalesReport(False)
            UpdatePageDisplay()
        End If
    End Sub

    Private Sub btnIncrease_Click(sender As Object, e As EventArgs) Handles btnincrease.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadSalesReport(False)
            UpdatePageDisplay()
        End If
    End Sub

    Private Sub UpdatePageDisplay()
        lblPage.Text = $"Page {currentPage} / {totalPages}"
    End Sub

    ' ===== CLOSE FORM =====
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
        Me.Close()
    End Sub

    ' ===== EXPORT TO PDF =====
    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        ' Check if there is anything to print
        If printData.Rows.Count <= 0 Then
            MessageBox.Show("No data available to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' === SETUP PRINT ===
            reportTitle = lblPeriod.Text & " Report"
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
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



            ' ===== 2. Show SaveFileDialog AFTER preview =====
            Using sfd As New SaveFileDialog()
                sfd.Filter = "PDF Files|*.pdf"
                sfd.Title = "Save report as PDF"
                sfd.FileName = reportTitle.Replace(" ", "_") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"

                If sfd.ShowDialog() = DialogResult.OK Then
                    ' Configure Microsoft Print to PDF
                    printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF"
                    printDoc.PrinterSettings.PrintToFile = True
                    printDoc.PrinterSettings.PrintFileName = sfd.FileName

                    ' Avoid extra print dialogs
                    printDoc.PrintController = New Printing.StandardPrintController()

                    ' Print directly to PDF
                    printDoc.Print()

                    ' Show success message
                    MessageBox.Show("Report saved to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' --- AUDIT TRAIL ---
                    LogAuditTrail(SessionData.role, SessionData.fullName, $"Exported {reportTitle} to PDF: {sfd.FileName}")
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Failed to export PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub






    ' ===== PRINT PAGE =====
    Private printPageNumber As Integer = 1
    Private rowsPerPage As Integer = 30 ' <-- adjustable per page

    Private Sub printDoc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles printDoc.PrintPage

        ' ===== FONTS =====
        Dim storeFont As New Font("Arial", 15, FontStyle.Bold)
        Dim addressFont As New Font("Arial", 13)
        Dim titleFont As New Font("Arial", 15, FontStyle.Bold)
        Dim dateFont As New Font("Arial", 9)
        Dim dgvHeaderFont As New Font("Arial", 8, FontStyle.Bold)
        Dim dgvCellFont As New Font("Arial", 8)
        Dim footerFont As New Font("Arial", 9)

        ' ===== HEADER =====
        Dim yPos As Integer = e.MarginBounds.Top
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
        e.Graphics.DrawString(reportTitle, titleFont, Brushes.Black, centerX - (textWidth / 2), yPos + 2)
        yPos += titleFont.GetHeight() + 25

        ' Date
        Dim dateText As String = "Date: " & lblDate.Text
        Dim dateTextWidth As Single = e.Graphics.MeasureString(dateText, dateFont).Width
        Dim dateX As Single = e.MarginBounds.Right - dateTextWidth + 20
        e.Graphics.DrawString(dateText, dateFont, Brushes.Black, dateX, yPos)
        yPos += dateFont.GetHeight() + 10

        ' ===== TABLE SETUP =====
        Dim columnsToPrint As New List(Of DataColumn)
        For Each col As DataColumn In printData.Columns
            ' Skip only columns that are explicitly hidden
            If col.ColumnName <> "BarcodeID" AndAlso col.ColumnName <> "UnitPrice" AndAlso col.ColumnName <> "SaleType" Then
                columnsToPrint.Add(col)
            End If
        Next

        Dim colWidths As New Dictionary(Of String, Integer) From {
        {"ReceiptNo", 120},
        {"TransactionNo", 140},
        {"SaleDate", 160},
        {"Cashier", 120},
        {"ProductName", 120},
        {"Discount", 80},
        {"Total", 80},
        {"Payment", 80}
    }

        Dim defaultWidth As Integer = 70
        Dim rowHeight As Integer = dgvCellFont.GetHeight() + 14
        Dim totalWidth As Integer = columnsToPrint.Sum(Function(c) If(colWidths.ContainsKey(c.ColumnName), colWidths(c.ColumnName), defaultWidth))
        Dim pageCenter As Integer = e.MarginBounds.Left + (e.MarginBounds.Width \ 2)
        Dim xStart As Integer = pageCenter - (totalWidth \ 2)
        Dim xPos As Integer = xStart

        ' ===== HEADER ROW =====
        For Each col As DataColumn In columnsToPrint
            Dim width As Integer = If(colWidths.ContainsKey(col.ColumnName), colWidths(col.ColumnName), defaultWidth)
            e.Graphics.FillRectangle(Brushes.LightGray, xPos, yPos, width, rowHeight)
            e.Graphics.DrawRectangle(Pens.Black, xPos, yPos, width, rowHeight)

            ' Center header text
            Dim headerTextWidth As Single = e.Graphics.MeasureString(col.ColumnName, dgvHeaderFont).Width
            Dim headerCenterX As Single = xPos + (width / 2) - (headerTextWidth / 2)
            e.Graphics.DrawString(col.ColumnName, dgvHeaderFont, Brushes.Black, headerCenterX, yPos + (rowHeight - dgvHeaderFont.GetHeight()) / 2)
            xPos += width
        Next
        yPos += rowHeight

        ' ===== PAGINATION =====
        Dim totalRecords As Integer = printData.Rows.Count
        Dim totalPages As Integer = Math.Ceiling(totalRecords / rowsPerPage)
        Dim startRow As Integer = (printPageNumber - 1) * rowsPerPage
        Dim endRow As Integer = Math.Min(startRow + rowsPerPage, totalRecords)

        ' ===== PRINT ROWS =====
        For rowIndex As Integer = startRow To endRow - 1
            xPos = xStart
            Dim rowBrush As Brush = If(rowIndex Mod 2 = 0, Brushes.White, Brushes.WhiteSmoke)

            For Each col As DataColumn In columnsToPrint
                Dim width As Integer = If(colWidths.ContainsKey(col.ColumnName), colWidths(col.ColumnName), defaultWidth)
                Dim cellValue As String = If(printData.Rows(rowIndex)(col) IsNot Nothing, printData.Rows(rowIndex)(col).ToString(), "")

                ' Format money columns
                If col.ColumnName.ToLower().Contains("price") OrElse col.ColumnName.ToLower().Contains("total") _
            OrElse col.ColumnName.ToLower().Contains("discount") OrElse col.ColumnName.ToLower().Contains("payment") Then
                    If IsNumeric(cellValue) Then
                        cellValue = Format(CDec(cellValue), "₱#,##0.00")
                    End If
                End If

                e.Graphics.FillRectangle(rowBrush, xPos, yPos, width, rowHeight)
                e.Graphics.DrawRectangle(Pens.Black, xPos, yPos, width, rowHeight)

                Dim cellTextWidth As Single = e.Graphics.MeasureString(cellValue, dgvCellFont).Width
                Dim cellCenterX As Single = xPos + (width / 2) - (cellTextWidth / 2)
                e.Graphics.DrawString(cellValue, dgvCellFont, Brushes.Black, cellCenterX, yPos + (rowHeight - dgvCellFont.GetHeight()) / 2)

                xPos += width
            Next
            yPos += rowHeight
        Next

        ' ===== TOTAL SALES ONLY (Right aligned) =====
        Dim totalSales As Decimal = 0
        For Each row As DataRow In printData.Rows
            Dim totalPrice As Decimal = If(row.Table.Columns.Contains("TotalPrice") AndAlso row("TotalPrice") IsNot DBNull.Value, Convert.ToDecimal(row("TotalPrice")), 0)
            totalSales += totalPrice
        Next

        Dim totalsY As Integer = yPos + 10

        Dim totalText As String = "Total Sales: " & Format(totalSales, "₱#,##0.00")
        Dim totalTextWidth As Single = e.Graphics.MeasureString(totalText, dgvCellFont).Width
        Dim totalX As Single = e.MarginBounds.Right - totalTextWidth ' Align right

        e.Graphics.DrawString(totalText, dgvCellFont, Brushes.Black, totalX, totalsY)

        ' ===== FOOTER =====
        e.Graphics.DrawString($"Page {printPageNumber} of {totalPages}", footerFont, Brushes.Black, e.MarginBounds.Left, e.PageBounds.Bottom - 40)

        ' ===== PAGINATION LOGIC =====
        printPageNumber += 1
        If printPageNumber <= totalPages Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            printPageNumber = 1
        End If

    End Sub











    Private Sub btnExportToCSV_Click(sender As Object, e As EventArgs) Handles btnExportToCSV.Click
        ' --- Ensure there is data to export ---
        If printData Is Nothing OrElse printData.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' --- Show SaveFileDialog ---
            Using sfd As New SaveFileDialog()
                sfd.Filter = "CSV Files (*.csv)|*.csv"
                sfd.Title = "Save Sales Report as CSV"
                sfd.FileName = reportTitle.Replace(" ", "_") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Using sw As New IO.StreamWriter(sfd.FileName)
                        ' --- Write header ---
                        For i As Integer = 0 To printData.Columns.Count - 1
                            sw.Write(printData.Columns(i).ColumnName)
                            If i < printData.Columns.Count - 1 Then sw.Write(",")
                        Next
                        sw.WriteLine()

                        ' --- Write rows ---
                        For Each row As DataRow In printData.Rows
                            For i As Integer = 0 To printData.Columns.Count - 1
                                Dim value As String = row(i).ToString()

                                ' Format dates properly
                                If printData.Columns(i).ColumnName.ToLower().Contains("date") AndAlso IsDate(value) Then
                                    value = Format(CDate(value), "yyyy-MM-dd")
                                End If

                                ' Escape commas inside values
                                If value.Contains(",") Then value = $"""{value}"""

                                sw.Write(value)
                                If i < printData.Columns.Count - 1 Then sw.Write(",")
                            Next
                            sw.WriteLine()
                        Next
                    End Using

                    ' --- Success message ---
                    MessageBox.Show("Sales Report exported to CSV successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' --- AUDIT TRAIL ---
                    LogAuditTrail(SessionData.role, SessionData.fullName, $"Exported {reportTitle} to CSV: {sfd.FileName}")
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Failed to export CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                    cmd.Parameters.AddWithValue("@Form", "Sales Report")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



End Class
