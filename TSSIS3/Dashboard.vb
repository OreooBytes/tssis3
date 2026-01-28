Imports Guna.UI2.WinForms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Dashboard

    ' === Constants ===
    Private Const CornerRadius As Integer = 10 ' Fixed radius for UI elements

    ' === Shared Instances ===


    Public LoggedInFullName As String

    Public CurrentFullName As String   ' full name of logged-in user

    Public Shared DashboardInstance As Dashboard = Nothing ' Singleton instance of Dashboard

    Private WithEvents timerDashboard As New Timer() ' ✅ Code-based realtime timer

    ' === User Information ===
    Public CurrentUsername As String          ' Store logged-in user's username
    Public Property FullName As String        ' Full name of the logged-in user
    Public Property ContactNo As String       ' Contact number of the user
    Public UserType As String                 ' Type/role of the user

    ' === Logged-in cashier ===
    Public Property CashierName As String

    Private Shared _instance As Dashboard = Nothing

    Public Shared Function GetInstance() As Dashboard
        If _instance Is Nothing OrElse _instance.IsDisposed Then
            _instance = New Dashboard()
        End If
        Return _instance
    End Function

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '============ UI ==============


        LoggedInFullName = SessionData.fullName

        userpbcircle.FillColor = ColorTranslator.FromHtml("#0B2447")

        '=== Curve Form ===

        ApplyRoundedCorners2()

        '=== Labels Fonts  ===

        lblFileMaintenance.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblUtilities.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblName.Font = New Font("Outfit", 12, FontStyle.Bold)
        lblRole.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblDate.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblTime.Font = New Font("Outfit", 9, FontStyle.Bold)



        '=== Revenue ===
        lblRevenue.Font = New Font("Outfit", 10, FontStyle.Bold)
        lbltotalRevenue.Font = New Font("Outfit", 15, FontStyle.Bold)
        lblPercent1Revenue.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblRevenueFLD.Font = New Font("Outfit", 8, FontStyle.Bold)

        '=== Customers ===
        lblCustomers.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblTotalCustomers.Font = New Font("Outfit", 15, FontStyle.Bold)
        lblPercentCustomers.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblCustomersFLD.Font = New Font("Outfit", 8, FontStyle.Bold)

        '=== Products ===
        lblProductSold.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblTotalProductSold.Font = New Font("Outfit", 15, FontStyle.Bold)
        lblPercentSold.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblProductSoldFLD.Font = New Font("Outfit", 8, FontStyle.Bold)

        '=== Return ===
        lblReturn.Font = New Font("Outfit", 10, FontStyle.Bold)
        lblTotalReturn.Font = New Font("Outfit", 15, FontStyle.Bold)
        lblPercentReturn.Font = New Font("Outfit", 9, FontStyle.Bold)
        lblRefundsFLD.Font = New Font("Outfit", 8, FontStyle.Bold)




        lblTotalSales.ForeColor = Color.White

        lblThismonths.ForeColor = Color.White
        lblTotalSalesThismonth.ForeColor = Color.White

        lblToday.ForeColor = Color.White
        lblTotalSales2.ForeColor = Color.White

        lblPercentSales.ForeColor = Color.White

        lblincreased.ForeColor = Color.White

        lblSalesSummary.ForeColor = Color.White
        lblTotalSalesToday.ForeColor = Color.White




        '=== Buttons ==

        '=== Fore Color ===
        btnDashboard.ForeColor = ColorTranslator.FromHtml("#0B2447")
        btnUsers.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnSupplier.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnCategory.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnProducts.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnInventory.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnPOS.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnDiscounts.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnVat.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnReports.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnUtilities.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        btnLogout.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Guna2ContextMenuStrip1.ForeColor = ColorTranslator.FromHtml("#0B2447")

        '=== Fill Color ===
        btnDashboard.FillColor = ColorTranslator.FromHtml("#FFD93D")
        btnUsers.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnSupplier.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnCategory.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnProducts.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnInventory.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnPOS.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnDiscounts.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnVat.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnReports.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnUtilities.FillColor = ColorTranslator.FromHtml("#0B2447")
        btnLogout.FillColor = ColorTranslator.FromHtml("#0B2447")


        '=== Fonts ===
        btnDashboard.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnUsers.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnSupplier.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnCategory.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnProducts.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnInventory.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnPOS.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnDiscounts.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnVat.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnReports.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnUtilities.Font = New Font("Outfit", 8, FontStyle.Bold)
        btnLogout.Font = New Font("Outfit", 8, FontStyle.Bold)
        Guna2ContextMenuStrip1.Font = New Font("Outfit", 8, FontStyle.Bold)


        '=== Panels === 

        '=== Panel BackColor
        'Guna2ShadowPanel1.FillColor = ColorTranslator.FromHtml("#FFFFFF")
        Guna2ShadowPanel3.FillColor = ColorTranslator.FromHtml("#0B2447")
        Guna2ShadowPanel4.FillColor = ColorTranslator.FromHtml("#0B2447")
        Guna2ShadowPanel5.FillColor = ColorTranslator.FromHtml("#0B2447")
        Guna2ShadowPanel6.FillColor = ColorTranslator.FromHtml("#0B2447")
        Guna2ShadowPanel7.FillColor = ColorTranslator.FromHtml("#0B2447")

        '=== First Name / Lastname ===

        LoadUserInitials()

        lblName.Text = SessionData.fullName
        lblRole.Text = SessionData.role

        '=== 2️⃣ Load charts / dashboard data ===

        LoadYearlySalesChart()
        LoadChart2()
        'LoadChart3()

        '=== Panel / BorderRadius ===
        PanelMain.BorderRadius = 5
        Guna2Panel1.BorderRadius = 5

        '=== Panel / Position ===
        PictureBox11.SendToBack()


        ' === Setup Timer ===
        timerDashboard.Interval = 1000 ' Refresh every 5 seconds
        timerDashboard.Start()

        LoadRevenueData()
        LoadTotalCustomers()
        LoadTotalProductsSold()
        LoadTotalReturns()
        LoadSalesSummary()

        ' Set Guna2ContextMenuStrip hover color
        Guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = ColorTranslator.FromHtml("#0B2447")
        Guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = Color.White
        Guna2ContextMenuStrip1.RenderStyle.ArrowColor = Color.White
        Guna2ContextMenuStrip1.RenderStyle.BorderColor = ColorTranslator.FromHtml("#0B2447")

        ' Set Guna2ContextMenuStrip hover color
        Guna2ContextMenuStrip2.RenderStyle.SelectionBackColor = ColorTranslator.FromHtml("#0B2447")
        Guna2ContextMenuStrip2.RenderStyle.SelectionForeColor = Color.White
        Guna2ContextMenuStrip2.RenderStyle.ArrowColor = Color.White
        Guna2ContextMenuStrip2.RenderStyle.BorderColor = ColorTranslator.FromHtml("#0B2447")

        Me.Size = New Size(1362, 788)
        Me.MaximumSize = New Size(1362, 788)
        Me.MinimumSize = New Size(1362, 788)
        Me.StartPosition = FormStartPosition.CenterScreen


        ApplyUserPermissions()
        ApplySuperAdminPermissions()

        EnableAllButtons()
    End Sub

    Private Sub LoadUserInitials()
        ' --- Check if userpbcircle exists ---
        If userpbcircle Is Nothing Then Return

        ' --- Get initials from full name safely ---
        Dim fullName As String = If(SessionData.fullName, "").Trim()
        If fullName = "" Then fullName = "?"

        Dim names() As String = fullName.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
        Dim initials As String = ""

        If names.Length >= 2 Then
            ' First letter of first and last name
            initials = names(0).Substring(0, 1).ToUpper() & names(names.Length - 1).Substring(0, 1).ToUpper()
        ElseIf names.Length = 1 Then
            ' Only first letter of single name
            initials = names(0).Substring(0, 1).ToUpper()
        Else
            initials = ""
        End If

        ' --- Remove existing labels inside the picture box safely ---
        For i As Integer = userpbcircle.Controls.Count - 1 To 0 Step -1
            Dim ctrl As Control = userpbcircle.Controls(i)
            If TypeOf ctrl Is Label Then
                userpbcircle.Controls.Remove(ctrl)
                ctrl.Dispose()
            End If
        Next

        ' --- Create label dynamically inside the circle picture box ---
        Dim lblInitials As New Label() With {
        .Text = initials,
        .ForeColor = Color.White,
        .BackColor = Color.Transparent,
        .TextAlign = ContentAlignment.MiddleCenter,
        .AutoSize = False,
        .Font = New Font("Segoe UI", 16, FontStyle.Bold),
        .Size = userpbcircle.Size,
        .Location = New Point(0, 0)
    }

        ' Add the label to the circle picture box
        userpbcircle.Controls.Add(lblInitials)
        lblInitials.BringToFront()
    End Sub

    Private Sub TimerDateTime_Tick(sender As Object, e As EventArgs) Handles TimerDateTime.Tick
        lblDate.Text = Date.Now.ToString("dddd, MMMM dd, yyyy")
        lblTime.Text = Date.Now.ToString("hh:mm:ss tt")
    End Sub


    '=================== DATE / TIME ========================
    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    'lblDate.Text = DateTime.Now.ToString("ddd, MMMM dd, yyyy")
    '    'lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
    'End Sub

    Private Sub ApplyRoundedCorners2()
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

    ' ==========================
    ' USER PERMISSIONS
    ' ==========================
    Private Sub ApplyUserPermissions()

        ' ✅ If user is ADMIN allow access
        If SessionData.role = "Admin" Then
            EnableAllButtons()
            btnUsers.Enabled = False
            btnUtilities.Enabled = False
            btnPOS.Enabled = False
            Return
        End If


    End Sub

    Private Sub ApplySuperAdminPermissions()
        Dim superAdminExists As Boolean = False

        ' 🔹 Check database kung may SuperAdmin
        Using conn As MySqlConnection = Module1.Openconnection()
            If conn IsNot Nothing Then
                Try
                    Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE UserType='SuperAdmin'", conn)
                    superAdminExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                Catch ex As MySqlException
                    MessageBox.Show("Database Error: " & ex.Message)
                Finally
                    Module1.ConnectionClose(conn)
                End Try
            End If
        End Using

        ' 🔹 Enable or disable buttons depende sa SuperAdmin existence
        ' Palitan ang mga button names sa actual buttons mo
        'btnDashboard.Enabled = superAdminExists
        btnDashboard.Enabled = True
        btnUsers.Enabled = True
        btnSupplier.Enabled = superAdminExists
        btnCategory.Enabled = superAdminExists
        btnProducts.Enabled = superAdminExists
        btnInventory.Enabled = superAdminExists
        btnPOS.Enabled = superAdminExists
        btnVat.Enabled = superAdminExists
        btnDiscounts.Enabled = superAdminExists
        btnUtilities.Enabled = superAdminExists
        btnReports.Enabled = superAdminExists
        btnLogout.Enabled = True
    End Sub



    ' Optional helper function to quickly enable everything
    Private Sub EnableAllButtons()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).Enabled = True
            End If
        Next
    End Sub


    ' === Global Variable ===
    Private activeButton As Guna.UI2.WinForms.Guna2Button = Nothing

    Private Sub SetActiveButton(selectedBtn As Guna.UI2.WinForms.Guna2Button)
        ' Step 1: Kung may dating active button, i-reset ito
        If activeButton IsNot Nothing Then
            ResetButtonAppearance(activeButton)
        End If

        ' Step 2: Highlight bagong pinili
        selectedBtn.FillColor = ColorTranslator.FromHtml("#FFD93D") ' Active yellow
        selectedBtn.ForeColor = Color.Black

        btnDashboard.FillColor = ColorTranslator.FromHtml("#0B2447") ' default background (dark blue)
        btnDashboard.ForeColor = ColorTranslator.FromHtml("#FFFFFF")  ' default text color (white)
        btnDashboard.Image = My.Resources.iconmain1                   ' default white icon



        ' Step 3: Lagyan ng colored icon (active)
        Select Case selectedBtn.Name
            Case "btnUsers" : selectedBtn.Image = My.Resources.icons8_main2
            Case "btnSupplier" : selectedBtn.Image = My.Resources.icons8_main3
            Case "btnCategory" : selectedBtn.Image = My.Resources.icons8_main4
            Case "btnProducts" : selectedBtn.Image = My.Resources.icons8_main5
            Case "btnInventory" : selectedBtn.Image = My.Resources.icons8_main6
            Case "btnPOS" : selectedBtn.Image = My.Resources.icons8_main7
            Case "btnDiscounts" : selectedBtn.Image = My.Resources.icons8_main8
            Case "btnVat" : selectedBtn.Image = My.Resources.icons8_main9
            Case "btnReports" : selectedBtn.Image = My.Resources.icons8_main10
            Case "btnUtilities" : selectedBtn.Image = My.Resources.icons8_main13

        End Select

        ' Step 4: I-save kung alin ang active
        activeButton = selectedBtn

        ' Step 4: Save as active button
        activeButton = selectedBtn


    End Sub


    Private Sub ResetButtonAppearance(btn As Guna.UI2.WinForms.Guna2Button)
        ' Step 1: Balik sa default background at text color
        btn.FillColor = ColorTranslator.FromHtml("#0B2447")
        btn.ForeColor = Color.White

        ' Step 2: Ibalik ang white (default) icon
        Select Case btn.Name
            Case "btnDashboard" : btn.Image = My.Resources.iconmain1
            Case "btnUsers" : btn.Image = My.Resources.iconmain2
            Case "btnSupplier" : btn.Image = My.Resources.iconmain3
            Case "btnCategory" : btn.Image = My.Resources.iconmain4
            Case "btnProducts" : btn.Image = My.Resources.iconmain5
            Case "btnInventory" : btn.Image = My.Resources.iconmain6
            Case "btnPOS" : btn.Image = My.Resources.iconmain7
            Case "btnDiscounts" : btn.Image = My.Resources.iconmain8
            Case "btnVat" : btn.Image = My.Resources.iconmain9
            Case "btnReports" : btn.Image = My.Resources.iconmain10
            Case "btnUtilities" : btn.Image = My.Resources.iconmain13

        End Select
    End Sub



    ' === BUTTON EVENTS ===
    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        SetActiveButton(btnDashboard)
        btnDashboard.FillColor = ColorTranslator.FromHtml("#FFD93D") ' default background (dark blue)
        btnDashboard.ForeColor = ColorTranslator.FromHtml("#0B2447")  ' default text color (white)
        btnDashboard.Image = My.Resources.icons8_main1


        For Each ctrl As Control In PanelMain.Controls
            If TypeOf ctrl Is Form Then
                Dim frm As Form = DirectCast(ctrl, Form)
                frm.Hide() ' or frm.Visible = False
            End If
        Next

        '--- I-set ang image ---
        pbAll.Image = My.Resources.DB

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

        overlaypanel.BringToFront()

        Guna2Panel1.BringToFront()


    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click

        SetActiveButton(btnUsers)

        OpenChildForm(Of User)()

        '=== Panel Size

        '=== Panel Size
        PanelMain.BringToFront()

        overlaypanel.SendToBack()

        ' --- I-set ang image ---
        pbAll.Image = My.Resources.UR

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

        PanelMain.SuspendLayout()


        ' === Lahat ng panel update, child forms, image, location, size ===
        PanelMain.ResumeLayout()

    End Sub

    Private Sub btnSupplier_Click(sender As Object, e As EventArgs) Handles btnSupplier.Click
        SetActiveButton(btnSupplier)

        OpenChildForm(Of Supplier)()

        '=== Panel Size

        PanelMain.BringToFront()

        '--- I-set ang image ---
        pbAll.Image = My.Resources.SP

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)
    End Sub

    Private Sub btnCategory_Click(sender As Object, e As EventArgs) Handles btnCategory.Click
        SetActiveButton(btnCategory)

        OpenChildForm(Of Category)()

        '=== Panel Size

        PanelMain.BringToFront()


        '--- I-set ang image ---
        pbAll.Image = My.Resources.CG

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        SetActiveButton(btnProducts)

        OpenChildForm(Of Product)()

        '=== Panel Size

        PanelMain.BringToFront()


        '--- I-set ang image ---
        pbAll.Image = My.Resources.PD

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        SetActiveButton(btnInventory)

        OpenChildForm(Of inventory)()

        '=== Panel Size

        PanelMain.BringToFront()


        '--- I-set ang image ---
        pbAll.Image = My.Resources.IT

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        SetActiveButton(btnPOS)

        OpenChildForm(Of POS)(Sub(f) f.CashierName = fullName)

        '=== Panel Size

        PanelMain.BringToFront()


        '--- I-set ang image ---
        pbAll.Image = My.Resources.PS

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)


    End Sub

    Private Sub btnDiscounts_Click(sender As Object, e As EventArgs) Handles btnDiscounts.Click
        SetActiveButton(btnDiscounts)

        OpenChildForm(Of Discount)()

        '=== Panel Size

        PanelMain.BringToFront()


        '--- I-set ang image ---
        pbAll.Image = My.Resources.DC

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

    End Sub

    Private Sub btnVat_Click(sender As Object, e As EventArgs) Handles btnVat.Click
        SetActiveButton(btnVat)

        OpenChildForm(Of Vat)()

        '=== Panel Size

        PanelMain.BringToFront()


        '--- I-set ang image ---
        pbAll.Image = My.Resources.VT

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

    End Sub
    Private Sub btnUtilities_Click(sender As Object, e As EventArgs) Handles btnUtilities.Click
        SetActiveButton(btnUtilities)

        Guna2ContextMenuStrip2.Show(btnUtilities, 0, btnUtilities.Height)
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        SetActiveButton(btnReports)
        Guna2ContextMenuStrip1.Show(btnReports, 0, btnReports.Height)
    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesReportToolStripMenuItem.Click
        OpenChildForm(Of SaleReport)()

        PanelMain.BringToFront()

        '--- I-set ang image ---
        pbAll.Image = My.Resources.SR

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

    End Sub
    Private Sub ExpirationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpirationToolStripMenuItem.Click
        OpenChildForm(Of ExpirationReports)()

        PanelMain.BringToFront()


        '--- I-set ang image ---
        pbAll.Image = My.Resources.ET

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        OpenChildForm(Of StockReports)()

        PanelMain.BringToFront()


        '--- I-set ang image ---
        pbAll.Image = My.Resources.STR

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)
    End Sub

    Private Sub LogHistoryToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LogHistoryToolStripMenuItem.Click

        OpenChildForm(Of LogHistory)()

        PanelMain.BringToFront()


        '--- I-set ang image ---
        pbAll.Image = My.Resources.LH

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

    End Sub
    Private Sub AuditTrailToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AuditTrailToolStripMenuItem.Click
        OpenChildForm(Of Audit)()

        PanelMain.BringToFront()

        '--- I-set ang image ---
        pbAll.Image = My.Resources.AT

        ' --- I-set ang location ---
        pbAll.Location = New Point(-19, -27)

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click

        Dim change As New ChangePassword
        ChangePassword.ShowDialog()

    End Sub


    ' === Logout button click (manual logout) ===
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        LogoutProcedure(False) ' False = normal logout
    End Sub

    ' === Shared logout procedure ===
    Public Sub LogoutProcedure(forced As Boolean)
        ' ✅ Ask confirmation only for manual logout
        If Not forced Then
            If MsgBox("Are you sure you want to log out?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Logout Confirmation") = MsgBoxResult.No Then
                Exit Sub
            End If
        Else
            ' 🔹 Forced logout message for SuperAdmin creation
            MessageBox.Show("System logged out automatically for security after creating a SuperAdmin.",
                        "Security Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' ✅ Open Login form
        Dim login As New Login()
        login.Show()

        ' ✅ Hide current User form
        Me.Hide()

        ' ✅ Log action (forced or manual)
        Dim actorRole As String = If(String.IsNullOrWhiteSpace(SessionData.role), "Default", SessionData.role)
        Dim actorName As String = If(String.IsNullOrWhiteSpace(SessionData.fullName), "Default", SessionData.fullName)
        Dim actionDesc As String = If(forced, "Forced logout after SuperAdmin creation", "Logged out")
        LogHistory.LogAction(actorRole, actorName, actionDesc)
    End Sub

    ' === Trigger forced logout from User form ===
    Public Sub TriggerLogout()
        LogoutProcedure(True) ' True = forced logout
    End Sub





    ' ==========================
    ' FORM CLOSING
    ' ==========================
    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' Exit application
        Application.Exit()
    End Sub

    ' ==========================
    ' PANEL & MODAL FORM HELPERS
    ' ==========================
    Private Sub ShowModalForm(modalForm As Form)
        overlaypanel.Visible = True
        modalForm.ShowDialog(Me)
        overlaypanel.Visible = False
        Dashboard_Load(Nothing, Nothing)
    End Sub

    Private Sub CloseAllFormsInPanel()
        For i As Integer = PanelMain.Controls.Count - 1 To 0 Step -1
            If TypeOf PanelMain.Controls(i) Is Form Then
                DirectCast(PanelMain.Controls(i), Form).Close()
            End If
        Next
    End Sub

    Private Sub LoadFormInPanel(childForm As Form)
        CloseAllFormsInPanel()
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        PanelMain.Controls.Add(childForm)
        childForm.BringToFront()
        childForm.Show()
    End Sub

    Private Sub OpenChildForm(Of T As {Form, New})(Optional setup As Action(Of T) = Nothing)
        Dim frm As New T()
        frm.Owner = Me
        setup?.Invoke(frm)
        LoadFormInPanel(frm)
    End Sub


    '==========================
    ' UI HELPER FUNCTIONS
    '==========================

    ' --- Helper function for chart setup ---
    Private Sub SetupChart(chart As DataVisualization.Charting.Chart, titleText As String)
        chart.Series.Clear()
        chart.Titles.Clear()
        chart.Legends.Clear()
        chart.ChartAreas.Clear()

        ' Chart Area
        Dim chartArea As New DataVisualization.Charting.ChartArea("MainArea")
        chartArea.BackColor = Color.LightGray
        chart.ChartAreas.Add(chartArea)

        ' Legend
        Dim legend As New DataVisualization.Charting.Legend()
        legend.Docking = DataVisualization.Charting.Docking.Right
        legend.BackColor = Color.LightGray
        chart.Legends.Add(legend)

        ' Title
        Dim chartTitle As New DataVisualization.Charting.Title()
        chartTitle.Text = titleText
        chartTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        chartTitle.ForeColor = Color.Black
        chart.Titles.Add(chartTitle)

        ' Chart Background
        chart.BackColor = Color.LightGray
    End Sub

    '==========================
    ' UI HELPER FUNCTIONS
    '==========================

    '=========================================
    Private currentYear As Integer = Date.Now.Year

    '==========================
    ' Yearly Sales Chart
    '==========================
    Private Sub LoadYearlySalesChart()
        ' Check year change
        If Date.Now.Year <> currentYear Then
            currentYear = Date.Now.Year
        End If

        ' === Reset chart ===
        SetupChart(Chart1, "Yearly Sales Performance (" & currentYear.ToString() & ")")

        ' === Overall Chart Background ===
        Chart1.BackColor = Color.White

        ' === Chart Area Setup ===
        Dim chartArea As DataVisualization.Charting.ChartArea = Chart1.ChartAreas(0)
        With chartArea
            .BackColor = Color.White

            ' === X Axis ===
            .AxisX.Title = "Month"
            .AxisX.TitleFont = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
            .AxisX.LabelStyle.Font = New Font("Segoe UI Semibold", 9, FontStyle.Bold)
            .AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#0B2447")
            .AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#AFBABA")
            .AxisX.LineColor = ColorTranslator.FromHtml("#828C8D")

            ' === Y Axis ===
            .AxisY.Title = "Total Sales (₱)"
            .AxisY.TitleFont = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
            .AxisY.LabelStyle.Font = New Font("Segoe UI Semibold", 9, FontStyle.Bold)
            .AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#0B2447")
            .AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#E0E0E0")
            .AxisY.LineColor = ColorTranslator.FromHtml("#828C8D")

            ' ₱ Sign for Y Axis labels
            .AxisY.LabelStyle.Format = "₱#,##0.00"

            ' === Border ===
            .BorderWidth = 0
        End With

        ' === Series Setup ===
        Dim salesSeries As New DataVisualization.Charting.Series("Monthly Sales")
        With salesSeries
            .ChartType = DataVisualization.Charting.SeriesChartType.Line
            .BorderWidth = 3
            .Color = ColorTranslator.FromHtml("#0B2447") ' line color
            .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
            .MarkerSize = 9
            .MarkerColor = ColorTranslator.FromHtml("#FFD93D") ' yellow markers
            .IsValueShownAsLabel = True
            .LabelForeColor = ColorTranslator.FromHtml("#0B2447")
            .Font = New Font("Segoe UI Semibold", 9, FontStyle.Bold)
            .ShadowOffset = 2
        End With

        ' === Data Prep ===
        Dim months() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun",
                              "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
        Dim salesDict As New Dictionary(Of String, Decimal)
        For Each m As String In months
            salesDict.Add(m, 0D)
        Next

        Try
            Using conn As MySqlConnection = Openconnection()
                Dim query As String = "
                SELECT DATE_FORMAT(SaleDate, '%Y-%m') AS Month,
                       SUM(TotalAmount) AS TotalSales
                FROM sales
                WHERE YEAR(SaleDate) = @Year
                GROUP BY DATE_FORMAT(SaleDate, '%Y-%m')
                ORDER BY Month;"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Year", currentYear)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim monthStr As String = reader("Month").ToString()
                            Dim total As Decimal = If(IsDBNull(reader("TotalSales")), 0, Convert.ToDecimal(reader("TotalSales")))
                            Dim dt As DateTime
                            If DateTime.TryParseExact(monthStr & "-01", "yyyy-MM-dd", Nothing, Globalization.DateTimeStyles.None, dt) Then
                                salesDict(dt.ToString("MMM")) = total
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading yearly sales chart: " & ex.Message)
        End Try

        ' === Add data points ===
        For Each m As String In months
            salesSeries.Points.AddXY(m, salesDict(m))
        Next

        Chart1.Series.Add(salesSeries)

        ' === Title Styling ===
        Chart1.Titles(0).Font = New Font("outfit", 11, FontStyle.Bold)
        Chart1.Titles(0).ForeColor = ColorTranslator.FromHtml("#0B2447")
    End Sub

    ' === Global Variables ===
    Private refreshTimer As New Timer()
    Private categoryColors As New Dictionary(Of String, Color)
    Private colorPalette As List(Of Color) = New List(Of Color) From {
    ColorTranslator.FromHtml("#0B2447"),
    ColorTranslator.FromHtml("#FFD93D"),
    ColorTranslator.FromHtml("#257180"),
    ColorTranslator.FromHtml("#A6AEBF"),
    ColorTranslator.FromHtml("#AFBABA"),
    ColorTranslator.FromHtml("#12B886"),
    ColorTranslator.FromHtml("#FF6B6B"),
    ColorTranslator.FromHtml("#1D3A70"),
    ColorTranslator.FromHtml("#74C0FC"),
    ColorTranslator.FromHtml("#82C91E"),
    ColorTranslator.FromHtml("#FF922B"),
    ColorTranslator.FromHtml("#E64980"),
    ColorTranslator.FromHtml("#4C6EF5"),
    ColorTranslator.FromHtml("#0CA678"),
    ColorTranslator.FromHtml("#9775FA"),
    ColorTranslator.FromHtml("#364FC7"),
    ColorTranslator.FromHtml("#F59F00"),
    ColorTranslator.FromHtml("#1864AB"),
    ColorTranslator.FromHtml("#E03131"),
    ColorTranslator.FromHtml("#2B8A3E"),
    ColorTranslator.FromHtml("#CC5DE8"),
    ColorTranslator.FromHtml("#228BE6"),
    ColorTranslator.FromHtml("#40C057"),
    ColorTranslator.FromHtml("#F76707"),
    ColorTranslator.FromHtml("#15AABF")
}

    Private Sub LoadChart2()
        Try
            ' === Setup Chart ===
            SetupChart(Chart2, "Stock Distribution by Category")
            Chart2.BackColor = Color.White
            Chart2.Series.Clear()
            Chart2.Titles.Clear()
            Chart2.Legends.Clear()
            Chart2.ChartAreas.Clear()

            Dim chartArea As New DataVisualization.Charting.ChartArea()
            With chartArea
                .BackColor = Color.White
                .BorderWidth = 0
            End With
            Chart2.ChartAreas.Add(chartArea)

            ' === Series Setup ===
            Dim series As New DataVisualization.Charting.Series("Stock by Category") With {
            .ChartType = DataVisualization.Charting.SeriesChartType.Doughnut,
            .IsValueShownAsLabel = True,
            .Font = New Font("Segoe UI Semibold", 9, FontStyle.Bold),
            .LabelForeColor = ColorTranslator.FromHtml("#0B2447")
        }

            ' === Database Fetch ===
            Using conn As MySqlConnection = Openconnection()
                Dim query As String = "
                SELECT c.CategoryName, COALESCE(SUM(i.quantity), 0) AS TotalStock
                FROM category c
                LEFT JOIN product p ON c.CategoryID = p.CategoryID
                LEFT JOIN inventory i ON p.BarcodeID = i.BarcodeID
                GROUP BY c.CategoryName;"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim hasData As Boolean = False
                        While reader.Read()
                            Dim catName As String = reader("CategoryName").ToString()
                            Dim stock As Decimal = Convert.ToDecimal(reader("TotalStock"))

                            ' === Assign a color only once ===
                            If Not categoryColors.ContainsKey(catName) Then
                                Dim colorIndex As Integer = categoryColors.Count Mod colorPalette.Count
                                categoryColors(catName) = colorPalette(colorIndex)
                            End If

                            hasData = True
                            Dim pointIndex As Integer = series.Points.AddXY(catName, stock)
                            series.Points(pointIndex).Color = categoryColors(catName)
                        End While
                        If Not hasData Then
                            series.Points.AddXY("No Data", 1)
                            series.Points(0).Color = Color.LightGray
                        End If
                    End Using
                End Using
            End Using

            ' === Add Series ===
            Chart2.Series.Add(series)

            ' === Title ===
            Dim chartTitle As New DataVisualization.Charting.Title("Stock Distribution by Category",
                                                          DataVisualization.Charting.Docking.Top,
                                                          New Font("Segoe UI Semibold", 11, FontStyle.Bold),
                                                          ColorTranslator.FromHtml("#0B2447"))
            Chart2.Titles.Add(chartTitle)

            ' === Legend ===
            Dim legend As New DataVisualization.Charting.Legend() With {
            .BackColor = Color.White,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .ForeColor = ColorTranslator.FromHtml("#0B2447")
        }
            Chart2.Legends.Add(legend)

            ' === Real-Time Refresh (1 second) ===
            If Not refreshTimer.Enabled Then
                AddHandler refreshTimer.Tick, Sub()
                                                  LoadChart2()
                                              End Sub
                refreshTimer.Interval = 1000 ' 1 sec
                refreshTimer.Start()
            End If

        Catch ex As Exception
            Console.WriteLine("Error loading chart: " & ex.Message)
        End Try
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint
        ApplyRoundedCorners(Guna2Panel1, 10)
    End Sub

    Private Sub overlaypanel_Paint(sender As Object, e As PaintEventArgs) Handles overlaypanel.Paint
        ApplyRoundedCorners(Guna2Panel1, 10)
    End Sub

    'Private Sub LoadChart3()
    '    SetupChart(chart3, "Top 5 Products by Stock")

    '    Dim conn As MySqlConnection = Openconnection()
    '    Dim query As String = "SELECT ProductName, quantity AS TotalStock
    '                       FROM inventory
    '                       ORDER BY quantity DESC
    '                       LIMIT 5"
    '    Dim cmd As New MySqlCommand(query, conn)
    '    Dim reader As MySqlDataReader = cmd.ExecuteReader()

    '    Dim series As New DataVisualization.Charting.Series()
    '    series.ChartType = DataVisualization.Charting.SeriesChartType.Doughnut
    '    series.IsValueShownAsLabel = True

    '    Dim hasData As Boolean = False
    '    While reader.Read()
    '        hasData = True
    '        series.Points.AddXY(reader("ProductName").ToString(), Convert.ToDecimal(reader("TotalStock")))
    '    End While

    '    If Not hasData Then
    '        series.Points.AddXY("No Data", 1)
    '    End If

    '    chart3.Series.Add(series)
    '    reader.Close()
    '    conn.Close()
    'End Sub


    ' === REALTIME AUTO REFRESH ===
    Private Sub timerDashboard_Tick(sender As Object, e As EventArgs) Handles timerDashboard.Tick
        LoadRevenueData()
        LoadTotalCustomers()
        LoadTotalProductsSold()
        LoadTotalReturns()
        LoadSalesSummary()
    End Sub


    ' === Total Revenue ===
    Private Sub LoadRevenueData()
        Dim todayTotal As Decimal = 0D
        Dim yesterdayTotal As Decimal = 0D
        Dim percentChange As Decimal = 0D

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                Dim cmdToday As New MySqlCommand("SELECT IFNULL(SUM(TotalAmount), 0) FROM sales WHERE DATE(SaleDate) = CURDATE()", conn)
                todayTotal = Convert.ToDecimal(cmdToday.ExecuteScalar())

                Dim cmdYesterday As New MySqlCommand("SELECT IFNULL(SUM(TotalAmount), 0) FROM sales WHERE DATE(SaleDate) = CURDATE() - INTERVAL 1 DAY", conn)
                yesterdayTotal = Convert.ToDecimal(cmdYesterday.ExecuteScalar())
            End Using

            If yesterdayTotal > 0 Then
                percentChange = ((todayTotal - yesterdayTotal) / yesterdayTotal) * 100
            Else
                percentChange = 0
            End If

            lbltotalRevenue.Text = "" & todayTotal.ToString("N2")

            If percentChange >= 0 Then
                lblPercent1Revenue.ForeColor = ColorTranslator.FromHtml("#40C057")
                lblPercent1Revenue.Text = "+" & percentChange.ToString("0.00") & "%"
                picpercentage1.Image = My.Resources.icons8_positive_dynamic_25
            Else
                lblPercent1Revenue.ForeColor = ColorTranslator.FromHtml("#FA5252")
                lblPercent1Revenue.Text = percentChange.ToString("0.00") & "%"
                picpercentage1.Image = My.Resources.icons8_negative_dynamic_25
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading revenue data: " & ex.Message)
        End Try
    End Sub


    ' === Total Customers ===
    Private Sub LoadTotalCustomers()
        Dim todayCustomers As Integer = 0
        Dim yesterdayCustomers As Integer = 0
        Dim percentChange As Decimal = 0D

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                Dim cmdToday As New MySqlCommand("SELECT COUNT(*) FROM sales WHERE DATE(SaleDate) = CURDATE()", conn)
                todayCustomers = Convert.ToInt32(cmdToday.ExecuteScalar())

                Dim cmdYesterday As New MySqlCommand("SELECT COUNT(*) FROM sales WHERE DATE(SaleDate) = CURDATE() - INTERVAL 1 DAY", conn)
                yesterdayCustomers = Convert.ToInt32(cmdYesterday.ExecuteScalar())
            End Using

            If yesterdayCustomers > 0 Then
                percentChange = ((todayCustomers - yesterdayCustomers) / yesterdayCustomers) * 100
            Else
                percentChange = 0
            End If

            lblTotalCustomers.Text = todayCustomers.ToString("N0")

            If percentChange >= 0 Then
                lblPercentCustomers.ForeColor = ColorTranslator.FromHtml("#40C057")
                lblPercentCustomers.Text = "+" & percentChange.ToString("0.00") & "%"
                picpercentage2.Image = My.Resources.icons8_positive_dynamic_25
            Else
                lblPercentCustomers.ForeColor = ColorTranslator.FromHtml("#FA5252")
                lblPercentCustomers.Text = percentChange.ToString("0.00") & "%"
                picpercentage2.Image = My.Resources.icons8_negative_dynamic_25
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading customer data: " & ex.Message)
        End Try
    End Sub


    ' === Total Product ===
    Private Sub LoadTotalProductsSold()
        Dim todaySold As Integer = 0
        Dim yesterdaySold As Integer = 0
        Dim percentChange As Decimal = 0D

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' --- Total items sold today ---
                Using cmdToday As New MySqlCommand("
                SELECT IFNULL(SUM(si.Quantity), 0)
                FROM sales_items si
                INNER JOIN sales s ON si.SaleID = s.SaleID
                WHERE DATE(s.SaleDate) = CURDATE()", conn)
                    todaySold = Convert.ToInt32(cmdToday.ExecuteScalar())
                End Using

                ' --- Total items sold yesterday ---
                Using cmdYesterday As New MySqlCommand("
                SELECT IFNULL(SUM(si.Quantity), 0)
                FROM sales_items si
                INNER JOIN sales s ON si.SaleID = s.SaleID
                WHERE DATE(s.SaleDate) = CURDATE() - INTERVAL 1 DAY", conn)
                    yesterdaySold = Convert.ToInt32(cmdYesterday.ExecuteScalar())
                End Using
            End Using

            ' --- Compute percentage change ---
            If yesterdaySold > 0 Then
                percentChange = ((todaySold - yesterdaySold) / yesterdaySold) * 100D
            Else
                percentChange = 0
            End If

            ' --- Display total sold ---
            lblTotalProductSold.Text = todaySold.ToString("N0")

            ' --- Update label and icon based on trend ---
            If percentChange >= 0 Then
                lblPercentSold.ForeColor = ColorTranslator.FromHtml("#40C057") ' green
                lblPercentSold.Text = "+" & percentChange.ToString("0.00") & "%"
                picPercentSold.Image = My.Resources.icons8_positive_dynamic_25
            Else
                lblPercentSold.ForeColor = ColorTranslator.FromHtml("#FA5252") ' red
                lblPercentSold.Text = percentChange.ToString("0.00") & "%"
                picPercentSold.Image = My.Resources.icons8_negative_dynamic_25
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading total products sold: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' === Total Return ===
    Private Sub LoadTotalReturns()
        Try
            Dim todayReturns As Long = 0
            Dim yesterdayReturns As Long = 0
            Dim percentChange As Decimal = 0D

            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                ' Get today's and yesterday's returns from customerreturns
                Dim sql As String = "
                SELECT ReturnID, TransactionNumber, BarcodeID, ReturnDate, QuantityReturned,
                       Reason, ConditionStatus, ApprovedBy, ReturnedToInventory
                FROM customerreturns
                WHERE DATE(ReturnDate) = CURDATE() OR DATE(ReturnDate) = CURDATE() - INTERVAL 1 DAY;
            "

                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim qty As Long = If(IsDBNull(reader("QuantityReturned")), 0, Convert.ToInt64(reader("QuantityReturned")))
                            Dim returnDate As Date = Convert.ToDateTime(reader("ReturnDate"))

                            If returnDate.Date = Date.Today Then
                                todayReturns += qty
                            ElseIf returnDate.Date = Date.Today.AddDays(-1) Then
                                yesterdayReturns += qty
                            End If
                        End While
                    End Using
                End Using
            End Using

            ' Calculate percent change safely
            If yesterdayReturns > 0 Then
                percentChange = ((todayReturns - yesterdayReturns) / yesterdayReturns) * 100
            ElseIf todayReturns > 0 Then
                percentChange = 100
            Else
                percentChange = 0
            End If

            ' Update labels
            lblTotalReturn.Text = todayReturns.ToString("N0")

            If percentChange >= 0 Then
                lblPercentReturn.ForeColor = ColorTranslator.FromHtml("#40C057")
                lblPercentReturn.Text = "+" & percentChange.ToString("0.00") & "%"
                picPercentReturn.Image = My.Resources.icons8_positive_dynamic_25
            Else
                lblPercentReturn.ForeColor = ColorTranslator.FromHtml("#FA5252")
                lblPercentReturn.Text = percentChange.ToString("0.00") & "%"
                picPercentReturn.Image = My.Resources.icons8_negative_dynamic_25
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading total returns: " & ex.Message)
        End Try
    End Sub





    ' === Total Sales Summary ===
    Private Sub LoadSalesSummary()
        Dim todaySales As Decimal = 0D
        Dim yesterdaySales As Decimal = 0D
        Dim thisMonthSales As Decimal = 0D
        Dim percentChange As Decimal = 0D

        Try
            Using conn As New MySqlConnection(connectionstring)
                conn.Open()

                Dim cmdToday As New MySqlCommand("SELECT IFNULL(SUM(TotalAmount), 0) FROM sales WHERE DATE(SaleDate) = CURDATE()", conn)
                todaySales = Convert.ToDecimal(cmdToday.ExecuteScalar())

                Dim cmdYesterday As New MySqlCommand("SELECT IFNULL(SUM(TotalAmount), 0) FROM sales WHERE DATE(SaleDate) = CURDATE() - INTERVAL 1 DAY", conn)
                yesterdaySales = Convert.ToDecimal(cmdYesterday.ExecuteScalar())

                Dim cmdMonth As New MySqlCommand("SELECT IFNULL(SUM(TotalAmount), 0) FROM sales WHERE MONTH(SaleDate) = MONTH(CURDATE()) AND YEAR(SaleDate) = YEAR(CURDATE())", conn)
                thisMonthSales = Convert.ToDecimal(cmdMonth.ExecuteScalar())
            End Using

            If yesterdaySales > 0 Then
                percentChange = ((todaySales - yesterdaySales) / yesterdaySales) * 100
            Else
                percentChange = 0
            End If

            lblTotalSalesToday.Text = "" & todaySales.ToString("N2")
            lblTotalSalesThismonth.Text = "" & thisMonthSales.ToString("N2")
            lblTotalSales2.Text = "" & yesterdaySales.ToString("N2")

            If percentChange > 0 Then
                lblPercentSales.ForeColor = ColorTranslator.FromHtml("#40C057")
                lblPercentSales.Text = "+" & percentChange.ToString("0.00") & "%"
                picSales.Image = My.Resources.icons8_positive_dynamic_25
                lblincreased.Text = "Increased"
                lblincreased.ForeColor = ColorTranslator.FromHtml("#40C057")
            ElseIf percentChange < 0 Then
                lblPercentSales.ForeColor = ColorTranslator.FromHtml("#FA5252")
                lblPercentSales.Text = percentChange.ToString("0.00") & "%"
                picSales.Image = My.Resources.icons8_negative_dynamic_25
                lblincreased.Text = "Decreased"
                lblincreased.ForeColor = ColorTranslator.FromHtml("#FA5252")
            Else
                lblPercentSales.ForeColor = Color.Gray
                lblPercentSales.Text = "0.00%"
                lblincreased.Text = "Unchanged"
                lblincreased.ForeColor = ColorTranslator.FromHtml("#40C057")
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading sales summary: " & ex.Message)
        End Try
    End Sub


    '========= FOR ALT F4 =========
    Private Sub dashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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









