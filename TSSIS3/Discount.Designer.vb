<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Discount
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.addbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.updatebtn = New Guna.UI2.WinForms.Guna2Button()
        Me.clearbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.dscnt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dscnttype = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2DataGridView1 = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.labelforbutton = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnupdateloyalty = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddnewDiscount = New Guna.UI2.WinForms.Guna2Button()
        Me.PictureBoxexit = New System.Windows.Forms.PictureBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        CType(Me.Guna2DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.PictureBoxexit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'addbtn
        '
        Me.addbtn.BackColor = System.Drawing.Color.Transparent
        Me.addbtn.BorderRadius = 5
        Me.addbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.addbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.addbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.addbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.addbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.addbtn.FillColor = System.Drawing.Color.LimeGreen
        Me.addbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.addbtn.ForeColor = System.Drawing.Color.White
        Me.addbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.addbtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.addbtn.Location = New System.Drawing.Point(103, 168)
        Me.addbtn.Name = "addbtn"
        Me.addbtn.Size = New System.Drawing.Size(115, 35)
        Me.addbtn.TabIndex = 5
        Me.addbtn.Text = "Save"
        '
        'updatebtn
        '
        Me.updatebtn.BackColor = System.Drawing.Color.Transparent
        Me.updatebtn.BorderRadius = 5
        Me.updatebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.updatebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.updatebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.updatebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.updatebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.updatebtn.FillColor = System.Drawing.Color.Orange
        Me.updatebtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updatebtn.ForeColor = System.Drawing.Color.White
        Me.updatebtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.updatebtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.updatebtn.Location = New System.Drawing.Point(103, 168)
        Me.updatebtn.Name = "updatebtn"
        Me.updatebtn.Size = New System.Drawing.Size(115, 35)
        Me.updatebtn.TabIndex = 11
        Me.updatebtn.Text = "Update"
        '
        'clearbtn
        '
        Me.clearbtn.BackColor = System.Drawing.Color.Transparent
        Me.clearbtn.BorderRadius = 5
        Me.clearbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.clearbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.clearbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.clearbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.clearbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.clearbtn.FillColor = System.Drawing.Color.Red
        Me.clearbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clearbtn.ForeColor = System.Drawing.Color.White
        Me.clearbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.clearbtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.clearbtn.Location = New System.Drawing.Point(224, 168)
        Me.clearbtn.Name = "clearbtn"
        Me.clearbtn.Size = New System.Drawing.Size(115, 35)
        Me.clearbtn.TabIndex = 6
        Me.clearbtn.Text = "Clear"
        '
        'dscnt
        '
        Me.dscnt.BorderColor = System.Drawing.Color.LightGray
        Me.dscnt.BorderRadius = 5
        Me.dscnt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dscnt.DefaultText = ""
        Me.dscnt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.dscnt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.dscnt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dscnt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dscnt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dscnt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dscnt.ForeColor = System.Drawing.Color.Black
        Me.dscnt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dscnt.Location = New System.Drawing.Point(104, 116)
        Me.dscnt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dscnt.Name = "dscnt"
        Me.dscnt.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.dscnt.PlaceholderText = "Enter Discount Percent"
        Me.dscnt.SelectedText = ""
        Me.dscnt.Size = New System.Drawing.Size(235, 36)
        Me.dscnt.TabIndex = 4
        '
        'dscnttype
        '
        Me.dscnttype.BorderColor = System.Drawing.Color.LightGray
        Me.dscnttype.BorderRadius = 5
        Me.dscnttype.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dscnttype.DefaultText = ""
        Me.dscnttype.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.dscnttype.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.dscnttype.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dscnttype.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dscnttype.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dscnttype.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dscnttype.ForeColor = System.Drawing.Color.Black
        Me.dscnttype.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dscnttype.Location = New System.Drawing.Point(104, 57)
        Me.dscnttype.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dscnttype.Name = "dscnttype"
        Me.dscnttype.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.dscnttype.PlaceholderText = "Enter Discount Type"
        Me.dscnttype.SelectedText = ""
        Me.dscnttype.Size = New System.Drawing.Size(235, 36)
        Me.dscnttype.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(102, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 15)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Discount Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(102, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 15)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Discount Percent"
        '
        'Guna2DataGridView1
        '
        Me.Guna2DataGridView1.AllowUserToAddRows = False
        Me.Guna2DataGridView1.AllowUserToDeleteRows = False
        Me.Guna2DataGridView1.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Guna2DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Guna2DataGridView1.ColumnHeadersHeight = 24
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Guna2DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Guna2DataGridView1.GridColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.Location = New System.Drawing.Point(6, 136)
        Me.Guna2DataGridView1.Name = "Guna2DataGridView1"
        Me.Guna2DataGridView1.ReadOnly = True
        Me.Guna2DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Guna2DataGridView1.RowHeadersVisible = False
        Me.Guna2DataGridView1.RowHeadersWidth = 51
        Me.Guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.RowTemplate.ReadOnly = True
        Me.Guna2DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Guna2DataGridView1.Size = New System.Drawing.Size(1099, 523)
        Me.Guna2DataGridView1.TabIndex = 62
        Me.Guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.Guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.Guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.Guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.Guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Guna2DataGridView1.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 24
        Me.Guna2DataGridView1.ThemeStyle.ReadOnly = True
        Me.Guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.Guna2DataGridView1.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22
        Me.Guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.PictureBox4)
        Me.Guna2ShadowPanel1.Controls.Add(Me.labelforbutton)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2Panel1)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(313, 183)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.Radius = 2
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(486, 318)
        Me.Guna2ShadowPanel1.TabIndex = 64
        Me.Guna2ShadowPanel1.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_39
        Me.PictureBox4.Location = New System.Drawing.Point(435, 12)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(39, 39)
        Me.PictureBox4.TabIndex = 50
        Me.PictureBox4.TabStop = False
        '
        'labelforbutton
        '
        Me.labelforbutton.AutoSize = True
        Me.labelforbutton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.labelforbutton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.labelforbutton.Location = New System.Drawing.Point(17, 24)
        Me.labelforbutton.Name = "labelforbutton"
        Me.labelforbutton.Size = New System.Drawing.Size(92, 17)
        Me.labelforbutton.TabIndex = 33
        Me.labelforbutton.Text = "Add Discount"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.dscnttype)
        Me.Guna2Panel1.Controls.Add(Me.addbtn)
        Me.Guna2Panel1.Controls.Add(Me.dscnt)
        Me.Guna2Panel1.Controls.Add(Me.updatebtn)
        Me.Guna2Panel1.Controls.Add(Me.clearbtn)
        Me.Guna2Panel1.Controls.Add(Me.Label11)
        Me.Guna2Panel1.Controls.Add(Me.Label3)
        Me.Guna2Panel1.Location = New System.Drawing.Point(22, 57)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(437, 238)
        Me.Guna2Panel1.TabIndex = 35
        '
        'btnupdateloyalty
        '
        Me.btnupdateloyalty.BorderRadius = 5
        Me.btnupdateloyalty.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnupdateloyalty.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnupdateloyalty.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnupdateloyalty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnupdateloyalty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdateloyalty.ForeColor = System.Drawing.Color.White
        Me.btnupdateloyalty.Image = Global.TSSIS3.My.Resources.Resources.icons8_update_normal
        Me.btnupdateloyalty.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnupdateloyalty.Location = New System.Drawing.Point(402, 94)
        Me.btnupdateloyalty.Name = "btnupdateloyalty"
        Me.btnupdateloyalty.Size = New System.Drawing.Size(217, 36)
        Me.btnupdateloyalty.TabIndex = 65
        Me.btnupdateloyalty.Text = "         Update Loyalty Discount"
        Me.btnupdateloyalty.Visible = False
        '
        'btnAddnewDiscount
        '
        Me.btnAddnewDiscount.BorderRadius = 5
        Me.btnAddnewDiscount.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddnewDiscount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddnewDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddnewDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddnewDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddnewDiscount.ForeColor = System.Drawing.Color.White
        Me.btnAddnewDiscount.Image = Global.TSSIS3.My.Resources.Resources.icons8_add_30__1_
        Me.btnAddnewDiscount.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnAddnewDiscount.Location = New System.Drawing.Point(212, 94)
        Me.btnAddnewDiscount.Name = "btnAddnewDiscount"
        Me.btnAddnewDiscount.Size = New System.Drawing.Size(184, 36)
        Me.btnAddnewDiscount.TabIndex = 2
        Me.btnAddnewDiscount.Text = "     Add New Discount"
        '
        'PictureBoxexit
        '
        Me.PictureBoxexit.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxexit.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_window_50
        Me.PictureBoxexit.Location = New System.Drawing.Point(1057, 1)
        Me.PictureBoxexit.Name = "PictureBoxexit"
        Me.PictureBoxexit.Size = New System.Drawing.Size(47, 49)
        Me.PictureBoxexit.TabIndex = 51
        Me.PictureBoxexit.TabStop = False
        '
        'txtSearch
        '
        Me.txtSearch.BorderColor = System.Drawing.Color.LightGray
        Me.txtSearch.BorderRadius = 5
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.IconLeft = Global.TSSIS3.My.Resources.Resources.icons8_search_35
        Me.txtSearch.Location = New System.Drawing.Point(6, 94)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtSearch.PlaceholderText = "Search Discount"
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(200, 36)
        Me.txtSearch.TabIndex = 1
        '
        'Discount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1108, 683)
        Me.Controls.Add(Me.btnupdateloyalty)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.btnAddnewDiscount)
        Me.Controls.Add(Me.PictureBoxexit)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Guna2DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Discount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Discount"
        CType(Me.Guna2DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.PictureBoxexit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents updatebtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents clearbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dscnt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dscnttype As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents addbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2DataGridView1 As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents labelforbutton As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBoxexit As PictureBox
    Friend WithEvents btnAddnewDiscount As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnupdateloyalty As Guna.UI2.WinForms.Guna2Button
End Class
