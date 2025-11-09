Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Audit

    ' Store the role of the logged-in user
    Public loggedInRole As String = ""

    ' Local table for filtering
    Private auditTable As New DataTable()

    ' === Form Load ===
    Private Sub AuditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupAuditTrailGrid()
        LoadAuditTrail() ' Load data from database

        ' Date pickers styling
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

        dgvAuditTrail.Font = New Font("Outfit", 9, FontStyle.Regular)


    End Sub

    ' === Setup DataGridView Columns & Styling ===
    Private Sub SetupAuditTrailGrid()
        dgvAuditTrail.Columns.Clear()

        ' Data Columns
        dgvAuditTrail.Columns.Add("AuditID", "ID")
        dgvAuditTrail.Columns("AuditID").Visible = False
        dgvAuditTrail.Columns.Add("Role", "Role")
        dgvAuditTrail.Columns.Add("FullName", "Full Name")
        dgvAuditTrail.Columns.Add("Action", "Action")
        dgvAuditTrail.Columns.Add("Form", "Form")
        dgvAuditTrail.Columns.Add("Date", "Date")

        ' Set custom widths for visible columns
        dgvAuditTrail.Columns("Role").Width = 150
        dgvAuditTrail.Columns("FullName").Width = 150
        dgvAuditTrail.Columns("Action").Width = 250
        dgvAuditTrail.Columns("Form").Width = 100
        dgvAuditTrail.Columns("Date").Width = 150

        With dgvAuditTrail
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 25
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .ScrollBars = ScrollBars.None

        End With
    End Sub

    ' === Load Audit Trail Data ===
    Private Sub LoadAuditTrail()
        auditTable.Clear()
        dgvAuditTrail.Rows.Clear()

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                Dim query As String = "SELECT AuditID, Role, FullName, Action, Form, Date FROM audittrail ORDER BY Date DESC"
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(auditTable)
                    End Using
                End Using
            End Using

            ' ✅ Manually add rows to DataGridView
            For Each row As DataRow In auditTable.Rows
                dgvAuditTrail.Rows.Add(
                    row("AuditID").ToString(),
                    row("Role").ToString(),
                    row("FullName").ToString(),
                    row("Action").ToString(),
                    row("Form").ToString(),
                    row("Date").ToString()
                )
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading audit trail: " & ex.Message, "AuditTrail", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' === Search Filter (Local Filtering) ===
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        ' Clear the DataGridView first
        dgvAuditTrail.Rows.Clear()

        ' If search box is empty, show all logs
        If String.IsNullOrEmpty(searchText) Then
            For Each row As DataRow In auditTable.Rows
                dgvAuditTrail.Rows.Add(
                    row("AuditID").ToString(),
                    row("Role").ToString(),
                    row("FullName").ToString(),
                    row("Action").ToString(),
                    row("Form").ToString(),
                    row("Date").ToString()
                )
            Next
            Exit Sub
        End If

        ' Apply local filter using LINQ
        Dim filteredRows = auditTable.AsEnumerable().Where(Function(r) _
            r("Role").ToString().ToLower().Contains(searchText) OrElse
            r("FullName").ToString().ToLower().Contains(searchText) OrElse
            r("Action").ToString().ToLower().Contains(searchText) OrElse
            r("Form").ToString().ToLower().Contains(searchText)
        )

        ' Add only matching rows to DataGridView
        For Each row In filteredRows
            dgvAuditTrail.Rows.Add(
                row("AuditID").ToString(),
                row("Role").ToString(),
                row("FullName").ToString(),
                row("Action").ToString(),
                row("Form").ToString(),
                row("Date").ToString()
            )
        Next

        ' Apply highlight colors
        For Each row As DataGridViewRow In dgvAuditTrail.Rows
            row.DefaultCellStyle.BackColor = Color.LightYellow
            row.DefaultCellStyle.SelectionBackColor = Color.Orange
            row.DefaultCellStyle.SelectionForeColor = Color.Black
        Next
    End Sub

    ' === Close Button ===
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then
                CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub dgvAuditTrail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAuditTrail.CellContentClick

    End Sub
End Class
