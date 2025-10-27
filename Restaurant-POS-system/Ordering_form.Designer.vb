<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Order
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblHeaderTitle = New Label()
        lblHeaderSubtitle = New Label()
        pnlHeaderActions = New Panel()
        IconButton3 = New FontAwesome.Sharp.IconButton()
        SettingsBtn = New FontAwesome.Sharp.IconButton()
        pnlSearch = New Panel()
        SearchTxtBox = New TextBox()
        SearchBtn = New FontAwesome.Sharp.IconButton()
        DataGridView1 = New DataGridView()
        pnlOrderSidebar = New Panel()
        OrderPnl = New FlowLayoutPanel()
        pnlTotal = New Panel()
        pnlTotalContent = New Panel()
        pnlTotalRow = New Panel()
        TotalLbl = New Label()
        Label2 = New Label()
        pnlDiscountRow = New Panel()
        DiscountLbl = New Label()
        Label3 = New Label()
        pnlSubtotalRow = New Panel()
        SubtotalLbl = New Label()
        Label6 = New Label()
        pnlOrderHeader = New Panel()
        lblOrderTitle = New Label()
        pnlMenu = New Panel()
        FoodPnl = New FlowLayoutPanel()
        pnlMenuActions = New Panel()
        IconButton2 = New FontAwesome.Sharp.IconButton()
        RecentOrdersBtn = New FontAwesome.Sharp.IconButton()
        CancelBtn = New FontAwesome.Sharp.IconButton()
        DiscountBtn = New FontAwesome.Sharp.IconButton()
        CreateOrderBtn = New FontAwesome.Sharp.IconButton()
        MenuCategoryPnl = New FlowLayoutPanel()
        pnlHeader.SuspendLayout()
        pnlHeaderActions.SuspendLayout()
        pnlSearch.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        pnlOrderSidebar.SuspendLayout()
        pnlTotal.SuspendLayout()
        pnlTotalContent.SuspendLayout()
        pnlTotalRow.SuspendLayout()
        pnlDiscountRow.SuspendLayout()
        pnlSubtotalRow.SuspendLayout()
        pnlOrderHeader.SuspendLayout()
        pnlMenu.SuspendLayout()
        pnlMenuActions.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        pnlHeader.Controls.Add(lblHeaderTitle)
        pnlHeader.Controls.Add(lblHeaderSubtitle)
        pnlHeader.Controls.Add(pnlHeaderActions)
        pnlHeader.Controls.Add(pnlSearch)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1600, 90)
        pnlHeader.TabIndex = 0
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Color.White
        lblHeaderTitle.Location = New Point(30, 20)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(159, 46)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = "OrderUp"
        ' 
        ' lblHeaderSubtitle
        ' 
        lblHeaderSubtitle.AutoSize = True
        lblHeaderSubtitle.Font = New Font("Segoe UI", 10F)
        lblHeaderSubtitle.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblHeaderSubtitle.Location = New Point(35, 63)
        lblHeaderSubtitle.Name = "lblHeaderSubtitle"
        lblHeaderSubtitle.Size = New Size(105, 23)
        lblHeaderSubtitle.TabIndex = 1
        lblHeaderSubtitle.Text = "Point of Sale"
        ' 
        ' pnlHeaderActions
        ' 
        pnlHeaderActions.Controls.Add(IconButton3)
        pnlHeaderActions.Controls.Add(SettingsBtn)
        pnlHeaderActions.Dock = DockStyle.Right
        pnlHeaderActions.Location = New Point(1500, 0)
        pnlHeaderActions.Name = "pnlHeaderActions"
        pnlHeaderActions.Padding = New Padding(10, 20, 20, 20)
        pnlHeaderActions.Size = New Size(100, 90)
        pnlHeaderActions.TabIndex = 3
        ' 
        ' IconButton3
        ' 
        IconButton3.BackColor = Color.FromArgb(CByte(220), CByte(38), CByte(38))
        IconButton3.Cursor = Cursors.Hand
        IconButton3.Dock = DockStyle.Right
        IconButton3.FlatAppearance.BorderSize = 0
        IconButton3.FlatStyle = FlatStyle.Flat
        IconButton3.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt
        IconButton3.IconColor = Color.White
        IconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton3.IconSize = 24
        IconButton3.Location = New Point(10, 20)
        IconButton3.Name = "IconButton3"
        IconButton3.Size = New Size(35, 50)
        IconButton3.TabIndex = 1
        IconButton3.UseVisualStyleBackColor = False
        ' 
        ' SettingsBtn
        ' 
        SettingsBtn.BackColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        SettingsBtn.Cursor = Cursors.Hand
        SettingsBtn.Dock = DockStyle.Right
        SettingsBtn.FlatAppearance.BorderSize = 0
        SettingsBtn.FlatStyle = FlatStyle.Flat
        SettingsBtn.IconChar = FontAwesome.Sharp.IconChar.Cog
        SettingsBtn.IconColor = Color.White
        SettingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SettingsBtn.IconSize = 24
        SettingsBtn.Location = New Point(45, 20)
        SettingsBtn.Name = "SettingsBtn"
        SettingsBtn.Size = New Size(35, 50)
        SettingsBtn.TabIndex = 0
        SettingsBtn.UseVisualStyleBackColor = False
        ' 
        ' pnlSearch
        ' 
        pnlSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlSearch.BackColor = Color.FromArgb(CByte(45), CByte(55), CByte(72))
        pnlSearch.Controls.Add(SearchTxtBox)
        pnlSearch.Controls.Add(SearchBtn)
        pnlSearch.Location = New Point(550, 20)
        pnlSearch.Name = "pnlSearch"
        pnlSearch.Size = New Size(500, 50)
        pnlSearch.TabIndex = 2
        ' 
        ' SearchTxtBox
        ' 
        SearchTxtBox.BackColor = Color.FromArgb(CByte(45), CByte(55), CByte(72))
        SearchTxtBox.BorderStyle = BorderStyle.None
        SearchTxtBox.Dock = DockStyle.Fill
        SearchTxtBox.Font = New Font("Segoe UI", 12F)
        SearchTxtBox.ForeColor = Color.White
        SearchTxtBox.Location = New Point(0, 0)
        SearchTxtBox.Multiline = True
        SearchTxtBox.Name = "SearchTxtBox"
        SearchTxtBox.PlaceholderText = "🔍 Search menu items..."
        SearchTxtBox.Size = New Size(380, 50)
        SearchTxtBox.TabIndex = 0
        ' 
        ' SearchBtn
        ' 
        SearchBtn.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        SearchBtn.Cursor = Cursors.Hand
        SearchBtn.Dock = DockStyle.Right
        SearchBtn.FlatAppearance.BorderSize = 0
        SearchBtn.FlatStyle = FlatStyle.Flat
        SearchBtn.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        SearchBtn.ForeColor = Color.White
        SearchBtn.IconChar = FontAwesome.Sharp.IconChar.Search
        SearchBtn.IconColor = Color.White
        SearchBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SearchBtn.IconSize = 20
        SearchBtn.Location = New Point(380, 0)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.Size = New Size(120, 50)
        SearchBtn.TabIndex = 1
        SearchBtn.Text = "Search"
        SearchBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        SearchBtn.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ColumnHeadersHeight = 29
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(10, 10)
        DataGridView1.TabIndex = 0
        DataGridView1.Visible = False
        ' 
        ' pnlOrderSidebar
        ' 
        pnlOrderSidebar.BackColor = Color.FromArgb(CByte(247), CByte(250), CByte(252))
        pnlOrderSidebar.Controls.Add(OrderPnl)
        pnlOrderSidebar.Controls.Add(pnlTotal)
        pnlOrderSidebar.Controls.Add(pnlOrderHeader)
        pnlOrderSidebar.Dock = DockStyle.Left
        pnlOrderSidebar.Location = New Point(0, 90)
        pnlOrderSidebar.Name = "pnlOrderSidebar"
        pnlOrderSidebar.Size = New Size(480, 920)
        pnlOrderSidebar.TabIndex = 1
        ' 
        ' OrderPnl
        ' 
        OrderPnl.AutoScroll = True
        OrderPnl.BackColor = Color.White
        OrderPnl.Dock = DockStyle.Fill
        OrderPnl.FlowDirection = FlowDirection.TopDown
        OrderPnl.Location = New Point(0, 70)
        OrderPnl.Name = "OrderPnl"
        OrderPnl.Padding = New Padding(15)
        OrderPnl.Size = New Size(480, 600)
        OrderPnl.TabIndex = 1
        OrderPnl.WrapContents = False
        ' 
        ' pnlTotal
        ' 
        pnlTotal.BackColor = Color.FromArgb(CByte(26), CByte(32), CByte(44))
        pnlTotal.Controls.Add(pnlTotalContent)
        pnlTotal.Dock = DockStyle.Bottom
        pnlTotal.Location = New Point(0, 670)
        pnlTotal.Name = "pnlTotal"
        pnlTotal.Padding = New Padding(25)
        pnlTotal.Size = New Size(480, 250)
        pnlTotal.TabIndex = 2
        ' 
        ' pnlTotalContent
        ' 
        pnlTotalContent.Controls.Add(pnlTotalRow)
        pnlTotalContent.Controls.Add(pnlDiscountRow)
        pnlTotalContent.Controls.Add(pnlSubtotalRow)
        pnlTotalContent.Dock = DockStyle.Fill
        pnlTotalContent.Location = New Point(25, 25)
        pnlTotalContent.Name = "pnlTotalContent"
        pnlTotalContent.Size = New Size(430, 200)
        pnlTotalContent.TabIndex = 0
        ' 
        ' pnlTotalRow
        ' 
        pnlTotalRow.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        pnlTotalRow.Controls.Add(TotalLbl)
        pnlTotalRow.Controls.Add(Label2)
        pnlTotalRow.Dock = DockStyle.Bottom
        pnlTotalRow.Location = New Point(0, 116)
        pnlTotalRow.Name = "pnlTotalRow"
        pnlTotalRow.Padding = New Padding(20, 15, 20, 15)
        pnlTotalRow.Size = New Size(430, 84)
        pnlTotalRow.TabIndex = 2
        ' 
        ' TotalLbl
        ' 
        TotalLbl.Dock = DockStyle.Right
        TotalLbl.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        TotalLbl.ForeColor = Color.White
        TotalLbl.Location = New Point(230, 15)
        TotalLbl.Name = "TotalLbl"
        TotalLbl.Size = New Size(180, 54)
        TotalLbl.TabIndex = 1
        TotalLbl.Text = "₱0"
        TotalLbl.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Dock = DockStyle.Left
        Label2.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(20, 15)
        Label2.Name = "Label2"
        Label2.Size = New Size(109, 41)
        Label2.TabIndex = 0
        Label2.Text = "TOTAL"
        ' 
        ' pnlDiscountRow
        ' 
        pnlDiscountRow.Controls.Add(DiscountLbl)
        pnlDiscountRow.Controls.Add(Label3)
        pnlDiscountRow.Dock = DockStyle.Top
        pnlDiscountRow.Location = New Point(0, 60)
        pnlDiscountRow.Name = "pnlDiscountRow"
        pnlDiscountRow.Padding = New Padding(20, 10, 20, 10)
        pnlDiscountRow.Size = New Size(430, 50)
        pnlDiscountRow.TabIndex = 1
        ' 
        ' DiscountLbl
        ' 
        DiscountLbl.Dock = DockStyle.Right
        DiscountLbl.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        DiscountLbl.ForeColor = Color.FromArgb(CByte(245), CByte(101), CByte(101))
        DiscountLbl.Location = New Point(310, 10)
        DiscountLbl.Name = "DiscountLbl"
        DiscountLbl.Size = New Size(100, 30)
        DiscountLbl.TabIndex = 1
        DiscountLbl.Text = "%0"
        DiscountLbl.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Dock = DockStyle.Left
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        Label3.Location = New Point(20, 10)
        Label3.Name = "Label3"
        Label3.Size = New Size(89, 28)
        Label3.TabIndex = 0
        Label3.Text = "Discount"
        ' 
        ' pnlSubtotalRow
        ' 
        pnlSubtotalRow.Controls.Add(SubtotalLbl)
        pnlSubtotalRow.Controls.Add(Label6)
        pnlSubtotalRow.Dock = DockStyle.Top
        pnlSubtotalRow.Location = New Point(0, 0)
        pnlSubtotalRow.Name = "pnlSubtotalRow"
        pnlSubtotalRow.Padding = New Padding(20, 10, 20, 10)
        pnlSubtotalRow.Size = New Size(430, 60)
        pnlSubtotalRow.TabIndex = 0
        ' 
        ' SubtotalLbl
        ' 
        SubtotalLbl.Dock = DockStyle.Right
        SubtotalLbl.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        SubtotalLbl.ForeColor = Color.White
        SubtotalLbl.Location = New Point(260, 10)
        SubtotalLbl.Name = "SubtotalLbl"
        SubtotalLbl.Size = New Size(150, 40)
        SubtotalLbl.TabIndex = 1
        SubtotalLbl.Text = "₱0"
        SubtotalLbl.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Dock = DockStyle.Left
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        Label6.Location = New Point(20, 10)
        Label6.Name = "Label6"
        Label6.Size = New Size(87, 28)
        Label6.TabIndex = 0
        Label6.Text = "Subtotal"
        ' 
        ' pnlOrderHeader
        ' 
        pnlOrderHeader.BackColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        pnlOrderHeader.Controls.Add(lblOrderTitle)
        pnlOrderHeader.Dock = DockStyle.Top
        pnlOrderHeader.Location = New Point(0, 0)
        pnlOrderHeader.Name = "pnlOrderHeader"
        pnlOrderHeader.Padding = New Padding(25, 20, 25, 20)
        pnlOrderHeader.Size = New Size(480, 70)
        pnlOrderHeader.TabIndex = 0
        ' 
        ' lblOrderTitle
        ' 
        lblOrderTitle.AutoSize = True
        lblOrderTitle.Dock = DockStyle.Left
        lblOrderTitle.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblOrderTitle.ForeColor = Color.White
        lblOrderTitle.Location = New Point(25, 20)
        lblOrderTitle.Name = "lblOrderTitle"
        lblOrderTitle.Size = New Size(215, 32)
        lblOrderTitle.TabIndex = 0
        lblOrderTitle.Text = ChrW(55357) & ChrW(57042) & " Current Order"
        ' 
        ' pnlMenu
        ' 
        pnlMenu.BackColor = Color.FromArgb(CByte(247), CByte(250), CByte(252))
        pnlMenu.Controls.Add(FoodPnl)
        pnlMenu.Controls.Add(pnlMenuActions)
        pnlMenu.Controls.Add(MenuCategoryPnl)
        pnlMenu.Dock = DockStyle.Fill
        pnlMenu.Location = New Point(480, 90)
        pnlMenu.Name = "pnlMenu"
        pnlMenu.Size = New Size(1120, 920)
        pnlMenu.TabIndex = 2
        ' 
        ' FoodPnl
        ' 
        FoodPnl.AutoScroll = True
        FoodPnl.BackColor = Color.White
        FoodPnl.Dock = DockStyle.Fill
        FoodPnl.Location = New Point(0, 80)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Padding = New Padding(25)
        FoodPnl.Size = New Size(1120, 730)
        FoodPnl.TabIndex = 1
        ' 
        ' pnlMenuActions
        ' 
        pnlMenuActions.BackColor = Color.White
        pnlMenuActions.BorderStyle = BorderStyle.FixedSingle
        pnlMenuActions.Controls.Add(IconButton2)
        pnlMenuActions.Controls.Add(RecentOrdersBtn)
        pnlMenuActions.Controls.Add(CancelBtn)
        pnlMenuActions.Controls.Add(DiscountBtn)
        pnlMenuActions.Controls.Add(CreateOrderBtn)
        pnlMenuActions.Dock = DockStyle.Bottom
        pnlMenuActions.Location = New Point(0, 810)
        pnlMenuActions.Name = "pnlMenuActions"
        pnlMenuActions.Padding = New Padding(20)
        pnlMenuActions.Size = New Size(1120, 110)
        pnlMenuActions.TabIndex = 2
        ' 
        ' IconButton2
        ' 
        IconButton2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        IconButton2.BackColor = Color.FromArgb(CByte(113), CByte(128), CByte(150))
        IconButton2.Cursor = Cursors.Hand
        IconButton2.FlatAppearance.BorderSize = 0
        IconButton2.FlatStyle = FlatStyle.Flat
        IconButton2.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        IconButton2.ForeColor = Color.White
        IconButton2.IconChar = FontAwesome.Sharp.IconChar.Keyboard
        IconButton2.IconColor = Color.White
        IconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton2.IconSize = 22
        IconButton2.ImageAlign = ContentAlignment.MiddleLeft
        IconButton2.Location = New Point(914, 25)
        IconButton2.Name = "IconButton2"
        IconButton2.Padding = New Padding(8, 0, 8, 0)
        IconButton2.Size = New Size(175, 58)
        IconButton2.TabIndex = 4
        IconButton2.Text = "Shortcuts"
        IconButton2.TextImageRelation = TextImageRelation.ImageBeforeText
        IconButton2.UseVisualStyleBackColor = False
        ' 
        ' RecentOrdersBtn
        ' 
        RecentOrdersBtn.BackColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        RecentOrdersBtn.Cursor = Cursors.Hand
        RecentOrdersBtn.FlatAppearance.BorderSize = 0
        RecentOrdersBtn.FlatStyle = FlatStyle.Flat
        RecentOrdersBtn.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        RecentOrdersBtn.ForeColor = Color.White
        RecentOrdersBtn.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft
        RecentOrdersBtn.IconColor = Color.White
        RecentOrdersBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        RecentOrdersBtn.IconSize = 22
        RecentOrdersBtn.ImageAlign = ContentAlignment.MiddleLeft
        RecentOrdersBtn.Location = New Point(690, 25)
        RecentOrdersBtn.Name = "RecentOrdersBtn"
        RecentOrdersBtn.Padding = New Padding(8, 0, 8, 0)
        RecentOrdersBtn.Size = New Size(200, 58)
        RecentOrdersBtn.TabIndex = 3
        RecentOrdersBtn.Text = "Recent Orders"
        RecentOrdersBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        RecentOrdersBtn.UseVisualStyleBackColor = False
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.FromArgb(CByte(220), CByte(38), CByte(38))
        CancelBtn.Cursor = Cursors.Hand
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        CancelBtn.ForeColor = Color.White
        CancelBtn.IconChar = FontAwesome.Sharp.IconChar.Close
        CancelBtn.IconColor = Color.White
        CancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CancelBtn.IconSize = 22
        CancelBtn.ImageAlign = ContentAlignment.MiddleLeft
        CancelBtn.Location = New Point(485, 25)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Padding = New Padding(8, 0, 8, 0)
        CancelBtn.Size = New Size(180, 58)
        CancelBtn.TabIndex = 2
        CancelBtn.Text = "Cancel Order"
        CancelBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' DiscountBtn
        ' 
        DiscountBtn.BackColor = Color.FromArgb(CByte(251), CByte(191), CByte(36))
        DiscountBtn.Cursor = Cursors.Hand
        DiscountBtn.FlatAppearance.BorderSize = 0
        DiscountBtn.FlatStyle = FlatStyle.Flat
        DiscountBtn.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        DiscountBtn.ForeColor = Color.White
        DiscountBtn.IconChar = FontAwesome.Sharp.IconChar.Tag
        DiscountBtn.IconColor = Color.White
        DiscountBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        DiscountBtn.IconSize = 22
        DiscountBtn.ImageAlign = ContentAlignment.MiddleLeft
        DiscountBtn.Location = New Point(270, 25)
        DiscountBtn.Name = "DiscountBtn"
        DiscountBtn.Padding = New Padding(8, 0, 8, 0)
        DiscountBtn.Size = New Size(190, 58)
        DiscountBtn.TabIndex = 1
        DiscountBtn.Text = "Apply Discount"
        DiscountBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        DiscountBtn.UseVisualStyleBackColor = False
        ' 
        ' CreateOrderBtn
        ' 
        CreateOrderBtn.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        CreateOrderBtn.Cursor = Cursors.Hand
        CreateOrderBtn.FlatAppearance.BorderSize = 0
        CreateOrderBtn.FlatStyle = FlatStyle.Flat
        CreateOrderBtn.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        CreateOrderBtn.ForeColor = Color.White
        CreateOrderBtn.IconChar = FontAwesome.Sharp.IconChar.CheckCircle
        CreateOrderBtn.IconColor = Color.White
        CreateOrderBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CreateOrderBtn.IconSize = 26
        CreateOrderBtn.ImageAlign = ContentAlignment.MiddleLeft
        CreateOrderBtn.Location = New Point(25, 25)
        CreateOrderBtn.Name = "CreateOrderBtn"
        CreateOrderBtn.Padding = New Padding(12, 0, 12, 0)
        CreateOrderBtn.Size = New Size(220, 58)
        CreateOrderBtn.TabIndex = 0
        CreateOrderBtn.Text = "Create Order"
        CreateOrderBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        CreateOrderBtn.UseVisualStyleBackColor = False
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.BackColor = Color.White
        MenuCategoryPnl.Dock = DockStyle.Top
        MenuCategoryPnl.Location = New Point(0, 0)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(20, 15, 20, 15)
        MenuCategoryPnl.Size = New Size(1120, 80)
        MenuCategoryPnl.TabIndex = 0
        ' 
        ' Order
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(247), CByte(250), CByte(252))
        ClientSize = New Size(1600, 1010)
        Controls.Add(pnlMenu)
        Controls.Add(pnlOrderSidebar)
        Controls.Add(pnlHeader)
        Controls.Add(DataGridView1)
        Font = New Font("Segoe UI", 9F)
        Name = "Order"
        Text = "OrderUp! - Point of Sale"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlHeaderActions.ResumeLayout(False)
        pnlSearch.ResumeLayout(False)
        pnlSearch.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        pnlOrderSidebar.ResumeLayout(False)
        pnlTotal.ResumeLayout(False)
        pnlTotalContent.ResumeLayout(False)
        pnlTotalRow.ResumeLayout(False)
        pnlTotalRow.PerformLayout()
        pnlDiscountRow.ResumeLayout(False)
        pnlDiscountRow.PerformLayout()
        pnlSubtotalRow.ResumeLayout(False)
        pnlSubtotalRow.PerformLayout()
        pnlOrderHeader.ResumeLayout(False)
        pnlOrderHeader.PerformLayout()
        pnlMenu.ResumeLayout(False)
        pnlMenuActions.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents lblHeaderSubtitle As Label
    Friend WithEvents pnlHeaderActions As Panel
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents SettingsBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents SearchTxtBox As TextBox
    Friend WithEvents SearchBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents pnlOrderSidebar As Panel
    Friend WithEvents OrderPnl As FlowLayoutPanel
    Friend WithEvents pnlTotal As Panel
    Friend WithEvents pnlTotalContent As Panel
    Friend WithEvents pnlTotalRow As Panel
    Friend WithEvents TotalLbl As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlDiscountRow As Panel
    Friend WithEvents DiscountLbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlSubtotalRow As Panel
    Friend WithEvents SubtotalLbl As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlOrderHeader As Panel
    Friend WithEvents lblOrderTitle As Label
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents pnlMenuActions As Panel
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents RecentOrdersBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents CancelBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents DiscountBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents CreateOrderBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
End Class