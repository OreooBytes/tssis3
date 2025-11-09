Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient



Public Class Category

    '=============================
    '       DECLARATIONS
    '=============================
    Private WithEvents refreshTimer As New Timer()
    Private categoryTable As New DataTable
    Private Const CornerRadius As Integer = 10 ' fixed radius


    '=============================
    '       FORM LOAD
    '=============================
    Private Sub Category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        categoryTable.Clear()


        updatebtn.Visible = False

        '  dito siya tatawagin para siguradong may columns
        SetupCategoryDataGridView()

        '  pagkatapos mag-setup ng columns, pwede nang mag-load ng data
        LoadData()

        AddHandler cname.KeyPress, AddressOf cname_KeyPress

        ' Timer setup for real-time updates every 1 second (1000ms)
        refreshTimer.Interval = 1000
        refreshTimer.Start()

        Guna2Panel1.BorderColor = ColorTranslator.FromHtml("#D3D3D3") ' light gray
        Guna2Panel1.BorderThickness = 2
        Guna2Panel1.BorderRadius = 5


        ApplyRoundedCorners()

        Guna2DataGridView1.Font = New Font("Outfit", 8, FontStyle.Regular)

        ' I-center ang MainPanel sa form
        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2

        ' ==== DataGridView Font ====
        Guna2DataGridView1.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== TextBoxes Font (Outfit, 9, Regular) ====
        cname.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtSearchCategory.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== Labels Font (Outfit, 9, Bold) ====
        Label1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label3.Font = New Font("Outfit", 9, FontStyle.Bold)


        ' ==== Buttons Font (Outfit, 9, Bold) ====
        Addbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        updatebtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        clearbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        btnAddnew.Font = New Font("Outfit", 9, FontStyle.Bold)


    End Sub



    '=============================
    '   DATAGRIDVIEW SETUP
    '=============================
    Private Sub SetupCategoryDataGridView()
        Guna2DataGridView1.Columns.Clear()

        ' Columns
        Guna2DataGridView1.Columns.Add("CategoryID", "ID")
        Guna2DataGridView1.Columns.Add("CategoryName", "Category Name")
        Guna2DataGridView1.Columns("CategoryID").Visible = False ' Hide ID

        ' Edit column
        If Guna2DataGridView1.Columns("Edit") Is Nothing Then
            Dim editCol As New DataGridViewImageColumn()
            editCol.Name = "Edit"
            editCol.HeaderText = "Edit"
            editCol.Image = My.Resources.icons8_edit_mains
            editCol.ImageLayout = DataGridViewImageCellLayout.Zoom
            Guna2DataGridView1.Columns.Add(editCol)
        End If

        ' Delete column
        If Guna2DataGridView1.Columns("Delete") Is Nothing Then
            Dim deleteCol As New DataGridViewImageColumn()
            deleteCol.Name = "Delete"
            deleteCol.HeaderText = "Delete"
            deleteCol.Image = My.Resources.icons8_delete_mains
            deleteCol.ImageLayout = DataGridViewImageCellLayout.Zoom
            Guna2DataGridView1.Columns.Add(deleteCol)
        End If

        ' === Styling ===
        With Guna2DataGridView1
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 30
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Set FillWeight for proper sizing
            .Columns("CategoryName").FillWeight = 120
            .Columns("Edit").FillWeight = 5
            .Columns("Delete").FillWeight = 5


            ' Header alignment
            .Columns("Edit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Delete").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Icon alignment
            .Columns("Edit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Delete").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With
    End Sub

    '=============================
    '       LOAD DATA
    '=============================
    Private Sub LoadData()
        ' Ensure thread-safe
        If Guna2DataGridView1.InvokeRequired Then
            Guna2DataGridView1.Invoke(Sub() LoadData())
            Return
        End If

        ' Remember selected CategoryID if any
        Dim selectedCategoryID As Integer = -1
        If Guna2DataGridView1.SelectedRows.Count > 0 Then
            Integer.TryParse(Guna2DataGridView1.SelectedRows(0).Cells("CategoryID").Value?.ToString(), selectedCategoryID)
        End If

        ' Clear DataGridView and DataTable
        Guna2DataGridView1.Rows.Clear()
        categoryTable.Clear()

        ' Load categories from database
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim sql As String = "SELECT * FROM category"
                    Using cmd As New MySqlCommand(sql, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            ' Load into DataTable safely
                            categoryTable.Load(reader)
                        End Using
                    End Using
                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using

        ' Populate DataGridView from categoryTable
        For Each row As DataRow In categoryTable.Rows
            ' Safe parsing of CategoryID
            Dim categoryID As Integer = 0
            Integer.TryParse(row("CategoryID")?.ToString(), categoryID)

            Dim index As Integer = Guna2DataGridView1.Rows.Add(categoryID, row("CategoryName").ToString())

            ' Optional Edit/Delete icons
            If Guna2DataGridView1.Columns.Contains("Edit") Then
                'Guna2DataGridView1.Rows(index).Cells("Edit").Value = My.Resources.icons8_pencil_30
            End If
            If Guna2DataGridView1.Columns.Contains("Delete") Then
                'Guna2DataGridView1.Rows(index).Cells("Delete").Value = My.Resources.icons8_delete_30
            End If
        Next

        ' Restore previous selection if possible
        If selectedCategoryID <> -1 Then
            For Each row As DataGridViewRow In Guna2DataGridView1.Rows
                If Integer.TryParse(row.Cells("CategoryID").Value?.ToString(), Nothing) Then
                    If row.Cells("CategoryID").Value = selectedCategoryID Then
                        row.Selected = True
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

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


    '=============================
    '       TIMER EVENT
    '=============================
    'Private Sub refreshTimer_Tick(sender As Object, e As EventArgs) Handles refreshTimer.Tick
    '    ' Only reload if not editing
    '    If Not updatebtn.Visible Then
    '        LoadData()
    '    End If
    'End Sub

    '=============================
    '       CRUD FUNCTIONS
    '=============================
    '=============================
    '       ADD CATEGORY
    '=============================
    Private Sub Addbtn_Click(sender As Object, e As EventArgs) Handles Addbtn.Click
        ' --- Validation ---
        If String.IsNullOrWhiteSpace(cname.Text) Then
            MessageBox.Show("Category name cannot be blank.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cname.Focus()
            Return
        End If

        ' --- Optional: limit category length ---
        If cname.Text.Length > 100 Then
            MessageBox.Show("Category name is too long. Please shorten it.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    ' --- Duplication Check ---
                    Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM category WHERE LOWER(CategoryName)=LOWER(@Name)", conn)
                    checkCmd.Parameters.AddWithValue("@Name", cname.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Category name already exists. Please enter a different name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        cname.Clear()
                        cname.Focus()
                        Return
                    End If

                    ' --- Insert New Category ---
                    Dim cmd As New MySqlCommand("INSERT INTO category (CategoryName) VALUES (@Name)", conn)
                    cmd.Parameters.AddWithValue("@Name", cname.Text.Trim())
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Category added successfully!", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' --- Audit Log ---
                    LogAuditTrail(SessionData.role, SessionData.fullName, "Added new category: " & cname.Text.Trim())

                    ' --- Reset UI ---
                    Guna2ShadowPanel1.Visible = False
                    cname.Clear()
                    LoadData()

                Catch ex As MySqlException
                    MessageBox.Show("Error adding category: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using
    End Sub



    '=============================
    '       UPDATE CATEGORY
    '=============================
    Private Sub updatebtn_Click(sender As Object, e As EventArgs) Handles updatebtn.Click
        ' --- Check Selection ---
        If Guna2DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a category to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = Guna2DataGridView1.SelectedRows(0)
        Dim originalID As Integer = selectedRow.Cells("CategoryID").Value
        Dim originalName As String = selectedRow.Cells("CategoryName").Value.ToString()

        ' --- Validation ---
        If String.IsNullOrWhiteSpace(cname.Text) Then
            MessageBox.Show("Category name cannot be blank.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cname.Focus()
            Return
        End If

        If cname.Text.Length > 100 Then
            MessageBox.Show("Category name is too long. Please shorten it.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Check if any changes were made ---
        Dim updatedFields As New List(Of String)
        If Not String.Equals(originalName.Trim(), cname.Text.Trim(), StringComparison.OrdinalIgnoreCase) Then
            updatedFields.Add($"Category Name: {originalName} → {cname.Text.Trim()}")
        End If

        If updatedFields.Count = 0 Then
            MessageBox.Show("No changes detected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    ' --- Duplication Check ---
                    Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM category WHERE LOWER(CategoryName)=LOWER(@Name) AND CategoryID<>@ID", conn)
                    checkCmd.Parameters.AddWithValue("@Name", cname.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@ID", originalID)

                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Another category with this name already exists. Please choose a different name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        cname.Clear()
                        cname.Focus()
                        Return
                    End If

                    ' --- Update Record ---
                    Dim cmd As New MySqlCommand("UPDATE category SET CategoryName=@Name WHERE CategoryID=@ID", conn)
                    cmd.Parameters.AddWithValue("@Name", cname.Text.Trim())
                    cmd.Parameters.AddWithValue("@ID", originalID)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Category updated successfully!", "Update Category", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' --- Audit Log ---
                    Dim actionDescription As String = "Updated Category:" & vbCrLf & String.Join(vbCrLf, updatedFields)
                    LogAuditTrail(SessionData.role, SessionData.fullName, actionDescription)

                    ' --- Reset UI ---
                    Guna2ShadowPanel1.Visible = False
                    cname.Clear()
                    LoadData()
                    updatebtn.Visible = False
                    Addbtn.Enabled = True

                Catch ex As MySqlException
                    MessageBox.Show("Error updating category: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using
    End Sub

    ' Delete
    Private Sub DeleteCategory(categoryID As Integer, categoryName As String)
        ' ===== Basic Validation =====
        If categoryID <= 0 Then
            MessageBox.Show("No category selected for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' ===== Confirm Deletion =====
        If MessageBox.Show($"Are you sure you want to delete the category '{categoryName}'?",
                       "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Exit Sub
        End If

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn Is Nothing Then
                MessageBox.Show("Failed to connect to database.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Try
                ' ===== Check References =====
                Dim referenceCount As Integer = 0
                Dim checkQuery As String = "SELECT COUNT(*) FROM product WHERE CategoryID=@id"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@id", categoryID)
                    referenceCount = Convert.ToInt32(checkCmd.ExecuteScalar())
                End Using

                If referenceCount > 0 Then
                    MessageBox.Show($"Cannot delete category '{categoryName}' because it is used in one or more products.",
                                "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' ===== Delete Category =====
                Dim deleteQuery As String = "DELETE FROM category WHERE CategoryID=@id"
                Using delCmd As New MySqlCommand(deleteQuery, conn)
                    delCmd.Parameters.AddWithValue("@id", categoryID)
                    Dim rowsAffected As Integer = delCmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        ' ===== Audit Trail =====
                        LogAuditTrail(SessionData.role, SessionData.fullName, $"Deleted category '{categoryName}'")

                        ' ===== Refresh UI =====
                        Guna2ShadowPanel1.Visible = False
                        LoadData()
                        MessageBox.Show($"Category '{categoryName}' deleted successfully!", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Failed to delete category. It might not exist anymore.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using

            Catch ex As MySqlException
                MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error deleting category: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Module1.ConnectionClose(conn)
            End Try
        End Using
    End Sub




    '=============================
    '       DATAGRIDVIEW EVENTS
    '=============================
    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim selectedRow As DataGridViewRow = Guna2DataGridView1.Rows(e.RowIndex)
        Dim categoryID As Integer = selectedRow.Cells("CategoryID").Value
        Dim categoryName As String = selectedRow.Cells("CategoryName").Value.ToString()
        Label1.Text = " Edit Category"

        Select Case Guna2DataGridView1.Columns(e.ColumnIndex).Name
            Case "Edit"
                cname.Text = categoryName
                updatebtn.Visible = True
                Addbtn.Visible = False

                Guna2ShadowPanel1.Visible = True


            Case "Delete"
                DeleteCategory(categoryID, categoryName)
        End Select
    End Sub

    '=============================
    '       PICTURE BOX & BUTTON EVENTS
    '=============================
    Private Sub btnAddnewUser_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        Guna2ShadowPanel1.Visible = True
        cname.Clear()
        updatebtn.Visible = False
        Addbtn.Visible = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Guna2ShadowPanel1.Visible = False
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Addbtn.Enabled = True
        updatebtn.Visible = False

    End Sub

    '=============================
    '       UTILITIES
    '=============================
    Private Sub cname_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtSearchCategory_TextChanged(sender As Object, e As EventArgs) Handles txtSearchCategory.TextChanged
        Dim searchText As String = txtSearchCategory.Text.Trim().ToLower()

        ' Reload all categories if search is empty
        If String.IsNullOrEmpty(searchText) Then
            LoadData()
            Exit Sub
        End If

        ' Clear current DataGridView
        Guna2DataGridView1.Rows.Clear()

        ' Loop through categoryTable to find matches
        For Each row As DataRow In categoryTable.Rows
            Dim categoryName As String = row("CategoryName").ToString()
            Dim categoryID As Integer = 0
            Integer.TryParse(row("CategoryID")?.ToString(), categoryID)

            ' Check if the category name contains the search text
            If categoryName.ToLower().Contains(searchText) Then
                Dim index As Integer = Guna2DataGridView1.Rows.Add(categoryID, categoryName)

                ' Highlight matching row
                Guna2DataGridView1.Rows(index).DefaultCellStyle.BackColor = Color.LightYellow
                Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionBackColor = Color.Orange
                Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Black

                ' Optional: Edit/Delete icons
                If Guna2DataGridView1.Columns.Contains("Edit") Then
                    'Guna2DataGridView1.Rows(index).Cells("Edit").Value = My.Resources.icons8_pencil_30
                End If
                If Guna2DataGridView1.Columns.Contains("Delete") Then
                    ' Guna2DataGridView1.Rows(index).Cells("Delete").Value = My.Resources.icons8_delete_30
                End If
            End If
        Next
    End Sub

    '=============================
    '       Audit Trail
    '=============================
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
                    cmd.Parameters.AddWithValue("@Form", "Categories")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        cname.Clear()

    End Sub
End Class
