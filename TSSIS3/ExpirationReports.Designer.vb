<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpirationReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpirationReports))
        Me.lblPage = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dgvExpiration = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.cmbStatus = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbMonths = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblmonths = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblStatus = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2ShadowPanel2 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.lblExpired = New System.Windows.Forms.Label()
        Me.lblCashier = New System.Windows.Forms.Label()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.lblValid = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2ShadowPanel3 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.lblNonExpiring = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPulledItems = New Guna.UI2.WinForms.Guna2Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnincrease = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDecrease = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportToCSV = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportToPDF = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.dgvExpiration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel2.SuspendLayout()
        Me.Guna2ShadowPanel1.SuspendLayout()
        Me.Guna2ShadowPanel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPage
        '
        Me.lblPage.BackColor = System.Drawing.Color.Transparent
        Me.lblPage.Font = New System.Drawing.Font("Outfit", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPage.Location = New System.Drawing.Point(6, 623)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(47, 17)
        Me.lblPage.TabIndex = 89
        Me.lblPage.Text = "Page 1/2"
        '
        'dgvExpiration
        '
        Me.dgvExpiration.AllowUserToAddRows = False
        Me.dgvExpiration.AllowUserToDeleteRows = False
        Me.dgvExpiration.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvExpiration.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExpiration.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvExpiration.ColumnHeadersHeight = 24
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExpiration.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvExpiration.GridColor = System.Drawing.Color.White
        Me.dgvExpiration.Location = New System.Drawing.Point(5, 204)
        Me.dgvExpiration.Name = "dgvExpiration"
        Me.dgvExpiration.ReadOnly = True
        Me.dgvExpiration.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvExpiration.RowHeadersVisible = False
        Me.dgvExpiration.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dgvExpiration.RowTemplate.ReadOnly = True
        Me.dgvExpiration.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExpiration.Size = New System.Drawing.Size(1099, 412)
        Me.dgvExpiration.TabIndex = 75
        Me.dgvExpiration.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvExpiration.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvExpiration.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvExpiration.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvExpiration.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvExpiration.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvExpiration.ThemeStyle.GridColor = System.Drawing.Color.White
        Me.dgvExpiration.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvExpiration.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvExpiration.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvExpiration.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvExpiration.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvExpiration.ThemeStyle.HeaderStyle.Height = 24
        Me.dgvExpiration.ThemeStyle.ReadOnly = True
        Me.dgvExpiration.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvExpiration.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvExpiration.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvExpiration.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvExpiration.ThemeStyle.RowsStyle.Height = 22
        Me.dgvExpiration.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvExpiration.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'cmbStatus
        '
        Me.cmbStatus.BackColor = System.Drawing.Color.Transparent
        Me.cmbStatus.BorderRadius = 5
        Me.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbStatus.ItemHeight = 30
        Me.cmbStatus.Location = New System.Drawing.Point(913, 162)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(191, 36)
        Me.cmbStatus.TabIndex = 93
        '
        'cmbMonths
        '
        Me.cmbMonths.BackColor = System.Drawing.Color.Transparent
        Me.cmbMonths.BorderRadius = 5
        Me.cmbMonths.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonths.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbMonths.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbMonths.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbMonths.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbMonths.ItemHeight = 30
        Me.cmbMonths.Location = New System.Drawing.Point(716, 162)
        Me.cmbMonths.Name = "cmbMonths"
        Me.cmbMonths.Size = New System.Drawing.Size(191, 36)
        Me.cmbMonths.TabIndex = 94
        '
        'lblmonths
        '
        Me.lblmonths.BackColor = System.Drawing.Color.Transparent
        Me.lblmonths.Font = New System.Drawing.Font("Outfit", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmonths.Location = New System.Drawing.Point(716, 141)
        Me.lblmonths.Name = "lblmonths"
        Me.lblmonths.Size = New System.Drawing.Size(44, 17)
        Me.lblmonths.TabIndex = 96
        Me.lblmonths.Text = "Months"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Outfit", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(913, 141)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 17)
        Me.lblStatus.TabIndex = 97
        Me.lblStatus.Text = "Status"
        '
        'Guna2ShadowPanel2
        '
        Me.Guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel2.Controls.Add(Me.lblExpired)
        Me.Guna2ShadowPanel2.Controls.Add(Me.lblCashier)
        Me.Guna2ShadowPanel2.Controls.Add(Me.PictureBox5)
        Me.Guna2ShadowPanel2.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel2.Location = New System.Drawing.Point(239, 12)
        Me.Guna2ShadowPanel2.Name = "Guna2ShadowPanel2"
        Me.Guna2ShadowPanel2.Radius = 5
        Me.Guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel2.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel2.Size = New System.Drawing.Size(228, 100)
        Me.Guna2ShadowPanel2.TabIndex = 98
        '
        'lblExpired
        '
        Me.lblExpired.AutoSize = True
        Me.lblExpired.BackColor = System.Drawing.Color.White
        Me.lblExpired.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpired.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblExpired.Location = New System.Drawing.Point(98, 46)
        Me.lblExpired.Name = "lblExpired"
        Me.lblExpired.Size = New System.Drawing.Size(15, 17)
        Me.lblExpired.TabIndex = 31
        Me.lblExpired.Text = "0"
        '
        'lblCashier
        '
        Me.lblCashier.AutoSize = True
        Me.lblCashier.BackColor = System.Drawing.Color.White
        Me.lblCashier.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashier.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCashier.Location = New System.Drawing.Point(98, 21)
        Me.lblCashier.Name = "lblCashier"
        Me.lblCashier.Size = New System.Drawing.Size(122, 17)
        Me.lblCashier.TabIndex = 32
        Me.lblCashier.Text = "Expired Product(s)"
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.lblValid)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.PictureBox1)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(6, 12)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.Radius = 5
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(228, 100)
        Me.Guna2ShadowPanel1.TabIndex = 99
        '
        'lblValid
        '
        Me.lblValid.AutoSize = True
        Me.lblValid.BackColor = System.Drawing.Color.White
        Me.lblValid.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblValid.Location = New System.Drawing.Point(98, 46)
        Me.lblValid.Name = "lblValid"
        Me.lblValid.Size = New System.Drawing.Size(15, 17)
        Me.lblValid.TabIndex = 31
        Me.lblValid.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(98, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 17)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Valid Product(s)"
        '
        'Guna2ShadowPanel3
        '
        Me.Guna2ShadowPanel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel3.Controls.Add(Me.lblNonExpiring)
        Me.Guna2ShadowPanel3.Controls.Add(Me.Label4)
        Me.Guna2ShadowPanel3.Controls.Add(Me.PictureBox2)
        Me.Guna2ShadowPanel3.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel3.Location = New System.Drawing.Point(473, 12)
        Me.Guna2ShadowPanel3.Name = "Guna2ShadowPanel3"
        Me.Guna2ShadowPanel3.Radius = 5
        Me.Guna2ShadowPanel3.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel3.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        Me.Guna2ShadowPanel3.Size = New System.Drawing.Size(249, 100)
        Me.Guna2ShadowPanel3.TabIndex = 100
        '
        'lblNonExpiring
        '
        Me.lblNonExpiring.AutoSize = True
        Me.lblNonExpiring.BackColor = System.Drawing.Color.White
        Me.lblNonExpiring.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNonExpiring.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblNonExpiring.Location = New System.Drawing.Point(98, 46)
        Me.lblNonExpiring.Name = "lblNonExpiring"
        Me.lblNonExpiring.Size = New System.Drawing.Size(15, 17)
        Me.lblNonExpiring.TabIndex = 31
        Me.lblNonExpiring.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(98, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 17)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Non-Expiring Products"
        '
        'btnPulledItems
        '
        Me.btnPulledItems.BorderRadius = 5
        Me.btnPulledItems.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPulledItems.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPulledItems.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPulledItems.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPulledItems.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPulledItems.ForeColor = System.Drawing.Color.White
        Me.btnPulledItems.Image = Global.TSSIS3.My.Resources.Resources.icons8_open_box_30_normal
        Me.btnPulledItems.Location = New System.Drawing.Point(239, 163)
        Me.btnPulledItems.Name = "btnPulledItems"
        Me.btnPulledItems.Size = New System.Drawing.Size(148, 35)
        Me.btnPulledItems.TabIndex = 83
        Me.btnPulledItems.Text = "Pulled Items"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.TSSIS3.My.Resources.Resources.icons8_products_65
        Me.PictureBox2.Location = New System.Drawing.Point(19, 9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(73, 69)
        Me.PictureBox2.TabIndex = 55
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TSSIS3.My.Resources.Resources.icons8_products_651
        Me.PictureBox1.Location = New System.Drawing.Point(19, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 69)
        Me.PictureBox1.TabIndex = 55
        Me.PictureBox1.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.TSSIS3.My.Resources.Resources.icons8_expired_65
        Me.PictureBox5.Location = New System.Drawing.Point(19, 9)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(73, 69)
        Me.PictureBox5.TabIndex = 55
        Me.PictureBox5.TabStop = False
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
        Me.txtSearch.Font = New System.Drawing.Font("Outfit", 9.0!)
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.IconLeft = Global.TSSIS3.My.Resources.Resources.icons8_search_35
        Me.txtSearch.Location = New System.Drawing.Point(5, 162)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtSearch.PlaceholderText = "Search Product"
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(228, 36)
        Me.txtSearch.TabIndex = 91
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1057, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(47, 49)
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
        Me.btnincrease.Location = New System.Drawing.Point(132, 622)
        Me.btnincrease.Name = "btnincrease"
        Me.btnincrease.Size = New System.Drawing.Size(50, 35)
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
        Me.btnDecrease.Location = New System.Drawing.Point(76, 622)
        Me.btnDecrease.Name = "btnDecrease"
        Me.btnDecrease.Size = New System.Drawing.Size(50, 35)
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
        Me.btnExportToCSV.Location = New System.Drawing.Point(956, 622)
        Me.btnExportToCSV.Name = "btnExportToCSV"
        Me.btnExportToCSV.Size = New System.Drawing.Size(148, 35)
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
        Me.btnExportToPDF.Location = New System.Drawing.Point(803, 622)
        Me.btnExportToPDF.Name = "btnExportToPDF"
        Me.btnExportToPDF.Size = New System.Drawing.Size(148, 35)
        Me.btnExportToPDF.TabIndex = 82
        Me.btnExportToPDF.Text = "Export To PDF"
        '
        'ExpirationReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1110, 683)
        Me.Controls.Add(Me.btnPulledItems)
        Me.Controls.Add(Me.Guna2ShadowPanel3)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.Guna2ShadowPanel2)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblmonths)
        Me.Controls.Add(Me.cmbMonths)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblPage)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.btnincrease)
        Me.Controls.Add(Me.btnDecrease)
        Me.Controls.Add(Me.btnExportToCSV)
        Me.Controls.Add(Me.btnExportToPDF)
        Me.Controls.Add(Me.dgvExpiration)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ExpirationReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ExpirationReports"
        CType(Me.dgvExpiration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel2.ResumeLayout(False)
        Me.Guna2ShadowPanel2.PerformLayout()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        Me.Guna2ShadowPanel3.ResumeLayout(False)
        Me.Guna2ShadowPanel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvExpiration As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cmbStatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cmbMonths As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblmonths As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblStatus As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2ShadowPanel2 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblExpired As Label
    Friend WithEvents lblCashier As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblValid As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Guna2ShadowPanel3 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblNonExpiring As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnPulledItems As Guna.UI2.WinForms.Guna2Button
End Class
