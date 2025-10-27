<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    ' === Navigation & Layout ===
    Friend WithEvents pnlSidebar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlContent As Guna.UI2.WinForms.Guna2Panel

    ' === Header Controls ===
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents btnLogout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblWelcome As System.Windows.Forms.Label

    ' === Sidebar Logo/Branding ===
    Friend WithEvents pnlLogo As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblAppName As System.Windows.Forms.Label
    Friend WithEvents lblAppSubtitle As System.Windows.Forms.Label

    ' === Menu Button Controls (AdminMenuButtonControl instances) ===
    Friend WithEvents menuBtnManageAccounts As AdminMenuButtonControl
    Friend WithEvents menuBtnViewSales As AdminMenuButtonControl
    Friend WithEvents menuBtnViewInventory As AdminMenuButtonControl
    Friend WithEvents menuBtnActivityLogs As AdminMenuButtonControl

    ' === Search & Filter (for account management) ===
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents flowAccountCards As System.Windows.Forms.FlowLayoutPanel

    ' === Action Buttons ===
    Friend WithEvents btnAddAccount As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button

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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()

        ' === Initialize Controls ===
        pnlSidebar = New Guna.UI2.WinForms.Guna2Panel()
        pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        pnlContent = New Guna.UI2.WinForms.Guna2Panel()
        pnlLogo = New Guna.UI2.WinForms.Guna2Panel()

        lblHeaderTitle = New Label()
        btnLogout = New Guna.UI2.WinForms.Guna2Button()
        lblWelcome = New Label()
        lblAppName = New Label()
        lblAppSubtitle = New Label()

        menuBtnManageAccounts = New AdminMenuButtonControl()
        menuBtnViewSales = New AdminMenuButtonControl()
        menuBtnViewInventory = New AdminMenuButtonControl()
        menuBtnActivityLogs = New AdminMenuButtonControl()

        txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        flowAccountCards = New FlowLayoutPanel()
        btnAddAccount = New Guna.UI2.WinForms.Guna2Button()
        btnRefresh = New Guna.UI2.WinForms.Guna2Button()

        pnlSidebar.SuspendLayout()
        pnlMain.SuspendLayout()
        pnlHeader.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlLogo.SuspendLayout()
        SuspendLayout()

        ' ===================================
        ' FORM CONFIGURATION
        ' ===================================
        Me.AutoScaleDimensions = New SizeF(8.0F, 16.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Theme.NeutralBackground
        Me.ClientSize = New Size(1600, 900)
        Me.Font = Theme.DefaultFont
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Name = "Admin"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Admin Dashboard - Restaurant POS"
        Me.WindowState = FormWindowState.Maximized

        ' ===================================
        ' SIDEBAR PANEL (Left Navigation)
        ' ===================================
        pnlSidebar.BackColor = Theme.WhiteSurface
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.FillColor = Theme.WhiteSurface
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Padding = New Padding(20, 20, 10, 20)
        pnlSidebar.ShadowDecoration.Color = Color.FromArgb(220, 220, 220)
        pnlSidebar.ShadowDecoration.Depth = 15
        pnlSidebar.ShadowDecoration.Enabled = True
        pnlSidebar.Size = New Size(300, 900)
        pnlSidebar.TabIndex = 0

        ' === Logo Panel ===
        pnlLogo.BackColor = Theme.PrimaryAccent
        pnlLogo.FillColor = Theme.PrimaryAccent
        pnlLogo.Dock = DockStyle.Top
        pnlLogo.Location = New Point(20, 20)
        pnlLogo.Name = "pnlLogo"
        pnlLogo.Padding = New Padding(15, 20, 15, 20)
        pnlLogo.Size = New Size(270, 100)
        pnlLogo.TabIndex = 0

        lblAppName.AutoSize = False
        lblAppName.Dock = DockStyle.Top
        lblAppName.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblAppName.ForeColor = Theme.DarkText
        lblAppName.Location = New Point(15, 20)
        lblAppName.Name = "lblAppName"
        lblAppName.Size = New Size(240, 40)
        lblAppName.TabIndex = 0
        lblAppName.Text = "🍽️ OrderUp!"
        lblAppName.TextAlign = ContentAlignment.MiddleCenter

        lblAppSubtitle.AutoSize = False
        lblAppSubtitle.Dock = DockStyle.Bottom
        lblAppSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
        lblAppSubtitle.ForeColor = Theme.DarkText
        lblAppSubtitle.Location = New Point(15, 60)
        lblAppSubtitle.Name = "lblAppSubtitle"
        lblAppSubtitle.Size = New Size(240, 20)
        lblAppSubtitle.TabIndex = 1
        lblAppSubtitle.Text = "Admin Dashboard"
        lblAppSubtitle.TextAlign = ContentAlignment.MiddleCenter

        pnlLogo.Controls.Add(lblAppName)
        pnlLogo.Controls.Add(lblAppSubtitle)

        ' === Menu Button 1: Manage Accounts ===
        menuBtnManageAccounts.Location = New Point(20, 140)
        menuBtnManageAccounts.Name = "menuBtnManageAccounts"
        menuBtnManageAccounts.Size = New Size(260, 120)
        menuBtnManageAccounts.TabIndex = 1
        menuBtnManageAccounts.Title = "Manage Accounts"
        menuBtnManageAccounts.Subtitle = "Add, edit, or remove users"
        menuBtnManageAccounts.IconText = "👥"
        menuBtnManageAccounts.BadgeColor = Theme.SecondaryAccent

        ' === Menu Button 2: View Sales ===
        menuBtnViewSales.Location = New Point(20, 275)
        menuBtnViewSales.Name = "menuBtnViewSales"
        menuBtnViewSales.Size = New Size(260, 120)
        menuBtnViewSales.TabIndex = 2
        menuBtnViewSales.Title = "Sales Reports"
        menuBtnViewSales.Subtitle = "View detailed analytics"
        menuBtnViewSales.IconText = "📊"
        menuBtnViewSales.BadgeColor = Theme.PrimaryAccent

        ' === Menu Button 3: View Inventory ===
        menuBtnViewInventory.Location = New Point(20, 410)
        menuBtnViewInventory.Name = "menuBtnViewInventory"
        menuBtnViewInventory.Size = New Size(260, 120)
        menuBtnViewInventory.TabIndex = 3
        menuBtnViewInventory.Title = "Inventory"
        menuBtnViewInventory.Subtitle = "Manage stock levels"
        menuBtnViewInventory.IconText = "📦"
        menuBtnViewInventory.BadgeColor = Color.FromArgb(100, 149, 237)

        ' === Menu Button 4: Activity Logs ===
        menuBtnActivityLogs.Location = New Point(20, 545)
        menuBtnActivityLogs.Name = "menuBtnActivityLogs"
        menuBtnActivityLogs.Size = New Size(260, 120)
        menuBtnActivityLogs.TabIndex = 4
        menuBtnActivityLogs.Title = "Activity Logs"
        menuBtnActivityLogs.Subtitle = "Track system events"
        menuBtnActivityLogs.IconText = "📋"
        menuBtnActivityLogs.BadgeColor = Color.FromArgb(147, 112, 219)

        pnlSidebar.Controls.Add(menuBtnActivityLogs)
        pnlSidebar.Controls.Add(menuBtnViewInventory)
        pnlSidebar.Controls.Add(menuBtnViewSales)
        pnlSidebar.Controls.Add(menuBtnManageAccounts)
        pnlSidebar.Controls.Add(pnlLogo)

        ' ===================================
        ' MAIN PANEL (Right Side Content)
        ' ===================================
        pnlMain.BackColor = Theme.NeutralBackground
        pnlMain.Dock = DockStyle.Fill
        pnlMain.FillColor = Theme.NeutralBackground
        pnlMain.Location = New Point(300, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(1300, 900)
        pnlMain.TabIndex = 1

        ' === HEADER PANEL ===
        pnlHeader.BackColor = Theme.WhiteSurface
        pnlHeader.FillColor = Theme.WhiteSurface
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(30, 20, 30, 20)
        pnlHeader.ShadowDecoration.Color = Color.FromArgb(230, 230, 230)
        pnlHeader.ShadowDecoration.Depth = 5
        pnlHeader.ShadowDecoration.Enabled = True
        pnlHeader.Size = New Size(1300, 80)
        pnlHeader.TabIndex = 0

        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Dock = DockStyle.Left
        lblHeaderTitle.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Theme.DarkText
        lblHeaderTitle.Location = New Point(30, 20)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(250, 40)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = "Account Management"
        lblHeaderTitle.TextAlign = ContentAlignment.MiddleLeft

        lblWelcome.AutoSize = True
        lblWelcome.Dock = DockStyle.Right
        lblWelcome.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular)
        lblWelcome.ForeColor = Theme.GrayText
        lblWelcome.Location = New Point(1000, 20)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(170, 40)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Welcome, Admin"
        lblWelcome.TextAlign = ContentAlignment.MiddleRight

        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BorderRadius = 8
        btnLogout.FillColor = Color.FromArgb(231, 76, 60)
        btnLogout.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(1180, 20)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(90, 40)
        btnLogout.TabIndex = 2
        btnLogout.Text = "⏻ Logout"
        btnLogout.Cursor = Cursors.Hand

        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Controls.Add(lblWelcome)
        pnlHeader.Controls.Add(lblHeaderTitle)

        ' === CONTENT PANEL ===
        pnlContent.BackColor = Theme.NeutralBackground
        pnlContent.Dock = DockStyle.Fill
        pnlContent.FillColor = Theme.NeutralBackground
        pnlContent.Location = New Point(0, 80)
        pnlContent.Name = "pnlContent"
        pnlContent.Padding = New Padding(30, 20, 30, 30)
        pnlContent.Size = New Size(1300, 820)
        pnlContent.TabIndex = 1

        ' === SEARCH BOX ===
        txtSearch.BorderRadius = 10
        txtSearch.BorderColor = Theme.LightBorder
        txtSearch.BorderThickness = 1
        txtSearch.Dock = DockStyle.Top
        txtSearch.Font = Theme.DefaultFont
        txtSearch.ForeColor = Theme.DarkText
        txtSearch.Location = New Point(30, 20)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "🔍 Search accounts by username or role..."
        txtSearch.PlaceholderForeColor = Theme.GrayText
        txtSearch.Size = New Size(900, 40)
        txtSearch.TabIndex = 0

        ' === ACTION BUTTONS PANEL ===
        Dim pnlActions As New Panel()
        pnlActions.Dock = DockStyle.Top
        pnlActions.Height = 60
        pnlActions.Padding = New Padding(0, 10, 0, 10)

        btnAddAccount.BorderRadius = 10
        btnAddAccount.FillColor = Theme.PrimaryAccent
        btnAddAccount.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnAddAccount.ForeColor = Theme.DarkText
        btnAddAccount.Location = New Point(30, 10)
        btnAddAccount.Name = "btnAddAccount"
        btnAddAccount.Size = New Size(150, 40)
        btnAddAccount.TabIndex = 0
        btnAddAccount.Text = "➕ Add Account"
        btnAddAccount.Cursor = Cursors.Hand
        Theme.ApplyPrimaryButton(btnAddAccount)

        btnRefresh.BorderRadius = 10
        btnRefresh.FillColor = Theme.SecondaryAccent
        btnRefresh.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(200, 10)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(120, 40)
        btnRefresh.TabIndex = 1
        btnRefresh.Text = "🔄 Refresh"
        btnRefresh.Cursor = Cursors.Hand
        Theme.ApplySecondaryButton(btnRefresh)

        pnlActions.Controls.Add(btnRefresh)
        pnlActions.Controls.Add(btnAddAccount)

        ' === FLOW LAYOUT FOR ACCOUNT CARDS ===
        flowAccountCards.AutoScroll = True
        flowAccountCards.BackColor = Color.Transparent
        flowAccountCards.Dock = DockStyle.Fill
        flowAccountCards.FlowDirection = FlowDirection.TopDown
        flowAccountCards.Location = New Point(30, 120)
        flowAccountCards.Name = "flowAccountCards"
        flowAccountCards.Padding = New Padding(0, 10, 0, 10)
        flowAccountCards.Size = New Size(1240, 670)
        flowAccountCards.TabIndex = 2
        flowAccountCards.WrapContents = False

        pnlContent.Controls.Add(flowAccountCards)
        pnlContent.Controls.Add(pnlActions)
        pnlContent.Controls.Add(txtSearch)

        pnlMain.Controls.Add(pnlContent)
        pnlMain.Controls.Add(pnlHeader)

        ' === ADD TO FORM ===
        Me.Controls.Add(pnlMain)
        Me.Controls.Add(pnlSidebar)

        ' === RESUME LAYOUTS ===
        pnlSidebar.ResumeLayout(False)
        pnlMain.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlContent.ResumeLayout(False)
        pnlLogo.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
End Class