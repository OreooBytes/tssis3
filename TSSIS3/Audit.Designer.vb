<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Audit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvAuditTrail = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dptStartDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.dptEndDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        CType(Me.dgvAuditTrail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAuditTrail
        '
        Me.dgvAuditTrail.AllowUserToAddRows = False
        Me.dgvAuditTrail.AllowUserToDeleteRows = False
        Me.dgvAuditTrail.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvAuditTrail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAuditTrail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAuditTrail.ColumnHeadersHeight = 24
        Me.dgvAuditTrail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FirstName, Me.LastName, Me.MI, Me.Address, Me.UserType})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAuditTrail.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAuditTrail.GridColor = System.Drawing.Color.White
        Me.dgvAuditTrail.Location = New System.Drawing.Point(5, 136)
        Me.dgvAuditTrail.Name = "dgvAuditTrail"
        Me.dgvAuditTrail.ReadOnly = True
        Me.dgvAuditTrail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvAuditTrail.RowHeadersVisible = False
        Me.dgvAuditTrail.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dgvAuditTrail.RowTemplate.ReadOnly = True
        Me.dgvAuditTrail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAuditTrail.Size = New System.Drawing.Size(1093, 523)
        Me.dgvAuditTrail.TabIndex = 17
        Me.dgvAuditTrail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvAuditTrail.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvAuditTrail.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvAuditTrail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvAuditTrail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvAuditTrail.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvAuditTrail.ThemeStyle.GridColor = System.Drawing.Color.White
        Me.dgvAuditTrail.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAuditTrail.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvAuditTrail.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAuditTrail.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvAuditTrail.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvAuditTrail.ThemeStyle.HeaderStyle.Height = 24
        Me.dgvAuditTrail.ThemeStyle.ReadOnly = True
        Me.dgvAuditTrail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvAuditTrail.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvAuditTrail.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAuditTrail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvAuditTrail.ThemeStyle.RowsStyle.Height = 22
        Me.dgvAuditTrail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAuditTrail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'FirstName
        '
        Me.FirstName.HeaderText = "AuditID"
        Me.FirstName.Name = "FirstName"
        Me.FirstName.ReadOnly = True
        '
        'LastName
        '
        Me.LastName.HeaderText = "Role"
        Me.LastName.Name = "LastName"
        Me.LastName.ReadOnly = True
        '
        'MI
        '
        Me.MI.HeaderText = " Fullname"
        Me.MI.Name = "MI"
        Me.MI.ReadOnly = True
        '
        'Address
        '
        Me.Address.HeaderText = "Action"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        '
        'UserType
        '
        Me.UserType.HeaderText = "Date"
        Me.UserType.Name = "UserType"
        Me.UserType.ReadOnly = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_window_50
        Me.PictureBox3.Location = New System.Drawing.Point(1056, 1)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(47, 49)
        Me.PictureBox3.TabIndex = 70
        Me.PictureBox3.TabStop = False
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(898, 73)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(62, 17)
        Me.Guna2HtmlLabel2.TabIndex = 69
        Me.Guna2HtmlLabel2.Text = "End Date"
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(709, 73)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(67, 17)
        Me.Guna2HtmlLabel1.TabIndex = 68
        Me.Guna2HtmlLabel1.Text = "Start Date"
        '
        'dptStartDate
        '
        Me.dptStartDate.BorderRadius = 5
        Me.dptStartDate.Checked = True
        Me.dptStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dptStartDate.ForeColor = System.Drawing.SystemColors.Control
        Me.dptStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dptStartDate.Location = New System.Drawing.Point(692, 94)
        Me.dptStartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dptStartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dptStartDate.Name = "dptStartDate"
        Me.dptStartDate.Size = New System.Drawing.Size(200, 36)
        Me.dptStartDate.TabIndex = 67
        Me.dptStartDate.Value = New Date(2025, 10, 16, 1, 7, 11, 632)
        '
        'dptEndDate
        '
        Me.dptEndDate.BorderRadius = 5
        Me.dptEndDate.Checked = True
        Me.dptEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dptEndDate.ForeColor = System.Drawing.SystemColors.Control
        Me.dptEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dptEndDate.Location = New System.Drawing.Point(898, 94)
        Me.dptEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dptEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dptEndDate.Name = "dptEndDate"
        Me.dptEndDate.Size = New System.Drawing.Size(200, 36)
        Me.dptEndDate.TabIndex = 66
        Me.dptEndDate.Value = New Date(2025, 10, 16, 1, 7, 11, 632)
        '
        'txtSearch
        '
        Me.txtSearch.BorderColor = System.Drawing.Color.LightGray
        Me.txtSearch.BorderRadius = 5
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.IconLeft = Global.TSSIS3.My.Resources.Resources.icons8_search_35
        Me.txtSearch.Location = New System.Drawing.Point(5, 94)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtSearch.PlaceholderText = "Search "
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(228, 36)
        Me.txtSearch.TabIndex = 65
        '
        'Audit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1110, 736)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Controls.Add(Me.dptStartDate)
        Me.Controls.Add(Me.dptEndDate)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dgvAuditTrail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Audit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Audit"
        CType(Me.dgvAuditTrail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvAuditTrail As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents FirstName As DataGridViewTextBoxColumn
    Friend WithEvents LastName As DataGridViewTextBoxColumn
    Friend WithEvents MI As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents UserType As DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dptStartDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents dptEndDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
End Class
