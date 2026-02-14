<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Supplier
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
        Me.Guna2DataGridView1 = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.CompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adrss = New Guna.UI2.WinForms.Guna2TextBox()
        Me.eml = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cno = New Guna.UI2.WinForms.Guna2TextBox()
        Me.sname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtSearchSupplier = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnupdate = New Guna.UI2.WinForms.Guna2Button()
        Me.addbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.clearbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnAddnew = New Guna.UI2.WinForms.Guna2Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.Guna2DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Guna2DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompanyName, Me.SupplierName, Me.ContactNo, Me.Email, Me.Address})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Guna2DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Guna2DataGridView1.GridColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.Location = New System.Drawing.Point(5, 167)
        Me.Guna2DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2DataGridView1.Name = "Guna2DataGridView1"
        Me.Guna2DataGridView1.ReadOnly = True
        Me.Guna2DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Guna2DataGridView1.RowHeadersVisible = False
        Me.Guna2DataGridView1.RowHeadersWidth = 51
        Me.Guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Guna2DataGridView1.RowTemplate.ReadOnly = True
        Me.Guna2DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Guna2DataGridView1.Size = New System.Drawing.Size(1464, 644)
        Me.Guna2DataGridView1.TabIndex = 11
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
        'CompanyName
        '
        Me.CompanyName.HeaderText = "CompanyName"
        Me.CompanyName.MinimumWidth = 6
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.ReadOnly = True
        '
        'SupplierName
        '
        Me.SupplierName.HeaderText = "SupplierName"
        Me.SupplierName.MinimumWidth = 6
        Me.SupplierName.Name = "SupplierName"
        Me.SupplierName.ReadOnly = True
        '
        'ContactNo
        '
        Me.ContactNo.HeaderText = "ContactNo"
        Me.ContactNo.MinimumWidth = 6
        Me.ContactNo.Name = "ContactNo"
        Me.ContactNo.ReadOnly = True
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.MinimumWidth = 6
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.MinimumWidth = 6
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        '
        'adrss
        '
        Me.adrss.BorderColor = System.Drawing.Color.LightGray
        Me.adrss.BorderRadius = 5
        Me.adrss.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.adrss.DefaultText = ""
        Me.adrss.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.adrss.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.adrss.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.adrss.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.adrss.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.adrss.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adrss.ForeColor = System.Drawing.Color.Black
        Me.adrss.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.adrss.Location = New System.Drawing.Point(39, 124)
        Me.adrss.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.adrss.Name = "adrss"
        Me.adrss.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.adrss.PlaceholderText = "Enter Address"
        Me.adrss.SelectedText = ""
        Me.adrss.Size = New System.Drawing.Size(655, 44)
        Me.adrss.TabIndex = 5
        '
        'eml
        '
        Me.eml.BorderColor = System.Drawing.Color.LightGray
        Me.eml.BorderRadius = 5
        Me.eml.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.eml.DefaultText = ""
        Me.eml.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.eml.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.eml.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.eml.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.eml.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.eml.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eml.ForeColor = System.Drawing.Color.Black
        Me.eml.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.eml.Location = New System.Drawing.Point(380, 202)
        Me.eml.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.eml.Name = "eml"
        Me.eml.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.eml.PlaceholderText = "Enter Email Address"
        Me.eml.SelectedText = ""
        Me.eml.Size = New System.Drawing.Size(313, 44)
        Me.eml.TabIndex = 7
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
        Me.cno.Location = New System.Drawing.Point(39, 203)
        Me.cno.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cno.Name = "cno"
        Me.cno.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.cno.PlaceholderText = "Enter Contact Number"
        Me.cno.SelectedText = ""
        Me.cno.Size = New System.Drawing.Size(313, 44)
        Me.cno.TabIndex = 6
        '
        'sname
        '
        Me.sname.BorderColor = System.Drawing.Color.LightGray
        Me.sname.BorderRadius = 5
        Me.sname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sname.DefaultText = ""
        Me.sname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.sname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.sname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.sname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.sname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.sname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sname.ForeColor = System.Drawing.Color.Black
        Me.sname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.sname.Location = New System.Drawing.Point(380, 52)
        Me.sname.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sname.Name = "sname"
        Me.sname.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.sname.PlaceholderText = "Enter Supplier Name"
        Me.sname.SelectedText = ""
        Me.sname.Size = New System.Drawing.Size(313, 44)
        Me.sname.TabIndex = 4
        '
        'cname
        '
        Me.cname.BorderColor = System.Drawing.Color.LightGray
        Me.cname.BorderRadius = 5
        Me.cname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.cname.DefaultText = ""
        Me.cname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.cname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.cname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cname.ForeColor = System.Drawing.Color.Black
        Me.cname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cname.Location = New System.Drawing.Point(39, 52)
        Me.cname.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cname.Name = "cname"
        Me.cname.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.cname.PlaceholderText = "Enter Company Name"
        Me.cname.SelectedText = ""
        Me.cname.Size = New System.Drawing.Size(313, 44)
        Me.cname.TabIndex = 3
        '
        'txtSearchSupplier
        '
        Me.txtSearchSupplier.BorderColor = System.Drawing.Color.LightGray
        Me.txtSearchSupplier.BorderRadius = 5
        Me.txtSearchSupplier.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearchSupplier.DefaultText = ""
        Me.txtSearchSupplier.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearchSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearchSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearchSupplier.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearchSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearchSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchSupplier.ForeColor = System.Drawing.Color.Black
        Me.txtSearchSupplier.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearchSupplier.IconLeft = Global.TSSIS3.My.Resources.Resources.icons8_search_35
        Me.txtSearchSupplier.Location = New System.Drawing.Point(228, 116)
        Me.txtSearchSupplier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearchSupplier.Name = "txtSearchSupplier"
        Me.txtSearchSupplier.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtSearchSupplier.PlaceholderText = "Search Suppliers"
        Me.txtSearchSupplier.SelectedText = ""
        Me.txtSearchSupplier.Size = New System.Drawing.Size(304, 44)
        Me.txtSearchSupplier.TabIndex = 2
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.Transparent
        Me.btnupdate.BorderRadius = 5
        Me.btnupdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnupdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnupdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnupdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnupdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnupdate.FillColor = System.Drawing.Color.Orange
        Me.btnupdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdate.ForeColor = System.Drawing.Color.White
        Me.btnupdate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnupdate.ImageSize = New System.Drawing.Size(30, 30)
        Me.btnupdate.Location = New System.Drawing.Point(380, 261)
        Me.btnupdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(153, 43)
        Me.btnupdate.TabIndex = 10
        Me.btnupdate.Text = "Update"
        Me.btnupdate.Visible = False
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
        Me.addbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addbtn.ForeColor = System.Drawing.Color.White
        Me.addbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.addbtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.addbtn.Location = New System.Drawing.Point(379, 261)
        Me.addbtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.addbtn.Name = "addbtn"
        Me.addbtn.Size = New System.Drawing.Size(153, 43)
        Me.addbtn.TabIndex = 8
        Me.addbtn.Text = "Save"
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
        Me.clearbtn.Location = New System.Drawing.Point(540, 261)
        Me.clearbtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.clearbtn.Name = "clearbtn"
        Me.clearbtn.Size = New System.Drawing.Size(153, 43)
        Me.clearbtn.TabIndex = 9
        Me.clearbtn.Text = "Clear"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(35, 100)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 18)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Address"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(376, 177)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 18)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Email Address"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(376, 27)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 18)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Supplier Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(31, 177)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 18)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = " Contact Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(35, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 18)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Company Name"
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.PictureBox2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2Panel1)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(369, 186)
        Me.Guna2ShadowPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.Radius = 2
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(793, 420)
        Me.Guna2ShadowPanel1.TabIndex = 53
        Me.Guna2ShadowPanel1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(27, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Add Supplier"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_39
        Me.PictureBox2.Location = New System.Drawing.Point(725, 12)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(52, 48)
        Me.PictureBox2.TabIndex = 50
        Me.PictureBox2.TabStop = False
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.Label11)
        Me.Guna2Panel1.Controls.Add(Me.addbtn)
        Me.Guna2Panel1.Controls.Add(Me.Label3)
        Me.Guna2Panel1.Controls.Add(Me.adrss)
        Me.Guna2Panel1.Controls.Add(Me.Label4)
        Me.Guna2Panel1.Controls.Add(Me.eml)
        Me.Guna2Panel1.Controls.Add(Me.Label10)
        Me.Guna2Panel1.Controls.Add(Me.clearbtn)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.cname)
        Me.Guna2Panel1.Controls.Add(Me.sname)
        Me.Guna2Panel1.Controls.Add(Me.cno)
        Me.Guna2Panel1.Controls.Add(Me.btnupdate)
        Me.Guna2Panel1.Location = New System.Drawing.Point(31, 68)
        Me.Guna2Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(732, 329)
        Me.Guna2Panel1.TabIndex = 0
        '
        'btnAddnew
        '
        Me.btnAddnew.BorderRadius = 5
        Me.btnAddnew.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddnew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddnew.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddnew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddnew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddnew.ForeColor = System.Drawing.Color.White
        Me.btnAddnew.Image = Global.TSSIS3.My.Resources.Resources.icons8_add_30__1_
        Me.btnAddnew.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnAddnew.Location = New System.Drawing.Point(8, 116)
        Me.btnAddnew.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddnew.Name = "btnAddnew"
        Me.btnAddnew.Size = New System.Drawing.Size(215, 44)
        Me.btnAddnew.TabIndex = 1
        Me.btnAddnew.Text = "     Add New Supplier"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_window_50
        Me.PictureBox1.Location = New System.Drawing.Point(1409, 1)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(63, 60)
        Me.PictureBox1.TabIndex = 55
        Me.PictureBox1.TabStop = False
        '
        'Supplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1477, 841)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnAddnew)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.txtSearchSupplier)
        Me.Controls.Add(Me.Guna2DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Supplier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier"
        CType(Me.Guna2DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Guna2DataGridView1 As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents CompanyName As DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As DataGridViewTextBoxColumn
    Friend WithEvents ContactNo As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents adrss As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents eml As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cno As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents sname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtSearchSupplier As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents addbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents clearbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnupdate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnAddnew As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
