Imports System.Drawing.Drawing2D
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class AccessPermission


    Private Const CornerRadius As Integer = 10 ' fixed radius

    Private Sub AccessPermission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackColor = ColorTranslator.FromHtml("#0B2447")

        ' Example font: Outfit, 10pt, Regular
        txtUsername.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtPassword.Font = New Font("Outfit", 9, FontStyle.Regular)
        loginbtn.Font = New Font("Outfit", 9, FontStyle.Bold)
        loginbtn.FillColor = ColorTranslator.FromHtml("#0B2447")

        ApplyRoundedCorners()

        txtPassword.UseSystemPasswordChar = True

        ' Center Guna2ShadowPanel1 inside the form
        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2

    End Sub

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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub

    Private Sub loginbtn_Click(sender As Object, e As EventArgs) Handles loginbtn.Click
        Dim uname As String = txtUsername.Text.Trim()
        Dim pword As String = txtPassword.Text.Trim()

        If uname = "" OrElse pword = "" Then
            MessageBox.Show("Please enter your username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Dim query As String = "SELECT * FROM users WHERE Username=@user AND Password=@pass AND UserType IN ('Admin', 'SuperAdmin') LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@user", uname)
                    cmd.Parameters.AddWithValue("@pass", pword)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()

                            ' Set session
                            SessionData.role = reader("UserType").ToString()
                            SessionData.fullName = reader("FirstName").ToString() & " " & reader("LastName").ToString()

                            ' ✅ Set DialogResult OK so parent knows login is successful
                            Me.DialogResult = DialogResult.OK
                            Me.Close()

                        Else
                            MessageBox.Show("Access denied! Only Admin or SuperAdmin accounts are allowed.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            loginbtn.PerformClick()  ' Trigger the login button click
        End If
    End Sub



End Class