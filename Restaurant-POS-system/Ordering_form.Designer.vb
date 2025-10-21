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
        pnlTotalValues = New Panel()
        TotalLbl = New Label()
        Label2 = New Label()
        DiscountLbl = New Label()
        Label3 = New Label()
        SubtotalLbl = New Label()
        Label6 = New Label()
        pnlMenu = New Panel()
        FoodPnl = New FlowLayoutPanel()
        pnlMenuActions = New Panel()
        IconButton2 = New FontAwesome.Sharp.IconButton()
        RecentOrdersBtn = New FontAwesome.Sharp.IconButton()
        CancelBtn = New FontAwesome.Sharp.IconButton()
        DiscountBtn = New Button()
        CreateOrderBtn = New FontAwesome.Sharp.IconButton()
        MenuCategoryPnl = New FlowLayoutPanel()
        pnlHeader.SuspendLayout()
        pnlHeaderActions.SuspendLayout()
        pnlSearch.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        pnlOrderSidebar.SuspendLayout()
        pnlTotal.SuspendLayout()
        pnlTotalValues.SuspendLayout()
        pnlMenu.SuspendLayout()
        pnlMenuActions.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(pnlHeaderActions)
        pnlHeader.Controls.Add(pnlSearch)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1600, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' pnlHeaderActions
        ' 
        pnlHeaderActions.Controls.Add(IconButton3)
        pnlHeaderActions.Controls.Add(SettingsBtn)
        pnlHeaderActions.Dock = DockStyle.Right
        pnlHeaderActions.Location = New Point(1400, 0)
        pnlHeaderActions.Name = "pnlHeaderActions"
        pnlHeaderActions.Padding = New Padding(10, 15, 30, 15)
        pnlHeaderActions.Size = New Size(200, 80)
        pnlHeaderActions.TabIndex = 1
        ' 
        ' IconButton3
        ' 
        IconButton3.BackColor = Color.Transparent
        IconButton3.Cursor = Cursors.Hand
        IconButton3.Dock = DockStyle.Right
        IconButton3.FlatAppearance.BorderSize = 0
        IconButton3.FlatStyle = FlatStyle.Flat
        IconButton3.IconChar = FontAwesome.Sharp.IconChar.SignOut
        IconButton3.IconColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        IconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton3.IconSize = 32
        IconButton3.Location = New Point(10, 15)
        IconButton3.Name = "IconButton3"
        IconButton3.Size = New Size(80, 50)
        IconButton3.TabIndex = 1
        IconButton3.UseVisualStyleBackColor = False
        ' 
        ' SettingsBtn
        ' 
        SettingsBtn.BackColor = Color.Transparent
        SettingsBtn.Cursor = Cursors.Hand
        SettingsBtn.Dock = DockStyle.Right
        SettingsBtn.FlatAppearance.BorderSize = 0
        SettingsBtn.FlatStyle = FlatStyle.Flat
        SettingsBtn.IconChar = FontAwesome.Sharp.IconChar.Cog
        SettingsBtn.IconColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        SettingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SettingsBtn.IconSize = 32
        SettingsBtn.Location = New Point(90, 15)
        SettingsBtn.Name = "SettingsBtn"
        SettingsBtn.Size = New Size(80, 50)
        SettingsBtn.TabIndex = 0
        SettingsBtn.UseVisualStyleBackColor = False
        ' 
        ' pnlSearch
        ' 
        pnlSearch.Controls.Add(SearchTxtBox)
        pnlSearch.Controls.Add(SearchBtn)
        pnlSearch.Dock = DockStyle.Left
        pnlSearch.Location = New Point(0, 0)
        pnlSearch.Name = "pnlSearch"
        pnlSearch.Padding = New Padding(30, 20, 20, 20)
        pnlSearch.Size = New Size(500, 80)
        pnlSearch.TabIndex = 0
        ' 
        ' SearchTxtBox
        ' 
        SearchTxtBox.Dock = DockStyle.Fill
        SearchTxtBox.Font = New Font("Segoe UI", 12.0F)
        SearchTxtBox.Location = New Point(30, 20)
        SearchTxtBox.Name = "SearchTxtBox"
        SearchTxtBox.PlaceholderText = "Search menu items..."
        SearchTxtBox.Size = New Size(350, 34)
        SearchTxtBox.TabIndex = 0
        ' 
        ' SearchBtn
        ' 
        SearchBtn.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        SearchBtn.Cursor = Cursors.Hand
        SearchBtn.Dock = DockStyle.Right
        SearchBtn.FlatAppearance.BorderSize = 0
        SearchBtn.FlatStyle = FlatStyle.Flat
        SearchBtn.IconChar = FontAwesome.Sharp.IconChar.Search
        SearchBtn.IconColor = Color.White
        SearchBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SearchBtn.IconSize = 24
        SearchBtn.Location = New Point(380, 20)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.Size = New Size(100, 40)
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
        pnlOrderSidebar.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlOrderSidebar.Controls.Add(OrderPnl)
        pnlOrderSidebar.Controls.Add(pnlTotal)
        pnlOrderSidebar.Dock = DockStyle.Left
        pnlOrderSidebar.Location = New Point(0, 80)
        pnlOrderSidebar.Name = "pnlOrderSidebar"
        pnlOrderSidebar.Size = New Size(450, 920)
        pnlOrderSidebar.TabIndex = 1
        ' 
        ' OrderPnl
        ' 
        OrderPnl.AutoScroll = True
        OrderPnl.BackColor = Color.White
        OrderPnl.Dock = DockStyle.Fill
        OrderPnl.FlowDirection = FlowDirection.TopDown
        OrderPnl.Location = New Point(0, 0)
        OrderPnl.Name = "OrderPnl"
        OrderPnl.Padding = New Padding(10)
        OrderPnl.Size = New Size(450, 700)
        OrderPnl.TabIndex = 0
        OrderPnl.WrapContents = False
        ' 
        ' pnlTotal
        ' 
        pnlTotal.BackColor = Color.White
        pnlTotal.BorderStyle = BorderStyle.FixedSingle
        pnlTotal.Controls.Add(pnlTotalValues)
        pnlTotal.Dock = DockStyle.Bottom
        pnlTotal.Location = New Point(0, 700)
        pnlTotal.Name = "pnlTotal"
        pnlTotal.Padding = New Padding(20)
        pnlTotal.Size = New Size(450, 220)
        pnlTotal.TabIndex = 1
        ' 
        ' pnlTotalValues
        ' 
        pnlTotalValues.Controls.Add(TotalLbl)
        pnlTotalValues.Controls.Add(Label2)
        pnlTotalValues.Controls.Add(DiscountLbl)
        pnlTotalValues.Controls.Add(Label3)
        pnlTotalValues.Controls.Add(SubtotalLbl)
        pnlTotalValues.Controls.Add(Label6)
        pnlTotalValues.Dock = DockStyle.Fill
        pnlTotalValues.Location = New Point(20, 20)
        pnlTotalValues.Name = "pnlTotalValues"
        pnlTotalValues.Size = New Size(408, 178)
        pnlTotalValues.TabIndex = 0
        ' 
        ' TotalLbl
        ' 
        TotalLbl.AutoSize = True
        TotalLbl.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        TotalLbl.ForeColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        TotalLbl.Location = New Point(260, 105)
        TotalLbl.Name = "TotalLbl"
        TotalLbl.Size = New Size(62, 46)
        TotalLbl.TabIndex = 5
        TotalLbl.Text = "₱0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        Label2.ForeColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        Label2.Location = New Point(10, 110)
        Label2.Name = "Label2"
        Label2.Size = New Size(82, 37)
        Label2.TabIndex = 4
        Label2.Text = "Total"
        ' 
        ' DiscountLbl
        ' 
        DiscountLbl.AutoSize = True
        DiscountLbl.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        DiscountLbl.ForeColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        DiscountLbl.Location = New Point(300, 50)
        DiscountLbl.Name = "DiscountLbl"
        DiscountLbl.Size = New Size(41, 28)
        DiscountLbl.TabIndex = 3
        DiscountLbl.Text = "%0"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12.0F)
        Label3.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label3.Location = New Point(10, 50)
        Label3.Name = "Label3"
        Label3.Size = New Size(89, 28)
        Label3.TabIndex = 2
        Label3.Text = "Discount"
        ' 
        ' SubtotalLbl
        ' 
        SubtotalLbl.AutoSize = True
        SubtotalLbl.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        SubtotalLbl.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        SubtotalLbl.Location = New Point(300, 10)
        SubtotalLbl.Name = "SubtotalLbl"
        SubtotalLbl.Size = New Size(37, 28)
        SubtotalLbl.TabIndex = 1
        SubtotalLbl.Text = "₱0"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12.0F)
        Label6.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label6.Location = New Point(10, 10)
        Label6.Name = "Label6"
        Label6.Size = New Size(87, 28)
        Label6.TabIndex = 0
        Label6.Text = "Subtotal"
        ' 
        ' pnlMenu
        ' 
        pnlMenu.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlMenu.Controls.Add(FoodPnl)
        pnlMenu.Controls.Add(pnlMenuActions)
        pnlMenu.Controls.Add(MenuCategoryPnl)
        pnlMenu.Dock = DockStyle.Fill
        pnlMenu.Location = New Point(450, 80)
        pnlMenu.Name = "pnlMenu"
        pnlMenu.Size = New Size(1150, 920)
        pnlMenu.TabIndex = 2
        ' 
        ' FoodPnl
        ' 
        FoodPnl.AutoScroll = True
        FoodPnl.BackColor = Color.White
        FoodPnl.Dock = DockStyle.Fill
        FoodPnl.Location = New Point(0, 70)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Padding = New Padding(20)
        FoodPnl.Size = New Size(1150, 730)
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
        pnlMenuActions.Location = New Point(0, 800)
        pnlMenuActions.Name = "pnlMenuActions"
        pnlMenuActions.Padding = New Padding(20, 15, 20, 15)
        pnlMenuActions.Size = New Size(1150, 120)
        pnlMenuActions.TabIndex = 2
        ' 
        ' IconButton2
        ' 
        IconButton2.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        IconButton2.Cursor = Cursors.Hand
        IconButton2.FlatAppearance.BorderSize = 0
        IconButton2.FlatStyle = FlatStyle.Flat
        IconButton2.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        IconButton2.ForeColor = Color.White
        IconButton2.IconChar = FontAwesome.Sharp.IconChar.Keyboard
        IconButton2.IconColor = Color.White
        IconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton2.IconSize = 24
        IconButton2.ImageAlign = ContentAlignment.MiddleLeft
        IconButton2.Location = New Point(770, 30)
        IconButton2.Name = "IconButton2"
        IconButton2.Padding = New Padding(5, 0, 5, 0)
        IconButton2.Size = New Size(170, 55)
        IconButton2.TabIndex = 4
        IconButton2.Text = "Shortcut Keys"
        IconButton2.TextAlign = ContentAlignment.MiddleRight
        IconButton2.TextImageRelation = TextImageRelation.ImageBeforeText
        IconButton2.UseVisualStyleBackColor = False
        ' 
        ' RecentOrdersBtn
        ' 
        RecentOrdersBtn.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        RecentOrdersBtn.Cursor = Cursors.Hand
        RecentOrdersBtn.FlatAppearance.BorderSize = 0
        RecentOrdersBtn.FlatStyle = FlatStyle.Flat
        RecentOrdersBtn.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        RecentOrdersBtn.ForeColor = Color.White
        RecentOrdersBtn.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft
        RecentOrdersBtn.IconColor = Color.White
        RecentOrdersBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        RecentOrdersBtn.IconSize = 24
        RecentOrdersBtn.ImageAlign = ContentAlignment.MiddleLeft
        RecentOrdersBtn.Location = New Point(580, 30)
        RecentOrdersBtn.Name = "RecentOrdersBtn"
        RecentOrdersBtn.Padding = New Padding(5, 0, 5, 0)
        RecentOrdersBtn.Size = New Size(170, 55)
        RecentOrdersBtn.TabIndex = 3
        RecentOrdersBtn.Text = "Recent Orders"
        RecentOrdersBtn.TextAlign = ContentAlignment.MiddleRight
        RecentOrdersBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        RecentOrdersBtn.UseVisualStyleBackColor = False
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        CancelBtn.Cursor = Cursors.Hand
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        CancelBtn.ForeColor = Color.White
        CancelBtn.IconChar = FontAwesome.Sharp.IconChar.Close
        CancelBtn.IconColor = Color.White
        CancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CancelBtn.IconSize = 24
        CancelBtn.ImageAlign = ContentAlignment.MiddleLeft
        CancelBtn.Location = New Point(400, 30)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Padding = New Padding(5, 0, 5, 0)
        CancelBtn.Size = New Size(160, 55)
        CancelBtn.TabIndex = 2
        CancelBtn.Text = "Cancel Order"
        CancelBtn.TextAlign = ContentAlignment.MiddleRight
        CancelBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' DiscountBtn
        ' 
        DiscountBtn.BackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        DiscountBtn.Cursor = Cursors.Hand
        DiscountBtn.FlatAppearance.BorderSize = 0
        DiscountBtn.FlatStyle = FlatStyle.Flat
        DiscountBtn.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        DiscountBtn.ForeColor = Color.White
        DiscountBtn.Location = New Point(220, 30)
        DiscountBtn.Name = "DiscountBtn"
        DiscountBtn.Size = New Size(160, 55)
        DiscountBtn.TabIndex = 1
        DiscountBtn.Text = "Apply Discount"
        DiscountBtn.UseVisualStyleBackColor = False
        ' 
        ' CreateOrderBtn
        ' 
        CreateOrderBtn.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        CreateOrderBtn.Cursor = Cursors.Hand
        CreateOrderBtn.FlatAppearance.BorderSize = 0
        CreateOrderBtn.FlatStyle = FlatStyle.Flat
        CreateOrderBtn.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        CreateOrderBtn.ForeColor = Color.White
        CreateOrderBtn.IconChar = FontAwesome.Sharp.IconChar.CheckCircle
        CreateOrderBtn.IconColor = Color.White
        CreateOrderBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CreateOrderBtn.IconSize = 28
        CreateOrderBtn.ImageAlign = ContentAlignment.MiddleLeft
        CreateOrderBtn.Location = New Point(20, 30)
        CreateOrderBtn.Name = "CreateOrderBtn"
        CreateOrderBtn.Padding = New Padding(10, 0, 10, 0)
        CreateOrderBtn.Size = New Size(180, 55)
        CreateOrderBtn.TabIndex = 0
        CreateOrderBtn.Text = "Create Order"
        CreateOrderBtn.TextAlign = ContentAlignment.MiddleRight
        CreateOrderBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        CreateOrderBtn.UseVisualStyleBackColor = False
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.BackColor = Color.White
        MenuCategoryPnl.Dock = DockStyle.Top
        MenuCategoryPnl.Location = New Point(0, 0)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(15, 10, 15, 10)
        MenuCategoryPnl.Size = New Size(1150, 70)
        MenuCategoryPnl.TabIndex = 0
        ' 
        ' Order
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(1600, 1000)
        Controls.Add(pnlMenu)
        Controls.Add(pnlOrderSidebar)
        Controls.Add(pnlHeader)
        Controls.Add(DataGridView1)
        Font = New Font("Segoe UI", 9.0F)
        Name = "Order"
        Text = "Order - OrderUp!"
        pnlHeader.ResumeLayout(False)
        pnlHeaderActions.ResumeLayout(False)
        pnlSearch.ResumeLayout(False)
        pnlSearch.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        pnlOrderSidebar.ResumeLayout(False)
        pnlTotal.ResumeLayout(False)
        pnlTotalValues.ResumeLayout(False)
        pnlTotalValues.PerformLayout()
        pnlMenu.ResumeLayout(False)
        pnlMenuActions.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents SearchTxtBox As TextBox
    Friend WithEvents SearchBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlHeaderActions As Panel
    Friend WithEvents SettingsBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents pnlOrderSidebar As Panel
    Friend WithEvents OrderPnl As FlowLayoutPanel
    Friend WithEvents pnlTotal As Panel
    Friend WithEvents pnlTotalValues As Panel
    Friend WithEvents TotalLbl As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DiscountLbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SubtotalLbl As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents pnlMenuActions As Panel
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents RecentOrdersBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents CancelBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents DiscountBtn As Button
    Friend WithEvents CreateOrderBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
End Class