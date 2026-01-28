Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class LoyaltyDiscount
    Private Const CornerRadius As Integer = 10
    Private latestId As Integer

    Private priceToGainPoint As Decimal = 0 ' 👈 Declared here


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
            Dim newDisc As Double, newRedeem As Integer, newPrice As Double
            Dim hasDisc As Boolean = Double.TryParse(updatedlyltydcsnt.Text, newDisc)
            Dim hasRedeem As Boolean = Integer.TryParse(txtredeemablepoints.Text, newRedeem)
            Dim hasPrice As Boolean = Double.TryParse(Guna2TextBox2.Text, newPrice)

            If Not (hasDisc AndAlso hasRedeem AndAlso hasPrice) Then
                MessageBox.Show("Invalid input values.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Using conn As MySqlConnection = Module1.Openconnection()

                ' === Check if record exists ===
                Dim recordExists As Boolean = False

                Using checkCmd As New MySqlCommand(
                "SELECT RedeemablePoints, PriceToGainPoint, Currentloyaltydiscount 
                 FROM loyaltydiscount WHERE id=@id", conn)

                    checkCmd.Parameters.AddWithValue("@id", latestId)

                    Using rdr As MySqlDataReader = checkCmd.ExecuteReader()
                        If rdr.Read() Then
                            recordExists = True
                        End If
                    End Using
                End Using

                ' === IF EXISTS → RUN YOUR ORIGINAL UPDATE CODE ===
                If recordExists Then

                    ' Get current values for comparison
                    Dim currentDisc As Double = 0
                    Dim currentRedeem As Integer = 0
                    Dim currentPrice As Double = 0

                    Using getCmd As New MySqlCommand(
                    "SELECT RedeemablePoints, PriceToGainPoint, Currentloyaltydiscount 
                     FROM loyaltydiscount WHERE id=@id", conn)

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

                    If newRedeem <> currentRedeem Then
                        updateFields.Add("RedeemablePoints=@redeem")
                        updatedFields.Add($"Redeemable Points changed from {currentRedeem} to {newRedeem}")
                    End If

                    If Math.Round(newPrice, 2) <> Math.Round(currentPrice, 2) Then
                        updateFields.Add("PriceToGainPoint=@price")
                        updatedFields.Add($"Price To Gain Point changed from {currentPrice:0.00} to {newPrice:0.00}")
                    End If

                    If Math.Round(newDisc, 2) <> Math.Round(currentDisc, 2) Then
                        updateFields.Add("Currentloyaltydiscount=@disc")
                        updatedFields.Add($"Loyalty Discount changed from {currentDisc:0.00}% to {newDisc:0.00}%")
                    End If

                    If updateFields.Count = 0 Then
                        MessageBox.Show("No changes detected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    Dim sql As String =
                    "UPDATE loyaltydiscount SET " & String.Join(", ", updateFields) & " WHERE id=@id"

                    Using cmd As New MySqlCommand(sql, conn)
                        If updateFields.Contains("RedeemablePoints=@redeem") Then cmd.Parameters.AddWithValue("@redeem", newRedeem)
                        If updateFields.Contains("PriceToGainPoint=@price") Then cmd.Parameters.AddWithValue("@price", newPrice)
                        If updateFields.Contains("Currentloyaltydiscount=@disc") Then cmd.Parameters.AddWithValue("@disc", newDisc)
                        cmd.Parameters.AddWithValue("@id", latestId)
                        cmd.ExecuteNonQuery()
                    End Using

                    LogAuditTrail(
                    SessionData.role,
                    SessionData.fullName,
                    "Updated Loyalty Settings:" & vbCrLf & String.Join(vbCrLf, updatedFields)
                )

                Else
                    ' === IF NOT EXISTS → INSERT ===
                    Using insertCmd As New MySqlCommand(
                    "INSERT INTO loyaltydiscount 
                     (id, RedeemablePoints, PriceToGainPoint, Currentloyaltydiscount)
                     VALUES (@id, @redeem, @price, @disc)", conn)

                        insertCmd.Parameters.AddWithValue("@id", latestId)
                        insertCmd.Parameters.AddWithValue("@redeem", newRedeem)
                        insertCmd.Parameters.AddWithValue("@price", newPrice)
                        insertCmd.Parameters.AddWithValue("@disc", newDisc)
                        insertCmd.ExecuteNonQuery()
                    End Using

                    LogAuditTrail(
                    SessionData.role,
                    SessionData.fullName,
                    "Created new Loyalty Settings."
                )
                End If
            End Using

            MessageBox.Show("Loyalty settings saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadData()
            updatedlyltydcsnt.Clear()
            txtredeemablepoints.Clear()
            Guna2TextBox2.Clear()

        Catch ex As Exception
            MessageBox.Show("Error updating loyalty data: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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



End Class