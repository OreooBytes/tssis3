Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class ViewRefund

    Private Const CornerRadius As Integer = 10 ' fixed radius


    ' === Load Return Data with 12-hour datetime range ===
    Private Sub LoadReturnData(Optional ByVal startDate As Date? = Nothing, Optional ByVal endDate As Date? = Nothing)
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

                ' --- Use 24-hour format for MySQL datetime ---
                Dim sDateStr As String = sDate.ToString("yyyy-MM-dd 00:00:00")
                Dim eDateStr As String = eDate.ToString("yyyy-MM-dd 23:59:59")

                ' --- Query customer returns within the range ---
                Dim query As String =
                "SELECT ReturnID, TransactionNumber, BarcodeID, ReturnDate, QuantityPurchased, QuantityReturned, Reason, ConditionStatus, ApprovedBy, ReturnedToInventory " &
                "FROM customerreturns " &
                "WHERE ReturnDate >= @startDate AND ReturnDate <= @endDate " &
                "ORDER BY ReturnDate DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@startDate", sDateStr)
                    cmd.Parameters.AddWithValue("@endDate", eDateStr)

                    Dim dt As New DataTable()
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using

                    dgvRefund.DataSource = dt

                    ' --- Hide ReturnID column ---
                    If dgvRefund.Columns.Contains("ReturnID") Then
                        dgvRefund.Columns("ReturnID").Visible = False
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading return records: " & ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub SetupDataGridView()

        ' === Hide PullOutID column ===
        If dgvRefund.Columns.Contains("ReturnID") Then
            dgvRefund.Columns("ReturnID").Visible = False
        End If

        With dgvRefund
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

        End With
    End Sub

    ' === DateTimePicker Event Handlers ===
    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        LoadReturnData(dtpStartDate.Value, dtpEndDate.Value)
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        LoadReturnData(dtpStartDate.Value, dtpEndDate.Value)
    End Sub

    ' === Form Load ===
    Private Sub ViewRefund_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' --- UI Styling ---
        dtpStartDate.FillColor = ColorTranslator.FromHtml("#0B2447")
        dtpEndDate.FillColor = ColorTranslator.FromHtml("#0B2447")
        BackColor = ColorTranslator.FromHtml("#0B2447")

        dtpStartDate.Font = New Font("Outfit", 8, FontStyle.Bold)
        dtpEndDate.Font = New Font("Outfit", 8, FontStyle.Bold)

        ' ===== DataGridView =====
        dgvRefund.Font = New Font("Outfit", 9, FontStyle.Regular)

        ApplyRoundedCorners()

        SetupDataGridView()

        dtpStartDate.Value = DateTime.Today
        dtpEndDate.Value = DateTime.Today

        LoadReturnData()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub
End Class
