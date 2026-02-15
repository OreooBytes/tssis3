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

Public Class Superadmin

    Private Const CornerRadius As Integer = 10

    Private Sub Superadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuperadminDetails() ' Replace with the actual logged-in username
        ApplyRoundedCorners()
        ' === Light Gray Rounded Border ===
        With Guna2Panel1
            .FillColor = Color.White
            .BorderColor = ColorTranslator.FromHtml("#D3D3D3")
            .BorderThickness = 2
            .BorderRadius = 10
            .BringToFront()
        End With

        BackColor = ColorTranslator.FromHtml("#0B2447")


        ' ===== TextBoxes (Regular 9) =====
        fname.Font = New Font("Outfit", 9, FontStyle.Regular)
        minitial.Font = New Font("Outfit", 9, FontStyle.Regular)
        pword.Font = New Font("Outfit", 9, FontStyle.Regular)
        lname.Font = New Font("Outfit", 9, FontStyle.Regular)
        cno.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtAddress.Font = New Font("Outfit", 9, FontStyle.Regular)
        uname.Font = New Font("Outfit", 9, FontStyle.Regular)
        cpword.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== Labels (Bold 9) =====
        Label1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label2.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label3.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label4.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label5.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label6.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label7.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label9.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label10.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== Buttons (Bold 9) =====
        clearbtn.Font = New Font("Outfit", 9, FontStyle.Bold)
        updatebtn.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== Set MaxLength to 150 =====
        fname.MaxLength = 150
        minitial.MaxLength = 150
        lname.MaxLength = 150
        txtAddress.MaxLength = 150
        cno.MaxLength = 150
        uname.MaxLength = 150
        pword.MaxLength = 150
        cpword.MaxLength = 150


    End Sub



    ' Apply rounded corners to the form
    Private Sub ApplyRoundedCorners()
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90) ' Top-left
        path.AddLine(CornerRadius, 0, Me.Width - CornerRadius, 0) ' Top
        path.AddArc(Me.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90) ' Top-right
        path.AddLine(Me.Width, CornerRadius, Me.Width, Me.Height - CornerRadius) ' Right
        path.AddArc(Me.Width - CornerRadius, Me.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90) ' Bottom-right
        path.AddLine(Me.Width - CornerRadius, Me.Height, CornerRadius, Me.Height) ' Bottom
        path.AddArc(0, Me.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90) ' Bottom-left
        path.AddLine(0, Me.Height - CornerRadius, 0, CornerRadius) ' Left
        path.CloseFigure()
        Me.Region = New Region(path)
        Me.Invalidate()
    End Sub

    ' Load superadmin details into textboxes
    Private Sub LoadSuperadminDetails()
        Using conn As New MySqlConnection(connectionstring)
            Try
                conn.Open()
                Dim sql As String = "SELECT FirstName, MI, LastName, Address, ContactNo, Username, Password 
                                 FROM users 
                                 WHERE UserType='Superadmin' LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            fname.Text = If(IsDBNull(reader("FirstName")), "", reader("FirstName").ToString())
                            minitial.Text = If(IsDBNull(reader("MI")), "", reader("MI").ToString())
                            lname.Text = If(IsDBNull(reader("LastName")), "", reader("LastName").ToString())
                            txtAddress.Text = If(IsDBNull(reader("Address")), "", reader("Address").ToString())
                            cno.Text = If(IsDBNull(reader("ContactNo")), "", reader("ContactNo").ToString())
                            uname.Text = If(IsDBNull(reader("Username")), "", reader("Username").ToString())
                            pword.Text = If(IsDBNull(reader("Password")), "", reader("Password").ToString())
                            cpword.Text = If(IsDBNull(reader("Password")), "", reader("Password").ToString())
                        Else
                            MessageBox.Show("Superadmin not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Error loading superadmin: " & ex.Message)
            End Try
        End Using
    End Sub


    '=============================
    '       PASSWORD TOGGLE
    '=============================
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            pword.PasswordChar = ControlChars.NullChar    ' Show main password
            cpword.PasswordChar = ControlChars.NullChar   ' Show confirm password
            CheckBox1.Text = "Hide Passwords"
        Else
            pword.PasswordChar = "*"                       ' Hide main password
            cpword.PasswordChar = "*"                      ' Hide confirm password
            CheckBox1.Text = "Show Passwords"
        End If
    End Sub





    Private Sub updatebtn_Click(sender As Object, e As EventArgs) Handles updatebtn.Click
        ' ===== Validation =====
        If String.IsNullOrWhiteSpace(fname.Text) OrElse String.IsNullOrWhiteSpace(lname.Text) OrElse
       String.IsNullOrWhiteSpace(uname.Text) OrElse String.IsNullOrWhiteSpace(pword.Text) OrElse
       String.IsNullOrWhiteSpace(cpword.Text) Then
            MessageBox.Show("Please fill all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If pword.Text <> cpword.Text Then
            MessageBox.Show("Passwords do not match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ===== Update Database =====
        Using conn As New MySqlConnection(connectionstring)
            Try
                conn.Open()

                Dim newUsername As String = uname.Text.Trim()

                ' --- Get current Superadmin username ---
                Dim getCurrentUsernameCmd As New MySqlCommand("
                SELECT Username FROM users 
                WHERE UserType='Superadmin' LIMIT 1
            ", conn)

                Dim currentUsernameObj As Object = getCurrentUsernameCmd.ExecuteScalar()
                Dim currentUsername As String = If(currentUsernameObj IsNot Nothing, currentUsernameObj.ToString(), "")

                ' --- Prevent using reserved username "SuperAdmin" if it's not the current username ---
                If newUsername.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase) AndAlso Not newUsername.Equals(currentUsername, StringComparison.OrdinalIgnoreCase) Then
                    MessageBox.Show("The username 'SuperAdmin' is reserved and cannot be used.", "Restricted Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    uname.Focus()
                    Return
                End If

                ' ===== Perform Update =====
                Dim sql As String = "
                UPDATE users
                SET FirstName=@fname,
                    MI=@mi,
                    LastName=@lname,
                    Address=@address,
                    ContactNo=@cno,
                    Password=@pword,
                    Username=@uname
                WHERE UserType='Superadmin'
            "

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@fname", fname.Text.Trim())
                    cmd.Parameters.AddWithValue("@mi", If(String.IsNullOrWhiteSpace(minitial.Text), "", minitial.Text.Trim()))
                    cmd.Parameters.AddWithValue("@lname", lname.Text.Trim())
                    cmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(txtAddress.Text), "", txtAddress.Text.Trim()))
                    cmd.Parameters.AddWithValue("@cno", If(String.IsNullOrWhiteSpace(cno.Text), "", cno.Text.Trim()))
                    cmd.Parameters.AddWithValue("@pword", pword.Text)
                    cmd.Parameters.AddWithValue("@uname", newUsername)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Superadmin updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Update failed. No Superadmin record found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using

            Catch ex As MySqlException
                MessageBox.Show("Error updating superadmin: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Me.Close()
    End Sub






    ' Clear all input fields
    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        fname.Clear()
        minitial.Clear()
        lname.Clear()
        txtAddress.Clear()
        cno.Clear()
        uname.Clear()
        pword.Clear()
        cpword.Clear()
        ' Uncheck the checkbox
        CheckBox1.Checked = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub

    '=============================
    '  KEYPRESS
    '=============================
    Private Function IsValidPassword(password As String) As Boolean
        ' Adjust the password validation logic as needed
        Return password.Length >= 8
    End Function

    ' === PASSWORD HANDLING ===
    Private Sub pword_TextChanged(sender As Object, e As EventArgs) Handles pword.TextChanged
        cpword.Enabled = Not String.IsNullOrWhiteSpace(pword.Text)
    End Sub

    ' === KEYPRESS VALIDATIONS ===

    ' Contact Number
    Private Sub cno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cno.KeyPress
        ' Allow only digits and control keys
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Automatically insert "09" if empty
        If cno.Text.Length = 0 AndAlso e.KeyChar <> ControlChars.Back Then
            cno.Text = "09"
            cno.SelectionStart = cno.Text.Length
        End If

        ' Limit to 11 digits
        If cno.Text.Length >= 11 AndAlso Not Char.IsControl(e.KeyChar) Then
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

    Private Sub lname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lname.KeyPress
        ' Allow only letters, control keys (like Backspace), and space
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " "c Then
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

                ' Check if clipboard contains only letters, numbers, or spaces
                If clipboardText.All(Function(c) Char.IsLetterOrDigit(c) OrElse Char.IsWhiteSpace(c)) Then
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

        ' Normal typing: allow letters, numbers, spaces, and control keys only
        If Not Char.IsControl(e.KeyChar) AndAlso Not (Char.IsLetterOrDigit(e.KeyChar) OrElse Char.IsWhiteSpace(e.KeyChar)) Then
            e.Handled = True
            Return
        End If

        ' Limit typing to 200 characters
        If txt.TextLength >= 200 Then
            e.Handled = True
        End If
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

End Class
