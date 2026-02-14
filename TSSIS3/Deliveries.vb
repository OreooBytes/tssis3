Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient


Public Class Deliveries

    ' === Variables ===
    Private editingRowIndex As Integer = -1
    Public Property LoggedInUser As String
    Public Property LoggedInFullName As String



    ' === Form Load ===
    Private Sub Deliveries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- Database connection test ---
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
        End Using

        ' --- Load suppliers ---
        LoadSuppliers()

        ' --- Setup DataGridView ---
        SetupPendingList()


        ' ✅ Set dtpReceiveDate to today’s date
        dtpReceiveDate.Value = Date.Today

        ' ✅ Disable user interaction (cannot change date)
        dtpReceiveDate.Enabled = True
        dtpReceiveDate.Format = DateTimePickerFormat.Custom
        dtpReceiveDate.CustomFormat = "MMMM dd, yyyy"

        ' ✅ Prevent clicking or typing
        AddHandler dtpReceiveDate.KeyDown, AddressOf DisableDatePickerInteraction
        AddHandler dtpReceiveDate.MouseDown, AddressOf DisableDatePickerInteraction


        ' --- Set logged-in user's full name ---
        txtrecievedby.Text = LoggedInFullName
        txtrecievedby.Enabled = False

        ' --- Enable input fields for next entry ---
        txtProductname.Enabled = False
        txtUnitPrice.Enabled = False
        txtWholesaleprice.Enabled = False


        ' --- Style panels ---
        BackColor = ColorTranslator.FromHtml("#0B2447")
        dtpReceiveDate.FillColor = ColorTranslator.FromHtml("#1D3A70")
        dtpReceiveDate.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        dtpReceiveDate.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' I-disable ang date picker para hindi ma-edit
        dtpReceiveDate.Enabled = False
        ' Optional: kung gusto mo hindi na rin lumabas yung calendar
        dtpReceiveDate.ShowUpDown = True

        dtpExpirationDate.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        dtpExpirationDate.FillColor = ColorTranslator.FromHtml("#1D3A70")

        Guna2Button1.FillColor = ColorTranslator.FromHtml("#FFD93D")
        Guna2Button1.ForeColor = ColorTranslator.FromHtml("#0B2447")
        Guna2Button1.Font = New Font("Outfit", 12, FontStyle.Bold)



        lblTittle.ForeColor = ColorTranslator.FromHtml("#0B2447")

        lblBatchNo.Font = New Font("Outfit", 7.5, FontStyle.Bold)
        lblTransactionNo.Font = New Font("Outfit", 7.5, FontStyle.Bold)
        lblSupplier.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblreceiveby.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblDeliveryDate.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblBarcode.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblProduct.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblQuantiy.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblExpiration.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblUnitPrice.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblCostPrice.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblTittle.Font = New Font("Outfit", 15, FontStyle.Bold)


        lblBatchNo.Text = "Batch Number: " & GenerateBatchCode()

        ' --- Set initial location of Panel4 ---
        Panel4.Location = New Point(352, 80)

        ' --- ApplyRoundedCorners2 ---
        ApplyRoundedCorners2()


        ' === Light Gray Rounded Border ===
        Guna2Panel1.BorderColor = ColorTranslator.FromHtml("#D3D3D3") ' light gray
        Guna2Panel1.BorderThickness = 2
        Guna2Panel1.BorderRadius = 5

        Guna2Panel2.BorderColor = ColorTranslator.FromHtml("#D3D3D3") ' light gray
        Guna2Panel2.BorderThickness = 2
        Guna2Panel2.BorderRadius = 5



        ' --- Configure numeric input ---
        numQuantity.Minimum = 0
        numQuantity.Maximum = Decimal.MaxValue
        numQuantity.Increment = 1


        ' === Customize numQuantity ===
        With numQuantity
            .UpDownButtonFillColor = ColorTranslator.FromHtml("#1D3A70")
            .UpDownButtonForeColor = Color.White
            .ForeColor = Color.Black
            .Font = New Font("Outfit", 9, FontStyle.Regular)
            .BorderColor = Color.Transparent
            .FillColor = Color.White
            .BackColor = Color.Gainsboro
        End With


        ' === FOR BTN SAVE ALL ===

        btnSaveAll.ForeColor = ColorTranslator.FromHtml("#0B2447")
        btnSaveAll.FillColor = ColorTranslator.FromHtml("#FFD93D")


        ' Para kahit mag-type ka sa NumericUpDown, mag-auto-update pa rin
        AddHandler numQuantity.Controls(1).TextChanged, AddressOf numQuantity_TextChanged

        ' ===== Labels =====
        lblTittle.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblBarcode.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblQuantiy.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblUnitPrice.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblCostPrice.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblExpiration.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblProduct.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblTransactionNo.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblBatchNo.Font = New Font("Outfit", 8, FontStyle.Bold)
        lblDeliveryDate.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblreceiveby.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblSupplier.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblTotalCost.Font = New Font("Outfit", 12, FontStyle.Bold)

        ' ===== TextBoxes / NumericUpDown =====
        txtCostprice.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtTransactionNo.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtUnitPrice.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtProductname.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtBarcodeID.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtrecievedby.Font = New Font("Outfit", 9, FontStyle.Regular)
        numQuantity.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== DateTimePickers =====
        dtpExpirationDate.Font = New Font("Outfit", 9, FontStyle.Bold)
        dtpReceiveDate.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== Buttons =====
        btnAddtopending.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnUpdate.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnAddNewitem.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnSaveAll.Font = New Font("Outfit", 17, FontStyle.Bold)
        Guna2Button1.Font = New Font("Outfit", 9, FontStyle.Bold)
        clearbtn.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== ComboBox =====
        cmbSupplierName.Font = New Font("Outfit", 9, FontStyle.Regular)


        ' Center Panel4 on the form
        panel4.Left = (Me.ClientSize.Width - panel4.Width) \ 2
        panel4.Top = (Me.ClientSize.Height - panel4.Height) \ 2

        ' Wholesale Read only
        txtWholesaleprice.ReadOnly = True


    End Sub

    Private Sub DisableDatePickerInteraction(sender As Object, e As EventArgs)
        e = Nothing ' Just prevents user input
    End Sub

    ' === LOAD SUPPLIERS INTO COMBOBOX ===
    Private Sub LoadSuppliers()
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT SupplierID, CompanyName FROM supplier", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            cmbSupplierName.Items.Clear()

            While reader.Read()
                cmbSupplierName.Items.Add(New KeyValuePair(Of Integer, String)(
                CInt(reader("SupplierID")),
                reader("CompanyName").ToString()
            ))
            End While

            cmbSupplierName.DisplayMember = "Value"
            cmbSupplierName.ValueMember = "Key"
        End Using
    End Sub


    ' === SETUP PENDING DELIVERIES DATAGRIDVIEW ===
    Private Sub SetupPendingList()
        With dgvPendingList
            .Columns.Clear()
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowTemplate.Height = 35
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False

            ' --- Column Order ---
            .Columns.Add("BatchNo", "Batch No")
            .Columns.Add("TransactionNo", "Transaction No")
            .Columns.Add("SupplierName", "Supplier Name")
            .Columns.Add("ReceivedBy", "Received By")
            .Columns.Add("Barcode", "Barcode ID")
            .Columns.Add("ProductName", "Product Name")
            .Columns.Add("Quantity", "Quantity")
            .Columns.Add("UnitPrice", "Unit Price")
            .Columns.Add("CostPrice", "Cost Price")
            .Columns.Add("TotalCost", "Total Cost")
            .Columns.Add("WholesalePrice", "Wholesale Price") ' ← NEW
            .Columns.Add("ExpirationDate", "Expiration Date")

            ' === Edit Column ===
            If dgvPendingList.Columns("Edit") Is Nothing Then
                Dim editCol As New DataGridViewImageColumn()
                editCol.Name = "Edit"
                editCol.HeaderText = "Edit"
                editCol.Image = My.Resources.icons8_edit_mains
                editCol.ImageLayout = DataGridViewImageCellLayout.Zoom
                editCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                editCol.Width = 60
                editCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvPendingList.Columns.Add(editCol)
            End If

            ' === Delete Column ===
            If dgvPendingList.Columns("Delete") Is Nothing Then
                Dim deleteCol As New DataGridViewImageColumn()
                deleteCol.Name = "Delete"
                deleteCol.HeaderText = "Delete"
                deleteCol.Image = My.Resources.icons8_delete_mains
                deleteCol.ImageLayout = DataGridViewImageCellLayout.Zoom
                deleteCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                deleteCol.Width = 60
                deleteCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                deleteCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvPendingList.Columns.Add(deleteCol)
            End If

            ' --- Header Style ---
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ColumnHeadersHeight = 35
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

            ' --- Other settings ---
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowTemplate.Height = 25
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub


    Private Function GenerateBatchCode() As String
        Dim today As String = DateTime.Now.ToString("yyyyMMdd")
        Dim nextNumber As Integer = 1

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' ✅ Get total deliveries count (hindi per day)
                Dim query As String = "
                SELECT COUNT(*) 
                FROM deliveries
            "

                Using cmd As New MySqlCommand(query, conn)
                    Dim totalCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    nextNumber = totalCount + 1
                End Using
            End Using

            ' ✅ Automatically expands digits as needed (0001, 0010, 10000…)
            Dim formattedNumber As String = nextNumber.ToString().PadLeft(4, "0"c)

            ' ✅ Final format
            Return $"BATCH-{today}-{formattedNumber}"

        Catch ex As Exception
            MessageBox.Show("Error generating Batch Code: " & ex.Message)
            Return Nothing
        End Try
    End Function








    ' === AUTO-COMPUTE TOTAL COST WHEN QUANTITY OR COST PRICE CHANGES ===
    Private Sub numQuantity_ValueChanged(sender As Object, e As EventArgs) Handles numQuantity.ValueChanged
        UpdateTotalCostLabel()
    End Sub
    Private Sub numQuantity_TextChanged(sender As Object, e As EventArgs)
        UpdateTotalCostLabel()
    End Sub
    ' --- Add this at the form level ---
    Private WithEvents costTimer As New Timer With {.Interval = 2000} ' 2 seconds

    ' --- TextChanged event ---
    ' === COST PRICE TEXTCHANGED ===
    Private Sub txtCostprice_TextChanged(sender As Object, e As EventArgs) Handles txtCostprice.TextChanged
        ' Restart timer every time user types
        costTimer.Stop()
        costTimer.Start()

        ' Allow typing (empty or incomplete decimal)
        If txtCostprice.Text = "" OrElse txtCostprice.Text.EndsWith(".") Then Exit Sub

        Dim cost As Decimal
        Dim unit As Decimal
        Dim wholesale As Decimal

        ' Always validate, regardless of other controls' Enabled state
        If Decimal.TryParse(txtCostprice.Text, cost) AndAlso
       Decimal.TryParse(txtUnitPrice.Text, unit) AndAlso
       Decimal.TryParse(txtWholesaleprice.Text, wholesale) Then

            ' Determine the maximum allowed cost (the lower of Unit and Wholesale)
            Dim maxAllowed As Decimal = Math.Min(unit, wholesale)

            ' Cost must not exceed maxAllowed — ALWAYS show warning, regardless of expiration date
            If cost > maxAllowed Then
                MessageBox.Show($"Cost Price cannot be higher than the lower of Unit Price and Wholesale Price ({maxAllowed:F2}).",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                txtCostprice.Text = maxAllowed.ToString("F2")
                txtCostprice.SelectionStart = txtCostprice.Text.Length
                Exit Sub
            End If
        End If

        ' 👉 Recompute total cost even if dtpExpirationDate is disabled
        UpdateTotalCostLabel()
    End Sub






    '' === TIMER TICK (FORMAT ONLY) ===
    'Private Sub costTimer_Tick(sender As Object, e As EventArgs) Handles costTimer.Tick
    '    costTimer.Stop()

    '    Dim cost As Decimal
    '    If Decimal.TryParse(txtCostprice.Text, cost) Then
    '        txtCostprice.Text = cost.ToString("F2")
    '        txtCostprice.SelectionStart = txtCostprice.Text.Length
    '    End If
    'End Sub


    ' === UPDATE TOTAL COST LABEL ===
    Private Sub UpdateTotalCostLabel()
        Dim qty As Decimal = 0D
        Dim costPrice As Decimal = 0D

        ' Ignore incomplete input
        If txtCostprice.Text = "" OrElse txtCostprice.Text = "." Then
            lblTotalCost.Text = "Total Cost: ₱0.00"
            Exit Sub
        End If

        ' NumericUpDown value is already safe
        qty = numQuantity.Value

        Decimal.TryParse(txtCostprice.Text, costPrice)

        Dim totalCost As Decimal = qty * costPrice

        lblTotalCost.Text = "Total Cost: ₱" & totalCost.ToString("N2")
    End Sub




    ' ===============================
    ' ADD TO PENDING BUTTON
    ' ===============================
    Private Sub btnAddToPending_Click(sender As Object, e As EventArgs) Handles btnAddtopending.Click
        ' === VALIDATION ===
        If String.IsNullOrWhiteSpace(txtBarcodeID.Text) OrElse
       String.IsNullOrWhiteSpace(txtProductname.Text) OrElse
       numQuantity.Value <= 0 Then

            MessageBox.Show("Complete the fields first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' === DETERMINE EXPIRATION BASED ON PRODUCT TABLE ===
        Dim expirationDisplay As String = "0/0/00"
        Dim productExpiration As String = GetProductExpiration(txtBarcodeID.Text)

        If Not String.Equals(productExpiration, "No Expiration", StringComparison.OrdinalIgnoreCase) Then
            Dim selectedDate As Date = dtpExpirationDate.Value.Date
            Dim today As Date = Date.Today
            Dim minValidDate As Date = today.AddDays(7) ' minimum 1 week from today

            If selectedDate <= today OrElse selectedDate < minValidDate Then
                MessageBox.Show("Expiration date is invalid. It must be at least 1 week from today and not in the past.",
                    "Invalid Expiration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpExpirationDate.Focus()
                Exit Sub
            End If

            expirationDisplay = selectedDate.ToString("yyyy-MM-dd")
        End If

        ' === GENERATE BATCH NUMBER IF EMPTY ===
        If String.IsNullOrWhiteSpace(lblBatchNo.Text) OrElse Not lblBatchNo.Text.Contains("Batch Number:") Then
            lblBatchNo.Text = "Batch Number: " & GenerateBatchCode()
        End If
        Dim batchNo As String = lblBatchNo.Text.Replace("Batch Number: ", "").Trim()

        ' === USE TRANSACTION NUMBER FROM TEXTBOX ===
        Dim transactionNo As String = txtTransactionNo.Text.Trim()

        ' === PRICES & QUANTITY ===
        Dim qty As Decimal = numQuantity.Value
        Dim unitPrice As Decimal = 0D
        Decimal.TryParse(txtUnitPrice.Text, unitPrice)

        Dim costPrice As Decimal = 0D
        Decimal.TryParse(txtCostprice.Text, costPrice)

        Dim wholesalePrice As Decimal = 0D
        Decimal.TryParse(txtWholesaleprice.Text, wholesalePrice)

        Dim totalCost As Decimal = qty * unitPrice

        ' === CHECK IF SAME SUPPLIER + PRODUCT EXISTS ===
        Dim existingRow As DataGridViewRow = Nothing
        For Each row As DataGridViewRow In dgvPendingList.Rows
            If row.Cells("Barcode").Value?.ToString() = txtBarcodeID.Text.Trim() AndAlso
           row.Cells("SupplierName").Value?.ToString() = cmbSupplierName.Text.Trim() Then
                existingRow = row
                Exit For
            End If
        Next

        If existingRow IsNot Nothing Then
            ' Update quantity, total cost, wholesale price, AND transaction number
            Dim existingQty As Decimal = Convert.ToDecimal(existingRow.Cells("Quantity").Value)
            existingQty += qty
            existingRow.Cells("Quantity").Value = existingQty
            existingRow.Cells("TotalCost").Value = (existingQty * unitPrice).ToString("N2")
            existingRow.Cells("WholesalePrice").Value = wholesalePrice.ToString("N2")
            existingRow.Cells("TransactionNo").Value = transactionNo ' <-- FIXED
            MessageBox.Show("Existing product quantity updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Add new row — FIXED COLUMN ORDER, include transactionNo
            dgvPendingList.Rows.Add(
            batchNo,         ' ← first column = Batch No
            transactionNo,   ' ← second column = Transaction No
            cmbSupplierName.Text.Trim(),
            txtrecievedby.Text.Trim(),
            txtBarcodeID.Text.Trim(),
            txtProductname.Text.Trim(),
            qty,
            unitPrice.ToString("N2"),
            costPrice.ToString("N2"),
            totalCost.ToString("N2"),
            wholesalePrice.ToString("N2"),
            expirationDisplay
        )

            ' --- Show confirmation ---
            MessageBox.Show("Item successfully added to pending list!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


            ' Temporarily enable fields for instant clearing
            txtProductname.Enabled = True
            txtUnitPrice.Enabled = True
            txtWholesaleprice.Enabled = True

            txtProductname.Text = String.Empty
            txtCostprice.Text = String.Empty
            txtUnitPrice.Text = String.Empty
            txtWholesaleprice.Text = String.Empty
            txtBarcodeID.Text = String.Empty


            ' Disable again if needed
            txtProductname.Enabled = False
            txtUnitPrice.Enabled = False
            txtWholesaleprice.Enabled = False

            ' Set focus back to barcode
            txtBarcodeID.Focus()


            ' Reset label
            lblTotalCost.Text = "Total Cost: ₱0.00"

            txtBarcodeID.Enabled = True
            txtBarcodeID.Focus()

            ' Reset numeric and date controls
            numQuantity.Value = 0  ' or 1, depending on your default quantity
            dtpExpirationDate.Value = Date.Today  ' resets to today's date

        End If

        ' Preserve persistent fields
        Dim currentBatchNo As String = lblBatchNo.Text
        Dim currentReceivedBy As String = txtrecievedby.Text

        ' Clear only product input fields


        ' Restore persistent fields
        lblBatchNo.Text = currentBatchNo
        txtrecievedby.Text = currentReceivedBy

    End Sub




    ' ===============================
    ' SAVE ALL PENDING DELIVERIES
    ' ===============================
    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        If dgvPendingList.Rows.Count = 0 Then
            MessageBox.Show("No pending deliveries to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
            Using trans = conn.BeginTransaction()
                Try
                    For Each row As DataGridViewRow In dgvPendingList.Rows
                        If row.IsNewRow Then Continue For

                        ' === Get SupplierID ===
                        Dim supplierCmd As New MySqlCommand("SELECT SupplierID FROM supplier WHERE CompanyName=@Supplier", conn, trans)
                        supplierCmd.Parameters.AddWithValue("@Supplier", row.Cells("SupplierName").Value)
                        Dim supplierID As Object = supplierCmd.ExecuteScalar()
                        If supplierID Is Nothing Then
                            Throw New Exception("Supplier not found: " & row.Cells("SupplierName").Value)
                        End If

                        ' === Handle Expiration Date ===
                        Dim expVal As String = row.Cells("ExpirationDate").Value?.ToString().Trim()
                        Dim expDate As Object
                        If String.IsNullOrWhiteSpace(expVal) OrElse expVal = "0/0/00" Then
                            expDate = DBNull.Value
                        Else
                            expDate = Convert.ToDateTime(expVal)
                        End If

                        ' === Check if product exists in inventory ===
                        Dim existsId As Integer = 0
                        Dim existingQty As Integer = 0
                        Using checkInv As New MySqlCommand("
                    SELECT id, quantity 
                    FROM inventory 
                    WHERE BarcodeID=@Barcode AND ProductName=@ProductName", conn, trans)
                            checkInv.Parameters.AddWithValue("@Barcode", row.Cells("Barcode").Value)
                            checkInv.Parameters.AddWithValue("@ProductName", row.Cells("ProductName").Value)
                            Using reader As MySqlDataReader = checkInv.ExecuteReader()
                                If reader.Read() Then
                                    existsId = reader.GetInt32("id")
                                    existingQty = reader.GetInt32("quantity")
                                End If
                            End Using
                        End Using

                        ' === Update or Insert into inventory ===
                        If existsId > 0 Then
                            Using updInv As New MySqlCommand("
                        UPDATE inventory 
                        SET quantity=@newQty, CostPrice=@CostPrice, UnitPrice=@UnitPrice 
                        WHERE id=@id", conn, trans)
                                updInv.Parameters.AddWithValue("@newQty", existingQty + Convert.ToInt32(row.Cells("Quantity").Value))
                                updInv.Parameters.AddWithValue("@CostPrice", row.Cells("CostPrice").Value)
                                updInv.Parameters.AddWithValue("@UnitPrice", row.Cells("UnitPrice").Value)
                                updInv.Parameters.AddWithValue("@id", existsId)
                                updInv.ExecuteNonQuery()
                            End Using
                        Else
                            Using insInv As New MySqlCommand("
                        INSERT INTO inventory (BarcodeID, ProductName, quantity, CostPrice, UnitPrice, CriticalLevel)
                        VALUES (@BarcodeID, @ProductName, @Quantity, @CostPrice, @UnitPrice, 10)", conn, trans)
                                insInv.Parameters.AddWithValue("@BarcodeID", row.Cells("Barcode").Value)
                                insInv.Parameters.AddWithValue("@ProductName", row.Cells("ProductName").Value)
                                insInv.Parameters.AddWithValue("@Quantity", row.Cells("Quantity").Value)
                                insInv.Parameters.AddWithValue("@CostPrice", row.Cells("CostPrice").Value)
                                insInv.Parameters.AddWithValue("@UnitPrice", row.Cells("UnitPrice").Value)
                                insInv.ExecuteNonQuery()
                            End Using
                        End If

                        ' === Insert into deliveries ===
                        Using insDelivery As New MySqlCommand("
                    INSERT INTO deliveries 
                    (TransactionNumber, BatchNumber, BarcodeID, ProductName, SupplierID, 
                     ReceiveDate, Quantity, RemainingQty, CostPrice, UnitPrice, WholesalePrice, TotalCost, 
                     ReceivedBy, ExpirationDate, OriginalExpirationDate) 
                    VALUES 
                    (@TransactionNumber, @BatchNumber, @BarcodeID, @ProductName, @SupplierID,
                     NOW(), @Quantity, @RemainingQty, @CostPrice, @UnitPrice, @WholesalePrice, @TotalCost, 
                     @ReceivedBy, @ExpirationDate, @OriginalExpirationDate)", conn, trans)

                            ' <-- FIX: use row's TransactionNo instead of textbox
                            insDelivery.Parameters.AddWithValue("@TransactionNumber", row.Cells("TransactionNo").Value)
                            insDelivery.Parameters.AddWithValue("@BatchNumber", row.Cells("BatchNo").Value)
                            insDelivery.Parameters.AddWithValue("@BarcodeID", row.Cells("Barcode").Value)
                            insDelivery.Parameters.AddWithValue("@ProductName", row.Cells("ProductName").Value)
                            insDelivery.Parameters.AddWithValue("@SupplierID", supplierID)
                            insDelivery.Parameters.AddWithValue("@Quantity", row.Cells("Quantity").Value)
                            insDelivery.Parameters.AddWithValue("@RemainingQty", row.Cells("Quantity").Value)
                            insDelivery.Parameters.AddWithValue("@CostPrice", row.Cells("CostPrice").Value)
                            insDelivery.Parameters.AddWithValue("@UnitPrice", row.Cells("UnitPrice").Value)
                            insDelivery.Parameters.AddWithValue("@WholesalePrice", row.Cells("WholesalePrice").Value)
                            insDelivery.Parameters.AddWithValue("@TotalCost", Convert.ToDecimal(row.Cells("TotalCost").Value))
                            insDelivery.Parameters.AddWithValue("@ReceivedBy", row.Cells("ReceivedBy").Value)
                            insDelivery.Parameters.AddWithValue("@ExpirationDate", expDate)
                            insDelivery.Parameters.AddWithValue("@OriginalExpirationDate", expDate)

                            insDelivery.ExecuteNonQuery()
                        End Using

                        ' === Audit Trail ===
                        Dim actionDesc As String = $"Added delivery: {row.Cells("ProductName").Value} | Qty: {row.Cells("Quantity").Value} | Supplier: {row.Cells("SupplierName").Value}"
                        LogAuditTrail(SessionData.role, SessionData.fullName, actionDesc)
                    Next

                    ' Commit transaction
                    trans.Commit()

                    dgvPendingList.Rows.Clear()
                    MessageBox.Show("All deliveries saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Reset UI
                    lblBatchNo.Text = "Batch Number: " & GenerateBatchCode()
                    lblTotalCost.Text = "Total Cost: ₱0.00"
                    cmbSupplierName.SelectedIndex = -1
                    Panelmain2.Visible = False
                    panel4.Visible = False
                    animTimer.Stop()
                    animationInProgress = False

                Catch ex As Exception
                    trans.Rollback()
                    MessageBox.Show("Error saving deliveries: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub



    ' === FUNCTION TO GET EXPIRATION FROM PRODUCT TABLE ===
    Private Function GetProductExpiration(barcode As String) As String
        Dim exp As String = "No Expiration"
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
            Using cmd As New MySqlCommand("SELECT Expiration FROM product WHERE BarcodeID=@barcode", conn)
                cmd.Parameters.AddWithValue("@barcode", barcode)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    exp = result.ToString()
                End If
            End Using
        End Using
        Return exp
    End Function


    ' ===============================
    ' UPDATE SELECTED ROW
    ' ===============================
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Make sure a row is selected for editing
        If editingRowIndex < 0 OrElse editingRowIndex >= dgvPendingList.Rows.Count Then
            MessageBox.Show("No row selected for update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate required input
        If String.IsNullOrWhiteSpace(txtBarcodeID.Text) OrElse
       String.IsNullOrWhiteSpace(txtProductname.Text) OrElse
       String.IsNullOrWhiteSpace(txtUnitPrice.Text) OrElse
       String.IsNullOrWhiteSpace(txtCostprice.Text) OrElse
       String.IsNullOrWhiteSpace(txtWholesaleprice.Text) OrElse
       cmbSupplierName.SelectedIndex = -1 Then

            MessageBox.Show("Please fill-up all required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate numeric input
        Dim unitPrice As Decimal
        Dim costPrice As Decimal
        Dim wholesalePrice As Decimal

        If Not Decimal.TryParse(txtUnitPrice.Text, unitPrice) OrElse
       Not Decimal.TryParse(txtCostprice.Text, costPrice) OrElse
       Not Decimal.TryParse(txtWholesaleprice.Text, wholesalePrice) Then

            MessageBox.Show("Unit, Cost, and Wholesale Price must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform the update
        Dim row As DataGridViewRow = dgvPendingList.Rows(editingRowIndex)

        row.Cells("Barcode").Value = txtBarcodeID.Text.Trim()
        row.Cells("ProductName").Value = txtProductname.Text.Trim()
        row.Cells("Quantity").Value = numQuantity.Value
        row.Cells("UnitPrice").Value = unitPrice
        row.Cells("CostPrice").Value = costPrice
        row.Cells("WholesalePrice").Value = wholesalePrice
        row.Cells("TotalCost").Value = numQuantity.Value * unitPrice ' auto compute
        row.Cells("SupplierName").Value = cmbSupplierName.Text.Trim()
        row.Cells("ExpirationDate").Value = dtpExpirationDate.Value.ToShortDateString()
        row.Cells("ReceivedBy").Value = txtrecievedby.Text.Trim()

        ' Reset editing index
        editingRowIndex = -1

        ' Clear inputs after update
        txtBarcodeID.Clear()
        txtProductname.Clear()
        numQuantity.Value = 1
        txtUnitPrice.Clear()
        txtCostprice.Clear()
        txtWholesaleprice.Clear()
        cmbSupplierName.SelectedIndex = -1
        dtpExpirationDate.Value = Date.Now
        txtrecievedby.Clear()

        MessageBox.Show("Successfully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    ' === FETCH PRODUCT BY BARCODE ===
    'Private Sub txtBarcodeID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcodeID.KeyPress
    '    ' If barcode is empty, clear all other input fields
    '    If String.IsNullOrWhiteSpace(txtBarcodeID.Text) Then
    '        ClearAllInputsExceptBarcode()
    '    End If
    'End Sub

    '' Helper function: clears all textboxes/numeric/date controls except the barcode
    'Private Sub ClearAllInputsExceptBarcode()
    '    ' Clear product fields
    '    txtProductname.Text = String.Empty
    '    numQuantity.Value = 0
    '    txtUnitPrice.Text = String.Empty
    '    txtCostprice.Text = String.Empty
    '    txtWholesaleprice.Text = String.Empty
    '    dtpExpirationDate.Value = Date.Today
    '    lblTotalCost.Text = "Total Cost: ₱0.00"

    'End Sub




    ' === CLEAR INPUTS ===
    Private Sub ClearInputs()
        txtBarcodeID.Clear()
        txtProductname.Clear()
        txtUnitPrice.Clear()
        txtCostprice.Clear()
        numQuantity.Value = 0
        ' ❌ wag i-reset ang supplier, para di ka paulit-ulit pumili
        'cmbSupplierName.SelectedIndex = -1
        dtpExpirationDate.Value = DateTime.Now

        ' ✅ Reset total cost label
        lblTotalCost.Text = "Total Cost: ₱0.00"
    End Sub









    '=========================== FOR UI ==========================
    Private Const CornerRadius As Integer = 10 ' fixed radius

    Private Sub ApplyRoundedCorners2()
        Dim path As New GraphicsPath()
        path.StartFigure()

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

    ' ===============================
    ' === Animation Variables ===
    ' ===============================

    Private WithEvents animTimer As New Timer With {.Interval = 5} ' 5ms = ultra-smooth & fast

    ' === Panel4 Animation Settings ===
    Private panel4StartX As Integer = 387
    Private panel4StartY As Integer = 86
    Private panel4TargetX As Integer = 176
    Private panel4TargetY As Integer = 113
    Private panel4TargetWidth As Integer = 275
    Private panel4TargetHeight As Integer = 385

    ' === PanelMain2 Final Position ===
    Private panelMain2X As Integer = 457
    Private panelMain2Y As Integer = 113
    Private panelMain2Width As Integer = 622
    Private panelMain2Height As Integer = 385

    ' ===============================
    ' === Button: Start Animation ===
    ' ===============================
    Private animationInProgress As Boolean = False ' 🔹 Flag para maiwasan multiple clicks

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ' --- Supplier Validation muna bago animation ---
        If String.IsNullOrWhiteSpace(cmbSupplierName.Text) Then
            MessageBox.Show("Please select a supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbSupplierName.Focus()
            Return
        End If

        txtBarcodeID.Focus()

        ' ✅ Check kung may animation na nagaganap
        If animationInProgress Then Exit Sub
        animationInProgress = True ' mark as busy

        ' Reset starting position and visibility
        panel4.Location = New Point(panel4StartX, panel4StartY)
        panel4.Size = New Size(100, 100) ' maliit muna para may smooth expand
        panel4.Visible = True
        Panelmain2.Visible = False ' itatago muna habang nag-a-animate si panel4

        ' ✅ Start animation
        animTimer.Start()
    End Sub



    ' ===============================
    ' === Animate Panel4 Only ===
    ' ===============================
    Private Sub animTimer_Tick(sender As Object, e As EventArgs) Handles animTimer.Tick
        ' Para smooth, gumamit tayo ng easing (parang lerp)
        Dim easeMove As Double = 0.4 ' 0.3–0.5 range = balance ng bilis at smoothness
        Dim easeSize As Double = 0.35

        Dim newX As Integer = panel4.Location.X + CInt((panel4TargetX - panel4.Location.X) * easeMove)
        Dim newY As Integer = panel4.Location.Y + CInt((panel4TargetY - panel4.Location.Y) * easeMove)
        Dim newW As Integer = panel4.Width + CInt((panel4TargetWidth - panel4.Width) * easeSize)
        Dim newH As Integer = panel4.Height + CInt((panel4TargetHeight - panel4.Height) * easeSize)

        panel4.Location = New Point(newX, newY)
        panel4.Size = New Size(newW, newH)

        ' Check kung halos tapos na animation
        If Math.Abs(panel4.Location.X - panel4TargetX) < 2 AndAlso
       Math.Abs(panel4.Location.Y - panel4TargetY) < 2 AndAlso
       Math.Abs(panel4.Width - panel4TargetWidth) < 2 AndAlso
       Math.Abs(panel4.Height - panel4TargetHeight) < 2 Then

            ' Stop animation
            animTimer.Stop()

            ' Final exact position & size
            panel4.Location = New Point(panel4TargetX, panel4TargetY)
            panel4.Size = New Size(panel4TargetWidth, panel4TargetHeight)

            ' Show PanelMain2 instantly (no animation)
            Panelmain2.Visible = True
            Panelmain2.Location = New Point(panelMain2X, panelMain2Y)
            Panelmain2.Size = New Size(panelMain2Width, panelMain2Height)
            Panelmain2.BringToFront()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' --- Hide panels ---
        panel4.Visible = False
        Panelmain2.Visible = False

        ' --- Reset position ---
        panel4.Location = New Point(384, 86)

        txtTransactionNo.Text = String.Empty
        cmbSupplierName.SelectedIndex = -1


        ' --- Stop animation timer ---
        animTimer.Stop()

        ' --- Generate new Transaction & Batch codes ---
        'lblTransactionNo.Text = "Transaction Number: " & GenerateTransactionCode()
        lblBatchNo.Text = "Batch Number: " & GenerateBatchCode()

        ClearInputs()
    End Sub


    Private Sub PictureBox3exit_Click(sender As Object, e As EventArgs) Handles PictureBox3exit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If

        txtTransactionNo.Text = String.Empty
        cmbSupplierName.SelectedIndex = -1

        txtBarcodeID.Text = String.Empty
        txtProductname.Text = String.Empty
        txtCostprice.Text = String.Empty
        txtUnitPrice.Text = String.Empty
        txtWholesaleprice.Text = String.Empty

        ' Reset label
        lblTotalCost.Text = "Total Cost: ₱0.00"

        txtBarcodeID.Enabled = True
        txtBarcodeID.Focus()

        ' Reset numeric and date controls
        numQuantity.Value = 0  ' or 1, depending on your default quantity
        dtpExpirationDate.Value = Date.Today  ' resets to today's date

    End Sub

    ' === Allow only whole numbers ===
    Private Sub NumericTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) _
Handles txtCostprice.KeyPress, txtUnitPrice.KeyPress, txtBarcodeID.KeyPress

        ' Allow digits, backspace, and decimal point
        If Not Char.IsDigit(e.KeyChar) AndAlso
       e.KeyChar <> ChrW(Keys.Back) AndAlso
       e.KeyChar <> "."c Then
            e.Handled = True
            Exit Sub
        End If

        ' GUNA2TEXTBOX ang gamit
        Dim tb As Guna.UI2.WinForms.Guna2TextBox =
        CType(sender, Guna.UI2.WinForms.Guna2TextBox)

        ' Barcode = walang decimal
        If tb.Name = "txtBarcodeID" AndAlso e.KeyChar = "."c Then
            e.Handled = True
            Exit Sub
        End If

        ' Allow only ONE decimal point
        If e.KeyChar = "."c AndAlso tb.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub


    ' === For Barcode (numbers only, no dot) ===
    Private Sub BarcodeTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcodeID.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If

        ' Enter key to fetch product
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True

        End If
    End Sub
    Private Sub txtBarcodeID_TextChanged(sender As Object, e As EventArgs) Handles txtBarcodeID.TextChanged

        If txtBarcodeID.Text.Trim() = "" Then
            ' Clear all fields when barcode is empty
            txtProductname.Clear()
            txtUnitPrice.Clear()
            txtWholesaleprice.Clear()
            dtpExpirationDate.Enabled = False
            Exit Sub
        End If

        Using conn As New MySqlConnection(connectionstring)
            Try
                conn.Open()
                Using cmd As New MySqlCommand("
                SELECT ProductName, Description, RetailPrice, WholesalePrice, Expiration 
                FROM product 
                WHERE BarcodeID = @Barcode", conn)

                    cmd.Parameters.AddWithValue("@Barcode", txtBarcodeID.Text.Trim())

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' ✅ Combine ProductName + Description
                            Dim name As String = If(reader("ProductName") IsNot DBNull.Value, reader("ProductName").ToString().Trim(), "")
                            Dim desc As String = If(reader("Description") IsNot DBNull.Value, reader("Description").ToString().Trim(), "")
                            txtProductname.Text = If(String.IsNullOrEmpty(desc), name, $"{name} ({desc})")

                            ' ✅ Unit Retail Price
                            Dim retailPrice As Decimal = If(Not IsDBNull(reader("RetailPrice")), Convert.ToDecimal(reader("RetailPrice")), 0D)
                            txtUnitPrice.Text = retailPrice.ToString("F2")

                            ' ✅ Wholesale Price (reference only)
                            Dim wholesalePrice As Decimal = If(Not IsDBNull(reader("WholesalePrice")), Convert.ToDecimal(reader("WholesalePrice")), 0D)
                            txtWholesaleprice.Text = wholesalePrice.ToString("F2")

                            ' ✅ Expiration Handling
                            Dim expirationStatus As String = If(reader("Expiration") IsNot DBNull.Value, reader("Expiration").ToString().Trim().ToLower(), "")
                            If expirationStatus = "no" OrElse expirationStatus = "no expiration" Then
                                dtpExpirationDate.Enabled = False
                            Else
                                dtpExpirationDate.Enabled = True
                                dtpExpirationDate.Value = DateTime.Now
                            End If

                        Else
                            ' ❌ Barcode Not Found — clear all fields
                            txtProductname.Clear()
                            txtUnitPrice.Clear()
                            txtWholesaleprice.Clear()
                            dtpExpirationDate.Enabled = False



                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error fetching product: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

    End Sub





    ' === Function to fetch product by barcode safely ===
    Private Sub FetchProductByBarcode()
        txtProductname.Clear()

        If String.IsNullOrWhiteSpace(txtBarcodeID.Text) Then Exit Sub

        Using conn As New MySqlConnection(connectionstring)
            Try
                conn.Open()

                Using cmd As New MySqlCommand("SELECT ProductName, Description FROM Product WHERE BarcodeID=@Barcode", conn)
                    cmd.Parameters.AddWithValue("@Barcode", txtBarcodeID.Text.Trim())

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim name As String = If(reader("ProductName") IsNot DBNull.Value, reader("ProductName").ToString().Trim(), "")
                            Dim desc As String = If(reader("Description") IsNot DBNull.Value, reader("Description").ToString().Trim(), "")

                            ' Combine ProductName and Description safely
                            txtProductname.Text = If(String.IsNullOrEmpty(desc), name, $"{name} ({desc})")
                        Else
                            MessageBox.Show("Barcode not found in inventory.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using




            Catch ex As Exception
                MessageBox.Show("Error fetching product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub




    ' === Product Name: letters only, allow space and backspace ===
    Private Sub txtProductname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProductname.KeyPress
        ' Allow letters, backspace, and space
        If Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub


    '' === Declare sa taas ng form ===
    'Private scanTimer As New Timer()
    'Private scanBuffer As New System.Text.StringBuilder()

    'Private Sub bid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcodeID.KeyPress
    '    ' Collect all scanned characters (excluding Enter)
    '    If Not Char.IsControl(e.KeyChar) Then
    '        scanBuffer.Append(e.KeyChar)
    '    End If

    '    ' Reset timer after every key press
    '    scanTimer.Stop()
    '    scanTimer.Interval = 200 ' delay para matapos ang mabilis na scan
    '    AddHandler scanTimer.Tick, AddressOf ScanCompleted
    '    scanTimer.Start()
    'End Sub

    'Private Sub ScanCompleted(sender As Object, e As EventArgs)
    '    scanTimer.Stop()

    '    ' Set text AFTER scan completes
    '    txtCostprice.Text = scanBuffer.ToString().Trim()

    '    ' Move focus to pname
    '    txtCostprice.Focus()
    '    txtCostprice.Clear()


    'End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === DEFAULT COLORS & IMAGES ===
        btnAddNewitem.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnAddNewitem.ForeColor = Color.White
        btnAddNewitem.Image = My.Resources.icons8_add_30_normal ' normal icon

        'btnSort.FillColor = ColorTranslator.FromHtml("#1D3A70")
        'btnSort.ForeColor = Color.White
        'btnSort.Image = My.Resources.icons8_alphabetical_sorting_normal ' normal icon


        ' === HOVER EFFECTS FOR btnAddnewUsar ===
        AddHandler btnAddNewitem.MouseEnter, Sub()
                                                 btnAddNewitem.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                 btnAddNewitem.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                 btnAddNewitem.Image = My.Resources.icons8_add_30_hindi ' hover icon
                                             End Sub

        AddHandler btnAddNewitem.MouseLeave, Sub()
                                                 btnAddNewitem.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                 btnAddNewitem.ForeColor = Color.White
                                                 btnAddNewitem.Image = My.Resources.icons8_add_30_normal ' back to normal
                                             End Sub


        '' === HOVER EFFECTS FOR btnSort ===
        'AddHandler btnDeliveryList.MouseEnter, Sub()
        '                                           btnDeliveryList.FillColor = ColorTranslator.FromHtml("#FFD93D")
        '                                           btnDeliveryList.ForeColor = ColorTranslator.FromHtml("#0B2447")
        '                                           btnDeliveryList.Image = My.Resources.icons8_delivery_30 ' hover icon
        '                                       End Sub

        'AddHandler btnDeliveryList.MouseLeave, Sub()
        '                                           btnDeliveryList.FillColor = ColorTranslator.FromHtml("#1D3A70")
        '                                           btnDeliveryList.ForeColor = Color.White
        '                                           btnDeliveryList.Image = My.Resources.icons8_successful_delivery_30 ' normal icon
        '                                       End Sub


        ' === OPTIONAL: CENTER THE FORM ON SCREEN ===
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    Private Sub btnAddNewitem_Click(sender As Object, e As EventArgs) Handles btnAddNewitem.Click
        ' --- Stop any ongoing animation first ---
        animTimer.Stop()
        animationInProgress = False

        ' --- Hide main panel muna ---
        Panelmain2.Visible = False

        ' --- Reset panel4 sa starting position and size ---
        panel4.Visible = True

        btnUpdate.Visible = False
        btnAddtopending.Visible = True

        'cmbSupplierName.SelectedIndex = -1

        ' --- Generate codes ---

        Dim batchCode As String = GenerateBatchCode()

        ' --- Set logged-in user's full name ---
        txtrecievedby.Text = LoggedInFullName
        txtrecievedby.Enabled = False
        txtBarcodeID.Enabled = True

        txtBarcodeID.Focus()


        ' Center Panel4 on the form
        panel4.Left = (Me.ClientSize.Width - panel4.Width) \ 2
        panel4.Top = (Me.ClientSize.Height - panel4.Height) \ 2


    End Sub

    Private Sub dgvPendingList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendingList.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvPendingList.Rows(e.RowIndex)
        Dim colName As String = dgvPendingList.Columns(e.ColumnIndex).Name

        Select Case colName

            Case "Edit"
                editingRowIndex = e.RowIndex

                ' Fetch ProductName first → then get Barcode from DB
                SetIfExists("ProductName", Sub(v)
                                               txtProductname.Text = v
                                               LoadBarcodeFromDB(v)
                                           End Sub)

                SetIfExists("Quantity", Sub(v) numQuantity.Value = If(IsNumeric(v), Convert.ToDecimal(v), 0))
                SetIfExists("UnitPrice", Sub(v) txtUnitPrice.Text = v)
                SetIfExists("CostPrice", Sub(v) txtCostprice.Text = v)
                SetIfExists("ReceivedBy", Sub(v) txtrecievedby.Text = v)
                SetIfExists("SupplierName", Sub(v) cmbSupplierName.Text = v)

                ' Expiration Date
                If dgvPendingList.Columns.Contains("ExpirationDate") Then
                    Dim expText As String = row.Cells("ExpirationDate").Value?.ToString()
                    Dim expDate As Date
                    If Date.TryParse(expText, expDate) Then
                        dtpExpirationDate.Value = expDate
                    Else
                        dtpExpirationDate.Value = Date.Now
                    End If
                End If

                ' Transaction Number → txtTransactionNo
                If dgvPendingList.Columns.Contains("TransactionNo") Then
                    Dim transValue = row.Cells("TransactionNo").Value
                    If transValue IsNot Nothing Then
                        txtTransactionNo.Text = transValue.ToString()
                    Else
                        txtTransactionNo.Text = ""
                    End If
                End If

                ' Batch Number
                SetIfExists("BatchNo", Sub(v) lblBatchNo.Text = "Batch Number: " & v)

                ' Show panels and buttons
                panel4.Visible = True
                Panelmain2.Visible = True
                btnUpdate.Visible = True
                btnAddtopending.Visible = False
                panel4.Location = New Point(103, 86)
                panel4.Location = New Point(176, 113)

            Case "Delete"
                If MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    dgvPendingList.Rows.RemoveAt(e.RowIndex)
                    MessageBox.Show("Item removed from pending list.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

        End Select

    End Sub


    Private Sub SetIfExists(columnName As String, setter As Action(Of String))
        If dgvPendingList.Columns.Contains(columnName) Then
            Dim value = dgvPendingList.CurrentRow.Cells(columnName).Value
            If value IsNot Nothing Then
                setter(value.ToString())
            End If
        End If
    End Sub

    Private Sub LoadBarcodeFromDB(productName As String)
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                Dim query As String = "SELECT BarcodeID FROM product WHERE ProductName = @name LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", productName)

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        txtBarcodeID.Text = result.ToString()
                    Else
                        txtBarcodeID.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading barcode: " & ex.Message)
        End Try
    End Sub




    Private Sub txtUnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        ' Prevent any key input
        e.Handled = True
    End Sub


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
                    cmd.Parameters.AddWithValue("@Form", "Deliveries")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub deliveries_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        ' Clear textboxes

        ''txtTransactionNo.Text = String.Empty
        ''cmbSupplierName.SelectedIndex = -1


        ' Temporarily enable fields for instant clearing
        txtProductname.Enabled = True
        txtUnitPrice.Enabled = True
        txtWholesaleprice.Enabled = True

        txtProductname.Text = String.Empty
        txtCostprice.Text = String.Empty
        txtUnitPrice.Text = String.Empty
        txtWholesaleprice.Text = String.Empty
        txtBarcodeID.Text = String.Empty


        ' Disable again if needed
        txtProductname.Enabled = False
        txtUnitPrice.Enabled = False
        txtWholesaleprice.Enabled = False

        ' Set focus back to barcode
        txtBarcodeID.Focus()

        ' Reset label
        lblTotalCost.Text = "Total Cost: ₱0.00"

        txtBarcodeID.Enabled = True
        txtBarcodeID.Focus()

        ' Reset numeric and date controls
        numQuantity.Value = 0  ' or 1, depending on your default quantity
        dtpExpirationDate.Value = Date.Today  ' resets to today's date
    End Sub


End Class
