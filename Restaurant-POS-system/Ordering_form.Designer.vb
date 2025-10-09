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
        IconButton2 = New FontAwesome.Sharp.IconButton()
        SearchTxtBox = New TextBox()
        Label1 = New Label()
        DataGridView1 = New DataGridView()
        TotalPnl = New Panel()
        CreateOrderBtn = New FontAwesome.Sharp.IconButton()
        Button1 = New Button()
        Label4 = New Label()
        Label3 = New Label()
        TotalLbl = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
        MenuCategoryPnl = New FlowLayoutPanel()
        FoodPnl = New FlowLayoutPanel()
        OrderPnl = New FlowLayoutPanel()
        NavbarPnl.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TotalPnl.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' NavbarPnl
        ' 
        NavbarPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        NavbarPnl.BackColor = Color.DarkSeaGreen
        NavbarPnl.Controls.Add(IconButton3)
        NavbarPnl.Controls.Add(SearchBtn)
        NavbarPnl.Controls.Add(IconButton2)
        NavbarPnl.Controls.Add(SearchTxtBox)
        NavbarPnl.Controls.Add(Label1)
        NavbarPnl.Location = New Point(458, 0)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(583, 68)
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
        IconButton3.Location = New Point(479, 16)
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
        ' IconButton2
        ' 
        IconButton2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        IconButton2.BackColor = Color.DarkSeaGreen
        IconButton2.FlatAppearance.BorderSize = 0
        IconButton2.FlatStyle = FlatStyle.Flat
        IconButton2.IconChar = FontAwesome.Sharp.IconChar.Cog
        IconButton2.IconColor = Color.Black
        IconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton2.IconSize = 40
        IconButton2.Location = New Point(528, 16)
        IconButton2.Name = "IconButton2"
        IconButton2.Size = New Size(43, 42)
        IconButton2.TabIndex = 1
        IconButton2.UseVisualStyleBackColor = False
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
        DataGridView1.Location = New Point(36, 63)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(29, 31)
        DataGridView1.TabIndex = 1
        DataGridView1.Visible = False
        ' 
        ' TotalPnl
        ' 
        TotalPnl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        TotalPnl.BackColor = SystemColors.Control
        TotalPnl.BorderStyle = BorderStyle.FixedSingle
        TotalPnl.Controls.Add(CreateOrderBtn)
        TotalPnl.Controls.Add(DataGridView1)
        TotalPnl.Controls.Add(Button1)
        TotalPnl.Controls.Add(Label4)
        TotalPnl.Controls.Add(Label3)
        TotalPnl.Controls.Add(TotalLbl)
        TotalPnl.Controls.Add(Label2)
        TotalPnl.Location = New Point(-1, 493)
        TotalPnl.Name = "TotalPnl"
        TotalPnl.Size = New Size(452, 111)
        TotalPnl.TabIndex = 4
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
        CreateOrderBtn.Location = New Point(293, 55)
        CreateOrderBtn.Name = "CreateOrderBtn"
        CreateOrderBtn.Size = New Size(141, 38)
        CreateOrderBtn.TabIndex = 1
        CreateOrderBtn.Text = "Proceed"
        CreateOrderBtn.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Gold
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(293, 11)
        Button1.Name = "Button1"
        Button1.Size = New Size(141, 38)
        Button1.TabIndex = 5
        Button1.Text = "Apply voucher"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 15F)
        Label4.Location = New Point(127, 15)
        Label4.Name = "Label4"
        Label4.Size = New Size(35, 28)
        Label4.TabIndex = 4
        Label4.Text = "₱0"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 15F)
        Label3.Location = New Point(14, 13)
        Label3.Name = "Label3"
        Label3.Size = New Size(89, 28)
        Label3.TabIndex = 3
        Label3.Text = "Discount"
        ' 
        ' TotalLbl
        ' 
        TotalLbl.AutoSize = True
        TotalLbl.Font = New Font("Segoe UI", 20F)
        TotalLbl.Location = New Point(124, 53)
        TotalLbl.Name = "TotalLbl"
        TotalLbl.Size = New Size(48, 37)
        TotalLbl.TabIndex = 1
        TotalLbl.Text = "₱0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F)
        Label2.Location = New Point(12, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 37)
        Label2.TabIndex = 0
        Label2.Text = "Total"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.DarkGray
        Panel1.Controls.Add(MenuCategoryPnl)
        Panel1.Controls.Add(FoodPnl)
        Panel1.Location = New Point(458, 66)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(584, 538)
        Panel1.TabIndex = 5
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        MenuCategoryPnl.BackColor = Color.WhiteSmoke
        MenuCategoryPnl.Location = New Point(3, 3)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(0, 0, 0, 20)
        MenuCategoryPnl.Size = New Size(583, 60)
        MenuCategoryPnl.TabIndex = 1
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.BackColor = SystemColors.Control
        FoodPnl.Location = New Point(2, 60)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Size = New Size(581, 478)
        FoodPnl.TabIndex = 2
        ' 
        ' OrderPnl
        ' 
        OrderPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        OrderPnl.BackColor = SystemColors.Control
        OrderPnl.FlowDirection = FlowDirection.TopDown
        OrderPnl.Location = New Point(0, 0)
        OrderPnl.Name = "OrderPnl"
        OrderPnl.Size = New Size(452, 493)
        OrderPnl.TabIndex = 6
        ' 
        ' Order
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1041, 604)
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
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents CreateOrderBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents SearchBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
End Class
