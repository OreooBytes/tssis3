Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class ViewReturn

    Private Const CornerRadius As Integer = 10 ' fixed radius

    Private Sub ViewReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpStart.FillColor = ColorTranslator.FromHtml("#0B2447")
        dtpEnd.FillColor = ColorTranslator.FromHtml("#0B2447")
        BackColor = ColorTranslator.FromHtml("#0B2447")

        dtpStart.Value = DateTime.Today
        dtpEnd.Value = DateTime.Today

        ApplyRoundedCorners()
        LoadReturnItems()
        SetupDataGridView()

        ' ==== DateTimePickers (Bold) ====
        dtpStart.Font = New Font("Outfit", 9, FontStyle.Bold)
        dtpEnd.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ==== Guna2HtmlLabels (Bold) ====
        Guna2HtmlLabel1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Guna2HtmlLabel2.Font = New Font("Outfit", 9, FontStyle.Bold)



        ' ==== DataGridView (Regular) ====
        dgvReturnList.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== Panel (no font needed) ====
        Guna2Panel1.BackColor = Color.Gainsboro

    End Sub


    ' --- Load Data Based on Optional Date Range ---
    Private Sub LoadReturnItems(Optional ByVal startDate As Date? = Nothing, Optional ByVal endDate As Date? = Nothing)
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' --- Default to today if no dates provided ---
                Dim sDate As Date = If(startDate.HasValue, startDate.Value.Date, DateTime.Today)
                Dim eDate As Date = If(endDate.HasValue, endDate.Value.Date, DateTime.Today)

                ' --- Swap if startDate > endDate ---
                If sDate > eDate Then
                    Dim temp As Date = sDate
                    sDate = eDate
                    eDate = temp
                End If

                ' --- 24-hour datetime format for MySQL ---
                Dim sDateStr As String = sDate.ToString("yyyy-MM-dd 00:00:00")
                Dim eDateStr As String = eDate.ToString("yyyy-MM-dd 23:59:59")

                Dim query As String =
"SELECT ri.ReturnID, ri.BarcodeID, d.ProductName,
        s.CompanyName AS SupplierCompany,
        ri.ReturnDate, ri.QuantityReturned,
        ri.Reason, ri.ConditionStatus, ri.Remarks
 FROM returnitems ri
 INNER JOIN deliveries d ON ri.DeliveryID = d.id
 INNER JOIN supplier s ON ri.SupplierID = s.SupplierID
 WHERE ri.ReturnDate BETWEEN @startDate AND @endDate
 ORDER BY ri.ReturnDate DESC"


                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@startDate", sDateStr)
                    cmd.Parameters.AddWithValue("@endDate", eDateStr)

                    Dim dt As New DataTable
                    dt.Load(cmd.ExecuteReader())
                    dgvReturnList.DataSource = dt

                    ' --- Stable row height and column sizing ---
                    dgvReturnList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                    dgvReturnList.RowTemplate.Height = 35
                    dgvReturnList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                    ' --- Hide unnecessary columns ---
                    If dgvReturnList.Columns.Contains("ReturnID") Then dgvReturnList.Columns("ReturnID").Visible = False
                    If dgvReturnList.Columns.Contains("Remarks") Then dgvReturnList.Columns("Remarks").Visible = False
                    If dgvReturnList.Columns.Contains("ConditionStatus") Then dgvReturnList.Columns("ConditionStatus").Visible = False
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading return items: " & ex.Message)
        End Try
    End Sub

    ' --- Refresh when date pickers change ---
    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        LoadReturnItems(dtpStart.Value, dtpEnd.Value)
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        LoadReturnItems(dtpStart.Value, dtpEnd.Value)
    End Sub

    ' ✅ UI Rounded Corners (Keep your design)
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

    ' ===== SETUP DATAGRIDVIEW =====
    Private Sub SetupDataGridView()
        With dgvReturnList
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

    '========= FOR ALT F4 =========
    Private Sub ViewReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt AndAlso e.KeyCode = Keys.F4 Then
            e.Handled = True
        End If
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Alt Or Keys.F4) Then
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?",
           "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()

        End If
    End Sub


End Class
