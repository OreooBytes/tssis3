Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class ReturnRefund


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

    ' === FORM LOAD ===
    Private Sub ReturnRefund_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyRoundedCorners2()
        SetupProductDGV()
        SetupReturnDGV()

        ' Theme
        BackColor = ColorTranslator.FromHtml("#0B2447")
        btnReturn.ForeColor = ColorTranslator.FromHtml("#0B2447")
        btnReturn.FillColor = ColorTranslator.FromHtml("#FFD93D")

        ' Fonts
        dgvreturnitems.Font = New Font("Outfit", 9, FontStyle.Regular)
        dgvProductlist.Font = New Font("Outfit", 9, FontStyle.Regular)
        btnLatestTransction.Font = New Font("Outfit", 9, FontStyle.Bold)
        Guna2Button1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Guna2Button2.Font = New Font("Outfit", 9, FontStyle.Bold)
        txtReceipt.Font = New Font("Outfit", 9, FontStyle.Regular)
        btnReturn.Font = New Font("Outfit", 17, FontStyle.Bold)
        lblSelectItemforReturn.Font = New Font("Outfit", 11, FontStyle.Bold)

        ' Center panel
        Guna2ShadowPanel1.Left = (ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (ClientSize.Height - Guna2ShadowPanel1.Height) \ 2
    End Sub

    ' === TEXT CHANGED EVENT FOR RECEIPT ===
    Private Sub txtReceipt_TextChanged(sender As Object, e As EventArgs) Handles txtReceipt.TextChanged
        Dim receiptNo As String = txtReceipt.Text.Trim()
        If receiptNo = "" Then
            dgvProductlist.Rows.Clear()
            txtTransactionNo.Clear()
            Return
        End If
        LoadProductsByReceipt(receiptNo)
    End Sub

    ' === LOAD PRODUCTS BY RECEIPT ===
    Private Sub LoadProductsByReceipt(receiptNo As String)
        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                ' Get SaleID + TransactionNo
                Dim saleID As Integer = -1
                Dim transactionNo As String = ""

                Using cmd As New MySqlCommand("SELECT SaleID, TransactionNo FROM sales WHERE ReceiptNo=@receiptNo LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("@receiptNo", receiptNo)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            saleID = Convert.ToInt32(reader("SaleID"))
                            transactionNo = reader("TransactionNo").ToString()
                        Else
                            dgvProductlist.Rows.Clear()
                            txtTransactionNo.Clear()
                            MessageBox.Show("Receipt not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using
                End Using

                txtTransactionNo.Text = transactionNo

                ' Load sale items
                Using cmdItems As New MySqlCommand("
                    SELECT BarcodeID, ProductName, Quantity, UnitPrice, TotalPrice
                    FROM sales_items
                    WHERE SaleID=@saleID", conn)
                    cmdItems.Parameters.AddWithValue("@saleID", saleID)

                    Using readerItems As MySqlDataReader = cmdItems.ExecuteReader()
                        dgvProductlist.Rows.Clear()
                        While readerItems.Read()
                            dgvProductlist.Rows.Add(
                                readerItems("BarcodeID"),
                                readerItems("ProductName"),
                                readerItems("Quantity"),
                                readerItems("UnitPrice"),
                                readerItems("TotalPrice")
                            )
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' === SETUP PRODUCT LIST DGV ===
    Private Sub SetupProductDGV()
        With dgvProductlist
            .Rows.Clear()
            .Columns.Clear()
            .AllowUserToAddRows = False
            .ReadOnly = True

            .Columns.Add("BarcodeID", "Barcode")
            .Columns.Add("ProductName", "Product Name")
            .Columns.Add("QtyPurchased", "Qty Purchased")
            .Columns.Add("UnitPrice", "Unit Price")
            .Columns.Add("TotalPrice", "Total Price")

            Dim addCol As New DataGridViewButtonColumn() With {
                .Name = "AddToReturn",
                .HeaderText = "Action",
                .Text = "Add",
                .UseColumnTextForButtonValue = True,
                .Width = 60
            }
            ' Center the header text
            addCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Add(addCol)

            ' Styling
            .ColumnHeadersHeight = 35
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            ' === Disable resizing for columns and rows ===
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
        End With
    End Sub

    ' === SETUP RETURN ITEMS DGV ===
    Private Sub SetupReturnDGV()
        With dgvreturnitems
            .Rows.Clear()
            .Columns.Clear()
            .AllowUserToAddRows = False

            ' Columns
            .Columns.Add("ReturnID", "Return ID")
            .Columns("ReturnID").Visible = False
            .Columns.Add("TransactionNumber", "Transaction Number")
            .Columns.Add("BarcodeID", "Barcode")
            .Columns.Add("ProductName", "Product Name")
            .Columns.Add("QuantityPurchased", "Qty Purchased")
            .Columns.Add("QuantityReturned", "Return Qty")
            .Columns.Add("TotalReturned", "Total Returned") ' UI only
            .Columns.Add("ApprovedBy", "Approved By")

            ' Reason Combo
            Dim reasonCol As New DataGridViewComboBoxColumn() With {.Name = "Reason", .HeaderText = "Reason"}
            reasonCol.Items.AddRange("Defective", "Wrong Item", "Expired", "Others")
            .Columns.Add(reasonCol)

            ' Condition Combo
            Dim condCol As New DataGridViewComboBoxColumn() With {.Name = "ConditionStatus", .HeaderText = "Condition"}
            condCol.Items.AddRange("Good", "Damaged", "Expired", "Others")
            .Columns.Add(condCol)

            ' Returned to Inventory Combo
            Dim invCol As New DataGridViewComboBoxColumn() With {.Name = "ReturnedToInventory", .HeaderText = "Return to Inventory"}
            invCol.Items.AddRange("Yes", "No")
            .Columns.Add(invCol)

            ' Cancel Button
            Dim cancelCol As New DataGridViewImageColumn With {
            .Name = "Cancel",
            .HeaderText = "Action",
            .Image = My.Resources.icons8_cancel_35,
            .ImageLayout = DataGridViewImageCellLayout.Zoom,
            .Width = 35
        }
            ' Center the header text
            cancelCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns.Add(cancelCol)

            ' Styling
            .ColumnHeadersHeight = 35
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            ' === Disable resizing for columns and rows ===
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False

            ' Read-only columns
            .Columns("ApprovedBy").ReadOnly = True
            .Columns("QuantityPurchased").ReadOnly = True
            .Columns("ProductName").ReadOnly = True
            .Columns("TotalReturned").ReadOnly = True ' UI only
        End With

        ' Focus on QuantityReturned of first row
        If dgvreturnitems.Columns.Contains("QuantityReturned") AndAlso dgvreturnitems.Rows.Count > 0 Then
            dgvreturnitems.CurrentCell = dgvreturnitems.Rows(0).Cells("QuantityReturned")
            dgvreturnitems.BeginEdit(True)
        End If
    End Sub


    ' === ADD PRODUCT TO RETURN LIST ===
    Private Sub dgvProductlist_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductlist.CellContentClick
        If e.RowIndex < 0 OrElse dgvProductlist.Columns(e.ColumnIndex).Name <> "AddToReturn" Then Exit Sub

        Dim selectedRow As DataGridViewRow = dgvProductlist.Rows(e.RowIndex)
        Dim barcode As String = selectedRow.Cells("BarcodeID").Value.ToString()
        Dim productName As String = selectedRow.Cells("ProductName").Value.ToString()
        Dim transNo As String = txtTransactionNo.Text.Trim()
        Dim qtyPurchased As Integer = Convert.ToInt32(selectedRow.Cells("QtyPurchased").Value)

        ' --- Calculate total returned so far from current session (DataGridView) ---
        Dim sessionReturned As Integer = 0
        For Each row As DataGridViewRow In dgvreturnitems.Rows
            If row.Cells("BarcodeID").Value?.ToString() = barcode Then
                sessionReturned += If(IsDBNull(row.Cells("QuantityReturned").Value), 0, Convert.ToInt32(row.Cells("QuantityReturned").Value))
            End If
        Next

        ' --- Query database to get previous returns ---
        Dim dbReturned As Integer = 0
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()
                Dim cmd As New MySqlCommand("
                SELECT SUM(QuantityReturned) 
                FROM customerreturns 
                WHERE TransactionNumber = @transNo AND BarcodeID = @barcode
            ", conn)
                cmd.Parameters.AddWithValue("@transNo", transNo)
                cmd.Parameters.AddWithValue("@barcode", barcode)

                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                    dbReturned = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking previous returns: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' --- Total returned so far including database ---
        Dim totalReturned As Integer = sessionReturned + dbReturned

        ' --- Prevent exceeding total purchased ---
        If totalReturned >= qtyPurchased Then
            MessageBox.Show($"Cannot add '{productName}' for return. Already returned maximum quantity ({qtyPurchased}).", "Invalid Return", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Add new row safely ---
        Dim newRowIndex As Integer = dgvreturnitems.Rows.Add()

        With dgvreturnitems.Rows(newRowIndex)
            .Cells("TransactionNumber").Value = transNo
            .Cells("BarcodeID").Value = barcode
            .Cells("ProductName").Value = productName
            .Cells("QuantityPurchased").Value = qtyPurchased
            .Cells("QuantityReturned").Value = 0
            .Cells("TotalReturned").Value = totalReturned
            .Cells("ApprovedBy").Value = SessionData.fullName
            .Cells("Reason").Value = "Wrong Item"
            .Cells("ConditionStatus").Value = "Good"
            .Cells("ReturnedToInventory").Value = "Yes"
        End With


        ' --- Set read-only for TotalReturned column (UI only) ---
        dgvreturnitems.Rows(newRowIndex).Cells("TotalReturned").ReadOnly = True

        ' --- Auto-focus on QuantityReturned cell for input ---
        dgvreturnitems.CurrentCell = dgvreturnitems.Rows(newRowIndex).Cells("QuantityReturned")
        dgvreturnitems.BeginEdit(True)
    End Sub





    ' === PROCESS RETURN ===
    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        ' --- Check if there are items to return ---
        If dgvreturnitems.Rows.Count = 0 Then
            MessageBox.Show("No items to process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Get Transaction Number ---
        Dim transNo As String = txtTransactionNo.Text.Trim()
        If String.IsNullOrWhiteSpace(transNo) Then
            MessageBox.Show("Please enter a valid Transaction Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                Using trans As MySqlTransaction = conn.BeginTransaction()
                    Try
                        For Each row As DataGridViewRow In dgvreturnitems.Rows
                            If row.IsNewRow Then Continue For

                            Dim barcode As String = Convert.ToString(row.Cells("BarcodeID").Value)
                            Dim productName As String = Convert.ToString(row.Cells("ProductName").Value)
                            Dim qtyPurchased As Integer = If(IsDBNull(row.Cells("QuantityPurchased").Value), 0, Convert.ToInt32(row.Cells("QuantityPurchased").Value))
                            Dim qtyReturned As Integer = If(IsDBNull(row.Cells("QuantityReturned").Value), 0, Convert.ToInt32(row.Cells("QuantityReturned").Value))
                            Dim reason As String = Convert.ToString(row.Cells("Reason").Value)
                            Dim condition As String = Convert.ToString(row.Cells("ConditionStatus").Value)
                            Dim returnedInv As String = Convert.ToString(row.Cells("ReturnedToInventory").Value)

                            ' --- Validations ---
                            If String.IsNullOrEmpty(barcode) Then
                                Throw New Exception("Missing barcode for one of the return items.")
                            End If
                            If qtyReturned <= 0 Then
                                Throw New Exception($"Invalid return quantity for product '{productName}'.")
                            End If
                            If qtyReturned > qtyPurchased Then
                                Throw New Exception($"Return quantity ({qtyReturned}) cannot exceed purchased quantity ({qtyPurchased}) for product '{productName}'.")
                            End If

                            ' --- Insert record into customerreturns ---
                            Using cmd As New MySqlCommand("
                            INSERT INTO customerreturns 
                            (TransactionNumber, BarcodeID, ReturnDate, QuantityPurchased, QuantityReturned, Reason, ConditionStatus, ApprovedBy, ReturnedToInventory) 
                            VALUES (@transNo, @barcode, NOW(), @qtyPurchased, @qtyReturned, @reason, @condition, @approvedBy, @returnedInv)", conn, trans)

                                cmd.Parameters.AddWithValue("@transNo", transNo)
                                cmd.Parameters.AddWithValue("@barcode", barcode)
                                cmd.Parameters.AddWithValue("@qtyPurchased", qtyPurchased)
                                cmd.Parameters.AddWithValue("@qtyReturned", qtyReturned)
                                cmd.Parameters.AddWithValue("@reason", reason)
                                cmd.Parameters.AddWithValue("@condition", condition)
                                cmd.Parameters.AddWithValue("@approvedBy", SessionData.fullName)
                                cmd.Parameters.AddWithValue("@returnedInv", returnedInv)
                                cmd.ExecuteNonQuery()
                            End Using
                            ' --- Update deliveries remaining quantity AND inventory if applicable ---
                            If returnedInv.Equals("Yes", StringComparison.OrdinalIgnoreCase) _
   OrElse (reason = "Wrong Item" AndAlso condition = "Good") Then

                                ' === Update deliveries.RemainingQty ===
                                ' We only use BarcodeID because sales transaction numbers don’t exist in deliveries.
                                Using cmdDel As New MySqlCommand("
        UPDATE deliveries  
        SET RemainingQty = RemainingQty + @qtyReturned 
        WHERE BarcodeID = @barcode 
        ORDER BY ReceiveDate DESC 
        LIMIT 1", conn, trans)

                                    cmdDel.Parameters.AddWithValue("@qtyReturned", qtyReturned)
                                    cmdDel.Parameters.AddWithValue("@barcode", barcode)
                                    cmdDel.ExecuteNonQuery()
                                End Using

                                ' === Update inventory ===
                                Using cmdInv As New MySqlCommand("
        UPDATE inventory  
        SET quantity = quantity + @qtyReturned  
        WHERE BarcodeID = @barcode", conn, trans)

                                    cmdInv.Parameters.AddWithValue("@qtyReturned", qtyReturned)
                                    cmdInv.Parameters.AddWithValue("@barcode", barcode)
                                    cmdInv.ExecuteNonQuery()
                                End Using
                            End If


                            ' --- Log activity ---
                            Dim actionDesc As String =
                            $"Returned item: {productName} | Qty Returned: {qtyReturned} | Reason: {reason} | Condition: {condition} | Returned to Inventory: {returnedInv}"
                            LogAuditTrail(SessionData.role, SessionData.fullName, actionDesc)
                        Next

                        trans.Commit()
                        MessageBox.Show("Return successfully processed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dgvreturnitems.Rows.Clear()

                    Catch ex As Exception
                        trans.Rollback()
                        MessageBox.Show("Transaction failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub









    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === DEFAULT COLORS & IMAGES ===
        Guna2Button1.FillColor = ColorTranslator.FromHtml("#1D3A70")
        Guna2Button1.ForeColor = Color.White
        Guna2Button1.Image = My.Resources.icons8_return_30_normal  ' normal icon

        Guna2Button2.FillColor = ColorTranslator.FromHtml("#1D3A70")
        Guna2Button2.ForeColor = Color.White
        Guna2Button2.Image = My.Resources.icons8_return_product_35_normal ' normal
        ' 
        btnLatestTransction.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnLatestTransction.ForeColor = Color.White
        btnLatestTransction.Image = My.Resources.icons8_transaction_30_normal ' normal icon

        'btnSort.FillColor = ColorTranslator.FromHtml("#1D3A70")
        'btnSort.ForeColor = Color.White
        'btnSort.Image = My.Resources.icons8_alphabetical_sorting_normal ' normal icon


        ' === HOVER EFFECTS FOR btnAddnewUsar ===
        AddHandler Guna2Button1.MouseEnter, Sub()
                                                Guna2Button1.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                Guna2Button1.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                Guna2Button1.Image = My.Resources.icons8_return_30_hindi  ' hover icon
                                            End Sub

        AddHandler Guna2Button1.MouseLeave, Sub()
                                                Guna2Button1.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                Guna2Button1.ForeColor = Color.White
                                                Guna2Button1.Image = My.Resources.icons8_return_30_normal ' back to normal
                                            End Sub


        AddHandler Guna2Button2.MouseEnter, Sub()
                                                Guna2Button2.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                Guna2Button2.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                Guna2Button2.Image = My.Resources.icons8_return_product_35_hindi ' hover icon
                                            End Sub

        AddHandler Guna2Button2.MouseLeave, Sub()
                                                Guna2Button2.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                Guna2Button2.ForeColor = Color.White
                                                Guna2Button2.Image = My.Resources.icons8_return_product_35_normal  ' normal icon
                                            End Sub


        AddHandler btnLatestTransction.MouseEnter, Sub()
                                                       btnLatestTransction.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                       btnLatestTransction.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                       btnLatestTransction.Image = My.Resources.icons8_transaction_30_hindi ' hover icon
                                                   End Sub

        AddHandler btnLatestTransction.MouseLeave, Sub()
                                                       btnLatestTransction.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                       btnLatestTransction.ForeColor = Color.White
                                                       btnLatestTransction.Image = My.Resources.icons8_transaction_30_normal ' normal icon
                                                   End Sub


        ' === OPTIONAL: CENTER THE FORM ON SCREEN ===
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub


    ' === CLOSE PANEL ===
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Guna2ShadowPanel1.Visible = False
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Guna2ShadowPanel1.Visible = True
    End Sub

    ' === HANDLE CELL CLICKS IN RETURN DGV ===
    Private Sub dgvreturnitems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvreturnitems.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        ' === Make Return Qty editable ===
        If dgvreturnitems.Columns(e.ColumnIndex).Name = "QuantityReturned" Then
            Dim qtyPurchased As Integer = Convert.ToInt32(dgvreturnitems.Rows(e.RowIndex).Cells("QuantityPurchased").Value)

            dgvreturnitems.CurrentCell = dgvreturnitems.Rows(e.RowIndex).Cells(e.ColumnIndex)
            dgvreturnitems.BeginEdit(True)

            ' Attach KeyPress handler to allow only numbers
            Dim tb As TextBox = TryCast(dgvreturnitems.EditingControl, TextBox)
            If tb IsNot Nothing Then
                RemoveHandler tb.KeyPress, AddressOf QuantityReturned_KeyPress
                AddHandler tb.KeyPress, Sub(sender2, e2)
                                            ' Allow only digits and control keys
                                            If Not Char.IsControl(e2.KeyChar) AndAlso Not Char.IsDigit(e2.KeyChar) Then
                                                e2.Handled = True
                                            End If
                                        End Sub
            End If
        End If

        ' === Handle Cancel button ===
        If dgvreturnitems.Columns(e.ColumnIndex).Name = "Cancel" Then
            dgvreturnitems.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    ' === Validate after editing ===
    Private Sub dgvreturnitems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvreturnitems.CellEndEdit
        If e.RowIndex < 0 Then Exit Sub
        If dgvreturnitems.Columns(e.ColumnIndex).Name = "QuantityReturned" Then
            Dim qtyPurchased As Integer = Convert.ToInt32(dgvreturnitems.Rows(e.RowIndex).Cells("QuantityPurchased").Value)
            Dim qtyReturnedCell As DataGridViewCell = dgvreturnitems.Rows(e.RowIndex).Cells("QuantityReturned")
            Dim qtyReturned As Integer

            If Integer.TryParse(qtyReturnedCell.Value?.ToString(), qtyReturned) Then
                If qtyReturned > qtyPurchased Then
                    MessageBox.Show($"Return quantity cannot exceed purchased quantity ({qtyPurchased}).", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    qtyReturnedCell.Value = qtyPurchased
                    dgvreturnitems.CurrentCell = qtyReturnedCell
                    dgvreturnitems.BeginEdit(True)
                ElseIf qtyReturned < 0 Then
                    MessageBox.Show("Return quantity cannot be negative.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    qtyReturnedCell.Value = 0
                    dgvreturnitems.CurrentCell = qtyReturnedCell
                    dgvreturnitems.BeginEdit(True)
                End If
            Else
                qtyReturnedCell.Value = 0
            End If
        End If
    End Sub

    ' --- Prevent typing in QuantityReturned and allow only numeric input ---
    Private Sub dgvreturnitems_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvreturnitems.EditingControlShowing
        If dgvreturnitems.CurrentCell.ColumnIndex = dgvreturnitems.Columns("QuantityReturned").Index Then
            Dim tb As TextBox = TryCast(e.Control, TextBox)
            If tb IsNot Nothing Then
                ' Remove any existing handlers to avoid multiple subscriptions
                RemoveHandler tb.KeyPress, AddressOf QuantityReturned_KeyPress
                ' Add handler
                AddHandler tb.KeyPress, AddressOf QuantityReturned_KeyPress
            End If
        End If
    End Sub

    ' --- KeyPress handler to allow only numbers ---
    Private Sub QuantityReturned_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Allow only digits and control keys (like backspace)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
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
                    cmd.Parameters.AddWithValue("@Form", "Return & Refund")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim viewreturnrefund As New ViewRefund
        viewreturnrefund.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub


    Private cmsLatestTransactions As New ContextMenuStrip()

    Private Sub btnLatestTransaction_Click(sender As Object, e As EventArgs) Handles btnLatestTransction.Click
        cmsLatestTransactions.Items.Clear()

        Using conn As New MySqlConnection(connectionstring)
            Try
                conn.Open()

                Dim query As String = "
                SELECT s.ReceiptNo, s.TransactionNo, s.Cashier, s.SaleDate, 
                       si.ProductName, si.Quantity, si.TotalPrice
                FROM sales s
                INNER JOIN sales_items si ON s.SaleID = si.SaleID
                WHERE DATE(s.SaleDate) = CURDATE()
                ORDER BY s.SaleDate DESC, s.TransactionNo
            "

                Dim cmd As New MySqlCommand(query, conn)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                Dim lastTransaction As String = ""
                Dim transactionText As String = ""
                Dim currentReceipt As String = ""

                While reader.Read()
                    Dim txnNo As String = reader("TransactionNo").ToString()
                    Dim receiptNo As String = reader("ReceiptNo").ToString()

                    ' Kapag bagong transaction, i-add ang previous sa dropdown
                    If txnNo <> lastTransaction Then
                        If transactionText <> "" Then
                            Dim menuItem As New ToolStripMenuItem(transactionText)
                            menuItem.Tag = currentReceipt ' I-store ang ReceiptNo para magamit sa click
                            AddHandler menuItem.Click, AddressOf TransactionItem_Click
                            cmsLatestTransactions.Items.Add(menuItem)
                        End If

                        lastTransaction = txnNo
                        currentReceipt = receiptNo
                        transactionText = $"#{txnNo} | Cashier: {reader("Cashier")} | {CDate(reader("SaleDate")).ToString("MM/dd/yyyy hh:mm tt")}" & vbCrLf
                    End If

                    ' Idagdag bawat product sa transaction
                    transactionText &= $"   - {reader("ProductName")} x{reader("Quantity")} ₱{reader("TotalPrice")}" & vbCrLf
                End While

                ' Add last transaction
                If transactionText <> "" Then
                    Dim menuItem As New ToolStripMenuItem(transactionText)
                    menuItem.Tag = currentReceipt
                    AddHandler menuItem.Click, AddressOf TransactionItem_Click
                    cmsLatestTransactions.Items.Add(menuItem)
                End If

                reader.Close()

                ' Ipakita ang dropdown sa button
                cmsLatestTransactions.Show(btnLatestTransction, New Point(0, btnLatestTransction.Height))

            Catch ex As Exception
                MessageBox.Show("Error loading transactions: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub TransactionItem_Click(sender As Object, e As EventArgs)
        Dim selectedItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim receiptNo As String = selectedItem.Tag.ToString()

        ' I-set ang receipt textbox kung meron
        txtReceipt.Text = receiptNo

        ' Tawagin ang function para mag-load ng products
        LoadProductsByReceipt(receiptNo)
    End Sub



End Class
