<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        pnlHeader = New Panel()
        lblTitle = New Label()
        btnLogout = New Button()
        btnHelp = New Button()
        btnInstructions = New Button()
        pnlDashboard = New Panel()
        btnManageAccounts = New Button()
        btnSalesReport = New Button()
        btnAuditLog = New Button()
        btnManageMenu = New Button()
        pnlAuditLog = New Panel()
        btnExportAuditLogs = New Button()
        btnFilterAuditLogs = New Button()
        dtpAuditTo = New DateTimePicker()
        dtpAuditFrom = New DateTimePicker()
        chkDateFilter = New CheckBox()
        txtUsernameFilter = New TextBox()
        lblUsernameFilter = New Label()
        dgvAuditLogs = New DataGridView()
        lblAuditTitle = New Label()
        pnlSalesReport = New Panel()
        btnExportSalesReport = New Button()
        dgvSalesReport = New DataGridView()
        pnlSummary = New Panel()
        lblOrderCount = New Label()
        lblTotalSales = New Label()
        Label4 = New Label()
        Label3 = New Label()
        btnGenerateReport = New Button()
        dtpTo = New DateTimePicker()
        dtpFrom = New DateTimePicker()
        Label2 = New Label()
        Label1 = New Label()
        lblSalesTitle = New Label()
        pnlManageAccounts = New Panel()
        btnCreateAccount = New Button()
        dgvUsers = New DataGridView()
        lblAccountsTitle = New Label()
        pnlHeader.SuspendLayout()
        pnlDashboard.SuspendLayout()
        pnlAuditLog.SuspendLayout()
        CType(dgvAuditLogs, ComponentModel.ISupportInitialize).BeginInit()
        pnlSalesReport.SuspendLayout()
        CType(dgvSalesReport, ComponentModel.ISupportInitialize).BeginInit()
        pnlSummary.SuspendLayout()
        pnlManageAccounts.SuspendLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.DarkSeaGreen
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Controls.Add(btnHelp)
        pnlHeader.Controls.Add(btnInstructions)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(3, 4, 3, 4)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1467, 107)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(34, 27)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(365, 54)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Admin Dashboard"
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BackColor = Color.LightCoral
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 10F)
        btnLogout.Location = New Point(1320, 30)
        btnLogout.Margin = New Padding(3, 4, 3, 4)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(100, 51)
        btnLogout.TabIndex = 5
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnHelp
        ' 
        btnHelp.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnHelp.BackColor = Color.LightGreen
        btnHelp.FlatStyle = FlatStyle.Flat
        btnHelp.Font = New Font("Segoe UI", 10F)
        btnHelp.Location = New Point(1091, 30)
        btnHelp.Margin = New Padding(3, 4, 3, 4)
        btnHelp.Name = "btnHelp"
        btnHelp.Size = New Size(100, 51)
        btnHelp.TabIndex = 6
        btnHelp.Text = "Help"
        btnHelp.UseVisualStyleBackColor = False
        ' 
        ' btnInstructions
        ' 
        btnInstructions.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnInstructions.BackColor = Color.LightYellow
        btnInstructions.FlatStyle = FlatStyle.Flat
        btnInstructions.Font = New Font("Segoe UI", 10F)
        btnInstructions.Location = New Point(1197, 30)
        btnInstructions.Margin = New Padding(3, 4, 3, 4)
        btnInstructions.Name = "btnInstructions"
        btnInstructions.Size = New Size(118, 51)
        btnInstructions.TabIndex = 7
        btnInstructions.Text = "Instructions"
        btnInstructions.UseVisualStyleBackColor = False
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.BackColor = SystemColors.Control
        pnlDashboard.Controls.Add(btnManageAccounts)
        pnlDashboard.Controls.Add(btnSalesReport)
        pnlDashboard.Controls.Add(btnAuditLog)
        pnlDashboard.Controls.Add(btnManageMenu)
        pnlDashboard.Dock = DockStyle.Left
        pnlDashboard.Location = New Point(0, 107)
        pnlDashboard.Margin = New Padding(3, 4, 3, 4)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(286, 881)
        pnlDashboard.TabIndex = 1
        ' 
        ' btnManageAccounts
        ' 
        btnManageAccounts.BackColor = Color.LightBlue
        btnManageAccounts.FlatStyle = FlatStyle.Flat
        btnManageAccounts.Font = New Font("Segoe UI", 12F)
        btnManageAccounts.Location = New Point(23, 373)
        btnManageAccounts.Margin = New Padding(3, 4, 3, 4)
        btnManageAccounts.Name = "btnManageAccounts"
        btnManageAccounts.Size = New Size(240, 80)
        btnManageAccounts.TabIndex = 3
        btnManageAccounts.Text = "Manage Accounts"
        btnManageAccounts.UseVisualStyleBackColor = False
        ' 
        ' btnSalesReport
        ' 
        btnSalesReport.BackColor = Color.LightGreen
        btnSalesReport.FlatStyle = FlatStyle.Flat
        btnSalesReport.Font = New Font("Segoe UI", 12F)
        btnSalesReport.Location = New Point(23, 267)
        btnSalesReport.Margin = New Padding(3, 4, 3, 4)
        btnSalesReport.Name = "btnSalesReport"
        btnSalesReport.Size = New Size(240, 80)
        btnSalesReport.TabIndex = 2
        btnSalesReport.Text = "Sales Report"
        btnSalesReport.UseVisualStyleBackColor = False
        ' 
        ' btnAuditLog
        ' 
        btnAuditLog.BackColor = Color.LightCoral
        btnAuditLog.FlatStyle = FlatStyle.Flat
        btnAuditLog.Font = New Font("Segoe UI", 12F)
        btnAuditLog.Location = New Point(23, 160)
        btnAuditLog.Margin = New Padding(3, 4, 3, 4)
        btnAuditLog.Name = "btnAuditLog"
        btnAuditLog.Size = New Size(240, 80)
        btnAuditLog.TabIndex = 1
        btnAuditLog.Text = "Audit Log"
        btnAuditLog.UseVisualStyleBackColor = False
        ' 
        ' btnManageMenu
        ' 
        btnManageMenu.BackColor = Color.LightSalmon
        btnManageMenu.FlatStyle = FlatStyle.Flat
        btnManageMenu.Font = New Font("Segoe UI", 12F)
        btnManageMenu.Location = New Point(23, 53)
        btnManageMenu.Margin = New Padding(3, 4, 3, 4)
        btnManageMenu.Name = "btnManageMenu"
        btnManageMenu.Size = New Size(240, 80)
        btnManageMenu.TabIndex = 0
        btnManageMenu.Text = "Manage Menu Items"
        btnManageMenu.UseVisualStyleBackColor = False
        ' 
        ' pnlAuditLog
        ' 
        pnlAuditLog.BackColor = SystemColors.Control
        pnlAuditLog.Controls.Add(btnExportAuditLogs)
        pnlAuditLog.Controls.Add(btnFilterAuditLogs)
        pnlAuditLog.Controls.Add(dtpAuditTo)
        pnlAuditLog.Controls.Add(dtpAuditFrom)
        pnlAuditLog.Controls.Add(chkDateFilter)
        pnlAuditLog.Controls.Add(txtUsernameFilter)
        pnlAuditLog.Controls.Add(lblUsernameFilter)
        pnlAuditLog.Controls.Add(dgvAuditLogs)
        pnlAuditLog.Controls.Add(lblAuditTitle)
        pnlAuditLog.Dock = DockStyle.Fill
        pnlAuditLog.Location = New Point(286, 107)
        pnlAuditLog.Margin = New Padding(3, 4, 3, 4)
        pnlAuditLog.Name = "pnlAuditLog"
        pnlAuditLog.Size = New Size(1181, 881)
        pnlAuditLog.TabIndex = 2
        ' 
        ' btnExportAuditLogs
        ' 
        btnExportAuditLogs.BackColor = Color.Gold
        btnExportAuditLogs.FlatStyle = FlatStyle.Flat
        btnExportAuditLogs.Location = New Point(949, 80)
        btnExportAuditLogs.Margin = New Padding(3, 4, 3, 4)
        btnExportAuditLogs.Name = "btnExportAuditLogs"
        btnExportAuditLogs.Size = New Size(137, 40)
        btnExportAuditLogs.TabIndex = 8
        btnExportAuditLogs.Text = "Export to CSV"
        btnExportAuditLogs.UseVisualStyleBackColor = False
        ' 
        ' btnFilterAuditLogs
        ' 
        btnFilterAuditLogs.BackColor = Color.SpringGreen
        btnFilterAuditLogs.FlatStyle = FlatStyle.Flat
        btnFilterAuditLogs.Location = New Point(800, 80)
        btnFilterAuditLogs.Margin = New Padding(3, 4, 3, 4)
        btnFilterAuditLogs.Name = "btnFilterAuditLogs"
        btnFilterAuditLogs.Size = New Size(114, 40)
        btnFilterAuditLogs.TabIndex = 7
        btnFilterAuditLogs.Text = "Filter"
        btnFilterAuditLogs.UseVisualStyleBackColor = False
        ' 
        ' dtpAuditTo
        ' 
        dtpAuditTo.Enabled = False
        dtpAuditTo.Location = New Point(651, 87)
        dtpAuditTo.Margin = New Padding(3, 4, 3, 4)
        dtpAuditTo.Name = "dtpAuditTo"
        dtpAuditTo.Size = New Size(137, 27)
        dtpAuditTo.TabIndex = 6
        ' 
        ' dtpAuditFrom
        ' 
        dtpAuditFrom.Enabled = False
        dtpAuditFrom.Location = New Point(503, 87)
        dtpAuditFrom.Margin = New Padding(3, 4, 3, 4)
        dtpAuditFrom.Name = "dtpAuditFrom"
        dtpAuditFrom.Size = New Size(137, 27)
        dtpAuditFrom.TabIndex = 5
        ' 
        ' chkDateFilter
        ' 
        chkDateFilter.AutoSize = True
        chkDateFilter.Location = New Point(400, 91)
        chkDateFilter.Margin = New Padding(3, 4, 3, 4)
        chkDateFilter.Name = "chkDateFilter"
        chkDateFilter.Size = New Size(109, 24)
        chkDateFilter.TabIndex = 4
        chkDateFilter.Text = "Date Range"
        chkDateFilter.UseVisualStyleBackColor = True
        ' 
        ' txtUsernameFilter
        ' 
        txtUsernameFilter.Location = New Point(171, 87)
        txtUsernameFilter.Margin = New Padding(3, 4, 3, 4)
        txtUsernameFilter.Name = "txtUsernameFilter"
        txtUsernameFilter.PlaceholderText = "Enter username..."
        txtUsernameFilter.Size = New Size(205, 27)
        txtUsernameFilter.TabIndex = 3
        ' 
        ' lblUsernameFilter
        ' 
        lblUsernameFilter.AutoSize = True
        lblUsernameFilter.Font = New Font("Segoe UI", 10F)
        lblUsernameFilter.Location = New Point(34, 91)
        lblUsernameFilter.Name = "lblUsernameFilter"
        lblUsernameFilter.Size = New Size(133, 23)
        lblUsernameFilter.TabIndex = 2
        lblUsernameFilter.Text = "Filter Username:"
        ' 
        ' dgvAuditLogs
        ' 
        dgvAuditLogs.AllowUserToAddRows = False
        dgvAuditLogs.AllowUserToDeleteRows = False
        dgvAuditLogs.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvAuditLogs.BackgroundColor = Color.White
        dgvAuditLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAuditLogs.Location = New Point(34, 147)
        dgvAuditLogs.Margin = New Padding(3, 4, 3, 4)
        dgvAuditLogs.Name = "dgvAuditLogs"
        dgvAuditLogs.ReadOnly = True
        dgvAuditLogs.RowHeadersWidth = 51
        dgvAuditLogs.Size = New Size(1119, 707)
        dgvAuditLogs.TabIndex = 1
        ' 
        ' lblAuditTitle
        ' 
        lblAuditTitle.AutoSize = True
        lblAuditTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblAuditTitle.Location = New Point(34, 27)
        lblAuditTitle.Name = "lblAuditTitle"
        lblAuditTitle.Size = New Size(157, 41)
        lblAuditTitle.TabIndex = 0
        lblAuditTitle.Text = "Audit Log"
        ' 
        ' pnlSalesReport
        ' 
        pnlSalesReport.BackColor = SystemColors.Control
        pnlSalesReport.Controls.Add(btnExportSalesReport)
        pnlSalesReport.Controls.Add(dgvSalesReport)
        pnlSalesReport.Controls.Add(pnlSummary)
        pnlSalesReport.Controls.Add(btnGenerateReport)
        pnlSalesReport.Controls.Add(dtpTo)
        pnlSalesReport.Controls.Add(dtpFrom)
        pnlSalesReport.Controls.Add(Label2)
        pnlSalesReport.Controls.Add(Label1)
        pnlSalesReport.Controls.Add(lblSalesTitle)
        pnlSalesReport.Dock = DockStyle.Fill
        pnlSalesReport.Location = New Point(286, 107)
        pnlSalesReport.Margin = New Padding(3, 4, 3, 4)
        pnlSalesReport.Name = "pnlSalesReport"
        pnlSalesReport.Size = New Size(1181, 881)
        pnlSalesReport.TabIndex = 3
        pnlSalesReport.Visible = False
        ' 
        ' btnExportSalesReport
        ' 
        btnExportSalesReport.BackColor = Color.Gold
        btnExportSalesReport.FlatStyle = FlatStyle.Flat
        btnExportSalesReport.Location = New Point(949, 240)
        btnExportSalesReport.Margin = New Padding(3, 4, 3, 4)
        btnExportSalesReport.Name = "btnExportSalesReport"
        btnExportSalesReport.Size = New Size(137, 40)
        btnExportSalesReport.TabIndex = 8
        btnExportSalesReport.Text = "Export to CSV"
        btnExportSalesReport.UseVisualStyleBackColor = False
        ' 
        ' dgvSalesReport
        ' 
        dgvSalesReport.AllowUserToAddRows = False
        dgvSalesReport.AllowUserToDeleteRows = False
        dgvSalesReport.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvSalesReport.BackgroundColor = Color.White
        dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSalesReport.Location = New Point(34, 307)
        dgvSalesReport.Margin = New Padding(3, 4, 3, 4)
        dgvSalesReport.Name = "dgvSalesReport"
        dgvSalesReport.ReadOnly = True
        dgvSalesReport.RowHeadersWidth = 51
        dgvSalesReport.Size = New Size(1119, 547)
        dgvSalesReport.TabIndex = 7
        ' 
        ' pnlSummary
        ' 
        pnlSummary.BackColor = Color.LightYellow
        pnlSummary.BorderStyle = BorderStyle.FixedSingle
        pnlSummary.Controls.Add(lblOrderCount)
        pnlSummary.Controls.Add(lblTotalSales)
        pnlSummary.Controls.Add(Label4)
        pnlSummary.Controls.Add(Label3)
        pnlSummary.Location = New Point(34, 160)
        pnlSummary.Margin = New Padding(3, 4, 3, 4)
        pnlSummary.Name = "pnlSummary"
        pnlSummary.Size = New Size(457, 106)
        pnlSummary.TabIndex = 6
        ' 
        ' lblOrderCount
        ' 
        lblOrderCount.AutoSize = True
        lblOrderCount.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblOrderCount.Location = New Point(366, 53)
        lblOrderCount.Name = "lblOrderCount"
        lblOrderCount.Size = New Size(28, 32)
        lblOrderCount.TabIndex = 3
        lblOrderCount.Text = "0"
        ' 
        ' lblTotalSales
        ' 
        lblTotalSales.AutoSize = True
        lblTotalSales.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTotalSales.Location = New Point(137, 53)
        lblTotalSales.Name = "lblTotalSales"
        lblTotalSales.Size = New Size(43, 32)
        lblTotalSales.TabIndex = 2
        lblTotalSales.Text = "₱0"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F)
        Label4.Location = New Point(251, 20)
        Label4.Name = "Label4"
        Label4.Size = New Size(110, 23)
        Label4.TabIndex = 1
        Label4.Text = "Order Count:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F)
        Label3.Location = New Point(23, 20)
        Label3.Name = "Label3"
        Label3.Size = New Size(93, 23)
        Label3.TabIndex = 0
        Label3.Text = "Total Sales:"
        ' 
        ' btnGenerateReport
        ' 
        btnGenerateReport.BackColor = Color.SpringGreen
        btnGenerateReport.FlatStyle = FlatStyle.Flat
        btnGenerateReport.Font = New Font("Segoe UI", 10F)
        btnGenerateReport.Location = New Point(400, 87)
        btnGenerateReport.Margin = New Padding(3, 4, 3, 4)
        btnGenerateReport.Name = "btnGenerateReport"
        btnGenerateReport.Size = New Size(137, 40)
        btnGenerateReport.TabIndex = 5
        btnGenerateReport.Text = "Generate Report"
        btnGenerateReport.UseVisualStyleBackColor = False
        ' 
        ' dtpTo
        ' 
        dtpTo.Location = New Point(229, 93)
        dtpTo.Margin = New Padding(3, 4, 3, 4)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(137, 27)
        dtpTo.TabIndex = 4
        ' 
        ' dtpFrom
        ' 
        dtpFrom.Location = New Point(80, 93)
        dtpFrom.Margin = New Padding(3, 4, 3, 4)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(137, 27)
        dtpFrom.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.Location = New Point(229, 64)
        Label2.Name = "Label2"
        Label2.Size = New Size(31, 23)
        Label2.TabIndex = 2
        Label2.Text = "To:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.Location = New Point(80, 64)
        Label1.Name = "Label1"
        Label1.Size = New Size(53, 23)
        Label1.TabIndex = 1
        Label1.Text = "From:"
        ' 
        ' lblSalesTitle
        ' 
        lblSalesTitle.AutoSize = True
        lblSalesTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblSalesTitle.Location = New Point(34, 27)
        lblSalesTitle.Name = "lblSalesTitle"
        lblSalesTitle.Size = New Size(194, 41)
        lblSalesTitle.TabIndex = 0
        lblSalesTitle.Text = "Sales Report"
        ' 
        ' pnlManageAccounts
        ' 
        pnlManageAccounts.BackColor = SystemColors.Control
        pnlManageAccounts.Controls.Add(btnCreateAccount)
        pnlManageAccounts.Controls.Add(dgvUsers)
        pnlManageAccounts.Controls.Add(lblAccountsTitle)
        pnlManageAccounts.Dock = DockStyle.Fill
        pnlManageAccounts.Location = New Point(286, 107)
        pnlManageAccounts.Margin = New Padding(3, 4, 3, 4)
        pnlManageAccounts.Name = "pnlManageAccounts"
        pnlManageAccounts.Size = New Size(1181, 881)
        pnlManageAccounts.TabIndex = 4
        pnlManageAccounts.Visible = False
        ' 
        ' btnCreateAccount
        ' 
        btnCreateAccount.BackColor = Color.LightGray
        btnCreateAccount.Enabled = False
        btnCreateAccount.FlatStyle = FlatStyle.Flat
        btnCreateAccount.Font = New Font("Segoe UI", 10F)
        btnCreateAccount.Location = New Point(34, 93)
        btnCreateAccount.Margin = New Padding(3, 4, 3, 4)
        btnCreateAccount.Name = "btnCreateAccount"
        btnCreateAccount.Size = New Size(268, 47)
        btnCreateAccount.TabIndex = 2
        btnCreateAccount.Text = "Create Account (MVP Later)"
        btnCreateAccount.UseVisualStyleBackColor = False
        ' 
        ' dgvUsers
        ' 
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.AllowUserToDeleteRows = False
        dgvUsers.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsers.Location = New Point(34, 160)
        dgvUsers.Margin = New Padding(3, 4, 3, 4)
        dgvUsers.Name = "dgvUsers"
        dgvUsers.ReadOnly = True
        dgvUsers.RowHeadersWidth = 51
        dgvUsers.Size = New Size(1119, 693)
        dgvUsers.TabIndex = 1
        ' 
        ' lblAccountsTitle
        ' 
        lblAccountsTitle.AutoSize = True
        lblAccountsTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblAccountsTitle.Location = New Point(34, 27)
        lblAccountsTitle.Name = "lblAccountsTitle"
        lblAccountsTitle.Size = New Size(268, 41)
        lblAccountsTitle.TabIndex = 0
        lblAccountsTitle.Text = "Manage Accounts"
        ' 
        ' Admin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1467, 988)
        Controls.Add(pnlManageAccounts)
        Controls.Add(pnlSalesReport)
        Controls.Add(pnlAuditLog)
        Controls.Add(pnlDashboard)
        Controls.Add(pnlHeader)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Admin"
        Text = "Admin Dashboard - OrderUp!"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlDashboard.ResumeLayout(False)
        pnlAuditLog.ResumeLayout(False)
        pnlAuditLog.PerformLayout()
        CType(dgvAuditLogs, ComponentModel.ISupportInitialize).EndInit()
        pnlSalesReport.ResumeLayout(False)
        pnlSalesReport.PerformLayout()
        CType(dgvSalesReport, ComponentModel.ISupportInitialize).EndInit()
        pnlSummary.ResumeLayout(False)
        pnlSummary.PerformLayout()
        pnlManageAccounts.ResumeLayout(False)
        pnlManageAccounts.PerformLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents btnManageMenu As Button
    Friend WithEvents btnAuditLog As Button
    Friend WithEvents btnSalesReport As Button
    Friend WithEvents btnManageAccounts As Button
    Friend WithEvents pnlAuditLog As Panel
    Friend WithEvents lblAuditTitle As Label
    Friend WithEvents dgvAuditLogs As DataGridView
    Friend WithEvents lblUsernameFilter As Label
    Friend WithEvents txtUsernameFilter As TextBox
    Friend WithEvents chkDateFilter As CheckBox
    Friend WithEvents dtpAuditFrom As DateTimePicker
    Friend WithEvents dtpAuditTo As DateTimePicker
    Friend WithEvents btnFilterAuditLogs As Button
    Friend WithEvents btnExportAuditLogs As Button
    Friend WithEvents pnlSalesReport As Panel
    Friend WithEvents lblSalesTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents pnlSummary As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotalSales As Label
    Friend WithEvents lblOrderCount As Label
    Friend WithEvents dgvSalesReport As DataGridView
    Friend WithEvents btnExportSalesReport As Button
    Friend WithEvents pnlManageAccounts As Panel
    Friend WithEvents lblAccountsTitle As Label
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents btnCreateAccount As Button
    ' Designer nav buttons
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnInstructions As Button
End Class