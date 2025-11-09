Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Public Class ChangePassword

    Private Const CornerRadius As Integer = 10


    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Default text ng checkbox
        chkShowPassword.Text = "Show Password"

        ' Ensure all password textboxes are masked at start
        txtCurrentPassword.UseSystemPasswordChar = True
        txtNewPassword.UseSystemPasswordChar = True
        txtConfirmPassword.UseSystemPasswordChar = True


        ' I-center ang MainPanel sa form
        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2

        Guna2Panel1.BackColor = Color.Gainsboro

        ' === Light Gray Rounded Border ===
        With Guna2Panel2
            .FillColor = Color.White
            .BorderColor = ColorTranslator.FromHtml("#D3D3D3")
            .BorderThickness = 2
            .BorderRadius = 10
            .BringToFront()
        End With

        BackColor = ColorTranslator.FromHtml("#0B2447")

        ApplyRoundedCorners()

        btnChangePassword.ForeColor = ColorTranslator.FromHtml("#0B2447")
        btnChangePassword.FillColor = ColorTranslator.FromHtml("#FFD93D")

        ' ===== Labels =====
        Label1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label2.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label3.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label4.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== TextBoxes =====
        txtUsername.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtCurrentPassword.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtNewPassword.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtConfirmPassword.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== Button =====
        btnChangePassword.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== CheckBox =====
        chkShowPassword.Font = New Font("Outfit", 9, FontStyle.Regular)

    End Sub

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
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim currentPass As String = txtCurrentPassword.Text.Trim()
        Dim newPass As String = txtNewPassword.Text.Trim()
        Dim confirmPass As String = txtConfirmPassword.Text.Trim()

        ' Basic validation
        If username = "" Or currentPass = "" Or newPass = "" Or confirmPass = "" Then
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If newPass <> confirmPass Then
            MessageBox.Show("New Password and Confirm Password do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' Check kung tama ang current password ng username
                Dim checkQuery As String = "SELECT Password FROM users WHERE Username=@username LIMIT 1"
                Using cmd As New MySqlCommand(checkQuery, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    Dim dbPass As Object = cmd.ExecuteScalar()

                    If dbPass Is Nothing Then
                        MessageBox.Show("Username not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If dbPass.ToString() <> currentPass Then
                        MessageBox.Show("Current password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using

                ' Update new password
                Dim updateQuery As String = "UPDATE users SET Password=@newPass WHERE Username=@username"
                Using cmdUpdate As New MySqlCommand(updateQuery, conn)
                    cmdUpdate.Parameters.AddWithValue("@newPass", newPass)
                    cmdUpdate.Parameters.AddWithValue("@username", username)
                    cmdUpdate.ExecuteNonQuery()
                End Using

                ' ✅ Log audit trail using session data
                Dim actionDescription As String =
                $"Password changed for user: {username}" & vbCrLf &
                $"Changed by: {SessionData.fullName} ({SessionData.role})"

                LogAuditTrail(SessionData.role, SessionData.fullName, actionDescription)

                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                txtUsername.Clear()
                txtCurrentPassword.Clear()
                txtNewPassword.Clear()
                txtConfirmPassword.Clear()


            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Show/Hide Passwords + palitan text ng checkbox
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            ' Ipakita ang password
            txtCurrentPassword.UseSystemPasswordChar = False
            txtNewPassword.UseSystemPasswordChar = False
            txtConfirmPassword.UseSystemPasswordChar = False
            chkShowPassword.Text = "Hide Password"
        Else
            ' Itago ulit
            txtCurrentPassword.UseSystemPasswordChar = True
            txtNewPassword.UseSystemPasswordChar = True
            txtConfirmPassword.UseSystemPasswordChar = True
            chkShowPassword.Text = "Show Password"
        End If
    End Sub


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
                    cmd.Parameters.AddWithValue("@Form", "Change Password")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub clear()
        txtUsername.Clear()
        txtCurrentPassword.Clear()
        txtNewPassword.Clear()
        txtConfirmPassword.Clear()

        ' Add pa kung may iba ka pang textboxes
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub






    'Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
    '    If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
    '    Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '    If result = DialogResult.Yes Then
    '        Me.Close()
    '    End If
    'End Sub

    Private Sub Changepassword_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
