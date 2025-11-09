Imports Guna.UI.WinForms
Imports MySql.Data.MySqlClient

Public Class DeliveryList

    ' Set default date to today on form load and load all deliveries data
    Private Sub DeliveryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        dptStartDate.Value = DateTime.Today
        dptEndDate.Value = DateTime.Today

        SetupDataGrid()

        LoadDeliveriesData()

        dptStartDate.FillColor = ColorTranslator.FromHtml("#0B2447")

        dptEndDate.FillColor = ColorTranslator.FromHtml("#0B2447")

        BackColor = ColorTranslator.FromHtml("#0B2447")
        Panel1.BackColor = Color.Gainsboro

        ' ===== DataGridView =====
        dgvDeliveriesList.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== TextBox =====
        txtSearchSupplier.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ===== DateTimePickers =====
        dptStartDate.Font = New Font("Outfit", 9, FontStyle.Bold)
        dptEndDate.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ===== Labels / HtmlLabels =====
        Guna2HtmlLabel1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Guna2HtmlLabel2.Font = New Font("Outfit", 9, FontStyle.Bold)

    End Sub

    ' Function to load deliveries data based on a date range
    Private Sub LoadDeliveriesData(Optional ByVal startDate As DateTime? = Nothing, Optional ByVal endDate As DateTime? = Nothing)
        If dgvDeliveriesList.Columns.Contains("RemainingQty") Then
            dgvDeliveriesList.Columns("RemainingQty").Visible = False
        End If
        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' ===== Base Query =====
                Dim query As String =
"SELECT 
    d.id,
    d.TransactionNumber,
    d.BatchNumber,
    d.BarcodeID,
    d.ProductName,
    d.SupplierID,
    DATE_FORMAT(d.ReceiveDate, '%Y-%m-%d') AS ReceiveDate,
    d.Quantity,
    d.RemainingQty,
    d.CostPrice,
    d.UnitPrice,
    d.TotalCost,
    d.ReceivedBy,
    CASE 
        WHEN d.ExpirationDate IS NULL OR d.ExpirationDate = '' OR d.ExpirationDate = '0000-00-00'
        THEN 'No Expiration'
        ELSE DATE_FORMAT(d.ExpirationDate, '%Y-%m-%d')
    END AS ExpirationDate,
    CASE 
        WHEN d.OriginalExpirationDate IS NULL OR d.OriginalExpirationDate = '' OR d.OriginalExpirationDate = '0000-00-00'
        THEN 'No Expiration'
        ELSE DATE_FORMAT(d.OriginalExpirationDate, '%Y-%m-%d')
    END AS OriginalExpirationDate
