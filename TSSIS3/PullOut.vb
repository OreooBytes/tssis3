Imports System.Data
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class PullOut


    Private Const CornerRadius As Integer = 10 ' fixed radius

    Private Sub PullOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === Style panel ===
        With Guna2Panel2
            .FillColor = Color.White
            .BorderColor = ColorTranslator.FromHtml("#D3D3D3")
            .BorderThickness = 2
            .BorderRadius = 10
            .BringToFront()
        End With

        ' === Setup Reason ComboBox ===
        cmbReason.Items.Clear()
        cmbReason.Items.AddRange(New String() {"Expired", "Other"})
        cmbReason.DropDownStyle = ComboBoxStyle.DropDownList
        cmbReason.SelectedIndex = 0

        BackColor = ColorTranslator.FromHtml("#0B2447")

        ' I-center ang MainPanel sa form
        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2


        Label1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label2.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label3.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label4.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label5.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label6.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label7.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label8.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblPullOutDateValue.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblPulledByValue.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblExpirationDateValue.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblRemainingQtyValue.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblSupplierValue.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblProductNameValue.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblBarcodeValue.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblBatchNumberValue.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label9.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label10.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnPullOut.Font = New Font("Outfit", 9, FontStyle.Bold)

        ApplyRoundedCorners()

        lblPullOutDateValue.Text = DateTime.Now.ToString("MMMM dd, yyyy  hh:mm tt")

    End Sub


    ' === Apply Rounded Corners ===
    Private Sub ApplyRoundedCorners()
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


    ' Save Pull Out
    Private Sub btnPullOut_Click(sender As Object, e As EventArgs) Handles btnPullOut.Click
        Dim batchNumber As String = lblBatchNumberValue.Text.Trim()
        Dim barcode As String = lblBarcodeValue.Text.Trim()
        Dim qty As Integer
        Dim reason As String = If(cmbReason.SelectedItem IsNot Nothing, cmbReason.SelectedItem.ToString(), "").Trim()

        ' === VALIDATIONS ===
        If String.IsNullOrWhiteSpace(batchNumber) Then
            MessageBox.Show("No batch number selected. Please select an item first.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(barcode) Then
            MessageBox.Show("No barcode found. Please select a valid product.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not Integer.TryParse(txtPullQty.Text.Trim(), qty) OrElse qty <= 0 Then
            MessageBox.Show("Please enter a valid pull-out quantity greater than zero.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPullQty.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(reason) Then
            MessageBox.Show("Please select a valid reason for pulling out the item.", "Missing Reason", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbReason.DroppedDown = True
            Return
        End If

        ' Determine expiration date
        Dim expDate As Object
        If String.IsNullOrWhiteSpace(lblExpirationDateValue.Text) OrElse lblExpirationDateValue.Text = "No Expiration" Then
            expDate = "0000-00-00"
        Else
            expDate = CDate(lblExpirationDateValue.Text)
        End If

        ' === DATABASE OPERATION ===
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' 🧮 Check Available Quantity before proceeding
                Dim availableQty As Integer = 0
                Using cmdCheck As New MySqlCommand("SELECT Quantity FROM inventory WHERE BarcodeID=@barcode", conn)
                    cmdCheck.Parameters.AddWithValue("@barcode", barcode)
                    Dim result = cmdCheck.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        availableQty = Convert.ToInt32(result)
                    End If
                End Using

                ' 🚫 If requested qty > available qty, stop the process
                If qty > availableQty Then
                    MessageBox.Show($"Insufficient stock! Available quantity: {availableQty}.", "Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtPullQty.Focus()
                    Return
                End If

                ' === TRANSACTION START ===
                Using trans = conn.BeginTransaction()
                    Try
                        ' 1️⃣ Insert into pullouts table
                        Using cmd As New MySqlCommand("INSERT INTO pullouts (BatchNumber, BarcodeID, ProductName, Supplier, ExpirationDate, PullOutQuantity, Reason, PulledBy, PullOutDate) VALUES (@batch, @barcode, @product, @supplier, @expdate, @qty, @reason, @pulledby, NOW())", conn, trans)
                            cmd.Parameters.AddWithValue("@batch", batchNumber)
                            cmd.Parameters.AddWithValue("@barcode", barcode)
                            cmd.Parameters.AddWithValue("@product", lblProductNameValue.Text.Trim())
                            cmd.Parameters.AddWithValue("@supplier", lblSupplierValue.Text.Trim())
                            cmd.Parameters.AddWithValue("@expdate", expDate)
                            cmd.Parameters.AddWithValue("@qty", qty)
                            cmd.Parameters.AddWithValue("@reason", reason)
                            cmd.Parameters.AddWithValue("@pulledby", SessionData.fullName)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' 2️⃣ Reduce RemainingQty in deliveries (FIFO)
                        Dim remaining As Integer = qty
                        Using cmdDel As New MySqlCommand("SELECT id, RemainingQty FROM deliveries WHERE BarcodeID=@barcode AND BatchNumber=@batch AND RemainingQty>0 ORDER BY ReceiveDate ASC", conn, trans)
                            cmdDel.Parameters.AddWithValue("@barcode", barcode)
                            cmdDel.Parameters.AddWithValue("@batch", batchNumber)
                            Using reader = cmdDel.ExecuteReader()
                                Dim updates As New List(Of Tuple(Of Integer, Integer))
                                While reader.Read() And remaining > 0
                                    Dim deliveryId As Integer = reader.GetInt32("id")
                                    Dim delQty As Integer = reader.GetInt32("RemainingQty")
                                    Dim deduct As Integer = Math.Min(delQty, remaining)
                                    updates.Add(Tuple.Create(deliveryId, delQty - deduct))
                                    remaining -= deduct
                                End While
                                reader.Close()

                                ' Apply updates
                                For Each upd In updates
                                    Using cmdUpd As New MySqlCommand("UPDATE deliveries SET RemainingQty=@rem WHERE id=@id", conn, trans)
                                        cmdUpd.Parameters.AddWithValue("@rem", upd.Item2)
                                        cmdUpd.Parameters.AddWithValue("@id", upd.Item1)
                                        cmdUpd.ExecuteNonQuery()
                                    End Using
                                Next
                            End Using
                        End Using

                        ' 3️⃣ Reduce Quantity in inventory
                        Using cmdInv As New MySqlCommand("UPDATE inventory SET Quantity = Quantity - @qty WHERE BarcodeID=@barcode", conn, trans)
                            cmdInv.Parameters.AddWithValue("@qty", qty)
                            cmdInv.Parameters.AddWithValue("@barcode", barcode)
                            cmdInv.ExecuteNonQuery()
                        End Using

                        ' ✅ Commit
                        trans.Commit()

                        ' --- AUDIT TRAIL LOG ---
                        Dim actionDesc As String = $"Pulled out item: {lblProductNameValue.Text.Trim()} | Qty: {qty} | Batch: {batchNumber} | Reason: {reason}"
                        LogAuditTrail(SessionData.role, SessionData.fullName, actionDesc)

                        ' --- SUCCESS MESSAGE ---
                        MessageBox.Show("Item successfully pulled out.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Reset fields
                        txtPullQty.Clear()
                        cmbReason.SelectedIndex = -1

                    Catch ex As Exception
                        trans.Rollback()
                        MessageBox.Show("Error during pull out operation: " & ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database connection failed: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                    cmd.Parameters.AddWithValue("@Form", "Pull Out")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPullQty.KeyPress
        ' Allow only digits and control keys (backspace, delete)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub
End Class
