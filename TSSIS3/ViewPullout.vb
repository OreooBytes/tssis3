Imports System.Data
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class ViewPullout

    Private Const CornerRadius As Integer = 10 ' fixed radius

    Private Sub ViewPullout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- UI Styling ---
        dtpStartDate.FillColor = ColorTranslator.FromHtml("#0B2447")
        dtpEndDate.FillColor = ColorTranslator.FromHtml("#0B2447")
        BackColor = ColorTranslator.FromHtml("#0B2447")

        dtpStartDate.Font = New Font("Outfit", 8, FontStyle.Bold)
        dtpEndDate.Font = New Font("Outfit", 8, FontStyle.Bold)

        ' ===== DataGridView =====
        dgvPullout.Font = New Font("Outfit", 9, FontStyle.Regular)

        ApplyRoundedCorners()

        ' --- Load only today's pullouts ---
        LoadPulloutData()

        SetupDataGridView()

        ' Set DateTimePickers default to today
        dtpStartDate.Value = DateTime.Today
        dtpEndDate.Value = DateTime.Today

        ' Load today's pullouts
        LoadPulloutData()


    End Sub
    ' === Load Pullout Data with accurate date range ===
    Private Sub LoadPulloutData(Optional ByVal startDate As Date? = Nothing, Optional ByVal endDate As Date? = Nothing)
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' Default to today if no dates provided
                Dim sDate As Date = If(startDate.HasValue, startDate.Value.Date, DateTime.Today)
                Dim eDate As Date = If(endDate.HasValue, endDate.Value.Date, DateTime.Today)

                ' Ensure startDate is not after endDate
                If sDate > eDate Then
                    Dim temp As Date = sDate
                    sDate = eDate
                    eDate = temp
                End If

                ' End date inclusive: add 1 day for < comparison
                Dim eDatePlusOne As Date = eDate.AddDays(1)

                ' SQL query with accurate date filtering
                Dim query As String =
"SELECT PullOutID, BatchNumber, BarcodeID, ProductName, Supplier, " &
"CASE WHEN ExpirationDate = '0000-00-00' THEN 'No Expiration' ELSE ExpirationDate END AS ExpirationDate, " &
"RemainingQty, Reason, PulledBy, PullOutDate, PullOutQuantity " &
"FROM pullouts " &
"WHERE PullOutDate >= @startDate AND PullOutDate < @endDatePlusOne " &
"ORDER BY PullOutDate DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@startDate", sDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@endDatePlusOne", eDatePlusOne.ToString("yyyy-MM-dd"))

                    Dim dt As New DataTable()
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                    dgvPullout.DataSource = dt

                    ' Hide PullOutID column automatically
                    If dgvPullout.Columns.Contains("PullOutID") Then
                        dgvPullout.Columns("PullOutID").Visible = False
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading pullout records: " & ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' === DateTimePicker Event Handlers ===
    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        LoadPulloutData(dtpStartDate.Value, dtpEndDate.Value)
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        LoadPulloutData(dtpStartDate.Value, dtpEndDate.Value)
    End Sub

    Private Sub SetupDataGridView()

        ' === Hide PullOutID column ===
        If dgvPullout.Columns.Contains("PullOutID") Then
            dgvPullout.Columns("PullOutID").Visible = False
        End If

        With dgvPullout
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



    ' === Apply Rounded Corners ===
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



    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?",
                                                     "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub

End Class
