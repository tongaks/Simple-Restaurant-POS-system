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
        btnLogout = New FontAwesome.Sharp.IconButton()
        btnInstructions = New FontAwesome.Sharp.IconButton()
        btnHelp = New FontAwesome.Sharp.IconButton()
        pnlHeaderContent = New Panel()
        lblSubtitle = New Label()
        lblTitle = New Label()
        pnlSidebar = New Panel()
        pnlSidebarContent = New Panel()
        btnManageAccounts = New FontAwesome.Sharp.IconButton()
        btnSalesReport = New FontAwesome.Sharp.IconButton()
        btnManageMenu = New FontAwesome.Sharp.IconButton()
        btnAuditLog = New FontAwesome.Sharp.IconButton()
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
        btnCreateAccount = New FontAwesome.Sharp.IconButton()
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
        pnlHeader.BackColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        pnlHeader.Controls.Add(pnlHeaderActions)
        pnlHeader.Controls.Add(pnlHeaderContent)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1467, 90)
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
        pnlHeaderActions.Padding = New Padding(10, 20, 30, 20)
        pnlHeaderActions.Size = New Size(400, 90)
        pnlHeaderActions.TabIndex = 1
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(220), CByte(38), CByte(38))
        btnLogout.Cursor = Cursors.Hand
        btnLogout.Dock = DockStyle.Right
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt
        btnLogout.IconColor = Color.White
        btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnLogout.IconSize = 20
        btnLogout.Location = New Point(30, 20)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(100, 50)
        btnLogout.TabIndex = 2
        btnLogout.Text = "Logout"
        btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnInstructions
        ' 
        btnInstructions.BackColor = Color.FromArgb(CByte(251), CByte(191), CByte(36))
        btnInstructions.Cursor = Cursors.Hand
        btnInstructions.Dock = DockStyle.Right
        btnInstructions.FlatAppearance.BorderSize = 0
        btnInstructions.FlatStyle = FlatStyle.Flat
        btnInstructions.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        btnInstructions.ForeColor = Color.White
        btnInstructions.IconChar = FontAwesome.Sharp.IconChar.Book
        btnInstructions.IconColor = Color.White
        btnInstructions.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnInstructions.IconSize = 18
        btnInstructions.Location = New Point(130, 20)
        btnInstructions.Name = "btnInstructions"
        btnInstructions.Size = New Size(130, 50)
        btnInstructions.TabIndex = 1
        btnInstructions.Text = "Instructions"
        btnInstructions.TextImageRelation = TextImageRelation.ImageBeforeText
        btnInstructions.UseVisualStyleBackColor = False
        ' 
        ' btnHelp
        ' 
        btnHelp.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        btnHelp.Cursor = Cursors.Hand
        btnHelp.Dock = DockStyle.Right
        btnHelp.FlatAppearance.BorderSize = 0
        btnHelp.FlatStyle = FlatStyle.Flat
        btnHelp.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnHelp.ForeColor = Color.White
        btnHelp.IconChar = FontAwesome.Sharp.IconChar.CircleQuestion
        btnHelp.IconColor = Color.White
        btnHelp.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnHelp.IconSize = 20
        btnHelp.Location = New Point(260, 20)
        btnHelp.Name = "btnHelp"
        btnHelp.Size = New Size(110, 50)
        btnHelp.TabIndex = 0
        btnHelp.Text = "Help"
        btnHelp.TextImageRelation = TextImageRelation.ImageBeforeText
        btnHelp.UseVisualStyleBackColor = False
        ' 
        ' pnlHeaderContent
        ' 
        pnlHeaderContent.Controls.Add(lblSubtitle)
        pnlHeaderContent.Controls.Add(lblTitle)
        pnlHeaderContent.Dock = DockStyle.Left
        pnlHeaderContent.Location = New Point(0, 0)
        pnlHeaderContent.Name = "pnlHeaderContent"
        pnlHeaderContent.Padding = New Padding(30, 15, 0, 15)
        pnlHeaderContent.Size = New Size(500, 90)
        pnlHeaderContent.TabIndex = 0
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Dock = DockStyle.Top
        lblSubtitle.Font = New Font("Segoe UI", 10.0F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblSubtitle.Location = New Point(30, 61)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Padding = New Padding(0, 2, 0, 0)
        lblSubtitle.Size = New Size(230, 25)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "System Administration Portal"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(30, 15)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(309, 46)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Admin Dashboard"
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(42))
        pnlSidebar.Controls.Add(pnlSidebarContent)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 90)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(260, 908)
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
        pnlSidebarContent.Padding = New Padding(15, 25, 15, 25)
        pnlSidebarContent.Size = New Size(260, 908)
        pnlSidebarContent.TabIndex = 0
        ' 
        ' btnManageAccounts
        ' 
        btnManageAccounts.BackColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        btnManageAccounts.Cursor = Cursors.Hand
        btnManageAccounts.Dock = DockStyle.Top
        btnManageAccounts.FlatAppearance.BorderSize = 0
        btnManageAccounts.FlatStyle = FlatStyle.Flat
        btnManageAccounts.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnManageAccounts.ForeColor = Color.White
        btnManageAccounts.IconChar = FontAwesome.Sharp.IconChar.Users
        btnManageAccounts.IconColor = Color.White
        btnManageAccounts.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnManageAccounts.IconSize = 24
        btnManageAccounts.ImageAlign = ContentAlignment.MiddleLeft
        btnManageAccounts.Location = New Point(15, 235)
        btnManageAccounts.Margin = New Padding(0, 10, 0, 10)
        btnManageAccounts.Name = "btnManageAccounts"
        btnManageAccounts.Padding = New Padding(15, 0, 0, 0)
        btnManageAccounts.Size = New Size(230, 70)
        btnManageAccounts.TabIndex = 3
        btnManageAccounts.Text = "   Manage Accounts"
        btnManageAccounts.TextAlign = ContentAlignment.MiddleLeft
        btnManageAccounts.TextImageRelation = TextImageRelation.ImageBeforeText
        btnManageAccounts.UseVisualStyleBackColor = False
        ' 
        ' btnSalesReport
        ' 
        btnSalesReport.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        btnSalesReport.Cursor = Cursors.Hand
        btnSalesReport.Dock = DockStyle.Top
        btnSalesReport.FlatAppearance.BorderSize = 0
        btnSalesReport.FlatStyle = FlatStyle.Flat
        btnSalesReport.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnSalesReport.ForeColor = Color.White
        btnSalesReport.IconChar = FontAwesome.Sharp.IconChar.ChartLine
        btnSalesReport.IconColor = Color.White
        btnSalesReport.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSalesReport.IconSize = 24
        btnSalesReport.ImageAlign = ContentAlignment.MiddleLeft
        btnSalesReport.Location = New Point(15, 165)
        btnSalesReport.Margin = New Padding(0, 10, 0, 10)
        btnSalesReport.Name = "btnSalesReport"
        btnSalesReport.Padding = New Padding(15, 0, 0, 0)
        btnSalesReport.Size = New Size(230, 70)
        btnSalesReport.TabIndex = 2
        btnSalesReport.Text = "   Sales Report"
        btnSalesReport.TextAlign = ContentAlignment.MiddleLeft
        btnSalesReport.TextImageRelation = TextImageRelation.ImageBeforeText
        btnSalesReport.UseVisualStyleBackColor = False
        ' 
        ' btnManageMenu
        ' 
        btnManageMenu.BackColor = Color.FromArgb(CByte(251), CByte(191), CByte(36))
        btnManageMenu.Cursor = Cursors.Hand
        btnManageMenu.Dock = DockStyle.Top
        btnManageMenu.FlatAppearance.BorderSize = 0
        btnManageMenu.FlatStyle = FlatStyle.Flat
        btnManageMenu.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnManageMenu.ForeColor = Color.White
        btnManageMenu.IconChar = FontAwesome.Sharp.IconChar.Utensils
        btnManageMenu.IconColor = Color.White
        btnManageMenu.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnManageMenu.IconSize = 24
        btnManageMenu.ImageAlign = ContentAlignment.MiddleLeft
        btnManageMenu.Location = New Point(15, 95)
        btnManageMenu.Margin = New Padding(0, 10, 0, 10)
        btnManageMenu.Name = "btnManageMenu"
        btnManageMenu.Padding = New Padding(15, 0, 0, 0)
        btnManageMenu.Size = New Size(230, 70)
        btnManageMenu.TabIndex = 1
        btnManageMenu.Text = "   Manage Menu"
        btnManageMenu.TextAlign = ContentAlignment.MiddleLeft
        btnManageMenu.TextImageRelation = TextImageRelation.ImageBeforeText
        btnManageMenu.UseVisualStyleBackColor = False
        ' 
        ' btnAuditLog
        ' 
        btnAuditLog.BackColor = Color.FromArgb(CByte(139), CByte(92), CByte(246))
        btnAuditLog.Cursor = Cursors.Hand
        btnAuditLog.Dock = DockStyle.Top
        btnAuditLog.FlatAppearance.BorderSize = 0
        btnAuditLog.FlatStyle = FlatStyle.Flat
        btnAuditLog.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnAuditLog.ForeColor = Color.White
        btnAuditLog.IconChar = FontAwesome.Sharp.IconChar.ClipboardList
        btnAuditLog.IconColor = Color.White
        btnAuditLog.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnAuditLog.IconSize = 24
        btnAuditLog.ImageAlign = ContentAlignment.MiddleLeft
        btnAuditLog.Location = New Point(15, 25)
        btnAuditLog.Margin = New Padding(0, 0, 0, 10)
        btnAuditLog.Name = "btnAuditLog"
        btnAuditLog.Padding = New Padding(15, 0, 0, 0)
        btnAuditLog.Size = New Size(230, 70)
        btnAuditLog.TabIndex = 0
        btnAuditLog.Text = "   Audit Log"
        btnAuditLog.TextAlign = ContentAlignment.MiddleLeft
        btnAuditLog.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAuditLog.UseVisualStyleBackColor = False
        ' 
        ' pnlAuditLog
        ' 
        pnlAuditLog.BackColor = Color.FromArgb(CByte(247), CByte(250), CByte(252))
        pnlAuditLog.Controls.Add(pnlAuditContent)
        pnlAuditLog.Controls.Add(pnlAuditFilters)
        pnlAuditLog.Controls.Add(pnlAuditHeader)
        pnlAuditLog.Dock = DockStyle.Fill
        pnlAuditLog.Location = New Point(260, 90)
        pnlAuditLog.Name = "pnlAuditLog"
        pnlAuditLog.Size = New Size(1207, 908)
        pnlAuditLog.TabIndex = 2
        ' 
        ' pnlAuditContent
        ' 
        pnlAuditContent.Controls.Add(dgvAuditLogs)
        pnlAuditContent.Dock = DockStyle.Fill
        pnlAuditContent.Location = New Point(0, 160)
        pnlAuditContent.Name = "pnlAuditContent"
        pnlAuditContent.Padding = New Padding(25, 20, 25, 25)
        pnlAuditContent.Size = New Size(1207, 748)
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
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.White
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvAuditLogs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvAuditLogs.ColumnHeadersHeight = 45
        dgvAuditLogs.Dock = DockStyle.Fill
        dgvAuditLogs.EnableHeadersVisualStyles = False
        dgvAuditLogs.GridColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        dgvAuditLogs.Location = New Point(25, 20)
        dgvAuditLogs.Name = "dgvAuditLogs"
        dgvAuditLogs.ReadOnly = True
        dgvAuditLogs.RowHeadersVisible = False
        dgvAuditLogs.RowHeadersWidth = 51
        dgvAuditLogs.RowTemplate.Height = 40
        dgvAuditLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAuditLogs.Size = New Size(1157, 703)
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
        pnlAuditFilters.Location = New Point(0, 80)
        pnlAuditFilters.Name = "pnlAuditFilters"
        pnlAuditFilters.Padding = New Padding(30, 15, 30, 15)
        pnlAuditFilters.Size = New Size(1207, 80)
        pnlAuditFilters.TabIndex = 1
        ' 
        ' btnExportAuditLogs
        ' 
        btnExportAuditLogs.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportAuditLogs.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        btnExportAuditLogs.Cursor = Cursors.Hand
        btnExportAuditLogs.FlatAppearance.BorderSize = 0
        btnExportAuditLogs.FlatStyle = FlatStyle.Flat
        btnExportAuditLogs.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnExportAuditLogs.ForeColor = Color.White
        btnExportAuditLogs.Location = New Point(1027, 20)
        btnExportAuditLogs.Name = "btnExportAuditLogs"
        btnExportAuditLogs.Size = New Size(150, 40)
        btnExportAuditLogs.TabIndex = 6
        btnExportAuditLogs.Text = "📊 Export CSV"
        btnExportAuditLogs.UseVisualStyleBackColor = False
        ' 
        ' btnFilterAuditLogs
        ' 
        btnFilterAuditLogs.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnFilterAuditLogs.BackColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        btnFilterAuditLogs.Cursor = Cursors.Hand
        btnFilterAuditLogs.FlatAppearance.BorderSize = 0
        btnFilterAuditLogs.FlatStyle = FlatStyle.Flat
        btnFilterAuditLogs.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnFilterAuditLogs.ForeColor = Color.White
        btnFilterAuditLogs.Location = New Point(902, 20)
        btnFilterAuditLogs.Name = "btnFilterAuditLogs"
        btnFilterAuditLogs.Size = New Size(110, 40)
        btnFilterAuditLogs.TabIndex = 5
        btnFilterAuditLogs.Text = "🔍 Filter"
        btnFilterAuditLogs.UseVisualStyleBackColor = False
        ' 
        ' dtpAuditTo
        ' 
        dtpAuditTo.Enabled = False
        dtpAuditTo.Font = New Font("Segoe UI", 9.5F)
        dtpAuditTo.Location = New Point(650, 25)
        dtpAuditTo.Name = "dtpAuditTo"
        dtpAuditTo.Size = New Size(150, 29)
        dtpAuditTo.TabIndex = 4
        ' 
        ' dtpAuditFrom
        ' 
        dtpAuditFrom.Enabled = False
        dtpAuditFrom.Font = New Font("Segoe UI", 9.5F)
        dtpAuditFrom.Location = New Point(490, 25)
        dtpAuditFrom.Name = "dtpAuditFrom"
        dtpAuditFrom.Size = New Size(150, 29)
        dtpAuditFrom.TabIndex = 3
        ' 
        ' chkDateFilter
        ' 
        chkDateFilter.AutoSize = True
        chkDateFilter.Font = New Font("Segoe UI", 10.0F)
        chkDateFilter.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        chkDateFilter.Location = New Point(360, 27)
        chkDateFilter.Name = "chkDateFilter"
        chkDateFilter.Size = New Size(121, 27)
        chkDateFilter.TabIndex = 2
        chkDateFilter.Text = "Date Range"
        chkDateFilter.UseVisualStyleBackColor = True
        ' 
        ' txtUsernameFilter
        ' 
        txtUsernameFilter.Font = New Font("Segoe UI", 10.0F)
        txtUsernameFilter.Location = New Point(130, 24)
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
        lblUsernameFilter.Location = New Point(30, 27)
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
        pnlAuditHeader.Size = New Size(1207, 80)
        pnlAuditHeader.TabIndex = 0
        ' 
        ' lblAuditTitle
        ' 
        lblAuditTitle.AutoSize = True
        lblAuditTitle.Dock = DockStyle.Left
        lblAuditTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblAuditTitle.ForeColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        lblAuditTitle.Location = New Point(30, 20)
        lblAuditTitle.Name = "lblAuditTitle"
        lblAuditTitle.Size = New Size(201, 41)
        lblAuditTitle.TabIndex = 0
        lblAuditTitle.Text = "📋 Audit Log"
        ' 
        ' pnlManageAccounts
        ' 
        pnlManageAccounts.BackColor = Color.FromArgb(CByte(247), CByte(250), CByte(252))
        pnlManageAccounts.Controls.Add(pnlAccountsContent)
        pnlManageAccounts.Controls.Add(pnlAccountsToolbar)
        pnlManageAccounts.Controls.Add(pnlAccountsHeader)
        pnlManageAccounts.Dock = DockStyle.Fill
        pnlManageAccounts.Location = New Point(260, 90)
        pnlManageAccounts.Name = "pnlManageAccounts"
        pnlManageAccounts.Size = New Size(1207, 908)
        pnlManageAccounts.TabIndex = 3
        pnlManageAccounts.Visible = False
        ' 
        ' pnlAccountsContent
        ' 
        pnlAccountsContent.Controls.Add(pnlAccountCards)
        pnlAccountsContent.Dock = DockStyle.Fill
        pnlAccountsContent.Location = New Point(0, 150)
        pnlAccountsContent.Name = "pnlAccountsContent"
        pnlAccountsContent.Padding = New Padding(25, 20, 25, 25)
        pnlAccountsContent.Size = New Size(1207, 758)
        pnlAccountsContent.TabIndex = 2
        ' 
        ' pnlAccountCards
        ' 
        pnlAccountCards.AutoScroll = True
        pnlAccountCards.BackColor = Color.FromArgb(CByte(247), CByte(250), CByte(252))
        pnlAccountCards.Dock = DockStyle.Fill
        pnlAccountCards.Location = New Point(25, 20)
        pnlAccountCards.Name = "pnlAccountCards"
        pnlAccountCards.Padding = New Padding(10)
        pnlAccountCards.Size = New Size(1157, 713)
        pnlAccountCards.TabIndex = 0
        ' 
        ' pnlAccountsToolbar
        ' 
        pnlAccountsToolbar.BackColor = Color.White
        pnlAccountsToolbar.Controls.Add(txtSearchAccounts)
        pnlAccountsToolbar.Controls.Add(btnCreateAccount)
        pnlAccountsToolbar.Dock = DockStyle.Top
        pnlAccountsToolbar.Location = New Point(0, 80)
        pnlAccountsToolbar.Name = "pnlAccountsToolbar"
        pnlAccountsToolbar.Padding = New Padding(30, 15, 30, 15)
        pnlAccountsToolbar.Size = New Size(1207, 70)
        pnlAccountsToolbar.TabIndex = 1
        ' 
        ' txtSearchAccounts
        ' 
        txtSearchAccounts.Font = New Font("Segoe UI", 10.0F)
        txtSearchAccounts.Location = New Point(250, 20)
        txtSearchAccounts.Name = "txtSearchAccounts"
        txtSearchAccounts.PlaceholderText = "🔍 Search by username or role..."
        txtSearchAccounts.Size = New Size(350, 30)
        txtSearchAccounts.TabIndex = 1
        ' 
        ' btnCreateAccount
        ' 
        btnCreateAccount.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        btnCreateAccount.Cursor = Cursors.Hand
        btnCreateAccount.FlatAppearance.BorderSize = 0
        btnCreateAccount.FlatStyle = FlatStyle.Flat
        btnCreateAccount.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnCreateAccount.ForeColor = Color.White
        btnCreateAccount.IconChar = FontAwesome.Sharp.IconChar.UserPlus
        btnCreateAccount.IconColor = Color.White
        btnCreateAccount.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnCreateAccount.IconSize = 20
        btnCreateAccount.Location = New Point(30, 17)
        btnCreateAccount.Name = "btnCreateAccount"
        btnCreateAccount.Size = New Size(200, 38)
        btnCreateAccount.TabIndex = 0
        btnCreateAccount.Text = "  Create Account"
        btnCreateAccount.TextImageRelation = TextImageRelation.ImageBeforeText
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
        pnlAccountsHeader.Size = New Size(1207, 80)
        pnlAccountsHeader.TabIndex = 0
        ' 
        ' lblAccountsTitle
        ' 
        lblAccountsTitle.AutoSize = True
        lblAccountsTitle.Dock = DockStyle.Left
        lblAccountsTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblAccountsTitle.ForeColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        lblAccountsTitle.Location = New Point(30, 20)
        lblAccountsTitle.Name = "lblAccountsTitle"
        lblAccountsTitle.Size = New Size(318, 41)
        lblAccountsTitle.TabIndex = 0
        lblAccountsTitle.Text = "👥 Manage Accounts"
        ' 
        ' Admin
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(247), CByte(250), CByte(252))
        ClientSize = New Size(1467, 998)
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
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlHeaderActions As Panel
    Friend WithEvents btnLogout As FontAwesome.Sharp.IconButton
    Friend WithEvents btnHelp As FontAwesome.Sharp.IconButton
    Friend WithEvents btnInstructions As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents pnlSidebarContent As Panel
    Friend WithEvents btnManageMenu As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAuditLog As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSalesReport As FontAwesome.Sharp.IconButton
    Friend WithEvents btnManageAccounts As FontAwesome.Sharp.IconButton
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
    Friend WithEvents btnCreateAccount As FontAwesome.Sharp.IconButton
    Friend WithEvents txtSearchAccounts As TextBox
    Friend WithEvents pnlAccountsContent As Panel
    Friend WithEvents pnlAccountCards As Panel
End Class