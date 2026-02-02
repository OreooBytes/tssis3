Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports Guna.UI.WinForms
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D


Public Class Vat

    Private Const CornerRadius As Integer = 10 ' fixed radius

    ' ===============================
    '           FORM LOAD
    ' ===============================
    Private Sub Vat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using conn As New MySqlConnection(connectionstring)
            conn.Open()
        End Using
        ' Set currvat TextBox to read-only
        currvat.ReadOnly = True

        ' Load the current VAT value from the database
        LoadData()


        Guna2Panel1.BorderColor = ColorTranslator.FromHtml("#D3D3D3") ' light gray
        Guna2Panel1.BorderThickness = 2
        Guna2Panel1.BorderRadius = 5

        ApplyRoundedCorners()

        ' ==== TextBoxes (Regular) ====
        update.Font = New Font("Outfit", 9, FontStyle.Regular)
        currvat.Font = New Font("Outfit", 9, FontStyle.Regular)

        ' ==== Labels (Bold) ====
        Label1.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label2.Font = New Font("Outfit", 9, FontStyle.Bold)
        Label3.Font = New Font("Outfit", 9, FontStyle.Bold)

        ' ==== Buttons (Bold) ====
        updatebtn.Font = New Font("Outfit", 9, FontStyle.Bold)

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


    ' ===============================
    '         BUTTON EVENTS
    ' ===============================
    Private Sub updatebtn_Click(sender As Object, e As EventArgs) Handles updatebtn.Click
        Dim newVat As Double

        ' Remove % sign and extra spaces from input
        Dim vatInput As String = update.Text.Replace("%", "").Trim()

        ' Try to parse the new VAT value
        If Double.TryParse(vatInput, newVat) Then
            ' Get current VAT (remove "%" and parse to double)
            Dim currentVat As Double
            Double.TryParse(currvat.Text.Replace("%", "").Trim(), currentVat)

            ' Validate VAT: must be >= 0 and less than 100 (do not allow 100% or more)
            If newVat < 0 OrElse newVat >= 100 Then
                MessageBox.Show("VAT must be a non-negative number and less than 100%.", "Invalid VAT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                update.Focus()
                Return
            End If

            ' Only proceed if there's an actual change
            If Math.Round(newVat, 4) <> Math.Round(currentVat, 4) Then
                ' Update the VAT value in the database
                UpdateVatInDatabase(newVat)

                ' Prepare audit log details
                Dim updatedFields As New List(Of String)
                updatedFields.Add($"VAT changed from {currentVat:0.00}% to {newVat:0.00}%")
                Dim actionDescription As String = "Updated VAT Settings:" & vbCrLf & String.Join(vbCrLf, updatedFields)

                ' Log to audit trail
                LogAuditTrail(SessionData.role, SessionData.fullName, actionDescription)

                ' Kapag successfully updated
                MessageBox.Show("Successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                update.Clear()
                currvat.Text = newVat.ToString("0.00") & "%"
            Else
                MessageBox.Show("No changes made to VAT.")
            End If
        Else
            ' Invalid input
            MessageBox.Show("Please enter a valid VAT percentage.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    ' ===============================
    '         DATABASE METHODS
    ' ===============================
    Private Sub UpdateVatInDatabase(newVat As Double)
        Using conn As MySqlConnection = Module1.Openconnection()
            Dim query As String = "INSERT INTO vat(CurrentVat) VALUES (@CurrentVat)"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@CurrentVat", newVat)
                command.ExecuteNonQuery()
            End Using
            Module1.ConnectionClose(conn)
        End Using
    End Sub

    Private Sub LoadData()
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim sql As String = "SELECT * FROM vat ORDER BY id DESC LIMIT 1" ' Load the most recent VAT value
                    Using cmd As New MySqlCommand(sql, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim currentVat As String = reader("CurrentVat").ToString()
                                currvat.Text = currentVat & "%"
                            End If
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

    ' ===============================
    '         AUDIT TRAIL
    ' ===============================
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
                    cmd.Parameters.AddWithValue("@Form", "Vat")
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==========================
    ' ✅ VAT TEXTBOX VALIDATION (update TextBox)
    ' ==========================

    ' ====== KEY PRESS VALIDATION ======
    Private Sub update_KeyPress(sender As Object, e As KeyPressEventArgs) Handles update.KeyPress
        ' Allow digits, backspace, and one decimal point
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        If e.KeyChar = "."c AndAlso update.Text.Replace("%", "").Contains(".") Then
            e.Handled = True
        End If
    End Sub

    ' ====== TEXT CHANGED: ALWAYS KEEP % SYMBOL ======
    Private Sub update_TextChanged(sender As Object, e As EventArgs) Handles update.TextChanged
        Dim textWithoutPercent As String = update.Text.Replace("%", "")

        ' Remove invalid characters (anything except digits and dot)
        textWithoutPercent = Regex.Replace(textWithoutPercent, "[^0-9.]", "")

        If textWithoutPercent = "" Then
            ' If nothing left, clear the TextBox completely
            update.Text = ""
        Else
            ' Otherwise, re-add % at the end
            Dim cursorPos As Integer = update.SelectionStart
            update.Text = textWithoutPercent & "%"
            update.SelectionStart = Math.Min(cursorPos, update.Text.Length - 1)
        End If
    End Sub

    ' ====== LEAVE EVENT ======
    Private Sub update_Leave(sender As Object, e As EventArgs) Handles update.Leave
        ' If only % is left, clear the TextBox
        If update.Text = "%" Then
            update.Clear()
        End If
    End Sub

    Private Sub PictureBoxexit_Click(sender As Object, e As EventArgs) Handles PictureBoxexit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If Me.Owner IsNot Nothing Then CType(Me.Owner, Dashboard).PanelMain.SendToBack()
            Me.Close()
        End If
    End Sub


    'Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
    '    If MessageBox.Show("Are you sure you want to close this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '        Me.Close()
    '    End If
    'End Sub


End Class
