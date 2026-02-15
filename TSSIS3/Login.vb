Imports System.Drawing.Drawing2D
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class Login

    Private Const CornerRadius As Integer = 10 ' fixed radius


    '=============================
    '       DECLARATIONS
    '=============================
    Private keyBuffer As New List(Of Keys)()
    Private ReadOnly requiredSequence As Keys() = {Keys.A, Keys.D, Keys.M, Keys.I, Keys.N}

    '=============================
    '       CONSTRUCTOR
    '=============================
    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True
    End Sub

    '=============================
    '       FORM LOAD
    '=============================
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ApplyRoundedCorners()
        ' ===== Automatic Default Superadmin =====
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
        End Using

        ' UI Setup

        loginbtn.FillColor = ColorTranslator.FromHtml("#0B2447")

        loginbtn.BorderRadius = 10

        pword.UseSystemPasswordChar = True

        ' Example font: Outfit, 10pt, Regular
        uname.Font = New Font("Outfit", 9, FontStyle.Regular)
        pword.Font = New Font("Outfit", 9, FontStyle.Regular)
        CheckBox1.Font = New Font("Outfit", 9, FontStyle.Regular)
        loginbtn.Font = New Font("Outfit", 9, FontStyle.Bold)


        PictureBox2.SendToBack()
        EnsureDefaultSuperAdmin()
    End Sub

    Public Sub EnsureDefaultSuperAdmin()
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    ' Check if default SuperAdmin already exists
                    Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE Username='superadmin'", conn)
                    Dim existsCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If existsCount = 0 Then
                        ' Insert default SuperAdmin only once
                        Dim insertCmd As New MySqlCommand("
                        INSERT INTO users 
                        (ContactNo, FirstName, LastName, MI, Address, Username, Password, UserType)
                        VALUES 
                        (@ContactNo, @FirstName, @LastName, @MI, @Address, @Username, @Password, @UserType)
                    ", conn)

                        insertCmd.Parameters.AddWithValue("@ContactNo", "09123456789")
                        insertCmd.Parameters.AddWithValue("@FirstName", "Super")
                        insertCmd.Parameters.AddWithValue("@LastName", "Admin")
                        insertCmd.Parameters.AddWithValue("@MI", "")
                        insertCmd.Parameters.AddWithValue("@Address", "Taller Store")
                        insertCmd.Parameters.AddWithValue("@Username", "superadmin")
                        insertCmd.Parameters.AddWithValue("@Password", "123456") ' hash later
                        insertCmd.Parameters.AddWithValue("@UserType", "defult") ' hidden account

                        insertCmd.ExecuteNonQuery()

                        MessageBox.Show("Default SuperAdmin account created." & vbCrLf &
                                    "Username: superadmin" & vbCrLf &
                                    "Password: 123456",
                                    "Default Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As MySqlException
                    MessageBox.Show("Database error: " & ex.Message)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using
    End Sub



    ' Shared instance


    Private Function LoadSessionData(username As String) As Boolean
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
            Using cmd As New MySqlCommand("SELECT FirstName, MI, LastName, UserType FROM users WHERE username = @username LIMIT 1", conn)
                cmd.Parameters.AddWithValue("@username", username)

                Using rdr As MySqlDataReader = cmd.ExecuteReader()
                    If rdr.Read() Then
                        ' --- Get first, middle initial, last name ---
                        Dim firstName As String = If(rdr("FirstName") Is DBNull.Value, "", rdr("FirstName").ToString().Trim())
                        Dim middleInitial As String = If(rdr("MI") Is DBNull.Value, "", rdr("MI").ToString().Trim())
                        Dim lastName As String = If(rdr("LastName") Is DBNull.Value, "", rdr("LastName").ToString().Trim())

                        ' --- Combine full name ---
                        Dim fullName As String = firstName
                        If middleInitial <> "" Then fullName &= " " & middleInitial & "."
                        If lastName <> "" Then fullName &= " " & lastName

                        ' --- Set session data ---
                        SessionData.fullName = fullName
                        SessionData.role = If(rdr("UserType") Is DBNull.Value, "", rdr("UserType").ToString().Trim())

                        Return True
                    Else
                        ' Walang user sa DB
                        Return False
                    End If
                End Using
            End Using
        End Using
    End Function




    ' --- Apply rounded corners
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

    '=============================
    '       CHECKBOX LOGIC
    '=============================
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            pword.UseSystemPasswordChar = False   ' Show password
            CheckBox1.Text = "Hide Password"
        Else
            pword.UseSystemPasswordChar = True    ' Hide password
            CheckBox1.Text = "Show Password"
        End If
    End Sub


    '=============================
    '       LOGIN LOGIC
    '=============================
    Private Sub loginbtn_Click(sender As Object, e As EventArgs) Handles loginbtn.Click
        Dim username As String = uname.Text.Trim()
        Dim password As String = pword.Text.Trim()

        ' === 1️⃣ Check empty fields ===
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' === 2️⃣ Check if SuperAdmin exists (optional, can keep original logic) ===
        Dim superAdminExists As Boolean = False
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim checkSuperAdminCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE UserType = 'SuperAdmin'", conn)
                    superAdminExists = Convert.ToInt32(checkSuperAdminCmd.ExecuteScalar()) > 0
                Catch ex As MySqlException
                    MsgBox("Database Error: " & ex.Message)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using

        '' === 3️⃣ Default SuperAdmin login (optional, keep original) ===
        'If username = "superadmin" And password = "superadmin" Then
        '    If superAdminExists Then
        '        MsgBox("Default SuperAdmin account is disabled because a SuperAdmin already exists in the database.", MsgBoxStyle.Exclamation, "Login Disabled")
        '        Return
        '    End If

        '    ' --- Set session ---
        '    SessionData.fullName = "Super Admin"
        '    SessionData.role = "SuperAdmin"

        '    ' ✅ Show login success message
        '    MsgBox("Login successful. Welcome SuperAdmin!", MsgBoxStyle.Information, "Login Status")

        '    ' ✅ Log the login action using default values if SessionData is empty
        '    Dim actorRole As String = If(String.IsNullOrWhiteSpace(SessionData.role), "Default", SessionData.role)
        '    Dim actorName As String = If(String.IsNullOrWhiteSpace(SessionData.fullName), "Default", SessionData.fullName)
        '    LogHistory.LogAction(actorRole, actorName, "Logged in")


        '    Dim dashboard As New Dashboard
        '    dashboard.Show()
        '    Me.Hide()
        '    Return
        'End If

        ' === 4️⃣ Normal user login (including SuperAdmin from DB) ===
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim query As String = "
                    SELECT UserType, ContactNo,
                           CONCAT(FirstName, IF(MI IS NOT NULL AND MI <> '', CONCAT(' ', MI), ''), ' ', LastName) AS FullName
                    FROM users
                    WHERE Username = @Username AND BINARY Password = @Password"

                    Dim checkUserCmd As New MySqlCommand(query, conn)
                    checkUserCmd.Parameters.AddWithValue("@Username", username)
                    checkUserCmd.Parameters.AddWithValue("@Password", password)

                    Using reader As MySqlDataReader = checkUserCmd.ExecuteReader()
                        If reader.Read() Then
                            Dim userType As String = reader("UserType").ToString()
                            Dim fullName As String = reader("FullName").ToString()
                            Dim contactNo As String = reader("ContactNo").ToString()

                            ' === Store session ===
                            SessionData.role = userType
                            SessionData.fullName = fullName

                            MessageBox.Show("Login successful!", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            LogHistory.LogAction(SessionData.role, SessionData.fullName, "Logged in")

                            ' === New: Direct Cashier to POS ===
                            If userType.ToLower() = "cashier" Then
                                Dim posForm As New POS()
                                posForm.Show()
                                Me.Hide()
                                Return
                            End If

                            ' === Otherwise, open Dashboard ===
                            Dim dashboard As New Dashboard()
                            dashboard.Show()
                            Me.Hide()

                        Else
                            MsgBox("Invalid username or password. Please try again.", MsgBoxStyle.Information, "Login Failed")

                        End If
                    End Using

                Catch ex As MySqlException
                    MsgBox("Database Error: " & ex.Message)
                Catch ex As Exception
                    MsgBox("Error: " & ex.Message)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using
    End Sub


    '=============================
    '       KEY SEQUENCE LOGIC (Ctrl + A D M I N)
    '=============================
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            If requiredSequence.Contains(e.KeyCode) Then
                keyBuffer.Add(e.KeyCode)

                If keyBuffer.Count > requiredSequence.Length Then
                    keyBuffer.RemoveAt(0)
                End If

                If keyBuffer.SequenceEqual(requiredSequence) Then
                    Dim dashboard As New Dashboard()
                    dashboard.Show()
                    keyBuffer.Clear()

                End If
            End If
        Else
            keyBuffer.Clear()
        End If



    End Sub

    '=============================
    '       EXIT BUTTON LOGIC
    '=============================
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then Application.Exit()
    End Sub

    Private Sub loginFormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    '=============================
    '       PANEL UI
    '=============================

    '=====================================
    '       VALIDATION KEYPRESS LOGIC / KEYDOWN
    '=====================================
    '=== USERNAME ===
    Private Sub pword_KeyDown(sender As Object, e As KeyEventArgs) Handles pword.KeyDown
        If e.KeyCode = Keys.Enter Then
            loginbtn.PerformClick()  ' Trigger the login button click
        End If
    End Sub

    Private Sub uname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uname.KeyPress
        ' Prevent spaces
        If e.KeyChar = " "c Then
            e.Handled = True
            MessageBox.Show("Spaces are not allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    '=== PASSWORD ===
    Private Sub pword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pword.KeyPress
        ' Prevent spaces
        If e.KeyChar = " "c Then
            e.Handled = True
            MessageBox.Show("Spaces are not allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    '========= FOR ALT F4 =========
    Private Sub login_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub btnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click
        CheckBox1.Checked = False
        btnHide.Visible = False
        btnShow.Visible = True
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        CheckBox1.Checked = True
        btnHide.Visible = True
        btnShow.Visible = False
    End Sub


End Class
