<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockReports
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockReports))
        Me.lblPage = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dgvStock = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.lblTotalStocks = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Guna2ShadowPanel2 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblLowStocks = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2ShadowPanel3 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.lblOutOfStock = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnincrease = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDecrease = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportToCSV = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportToPDF = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel3.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPage
        '
        Me.lblPage.BackColor = System.Drawing.Color.Transparent
        Me.lblPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPage.Location = New System.Drawing.Point(11, 767)
        Me.lblPage.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(61, 20)
        Me.lblPage.TabIndex = 89
        Me.lblPage.Text = "Page 1/2"
        '
        'dgvStock
        '
        Me.dgvStock.AllowUserToAddRows = False
        Me.dgvStock.AllowUserToDeleteRows = False
        Me.dgvStock.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvStock.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStock.ColumnHeadersHeight = 24
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStock.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStock.GridColor = System.Drawing.Color.White
        Me.dgvStock.Location = New System.Drawing.Point(7, 214)
        Me.dgvStock.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvStock.Name = "dgvStock"
        Me.dgvStock.ReadOnly = True
        Me.dgvStock.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvStock.RowHeadersVisible = False
        Me.dgvStock.RowHeadersWidth = 51
        Me.dgvStock.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dgvStock.RowTemplate.ReadOnly = True
        Me.dgvStock.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStock.Size = New System.Drawing.Size(1465, 545)
        Me.dgvStock.TabIndex = 75
        Me.dgvStock.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvStock.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvStock.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvStock.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvStock.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvStock.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvStock.ThemeStyle.GridColor = System.Drawing.Color.White
        Me.dgvStock.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvStock.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvStock.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvStock.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvStock.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvStock.ThemeStyle.HeaderStyle.Height = 24
        Me.dgvStock.ThemeStyle.ReadOnly = True
        Me.dgvStock.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvStock.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvStock.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvStock.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvStock.ThemeStyle.RowsStyle.Height = 22
        Me.dgvStock.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvStock.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.lblTotalStocks)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.PictureBox1)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(16, 10)
        Me.Guna2ShadowPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.Radius = 5
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(304, 123)
        Me.Guna2ShadowPanel1.TabIndex = 100
        '
        'lblTotalStocks
        '
        Me.lblTotalStocks.AutoSize = True
        Me.lblTotalStocks.BackColor = System.Drawing.Color.White
        Me.lblTotalStocks.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalStocks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotalStocks.Location = New System.Drawing.Point(131, 57)
        Me.lblTotalStocks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalStocks.Name = "lblTotalStocks"
        Me.lblTotalStocks.Size = New System.Drawing.Size(20, 23)
        Me.lblTotalStocks.TabIndex = 31
        Me.lblTotalStocks.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(131, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 23)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Total Stock(s)"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TSSIS3.My.Resources.Resources.icons8_product_65
        Me.PictureBox1.Location = New System.Drawing.Point(25, 11)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(97, 85)
        Me.PictureBox1.TabIndex = 55
        Me.PictureBox1.TabStop = False
        '
        'Guna2ShadowPanel2
        '
        Me.Guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel2.Controls.Add(Me.PictureBox2)
        Me.Guna2ShadowPanel2.Controls.Add(Me.lblLowStocks)
        Me.Guna2ShadowPanel2.Controls.Add(Me.Label3)
        Me.Guna2ShadowPanel2.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel2.Location = New System.Drawing.Point(328, 10)
        Me.Guna2ShadowPanel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2ShadowPanel2.Name = "Guna2ShadowPanel2"
        Me.Guna2ShadowPanel2.Radius = 5
        Me.Guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel2.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel2.Size = New System.Drawing.Size(304, 123)
        Me.Guna2ShadowPanel2.TabIndex = 100
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.TSSIS3.My.Resources.Resources.icons8_product_65
        Me.PictureBox2.Location = New System.Drawing.Point(25, 11)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(97, 85)
        Me.PictureBox2.TabIndex = 56
        Me.PictureBox2.TabStop = False
        '
        'lblLowStocks
        '
        Me.lblLowStocks.AutoSize = True
        Me.lblLowStocks.BackColor = System.Drawing.Color.White
        Me.lblLowStocks.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLowStocks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblLowStocks.Location = New System.Drawing.Point(131, 57)
        Me.lblLowStocks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLowStocks.Name = "lblLowStocks"
        Me.lblLowStocks.Size = New System.Drawing.Size(20, 23)
        Me.lblLowStocks.TabIndex = 31
        Me.lblLowStocks.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(131, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Low Stock(s)"
        '
        'Guna2ShadowPanel3
        '
        Me.Guna2ShadowPanel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel3.Controls.Add(Me.PictureBox4)
        Me.Guna2ShadowPanel3.Controls.Add(Me.lblOutOfStock)
        Me.Guna2ShadowPanel3.Controls.Add(Me.Label5)
        Me.Guna2ShadowPanel3.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel3.Location = New System.Drawing.Point(640, 10)
        Me.Guna2ShadowPanel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2ShadowPanel3.Name = "Guna2ShadowPanel3"
        Me.Guna2ShadowPanel3.Radius = 5
        Me.Guna2ShadowPanel3.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel3.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel3.Size = New System.Drawing.Size(304, 123)
        Me.Guna2ShadowPanel3.TabIndex = 101
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.TSSIS3.My.Resources.Resources.icons8_product_65
        Me.PictureBox4.Location = New System.Drawing.Point(25, 11)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(97, 85)
        Me.PictureBox4.TabIndex = 57
        Me.PictureBox4.TabStop = False
        '
        'lblOutOfStock
        '
        Me.lblOutOfStock.AutoSize = True
        Me.lblOutOfStock.BackColor = System.Drawing.Color.White
        Me.lblOutOfStock.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutOfStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblOutOfStock.Location = New System.Drawing.Point(131, 57)
        Me.lblOutOfStock.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOutOfStock.Name = "lblOutOfStock"
        Me.lblOutOfStock.Size = New System.Drawing.Size(20, 23)
        Me.lblOutOfStock.TabIndex = 31
        Me.lblOutOfStock.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(131, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 23)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Out Of Stock"
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
        Me.txtSearch.Location = New System.Drawing.Point(7, 161)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtSearch.PlaceholderText = "Search "
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(304, 44)
        Me.txtSearch.TabIndex = 90
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1411, 10)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(63, 60)
        Me.PictureBox3.TabIndex = 86
        Me.PictureBox3.TabStop = False
        '
        'btnincrease
        '
        Me.btnincrease.BorderRadius = 5
        Me.btnincrease.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnincrease.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnincrease.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnincrease.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnincrease.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnincrease.ForeColor = System.Drawing.Color.White
        Me.btnincrease.Image = CType(resources.GetObject("btnincrease.Image"), System.Drawing.Image)
        Me.btnincrease.Location = New System.Drawing.Point(179, 766)
        Me.btnincrease.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnincrease.Name = "btnincrease"
        Me.btnincrease.Size = New System.Drawing.Size(67, 43)
        Me.btnincrease.TabIndex = 85
        '
        'btnDecrease
        '
        Me.btnDecrease.BorderRadius = 5
        Me.btnDecrease.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDecrease.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDecrease.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDecrease.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDecrease.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDecrease.ForeColor = System.Drawing.Color.White
        Me.btnDecrease.Image = CType(resources.GetObject("btnDecrease.Image"), System.Drawing.Image)
        Me.btnDecrease.Location = New System.Drawing.Point(104, 766)
        Me.btnDecrease.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDecrease.Name = "btnDecrease"
        Me.btnDecrease.Size = New System.Drawing.Size(67, 43)
        Me.btnDecrease.TabIndex = 84
        '
        'btnExportToCSV
        '
        Me.btnExportToCSV.BorderRadius = 5
        Me.btnExportToCSV.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnExportToCSV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnExportToCSV.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnExportToCSV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnExportToCSV.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExportToCSV.ForeColor = System.Drawing.Color.White
        Me.btnExportToCSV.Image = CType(resources.GetObject("btnExportToCSV.Image"), System.Drawing.Image)
        Me.btnExportToCSV.Location = New System.Drawing.Point(1275, 766)
        Me.btnExportToCSV.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExportToCSV.Name = "btnExportToCSV"
        Me.btnExportToCSV.Size = New System.Drawing.Size(197, 43)
        Me.btnExportToCSV.TabIndex = 83
        Me.btnExportToCSV.Text = "Export To CSV"
        '
        'btnExportToPDF
        '
        Me.btnExportToPDF.BorderRadius = 5
        Me.btnExportToPDF.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnExportToPDF.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnExportToPDF.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnExportToPDF.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnExportToPDF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExportToPDF.ForeColor = System.Drawing.Color.White
        Me.btnExportToPDF.Image = CType(resources.GetObject("btnExportToPDF.Image"), System.Drawing.Image)
        Me.btnExportToPDF.Location = New System.Drawing.Point(1069, 766)
        Me.btnExportToPDF.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExportToPDF.Name = "btnExportToPDF"
        Me.btnExportToPDF.Size = New System.Drawing.Size(197, 43)
        Me.btnExportToPDF.TabIndex = 82
        Me.btnExportToPDF.Text = "Export To PDF"
        '
        'StockReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1480, 841)
        Me.Controls.Add(Me.Guna2ShadowPanel3)
        Me.Controls.Add(Me.Guna2ShadowPanel2)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.dgvStock)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblPage)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.btnincrease)
        Me.Controls.Add(Me.btnDecrease)
        Me.Controls.Add(Me.btnExportToCSV)
        Me.Controls.Add(Me.btnExportToPDF)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "StockReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "StockReports"
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel2.ResumeLayout(False)
        Me.Guna2ShadowPanel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel3.ResumeLayout(False)
        Me.Guna2ShadowPanel3.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPage As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnincrease As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDecrease As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportToCSV As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportToPDF As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgvStock As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblTotalStocks As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Guna2ShadowPanel2 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblLowStocks As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Guna2ShadowPanel3 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblOutOfStock As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
End Class
