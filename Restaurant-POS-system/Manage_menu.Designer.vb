<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manage_menu
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
        BackBtn = New FontAwesome.Sharp.IconButton()
        SettingsBtn = New FontAwesome.Sharp.IconButton()
        SearchTxtBox = New TextBox()
        Label1 = New Label()
        SearchBtn = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Panel1 = New Panel()
        MenuCategoryPnl = New FlowLayoutPanel()
        FoodPnl = New FlowLayoutPanel()
        Panel2 = New Panel()
        ItemInfoPnl = New Panel()
        PriceTxtBox = New TextBox()
        PriceLbl = New Label()
        ItemNameTxtBox = New TextBox()
        ItemNameLbl = New Label()
        Label4 = New Label()
        lblItemPreview = New Label()
        UpdateBtn = New FontAwesome.Sharp.IconButton()
        CancelBtn = New FontAwesome.Sharp.IconButton()
        DeleteBtn = New FontAwesome.Sharp.IconButton()
        EditBtn = New FontAwesome.Sharp.IconButton()
        SaveBtn = New FontAwesome.Sharp.IconButton()
        Label2 = New Label()
        ItemBtn = New Button()
        NavbarPnl.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        ItemInfoPnl.SuspendLayout()
        SuspendLayout()
        ' 
        ' NavbarPnl
        ' 
        NavbarPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        NavbarPnl.BackColor = Color.DarkSeaGreen
        NavbarPnl.Controls.Add(BackBtn)
        NavbarPnl.Controls.Add(SettingsBtn)
        NavbarPnl.Controls.Add(SearchTxtBox)
        NavbarPnl.Controls.Add(Label1)
        NavbarPnl.Controls.Add(SearchBtn)
        NavbarPnl.Controls.Add(Button3)
        NavbarPnl.Controls.Add(Button2)
        NavbarPnl.Location = New Point(414, 0)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(627, 68)
        NavbarPnl.TabIndex = 7
        ' 
        ' BackBtn
        ' 
        BackBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BackBtn.BackColor = Color.Transparent
        BackBtn.FlatAppearance.BorderSize = 0
        BackBtn.FlatStyle = FlatStyle.Flat
        BackBtn.IconChar = FontAwesome.Sharp.IconChar.SignOut
        BackBtn.IconColor = Color.WhiteSmoke
        BackBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        BackBtn.IconSize = 40
        BackBtn.Location = New Point(523, 12)
        BackBtn.Name = "BackBtn"
        BackBtn.Size = New Size(43, 42)
        BackBtn.TabIndex = 9
        BackBtn.UseVisualStyleBackColor = False
        ' 
        ' SettingsBtn
        ' 
        SettingsBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SettingsBtn.BackColor = Color.Transparent
        SettingsBtn.FlatAppearance.BorderSize = 0
        SettingsBtn.FlatStyle = FlatStyle.Flat
        SettingsBtn.IconChar = FontAwesome.Sharp.IconChar.Cog
        SettingsBtn.IconColor = Color.WhiteSmoke
        SettingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SettingsBtn.IconSize = 40
        SettingsBtn.Location = New Point(572, 12)
        SettingsBtn.Name = "SettingsBtn"
        SettingsBtn.Size = New Size(43, 42)
        SettingsBtn.TabIndex = 8
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
        ' SearchBtn
        ' 
        SearchBtn.BackColor = Color.FromArgb(CByte(128), CByte(255), CByte(128))
        SearchBtn.FlatStyle = FlatStyle.Flat
        SearchBtn.Location = New Point(352, 21)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.Size = New Size(75, 34)
        SearchBtn.TabIndex = 5
        SearchBtn.Text = "Search"
        SearchBtn.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button3.Location = New Point(969, 27)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 3
        Button3.Text = "Settings"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.Location = New Point(888, 27)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 2
        Button2.Text = "Account"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.DarkGray
        Panel1.Controls.Add(MenuCategoryPnl)
        Panel1.Controls.Add(FoodPnl)
        Panel1.Location = New Point(414, 66)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(628, 583)
        Panel1.TabIndex = 9
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        MenuCategoryPnl.BackColor = Color.WhiteSmoke
        MenuCategoryPnl.Location = New Point(3, 3)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(0, 0, 0, 20)
        MenuCategoryPnl.Size = New Size(628, 60)
        MenuCategoryPnl.TabIndex = 1
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.BackColor = SystemColors.Control
        FoodPnl.Location = New Point(3, 60)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Size = New Size(625, 525)
        FoodPnl.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel2.BackColor = SystemColors.ControlLight
        Panel2.Controls.Add(ItemInfoPnl)
        Panel2.Location = New Point(1, 1)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(405, 648)
        Panel2.TabIndex = 10
        ' 
        ' ItemInfoPnl
        ' 
        ItemInfoPnl.BackColor = SystemColors.ButtonFace
        ItemInfoPnl.Controls.Add(PriceTxtBox)
        ItemInfoPnl.Controls.Add(PriceLbl)
        ItemInfoPnl.Controls.Add(ItemNameTxtBox)
        ItemInfoPnl.Controls.Add(ItemNameLbl)
        ItemInfoPnl.Controls.Add(Label4)
        ItemInfoPnl.Controls.Add(lblItemPreview)
        ItemInfoPnl.Controls.Add(UpdateBtn)
        ItemInfoPnl.Controls.Add(CancelBtn)
        ItemInfoPnl.Controls.Add(DeleteBtn)
        ItemInfoPnl.Controls.Add(EditBtn)
        ItemInfoPnl.Controls.Add(SaveBtn)
        ItemInfoPnl.Controls.Add(Label2)
        ItemInfoPnl.Controls.Add(ItemBtn)
        ItemInfoPnl.Location = New Point(23, 26)
        ItemInfoPnl.Name = "ItemInfoPnl"
        ItemInfoPnl.Size = New Size(359, 601)
        ItemInfoPnl.TabIndex = 0
        ' 
        ' PriceTxtBox
        ' 
        PriceTxtBox.BorderStyle = BorderStyle.FixedSingle
        PriceTxtBox.Enabled = False
        PriceTxtBox.Font = New Font("Segoe UI", 11F)
        PriceTxtBox.Location = New Point(35, 330)
        PriceTxtBox.Margin = New Padding(3, 2, 3, 2)
        PriceTxtBox.Name = "PriceTxtBox"
        PriceTxtBox.Size = New Size(149, 27)
        PriceTxtBox.TabIndex = 25
        ' 
        ' PriceLbl
        ' 
        PriceLbl.AutoSize = True
        PriceLbl.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        PriceLbl.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        PriceLbl.Location = New Point(35, 307)
        PriceLbl.Name = "PriceLbl"
        PriceLbl.Size = New Size(65, 20)
        PriceLbl.TabIndex = 24
        PriceLbl.Text = "💰 Price"
        ' 
        ' ItemNameTxtBox
        ' 
        ItemNameTxtBox.BorderStyle = BorderStyle.FixedSingle
        ItemNameTxtBox.Enabled = False
        ItemNameTxtBox.Font = New Font("Segoe UI", 11F)
        ItemNameTxtBox.Location = New Point(35, 266)
        ItemNameTxtBox.Margin = New Padding(3, 2, 3, 2)
        ItemNameTxtBox.Name = "ItemNameTxtBox"
        ItemNameTxtBox.Size = New Size(289, 27)
        ItemNameTxtBox.TabIndex = 23
        ' 
        ' ItemNameLbl
        ' 
        ItemNameLbl.AutoSize = True
        ItemNameLbl.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        ItemNameLbl.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        ItemNameLbl.Location = New Point(35, 244)
        ItemNameLbl.Name = "ItemNameLbl"
        ItemNameLbl.Size = New Size(110, 20)
        ItemNameLbl.TabIndex = 22
        ItemNameLbl.Text = "📌 Item Name"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Dock = DockStyle.Top
        Label4.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        Label4.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        Label4.Location = New Point(0, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(147, 28)
        Label4.TabIndex = 21
        Label4.Text = "📝 Item Editor"
        ' 
        ' lblItemPreview
        ' 
        lblItemPreview.AutoSize = True
        lblItemPreview.Font = New Font("Segoe UI", 10F, FontStyle.Italic)
        lblItemPreview.ForeColor = Color.Gray
        lblItemPreview.Location = New Point(0, 39)
        lblItemPreview.Name = "lblItemPreview"
        lblItemPreview.Size = New Size(193, 19)
        lblItemPreview.TabIndex = 20
        lblItemPreview.Text = "Select an item from the menu"
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.BackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        UpdateBtn.Cursor = Cursors.Hand
        UpdateBtn.Enabled = False
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.IconChar = FontAwesome.Sharp.IconChar.Refresh
        UpdateBtn.IconColor = Color.White
        UpdateBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        UpdateBtn.IconSize = 28
        UpdateBtn.ImageAlign = ContentAlignment.MiddleLeft
        UpdateBtn.Location = New Point(38, 540)
        UpdateBtn.Margin = New Padding(3, 2, 3, 2)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Padding = New Padding(9, 0, 9, 0)
        UpdateBtn.Size = New Size(140, 38)
        UpdateBtn.TabIndex = 18
        UpdateBtn.Text = "  Update"
        UpdateBtn.TextAlign = ContentAlignment.MiddleLeft
        UpdateBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        UpdateBtn.UseVisualStyleBackColor = False
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        CancelBtn.Cursor = Cursors.Hand
        CancelBtn.Enabled = False
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        CancelBtn.ForeColor = Color.White
        CancelBtn.IconChar = FontAwesome.Sharp.IconChar.Close
        CancelBtn.IconColor = Color.White
        CancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CancelBtn.IconSize = 28
        CancelBtn.ImageAlign = ContentAlignment.MiddleLeft
        CancelBtn.Location = New Point(187, 540)
        CancelBtn.Margin = New Padding(3, 2, 3, 2)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Padding = New Padding(9, 0, 9, 0)
        CancelBtn.Size = New Size(140, 38)
        CancelBtn.TabIndex = 17
        CancelBtn.Text = "   Cancel"
        CancelBtn.TextAlign = ContentAlignment.MiddleLeft
        CancelBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' DeleteBtn
        ' 
        DeleteBtn.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        DeleteBtn.Cursor = Cursors.Hand
        DeleteBtn.Enabled = False
        DeleteBtn.FlatAppearance.BorderSize = 0
        DeleteBtn.FlatStyle = FlatStyle.Flat
        DeleteBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        DeleteBtn.ForeColor = Color.White
        DeleteBtn.IconChar = FontAwesome.Sharp.IconChar.TrashAlt
        DeleteBtn.IconColor = Color.White
        DeleteBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        DeleteBtn.IconSize = 28
        DeleteBtn.ImageAlign = ContentAlignment.MiddleLeft
        DeleteBtn.Location = New Point(38, 488)
        DeleteBtn.Margin = New Padding(3, 2, 3, 2)
        DeleteBtn.Name = "DeleteBtn"
        DeleteBtn.Padding = New Padding(13, 0, 13, 0)
        DeleteBtn.Size = New Size(289, 41)
        DeleteBtn.TabIndex = 16
        DeleteBtn.Text = "    Delete Item"
        DeleteBtn.TextAlign = ContentAlignment.MiddleLeft
        DeleteBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        DeleteBtn.UseVisualStyleBackColor = False
        ' 
        ' EditBtn
        ' 
        EditBtn.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        EditBtn.Cursor = Cursors.Hand
        EditBtn.Enabled = False
        EditBtn.FlatAppearance.BorderSize = 0
        EditBtn.FlatStyle = FlatStyle.Flat
        EditBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        EditBtn.ForeColor = Color.White
        EditBtn.IconChar = FontAwesome.Sharp.IconChar.Edit
        EditBtn.IconColor = Color.White
        EditBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        EditBtn.IconSize = 28
        EditBtn.ImageAlign = ContentAlignment.MiddleLeft
        EditBtn.Location = New Point(38, 435)
        EditBtn.Margin = New Padding(3, 2, 3, 2)
        EditBtn.Name = "EditBtn"
        EditBtn.Padding = New Padding(13, 0, 13, 0)
        EditBtn.Size = New Size(289, 41)
        EditBtn.TabIndex = 15
        EditBtn.Text = "    Edit Item"
        EditBtn.TextAlign = ContentAlignment.MiddleLeft
        EditBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        EditBtn.UseVisualStyleBackColor = False
        ' 
        ' SaveBtn
        ' 
        SaveBtn.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        SaveBtn.Cursor = Cursors.Hand
        SaveBtn.Enabled = False
        SaveBtn.FlatAppearance.BorderSize = 0
        SaveBtn.FlatStyle = FlatStyle.Flat
        SaveBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        SaveBtn.ForeColor = Color.White
        SaveBtn.IconChar = FontAwesome.Sharp.IconChar.Save
        SaveBtn.IconColor = Color.White
        SaveBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SaveBtn.IconSize = 28
        SaveBtn.ImageAlign = ContentAlignment.MiddleLeft
        SaveBtn.Location = New Point(38, 387)
        SaveBtn.Margin = New Padding(3, 2, 3, 2)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Padding = New Padding(13, 0, 13, 0)
        SaveBtn.Size = New Size(289, 41)
        SaveBtn.TabIndex = 14
        SaveBtn.Text = "    Save Item"
        SaveBtn.TextAlign = ContentAlignment.MiddleLeft
        SaveBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        SaveBtn.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(91, 206)
        Label2.Name = "Label2"
        Label2.Size = New Size(171, 15)
        Label2.TabIndex = 13
        Label2.Text = "Click this to set the food image"
        ' 
        ' ItemBtn
        ' 
        ItemBtn.Enabled = False
        ItemBtn.Location = New Point(101, 65)
        ItemBtn.Name = "ItemBtn"
        ItemBtn.Size = New Size(148, 138)
        ItemBtn.TabIndex = 2
        ItemBtn.UseVisualStyleBackColor = True
        ' 
        ' Manage_menu
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1041, 649)
        Controls.Add(NavbarPnl)
        Controls.Add(Panel1)
        Controls.Add(Panel2)
        Name = "Manage_menu"
        Text = "Manage menu"
        NavbarPnl.ResumeLayout(False)
        NavbarPnl.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ItemInfoPnl.ResumeLayout(False)
        ItemInfoPnl.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents NavbarPnl As Panel
    Friend WithEvents SearchTxtBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SearchBtn As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ItemInfoPnl As Panel
    Friend WithEvents ItemBtn As Button
    Friend WithEvents BackBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents SettingsBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents Label2 As Label
    Friend WithEvents UpdateBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents CancelBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents DeleteBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents EditBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents SaveBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents Label4 As Label
    Friend WithEvents lblItemPreview As Label
    Friend WithEvents PriceTxtBox As TextBox
    Friend WithEvents PriceLbl As Label
    Friend WithEvents ItemNameTxtBox As TextBox
    Friend WithEvents ItemNameLbl As Label
End Class
