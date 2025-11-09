Imports Guna.UI.WinForms
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D


Public Class inventory


    Private Const CornerRadius As Integer = 10 ' fixed radius

    Private editing As Boolean = False ' Track if editing
    Public Property LoggedInFullName As String

    Private dtInventory As DataTable


    ' ==============================
    ' Form Load
    ' ==============================
    Private Sub inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventoryData()
        Guna2ShadowPanel1.Visible = False

        ' Panel styling
        Guna2Panel1.BorderColor = ColorTranslator.FromHtml("#D3D3D3")
        Guna2Panel1.BorderThickness = 2
        Guna2Panel1.BorderRadius = 5

        ' Buttons styling
        deliveriesbtn.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnDeliveryList.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnReturn.FillColor = ColorTranslator.FromHtml("#1D3A70")

        ' Center shadow panel
        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2

        SetupButtonHoverEffects()

        Timer1.Start()



        ' ==== TextBoxes (Regular) ====
        txtCriticalLevel.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtSearch.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== Labels (Bold) ====
        Label1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label3.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblAlert.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ==== Buttons (Bold) ====
        Guna2Button1.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnUpdate.Font = New Font("Outfit", 10, FontStyle.Bold)
        clearbtn.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnReturn.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnDeliveryList.Font = New Font("Outfit", 9, FontStyle.Bold)
        deliveriesbtn.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ==== DataGridView Font (Regular) ====
        dgvInventoryList.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' Set Timer interval (e.g., 5 seconds)
        Timer1.Interval = 5000
        Timer1.Start()

        ' Load inventory initially
        LoadInventoryData()

        ApplyRoundedCorners2()

    End Sub

    ' ✅ UI Rounded Corners (Keep your design)
    Private Sub ApplyRoundedCorners2()
        Dim path As New GraphicsPath()
        path.StartFigure()

        path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90)
        path.AddLine(CornerRadius, 0, Me.Width - CornerRadius, 0)
        path.AddArc(Me.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90)
        path.AddLine(Me.Width, CornerRadius, Me.Width, Me.Height - CornerRadius)
        path.AddArc(Me.Width - CornerRadius, Me.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90)
        path.AddLine(Me.Width - CornerRadius, Me.Height, CornerRadius, Me.Height)
        path.AddArc(0, Me.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90)
        path.AddLine(0, Me.Height - CornerRadius, 0, CornerRadius)

        path.CloseFigure()
        Me.Region = New Region(path)
        Me.Invalidate()
    End Sub

    ' ==========================
    ' Timer Tick - Auto-refresh
    ' ==========================
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadInventoryData()
    End Sub

    ' ==========================
    ' Unified LoadInventoryData
    ' ==========================
    Private Sub LoadInventoryData()
        Using conn As New MySqlConnection(connectionstring)
            Try
                conn.Open()

                ' ===== Join product table to get RetailPrice (used as UnitPrice), WholesalePrice, CriticalLevel =====
                Dim query As String = "
        SELECT 
            i.id, 
            p.BarcodeID, 
            p.ProductName, 
            i.Quantity, 
            p.RetailPrice AS UnitPrice,
            p.WholesalePrice, 
            p.CriticalLevel
        FROM inventory i
        INNER JOIN product p ON i.BarcodeID = p.BarcodeID
        ORDER BY i.id DESC"

                Using cmd As New MySqlCommand(query, conn)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    dtInventory = dt.Copy()
                    dgvInventoryList.DataSource = dt

                    ' Format UnitPrice column
                    If dgvInventoryList.Columns.Contains("UnitPrice") Then
                        dgvInventoryList.Columns("UnitPrice").DefaultCellStyle.Format = "N2"
                    End If

                    ' Low-stock alert
                    Dim lowStockCount As Integer = dt.AsEnumerable() _
                    .Count(Function(r)
                               Dim qty As Integer = If(IsDBNull(r("Quantity")), 0, Convert.ToInt32(r("Quantity")))
                               Dim critical As Integer = If(IsDBNull(r("CriticalLevel")), 0, Convert.ToInt32(r("CriticalLevel")))
                               Return qty <= critical
                           End Function)
                    PanelAlert.Visible = (lowStockCount > 0)
                    lblAlert.Text = If(lowStockCount > 0, $"Warning: {lowStockCount} item(s) are low in stock!", "")

                    dgvInventoryList.AutoGenerateColumns = False
                    dgvInventoryList.AllowUserToAddRows = False

                    ' ===== Edit/Delete column logic =====
                    If Not dgvInventoryList.Columns.Contains("Edit") Then
                        Dim editCol As New DataGridViewImageColumn()
                        editCol.Name = "Edit"
                        editCol.HeaderText = "Edit"
                        editCol.Image = My.Resources.icons8_edit_mains
                        editCol.ImageLayout = DataGridViewImageCellLayout.Zoom
                        dgvInventoryList.Columns.Add(editCol)
                    End If

                    ' Hide Edit/Delete columns safely
                    If dgvInventoryList.Columns.Contains("Edit") Then dgvInventoryList.Columns("Edit").Visible = False
                    If dgvInventoryList.Columns.Contains("Delete") Then dgvInventoryList.Columns("Delete").Visible = False

                    ' Apply styling
                    SetupDataGrid()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error loading inventory: " & ex.Message)
            End Try
        End Using
    End Sub






    ' ==============================
    ' DataGridView Styling
    ' ==============================
    Private Sub SetupDataGrid()
        With dgvInventoryList
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 30
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .RowTemplate.Height = 30
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill


            ' === Disable resizing for columns and rows ===
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False

            ' Hide ID if exists
            If .Columns.Contains("ID") Then .Columns("ID").Visible = False

            ' Hide Edit/Delete columns safely
            If .Columns.Contains("Edit") Then .Columns("Edit").Visible = False
            If .Columns.Contains("Delete") Then .Columns("Delete").Visible = False
        End With
    End Sub







    ' ==============================
    ' Button Hover Effects
    ' ==============================
    Private Sub SetupButtonHoverEffects()

        deliveriesbtn.FillColor = ColorTranslator.FromHtml("#1D3A70")
        deliveriesbtn.ForeColor = Color.White
        deliveriesbtn.Image = My.Resources.icons8_add_30_normal ' normal icon

        btnDeliveryList.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnDeliveryList.ForeColor = Color.White
        btnDeliveryList.Image = My.Resources.icons8_successful_delivery_30 ' normal icon

        btnReturn.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnReturn.ForeColor = Color.White
        btnReturn.Image = My.Resources.icons8_return_30_normal ' normal icon

        AddHandler deliveriesbtn.MouseEnter, Sub()
                                                 deliveriesbtn.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                 deliveriesbtn.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                 deliveriesbtn.Image = My.Resources.icons8_add_30_hindi
                                             End Sub
        AddHandler deliveriesbtn.MouseLeave, Sub()
                                                 deliveriesbtn.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                 deliveriesbtn.ForeColor = Color.White
                                                 deliveriesbtn.Image = My.Resources.icons8_add_30_normal
                                             End Sub

        AddHandler btnDeliveryList.MouseEnter, Sub()
                                                   btnDeliveryList.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                   btnDeliveryList.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                   btnDeliveryList.Image = My.Resources.icons8_delivery_30
                                               End Sub
        AddHandler btnDeliveryList.MouseLeave, Sub()
                                                   btnDeliveryList.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                   btnDeliveryList.ForeColor = Color.White
                                                   btnDeliveryList.Image = My.Resources.icons8_successful_delivery_30
                                               End Sub
        AddHandler btnReturn.MouseEnter, Sub()
                                             btnReturn.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                             btnReturn.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                             btnReturn.Image = My.Resources.icons8_return_30_hindi
                                         End Sub
        AddHandler btnReturn.MouseLeave, Sub()
                                             btnReturn.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                             btnReturn.ForeColor = Color.White
                                             btnReturn.Image = My.Resources.icons8_return_30_normal
                                         End Sub
    End Sub

    ' ==============================
    ' Edit Row
    ' ==============================
    Private Sub dgvInventoryList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventoryList.CellDoubleClick
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = dgvInventoryList.Rows(e.RowIndex)

        If dgvInventoryList.Columns(e.ColumnIndex).Name = "Edit" Then
            editing = True
            Timer1.Stop()
            txtCriticalLevel.Text = row.Cells("CriticalLevel").Value.ToString()
            dgvInventoryList.ClearSelection()
            row.Selected = True
            Guna2ShadowPanel1.Visible = True
        End If

        ' Delete logic (optional)
    End Sub

    ' ==============================
    ' Update Critical Level
    ' ==============================
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvInventoryList.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a row first using Edit button.")
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvInventoryList.SelectedRows(0)
        Dim id As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)

        ' Validate input
        Dim critLevel As Integer = 10
        If Not String.IsNullOrWhiteSpace(txtCriticalLevel.Text) Then
            If Not Integer.TryParse(txtCriticalLevel.Text, critLevel) Then
                MessageBox.Show("Critical Level must be a number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        ' Update database
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
            Using cmd As New MySqlCommand("
                UPDATE inventory    
                SET CriticalLevel=@critical
                WHERE id=@id", conn)
                cmd.Parameters.AddWithValue("@critical", critLevel)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Log audit trail
        Dim actionDesc As String = $"Updated Critical Level for item: {selectedRow.Cells("ProductName").Value} | New Level: {critLevel}"
        LogAuditTrail(SessionData.role, SessionData.fullName, actionDesc)

        Guna2ShadowPanel1.Visible = False
        MessageBox.Show("Critical Level updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        editing = False
        Timer1.Start()
        LoadInventoryData()
    End Sub

    ' ==============================
    ' Open Deliveries
    ' ==============================
    ' At the class level
    Private deliveriesFormInstance As Deliveries = Nothing

    Private Sub deliveriesbtn_Click(sender As Object, e As EventArgs) Handles deliveriesbtn.Click
        Try
            ' Check if the form is already open
            If deliveriesFormInstance Is Nothing OrElse deliveriesFormInstance.IsDisposed Then
                deliveriesFormInstance = New Deliveries()
                deliveriesFormInstance.LoggedInFullName = SessionData.fullName
                deliveriesFormInstance.Show() ' Use ShowDialog() if you want it modal
            Else
                ' Bring the existing form to front
                deliveriesFormInstance.BringToFront()
                deliveriesFormInstance.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening Deliveries form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' ==============================
    ' Timer Tick
    ' ==============================
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not editing Then LoadInventoryData()
    End Sub

    ' ==============================
    ' Close Panel
    ' ==============================
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Guna2ShadowPanel1.Visible = False
    End Sub

    ' ==============================
    ' Close Form
    ' ==============================
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub

    ' ==============================
    ' Delivery List
    ' ==============================
    ' Class-level variable to track the DeliveryList form
    Private deliveryListFormInstance As DeliveryList = Nothing

    Private Sub btnDeliveryList_Click(sender As Object, e As EventArgs) Handles btnDeliveryList.Click
        Try
            ' Check if the form is already open
            If deliveryListFormInstance Is Nothing OrElse deliveryListFormInstance.IsDisposed Then
                deliveryListFormInstance = New DeliveryList()
                deliveryListFormInstance.Show() ' Use ShowDialog() for modal if needed
            Else
                ' Bring existing form to front
                deliveryListFormInstance.BringToFront()
                deliveryListFormInstance.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening Delivery List: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    cmd.Parameters.AddWithValue("@Form", "Inventories")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private returnFormInstance As ReturnItem = Nothing

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        ' Check kung naka-open na ang form
        If returnFormInstance Is Nothing OrElse returnFormInstance.IsDisposed Then
            returnFormInstance = New ReturnItem()
            returnFormInstance.Show()
        Else
            ' Kung open na, i-activate lang
            returnFormInstance.BringToFront()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' Stop timer temporarily
        Timer1.Stop()

        If dtInventory Is Nothing Then Return

        Dim searchText As String = txtSearch.Text.Trim().ToLower()
        Dim tempTable As DataTable = dtInventory.Clone()

        If String.IsNullOrEmpty(searchText) Then
            ' Show full inventory
            For Each row As DataRow In dtInventory.Rows
                tempTable.ImportRow(row)
            Next
            dgvInventoryList.DataSource = tempTable

            ' Reset row styles
            For Each row As DataGridViewRow In dgvInventoryList.Rows
                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.SelectionBackColor = Color.White
                row.DefaultCellStyle.SelectionForeColor = Color.Black
            Next

            ' Restart timer now that search is cleared
            Timer1.Start()
            Return
        End If

        ' Filter rows
        Dim filteredRows = dtInventory.AsEnumerable().Where(Function(r) _
            r("BarcodeID").ToString().ToLower().Contains(searchText) OrElse
            r("ProductName").ToString().ToLower().Contains(searchText) OrElse
            r("Quantity").ToString().ToLower().Contains(searchText)
        )

        For Each row In filteredRows
            tempTable.ImportRow(row)
        Next

        dgvInventoryList.DataSource = tempTable

        ' Apply highlight
        For Each row As DataGridViewRow In dgvInventoryList.Rows
            row.DefaultCellStyle.BackColor = Color.LightYellow
            row.DefaultCellStyle.SelectionBackColor = Color.Orange
            row.DefaultCellStyle.SelectionForeColor = Color.Black
        Next
    End Sub

    Private Sub PanelAlert_Paint(sender As Object, e As PaintEventArgs)
        ApplyRoundedCorners(Guna2Panel1, 10)
    End Sub
End Class
