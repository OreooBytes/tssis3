<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class User
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TimerSlide = New System.Windows.Forms.Timer(Me.components)
        Me.Guna2DataGridView1 = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Guna2ShadowPanel3 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.lblTotalSupperadmin = New System.Windows.Forms.Label()
        Me.lblSuperadmin = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.lblTotalAdmin = New System.Windows.Forms.Label()
        Me.lblAdmin = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Guna2ShadowPanel2 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.lblTotalCashier = New System.Windows.Forms.Label()
        Me.lblCashier = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lblCustom = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.fname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.minitial = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pword = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cno = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAddress = New Guna.UI2.WinForms.Guna2TextBox()
        Me.uname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cpword = New Guna.UI2.WinForms.Guna2TextBox()
        Me.addbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.utype = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.clearbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.updatebtn = New Guna.UI2.WinForms.Guna2Button()
        Me.Mainpanel = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnAddnewUser = New Guna.UI2.WinForms.Guna2Button()
        Me.txtsearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnSuperadmin = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.Guna2DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel3.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel2.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Mainpanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerSlide
        '
        Me.TimerSlide.Interval = 1
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
        Me.Guna2DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FirstName, Me.LastName, Me.MI, Me.Address, Me.ContactNo, Me.Username, Me.UserType, Me.Edit, Me.Delete})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Guna2DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Guna2DataGridView1.GridColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.Location = New System.Drawing.Point(4, 196)
        Me.Guna2DataGridView1.Name = "Guna2DataGridView1"
        Me.Guna2DataGridView1.ReadOnly = True
        Me.Guna2DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Guna2DataGridView1.RowHeadersVisible = False
        Me.Guna2DataGridView1.RowHeadersWidth = 51
        Me.Guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.RowTemplate.ReadOnly = True
        Me.Guna2DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Guna2DataGridView1.Size = New System.Drawing.Size(1099, 464)
        Me.Guna2DataGridView1.TabIndex = 16
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
        'FirstName
        '
        Me.FirstName.HeaderText = "FirstName"
        Me.FirstName.MinimumWidth = 6
        Me.FirstName.Name = "FirstName"
        Me.FirstName.ReadOnly = True
        '
        'LastName
        '
        Me.LastName.HeaderText = "LastName"
        Me.LastName.MinimumWidth = 6
        Me.LastName.Name = "LastName"
        Me.LastName.ReadOnly = True
        '
        'MI
        '
        Me.MI.HeaderText = "MI"
        Me.MI.MinimumWidth = 6
        Me.MI.Name = "MI"
        Me.MI.ReadOnly = True
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.MinimumWidth = 6
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        '
        'ContactNo
        '
        Me.ContactNo.HeaderText = "ContactNo"
        Me.ContactNo.MinimumWidth = 6
        Me.ContactNo.Name = "ContactNo"
        Me.ContactNo.ReadOnly = True
        '
        'Username
        '
        Me.Username.HeaderText = "Username"
        Me.Username.MinimumWidth = 6
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = True
        '
        'UserType
        '
        Me.UserType.HeaderText = "UserType"
        Me.UserType.MinimumWidth = 6
        Me.UserType.Name = "UserType"
        Me.UserType.ReadOnly = True
        '
        'Edit
        '
        Me.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Edit.HeaderText = ""
        Me.Edit.MinimumWidth = 6
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = True
        Me.Edit.Width = 6
        '
        'Delete
        '
        Me.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Delete.HeaderText = ""
        Me.Delete.MinimumWidth = 6
        Me.Delete.Name = "Delete"
        Me.Delete.ReadOnly = True
        Me.Delete.Width = 6
        '
        'Guna2ShadowPanel3
        '
        Me.Guna2ShadowPanel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel3.Controls.Add(Me.lblTotalSupperadmin)
        Me.Guna2ShadowPanel3.Controls.Add(Me.lblSuperadmin)
        Me.Guna2ShadowPanel3.Controls.Add(Me.PictureBox6)
        Me.Guna2ShadowPanel3.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel3.Location = New System.Drawing.Point(8, 12)
        Me.Guna2ShadowPanel3.Name = "Guna2ShadowPanel3"
        Me.Guna2ShadowPanel3.Radius = 5
        Me.Guna2ShadowPanel3.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel3.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel3.Size = New System.Drawing.Size(200, 100)
        Me.Guna2ShadowPanel3.TabIndex = 56
        '
        'lblTotalSupperadmin
        '
        Me.lblTotalSupperadmin.AutoSize = True
        Me.lblTotalSupperadmin.BackColor = System.Drawing.Color.White
        Me.lblTotalSupperadmin.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSupperadmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotalSupperadmin.Location = New System.Drawing.Point(98, 46)
        Me.lblTotalSupperadmin.Name = "lblTotalSupperadmin"
        Me.lblTotalSupperadmin.Size = New System.Drawing.Size(69, 17)
        Me.lblTotalSupperadmin.TabIndex = 31
        Me.lblTotalSupperadmin.Text = "Firstname"
        '
        'lblSuperadmin
        '
        Me.lblSuperadmin.AutoSize = True
        Me.lblSuperadmin.BackColor = System.Drawing.Color.White
        Me.lblSuperadmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblSuperadmin.Location = New System.Drawing.Point(98, 21)
        Me.lblSuperadmin.Name = "lblSuperadmin"
        Me.lblSuperadmin.Size = New System.Drawing.Size(67, 13)
        Me.lblSuperadmin.TabIndex = 32
        Me.lblSuperadmin.Text = "Super Admin"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.TSSIS3.My.Resources.Resources.icons8_user_groups_60
        Me.PictureBox6.Location = New System.Drawing.Point(19, 9)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(73, 54)
        Me.PictureBox6.TabIndex = 55
        Me.PictureBox6.TabStop = False
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.lblTotalAdmin)
        Me.Guna2ShadowPanel1.Controls.Add(Me.lblAdmin)
        Me.Guna2ShadowPanel1.Controls.Add(Me.PictureBox4)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(214, 12)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.Radius = 5
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(200, 100)
        Me.Guna2ShadowPanel1.TabIndex = 57
        '
        'lblTotalAdmin
        '
        Me.lblTotalAdmin.AutoSize = True
        Me.lblTotalAdmin.BackColor = System.Drawing.Color.White
        Me.lblTotalAdmin.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAdmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotalAdmin.Location = New System.Drawing.Point(98, 46)
        Me.lblTotalAdmin.Name = "lblTotalAdmin"
        Me.lblTotalAdmin.Size = New System.Drawing.Size(69, 17)
        Me.lblTotalAdmin.TabIndex = 31
        Me.lblTotalAdmin.Text = "Firstname"
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.BackColor = System.Drawing.Color.White
        Me.lblAdmin.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblAdmin.Location = New System.Drawing.Point(98, 21)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(84, 17)
        Me.lblAdmin.TabIndex = 32
        Me.lblAdmin.Text = "Total Admin"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.TSSIS3.My.Resources.Resources.icons8_user_groups_60
        Me.PictureBox4.Location = New System.Drawing.Point(19, 9)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(73, 54)
        Me.PictureBox4.TabIndex = 55
        Me.PictureBox4.TabStop = False
        '
        'Guna2ShadowPanel2
        '
        Me.Guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel2.Controls.Add(Me.lblTotalCashier)
        Me.Guna2ShadowPanel2.Controls.Add(Me.lblCashier)
        Me.Guna2ShadowPanel2.Controls.Add(Me.PictureBox5)
        Me.Guna2ShadowPanel2.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel2.Location = New System.Drawing.Point(420, 12)
        Me.Guna2ShadowPanel2.Name = "Guna2ShadowPanel2"
        Me.Guna2ShadowPanel2.Radius = 5
        Me.Guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel2.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel2.Size = New System.Drawing.Size(200, 100)
        Me.Guna2ShadowPanel2.TabIndex = 57
        '
        'lblTotalCashier
        '
        Me.lblTotalCashier.AutoSize = True
        Me.lblTotalCashier.BackColor = System.Drawing.Color.White
        Me.lblTotalCashier.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCashier.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotalCashier.Location = New System.Drawing.Point(98, 46)
        Me.lblTotalCashier.Name = "lblTotalCashier"
        Me.lblTotalCashier.Size = New System.Drawing.Size(69, 17)
        Me.lblTotalCashier.TabIndex = 31
        Me.lblTotalCashier.Text = "Firstname"
        '
        'lblCashier
        '
        Me.lblCashier.AutoSize = True
        Me.lblCashier.BackColor = System.Drawing.Color.White
        Me.lblCashier.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashier.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCashier.Location = New System.Drawing.Point(98, 21)
        Me.lblCashier.Name = "lblCashier"
        Me.lblCashier.Size = New System.Drawing.Size(88, 17)
        Me.lblCashier.TabIndex = 32
        Me.lblCashier.Text = "Total Cashier"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.TSSIS3.My.Resources.Resources.icons8_user_groups_60
        Me.PictureBox5.Location = New System.Drawing.Point(19, 9)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(73, 54)
        Me.PictureBox5.TabIndex = 55
        Me.PictureBox5.TabStop = False
        '
        'lblCustom
        '
        Me.lblCustom.AutoSize = True
        Me.lblCustom.BackColor = System.Drawing.Color.White
        Me.lblCustom.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCustom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCustom.Location = New System.Drawing.Point(15, 20)
        Me.lblCustom.Name = "lblCustom"
        Me.lblCustom.Size = New System.Drawing.Size(95, 17)
        Me.lblCustom.TabIndex = 31
        Me.lblCustom.Text = "Add New User"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.BorderColor = System.Drawing.Color.LightGray
        Me.Guna2Panel1.BorderRadius = 10
        Me.Guna2Panel1.Controls.Add(Me.PictureBox3)
        Me.Guna2Panel1.Controls.Add(Me.fname)
        Me.Guna2Panel1.Controls.Add(Me.minitial)
        Me.Guna2Panel1.Controls.Add(Me.pword)
        Me.Guna2Panel1.Controls.Add(Me.lname)
        Me.Guna2Panel1.Controls.Add(Me.cno)
        Me.Guna2Panel1.Controls.Add(Me.Label3)
        Me.Guna2Panel1.Controls.Add(Me.txtAddress)
        Me.Guna2Panel1.Controls.Add(Me.uname)
        Me.Guna2Panel1.Controls.Add(Me.Label4)
        Me.Guna2Panel1.Controls.Add(Me.cpword)
        Me.Guna2Panel1.Controls.Add(Me.addbtn)
        Me.Guna2Panel1.Controls.Add(Me.Label5)
        Me.Guna2Panel1.Controls.Add(Me.utype)
        Me.Guna2Panel1.Controls.Add(Me.Label6)
        Me.Guna2Panel1.Controls.Add(Me.Label7)
        Me.Guna2Panel1.Controls.Add(Me.clearbtn)
        Me.Guna2Panel1.Controls.Add(Me.Label10)
        Me.Guna2Panel1.Controls.Add(Me.Label9)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.Label8)
        Me.Guna2Panel1.Controls.Add(Me.updatebtn)
        Me.Guna2Panel1.FillColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.Location = New System.Drawing.Point(19, 52)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(588, 372)
        Me.Guna2Panel1.TabIndex = 31
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.TSSIS3.My.Resources.Resources.icons8_cancel_48
        Me.PictureBox3.Location = New System.Drawing.Point(278, -52)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(45, 45)
        Me.PictureBox3.TabIndex = 30
        Me.PictureBox3.TabStop = False
        '
        'fname
        '
        Me.fname.BorderColor = System.Drawing.Color.LightGray
        Me.fname.BorderRadius = 5
        Me.fname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.fname.DefaultText = ""
        Me.fname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.fname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.fname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.fname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.fname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fname.ForeColor = System.Drawing.Color.Black
        Me.fname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fname.Location = New System.Drawing.Point(22, 36)
        Me.fname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.fname.Name = "fname"
        Me.fname.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.fname.PlaceholderText = "Enter Firstname" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.fname.SelectedText = ""
        Me.fname.Size = New System.Drawing.Size(268, 36)
        Me.fname.TabIndex = 3
        '
        'minitial
        '
        Me.minitial.BorderColor = System.Drawing.Color.LightGray
        Me.minitial.BorderRadius = 5
        Me.minitial.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.minitial.DefaultText = ""
        Me.minitial.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.minitial.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.minitial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.minitial.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.minitial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.minitial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minitial.ForeColor = System.Drawing.Color.Black
        Me.minitial.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.minitial.Location = New System.Drawing.Point(22, 95)
        Me.minitial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.minitial.Name = "minitial"
        Me.minitial.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.minitial.PlaceholderText = "Enter M.I"
        Me.minitial.SelectedText = ""
        Me.minitial.Size = New System.Drawing.Size(268, 36)
        Me.minitial.TabIndex = 5
        '
        'pword
        '
        Me.pword.BorderColor = System.Drawing.Color.LightGray
        Me.pword.BorderRadius = 5
        Me.pword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pword.DefaultText = ""
        Me.pword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.pword.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.pword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pword.ForeColor = System.Drawing.Color.Black
        Me.pword.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pword.Location = New System.Drawing.Point(20, 272)
        Me.pword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pword.Name = "pword"
        Me.pword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pword.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.pword.PlaceholderText = "Enter Password"
        Me.pword.SelectedText = ""
        Me.pword.Size = New System.Drawing.Size(268, 36)
        Me.pword.TabIndex = 9
        '
        'lname
        '
        Me.lname.BorderColor = System.Drawing.Color.LightGray
        Me.lname.BorderRadius = 5
        Me.lname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lname.DefaultText = ""
        Me.lname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.lname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.lname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.lname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.lname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lname.ForeColor = System.Drawing.Color.Black
        Me.lname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lname.Location = New System.Drawing.Point(297, 35)
        Me.lname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lname.Name = "lname"
        Me.lname.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.lname.PlaceholderText = "Enter Lastname"
        Me.lname.SelectedText = ""
        Me.lname.Size = New System.Drawing.Size(268, 36)
        Me.lname.TabIndex = 4
        '
        'cno
        '
        Me.cno.BorderColor = System.Drawing.Color.LightGray
        Me.cno.BorderRadius = 5
        Me.cno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.cno.DefaultText = ""
        Me.cno.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.cno.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.cno.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cno.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cno.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cno.ForeColor = System.Drawing.Color.Black
        Me.cno.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cno.Location = New System.Drawing.Point(297, 94)
        Me.cno.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cno.Name = "cno"
        Me.cno.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.cno.PlaceholderText = "Enter Contact Number"
        Me.cno.SelectedText = ""
        Me.cno.Size = New System.Drawing.Size(268, 36)
        Me.cno.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(19, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Firstname"
        '
        'txtAddress
        '
        Me.txtAddress.BorderColor = System.Drawing.Color.LightGray
        Me.txtAddress.BorderRadius = 5
        Me.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAddress.DefaultText = ""
        Me.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAddress.Location = New System.Drawing.Point(22, 154)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.txtAddress.PlaceholderText = "Enter Address"
        Me.txtAddress.SelectedText = ""
        Me.txtAddress.Size = New System.Drawing.Size(544, 36)
        Me.txtAddress.TabIndex = 7
        '
        'uname
        '
        Me.uname.BorderColor = System.Drawing.Color.LightGray
        Me.uname.BorderRadius = 5
        Me.uname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.uname.DefaultText = ""
        Me.uname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.uname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.uname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.uname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.uname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.uname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uname.ForeColor = System.Drawing.Color.Black
        Me.uname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.uname.Location = New System.Drawing.Point(294, 214)
        Me.uname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.uname.Name = "uname"
        Me.uname.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.uname.PlaceholderText = "Enter Username"
        Me.uname.SelectedText = ""
        Me.uname.Size = New System.Drawing.Size(268, 36)
        Me.uname.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(294, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Lastname"
        '
        'cpword
        '
        Me.cpword.BorderColor = System.Drawing.Color.LightGray
        Me.cpword.BorderRadius = 5
        Me.cpword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.cpword.DefaultText = ""
        Me.cpword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.cpword.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.cpword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cpword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cpword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cpword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpword.ForeColor = System.Drawing.Color.Black
        Me.cpword.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cpword.Location = New System.Drawing.Point(294, 272)
        Me.cpword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cpword.Name = "cpword"
        Me.cpword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.cpword.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.cpword.PlaceholderText = "Enter Confirm Password"
        Me.cpword.SelectedText = ""
        Me.cpword.Size = New System.Drawing.Size(268, 36)
        Me.cpword.TabIndex = 10
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
        Me.addbtn.Location = New System.Drawing.Point(329, 324)
        Me.addbtn.Name = "addbtn"
        Me.addbtn.Size = New System.Drawing.Size(115, 35)
        Me.addbtn.TabIndex = 12
        Me.addbtn.Text = "Save"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(19, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "M.I"
        '
        'utype
        '
        Me.utype.BackColor = System.Drawing.Color.Transparent
        Me.utype.BorderColor = System.Drawing.Color.LightGray
        Me.utype.BorderRadius = 5
        Me.utype.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.utype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.utype.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.utype.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.utype.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.utype.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.utype.ItemHeight = 30
        Me.utype.Location = New System.Drawing.Point(22, 214)
        Me.utype.Name = "utype"
        Me.utype.Size = New System.Drawing.Size(268, 36)
        Me.utype.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(294, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 15)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Contact Number"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(19, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 15)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Address"
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
        Me.clearbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.clearbtn.ForeColor = System.Drawing.Color.White
        Me.clearbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.clearbtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.clearbtn.Location = New System.Drawing.Point(450, 324)
        Me.clearbtn.Name = "clearbtn"
        Me.clearbtn.Size = New System.Drawing.Size(115, 35)
        Me.clearbtn.TabIndex = 13
        Me.clearbtn.Text = "Clear"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(291, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 15)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Username"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(17, 252)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 15)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(291, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 15)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Confirm Password"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(19, 194)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "User Type"
        '
        'updatebtn
        '
        Me.updatebtn.AccessibleName = ""
        Me.updatebtn.BackColor = System.Drawing.Color.Transparent
        Me.updatebtn.BorderRadius = 5
        Me.updatebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.updatebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.updatebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.updatebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.updatebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.updatebtn.FillColor = System.Drawing.Color.Orange
        Me.updatebtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.updatebtn.ForeColor = System.Drawing.Color.White
        Me.updatebtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.updatebtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.updatebtn.Location = New System.Drawing.Point(329, 324)
        Me.updatebtn.Name = "updatebtn"
        Me.updatebtn.Size = New System.Drawing.Size(115, 35)
        Me.updatebtn.TabIndex = 14
        Me.updatebtn.Text = "Update"
        Me.updatebtn.Visible = False
        '
        'Mainpanel
        '
        Me.Mainpanel.BackColor = System.Drawing.Color.Transparent
        Me.Mainpanel.Controls.Add(Me.Guna2Panel1)
        Me.Mainpanel.Controls.Add(Me.lblCustom)
        Me.Mainpanel.Controls.Add(Me.PictureBox1)
        Me.Mainpanel.FillColor = System.Drawing.Color.White
        Me.Mainpanel.Location = New System.Drawing.Point(268, 176)
        Me.Mainpanel.Name = "Mainpanel"
        Me.Mainpanel.Radius = 2
        Me.Mainpanel.ShadowColor = System.Drawing.Color.Black
        Me.Mainpanel.Size = New System.Drawing.Size(625, 440)
        Me.Mainpanel.TabIndex = 51
        Me.Mainpanel.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_39
        Me.PictureBox1.Location = New System.Drawing.Point(579, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(39, 39)
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_window_50
        Me.PictureBox2.Location = New System.Drawing.Point(1056, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(47, 49)
        Me.PictureBox2.TabIndex = 50
        Me.PictureBox2.TabStop = False
        '
        'btnAddnewUser
        '
        Me.btnAddnewUser.BorderRadius = 5
        Me.btnAddnewUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddnewUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddnewUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddnewUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddnewUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddnewUser.ForeColor = System.Drawing.Color.White
        Me.btnAddnewUser.Image = Global.TSSIS3.My.Resources.Resources.icons8_add_30__1_
        Me.btnAddnewUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnAddnewUser.Location = New System.Drawing.Point(942, 154)
        Me.btnAddnewUser.Name = "btnAddnewUser"
        Me.btnAddnewUser.Size = New System.Drawing.Size(161, 36)
        Me.btnAddnewUser.TabIndex = 2
        Me.btnAddnewUser.Text = "     Add New User"
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
        Me.txtsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.ForeColor = System.Drawing.Color.Black
        Me.txtsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtsearch.IconLeft = Global.TSSIS3.My.Resources.Resources.icons8_search_35
        Me.txtsearch.Location = New System.Drawing.Point(4, 154)
        Me.txtsearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtsearch.PlaceholderText = "Search Users"
        Me.txtsearch.SelectedText = ""
        Me.txtsearch.Size = New System.Drawing.Size(228, 36)
        Me.txtsearch.TabIndex = 1
        '
        'btnSuperadmin
        '
        Me.btnSuperadmin.BorderRadius = 5
        Me.btnSuperadmin.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSuperadmin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSuperadmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSuperadmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSuperadmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSuperadmin.ForeColor = System.Drawing.Color.White
        Me.btnSuperadmin.Image = Global.TSSIS3.My.Resources.Resources.icons8_admin_normal
        Me.btnSuperadmin.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnSuperadmin.Location = New System.Drawing.Point(235, 154)
        Me.btnSuperadmin.Name = "btnSuperadmin"
        Me.btnSuperadmin.Size = New System.Drawing.Size(214, 36)
        Me.btnSuperadmin.TabIndex = 58
        Me.btnSuperadmin.Text = "     Super Admin Account"
        Me.btnSuperadmin.Visible = False
        '
        'User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1108, 683)
        Me.Controls.Add(Me.Mainpanel)
        Me.Controls.Add(Me.Guna2ShadowPanel2)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.Guna2DataGridView1)
        Me.Controls.Add(Me.Guna2ShadowPanel3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnAddnewUser)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.btnSuperadmin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "User"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User"
        CType(Me.Guna2DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel3.ResumeLayout(False)
        Me.Guna2ShadowPanel3.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel2.ResumeLayout(False)
        Me.Guna2ShadowPanel2.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Mainpanel.ResumeLayout(False)
        Me.Mainpanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimerSlide As Timer
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Guna2DataGridView1 As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents FirstName As DataGridViewTextBoxColumn
    Friend WithEvents LastName As DataGridViewTextBoxColumn
    Friend WithEvents MI As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents ContactNo As DataGridViewTextBoxColumn
    Friend WithEvents Username As DataGridViewTextBoxColumn
    Friend WithEvents UserType As DataGridViewTextBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
    Friend WithEvents txtsearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnAddnewUser As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2ShadowPanel3 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblTotalSupperadmin As Label
    Friend WithEvents lblSuperadmin As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblTotalAdmin As Label
    Friend WithEvents lblAdmin As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Guna2ShadowPanel2 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblTotalCashier As Label
    Friend WithEvents lblCashier As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents btnSuperadmin As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblCustom As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents fname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents minitial As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cno As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAddress As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents uname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cpword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents addbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label5 As Label
    Friend WithEvents utype As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents clearbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents updatebtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Mainpanel As Guna.UI2.WinForms.Guna2ShadowPanel
End Class