FROM deliveries d
WHERE 1=1"

                ' ===== Apply Date Filter =====
                If startDate.HasValue AndAlso endDate.HasValue Then
                    query &= " AND DATE(d.ReceiveDate) BETWEEN @StartDate AND @EndDate"
                Else
                    query &= " AND DATE(d.ReceiveDate) = CURDATE()"
                End If

                ' ===== Execute Query =====
                Using cmd As New MySqlCommand(query, conn)
                    If startDate.HasValue AndAlso endDate.HasValue Then
                        cmd.Parameters.AddWithValue("@StartDate", startDate.Value.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@EndDate", endDate.Value.ToString("yyyy-MM-dd"))
                    End If

                    Dim dt As New DataTable()
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using

                    ' ===== Bind Data to DataGridView =====
                    dgvDeliveriesList.Columns.Clear()
                    dgvDeliveriesList.DataSource = Nothing
                    dgvDeliveriesList.DataSource = dt

                    deliveriesTable = dt.Copy()

                    ' ===== Hide Columns =====
                    If dgvDeliveriesList.Columns.Contains("id") Then dgvDeliveriesList.Columns("id").Visible = False
                    If dgvDeliveriesList.Columns.Contains("RemainingQty") Then dgvDeliveriesList.Columns("RemainingQty").Visible = False
                    If dgvDeliveriesList.Columns.Contains("OriginalExpirationDate") Then dgvDeliveriesList.Columns("OriginalExpirationDate").Visible = False

                    ' ===== Prevent Auto Date Formatting =====
                    If dgvDeliveriesList.Columns.Contains("ReceiveDate") Then dgvDeliveriesList.Columns("ReceiveDate").DefaultCellStyle.Format = ""
                    If dgvDeliveriesList.Columns.Contains("ExpirationDate") Then dgvDeliveriesList.Columns("ExpirationDate").DefaultCellStyle.Format = ""

                    ' ===== Clean Selection =====
                    dgvDeliveriesList.ClearSelection()
                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading deliveries: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    ' ==============================
    ' DataGridView Styling
    ' ==============================
    Private Sub SetupDataGrid()
        With dgvDeliveriesList
            ' Disable the default header styles to apply custom styling
            .EnableHeadersVisualStyles = False

            ' Customize the header style
            .ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1D3A70")  ' Blue header color
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White  ' White text for the header
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft  ' Center-align the header text
            .ColumnHeadersHeight = 30  ' Header row height

            ' Customize the default cell style
            .DefaultCellStyle.ForeColor = Color.Black  ' Set text color for rows
            .DefaultCellStyle.BackColor = Color.White  ' Set background color for rows
            .DefaultCellStyle.SelectionBackColor = Color.White   ' Highlight color for selected rows
            .DefaultCellStyle.SelectionForeColor = Color.Black  ' Text color for selected rows

            ' Set the grid to be read-only (no editing)
            .ReadOnly = True

            ' Set the selection mode to full row select
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            ' Disable adding new rows through the UI
            .AllowUserToAddRows = False

            ' Set row height
            .RowTemplate.Height = 30

            ' Set auto-size mode to fill the entire DataGridView width
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Optionally, set a fixed width for certain columns
            .Columns("TransactionNumber").Width = 120  ' Example column with fixed width
            .Columns("ProductName").Width = 200  ' Wider column for ProductName
            .Columns("ReceiveDate").Width = 120  ' Fixed width for ReceiveDate column

            ' If you need to auto-size individual columns based on their content, you can adjust those
            For Each column As DataGridViewColumn In .Columns
                If column.Width < 80 Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next

            ' Optional: Customize the row style for better readability
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray  ' Alternate row color for better readability
        End With
    End Sub



    Private Sub dptStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dptStartDate.ValueChanged
        LoadDeliveriesData(dptStartDate.Value, dptEndDate.Value)
    End Sub

    Private Sub dptEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dptEndDate.ValueChanged
        LoadDeliveriesData(dptStartDate.Value, dptEndDate.Value)
    End Sub

    '========= FOR ALT F4 =========
    Private Sub ViewReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?",
           "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()

        End If
    End Sub

    ' Add this at the top of the class (to store the full dataset for searching)
    Private deliveriesTable As DataTable

    Private Sub txtSearchSupplier_TextChanged(sender As Object, e As EventArgs) Handles txtSearchSupplier.TextChanged
        Try
            If deliveriesTable Is Nothing Then Exit Sub

            Dim searchText As String = txtSearchSupplier.Text.Trim().ToLower()
            Dim tempTable As DataTable = deliveriesTable.Clone()

            ' === If search is empty, show all data ===
            If String.IsNullOrEmpty(searchText) Then
                For Each row As DataRow In deliveriesTable.Rows
                    tempTable.ImportRow(row)
                Next
                dgvDeliveriesList.DataSource = tempTable

                ' Reset colors
                For Each row As DataGridViewRow In dgvDeliveriesList.Rows
                    row.DefaultCellStyle.BackColor = Color.White
                    row.DefaultCellStyle.SelectionBackColor = Color.White
                    row.DefaultCellStyle.SelectionForeColor = Color.Black
                Next
                Return
            End If

            ' === Filter the deliveries by common fields ===
            Dim filteredRows = deliveriesTable.AsEnumerable().Where(Function(r) _
                r("TransactionNumber").ToString().ToLower().Contains(searchText) OrElse
                r("ProductName").ToString().ToLower().Contains(searchText) OrElse
                r("BarcodeID").ToString().ToLower().Contains(searchText) OrElse
                r("SupplierID").ToString().ToLower().Contains(searchText) OrElse
                r("ReceivedBy").ToString().ToLower().Contains(searchText)
            )

            ' === Add filtered rows to temporary table ===
            For Each row In filteredRows
                tempTable.ImportRow(row)
            Next

            ' === Bind filtered data ===
            dgvDeliveriesList.DataSource = tempTable

            ' === Apply highlight to filtered results ===
            For Each row As DataGridViewRow In dgvDeliveriesList.Rows
                row.DefaultCellStyle.BackColor = Color.LightYellow
                row.DefaultCellStyle.SelectionBackColor = Color.Orange
                row.DefaultCellStyle.SelectionForeColor = Color.Black
            Next

        Catch ex As Exception
            MessageBox.Show("Error during search: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
