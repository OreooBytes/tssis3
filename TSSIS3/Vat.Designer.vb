<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Vat
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.update = New Guna.UI2.WinForms.Guna2TextBox()
        Me.updatebtn = New Guna.UI2.WinForms.Guna2Button()
        Me.currvat = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.PictureBoxexit = New System.Windows.Forms.PictureBox()
        Me.Guna2ShadowPanel1.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.PictureBoxexit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(98, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Update Vat %"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(98, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Vat %"
        '
        'update
        '
        Me.update.BorderColor = System.Drawing.Color.LightGray
        Me.update.BorderRadius = 5
        Me.update.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.update.DefaultText = ""
        Me.update.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.update.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.update.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.update.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.update.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.update.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.update.ForeColor = System.Drawing.Color.Black
        Me.update.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.update.Location = New System.Drawing.Point(101, 123)
        Me.update.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.update.Name = "update"
        Me.update.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.update.PlaceholderText = "Enter New Vat Value"
        Me.update.SelectedText = ""
        Me.update.Size = New System.Drawing.Size(235, 36)
        Me.update.TabIndex = 2
        '
        'updatebtn
        '
        Me.updatebtn.BorderRadius = 5
        Me.updatebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.updatebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.updatebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.updatebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.updatebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.updatebtn.FillColor = System.Drawing.Color.Orange
        Me.updatebtn.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updatebtn.ForeColor = System.Drawing.Color.White
        Me.updatebtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.updatebtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.updatebtn.Location = New System.Drawing.Point(287, 182)
        Me.updatebtn.Name = "updatebtn"
        Me.updatebtn.Size = New System.Drawing.Size(115, 35)
        Me.updatebtn.TabIndex = 3
        Me.updatebtn.Text = "Update"
        '
        'currvat
        '
        Me.currvat.BorderColor = System.Drawing.Color.LightGray
        Me.currvat.BorderRadius = 5
        Me.currvat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.currvat.DefaultText = ""
        Me.currvat.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.currvat.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.currvat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.currvat.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.currvat.Enabled = False
        Me.currvat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.currvat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.currvat.ForeColor = System.Drawing.Color.Black
        Me.currvat.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.currvat.Location = New System.Drawing.Point(101, 61)
        Me.currvat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.currvat.Name = "currvat"
        Me.currvat.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.currvat.PlaceholderText = "Vat%"
        Me.currvat.SelectedText = ""
        Me.currvat.Size = New System.Drawing.Size(235, 36)
        Me.currvat.TabIndex = 1
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2Panel1)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(319, 160)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.Radius = 2
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(486, 318)
        Me.Guna2ShadowPanel1.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(17, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Update Vat"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.currvat)
        Me.Guna2Panel1.Controls.Add(Me.update)
        Me.Guna2Panel1.Controls.Add(Me.updatebtn)
        Me.Guna2Panel1.Controls.Add(Me.Label3)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Location = New System.Drawing.Point(22, 57)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(437, 238)
        Me.Guna2Panel1.TabIndex = 35
        '
        'PictureBoxexit
        '
        Me.PictureBoxexit.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxexit.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_window_50
        Me.PictureBoxexit.Location = New System.Drawing.Point(1056, 1)
        Me.PictureBoxexit.Name = "PictureBoxexit"
        Me.PictureBoxexit.Size = New System.Drawing.Size(47, 49)
        Me.PictureBoxexit.TabIndex = 52
        Me.PictureBoxexit.TabStop = False
        '
        'Vat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1108, 683)
        Me.Controls.Add(Me.PictureBoxexit)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Vat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vat"
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.PictureBoxexit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents update As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents updatebtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents currvat As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBoxexit As PictureBox
End Class
