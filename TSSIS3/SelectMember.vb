Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class SelectMember
    Public SelectedMemberID As String
    Public SelectedMemberName As String
    Public SelectedMemberBarcode As String
    Public SelectedMemberPoints As String
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

    ' ===============================
    ' FORM LOAD
    ' ===============================
    Private Sub SelectMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
        End Using

        ApplyRoundedCorners()

        BackColor = ColorTranslator.FromHtml("#1D3A70")
        SetupGrid()      ' Setup columns first
        LoadMembers()    ' Load members after columns exist

        BackColor = ColorTranslator.FromHtml("#0B2447")

        Guna2Panel1.BackColor = Color.Gainsboro

        ' ===== DataGridView =====
        DataGridView1.DefaultCellStyle.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== TextBox =====
        txtSearchMember.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== Panels and Pictures =====
        ' Panels and PictureBoxes do not need font changes


    End Sub

    ' ===============================
    ' SETUP DATAGRIDVIEW
    ' ===============================
    Private Sub SetupGrid()
        With DataGridView1
            .Columns.Clear()
            .Rows.Clear()
            .AutoGenerateColumns = False

            ' Add data columns
            .Columns.Add("ID", "ID")
            .Columns.Add("Name", "Name")
            .Columns.Add("ContactNo", "Contact No")
            .Columns.Add("Points", "Points")
            .Columns.Add("Barcode", "Barcode")

            ' Hide the ID column
            .Columns("ID").Visible = False

            ' Add Select button column
            Dim btnCol As New DataGridViewButtonColumn()
            btnCol.Name = "Action"
            btnCol.HeaderText = "Action"
            btnCol.Text = "Select"
            btnCol.UseColumnTextForButtonValue = True
            ' Center the header text
            btnCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns.Add(btnCol)

            ' --- Style the grid ---
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 30
            .ColumnHeadersHeight = 30
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .MultiSelect = False

            ' === Disable resizing for columns and rows ===
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False

            ' AutoSize logic: keep Action fixed, fill others
            For Each col As DataGridViewColumn In .Columns
                If col.Name = "Action" Or col.Name = "ID" Then
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Else
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            Next
        End With
    End Sub



    ' ===============================
    ' LOAD MEMBERS
    ' ===============================
    Private Sub LoadMembers(Optional searchText As String = "")
        ' Ensure columns exist before adding rows
        If DataGridView1.Columns.Count = 0 Then SetupGrid()
        DataGridView1.Rows.Clear()

        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                Dim query As String = "SELECT * FROM membership"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim id As String = reader("ID").ToString()
                            Dim name As String = reader("Name").ToString()
                            Dim contact As String = reader("ContactNo").ToString()
                            Dim points As String = reader("Points").ToString()
                            Dim barcode As String = reader("Barcode").ToString()

                            ' Search filter
                            If searchText = "" OrElse
                               id.ToLower().Contains(searchText.ToLower()) OrElse
                               name.ToLower().Contains(searchText.ToLower()) OrElse
                               contact.ToLower().Contains(searchText.ToLower()) OrElse
                               barcode.ToLower().Contains(searchText.ToLower()) Then

                                Dim index As Integer = DataGridView1.Rows.Add(id, name, contact, points, barcode)

                                ' Highlight search matches
                                If searchText <> "" Then
                                    DataGridView1.Rows(index).DefaultCellStyle.BackColor = Color.LightYellow
                                    DataGridView1.Rows(index).DefaultCellStyle.SelectionBackColor = Color.Orange
                                    DataGridView1.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Black
                                End If
                            End If
                        End While
                    End Using
                End Using
                Module1.ConnectionClose(conn)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading members: " & ex.Message)
        End Try
    End Sub

    ' ===============================
    ' SELECT BUTTON CLICK
    ' ===============================
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Action").Index Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            SelectedMemberID = row.Cells("ID").Value.ToString()
            SelectedMemberName = row.Cells("Name").Value.ToString()
            SelectedMemberPoints = row.Cells("Points").Value.ToString()
            SelectedMemberBarcode = row.Cells("Barcode").Value.ToString()

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    ' ===============================
    ' CLOSE BUTTON
    ' ===============================
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    ' ===============================
    ' SEARCH MEMBER
    ' ===============================
    Private Sub txtSearchMember_TextChanged(sender As Object, e As EventArgs) Handles txtSearchMember.TextChanged
        Dim searchText As String = txtSearchMember.Text.Trim()
        LoadMembers(searchText)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then
                CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            End If
            Me.Close()
        End If
    End Sub
    '========= FOR ALT F4 =========
    Private Sub seleectproduct_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
End Class
