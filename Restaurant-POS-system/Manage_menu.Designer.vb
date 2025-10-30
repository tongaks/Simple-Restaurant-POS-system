Imports Guna.UI2.WinForms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Manage_menu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges13 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges14 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges15 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges16 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges17 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges18 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Panel1 = New Panel()
        Label1 = New Label()
        FoodPnl = New FlowLayoutPanel()
        MenuPnl = New Guna2Panel()
        Label9 = New Label()
        MenuCategoryPnl = New FlowLayoutPanel()
        NavbarPnl = New Panel()
        LogoutBtn = New Guna2Button()
        SearchBtn = New Guna2Button()
        SearchTxtBox = New Guna2TextBox()
        Label3 = New Label()
        DataGridView1 = New DataGridView()
        ItemBtn = New Guna2PictureBox()
        Label2 = New Label()
        SaveBtn = New Guna2Button()
        DeleteBtn = New Guna2Button()
        CancelBtn = New Guna2Button()
        lblItemPreview = New Label()
        Label4 = New Label()
        ItemNameLbl = New Label()
        ItemNameTxtBox = New TextBox()
        PriceLbl = New Label()
        PriceTxtBox = New TextBox()
        Label5 = New Label()
        ItemInfoPnl = New Guna2Panel()
        Panel1.SuspendLayout()
        MenuPnl.SuspendLayout()
        NavbarPnl.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(ItemBtn, ComponentModel.ISupportInitialize).BeginInit()
        ItemInfoPnl.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.Transparent
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(FoodPnl)
        Panel1.Controls.Add(MenuPnl)
        Panel1.Location = New Point(412, 68)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(831, 616)
        Panel1.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F)
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(12, 131)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 28)
        Label1.TabIndex = 11
        Label1.Text = "Menu items"
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.Location = New Point(12, 162)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Size = New Size(805, 438)
        FoodPnl.TabIndex = 4
        ' 
        ' MenuPnl
        ' 
        MenuPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        MenuPnl.BackColor = Color.Transparent
        MenuPnl.BorderRadius = 10
        MenuPnl.Controls.Add(Label9)
        MenuPnl.Controls.Add(MenuCategoryPnl)
        MenuPnl.CustomizableEdges = CustomizableEdges1
        MenuPnl.FillColor = Color.White
        MenuPnl.Location = New Point(2, 8)
        MenuPnl.Name = "MenuPnl"
        MenuPnl.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        MenuPnl.ShadowDecoration.Depth = 10
        MenuPnl.ShadowDecoration.Enabled = True
        MenuPnl.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        MenuPnl.Size = New Size(815, 114)
        MenuPnl.TabIndex = 3
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 15F)
        Label9.Location = New Point(21, 7)
        Label9.Name = "Label9"
        Label9.Size = New Size(105, 28)
        Label9.TabIndex = 10
        Label9.Text = "Categories"
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.AutoSize = True
        MenuCategoryPnl.Location = New Point(10, 38)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Size = New Size(792, 55)
        MenuCategoryPnl.TabIndex = 0
        ' 
        ' NavbarPnl
        ' 
        NavbarPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        NavbarPnl.BackColor = Color.SteelBlue
        NavbarPnl.Controls.Add(LogoutBtn)
        NavbarPnl.Controls.Add(SearchBtn)
        NavbarPnl.Controls.Add(SearchTxtBox)
        NavbarPnl.Controls.Add(Label3)
        NavbarPnl.Controls.Add(DataGridView1)
        NavbarPnl.Location = New Point(1, 0)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(1242, 68)
        NavbarPnl.TabIndex = 12
        ' 
        ' LogoutBtn
        ' 
        LogoutBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LogoutBtn.BackColor = Color.Transparent
        LogoutBtn.BorderRadius = 10
        LogoutBtn.Cursor = Cursors.Hand
        LogoutBtn.CustomizableEdges = CustomizableEdges3
        LogoutBtn.FillColor = Color.DarkRed
        LogoutBtn.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        LogoutBtn.ForeColor = SystemColors.ControlLightLight
        LogoutBtn.Location = New Point(2178, 15)
        LogoutBtn.Name = "LogoutBtn"
        LogoutBtn.ShadowDecoration.BorderRadius = 10
        LogoutBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        LogoutBtn.ShadowDecoration.Depth = 20
        LogoutBtn.ShadowDecoration.Enabled = True
        LogoutBtn.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        LogoutBtn.Size = New Size(92, 36)
        LogoutBtn.TabIndex = 2
        LogoutBtn.Text = "→ Logout"
        ' 
        ' SearchBtn
        ' 
        SearchBtn.Anchor = AnchorStyles.None
        SearchBtn.BackColor = Color.Transparent
        SearchBtn.BorderRadius = 10
        SearchBtn.CustomizableEdges = CustomizableEdges5
        SearchBtn.FillColor = Color.SpringGreen
        SearchBtn.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SearchBtn.ForeColor = Color.Black
        SearchBtn.Location = New Point(837, 12)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.ShadowDecoration.BorderRadius = 10
        SearchBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        SearchBtn.ShadowDecoration.Depth = 20
        SearchBtn.ShadowDecoration.Enabled = True
        SearchBtn.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        SearchBtn.Size = New Size(97, 36)
        SearchBtn.TabIndex = 8
        SearchBtn.Text = "⌕ Search"
        ' 
        ' SearchTxtBox
        ' 
        SearchTxtBox.Anchor = AnchorStyles.None
        SearchTxtBox.BorderRadius = 10
        SearchTxtBox.CustomizableEdges = CustomizableEdges7
        SearchTxtBox.DefaultText = ""
        SearchTxtBox.Font = New Font("Segoe UI", 10F)
        SearchTxtBox.Location = New Point(490, 12)
        SearchTxtBox.Name = "SearchTxtBox"
        SearchTxtBox.PlaceholderText = "Search item name here"
        SearchTxtBox.SelectedText = ""
        SearchTxtBox.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        SearchTxtBox.Size = New Size(341, 39)
        SearchTxtBox.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ControlLightLight
        Label3.Location = New Point(412, 16)
        Label3.Name = "Label3"
        Label3.Size = New Size(72, 28)
        Label3.TabIndex = 6
        Label3.Text = "Search"
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
        DataGridView1.Size = New Size(29, 0)
        DataGridView1.TabIndex = 1
        DataGridView1.Visible = False
        ' 
        ' ItemBtn
        ' 
        ItemBtn.CustomizableEdges = CustomizableEdges9
        ItemBtn.Enabled = False
        ItemBtn.FillColor = SystemColors.Control
        ItemBtn.Font = New Font("Segoe UI", 9F)
        ItemBtn.ForeColor = Color.Gray
        ItemBtn.ImageRotate = 0F
        ItemBtn.Location = New Point(98, 101)
        ItemBtn.Name = "ItemBtn"
        ItemBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        ItemBtn.Size = New Size(148, 138)
        ItemBtn.TabIndex = 2
        ItemBtn.TabStop = False
        ItemBtn.Text = "No image"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(88, 242)
        Label2.Name = "Label2"
        Label2.Size = New Size(171, 15)
        Label2.TabIndex = 13
        Label2.Text = "Click this to set the food image"
        ' 
        ' SaveBtn
        ' 
        SaveBtn.BackColor = Color.Transparent
        SaveBtn.BorderColor = Color.Transparent
        SaveBtn.BorderRadius = 10
        SaveBtn.Cursor = Cursors.Hand
        SaveBtn.CustomizableEdges = CustomizableEdges11
        SaveBtn.Enabled = False
        SaveBtn.FillColor = Color.LimeGreen
        SaveBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        SaveBtn.ForeColor = Color.White
        SaveBtn.Location = New Point(35, 423)
        SaveBtn.Margin = New Padding(3, 2, 3, 2)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Padding = New Padding(13, 0, 13, 0)
        SaveBtn.ShadowDecoration.BorderRadius = 10
        SaveBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        SaveBtn.ShadowDecoration.Depth = 20
        SaveBtn.ShadowDecoration.Enabled = True
        SaveBtn.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        SaveBtn.Size = New Size(289, 41)
        SaveBtn.TabIndex = 14
        SaveBtn.Text = "    💾 Save Item"
        ' 
        ' DeleteBtn
        ' 
        DeleteBtn.BackColor = Color.Transparent
        DeleteBtn.BorderColor = Color.Transparent
        DeleteBtn.BorderRadius = 10
        DeleteBtn.Cursor = Cursors.Hand
        DeleteBtn.CustomizableEdges = CustomizableEdges13
        DeleteBtn.Enabled = False
        DeleteBtn.FillColor = Color.IndianRed
        DeleteBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        DeleteBtn.ForeColor = Color.White
        DeleteBtn.Location = New Point(35, 524)
        DeleteBtn.Margin = New Padding(3, 2, 3, 2)
        DeleteBtn.Name = "DeleteBtn"
        DeleteBtn.Padding = New Padding(13, 0, 13, 0)
        DeleteBtn.ShadowDecoration.BorderRadius = 10
        DeleteBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges14
        DeleteBtn.ShadowDecoration.Depth = 20
        DeleteBtn.ShadowDecoration.Enabled = True
        DeleteBtn.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        DeleteBtn.Size = New Size(289, 41)
        DeleteBtn.TabIndex = 16
        DeleteBtn.Text = "    🗑️ Delete Item"
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.Transparent
        CancelBtn.BorderColor = Color.Transparent
        CancelBtn.BorderRadius = 10
        CancelBtn.Cursor = Cursors.Hand
        CancelBtn.CustomizableEdges = CustomizableEdges15
        CancelBtn.Enabled = False
        CancelBtn.FillColor = Color.Gray
        CancelBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        CancelBtn.ForeColor = Color.White
        CancelBtn.Location = New Point(35, 474)
        CancelBtn.Margin = New Padding(3, 2, 3, 2)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Padding = New Padding(9, 0, 9, 0)
        CancelBtn.ShadowDecoration.BorderRadius = 10
        CancelBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges16
        CancelBtn.ShadowDecoration.Depth = 20
        CancelBtn.ShadowDecoration.Enabled = True
        CancelBtn.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        CancelBtn.Size = New Size(289, 38)
        CancelBtn.TabIndex = 17
        CancelBtn.Text = "   × Cancel"
        ' 
        ' lblItemPreview
        ' 
        lblItemPreview.AutoSize = True
        lblItemPreview.Font = New Font("Segoe UI", 10F, FontStyle.Italic)
        lblItemPreview.ForeColor = Color.Gray
        lblItemPreview.Location = New Point(12, 39)
        lblItemPreview.Name = "lblItemPreview"
        lblItemPreview.Size = New Size(193, 19)
        lblItemPreview.TabIndex = 20
        lblItemPreview.Text = "Select an item from the menu"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Dock = DockStyle.Top
        Label4.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        Label4.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        Label4.Location = New Point(0, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(0, 28)
        Label4.TabIndex = 21
        ' 
        ' ItemNameLbl
        ' 
        ItemNameLbl.AutoSize = True
        ItemNameLbl.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        ItemNameLbl.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        ItemNameLbl.Location = New Point(32, 280)
        ItemNameLbl.Name = "ItemNameLbl"
        ItemNameLbl.Size = New Size(110, 20)
        ItemNameLbl.TabIndex = 22
        ItemNameLbl.Text = "📌 Item Name"
        ' 
        ' ItemNameTxtBox
        ' 
        ItemNameTxtBox.BorderStyle = BorderStyle.FixedSingle
        ItemNameTxtBox.Enabled = False
        ItemNameTxtBox.Font = New Font("Segoe UI", 11F)
        ItemNameTxtBox.Location = New Point(32, 302)
        ItemNameTxtBox.Margin = New Padding(3, 2, 3, 2)
        ItemNameTxtBox.Name = "ItemNameTxtBox"
        ItemNameTxtBox.Size = New Size(289, 27)
        ItemNameTxtBox.TabIndex = 23
        ' 
        ' PriceLbl
        ' 
        PriceLbl.AutoSize = True
        PriceLbl.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        PriceLbl.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        PriceLbl.Location = New Point(32, 343)
        PriceLbl.Name = "PriceLbl"
        PriceLbl.Size = New Size(65, 20)
        PriceLbl.TabIndex = 24
        PriceLbl.Text = "💰 Price"
        ' 
        ' PriceTxtBox
        ' 
        PriceTxtBox.BorderStyle = BorderStyle.FixedSingle
        PriceTxtBox.Enabled = False
        PriceTxtBox.Font = New Font("Segoe UI", 11F)
        PriceTxtBox.Location = New Point(32, 366)
        PriceTxtBox.Margin = New Padding(3, 2, 3, 2)
        PriceTxtBox.Name = "PriceTxtBox"
        PriceTxtBox.Size = New Size(149, 27)
        PriceTxtBox.TabIndex = 25
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(12, 15)
        Label5.Name = "Label5"
        Label5.Size = New Size(119, 21)
        Label5.TabIndex = 26
        Label5.Text = "📝 Item Editor"
        ' 
        ' ItemInfoPnl
        ' 
        ItemInfoPnl.BackColor = Color.Transparent
        ItemInfoPnl.BorderRadius = 10
        ItemInfoPnl.Controls.Add(Label5)
        ItemInfoPnl.Controls.Add(PriceTxtBox)
        ItemInfoPnl.Controls.Add(PriceLbl)
        ItemInfoPnl.Controls.Add(ItemNameTxtBox)
        ItemInfoPnl.Controls.Add(ItemNameLbl)
        ItemInfoPnl.Controls.Add(Label4)
        ItemInfoPnl.Controls.Add(lblItemPreview)
        ItemInfoPnl.Controls.Add(CancelBtn)
        ItemInfoPnl.Controls.Add(DeleteBtn)
        ItemInfoPnl.Controls.Add(SaveBtn)
        ItemInfoPnl.Controls.Add(Label2)
        ItemInfoPnl.Controls.Add(ItemBtn)
        ItemInfoPnl.CustomizableEdges = CustomizableEdges17
        ItemInfoPnl.FillColor = Color.White
        ItemInfoPnl.Location = New Point(25, 83)
        ItemInfoPnl.Name = "ItemInfoPnl"
        ItemInfoPnl.ShadowDecoration.BorderRadius = 10
        ItemInfoPnl.ShadowDecoration.CustomizableEdges = CustomizableEdges18
        ItemInfoPnl.ShadowDecoration.Depth = 20
        ItemInfoPnl.ShadowDecoration.Enabled = True
        ItemInfoPnl.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        ItemInfoPnl.Size = New Size(359, 601)
        ItemInfoPnl.TabIndex = 0
        ' 
        ' Manage_menu
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gainsboro
        ClientSize = New Size(1241, 711)
        Controls.Add(ItemInfoPnl)
        Controls.Add(NavbarPnl)
        Controls.Add(Panel1)
        Name = "Manage_menu"
        Text = "Manage menu"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        MenuPnl.ResumeLayout(False)
        MenuPnl.PerformLayout()
        NavbarPnl.ResumeLayout(False)
        NavbarPnl.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(ItemBtn, ComponentModel.ISupportInitialize).EndInit()
        ItemInfoPnl.ResumeLayout(False)
        ItemInfoPnl.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuPnl As Guna2Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents NavbarPnl As Panel
    Friend WithEvents LogoutBtn As Guna2Button
    Friend WithEvents SearchBtn As Guna2Button
    Friend WithEvents SearchTxtBox As Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ItemBtn As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SaveBtn As Guna2Button
    Friend WithEvents DeleteBtn As Guna2Button
    Friend WithEvents CancelBtn As Guna2Button
    Friend WithEvents lblItemPreview As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ItemNameLbl As Label
    Friend WithEvents ItemNameTxtBox As TextBox
    Friend WithEvents PriceLbl As Label
    Friend WithEvents PriceTxtBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ItemInfoPnl As Guna2Panel
End Class
