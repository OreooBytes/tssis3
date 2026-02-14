Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Media
Imports Guna.UI.WinForms
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports ZXing

Public Class Membership

    '========================
    ' FORM LOAD
    '========================
    Private Sub membership_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetupMembershipDataGridView()
        pbBarcode.SizeMode = PictureBoxSizeMode.StretchImage
        LoadMembershipsFromDatabase()

        'BackColor = ColorTranslator.FromHtml("#0B2447")

        ' Clear fields
        nametxt.Clear()
        contactnotxt.Clear()




        ' Auto-generate barcode on load
        GenerateNewBarcode()


        contactnotxt.SelectionStart = contactnotxt.Text.Length
        btnupdate.Visible = True

        ' I-center ang MainPanel sa form
        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2


        ' === Light Gray Rounded Border ===
        With Guna2Panel1
            .FillColor = Color.White
            .BorderColor = ColorTranslator.FromHtml("#D3D3D3")
            .BorderThickness = 2
            .BorderRadius = 10
            .BringToFront()
        End With

        ApplyRoundedCorners()

        ' ===== DataGridView =====

        Guna2DataGridView1.DefaultCellStyle.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== TextBoxes =====
        contactnotxt.Font = New Font("Outfit", 9, FontStyle.Regular)
        nametxt.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtSearch.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== Buttons =====
        clearbtn.Font = New Font("Outfit", 9, FontStyle.Bold)
        deletebtn.Font = New Font("Outfit", 9, FontStyle.Bold)
        Addbtn.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnAddnewUser.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnupdateloyalty.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnupdate.Font = New Font("Outfit", 9, FontStyle.Bold)


        ' ===== Labels =====
        Label1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label2.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label4.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblMembership.Font = New Font("Outfit", 9, FontStyle.Bold)



    End Sub

    Private Const CornerRadius As Integer = 10 ' fixed radius

    '========================
    ' Apply Rounded Corners
    '========================
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


    '========================
    ' SETUP GRID
    '========================
    Private Sub SetupMembershipDataGridView()
        Guna2DataGridView1.Columns.Clear()

        ' === Columns ===
        Guna2DataGridView1.Columns.Add("ID", "ID")
        Guna2DataGridView1.Columns("ID").Visible = False   ' Hide ID
        Guna2DataGridView1.Columns.Add("Name", "Name")
        Guna2DataGridView1.Columns.Add("ContactNo", "Contact No")
        Guna2DataGridView1.Columns.Add("Points", "Points")
        Guna2DataGridView1.Columns.Add("Barcode", "Barcode")

        ' === Edit column ===
        If Guna2DataGridView1.Columns("Edit") Is Nothing Then
            Dim editCol As New DataGridViewImageColumn()
            editCol.Name = "Edit"
            editCol.HeaderText = "Edit"
            editCol.Image = My.Resources.icons8_edit_mains
            editCol.ImageLayout = DataGridViewImageCellLayout.Zoom
            Guna2DataGridView1.Columns.Add(editCol)
        End If

        ' === Delete column ===
        If Guna2DataGridView1.Columns("Delete") Is Nothing Then
            Dim deleteCol As New DataGridViewImageColumn()
            deleteCol.Name = "Delete"
            deleteCol.HeaderText = "Delete"
            deleteCol.Image = My.Resources.icons8_delete_mains
            deleteCol.ImageLayout = DataGridViewImageCellLayout.Zoom
            Guna2DataGridView1.Columns.Add(deleteCol)
        End If

        ' === Styling ===
        With Guna2DataGridView1
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 30
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Set FillWeight
            .Columns("Name").FillWeight = 100
            .Columns("ContactNo").FillWeight = 80
            .Columns("Points").FillWeight = 50
            .Columns("Barcode").FillWeight = 100
            .Columns("Edit").FillWeight = 25
            .Columns("Delete").FillWeight = 25

            ' Alignment
            .Columns("Edit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Delete").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Edit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Delete").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    '========================
    ' LOAD MEMBERSHIPS
    '========================
    Private Sub LoadMembershipsFromDatabase(Optional searchText As String = "")
        Try
            If Guna2DataGridView1.Columns.Count = 0 Then
                SetupMembershipDataGridView()
            End If

            Guna2DataGridView1.Rows.Clear()

            Using conn As MySqlConnection = Module1.Openconnection()
                Dim query As String = "SELECT * FROM membership"

                If Not String.IsNullOrWhiteSpace(searchText) Then
                    query &= " WHERE Name Like @search Or ContactNo Like @search Or ID Like @search Or Barcode Like @search"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Guna2DataGridView1.Rows.Add(
                            reader("ID").ToString(),
                            reader("Name").ToString(),
                            reader("ContactNo").ToString(),
                            reader("Points").ToString(),
                            reader("Barcode").ToString()
                        )
                        End While
                    End Using
                End Using
            End Using

            ' ✅ REAL-TIME TOTAL MEMBERS
            lblTotalMember.Text = Guna2DataGridView1.Rows.Count.ToString()

        Catch ex As Exception
            MessageBox.Show("Error loading membership data:  " & ex.Message)
        End Try
    End Sub


    '========================
    ' GENERATE BARCODE
    '========================
    Private Function GenerateBarcode(data As String) As Bitmap
        Dim writer As New BarcodeWriter()
        writer.Format = BarcodeFormat.CODE_128
        writer.Options = New ZXing.Common.EncodingOptions With {
            .Width = 234,
            .Height = 80,
            .Margin = 0
        }
        pbBarcode.SizeMode = PictureBoxSizeMode.StretchImage
        Return writer.Write(data)
    End Function

    '========================
    ' AUTO GENERATE BARCODE
    '========================
    Private Sub GenerateNewBarcode()
        Dim randomBarcode As String = "BC-" & Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper()
        pbBarcode.Image = GenerateBarcode(randomBarcode)
        pbBarcode.Tag = randomBarcode
    End Sub

    '========================
    ' CLEAR FORM
    '========================
    Private Sub clear()
        nametxt.Clear()
        contactnotxt.Clear()
        pbBarcode.Image = Nothing
        Addbtn.Enabled = True
        GenerateNewBarcode()
    End Sub

    '========================
    ' ADD MEMBER
    '========================
    Private Sub Addbtn_Click(sender As Object, e As EventArgs) Handles Addbtn.Click

        ' === Basic Validation ===
        If String.IsNullOrWhiteSpace(nametxt.Text) Or String.IsNullOrWhiteSpace(contactnotxt.Text) Then
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim nameValue As String = nametxt.Text.Trim()
        Dim contactValue As String = contactnotxt.Text.Trim()

        ' === Bawal pareho ang Name at Contact ===
        If String.Equals(nameValue, contactValue, StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Name and Contact Number cannot be the same.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nametxt.Focus()
            Exit Sub
        End If

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Exit Sub

            Try
                ' === STRICT DUPLICATE CHECK (Name OR Contact) ===
                Dim checkCmd As New MySqlCommand("
                SELECT COUNT(*) 
                FROM membership 
                WHERE LOWER(Name) = LOWER(@Name) 
                   OR ContactNo = @ContactNo", conn)

                checkCmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = nameValue
                checkCmd.Parameters.Add("@ContactNo", MySqlDbType.VarChar).Value = contactValue

                Dim existingCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If existingCount > 0 Then
                    MessageBox.Show("Duplicate Name or Contact Number detected. Saving not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' === Insert ===
                Dim randomBarcode As String = pbBarcode.Tag.ToString()

                Dim insertCmd As New MySqlCommand("
                INSERT INTO membership (Name, ContactNo, Barcode, Points) 
                VALUES (@Name, @ContactNo, @Barcode, @Points)", conn)

                insertCmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = nameValue
                insertCmd.Parameters.Add("@ContactNo", MySqlDbType.VarChar).Value = contactValue
                insertCmd.Parameters.Add("@Barcode", MySqlDbType.VarChar).Value = randomBarcode
                insertCmd.Parameters.Add("@Points", MySqlDbType.Int32).Value = 1

                insertCmd.ExecuteNonQuery()

                LogAuditTrail(SessionData.role, SessionData.fullName, "Added new member: " & nameValue)

                MessageBox.Show("Successfully added! Member receives 1 Welcome Point.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadMembershipsFromDatabase()
                clear()
                Guna2ShadowPanel1.Visible = False

            Catch ex As MySqlException
                MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using

    End Sub




    '========================
    'UPDATE MEMBER
    '========================
    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click

        ' === Basic Validation ===
        If String.IsNullOrWhiteSpace(nametxt.Text) Or String.IsNullOrWhiteSpace(contactnotxt.Text) Then
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Guna2DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a member to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim nameValue As String = nametxt.Text.Trim()
        Dim contactValue As String = contactnotxt.Text.Trim()

        ' === Validation: Name and Contact cannot be the same ===
        If String.Equals(nameValue, contactValue, StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Name and Contact Number cannot be the same.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nametxt.Focus()
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = Guna2DataGridView1.SelectedRows(0)
        Dim originalContactNo As String = selectedRow.Cells("ContactNo").Value.ToString()

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Exit Sub

            Try
                ' === STRICT DUPLICATE CHECK FOR NAME OR CONTACT (case-insensitive for name) ===
                Dim checkDuplicateCmd As New MySqlCommand("
                SELECT COUNT(*) FROM membership
                WHERE (LOWER(Name) = LOWER(@Name) OR ContactNo = @ContactNo)
                  AND ContactNo <> @OriginalContactNo
            ", conn)
                checkDuplicateCmd.Parameters.AddWithValue("@Name", nameValue)
                checkDuplicateCmd.Parameters.AddWithValue("@ContactNo", contactValue)
                checkDuplicateCmd.Parameters.AddWithValue("@OriginalContactNo", originalContactNo)

                If Convert.ToInt32(checkDuplicateCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("A member with the same Name or Contact Number already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' === Get old values for audit ===
                Dim oldValues As New Dictionary(Of String, String)
                Dim getCmd As New MySqlCommand("
                SELECT Name, Points, ContactNo 
                FROM membership 
                WHERE ContactNo=@ContactNo
            ", conn)
                getCmd.Parameters.AddWithValue("@ContactNo", originalContactNo)

                Using reader = getCmd.ExecuteReader()
                    If reader.Read() Then
                        oldValues("Name") = reader("Name").ToString()
                        oldValues("Points") = reader("Points").ToString()
                        oldValues("ContactNo") = reader("ContactNo").ToString()
                    End If
                End Using

                ' === Perform Update ===
                Dim updateCmd As New MySqlCommand("
                UPDATE membership 
                SET Name=@Name, Points=@Points, ContactNo=@NewContactNo 
                WHERE ContactNo=@OriginalContactNo
            ", conn)
                updateCmd.Parameters.AddWithValue("@Name", nameValue)
                updateCmd.Parameters.AddWithValue("@Points", 1)
                updateCmd.Parameters.AddWithValue("@NewContactNo", contactValue)
                updateCmd.Parameters.AddWithValue("@OriginalContactNo", originalContactNo)

                Dim rowsAffected As Integer = updateCmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    ' === Audit Trail ===
                    Dim updatedFields As New List(Of String)
                    If Not String.Equals(nameValue, oldValues("Name"), StringComparison.OrdinalIgnoreCase) Then
                        updatedFields.Add($"Name: ""{oldValues("Name")}"" → ""{nameValue}""")
                    End If
                    If Not String.Equals(contactValue, oldValues("ContactNo"), StringComparison.OrdinalIgnoreCase) Then
                        updatedFields.Add($"Contact No: ""{oldValues("ContactNo")}"" → ""{contactValue}""")
                    End If

                    If updatedFields.Count > 0 Then
                        Dim actionDescription As String =
                        "Updated Membership Details:" & vbCrLf &
                        String.Join(vbCrLf, updatedFields)

                        Dim actorRole As String = If(String.IsNullOrWhiteSpace(SessionData.role), "System", SessionData.role)
                        Dim actorName As String = If(String.IsNullOrWhiteSpace(SessionData.fullName), "System", SessionData.fullName)

                        LogAuditTrail(actorRole, actorName, actionDescription)
                    End If

                    MessageBox.Show("Successfully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SystemSounds.Exclamation.Play()

                    LoadMembershipsFromDatabase()
                    Addbtn.Visible = True
                    btnupdate.Visible = False
                    Guna2ShadowPanel1.Visible = False
                    clear()
                Else
                    MessageBox.Show("No record was updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As MySqlException
                MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using

    End Sub








    '========================
    ' DELETE MEMBER
    '========================
    Private Sub deletebtn_Click(sender As Object, e As EventArgs) Handles deletebtn.Click

        ' Prevent Cashier from deleting members
        If SessionData.role = "Cashier" Then
            MessageBox.Show("You don't have permission to delete a member.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' --- Check if any row is selected ---
        If Guna2DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a member to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Safely get selected member's info ---
        Dim selectedRow As DataGridViewRow = Guna2DataGridView1.SelectedRows(0)
        Dim id As String = If(selectedRow.Cells("ID").Value IsNot Nothing, selectedRow.Cells("ID").Value.ToString(), "")
        Dim memberName As String = If(selectedRow.Cells("Name").Value IsNot Nothing, selectedRow.Cells("Name").Value.ToString(), "")

        ' Build display string
        Dim memberInfo As String = $"{memberName} (ID: {id})"

        ' --- Confirm deletion ---
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this member?",
                                             "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Using conn As MySqlConnection = Module1.Openconnection()
                Try
                    ' --- Delete from database ---
                    Dim sql As String = "DELETE FROM membership WHERE ID = @ID"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@ID", id)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' --- Audit log ---
                    LogAuditTrail(SessionData.role, SessionData.fullName, $"Deleted member: {memberInfo}")

                    ' --- Success message ---
                    MessageBox.Show($"Member successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As MySqlException
                    MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End Using

            ' --- Refresh DataGridView and clear form ---
            LoadMembershipsFromDatabase()
            clear()
        End If

        ' --- Hide panels ---
        Guna2ShadowPanel1.Visible = False

    End Sub



    '========================
    ' HANDLE EDIT/DELETE CLICKS
    '========================
    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim colName As String = Guna2DataGridView1.Columns(e.ColumnIndex).Name

            If colName = "Edit" Then
                Dim row As DataGridViewRow = Guna2DataGridView1.Rows(e.RowIndex)

                nametxt.Text = row.Cells("Name").Value.ToString()
                contactnotxt.Text = row.Cells("ContactNo").Value.ToString()

                Dim barcodeValue As String = row.Cells("Barcode").Value.ToString()
                pbBarcode.Image = GenerateBarcode(barcodeValue)
                pbBarcode.Tag = barcodeValue

                Guna2ShadowPanel1.Visible = True

                lblMembership.Text = "Edit Membership"

                btnupdate.Visible = True

                Addbtn.Visible = False


                Addbtn.Visible = False
                btnupdate.Visible = True
            ElseIf colName = "Delete" Then
                Guna2DataGridView1.Rows(e.RowIndex).Selected = True
                deletebtn.PerformClick()
            End If
        End If
    End Sub

    '========================
    ' AUDIT TRAIL
    '========================
    Private Sub LogAuditTrail(ByVal role As String, ByVal fullName As String, ByVal action As String)
        Try
            Using connection As New MySqlConnection(connectionstring)
                connection.Open()
                Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@Role, @FullName, @Action, @Form, @Date)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@Action", action)
                    cmd.Parameters.AddWithValue("@Form", "Membership")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '========================
    ' CLEAR BUTTON
    '========================
    Private Sub Clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        nametxt.Clear()
        contactnotxt.Clear()
        Addbtn.Enabled = True
        Guna2DataGridView1.ClearSelection()
        GenerateNewBarcode()
    End Sub

    '========================
    ' SEARCH MEMBERSHIP
    '========================
    Private Sub txtSearchCategory_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        If String.IsNullOrEmpty(searchText) Then
            LoadMembershipsFromDatabase()
            Exit Sub
        End If

        Guna2DataGridView1.Rows.Clear()

        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                Dim query As String =
                    "SELECT * FROM membership 
                     WHERE LOWER(Name) LIKE @search 
                        OR LOWER(ContactNo) LIKE @search 
                        OR LOWER(Barcode) LIKE @search 
                        OR CAST(ID AS CHAR) LIKE @search"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim index As Integer = Guna2DataGridView1.Rows.Add(
                                reader("ID").ToString(),
                                reader("Name").ToString(),
                                reader("ContactNo").ToString(),
                                reader("Points").ToString(),
                                reader("Barcode").ToString()
                            )

                            ' Highlight matching
                            Guna2DataGridView1.Rows(index).DefaultCellStyle.BackColor = Color.LightYellow
                            Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionBackColor = Color.Orange
                            Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Black
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching members: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '========================
    ' PANEL BUTTONS & CLOSE
    '========================
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub



    '========================
    ' NAMETXT - LETTERS ONLY
    '========================
    Private Sub nametxt_TextChanged(sender As Object, e As EventArgs) Handles nametxt.TextChanged
        Dim cursorPos As Integer = nametxt.SelectionStart
        nametxt.Text = New String(nametxt.Text.Where(Function(c) Char.IsLetter(c) Or c = " "c).ToArray())
        nametxt.SelectionStart = cursorPos
    End Sub




    '========================
    ' CONTACTNOTXT - NUMERIC ONLY, START WITH "09", EXACTLY 11 DIGITS
    '========================
    Private Sub contactnotxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles contactnotxt.KeyPress
    ' Allow control keys (backspace) and digits only
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If

    ' Limit max length to 11
    If Not Char.IsControl(e.KeyChar) AndAlso contactnotxt.Text.Length >= 11 Then
        e.Handled = True
    End If
End Sub

Private Sub contactnotxt_TextChanged(sender As Object, e As EventArgs) Handles contactnotxt.TextChanged
    ' Always start with "09"
    If Not contactnotxt.Text.StartsWith("09") Then
        contactnotxt.Text = "09"
        contactnotxt.SelectionStart = contactnotxt.Text.Length
    End If
End Sub


    '========================
    ' FORM CLOSE
    '========================
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub


    '========================
    ' UI FOR BUTTONS
    '========================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === DEFAULT COLORS & IMAGES ===
        btnAddnewUser.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnAddnewUser.ForeColor = Color.White
        btnAddnewUser.Image = My.Resources.icons8_add_30_normal ' normal icon

        btnupdateloyalty.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnupdateloyalty.ForeColor = Color.White
        btnupdateloyalty.Image = My.Resources.icons8_update_normal ' normal icon


        ' === HOVER EFFECTS FOR btnAddnewUsar ===
        AddHandler btnAddnewUser.MouseEnter, Sub()
                                                 btnAddnewUser.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                 btnAddnewUser.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                 btnAddnewUser.Image = My.Resources.icons8_add_30_hindi ' hover icon
                                             End Sub

        AddHandler btnAddnewUser.MouseLeave, Sub()
                                                 btnAddnewUser.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                 btnAddnewUser.ForeColor = Color.White
                                                 btnAddnewUser.Image = My.Resources.icons8_add_30_normal ' back to normal
                                             End Sub

        ' === HOVER EFFECTS FOR btnSort ===
        AddHandler btnupdateloyalty.MouseEnter, Sub()
                                                    btnupdateloyalty.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                    btnupdateloyalty.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                    btnupdateloyalty.Image = My.Resources.icons8_update_hindi ' hover icon
                                                End Sub

        AddHandler btnupdateloyalty.MouseLeave, Sub()
                                                    btnupdateloyalty.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                    btnupdateloyalty.ForeColor = Color.White
                                                    btnupdateloyalty.Image = My.Resources.icons8_update_normal  ' normal icon
                                                End Sub


        ' === OPTIONAL: CENTER THE FORM ON SCREEN ===
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub


    Private Sub btnAddnewUser_Click(sender As Object, e As EventArgs) Handles btnAddnewUser.Click
        Guna2ShadowPanel1.Visible = True
        btnupdate.Visible = False
        Addbtn.Visible = True

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Guna2ShadowPanel1.Visible = False
    End Sub

    '========= FOR ALT F4 =========
    Private Sub membership_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub btnupdateloyalty_Click(sender As Object, e As EventArgs) Handles btnupdateloyalty.Click
        Dim loyalty As New LoyaltyDiscount
        LoyaltyDiscount.ShowDialog()
    End Sub
End Class
