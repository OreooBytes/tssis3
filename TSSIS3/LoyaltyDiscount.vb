Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class LoyaltyDiscount
    Private Const CornerRadius As Integer = 10
    Private latestId As Integer

    Private priceToGainPoint As Decimal = 0 ' 👈 Declared here

    ' Place near top of class (e.g., after latestId)
    Private suppressPercentHandler As Boolean = False

    ' Called when the discount TextBox changes — ensures only digits/one dot and appends "%"
    Private Sub UpdatedLoyaltyDiscount_TextChanged(sender As Object, e As EventArgs)
        If suppressPercentHandler Then Return
        Try
            Dim controlText As String = ""
            Dim isGuna As Boolean = False

            If TypeOf sender Is Guna.UI2.WinForms.Guna2TextBox Then
                controlText = CType(sender, Guna.UI2.WinForms.Guna2TextBox).Text
                isGuna = True
            ElseIf TypeOf sender Is TextBox Then
                controlText = CType(sender, TextBox).Text
            Else
                Return
            End If

            ' remove existing percent sign and spaces
            Dim raw As String = controlText.Replace("%"c, "").Trim()

            ' keep only digits and at most one dot
            Dim cleaned As New System.Text.StringBuilder()
            Dim dotSeen As Boolean = False
            For Each ch As Char In raw
                If Char.IsDigit(ch) Then
                    cleaned.Append(ch)
                ElseIf ch = "."c AndAlso Not dotSeen Then
                    dotSeen = True
                    cleaned.Append(ch)
                End If
            Next

            Dim newRaw As String = cleaned.ToString()

            ' If empty, keep empty (no "%")
            Dim display As String = If(String.IsNullOrEmpty(newRaw), "", newRaw & "%")

            suppressPercentHandler = True
            If isGuna Then
                Dim tb = CType(sender, Guna.UI2.WinForms.Guna2TextBox)
                tb.Text = display
                ' place caret before the '%' so user continues editing number
                If String.IsNullOrEmpty(display) Then
                    tb.SelectionStart = 0
                Else
                    tb.SelectionStart = Math.Max(0, display.Length - 1)
                End If
            Else
                Dim tb = CType(sender, TextBox)
                tb.Text = display
                If String.IsNullOrEmpty(display) Then
                    tb.SelectionStart = 0
                Else
                    tb.SelectionStart = Math.Max(0, display.Length - 1)
                End If
            End If
        Catch
            ' non-fatal
        Finally
            suppressPercentHandler = False
        End Try
    End Sub

    ' === ROUND CORNERS ===
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
    End Sub

    ' === LOAD DATA ===
    Private Sub LoadData()
        Using conn As MySqlConnection = Module1.Openconnection()
            Try
                Dim sql As String = "SELECT * FROM loyaltydiscount ORDER BY id DESC LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            latestId = reader.GetInt32("id")
                            Guna2TextBox1.Text = reader.GetDecimal("PriceToGainPoint").ToString("0.00")
                            curlyltydscnt.Text = reader.GetDecimal("Currentloyaltydiscount").ToString("0.00") & "%"
                            txtupdatedredeemablepoints.Text = reader.GetInt32("RedeemablePoints").ToString()
                        Else
                            latestId = 0
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading data: " & ex.Message)
            End Try
        End Using
    End Sub

    ' === UPDATE BUTTON CLICK ===
    Private Sub updatebtn_Click(sender As Object, e As EventArgs) Handles updatebtn.Click
        Try
            Dim newDisc As Double = 0
            Dim newRedeem As Integer = 0
            Dim newPrice As Double = 0

            ' Read raw inputs (strip trailing % for disc/price)
            Dim discInput As String = If(updatedlyltydcsnt.Text IsNot Nothing, updatedlyltydcsnt.Text.Replace("%"c, "").Trim(), "")
            Dim priceInput As String = If(Guna2TextBox2.Text IsNot Nothing, Guna2TextBox2.Text.Replace("%"c, "").Trim(), "")
            Dim redeemInput As String = If(txtredeemablepoints.Text IsNot Nothing, txtredeemablepoints.Text.Trim(), "")

            ' Only attempt parse if user provided something — empty means "no change"
            Dim hasDisc As Boolean = False
            Dim hasPrice As Boolean = False
            Dim hasRedeem As Boolean = False

            If discInput <> "" Then hasDisc = Double.TryParse(discInput, newDisc)
            If priceInput <> "" Then hasPrice = Double.TryParse(priceInput, newPrice)
            If redeemInput <> "" Then hasRedeem = Integer.TryParse(redeemInput, newRedeem)

            ' If nothing provided, inform user and exit
            If Not (hasDisc Or hasPrice Or hasRedeem) Then
                MessageBox.Show("Please enter at least one value to update (Discount, Redeemable Points or Price to Gain Point).", "No Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' Validate discount constraint early if provided
            If hasDisc Then
                If newDisc < 0 OrElse newDisc >= 100 Then
                    MessageBox.Show("Discount must be greater than or equal to 0 and less than 100%.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            Using conn As MySqlConnection = Module1.Openconnection()
                ' === Check if record exists ===
                Dim recordExists As Boolean = False
                Using checkCmd As New MySqlCommand("SELECT RedeemablePoints, PriceToGainPoint, Currentloyaltydiscount FROM loyaltydiscount WHERE id=@id", conn)
                    checkCmd.Parameters.AddWithValue("@id", latestId)
                    Using rdr As MySqlDataReader = checkCmd.ExecuteReader()
                        If rdr.Read() Then recordExists = True
                    End Using
                End Using

                If recordExists Then
                    ' Get current values for comparison
                    Dim currentDisc As Double = 0
                    Dim currentRedeem As Integer = 0
                    Dim currentPrice As Double = 0

                    Using getCmd As New MySqlCommand("SELECT RedeemablePoints, PriceToGainPoint, Currentloyaltydiscount FROM loyaltydiscount WHERE id=@id", conn)
                        getCmd.Parameters.AddWithValue("@id", latestId)
                        Using rdr As MySqlDataReader = getCmd.ExecuteReader()
                            If rdr.Read() Then
                                currentRedeem = Convert.ToInt32(rdr("RedeemablePoints"))
                                currentPrice = Convert.ToDouble(rdr("PriceToGainPoint"))
                                currentDisc = Convert.ToDouble(rdr("Currentloyaltydiscount"))
                            End If
                        End Using
                    End Using

                    Dim updatedFields As New List(Of String)
                    Dim updateFields As New List(Of String)

                    ' Compare only fields provided by user
                    If hasRedeem AndAlso newRedeem <> currentRedeem Then
                        updateFields.Add("RedeemablePoints=@redeem")
                        updatedFields.Add($"Redeemable Points changed from {currentRedeem} to {newRedeem}")
                    End If

                    If hasPrice AndAlso Math.Round(newPrice, 2) <> Math.Round(currentPrice, 2) Then
                        updateFields.Add("PriceToGainPoint=@price")
                        updatedFields.Add($"Price To Gain Point changed from {currentPrice:0.00} to {newPrice:0.00}")
                    End If

                    If hasDisc AndAlso Math.Round(newDisc, 2) <> Math.Round(currentDisc, 2) Then
                        updateFields.Add("Currentloyaltydiscount=@disc")
                        updatedFields.Add($"Loyalty Discount changed from {currentDisc:0.00}% to {newDisc:0.00}%")
                    End If

                    If updateFields.Count = 0 Then
                        MessageBox.Show("No changes detected for the fields you provided.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    Dim sql As String = "UPDATE loyaltydiscount SET " & String.Join(", ", updateFields) & " WHERE id=@id"
                    Using cmd As New MySqlCommand(sql, conn)
                        If updateFields.Contains("RedeemablePoints=@redeem") Then cmd.Parameters.AddWithValue("@redeem", newRedeem)
                        If updateFields.Contains("PriceToGainPoint=@price") Then cmd.Parameters.AddWithValue("@price", newPrice)
                        If updateFields.Contains("Currentloyaltydiscount=@disc") Then cmd.Parameters.AddWithValue("@disc", newDisc)
                        cmd.Parameters.AddWithValue("@id", latestId)
                        cmd.ExecuteNonQuery()
                    End Using

                    LogAuditTrail(SessionData.role, SessionData.fullName, "Updated Loyalty Settings:" & vbCrLf & String.Join(vbCrLf, updatedFields))
                Else
                    ' If no record exists and user provided some fields, insert a new record using provided values or defaults
                    ' Determine values to insert: prefer provided, otherwise fallback to safe defaults (0)
                    Dim insertRedeem As Integer = If(hasRedeem, newRedeem, 0)
                    Dim insertPrice As Double = If(hasPrice, newPrice, 0)
                    Dim insertDisc As Double = If(hasDisc, newDisc, 0)

                    If hasDisc AndAlso insertDisc >= 100 Then
                        MessageBox.Show("Discount must be less than 100%. Insert aborted.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Using insertCmd As New MySqlCommand("INSERT INTO loyaltydiscount (id, RedeemablePoints, PriceToGainPoint, Currentloyaltydiscount) VALUES (@id, @redeem, @price, @disc)", conn)
                        insertCmd.Parameters.AddWithValue("@id", latestId)
                        insertCmd.Parameters.AddWithValue("@redeem", insertRedeem)
                        insertCmd.Parameters.AddWithValue("@price", insertPrice)
                        insertCmd.Parameters.AddWithValue("@disc", insertDisc)
                        insertCmd.ExecuteNonQuery()
                    End Using

                    LogAuditTrail(SessionData.role, SessionData.fullName, "Created new Loyalty Settings.")
                End If
            End Using

            MessageBox.Show("Loyalty settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh UI with saved data and clear only the fields the user expects
            LoadData()
            ' Do not force user to re-type everything — clear only the inputs they used
            If hasDisc Then updatedlyltydcsnt.Clear()
            If hasRedeem Then txtredeemablepoints.Clear()
            If hasPrice Then Guna2TextBox2.Clear()
        Catch ex As Exception
            MessageBox.Show("Error updating loyalty data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' === LOAD FORM ===
    Private Sub LoyaltyDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        Guna2ShadowPanel1.Left = (Me.ClientSize.Width - Guna2ShadowPanel1.Width) \ 2
        Guna2ShadowPanel1.Top = (Me.ClientSize.Height - Guna2ShadowPanel1.Height) \ 2
        BackColor = ColorTranslator.FromHtml("#0B2447")
        Guna2Panel2.BackColor = Color.Gainsboro
        ApplyRoundedCorners()

        ' === NEW: wire numeric-only input handlers (non-destructive) ===
        AddNumericInputHandlers()
    End Sub

    Private Sub PictureBoxexit_Click(sender As Object, e As EventArgs) Handles PictureBoxexit.Click
        If MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
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
                    cmd.Parameters.AddWithValue("@Form", "Loyalty Discount")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- Add these helpers inside the LoyaltyDiscount class (class scope) ---

    Private Sub AddNumericInputHandlers()
        ' Decimal inputs: discount and price
        Try
            AddHandler updatedlyltydcsnt.KeyPress, AddressOf DecimalKeyPress
            AddHandler updatedlyltydcsnt.TextChanged, AddressOf UpdatedLoyaltyDiscount_TextChanged
        Catch : End Try
        Try
            AddHandler Guna2TextBox2.KeyPress, AddressOf DecimalKeyPress
        Catch : End Try

        ' Integer input: redeemable points
        Try
            AddHandler txtredeemablepoints.KeyPress, AddressOf IntegerKeyPress
        Catch : End Try
    End Sub

    Private Sub DecimalKeyPress(sender As Object, e As KeyPressEventArgs)
        ' Allow control keys, digits and one decimal point only
        If Not (Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "."c) Then
            e.Handled = True
            Return
        End If

        ' Prevent multiple decimal points
        Dim currentText As String = String.Empty
        If TypeOf sender Is System.Windows.Forms.TextBox Then
            currentText = CType(sender, System.Windows.Forms.TextBox).Text
        ElseIf TypeOf sender Is Guna.UI2.WinForms.Guna2TextBox Then
            currentText = CType(sender, Guna.UI2.WinForms.Guna2TextBox).Text
        End If

        If e.KeyChar = "."c AndAlso currentText.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub IntegerKeyPress(sender As Object, e As KeyPressEventArgs)
        ' Allow control keys and digits only (no decimal point)
        If Not (Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub
End Class