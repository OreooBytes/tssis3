Imports Guna.UI.WinForms
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports ZXing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class POS
    ' For loyalty discount feature
    Private loyaltyDiscountPercent As Decimal = 0D
    Private redeemablePointsRequired As Integer = 0
    Private loyaltyDiscountAmount As Decimal = 0D
    Private memberBarcode As String = ""
    Private isMemberSelected As Boolean = False
    ' at top of the POS form class
    Private isLoyaltyApplied As Boolean = False

    ' === Logged-in cashier ===
    Public Property CashierName As String

    ' === Currently editing row index ===
    Private editingRowIndex As Integer = -1

    ' === Store last computed VAT amount ===
    Private lastVatAmount As Decimal = 0

    Private Const CornerRadius As Integer = 10 ' fixed radius

    ' ===== Timer for real-time update =====
    Private WithEvents DashboardTimer As New Timer()

    ' Track current date to detect day change
    Private currentDate As Date = Date.Today


    ' ===== TOP OF FORM (Global variables) =====
    Private currentInvoiceNo As String
    Private currentTransactionNo As String
    Private WithEvents focusTimer As New Timer()




    ' === Class for discount combo box items ===
    Public Class DiscountItem
        Public Property Text As String
        Public Property Value As Decimal
        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    ' === Form Load ===

    Private Sub PointOfSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnCancel.Visible = False
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
        End Using

        GenerateNewNumbers()

        btnredeempoints.Visible = False

        LoadLoyaltySettings()

        SetupProductListGrid()

        '===== POS / METRICS =====
        LoadPOSMetrics()

        '===== Check Out Retail / Wholse =====
        rbRetail.Checked = True

        '===== Label Fore Color =====
        lblPayment.ForeColor = ColorTranslator.FromHtml("#1D3A70")

        '===== Label Radius / Backcolor =====
        Guna2Panel6.BackColor = Color.Gainsboro
        Guna2Panel6.BorderRadius = 5

        '===== For Customer Picure box =====
        userpbcircle.FillColor = ColorTranslator.FromHtml("#1D3A70")

        '===== For Dgv =====
        SetupCartDGV()



        '===== For Load =====
        LoadDiscounts()

        '===== Lastname / Fistnmae Letter =====
        LoadUserInitials()

        '===== User Fullname =====
        lblCashier.Text = SessionData.fullName  ' optional, kung gusto mo rin ipakita buong name


        CheckProductCount()

        '===== Button Fore Color =====

        btnNewTransaction.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btnRetrieveHold.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btnHoldTransaction.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btnAddMember.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btnReturn.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn50.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn100.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn500.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn1000.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btnSelectProduct.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btnCheckout.ForeColor = ColorTranslator.FromHtml("#1D3A70")
        btnPay.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btnLogout.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btnReturnrefund.ForeColor = ColorTranslator.FromHtml("#FFD93D")

        btndot.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn00.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn0.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn1.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn2.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn3.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn4.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn5.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn6.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn7.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn8.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn9.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn50.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn100.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn500.ForeColor = ColorTranslator.FromHtml("#FFD93D")
        btn1000.ForeColor = ColorTranslator.FromHtml("#FFD93D")



        '===== Button Fore Color =====

        dgvProductList.Font = New Font("Outfit", 8, FontStyle.Regular)
        dgvCart.Font = New Font("Outfit", 8, FontStyle.Regular)



        '===== Button fill  Color =====

        btnSelectProduct.FillColor = ColorTranslator.FromHtml("#FFD93D")
        btnNewTransaction.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnRetrieveHold.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnHoldTransaction.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnAddMember.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnReturn.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnPay.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnCheckout.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnSelectProduct.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnCheckout.FillColor = ColorTranslator.FromHtml("#FFD93D")
        customerpbcircle.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnLogout.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnReturnrefund.FillColor = ColorTranslator.FromHtml("#1D3A70")
        customerpbcircle.FillColor = ColorTranslator.FromHtml("#1D3A70")

        btndot.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn00.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn0.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn1.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn2.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn3.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn4.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn5.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn6.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn7.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn8.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn9.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn50.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn100.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn500.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btn1000.FillColor = ColorTranslator.FromHtml("#1D3A70")


        '======= btn font size =======

        btn50.Font = New Font(btn50.Font.FontFamily, 6, btn50.Font.Style)
        btn100.Font = New Font(btn50.Font.FontFamily, 6, btn50.Font.Style)
        btn500.Font = New Font(btn50.Font.FontFamily, 6, btn50.Font.Style)
        btn1000.Font = New Font(btn50.Font.FontFamily, 6, btn50.Font.Style)


        '======= ApplyRounded ========
        ApplyRoundedCorners2()

        '======= Focus Txtbarcode ========
        txtBarcode.Focus()

        '======= Timer ========
        Timer1.Start()

        '======= Label Setup ========
        lblTotalAmount.Text = " ₱ 0.00"
        lblVAT.Text = "₱ 0.00"
        lblDiscount.Text = "₱ 0.00"
        lblVatableSales.Text = "₱ 0.00"
        lblloyaltydiscount.Text = "₱ 0.00"
        lblWholesale.Text = "₱ 0.00"
        lblSubtotal.Text = "₱ 0.00"


        '=== FOR POS METRICS ===

        ' Setup Timer
        DashboardTimer.Interval = 1000 ' every 5 seconds
        DashboardTimer.Start()

        'StartFocusTimer(1000) ' default 1 second



        '=== FOR Short key ===

        Me.KeyPreview = True


        '=== panelquantity Visible ===
        panelquantity.Visible = False


    End Sub

    'Private Sub StartFocusTimer(intervalValue As Integer)
    '    focusTimer.Stop()
    '    focusTimer.Interval = intervalValue
    '    focusTimer.Start()
    'End Sub

    'Private Sub focusTimer_Tick(sender As Object, e As EventArgs) Handles focusTimer.Tick
    '    If Not txtBarcode.Focused Then
    '        txtBarcode.Focus()
    '    End If
    'End Sub



    ' === AUTO GENERATE TRX - RCP ===

    Private rand As New Random() ' Form-level Random instance

    Private Sub GenerateNewNumbers()
        ' Random generator
        Dim rand As New Random()

        ' ===== Shortened Transaction Number: 14 characters =====
        ' Timestamp: yyMMddHHmm (10 digits)
        ' Random: 4 digits (ensuring total length is 14)
        Dim transSuffix As Integer = rand.Next(1000, 9999) ' 4-digit random number
        Dim transTimestamp As String = DateTime.Now.ToString("yyMMddHHmm") ' 10 digits
        currentTransactionNo = "TXN" & transTimestamp & transSuffix ' Total length: 14 characters


        ' ===== Invoice Number: 13 characters =====
        ' Timestamp: yyMMddHHmmss (12 digits)
        ' Random: 1 digit (ensuring total length is 13)
        Dim invoiceSuffix As Integer = rand.Next(0, 9) ' 1-digit random number (0 to 9)
        Dim invoiceMillis As String = DateTime.Now.ToString("yyMMddHHmmss")
        currentInvoiceNo = "RCP" & invoiceMillis & invoiceSuffix ' Total length: 13 characters

        ' Update labels
        lblInvoiceNo.Text = "Receipt # : " & currentInvoiceNo
        lblTransactionNo.Text = "Transaction # : " & currentTransactionNo
    End Sub


    ' === LoadLoyalSettings ===
    Private Sub LoadLoyaltySettings()
        Using conn As MySqlConnection = Module1.Openconnection()
            Dim sql As String = "SELECT RedeemablePoints, Currentloyaltydiscount 
                             FROM loyaltydiscount 
                             ORDER BY id DESC LIMIT 1"
            Using cmd As New MySqlCommand(sql, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        redeemablePointsRequired = Convert.ToInt32(reader("RedeemablePoints"))
                        loyaltyDiscountPercent = Convert.ToDecimal(reader("Currentloyaltydiscount"))
                    End If
                End Using
            End Using
            Module1.ConnectionClose(conn)
        End Using
    End Sub

    ' === LOAD DISCOUNTS ===
    Private Sub LoadDiscounts()
        cmbDiscount.Items.Clear()

        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
            Dim sql As String = "SELECT * FROM discount ORDER BY DiscountPercent ASC"
            Using cmd As New MySqlCommand(sql, conn)
                Dim reader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New DiscountItem()
                    item.Text = reader("DiscountType").ToString()
                    item.Value = CDec(reader("DiscountPercent"))
                    cmbDiscount.Items.Add(item)
                End While
            End Using
        End Using
        If cmbDiscount.Items.Count > 0 Then cmbDiscount.SelectedIndex = -1
        txtBarcode.Focus()
    End Sub


    '=================== USERS FIRSTNAME / LASTNAME ========================
    Private Sub LoadUserInitials()
        ' --- Safety check kung may control ---
        If userpbcircle Is Nothing Then Return

        ' --- Kunin ang buong pangalan mula sa SessionData (o palitan kung ibang variable gamit mo) ---
        Dim fullName As String = If(SessionData.fullName, "").Trim()
        If fullName = "" Then fullName = "User"

        ' --- Ihiwalay ang mga pangalan ---
        Dim names() As String = fullName.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
        Dim initials As String = ""

        ' --- Kunin ang first letter ng First at Last name ---
        If names.Length >= 2 Then
            initials = names(0).Substring(0, 1).ToUpper() & names(names.Length - 1).Substring(0, 1).ToUpper()
        ElseIf names.Length = 1 Then
            initials = names(0).Substring(0, 1).ToUpper()
        Else
            initials = "?"
        End If

        ' --- Linisin muna ang lumang label sa loob ng picturebox ---
        For i As Integer = userpbcircle.Controls.Count - 1 To 0 Step -1
            Dim ctrl As Control = userpbcircle.Controls(i)
            If TypeOf ctrl Is Label Then
                userpbcircle.Controls.Remove(ctrl)
                ctrl.Dispose()
            End If
        Next

        ' --- Gumawa ng bagong Label para sa initials ---
        Dim lblInitials As New Label() With {
        .Text = initials,
        .ForeColor = Color.White,
        .BackColor = Color.Transparent,
        .TextAlign = ContentAlignment.MiddleCenter,
        .AutoSize = False,
        .Font = New Font("Segoe UI", 16, FontStyle.Bold),
        .Size = userpbcircle.Size,
        .Location = New Point(0, 0)
    }

        ' --- Idagdag sa loob ng PictureBox ---
        userpbcircle.Controls.Add(lblInitials)
        lblInitials.BringToFront()
    End Sub


    ' === LOAD CUSTOMERS ===

    Private Sub LoadCustomerInitials(customerName As String)
        ' --- Safety check ---
        If customerpbcircle Is Nothing Then Return

        ' --- Default name kung walang laman ---
        Dim fullName As String = If(customerName, "").Trim()
        If fullName = "" Then fullName = "Customer"

        ' --- Ihiwalay ang mga pangalan ---
        Dim names() As String = fullName.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
        Dim initials As String = ""

        ' --- Kunin ang first letter ng first at last name ---
        If names.Length >= 2 Then
            initials = names(0).Substring(0, 1).ToUpper() & names(names.Length - 1).Substring(0, 1).ToUpper()
        ElseIf names.Length = 1 Then
            initials = names(0).Substring(0, 1).ToUpper()
        Else
            initials = "?"
        End If

        ' --- Linisin muna ang lumang label ---
        For i As Integer = customerpbcircle.Controls.Count - 1 To 0 Step -1
            Dim ctrl As Control = customerpbcircle.Controls(i)
            If TypeOf ctrl Is Label Then
                customerpbcircle.Controls.Remove(ctrl)
                ctrl.Dispose()
            End If
        Next

        ' --- Gumawa ng bagong label ---
        Dim lblInitials As New Label() With {
        .Text = initials,
        .ForeColor = Color.White,
        .BackColor = Color.Transparent,
        .TextAlign = ContentAlignment.MiddleCenter,
        .AutoSize = False,
        .Font = New Font("Segoe UI", 16, FontStyle.Bold),
        .Size = customerpbcircle.Size,
        .Location = New Point(0, 0)
    }

        ' --- Idagdag sa loob ng PictureBox ---
        customerpbcircle.Controls.Add(lblInitials)
        lblInitials.BringToFront()
    End Sub



    ' === ApplyRoundedCorners ===
    Private Sub ApplyRoundedCorners2()
        Dim path As New GraphicsPath()

        ' Top-left
        path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90)
        ' Top edge
        path.AddLine(CornerRadius, 0, Me.Width - CornerRadius, 0)
        ' Top-right
        path.AddArc(Me.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90)
        ' Right edge
        path.AddLine(Me.Width, CornerRadius, Me.Width, Me.Height - CornerRadius)
        ' Bottom-right
        path.AddArc(Me.Width - CornerRadius, Me.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90)
        ' Bottom edge
        path.AddLine(Me.Width - CornerRadius, Me.Height, CornerRadius, Me.Height)
        ' Bottom-left
        path.AddArc(0, Me.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90)
        ' Left edge
        path.AddLine(0, Me.Height - CornerRadius, 0, CornerRadius)

        path.CloseFigure()
        Me.Region = New Region(path)
        Me.Invalidate()
    End Sub

    '=================== POS / METRICS ========================

    Private Sub DashboardTimer_Tick(sender As Object, e As EventArgs) Handles DashboardTimer.Tick
        ' Check if day has changed
        If Date.Today <> currentDate Then
            currentDate = Date.Today
            ' Metrics na need i-reset will auto-update based on CURDATE()
        End If

        ' Refresh metrics
        LoadPOSMetrics()
    End Sub


    '===================  LoadPOSMetrics ========================

    Private Sub LoadPOSMetrics()
        Using conn As New MySqlConnection(connectionstring)
            Try
                conn.Open()

                ' ==== 1. Total Revenue (Overall) ====
                Dim totalRevenueQuery As String = "
                SELECT IFNULL(SUM(TotalAmount), 0)
                FROM sales
            "
                Using cmd As New MySqlCommand(totalRevenueQuery, conn)
                    lblTotalRevenue.Text = "₱" & Format(CDec(cmd.ExecuteScalar()), "N2")
                End Using

                ' ==== 2. Today's Sales ====
                Dim todaySalesQuery As String = "
                SELECT IFNULL(SUM(TotalAmount), 0)
                FROM sales
                WHERE DATE(SaleDate) = CURDATE()
            "
                Using cmd As New MySqlCommand(todaySalesQuery, conn)
                    lblTodaySale.Text = "₱" & Format(CDec(cmd.ExecuteScalar()), "N2")
                End Using

                ' ==== 3. Pending / Hold Transactions (count only) ====
                Dim holdQuery As String = "
                SELECT COUNT(*)
                FROM hold_transaction_items
            "
                Using cmd As New MySqlCommand(holdQuery, conn)
                    lblHold.Text = cmd.ExecuteScalar().ToString() & " items"
                End Using

                ' ==== 4. Average Sale per Customer (Today) ====
                Dim avgSaleQuery As String = "
                SELECT IFNULL(SUM(TotalAmount) / COUNT(DISTINCT SaleID), 0)
                FROM sales
                WHERE DATE(SaleDate) = CURDATE()
            "
                Using cmd As New MySqlCommand(avgSaleQuery, conn)
                    lblAverageSale.Text = "₱" & Format(CDec(cmd.ExecuteScalar()), "N2")
                End Using

                ' ==== 5. Total Customers Today ====
                Dim totalCustQuery As String = "
                SELECT COUNT(DISTINCT SaleID)
                FROM sales
                WHERE DATE(SaleDate) = CURDATE()
            "
                Using cmd As New MySqlCommand(totalCustQuery, conn)
                    lblTotalCustomers.Text = cmd.ExecuteScalar().ToString()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error loading dashboard metrics: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub


    '=================== DATE / TIME ========================
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = DateTime.Now.ToString("ddd, MMMM dd, yyyy")
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    ' ================= SCAN BARCODE ===================



    ' ================= COMPUTE CART TOTAL WITH DISCOUNT AND VAT ===================

    ' === Update total when discount changes ===
    Private Sub cmbDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscount.SelectedIndexChanged
        ComputeCartTotal()
        txtBarcode.Focus()
    End Sub


    ' ===== Current product tracking =====
    Private currentProductBarcode As String = ""
    Private currentBaseName As String = ""
    Private currentStockQty As Integer = 0
    Private currentRetailPrice As Decimal = 0D
    Private currentWholesalePrice As Decimal = 0D

    ' --- Barcode Scan KeyDown ---
    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim barcode As String = txtBarcode.Text.Trim()
            If Not String.IsNullOrEmpty(barcode) Then
                ' Fetch product info and show quantity input
                PrepareProductForQuantity(barcode)
            End If

            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    ' --- Quantity Input KeyDown ---
    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            Dim qty As Integer = 1

            ' Try parse input quantity
            If Integer.TryParse(txtQuantity.Text, qty) Then
                ' Minimum quantity = 1
                If qty < 1 Then qty = 1

                ' Cap quantity to available stock
                If qty > currentStockQty Then
                    qty = currentStockQty
                    MessageBox.Show($"Maximum available stock for '{currentBaseName}' is {currentStockQty}.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ' Add product to cart using the quantity entered
                AddItemToCartWithQuantity(currentProductBarcode, currentBaseName, qty, currentRetailPrice, currentWholesalePrice, currentStockQty)

                ' Reset input
                panelquantity.Visible = False
                txtQuantity.Clear()
                txtBarcode.Clear()
                txtBarcode.Focus()
            End If
        End If
    End Sub

    ' --- Prepare product info for quantity input ---
    Private Sub PrepareProductForQuantity(barcode As String)
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                Dim sql As String = "
                SELECT p.ProductName,
                       p.Description,
                       p.RetailPrice,
                       p.WholesalePrice,
                       i.Quantity
                FROM product p
                LEFT JOIN inventory i ON p.BarcodeID = i.BarcodeID
                WHERE p.BarcodeID = @barcode
            "

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@barcode", barcode)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            currentBaseName = reader("ProductName").ToString()
                            Dim description As String = If(IsDBNull(reader("Description")), "", reader("Description").ToString())
                            currentRetailPrice = If(IsDBNull(reader("RetailPrice")), 0D, Convert.ToDecimal(reader("RetailPrice")))
                            currentWholesalePrice = If(IsDBNull(reader("WholesalePrice")), 0D, Convert.ToDecimal(reader("WholesalePrice")))
                            currentStockQty = If(IsDBNull(reader("Quantity")), 0, Convert.ToInt32(reader("Quantity")))
                            currentProductBarcode = barcode

                            If currentStockQty < 1 Then
                                MessageBox.Show($"Product '{currentBaseName}' is out of stock!", "Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                txtBarcode.Clear()
                                txtBarcode.Focus()
                                Return
                            End If

                            ' Show quantity input panel for user
                            panelquantity.Visible = True
                            txtQuantity.Clear()
                            txtQuantity.Focus()

                        Else
                            MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtBarcode.Clear()
                            txtBarcode.Focus()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading product data: " & ex.Message)
        End Try
    End Sub

    ' --- Add product to cart with specific quantity ---
    Private Sub AddItemToCartWithQuantity(barcode As String, baseProductName As String, inputQty As Integer, retailPrice As Decimal, wholesalePrice As Decimal, stockQty As Integer)
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' === Get Product Info + Description + Prices + Stock ===
                Dim sql As String = "
                SELECT p.ProductName,
                       p.Description,
                       p.RetailPrice,
                       p.WholesalePrice,
                       i.Quantity
                FROM product p
                LEFT JOIN inventory i ON p.BarcodeID = i.BarcodeID
                WHERE p.BarcodeID = @barcode
            "

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@barcode", barcode)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then

                            Dim description As String = If(IsDBNull(reader("Description")), "", reader("Description").ToString())
                            Dim productName As String = If(String.IsNullOrWhiteSpace(description), baseProductName, baseProductName & " (" & description & ")")
                            Dim currentStock As Integer = If(IsDBNull(reader("Quantity")), 0, Convert.ToInt32(reader("Quantity")))

                            reader.Close()

                            ' === UPDATE CART ===
                            Dim existingCartRow = dgvCart.Rows.Cast(Of DataGridViewRow)().
                            FirstOrDefault(Function(r) r.Cells("Barcode").Value.ToString() = barcode)

                            Dim cartRow As DataGridViewRow

                            If existingCartRow IsNot Nothing Then
                                Dim currentQty As Integer = Convert.ToInt32(existingCartRow.Cells("Quantity").Value)

                                If currentQty + inputQty <= currentStock Then
                                    currentQty += inputQty
                                Else
                                    currentQty = currentStock
                                    MessageBox.Show($"Maximum stock reached for '{baseProductName}'.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                                Dim thresh As Integer = GetWholesaleThreshold(barcode, baseProductName)
                                Dim finalPrice As Decimal = If(thresh > 0 AndAlso currentQty >= thresh, wholesalePrice, retailPrice)

                                existingCartRow.Cells("Quantity").Value = currentQty
                                existingCartRow.Cells("UnitPrice").Value = finalPrice
                                existingCartRow.Cells("Total").Value = currentQty * finalPrice
                                existingCartRow.Cells("PriceType").Value = If(thresh > 0 AndAlso currentQty >= thresh, "Wholesale", "Retail")
                                existingCartRow.Cells("ProductName").Value = productName

                                cartRow = existingCartRow

                            Else
                                ' New row
                                If inputQty > currentStock Then inputQty = currentStock
                                Dim initialThresh As Integer = GetWholesaleThreshold(barcode, baseProductName)
                                Dim finalPrice As Decimal = If(initialThresh > 0 AndAlso inputQty >= initialThresh, wholesalePrice, retailPrice)
                                Dim initialType As String = If(initialThresh > 0 AndAlso inputQty >= initialThresh, "Wholesale", "Retail")

                                dgvCart.Rows.Add(barcode, productName, inputQty, finalPrice, inputQty * finalPrice, initialType)
                                cartRow = dgvCart.Rows(dgvCart.Rows.Count - 1)
                            End If

                            ' === Highlight cart row temporarily ===
                            HighlightCartRowTemporary(cartRow)

                            ' === Recompute totals ===
                            ComputeCartTotal()

                            ' === UPDATE PRODUCT LIST ===
                            Dim existingPLRow = dgvProductList.Rows.Cast(Of DataGridViewRow)().
                            FirstOrDefault(Function(r) r.Cells("ProductName").Value.ToString() = baseProductName)

                            Dim totalInCart As Integer = dgvCart.Rows.Cast(Of DataGridViewRow)().
                            Where(Function(r) r.Cells("Barcode").Value.ToString() = barcode).
                            Sum(Function(r) Convert.ToInt32(r.Cells("Quantity").Value))

                            If existingPLRow IsNot Nothing Then
                                existingPLRow.Cells("EditQuantity").Value = totalInCart
                                existingPLRow.Cells("AvailableQuantity").Value = currentStock
                            Else
                                Dim newPLRowIndex As Integer = dgvProductList.Rows.Add(baseProductName, totalInCart, currentStock)
                                Dim plRow = dgvProductList.Rows(newPLRowIndex)
                                With plRow.Cells("EditQuantity").Style
                                    .BackColor = Color.LightGreen
                                    .SelectionBackColor = Color.LightGreen
                                    .ForeColor = Color.Black
                                    .SelectionForeColor = Color.Black
                                End With
                            End If

                        Else
                            MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding product to cart: " & ex.Message)
        End Try
    End Sub

    '===== ORGINAL =======
    Private Sub AddItemToCartDynamic(barcode As String)
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' === Get Product Info + Description + Prices + Stock ===
                Dim sql As String = "
            SELECT p.ProductName,
                   p.Description,
                   p.RetailPrice,
                   p.WholesalePrice,
                   i.Quantity
            FROM product p
            LEFT JOIN inventory i ON p.BarcodeID = i.BarcodeID
            WHERE p.BarcodeID = @barcode
        "

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@barcode", barcode)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then

                            Dim baseProductName As String = reader("ProductName").ToString()
                            Dim description As String = If(IsDBNull(reader("Description")), "", reader("Description").ToString())

                            ' === DISPLAY ONLY (ProductName + Description) ===
                            Dim productName As String =
                        If(String.IsNullOrWhiteSpace(description),
                           baseProductName,
                           baseProductName & " (" & description & ")")

                            Dim stockQty As Integer = If(IsDBNull(reader("Quantity")), 0, Convert.ToInt32(reader("Quantity")))
                            Dim retailPrice As Decimal = If(IsDBNull(reader("RetailPrice")), 0D, Convert.ToDecimal(reader("RetailPrice")))
                            Dim wholesalePrice As Decimal = If(IsDBNull(reader("WholesalePrice")), 0D, Convert.ToDecimal(reader("WholesalePrice")))

                            If stockQty < 1 Then
                                MessageBox.Show($"Product '{baseProductName}' is out of stock!",
                                        "Stock Alert",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning)
                                Return
                            End If

                            ' === GET INPUT QUANTITY (Default = 1) ===
                            Dim inputQty As Integer = 1
                            If panelquantity.Visible AndAlso Integer.TryParse(txtQuantity.Text, inputQty) Then
                                If inputQty <= 0 Then inputQty = 1
                            End If

                            reader.Close()

                            ' === UPDATE CART ===
                            Dim existingCartRow = dgvCart.Rows.Cast(Of DataGridViewRow)().
                        FirstOrDefault(Function(r) r.Cells("Barcode").Value.ToString() = barcode)

                            Dim cartRow As DataGridViewRow

                            If existingCartRow IsNot Nothing Then

                                Dim currentQty As Integer = Convert.ToInt32(existingCartRow.Cells("Quantity").Value)

                                If currentQty + inputQty <= stockQty Then

                                    currentQty += inputQty
                                    existingCartRow.Cells("Quantity").Value = currentQty

                                    ' Determine price type using product threshold
                                    Dim thresh As Integer = GetWholesaleThreshold(barcode, baseProductName)

                                    Dim finalPrice As Decimal =
                                    If(thresh > 0 AndAlso currentQty >= thresh, wholesalePrice, retailPrice)

                                    existingCartRow.Cells("UnitPrice").Value = finalPrice
                                    existingCartRow.Cells("Total").Value = currentQty * finalPrice
                                    existingCartRow.Cells("PriceType").Value =
                                    If(thresh > 0 AndAlso currentQty >= thresh, "Wholesale", "Retail")

                                    existingCartRow.Cells("ProductName").Value = productName
                                Else
                                    MessageBox.Show($"Maximum stock reached for '{baseProductName}'.",
                                            "Stock Limit",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information)
                                End If

                                cartRow = existingCartRow

                            Else
                                ' New row
                                Dim initialQty As Integer = inputQty
                                If initialQty > stockQty Then initialQty = stockQty

                                Dim initialThresh As Integer = GetWholesaleThreshold(barcode, baseProductName)

                                Dim finalPrice As Decimal =
                                If(initialThresh > 0 AndAlso initialQty >= initialThresh, wholesalePrice, retailPrice)

                                Dim initialType As String =
                                If(initialThresh > 0 AndAlso initialQty >= initialThresh, "Wholesale", "Retail")

                                dgvCart.Rows.Add(barcode, productName, initialQty, finalPrice, initialQty * finalPrice, initialType)
                                cartRow = dgvCart.Rows(dgvCart.Rows.Count - 1)
                            End If

                            ' === Highlight cart row temporarily ===
                            HighlightCartRowTemporary(cartRow)

                            ' === Recompute totals ===
                            ComputeCartTotal()

                            ' === UPDATE PRODUCT LIST ===
                            Dim existingPLRow = dgvProductList.Rows.Cast(Of DataGridViewRow)().
                        FirstOrDefault(Function(r) r.Cells("ProductName").Value.ToString() = baseProductName)

                            Dim totalInCart As Integer = dgvCart.Rows.Cast(Of DataGridViewRow)().
                        Where(Function(r) r.Cells("Barcode").Value.ToString() = barcode).
                        Sum(Function(r) Convert.ToInt32(r.Cells("Quantity").Value))

                            If existingPLRow IsNot Nothing Then
                                existingPLRow.Cells("EditQuantity").Value = totalInCart
                                existingPLRow.Cells("AvailableQuantity").Value = stockQty
                            Else
                                Dim newPLRowIndex As Integer = dgvProductList.Rows.Add(baseProductName, totalInCart, stockQty)
                                Dim plRow = dgvProductList.Rows(newPLRowIndex)

                                With plRow.Cells("EditQuantity").Style
                                    .BackColor = Color.LightGreen
                                    .SelectionBackColor = Color.LightGreen
                                    .ForeColor = Color.Black
                                    .SelectionForeColor = Color.Black
                                End With
                            End If

                        Else
                            MessageBox.Show("Product not found.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning)
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading product data: " & ex.Message)

        Finally
            panelquantity.Visible = False
            txtQuantity.Clear()
            txtBarcode.Clear()
            txtBarcode.Focus()
        End Try
    End Sub


    Private Sub CheckProductCount()
        If dgvCart.Rows.Count > 2 Then
            btnNewTransaction.Enabled = False
        Else
            btnNewTransaction.Enabled = True
        End If
    End Sub



    '=== COMPUTE CART ===
    Private Sub ComputeCartTotal()
        Dim subtotal As Decimal = 0
        Dim wholesaleTotal As Decimal = 0
        Dim pointsEarned As Integer = 0

        For Each row As DataGridViewRow In dgvCart.Rows
            Dim qty As Integer = CInt(row.Cells("Quantity").Value)
            Dim unitPrice As Decimal = CDec(row.Cells("UnitPrice").Value)

            subtotal += qty * unitPrice

            ' ✅ Compute wholesale equivalent for info display
            Dim productName As String = row.Cells("ProductName").Value.ToString()
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Dim sql As String = "SELECT WholesalePrice FROM product WHERE ProductName = @productName"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@productName", productName)
                    Dim wholesalePriceObj = cmd.ExecuteScalar()
                    If wholesalePriceObj IsNot Nothing AndAlso IsNumeric(wholesalePriceObj) Then
                        wholesaleTotal += qty * CDec(wholesalePriceObj)
                    End If
                End Using
            End Using
        Next

        ' === GET PRICE TO GAIN A POINT ===
        Dim priceToGainPoint As Decimal = 0

        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
            Dim sql As String = "SELECT PriceToGainPoint FROM loyaltydiscount ORDER BY id DESC LIMIT 1"
            Using cmd As New MySqlCommand(sql, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then priceToGainPoint = CDec(result)
            End Using
        End Using

        ' === COMPUTE POINTS ===
        If subtotal >= priceToGainPoint Then
            pointsEarned = 1
        Else
            pointsEarned = 0
        End If

        ' Discount logic: apply only for retail
        Dim discountPercent As Decimal = 0
        If rbRetail.Checked Then
            Dim selectedDiscount = TryCast(cmbDiscount.SelectedItem, DiscountItem)
            If selectedDiscount IsNot Nothing Then discountPercent = selectedDiscount.Value
        End If

        Dim discountAmount As Decimal = subtotal * (discountPercent / 100D)
        Dim totalAfterDiscount As Decimal = subtotal - discountAmount

        ' ===== VAT calculation (assume prices are VAT-inclusive) =====
        Dim vatAmount As Decimal = 0D
        Dim vatableSales As Decimal = 0D

        If totalAfterDiscount > 0D Then
            ' vatAmount = portion of totalAfterDiscount that is VAT
            vatAmount = Math.Round(totalAfterDiscount * (0.12D / 1.12D), 2)
            ' vatableSales is the price excluding VAT
            vatableSales = Math.Round(totalAfterDiscount - vatAmount, 2)
        Else
            vatAmount = 0D
            vatableSales = 0D
        End If

        lastVatAmount = vatAmount

        ' === Update Labels ===
        lblDiscount.Text = "₱ " & discountAmount.ToString("N2")
        lblVAT.Text = "₱ " & vatAmount.ToString("N2") & " (12%)"
        lblTotalAmount.Text = "₱ " & totalAfterDiscount.ToString("N2")
        lblVatableSales.Text = "₱ " & vatableSales.ToString("N2")
        totalamount.Text = "₱ " & totalAfterDiscount.ToString("N2")
        lblloyaltydiscount.Text = "₱ 0.00"
        lblSubtotal.Text = "₱ " & subtotal.ToString("N2")

        ' ✅ Show computed wholesale total
        lblWholesale.Text = "₱ " & wholesaleTotal.ToString("N2")

        txtBarcode.Focus()
    End Sub


    ' --- Only highlight Cart row temporarily ---
    Private Sub HighlightCartRowTemporary(row As DataGridViewRow)
        Dim originalColors As New Dictionary(Of Integer, Color)()

        For i As Integer = 0 To row.Cells.Count - 1
            originalColors.Add(i, row.Cells(i).Style.BackColor)
            row.Cells(i).Style.BackColor = Color.LightGreen
            row.Cells(i).Style.SelectionBackColor = Color.LightGreen
            row.Cells(i).Style.ForeColor = Color.Black
            row.Cells(i).Style.SelectionForeColor = Color.Black
        Next

        Dim t As New Timer()
        t.Interval = 3000
        AddHandler t.Tick, Sub(sender, e)
                               For i As Integer = 0 To row.Cells.Count - 1
                                   row.Cells(i).Style.BackColor = originalColors(i)
                                   row.Cells(i).Style.SelectionBackColor = originalColors(i)
                                   row.Cells(i).Style.ForeColor = Color.Black
                                   row.Cells(i).Style.SelectionForeColor = Color.Black
                               Next
                               t.Stop()
                               t.Dispose()
                           End Sub
        t.Start()
    End Sub



    '=================== DGV CART ==============================
    Private highlightedRowIndex As Integer = -1
    Private WithEvents unhighlightTimer As Timer

    ' Helper: extract base product name from display "ProductName (Description)" or "ProductName - Description"
    Private Function BaseNameFromDisplay(displayName As String) As String
        If String.IsNullOrWhiteSpace(displayName) Then Return String.Empty
        Dim txt As String = displayName.Trim()
        Dim idx As Integer = txt.IndexOf(" (", StringComparison.Ordinal)
        If idx = -1 Then idx = txt.IndexOf(" - ", StringComparison.Ordinal)
        If idx >= 0 Then
            Return txt.Substring(0, idx).Trim()
        End If
        Return txt
    End Function

    ' === Get wholesale threshold per product (read from product.MinimumWholesaleQuantity) ===
    Private Function GetWholesaleThreshold(barcode As String, Optional productName As String = "") As Integer
        Dim threshold As Integer = 0
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Dim sql As String = "SELECT MinimumWholesaleQuantity FROM product WHERE BarcodeID = @barcode LIMIT 1"
                If String.IsNullOrEmpty(barcode) AndAlso Not String.IsNullOrEmpty(productName) Then
                    sql = "SELECT MinimumWholesaleQuantity FROM product WHERE ProductName = @productName LIMIT 1"
                End If
                Using cmd As New MySqlCommand(sql, conn)
                    If sql.Contains("@barcode") Then
                        cmd.Parameters.AddWithValue("@barcode", barcode)
                    Else
                        cmd.Parameters.AddWithValue("@productName", productName)
                    End If
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Integer.TryParse(result.ToString(), threshold)
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' swallow to avoid breaking flow; default threshold 0 => retail
        End Try
        Return threshold
    End Function


    Private Sub dgvCart_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        ' Check if Edit column clicked
        If dgvCart.Columns(e.ColumnIndex).Name = "Edit" Then
            ' Safely read ProductName cell (avoid malformed null-coalescing syntax)
            Dim cellObj As Object = dgvCart.Rows(e.RowIndex).Cells("ProductName").Value
            Dim selectedDisplay As String = If(cellObj Is Nothing, String.Empty, cellObj.ToString()).Trim()

            ' Extract base product name (strip " (description)" or " - description" if present)
            Dim selectedBase As String = selectedDisplay
            Dim idx As Integer = selectedBase.IndexOf(" (", StringComparison.Ordinal)
            If idx = -1 Then idx = selectedBase.IndexOf(" - ", StringComparison.Ordinal)
            If idx >= 0 Then selectedBase = selectedBase.Substring(0, idx).Trim()

            ' Match case-insensitive against dgvProductList ProductName
            Dim foundIndex As Integer = -1
            For Each row As DataGridViewRow In dgvProductList.Rows
                If row.Cells("ProductName").Value IsNot Nothing Then
                    Dim plName As String = row.Cells("ProductName").Value.ToString().Trim()
                    If String.Compare(plName, selectedBase, StringComparison.OrdinalIgnoreCase) = 0 Then
                        foundIndex = row.Index
                        Exit For
                    End If
                End If
            Next

            If foundIndex >= 0 Then
                ' Clear previous highlight if any
                If highlightedRowIndex >= 0 AndAlso highlightedRowIndex < dgvProductList.Rows.Count Then
                    Dim prevRow = dgvProductList.Rows(highlightedRowIndex)
                    Dim prevCell = prevRow.Cells("EditQuantity")
                    prevCell.Style.BackColor = Color.LightGreen
                    prevCell.Style.SelectionBackColor = Color.LightGreen
                    prevCell.Style.ForeColor = Color.Black
                    prevCell.Style.SelectionForeColor = Color.Black
                End If

                ' Highlight target EditQuantity cell and begin edit
                Dim targetRow = dgvProductList.Rows(foundIndex)
                Dim editCell = targetRow.Cells("EditQuantity")
                editCell.Style.BackColor = Color.LightCoral
                editCell.Style.SelectionBackColor = Color.LightCoral
                editCell.Style.ForeColor = Color.Black
                editCell.Style.SelectionForeColor = Color.Black
                editCell.ReadOnly = False

                highlightedRowIndex = foundIndex

                dgvProductList.CurrentCell = editCell
                dgvProductList.BeginEdit(True)
                dgvProductList.FirstDisplayedScrollingRowIndex = foundIndex




            End If
        End If
    End Sub

    '=== SETUP DGV CART =====
    Private Sub SetupCartDGV()
        dgvCart.Columns.Clear()
        dgvCart.Rows.Clear()

        dgvCart.AutoGenerateColumns = False
        dgvCart.AllowUserToAddRows = False
        dgvCart.AllowUserToResizeRows = False

        ' Assuming your DataGridView is named dgvExample
        dgvCart.ReadOnly = True


        ' === Columns ===
        dgvCart.Columns.Add("Barcode", "Barcode") ' Column Name = "Barcode"
        dgvCart.Columns.Add("ProductName", "Product Name") ' Column Name = "ProductName"
        dgvCart.Columns.Add("Quantity", "Quantity") ' Column Name = "Quantity"
        dgvCart.Columns.Add("UnitPrice", "Unit Price") ' Column Name = "UnitPrice"
        dgvCart.Columns.Add("Total", "Total") ' Column Name = "Total"
        dgvCart.Columns("Total").Visible = False

        ' === Price Type ComboBox Column ===
        Dim priceTypeCol As New DataGridViewComboBoxColumn()
        priceTypeCol.Name = "PriceType" ' Column Name
        priceTypeCol.HeaderText = "Price Type"
        priceTypeCol.Items.AddRange("Retail", "Wholesale")
        priceTypeCol.Width = 100
        priceTypeCol.ValueType = GetType(String)
        dgvCart.Columns.Add(priceTypeCol)

        ' === Default value ===
        AddHandler dgvCart.DefaultValuesNeeded, Sub(sender As Object, e As DataGridViewRowEventArgs)
                                                    e.Row.Cells("PriceType").Value = "Retail"
                                                End Sub

        ' === Edit Column ===
        Dim imgEdit As New DataGridViewImageColumn()
        imgEdit.Name = "Edit" ' Column Name
        imgEdit.HeaderText = "Edit"
        imgEdit.Image = My.Resources.icons8_edit_mains
        imgEdit.ImageLayout = DataGridViewImageCellLayout.Zoom
        imgEdit.Width = 40
        imgEdit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCart.Columns.Add(imgEdit)

        ' === Set Column Widths ===
        dgvCart.Columns("Barcode").Width = 150
        dgvCart.Columns("ProductName").Width = 185
        dgvCart.Columns("Quantity").Width = 60
        dgvCart.Columns("UnitPrice").Width = 65

        ' === Header Styling ===
        With dgvCart
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 25
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            For Each col As DataGridViewColumn In .Columns
                col.Resizable = DataGridViewTriState.False
            Next
            .RowTemplate.Height = 25
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
        End With

        txtBarcode.Focus()
    End Sub

    Private Sub dgvCart_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellValueChanged
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

            Dim row As DataGridViewRow = dgvCart.Rows(e.RowIndex)
            Dim colName As String = dgvCart.Columns(e.ColumnIndex).Name

            ' 🔹 Update total when Quantity changes
            If colName = "Quantity" Then
                Dim qty As Integer = 0
                Integer.TryParse(row.Cells("Quantity").Value?.ToString(), qty)

                ' Update total
                Dim unitPrice As Decimal = 0
                Decimal.TryParse(row.Cells("UnitPrice").Value?.ToString(), unitPrice)
                row.Cells("Total").Value = (qty * unitPrice).ToString("0.00")

                ' Sync product list EditQuantity
                Dim baseName As String = BaseNameFromDisplay(row.Cells("ProductName").Value?.ToString())
                If Not String.IsNullOrEmpty(baseName) Then
                    For Each prodRow As DataGridViewRow In dgvProductList.Rows
                        If prodRow.Cells("ProductName").Value IsNot Nothing AndAlso
                       String.Compare(prodRow.Cells("ProductName").Value.ToString().Trim(), baseName, StringComparison.OrdinalIgnoreCase) = 0 Then
                            prodRow.Cells("EditQuantity").Value = qty
                            Exit For
                        End If
                    Next
                End If
            End If

            ' 🔹 Update UnitPrice if PriceType changed
            If colName = "PriceType" Then
                Dim priceType As String = row.Cells("PriceType").Value?.ToString()
                If String.IsNullOrEmpty(priceType) Then Exit Sub

                Dim barcode As String = If(row.Cells("Barcode").Value, "").ToString().Trim()
                Dim retailPrice As Decimal = 0D
                Dim wholesalePrice As Decimal = 0D

                Using conn As New MySqlConnection(connectionstring)
                    conn.Open()
                    Dim sql As String = "SELECT RetailPrice, WholesalePrice FROM product WHERE BarcodeID=@barcode LIMIT 1"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@barcode", barcode)
                        Using rdr As MySqlDataReader = cmd.ExecuteReader()
                            If rdr.Read() Then
                                Decimal.TryParse(rdr("RetailPrice").ToString(), retailPrice)
                                Decimal.TryParse(rdr("WholesalePrice").ToString(), wholesalePrice)
                            End If
                        End Using
                    End Using
                End Using

                Select Case priceType
                    Case "Wholesale"
                        If wholesalePrice > 0D Then row.Cells("UnitPrice").Value = wholesalePrice.ToString("0.00")
                    Case "Retail"
                        If retailPrice > 0D Then row.Cells("UnitPrice").Value = retailPrice.ToString("0.00")
                End Select

                ' Update total
                Dim qty As Integer = 0
                Integer.TryParse(row.Cells("Quantity").Value?.ToString(), qty)
                Dim unitPrice2 As Decimal = 0
                Decimal.TryParse(row.Cells("UnitPrice").Value?.ToString(), unitPrice2)
                row.Cells("Total").Value = (qty * unitPrice2).ToString("0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating cart: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ComputeCartTotal()
            txtBarcode.Focus()
        End Try
    End Sub



    ' --- AUTO-COMPUTE for Quantity, PriceType, UnitPrice changes ---
    Private Sub dgvCart_CellValueChanged_AutoCompute(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub
        Dim colName As String = dgvCart.Columns(e.ColumnIndex).Name

        If colName = "Quantity" OrElse colName = "UnitPrice" OrElse colName = "PriceType" Then
            computeTimer.Stop()
            computeTimer.Start()
            ComputeCartTotal()
        End If
    End Sub


    ' --- ENSURE COMBOBOX COMMIT + AUTO COMPUTE ---
    Private Sub dgvCart_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvCart.CurrentCellDirtyStateChanged
        If dgvCart.IsCurrentCellDirty Then
            dgvCart.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

        ComputeCartTotal()
        txtBarcode.Focus()
    End Sub


    '=================== DGV PRODUCT LIST ======================

    ' === Setup DGV Product list ===
    Private Sub SetupProductListGrid()
        ' === Clear old setup ===
        dgvProductList.Columns.Clear()
        dgvProductList.AutoGenerateColumns = False
        dgvProductList.AllowUserToAddRows = False
        dgvProductList.RowHeadersVisible = False
        dgvProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProductList.MultiSelect = False
        dgvProductList.ReadOnly = False
        dgvProductList.EditMode = DataGridViewEditMode.EditOnEnter

        ' === Product Name Column ===
        Dim colProductName As New DataGridViewTextBoxColumn()
        colProductName.HeaderText = "Product Name"
        colProductName.Name = "ProductName"
        colProductName.ReadOnly = True
        colProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvProductList.Columns.Add(colProductName)

        ' === Quantity Column (Editable TextBox) ===
        Dim colQuantity As New DataGridViewTextBoxColumn()
        colQuantity.HeaderText = "Edit Quantity"
        colQuantity.Name = "EditQuantity"
        colQuantity.Width = 120
        colQuantity.ReadOnly = True ' ⛔ default: not editable
        dgvProductList.Columns.Add(colQuantity)

        ' === Available Quantity Column ===
        Dim colAvailable As New DataGridViewTextBoxColumn()
        colAvailable.HeaderText = "Available Quantity"
        colAvailable.Name = "AvailableQuantity"
        colAvailable.ReadOnly = True
        colAvailable.Width = 120 ' fixed width
        colAvailable.HeaderCell.Style.WrapMode = DataGridViewTriState.False ' ✅ prevent text wrapping
        dgvProductList.Columns.Add(colAvailable)


        ' === Delete Column (Image Button) ===
        Dim colDelete As New DataGridViewImageColumn()
        colDelete.HeaderText = "Delete"
        colDelete.Name = "Delete"
        colDelete.Width = 60
        colDelete.ImageLayout = DataGridViewImageCellLayout.Zoom
        colDelete.Image = My.Resources.icons8_delete_mains
        colDelete.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' ✅ Center header text
        colDelete.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter  ' ✅ Center image in cell
        dgvProductList.Columns.Add(colDelete)


        ' === Styling ===
        With dgvProductList
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersHeight = 30
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .RowTemplate.Height = 30
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' === Disable resizing for columns and rows ===
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False

            ' === Selected Row Styling ===
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
        End With
    End Sub


    ' 1️⃣ Handle CellContentClick para sa Delete
    Private Sub dgvProductList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductList.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        If dgvProductList.Columns(e.ColumnIndex).Name = "Delete" Then
            Dim currentRow As DataGridViewRow = dgvProductList.Rows(e.RowIndex)
            Dim productName As String = If(currentRow.Cells("ProductName").Value, "").ToString().Trim()

            If MessageBox.Show("Are you sure you want to delete " & productName & "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                For i As Integer = dgvCart.Rows.Count - 1 To 0 Step -1
                    Dim cartDisplay As String = If(dgvCart.Rows(i).Cells("ProductName").Value, "").ToString()
                    Dim cartBase As String = BaseNameFromDisplay(cartDisplay)
                    If String.Compare(cartBase, productName, StringComparison.OrdinalIgnoreCase) = 0 Then
                        dgvCart.Rows.RemoveAt(i)
                    End If
                Next

                ComputeCartTotal()
                dgvProductList.Rows.RemoveAt(currentRow.Index)
            End If
        End If
    End Sub


    ' === Declare globally sa taas ng form ===
    Private WithEvents computeTimer As New Timer() With {.Interval = 1000}
    Private WithEvents qtyTypingTimer As New Timer() With {.Interval = 1000} ' 4 seconds delay

    Private Sub dgvProductList_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvProductList.EditingControlShowing
        ' Kapag nasa EditQuantity column tayo
        If dgvProductList.CurrentCell.ColumnIndex = dgvProductList.Columns("EditQuantity").Index Then
            Dim tb As TextBox = TryCast(e.Control, TextBox)
            If tb IsNot Nothing Then
                ' Alisin muna ang old handler para iwas duplicate triggers
                RemoveHandler tb.TextChanged, AddressOf EditQuantity_TextChanged
                ' I-attach ulit ang handler
                AddHandler tb.TextChanged, AddressOf EditQuantity_TextChanged
            End If
        End If

        ' Clear barcode textbox
        txtBarcode.Clear()
    End Sub

    Private Sub dgvProductList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductList.CellEndEdit
        ' Kapag natapos mag-type (CellEndEdit) balik sa LightGreen
        If e.RowIndex >= 0 AndAlso dgvProductList.Columns(e.ColumnIndex).Name = "EditQuantity" Then
            Dim editCell = dgvProductList.Rows(e.RowIndex).Cells("EditQuantity")
            editCell.Style.BackColor = Color.LightGreen
            editCell.Style.SelectionBackColor = Color.LightGreen
            editCell.Style.ForeColor = Color.Black
            editCell.Style.SelectionForeColor = Color.Black

            ' After editing, update dgvCart with the new quantity
            UpdateCartQuantity(e.RowIndex)
        End If
    End Sub

    ' Function to update the quantity in dgvCart based on changes in dgvProductList
    Private Sub UpdateCartQuantity(rowIndex As Integer)
        Dim productName As String = dgvProductList.Rows(rowIndex).Cells("ProductName").Value.ToString()
        Dim newQty As Integer = Convert.ToInt32(dgvProductList.Rows(rowIndex).Cells("EditQuantity").Value)

        If dgvCart Is Nothing OrElse dgvCart.Rows.Count = 0 Then Return

        For Each cartRow As DataGridViewRow In dgvCart.Rows
            If cartRow.IsNewRow Then Continue For
            Dim cartDisplay As String = If(cartRow.Cells("ProductName").Value, "").ToString()
            Dim cartBase As String = BaseNameFromDisplay(cartDisplay)

            If String.Compare(cartBase, productName, StringComparison.OrdinalIgnoreCase) = 0 Then
                cartRow.Cells("Quantity").Value = newQty
                If dgvCart.Columns.Contains("UnitPrice") AndAlso dgvCart.Columns.Contains("Total") Then
                    Dim unitPrice As Decimal = 0
                    Decimal.TryParse(cartRow.Cells("UnitPrice").Value?.ToString(), unitPrice)
                    cartRow.Cells("Total").Value = (unitPrice * newQty).ToString("N2")
                End If
                If dgvCart.Columns.Contains("PriceType") Then
                    Dim bc As String = If(cartRow.Cells("Barcode").Value, "").ToString().Trim()
                    Dim thresh As Integer = GetWholesaleThreshold(bc, productName)
                    cartRow.Cells("PriceType").Value = If(thresh > 0 AndAlso newQty >= thresh, "Wholesale", "Retail")
                End If
                Exit For
            End If
        Next
    End Sub
    Private Sub EditQuantity_TextChanged(sender As Object, e As EventArgs)
        Try
            ' Ensure dgvProductList and the current row are valid
            If dgvProductList Is Nothing OrElse dgvProductList.CurrentRow Is Nothing Then Exit Sub
            If dgvProductList.IsCurrentCellInEditMode = False Then Exit Sub
            If sender Is Nothing OrElse Not TypeOf sender Is TextBox Then Exit Sub

            Dim tb As TextBox = CType(sender, TextBox)
            Dim currentRow As DataGridViewRow = dgvProductList.CurrentRow
            If currentRow Is Nothing OrElse currentRow.Index < 0 Then Exit Sub

            ' === Ensure ProductName column exists ===
            If Not dgvProductList.Columns.Contains("ProductName") Then Exit Sub
            Dim productNameCell = currentRow.Cells("ProductName")
            If productNameCell Is Nothing Then Exit Sub


            Dim productName As String = productNameCell.Value.ToString()

            Dim qtyText As String = tb.Text.Trim()
            Dim newQty As Integer

            ' === VALIDATION 1: Numbers only ===
            If qtyText.Any(Function(c) Not Char.IsDigit(c)) Then
                tb.Text = New String(qtyText.Where(Function(c) Char.IsDigit(c)).ToArray())
                tb.SelectionStart = tb.Text.Length
                Exit Sub
            End If

            ' === VALIDATION 2: Numeric check ===
            If Integer.TryParse(qtyText, newQty) Then
                Dim availableQty As Integer = 0
                Dim stockValue As String = Nothing
                Dim stockColumnNames As String() = {"Quantity", "Stock", "AvailableQty", "AvailableQuantity"}

                ' 🔹 Find stock column dynamically
                For Each colName In stockColumnNames
                    If dgvProductList.Columns.Contains(colName) Then
                        stockValue = currentRow.Cells(colName).Value?.ToString()
                        Exit For
                    End If
                Next

                ' ✅ VALIDATION 3: Don’t exceed available stock
                If Not String.IsNullOrEmpty(stockValue) AndAlso Integer.TryParse(stockValue, availableQty) Then
                    If newQty > availableQty Then
                        MessageBox.Show($"You cannot enter more than the available stock ({availableQty}).", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tb.Text = availableQty.ToString() ' Reset to available stock if the input exceeds it
                        tb.SelectionStart = tb.Text.Length
                        Exit Sub
                    End If
                End If

                ' === Restart compute timer ===
                computeTimer.Stop()
                computeTimer.Start()

                ' === Restart 4-sec delay for typing ===
                qtyTypingTimer.Stop()
                qtyTypingTimer.Start()
            End If



        Catch ex As Exception
            MessageBox.Show("Error while updating quantity: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' === 🔹 Runs after 4 seconds of no typing ===
    Private Sub qtyTypingTimer_Tick(sender As Object, e As EventArgs) Handles qtyTypingTimer.Tick
        qtyTypingTimer.Stop()
        ComputeCartTotal()
        txtBarcode.Focus()
    End Sub

    Private Sub computeTimer_Tick(sender As Object, e As EventArgs) Handles computeTimer.Tick
        computeTimer.Stop()
        ComputeCartTotal()
    End Sub

    ' ============= SUB MODULE BUTTON =============

    ' =================== Select Product ===================

    'Public Sub AddProductFromSelect(barcode As String, productName As String, price As Decimal, qty As Integer)
    '    Dim foundInCart As Boolean = False
    '    Dim availableQty As Integer = 0
    '    Dim productDescription As String = String.Empty ' Variable for Description

    '    ' === 1️⃣ Get available stock and description from database ===
    '    Try
    '        Using conn As New MySqlConnection(connectionstring)
    '            conn.Open()
    '            Dim sql As String = "
    '        SELECT p.Description, i.Quantity 
    '        FROM product p 
    '        LEFT JOIN inventory i ON p.BarcodeID = i.BarcodeID 
    '        WHERE p.BarcodeID = @barcode"
    '            Using cmd As New MySqlCommand(sql, conn)
    '                cmd.Parameters.AddWithValue("@barcode", barcode)
    '                Using reader = cmd.ExecuteReader()
    '                    If reader.Read() Then
    '                        productDescription = reader("Description").ToString() ' Fetch description
    '                        availableQty = If(IsDBNull(reader("Quantity")), 0, Convert.ToInt32(reader("Quantity")))
    '                    End If
    '                End Using
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("Database error while checking stock: " & ex.Message)
    '        Exit Sub
    '    End Try

    '    ' === 2️⃣ Check if qty exceeds available stock ===
    '    If qty > availableQty Then
    '        MessageBox.Show($"Cannot add {qty} pcs. Only {availableQty} left in stock.",
    '                "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    ' === 3️⃣ Update OR Add to Cart without adding old qty ===
    '    For Each row As DataGridViewRow In dgvCart.Rows
    '        If row.Cells("Barcode").Value.ToString() = barcode Then
    '            ' If the product already exists in the cart, add the new quantity to the existing quantity
    '            Dim currentQty As Integer = Convert.ToInt32(row.Cells("Quantity").Value)
    '            row.Cells("Quantity").Value = currentQty + qty ' Add the new quantity to the current quantity
    '            row.Cells("Total").Value = (currentQty + qty) * price ' Recalculate the total price

    '            ' Update PriceType based on updated quantity
    '            If dgvCart.Columns.Contains("PriceType") Then
    '                row.Cells("PriceType").Value = If(currentQty + qty >= 50, "Wholesale", "Retail")
    '            End If

    '            foundInCart = True
    '            Exit For
    '        End If
    '    Next

    '    ' === Add new row if item not in cart ===
    '    If Not foundInCart Then
    '        ' Combine ProductName and Description
    '        Dim combinedProductName As String = productName & " " & productDescription
    '        Dim newRowIndex As Integer = dgvCart.Rows.Add(barcode, combinedProductName, qty, price, qty * price)
    '        Dim newRow As DataGridViewRow = dgvCart.Rows(newRowIndex)
    '        If dgvCart.Columns.Contains("PriceType") Then
    '            newRow.Cells("PriceType").Value = If(qty >= 50, "Wholesale", "Retail")
    '        End If
    '    End If

    '    ' === 4️⃣ Update ProductList DGV ===
    '    Dim existingPLRow = dgvProductList.Rows.Cast(Of DataGridViewRow)().
    'FirstOrDefault(Function(r) r.Cells("ProductName").Value.ToString() = productName)

    '    If existingPLRow IsNot Nothing Then
    '        ' If product already exists, update the quantity and available quantity
    '        Dim existingQty As Integer = Convert.ToInt32(existingPLRow.Cells("EditQuantity").Value)
    '        existingPLRow.Cells("EditQuantity").Value = existingQty + qty ' Add to the existing quantity
    '        existingPLRow.Cells("AvailableQuantity").Value = availableQty
    '    Else
    '        ' If product is not found, add new row to ProductList DGV
    '        Dim newRowIndex As Integer = dgvProductList.Rows.Add(productName, qty, availableQty)
    '        Dim newRow As DataGridViewRow = dgvProductList.Rows(newRowIndex)
    '        With newRow.Cells("EditQuantity").Style
    '            .BackColor = Color.LightGreen
    '            .SelectionBackColor = Color.LightGreen
    '            .ForeColor = Color.Black
    '            .SelectionForeColor = Color.Black
    '        End With
    '    End If

    '    ' === 5️⃣ Update total display ===
    '    Try
    '        totalamount.Text = "₱ " & dgvCart.Rows.Cast(Of DataGridViewRow)().
    '    Sum(Function(r) Convert.ToDecimal(r.Cells("Total").Value)).ToString("N2")
    '    Catch
    '    End Try

    '    ComputeCartTotal()
    'End Sub



    '===== ORGINAL =====
    Public Sub AddProductFromSelect(barcode As String, productName As String, price As Decimal, qty As Integer)
        Dim foundInCart As Boolean = False
        Dim availableQty As Integer = 0
        Dim description As String = ""

        ' === 1️⃣ Get available stock + description from database ===
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Dim sql As String = "
                SELECT i.Quantity, p.Description
                FROM inventory i
                LEFT JOIN product p ON p.BarcodeID = i.BarcodeID
                WHERE i.BarcodeID = @barcode
            "
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@barcode", barcode)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            availableQty = If(IsDBNull(reader("Quantity")), 0, Convert.ToInt32(reader("Quantity")))
                            description = If(IsDBNull(reader("Description")), "", reader("Description").ToString())
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error while checking stock: " & ex.Message)
            Exit Sub
        End Try

        ' === DISPLAY-ONLY ProductName ===
        Dim displayProductName As String =
        If(String.IsNullOrWhiteSpace(description),
           productName,
           productName & " (" & description & ")")

        ' === 2️⃣ Check if qty exceeds available stock ===
        If qty > availableQty Then
            MessageBox.Show($"Cannot add {qty} pcs. Only {availableQty} left in stock.",
                        "Stock Limit",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' === 3️⃣ Update OR Add to Cart ===
        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("Barcode").Value.ToString() = barcode Then

                Dim currentQty As Integer = Convert.ToInt32(row.Cells("Quantity").Value)
                row.Cells("Quantity").Value = currentQty + qty
                row.Cells("Total").Value = (currentQty + qty) * price

                ' display only
                row.Cells("ProductName").Value = displayProductName

                If dgvCart.Columns.Contains("PriceType") Then
                    Dim thresh As Integer = GetWholesaleThreshold(barcode, productName)
                    row.Cells("PriceType").Value = If(thresh > 0 AndAlso currentQty + qty >= thresh, "Wholesale", "Retail")
                End If

                foundInCart = True
                Exit For
            End If
        Next

        ' === Add new row if item not in cart ===
        If Not foundInCart Then
            Dim newRowIndex As Integer = dgvCart.Rows.Add(barcode, displayProductName, qty, price, qty * price)

            Dim newRow As DataGridViewRow = dgvCart.Rows(newRowIndex)
            If dgvCart.Columns.Contains("PriceType") Then
                Dim thresh As Integer = GetWholesaleThreshold(barcode, productName)
                newRow.Cells("PriceType").Value = If(thresh > 0 AndAlso qty >= thresh, "Wholesale", "Retail")
            End If
        End If

        ' === 4️⃣ Update ProductList DGV (BASE product name only) ===
        Dim existingPLRow = dgvProductList.Rows.Cast(Of DataGridViewRow)().
        FirstOrDefault(Function(r) r.Cells("ProductName").Value.ToString() = productName)

        If existingPLRow IsNot Nothing Then
            Dim currentQtyInPL As Integer = Convert.ToInt32(existingPLRow.Cells("EditQuantity").Value)
            existingPLRow.Cells("EditQuantity").Value = currentQtyInPL + qty
            existingPLRow.Cells("AvailableQuantity").Value = availableQty
        Else
            Dim newRowIndex As Integer = dgvProductList.Rows.Add(productName, qty, availableQty)
            Dim newRow As DataGridViewRow = dgvProductList.Rows(newRowIndex)
            With newRow.Cells("EditQuantity").Style
                .BackColor = Color.LightGreen
                .SelectionBackColor = Color.LightGreen
                .ForeColor = Color.Black
                .SelectionForeColor = Color.Black
            End With
        End If

        ' === 5️⃣ Update total display ===
        Try
            totalamount.Text = "₱ " & dgvCart.Rows.Cast(Of DataGridViewRow)().
            Sum(Function(r) Convert.ToDecimal(r.Cells("Total").Value)).ToString("N2")
        Catch
        End Try

        ComputeCartTotal()
    End Sub




    ' === BTN SELECT PRODUCT ===

    Private Sub btnSelectProduct_Click(sender As Object, e As EventArgs) Handles btnSelectProduct.Click
        Dim selectForm As New SelectProduct()
        selectForm.TopMost = True

        ' ✅ Connect event handler
        AddHandler selectForm.ProductSelected,
    Sub(barcode, name, price, qty)
        ' --- Hanapin ang product sa dgvProductList ---
        Dim existingRow As DataGridViewRow = dgvProductList.Rows.Cast(Of DataGridViewRow)() _
            .FirstOrDefault(Function(r) r.Cells("ProductName").Value IsNot Nothing AndAlso
                                        r.Cells("ProductName").Value.ToString().Trim().ToLower() = name.ToLower())

        If existingRow IsNot Nothing AndAlso dgvProductList.Columns.Contains("EditQuantity") Then
            ' Kasalukuyang edit quantity
            Dim currentEditQty As Integer = Convert.ToInt32(existingRow.Cells("EditQuantity").Value)

            ' Total qty kung idagdag
            Dim totalQty As Integer = currentEditQty + qty

            ' Kunin ang total stock (AvailableQuantity sa dgvProductList ay hindi babaguhin)
            Dim totalStock As Integer = Convert.ToInt32(existingRow.Cells("AvailableQuantity").Value)

            ' Validation bago idagdag
            If totalQty > totalStock Then
                MessageBox.Show($"Cannot add product '{name}'. Exceeds available stock ({totalStock}).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' --- Add product sa cart ---
            AddProductFromSelect(barcode, name, price, qty)

            ' --- Update EditQuantity lang ---
            existingRow.Cells("EditQuantity").Value = totalQty

            ' Highlight kung may change
            With existingRow.Cells("EditQuantity").Style
                .BackColor = Color.LightGreen
                .SelectionBackColor = Color.LightGreen
                .ForeColor = Color.Black
                .SelectionForeColor = Color.Black
            End With
        Else
            ' Kung wala sa dgvProductList, direkta na lang idagdag
            AddProductFromSelect(barcode, name, price, qty)
        End If
    End Sub

        selectForm.Show()
        txtBarcode.Focus()
    End Sub

    ' Event handler kapag may piniling product
    Private Sub OnProductSelected(barcode As String)
        ' Tawagin ang existing function mo para idagdag sa cart
        AddItemToCartDynamic(barcode)
    End Sub


    ' =================== New Transaction ===================
    Private Sub btnNewTransaction_Click(sender As Object, e As EventArgs) Handles btnNewTransaction.Click
        SetupProductListGrid()
        dgvCart.Rows.Clear()
        txtPayment.Clear()
        lblChange.Text = "₱ 0.00"
        rbRetail.Checked = True
        txtBarcode.Focus()
        GenerateNewNumbers()
        ComputeCartTotal()
        Checkoutshadowpanel.Visible = False

    End Sub

    ' =================== Add Membership ===================

    Private Sub btnAddMember_Click(sender As Object, e As EventArgs) Handles btnAddMember.Click
        ' 1️⃣ Open Access Permission first
        Using accessForm As New AccessPermission()
            Dim result As DialogResult = accessForm.ShowDialog()

            ' Only proceed if AccessPermission login was successful
            If result = DialogResult.OK AndAlso (SessionData.role = "Admin" OrElse SessionData.role = "SuperAdmin") Then

                ' Show welcome message
                MessageBox.Show("Login successful! You can now access Membership.", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 2️⃣ Check if Membership form is already open
                Dim membershipForm As Membership = Nothing
                For Each form As Form In Application.OpenForms
                    If TypeOf form Is Membership Then
                        membershipForm = CType(form, Membership)
                        Exit For
                    End If
                Next

                ' 3️⃣ Open or show the Membership form
                If membershipForm Is Nothing Then
                    membershipForm = New Membership()
                    membershipForm.ShowDialog()
                Else
                    membershipForm.Show()
                    membershipForm.BringToFront()
                End If

            Else
                MessageBox.Show("Access denied or login cancelled.", "Permission Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Using

        ' 4️⃣ Refocus barcode textbox after closing Membership or cancel
        txtBarcode.Focus()
    End Sub


    ' =================== Return Product ===================
    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Dim returnitem As New ReturnItem
        returnitem.Show()
        Checkoutshadowpanel.Visible = False

    End Sub

    ' =================== Returnrefund ===================
    Private Sub btnReturnrefund_Click(sender As Object, e As EventArgs) Handles btnReturnrefund.Click
        Dim returnrefund As New ReturnRefund
        returnrefund.ShowDialog()
        Checkoutshadowpanel.Visible = False

    End Sub

    ' =================== PointsEarned ===================

    Private pointsEarned As Integer = 0

    ' =================== Pay / Checkout ===================
    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click

        ' ============================
        ' 1. CHECK CART
        ' ============================
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("Cart is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Check for invalid quantity
        For Each row As DataGridViewRow In dgvCart.Rows
            If row.IsNewRow Then Continue For
            Dim qty As Integer
            If Not Integer.TryParse(row.Cells("Quantity").Value.ToString(), qty) OrElse qty <= 0 Then
                MessageBox.Show("One or more items have invalid or zero quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next

        ' ============================
        ' 2. PAYMENT VALIDATION
        ' ============================
        Dim payment As Decimal
        If Not Decimal.TryParse(txtPayment.Text.Replace("₱", "").Replace(",", "").Trim(), payment) OrElse payment <= 0 Then
            MessageBox.Show("Enter a valid payment amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim totalDue As Decimal
        If Not Decimal.TryParse(lblTotalAmount.Text.Replace("₱", "").Replace(",", "").Trim(), totalDue) Then
            MessageBox.Show("Invalid total amount format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim change As Decimal = payment - totalDue
        If change < 0 Then
            MessageBox.Show("Insufficient payment amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        lblChange.Text = "₱ " & change.ToString("N2")

        ' ============================
        ' 3. GET LOYALTY POINT SETTING
        ' ============================
        Dim priceToGainPoint As Decimal = 10

        Using connPts As New MySqlConnection(connectionstring)
            connPts.Open()
            Using cmdPts As New MySqlCommand("SELECT PriceToGainPoint FROM loyaltydiscount ORDER BY id DESC LIMIT 1", connPts)
                Dim result = cmdPts.ExecuteScalar()
                If result IsNot Nothing Then priceToGainPoint = CDec(result)
            End Using
        End Using


        ' ============================
        ' 4. START TRANSACTION
        ' ============================
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
            Using trans = conn.BeginTransaction()

                Try
                    ' ============================
                    ' INVENTORY + FIFO DEDUCTION
                    ' ============================
                    For Each row As DataGridViewRow In dgvCart.Rows
                        If row.IsNewRow Then Continue For

                        Dim barcodeID As String = row.Cells("Barcode").Value.ToString()
                        Dim qty As Integer = CInt(row.Cells("Quantity").Value)

                        ' Check stock
                        Dim stockQty As Integer = 0
                        Using cmdCheck As New MySqlCommand("SELECT Quantity FROM inventory WHERE BarcodeID=@barcode", conn, trans)
                            cmdCheck.Parameters.AddWithValue("@barcode", barcodeID)
                            stockQty = Convert.ToInt32(cmdCheck.ExecuteScalar())
                        End Using

                        If stockQty < qty Then
                            Throw New Exception($"Not enough stock for {row.Cells("ProductName").Value}.")
                        End If

                        ' FIFO deduction
                        Dim qtyToDeduct As Integer = qty
                        Dim fifoList As New List(Of Tuple(Of Integer, Integer))()

                        Using selectCmd As New MySqlCommand("
                        SELECT id, RemainingQty 
                        FROM deliveries 
                        WHERE BarcodeID=@barcode AND RemainingQty>0 
                        ORDER BY ReceiveDate ASC", conn, trans)

                            selectCmd.Parameters.AddWithValue("@barcode", barcodeID)
                            Using r = selectCmd.ExecuteReader()
                                While r.Read()
                                    fifoList.Add(Tuple.Create(r.GetInt32(0), r.GetInt32(1)))
                                End While
                            End Using
                        End Using

                        For Each batch In fifoList
                            If qtyToDeduct <= 0 Then Exit For
                            Dim deduct = Math.Min(batch.Item2, qtyToDeduct)

                            Using updateCmd As New MySqlCommand("
                            UPDATE deliveries 
                            SET RemainingQty = RemainingQty - @d 
                            WHERE id=@id", conn, trans)
                                updateCmd.Parameters.AddWithValue("@d", deduct)
                                updateCmd.Parameters.AddWithValue("@id", batch.Item1)
                                updateCmd.ExecuteNonQuery()
                            End Using

                            qtyToDeduct -= deduct
                        Next

                        ' Update inventory
                        Using updateInv As New MySqlCommand("
                        UPDATE inventory 
                        SET Quantity = Quantity - @q 
                        WHERE BarcodeID=@barcode", conn, trans)
                            updateInv.Parameters.AddWithValue("@q", qty)
                            updateInv.Parameters.AddWithValue("@barcode", barcodeID)
                            updateInv.ExecuteNonQuery()
                        End Using
                    Next


                    ' ============================
                    ' SAVE SALES HEADER
                    ' ============================
                    Dim transactionNumber = currentTransactionNo
                    Dim receiptNumber = currentInvoiceNo
                    Dim saleID As Integer

                    Using cmd As New MySqlCommand("
                    INSERT INTO sales 
                    (ReceiptNo, TransactionNo, TotalAmount, Payment, ChangeAmount, Discount, VAT, Cashier, SaleDate, LoyaltyDiscount)
                    VALUES
                    (@r, @t, @total, @pay, @chg, @disc, @vat, @cash, NOW(), @loyal);
                    SELECT LAST_INSERT_ID();", conn, trans)

                        cmd.Parameters.AddWithValue("@r", receiptNumber)
                        cmd.Parameters.AddWithValue("@t", transactionNumber)
                        cmd.Parameters.AddWithValue("@total", totalDue)
                        cmd.Parameters.AddWithValue("@pay", payment)
                        cmd.Parameters.AddWithValue("@chg", change)
                        cmd.Parameters.AddWithValue("@disc", CDec(lblDiscount.Text.Replace("₱", "").Trim()))
                        cmd.Parameters.AddWithValue("@vat", lastVatAmount)
                        cmd.Parameters.AddWithValue("@cash", lblCashier.Text)
                        cmd.Parameters.AddWithValue("@loyal", loyaltyDiscountAmount)

                        saleID = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using


                    ' ============================
                    ' SAVE SALES ITEMS
                    ' ============================
                    For Each row As DataGridViewRow In dgvCart.Rows
                        If row.IsNewRow Then Continue For

                        Dim qty As Integer = CInt(row.Cells("Quantity").Value)
                        Dim bc As String = If(row.Cells("Barcode").Value, "").ToString().Trim()
                        Dim prodNameForThreshold As String = BaseNameFromDisplay(If(row.Cells("ProductName").Value, "").ToString())
                        Dim thresh As Integer = GetWholesaleThreshold(bc, prodNameForThreshold)
                        Dim saleType As String = If(thresh > 0 AndAlso qty >= thresh, "Wholesale", "Retail")

                        Using cmd As New MySqlCommand("
                        INSERT INTO sales_items
                        (SaleID, BarcodeID, ProductName, Quantity, UnitPrice, TotalPrice, SaleType)
                        VALUES
                        (@sid, @b, @p, @q, @u, @t, @type)", conn, trans)

                            cmd.Parameters.AddWithValue("@sid", saleID)
                            cmd.Parameters.AddWithValue("@b", row.Cells("Barcode").Value.ToString())
                            cmd.Parameters.AddWithValue("@p", row.Cells("ProductName").Value.ToString())
                            cmd.Parameters.AddWithValue("@q", qty)
                            cmd.Parameters.AddWithValue("@u", CDec(row.Cells("UnitPrice").Value))
                            cmd.Parameters.AddWithValue("@t", CDec(row.Cells("Total").Value))
                            cmd.Parameters.AddWithValue("@type", saleType)

                            cmd.ExecuteNonQuery()
                        End Using
                    Next


                    ' ============================
                    ' LOYALTY POINTS (EARN)
                    ' Add points only as part of the checkout transaction so rollback cancels it
                    ' ============================
                    Dim pointsAdded As Boolean = False
                    If isMemberSelected AndAlso memberBarcode <> "" Then
                        If totalDue >= priceToGainPoint Then
                            Try
                                Using cmdPoints As New MySqlCommand("UPDATE membership SET Points = Points + 1 WHERE Barcode=@b", conn, trans)
                                    cmdPoints.Parameters.AddWithValue("@b", memberBarcode)
                                    cmdPoints.ExecuteNonQuery()
                                End Using
                                pointsAdded = True
                            Catch ex As Exception
                                ' Will be rolled back with transaction; notify cashier after transaction failure
                                pointsAdded = False
                            End Try
                        End If
                    End If


                    ' ============================
                    ' COMMIT
                    ' ============================
                    trans.Commit()

                    ' If points were added as part of the transaction, inform cashier with updated total
                    Try
                        If pointsAdded AndAlso Not String.IsNullOrEmpty(memberBarcode) Then
                            Using connInfo As New MySqlConnection(connectionstring)
                                connInfo.Open()
                                Using cmdGet As New MySqlCommand("SELECT Points FROM membership WHERE Barcode=@b LIMIT 1", connInfo)
                                    cmdGet.Parameters.AddWithValue("@b", memberBarcode)
                                    Dim ptsObj = cmdGet.ExecuteScalar()
                                    Dim updatedPts As Integer = 0
                                    If ptsObj IsNot Nothing AndAlso Not IsDBNull(ptsObj) Then
                                        Integer.TryParse(ptsObj.ToString(), updatedPts)
                                    End If
                                    MessageBox.Show($"Member earned 1 point. Current points: {updatedPts}", "Points Earned", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Using
                            End Using
                        End If
                    Catch
                        ' ignore messaging errors
                    End Try

                    ' Print receipt
                    GenerateReceipt(payment, change, receiptNumber, transactionNumber)

                    ' ========== RESET UI ==========
                    dgvCart.Rows.Clear()
                    lblTotalAmount.Text = "₱ 0.00"
                    lblDiscount.Text = "₱ 0.00"
                    lblVAT.Text = "₱ 0.00"
                    lblVatableSales.Text = "₱ 0.00"
                    lblChange.Text = "₱ 0.00"
                    lblWholesale.Text = "₱ 0.00"
                    lblloyaltydiscount.Text = "₱ 0.00"
                    lblSubtotal.Text = "₱ 0.00"

                    txtPayment.Clear()
                    txtBarcode.Clear()
                    txtBarcode.Focus()

                    Checkoutshadowpanel.Visible = False
                    Guna2Panel3.Visible = False

                    cmbDiscount.SelectedIndex = -1

                    ' Loyalty reset
                    isMemberSelected = False
                    isLoyaltyApplied = False
                    loyaltyDiscountAmount = 0D
                    loyaltyDiscountPercent = 0D
                    redeemablePointsRequired = 0
                    memberBarcode = ""

                    txtBarcodeCustomer.Clear()
                    lblCustomerName.Text = ""
                    lblCustomerPoints.Text = ""
                    picbarcode.Image = Nothing

                    btnredeempoints.Visible = False
                    btnCancel.Visible = False

                    ' Audit
                    LogAuditTrail(SessionData.role, SessionData.fullName, $"Checkout Transaction: {transactionNumber}")

                    ' Prepare new transaction
                    GenerateNewNumbers()
                    SetupProductListGrid()

                    MessageBox.Show("Checkout completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    trans.Rollback()
                    MessageBox.Show("Checkout failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End Using
        End Using

    End Sub


    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click

        ' === Check if cart is empty (no valid rows) ===
        If dgvCart.Rows.Count = 0 OrElse dgvCart.Rows.Cast(Of DataGridViewRow).All(Function(r) r.IsNewRow) Then
            MessageBox.Show("Cart is empty! Cannot proceed to payment.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

            ' Return focus to the barcode input
            txtBarcode.Focus()
            Exit Sub
        End If

        ' === If cart has items, show checkout panel ===
        Checkoutshadowpanel.Visible = True

        ' Use the same numbers from labels
        Dim transactionNumber As String = currentTransactionNo
        Dim receiptNumber As String = currentInvoiceNo

        ' Prepare payment input
        txtPayment.Clear()
        txtPayment.Focus()

        txtBarcodeCustomer.Clear()
        lblCustomerName.Text = " "
        lblCustomerPoints.Text = " "
        picbarcode.Image = Nothing
        btnCancel.Visible = False
        ' --- Remove dynamic initials label if it exists ---
        For i As Integer = customerpbcircle.Controls.Count - 1 To 0 Step -1
            Dim ctrl As Control = customerpbcircle.Controls(i)
            If TypeOf ctrl Is Label Then
                customerpbcircle.Controls.Remove(ctrl)
                ctrl.Dispose()
            End If
        Next
    End Sub

    '========= BTN CANCELED / RESET =========
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' ✅ Clear displayed member info
        txtBarcodeCustomer.Clear()
        lblCustomerName.Text = " "
        lblCustomerPoints.Text = " "
        picbarcode.Image = Nothing

        ' ✅ Reset loyalty-related variables
        memberBarcode = ""
        isMemberSelected = False
        isLoyaltyApplied = False
        loyaltyDiscountAmount = 0D
        loyaltyDiscountPercent = 0D
        redeemablePointsRequired = 0

        ' ✅ Hide redeem button
        btnredeempoints.Visible = False

        ' ✅ Reload (reset) Guna2Panel3
        Guna2Panel3.Visible = True   ' make sure it's visible
        Guna2Panel3.Controls.Clear() ' remove all old controls if any

        ' 👉 Option 1: If you want to repopulate it with default UI
        ' Example (you can customize this)
        Dim lblInfo As New Label()
        lblInfo.Text = "No member selected."
        lblInfo.Font = New Font("Segoe UI", 10, FontStyle.Italic)
        lblInfo.ForeColor = Color.Gray
        lblInfo.AutoSize = True
        lblInfo.Location = New Point(10, 10)
        Guna2Panel3.Controls.Add(lblInfo)

        ' ✅ Also remove any dynamic initials label inside customerpbcircle (customer avatar)
        If customerpbcircle IsNot Nothing Then
            For i As Integer = customerpbcircle.Controls.Count - 1 To 0 Step -1
                Dim ctrl As Control = customerpbcircle.Controls(i)
                If TypeOf ctrl Is Label Then
                    customerpbcircle.Controls.Remove(ctrl)
                    ctrl.Dispose()
                End If
            Next
            ' Reset fill color to default (safe-guard in Try)
            Try
                customerpbcircle.FillColor = ColorTranslator.FromHtml("#1D3A70")
            Catch
            End Try
        End If

        ' ✅ Return focus to the product barcode field
        txtBarcode.Focus()

        MessageBox.Show("Member selection has been cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        btnCancel.Visible = False
        cmbDiscount.Enabled = True
        ComputeCartTotal()
        UpdateChange()
    End Sub

    ' === Update Change ===
    Private Sub UpdateChange()
        Dim payment As Decimal = 0D
        Dim total As Decimal = 0D

        ' Linisin ang text values (tanggal ₱ at spaces)
        Decimal.TryParse(txtPayment.Text.Replace("₱", "").Trim(), payment)
        Decimal.TryParse(lblTotalAmount.Text.Replace("₱", "").Trim(), total)

        ' Compute sukli
        Dim change As Decimal = payment - total

        If change < 0 Then
            lblChange.Text = "₱ 0.00"
        Else
            lblChange.Text = "₱ " & change.ToString("N2")
        End If
    End Sub


    ' === Trigger auto update kapag may binago sa txtPayment ===
    Private Sub txtPayment_TextChanged(sender As Object, e As EventArgs) Handles txtPayment.TextChanged
        UpdateChange()
    End Sub

    ' === Btn For Loyal/ Memberships ====
    Private Sub btnLoyal_Click(sender As Object, e As EventArgs) Handles btnLoyal.Click

        ' === STEP 1: Access Permission ===
        Using accessForm As New AccessPermission()
            Dim accessResult As DialogResult = accessForm.ShowDialog()

            If accessResult <> DialogResult.OK OrElse (SessionData.role <> "Admin" AndAlso SessionData.role <> "SuperAdmin") Then
                MessageBox.Show("Access denied or login cancelled.", "Permission Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End Using

        ' === STEP 2: Show success message ===
        MessageBox.Show("Login successful! You can now access Membership.", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' === STEP 3: Open SelectMember (single instance) ===
        Dim frm As SelectMember = Application.OpenForms.OfType(Of SelectMember)().FirstOrDefault()
        If frm Is Nothing Then frm = New SelectMember()

        If frm.ShowDialog() = DialogResult.OK Then
            ' --- Save selected member info ---
            txtBarcodeCustomer.Text = frm.SelectedMemberBarcode
            lblCustomerName.Text = frm.SelectedMemberName
            lblCustomerPoints.Text = frm.SelectedMemberPoints
            LoadCustomerInitials(frm.SelectedMemberName)

            memberBarcode = frm.SelectedMemberBarcode
            isMemberSelected = True

            ' --- Generate barcode image ---
            If Not String.IsNullOrEmpty(frm.SelectedMemberBarcode) Then
                Dim writer As New ZXing.BarcodeWriter() With {
                .Format = ZXing.BarcodeFormat.CODE_128,
                .Options = New ZXing.Common.EncodingOptions With {.Width = 234, .Height = 80, .Margin = 0}
            }
                picbarcode.SizeMode = PictureBoxSizeMode.StretchImage
                picbarcode.Image = writer.Write(frm.SelectedMemberBarcode)
            Else
                picbarcode.Image = Nothing
            End If

            Try
                Using conn As MySqlConnection = Module1.Openconnection()
                    ' NOTE: Module1.Openconnection() returns an open connection — do NOT call conn.Open() here.

                    ' --- Prefer SelectMember's provided points (keeps POS consistent with SelectMember)
                    Dim memberPoints As Integer = 0
                    Dim rawPoints As String = If(frm.SelectedMemberPoints, "").Trim()
                    Integer.TryParse(rawPoints, memberPoints)

                    ' Fallback: read from DB by barcode if SelectMember did not return a valid number
                    If memberPoints = 0 AndAlso Not String.IsNullOrEmpty(frm.SelectedMemberBarcode) Then
                        Using getPoints As New MySqlCommand("SELECT Points FROM membership WHERE Barcode=@barcode LIMIT 1", conn)
                            getPoints.Parameters.AddWithValue("@barcode", frm.SelectedMemberBarcode)
                            Dim pointsResult = getPoints.ExecuteScalar()
                            If pointsResult IsNot Nothing Then Integer.TryParse(pointsResult.ToString(), memberPoints)
                        End Using
                    End If

                    ' Display points consistently in POS
                    lblCustomerPoints.Text = "" & memberPoints.ToString()

                    ' --- Read redeemable threshold from loyaltydiscount (DB authoritative)
                    Dim redeemablePoints As Integer = 0
                    Using cmdRedeem As New MySqlCommand("SELECT RedeemablePoints FROM loyaltydiscount ORDER BY id DESC LIMIT 1", conn)
                        Dim redeemResult = cmdRedeem.ExecuteScalar()
                        If redeemResult IsNot Nothing Then Integer.TryParse(redeemResult.ToString(), redeemablePoints)
                    End Using

                    ' --- Show Redeem button only when memberPoints is GREATER than redeemablePoints
                    '     (if redeemablePoints = 10 and member has 10 -> button will NOT show;
                    '      if member has 11+ -> button shows)
                    Dim canRedeem As Boolean = isMemberSelected AndAlso (memberPoints > redeemablePoints)

                    btnredeempoints.Visible = canRedeem
                    btnredeempoints.Enabled = canRedeem
                    btnCancel.Visible = canRedeem

                    ' keep other UI state
                    btnLoyal.Enabled = True
                    Guna2Panel3.Visible = isMemberSelected

                    Module1.ConnectionClose(conn)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' === IF NO MEMBER SELECTED: HIDE REDEEM & CANCEL ===
            btnredeempoints.Visible = False
            btnredeempoints.Enabled = False
            btnCancel.Visible = False
            btnCancel.Enabled = False
            Guna2Panel3.Visible = False
            memberBarcode = String.Empty
            isMemberSelected = False
            txtBarcodeCustomer.Text = ""
            lblCustomerName.Text = ""
            lblCustomerPoints.Text = "0"
            picbarcode.Image = Nothing
            ' --- Remove dynamic initials label from customerpbcircle ---
            For i As Integer = customerpbcircle.Controls.Count - 1 To 0 Step -1
                Dim ctrl As Control = customerpbcircle.Controls(i)
                If TypeOf ctrl Is Label Then
                    customerpbcircle.Controls.Remove(ctrl)
                    ctrl.Dispose()
                End If
            Next
        End If

        txtBarcode.Focus()


    End Sub


    ' === Btn Redeeem Points ====
    Private Sub btnRedeemPoints_Click(sender As Object, e As EventArgs) Handles btnredeempoints.Click
        Dim memberPoints As Integer
        Dim pointsText As String = lblCustomerPoints.Text.Replace("Current Points:", "").Trim()

        If Not Integer.TryParse(pointsText, memberPoints) Then
            MessageBox.Show("Invalid customer points.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Compute subtotal
        Dim subtotal As Decimal = dgvCart.Rows.Cast(Of DataGridViewRow)().Sum(Function(r) CDec(r.Cells("Total").Value))

        redeemablePointsRequired = 0
        loyaltyDiscountPercent = 0D

        ' --- Get discount details ---
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Dim query As String = "SELECT RedeemablePoints, Currentloyaltydiscount FROM loyaltydiscount ORDER BY id DESC LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            redeemablePointsRequired = reader.GetInt32("RedeemablePoints")
                            loyaltyDiscountPercent = reader.GetDecimal("Currentloyaltydiscount")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading loyalty discount: " & ex.Message)
            Exit Sub
        End Try

        ' --- Apply discount ---
        loyaltyDiscountAmount = subtotal * (loyaltyDiscountPercent / 100D)
        lblloyaltydiscount.Text = "₱ " & loyaltyDiscountAmount.ToString("N2")
        lblTotalAmount.Text = "₱ " & (subtotal - loyaltyDiscountAmount).ToString("N2")
        totalamount.Text = "₱ " & (subtotal - loyaltyDiscountAmount).ToString("N2")
        memberBarcode = txtBarcodeCustomer.Text.Trim()
        isLoyaltyApplied = True

        ' Note: Do NOT update membership points here. Points will be added as part of a successful checkout
        ' so that cancelling the transaction/redeem does not prematurely change member points.
        If String.IsNullOrEmpty(memberBarcode) Then
            MessageBox.Show("No member selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            ' Inform cashier that points will be applied at checkout when transaction completes
            MessageBox.Show("Loyalty discount applied. Member points will be updated when the transaction is completed.", "Loyalty", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        UpdateChange()
        cmbDiscount.Enabled = False
    End Sub


    'Private currentInvoice As String
    Private currentTransaction As String

    ' === Generate Receipts ====
    Public Sub GenerateReceipt(payment As Decimal, change As Decimal, currentInvoiceNo As String, currentTransactionNo As String)
        Dim fontBig As New Font("Courier New", 10, FontStyle.Bold)
        Dim fontSmall As New Font("Courier New", 6, FontStyle.Bold)
        Dim pd As New PrintDocument()

        ' --- Minimal Margins ---
        pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

        AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                     Dim g = e.Graphics
                                     Dim pageWidth As Integer = e.PageBounds.Width
                                     Dim y As Integer = 0

                                     ' ✅ NEW: uniform inner margin to balance left/right spacing
                                     Dim leftMargin As Integer = 10
                                     Dim rightMargin As Integer = 10

                                     ' effective printable width after margins
                                     Dim usableWidth As Integer = pageWidth - leftMargin - rightMargin

                                     Dim textShiftLeft As Integer = leftMargin
                                     Dim totalsShiftLeft As Integer = 40

                                     ' === LOGO ===
                                     Dim logo As Image = My.Resources.mainlogo_1
                                     Dim logoWidth As Integer = 75
                                     If logo IsNot Nothing Then
                                         Dim logoHeight As Integer = CInt(logo.Height * (logoWidth / logo.Width))
                                         Dim logoX As Integer = leftMargin + (usableWidth - logoWidth) \ 2
                                         g.DrawImage(logo, logoX, y, logoWidth, logoHeight)
                                         y += logoHeight + 5
                                     End If

                                     ' === ADDRESS ===
                                     Dim addressLines As String() = {"Road 11, Maguindanao Street", "Prk 3 Brgy.", "Taguig, Metro Manila"}
                                     For Each line As String In addressLines
                                         Dim lineX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(line, fontSmall).Width)) \ 2
                                         g.DrawString(line, fontSmall, Brushes.Black, lineX, y)
                                         y += fontSmall.GetHeight(g)
                                     Next

                                     ' === SEPARATOR LINE 1 ===
                                     Dim separator1 As String = "---------------------------------------------"
                                     Dim separatorX1 As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(separator1, fontSmall).Width)) \ 2
                                     g.DrawString(separator1, fontSmall, Brushes.Black, separatorX1, y)
                                     y += fontSmall.GetHeight(g)

                                     ' === SALE HEADER ===
                                     Dim saleHeader As String = "- SALE -"
                                     Dim saleHeaderX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(saleHeader, fontBig).Width)) \ 2
                                     g.DrawString(saleHeader, fontBig, Brushes.Black, saleHeaderX, y)
                                     y += fontBig.GetHeight(g)

                                     ' === CASHIER ===
                                     Dim cashierText As String = "Cashier: " & lblCashier.Text
                                     Dim cashierX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(cashierText, fontSmall).Width)) \ 2
                                     g.DrawString(cashierText, fontSmall, Brushes.Black, cashierX, y)
                                     y += fontSmall.GetHeight(g)

                                     Dim transText As String = "Transaction #: " & currentTransactionNo
                                     Dim transX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(transText, fontSmall).Width)) \ 2
                                     g.DrawString(transText, fontSmall, Brushes.Black, transX, y)
                                     y += fontSmall.GetHeight(g)


                                     ' === RECEIPT NUMBER (RCP #) ===
                                     Dim ReceiptText As String = "RCP #: " & currentTransactionNo
                                     Dim ReceiptX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(ReceiptText, fontSmall).Width)) \ 2
                                     g.DrawString(ReceiptText, fontSmall, Brushes.Black, ReceiptX, y)
                                     y += fontSmall.GetHeight(g)

                                     ' === SALE DATE ===
                                     Dim saleDate As String = "Sale Date : " & DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")
                                     Dim dateX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(saleDate, fontSmall).Width)) \ 2
                                     g.DrawString(saleDate, fontSmall, Brushes.Black, dateX, y)
                                     y += fontSmall.GetHeight(g)

                                     ' === SEPARATOR 2 ===
                                     Dim separator2 As String = "---------------------------------------------"
                                     Dim separatorX2 As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(separator2, fontSmall).Width)) \ 2
                                     g.DrawString(separator2, fontSmall, Brushes.Black, separatorX2, y)
                                     y += fontSmall.GetHeight(g)

                                     ' === ITEMS ===
                                     For Each row As DataGridViewRow In dgvCart.Rows
                                         If row.IsNewRow Then Continue For

                                         Dim name As String = row.Cells("ProductName").Value.ToString()
                                         Dim qty As Integer = CInt(row.Cells("Quantity").Value)
                                         Dim unitPrice As Decimal = CDec(row.Cells("UnitPrice").Value)
                                         Dim totalPrice As Decimal = CDec(row.Cells("Total").Value)
                                         Dim priceType As String = If(dgvCart.Columns.Contains("PriceType") AndAlso row.Cells("PriceType").Value IsNot Nothing, row.Cells("PriceType").Value.ToString(), "")

                                         Dim productLabel As String = name
                                         If priceType = "Wholesale" Then productLabel &= " (Wholesale)"

                                         ' Left align within margins
                                         g.DrawString(productLabel, fontSmall, Brushes.Black, leftMargin, y)
                                         y += fontSmall.GetHeight(g)

                                         Dim qtyPriceText As String = String.Format("{0}x @ ₱{1:N2} =", qty, unitPrice)
                                         g.DrawString(qtyPriceText, fontSmall, Brushes.Black, leftMargin, y)

                                         Dim totalX As Integer = leftMargin + usableWidth - CInt(g.MeasureString("₱" & totalPrice.ToString("N2"), fontSmall).Width)
                                         g.DrawString("₱" & totalPrice.ToString("N2"), fontSmall, Brushes.Black, totalX, y)
                                         y += fontSmall.GetHeight(g)

                                         Dim separatorItem As String = "---------------------------------------------"
                                         Dim separatorX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(separatorItem, fontSmall).Width)) \ 2
                                         g.DrawString(separatorItem, fontSmall, Brushes.Black, separatorX, y)
                                         y += fontSmall.GetHeight(g)
                                     Next

                                     ' === TOTALS ===
                                     Dim subTotal As Decimal = 0D
                                     For Each r As DataGridViewRow In dgvCart.Rows
                                         If Not r.IsNewRow Then
                                             subTotal += ToDecimalSafe(r.Cells("Total").Value)
                                         End If
                                     Next

                                     Dim discount As Decimal = ToDecimalSafe(lblDiscount.Text)
                                     Dim loyaltyDiscount As Decimal = ToDecimalSafe(lblloyaltydiscount.Text)
                                     Dim wholesaleDiscount As Decimal = ToDecimalSafe(lblWholesale.Text)
                                     Dim vat As Decimal = lastVatAmount
                                     Dim total As Decimal = ToDecimalSafe(lblTotalAmount.Text)
                                     Dim vatableSales As Decimal = subTotal


                                     Dim totalLines As New Dictionary(Of String, Decimal) From {
                                     {"SUBTOTAL", subTotal},
                                     {"DISCOUNT", discount},
                                     {"LOYALTY", loyaltyDiscount},
                                     {"VATABLE SALES", vatableSales},
                                     {"VAT (12%)", vat},
                                     {"TOTAL", total},
                                     {"PAYMENT", payment},
                                     {"CHANGE", change}
                                 }

                                     Dim maxAmountWidth As Integer = totalLines.Values.Max(Function(v) CInt(g.MeasureString("₱" & v.ToString("N2"), fontSmall).Width))

                                     For Each kvp In totalLines
                                         g.DrawString(kvp.Key & ":", fontSmall, Brushes.Black, leftMargin, y)
                                         Dim amountText As String = "₱" & kvp.Value.ToString("N2")
                                         Dim amountX As Integer = leftMargin + usableWidth - maxAmountWidth
                                         g.DrawString(amountText, fontSmall, Brushes.Black, amountX, y)
                                         y += fontSmall.GetHeight(g)
                                     Next

                                     ' === SEPARATOR 3 ===
                                     Dim separator3 As String = "---------------------------------------------"
                                     Dim separatorX3 As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(separator3, fontSmall).Width)) \ 2
                                     g.DrawString(separator3, fontSmall, Brushes.Black, separatorX3, y)
                                     y += fontSmall.GetHeight(g)

                                     ' === ITEMS COUNT ===
                                     Dim numItems As Integer = dgvCart.Rows.Cast(Of DataGridViewRow)().Sum(Function(r) CInt(r.Cells("Quantity").Value))
                                     Dim itemsText As String = $"#ITEMS PURCHASED: {numItems}"
                                     Dim itemsX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(itemsText, fontBig).Width)) \ 2
                                     g.DrawString(itemsText, fontBig, Brushes.Black, itemsX, y)
                                     y += fontBig.GetHeight(g)

                                     ' === SEPARATOR 4 ===
                                     Dim separator4 As String = "---------------------------------------------"
                                     Dim separatorX4 As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(separator4, fontSmall).Width)) \ 2
                                     g.DrawString(separator4, fontSmall, Brushes.Black, separatorX4, y)
                                     y += fontSmall.GetHeight(g)

                                     ' === CUSTOMER INFO ===
                                     Dim customerLabel As String = "Suki: " & lblCustomerName.Text
                                     Dim customerLabelX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(customerLabel, fontSmall).Width)) \ 2
                                     g.DrawString(customerLabel, fontSmall, Brushes.Black, customerLabelX, y)
                                     y += fontSmall.GetHeight(g)

                                     ' === CUSTOMER POINTS ===
                                     Dim updatedPoints As Integer = 0
                                     If Not String.IsNullOrEmpty(memberBarcode) Then
                                         Using conUpdate As New MySqlConnection(connectionstring)
                                             conUpdate.Open()
                                             Dim sqlGetPts As String = "SELECT Points FROM membership WHERE Barcode = @barcode LIMIT 1"
                                             Using cmdGetPts As New MySqlCommand(sqlGetPts, conUpdate)
                                                 cmdGetPts.Parameters.AddWithValue("@barcode", memberBarcode)
                                                 Dim result = cmdGetPts.ExecuteScalar()
                                                 If result IsNot Nothing Then
                                                     updatedPoints = CInt(result)
                                                 End If
                                             End Using
                                         End Using
                                     End If
                                     Dim customerPointsText As String = "Current Suki Points: " & updatedPoints.ToString()
                                     Dim customerPointsX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(customerPointsText, fontSmall).Width)) \ 2
                                     g.DrawString(customerPointsText, fontSmall, Brushes.Black, customerPointsX, y)
                                     y += fontSmall.GetHeight(g)

                                     ' === BARCODE ===
                                     If Not String.IsNullOrEmpty(txtBarcodeCustomer.Text) Then
                                         Dim writer As New ZXing.BarcodeWriter With {
                                         .Format = ZXing.BarcodeFormat.CODE_128,
                                         .Options = New ZXing.Common.EncodingOptions With {.Width = 120, .Height = 30, .Margin = 1}
                                     }
                                         Dim barcodeImage As Image = writer.Write(txtBarcodeCustomer.Text)
                                         Dim barcodeX As Integer = leftMargin + (usableWidth - barcodeImage.Width) \ 2
                                         g.DrawImage(barcodeImage, barcodeX, y, barcodeImage.Width, barcodeImage.Height)
                                         y += barcodeImage.Height
                                     End If

                                     ' === THANK YOU ===
                                     Dim thankYou As String = "THANK YOU FOR SHOPPING!"
                                     Dim thankYouX As Integer = leftMargin + (usableWidth - CInt(g.MeasureString(thankYou, fontSmall).Width)) \ 2
                                     g.DrawString(thankYou, fontSmall, Brushes.Black, thankYouX, y)
                                     y += fontSmall.GetHeight(g)

                                     e.HasMorePages = False
                                 End Sub


        ' === PRINT PREVIEW ===
        Dim preview As New PrintPreviewDialog() With {.Document = pd, .Width = 600, .Height = 800}
        preview.PrintPreviewControl.Zoom = 2.0
        preview.StartPosition = FormStartPosition.CenterScreen
        preview.ShowDialog()

        txtBarcode.Text = ""
        txtBarcode.Focus()
    End Sub

    Private Function ToDecimalSafe(value As Object) As Decimal
        If value Is Nothing Then Return 0D

        Dim s As String = value.ToString()

        ' Remove Peso sign & commas
        s = s.Replace("₱", "").Replace(",", "").Replace("-", "").Trim()

        Dim d As Decimal = 0D
        Decimal.TryParse(s, d)

        Return d
    End Function




    ' =================== Hold Transaction ===================
    Private Sub btnHoldTransaction_Click(sender As Object, e As EventArgs) Handles btnHoldTransaction.Click
        ' 1️⃣ Check if cart is empty
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("Cart is empty! Cannot hold the transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            ' Set focus to the txtBarcode textbox
            txtBarcode.Focus()

            Exit Sub
        End If


        ' 2️⃣ Get cashier
        Dim cashierName As String = lblCashier.Text.Trim()
        If String.IsNullOrWhiteSpace(cashierName) Then
            MessageBox.Show("Cannot hold transaction. No cashier is logged in.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 3️⃣ Use current transaction/invoice numbers
        ' If none, generate temporary ones
        If String.IsNullOrWhiteSpace(currentTransactionNo) Then GenerateNewNumbers()
        Dim heldTransactionNo As String = currentTransactionNo
        Dim heldInvoiceNo As String = currentInvoiceNo

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' Insert into hold_transactions
                Dim sqlHold As String = "INSERT INTO hold_transactions (TransactionNo, InvoiceNo, DateHeld, Cashier, SaleType, Discount, VAT) " &
                                    "VALUES (@transactionNo, @invoiceNo, @dateHeld, @cashier, @saleType, @discount, @vat)"
                Using cmd As New MySqlCommand(sqlHold, conn)
                    cmd.Parameters.AddWithValue("@transactionNo", heldTransactionNo)
                    cmd.Parameters.AddWithValue("@invoiceNo", heldInvoiceNo)
                    cmd.Parameters.AddWithValue("@dateHeld", DateTime.Now)
                    cmd.Parameters.AddWithValue("@cashier", cashierName)
                    cmd.Parameters.AddWithValue("@saleType", If(rbRetail.Checked, "Retail", "Wholesale"))
                    cmd.Parameters.AddWithValue("@discount", CDec(lblDiscount.Text.Replace("₱", "").Trim()))
                    cmd.Parameters.AddWithValue("@vat", lastVatAmount)
                    cmd.ExecuteNonQuery()
                End Using

                ' Get last inserted HoldID
                Dim holdID As Integer
                Using cmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn)
                    holdID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' Insert each cart item into hold_transaction_items
                For Each row As DataGridViewRow In dgvCart.Rows
                    If row.IsNewRow Then Continue For

                    Dim barcode As String = row.Cells("Barcode").Value?.ToString().Trim()
                    If String.IsNullOrWhiteSpace(barcode) Then Continue For

                    Dim qty As Integer = 0
                    Dim unitPrice As Decimal = 0
                    Dim total As Decimal = 0

                    Integer.TryParse(row.Cells("Quantity").Value?.ToString(), qty)
                    Decimal.TryParse(row.Cells("UnitPrice").Value?.ToString(), unitPrice)
                    Decimal.TryParse(row.Cells("Total").Value?.ToString(), total)

                    Dim sqlItem As String = "INSERT INTO hold_transaction_items (HoldID, TransactionNo, BarcodeID, ProductName, Quantity, UnitPrice, Total) " &
                                        "VALUES (@holdID, @transactionNo, @barcode, @productName, @qty, @unitPrice, @total)"
                    Using cmd As New MySqlCommand(sqlItem, conn)
                        cmd.Parameters.AddWithValue("@holdID", holdID)
                        cmd.Parameters.AddWithValue("@transactionNo", heldTransactionNo)
                        cmd.Parameters.AddWithValue("@barcode", barcode)
                        cmd.Parameters.AddWithValue("@productName", row.Cells("ProductName").Value)
                        cmd.Parameters.AddWithValue("@qty", qty)
                        cmd.Parameters.AddWithValue("@unitPrice", unitPrice)
                        cmd.Parameters.AddWithValue("@total", total)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End Using

            ' ✅ Clear cart and reset totals for a new transaction
            dgvCart.Rows.Clear()
            dgvProductList.Rows.Clear()
            lblDiscount.Text = "₱0.00"
            lblloyaltydiscount.Text = "₱0.00"
            lblVatableSales.Text = "₱0.00"
            lblVAT.Text = "₱0.00"
            lblTotalAmount.Text = "₱0.00"
            lblSubtotal.Text = "₱ 0.00"

            ' ✅ Generate new numbers for the next transaction
            GenerateNewNumbers()

            ' ✅ Inform the user (without invoice)
            MessageBox.Show("Transaction held successfully!" &
    vbCrLf & "Transaction No: " & heldTransactionNo,
    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


            ' ✅ Audit Trail including InvoiceNo
            LogAuditTrail(SessionData.role,
              SessionData.fullName,
              $"Held transaction: TransactionNo: {heldTransactionNo}")



            ' Focus on barcode box for new scan
            txtBarcode.Clear()
            txtBarcode.Focus()

        Catch ex As Exception
            MessageBox.Show("Error holding transaction: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =================== Retrieve Held Transaction ===================
    Private Sub btnRetrieveHold_Click(sender As Object, e As EventArgs) Handles btnRetrieveHold.Click
        Try
            ' ✅ Check if current cart has items
            If dgvCart.Rows.Count > 0 Then
                MessageBox.Show("Cannot retrieve a held transaction while the cart has items. Please clear the cart first.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Exit Sub
            End If

            ' Open HoldTransactions form passing this POS form reference
            Dim holdForm As New HoldTransactions(Me)
            holdForm.ShowDialog()

            ' Focus back on barcode input after retrieving
            txtBarcode.Focus()

            ' ✅ Do NOT call GenerateNewNumbers() here because we are restoring a held transaction
        Catch ex As Exception
            MessageBox.Show("Error retrieving held transaction: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' =================== Load Held Items Back to POS ===================
    Public Sub LoadHeldItems(items As DataTable, transactionNo As String)
        Try
            ' ================== 0️⃣ Delete old held items (older than today) ==================
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Dim deleteCmd As New MySqlCommand("DELETE FROM hold_transactions WHERE Dateheld < @today", conn)
                deleteCmd.Parameters.AddWithValue("@today", DateTime.Today)
                deleteCmd.ExecuteNonQuery()
            End Using

            ' ================== 1️⃣ Save current selection ==================
            Dim selectedRowIndex As Integer = -1
            Dim selectedColIndex As Integer = -1
            If dgvProductList.CurrentCell IsNot Nothing Then
                selectedRowIndex = dgvProductList.CurrentCell.RowIndex
                selectedColIndex = dgvProductList.CurrentCell.ColumnIndex
            End If

            ' ================== 2️⃣ Clear current cart ==================
            dgvCart.Rows.Clear()

            ' ================== 3️⃣ Reset EditQuantity ==================
            If dgvProductList.Columns.Contains("EditQuantity") Then
                For Each row As DataGridViewRow In dgvProductList.Rows
                    row.Cells("EditQuantity").Value = 0
                    With row.Cells("EditQuantity").Style
                        .BackColor = Color.White
                        .SelectionBackColor = Color.White
                        .ForeColor = Color.Black
                        .SelectionForeColor = Color.Black
                    End With
                Next
            End If

            ' ================== 4️⃣ Load inventory quantities ==================
            Dim inventoryByBarcode As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
            Dim inventoryByName As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)

            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Dim sql As String = "SELECT BarcodeID, ProductName, Quantity FROM inventory"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim bc As String = If(IsDBNull(reader("BarcodeID")), "", reader("BarcodeID").ToString().Trim())
                            Dim pName As String = If(IsDBNull(reader("ProductName")), "", reader("ProductName").ToString().Trim())
                            Dim qty As Integer = If(IsDBNull(reader("Quantity")), 0, Convert.ToInt32(reader("Quantity")))

                            If Not String.IsNullOrEmpty(bc) Then inventoryByBarcode(bc) = qty
                            If Not String.IsNullOrEmpty(pName) Then inventoryByName(pName.ToLower()) = qty
                        End While
                    End Using
                End Using
            End Using

            ' ================== 5️⃣ Load held items into cart ==================
            Dim heldItemNames As New HashSet(Of String) ' track names for AvailableQuantity update

            For Each row As DataRow In items.Rows
                Dim displayName As String = row("ProductName").ToString().Trim()
                Dim baseName As String = BaseNameFromDisplay(displayName)

                ' Parse quantity and prices safely
                Dim heldQty As Integer = 0
                Integer.TryParse(row("Quantity").ToString().Replace("₱", "").Replace(",", ""), heldQty)

                Dim unitPrice As Decimal = 0D
                Decimal.TryParse(row("UnitPrice").ToString().Replace("₱", "").Replace(",", ""), unitPrice)

                Dim total As Decimal = unitPrice * heldQty

                Dim barcode As String = If(items.Columns.Contains("BarcodeID") AndAlso row("BarcodeID") IsNot Nothing, row("BarcodeID").ToString().Trim(), "")

                heldItemNames.Add(baseName.ToLower())

                ' Determine sale type
                Dim thresh As Integer = GetWholesaleThreshold(barcode, baseName)
                Dim saleType As String = If(thresh > 0 AndAlso heldQty >= thresh, "Wholesale", "Retail")

                ' --- Add to dgvCart ---
                Dim cartRowIndex As Integer = dgvCart.Rows.Add(barcode, displayName, heldQty, unitPrice, total)
                If dgvCart.Columns.Contains("EditQuantity") Then
                    dgvCart.Rows(cartRowIndex).Cells("EditQuantity").Value = heldQty
                End If
                If dgvCart.Columns.Contains("PriceType") Then
                    dgvCart.Rows(cartRowIndex).Cells("PriceType").Value = saleType
                End If

                ' --- Update product list ---
                Dim productRow As DataGridViewRow = dgvProductList.Rows.Cast(Of DataGridViewRow)().
                FirstOrDefault(Function(r)
                                   If r.Cells("ProductName").Value Is Nothing Then Return False
                                   Return BaseNameFromDisplay(r.Cells("ProductName").Value.ToString()).ToLower() = baseName.ToLower()
                               End Function)

                ' Determine available quantity
                Dim availableQty As Integer = 0
                If Not String.IsNullOrEmpty(barcode) AndAlso inventoryByBarcode.ContainsKey(barcode) Then
                    availableQty = inventoryByBarcode(barcode)
                ElseIf inventoryByName.ContainsKey(baseName.ToLower()) Then
                    availableQty = inventoryByName(baseName.ToLower())
                End If

                If productRow IsNot Nothing Then
                    ' Set EditQuantity to held quantity
                    If dgvProductList.Columns.Contains("EditQuantity") Then productRow.Cells("EditQuantity").Value = heldQty
                    If dgvProductList.Columns.Contains("AvailableQuantity") Then productRow.Cells("AvailableQuantity").Value = availableQty
                    With productRow.Cells("EditQuantity").Style
                        .BackColor = Color.LightGreen
                        .SelectionBackColor = Color.LightGreen
                        .ForeColor = Color.Black
                        .SelectionForeColor = Color.Black
                    End With
                Else
                    ' Add new row if not exists
                    Dim newRowIndex As Integer = dgvProductList.Rows.Add(baseName, heldQty, availableQty)
                    Dim newRow As DataGridViewRow = dgvProductList.Rows(newRowIndex)
                    If dgvProductList.Columns.Contains("EditQuantity") Then
                        With newRow.Cells("EditQuantity").Style
                            .BackColor = Color.LightGreen
                            .SelectionBackColor = Color.LightGreen
                            .ForeColor = Color.Black
                            .SelectionForeColor = Color.Black
                        End With
                    End If
                End If
            Next

            ' ================== 6️⃣ Update AvailableQuantity for other products ==================
            If dgvProductList.Columns.Contains("ProductName") AndAlso dgvProductList.Columns.Contains("AvailableQuantity") Then
                For Each prodRow As DataGridViewRow In dgvProductList.Rows
                    Dim prodName As String = prodRow.Cells("ProductName").Value?.ToString().Trim().ToLower()
                    If Not String.IsNullOrEmpty(prodName) AndAlso inventoryByName.ContainsKey(prodName) AndAlso Not heldItemNames.Contains(prodName) Then
                        prodRow.Cells("AvailableQuantity").Value = inventoryByName(prodName)
                    End If
                Next
            End If

            ' ================== 7️⃣ Restore Transaction Number ==================
            lblTransactionNo.Text = "Transaction Number : " & transactionNo
            currentTransactionNo = transactionNo

            ' ================== 8️⃣ Recompute totals ==================
            ComputeCartTotal()

            ' ================== 9️⃣ Restore selection ==================
            If selectedRowIndex >= 0 AndAlso selectedRowIndex < dgvProductList.Rows.Count AndAlso selectedColIndex >= 0 Then
                dgvProductList.CurrentCell = dgvProductList.Rows(selectedRowIndex).Cells(selectedColIndex)
            End If

            ' ================== 🔟 Focus on barcode ==================
            txtBarcode.Focus()

        Catch ex As Exception
            MessageBox.Show("Error loading held items: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' =================== PICTURE BOX SECTIONS ===================
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        txtBarcode.Focus()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Checkoutshadowpanel.Visible = False
        txtBarcode.Focus()
        Guna2Panel3.Visible = False
        txtPayment.Clear()
        btnredeempoints.Visible = False

        cmbDiscount.SelectedIndex = -1

        txtBarcodeCustomer.Clear()
        lblCustomerName.Text = " "
        lblCustomerPoints.Text = " "
        picbarcode.Image = Nothing
        btnCancel.Visible = False
        ' --- Remove dynamic initials label if it exists ---
        For i As Integer = customerpbcircle.Controls.Count - 1 To 0 Step -1
            Dim ctrl As Control = customerpbcircle.Controls(i)
            If TypeOf ctrl Is Label Then
                customerpbcircle.Controls.Remove(ctrl)
                ctrl.Dispose()
            End If
        Next



    End Sub

    '=================== CURVE PANEL SECTION ===================

    Private Sub Guna2Panel3_Paint(sender As Object, e As PaintEventArgs)
        ApplyRoundedCorners(Guna2Panel3, 20)
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles lblRevenue.Paint
        ApplyRoundedCorners(lblRevenue, 20)
    End Sub

    Private Sub Guna2Panel5_Paint(sender As Object, e As PaintEventArgs)
        'ApplyRoundedCorners(Guna2Panel5, 20)
    End Sub

    Private Sub Guna2Panel4_Paint(sender As Object, e As PaintEventArgs)
        ApplyRoundedCorners(Guna2Panel4, 20)
    End Sub

    ' === HELPER FUNCTION ===
    Private Sub SetPaymentAmount(amount As Decimal)
        Dim currentAmount As Decimal = 0
        Decimal.TryParse(txtPayment.Text, currentAmount)

        txtPayment.Text = (currentAmount + amount).ToString("0")
    End Sub

    Private Sub btn50_Click(sender As Object, e As EventArgs) Handles btn50.Click
        SetPaymentAmount(50)
        UpdateChange()
    End Sub

    Private Sub btn100_Click(sender As Object, e As EventArgs) Handles btn100.Click
        SetPaymentAmount(100)
        UpdateChange()
    End Sub

    Private Sub btn500_Click(sender As Object, e As EventArgs) Handles btn500.Click
        SetPaymentAmount(500)
        UpdateChange()
    End Sub

    Private Sub btn1000_Click(sender As Object, e As EventArgs) Handles btn1000.Click
        SetPaymentAmount(1000)
        UpdateChange()
    End Sub


    ' === NUMBER BUTTONS ===
    Private Sub AppendToPayment(value As String)
        ' Append value to txtPayment if the panel is visible
        txtPayment.Text &= value
        UpdateChange()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        AppendToPayment("1")
        UpdateChange()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        AppendToPayment("2")
        UpdateChange()
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        AppendToPayment("3")
        UpdateChange()

    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        AppendToPayment("4")
        UpdateChange()
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        AppendToPayment("5")
        UpdateChange()
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        AppendToPayment("6")
        UpdateChange()
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        AppendToPayment("7")
        UpdateChange()
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        AppendToPayment("8")
        UpdateChange()
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        AppendToPayment("9")
        UpdateChange()
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        AppendToPayment("0")
        UpdateChange()
    End Sub

    Private Sub btn00_Click(sender As Object, e As EventArgs) Handles btn00.Click
        AppendToPayment("00")
        UpdateChange()
    End Sub

    Private Sub btndot_Click(sender As Object, e As EventArgs) Handles btndot.Click
        ' Avoid adding multiple dots
        If Not txtPayment.Text.Contains(".") Then
            AppendToPayment(".")
        End If
        UpdateChange()
    End Sub


    '=================== KEYPRESS SECTION ===================

    ' === txtBarcode (13 digits max, numbers only) ===
    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        ' Allow only digits and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If

        ' Limit to 13 digits
        If Char.IsDigit(e.KeyChar) AndAlso txtBarcode.Text.Length >= 13 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        ' Allow only numbers and Backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    '' === txtPayment (numbers + decimal allowed) ===
    Private Sub txtPayment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPayment.KeyPress
        ' Allow digits, backspace, and one decimal point
        If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ChrW(Keys.Back) OrElse e.KeyChar = ".") Then
            e.Handled = True
        End If

        ' Only allow one decimal point
        If e.KeyChar = "." AndAlso txtPayment.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Logout Confirmation") = MsgBoxResult.Yes Then
            Dim login As New Login
            login.Show()
            Me.Hide()
        End If

        LogHistory.LogAction(SessionData.role, SessionData.fullName, "Logged out")
    End Sub


    ' === FormClosing ===

    Private Sub POS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            ' Only proceed if role is not null or empty
            If Not String.IsNullOrEmpty(SessionData.role) AndAlso SessionData.role.ToLower() = "cashier" Then
                Application.Exit() ' Exit entire application safely
            End If
        Catch ex As Exception
            ' Optional: log or show error instead of crashing
            MessageBox.Show("Error during form closing: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' === Form1 Load ===
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === DEFAULT COLORS & IMAGES ===
        btnLogout.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnLogout.ForeColor = Color.White
        btnLogout.Image = My.Resources.iconmain12 ' normal icon

        'btnSort.FillColor = ColorTranslator.FromHtml("#1D3A70")
        'btnSort.ForeColor = Color.White
        'btnSort.Image = My.Resources.icons8_alphabetical_sorting_normal ' normal icon


        ' === HOVER EFFECTS FOR btnAddnewUsar ===
        AddHandler btnLogout.MouseEnter, Sub()
                                             btnLogout.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                             btnLogout.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                             btnLogout.Image = My.Resources.icons8_main12_1 ' hover icon
                                         End Sub

        AddHandler btnLogout.MouseLeave, Sub()
                                             btnLogout.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                             btnLogout.ForeColor = Color.White
                                             btnLogout.Image = My.Resources.iconmain12
                                         End Sub


        '' === HOVER EFFECTS FOR btnSort ===
        'AddHandler btnSort.MouseEnter, Sub()
        '                                   btnSort.FillColor = ColorTranslator.FromHtml("#FFD93D")
        '                                   btnSort.ForeColor = ColorTranslator.FromHtml("#0B2447")
        '                                   btnSort.Image = My.Resources.icons8_alphabetical_sorting_30_hindi ' hover icon
        '                               End Sub

        'AddHandler btnSort.MouseLeave, Sub()
        '                                   btnSort.FillColor = ColorTranslator.FromHtml("#1D3A70")
        '                                   btnSort.ForeColor = Color.White
        '                                   btnSort.Image = My.Resources.icons8_alphabetical_sorting_normal ' normal icon
        '                               End Sub


        ' === OPTIONAL: CENTER THE FORM ON SCREEN ===
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    ' === LogAuditTrail ===

    Private Sub LogAuditTrail(ByVal role As String, ByVal fullName As String, ByVal action As String)
        Try
            Using connection As New MySqlConnection(connectionstring)
                connection.Open()
                Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) " &
                                      "VALUES (@Role, @FullName, @Action, @Form, @Date)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@Action", action)
                    cmd.Parameters.AddWithValue("@Form", "POS")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '========= FOR ALT F4 FUNCTION =========
    Private Sub login_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt AndAlso e.KeyCode = Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Alt Or Keys.F4) Then
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' Flag para malaman kung may active transaction
    Private hasActiveTransaction As Boolean = False

    ' -----------------------------
    ' Form KeyDown: single key shortcuts
    ' -----------------------------
    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.H ' N = New Transaction
                HandleTransactionButton(btnHoldTransaction)

            Case Keys.R ' R = Return / Refund
                HandleTransactionButton(btnReturnrefund)

            Case Keys.G ' T = Retrieve Hold (example)
                HandleTransactionButton(btnRetrieveHold)

            Case Keys.N ' T = Retrieve Hold (example)
                HandleTransactionButton(btnNewTransaction)

            Case Keys.P ' P = Payment
                HandleTransactionButton(btnPay)
        End Select
    End Sub

    ' -----------------------------
    ' Trigger button na may sound + highlight
    ' -----------------------------
    Private Sub TriggerButton(btn As Guna.UI2.WinForms.Guna2Button)
        btn.PerformClick()                        ' Execute button click
        System.Media.SystemSounds.Beep.Play()     ' Sound feedback

        ' Highlight button
        Dim originalColor As Color = btn.FillColor
        btn.FillColor = ColorTranslator.FromHtml("#FFD93D")


        ' Reset highlight after 0.5 second
        Dim t As New Timer With {.Interval = 500, .Enabled = True}
        AddHandler t.Tick, Sub()
                               btn.FillColor = originalColor
                               t.Stop()
                               t.Dispose()
                           End Sub
    End Sub

    ' -----------------------------
    ' Trigger button lang kung may active transaction
    ' -----------------------------
    Private Sub HandleTransactionButton(btn As Guna.UI2.WinForms.Guna2Button)
        ' List of buttons that require active transaction
        Dim requiresTransaction As Boolean = (btn Is btnNewTransaction OrElse btn Is btnPay OrElse btn Is btnHoldTransaction OrElse btn Is btnReturnrefund OrElse btn Is btnRetrieveHold)

        TriggerButton(btn)
    End Sub


End Class

