<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeliveryList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDeliveriesList = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dptStartDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.dptEndDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtSearchSupplier = New Guna.UI2.WinForms.Guna2TextBox()
        CType(Me.dgvDeliveriesList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDeliveriesList
        '
        Me.dgvDeliveriesList.AllowUserToAddRows = False
        Me.dgvDeliveriesList.AllowUserToDeleteRows = False
        Me.dgvDeliveriesList.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvDeliveriesList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDeliveriesList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDeliveriesList.ColumnHeadersHeight = 24
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDeliveriesList.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDeliveriesList.GridColor = System.Drawing.Color.White
        Me.dgvDeliveriesList.Location = New System.Drawing.Point(4, 180)
        Me.dgvDeliveriesList.Name = "dgvDeliveriesList"
        Me.dgvDeliveriesList.ReadOnly = True
        Me.dgvDeliveriesList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvDeliveriesList.RowHeadersVisible = False
        Me.dgvDeliveriesList.RowHeadersWidth = 51
        Me.dgvDeliveriesList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dgvDeliveriesList.RowTemplate.ReadOnly = True
        Me.dgvDeliveriesList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDeliveriesList.Size = New System.Drawing.Size(1291, 467)
        Me.dgvDeliveriesList.TabIndex = 59
        Me.dgvDeliveriesList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvDeliveriesList.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvDeliveriesList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvDeliveriesList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvDeliveriesList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvDeliveriesList.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvDeliveriesList.ThemeStyle.GridColor = System.Drawing.Color.White
        Me.dgvDeliveriesList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvDeliveriesList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvDeliveriesList.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDeliveriesList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvDeliveriesList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDeliveriesList.ThemeStyle.HeaderStyle.Height = 24
        Me.dgvDeliveriesList.ThemeStyle.ReadOnly = True
        Me.dgvDeliveriesList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvDeliveriesList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvDeliveriesList.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDeliveriesList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvDeliveriesList.ThemeStyle.RowsStyle.Height = 22
        Me.dgvDeliveriesList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvDeliveriesList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(1080, 117)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(62, 17)
        Me.Guna2HtmlLabel2.TabIndex = 73
        Me.Guna2HtmlLabel2.Text = "End Date"
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(859, 117)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(67, 17)
        Me.Guna2HtmlLabel1.TabIndex = 72
        Me.Guna2HtmlLabel1.Text = "Start Date"
        '
        'dptStartDate
        '
        Me.dptStartDate.BorderRadius = 5
        Me.dptStartDate.Checked = True
        Me.dptStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dptStartDate.ForeColor = System.Drawing.SystemColors.Control
        Me.dptStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dptStartDate.Location = New System.Drawing.Point(859, 138)
        Me.dptStartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dptStartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dptStartDate.Name = "dptStartDate"
        Me.dptStartDate.Size = New System.Drawing.Size(215, 36)
        Me.dptStartDate.TabIndex = 71
        Me.dptStartDate.Value = New Date(2025, 10, 16, 1, 7, 11, 632)
        '
        'dptEndDate
        '
        Me.dptEndDate.BorderRadius = 5
        Me.dptEndDate.Checked = True
        Me.dptEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dptEndDate.ForeColor = System.Drawing.SystemColors.Control
        Me.dptEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dptEndDate.Location = New System.Drawing.Point(1080, 138)
        Me.dptEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dptEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dptEndDate.Name = "dptEndDate"
        Me.dptEndDate.Size = New System.Drawing.Size(215, 36)
        Me.dptEndDate.TabIndex = 70
        Me.dptEndDate.Value = New Date(2025, 10, 16, 1, 7, 11, 632)
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom
        Me.Guna2Panel1.Controls.Add(Me.PictureBox2)
        Me.Guna2Panel1.Location = New System.Drawing.Point(5, 11)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(472, 79)
        Me.Guna2Panel1.TabIndex = 74
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.Guna2Panel1)
        Me.Panel1.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Panel1.Controls.Add(Me.dgvDeliveriesList)
        Me.Panel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Panel1.Controls.Add(Me.txtSearchSupplier)
        Me.Panel1.Controls.Add(Me.dptStartDate)
        Me.Panel1.Controls.Add(Me.dptEndDate)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1298, 659)
        Me.Panel1.TabIndex = 75
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.TSSIS3.My.Resources.Resources.icons8_close_window_50
        Me.PictureBox3.Location = New System.Drawing.Point(1248, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(47, 49)
        Me.PictureBox3.TabIndex = 58
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.TSSIS3.My.Resources.Resources.DL
        Me.PictureBox2.Location = New System.Drawing.Point(-12, -27)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(310, 107)
        Me.PictureBox2.TabIndex = 60
        Me.PictureBox2.TabStop = False
        '
        'txtSearchSupplier
        '
        Me.txtSearchSupplier.BorderColor = System.Drawing.Color.LightGray
        Me.txtSearchSupplier.BorderRadius = 5
        Me.txtSearchSupplier.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearchSupplier.DefaultText = ""
        Me.txtSearchSupplier.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearchSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearchSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearchSupplier.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearchSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearchSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtSearchSupplier.ForeColor = System.Drawing.Color.Black
        Me.txtSearchSupplier.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearchSupplier.IconLeft = Global.TSSIS3.My.Resources.Resources.icons8_search_35
        Me.txtSearchSupplier.Location = New System.Drawing.Point(5, 138)
        Me.txtSearchSupplier.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearchSupplier.Name = "txtSearchSupplier"
        Me.txtSearchSupplier.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtSearchSupplier.PlaceholderText = "Search Deliveries"
        Me.txtSearchSupplier.SelectedText = ""
        Me.txtSearchSupplier.Size = New System.Drawing.Size(228, 36)
        Me.txtSearchSupplier.TabIndex = 57
        '
        'DeliveryList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1322, 685)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DeliveryList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DeliveryList"
        CType(Me.dgvDeliveriesList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents txtSearchSupplier As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvDeliveriesList As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dptStartDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents dptEndDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Panel1 As Panel


End Class
