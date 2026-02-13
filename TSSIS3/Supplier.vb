Imports K4os.Compression.LZ4.Streams
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports Mysqlx.Notice
Imports System.Security.Cryptography
Imports System.Drawing.Drawing2D

Public Class Supplier
    Private Const CornerRadius As Integer = 10
    Private currentSupplierID As Integer = -1
    Private currentSupplierName As String = ""


    '=============================
    '       FORM LOAD
    '=============================
    Private Sub Supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
        End Using

        cname.MaxLength = 100
        cno.MaxLength = 11
        sname.MaxLength = 100
        eml.MaxLength = 255
        adrss.MaxLength = 100

        SetupDataGridView()
        LoadData()

        Guna2Panel1.BorderColor = ColorTranslator.FromHtml("#D3D3D3")
        Guna2Panel1.BorderThickness = 2
        Guna2Panel1.BorderRadius = 5
        ApplyRoundedCorners()

        ' ==== DataGridView Font ====
        Guna2DataGridView1.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== TextBoxes Font (Outfit, 9, Regular) ====
        adrss.Font = New Font("Outfit", 9, FontStyle.Regular)
        eml.Font = New Font("Outfit", 9, FontStyle.Regular)
        cno.Font = New Font("Outfit", 9, FontStyle.Regular)
        sname.Font = New Font("Outfit", 9, FontStyle.Regular)
        cname.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtSearchSupplier.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== Labels Font (Outfit, 9, Bold) ====
        Label1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label2.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label3.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label4.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label10.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label11.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ==== Buttons Font (Outfit, 9, Bold) ====
        btnupdate.Font = New Font("Outfit", 10, FontStyle.Bold)
        addbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        clearbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        btnAddnew.Font = New Font("Outfit", 9, FontStyle.Bold)


        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2

    End Sub

    '=============================
    '       LOAD DATA
    '============================
    Private Sub LoadData()
        Guna2DataGridView1.Rows.Clear()

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return
            Try
                Using cmd As New MySqlCommand("SELECT SupplierID, CompanyName, SupplierName, ContactNo, Email, Address FROM supplier", conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Guna2DataGridView1.Rows.Add(
                                reader("SupplierID").ToString(),
                                reader("CompanyName").ToString(),
                                reader("SupplierName").ToString(),
                                reader("ContactNo").ToString(),
                                reader("Email").ToString(),
                                reader("Address").ToString()
                            )
                        End While
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Error loading data: " & ex.Message)
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

    '=============================
    '       ROUNDED CORNERS
    '=============================
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
        path.AddLine(0, Me.Height - CornerRadius, 0, CornerRadius)
        path.CloseFigure()
        Me.Region = New Region(path)
        Me.Invalidate()
    End Sub

    '=============================
    '       ADD SUPPLIER
    '=============================





    '=============================
    '       UPDATE SUPPLIER
    '=============================
    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        ' --- Validation ---
        If currentSupplierID = -1 Then
            MessageBox.Show("No supplier selected for update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs() Then Return

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return

            Try
                ' ===== Duplication check (exclude current supplier) =====
                Dim dupCmd As New MySqlCommand("
                SELECT 
                    SUM(CASE WHEN SupplierName = @SupplierName AND SupplierID <> @SupplierID THEN 1 ELSE 0 END) AS NameExists,
                    SUM(CASE WHEN ContactNo = @ContactNo AND SupplierID <> @SupplierID THEN 1 ELSE 0 END) AS ContactExists,
                    SUM(CASE WHEN Email = @Email AND SupplierID <> @SupplierID THEN 1 ELSE 0 END) AS EmailExists,
                    SUM(CASE WHEN Address = @Address AND SupplierID <> @SupplierID THEN 1 ELSE 0 END) AS AddressExists
                FROM supplier", conn)

                dupCmd.Parameters.AddWithValue("@SupplierName", sname.Text.Trim())
                dupCmd.Parameters.AddWithValue("@ContactNo", cno.Text.Trim())
                dupCmd.Parameters.AddWithValue("@Email", eml.Text.Trim())
                dupCmd.Parameters.AddWithValue("@Address", adrss.Text.Trim())
                dupCmd.Parameters.AddWithValue("@SupplierID", currentSupplierID)

                Using reader As MySqlDataReader = dupCmd.ExecuteReader()
                    If reader.Read() Then
                        Dim nameExists As Boolean = If(IsDBNull(reader("NameExists")), False, Convert.ToInt32(reader("NameExists")) > 0)
                        Dim contactExists As Boolean = If(IsDBNull(reader("ContactExists")), False, Convert.ToInt32(reader("ContactExists")) > 0)
                        Dim emailExists As Boolean = If(IsDBNull(reader("EmailExists")), False, Convert.ToInt32(reader("EmailExists")) > 0)
                        Dim addressExists As Boolean = If(IsDBNull(reader("AddressExists")), False, Convert.ToInt32(reader("AddressExists")) > 0)

                        ' ===== Build duplicate message =====
                        Dim dupMessage As String = ""
                        If nameExists Then dupMessage &= "Supplier Name already exists." & vbCrLf
                        If contactExists Then dupMessage &= "Contact Number already exists." & vbCrLf
                        If emailExists Then dupMessage &= "Email already exists." & vbCrLf
                        If addressExists Then dupMessage &= "Address already exists." & vbCrLf

                        If dupMessage <> "" Then
                            MessageBox.Show(dupMessage.Trim(), "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            ' Focus the first duplicate field
                            If nameExists Then sname.Focus()
                            If contactExists Then cno.Focus()
                            If emailExists Then eml.Focus()
                            If addressExists Then adrss.Focus()
                            Return
                        End If
                    End If
                End Using

                ' ===== Get original data =====
                Dim updatedFields As New List(Of String)
                Dim origName As String = "", origCompany As String = "", origContact As String = "", origEmail As String = "", origAddress As String = ""

                Using cmd As New MySqlCommand("SELECT SupplierName, CompanyName, ContactNo, Email, Address FROM supplier WHERE SupplierID=@SupplierID", conn)
                    cmd.Parameters.AddWithValue("@SupplierID", currentSupplierID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            origName = If(IsDBNull(reader("SupplierName")), "", reader("SupplierName").ToString())
                            origCompany = If(IsDBNull(reader("CompanyName")), "", reader("CompanyName").ToString())
                            origContact = If(IsDBNull(reader("ContactNo")), "", reader("ContactNo").ToString())
                            origEmail = If(IsDBNull(reader("Email")), "", reader("Email").ToString())
                            origAddress = If(IsDBNull(reader("Address")), "", reader("Address").ToString())
                        End If
                    End Using
                End Using

                ' --- Track changed fields ---
                If sname.Text.Trim() <> origName Then updatedFields.Add($"Supplier Name: {origName} → {sname.Text.Trim()}")
                If cname.Text.Trim() <> origCompany Then updatedFields.Add($"Company Name: {origCompany} → {cname.Text.Trim()}")
                If cno.Text.Trim() <> origContact Then updatedFields.Add($"Contact No: {origContact} → {cno.Text.Trim()}")
                If eml.Text.Trim() <> origEmail Then updatedFields.Add($"Email: {origEmail} → {eml.Text.Trim()}")
                If adrss.Text.Trim() <> origAddress Then updatedFields.Add($"Address: {origAddress} → {adrss.Text.Trim()}")

                ' ===== Perform update =====
                Using updateCmd As New MySqlCommand("
                UPDATE supplier 
                SET SupplierName=@SupplierName, CompanyName=@CompanyName, ContactNo=@ContactNo, 
                    Email=@Email, Address=@Address 
                WHERE SupplierID=@SupplierID", conn)

                    updateCmd.Parameters.AddWithValue("@SupplierName", sname.Text.Trim())
                    updateCmd.Parameters.AddWithValue("@CompanyName", cname.Text.Trim())
                    updateCmd.Parameters.AddWithValue("@ContactNo", cno.Text.Trim())
                    updateCmd.Parameters.AddWithValue("@Email", eml.Text.Trim())
                    updateCmd.Parameters.AddWithValue("@Address", adrss.Text.Trim())
                    updateCmd.Parameters.AddWithValue("@SupplierID", currentSupplierID)
                    updateCmd.ExecuteNonQuery()
                End Using

                ' ===== Log changes if any =====
                If updatedFields.Count > 0 Then
                    LogAuditTrail(SessionData.role, SessionData.fullName, "Updated Supplier:" & vbCrLf & String.Join(vbCrLf, updatedFields))
                End If

                MessageBox.Show("Supplier successfully updated!", "Update Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear()
                LoadData()
                addbtn.Enabled = True
                Guna2ShadowPanel1.Visible = False
                currentSupplierID = -1

            Catch ex As MySqlException
                MessageBox.Show("Error updating supplier: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub



    '=============================
    '       DELETE SUPPLIER
    '=============================
    Private Sub deletebtn_Click(supplierID As Integer, supplierName As String)
        If supplierID = -1 Then
            MessageBox.Show("Please select a supplier to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return
            Try
                Using checkCmd As New MySqlCommand("SELECT COUNT(*) FROM deliveries WHERE SupplierID=@SupplierID", conn)
                    checkCmd.Parameters.AddWithValue("@SupplierID", supplierID)
                    Dim usedCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If usedCount > 0 Then
                        MessageBox.Show("Cannot delete this supplier because it is linked to delivery records.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                If MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Using deleteCmd As New MySqlCommand("DELETE FROM supplier WHERE SupplierID=@SupplierID", conn)
                        deleteCmd.Parameters.AddWithValue("@SupplierID", supplierID)
                        deleteCmd.ExecuteNonQuery()
                    End Using

                    LogAuditTrail(SessionData.role, SessionData.fullName, $"Deleted Supplier: {supplierName}")
                    MessageBox.Show("Supplier successfully deleted!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                    clear()
                    addbtn.Enabled = True
                    Guna2ShadowPanel1.Visible = False

                End If
            Catch ex As MySqlException
                MessageBox.Show("Error deleting supplier: " & ex.Message)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub



    '=============================
    '       AUDIT TRAIL
    '=============================
    Private Sub LogAuditTrail(ByVal role As String, ByVal fullName As String, ByVal action As String)
        Try
            Using connection As New MySqlConnection(connectionstring)
                connection.Open()
                Dim query As String = "INSERT INTO audittrail (Role, FullName, Action, Form, Date) VALUES (@Role, @FullName, @Action, @Form, @Date)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@Action", action)
                    cmd.Parameters.AddWithValue("@Form", "Suppliers")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message)
        End Try
    End Sub

    '=============================
    '       DATAGRID SETUP
    '=============================
    Private Sub SetupDataGridView()
        ' =============================
        '       RESET DGV FIRST
        ' =============================
        Guna2DataGridView1.Columns.Clear()
        Guna2DataGridView1.AllowUserToAddRows = False

        ' =============================
        '       ADD DATA COLUMNS
        ' =============================
        Dim columns As (String, String, Boolean)() = {
        ("SupplierID", "Supplier ID", True),       ' <-- Hidden Column
        ("CompanyName", "Company Name", False),
        ("SupplierName", "Supplier Name", False),
        ("ContactNo", "Contact No", False),
        ("Email", "Email", False),
        ("Address", "Address", False)
    }

        For Each col In columns
            Dim dgvCol As New DataGridViewTextBoxColumn() With {
            .Name = col.Item1,
            .HeaderText = col.Item2,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .SortMode = DataGridViewColumnSortMode.NotSortable,
            .Visible = Not col.Item3 ' Hide if True
        }
            Guna2DataGridView1.Columns.Add(dgvCol)
        Next

        ' =============================
        '       ADD EDIT COLUMN
        ' =============================
        Dim editCol As New DataGridViewImageColumn() With {
        .Name = "Edit",
        .HeaderText = "Edit",
        .Image = My.Resources.icons8_edit_mains,
        .ImageLayout = DataGridViewImageCellLayout.Zoom,
        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
        .Width = 60,
        .DefaultCellStyle = New DataGridViewCellStyle() With {
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        },
        .Resizable = DataGridViewTriState.False
    }
        editCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Guna2DataGridView1.Columns.Add(editCol)

        ' =============================
        '       ADD DELETE COLUMN
        ' =============================
        Dim deleteCol As New DataGridViewImageColumn() With {
        .Name = "Delete",
        .HeaderText = "Delete",
        .Image = My.Resources.icons8_delete_mains,
        .ImageLayout = DataGridViewImageCellLayout.Zoom,
        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
        .Width = 60,
        .DefaultCellStyle = New DataGridViewCellStyle() With {
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        },
        .Resizable = DataGridViewTriState.False
    }
        deleteCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Guna2DataGridView1.Columns.Add(deleteCol)

        ' =============================
        '       GENERAL STYLING
        ' =============================
        With Guna2DataGridView1
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 30
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Fix Edit/Delete widths
            For Each col As DataGridViewColumn In .Columns
                If col.Name = "Edit" OrElse col.Name = "Delete" Then
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Else
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            Next
        End With
    End Sub



    '=============================
    '       VALIDATION
    '=============================
    Private Function ValidateInputs() As Boolean
        ' --- COMPANY NAME ---
        If String.IsNullOrWhiteSpace(cname.Text) Then
            MessageBox.Show("Company Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' --- SUPPLIER NAME ---
        If String.IsNullOrWhiteSpace(sname.Text) Then
            MessageBox.Show("Supplier Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' --- CONTACT NUMBER (11 digits) ---
        If Not Regex.IsMatch(cno.Text, "^\d{11}$") Then
            MessageBox.Show("Contact Number must be 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' --- EMAIL VALIDATION ---
        If Not IsValidEmail(eml.Text) Then
            MessageBox.Show("Invalid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' --- ADDRESS ---
        If String.IsNullOrWhiteSpace(adrss.Text) Then
            MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' --- ALL VALID ---
        Return True
    End Function

    ' =============================
    '  Helper: Levenshtein Distance / Similarity
    ' =============================
    Private Function LevenshteinDistance(s As String, t As String) As Integer
        If s Is Nothing Then s = String.Empty
        If t Is Nothing Then t = String.Empty

        Dim n As Integer = s.Length
        Dim m As Integer = t.Length
        If n = 0 Then Return m
        If m = 0 Then Return n

        Dim d(n + 1, m + 1) As Integer
        For i As Integer = 0 To n
            d(i, 0) = i
        Next
        For j As Integer = 0 To m
            d(0, j) = j
        Next

        For i As Integer = 1 To n
            For j As Integer = 1 To m
                Dim cost As Integer = If(Char.ToLowerInvariant(s(i - 1)) = Char.ToLowerInvariant(t(j - 1)), 0, 1)
                d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
            Next
        Next

        Return d(n, m)
    End Function

    Private Function IsSimilar(a As String, b As String, Optional maxDistance As Integer = 1) As Boolean
        a = If(a, String.Empty).Trim()
        b = If(b, String.Empty).Trim()
        If String.Equals(a, b, StringComparison.OrdinalIgnoreCase) Then Return True
        ' Treat very short strings specially
        If a.Length <= 2 OrElse b.Length <= 2 Then
            Return String.Equals(a, b, StringComparison.OrdinalIgnoreCase)
        End If
        Dim dist = LevenshteinDistance(a, b)
        Return dist <= maxDistance
    End Function

    ' Check if a supplier already exists with near-identical details
    Private Function IsDuplicateSupplier(company As String, supplier As String, contact As String, email As String, address As String, Optional excludeSupplierID As Integer = -1) As Boolean
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return False
            Try
                Using cmd As New MySqlCommand("SELECT SupplierID, CompanyName, SupplierName, ContactNo, Email, Address FROM supplier", conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim sid As Integer = If(IsDBNull(reader("SupplierID")), -1, Convert.ToInt32(reader("SupplierID")))
                            If excludeSupplierID <> -1 AndAlso sid = excludeSupplierID Then Continue While

                            Dim exCompany = If(IsDBNull(reader("CompanyName")), "", reader("CompanyName").ToString())
                            Dim exSupplier = If(IsDBNull(reader("SupplierName")), "", reader("SupplierName").ToString())
                            Dim exContact = If(IsDBNull(reader("ContactNo")), "", reader("ContactNo").ToString())
                            Dim exEmail = If(IsDBNull(reader("Email")), "", reader("Email").ToString())
                            Dim exAddress = If(IsDBNull(reader("Address")), "", reader("Address").ToString())

                            Dim matchCompany = IsSimilar(company, exCompany)
                            Dim matchSupplier = IsSimilar(supplier, exSupplier)
                            Dim matchContact = IsSimilar(contact, exContact)
                            Dim matchEmail = IsSimilar(email, exEmail)
                            Dim matchAddress = IsSimilar(address, exAddress)

                            ' If all key fields are similar (allowing small typos), consider duplicate
                            If matchCompany AndAlso matchSupplier AndAlso matchContact AndAlso matchEmail AndAlso matchAddress Then
                                Return True
                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                ' on error, be conservative and do not block
                Return False
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using

        Return False
    End Function


    ' === Barcode TextBox behavior ===
    Private Sub bid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cno.KeyPress
        ' Only allow numbers and control keys (like Backspace)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Prevent deleting or moving before the prefix "09"
        If cno.SelectionStart < 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub bid_TextChanged(sender As Object, e As EventArgs) Handles cno.TextChanged
        ' Always ensure prefix "09" exists
        If Not cno.Text.StartsWith("09") Then
            Dim cursorPos As Integer = cno.SelectionStart
            cno.Text = "09"
            cno.SelectionStart = cno.Text.Length ' move cursor to end
        End If
    End Sub

    Private Sub bid_Enter(sender As Object, e As EventArgs) Handles cno.Enter
        ' Auto-add prefix if empty when entering the box
        If String.IsNullOrEmpty(cno.Text) Then
            cno.Text = "09"
            cno.SelectionStart = cno.Text.Length
        End If
    End Sub

    Private Sub bid_KeyDown(sender As Object, e As KeyEventArgs) Handles cno.KeyDown
        ' Prevent Backspace/Delete on prefix
        If (cno.SelectionStart <= 2 AndAlso (e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete)) Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub sname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles sname.KeyPress
        ' ✅ Check if key is not a letter, control (like backspace), or space
        If Not Char.IsLetter(e.KeyChar) AndAlso
       Not Char.IsControl(e.KeyChar) AndAlso
       Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True ' 🚫 Cancel the keypress
        End If
    End Sub


    Private Function IsValidEmail(email As String) As Boolean
        Return Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
    End Function

    '=============================
    '       SEARCH SUPPLIER
    '=============================
    Private Sub txtSearchSupplier_TextChanged(sender As Object, e As EventArgs) Handles txtSearchSupplier.TextChanged
        Dim searchText As String = txtSearchSupplier.Text.Trim().ToLower()

        If String.IsNullOrEmpty(searchText) Then
            LoadData()
            Return
        End If

        Guna2DataGridView1.Rows.Clear()

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then Return
            Try
                Dim sql As String = "SELECT SupplierID, CompanyName, SupplierName, ContactNo, Email, Address FROM supplier"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim cnameVal = reader("CompanyName").ToString()
                            Dim snameVal = reader("SupplierName").ToString()
                            Dim cnoVal = reader("ContactNo").ToString()
                            Dim emailVal = reader("Email").ToString()
                            Dim addrVal = reader("Address").ToString()
                            Dim supplierIDVal = Convert.ToInt32(reader("SupplierID"))

                            If cnameVal.ToLower().Contains(searchText) OrElse snameVal.ToLower().Contains(searchText) _
                           OrElse cnoVal.ToLower().Contains(searchText) OrElse emailVal.ToLower().Contains(searchText) _
                           OrElse addrVal.ToLower().Contains(searchText) Then

                                Dim idx = Guna2DataGridView1.Rows.Add(supplierIDVal, cnameVal, snameVal, cnoVal, emailVal, addrVal)
                                Guna2DataGridView1.Rows(idx).DefaultCellStyle.BackColor = Color.LightYellow
                                Guna2DataGridView1.Rows(idx).DefaultCellStyle.SelectionBackColor = Color.Orange
                                Guna2DataGridView1.Rows(idx).DefaultCellStyle.SelectionForeColor = Color.Black
                            End If
                        End While
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Error searching suppliers: " & ex.Message)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub


    '=============================
    '       DATAGRID CLICK
    '=============================
    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex < 0 Then Return
        Dim row = Guna2DataGridView1.Rows(e.RowIndex)
        currentSupplierID = Convert.ToInt32(row.Cells("SupplierID").Value)
        currentSupplierName = row.Cells("SupplierName").Value.ToString()

        Label2.Text = "Edit Supplier"

        Select Case Guna2DataGridView1.Columns(e.ColumnIndex).Name
            Case "Edit"
                cname.Text = row.Cells("CompanyName").Value.ToString()
                sname.Text = row.Cells("SupplierName").Value.ToString()
                cno.Text = row.Cells("ContactNo").Value.ToString()
                eml.Text = row.Cells("Email").Value.ToString()
                adrss.Text = row.Cells("Address").Value.ToString()
                Guna2ShadowPanel1.Visible = True
                addbtn.Visible = False
                btnupdate.Visible = True

            Case "Delete"
                deletebtn_Click(currentSupplierID, currentSupplierName)
        End Select
    End Sub

    '=============================
    '       CLEAR
    '=============================
    Private Sub clear()
        cname.Clear() : sname.Clear() : cno.Clear() : eml.Clear() : adrss.Clear()
        currentSupplierID = -1
    End Sub

    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        clear()

    End Sub

    '=============================
    '       ADD NEW BUTTON
    '=============================
    Private Sub btnAddnew_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        Guna2ShadowPanel1.Visible = True
        addbtn.Visible = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Guna2ShadowPanel1.Visible = False
        clear()
        btnupdate.Visible = False
        addbtn.Visible = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub
End Class
