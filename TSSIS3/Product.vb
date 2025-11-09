Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class Product

    Private Const CornerRadius As Integer = 10 ' fixed radius


    Private Sub Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize
        Guna2ShadowPanel1.Visible = False ' default to not showing edit/add panel
        SetupProductDataGridView()
        PopulateCategoryComboBox()
        LoadData()
        fillcategory()

        ' Ensure update button visibility
        btnupdate.Visible = False

        Guna2Panel1.BorderColor = ColorTranslator.FromHtml("#D3D3D3") ' light gray
        Guna2Panel1.BorderThickness = 2
        Guna2Panel1.BorderRadius = 5

        Guna2DataGridView1.Font = New Font("Outfit", 8, FontStyle.Regular)

        ' I-center ang MainPanel sa form
        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2

        ApplyRoundedCorners()

        bid.Focus()

        ' ==== DataGridView Font ====
        Guna2DataGridView1.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== TextBoxes Font (Outfit, 9, Regular) ====
        bid.Font = New Font("Outfit", 9, FontStyle.Regular)
        pname.Font = New Font("Outfit", 9, FontStyle.Regular)
        desp.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtSearch.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtMinimumQuantity.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtwholesale.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtretail.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== ComboBox Font (Outfit, 9, Regular) ====
        Catname.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== Labels Font (Outfit, 9, Bold) ====
        Label1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label2.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label3.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label4.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label5.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label6.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label7.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label8.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label10.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label11.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ==== Buttons Font (Outfit, 9, Bold) ====
        addbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        clearbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        btnupdate.Font = New Font("Outfit", 10, FontStyle.Bold)
        btnBrowse.Font = New Font("Outfit", 10, FontStyle.Bold)
        btnAddnew.Font = New Font("Outfit", 9, FontStyle.Bold)

    End Sub



    ' ------------------------- CATEGORIES -------------------------
    Private Sub fillcategory()
        Dim table As New DataTable()
        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                If conn IsNot Nothing Then
                    Using cmd As New MySqlCommand("SELECT CategoryID, CategoryName FROM category", conn)
                        Using adapter As New MySqlDataAdapter(cmd)
                            adapter.Fill(table)
                        End Using
                    End Using
                    Module1.ConnectionClose(conn)
                End If
            End Using

            Catname.DataSource = table
            Catname.DisplayMember = "CategoryName"
            Catname.ValueMember = "CategoryID"
            Catname.SelectedIndex = -1
        Catch ex As MySqlException
            MsgBox("Error loading categories: " & ex.Message)
        End Try
    End Sub

    Private Sub PopulateCategoryComboBox()
        ' This method populates ComboBox Items for backward compatibility (if using simple Items)
        ' If using DataSource above, this may be redundant. Kept to avoid breaking existing usage.
        If Catname.DataSource IsNot Nothing Then Return

        Try
            Using conn As MySqlConnection = Module1.Openconnection()
                If conn IsNot Nothing Then
                    Dim sql As String = "SELECT CategoryName FROM category"
                    Using cmd As New MySqlCommand(sql, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            Catname.Items.Clear()
                            While reader.Read()
                                Dim categoryName As String = reader("CategoryName").ToString()
                                Catname.Items.Add(categoryName)
                            End While
                        End Using
                    End Using
                End If
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' ensure connection closed by Module1 if needed
        End Try
    End Sub

    ' ------------------------- LOAD DATA -------------------------
    Private Sub LoadData()
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                Dim sql As String =
                    "SELECT p.BarcodeID, p.ProductName, c.CategoryName, p.Description, p.Expiration, " &
                    "p.WholesalePrice, p.RetailPrice, p.MinimumWholesaleQuantity, p.CriticalLevel " &
                    "FROM product p LEFT JOIN category c ON p.CategoryID = c.CategoryID"

                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        ' Clear old rows before adding new ones
                        Guna2DataGridView1.Rows.Clear()

                        While reader.Read()
                            Dim bidVal As String = reader("BarcodeID").ToString()
                            Dim pnameVal As String = reader("ProductName").ToString()
                            Dim catnameVal As String = If(IsDBNull(reader("CategoryName")), "No Category", reader("CategoryName").ToString())
                            Dim descpVal As String = If(IsDBNull(reader("Description")), "", reader("Description").ToString())
                            Dim expirationVal As String = If(IsDBNull(reader("Expiration")), "", reader("Expiration").ToString())
                            Dim wholesaleVal As String = If(IsDBNull(reader("WholesalePrice")), "0.00", Convert.ToDecimal(reader("WholesalePrice")).ToString("F2"))
                            Dim retailVal As String = If(IsDBNull(reader("RetailPrice")), "0.00", Convert.ToDecimal(reader("RetailPrice")).ToString("F2"))
                            Dim minQtyVal As String = If(IsDBNull(reader("MinimumWholesaleQuantity")), "0", reader("MinimumWholesaleQuantity").ToString())
                            Dim criticalLevelVal As String = If(IsDBNull(reader("CriticalLevel")), "0", reader("CriticalLevel").ToString())

                            Guna2DataGridView1.Rows.Add(bidVal, pnameVal, catnameVal, descpVal, expirationVal, wholesaleVal, retailVal, minQtyVal, criticalLevelVal)


                        End While
                    End Using
                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show("Error loading data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        pbimage.Image = My.Resources.noprodcutimage
    End Sub


    ' ------------------------- DATAGRIDVIEW SETUP -------------------------
    Private Sub SetupProductDataGridView()
        ' Clear existing columns
        Guna2DataGridView1.Columns.Clear()
        Guna2DataGridView1.AllowUserToAddRows = False
        Guna2DataGridView1.MultiSelect = False

        ' === Visible Data Columns ===
        Guna2DataGridView1.Columns.Add("BarcodeID", "Barcode")
        Guna2DataGridView1.Columns.Add("ProductName", "Product Name")
        Guna2DataGridView1.Columns.Add("CategoryName", "Category")
        Guna2DataGridView1.Columns.Add("Description", "Description")
        Guna2DataGridView1.Columns.Add("Expiration", "Expiration")
        Guna2DataGridView1.Columns.Add("WholesalePrice", "Wholesale Price")
        Guna2DataGridView1.Columns.Add("RetailPrice", "Retail Price")
        Guna2DataGridView1.Columns.Add("MinimumWholesaleQuantity", "Minimum Wholesale Quantity")
        Guna2DataGridView1.Columns.Add("CriticalLevel", "Critical Level")


        ' === Edit Column ===
        Dim editCol As New DataGridViewImageColumn() With {
        .Name = "Edit",
        .HeaderText = "Edit",
        .Image = My.Resources.icons8_edit_mains,
        .ImageLayout = DataGridViewImageCellLayout.Zoom,
        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
        .Width = 60
    }
        editCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Guna2DataGridView1.Columns.Add(editCol)

        ' === Delete Column ===
        Dim deleteCol As New DataGridViewImageColumn() With {
        .Name = "Delete",
        .HeaderText = "Delete",
        .Image = My.Resources.icons8_delete_mains,
        .ImageLayout = DataGridViewImageCellLayout.Zoom,
        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
        .Width = 60
    }
        deleteCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        deleteCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Guna2DataGridView1.Columns.Add(deleteCol)

        ' === Styling ===
        With Guna2DataGridView1
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ColumnHeadersHeight = 50 ' << Added header height
            .RowTemplate.Height = 35
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With

        ' === Set Column FillWeights ===
        Guna2DataGridView1.Columns("BarcodeID").FillWeight = 140
        Guna2DataGridView1.Columns("ProductName").FillWeight = 165
        Guna2DataGridView1.Columns("CategoryName").FillWeight = 120
        Guna2DataGridView1.Columns("Description").FillWeight = 150
        Guna2DataGridView1.Columns("Expiration").FillWeight = 100
        Guna2DataGridView1.Columns("WholesalePrice").FillWeight = 85
        Guna2DataGridView1.Columns("RetailPrice").FillWeight = 85
        Guna2DataGridView1.Columns("MinimumWholesaleQuantity").FillWeight = 120
        Guna2DataGridView1.Columns("CriticalLevel").FillWeight = 100

    End Sub





    ' ------------------------- APPLY ROUND CORNERS -------------------------
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

    ' ------------------------- VALIDATION -------------------------
    Private Function ValidateFields() As Boolean
        ' ===== Validate main fields =====
        If String.IsNullOrWhiteSpace(bid.Text) Then
            MessageBox.Show("Barcode ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf String.IsNullOrWhiteSpace(pname.Text) Then
            MessageBox.Show("Product Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf (TypeOf Catname Is ComboBox AndAlso Catname.SelectedIndex = -1) AndAlso (Catname.Text = "") Then
            MessageBox.Show("Category is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim minQty As Integer
        If Not Integer.TryParse(txtMinimumQuantity.Text, minQty) OrElse minQty < 0 Then
            MessageBox.Show("Minimum Wholesale Quantity must be a valid integer greater than or equal to 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True

        Dim criticalLevel As Integer
        If Not Integer.TryParse(txtCriticalLevel.Text, criticalLevel) OrElse criticalLevel < 0 Then
            MessageBox.Show("Critical Level must be a valid integer >= 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

    End Function


    ' ------------------------- ADD NEW PRODUCT -------------------------
    Private Sub addbtn_Click(sender As Object, e As EventArgs) Handles addbtn.Click
        ' ===== Validate required fields =====
        If String.IsNullOrWhiteSpace(bid.Text) Then
            MessageBox.Show("Please enter or scan a barcode.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(pname.Text) Then
            MessageBox.Show("Product Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(desp.Text) Then
            MessageBox.Show("Description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not withExpiry.Checked AndAlso Not noExpiry.Checked Then
            MessageBox.Show("Please select either 'With Expiry' or 'No Expiry'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ===== Numeric validation =====
        Dim wholesalePrice As Decimal
        Dim retailPrice As Decimal
        Dim minQty As Integer
        Dim criticalLevel As Integer

        If Not Decimal.TryParse(txtwholesale.Text, wholesalePrice) OrElse wholesalePrice < 0 Then
            MessageBox.Show("Wholesale Price must be a valid number (≥ 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtwholesale.Clear()
            Return
        End If

        If Not Decimal.TryParse(txtretail.Text, retailPrice) OrElse retailPrice < 0 Then
            MessageBox.Show("Retail Price must be a valid number (≥ 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtretail.Clear()
            Return
        End If

        If retailPrice <= wholesalePrice Then
            MessageBox.Show("Retail price must be greater than wholesale price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not Integer.TryParse(txtMinimumQuantity.Text, minQty) OrElse minQty < 0 Then
            MessageBox.Show("Minimum Quantity must be a valid integer (≥ 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMinimumQuantity.Clear()
            Return
        End If

        If Not Integer.TryParse(txtCriticalLevel.Text, criticalLevel) OrElse criticalLevel < 0 Then
            MessageBox.Show("Critical Level must be a valid integer (≥ 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCriticalLevel.Clear()
            Return
        End If

        Dim expirationValue As String = If(withExpiry.Checked, "With Expiration", "No Expiration")

        ' ===== Handle image =====
        Dim imgBytes() As Byte = Nothing
        Using ms As New MemoryStream()
            If pbimage.Image IsNot Nothing Then
                pbimage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Else
                My.Resources.noprodcutimage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            End If
            imgBytes = ms.ToArray()
        End Using

        ' ===== Insert into database =====
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return

            Try
                ' ===== Check for duplicate BarcodeID or ProductName =====
                Dim dupCmd As New MySqlCommand("
                SELECT 
                    SUM(CASE WHEN BarcodeID=@bid THEN 1 ELSE 0 END) AS BarcodeExists,
                    SUM(CASE WHEN ProductName=@pname THEN 1 ELSE 0 END) AS NameExists
                FROM product", conn)

                dupCmd.Parameters.AddWithValue("@bid", bid.Text.Trim())
                dupCmd.Parameters.AddWithValue("@pname", pname.Text.Trim())

                Using reader As MySqlDataReader = dupCmd.ExecuteReader()
                    If reader.Read() Then
                        Dim barcodeExists As Boolean = If(IsDBNull(reader("BarcodeExists")), False, Convert.ToInt32(reader("BarcodeExists")) > 0)
                        Dim nameExists As Boolean = If(IsDBNull(reader("NameExists")), False, Convert.ToInt32(reader("NameExists")) > 0)

                        If barcodeExists AndAlso nameExists Then
                            MessageBox.Show("Both the Barcode ID and Product Name already exist.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        ElseIf barcodeExists Then
                            MessageBox.Show("The Barcode ID already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        ElseIf nameExists Then
                            MessageBox.Show("The Product Name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End If
                End Using

                ' ===== Insert product =====
                Dim sql As String = "INSERT INTO product 
                (BarcodeID, ProductName, CategoryID, Description, Expiration, WholesalePrice, RetailPrice, MinimumWholesaleQuantity, CriticalLevel, ProductImage) 
                VALUES(@BarcodeID, @ProductName, @CategoryID, @Description, @Expiration, @WholesalePrice, @RetailPrice, @MinimumWholesaleQuantity, @CriticalLevel, @ProductImage)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@BarcodeID", bid.Text)
                    cmd.Parameters.AddWithValue("@ProductName", pname.Text)

                    ' ===== Category handling =====
                    Dim categoryID As Object = DBNull.Value
                    If Catname.SelectedValue IsNot Nothing Then
                        categoryID = Catname.SelectedValue
                    ElseIf Not String.IsNullOrWhiteSpace(Catname.Text) Then
                        Dim catSql As String = "SELECT CategoryID FROM category WHERE CategoryName=@name LIMIT 1"
                        Using ccmd As New MySqlCommand(catSql, conn)
                            ccmd.Parameters.AddWithValue("@name", Catname.Text)
                            Dim res = ccmd.ExecuteScalar()
                            If res IsNot Nothing AndAlso Not IsDBNull(res) Then
                                categoryID = res
                            End If
                        End Using
                    End If
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID)

                    cmd.Parameters.AddWithValue("@Description", desp.Text)
                    cmd.Parameters.AddWithValue("@Expiration", expirationValue)
                    cmd.Parameters.AddWithValue("@WholesalePrice", wholesalePrice)
                    cmd.Parameters.AddWithValue("@RetailPrice", retailPrice)
                    cmd.Parameters.AddWithValue("@MinimumWholesaleQuantity", minQty)
                    cmd.Parameters.AddWithValue("@CriticalLevel", criticalLevel)
                    cmd.Parameters.Add("@ProductImage", MySqlDbType.Blob).Value = imgBytes

                    cmd.ExecuteNonQuery()
                End Using

                ' ===== Audit Trail =====
                LogAuditTrail(SessionData.role, SessionData.fullName, $"Added product: {pname.Text} (BarcodeID: {bid.Text})")

                ' ===== UI refresh =====
                LoadData()
                ClearFields()
                Guna2ShadowPanel1.Visible = False
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub



    ' ------------------------- UPDATE PRODUCT -------------------------
    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If Guna2DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateFields() Then Return

        ' ===== Numeric validation =====
        Dim wholesalePrice As Decimal
        Dim retailPrice As Decimal
        Dim minQty As Integer
        Dim newCriticalLevel As Integer

        If Not Integer.TryParse(txtMinimumQuantity.Text, minQty) OrElse minQty < 0 Then
            MessageBox.Show("Minimum Quantity must be a valid integer (≥ 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not Integer.TryParse(txtCriticalLevel.Text, newCriticalLevel) OrElse newCriticalLevel < 0 Then
            MessageBox.Show("Critical Level must be a valid integer (≥ 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim expirationValue As String = If(withExpiry.Checked, "With Expiration", "No Expiration")

        ' ===== Prepare image =====
        Dim imgBytes() As Byte = Nothing
        If pbimage.Image IsNot Nothing AndAlso pbimage.Tag IsNot Nothing AndAlso pbimage.Tag.ToString() = "changed" Then
            Using ms As New MemoryStream()
                pbimage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                imgBytes = ms.ToArray()
            End Using
        End If

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return

            Try
                Dim selectedRow As DataGridViewRow = Guna2DataGridView1.SelectedRows(0)
                Dim originalBarcodeID As String = selectedRow.Cells("BarcodeID").Value.ToString()
                Dim newBarcodeID As String = bid.Text.Trim()

                ' ===== Duplication check (combined) =====
                Dim dupCheck As New MySqlCommand("
    SELECT 
        CASE 
            WHEN EXISTS(SELECT 1 FROM product WHERE BarcodeID=@bid AND BarcodeID<>@original) THEN 'barcode'
            WHEN EXISTS(SELECT 1 FROM product WHERE ProductName=@pname AND BarcodeID<>@original) THEN 'name'
            ELSE ''
        END AS DuplicateType", conn)

                dupCheck.Parameters.AddWithValue("@bid", newBarcodeID)
                dupCheck.Parameters.AddWithValue("@pname", pname.Text.Trim())
                dupCheck.Parameters.AddWithValue("@original", originalBarcodeID)

                Dim duplicateType As String = Convert.ToString(dupCheck.ExecuteScalar())

                If duplicateType = "barcode" Then
                    MessageBox.Show("The Barcode ID already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    bid.Focus()
                    Return
                ElseIf duplicateType = "name" Then
                    MessageBox.Show("The Product Name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    pname.Focus()
                    Return
                End If


                ' ===== Build SQL Update for changed fields =====
                Dim updates As New List(Of String)
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn
                Dim updatedFields As New List(Of String)

                ' --- BarcodeID ---
                If newBarcodeID <> originalBarcodeID Then
                    updates.Add("BarcodeID=@BarcodeID")
                    cmd.Parameters.AddWithValue("@BarcodeID", newBarcodeID)
                    updatedFields.Add($"Barcode: {originalBarcodeID} → {newBarcodeID}")
                End If

                ' --- ProductName ---
                Dim oldName As String = selectedRow.Cells("ProductName").Value.ToString()
                If pname.Text.Trim() <> oldName Then
                    updates.Add("ProductName=@ProductName")
                    cmd.Parameters.AddWithValue("@ProductName", pname.Text.Trim())
                    updatedFields.Add($"Product Name: {oldName} → {pname.Text.Trim()}")
                End If

                ' --- Description ---
                Dim oldDesc As String = selectedRow.Cells("Description").Value.ToString()
                If desp.Text.Trim() <> oldDesc Then
                    updates.Add("Description=@Description")
                    cmd.Parameters.AddWithValue("@Description", desp.Text.Trim())
                    updatedFields.Add($"Description: {oldDesc} → {desp.Text.Trim()}")
                End If

                ' --- Category ---
                Dim oldCategory As String = If(selectedRow.Cells("CategoryName").Value IsNot Nothing, selectedRow.Cells("CategoryName").Value.ToString(), "")
                If Catname.Text <> oldCategory Then
                    updates.Add("CategoryID=@CategoryID")
                    cmd.Parameters.AddWithValue("@CategoryID", If(Catname.SelectedValue, DBNull.Value))
                    updatedFields.Add($"Category: {oldCategory} → {Catname.Text}")
                End If

                ' --- Expiration ---
                Dim oldExpiration As String = selectedRow.Cells("Expiration").Value.ToString()
                If expirationValue <> oldExpiration Then
                    updates.Add("Expiration=@Expiration")
                    cmd.Parameters.AddWithValue("@Expiration", expirationValue)
                    updatedFields.Add($"Expiration: {oldExpiration} → {expirationValue}")
                End If

                ' --- Prices ---
                Dim oldWholesale As Decimal = Convert.ToDecimal(selectedRow.Cells("WholesalePrice").Value)
                Dim oldRetail As Decimal = Convert.ToDecimal(selectedRow.Cells("RetailPrice").Value)

                If Decimal.TryParse(txtwholesale.Text, wholesalePrice) AndAlso wholesalePrice <> oldWholesale Then
                    updates.Add("WholesalePrice=@WholesalePrice")
                    cmd.Parameters.AddWithValue("@WholesalePrice", wholesalePrice)
                    updatedFields.Add($"Wholesale Price: {oldWholesale} → {wholesalePrice}")
                End If

                If Decimal.TryParse(txtretail.Text, retailPrice) AndAlso retailPrice <> oldRetail Then
                    updates.Add("RetailPrice=@RetailPrice")
                    cmd.Parameters.AddWithValue("@RetailPrice", retailPrice)
                    updatedFields.Add($"Retail Price: {oldRetail} → {retailPrice}")
                End If

                ' --- Quantities ---
                Dim oldMinQty As Integer = Convert.ToInt32(selectedRow.Cells("MinimumWholesaleQuantity").Value)
                Dim oldCritical As Integer = Convert.ToInt32(selectedRow.Cells("CriticalLevel").Value)

                If minQty <> oldMinQty Then
                    updates.Add("MinimumWholesaleQuantity=@MinimumWholesaleQuantity")
                    cmd.Parameters.AddWithValue("@MinimumWholesaleQuantity", minQty)
                    updatedFields.Add($"Minimum Quantity: {oldMinQty} → {minQty}")
                End If

                If newCriticalLevel <> oldCritical Then
                    updates.Add("CriticalLevel=@CriticalLevel")
                    cmd.Parameters.AddWithValue("@CriticalLevel", newCriticalLevel)
                    updatedFields.Add($"Critical Level: {oldCritical} → {newCriticalLevel}")
                End If

                ' --- Product Image ---
                If pbimage.Image IsNot Nothing AndAlso pbimage.Tag IsNot Nothing AndAlso pbimage.Tag.ToString() = "changed" Then
                    updates.Add("ProductImage=@ProductImage")
                    cmd.Parameters.Add("@ProductImage", MySqlDbType.Blob).Value = imgBytes
                    updatedFields.Add("Product Image: Updated")
                End If

                ' ===== If no changes detected =====
                If updates.Count = 0 Then
                    MessageBox.Show("No changes detected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                ' ===== Execute Update =====
                cmd.CommandText = $"UPDATE product SET {String.Join(", ", updates)} WHERE BarcodeID=@OriginalBarcodeID"
                cmd.Parameters.AddWithValue("@OriginalBarcodeID", originalBarcodeID)
                cmd.ExecuteNonQuery()

                ' ===== Audit Trail =====
                LogAuditTrail(SessionData.role, SessionData.fullName, $"Updated product: {pname.Text}" & vbCrLf & String.Join(vbCrLf, updatedFields))

                ' ===== UI Refresh =====
                LoadData()
                ClearFields()
                pbimage.Image = Nothing
                pbimage.Tag = Nothing
                Guna2ShadowPanel1.Visible = False
                btnupdate.Visible = False

                MessageBox.Show("Product updated successfully!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As MySqlException
                MessageBox.Show("MySQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub



    ' ------------------------- IMAGE BROWSE -------------------------
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            ofd.Title = "Select Product Image"

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    ' === Load image safely using MemoryStream ===
                    Dim imgBytes() As Byte = File.ReadAllBytes(ofd.FileName)

                    Using ms As New MemoryStream(imgBytes)
                        ' Dispose old image safely
                        If pbimage.Image IsNot Nothing Then
                            pbimage.Image.Dispose()
                        End If
                        pbimage.Image = Image.FromStream(ms)
                    End Using

                    pbimage.SizeMode = PictureBoxSizeMode.StretchImage
                    pbimage.Tag = "changed" ' mark as changed for update

                Catch ex As Exception
                    MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub


    ' ------------------------- DELETE PRODUCT -------------------------
    Private Sub DeleteProduct(barcodeId As String)
        ' ===== Basic Validation =====
        If String.IsNullOrWhiteSpace(barcodeId) Then
            MessageBox.Show("No product selected for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' ===== Confirm Deletion =====
        If MessageBox.Show($"Are you sure you want to delete the product with BarcodeID '{barcodeId}'?",
                       "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Exit Sub
        End If

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return

            Try
                ' ===== Get Product Details =====
                Dim productName As String = ""
                Dim productDesc As String = ""
                Dim getNameQuery As String = "SELECT ProductName, Description FROM product WHERE BarcodeID=@id"
                Using getCmd As New MySqlCommand(getNameQuery, conn)
                    getCmd.Parameters.AddWithValue("@id", barcodeId)
                    Using reader As MySqlDataReader = getCmd.ExecuteReader()
                        If reader.Read() Then
                            productName = reader("ProductName").ToString()
                            productDesc = reader("Description").ToString()
                        Else
                            MessageBox.Show("Product not found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End Using
                End Using

                ' ===== Check References in Other Tables =====
                Dim referenceCount As Integer = 0
                Dim checkInventoryQuery As String = "SELECT COUNT(*) FROM inventory WHERE BarcodeID=@id"
                Using checkInventoryCmd As New MySqlCommand(checkInventoryQuery, conn)
                    checkInventoryCmd.Parameters.AddWithValue("@id", barcodeId)
                    referenceCount += Convert.ToInt32(checkInventoryCmd.ExecuteScalar())
                End Using

                ' Optionally, add checks for sales, deliveries, etc.

                If referenceCount > 0 Then
                    MessageBox.Show($"Cannot delete product '{productName}' because it is still referenced in other records (e.g., inventory, sales).",
                                "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' ===== Delete Product =====
                Dim deleteQuery As String = "DELETE FROM product WHERE BarcodeID=@id"
                Using delCmd As New MySqlCommand(deleteQuery, conn)
                    delCmd.Parameters.AddWithValue("@id", barcodeId)
                    Dim rowsAffected As Integer = delCmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        ' ===== Audit Trail =====
                        Dim actionDescription As String = $"Deleted product '{productName}' ({productDesc}) [BarcodeID: {barcodeId}]"
                        LogAuditTrail(SessionData.role, SessionData.fullName, actionDescription)

                        ' ===== Refresh UI =====
                        LoadData()
                        MessageBox.Show($"Product '{productName}' deleted successfully!", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Failed to delete product. Product might not exist anymore.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using

            Catch ex As MySqlException
                MessageBox.Show("MySQL Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error deleting product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub

    ' ------------------------- GRID CLICK HANDLER (EDIT / DELETE) -------------------------
    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        ' Prevent header or invalid clicks
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim clickedColumn As DataGridViewColumn = Guna2DataGridView1.Columns(e.ColumnIndex)
        Dim selectedRow As DataGridViewRow = Guna2DataGridView1.Rows(e.RowIndex)

        ' ===== EDIT =====
        If clickedColumn.Name = "Edit" Then
            ' Load basic info
            bid.Text = selectedRow.Cells("BarcodeID").Value?.ToString()
            pname.Text = selectedRow.Cells("ProductName").Value?.ToString()
            desp.Text = selectedRow.Cells("Description").Value?.ToString()

            ' Minimum Quantity
            Dim minQtyVal As String = selectedRow.Cells("MinimumWholesaleQuantity").Value?.ToString()
            txtMinimumQuantity.Text = If(String.IsNullOrEmpty(minQtyVal), "0", minQtyVal)

            ' ===== Prices (safe parsing with InvariantCulture) =====
            Dim wholesaleDecimal As Decimal = 0D
            Dim retailDecimal As Decimal = 0D

            If selectedRow.Cells("WholesalePrice").Value IsNot Nothing AndAlso
           Decimal.TryParse(selectedRow.Cells("WholesalePrice").Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, wholesaleDecimal) Then
                txtwholesale.Text = wholesaleDecimal.ToString("F2", CultureInfo.InvariantCulture)
            Else
                txtwholesale.Text = "0.00"
            End If

            If selectedRow.Cells("RetailPrice").Value IsNot Nothing AndAlso
           Decimal.TryParse(selectedRow.Cells("RetailPrice").Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, retailDecimal) Then
                txtretail.Text = retailDecimal.ToString("F2", CultureInfo.InvariantCulture)
            Else
                txtretail.Text = "0.00"
            End If

            ' Category
            Dim categoryName As String = selectedRow.Cells("CategoryName").Value?.ToString()
            If Not String.IsNullOrEmpty(categoryName) Then
                If TypeOf Catname.DataSource Is DataTable Then
                    Catname.SelectedIndex = Catname.FindStringExact(categoryName)
                Else
                    Catname.Text = categoryName
                End If
            Else
                Catname.SelectedIndex = -1
            End If

            ' Expiration
            Dim expirationValue As String = selectedRow.Cells("Expiration").Value?.ToString()
            If String.IsNullOrEmpty(expirationValue) OrElse expirationValue.ToLower() = "no expiration" Then
                noExpiry.Checked = True
                withExpiry.Checked = False
            Else
                withExpiry.Checked = True
                noExpiry.Checked = False
            End If

            ' Critical Level
            Dim criticalLevelVal As String = selectedRow.Cells("CriticalLevel").Value?.ToString()
            txtCriticalLevel.Text = If(String.IsNullOrEmpty(criticalLevelVal), "0", criticalLevelVal)

            ' Load image
            Using conn As MySqlConnection = Module1.Openconnection()
                If conn IsNot Nothing Then
                    Try
                        Dim sql As String = "SELECT ProductImage FROM product WHERE BarcodeID=@BarcodeID"
                        Using cmd As New MySqlCommand(sql, conn)
                            cmd.Parameters.AddWithValue("@BarcodeID", bid.Text)
                            Dim imgObj = cmd.ExecuteScalar()
                            If imgObj IsNot Nothing AndAlso Not Convert.IsDBNull(imgObj) Then
                                Dim imgBytes() As Byte = CType(imgObj, Byte())
                                Using ms As New IO.MemoryStream(imgBytes)
                                    pbimage.Image = Drawing.Image.FromStream(ms)
                                End Using
                            Else
                                pbimage.Image = My.Resources.noprodcutimage
                            End If
                            pbimage.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                    Catch ex As Exception
                        pbimage.Image = My.Resources.noprodcutimage
                    End Try
                End If
            End Using

            ' Show Edit Panel
            Guna2ShadowPanel1.Visible = True
            btnupdate.Visible = True
            addbtn.Visible = False
        End If

        ' ===== DELETE =====
        If clickedColumn.Name = "Delete" Then
            Dim BarcodeId As String = selectedRow.Cells("BarcodeID").Value?.ToString()
            If Not String.IsNullOrEmpty(BarcodeId) Then
                DeleteProduct(BarcodeId)
            End If
        End If
    End Sub





    ' ------------------------- ADD NEW PRODUCT PANEL  -------------------------

    Private Sub btnAddnewProduct_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        Guna2ShadowPanel1.Visible = True
        addbtn.Visible = True
        bid.Focus()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Guna2ShadowPanel1.Visible = False

        ClearFields()

    End Sub

    ' ------------------------- AUDIT TRAIL -------------------------
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
                    cmd.Parameters.AddWithValue("@Form", "Products")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ------------------------- CLEAR FIELDS -------------------------
    Private Sub ClearFields()
        ' Clear text fields
        bid.Clear()
        pname.Clear()
        desp.Clear()
        txtretail.Clear()
        txtwholesale.Clear()

        ' Reset category selection
        Catname.SelectedIndex = -1

        ' Reset buttons

        ' Reset expiration checkboxes
        withExpiry.Checked = False
        noExpiry.Checked = False

        pbimage.Image = My.Resources.noprodcutimage

        txtMinimumQuantity.Clear()

        bid.Focus()

        txtCriticalLevel.Clear()


    End Sub


    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        ClearFields()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ClearFields()
    End Sub

    ' ------------------------- SEARCH -------------------------
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        ' If search box is empty, reload all data
        If String.IsNullOrEmpty(searchText) Then
            LoadData()
            Exit Sub
        End If

        Guna2DataGridView1.Rows.Clear()

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return
            Try
                Dim sql As String =
            "SELECT p.BarcodeID, p.ProductName, c.CategoryName, p.Description, p.Expiration, " &
            "p.WholesalePrice, p.RetailPrice, p.CriticalLevel " &
            "FROM product p LEFT JOIN category c ON p.CategoryID = c.CategoryID"

                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim bidVal As String = reader("BarcodeID").ToString()
                            Dim pnameVal As String = reader("ProductName").ToString()
                            Dim catnameVal As String = If(IsDBNull(reader("CategoryName")), "No Category", reader("CategoryName").ToString())
                            Dim descpVal As String = If(IsDBNull(reader("Description")), "", reader("Description").ToString())
                            Dim expirationVal As String = If(IsDBNull(reader("Expiration")), "", reader("Expiration").ToString())
                            Dim wholesaleVal As String = If(IsDBNull(reader("WholesalePrice")), "0", reader("WholesalePrice").ToString())
                            Dim retailVal As String = If(IsDBNull(reader("RetailPrice")), "0", reader("RetailPrice").ToString())
                            Dim criticalVal As String = If(IsDBNull(reader("CriticalLevel")), "0", reader("CriticalLevel").ToString())

                            ' Match search text across all relevant columns
                            If bidVal.ToLower().Contains(searchText) OrElse
                           pnameVal.ToLower().Contains(searchText) OrElse
                           catnameVal.ToLower().Contains(searchText) OrElse
                           descpVal.ToLower().Contains(searchText) OrElse
                           expirationVal.ToLower().Contains(searchText) OrElse
                           wholesaleVal.ToLower().Contains(searchText) OrElse
                           retailVal.ToLower().Contains(searchText) OrElse
                           criticalVal.ToLower().Contains(searchText) Then

                                Dim index As Integer = Guna2DataGridView1.Rows.Add(bidVal, pnameVal, catnameVal, descpVal, expirationVal, wholesaleVal, retailVal, criticalVal)
                                Guna2DataGridView1.Rows(index).DefaultCellStyle.BackColor = Color.LightYellow
                                Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionBackColor = Color.Orange
                                Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Black
                            End If
                        End While
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Error loading search results: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub



    ' ======================= KEYPRESS / TEXT CHANGES =======================

    ' ===== Barcode (digits only, max 13) =====
    Private Sub bid_TextChanged(sender As Object, e As EventArgs) Handles bid.TextChanged
        Dim txt = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)
        Dim newText = New String(txt.Text.Where(AddressOf Char.IsDigit).Take(13).ToArray())
        If txt.Text <> newText Then
            txt.Text = newText
            txt.SelectionStart = txt.TextLength
        End If
    End Sub

    ' ===== Product Name (letters, space, ', - allowed) =====
    Private Sub pname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pname.KeyPress
        Dim allowedSymbols As String = "'-"
        If Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> " "c AndAlso Not allowedSymbols.Contains(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' ===== Description (alphanumeric + spaces, max 200) =====
    Private Sub desp_TextChanged(sender As Object, e As EventArgs) Handles desp.TextChanged
        Dim txt = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)
        Dim newText = New String(txt.Text.Where(Function(c) Char.IsLetterOrDigit(c) OrElse Char.IsWhiteSpace(c)).Take(200).ToArray())
        If txt.Text <> newText Then
            txt.Text = newText
            txt.SelectionStart = txt.TextLength
        End If
    End Sub

    ' ===== Price Validation (Unit ≥ Wholesale, Retail ≥ Wholesale) =====
    Private Sub txtNumbersOnly_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtretail.KeyPress, txtwholesale.KeyPress, txtCriticalLevel.KeyPress
        Dim txt As Guna.UI2.WinForms.Guna2TextBox = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)

        ' Allow only digits, backspace, and period (for decimals)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        Dim txtBox As Guna.UI2.WinForms.Guna2TextBox = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)
        If e.KeyChar = "."c AndAlso txtBox.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub




    ' ===== NUMERIC ONLY (Minimum Quantity) =====

    Private Sub txtMinimumQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMinimumQuantity.KeyPress
        Dim txt As Guna.UI2.WinForms.Guna2TextBox = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)

        ' Allow only digits and control keys (backspace, delete)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If

        ' Optional: limit length (e.g., max 5 digits)
        If Char.IsDigit(e.KeyChar) AndAlso txt.TextLength >= 5 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMinimumQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtMinimumQuantity.TextChanged
        Dim txt As Guna.UI2.WinForms.Guna2TextBox = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)
        ' Remove non-digit characters just in case
        Dim newText As String = New String(txt.Text.Where(AddressOf Char.IsDigit).ToArray())
        If txt.Text <> newText Then
            txt.Text = newText
            txt.SelectionStart = txt.TextLength
        End If
    End Sub

    Private Sub txtwholesale_TextChanged(sender As Object, e As EventArgs) Handles txtwholesale.TextChanged, txtretail.TextChanged
        Dim wholesalePrice As Decimal
        Dim retailPrice As Decimal

        ' Try parse; if invalid, exit
        If Not Decimal.TryParse(txtwholesale.Text, wholesalePrice) Then Return
        If Not Decimal.TryParse(txtretail.Text, retailPrice) Then Return

        ' Check condition
        If retailPrice <= wholesalePrice Then
            MessageBox.Show("Retail price must be greater than wholesale price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtwholesale.Clear()
            txtretail.Clear()
        End If
    End Sub

    Private Sub txtCriticalLevel_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtCriticalLevel_TextChanged(sender As Object, e As EventArgs)
        Dim txt As Guna.UI2.WinForms.Guna2TextBox = DirectCast(sender, Guna.UI2.WinForms.Guna2TextBox)
        Dim newText As String = New String(txt.Text.Where(AddressOf Char.IsDigit).ToArray())
        If txt.Text <> newText Then
            txt.Text = newText
            txt.SelectionStart = txt.TextLength
        End If
    End Sub

    ' === Declare sa taas ng form ===
    Private scanTimer As New Timer()
    Private scanBuffer As New System.Text.StringBuilder()

    Private Sub bid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bid.KeyPress
        ' Collect all scanned characters (excluding Enter)
        If Not Char.IsControl(e.KeyChar) Then
            scanBuffer.Append(e.KeyChar)
        End If

        ' Reset timer after every key press
        scanTimer.Stop()
        scanTimer.Interval = 200 ' delay para matapos ang mabilis na scan
        AddHandler scanTimer.Tick, AddressOf ScanCompleted
        scanTimer.Start()
    End Sub

    Private Sub ScanCompleted(sender As Object, e As EventArgs)
        scanTimer.Stop()

        ' Set text AFTER scan completes
        'bid.Text = scanBuffer.ToString().Trim()

        ' Move focus to pname
        pname.Focus()



    End Sub

    ' ------------------------- HELPER: Set Product Category to NULL (if needed) -------------------------
    Private Sub SetProductCategoryToNull(categoryName As String)
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return
            Try
                Dim sql As String = "UPDATE product p " &
                                    "JOIN category c ON p.CategoryID = c.CategoryID " &
                                    "SET p.CategoryID = NULL " &
                                    "WHERE c.CategoryName = @CategoryName"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName)
                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Error: " & ex.Message)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === DEFAULT COLORS & IMAGES ===
        btnAddnew.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnAddnew.ForeColor = Color.White
        btnAddnew.Image = My.Resources.icons8_add_30_normal ' normal iconn

        ' === HOVER EFFECTS FOR btnAddnewUsar ===
        AddHandler btnAddnew.MouseEnter, Sub()
                                             btnAddnew.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                             btnAddnew.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                             btnAddnew.Image = My.Resources.icons8_add_30_hindi ' hover icon
                                         End Sub

        AddHandler btnAddnew.MouseLeave, Sub()
                                             btnAddnew.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                             btnAddnew.ForeColor = Color.White
                                             btnAddnew.Image = My.Resources.icons8_add_30_normal ' back to normal
                                         End Sub

        ' === OPTIONAL: CENTER THE FORM ON SCREEN ===
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub
End Class
