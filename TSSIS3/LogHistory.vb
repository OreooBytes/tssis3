Imports MySql.Data.MySqlClient
Imports System.Data

Public Class LogHistory


    ' Store logs locally for filtering
    Private logTable As New DataTable()

    ' --------------------------
    ' Load logs from database
    ' --------------------------
    Private Sub LoadLogs()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT LogID, Role, FullName, Action, ActionDate FROM loghistory ORDER BY ActionDate DESC"
                Using cmd As New MySqlCommand(query, conn)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    logTable.Clear()
                    adapter.Fill(logTable)

                    dgvLogs.DataSource = logTable

                    ' Hide ID column
                    If dgvLogs.Columns.Contains("LogID") Then
                        dgvLogs.Columns("LogID").Visible = False
                    End If

                    SetupDGV() ' apply formatting
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading logs: " & ex.Message)
        End Try
    End Sub

    ' --------------------------
    ' Log action to database
    ' --------------------------
    Public Sub LogAction(role As String, fullName As String, action As String)
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Dim query As String = "INSERT INTO loghistory (Role, FullName, Action) VALUES (@Role, @FullName, @Action)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@Action", action)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging action: " & ex.Message)
        End Try
    End Sub

    ' --------------------------
    ' Setup DataGridView appearance
    ' --------------------------
    Private Sub SetupDGV()
        With dgvLogs
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 25
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Set column widths
            If .Columns.Contains("Role") Then .Columns("Role").Width = 150
            If .Columns.Contains("FullName") Then .Columns("FullName").Width = 150
            If .Columns.Contains("Action") Then .Columns("Action").Width = 150
            If .Columns.Contains("ActionDate") Then .Columns("ActionDate").Width = 150
        End With
    End Sub

    ' --------------------------
    ' Form Load Event
    ' --------------------------
    Private Sub LogHistoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' BackColor = ColorTranslator.FromHtml("#1D3A70")  
        SetupDGV()
        LoadLogs()

        Timer1.Interval = 1000
        Timer1.Start()

        dptStartDate.FillColor = ColorTranslator.FromHtml("#1D3A70")
        dptEndDate.FillColor = ColorTranslator.FromHtml("#1D3A70")

        ' ===== Labels / HtmlLabels =====
        Guna2HtmlLabel1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Guna2HtmlLabel2.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== TextBoxes =====
        txtSearch.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== DateTimePickers =====
        dptStartDate.Font = New Font("Outfit", 9, FontStyle.Bold)
        dptEndDate.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== DataGridView =====

        dgvLogs.Font = New Font("Outfit", 9, FontStyle.Regular)


    End Sub

    ' --------------------------
    ' Timer Tick Event
    ' --------------------------
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadLogs()  ' Refresh logs every tick
    End Sub


    ' Add this event for Start Date
    Private Sub dptStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dptStartDate.ValueChanged
        FilterLogsByDate()
    End Sub

    ' Add this event for End Date
    Private Sub dptEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dptEndDate.ValueChanged
        FilterLogsByDate()
    End Sub

    ' Function to filter logs based on selected date range
    Private Sub FilterLogsByDate()
        If logTable.Rows.Count = 0 Then Exit Sub

        Dim startDate As DateTime = dptStartDate.Value.Date
        Dim endDate As DateTime = dptEndDate.Value.Date.AddDays(1).AddSeconds(-1) ' Include full day

        Dim dv As New DataView(logTable)
        dv.RowFilter = String.Format("ActionDate >= #{0}# AND ActionDate <= #{1}#", startDate.ToString("yyyy-MM-dd HH:mm:ss"), endDate.ToString("yyyy-MM-dd HH:mm:ss"))
        dgvLogs.DataSource = dv
    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Ilagay dito ang SendToBack bago magsara
            If Me.Owner IsNot Nothing Then
                CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            End If

            Me.Close()
        End If

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' Pause auto-refresh while searching
        Timer1.Stop()

        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        If String.IsNullOrEmpty(searchText) Then
            dgvLogs.DataSource = logTable
            Timer1.Start() ' Resume timer when cleared
            Exit Sub
        End If

        Dim dv As New DataView(logTable)
        dv.RowFilter = String.Format(
            "ISNULL(Role, '') LIKE '%{0}%' OR " &
            "ISNULL(FullName, '') LIKE '%{0}%' OR " &
            "ISNULL(Action, '') LIKE '%{0}%'",
            searchText.Replace("'", "''")
        )

        dgvLogs.DataSource = dv

        ' Apply highlight
        For Each row As DataGridViewRow In dgvLogs.Rows
            row.DefaultCellStyle.BackColor = Color.LightYellow
            row.DefaultCellStyle.SelectionBackColor = Color.Orange
            row.DefaultCellStyle.SelectionForeColor = Color.Black
        Next
    End Sub


End Class
