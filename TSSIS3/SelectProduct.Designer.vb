<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SelectProduct
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
    Friend WithEvents cmbCategory As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnExit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlContainer As Panel

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmbCategory = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnExit = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.pnlProductTemplate = New System.Windows.Forms.Panel()
        Me.numQuantity = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.lblBarcode = New System.Windows.Forms.Label()
        Me.btnselect = New Guna.UI2.WinForms.Guna2Button()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.pbProductImage = New System.Windows.Forms.PictureBox()
        Me.txtsearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContainer.SuspendLayout()
        Me.pnlProductTemplate.SuspendLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbProductImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbCategory
        '
        Me.cmbCategory.BackColor = System.Drawing.Color.Transparent
        Me.cmbCategory.BorderRadius = 5
        Me.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FocusedColor = System.Drawing.Color.Empty
        Me.cmbCategory.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbCategory.ItemHeight = 30
        Me.cmbCategory.Location = New System.Drawing.Point(9, 51)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(239, 36)
        Me.cmbCategory.TabIndex = 2
        '
        'btnExit
        '
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnExit.FillColor = System.Drawing.Color.Transparent
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExit.ForeColor = System.Drawing.Color.Transparent
        Me.btnExit.Location = New System.Drawing.Point(195, 10)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(40, 35)
        Me.btnExit.TabIndex = 1
        '
        'pnlContainer
        '
        Me.pnlContainer.BackColor = System.Drawing.Color.White
        Me.pnlContainer.Controls.Add(Me.pnlProductTemplate)
        Me.pnlContainer.Location = New System.Drawing.Point(9, 91)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(239, 685)
        Me.pnlContainer.TabIndex = 3
        '
        'pnlProductTemplate
        '
        Me.pnlProductTemplate.Controls.Add(Me.numQuantity)
        Me.pnlProductTemplate.Controls.Add(Me.lblBarcode)
        Me.pnlProductTemplate.Controls.Add(Me.btnselect)
        Me.pnlProductTemplate.Controls.Add(Me.lblPrice)
        Me.pnlProductTemplate.Controls.Add(Me.lblQty)
        Me.pnlProductTemplate.Controls.Add(Me.lblProductName)
        Me.pnlProductTemplate.Controls.Add(Me.pbProductImage)
        Me.pnlProductTemplate.Location = New System.Drawing.Point(12, 13)
        Me.pnlProductTemplate.Name = "pnlProductTemplate"
        Me.pnlProductTemplate.Size = New System.Drawing.Size(214, 115)
        Me.pnlProductTemplate.TabIndex = 0
        '
        'numQuantity
        '
        Me.numQuantity.BackColor = System.Drawing.Color.Transparent
        Me.numQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.numQuantity.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numQuantity.Location = New System.Drawing.Point(9, 81)
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(64, 23)
        Me.numQuantity.TabIndex = 25
        Me.numQuantity.UpDownButtonFillColor = System.Drawing.Color.DarkBlue
        Me.numQuantity.UpDownButtonForeColor = System.Drawing.Color.White
        '
        'lblBarcode
        '
        Me.lblBarcode.AutoSize = True
        Me.lblBarcode.Location = New System.Drawing.Point(79, 11)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(39, 13)
        Me.lblBarcode.TabIndex = 7
        Me.lblBarcode.Text = "Label1"
        '
        'btnselect
        '
        Me.btnselect.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnselect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnselect.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnselect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnselect.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnselect.ForeColor = System.Drawing.Color.White
        Me.btnselect.Location = New System.Drawing.Point(94, 81)
        Me.btnselect.Name = "btnselect"
        Me.btnselect.Size = New System.Drawing.Size(105, 24)
        Me.btnselect.TabIndex = 6
        Me.btnselect.Text = "Guna2Button1"
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(79, 57)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(39, 13)
        Me.lblPrice.TabIndex = 3
        Me.lblPrice.Text = "Label3"
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Location = New System.Drawing.Point(79, 42)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(39, 13)
        Me.lblQty.TabIndex = 2
        Me.lblQty.Text = "Label2"
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(79, 27)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(39, 13)
        Me.lblProductName.TabIndex = 1
        Me.lblProductName.Text = "Label1"
        '
        'pbProductImage
        '
        Me.pbProductImage.Location = New System.Drawing.Point(9, 11)
        Me.pbProductImage.Name = "pbProductImage"
        Me.pbProductImage.Size = New System.Drawing.Size(64, 65)
        Me.pbProductImage.TabIndex = 0
        Me.pbProductImage.TabStop = False
        '
        'txtsearch
        '
        Me.txtsearch.BorderColor = System.Drawing.Color.LightGray
        Me.txtsearch.BorderRadius = 5
        Me.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtsearch.DefaultText = ""
        Me.txtsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtsearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtsearch.IconLeft = Global.TSSIS3.My.Resources.Resources.icons8_search_35
        Me.txtsearch.Location = New System.Drawing.Point(9, 9)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtsearch.PlaceholderText = "Search Product"
        Me.txtsearch.SelectedText = ""
        Me.txtsearch.Size = New System.Drawing.Size(239, 36)
        Me.txtsearch.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_39
        Me.PictureBox1.Location = New System.Drawing.Point(252, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 42)
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'SelectProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(295, 788)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SelectProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ㅤ"
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlProductTemplate.ResumeLayout(False)
        Me.pnlProductTemplate.PerformLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbProductImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlProductTemplate As Panel
    Friend WithEvents lblPrice As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents lblProductName As Label
    Friend WithEvents pbProductImage As PictureBox
    Friend WithEvents btnselect As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblBarcode As Label
    Friend WithEvents numQuantity As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents txtsearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
