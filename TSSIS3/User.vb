Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Media
Imports System.Security.AccessControl
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient


Public Class User
    ' === Variables ===
    Private originalUsername As String
    Private originalcontactno As String
    Private bsUsers As New BindingSource()

    Private selectedUserID As Integer = 0
    Private isDeleting As Boolean = False

    Private WithEvents timerUserCount As New Timer() ' ✅ Code-based Timer


    ' === Class-level variable ===
    Private userTable As New DataTable()

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



    ' === Form Load ===
    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
        End Using

        ApplyRoundedCorners()

        uname.MaxLength = 50
        pword.MaxLength = 50
        cpword.MaxLength = 50
        txtAddress.MaxLength = 255
        Guna2DataGridView1.Rows.Clear()

        updatebtn.Visible = False
        'deletebtn.Visible = False

        SetupDataGridView() ' Ensure columns are set up first
        LoadData()
        LoadUserTypes() ' Load user types into the ComboBox

        ' Wire up the event handler
        'AddHandler Guna2DataGridView1.CellContentClick, AddressOf Guna2DataGridView1_CellContentClick

        ' Initialize cpword state
        'cpword.Enabled = Not String.IsNullOrWhiteSpace(pword.Text)

        ' KeyPress events
        AddHandler fname.KeyPress, AddressOf fname_KeyPress
        AddHandler lname.KeyPress, AddressOf fname_KeyPress

        'Guna2Panel2.BackColor = ColorTranslator.FromHtml("#1D3A70")

        'BackColor = ColorTranslator.FromHtml("#1D3A70")

        btnAddnewUser.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnSuperadmin.FillColor = ColorTranslator.FromHtml("#1D3A70")

        'btnSort.FillColor = ColorTranslator.FromHtml("#1D3A70")

        ' === Light Gray Rounded Border ===
        With Guna2Panel1
            .FillColor = Color.White
            .BorderColor = ColorTranslator.FromHtml("#D3D3D3")
            .BorderThickness = 2
            .BorderRadius = 10
            .BringToFront()
        End With


        ' === User Firstname / Lastname ===
        LoadUserCounts()
        ' Start timer for real-time update
        timerUserCount.Interval = 1000 ' every 1 second
        timerUserCount.Start()

        Guna2DataGridView1.Font = New Font("Outfit", 8, FontStyle.Regular)

        ' Set all labels to Outfit, size 10, bold
        Label1.Font = New Font("Outfit", 10, FontStyle.Bold)
        Label3.Font = New Font("Outfit", 10, FontStyle.Bold)
        Label4.Font = New Font("Outfit", 10, FontStyle.Bold)
        Label5.Font = New Font("Outfit", 10, FontStyle.Bold)
        Label6.Font = New Font("Outfit", 10, FontStyle.Bold)
        Label7.Font = New Font("Outfit", 10, FontStyle.Bold)
        Label8.Font = New Font("Outfit", 10, FontStyle.Bold)
        Label9.Font = New Font("Outfit", 10, FontStyle.Bold)
        Label10.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblSuperadmin.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblAdmin.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblCashier.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblCustom.Font = New Font("Outfit", 10, FontStyle.Bold)

        uname.Font = New Font("Outfit", 9, FontStyle.Regular)

        fname.Font = New Font("Outfit", 9, FontStyle.Regular)
        utype.Font = New Font("Outfit", 9, FontStyle.Regular)
        cpword.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtAddress.Font = New Font("Outfit", 9, FontStyle.Regular)
        cno.Font = New Font("Outfit", 9, FontStyle.Regular)
        pword.Font = New Font("Outfit", 9, FontStyle.Regular)
        lname.Font = New Font("Outfit", 9, FontStyle.Regular)
        minitial.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtsearch.Font = New Font("Outfit", 9, FontStyle.Regular)


        addbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        updatebtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        clearbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        btnAddnewUser.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnSuperadmin.Font = New Font("Outfit", 10, FontStyle.Bold)


        ' I-center ang MainPanel sa form
        Mainpanel.Left = (Me.ClientSize.Width - Mainpanel.Width) \ 2
        Mainpanel.Top = (Me.ClientSize.Height - Mainpanel.Height) \ 2


        ' ===== Set MaxLength to 150 =====
        fname.MaxLength = 150
        minitial.MaxLength = 150
        lname.MaxLength = 150
        txtAddress.MaxLength = 150
        cno.MaxLength = 150
        uname.MaxLength = 150
        pword.MaxLength = 150
        cpword.MaxLength = 150

        LoadUserRole()
        CheckSuperAdmin()
        'btnSuperadmin.Visible = False

    End Sub
    ' === Load All Data ===
    Private Sub LoadData()
        ' Ensure DataGridView columns are defined
        If Guna2DataGridView1.Columns.Count = 0 Then
            Guna2DataGridView1.Columns.Clear()

            Guna2DataGridView1.Columns.Add("FirstName", "First Name")
            Guna2DataGridView1.Columns.Add("MI", "Middle Initial")
            Guna2DataGridView1.Columns.Add("LastName", "Last Name")
            Guna2DataGridView1.Columns.Add("Address", "Address")
            Guna2DataGridView1.Columns.Add("ContactNo", "Contact No")
            Guna2DataGridView1.Columns.Add("Username", "Username")
            Guna2DataGridView1.Columns.Add("UserType", "User Type")

            Dim editCol As New DataGridViewImageColumn()
            editCol.Name = "Edit"
            editCol.HeaderText = ""
            Guna2DataGridView1.Columns.Add(editCol)

            Dim deleteCol As New DataGridViewImageColumn()
            deleteCol.Name = "Delete"
            deleteCol.HeaderText = ""
            Guna2DataGridView1.Columns.Add(deleteCol)
        End If

        ' Clear DataGridView and backend DataTable
        Guna2DataGridView1.Rows.Clear()
        userTable.Clear()

        ' Ensure backend columns exist
        If userTable.Columns.Count = 0 Then
            userTable.Columns.Add("FirstName")
            userTable.Columns.Add("MI")
            userTable.Columns.Add("LastName")
            userTable.Columns.Add("Address")
            userTable.Columns.Add("ContactNo")
            userTable.Columns.Add("Username")
            userTable.Columns.Add("Password") ' backend only
            userTable.Columns.Add("UserType")
        End If

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim sql As String = "Select FirstName, LastName, MI, Address, ContactNo, Username, Password, UserType FROM users"
                    Using cmd As New MySqlCommand(sql, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                Dim firstName As String = If(IsDBNull(reader("FirstName")), "", reader("FirstName").ToString())
                                Dim mi As String = If(IsDBNull(reader("MI")), "", reader("MI").ToString())
                                Dim lastName As String = If(IsDBNull(reader("LastName")), "", reader("LastName").ToString())
                                Dim address As String = If(IsDBNull(reader("Address")), "", reader("Address").ToString())
                                Dim contact As String = If(IsDBNull(reader("ContactNo")), "", reader("ContactNo").ToString())
                                Dim username As String = If(IsDBNull(reader("Username")), "", reader("Username").ToString())
                                Dim password As String = If(IsDBNull(reader("Password")), "", reader("Password").ToString())
                                Dim userType As String = If(IsDBNull(reader("UserType")), "", reader("UserType").ToString())

                                userTable.Rows.Add(firstName, mi, lastName, address, contact, username, password, userType)

                                If userType.ToLower() <> "superadmin" Then
                                    Dim index As Integer = Guna2DataGridView1.Rows.Add(firstName, mi, lastName, address, contact, username, userType)
                                    Guna2DataGridView1.Rows(index).Cells("Edit").Value = My.Resources.icons8_edit_mains
                                    Guna2DataGridView1.Rows(index).Cells("Delete").Value = My.Resources.icons8_delete_mains
                                End If
                            End While
                        End Using
                    End Using
                Catch ex As MySqlException
                    MessageBox.Show("Error loading users: " & ex.Message)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using
    End Sub

    Private Sub CheckSuperAdmin()
        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                Dim query As String = "SELECT COUNT(*) FROM users WHERE Usertype = 'Superadmin'"

                Using cmd As New MySqlCommand(query, conn)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' 👉 Visible lang kapag MAY superadmin na
                    If count >= 1 Then
                        btnSuperadmin.Visible = True
                    Else
                        btnSuperadmin.Visible = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking superadmin: " & ex.Message)
        End Try
    End Sub



    Private Sub LoadUserRole()
        ' Clear existing items in ComboBox
        utype.Items.Clear()

        Dim hasSuperAdmin As Boolean = False

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim sql As String = "SELECT COUNT(*) FROM users WHERE LOWER(UserType) = 'superadmin'"
                    Using cmd As New MySqlCommand(sql, conn)
                        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        If count > 0 Then
                            hasSuperAdmin = True
                        End If
                    End Using
                Catch ex As MySqlException
                    MessageBox.Show("Error checking SuperAdmin: " & ex.Message)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using

        ' Populate ComboBox based on result
        If hasSuperAdmin Then
            ' ✅ Hide SuperAdmin if one already exists
            utype.Items.Add("Admin")
            utype.Items.Add("Cashier")
        Else
            ' 🚫 Only allow SuperAdmin creation if none exists yet
            utype.Items.Add("SuperAdmin")
        End If

        ' Optional: select first item by default
        If utype.Items.Count > 0 Then
            utype.SelectedIndex = 0
        End If
    End Sub



    ' === Load All User ===
    ' ===== LOAD USER COUNTS =====
    Private Sub LoadUserCounts()
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' === Total Super Admin ===
                Dim cmdSuper As New MySqlCommand("SELECT COUNT(*) FROM users WHERE UserType = 'SuperAdmin'", conn)
                lblTotalSupperadmin.Text = cmdSuper.ExecuteScalar().ToString()

                ' === Total Admin ===
                Dim cmdAdmin As New MySqlCommand("SELECT COUNT(*) FROM users WHERE UserType = 'Admin'", conn)
                lblTotalAdmin.Text = cmdAdmin.ExecuteScalar().ToString()

                ' === Total Cashier ===
                Dim cmdCashier As New MySqlCommand("SELECT COUNT(*) FROM users WHERE UserType = 'Cashier'", conn)
                lblTotalCashier.Text = cmdCashier.ExecuteScalar().ToString()
            End Using

            ' Apply font style once only
            lblTotalSupperadmin.Font = New Font("Outfit", 12, FontStyle.Bold)
            lblTotalAdmin.Font = New Font("Outfit", 12, FontStyle.Bold)
            lblTotalCashier.Font = New Font("Outfit", 12, FontStyle.Bold)



        Catch ex As Exception
            MessageBox.Show("Error loading user totals: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== TIMER TICK (Real-time update) =====
    Private Sub TimerUserCount_Tick(sender As Object, e As EventArgs) Handles timerUserCount.Tick
        LoadUserCounts()
    End Sub


    ' === Suppress DataGridView Default Errors ===
    Private Sub Guna2DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Guna2DataGridView1.DataError
        e.ThrowException = False
    End Sub

    ' === DataGridView Cell Content Click ===
    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex < 0 OrElse e.RowIndex >= Guna2DataGridView1.Rows.Count Then Exit Sub

        Dim clickedColumn As DataGridViewColumn = Guna2DataGridView1.Columns(e.ColumnIndex)
        Dim selectedRow As DataGridViewRow = Guna2DataGridView1.Rows(e.RowIndex)
        Dim usernameKey As String = If(selectedRow.Cells("Username").Value?.ToString(), "")


        lblCustom.Text = "Edit User"

        Select Case clickedColumn.Name
            Case "Edit"

                addbtn.Visible = False
                updatebtn.Visible = True
                'pword.Enabled = False
                'cpword.Enabled = False
                Mainpanel.Visible = True


                lblCustom.Text = "Edit User"



                ' Populate TextBoxes
                fname.Text = selectedRow.Cells("FirstName").Value?.ToString()
                minitial.Text = selectedRow.Cells("MI").Value?.ToString()
                lname.Text = selectedRow.Cells("LastName").Value?.ToString()
                txtAddress.Text = selectedRow.Cells("Address").Value?.ToString()
                cno.Text = selectedRow.Cells("ContactNo").Value?.ToString()
                uname.Text = usernameKey

                ' Save original values for update
                originalUsername = usernameKey
                originalcontactno = selectedRow.Cells("ContactNo").Value?.ToString()

                ' Get password from backend table
                Dim row As DataRow = userTable.Select("Username = '" & usernameKey.Replace("'", "''") & "'").FirstOrDefault()
                If row IsNot Nothing Then
                    pword.Text = row("Password").ToString()
                    cpword.Text = pword.Text
                End If

                ' Set ComboBox
                Dim userType As String = selectedRow.Cells("UserType").Value?.ToString()
                If Not String.IsNullOrEmpty(userType) Then
                    If Not utype.Items.Contains(userType) Then utype.Items.Add(userType)
                    utype.SelectedItem = userType
                Else
                    utype.SelectedIndex = -1
                End If

            Case "Delete"

                ' --- Safe delete with guard ---
                If Not String.IsNullOrEmpty(usernameKey) AndAlso Not isDeleting Then
                    isDeleting = True
                    DeleteUser(usernameKey)
                    isDeleting = False
                End If
        End Select
    End Sub



    ' === Setup DataGridView Columns ===
    Private Sub SetupDataGridView()
        Guna2DataGridView1.Columns.Clear()

        ' === Visible Data Columns ===
        Guna2DataGridView1.Columns.Add("FirstName", "First Name")
        Guna2DataGridView1.Columns.Add("MI", "MI")
        Guna2DataGridView1.Columns.Add("LastName", "Last Name")
        Guna2DataGridView1.Columns.Add("Address", "Address")
        Guna2DataGridView1.Columns.Add("ContactNo", "Contact No")
        Guna2DataGridView1.Columns.Add("Username", "Username")
        Guna2DataGridView1.Columns.Add("UserType", "User Type")

        ' === Edit Column ===
        If Guna2DataGridView1.Columns("Edit") Is Nothing Then
            Dim editCol As New DataGridViewImageColumn()
            editCol.Name = "Edit"
            editCol.HeaderText = "Edit"
            editCol.Image = My.Resources.icons8_edit_mains
            editCol.ImageLayout = DataGridViewImageCellLayout.Zoom
            editCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            editCol.Width = 60
            editCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Guna2DataGridView1.Columns.Add(editCol)
        End If

        ' === Delete Column ===
        If Guna2DataGridView1.Columns("Delete") Is Nothing Then
            Dim deleteCol As New DataGridViewImageColumn()
            deleteCol.Name = "Delete"
            deleteCol.HeaderText = "Delete"
            deleteCol.Image = My.Resources.icons8_delete_mains
            deleteCol.ImageLayout = DataGridViewImageCellLayout.Zoom
            deleteCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            deleteCol.Width = 60
            deleteCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            deleteCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
        End With

        ' === Set Column Widths (Proportional for text columns) ===
        Guna2DataGridView1.Columns("FirstName").FillWeight = 120
        Guna2DataGridView1.Columns("MI").FillWeight = 40
        Guna2DataGridView1.Columns("LastName").FillWeight = 120
        Guna2DataGridView1.Columns("Address").FillWeight = 200
        Guna2DataGridView1.Columns("ContactNo").FillWeight = 120
        Guna2DataGridView1.Columns("Username").FillWeight = 100
        Guna2DataGridView1.Columns("UserType").FillWeight = 80
    End Sub


    ' === Load User Types ===
    Private Sub LoadUserTypes()
        utype.Items.Clear()

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    ' Check if "Superadmin" exists in the user types
                    Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE UserType = 'Superadmin'", conn)
                    Dim superadminExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    ' Add user types to ComboBox
                    Dim userTypes As New List(Of String)({"Cashier", "Admin"})
                    If superadminExists = 0 Then
                        userTypes.Add("Superadmin")
                    End If

                    utype.Items.AddRange(userTypes.ToArray())
                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using
    End Sub

    ' === ADD USER ===
    Private Sub addbtn_Click(sender As Object, e As EventArgs) Handles addbtn.Click
        If Not ValidateInputs() Then Exit Sub

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Exit Sub

            Try
                ' --- Check kung may SuperAdmin na ---
                If utype.SelectedItem.ToString().Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase) Then
                    Dim checkSuperCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE UserType = 'SuperAdmin'", conn)
                    Dim superCount As Integer = Convert.ToInt32(checkSuperCmd.ExecuteScalar())
                    If superCount > 0 Then
                        MessageBox.Show(" A SuperAdmin already exists. You cannot add another one.",
                                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ' Optional: focus lang sa combo box, hindi mag-exit
                        utype.Focus()
                        Return
                    End If
                End If

                ' --- Check Username duplication ---
                Dim checkUserCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE Username = @Username", conn)
                checkUserCmd.Parameters.AddWithValue("@Username", uname.Text.Trim())
                Dim userExists As Integer = Convert.ToInt32(checkUserCmd.ExecuteScalar())
                If userExists > 0 Then
                    MessageBox.Show(" Username already exists. Please choose a different one.",
                                "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    uname.Clear()
                    uname.Focus()
                    Return
                End If

                ' --- Check ContactNo duplication ---
                Dim checkCnoCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE ContactNo = @ContactNo", conn)
                checkCnoCmd.Parameters.AddWithValue("@ContactNo", cno.Text.Trim())
                Dim CnoExists As Integer = Convert.ToInt32(checkCnoCmd.ExecuteScalar())
                If CnoExists > 0 Then
                    MessageBox.Show("Contact Number already exists. Please choose a different one.",
                                "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cno.Clear()
                    cno.Focus()
                    Return
                End If

                ' --- Check Address duplication ---
                Dim checkAddressCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE Address = @Address", conn)
                checkAddressCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                Dim addressExists As Integer = Convert.ToInt32(checkAddressCmd.ExecuteScalar())

                If addressExists > 0 Then
                    MessageBox.Show("Address already exists. Duplicate address is not allowed.",
                    "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAddress.Focus()
                    Return
                End If

                ' --- Insert New User ---
                Dim cmd As New MySqlCommand("
                INSERT INTO users 
                (ContactNo, FirstName, LastName, MI, Address, Username, Password, UserType) 
                VALUES (@ContactNo, @FirstName, @LastName, @MI, @Address, @Username, @Password, @UserType)", conn)

                cmd.Parameters.AddWithValue("@ContactNo", cno.Text.Trim())
                cmd.Parameters.AddWithValue("@FirstName", fname.Text.Trim())
                cmd.Parameters.AddWithValue("@LastName", lname.Text.Trim())
                cmd.Parameters.AddWithValue("@MI", If(String.IsNullOrWhiteSpace(minitial.Text), DBNull.Value, minitial.Text.Trim()))
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@Username", uname.Text.Trim())
                cmd.Parameters.AddWithValue("@Password", pword.Text.Trim())
                cmd.Parameters.AddWithValue("@UserType", utype.SelectedItem.ToString())
                cmd.ExecuteNonQuery()

                ' --- Audit Trail ---
                Dim actorRole As String = If(String.IsNullOrWhiteSpace(SessionData.role), "Default", SessionData.role)
                Dim actorName As String = If(String.IsNullOrWhiteSpace(SessionData.fullName), "Default", SessionData.fullName)
                LogAuditTrail(actorRole, actorName, $"Added new user: {If(fname.Text, "")} {If(lname.Text, "")}")

                ' --- If SuperAdmin, force logout ---
                If utype.SelectedItem.ToString().Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase) Then
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is Dashboard Then
                            DirectCast(f, Dashboard).TriggerLogout()
                            Exit For
                        End If
                    Next
                    Return
                End If

                ' --- Final UI feedback ---
                clear()
                LoadData()
                Mainpanel.Visible = False
                SystemSounds.Exclamation.Play()
                MessageBox.Show("Successfully Added!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As MySqlException
                MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub





    ' === UPDATE USER ===
    Private Sub updatebtn_Click(sender As Object, e As EventArgs) Handles updatebtn.Click
        If Not ValidateInputs() Then Exit Sub
        If String.IsNullOrWhiteSpace(originalUsername) Then Exit Sub

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Exit Sub

            Try
                Dim newUsername As String = uname.Text.Trim()
                Dim newContact As String = cno.Text.Trim()
                Dim newAddress As String = txtAddress.Text.Trim()

                ' --- Check duplicate username (if changed) ---
                If Not String.Equals(originalUsername.Trim(), newUsername, StringComparison.OrdinalIgnoreCase) Then

                    Dim checkUserCmd As New MySqlCommand("
                    SELECT COUNT(*) FROM users 
                    WHERE LOWER(Username) = LOWER(@Username)", conn)

                    checkUserCmd.Parameters.AddWithValue("@Username", newUsername)

                    If Convert.ToInt32(checkUserCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("The username already exists. Please enter a different one.",
                                    "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        uname.Focus()
                        Return
                    End If
                End If


                ' --- Check duplicate contact number (if changed) ---
                If Not String.Equals(originalcontactno.Trim(), newContact, StringComparison.Ordinal) Then

                    Dim checkCnoCmd As New MySqlCommand("
                    SELECT COUNT(*) FROM users 
                    WHERE ContactNo = @ContactNo 
                    AND LOWER(Username) <> LOWER(@OriginalUsername)", conn)

                    checkCnoCmd.Parameters.AddWithValue("@ContactNo", newContact)
                    checkCnoCmd.Parameters.AddWithValue("@OriginalUsername", originalUsername.Trim())

                    If Convert.ToInt32(checkCnoCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("The contact number already exists. Please enter a different one.",
                                    "Duplicate Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        cno.Focus()
                        Return
                    End If
                End If


                ' --- Get old values for audit trail ---
                Dim oldValues As New Dictionary(Of String, String)

                Dim getCurrentCmd As New MySqlCommand("
                SELECT FirstName, MI, LastName, Address, ContactNo, Username, Password, UserType 
                FROM users 
                WHERE LOWER(Username)=LOWER(@OriginalUsername)", conn)

                getCurrentCmd.Parameters.AddWithValue("@OriginalUsername", originalUsername.Trim())

                Using reader = getCurrentCmd.ExecuteReader()
                    If reader.Read() Then
                        oldValues("FirstName") = reader("FirstName").ToString().Trim()
                        oldValues("MI") = If(IsDBNull(reader("MI")), "", reader("MI").ToString().Trim())
                        oldValues("LastName") = reader("LastName").ToString().Trim()
                        oldValues("Address") = reader("Address").ToString().Trim()
                        oldValues("ContactNo") = reader("ContactNo").ToString().Trim()
                        oldValues("Username") = reader("Username").ToString().Trim()
                        oldValues("Password") = reader("Password").ToString().Trim()
                        oldValues("UserType") = reader("UserType").ToString().Trim()
                    End If
                End Using


                ' --- Check duplicate address (if changed) ---
                If Not String.Equals(oldValues("Address"), newAddress, StringComparison.OrdinalIgnoreCase) Then

                    Dim checkAddressCmd As New MySqlCommand("
                    SELECT COUNT(*) FROM users 
                    WHERE LOWER(Address) = LOWER(@Address)
                    AND LOWER(Username) <> LOWER(@OriginalUsername)", conn)

                    checkAddressCmd.Parameters.AddWithValue("@Address", newAddress)
                    checkAddressCmd.Parameters.AddWithValue("@OriginalUsername", originalUsername.Trim())

                    If Convert.ToInt32(checkAddressCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("The address already exists. Duplicate address is not allowed.",
                                    "Duplicate Address", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtAddress.Focus()
                        Return
                    End If
                End If


                ' --- Update record ---
                Dim cmd As New MySqlCommand("
                UPDATE users SET
                    FirstName=@FirstName, MI=@MI, LastName=@LastName, Address=@Address,
                    ContactNo=@ContactNo, Username=@Username, Password=@Password, UserType=@UserType
                WHERE LOWER(Username)=LOWER(@OriginalUsername)", conn)

                Dim newRole As String = If(utype.SelectedItem IsNot Nothing, utype.SelectedItem.ToString(), "")

                cmd.Parameters.AddWithValue("@FirstName", fname.Text.Trim())
                cmd.Parameters.AddWithValue("@MI", If(String.IsNullOrWhiteSpace(minitial.Text), DBNull.Value, minitial.Text.Trim()))
                cmd.Parameters.AddWithValue("@LastName", lname.Text.Trim())
                cmd.Parameters.AddWithValue("@Address", newAddress)
                cmd.Parameters.AddWithValue("@ContactNo", newContact)
                cmd.Parameters.AddWithValue("@Username", newUsername)
                cmd.Parameters.AddWithValue("@Password", pword.Text.Trim())
                cmd.Parameters.AddWithValue("@UserType", newRole)
                cmd.Parameters.AddWithValue("@OriginalUsername", originalUsername.Trim())

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then

                    ' --- Compare old vs new values for audit trail ---
                    Dim updatedFields As New List(Of String)

                    If fname.Text.Trim() <> oldValues("FirstName") Then
                        updatedFields.Add($"First Name: ""{oldValues("FirstName")}"" → ""{fname.Text.Trim()}""")
                    End If

                    If minitial.Text.Trim() <> oldValues("MI") Then
                        updatedFields.Add($"MI: ""{oldValues("MI")}"" → ""{minitial.Text.Trim()}""")
                    End If

                    If lname.Text.Trim() <> oldValues("LastName") Then
                        updatedFields.Add($"Last Name: ""{oldValues("LastName")}"" → ""{lname.Text.Trim()}""")
                    End If

                    If newAddress <> oldValues("Address") Then
                        updatedFields.Add($"Address: ""{oldValues("Address")}"" → ""{newAddress}""")
                    End If

                    If newContact <> oldValues("ContactNo") Then
                        updatedFields.Add($"Contact No: ""{oldValues("ContactNo")}"" → ""{newContact}""")
                    End If

                    If newUsername <> oldValues("Username") Then
                        updatedFields.Add($"Username: ""{oldValues("Username")}"" → ""{newUsername}""")
                    End If

                    If newRole <> oldValues("UserType") Then
                        updatedFields.Add($"Role: ""{oldValues("UserType")}"" → ""{newRole}""")
                    End If

                    If updatedFields.Count > 0 Then
                        Dim actionDescription As String = "Updated User Details:" &
                                                      vbCrLf & String.Join(vbCrLf, updatedFields)

                        Dim actorRole As String = If(String.IsNullOrWhiteSpace(SessionData.role), "System", SessionData.role)
                        Dim actorName As String = If(String.IsNullOrWhiteSpace(SessionData.fullName), "System", SessionData.fullName)

                        LogAuditTrail(actorRole, actorName, actionDescription)
                    End If

                    SystemSounds.Exclamation.Play()
                    MessageBox.Show("Successfully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Mainpanel.Visible = False
                    clear()
                    addbtn.Enabled = True
                    updatebtn.Visible = False
                    LoadData()
                End If

            Catch ex As MySqlException
                MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub





    ' === DELETE USER ===
    Public Sub DeleteUser(username As String)
            If String.IsNullOrWhiteSpace(username) Then Exit Sub

            Dim confirm As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete user '{username}'?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

            If confirm <> DialogResult.Yes Then Exit Sub

            Using conn As MySqlConnection = Module1.Openconnection()
                If conn Is Nothing Then
                    MessageBox.Show("Failed to connect to database.")
                    Exit Sub
                End If

                Try
                    ' --- Get full name for audit ---
                    Dim fullName As String = ""
                    Using getNameCmd As New MySqlCommand("SELECT CONCAT(FirstName, ' ', IFNULL(MI,''), ' ', LastName) AS FullName FROM users WHERE Username=@Username", conn)
                        getNameCmd.Parameters.AddWithValue("@Username", username)
                        fullName = If(getNameCmd.ExecuteScalar(), "").ToString().Trim()
                    End Using

                    ' --- Delete user ---
                    Using deleteCmd As New MySqlCommand("DELETE FROM users WHERE Username=@Username", conn)
                        deleteCmd.Parameters.AddWithValue("@Username", username)
                        Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            ' --- Log deletion ---
                            LogAuditTrail(SessionData.role, SessionData.fullName, $"Deleted User: {fullName} (Username: {username})")

                        'Dim msg As New deleteMessagebox()
                        'msg.StartPosition = FormStartPosition.Manual
                        'msg.Location = New Point(540, 140)
                        'msg.Show()

                        SystemSounds.Exclamation.Play()

                        MessageBox.Show("Successfully deleted!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        clear()
                            LoadData()
                        addbtn.Enabled = True

                    Else
                            MessageBox.Show("No user was deleted. Please check the username.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using

                Catch ex As MySqlException
                    MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End Using
        End Sub


        Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click

        fname.Clear()
        lname.Clear()
        minitial.Clear()
        cno.Clear()
        txtAddress.Clear()
        uname.Clear()
        pword.Clear()
        cpword.Clear()
        utype.Items.Clear()
        LoadUserTypes()



    End Sub

    ' === REFRESH & CLEAR ===
    Private Sub refresh_user()
        LoadData()
        clear()
        LoadUserTypes()
    End Sub

    ' === VALIDATION ===
    Private Function ValidateInputs() As Boolean
        ' --- First Name ---
        If String.IsNullOrWhiteSpace(fname.Text) Then
            MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            fname.Focus()
            Return False
        End If

        ' --- Last Name ---
        If String.IsNullOrWhiteSpace(lname.Text) Then
            MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lname.Focus()
            Return False
        End If

        ' --- Address ---
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Return False
        End If

        ' --- Contact Number ---
        If String.IsNullOrWhiteSpace(cno.Text) OrElse Not Regex.IsMatch(cno.Text, "^\d{1,15}$") Then
            MessageBox.Show("Contact Number must contain only digits (up to 15).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cno.Focus()
            Return False
        End If

        ' --- Username ---
        If String.IsNullOrWhiteSpace(uname.Text) Then
            MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            uname.Focus()
            Return False
        End If

        ' --- Reserved Username ---
        If uname.Text.Trim().ToLower() = "superadmin" Then
            MessageBox.Show("The username 'superadmin' is reserved. Please choose a different username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            uname.Focus()
            Return False
        End If

        ' --- Password ---
        If String.IsNullOrWhiteSpace(pword.Text) OrElse Not IsValidPassword(pword.Text) Then
            MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pword.Clear()
            pword.Focus()
            Return False
        End If

        ' --- Confirm Password ---
        If pword.Text <> cpword.Text Then
            MessageBox.Show("Password and Confirm Password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pword.Clear()
            cpword.Clear()
            pword.Focus()
            Return False
        End If

        ' --- User Type ---
        If utype.SelectedIndex = -1 Then
            MessageBox.Show("Please select a User Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            utype.Focus()
            Return False
        End If

        ' ✅ All inputs are valid
        Return True
    End Function


    Private Function IsValidPassword(password As String) As Boolean
        ' Adjust the password validation logic as needed
        Return password.Length >= 8
    End Function

    ' === KEYPRESS VALIDATIONS ===

    ' Contact Number
    Private Sub cno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cno.KeyPress
        ' Ensure the first two characters are always "09"

        If cno.Text.Length = 0 AndAlso e.KeyChar <> "0"c Then
            e.Handled = True
        ElseIf cno.Text.Length = 1 AndAlso e.KeyChar <> "9"c Then
            e.Handled = True
        End If

        ' Allow only 11 digits (for a valid phone number format starting with "09")
        If cno.Text.Length >= 11 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        ' Ensure it's a digit or control key (backspace, etc.)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' First Name
    Private Sub fname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fname.KeyPress
        Dim txt = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)

        ' Detect Ctrl+V (paste)
        If (ModifierKeys = Keys.Control AndAlso e.KeyChar = ChrW(22)) Then
            If Clipboard.ContainsText() Then
                Dim clipboardText As String = Clipboard.GetText()

                ' Check if clipboard contains only letters
                If clipboardText.All(AddressOf Char.IsLetter) Then
                    ' Check if pasted result will not exceed 100 characters
                    If (txt.TextLength + clipboardText.Length) <= 100 Then
                        ' Allow paste
                        Return
                    End If
                End If
            End If

            ' If not valid letters or exceeds 100, block paste
            e.Handled = True
            Return
        End If

        ' Normal typing: allow letters and control keys only
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Typing letters: limit to 100
        If Char.IsLetter(e.KeyChar) AndAlso txt.TextLength >= 100 Then
            e.Handled = True
        End If
    End Sub

    ' Middle Initial
    Private Sub minitial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles minitial.KeyPress
        ' Allow only one letter for the middle initial
        If minitial.Text.Length >= 1 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        ' Ensure it's a letter or control key (backspace, etc.)
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Address
    Private Sub txtaddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddress.KeyPress
        Dim txt = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)

        ' Detect Ctrl+V (paste)
        If (ModifierKeys = Keys.Control AndAlso e.KeyChar = ChrW(22)) Then
            If Clipboard.ContainsText() Then
                Dim clipboardText As String = Clipboard.GetText()

                ' Check if clipboard contains only letters, numbers, spaces, or hyphens
                If clipboardText.All(Function(c) Char.IsLetterOrDigit(c) OrElse Char.IsWhiteSpace(c) OrElse c = "-"c) Then
                    ' Check if pasted result will not exceed 200 characters
                    If (txt.TextLength + clipboardText.Length) <= 200 Then
                        ' Allow paste
                        Return
                    End If
                End If
            End If

            ' If not valid text or exceeds 200 characters, block paste
            e.Handled = True
            Return
        End If

        ' Normal typing: allow letters, numbers, spaces, hyphens, and control keys only
        If Not Char.IsControl(e.KeyChar) AndAlso Not (Char.IsLetterOrDigit(e.KeyChar) OrElse Char.IsWhiteSpace(e.KeyChar) OrElse e.KeyChar = "-"c) Then
            e.Handled = True
            Return
        End If

        ' Limit typing to 200 characters
        If txt.TextLength >= 200 Then
            e.Handled = True
        End If
    End Sub



    ' === CLEAR ===
    Private Sub clear()
        ' Implement your clear logic for input fields
        fname.Clear()
        lname.Clear()
        minitial.Clear() ' This is optional, so we can clear it
        txtAddress.Clear()
        cno.Clear()
        uname.Clear()
        pword.Clear()
        cpword.Clear()
        utype.SelectedIndex = -1
    End Sub


    ' === BUTTON EVENTS ===
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    ' ===== Search function =====
    Private Sub btnsearchuser_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim searchText As String = txtsearch.Text.Trim().ToLower()

        ' If search is empty, reload all users
        If String.IsNullOrEmpty(searchText) Then
            LoadData()
            Exit Sub
        End If

        ' Filter using DataView
        Dim dv As New DataView(userTable)

        ' Null-safe filter
        dv.RowFilter = String.Format(
        "ISNULL(FirstName,'') LIKE '%{0}%' OR ISNULL(MI,'') LIKE '%{0}%' OR ISNULL(LastName,'') LIKE '%{0}%' OR ISNULL(Username,'') LIKE '%{0}%' OR ISNULL(UserType,'') LIKE '%{0}%'",
        searchText.Replace("'", "''")
    )

        ' Clear current DataGridView rows
        Guna2DataGridView1.Rows.Clear()

        ' Add filtered rows manually (preserves Edit/Delete)
        For Each rowView As DataRowView In dv
            Dim row As DataRow = rowView.Row

            ' Skip SuperAdmin
            If row("UserType").ToString().ToLower() = "superadmin" Then Continue For

            Dim index As Integer = Guna2DataGridView1.Rows.Add(
            row("FirstName").ToString(),
            row("MI").ToString(),
            row("LastName").ToString(),
            row("Address").ToString(),
            row("ContactNo").ToString(),
            row("Username").ToString(),
            row("UserType").ToString()
        )

            ' Set Edit/Delete images
            'Guna2DataGridView1.Rows(index).Cells("Edit").Value = My.Resources.icons8_pencil_30
            'Guna2DataGridView1.Rows(index).Cells("Delete").Value = My.Resources.icons8_delete_30

            ' Highlight row
            Guna2DataGridView1.Rows(index).DefaultCellStyle.BackColor = Color.LightYellow
            Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionBackColor = Color.Orange
            Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Black
        Next
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub fname_TextChanged(sender As Object, e As EventArgs) Handles fname.TextChanged
        Dim txt = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)

        ' Remove any non-letter characters, and limit to 100 characters
        Dim newText = New String(txt.Text.Where(AddressOf Char.IsLetter).Take(50).ToArray())

        If txt.Text <> newText Then
            txt.Text = newText
            txt.SelectionStart = txt.TextLength
        End If
    End Sub

    'Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
    '    If Me.Owner IsNot Nothing Then
    '        Dim dashboard As Dashboard = CType(Me.Owner, Dashboard)
    '        dashboard.PanelMain.SendToBack()
    '    End If

    '    Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '    If result = DialogResult.Yes Then
    '        Me.Close()
    '    End If
    'End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        clear()
        LoadData()
        updatebtn.Visible = False
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
                    cmd.Parameters.AddWithValue("@Form", "Users")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddnewUser_Click(sender As Object, e As EventArgs) Handles btnAddnewUser.Click
        ' --- Enable/disable controls ---
        addbtn.Visible = True
        updatebtn.Visible = False
        pword.Enabled = True
        cpword.Enabled = True

        Mainpanel.Visible = True
        Mainpanel.BringToFront()

        lblCustom.Text = "Add New User"

        ' --- Step 3: (optional) Center MainPanel sa form ---
        Mainpanel.Location = New Point(
        (Me.ClientSize.Width - Mainpanel.Width) \ 2,
        (Me.ClientSize.Height - Mainpanel.Height) \ 2
    )
        clear()

    End Sub



    '====================== UI '======================

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === DEFAULT COLORS & IMAGES ===
        btnAddnewUser.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnAddnewUser.ForeColor = Color.White
        btnAddnewUser.Image = My.Resources.icons8_add_30_normal ' normal icon

        'btnSort.FillColor = ColorTranslator.FromHtml("#1D3A70")
        'btnSort.ForeColor = Color.White
        'btnSort.Image = My.Resources.icons8_alphabetical_sorting_normal ' normal icon


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
        AddHandler btnSuperadmin.MouseEnter, Sub()
                                                 btnSuperadmin.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                 btnSuperadmin.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                 btnSuperadmin.Image = My.Resources.icons8_admin_hindi ' hover icon
                                             End Sub

        AddHandler btnSuperadmin.MouseLeave, Sub()
                                                 btnSuperadmin.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                 btnSuperadmin.ForeColor = Color.White
                                                 btnSuperadmin.Image = My.Resources.icons8_admin_normal  ' normal icon
                                             End Sub


        ' === OPTIONAL: CENTER THE FORM ON SCREEN ===
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Mainpanel.Visible = False
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub

    Private Sub btnSuperadmin_Click(sender As Object, e As EventArgs) Handles btnSuperadmin.Click
        ' Check if a user is logged in and their role
        If Not String.IsNullOrEmpty(SessionData.role) AndAlso SessionData.role.ToLower() = "superadmin" Then
            ' Allow access: open the Superadmin form
            Dim saForm As New Superadmin()
            saForm.ShowDialog()
        Else
            ' Deny access
            MessageBox.Show("Access denied. Only Superadmin can access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


End Class

