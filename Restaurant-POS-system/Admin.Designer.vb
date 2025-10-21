<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

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
        pnlCharts = New Panel()
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
        pnlAccountCards = New Panel()
        txtSearchAccounts = New TextBox()
        lblSearchAccounts = New Label()
        btnCreateAccount = New Button()
        lblAccountsTitle = New Label()
        SettingsBtn = New FontAwesome.Sharp.IconButton()
        pnlHeader.SuspendLayout()
        pnlDashboard.SuspendLayout()
        pnlAuditLog.SuspendLayout()
        CType(dgvAuditLogs, ComponentModel.ISupportInitialize).BeginInit()
        pnlSalesReport.SuspendLayout()
        CType(dgvSalesReport, ComponentModel.ISupportInitialize).BeginInit()
        pnlSummary.SuspendLayout()
        pnlManageAccounts.SuspendLayout()
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
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1284, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(30, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(293, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Admin Dashboard"
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BackColor = Color.LightCoral
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 10F)
        btnLogout.Location = New Point(1155, 22)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(88, 38)
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
        btnHelp.Location = New Point(955, 22)
        btnHelp.Name = "btnHelp"
        btnHelp.Size = New Size(88, 38)
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
        btnInstructions.Location = New Point(1047, 22)
        btnInstructions.Name = "btnInstructions"
        btnInstructions.Size = New Size(103, 38)
        btnInstructions.TabIndex = 7
        btnInstructions.Text = "Instructions"
        btnInstructions.UseVisualStyleBackColor = False
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.BackColor = SystemColors.Control
        pnlDashboard.Controls.Add(SettingsBtn)
        pnlDashboard.Controls.Add(btnManageAccounts)
        pnlDashboard.Controls.Add(btnSalesReport)
        pnlDashboard.Controls.Add(btnAuditLog)
        pnlDashboard.Controls.Add(btnManageMenu)
        pnlDashboard.Dock = DockStyle.Left
        pnlDashboard.Location = New Point(0, 80)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(250, 581)
        pnlDashboard.TabIndex = 1
        ' 
        ' btnManageAccounts
        ' 
        btnManageAccounts.BackColor = Color.LightBlue
        btnManageAccounts.FlatStyle = FlatStyle.Flat
        btnManageAccounts.Font = New Font("Segoe UI", 12F)
        btnManageAccounts.Location = New Point(20, 280)
        btnManageAccounts.Name = "btnManageAccounts"
        btnManageAccounts.Size = New Size(210, 60)
        btnManageAccounts.TabIndex = 3
        btnManageAccounts.Text = "Manage Accounts"
        btnManageAccounts.UseVisualStyleBackColor = False
        ' 
        ' btnSalesReport
        ' 
        btnSalesReport.BackColor = Color.LightGreen
        btnSalesReport.FlatStyle = FlatStyle.Flat
        btnSalesReport.Font = New Font("Segoe UI", 12F)
        btnSalesReport.Location = New Point(20, 200)
        btnSalesReport.Name = "btnSalesReport"
        btnSalesReport.Size = New Size(210, 60)
        btnSalesReport.TabIndex = 2
        btnSalesReport.Text = "Sales Report"
        btnSalesReport.UseVisualStyleBackColor = False
        ' 
        ' btnAuditLog
        ' 
        btnAuditLog.BackColor = Color.LightCoral
        btnAuditLog.FlatStyle = FlatStyle.Flat
        btnAuditLog.Font = New Font("Segoe UI", 12F)
        btnAuditLog.Location = New Point(20, 120)
        btnAuditLog.Name = "btnAuditLog"
        btnAuditLog.Size = New Size(210, 60)
        btnAuditLog.TabIndex = 1
        btnAuditLog.Text = "Audit Log"
        btnAuditLog.UseVisualStyleBackColor = False
        ' 
        ' btnManageMenu
        ' 
        btnManageMenu.BackColor = Color.LightSalmon
        btnManageMenu.FlatStyle = FlatStyle.Flat
        btnManageMenu.Font = New Font("Segoe UI", 12F)
        btnManageMenu.Location = New Point(20, 40)
        btnManageMenu.Name = "btnManageMenu"
        btnManageMenu.Size = New Size(210, 60)
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
        pnlAuditLog.Location = New Point(250, 80)
        pnlAuditLog.Name = "pnlAuditLog"
        pnlAuditLog.Size = New Size(1034, 581)
        pnlAuditLog.TabIndex = 2
        ' 
        ' btnExportAuditLogs
        ' 
        btnExportAuditLogs.BackColor = Color.Gold
        btnExportAuditLogs.FlatStyle = FlatStyle.Flat
        btnExportAuditLogs.Location = New Point(830, 60)
        btnExportAuditLogs.Name = "btnExportAuditLogs"
        btnExportAuditLogs.Size = New Size(120, 30)
        btnExportAuditLogs.TabIndex = 8
        btnExportAuditLogs.Text = "Export to CSV"
        btnExportAuditLogs.UseVisualStyleBackColor = False
        ' 
        ' btnFilterAuditLogs
        ' 
        btnFilterAuditLogs.BackColor = Color.SpringGreen
        btnFilterAuditLogs.FlatStyle = FlatStyle.Flat
        btnFilterAuditLogs.Location = New Point(700, 60)
        btnFilterAuditLogs.Name = "btnFilterAuditLogs"
        btnFilterAuditLogs.Size = New Size(100, 30)
        btnFilterAuditLogs.TabIndex = 7
        btnFilterAuditLogs.Text = "Filter"
        btnFilterAuditLogs.UseVisualStyleBackColor = False
        ' 
        ' dtpAuditTo
        ' 
        dtpAuditTo.Enabled = False
        dtpAuditTo.Location = New Point(570, 65)
        dtpAuditTo.Name = "dtpAuditTo"
        dtpAuditTo.Size = New Size(120, 23)
        dtpAuditTo.TabIndex = 6
        ' 
        ' dtpAuditFrom
        ' 
        dtpAuditFrom.Enabled = False
        dtpAuditFrom.Location = New Point(440, 65)
        dtpAuditFrom.Name = "dtpAuditFrom"
        dtpAuditFrom.Size = New Size(120, 23)
        dtpAuditFrom.TabIndex = 5
        ' 
        ' chkDateFilter
        ' 
        chkDateFilter.AutoSize = True
        chkDateFilter.Location = New Point(350, 68)
        chkDateFilter.Name = "chkDateFilter"
        chkDateFilter.Size = New Size(86, 19)
        chkDateFilter.TabIndex = 4
        chkDateFilter.Text = "Date Range"
        chkDateFilter.UseVisualStyleBackColor = True
        ' 
        ' txtUsernameFilter
        ' 
        txtUsernameFilter.Location = New Point(150, 65)
        txtUsernameFilter.Name = "txtUsernameFilter"
        txtUsernameFilter.PlaceholderText = "Enter username..."
        txtUsernameFilter.Size = New Size(180, 23)
        txtUsernameFilter.TabIndex = 3
        ' 
        ' lblUsernameFilter
        ' 
        lblUsernameFilter.AutoSize = True
        lblUsernameFilter.Font = New Font("Segoe UI", 10F)
        lblUsernameFilter.Location = New Point(30, 68)
        lblUsernameFilter.Name = "lblUsernameFilter"
        lblUsernameFilter.Size = New Size(108, 19)
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
        dgvAuditLogs.Location = New Point(30, 110)
        dgvAuditLogs.Name = "dgvAuditLogs"
        dgvAuditLogs.ReadOnly = True
        dgvAuditLogs.RowHeadersWidth = 51
        dgvAuditLogs.Size = New Size(980, 450)
        dgvAuditLogs.TabIndex = 1
        ' 
        ' lblAuditTitle
        ' 
        lblAuditTitle.AutoSize = True
        lblAuditTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblAuditTitle.Location = New Point(30, 20)
        lblAuditTitle.Name = "lblAuditTitle"
        lblAuditTitle.Size = New Size(126, 32)
        lblAuditTitle.TabIndex = 0
        lblAuditTitle.Text = "Audit Log"
        ' 
        ' pnlSalesReport
        ' 
        pnlSalesReport.BackColor = SystemColors.Control
        pnlSalesReport.Controls.Add(pnlCharts)
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
        pnlSalesReport.Location = New Point(250, 80)
        pnlSalesReport.Name = "pnlSalesReport"
        pnlSalesReport.Size = New Size(1034, 581)
        pnlSalesReport.TabIndex = 3
        pnlSalesReport.Visible = False
        ' 
        ' pnlCharts
        ' 
        pnlCharts.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlCharts.Location = New Point(30, 218)
        pnlCharts.Margin = New Padding(3, 2, 3, 2)
        pnlCharts.Name = "pnlCharts"
        pnlCharts.Size = New Size(980, 225)
        pnlCharts.TabIndex = 9
        ' 
        ' btnExportSalesReport
        ' 
        btnExportSalesReport.BackColor = Color.Gold
        btnExportSalesReport.FlatStyle = FlatStyle.Flat
        btnExportSalesReport.Location = New Point(830, 450)
        btnExportSalesReport.Name = "btnExportSalesReport"
        btnExportSalesReport.Size = New Size(120, 30)
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
        dgvSalesReport.Location = New Point(30, 488)
        dgvSalesReport.Name = "dgvSalesReport"
        dgvSalesReport.ReadOnly = True
        dgvSalesReport.RowHeadersWidth = 51
        dgvSalesReport.Size = New Size(980, 73)
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
        pnlSummary.Location = New Point(30, 120)
        pnlSummary.Name = "pnlSummary"
        pnlSummary.Size = New Size(400, 80)
        pnlSummary.TabIndex = 6
        ' 
        ' lblOrderCount
        ' 
        lblOrderCount.AutoSize = True
        lblOrderCount.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblOrderCount.Location = New Point(320, 40)
        lblOrderCount.Name = "lblOrderCount"
        lblOrderCount.Size = New Size(23, 25)
        lblOrderCount.TabIndex = 3
        lblOrderCount.Text = "0"
        ' 
        ' lblTotalSales
        ' 
        lblTotalSales.AutoSize = True
        lblTotalSales.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTotalSales.Location = New Point(120, 40)
        lblTotalSales.Name = "lblTotalSales"
        lblTotalSales.Size = New Size(35, 25)
        lblTotalSales.TabIndex = 2
        lblTotalSales.Text = "₱0"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F)
        Label4.Location = New Point(220, 15)
        Label4.Name = "Label4"
        Label4.Size = New Size(90, 19)
        Label4.TabIndex = 1
        Label4.Text = "Order Count:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F)
        Label3.Location = New Point(20, 15)
        Label3.Name = "Label3"
        Label3.Size = New Size(75, 19)
        Label3.TabIndex = 0
        Label3.Text = "Total Sales:"
        ' 
        ' btnGenerateReport
        ' 
        btnGenerateReport.BackColor = Color.SpringGreen
        btnGenerateReport.FlatStyle = FlatStyle.Flat
        btnGenerateReport.Font = New Font("Segoe UI", 10F)
        btnGenerateReport.Location = New Point(350, 65)
        btnGenerateReport.Name = "btnGenerateReport"
        btnGenerateReport.Size = New Size(120, 30)
        btnGenerateReport.TabIndex = 5
        btnGenerateReport.Text = "Generate Report"
        btnGenerateReport.UseVisualStyleBackColor = False
        ' 
        ' dtpTo
        ' 
        dtpTo.Location = New Point(200, 70)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(120, 23)
        dtpTo.TabIndex = 4
        ' 
        ' dtpFrom
        ' 
        dtpFrom.Location = New Point(70, 70)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(120, 23)
        dtpFrom.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.Location = New Point(200, 48)
        Label2.Name = "Label2"
        Label2.Size = New Size(26, 19)
        Label2.TabIndex = 2
        Label2.Text = "To:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.Location = New Point(70, 48)
        Label1.Name = "Label1"
        Label1.Size = New Size(44, 19)
        Label1.TabIndex = 1
        Label1.Text = "From:"
        ' 
        ' lblSalesTitle
        ' 
        lblSalesTitle.AutoSize = True
        lblSalesTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblSalesTitle.Location = New Point(30, 20)
        lblSalesTitle.Name = "lblSalesTitle"
        lblSalesTitle.Size = New Size(156, 32)
        lblSalesTitle.TabIndex = 0
        lblSalesTitle.Text = "Sales Report"
        ' 
        ' pnlManageAccounts
        ' 
        pnlManageAccounts.BackColor = SystemColors.Control
        pnlManageAccounts.Controls.Add(pnlAccountCards)
        pnlManageAccounts.Controls.Add(txtSearchAccounts)
        pnlManageAccounts.Controls.Add(lblSearchAccounts)
        pnlManageAccounts.Controls.Add(btnCreateAccount)
        pnlManageAccounts.Controls.Add(lblAccountsTitle)
        pnlManageAccounts.Dock = DockStyle.Fill
        pnlManageAccounts.Location = New Point(250, 80)
        pnlManageAccounts.Name = "pnlManageAccounts"
        pnlManageAccounts.Size = New Size(1034, 581)
        pnlManageAccounts.TabIndex = 4
        pnlManageAccounts.Visible = False
        ' 
        ' pnlAccountCards
        ' 
        pnlAccountCards.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlAccountCards.AutoScroll = True
        pnlAccountCards.BackColor = Color.WhiteSmoke
        pnlAccountCards.BorderStyle = BorderStyle.FixedSingle
        pnlAccountCards.Location = New Point(30, 120)
        pnlAccountCards.Margin = New Padding(3, 2, 3, 2)
        pnlAccountCards.Name = "pnlAccountCards"
        pnlAccountCards.Size = New Size(980, 440)
        pnlAccountCards.TabIndex = 4
        ' 
        ' txtSearchAccounts
        ' 
        txtSearchAccounts.Location = New Point(354, 75)
        txtSearchAccounts.Margin = New Padding(3, 2, 3, 2)
        txtSearchAccounts.Name = "txtSearchAccounts"
        txtSearchAccounts.PlaceholderText = "Search by username or role..."
        txtSearchAccounts.Size = New Size(263, 23)
        txtSearchAccounts.TabIndex = 3
        ' 
        ' lblSearchAccounts
        ' 
        lblSearchAccounts.AutoSize = True
        lblSearchAccounts.Font = New Font("Segoe UI", 10F)
        lblSearchAccounts.Location = New Point(278, 76)
        lblSearchAccounts.Name = "lblSearchAccounts"
        lblSearchAccounts.Size = New Size(52, 19)
        lblSearchAccounts.TabIndex = 2
        lblSearchAccounts.Text = "Search:"
        ' 
        ' btnCreateAccount
        ' 
        btnCreateAccount.BackColor = Color.LightGreen
        btnCreateAccount.FlatStyle = FlatStyle.Flat
        btnCreateAccount.Font = New Font("Segoe UI", 10F)
        btnCreateAccount.Location = New Point(30, 70)
        btnCreateAccount.Name = "btnCreateAccount"
        btnCreateAccount.Size = New Size(198, 30)
        btnCreateAccount.TabIndex = 1
        btnCreateAccount.Text = "➕ Create New Account"
        btnCreateAccount.UseVisualStyleBackColor = False
        ' 
        ' lblAccountsTitle
        ' 
        lblAccountsTitle.AutoSize = True
        lblAccountsTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblAccountsTitle.Location = New Point(30, 20)
        lblAccountsTitle.Name = "lblAccountsTitle"
        lblAccountsTitle.Size = New Size(219, 32)
        lblAccountsTitle.TabIndex = 0
        lblAccountsTitle.Text = "Manage Accounts"
        ' 
        ' SettingsBtn
        ' 
        SettingsBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SettingsBtn.BackColor = Color.Gray
        SettingsBtn.FlatAppearance.BorderColor = Color.Black
        SettingsBtn.FlatStyle = FlatStyle.Flat
        SettingsBtn.Font = New Font("Segoe UI", 12F)
        SettingsBtn.ForeColor = SystemColors.ControlLightLight
        SettingsBtn.IconChar = FontAwesome.Sharp.IconChar.Cog
        SettingsBtn.IconColor = Color.Black
        SettingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SettingsBtn.IconSize = 50
        SettingsBtn.ImageAlign = ContentAlignment.MiddleLeft
        SettingsBtn.Location = New Point(20, 363)
        SettingsBtn.Name = "SettingsBtn"
        SettingsBtn.Size = New Size(210, 60)
        SettingsBtn.TabIndex = 4
        SettingsBtn.Text = "Settings"
        SettingsBtn.UseVisualStyleBackColor = False
        ' 
        ' Admin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1284, 661)
        Controls.Add(pnlManageAccounts)
        Controls.Add(pnlSalesReport)
        Controls.Add(pnlAuditLog)
        Controls.Add(pnlDashboard)
        Controls.Add(pnlHeader)
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
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnInstructions As Button
    Friend WithEvents btnCreateAccount As Button
    Friend WithEvents pnlAccountCards As Panel
    Friend WithEvents txtSearchAccounts As TextBox
    Friend WithEvents lblSearchAccounts As Label
    Friend WithEvents pnlCharts As Panel
    Friend WithEvents chartDailySales As DataVisualization.Charting.Chart
    Friend WithEvents chartTopItems As DataVisualization.Charting.Chart
    Friend WithEvents SettingsBtn As FontAwesome.Sharp.IconButton
End Class