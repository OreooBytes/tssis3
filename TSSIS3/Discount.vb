Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class Discount
    Private selectedDiscountID As Integer = -1

    Private discountTable As New DataTable

    Private Const CornerRadius As Integer = 10 ' fixed radius


    Private Sub Discount_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
        End Using

        SetupDiscountDataGridView()   ' ensure DataGridView columns exist

        ' Setup discountTable columns
        discountTable.Columns.Clear()
        discountTable.Columns.Add("DiscountType", GetType(String))
        discountTable.Columns.Add("DiscountPercent", GetType(String))

        LoadData()
        updatebtn.Visible = False


        Guna2Panel1.BorderColor = ColorTranslator.FromHtml("#D3D3D3") ' light gray
        Guna2Panel1.BorderThickness = 2
        Guna2Panel1.BorderRadius = 5


        Guna2DataGridView1.Font = New Font("Outfit", 8, FontStyle.Regular)

        ' I-center ang MainPanel sa form
        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2



        ApplyRoundedCorners()

        ' ==== TextBoxes (Regular) ====
        dscnt.Font = New Font("Outfit", 9, FontStyle.Regular)
        dscnttype.Font = New Font("Outfit", 9, FontStyle.Regular)
        txtSearch.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== Labels (Bold) ====
        Label3.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label11.Font = New Font("Outfit", 9, FontStyle.Bold)
        labelforbutton.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ==== Buttons (Bold) ====
        addbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        updatebtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        clearbtn.Font = New Font("Outfit", 10, FontStyle.Bold)
        btnupdateloyalty.Font = New Font("Outfit", 9, FontStyle.Bold)
        btnAddnewDiscount.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ==== DataGridView Font (Regular) ====
        Guna2DataGridView1.Font = New Font("Outfit", 9, FontStyle.Regular)


    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === DEFAULT COLORS & IMAGES ===
        btnAddnewDiscount.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnAddnewDiscount.ForeColor = Color.White
        btnAddnewDiscount.Image = My.Resources.icons8_add_30_normal ' normal icon

        btnupdateloyalty.FillColor = ColorTranslator.FromHtml("#1D3A70")
        btnupdateloyalty.ForeColor = Color.White
        'btnSort.Image = My.Resources.icons8_alphabetical_sorting_normal ' normal icon


        ' === HOVER EFFECTS FOR btnAddnewUsar ===
        AddHandler btnAddnewDiscount.MouseEnter, Sub()
                                                     btnAddnewDiscount.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                     btnAddnewDiscount.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                     btnAddnewDiscount.Image = My.Resources.icons8_add_30_hindi ' hover icon
                                                 End Sub

        AddHandler btnAddnewDiscount.MouseLeave, Sub()
                                                     btnAddnewDiscount.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                     btnAddnewDiscount.ForeColor = Color.White
                                                     btnAddnewDiscount.Image = My.Resources.icons8_add_30_normal ' back to normal
                                                 End Sub


        ' === HOVER EFFECTS FOR btnSort ===
        AddHandler btnupdateloyalty.MouseEnter, Sub()
                                                    btnupdateloyalty.FillColor = ColorTranslator.FromHtml("#FFD93D")
                                                    btnupdateloyalty.ForeColor = ColorTranslator.FromHtml("#0B2447")
                                                    btnupdateloyalty.Image = My.Resources.icons8_update_hindi ' hover icon
                                                End Sub

        AddHandler btnupdateloyalty.MouseLeave, Sub()
                                                    btnupdateloyalty.FillColor = ColorTranslator.FromHtml("#1D3A70")
                                                    btnupdateloyalty.ForeColor = Color.White
                                                    btnupdateloyalty.Image = My.Resources.icons8_update_normal  ' normal icon
                                                End Sub


        ' === OPTIONAL: CENTER THE FORM ON SCREEN ===
        Me.StartPosition = FormStartPosition.CenterScreen
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


    Private Sub LoadData()
        ' Ensure columns exist first
        If Guna2DataGridView1.Columns.Count = 0 Then
            SetupDiscountDataGridView()
        End If

        Guna2DataGridView1.Rows.Clear()
        discountTable.Clear()  ' Clear previous data

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim sql As String = "SELECT * FROM discount WHERE LOWER(DiscountType) <> 'nodiscount'"
                    Using cmd As New MySqlCommand(sql, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                Dim dscnttype As String = reader("DiscountType").ToString()
                                Dim dscnt As String = reader("DiscountPercent").ToString() & "%"

                                ' Add to DataGridView
                                Guna2DataGridView1.Rows.Add(dscnttype, dscnt)

                                ' Add to discountTable for searching
                                Dim dr As DataRow = discountTable.NewRow()
                                dr("DiscountType") = dscnttype
                                dr("DiscountPercent") = dscnt
                                discountTable.Rows.Add(dr)
                            End While
                        End Using
                    End Using
                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using
    End Sub



    Private Sub dscnttype_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dscnttype.KeyPress
        ' Check if the key is NOT a letter or space or control key (like Backspace)
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True ' Bawal ang key

        End If
    End Sub


    ' ==========================
    ' ✅ DISCOUNT TEXTBOX VALIDATION (dscnt TextBox)
    ' ==========================

    ' ====== KEY PRESS VALIDATION ======
    Private Sub dscnt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dscnt.KeyPress
        ' Allow digits, backspace, and one decimal point
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        If e.KeyChar = "."c AndAlso dscnt.Text.Replace("%", "").Contains(".") Then
            e.Handled = True
        End If
    End Sub

    ' ====== TEXT CHANGED: ALWAYS KEEP % SYMBOL ======
    Private Sub dscnt_TextChanged(sender As Object, e As EventArgs) Handles dscnt.TextChanged
        ' Remove any existing %
        Dim textWithoutPercent As String = dscnt.Text.Replace("%", "")

        ' Remove invalid characters (anything except digits and dot)
        textWithoutPercent = Regex.Replace(textWithoutPercent, "[^0-9.]", "")

        If textWithoutPercent = "" Then
            ' Clear the box completely if nothing left
            dscnt.Text = ""
        Else
            ' Otherwise, re-add % at the end
            Dim cursorPos As Integer = dscnt.SelectionStart
            dscnt.Text = textWithoutPercent & "%"
            dscnt.SelectionStart = Math.Min(cursorPos, dscnt.Text.Length - 1)
        End If
    End Sub

    ' ====== LEAVE EVENT ======
    Private Sub dscnt_Leave(sender As Object, e As EventArgs) Handles dscnt.Leave
        ' Clear if only % is left
        If dscnt.Text = "%" Then
            dscnt.Clear()
        End If
    End Sub


    '==========================
    ' ADD DISCOUNT
    '==========================
    Private Sub addbtn_Click(sender As Object, e As EventArgs) Handles addbtn.Click
        Dim discountType As String = dscnttype.Text.Trim()
        Dim discountPercent As Decimal
        Dim inputPercent As String = dscnt.Text.Replace("%", "")

        ' --- VALIDATION ---
        If String.IsNullOrEmpty(discountType) Then
            MessageBox.Show("Please enter a discount type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not Decimal.TryParse(inputPercent, discountPercent) Then
            MessageBox.Show("Please enter a valid discount percentage.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DiscountTypeExists(discountType) Then
            MessageBox.Show("Discount type already exists. Please choose a different name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- INSERT INTO DATABASE ---
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim sql As String = "INSERT INTO discount (DiscountType, DiscountPercent) VALUES (@DiscountType, @DiscountPercent)"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@DiscountType", discountType)
                        cmd.Parameters.AddWithValue("@DiscountPercent", discountPercent)
                        cmd.ExecuteNonQuery()

                        MessageBox.Show("Discount added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' --- AUDIT LOGGING ---
                        LogAuditTrail(SessionData.role, SessionData.fullName, $"Added new discount type: {discountType} ({discountPercent}%)")
                    End Using
                Catch ex As MySqlException
                    MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using

        Guna2ShadowPanel1.Visible = False
        LoadData()
        ClearInputs()
    End Sub

    '==========================
    ' UPDATE DISCOUNT
    '==========================
    Private Sub updatebtn_Click(sender As Object, e As EventArgs) Handles updatebtn.Click
        If selectedDiscountID = -1 Then
            MessageBox.Show("Please select a discount to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            addbtn.Enabled = True
            Return
        End If

        Dim discountType As String = dscnttype.Text.Trim()
        Dim discountPercent As Decimal
        Dim inputPercent As String = dscnt.Text.Replace("%", "")

        ' --- VALIDATION ---
        If String.IsNullOrEmpty(discountType) Then
            MessageBox.Show("Please enter a discount type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            addbtn.Enabled = True
            Return
        End If

        If Not Decimal.TryParse(inputPercent, discountPercent) Then
            MessageBox.Show("Please enter a valid discount percentage.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            addbtn.Enabled = True
            Return
        End If

        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim selectedRow As DataGridViewRow = Guna2DataGridView1.SelectedRows(0)
                    Dim originalDiscount As String = selectedRow.Cells("DiscountName").Value.ToString()

                    ' --- GET CURRENT VALUES ---
                    Dim currentType As String = ""
                    Dim currentPercent As Decimal = 0
                    Dim getCurrentCmd As New MySqlCommand("SELECT DiscountType, DiscountPercent FROM discount WHERE DiscountType = @originalDiscount", conn)
                    getCurrentCmd.Parameters.AddWithValue("@originalDiscount", originalDiscount)

                    Using reader As MySqlDataReader = getCurrentCmd.ExecuteReader()
                        If reader.Read() Then
                            currentType = reader("DiscountType").ToString()
                            currentPercent = Convert.ToDecimal(reader("DiscountPercent"))
                        End If
                    End Using

                    ' --- DUPLICATE CHECK ---
                    Dim checkDiscountTypeCmd As New MySqlCommand("
                    SELECT COUNT(*) FROM discount
                    WHERE (LOWER(DiscountType) = LOWER(@DiscountType) OR LOWER(DiscountType) = LOWER(@DiscountTypeWithS))
                    AND DiscountType <> @originalDiscount", conn)
                    checkDiscountTypeCmd.Parameters.AddWithValue("@DiscountType", discountType.ToLower())
                    checkDiscountTypeCmd.Parameters.AddWithValue("@DiscountTypeWithS", If(discountType.ToLower().EndsWith("s"), discountType.ToLower().TrimEnd("s"c), discountType.ToLower() & "s"))
                    checkDiscountTypeCmd.Parameters.AddWithValue("@originalDiscount", originalDiscount)

                    Dim discountExist As Integer = Convert.ToInt32(checkDiscountTypeCmd.ExecuteScalar())
                    If discountExist > 0 Then
                        MessageBox.Show("Discount type already exists. Please choose a different name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dscnttype.Clear()
                        addbtn.Enabled = True
                        Return
                    End If

                    ' --- CHECK IF ANY CHANGE ---
                    Dim updatedFields As New List(Of String)
                    If currentType <> discountType Then updatedFields.Add($"Type: '{currentType}' → '{discountType}'")
                    If currentPercent <> discountPercent Then updatedFields.Add($"Percent: {currentPercent}% → {discountPercent}%")

                    If updatedFields.Count > 0 Then
                        Dim cmd As New MySqlCommand("UPDATE discount SET DiscountPercent = @DiscountPercent, DiscountType = @DiscountType WHERE DiscountType = @originalDiscount", conn)
                        cmd.Parameters.AddWithValue("@DiscountType", discountType)
                        cmd.Parameters.AddWithValue("@DiscountPercent", discountPercent)
                        cmd.Parameters.AddWithValue("@originalDiscount", originalDiscount)
                        cmd.ExecuteNonQuery()

                        MessageBox.Show("Discount updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' --- AUDIT LOGGING ---
                        Dim actionDescription As String = "Updated discount:" & vbCrLf & String.Join(vbCrLf, updatedFields)
                        LogAuditTrail(SessionData.role, SessionData.fullName, actionDescription)
                    Else
                        MessageBox.Show("No changes were made.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    addbtn.Enabled = True
                    LoadData()
                    ClearInputs()
                    Guna2ShadowPanel1.Visible = False

                Catch ex As MySqlException
                    MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using
    End Sub


    ' ✅ ginawa kong Friend para matawag sa ibang Sub
    Friend Sub deletebtn_Click(sender As Object, e As EventArgs)
        ' --- CHECK SELECTION ---
        If selectedDiscountID = -1 Then
            MessageBox.Show("Please select a discount to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim discountType As String = dscnttype.Text.Trim()

        ' --- CONFIRM DELETE ---
        Dim confirmResult As DialogResult = MessageBox.Show(
        $"Are you sure you want to delete the discount type '{discountType}'?",
        "Confirm Delete",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning)

        If confirmResult = DialogResult.Yes Then
            Using conn As MySqlConnection = Module1.Openconnection()
                If conn IsNot Nothing Then
                    Try
                        Dim sql As String = "DELETE FROM discount WHERE DiscountType = @DiscountType"
                        Using cmd As New MySqlCommand(sql, conn)
                            cmd.Parameters.AddWithValue("@DiscountType", discountType)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' --- SUCCESS MESSAGE ---
                        MessageBox.Show("Discount type deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' --- AUDIT LOGGING ---
                        Try
                            LogAuditTrail(SessionData.role, SessionData.fullName, $"Deleted discount type: {discountType}")
                        Catch ex As Exception
                            ' Ignore logging errors
                        End Try

                        addbtn.Enabled = True

                    Catch ex As MySqlException
                        MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        Module1.ConnectionClose(conn)
                    End Try
                End If
            End Using

            LoadData()
            ClearInputs()
        Else
            ' If user cancels deletion
            ClearInputs()
            addbtn.Enabled = True
        End If

        Guna2ShadowPanel1.Visible = False
    End Sub



    Private Sub SetupDiscountDataGridView()
        ' Clear previous columns
        Guna2DataGridView1.Columns.Clear()
        Guna2DataGridView1.AllowUserToAddRows = False

        ' =============================
        '       ADD DATA COLUMNS
        ' =============================
        Dim columns As (String, String)() = {
        ("DiscountName", "Discount Type"),
        ("Percentage", "Percentage")
    }

        For Each col In columns
            Dim dgvCol As New DataGridViewTextBoxColumn() With {
            .Name = col.Item1,
            .HeaderText = col.Item2,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .AllowUserToAddRows = False
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Lock column widths for Edit/Delete
            For Each col As DataGridViewColumn In .Columns
                If col.Name = "Edit" OrElse col.Name = "Delete" Then
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Else
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            Next
        End With
    End Sub



    Private Sub Guna2DataGridView1CellContentClick_Click(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Guna2DataGridView1.Rows(e.RowIndex)

            ' Check kung Edit column
            If e.ColumnIndex = Guna2DataGridView1.Columns("Edit").Index Then
                dscnttype.Text = row.Cells("DiscountName").Value.ToString()
                dscnt.Text = row.Cells("Percentage").Value.ToString().Replace("%", "") ' ✅ tanggalin % para editable
                selectedDiscountID = e.RowIndex
                addbtn.Visible = False
                updatebtn.Visible = True


                labelforbutton.Text = "Edit Discount"

                Guna2ShadowPanel1.Visible = True

                ' Check kung Delete column
            ElseIf e.ColumnIndex = Guna2DataGridView1.Columns("Delete").Index Then
                dscnttype.Text = row.Cells("DiscountName").Value.ToString()
                selectedDiscountID = e.RowIndex
                ' Tawagin yung delete button click
                deletebtn_Click(Nothing, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub ClearInputs()
        dscnttype.Clear()
        dscnt.Clear()
        selectedDiscountID = -1
    End Sub

    Private Function DiscountTypeExists(discountType As String, Optional currentDiscountType As String = "") As Boolean
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim sql As String = "SELECT COUNT(*) FROM discount WHERE (DiscountType = @DiscountType OR DiscountType = @DiscountTypeS)"
                    sql &= " AND DiscountType <> @CurrentDiscountType"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@DiscountType", discountType)
                        cmd.Parameters.AddWithValue("@DiscountTypeS", If(discountType.EndsWith("s"), discountType.Substring(0, discountType.Length - 1), discountType & "s"))
                        cmd.Parameters.AddWithValue("@CurrentDiscountType", currentDiscountType)
                        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        Return count > 0
                    End Using
                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                    Return True
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using
        Return False
    End Function

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
                    cmd.Parameters.AddWithValue("@Form", "Discounts")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBoxexit_Click(sender As Object, e As EventArgs) Handles PictureBoxexit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        Guna2ShadowPanel1.Visible = False
        ClearInputs()
        LoadData()
        updatebtn.Visible = False
        addbtn.Visible = True
    End Sub

    Private Sub btnAddnewDiscount_Click(sender As Object, e As EventArgs) Handles btnAddnewDiscount.Click
        addbtn.Visible = True
        updatebtn.Visible = False

        Guna2ShadowPanel1.Visible = True
        labelforbutton.Text = "Add Discount"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' Make sure columns exist first
        If Guna2DataGridView1.Columns.Count = 0 Then Exit Sub

        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        If String.IsNullOrEmpty(searchText) Then
            LoadData()
            Exit Sub
        End If

        Guna2DataGridView1.Rows.Clear()

        ' Filter discountTable
        For Each row As DataRow In discountTable.Rows
            Dim dscntType As String = row("DiscountType").ToString()
            Dim dscntPercent As String = row("DiscountPercent").ToString()

            If dscntType.ToLower().Contains(searchText) Then
                Dim index As Integer = Guna2DataGridView1.Rows.Add(dscntType, dscntPercent)

                Guna2DataGridView1.Rows(index).DefaultCellStyle.BackColor = Color.LightYellow
                Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionBackColor = Color.Orange
                Guna2DataGridView1.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnupdateloyalty.Click
        Dim loyalty As New LoyaltyDiscount
        LoyaltyDiscount.ShowDialog()
    End Sub

    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        dscnt.Clear()
        dscnttype.Clear()
    End Sub
End Class
