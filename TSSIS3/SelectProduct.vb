Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms
Imports System.Drawing.Drawing2D

Public Class SelectProduct

    '===== VARIABLES =====
    Private ProductPanels As New List(Of Guna2Panel)
    Private Const panelPadding As Integer = 10
    Public Event ProductSelected(barcode As String, productName As String, price As Decimal, quantity As Integer)
    Public PosForm As POS
    Public Property InitialSearch As String = ""
    Private Const CornerRadius As Integer = 10

    '===== CATEGORY HELPER CLASS =====
    Public Class CategoryItem
        Public Property ID As Integer
        Public Property Name As String
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    '===== FORM LOAD =====
    Private Sub SelectProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' === UI setup ===
        ApplyRoundedCorners(pnlContainer, 20)
        ApplyRoundedCorners(pnlProductTemplate, 20)

        ' === Data loading ===
        LoadCategories()
        LoadProducts()
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

    '===== LOAD CATEGORIES =====
    Private Sub LoadCategories()
        cmbCategory.Items.Clear()
        cmbCategory.Items.Add(New CategoryItem With {.ID = 0, .Name = "All Categories"})

        Using conn As MySqlConnection = Openconnection()
            Dim query As String = "SELECT CategoryID, CategoryName FROM category"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        cmbCategory.Items.Add(New CategoryItem With {
                            .ID = Convert.ToInt32(reader("CategoryID")),
                            .Name = reader("CategoryName").ToString()
                        })
                    End While
                End Using
            End Using
        End Using

        cmbCategory.DisplayMember = "Name"
        cmbCategory.ValueMember = "ID"
        cmbCategory.SelectedIndex = 0
    End Sub

    '===== CREATE PRODUCT PANEL =====
    Private Function CreateProductPanel(productName As String, barcode As String, qty As Integer, price As Decimal, imgData As Byte()) As Guna2Panel
        Dim pnl As New Guna2Panel() With {
            .Width = pnlProductTemplate.Width,
            .Height = pnlProductTemplate.Height,
            .BackColor = pnlProductTemplate.BackColor,
            .BorderRadius = 15,
            .Cursor = Cursors.Hand
        }

        '--- Copy Template Controls
        For Each ctrl As Control In pnlProductTemplate.Controls
            Dim newCtrl As Control = Nothing

            If TypeOf ctrl Is Label Then
                Dim lbl As New Label() With {
                    .Font = CType(ctrl, Label).Font,
                    .ForeColor = CType(ctrl, Label).ForeColor,
                    .AutoSize = True,
                    .Left = ctrl.Left,
                    .Top = ctrl.Top
                }

                Select Case ctrl.Name
                    Case "lblProductName"
                        lbl.Text = productName
                        lbl.Font = New Font(lbl.Font.FontFamily, lbl.Font.Size - 1, lbl.Font.Style)
                    Case "lblBarcode"
                        lbl.Text = "Barcode: " & barcode
                        lbl.Font = New Font(lbl.Font.FontFamily, lbl.Font.Size - 1, lbl.Font.Style)
                    Case "lblQty"
                        lbl.Text = "Qty: " & qty
                    Case "lblPrice"
                        lbl.Text = "Unit Price: ₱" & price.ToString("0.00")
                    Case Else
                        lbl.Text = ctrl.Text
                End Select

                newCtrl = lbl

            ElseIf TypeOf ctrl Is PictureBox Then
                Dim pb As New PictureBox() With {
                    .Width = ctrl.Width,
                    .Height = ctrl.Height,
                    .Left = ctrl.Left,
                    .Top = ctrl.Top,
                    .SizeMode = PictureBoxSizeMode.Zoom
                }

                If imgData IsNot Nothing Then
                    Using ms As New IO.MemoryStream(imgData)
                        pb.Image = Image.FromStream(ms)
                    End Using
                End If
                newCtrl = pb
            End If

            If newCtrl IsNot Nothing Then pnl.Controls.Add(newCtrl)
        Next

        '--- Quantity Input
        Dim numQuantity As Guna2NumericUpDown = CreateQuantityInput(qty)
        pnl.Controls.Add(numQuantity)

        '--- Validate Quantity
        AddHandler numQuantity.ValueChanged, Sub(s, e)
                                                 If numQuantity.Value < 1 Then numQuantity.Value = 1
                                                 If numQuantity.Value > qty Then numQuantity.Value = qty
                                             End Sub

        '--- Select Button
        Dim btnSelect As New Guna2Button() With {
    .Width = 99,
    .Height = 23,
    .Left = 94,        ' Fixed X position
    .Top = 81,         ' Fixed Y position
    .Text = "Select",
    .BorderRadius = 10,
    .FillColor = ColorTranslator.FromHtml("#1D3A70"),
    .ForeColor = ColorTranslator.FromHtml("#FFD93D"),
    .Cursor = Cursors.Hand
}


        AddHandler btnSelect.MouseEnter, Sub() btnSelect.FillColor = ColorTranslator.FromHtml("#0F2A4C")
        AddHandler btnSelect.MouseLeave, Sub() btnSelect.FillColor = ColorTranslator.FromHtml("#1D3A70")

        AddHandler btnSelect.Click, Sub(s, e)
                                        RaiseEvent ProductSelected(barcode, productName, price, CInt(numQuantity.Value))
                                        Me.Close()
                                    End Sub

        pnl.Controls.Add(btnSelect)
        Return pnl
    End Function

    '===== CREATE NUMERIC INPUT =====
    Private Function CreateQuantityInput(maxQty As Integer) As Guna2NumericUpDown
        Dim num As New Guna2NumericUpDown() With {
            .Width = 64,
            .Height = 23,
            .Left = 9,
            .Top = 81,
            .Minimum = 1,
            .Maximum = Math.Max(1, maxQty),
            .Value = 1,
            .BorderRadius = 8,
            .UpDownButtonFillColor = ColorTranslator.FromHtml("#1D3A70"),
            .UpDownButtonForeColor = Color.White,
            .ForeColor = Color.Black,
            .Font = New Font("outfit", 9, FontStyle.Regular),
            .BorderColor = Color.Transparent,
            .FillColor = Color.White,
            .BackColor = Color.Gainsboro
        }

        num.ShadowDecoration.Enabled = True
        num.ShadowDecoration.Depth = 3

        Return num
    End Function

    '===== LOAD PRODUCTS =====
    Private Sub LoadProducts(Optional ByVal search As String = "", Optional ByVal categoryId As Integer = 0)
        pnlContainer.Controls.Clear()
        ProductPanels.Clear()

        Dim startX As Integer = 12
        Dim startY As Integer = 13
        Dim spacing As Integer = 10
        Dim currentY As Integer = startY

        Using conn As MySqlConnection = Openconnection()
            Dim query As String = "
                SELECT p.ProductName, p.ProductImage, i.quantity, i.UnitPrice, p.BarcodeID
                FROM product p
                INNER JOIN inventory i ON p.BarcodeID = i.BarcodeID
                WHERE 1=1
            "

            If Not String.IsNullOrEmpty(search) Then
                query &= " AND (p.ProductName LIKE @search OR p.BarcodeID LIKE @search)"
            End If

            If categoryId > 0 Then query &= " AND p.CategoryID = @catId"

            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(search) Then cmd.Parameters.AddWithValue("@search", "%" & search & "%")
                If categoryId > 0 Then cmd.Parameters.AddWithValue("@catId", categoryId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim imgData As Byte() = If(reader("ProductImage") IsNot DBNull.Value, DirectCast(reader("ProductImage"), Byte()), Nothing)
                        Dim pnlClone As Guna2Panel = CreateProductPanel(
                            reader("ProductName").ToString(),
                            reader("BarcodeID").ToString(),
                            CInt(reader("quantity")),
                            CDec(reader("UnitPrice")),
                            imgData
                        )

                        pnlClone.Left = startX
                        pnlClone.Top = currentY
                        pnlClone.Visible = True

                        pnlContainer.Controls.Add(pnlClone)
                        ProductPanels.Add(pnlClone)

                        currentY += pnlClone.Height + spacing
                    End While
                End Using
            End Using
        End Using
    End Sub

    '===== SEARCH & CATEGORY EVENTS =====
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim catId As Integer = 0
        If cmbCategory.SelectedIndex > 0 Then catId = cmbCategory.SelectedItem.ID
        LoadProducts(txtsearch.Text, catId)
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        Dim catId As Integer = 0
        If cmbCategory.SelectedIndex > 0 Then
            Dim selectedItem = cmbCategory.SelectedItem
            Dim prop = selectedItem.GetType().GetProperty("ID")
            If prop IsNot Nothing Then catId = Convert.ToInt32(prop.GetValue(selectedItem, Nothing))
        End If
        LoadProducts(txtsearch.Text.Trim(), catId)
    End Sub

    '===== ROUNDED CORNERS =====
    Private Sub pnlContainer_Paint(sender As Object, e As PaintEventArgs) Handles pnlContainer.Paint
        ApplyRoundedCorners(pnlContainer, 20)
    End Sub

    Private Sub pnlProductTemplate_Paint(sender As Object, e As PaintEventArgs) Handles pnlProductTemplate.Paint
        ApplyRoundedCorners(pnlProductTemplate, 20)
    End Sub

    Private Sub ApplyRoundedCorners(ctrl As Control, radius As Integer)
        Dim rect As New Drawing.Rectangle(0, 0, ctrl.Width, ctrl.Height)
        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseAllFigures()
        ctrl.Region = New Region(path)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub


    '========= FOR ALT F4 =========
    Private Sub seleectproduct_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
End Class
