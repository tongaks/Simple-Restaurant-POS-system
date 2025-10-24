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
        PictureBox1 = New PictureBox()
        IconButton3 = New FontAwesome.Sharp.IconButton()
        SearchBtn = New FontAwesome.Sharp.IconButton()
        DataGridView1 = New DataGridView()
        SearchTxtBox = New TextBox()
        Label1 = New Label()
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
        Panel2 = New Panel()
        TotalPnl = New Panel()
        Panel4 = New Panel()
        SubtotalLbl = New Label()
        Label6 = New Label()
        Panel3 = New Panel()
        TotalLbl = New Label()
        Label2 = New Label()
        DiscountLbl = New Label()
        Label3 = New Label()
        OrderPnl = New FlowLayoutPanel()
        NavbarPnl.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CurrentFocusedPnl.SuspendLayout()
        Panel2.SuspendLayout()
        TotalPnl.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' NavbarPnl
        ' 
        NavbarPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        NavbarPnl.BackColor = Color.SteelBlue
        NavbarPnl.Controls.Add(PictureBox1)
        NavbarPnl.Controls.Add(IconButton3)
        NavbarPnl.Controls.Add(SearchBtn)
        NavbarPnl.Controls.Add(DataGridView1)
        NavbarPnl.Controls.Add(SearchTxtBox)
        NavbarPnl.Controls.Add(Label1)
        NavbarPnl.Location = New Point(0, 0)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(1213, 68)
        NavbarPnl.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.BOLD_removebg_preview
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(117, 67)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' IconButton3
        ' 
        IconButton3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        IconButton3.BackColor = Color.DarkRed
        IconButton3.FlatAppearance.BorderColor = Color.Black
        IconButton3.FlatStyle = FlatStyle.Flat
        IconButton3.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        IconButton3.ForeColor = SystemColors.ControlLightLight
        IconButton3.IconChar = FontAwesome.Sharp.IconChar.SignOut
        IconButton3.IconColor = Color.WhiteSmoke
        IconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton3.IconSize = 30
        IconButton3.ImageAlign = ContentAlignment.MiddleLeft
        IconButton3.Location = New Point(1108, 15)
        IconButton3.Name = "IconButton3"
        IconButton3.Size = New Size(92, 36)
        IconButton3.TabIndex = 2
        IconButton3.Text = "Logout"
        IconButton3.TextAlign = ContentAlignment.MiddleRight
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
        SearchBtn.Location = New Point(874, 15)
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
        DataGridView1.Location = New Point(903, 28)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(29, 10)
        DataGridView1.TabIndex = 1
        DataGridView1.Visible = False
        ' 
        ' SearchTxtBox
        ' 
        SearchTxtBox.Font = New Font("Segoe UI", 15F)
        SearchTxtBox.Location = New Point(533, 16)
        SearchTxtBox.Name = "SearchTxtBox"
        SearchTxtBox.Size = New Size(316, 34)
        SearchTxtBox.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlLightLight
        Label1.Location = New Point(457, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(72, 28)
        Label1.TabIndex = 6
        Label1.Text = "Search"
        ' 
        ' CreateOrderBtn
        ' 
        CreateOrderBtn.BackColor = Color.SpringGreen
        CreateOrderBtn.FlatStyle = FlatStyle.Flat
        CreateOrderBtn.IconChar = FontAwesome.Sharp.IconChar.CheckCircle
        CreateOrderBtn.IconColor = Color.Black
        CreateOrderBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CreateOrderBtn.IconSize = 35
        CreateOrderBtn.ImageAlign = ContentAlignment.MiddleLeft
        CreateOrderBtn.Location = New Point(15, 42)
        CreateOrderBtn.Name = "CreateOrderBtn"
        CreateOrderBtn.Size = New Size(123, 38)
        CreateOrderBtn.TabIndex = 1
        CreateOrderBtn.Text = "Create order"
        CreateOrderBtn.TextAlign = ContentAlignment.MiddleRight
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
        Panel1.Size = New Size(743, 645)
        Panel1.TabIndex = 5
        ' 
        ' CurrentFocusedPnl
        ' 
        CurrentFocusedPnl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        CurrentFocusedPnl.BackColor = SystemColors.ControlLightLight
        CurrentFocusedPnl.Controls.Add(Label8)
        CurrentFocusedPnl.Controls.Add(RecentOrdersBtn)
        CurrentFocusedPnl.Controls.Add(Label7)
        CurrentFocusedPnl.Controls.Add(Label5)
        CurrentFocusedPnl.Controls.Add(Label4)
        CurrentFocusedPnl.Controls.Add(IconButton2)
        CurrentFocusedPnl.Controls.Add(CancelBtn)
        CurrentFocusedPnl.Controls.Add(CreateOrderBtn)
        CurrentFocusedPnl.Controls.Add(DiscountBtn)
        CurrentFocusedPnl.Location = New Point(2, 543)
        CurrentFocusedPnl.Name = "CurrentFocusedPnl"
        CurrentFocusedPnl.Size = New Size(743, 102)
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
        RecentOrdersBtn.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft
        RecentOrdersBtn.IconColor = Color.Black
        RecentOrdersBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        RecentOrdersBtn.IconSize = 30
        RecentOrdersBtn.ImageAlign = ContentAlignment.MiddleLeft
        RecentOrdersBtn.Location = New Point(433, 42)
        RecentOrdersBtn.Name = "RecentOrdersBtn"
        RecentOrdersBtn.Size = New Size(121, 36)
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
        MenuCategoryPnl.BackColor = SystemColors.ControlLightLight
        MenuCategoryPnl.Location = New Point(3, 8)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(0, 0, 0, 20)
        MenuCategoryPnl.Size = New Size(742, 89)
        MenuCategoryPnl.TabIndex = 1
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.AutoScroll = True
        FoodPnl.BackColor = Color.WhiteSmoke
        FoodPnl.Location = New Point(2, 103)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Padding = New Padding(10)
        FoodPnl.Size = New Size(740, 434)
        FoodPnl.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel2.BackColor = SystemColors.Control
        Panel2.Controls.Add(TotalPnl)
        Panel2.Controls.Add(OrderPnl)
        Panel2.Location = New Point(12, 74)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(440, 637)
        Panel2.TabIndex = 6
        ' 
        ' TotalPnl
        ' 
        TotalPnl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        TotalPnl.BackColor = SystemColors.ControlLightLight
        TotalPnl.BorderStyle = BorderStyle.FixedSingle
        TotalPnl.Controls.Add(Panel4)
        TotalPnl.Controls.Add(Panel3)
        TotalPnl.Controls.Add(DiscountLbl)
        TotalPnl.Controls.Add(Label3)
        TotalPnl.Location = New Point(30, 496)
        TotalPnl.Name = "TotalPnl"
        TotalPnl.Size = New Size(386, 129)
        TotalPnl.TabIndex = 4
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.ControlLightLight
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(SubtotalLbl)
        Panel4.Controls.Add(Label6)
        Panel4.Location = New Point(-1, -1)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(386, 41)
        Panel4.TabIndex = 9
        ' 
        ' SubtotalLbl
        ' 
        SubtotalLbl.AutoSize = True
        SubtotalLbl.Font = New Font("Segoe UI", 15F)
        SubtotalLbl.Location = New Point(304, 3)
        SubtotalLbl.Name = "SubtotalLbl"
        SubtotalLbl.Size = New Size(35, 28)
        SubtotalLbl.TabIndex = 9
        SubtotalLbl.Text = "₱0"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 15F)
        Label6.Location = New Point(20, 3)
        Label6.Name = "Label6"
        Label6.Size = New Size(87, 28)
        Label6.TabIndex = 8
        Label6.Text = "Subtotal"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.SteelBlue
        Panel3.Controls.Add(TotalLbl)
        Panel3.Controls.Add(Label2)
        Panel3.Location = New Point(-1, 78)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(386, 50)
        Panel3.TabIndex = 8
        ' 
        ' TotalLbl
        ' 
        TotalLbl.AutoSize = True
        TotalLbl.Font = New Font("Segoe UI", 20F)
        TotalLbl.ForeColor = SystemColors.ControlLightLight
        TotalLbl.Location = New Point(298, 7)
        TotalLbl.Name = "TotalLbl"
        TotalLbl.Size = New Size(48, 37)
        TotalLbl.TabIndex = 3
        TotalLbl.Text = "₱0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F)
        Label2.ForeColor = SystemColors.ControlLightLight
        Label2.Location = New Point(29, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 37)
        Label2.TabIndex = 2
        Label2.Text = "Total"
        ' 
        ' DiscountLbl
        ' 
        DiscountLbl.AutoSize = True
        DiscountLbl.Font = New Font("Segoe UI", 15F)
        DiscountLbl.ForeColor = Color.Red
        DiscountLbl.Location = New Point(300, 43)
        DiscountLbl.Name = "DiscountLbl"
        DiscountLbl.Size = New Size(39, 28)
        DiscountLbl.TabIndex = 4
        DiscountLbl.Text = "%0"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 15F)
        Label3.Location = New Point(18, 43)
        Label3.Name = "Label3"
        Label3.Size = New Size(89, 28)
        Label3.TabIndex = 3
        Label3.Text = "Discount"
        ' 
        ' OrderPnl
        ' 
        OrderPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        OrderPnl.AutoScroll = True
        OrderPnl.BackColor = SystemColors.ControlLightLight
        OrderPnl.FlowDirection = FlowDirection.TopDown
        OrderPnl.Location = New Point(0, 0)
        OrderPnl.Name = "OrderPnl"
        OrderPnl.Size = New Size(443, 478)
        OrderPnl.TabIndex = 7
        OrderPnl.WrapContents = False
        ' 
        ' Order
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1213, 723)
        Controls.Add(Panel2)
        Controls.Add(NavbarPnl)
        Controls.Add(Panel1)
        Name = "Order"
        Text = "Order form"
        NavbarPnl.ResumeLayout(False)
        NavbarPnl.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        CurrentFocusedPnl.ResumeLayout(False)
        CurrentFocusedPnl.PerformLayout()
        Panel2.ResumeLayout(False)
        TotalPnl.ResumeLayout(False)
        TotalPnl.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents NavbarPnl As Panel
    Friend WithEvents TestTable As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents SearchTxtBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DiscountBtn As Button
    Friend WithEvents CreateOrderBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents SearchBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents CurrentFocusedPnl As Panel
    Friend WithEvents CancelBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents RecentOrdersBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents OrderPnl As FlowLayoutPanel
    Friend WithEvents TotalPnl As Panel
    Friend WithEvents DiscountLbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TotalLbl As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents SubtotalLbl As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
