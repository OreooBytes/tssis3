<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PointOfSale
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PointOfSale))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtBarcode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.rbRetail = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.rbWholesale = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.txtPayment = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblChanges = New System.Windows.Forms.Label()
        Me.lblCashier = New System.Windows.Forms.Label()
        Me.btnCheckout = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNewTransaction = New Guna.UI2.WinForms.Guna2Button()
        Me.btnHoldTransaction = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRetrieveHold = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAvailableProducts = New Guna.UI2.WinForms.Guna2Button()
        Me.lblVAT = New System.Windows.Forms.Label()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.cmbDiscount = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtEditQuantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnUpdateQuantity = New Guna.UI2.WinForms.Guna2Button()
        Me.lblVatableSales = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel5 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.PanelQuantity = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel4 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Guna2Button2 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button3 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button4 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button5 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button6 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button7 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button8 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button9 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button10 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button11 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button12 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button13 = New Guna.UI2.WinForms.Guna2Button()
        Me.dgvCart = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.PanelCheckout = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel6 = New Guna.UI2.WinForms.Guna2Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2Panel7 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Guna2Button15 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button14 = New Guna.UI2.WinForms.Guna2Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Guna2Panel1.SuspendLayout()
        Me.PanelQuantity.SuspendLayout()
        Me.Guna2Panel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCheckout.SuspendLayout()
        Me.Guna2Panel6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBarcode
        '
        Me.txtBarcode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBarcode.DefaultText = ""
        Me.txtBarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBarcode.Location = New System.Drawing.Point(653, 488)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.PlaceholderText = ""
        Me.txtBarcode.SelectedText = ""
        Me.txtBarcode.Size = New System.Drawing.Size(148, 36)
        Me.txtBarcode.TabIndex = 0
        '
        'rbRetail
        '
        Me.rbRetail.AutoSize = True
        Me.rbRetail.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbRetail.CheckedState.BorderThickness = 0
        Me.rbRetail.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbRetail.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbRetail.CheckedState.InnerOffset = -4
        Me.rbRetail.Font = New System.Drawing.Font("Segoe UI Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRetail.Location = New System.Drawing.Point(11, 223)
        Me.rbRetail.Name = "rbRetail"
        Me.rbRetail.Size = New System.Drawing.Size(66, 21)
        Me.rbRetail.TabIndex = 1
        Me.rbRetail.Text = "Retail "
        Me.rbRetail.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbRetail.UncheckedState.BorderThickness = 2
        Me.rbRetail.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbRetail.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'rbWholesale
        '
        Me.rbWholesale.AutoSize = True
        Me.rbWholesale.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbWholesale.CheckedState.BorderThickness = 0
        Me.rbWholesale.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbWholesale.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbWholesale.CheckedState.InnerOffset = -4
        Me.rbWholesale.Font = New System.Drawing.Font("Segoe UI Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbWholesale.Location = New System.Drawing.Point(83, 223)
        Me.rbWholesale.Name = "rbWholesale"
        Me.rbWholesale.Size = New System.Drawing.Size(91, 21)
        Me.rbWholesale.TabIndex = 2
        Me.rbWholesale.Text = "Wholesale" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rbWholesale.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbWholesale.UncheckedState.BorderThickness = 2
        Me.rbWholesale.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbWholesale.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAmount.Location = New System.Drawing.Point(11, 167)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(143, 25)
        Me.lblTotalAmount.TabIndex = 4
        Me.lblTotalAmount.Text = "Total Amount :"
        '
        'txtPayment
        '
        Me.txtPayment.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPayment.DefaultText = ""
        Me.txtPayment.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPayment.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPayment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPayment.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtPayment.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPayment.Location = New System.Drawing.Point(11, 95)
        Me.txtPayment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPayment.Name = "txtPayment"
        Me.txtPayment.PlaceholderText = ""
        Me.txtPayment.SelectedText = ""
        Me.txtPayment.Size = New System.Drawing.Size(223, 43)
        Me.txtPayment.TabIndex = 5
        '
        'lblChanges
        '
        Me.lblChanges.AutoSize = True
        Me.lblChanges.Font = New System.Drawing.Font("Segoe UI Black", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblChanges.Location = New System.Drawing.Point(3, 68)
        Me.lblChanges.Name = "lblChanges"
        Me.lblChanges.Size = New System.Drawing.Size(87, 25)
        Me.lblChanges.TabIndex = 6
        Me.lblChanges.Text = "Change "
        '
        'lblCashier
        '
        Me.lblCashier.AutoSize = True
        Me.lblCashier.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashier.Location = New System.Drawing.Point(13, 27)
        Me.lblCashier.Name = "lblCashier"
        Me.lblCashier.Size = New System.Drawing.Size(48, 17)
        Me.lblCashier.TabIndex = 7
        Me.lblCashier.Text = "Label1"
        '
        'btnCheckout
        '
        Me.btnCheckout.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCheckout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCheckout.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCheckout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCheckout.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCheckout.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckout.ForeColor = System.Drawing.Color.White
        Me.btnCheckout.Location = New System.Drawing.Point(29, 280)
        Me.btnCheckout.Name = "btnCheckout"
        Me.btnCheckout.Size = New System.Drawing.Size(150, 39)
        Me.btnCheckout.TabIndex = 8
        Me.btnCheckout.Text = "CHECK OUT"
        '
        'btnNewTransaction
        '
        Me.btnNewTransaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnNewTransaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnNewTransaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnNewTransaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnNewTransaction.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNewTransaction.ForeColor = System.Drawing.Color.White
        Me.btnNewTransaction.Location = New System.Drawing.Point(965, 373)
        Me.btnNewTransaction.Name = "btnNewTransaction"
        Me.btnNewTransaction.Size = New System.Drawing.Size(152, 50)
        Me.btnNewTransaction.TabIndex = 9
        Me.btnNewTransaction.Text = "New Transaction"
        '
        'btnHoldTransaction
        '
        Me.btnHoldTransaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnHoldTransaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnHoldTransaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnHoldTransaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnHoldTransaction.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnHoldTransaction.ForeColor = System.Drawing.Color.White
        Me.btnHoldTransaction.Location = New System.Drawing.Point(965, 488)
        Me.btnHoldTransaction.Name = "btnHoldTransaction"
        Me.btnHoldTransaction.Size = New System.Drawing.Size(152, 45)
        Me.btnHoldTransaction.TabIndex = 10
        Me.btnHoldTransaction.Text = "Hold Transaction"
        '
        'btnRetrieveHold
        '
        Me.btnRetrieveHold.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnRetrieveHold.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnRetrieveHold.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnRetrieveHold.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnRetrieveHold.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRetrieveHold.ForeColor = System.Drawing.Color.White
        Me.btnRetrieveHold.Location = New System.Drawing.Point(965, 314)
        Me.btnRetrieveHold.Name = "btnRetrieveHold"
        Me.btnRetrieveHold.Size = New System.Drawing.Size(152, 50)
        Me.btnRetrieveHold.TabIndex = 11
        Me.btnRetrieveHold.Text = "Retrieve Hold"
        '
        'btnAvailableProducts
        '
        Me.btnAvailableProducts.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAvailableProducts.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAvailableProducts.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAvailableProducts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAvailableProducts.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAvailableProducts.ForeColor = System.Drawing.Color.White
        Me.btnAvailableProducts.Location = New System.Drawing.Point(965, 432)
        Me.btnAvailableProducts.Name = "btnAvailableProducts"
        Me.btnAvailableProducts.Size = New System.Drawing.Size(152, 50)
        Me.btnAvailableProducts.TabIndex = 12
        Me.btnAvailableProducts.Text = "Available Products"
        '
        'lblVAT
        '
        Me.lblVAT.AutoSize = True
        Me.lblVAT.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVAT.Location = New System.Drawing.Point(11, 98)
        Me.lblVAT.Name = "lblVAT"
        Me.lblVAT.Size = New System.Drawing.Size(51, 25)
        Me.lblVAT.TabIndex = 14
        Me.lblVAT.Text = "Vat :"
        '
        'lblDiscount
        '
        Me.lblDiscount.AutoSize = True
        Me.lblDiscount.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscount.Location = New System.Drawing.Point(11, 63)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(101, 25)
        Me.lblDiscount.TabIndex = 13
        Me.lblDiscount.Text = "Discount :"
        '
        'cmbDiscount
        '
        Me.cmbDiscount.BackColor = System.Drawing.Color.Transparent
        Me.cmbDiscount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiscount.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDiscount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbDiscount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbDiscount.ItemHeight = 30
        Me.cmbDiscount.Location = New System.Drawing.Point(11, 171)
        Me.cmbDiscount.Name = "cmbDiscount"
        Me.cmbDiscount.Size = New System.Drawing.Size(223, 36)
        Me.cmbDiscount.TabIndex = 15
        '
        'txtEditQuantity
        '
        Me.txtEditQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEditQuantity.DefaultText = ""
        Me.txtEditQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtEditQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtEditQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEditQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEditQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEditQuantity.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEditQuantity.Location = New System.Drawing.Point(3, 48)
        Me.txtEditQuantity.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEditQuantity.Name = "txtEditQuantity"
        Me.txtEditQuantity.PlaceholderText = "Edit Quantity"
        Me.txtEditQuantity.SelectedText = ""
        Me.txtEditQuantity.Size = New System.Drawing.Size(346, 74)
        Me.txtEditQuantity.TabIndex = 16
        '
        'btnUpdateQuantity
        '
        Me.btnUpdateQuantity.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdateQuantity.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdateQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnUpdateQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnUpdateQuantity.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnUpdateQuantity.ForeColor = System.Drawing.Color.White
        Me.btnUpdateQuantity.Location = New System.Drawing.Point(807, 488)
        Me.btnUpdateQuantity.Name = "btnUpdateQuantity"
        Me.btnUpdateQuantity.Size = New System.Drawing.Size(152, 45)
        Me.btnUpdateQuantity.TabIndex = 17
        Me.btnUpdateQuantity.Text = "Guna2Button5"
        Me.btnUpdateQuantity.Visible = False
        '
        'lblVatableSales
        '
        Me.lblVatableSales.AutoSize = True
        Me.lblVatableSales.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVatableSales.Location = New System.Drawing.Point(11, 132)
        Me.lblVatableSales.Name = "lblVatableSales"
        Me.lblVatableSales.Size = New System.Drawing.Size(137, 25)
        Me.lblVatableSales.TabIndex = 18
        Me.lblVatableSales.Text = "Vatable Sales :"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Guna2Panel1.Controls.Add(Me.lblSubTotal)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Panel2)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.lblVAT)
        Me.Guna2Panel1.Controls.Add(Me.lblDiscount)
        Me.Guna2Panel1.Controls.Add(Me.lblVatableSales)
        Me.Guna2Panel1.Controls.Add(Me.lblCashier)
        Me.Guna2Panel1.Controls.Add(Me.lblTotalAmount)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Panel5)
        Me.Guna2Panel1.Location = New System.Drawing.Point(653, 9)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(464, 240)
        Me.Guna2Panel1.TabIndex = 19
        '
        'lblSubTotal
        '
        Me.lblSubTotal.AutoSize = True
        Me.lblSubTotal.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblSubTotal.Location = New System.Drawing.Point(11, 198)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(143, 25)
        Me.lblSubTotal.TabIndex = 21
        Me.lblSubTotal.Text = "Total Amount :"
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Guna2Panel2.Location = New System.Drawing.Point(3, 56)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(457, 4)
        Me.Guna2Panel2.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Cashier :"
        '
        'Guna2Panel5
        '
        Me.Guna2Panel5.Location = New System.Drawing.Point(0, 3)
        Me.Guna2Panel5.Name = "Guna2Panel5"
        Me.Guna2Panel5.Size = New System.Drawing.Size(464, 47)
        Me.Guna2Panel5.TabIndex = 20
        '
        'Guna2Button1
        '
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.Location = New System.Drawing.Point(965, 255)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(152, 50)
        Me.Guna2Button1.TabIndex = 21
        Me.Guna2Button1.Text = "Pay"
        '
        'PanelQuantity
        '
        Me.PanelQuantity.BackColor = System.Drawing.SystemColors.Control
        Me.PanelQuantity.Controls.Add(Me.Guna2Panel4)
        Me.PanelQuantity.Controls.Add(Me.txtEditQuantity)
        Me.PanelQuantity.Location = New System.Drawing.Point(201, 107)
        Me.PanelQuantity.Name = "PanelQuantity"
        Me.PanelQuantity.Size = New System.Drawing.Size(352, 125)
        Me.PanelQuantity.TabIndex = 21
        Me.PanelQuantity.Visible = False
        '
        'Guna2Panel4
        '
        Me.Guna2Panel4.BackColor = System.Drawing.Color.DarkBlue
        Me.Guna2Panel4.Controls.Add(Me.Label2)
        Me.Guna2Panel4.Controls.Add(Me.PictureBox3)
        Me.Guna2Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Guna2Panel4.Name = "Guna2Panel4"
        Me.Guna2Panel4.Size = New System.Drawing.Size(346, 46)
        Me.Guna2Panel4.TabIndex = 32
        Me.Guna2Panel4.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 25)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Quantity"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(306, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(43, 43)
        Me.PictureBox3.TabIndex = 31
        Me.PictureBox3.TabStop = False
        '
        'Guna2Button2
        '
        Me.Guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button2.ForeColor = System.Drawing.Color.White
        Me.Guna2Button2.Location = New System.Drawing.Point(653, 255)
        Me.Guna2Button2.Name = "Guna2Button2"
        Me.Guna2Button2.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button2.TabIndex = 22
        Me.Guna2Button2.Text = "1"
        '
        'Guna2Button3
        '
        Me.Guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button3.ForeColor = System.Drawing.Color.White
        Me.Guna2Button3.Location = New System.Drawing.Point(757, 255)
        Me.Guna2Button3.Name = "Guna2Button3"
        Me.Guna2Button3.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button3.TabIndex = 23
        Me.Guna2Button3.Text = "2"
        '
        'Guna2Button4
        '
        Me.Guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button4.ForeColor = System.Drawing.Color.White
        Me.Guna2Button4.Location = New System.Drawing.Point(861, 255)
        Me.Guna2Button4.Name = "Guna2Button4"
        Me.Guna2Button4.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button4.TabIndex = 24
        Me.Guna2Button4.Text = "3"
        '
        'Guna2Button5
        '
        Me.Guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button5.ForeColor = System.Drawing.Color.White
        Me.Guna2Button5.Location = New System.Drawing.Point(653, 314)
        Me.Guna2Button5.Name = "Guna2Button5"
        Me.Guna2Button5.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button5.TabIndex = 25
        Me.Guna2Button5.Text = "4"
        '
        'Guna2Button6
        '
        Me.Guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button6.ForeColor = System.Drawing.Color.White
        Me.Guna2Button6.Location = New System.Drawing.Point(757, 314)
        Me.Guna2Button6.Name = "Guna2Button6"
        Me.Guna2Button6.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button6.TabIndex = 26
        Me.Guna2Button6.Text = "5"
        '
        'Guna2Button7
        '
        Me.Guna2Button7.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button7.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button7.ForeColor = System.Drawing.Color.White
        Me.Guna2Button7.Location = New System.Drawing.Point(861, 314)
        Me.Guna2Button7.Name = "Guna2Button7"
        Me.Guna2Button7.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button7.TabIndex = 27
        Me.Guna2Button7.Text = "6"
        '
        'Guna2Button8
        '
        Me.Guna2Button8.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button8.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button8.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button8.ForeColor = System.Drawing.Color.White
        Me.Guna2Button8.Location = New System.Drawing.Point(653, 373)
        Me.Guna2Button8.Name = "Guna2Button8"
        Me.Guna2Button8.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button8.TabIndex = 28
        Me.Guna2Button8.Text = "7"
        '
        'Guna2Button9
        '
        Me.Guna2Button9.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button9.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button9.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button9.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button9.ForeColor = System.Drawing.Color.White
        Me.Guna2Button9.Location = New System.Drawing.Point(757, 373)
        Me.Guna2Button9.Name = "Guna2Button9"
        Me.Guna2Button9.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button9.TabIndex = 29
        Me.Guna2Button9.Text = "8"
        '
        'Guna2Button10
        '
        Me.Guna2Button10.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button10.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button10.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button10.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button10.ForeColor = System.Drawing.Color.White
        Me.Guna2Button10.Location = New System.Drawing.Point(861, 373)
        Me.Guna2Button10.Name = "Guna2Button10"
        Me.Guna2Button10.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button10.TabIndex = 30
        Me.Guna2Button10.Text = "9"
        '
        'Guna2Button11
        '
        Me.Guna2Button11.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button11.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button11.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button11.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button11.ForeColor = System.Drawing.Color.White
        Me.Guna2Button11.Location = New System.Drawing.Point(653, 432)
        Me.Guna2Button11.Name = "Guna2Button11"
        Me.Guna2Button11.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button11.TabIndex = 31
        Me.Guna2Button11.Text = "."
        '
        'Guna2Button12
        '
        Me.Guna2Button12.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button12.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button12.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button12.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button12.ForeColor = System.Drawing.Color.White
        Me.Guna2Button12.Location = New System.Drawing.Point(757, 432)
        Me.Guna2Button12.Name = "Guna2Button12"
        Me.Guna2Button12.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button12.TabIndex = 32
        Me.Guna2Button12.Text = "0"
        '
        'Guna2Button13
        '
        Me.Guna2Button13.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button13.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button13.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button13.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button13.ForeColor = System.Drawing.Color.White
        Me.Guna2Button13.Location = New System.Drawing.Point(861, 432)
        Me.Guna2Button13.Name = "Guna2Button13"
        Me.Guna2Button13.Size = New System.Drawing.Size(98, 50)
        Me.Guna2Button13.TabIndex = 33
        Me.Guna2Button13.Text = "00"
        '
        'dgvCart
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.dgvCart.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvCart.ColumnHeadersHeight = 4
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCart.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvCart.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCart.Location = New System.Drawing.Point(12, 9)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.RowHeadersVisible = False
        Me.dgvCart.Size = New System.Drawing.Size(635, 737)
        Me.dgvCart.TabIndex = 34
        Me.dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvCart.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvCart.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCart.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvCart.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvCart.ThemeStyle.ReadOnly = False
        Me.dgvCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvCart.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvCart.ThemeStyle.RowsStyle.Height = 22
        Me.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Image = CType(resources.GetObject("Guna2PictureBox1.Image"), System.Drawing.Image)
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(652, 530)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(461, 207)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Guna2PictureBox1.TabIndex = 35
        Me.Guna2PictureBox1.TabStop = False
        '
        'PanelCheckout
        '
        Me.PanelCheckout.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PanelCheckout.Controls.Add(Me.Guna2Panel6)
        Me.PanelCheckout.Controls.Add(Me.Guna2Panel7)
        Me.PanelCheckout.Controls.Add(Me.rbRetail)
        Me.PanelCheckout.Controls.Add(Me.cmbDiscount)
        Me.PanelCheckout.Controls.Add(Me.txtPayment)
        Me.PanelCheckout.Controls.Add(Me.rbWholesale)
        Me.PanelCheckout.Controls.Add(Me.Label4)
        Me.PanelCheckout.Controls.Add(Me.Label6)
        Me.PanelCheckout.Location = New System.Drawing.Point(167, 298)
        Me.PanelCheckout.Name = "PanelCheckout"
        Me.PanelCheckout.Size = New System.Drawing.Size(453, 373)
        Me.PanelCheckout.TabIndex = 32
        Me.PanelCheckout.Visible = False
        '
        'Guna2Panel6
        '
        Me.Guna2Panel6.BackColor = System.Drawing.Color.DarkBlue
        Me.Guna2Panel6.Controls.Add(Me.PictureBox1)
        Me.Guna2Panel6.Controls.Add(Me.Label3)
        Me.Guna2Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel6.Name = "Guna2Panel6"
        Me.Guna2Panel6.Size = New System.Drawing.Size(543, 46)
        Me.Guna2Panel6.TabIndex = 33
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(410, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(43, 43)
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 25)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Checkout"
        '
        'Guna2Panel7
        '
        Me.Guna2Panel7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2Panel7.Controls.Add(Me.lblChange)
        Me.Guna2Panel7.Controls.Add(Me.Label7)
        Me.Guna2Panel7.Controls.Add(Me.Label5)
        Me.Guna2Panel7.Controls.Add(Me.Guna2Button15)
        Me.Guna2Panel7.Controls.Add(Me.Guna2Button14)
        Me.Guna2Panel7.Controls.Add(Me.btnCheckout)
        Me.Guna2Panel7.Controls.Add(Me.lblChanges)
        Me.Guna2Panel7.Location = New System.Drawing.Point(241, 45)
        Me.Guna2Panel7.Name = "Guna2Panel7"
        Me.Guna2Panel7.Size = New System.Drawing.Size(212, 328)
        Me.Guna2Panel7.TabIndex = 34
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Segoe UI Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.Location = New System.Drawing.Point(3, 98)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(70, 25)
        Me.lblChange.TabIndex = 37
        Me.lblChange.Text = "₱ 0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 25)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "₱ 0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 25)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Total Amount"
        '
        'Guna2Button15
        '
        Me.Guna2Button15.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button15.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button15.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button15.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button15.FillColor = System.Drawing.Color.DimGray
        Me.Guna2Button15.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button15.ForeColor = System.Drawing.Color.White
        Me.Guna2Button15.Location = New System.Drawing.Point(29, 190)
        Me.Guna2Button15.Name = "Guna2Button15"
        Me.Guna2Button15.Size = New System.Drawing.Size(150, 39)
        Me.Guna2Button15.TabIndex = 10
        Me.Guna2Button15.Text = "CANCEL"
        '
        'Guna2Button14
        '
        Me.Guna2Button14.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button14.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button14.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button14.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button14.FillColor = System.Drawing.Color.Red
        Me.Guna2Button14.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button14.ForeColor = System.Drawing.Color.White
        Me.Guna2Button14.Location = New System.Drawing.Point(29, 235)
        Me.Guna2Button14.Name = "Guna2Button14"
        Me.Guna2Button14.Size = New System.Drawing.Size(150, 39)
        Me.Guna2Button14.TabIndex = 9
        Me.Guna2Button14.Text = "VOID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 25)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Amount Paid"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 25)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Discount Type"
        '
        'PointOfSale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1158, 749)
        Me.Controls.Add(Me.PanelCheckout)
        Me.Controls.Add(Me.PanelQuantity)
        Me.Controls.Add(Me.Guna2Button13)
        Me.Controls.Add(Me.Guna2Button12)
        Me.Controls.Add(Me.Guna2Button11)
        Me.Controls.Add(Me.Guna2Button10)
        Me.Controls.Add(Me.Guna2Button9)
        Me.Controls.Add(Me.Guna2Button8)
        Me.Controls.Add(Me.Guna2Button7)
        Me.Controls.Add(Me.Guna2Button6)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Guna2Button5)
        Me.Controls.Add(Me.Guna2Button4)
        Me.Controls.Add(Me.Guna2Button3)
        Me.Controls.Add(Me.Guna2Button2)
        Me.Controls.Add(Me.Guna2Button1)
        Me.Controls.Add(Me.btnUpdateQuantity)
        Me.Controls.Add(Me.btnAvailableProducts)
        Me.Controls.Add(Me.btnRetrieveHold)
        Me.Controls.Add(Me.btnHoldTransaction)
        Me.Controls.Add(Me.btnNewTransaction)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.dgvCart)
        Me.Controls.Add(Me.Guna2PictureBox1)
        Me.Name = "PointOfSale"
        Me.Text = "PointOfSale"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.PanelQuantity.ResumeLayout(False)
        Me.Guna2Panel4.ResumeLayout(False)
        Me.Guna2Panel4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCheckout.ResumeLayout(False)
        Me.PanelCheckout.PerformLayout()
        Me.Guna2Panel6.ResumeLayout(False)
        Me.Guna2Panel6.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel7.ResumeLayout(False)
        Me.Guna2Panel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtBarcode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents rbRetail As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents rbWholesale As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents txtPayment As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblChanges As Label
    Friend WithEvents lblCashier As Label
    Friend WithEvents btnCheckout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNewTransaction As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnHoldTransaction As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRetrieveHold As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAvailableProducts As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblVAT As Label
    Friend WithEvents lblDiscount As Label
    Friend WithEvents cmbDiscount As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtEditQuantity As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnUpdateQuantity As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblVatableSales As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PanelQuantity As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Guna2Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button4 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button5 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button6 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button7 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button8 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button9 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button10 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button11 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button12 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button13 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel5 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dgvCart As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents PanelCheckout As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel4 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel6 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Guna2Panel7 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Guna2Button15 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button14 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents lblSubTotal As Label
End Class
