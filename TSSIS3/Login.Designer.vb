<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.btnShow = New Guna.UI2.WinForms.Guna2Button()
        Me.btnHide = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.uname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.loginbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.pword = New Guna.UI2.WinForms.Guna2TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(181, 45)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(74, 34)
        Me.Guna2HtmlLabel1.TabIndex = 2
        Me.Guna2HtmlLabel1.Text = "Log in"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Outfit", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(33, 225)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(110, 19)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Show Password"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.btnShow)
        Me.Guna2ShadowPanel1.Controls.Add(Me.btnHide)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.uname)
        Me.Guna2ShadowPanel1.Controls.Add(Me.loginbtn)
        Me.Guna2ShadowPanel1.Controls.Add(Me.pword)
        Me.Guna2ShadowPanel1.Controls.Add(Me.CheckBox1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.PictureBox2)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(353, 12)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.Radius = 5
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(315, 377)
        Me.Guna2ShadowPanel1.TabIndex = 20
        '
        'btnShow
        '
        Me.btnShow.BorderRadius = 5
        Me.btnShow.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnShow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnShow.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnShow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnShow.FillColor = System.Drawing.Color.White
        Me.btnShow.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnShow.ForeColor = System.Drawing.Color.White
        Me.btnShow.Image = Global.TSSIS3.My.Resources.Resources.icons8_show_password_25__1_
        Me.btnShow.Location = New System.Drawing.Point(239, 212)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(42, 32)
        Me.btnShow.TabIndex = 16
        '
        'btnHide
        '
        Me.btnHide.BorderRadius = 5
        Me.btnHide.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnHide.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnHide.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnHide.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnHide.FillColor = System.Drawing.Color.White
        Me.btnHide.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnHide.ForeColor = System.Drawing.Color.White
        Me.btnHide.Image = Global.TSSIS3.My.Resources.Resources.icons8_hide_password_25
        Me.btnHide.Location = New System.Drawing.Point(239, 212)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(42, 32)
        Me.btnHide.TabIndex = 17
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.Image = Global.TSSIS3.My.Resources.Resources.icons8_user_56
        Me.Guna2CirclePictureBox1.ImageRotate = 0!
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(130, 29)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(56, 56)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Guna2CirclePictureBox1.TabIndex = 14
        Me.Guna2CirclePictureBox1.TabStop = False
        '
        'uname
        '
        Me.uname.BorderColor = System.Drawing.Color.Gray
        Me.uname.BorderRadius = 5
        Me.uname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.uname.DefaultText = ""
        Me.uname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.uname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.uname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.uname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.uname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.uname.Font = New System.Drawing.Font("Outfit", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uname.ForeColor = System.Drawing.Color.Black
        Me.uname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.uname.IconLeft = Global.TSSIS3.My.Resources.Resources.icons8_username_301
        Me.uname.Location = New System.Drawing.Point(33, 162)
        Me.uname.Margin = New System.Windows.Forms.Padding(2)
        Me.uname.Name = "uname"
        Me.uname.PlaceholderForeColor = System.Drawing.Color.Black
        Me.uname.PlaceholderText = "Enter Username"
        Me.uname.SelectedText = ""
        Me.uname.Size = New System.Drawing.Size(250, 36)
        Me.uname.TabIndex = 10
        '
        'loginbtn
        '
        Me.loginbtn.BackColor = System.Drawing.Color.Transparent
        Me.loginbtn.BorderRadius = 10
        Me.loginbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.loginbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.loginbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.loginbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.loginbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.loginbtn.FillColor = System.Drawing.Color.Transparent
        Me.loginbtn.Font = New System.Drawing.Font("Outfit", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loginbtn.ForeColor = System.Drawing.Color.White
        Me.loginbtn.Image = Global.TSSIS3.My.Resources.Resources.icons8_login_43
        Me.loginbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.loginbtn.Location = New System.Drawing.Point(33, 262)
        Me.loginbtn.Name = "loginbtn"
        Me.loginbtn.Size = New System.Drawing.Size(248, 37)
        Me.loginbtn.TabIndex = 13
        Me.loginbtn.Text = "LOG IN"
        '
        'pword
        '
        Me.pword.BorderColor = System.Drawing.Color.Gray
        Me.pword.BorderRadius = 5
        Me.pword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pword.DefaultText = ""
        Me.pword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.pword.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.pword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pword.Font = New System.Drawing.Font("Outfit", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pword.ForeColor = System.Drawing.Color.Black
        Me.pword.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pword.IconLeft = Global.TSSIS3.My.Resources.Resources.icons8_password_30
        Me.pword.Location = New System.Drawing.Point(33, 210)
        Me.pword.Margin = New System.Windows.Forms.Padding(2)
        Me.pword.Name = "pword"
        Me.pword.PlaceholderForeColor = System.Drawing.Color.Black
        Me.pword.PlaceholderText = "Enter Password"
        Me.pword.SelectedText = ""
        Me.pword.Size = New System.Drawing.Size(250, 36)
        Me.pword.TabIndex = 11
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.TSSIS3.My.Resources.Resources.ay__2_
        Me.PictureBox2.Location = New System.Drawing.Point(-24, 91)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(331, 268)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TSSIS3.My.Resources.Resources._4946674_2527710_removebg_preview
        Me.PictureBox1.Location = New System.Drawing.Point(-13, 74)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(348, 329)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Image = Global.TSSIS3.My.Resources.Resources.lologo
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(335, 315)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 0
        Me.Guna2PictureBox1.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(689, 401)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Guna2PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents pword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents loginbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents uname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents btnShow As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnHide As Guna.UI2.WinForms.Guna2Button
End Class
