<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Manage_menu
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If

                Try
                    If searchTimer IsNot Nothing Then
                        searchTimer.Stop()
                        searchTimer.Dispose()
                        searchTimer = Nothing
                    End If
                Catch
                End Try

                Try
                    For Each card In displayedCards
                        Try
                            card.Dispose()
                        Catch
                        End Try
                    Next
                Catch
                End Try
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim CustomizableEdges20 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges21 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges18 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges19 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges13 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges14 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges15 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges16 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges17 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges25 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges26 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges23 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges24 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges22 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        pnlTopBar = New Guna.UI2.WinForms.Guna2GradientPanel()
        pnlTopBarRow2 = New Guna.UI2.WinForms.Guna2Panel()
        flowCategoryTabs = New FlowLayoutPanel()
        pnlActions = New Guna.UI2.WinForms.Guna2Panel()
        cmbSortFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        btnAddNew = New Guna.UI2.WinForms.Guna2Button()
        pnlTopBarRow1 = New Guna.UI2.WinForms.Guna2Panel()
        btnBack = New Guna.UI2.WinForms.Guna2Button()
        lblTitle = New Label()
        pnlTitleGlow = New Guna.UI2.WinForms.Guna2Panel()
        txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        btnHelp = New Guna.UI2.WinForms.Guna2CircleButton()
        btnLogout = New Guna.UI2.WinForms.Guna2Button()
        pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        flowMenuItems = New FlowLayoutPanel()
        pnlLoadingOverlay = New Guna.UI2.WinForms.Guna2Panel()
        lblLoading = New Label()
        pbLoadingSpinner = New Guna.UI2.WinForms.Guna2CircleProgressBar()
        pnlTopBar.SuspendLayout()
        pnlTopBarRow2.SuspendLayout()
        pnlActions.SuspendLayout()
        pnlTopBarRow1.SuspendLayout()
        pnlMain.SuspendLayout()
        pnlLoadingOverlay.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlTopBar
        ' 
        pnlTopBar.Controls.Add(pnlTopBarRow2)
        pnlTopBar.Controls.Add(pnlTopBarRow1)
        pnlTopBar.CustomizableEdges = CustomizableEdges20
        pnlTopBar.Dock = DockStyle.Top
        pnlTopBar.FillColor = Color.FromArgb(CByte(31), CByte(138), CByte(112))
        pnlTopBar.FillColor2 = Color.FromArgb(CByte(21), CByte(108), CByte(82))
        pnlTopBar.Location = New Point(0, 0)
        pnlTopBar.Name = "pnlTopBar"
        pnlTopBar.ShadowDecoration.BorderRadius = 0
        pnlTopBar.ShadowDecoration.Color = Color.FromArgb(CByte(80), CByte(0), CByte(0), CByte(0))
        pnlTopBar.ShadowDecoration.CustomizableEdges = CustomizableEdges21
        pnlTopBar.ShadowDecoration.Depth = 20
        pnlTopBar.ShadowDecoration.Enabled = True
        pnlTopBar.ShadowDecoration.Shadow = New Padding(0, 8, 0, 0)
        pnlTopBar.Size = New Size(1600, 207)
        pnlTopBar.TabIndex = 0
        ' 
        ' pnlTopBarRow2
        ' 
        pnlTopBarRow2.BackColor = Color.Transparent
        pnlTopBarRow2.Controls.Add(flowCategoryTabs)
        pnlTopBarRow2.Controls.Add(pnlActions)
        pnlTopBarRow2.CustomizableEdges = CustomizableEdges7
        pnlTopBarRow2.Dock = DockStyle.Top
        pnlTopBarRow2.FillColor = Color.Transparent
        pnlTopBarRow2.Location = New Point(0, 70)
        pnlTopBarRow2.Name = "pnlTopBarRow2"
        pnlTopBarRow2.Padding = New Padding(25, 15, 25, 15)
        pnlTopBarRow2.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        pnlTopBarRow2.Size = New Size(1600, 137)
        pnlTopBarRow2.TabIndex = 1
        ' 
        ' flowCategoryTabs
        ' 
        flowCategoryTabs.AutoSize = True
        flowCategoryTabs.BackColor = Color.Transparent
        flowCategoryTabs.Dock = DockStyle.Left
        flowCategoryTabs.Location = New Point(25, 15)
        flowCategoryTabs.Name = "flowCategoryTabs"
        flowCategoryTabs.Padding = New Padding(0, 8, 0, 8)
        flowCategoryTabs.Size = New Size(0, 107)
        flowCategoryTabs.TabIndex = 0
        flowCategoryTabs.WrapContents = False
        ' 
        ' pnlActions
        ' 
        pnlActions.BackColor = Color.Transparent
        pnlActions.Controls.Add(cmbSortFilter)
        pnlActions.Controls.Add(btnAddNew)
        pnlActions.CustomizableEdges = CustomizableEdges5
        pnlActions.Dock = DockStyle.Right
        pnlActions.FillColor = Color.Transparent
        pnlActions.Location = New Point(1225, 15)
        pnlActions.Name = "pnlActions"
        pnlActions.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        pnlActions.Size = New Size(350, 107)
        pnlActions.TabIndex = 1
        ' 
        ' cmbSortFilter
        ' 
        cmbSortFilter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cmbSortFilter.BackColor = Color.Transparent
        cmbSortFilter.BorderColor = Color.FromArgb(CByte(255), CByte(255), CByte(60))
        cmbSortFilter.BorderRadius = 16
        cmbSortFilter.BorderThickness = 2
        cmbSortFilter.CustomizableEdges = CustomizableEdges1
        cmbSortFilter.DrawMode = DrawMode.OwnerDrawFixed
        cmbSortFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSortFilter.FillColor = Color.FromArgb(CByte(40), CByte(255), CByte(255), CByte(255))
        cmbSortFilter.FocusedColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        cmbSortFilter.FocusedState.BorderColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        cmbSortFilter.Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Bold)
        cmbSortFilter.ForeColor = Color.White
        cmbSortFilter.HoverState.BorderColor = Color.FromArgb(CByte(255), CByte(255), CByte(100))
        cmbSortFilter.ItemHeight = 40
        cmbSortFilter.Items.AddRange(New Object() {"All Items", "New Items", "Price: Low to High", "Price: High to Low"})
        cmbSortFilter.Location = New Point(0, 12)
        cmbSortFilter.Name = "cmbSortFilter"
        cmbSortFilter.ShadowDecoration.BorderRadius = 16
        cmbSortFilter.ShadowDecoration.Color = Color.FromArgb(CByte(60), CByte(0), CByte(0), CByte(0))
        cmbSortFilter.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        cmbSortFilter.ShadowDecoration.Depth = 12
        cmbSortFilter.ShadowDecoration.Enabled = True
        cmbSortFilter.Size = New Size(180, 46)
        cmbSortFilter.StartIndex = 0
        cmbSortFilter.TabIndex = 0
        cmbSortFilter.TextOffset = New Point(5, 0)
        ' 
        ' btnAddNew
        ' 
        btnAddNew.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddNew.Animated = True
        btnAddNew.BackColor = Color.Transparent
        btnAddNew.BorderRadius = 16
        btnAddNew.Cursor = Cursors.Hand
        btnAddNew.CustomizableEdges = CustomizableEdges3
        btnAddNew.DisabledState.BorderColor = Color.DarkGray
        btnAddNew.DisabledState.CustomBorderColor = Color.DarkGray
        btnAddNew.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnAddNew.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnAddNew.FillColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        btnAddNew.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnAddNew.ForeColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        btnAddNew.HoverState.FillColor = Color.FromArgb(CByte(255), CByte(220), CByte(117))
        btnAddNew.ImageSize = New Size(22, 22)
        btnAddNew.Location = New Point(195, 12)
        btnAddNew.Name = "btnAddNew"
        btnAddNew.PressedColor = Color.FromArgb(CByte(235), CByte(180), CByte(67))
        btnAddNew.ShadowDecoration.BorderRadius = 16
        btnAddNew.ShadowDecoration.Color = Color.FromArgb(CByte(100), CByte(255), CByte(200), CByte(87))
        btnAddNew.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnAddNew.ShadowDecoration.Depth = 15
        btnAddNew.ShadowDecoration.Enabled = True
        btnAddNew.Size = New Size(155, 46)
        btnAddNew.TabIndex = 1
        btnAddNew.Text = "✨ Add New"
        ' 
        ' pnlTopBarRow1
        ' 
        pnlTopBarRow1.BackColor = Color.Transparent
        pnlTopBarRow1.Controls.Add(btnBack)
        pnlTopBarRow1.Controls.Add(lblTitle)
        pnlTopBarRow1.Controls.Add(pnlTitleGlow)
        pnlTopBarRow1.Controls.Add(txtSearch)
        pnlTopBarRow1.Controls.Add(btnHelp)
        pnlTopBarRow1.Controls.Add(btnLogout)
        pnlTopBarRow1.CustomizableEdges = CustomizableEdges18
        pnlTopBarRow1.Dock = DockStyle.Top
        pnlTopBarRow1.FillColor = Color.Transparent
        pnlTopBarRow1.Location = New Point(0, 0)
        pnlTopBarRow1.Name = "pnlTopBarRow1"
        pnlTopBarRow1.Padding = New Padding(25, 15, 25, 10)
        pnlTopBarRow1.ShadowDecoration.CustomizableEdges = CustomizableEdges19
        pnlTopBarRow1.Size = New Size(1600, 70)
        pnlTopBarRow1.TabIndex = 0
        ' 
        ' btnBack
        ' 
        btnBack.Animated = True
        btnBack.BackColor = Color.Transparent
        btnBack.BorderColor = Color.FromArgb(CByte(255), CByte(255), CByte(80))
        btnBack.BorderRadius = 14
        btnBack.BorderThickness = 2
        btnBack.Cursor = Cursors.Hand
        btnBack.CustomizableEdges = CustomizableEdges9
        btnBack.DisabledState.BorderColor = Color.DarkGray
        btnBack.DisabledState.CustomBorderColor = Color.DarkGray
        btnBack.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnBack.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnBack.FillColor = Color.FromArgb(CByte(30), CByte(255), CByte(255), CByte(255))
        btnBack.Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Bold)
        btnBack.ForeColor = Color.White
        btnBack.HoverState.BorderColor = Color.FromArgb(CByte(255), CByte(255), CByte(120))
        btnBack.HoverState.FillColor = Color.FromArgb(CByte(50), CByte(255), CByte(255), CByte(255))
        btnBack.Location = New Point(25, 18)
        btnBack.Name = "btnBack"
        btnBack.PressedColor = Color.FromArgb(CByte(70), CByte(255), CByte(255), CByte(255))
        btnBack.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        btnBack.Size = New Size(110, 40)
        btnBack.TabIndex = 0
        btnBack.Text = "← Back"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(155, 22)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(308, 46)
        lblTitle.TabIndex = 1
        lblTitle.Text = "🍽️ Manage Menu"
        ' 
        ' pnlTitleGlow
        ' 
        pnlTitleGlow.BackColor = Color.Transparent
        pnlTitleGlow.BorderRadius = 20
        pnlTitleGlow.CustomizableEdges = CustomizableEdges11
        pnlTitleGlow.FillColor = Color.FromArgb(CByte(40), CByte(255), CByte(200), CByte(87))
        pnlTitleGlow.Location = New Point(145, 13)
        pnlTitleGlow.Name = "pnlTitleGlow"
        pnlTitleGlow.ShadowDecoration.BorderRadius = 20
        pnlTitleGlow.ShadowDecoration.Color = Color.FromArgb(CByte(120), CByte(255), CByte(200), CByte(87))
        pnlTitleGlow.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        pnlTitleGlow.ShadowDecoration.Depth = 25
        pnlTitleGlow.ShadowDecoration.Enabled = True
        pnlTitleGlow.Size = New Size(300, 50)
        pnlTitleGlow.TabIndex = 2
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtSearch.Animated = True
        txtSearch.BackColor = Color.Transparent
        txtSearch.BorderColor = Color.FromArgb(CByte(255), CByte(255), CByte(60))
        txtSearch.BorderRadius = 16
        txtSearch.BorderThickness = 2
        txtSearch.Cursor = Cursors.IBeam
        txtSearch.CustomizableEdges = CustomizableEdges13
        txtSearch.DefaultText = ""
        txtSearch.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtSearch.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtSearch.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtSearch.FocusedState.BorderColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        txtSearch.Font = New Font("Segoe UI", 11F)
        txtSearch.ForeColor = Color.White
        txtSearch.HoverState.BorderColor = Color.FromArgb(CByte(255), CByte(255), CByte(100))
        txtSearch.IconLeftOffset = New Point(15, 0)
        txtSearch.Location = New Point(930, 15)
        txtSearch.Margin = New Padding(4)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderForeColor = Color.FromArgb(CByte(200), CByte(200), CByte(200))
        txtSearch.PlaceholderText = "🔍 Search menu items..."
        txtSearch.SelectedText = ""
        txtSearch.ShadowDecoration.BorderRadius = 16
        txtSearch.ShadowDecoration.Color = Color.FromArgb(CByte(60), CByte(0), CByte(0), CByte(0))
        txtSearch.ShadowDecoration.CustomizableEdges = CustomizableEdges14
        txtSearch.ShadowDecoration.Depth = 12
        txtSearch.ShadowDecoration.Enabled = True
        txtSearch.Size = New Size(420, 46)
        txtSearch.TabIndex = 3
        txtSearch.TextOffset = New Point(8, 0)
        ' 
        ' btnHelp
        ' 
        btnHelp.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnHelp.Animated = True
        btnHelp.BackColor = Color.Transparent
        btnHelp.BorderColor = Color.FromArgb(CByte(255), CByte(255), CByte(80))
        btnHelp.BorderThickness = 2
        btnHelp.Cursor = Cursors.Hand
        btnHelp.DisabledState.BorderColor = Color.DarkGray
        btnHelp.DisabledState.CustomBorderColor = Color.DarkGray
        btnHelp.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnHelp.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnHelp.FillColor = Color.FromArgb(CByte(30), CByte(255), CByte(255), CByte(255))
        btnHelp.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        btnHelp.ForeColor = Color.White
        btnHelp.HoverState.BorderColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        btnHelp.HoverState.FillColor = Color.FromArgb(CByte(50), CByte(255), CByte(200), CByte(87))
        btnHelp.Location = New Point(1370, 15)
        btnHelp.Name = "btnHelp"
        btnHelp.ShadowDecoration.CustomizableEdges = CustomizableEdges15
        btnHelp.ShadowDecoration.Enabled = True
        btnHelp.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        btnHelp.Size = New Size(50, 46)
        btnHelp.TabIndex = 4
        btnHelp.Text = "?"
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.Animated = True
        btnLogout.BackColor = Color.Transparent
        btnLogout.BorderRadius = 14
        btnLogout.Cursor = Cursors.Hand
        btnLogout.CustomizableEdges = CustomizableEdges16
        btnLogout.DisabledState.BorderColor = Color.DarkGray
        btnLogout.DisabledState.CustomBorderColor = Color.DarkGray
        btnLogout.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLogout.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLogout.FillColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnLogout.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.HoverState.FillColor = Color.FromArgb(CByte(211), CByte(56), CByte(40))
        btnLogout.Location = New Point(1440, 15)
        btnLogout.Name = "btnLogout"
        btnLogout.PressedColor = Color.FromArgb(CByte(191), CByte(36), CByte(20))
        btnLogout.ShadowDecoration.BorderRadius = 14
        btnLogout.ShadowDecoration.Color = Color.FromArgb(CByte(80), CByte(231), CByte(76), CByte(60))
        btnLogout.ShadowDecoration.CustomizableEdges = CustomizableEdges17
        btnLogout.ShadowDecoration.Depth = 12
        btnLogout.ShadowDecoration.Enabled = True
        btnLogout.Size = New Size(135, 46)
        btnLogout.TabIndex = 5
        btnLogout.Text = "🚪 Logout"
        ' 
        ' pnlMain
        ' 
        pnlMain.AutoScroll = True
        pnlMain.BackColor = Color.Transparent
        pnlMain.Controls.Add(flowMenuItems)
        pnlMain.Controls.Add(pnlLoadingOverlay)
        pnlMain.CustomizableEdges = CustomizableEdges25
        pnlMain.Dock = DockStyle.Fill
        pnlMain.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(249))
        pnlMain.Location = New Point(0, 207)
        pnlMain.Name = "pnlMain"
        pnlMain.Padding = New Padding(35)
        pnlMain.ShadowDecoration.CustomizableEdges = CustomizableEdges26
        pnlMain.Size = New Size(1600, 793)
        pnlMain.TabIndex = 1
        ' 
        ' flowMenuItems
        ' 
        flowMenuItems.AutoScroll = True
        flowMenuItems.BackColor = Color.Transparent
        flowMenuItems.Dock = DockStyle.Fill
        flowMenuItems.Location = New Point(35, 35)
        flowMenuItems.Name = "flowMenuItems"
        flowMenuItems.Padding = New Padding(15)
        flowMenuItems.Size = New Size(1530, 723)
        flowMenuItems.TabIndex = 0
        ' 
        ' pnlLoadingOverlay
        ' 
        pnlLoadingOverlay.BackColor = Color.FromArgb(CByte(230), CByte(247), CByte(247), CByte(249))
        pnlLoadingOverlay.Controls.Add(lblLoading)
        pnlLoadingOverlay.Controls.Add(pbLoadingSpinner)
        pnlLoadingOverlay.CustomizableEdges = CustomizableEdges23
        pnlLoadingOverlay.Dock = DockStyle.Fill
        pnlLoadingOverlay.FillColor = Color.FromArgb(CByte(230), CByte(247), CByte(247), CByte(249))
        pnlLoadingOverlay.Location = New Point(35, 35)
        pnlLoadingOverlay.Name = "pnlLoadingOverlay"
        pnlLoadingOverlay.ShadowDecoration.CustomizableEdges = CustomizableEdges24
        pnlLoadingOverlay.Size = New Size(1530, 723)
        pnlLoadingOverlay.TabIndex = 1
        pnlLoadingOverlay.Visible = False
        ' 
        ' lblLoading
        ' 
        lblLoading.Anchor = AnchorStyles.None
        lblLoading.AutoSize = True
        lblLoading.BackColor = Color.Transparent
        lblLoading.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        lblLoading.ForeColor = Color.FromArgb(CByte(31), CByte(138), CByte(112))
        lblLoading.Location = New Point(640, 416)
        lblLoading.Name = "lblLoading"
        lblLoading.Size = New Size(255, 37)
        lblLoading.TabIndex = 1
        lblLoading.Text = "✨ Loading items..."
        lblLoading.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pbLoadingSpinner
        ' 
        pbLoadingSpinner.Anchor = AnchorStyles.None
        pbLoadingSpinner.Animated = True
        pbLoadingSpinner.BackColor = Color.Transparent
        pbLoadingSpinner.FillColor = Color.FromArgb(CByte(230), CByte(230), CByte(230))
        pbLoadingSpinner.FillThickness = 10
        pbLoadingSpinner.Font = New Font("Segoe UI", 12F)
        pbLoadingSpinner.ForeColor = Color.White
        pbLoadingSpinner.Location = New Point(690, 286)
        pbLoadingSpinner.Minimum = 0
        pbLoadingSpinner.Name = "pbLoadingSpinner"
        pbLoadingSpinner.ProgressColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        pbLoadingSpinner.ProgressColor2 = Color.FromArgb(CByte(31), CByte(138), CByte(112))
        pbLoadingSpinner.ProgressThickness = 10
        pbLoadingSpinner.ShadowDecoration.CustomizableEdges = CustomizableEdges22
        pbLoadingSpinner.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        pbLoadingSpinner.Size = New Size(150, 150)
        pbLoadingSpinner.TabIndex = 0
        pbLoadingSpinner.Text = "Guna2CircleProgressBar1"
        pbLoadingSpinner.Value = 60
        ' 
        ' Manage_menu
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(247), CByte(247), CByte(249))
        Controls.Add(pnlMain)
        Controls.Add(pnlTopBar)
        Font = New Font("Segoe UI", 9F)
        MinimumSize = New Size(1200, 800)
        Name = "Manage_menu"
        Size = New Size(1600, 1000)
        pnlTopBar.ResumeLayout(False)
        pnlTopBarRow2.ResumeLayout(False)
        pnlTopBarRow2.PerformLayout()
        pnlActions.ResumeLayout(False)
        pnlTopBarRow1.ResumeLayout(False)
        pnlTopBarRow1.PerformLayout()
        pnlMain.ResumeLayout(False)
        pnlLoadingOverlay.ResumeLayout(False)
        pnlLoadingOverlay.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' ===== CONTROL DECLARATIONS =====
    Friend WithEvents pnlTopBar As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents pnlTopBarRow1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlTitleGlow As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnHelp As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents btnLogout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlTopBarRow2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents flowCategoryTabs As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlActions As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents cmbSortFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnAddNew As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents flowMenuItems As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlLoadingOverlay As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents pbLoadingSpinner As Guna.UI2.WinForms.Guna2CircleProgressBar

End Class