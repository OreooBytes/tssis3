Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms
Imports System.Drawing.Drawing2D

Public Class ReturnItem

    Private Const CornerRadius As Integer = 10

    ' -------------------------
    ' FORM LOAD
    ' -------------------------
    Private Sub ReturnItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2Panel2.Visible = False
        LoadDeliveries()
        ' Setup DGVs
        SetupDgvReturnItems()
        ApplyRoundedCorners()
        SetupButtonHoverEffects()
        SetupDgvReturnItemss()

        ' Theme
        BackColor = ColorTranslator.FromHtml("#0B2447")
        btnProcessReturn.ForeColor = ColorTranslator.FromHtml("#0B2447")
        btnProcessReturn.FillColor = ColorTranslator.FromHtml("#FFD93D")
        btnReturn.FillColor = ColorTranslator.FromHtml("#1D3A70")
        Guna2Button1.FillColor = ColorTranslator.FromHtml("#1D3A70")

        ' ===== DataGridView (Regular) =====
        dgvreturnitems.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== TextBox (Regular) =====
        txtbatchno.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== Buttons (Bold) =====
        btnProcessReturn.Font = New Font("Outfit", 17, FontStyle.Bold)
        btnReturn.Font = New Font("Outfit", 9, FontStyle.Bold)
        Guna2Button1.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== Labels (Bold) =====
        lblSelectBatchforReturn.Font = New Font("Outfit", 11, FontStyle.Bold)


        Guna2Panel2.Left = (Me.ClientSize.Width - Guna2Panel2.Width) \ 2
        Guna2Panel2.Top = (Me.ClientSize.Height - Guna2Panel2.Height) \ 2

    End Sub

    ' -------------------------
    ' GENERATE RETURN NO
    ' -------------------------
    Private Function GenerateReturnNo() As String
        Dim newReturnNo As String = "RTN-00001"
        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                Dim query As String = "SELECT IFNULL(MAX(ReturnID),0) FROM returnitems"
                Using cmd As New MySqlCommand(query, conn)
                    Dim lastId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    newReturnNo = "RTN-" & (lastId + 1).ToString("D5")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating Return No: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return newReturnNo
    End Function

    ' -------------------------
    ' SETUP DGV
    ' -------------------------
    Private Sub SetupDgvReturnItems()
        dgvreturnitems.Columns.Clear()

        ' --- Product info ---
        dgvreturnitems.Columns.Add("BarcodeID", "Barcode ID")
        dgvreturnitems.Columns.Add("ProductName", "Product Name")
        dgvreturnitems.Columns.Add("UnitPrice", "Unit Price")
        dgvreturnitems.Columns.Add("TotalPrice", "Total Price")
        dgvreturnitems.Columns.Add("RemainingQty", "Remaining Qty")
        dgvreturnitems.Columns.Add("QuantityReturned", "Return Qty") ' matches DB column

        ' --- Reason ComboBox column with default "Others" ---
        Dim colReason As New DataGridViewComboBoxColumn()
        colReason.Name = "Reason"
        colReason.HeaderText = "Reason"
        colReason.Items.AddRange("Damaged", "Expired", "Wrong Item", "Others")
        dgvreturnitems.Columns.Add(colReason)

        ' Set default value for newly added rows automatically
        AddHandler dgvreturnitems.RowsAdded, Sub(sender As Object, e As DataGridViewRowsAddedEventArgs)
                                                 For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
                                                     dgvreturnitems.Rows(i).Cells("Reason").Value = "Others"
                                                 Next
                                                 ' Autofocus to "Return Qty" in first row
                                                 If dgvreturnitems.Rows.Count > 0 Then
                                                     dgvreturnitems.CurrentCell = dgvreturnitems.Rows(0).Cells("QuantityReturned")
                                                     dgvreturnitems.BeginEdit(True)
                                                 End If
                                             End Sub

        ' --- Cancel Button ---
        Dim cancelCol As New DataGridViewImageColumn With {
        .Name = "Cancel",
        .HeaderText = "Action",
        .Image = My.Resources.icons8_cancel_35,
        .ImageLayout = DataGridViewImageCellLayout.Zoom,
        .Width = 35
    }
        ' Center the header text
        cancelCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvreturnitems.Columns.Add(cancelCol)

        ' --- Styling ---
        With dgvreturnitems
            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .ColumnHeadersHeight = 35
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        End With
    End Sub

    Private Sub setupdgvdeliverylist()
        Dim btnSelect As New DataGridViewButtonColumn()
        btnSelect.Name = "SelectItem"
        btnSelect.HeaderText = "Action"
        btnSelect.Text = "Select"
        btnSelect.UseColumnTextForButtonValue = True
        btnSelect.Width = 70
        btnSelect.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvdeliveries.Columns.Add(btnSelect)

    End Sub

    ' -------------------------
    Private Sub LoadDeliveryDetails(batchNo As String)
        Dim conn As MySqlConnection = Openconnection()
        If conn Is Nothing Then Exit Sub

        Try
            Dim query As String = "
                SELECT BarcodeID, ProductName, UnitPrice, Quantity, RemainingQty
                FROM deliveries
                WHERE BatchNumber = @BatchNo;
            "

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@BatchNo", batchNo)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    dgvreturnitems.Rows.Clear()
                    While reader.Read()
                        Dim unitPrice As Decimal = reader.GetDecimal("UnitPrice")
                        Dim qty As Integer = reader.GetInt32("Quantity")
                        Dim totalPrice As Decimal = unitPrice * qty
                        Dim remainingQty As Integer = reader.GetInt32("RemainingQty")




                        dgvreturnitems.Rows.Add(
                            reader("BarcodeID").ToString(),
                            reader("ProductName").ToString(),
                            unitPrice.ToString("N2"),
                            totalPrice.ToString("N2"),
                            remainingQty,
                            0, ' default return qty
                            "Damaged" ' default Reason
                        )


                    End While
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(" Error fetching delivery details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgvreturnitems_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvreturnitems.CellValidating
        If dgvreturnitems.Columns(e.ColumnIndex).Name = "QuantityReturned" Then
            Dim input As String = e.FormattedValue.ToString()
            Dim val As Integer
            If Not Integer.TryParse(input, val) OrElse val < 0 Then
                e.Cancel = True
                MessageBox.Show("Return quantity must be greater than zero.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Return
            End If

            Dim remainingQty As Integer = Convert.ToInt32(dgvreturnitems.Rows(e.RowIndex).Cells("RemainingQty").Value)
            If val > remainingQty Then
                e.Cancel = True
                MessageBox.Show($"Return quantity cannot exceed the remaining quantity of {remainingQty}.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If
        End If
    End Sub

    ' -------------------------
    ' CREATE COMBOBOX COLUMN
    ' -------------------------
    Private Function CreateComboColumn(name As String, header As String, items As String()) As DataGridViewComboBoxColumn
        Dim col As New DataGridViewComboBoxColumn With {
            .Name = name,
            .HeaderText = header
        }
        col.Items.AddRange(items)
        Return col
    End Function

    ' -------------------------
    ' ROUNDED CORNERS
    ' -------------------------
    Private Sub ApplyRoundedCorners()
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90)
        path.AddLine(CornerRadius, 0, Me.Width - CornerRadius, 0)
        path.AddArc(Me.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90)
        path.AddLine(Me.Width, CornerRadius, Me.Width, Me.Height - CornerRadius)
        path.AddArc(Me.Width - CornerRadius, Me.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90)
        path.AddLine(Me.Width - CornerRadius, Me.Height, CornerRadius, Me.Height)
        path.AddArc(0, Me.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90)
        path.CloseFigure()
        Me.Region = New Region(path)
    End Sub

    ' -------------------------
    ' PROCESS RETURN
    ' -------------------------
    Private Sub btnProcessReturn_Click(sender As Object, e As EventArgs) Handles btnProcessReturn.Click
        If dgvreturnitems.Rows.Count = 0 Then
            MessageBox.Show("No items to return.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                Dim trans As MySqlTransaction = conn.BeginTransaction()

                Try
                    For Each row As DataGridViewRow In dgvreturnitems.Rows
                        If row.IsNewRow Then Continue For

                        Dim batchNo As String = txtbatchno.Text.Trim()
                        Dim barcode As String = row.Cells("BarcodeID").Value.ToString()
                        Dim qtyReturned As Integer = Integer.Parse(row.Cells("QuantityReturned").Value.ToString())
                        Dim reason As String = If(row.Cells("Reason").Value, "")

                        ' --- Validate positive quantity ---
                        If qtyReturned <= 0 Then
                            Throw New Exception($"Return quantity must be greater than 0 for product {barcode}.")
                        End If

                        ' --- Get delivery info ---
                        Dim deliveryId As Integer
                        Dim supplierId As Integer
                        Dim remainingQty As Integer
                        Dim productName As String = ""

                        Using cmd As New MySqlCommand("
                        SELECT d.id, d.SupplierID, d.RemainingQty, p.ProductName
                        FROM deliveries d
                        INNER JOIN product p ON d.BarcodeID = p.BarcodeID
                        WHERE d.BatchNumber=@BatchNo AND d.BarcodeID=@Barcode
                        LIMIT 1", conn, trans)

                            cmd.Parameters.AddWithValue("@BatchNo", batchNo)
                            cmd.Parameters.AddWithValue("@Barcode", barcode)

                            Using reader = cmd.ExecuteReader()
                                If reader.Read() Then
                                    deliveryId = reader.GetInt32("id")
                                    supplierId = reader.GetInt32("SupplierID")
                                    remainingQty = reader.GetInt32("RemainingQty")
                                    productName = reader.GetString("ProductName")
                                Else
                                    Throw New Exception("Delivery not found for product: " & barcode)
                                End If
                            End Using
                        End Using

                        ' --- Validate return qty against remainingQty ---
                        If qtyReturned > remainingQty Then
                            Throw New Exception($"Return quantity ({qtyReturned}) exceeds remaining quantity ({remainingQty}) for product {barcode}.")
                        End If

                        ' --- Insert into returnitems ---
                        Using cmd As New MySqlCommand("
                        INSERT INTO returnitems
                            (DeliveryID, SupplierID, BarcodeID, ReturnDate, QuantityReturned, Reason)
                        VALUES
                            (@DeliveryID, @SupplierID, @BarcodeID, CURDATE(), @QuantityReturned, @Reason)", conn, trans)

                            cmd.Parameters.AddWithValue("@DeliveryID", deliveryId)
                            cmd.Parameters.AddWithValue("@SupplierID", supplierId)
                            cmd.Parameters.AddWithValue("@BarcodeID", barcode)
                            cmd.Parameters.AddWithValue("@QuantityReturned", qtyReturned)
                            cmd.Parameters.AddWithValue("@Reason", reason)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' --- Update remaining qty in deliveries ---
                        Using updateCmd As New MySqlCommand("
                        UPDATE deliveries
                        SET RemainingQty = RemainingQty - @ReturnQuantity
                        WHERE id = @DeliveryID", conn, trans)

                            updateCmd.Parameters.AddWithValue("@ReturnQuantity", qtyReturned)
                            updateCmd.Parameters.AddWithValue("@DeliveryID", deliveryId)
                            updateCmd.ExecuteNonQuery()
                        End Using

                        ' --- Update inventory quantity ---
                        Dim returnedInv As String = "No"
                        Using updateInvCmd As New MySqlCommand("
                        UPDATE inventory
                        SET quantity = quantity - @ReturnQuantity
                        WHERE BarcodeID = @BarcodeID AND quantity >= @ReturnQuantity", conn, trans)

                            updateInvCmd.Parameters.AddWithValue("@ReturnQuantity", qtyReturned)
                            updateInvCmd.Parameters.AddWithValue("@BarcodeID", barcode)
                            Dim rowsAffected As Integer = updateInvCmd.ExecuteNonQuery()

                            If rowsAffected = 0 Then
                                Throw New Exception("Inventory does not have enough stock for product " & barcode)
                            Else
                                returnedInv = "Yes"
                            End If
                        End Using

                        ' --- Log Audit Trail ---
                        Dim actionDesc As String = $"Returned item: {productName} | Qty Returned: {qtyReturned} | Reason: {reason} | Returned to Inventory: {returnedInv}"
                        LogAuditTrail(SessionData.role, SessionData.fullName, actionDesc)

                    Next

                    trans.Commit()
                    MessageBox.Show("Return successfully processed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvreturnitems.Rows.Clear()
                    txtbatchno.Clear()

                Catch ex As Exception
                    trans.Rollback()
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    ' -------------------------
    ' REMOVE ITEM
    ' -------------------------
    Private Sub dgvreturnitems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvreturnitems.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvreturnitems.Columns(e.ColumnIndex).Name = "Cancel" Then
            dgvreturnitems.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub


    ' -------------------------
    ' BATCHNO FILTER
    ' -------------------------
    Private Sub txtbatchno_TextChanged(sender As Object, e As EventArgs) Handles txtbatchno.TextChanged
        If txtbatchno.Text.Trim() <> "" Then
            LoadDeliveryDetails(txtbatchno.Text.Trim())
        Else
            dgvreturnitems.Rows.Clear()
        End If

        Guna2Panel2.Visible = False
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?",
            "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()

        End If
    End Sub

    Private Sub returnitem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SetupButtonHoverEffects()

        btnReturn.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnReturn.ForeColor = Color.White
        btnReturn.Image = My.Resources.icons8_return_30_normal ' normal icon

        Guna2Button1.FillColor = ColorTranslator.FromHtml("#1D3A70")
        Guna2Button1.ForeColor = Color.White
        Guna2Button1.Image = My.Resources.icons8_successful_delivery_30 ' normal icon

        AddHandler btnReturn.MouseEnter, Sub()
                                             btnReturn.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                             btnReturn.ForeColor = ColorTranslator.FromHtml("#1D3A70")
                                             btnReturn.Image = My.Resources.icons8_return_30_hindi
                                         End Sub
        AddHandler btnReturn.MouseLeave, Sub()
                                             btnReturn.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                             btnReturn.ForeColor = Color.White
                                             btnReturn.Image = My.Resources.icons8_return_30_normal
                                         End Sub
        AddHandler Guna2Button1.MouseEnter, Sub()
                                                Guna2Button1.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                Guna2Button1.ForeColor = ColorTranslator.FromHtml("#1D3A70")
                                                Guna2Button1.Image = My.Resources.icons8_successful_delivery_30main
                                            End Sub
        AddHandler Guna2Button1.MouseLeave, Sub()
                                                Guna2Button1.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                Guna2Button1.ForeColor = Color.White
                                                Guna2Button1.Image = My.Resources.icons8_successful_delivery_30
                                            End Sub
    End Sub

    Private viewreturntFormInstance As ViewReturn = Nothing
    Private Sub dgvdeliveries_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdeliveries.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        If dgvdeliveries.Columns(e.ColumnIndex).Name = "SelectItem" Then

            Dim barcode As String = dgvdeliveries.Rows(e.RowIndex).Cells("BarcodeID").Value.ToString()
            Dim product As String = dgvdeliveries.Rows(e.RowIndex).Cells("ProductName").Value.ToString()
            Dim remainingQty As Integer = CInt(dgvdeliveries.Rows(e.RowIndex).Cells("RemainingQty").Value)
            Dim batchNo As String = dgvdeliveries.Rows(e.RowIndex).Cells("BatchNumber").Value.ToString()
            Dim unitPrice As Decimal = 0

            ' 🛑 Prevent duplicate selection
            For Each row As DataGridViewRow In dgvreturnitems.Rows
                If row.Cells("BarcodeID").Value.ToString() = barcode Then
                    MessageBox.Show("This item has already been added.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            ' ✅ Fetch unit price from database
            Try
                Using conn As MySqlConnection = Module1.Openconnection()
                    Dim cmd As New MySqlCommand("
                    SELECT UnitPrice 
                    FROM deliveries 
                    WHERE BarcodeID = @BarcodeID AND BatchNumber = @BatchNumber LIMIT 1", conn)

                    cmd.Parameters.AddWithValue("@BarcodeID", barcode)
                    cmd.Parameters.AddWithValue("@BatchNumber", batchNo)

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then unitPrice = Convert.ToDecimal(result)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading unit price: " & ex.Message)
            End Try

            ' ✅ Compute total price (unit * remaining)
            Dim totalPrice As Decimal = unitPrice * remainingQty

            ' ➕ Add to return items table
            dgvreturnitems.Rows.Add(
            barcode,
            product,
            unitPrice.ToString("N2"),
            totalPrice.ToString("N2"),
            remainingQty,
            0,               ' Return qty default
            "Others"        ' Default reason
        )

            ' Auto-set batch number for form if needed
            txtbatchno.Text = batchNo
        End If

        Guna2Panel2.Visible = False
    End Sub

    Private Sub LoadDeliveries()
        dgvdeliveries.Columns.Clear()
        dgvdeliveries.Rows.Clear()

        ' --- Columns to display ---
        dgvdeliveries.Columns.Add("BarcodeID", "Barcode ID")
        dgvdeliveries.Columns.Add("ProductName", "Product Name")
        dgvdeliveries.Columns.Add("RemainingQty", "Remaining Qty")
        dgvdeliveries.Columns.Add("BatchNumber", "Batch Number")
        dgvdeliveries.Columns.Add("Supplier", "Supplier") ' <-- NEW column for supplier/company name

        ' --- Add Select button ---
        Dim btnSelect As New DataGridViewButtonColumn()
        btnSelect.Name = "SelectItem"
        btnSelect.HeaderText = ""
        btnSelect.Text = "Select"
        btnSelect.UseColumnTextForButtonValue = True
        btnSelect.Width = 60
        dgvdeliveries.Columns.Add(btnSelect)

        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                Dim query As String = "
            SELECT d.BarcodeID, d.ProductName, d.RemainingQty, d.BatchNumber, s.CompanyName
            FROM deliveries d
            INNER JOIN supplier s ON d.SupplierID = s.SupplierID
            WHERE d.RemainingQty > 0;
            "

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            dgvdeliveries.Rows.Add(
                            reader("BarcodeID").ToString(),
                            reader("ProductName").ToString(),
                            reader("RemainingQty").ToString(),
                            reader("BatchNumber").ToString(),
                            reader("CompanyName").ToString() ' supplier/company name
                        )
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading deliveries: " & ex.Message)
        End Try

        ' --- Optional styling ---
        dgvdeliveries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvdeliveries.ColumnHeadersHeight = 35
        dgvdeliveries.EnableHeadersVisualStyles = False
        dgvdeliveries.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
        dgvdeliveries.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    End Sub



    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Try
            ' Check if the form is already open
            If viewreturntFormInstance Is Nothing OrElse viewreturntFormInstance.IsDisposed Then
                viewreturntFormInstance = New ViewReturn() ' Corrected instantiation
                viewreturntFormInstance.Show() ' Use ShowDialog() for modal if needed
            Else
                ' Bring existing form to front
                viewreturntFormInstance.BringToFront()
                viewreturntFormInstance.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening ViewReturn: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Guna2Panel2.Visible = True


    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Guna2Panel2.Visible = False
    End Sub

    Public Sub SetupDgvReturnItemss()
        With dgvdeliveries
            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .ColumnHeadersHeight = 35
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .EnableHeadersVisualStyles = False
            .ReadOnly = True
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            ' === Disable resizing for columns and rows ===
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
        End With
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
                    cmd.Parameters.AddWithValue("@Form", "Return to Supplier")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
