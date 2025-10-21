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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        pnlHeaderActions = New Panel()
        btnLogout = New Button()
        btnInstructions = New Button()
        btnHelp = New Button()
        pnlHeaderContent = New Panel()
        lblTitle = New Label()
        pnlSidebar = New Panel()
        pnlSidebarContent = New Panel()
        btnManageAccounts = New Button()
        btnSalesReport = New Button()
        btnManageMenu = New Button()
        btnAuditLog = New Button()
        pnlAuditLog = New Panel()
        pnlAuditContent = New Panel()
        dgvAuditLogs = New DataGridView()
        pnlAuditFilters = New Panel()
        btnExportAuditLogs = New Button()
        btnFilterAuditLogs = New Button()
        dtpAuditTo = New DateTimePicker()
        dtpAuditFrom = New DateTimePicker()
        chkDateFilter = New CheckBox()
        txtUsernameFilter = New TextBox()
        lblUsernameFilter = New Label()
        pnlAuditHeader = New Panel()
        lblAuditTitle = New Label()
        pnlManageAccounts = New Panel()
        pnlAccountsContent = New Panel()
        pnlAccountCards = New Panel()
        pnlAccountsToolbar = New Panel()
        txtSearchAccounts = New TextBox()
        btnCreateAccount = New Button()
        pnlAccountsHeader = New Panel()
        lblAccountsTitle = New Label()
        pnlHeader.SuspendLayout()
        pnlHeaderActions.SuspendLayout()
        pnlHeaderContent.SuspendLayout()
        pnlSidebar.SuspendLayout()
        pnlSidebarContent.SuspendLayout()
        pnlAuditLog.SuspendLayout()
        pnlAuditContent.SuspendLayout()
        CType(dgvAuditLogs, ComponentModel.ISupportInitialize).BeginInit()
        pnlAuditFilters.SuspendLayout()
        pnlAuditHeader.SuspendLayout()
        pnlManageAccounts.SuspendLayout()
        pnlAccountsContent.SuspendLayout()
        pnlAccountsToolbar.SuspendLayout()
        pnlAccountsHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(pnlHeaderActions)
        pnlHeader.Controls.Add(pnlHeaderContent)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1467, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' pnlHeaderActions
        ' 
        pnlHeaderActions.Controls.Add(btnLogout)
        pnlHeaderActions.Controls.Add(btnInstructions)
        pnlHeaderActions.Controls.Add(btnHelp)
        pnlHeaderActions.Dock = DockStyle.Right
        pnlHeaderActions.Location = New Point(1067, 0)
        pnlHeaderActions.Name = "pnlHeaderActions"
        pnlHeaderActions.Padding = New Padding(10, 15, 30, 15)
        pnlHeaderActions.Size = New Size(400, 80)
        pnlHeaderActions.TabIndex = 1
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnLogout.Cursor = Cursors.Hand
        btnLogout.Dock = DockStyle.Right
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(30, 15)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(100, 50)
        btnLogout.TabIndex = 2
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnInstructions
        ' 
        btnInstructions.BackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        btnInstructions.Cursor = Cursors.Hand
        btnInstructions.Dock = DockStyle.Right
        btnInstructions.FlatAppearance.BorderSize = 0
        btnInstructions.FlatStyle = FlatStyle.Flat
        btnInstructions.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnInstructions.ForeColor = Color.White
        btnInstructions.Location = New Point(130, 15)
        btnInstructions.Name = "btnInstructions"
        btnInstructions.Size = New Size(130, 50)
        btnInstructions.TabIndex = 1
        btnInstructions.Text = "Instructions"
        btnInstructions.UseVisualStyleBackColor = False
        ' 
        ' btnHelp
        ' 
        btnHelp.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnHelp.Cursor = Cursors.Hand
        btnHelp.Dock = DockStyle.Right
        btnHelp.FlatAppearance.BorderSize = 0
        btnHelp.FlatStyle = FlatStyle.Flat
        btnHelp.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnHelp.ForeColor = Color.White
        btnHelp.Location = New Point(260, 15)
        btnHelp.Name = "btnHelp"
        btnHelp.Size = New Size(110, 50)
        btnHelp.TabIndex = 0
        btnHelp.Text = "Help"
        btnHelp.UseVisualStyleBackColor = False
        ' 
        ' pnlHeaderContent
        ' 
        pnlHeaderContent.Controls.Add(lblTitle)
        pnlHeaderContent.Dock = DockStyle.Left
        pnlHeaderContent.Location = New Point(0, 0)
        pnlHeaderContent.Name = "pnlHeaderContent"
        pnlHeaderContent.Padding = New Padding(30, 20, 0, 20)
        pnlHeaderContent.Size = New Size(400, 80)
        pnlHeaderContent.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Dock = DockStyle.Left
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lblTitle.Location = New Point(30, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(365, 54)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Admin Dashboard"
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        pnlSidebar.Controls.Add(pnlSidebarContent)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 80)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(250, 908)
        pnlSidebar.TabIndex = 1
        ' 
        ' pnlSidebarContent
        ' 
        pnlSidebarContent.Controls.Add(btnManageAccounts)
        pnlSidebarContent.Controls.Add(btnSalesReport)
        pnlSidebarContent.Controls.Add(btnManageMenu)
        pnlSidebarContent.Controls.Add(btnAuditLog)
        pnlSidebarContent.Dock = DockStyle.Fill
        pnlSidebarContent.Location = New Point(0, 0)
        pnlSidebarContent.Name = "pnlSidebarContent"
        pnlSidebarContent.Padding = New Padding(15, 30, 15, 30)
        pnlSidebarContent.Size = New Size(250, 908)
        pnlSidebarContent.TabIndex = 0
        ' 
        ' btnManageAccounts
        ' 
        btnManageAccounts.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnManageAccounts.Cursor = Cursors.Hand
        btnManageAccounts.Dock = DockStyle.Top
        btnManageAccounts.FlatAppearance.BorderSize = 0
        btnManageAccounts.FlatStyle = FlatStyle.Flat
        btnManageAccounts.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnManageAccounts.ForeColor = Color.White
        btnManageAccounts.Location = New Point(15, 240)
        btnManageAccounts.Margin = New Padding(0, 15, 0, 15)
        btnManageAccounts.Name = "btnManageAccounts"
        btnManageAccounts.Padding = New Padding(10, 0, 0, 0)
        btnManageAccounts.Size = New Size(220, 70)
        btnManageAccounts.TabIndex = 3
        btnManageAccounts.Text = "Manage Accounts"
        btnManageAccounts.TextAlign = ContentAlignment.MiddleLeft
        btnManageAccounts.UseVisualStyleBackColor = False
        ' 
        ' btnSalesReport
        ' 
        btnSalesReport.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSalesReport.Cursor = Cursors.Hand
        btnSalesReport.Dock = DockStyle.Top
        btnSalesReport.FlatAppearance.BorderSize = 0
        btnSalesReport.FlatStyle = FlatStyle.Flat
        btnSalesReport.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnSalesReport.ForeColor = Color.White
        btnSalesReport.Location = New Point(15, 170)
        btnSalesReport.Margin = New Padding(0, 15, 0, 15)
        btnSalesReport.Name = "btnSalesReport"
        btnSalesReport.Padding = New Padding(10, 0, 0, 0)
        btnSalesReport.Size = New Size(220, 70)
        btnSalesReport.TabIndex = 2
        btnSalesReport.Text = "Sales Report"
        btnSalesReport.TextAlign = ContentAlignment.MiddleLeft
        btnSalesReport.UseVisualStyleBackColor = False
        ' 
        ' btnManageMenu
        ' 
        btnManageMenu.BackColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
        btnManageMenu.Cursor = Cursors.Hand
        btnManageMenu.Dock = DockStyle.Top
        btnManageMenu.FlatAppearance.BorderSize = 0
        btnManageMenu.FlatStyle = FlatStyle.Flat
        btnManageMenu.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnManageMenu.ForeColor = Color.White
        btnManageMenu.Location = New Point(15, 100)
        btnManageMenu.Margin = New Padding(0, 15, 0, 15)
        btnManageMenu.Name = "btnManageMenu"
        btnManageMenu.Padding = New Padding(10, 0, 0, 0)
        btnManageMenu.Size = New Size(220, 70)
        btnManageMenu.TabIndex = 1
        btnManageMenu.Text = "Manage Menu Items"
        btnManageMenu.TextAlign = ContentAlignment.MiddleLeft
        btnManageMenu.UseVisualStyleBackColor = False
        ' 
        ' btnAuditLog
        ' 
        btnAuditLog.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnAuditLog.Cursor = Cursors.Hand
        btnAuditLog.Dock = DockStyle.Top
        btnAuditLog.FlatAppearance.BorderSize = 0
        btnAuditLog.FlatStyle = FlatStyle.Flat
        btnAuditLog.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnAuditLog.ForeColor = Color.White
        btnAuditLog.Location = New Point(15, 30)
        btnAuditLog.Margin = New Padding(0, 0, 0, 15)
        btnAuditLog.Name = "btnAuditLog"
        btnAuditLog.Padding = New Padding(10, 0, 0, 0)
        btnAuditLog.Size = New Size(220, 70)
        btnAuditLog.TabIndex = 0
        btnAuditLog.Text = "Audit Log"
        btnAuditLog.TextAlign = ContentAlignment.MiddleLeft
        btnAuditLog.UseVisualStyleBackColor = False
        ' 
        ' pnlAuditLog
        ' 
        pnlAuditLog.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlAuditLog.Controls.Add(pnlAuditContent)
        pnlAuditLog.Controls.Add(pnlAuditFilters)
        pnlAuditLog.Controls.Add(pnlAuditHeader)
        pnlAuditLog.Dock = DockStyle.Fill
        pnlAuditLog.Location = New Point(250, 80)
        pnlAuditLog.Name = "pnlAuditLog"
        pnlAuditLog.Size = New Size(1217, 908)
        pnlAuditLog.TabIndex = 2
        ' 
        ' pnlAuditContent
        ' 
        pnlAuditContent.Controls.Add(dgvAuditLogs)
        pnlAuditContent.Dock = DockStyle.Fill
        pnlAuditContent.Location = New Point(0, 150)
        pnlAuditContent.Name = "pnlAuditContent"
        pnlAuditContent.Padding = New Padding(30, 20, 30, 30)
        pnlAuditContent.Size = New Size(1217, 758)
        pnlAuditContent.TabIndex = 2
        ' 
        ' dgvAuditLogs
        ' 
        dgvAuditLogs.AllowUserToAddRows = False
        dgvAuditLogs.AllowUserToDeleteRows = False
        dgvAuditLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAuditLogs.BackgroundColor = Color.White
        dgvAuditLogs.BorderStyle = BorderStyle.None
        dgvAuditLogs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvAuditLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgvAuditLogs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvAuditLogs.ColumnHeadersHeight = 40
        dgvAuditLogs.Dock = DockStyle.Fill
        dgvAuditLogs.EnableHeadersVisualStyles = False
        dgvAuditLogs.GridColor = Color.FromArgb(CByte(230), CByte(230), CByte(230))
        dgvAuditLogs.Location = New Point(30, 20)
        dgvAuditLogs.Name = "dgvAuditLogs"
        dgvAuditLogs.ReadOnly = True
        dgvAuditLogs.RowHeadersVisible = False
        dgvAuditLogs.RowHeadersWidth = 51
        dgvAuditLogs.RowTemplate.Height = 35
        dgvAuditLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAuditLogs.Size = New Size(1157, 708)
        dgvAuditLogs.TabIndex = 0
        ' 
        ' pnlAuditFilters
        ' 
        pnlAuditFilters.BackColor = Color.White
        pnlAuditFilters.Controls.Add(btnExportAuditLogs)
        pnlAuditFilters.Controls.Add(btnFilterAuditLogs)
        pnlAuditFilters.Controls.Add(dtpAuditTo)
        pnlAuditFilters.Controls.Add(dtpAuditFrom)
        pnlAuditFilters.Controls.Add(chkDateFilter)
        pnlAuditFilters.Controls.Add(txtUsernameFilter)
        pnlAuditFilters.Controls.Add(lblUsernameFilter)
        pnlAuditFilters.Dock = DockStyle.Top
        pnlAuditFilters.Location = New Point(0, 70)
        pnlAuditFilters.Name = "pnlAuditFilters"
        pnlAuditFilters.Padding = New Padding(30, 15, 30, 15)
        pnlAuditFilters.Size = New Size(1217, 80)
        pnlAuditFilters.TabIndex = 1
        ' 
        ' btnExportAuditLogs
        ' 
        btnExportAuditLogs.BackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        btnExportAuditLogs.Cursor = Cursors.Hand
        btnExportAuditLogs.FlatAppearance.BorderSize = 0
        btnExportAuditLogs.FlatStyle = FlatStyle.Flat
        btnExportAuditLogs.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnExportAuditLogs.ForeColor = Color.White
        btnExportAuditLogs.Location = New Point(935, 20)
        btnExportAuditLogs.Name = "btnExportAuditLogs"
        btnExportAuditLogs.Size = New Size(130, 35)
        btnExportAuditLogs.TabIndex = 6
        btnExportAuditLogs.Text = "Export CSV"
        btnExportAuditLogs.UseVisualStyleBackColor = False
        ' 
        ' btnFilterAuditLogs
        ' 
        btnFilterAuditLogs.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnFilterAuditLogs.Cursor = Cursors.Hand
        btnFilterAuditLogs.FlatAppearance.BorderSize = 0
        btnFilterAuditLogs.FlatStyle = FlatStyle.Flat
        btnFilterAuditLogs.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnFilterAuditLogs.ForeColor = Color.White
        btnFilterAuditLogs.Location = New Point(820, 20)
        btnFilterAuditLogs.Name = "btnFilterAuditLogs"
        btnFilterAuditLogs.Size = New Size(100, 35)
        btnFilterAuditLogs.TabIndex = 5
        btnFilterAuditLogs.Text = "Filter"
        btnFilterAuditLogs.UseVisualStyleBackColor = False
        ' 
        ' dtpAuditTo
        ' 
        dtpAuditTo.Enabled = False
        dtpAuditTo.Font = New Font("Segoe UI", 9.5F)
        dtpAuditTo.Location = New Point(650, 23)
        dtpAuditTo.Name = "dtpAuditTo"
        dtpAuditTo.Size = New Size(150, 29)
        dtpAuditTo.TabIndex = 4
        ' 
        ' dtpAuditFrom
        ' 
        dtpAuditFrom.Enabled = False
        dtpAuditFrom.Font = New Font("Segoe UI", 9.5F)
        dtpAuditFrom.Location = New Point(490, 23)
        dtpAuditFrom.Name = "dtpAuditFrom"
        dtpAuditFrom.Size = New Size(150, 29)
        dtpAuditFrom.TabIndex = 3
        ' 
        ' chkDateFilter
        ' 
        chkDateFilter.AutoSize = True
        chkDateFilter.Font = New Font("Segoe UI", 10.0F)
        chkDateFilter.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        chkDateFilter.Location = New Point(360, 25)
        chkDateFilter.Name = "chkDateFilter"
        chkDateFilter.Size = New Size(121, 27)
        chkDateFilter.TabIndex = 2
        chkDateFilter.Text = "Date Range"
        chkDateFilter.UseVisualStyleBackColor = True
        ' 
        ' txtUsernameFilter
        ' 
        txtUsernameFilter.Font = New Font("Segoe UI", 10.0F)
        txtUsernameFilter.Location = New Point(130, 22)
        txtUsernameFilter.Name = "txtUsernameFilter"
        txtUsernameFilter.PlaceholderText = "Filter by username..."
        txtUsernameFilter.Size = New Size(200, 30)
        txtUsernameFilter.TabIndex = 1
        ' 
        ' lblUsernameFilter
        ' 
        lblUsernameFilter.AutoSize = True
        lblUsernameFilter.Font = New Font("Segoe UI", 10.0F)
        lblUsernameFilter.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblUsernameFilter.Location = New Point(30, 25)
        lblUsernameFilter.Name = "lblUsernameFilter"
        lblUsernameFilter.Size = New Size(91, 23)
        lblUsernameFilter.TabIndex = 0
        lblUsernameFilter.Text = "Username:"
        ' 
        ' pnlAuditHeader
        ' 
        pnlAuditHeader.BackColor = Color.White
        pnlAuditHeader.Controls.Add(lblAuditTitle)
        pnlAuditHeader.Dock = DockStyle.Top
        pnlAuditHeader.Location = New Point(0, 0)
        pnlAuditHeader.Name = "pnlAuditHeader"
        pnlAuditHeader.Padding = New Padding(30, 20, 30, 20)
        pnlAuditHeader.Size = New Size(1217, 70)
        pnlAuditHeader.TabIndex = 0
        ' 
        ' lblAuditTitle
        ' 
        lblAuditTitle.AutoSize = True
        lblAuditTitle.Dock = DockStyle.Left
        lblAuditTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblAuditTitle.ForeColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lblAuditTitle.Location = New Point(30, 20)
        lblAuditTitle.Name = "lblAuditTitle"
        lblAuditTitle.Size = New Size(157, 41)
        lblAuditTitle.TabIndex = 0
        lblAuditTitle.Text = "Audit Log"
        ' 
        ' pnlManageAccounts
        ' 
        pnlManageAccounts.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlManageAccounts.Controls.Add(pnlAccountsContent)
        pnlManageAccounts.Controls.Add(pnlAccountsToolbar)
        pnlManageAccounts.Controls.Add(pnlAccountsHeader)
        pnlManageAccounts.Dock = DockStyle.Fill
        pnlManageAccounts.Location = New Point(250, 80)
        pnlManageAccounts.Name = "pnlManageAccounts"
        pnlManageAccounts.Size = New Size(1217, 908)
        pnlManageAccounts.TabIndex = 3
        pnlManageAccounts.Visible = True
        ' 
        ' pnlAccountsContent
        ' 
        pnlAccountsContent.Controls.Add(pnlAccountCards)
        pnlAccountsContent.Dock = DockStyle.Fill
        pnlAccountsContent.Location = New Point(0, 140)
        pnlAccountsContent.Name = "pnlAccountsContent"
        pnlAccountsContent.Padding = New Padding(30, 20, 30, 30)
        pnlAccountsContent.Size = New Size(1217, 768)
        pnlAccountsContent.TabIndex = 2
        ' 
        ' pnlAccountCards
        ' 
        pnlAccountCards.AutoScroll = True
        pnlAccountCards.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlAccountCards.Dock = DockStyle.Fill
        pnlAccountCards.Location = New Point(30, 20)
        pnlAccountCards.Name = "pnlAccountCards"
        pnlAccountCards.Padding = New Padding(10)
        pnlAccountCards.Size = New Size(1157, 718)
        pnlAccountCards.TabIndex = 0
        ' 
        ' pnlAccountsToolbar
        ' 
        pnlAccountsToolbar.BackColor = Color.White
        pnlAccountsToolbar.Controls.Add(txtSearchAccounts)
        pnlAccountsToolbar.Controls.Add(btnCreateAccount)
        pnlAccountsToolbar.Dock = DockStyle.Top
        pnlAccountsToolbar.Location = New Point(0, 70)
        pnlAccountsToolbar.Name = "pnlAccountsToolbar"
        pnlAccountsToolbar.Padding = New Padding(30, 15, 30, 15)
        pnlAccountsToolbar.Size = New Size(1217, 70)
        pnlAccountsToolbar.TabIndex = 1
        ' 
        ' txtSearchAccounts
        ' 
        txtSearchAccounts.Font = New Font("Segoe UI", 10.0F)
        txtSearchAccounts.Location = New Point(230, 19)
        txtSearchAccounts.Name = "txtSearchAccounts"
        txtSearchAccounts.PlaceholderText = "Search by username or role..."
        txtSearchAccounts.Size = New Size(300, 30)
        txtSearchAccounts.TabIndex = 1
        ' 
        ' btnCreateAccount
        ' 
        btnCreateAccount.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnCreateAccount.Cursor = Cursors.Hand
        btnCreateAccount.FlatAppearance.BorderSize = 0
        btnCreateAccount.FlatStyle = FlatStyle.Flat
        btnCreateAccount.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnCreateAccount.ForeColor = Color.White
        btnCreateAccount.Location = New Point(30, 17)
        btnCreateAccount.Name = "btnCreateAccount"
        btnCreateAccount.Size = New Size(180, 38)
        btnCreateAccount.TabIndex = 0
        btnCreateAccount.Text = "➕ Create Account"
        btnCreateAccount.UseVisualStyleBackColor = False
        ' 
        ' pnlAccountsHeader
        ' 
        pnlAccountsHeader.BackColor = Color.White
        pnlAccountsHeader.Controls.Add(lblAccountsTitle)
        pnlAccountsHeader.Dock = DockStyle.Top
        pnlAccountsHeader.Location = New Point(0, 0)
        pnlAccountsHeader.Name = "pnlAccountsHeader"
        pnlAccountsHeader.Padding = New Padding(30, 20, 30, 20)
        pnlAccountsHeader.Size = New Size(1217, 70)
        pnlAccountsHeader.TabIndex = 0
        ' 
        ' lblAccountsTitle
        ' 
        lblAccountsTitle.AutoSize = True
        lblAccountsTitle.Dock = DockStyle.Left
        lblAccountsTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblAccountsTitle.ForeColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lblAccountsTitle.Location = New Point(30, 20)
        lblAccountsTitle.Name = "lblAccountsTitle"
        lblAccountsTitle.Size = New Size(268, 41)
        lblAccountsTitle.TabIndex = 0
        lblAccountsTitle.Text = "Manage Accounts"
        ' 
        ' Admin
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(1467, 988)
        Controls.Add(pnlManageAccounts)
        Controls.Add(pnlAuditLog)
        Controls.Add(pnlSidebar)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 9.0F)
        Name = "Admin"
        Text = "Admin Dashboard - OrderUp!"
        pnlHeader.ResumeLayout(False)
        pnlHeaderActions.ResumeLayout(False)
        pnlHeaderContent.ResumeLayout(False)
        pnlHeaderContent.PerformLayout()
        pnlSidebar.ResumeLayout(False)
        pnlSidebarContent.ResumeLayout(False)
        pnlAuditLog.ResumeLayout(False)
        pnlAuditContent.ResumeLayout(False)
        CType(dgvAuditLogs, ComponentModel.ISupportInitialize).EndInit()
        pnlAuditFilters.ResumeLayout(False)
        pnlAuditFilters.PerformLayout()
        pnlAuditHeader.ResumeLayout(False)
        pnlAuditHeader.PerformLayout()
        pnlManageAccounts.ResumeLayout(False)
        pnlAccountsContent.ResumeLayout(False)
        pnlAccountsToolbar.ResumeLayout(False)
        pnlAccountsToolbar.PerformLayout()
        pnlAccountsHeader.ResumeLayout(False)
        pnlAccountsHeader.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlHeaderContent As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlHeaderActions As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnInstructions As Button
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents pnlSidebarContent As Panel
    Friend WithEvents btnManageMenu As Button
    Friend WithEvents btnAuditLog As Button
    Friend WithEvents btnSalesReport As Button
    Friend WithEvents btnManageAccounts As Button
    Friend WithEvents pnlAuditLog As Panel
    Friend WithEvents pnlAuditHeader As Panel
    Friend WithEvents lblAuditTitle As Label
    Friend WithEvents pnlAuditFilters As Panel
    Friend WithEvents lblUsernameFilter As Label
    Friend WithEvents txtUsernameFilter As TextBox
    Friend WithEvents chkDateFilter As CheckBox
    Friend WithEvents dtpAuditFrom As DateTimePicker
    Friend WithEvents dtpAuditTo As DateTimePicker
    Friend WithEvents btnFilterAuditLogs As Button
    Friend WithEvents btnExportAuditLogs As Button
    Friend WithEvents pnlAuditContent As Panel
    Friend WithEvents dgvAuditLogs As DataGridView
    Friend WithEvents pnlManageAccounts As Panel
    Friend WithEvents pnlAccountsHeader As Panel
    Friend WithEvents lblAccountsTitle As Label
    Friend WithEvents pnlAccountsToolbar As Panel
    Friend WithEvents btnCreateAccount As Button
    Friend WithEvents txtSearchAccounts As TextBox
    Friend WithEvents pnlAccountsContent As Panel
    Friend WithEvents pnlAccountCards As Panel
End Class