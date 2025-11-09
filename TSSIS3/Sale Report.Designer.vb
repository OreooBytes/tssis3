<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SaleReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaleReport))
        Me.dgvAllReports = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.cmbReportType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dtpEnd = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.dtpStart = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.lblPeriod = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDate = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblPage = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2ShadowPanel2 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblTotalSales = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTotalProfit = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnincrease = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDecrease = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportToCSV = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportToPDF = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.dgvAllReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAllReports
        '
        Me.dgvAllReports.AllowUserToAddRows = False
        Me.dgvAllReports.AllowUserToDeleteRows = False
        Me.dgvAllReports.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvAllReports.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAllReports.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAllReports.ColumnHeadersHeight = 24
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAllReports.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAllReports.GridColor = System.Drawing.Color.White
        Me.dgvAllReports.Location = New System.Drawing.Point(5, 205)
        Me.dgvAllReports.Name = "dgvAllReports"
        Me.dgvAllReports.ReadOnly = True
        Me.dgvAllReports.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvAllReports.RowHeadersVisible = False
        Me.dgvAllReports.RowHeadersWidth = 51
        Me.dgvAllReports.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dgvAllReports.RowTemplate.ReadOnly = True
        Me.dgvAllReports.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAllReports.Size = New System.Drawing.Size(1099, 411)
        Me.dgvAllReports.TabIndex = 17
        Me.dgvAllReports.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvAllReports.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvAllReports.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvAllReports.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvAllReports.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvAllReports.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvAllReports.ThemeStyle.GridColor = System.Drawing.Color.White
        Me.dgvAllReports.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAllReports.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvAllReports.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAllReports.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvAllReports.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvAllReports.ThemeStyle.HeaderStyle.Height = 24
        Me.dgvAllReports.ThemeStyle.ReadOnly = True
        Me.dgvAllReports.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvAllReports.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvAllReports.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAllReports.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvAllReports.ThemeStyle.RowsStyle.Height = 22
        Me.dgvAllReports.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAllReports.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'cmbReportType
        '
        Me.cmbReportType.BackColor = System.Drawing.Color.Transparent
        Me.cmbReportType.BorderRadius = 5
        Me.cmbReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbReportType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbReportType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReportType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbReportType.ItemHeight = 30
        Me.cmbReportType.Items.AddRange(New Object() {"Daily Sales Report", "Weekly Sales Report", "Monthly Sales Report", "Yearly Sales Report"})
        Me.cmbReportType.Location = New System.Drawing.Point(421, 163)
        Me.cmbReportType.Name = "cmbReportType"
        Me.cmbReportType.Size = New System.Drawing.Size(207, 36)
        Me.cmbReportType.TabIndex = 18
        Me.cmbReportType.Visible = False
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(668, 142)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(67, 17)
        Me.Guna2HtmlLabel1.TabIndex = 21
        Me.Guna2HtmlLabel1.Text = "Start Date"
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(889, 142)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(62, 17)
        Me.Guna2HtmlLabel2.TabIndex = 22
        Me.Guna2HtmlLabel2.Text = "End Date"
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(421, 142)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(87, 17)
        Me.Guna2HtmlLabel3.TabIndex = 23
        Me.Guna2HtmlLabel3.Text = "Report Types"
        Me.Guna2HtmlLabel3.Visible = False
        '
        'dtpEnd
        '
        Me.dtpEnd.BorderRadius = 5
        Me.dtpEnd.Checked = True
        Me.dtpEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dtpEnd.ForeColor = System.Drawing.Color.White
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpEnd.Location = New System.Drawing.Point(889, 165)
        Me.dtpEnd.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEnd.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(215, 36)
        Me.dtpEnd.TabIndex = 19
        Me.dtpEnd.Value = New Date(2025, 10, 15, 14, 8, 44, 199)
        '
        'dtpStart
        '
        Me.dtpStart.BorderRadius = 5
        Me.dtpStart.Checked = True
        Me.dtpStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dtpStart.ForeColor = System.Drawing.Color.White
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpStart.Location = New System.Drawing.Point(668, 165)
        Me.dtpStart.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpStart.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(215, 36)
        Me.dtpStart.TabIndex = 20
        Me.dtpStart.Value = New Date(2025, 10, 15, 14, 8, 44, 199)
        '
        'lblPeriod
        '
        Me.lblPeriod.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblPeriod.Location = New System.Drawing.Point(6, 139)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(150, 33)
        Me.lblPeriod.TabIndex = 72
        Me.lblPeriod.Text = "Daily Sales"
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDate.Location = New System.Drawing.Point(6, 181)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(83, 18)
        Me.lblDate.TabIndex = 73
        Me.lblDate.Text = "Daily Sales"
        '
        'lblPage
        '
        Me.lblPage.BackColor = System.Drawing.Color.Transparent
        Me.lblPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPage.Location = New System.Drawing.Point(6, 623)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(52, 17)
        Me.lblPage.TabIndex = 74
        Me.lblPage.Text = "Page 1/2"
        '
        'Guna2ShadowPanel2
        '
        Me.Guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel2.Controls.Add(Me.PictureBox2)
        Me.Guna2ShadowPanel2.Controls.Add(Me.lblTotalSales)
        Me.Guna2ShadowPanel2.Controls.Add(Me.Label3)
        Me.Guna2ShadowPanel2.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel2.Location = New System.Drawing.Point(6, 12)
        Me.Guna2ShadowPanel2.Name = "Guna2ShadowPanel2"
        Me.Guna2ShadowPanel2.Radius = 5
        Me.Guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel2.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel2.Size = New System.Drawing.Size(251, 100)
        Me.Guna2ShadowPanel2.TabIndex = 101
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.TSSIS3.My.Resources.Resources.icons8_peso_symbol_65
        Me.PictureBox2.Location = New System.Drawing.Point(19, 9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(73, 69)
        Me.PictureBox2.TabIndex = 56
        Me.PictureBox2.TabStop = False
        '
        'lblTotalSales
        '
        Me.lblTotalSales.AutoSize = True
        Me.lblTotalSales.BackColor = System.Drawing.Color.White
        Me.lblTotalSales.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotalSales.Location = New System.Drawing.Point(98, 46)
        Me.lblTotalSales.Name = "lblTotalSales"
        Me.lblTotalSales.Size = New System.Drawing.Size(15, 17)
        Me.lblTotalSales.TabIndex = 31
        Me.lblTotalSales.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(98, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 17)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Total Sales (Overall)"
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.PictureBox1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.lblTotalProfit)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label2)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(263, 12)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.Radius = 5
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(251, 100)
        Me.Guna2ShadowPanel1.TabIndex = 102
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TSSIS3.My.Resources.Resources.icons8_peso_symbol_65
        Me.PictureBox1.Location = New System.Drawing.Point(19, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 69)
        Me.PictureBox1.TabIndex = 57
        Me.PictureBox1.TabStop = False
        '
        'lblTotalProfit
        '
        Me.lblTotalProfit.AutoSize = True
        Me.lblTotalProfit.BackColor = System.Drawing.Color.White
        Me.lblTotalProfit.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalProfit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotalProfit.Location = New System.Drawing.Point(98, 46)
        Me.lblTotalProfit.Name = "lblTotalProfit"
        Me.lblTotalProfit.Size = New System.Drawing.Size(15, 17)
        Me.lblTotalProfit.TabIndex = 31
        Me.lblTotalProfit.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(98, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 17)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Total Profit (Overall)"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1057, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(47, 49)
        Me.PictureBox3.TabIndex = 71
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
        Me.btnincrease.Location = New System.Drawing.Point(132, 622)
        Me.btnincrease.Name = "btnincrease"
        Me.btnincrease.Size = New System.Drawing.Size(50, 35)
        Me.btnincrease.TabIndex = 28
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
        Me.btnDecrease.Location = New System.Drawing.Point(76, 622)
        Me.btnDecrease.Name = "btnDecrease"
        Me.btnDecrease.Size = New System.Drawing.Size(50, 35)
        Me.btnDecrease.TabIndex = 27
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
        Me.btnExportToCSV.Location = New System.Drawing.Point(956, 622)
        Me.btnExportToCSV.Name = "btnExportToCSV"
        Me.btnExportToCSV.Size = New System.Drawing.Size(148, 35)
        Me.btnExportToCSV.TabIndex = 25
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
        Me.btnExportToPDF.Location = New System.Drawing.Point(802, 622)
        Me.btnExportToPDF.Name = "btnExportToPDF"
        Me.btnExportToPDF.Size = New System.Drawing.Size(148, 35)
        Me.btnExportToPDF.TabIndex = 24
        Me.btnExportToPDF.Text = "Export To PDF"
        '
        'SaleReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1110, 683)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.Guna2ShadowPanel2)
        Me.Controls.Add(Me.cmbReportType)
        Me.Controls.Add(Me.lblPage)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.btnincrease)
        Me.Controls.Add(Me.btnDecrease)
        Me.Controls.Add(Me.btnExportToCSV)
        Me.Controls.Add(Me.btnExportToPDF)
        Me.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.dgvAllReports)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SaleReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sale_Report"
        CType(Me.dgvAllReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel2.ResumeLayout(False)
        Me.Guna2ShadowPanel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvAllReports As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents cmbReportType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnExportToPDF As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportToCSV As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDecrease As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnincrease As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents dtpEnd As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents dtpStart As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents lblPeriod As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDate As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblPage As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2ShadowPanel2 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblTotalSales As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblTotalProfit As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
