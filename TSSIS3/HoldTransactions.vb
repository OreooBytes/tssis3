Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class HoldTransactions

    ' Reference sa POS form
    Private pos As POS
    Private Const CornerRadius As Integer = 10 ' fixed radius

    ' Constructor: kailangan para ma-pass ang POS form instance
    Public Sub New(posForm As POS)
        InitializeComponent()
        Me.pos = posForm
    End Sub

    ' ================== LOAD FORM ==================
    Private Sub HoldTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadHoldTransactions()

        ' Add Select button column kung wala pa
        If dgvHoldTransactions.Columns("Select") Is Nothing Then
            Dim btnColumn As New DataGridViewButtonColumn() With {
                .Name = "Select",
                .HeaderText = "Action",
                .Text = "Retrieve",
                .UseColumnTextForButtonValue = True
            }
            dgvHoldTransactions.Columns.Add(btnColumn)
        End If

        BackColor = ColorTranslator.FromHtml("#0B2447")
        ApplyRoundedCorners()
        SetupAuditTrailGrid()

        ' ===== DataGridView styling =====
        dgvHoldTransactions.ColumnHeadersDefaultCellStyle.Font = New Font("Outfit", 9, FontStyle.Bold)
        dgvHoldTransactions.DefaultCellStyle.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== TextBox styling =====
        txtsearch.Font = New Font("Outfit", 9, FontStyle.Regular)
    End Sub

    ' ================== Apply Rounded Corners ==================
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

    ' ================== Setup Grid ==================
    Private Sub SetupAuditTrailGrid()
        With dgvHoldTransactions
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowTemplate.Height = 35
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        End With
    End Sub

    ' ================== Load Held Transactions ==================
    Private Sub LoadHoldTransactions()
        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
            Dim sql As String = "SELECT HoldID, TransactionNo, DateHeld, Cashier, SaleType, Discount, VAT " &
                                "FROM hold_transactions ORDER BY DateHeld DESC"
            Using cmd As New MySqlCommand(sql, conn)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvHoldTransactions.DataSource = dt
            End Using
        End Using

        ' Hide HoldID and SaleType columns
        If dgvHoldTransactions.Columns.Contains("HoldID") Then dgvHoldTransactions.Columns("HoldID").Visible = False
        If dgvHoldTransactions.Columns.Contains("SaleType") Then dgvHoldTransactions.Columns("SaleType").Visible = False

        ' Format DateHeld column
        If dgvHoldTransactions.Columns.Contains("DateHeld") Then
            dgvHoldTransactions.Columns("DateHeld").DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt"
        End If

        ' Apply consistent row height
        For Each row As DataGridViewRow In dgvHoldTransactions.Rows
            row.Height = 35
        Next
    End Sub

    ' ================== Retrieve Button Click ==================
    Private Sub dgvHoldTransactions_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHoldTransactions.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvHoldTransactions.Columns(e.ColumnIndex).Name = "Select" Then
            Dim holdID As Integer = CInt(dgvHoldTransactions.Rows(e.RowIndex).Cells("HoldID").Value)
            Dim transactionNo As String = dgvHoldTransactions.Rows(e.RowIndex).Cells("TransactionNo").Value.ToString()
            RetrieveHoldTransaction(holdID, transactionNo)
        End If
    End Sub

    ' ================== Retrieve Held Transaction ==================
    Private Sub RetrieveHoldTransaction(holdID As Integer, transactionNo As String)
        Try
            ' Table para sa held items
            Dim itemsTable As New DataTable()

            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' 1️⃣ Kunin ang held items
                Dim sqlSelect As String = "SELECT BarcodeID, ProductName, Quantity, UnitPrice, Total " &
                                          "FROM hold_transaction_items WHERE HoldID=@HoldID"
                Using cmd As New MySqlCommand(sqlSelect, conn)
                    cmd.Parameters.AddWithValue("@HoldID", holdID)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(itemsTable)
                    End Using
                End Using

                ' 2️⃣ Delete held items
                Dim sqlDeleteItems As String = "DELETE FROM hold_transaction_items WHERE HoldID=@HoldID"
                Using cmd As New MySqlCommand(sqlDeleteItems, conn)
                    cmd.Parameters.AddWithValue("@HoldID", holdID)
                    cmd.ExecuteNonQuery()
                End Using

                ' 3️⃣ Delete main hold record
                Dim sqlDeleteTransaction As String = "DELETE FROM hold_transactions WHERE HoldID=@HoldID"
                Using cmd As New MySqlCommand(sqlDeleteTransaction, conn)
                    cmd.Parameters.AddWithValue("@HoldID", holdID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' 4️⃣ Load held items sa POS
            pos.LoadHeldItems(itemsTable, transactionNo)

            ' 5️⃣ Notify user
            MessageBox.Show("Held transaction retrieved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 6️⃣ Close this form
            Me.Close()

            ' 7️⃣ Log Audit Trail
            LogAuditTrail(SessionData.role, SessionData.fullName, $"Retrieved held transaction: {transactionNo}")

        Catch ex As Exception
            MessageBox.Show("Error retrieving held transaction: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================== Audit Trail ==================
    Private Sub LogAuditTrail(role As String, fullName As String, action As String)
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

    ' ================== Search Held Transactions ==================
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim searchText As String = txtsearch.Text.Trim().ToLower()
        If String.IsNullOrEmpty(searchText) Then
            LoadHoldTransactions()
            Exit Sub
        End If

        Dim dt As DataTable = TryCast(dgvHoldTransactions.DataSource, DataTable)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Exit Sub

        Dim dv As New DataView(dt)
        dv.RowFilter = String.Format(
            "CONVERT(TransactionNo, 'System.String') LIKE '%{0}%' OR " &
            "CONVERT(Cashier, 'System.String') LIKE '%{0}%' OR " &
            "CONVERT(SaleType, 'System.String') LIKE '%{0}%' OR " &
            "CONVERT(Discount, 'System.String') LIKE '%{0}%' OR " &
            "CONVERT(VAT, 'System.String') LIKE '%{0}%' OR " &
            "CONVERT(DateHeld, 'System.String') LIKE '%{0}%'",
            searchText.Replace("'", "''")
        )

        dgvHoldTransactions.DataSource = dv
        For Each row As DataGridViewRow In dgvHoldTransactions.Rows
            row.DefaultCellStyle.BackColor = Color.LightYellow
            row.DefaultCellStyle.SelectionBackColor = Color.Orange
            row.DefaultCellStyle.SelectionForeColor = Color.Black
        Next
    End Sub

    ' ================== Close Form ==================
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub

End Class
