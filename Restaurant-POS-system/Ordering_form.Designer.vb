<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Order
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        NavbarPnl = New Panel()
        IconButton3 = New FontAwesome.Sharp.IconButton()
        SearchBtn = New FontAwesome.Sharp.IconButton()
        DataGridView1 = New DataGridView()
        SettingsBtn = New FontAwesome.Sharp.IconButton()
        SearchTxtBox = New TextBox()
        Label1 = New Label()
        TotalPnl = New Panel()
        SubtotalLbl = New Label()
        Label6 = New Label()
        DiscountLbl = New Label()
        Label3 = New Label()
        TotalLbl = New Label()
        Label2 = New Label()
        CreateOrderBtn = New FontAwesome.Sharp.IconButton()
        DiscountBtn = New Button()
        Panel1 = New Panel()
        CurrentFocusedPnl = New Panel()
        Label8 = New Label()
        RecentOrdersBtn = New FontAwesome.Sharp.IconButton()
        Label7 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        IconButton2 = New FontAwesome.Sharp.IconButton()
        CancelBtn = New FontAwesome.Sharp.IconButton()
        MenuCategoryPnl = New FlowLayoutPanel()
        FoodPnl = New FlowLayoutPanel()
        OrderPnl = New FlowLayoutPanel()
        NavbarPnl.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TotalPnl.SuspendLayout()
        Panel1.SuspendLayout()
        CurrentFocusedPnl.SuspendLayout()
        SuspendLayout()
        ' 
        ' NavbarPnl
        ' 
        NavbarPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        NavbarPnl.BackColor = Color.DarkSeaGreen
        NavbarPnl.Controls.Add(IconButton3)
        NavbarPnl.Controls.Add(SearchBtn)
        NavbarPnl.Controls.Add(DataGridView1)
        NavbarPnl.Controls.Add(SettingsBtn)
        NavbarPnl.Controls.Add(SearchTxtBox)
        NavbarPnl.Controls.Add(Label1)
        NavbarPnl.Location = New Point(458, 0)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(703, 68)
        NavbarPnl.TabIndex = 1
        ' 
        ' IconButton3
        ' 
        IconButton3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        IconButton3.BackColor = Color.DarkSeaGreen
        IconButton3.FlatAppearance.BorderSize = 0
        IconButton3.FlatStyle = FlatStyle.Flat
        IconButton3.IconChar = FontAwesome.Sharp.IconChar.SignOut
        IconButton3.IconColor = Color.Black
        IconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton3.IconSize = 40
        IconButton3.Location = New Point(599, 16)
        IconButton3.Name = "IconButton3"
        IconButton3.Size = New Size(43, 42)
        IconButton3.TabIndex = 2
        IconButton3.UseVisualStyleBackColor = False
        ' 
        ' SearchBtn
        ' 
        SearchBtn.BackColor = Color.SpringGreen
        SearchBtn.FlatStyle = FlatStyle.Flat
        SearchBtn.IconChar = FontAwesome.Sharp.IconChar.Search
        SearchBtn.IconColor = Color.Black
        SearchBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SearchBtn.IconSize = 30
        SearchBtn.ImageAlign = ContentAlignment.MiddleLeft
        SearchBtn.Location = New Point(352, 19)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.Size = New Size(79, 36)
        SearchBtn.TabIndex = 8
        SearchBtn.Text = "Search"
        SearchBtn.TextAlign = ContentAlignment.MiddleRight
        SearchBtn.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(444, 11)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(29, 49)
        DataGridView1.TabIndex = 1
        DataGridView1.Visible = False
        ' 
        ' SettingsBtn
        ' 
        SettingsBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SettingsBtn.BackColor = Color.DarkSeaGreen
        SettingsBtn.FlatAppearance.BorderSize = 0
        SettingsBtn.FlatStyle = FlatStyle.Flat
        SettingsBtn.IconChar = FontAwesome.Sharp.IconChar.Cog
        SettingsBtn.IconColor = Color.Black
        SettingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SettingsBtn.IconSize = 40
        SettingsBtn.Location = New Point(648, 16)
        SettingsBtn.Name = "SettingsBtn"
        SettingsBtn.Size = New Size(43, 42)
        SettingsBtn.TabIndex = 1
        SettingsBtn.UseVisualStyleBackColor = False
        ' 
        ' SearchTxtBox
        ' 
        SearchTxtBox.Font = New Font("Segoe UI", 15F)
        SearchTxtBox.Location = New Point(80, 19)
        SearchTxtBox.Name = "SearchTxtBox"
        SearchTxtBox.Size = New Size(255, 34)
        SearchTxtBox.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(17, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 21)
        Label1.TabIndex = 6
        Label1.Text = "Search"
        ' 
        ' TotalPnl
        ' 
        TotalPnl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        TotalPnl.BackColor = SystemColors.ControlLight
        TotalPnl.BorderStyle = BorderStyle.FixedSingle
        TotalPnl.Controls.Add(SubtotalLbl)
        TotalPnl.Controls.Add(Label6)
        TotalPnl.Controls.Add(DiscountLbl)
        TotalPnl.Controls.Add(Label3)
        TotalPnl.Controls.Add(TotalLbl)
        TotalPnl.Controls.Add(Label2)
        TotalPnl.Location = New Point(0, 475)
        TotalPnl.Name = "TotalPnl"
        TotalPnl.Size = New Size(452, 129)
        TotalPnl.TabIndex = 4
        ' 
        ' SubtotalLbl
        ' 
        SubtotalLbl.AutoSize = True
        SubtotalLbl.Font = New Font("Segoe UI", 15F)
        SubtotalLbl.Location = New Point(354, 10)
        SubtotalLbl.Name = "SubtotalLbl"
        SubtotalLbl.Size = New Size(35, 28)
        SubtotalLbl.TabIndex = 7
        SubtotalLbl.Text = "₱0"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 15F)
        Label6.Location = New Point(18, 10)
        Label6.Name = "Label6"
        Label6.Size = New Size(87, 28)
        Label6.TabIndex = 6
        Label6.Text = "Subtotal"
        ' 
        ' DiscountLbl
        ' 
        DiscountLbl.AutoSize = True
        DiscountLbl.Font = New Font("Segoe UI", 15F)
        DiscountLbl.Location = New Point(354, 42)
        DiscountLbl.Name = "DiscountLbl"
        DiscountLbl.Size = New Size(39, 28)
        DiscountLbl.TabIndex = 4
        DiscountLbl.Text = "%0"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 15F)
        Label3.Location = New Point(18, 40)
        Label3.Name = "Label3"
        Label3.Size = New Size(89, 28)
        Label3.TabIndex = 3
        Label3.Text = "Discount"
        ' 
        ' TotalLbl
        ' 
        TotalLbl.AutoSize = True
        TotalLbl.Font = New Font("Segoe UI", 20F)
        TotalLbl.Location = New Point(350, 72)
        TotalLbl.Name = "TotalLbl"
        TotalLbl.Size = New Size(48, 37)
        TotalLbl.TabIndex = 1
        TotalLbl.Text = "₱0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F)
        Label2.Location = New Point(15, 72)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 37)
        Label2.TabIndex = 0
        Label2.Text = "Total"
        ' 
        ' CreateOrderBtn
        ' 
        CreateOrderBtn.BackColor = Color.SpringGreen
        CreateOrderBtn.FlatStyle = FlatStyle.Flat
        CreateOrderBtn.IconChar = FontAwesome.Sharp.IconChar.ArrowRight
        CreateOrderBtn.IconColor = Color.Black
        CreateOrderBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CreateOrderBtn.IconSize = 40
        CreateOrderBtn.ImageAlign = ContentAlignment.MiddleRight
        CreateOrderBtn.Location = New Point(15, 42)
        CreateOrderBtn.Name = "CreateOrderBtn"
        CreateOrderBtn.Size = New Size(123, 38)
        CreateOrderBtn.TabIndex = 1
        CreateOrderBtn.Text = "Create order"
        CreateOrderBtn.TextAlign = ContentAlignment.MiddleLeft
        CreateOrderBtn.UseVisualStyleBackColor = False
        ' 
        ' DiscountBtn
        ' 
        DiscountBtn.BackColor = Color.Gold
        DiscountBtn.FlatStyle = FlatStyle.Flat
        DiscountBtn.Location = New Point(157, 42)
        DiscountBtn.Name = "DiscountBtn"
        DiscountBtn.Size = New Size(123, 38)
        DiscountBtn.TabIndex = 5
        DiscountBtn.Text = "Apply discount"
        DiscountBtn.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.DarkGray
        Panel1.Controls.Add(CurrentFocusedPnl)
        Panel1.Controls.Add(MenuCategoryPnl)
        Panel1.Controls.Add(FoodPnl)
        Panel1.Location = New Point(458, 66)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(704, 538)
        Panel1.TabIndex = 5
        ' 
        ' CurrentFocusedPnl
        ' 
        CurrentFocusedPnl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        CurrentFocusedPnl.BackColor = SystemColors.ControlLight
        CurrentFocusedPnl.Controls.Add(Label8)
        CurrentFocusedPnl.Controls.Add(RecentOrdersBtn)
        CurrentFocusedPnl.Controls.Add(Label7)
        CurrentFocusedPnl.Controls.Add(Label5)
        CurrentFocusedPnl.Controls.Add(Label4)
        CurrentFocusedPnl.Controls.Add(IconButton2)
        CurrentFocusedPnl.Controls.Add(CancelBtn)
        CurrentFocusedPnl.Controls.Add(CreateOrderBtn)
        CurrentFocusedPnl.Controls.Add(DiscountBtn)
        CurrentFocusedPnl.Location = New Point(2, 436)
        CurrentFocusedPnl.Name = "CurrentFocusedPnl"
        CurrentFocusedPnl.Size = New Size(704, 102)
        CurrentFocusedPnl.TabIndex = 0
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 15F)
        Label8.Location = New Point(456, 10)
        Label8.Name = "Label8"
        Label8.Size = New Size(82, 28)
        Label8.TabIndex = 14
        Label8.Text = "Ctrl + O"
        ' 
        ' RecentOrdersBtn
        ' 
        RecentOrdersBtn.BackColor = Color.CornflowerBlue
        RecentOrdersBtn.FlatStyle = FlatStyle.Flat
        RecentOrdersBtn.IconChar = FontAwesome.Sharp.IconChar.Buffer
        RecentOrdersBtn.IconColor = Color.Black
        RecentOrdersBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        RecentOrdersBtn.IconSize = 30
        RecentOrdersBtn.ImageAlign = ContentAlignment.MiddleLeft
        RecentOrdersBtn.Location = New Point(440, 42)
        RecentOrdersBtn.Name = "RecentOrdersBtn"
        RecentOrdersBtn.Size = New Size(114, 36)
        RecentOrdersBtn.TabIndex = 13
        RecentOrdersBtn.Text = "Recent orders"
        RecentOrdersBtn.TextAlign = ContentAlignment.MiddleRight
        RecentOrdersBtn.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 15F)
        Label7.Location = New Point(176, 11)
        Label7.Name = "Label7"
        Label7.Size = New Size(81, 28)
        Label7.TabIndex = 12
        Label7.Text = "Ctrl + D"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 15F)
        Label5.Location = New Point(317, 11)
        Label5.Name = "Label5"
        Label5.Size = New Size(79, 28)
        Label5.TabIndex = 11
        Label5.Text = "Ctrl + C"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 15F)
        Label4.Location = New Point(21, 11)
        Label4.Name = "Label4"
        Label4.Size = New Size(112, 28)
        Label4.TabIndex = 8
        Label4.Text = "Ctrl + Enter"
        ' 
        ' IconButton2
        ' 
        IconButton2.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        IconButton2.FlatStyle = FlatStyle.Flat
        IconButton2.IconChar = FontAwesome.Sharp.IconChar.Keyboard
        IconButton2.IconColor = Color.Black
        IconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton2.IconSize = 30
        IconButton2.ImageAlign = ContentAlignment.MiddleLeft
        IconButton2.Location = New Point(575, 42)
        IconButton2.Name = "IconButton2"
        IconButton2.Size = New Size(114, 36)
        IconButton2.TabIndex = 10
        IconButton2.Text = "Shortcut keys"
        IconButton2.TextAlign = ContentAlignment.MiddleRight
        IconButton2.UseVisualStyleBackColor = False
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.DarkGray
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.IconChar = FontAwesome.Sharp.IconChar.Cancel
        CancelBtn.IconColor = Color.Black
        CancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CancelBtn.IconSize = 30
        CancelBtn.ImageAlign = ContentAlignment.MiddleLeft
        CancelBtn.Location = New Point(301, 42)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(114, 36)
        CancelBtn.TabIndex = 9
        CancelBtn.Text = "Cancel order"
        CancelBtn.TextAlign = ContentAlignment.MiddleRight
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        MenuCategoryPnl.BackColor = Color.WhiteSmoke
        MenuCategoryPnl.Location = New Point(3, 3)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(0, 0, 0, 20)
        MenuCategoryPnl.Size = New Size(703, 60)
        MenuCategoryPnl.TabIndex = 1
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.AutoScroll = True
        FoodPnl.BackColor = SystemColors.Control
        FoodPnl.Location = New Point(2, 60)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Size = New Size(701, 381)
        FoodPnl.TabIndex = 2
        ' 
        ' OrderPnl
        ' 
        OrderPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        OrderPnl.AutoScroll = True
        OrderPnl.BackColor = SystemColors.Control
        OrderPnl.FlowDirection = FlowDirection.TopDown
        OrderPnl.Location = New Point(0, 0)
        OrderPnl.Name = "OrderPnl"
        OrderPnl.Size = New Size(452, 478)
        OrderPnl.TabIndex = 6
        OrderPnl.WrapContents = False
        ' 
        ' Order
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1161, 604)
        Controls.Add(OrderPnl)
        Controls.Add(NavbarPnl)
        Controls.Add(Panel1)
        Controls.Add(TotalPnl)
        Name = "Order"
        Text = "Order form"
        NavbarPnl.ResumeLayout(False)
        NavbarPnl.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        TotalPnl.ResumeLayout(False)
        TotalPnl.PerformLayout()
        Panel1.ResumeLayout(False)
        CurrentFocusedPnl.ResumeLayout(False)
        CurrentFocusedPnl.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents NavbarPnl As Panel
    Friend WithEvents TotalPnl As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TotalLbl As Label
    Friend WithEvents TestTable As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents SearchTxtBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents OrderPnl As FlowLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents DiscountBtn As Button
    Friend WithEvents DiscountLbl As Label
    Friend WithEvents CreateOrderBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents SearchBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents SettingsBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents SubtotalLbl As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents CurrentFocusedPnl As Panel
    Friend WithEvents CancelBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents RecentOrdersBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents Label8 As Label
End Class
