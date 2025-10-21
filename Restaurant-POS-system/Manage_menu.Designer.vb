<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Manage_menu
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
        pnlSearch = New Panel()
        SearchBtn = New FontAwesome.Sharp.IconButton()
        SearchTxtBox = New TextBox()
        lblTitle = New Label()
        lblHeaderIcon = New Label()
        pnlSidebar = New Panel()
        ItemInfoPnl = New Panel()
        pnlItemActions = New Panel()
        UpdateBtn = New FontAwesome.Sharp.IconButton()
        CancelBtn = New FontAwesome.Sharp.IconButton()
        DeleteBtn = New FontAwesome.Sharp.IconButton()
        EditBtn = New FontAwesome.Sharp.IconButton()
        SaveBtn = New FontAwesome.Sharp.IconButton()
        pnlItemFields = New Panel()
        PriceTxtBox = New TextBox()
        PriceLbl = New Label()
        ItemNameTxtBox = New TextBox()
        ItemNameLbl = New Label()
        lblItemPreview = New Label()
        ItemBtn = New Button()
        Label4 = New Label()
        pnlMain = New Panel()
        FoodPnl = New FlowLayoutPanel()
        MenuCategoryPnl = New FlowLayoutPanel()
        pnlHeader.SuspendLayout()
        pnlSearch.SuspendLayout()
        pnlSidebar.SuspendLayout()
        ItemInfoPnl.SuspendLayout()
        pnlItemActions.SuspendLayout()
        pnlItemFields.SuspendLayout()
        pnlMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        pnlHeader.Controls.Add(pnlSearch)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(lblHeaderIcon)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1600, 90)
        pnlHeader.TabIndex = 0
        ' 
        ' pnlSearch
        ' 
        pnlSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlSearch.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        pnlSearch.Controls.Add(SearchBtn)
        pnlSearch.Controls.Add(SearchTxtBox)
        pnlSearch.Location = New Point(1150, 20)
        pnlSearch.Name = "pnlSearch"
        pnlSearch.Size = New Size(420, 50)
        pnlSearch.TabIndex = 2
        ' 
        ' SearchBtn
        ' 
        SearchBtn.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        SearchBtn.Cursor = Cursors.Hand
        SearchBtn.Dock = DockStyle.Right
        SearchBtn.FlatAppearance.BorderSize = 0
        SearchBtn.FlatStyle = FlatStyle.Flat
        SearchBtn.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        SearchBtn.ForeColor = Color.White
        SearchBtn.IconChar = FontAwesome.Sharp.IconChar.Search
        SearchBtn.IconColor = Color.White
        SearchBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SearchBtn.IconSize = 24
        SearchBtn.Location = New Point(300, 0)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.Size = New Size(120, 50)
        SearchBtn.TabIndex = 1
        SearchBtn.Text = "Search"
        SearchBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        SearchBtn.UseVisualStyleBackColor = False
        ' 
        ' SearchTxtBox
        ' 
        SearchTxtBox.BorderStyle = BorderStyle.None
        SearchTxtBox.Dock = DockStyle.Fill
        SearchTxtBox.Font = New Font("Segoe UI", 12.0F)
        SearchTxtBox.Location = New Point(0, 0)
        SearchTxtBox.Multiline = True
        SearchTxtBox.Name = "SearchTxtBox"
        SearchTxtBox.PlaceholderText = "🔍 Search menu items..."
        SearchTxtBox.Size = New Size(420, 50)
        SearchTxtBox.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(110, 28)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(271, 50)
        lblTitle.TabIndex = 1
        lblTitle.Text = "Manage Menu"
        ' 
        ' lblHeaderIcon
        ' 
        lblHeaderIcon.AutoSize = True
        lblHeaderIcon.Font = New Font("Segoe UI", 28.0F, FontStyle.Bold)
        lblHeaderIcon.ForeColor = Color.White
        lblHeaderIcon.Location = New Point(30, 20)
        lblHeaderIcon.Name = "lblHeaderIcon"
        lblHeaderIcon.Size = New Size(87, 62)
        lblHeaderIcon.TabIndex = 0
        lblHeaderIcon.Text = "🍽️"
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(245))
        pnlSidebar.Controls.Add(ItemInfoPnl)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 90)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Padding = New Padding(25)
        pnlSidebar.Size = New Size(450, 920)
        pnlSidebar.TabIndex = 1
        ' 
        ' ItemInfoPnl
        ' 
        ItemInfoPnl.BackColor = Color.White
        ItemInfoPnl.Controls.Add(pnlItemActions)
        ItemInfoPnl.Controls.Add(pnlItemFields)
        ItemInfoPnl.Controls.Add(lblItemPreview)
        ItemInfoPnl.Controls.Add(ItemBtn)
        ItemInfoPnl.Controls.Add(Label4)
        ItemInfoPnl.Dock = DockStyle.Fill
        ItemInfoPnl.Location = New Point(25, 25)
        ItemInfoPnl.Name = "ItemInfoPnl"
        ItemInfoPnl.Padding = New Padding(25)
        ItemInfoPnl.Size = New Size(400, 870)
        ItemInfoPnl.TabIndex = 0
        ' 
        ' pnlItemActions
        ' 
        pnlItemActions.Controls.Add(UpdateBtn)
        pnlItemActions.Controls.Add(CancelBtn)
        pnlItemActions.Controls.Add(DeleteBtn)
        pnlItemActions.Controls.Add(EditBtn)
        pnlItemActions.Controls.Add(SaveBtn)
        pnlItemActions.Location = New Point(25, 550)
        pnlItemActions.Name = "pnlItemActions"
        pnlItemActions.Size = New Size(350, 280)
        pnlItemActions.TabIndex = 4
        pnlItemActions.Visible = False
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.BackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        UpdateBtn.Cursor = Cursors.Hand
        UpdateBtn.Enabled = False
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.IconChar = FontAwesome.Sharp.IconChar.Refresh
        UpdateBtn.IconColor = Color.White
        UpdateBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        UpdateBtn.IconSize = 32
        UpdateBtn.ImageAlign = ContentAlignment.MiddleLeft
        UpdateBtn.Location = New Point(10, 205)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Padding = New Padding(10, 0, 10, 0)
        UpdateBtn.Size = New Size(160, 50)
        UpdateBtn.TabIndex = 4
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
        CancelBtn.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        CancelBtn.ForeColor = Color.White
        CancelBtn.IconChar = FontAwesome.Sharp.IconChar.Close
        CancelBtn.IconColor = Color.White
        CancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CancelBtn.IconSize = 32
        CancelBtn.ImageAlign = ContentAlignment.MiddleLeft
        CancelBtn.Location = New Point(180, 205)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Padding = New Padding(10, 0, 10, 0)
        CancelBtn.Size = New Size(160, 50)
        CancelBtn.TabIndex = 3
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
        DeleteBtn.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        DeleteBtn.ForeColor = Color.White
        DeleteBtn.IconChar = FontAwesome.Sharp.IconChar.TrashAlt
        DeleteBtn.IconColor = Color.White
        DeleteBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        DeleteBtn.IconSize = 32
        DeleteBtn.ImageAlign = ContentAlignment.MiddleLeft
        DeleteBtn.Location = New Point(10, 140)
        DeleteBtn.Name = "DeleteBtn"
        DeleteBtn.Padding = New Padding(15, 0, 15, 0)
        DeleteBtn.Size = New Size(330, 50)
        DeleteBtn.TabIndex = 2
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
        EditBtn.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        EditBtn.ForeColor = Color.White
        EditBtn.IconChar = FontAwesome.Sharp.IconChar.Edit
        EditBtn.IconColor = Color.White
        EditBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        EditBtn.IconSize = 32
        EditBtn.ImageAlign = ContentAlignment.MiddleLeft
        EditBtn.Location = New Point(10, 75)
        EditBtn.Name = "EditBtn"
        EditBtn.Padding = New Padding(15, 0, 15, 0)
        EditBtn.Size = New Size(330, 50)
        EditBtn.TabIndex = 1
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
        SaveBtn.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        SaveBtn.ForeColor = Color.White
        SaveBtn.IconChar = FontAwesome.Sharp.IconChar.Save
        SaveBtn.IconColor = Color.White
        SaveBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SaveBtn.IconSize = 32
        SaveBtn.ImageAlign = ContentAlignment.MiddleLeft
        SaveBtn.Location = New Point(10, 10)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Padding = New Padding(15, 0, 15, 0)
        SaveBtn.Size = New Size(330, 50)
        SaveBtn.TabIndex = 0
        SaveBtn.Text = "    Save Item"
        SaveBtn.TextAlign = ContentAlignment.MiddleLeft
        SaveBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        SaveBtn.UseVisualStyleBackColor = False
        ' 
        ' pnlItemFields
        ' 
        pnlItemFields.Controls.Add(PriceTxtBox)
        pnlItemFields.Controls.Add(PriceLbl)
        pnlItemFields.Controls.Add(ItemNameTxtBox)
        pnlItemFields.Controls.Add(ItemNameLbl)
        pnlItemFields.Location = New Point(25, 350)
        pnlItemFields.Name = "pnlItemFields"
        pnlItemFields.Size = New Size(350, 180)
        pnlItemFields.TabIndex = 3
        pnlItemFields.Visible = False
        ' 
        ' PriceTxtBox
        ' 
        PriceTxtBox.BorderStyle = BorderStyle.FixedSingle
        PriceTxtBox.Enabled = False
        PriceTxtBox.Font = New Font("Segoe UI", 11.0F)
        PriceTxtBox.Location = New Point(10, 125)
        PriceTxtBox.Name = "PriceTxtBox"
        PriceTxtBox.Size = New Size(170, 32)
        PriceTxtBox.TabIndex = 3
        ' 
        ' PriceLbl
        ' 
        PriceLbl.AutoSize = True
        PriceLbl.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        PriceLbl.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        PriceLbl.Location = New Point(10, 95)
        PriceLbl.Name = "PriceLbl"
        PriceLbl.Size = New Size(77, 25)
        PriceLbl.TabIndex = 2
        PriceLbl.Text = "💰 Price"
        ' 
        ' ItemNameTxtBox
        ' 
        ItemNameTxtBox.BorderStyle = BorderStyle.FixedSingle
        ItemNameTxtBox.Enabled = False
        ItemNameTxtBox.Font = New Font("Segoe UI", 11.0F)
        ItemNameTxtBox.Location = New Point(10, 40)
        ItemNameTxtBox.Name = "ItemNameTxtBox"
        ItemNameTxtBox.Size = New Size(330, 32)
        ItemNameTxtBox.TabIndex = 1
        ' 
        ' ItemNameLbl
        ' 
        ItemNameLbl.AutoSize = True
        ItemNameLbl.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        ItemNameLbl.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        ItemNameLbl.Location = New Point(10, 10)
        ItemNameLbl.Name = "ItemNameLbl"
        ItemNameLbl.Size = New Size(136, 25)
        ItemNameLbl.TabIndex = 0
        ItemNameLbl.Text = "📌 Item Name"
        ' 
        ' lblItemPreview
        ' 
        lblItemPreview.AutoSize = True
        lblItemPreview.Font = New Font("Segoe UI", 10.0F, FontStyle.Italic)
        lblItemPreview.ForeColor = Color.Gray
        lblItemPreview.Location = New Point(25, 65)
        lblItemPreview.Name = "lblItemPreview"
        lblItemPreview.Size = New Size(228, 23)
        lblItemPreview.TabIndex = 1
        lblItemPreview.Text = "Select an item from the menu"
        ' 
        ' ItemBtn
        ' 
        ItemBtn.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ItemBtn.Cursor = Cursors.Hand
        ItemBtn.Enabled = False
        ItemBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        ItemBtn.FlatAppearance.BorderSize = 3
        ItemBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(236), CByte(240), CByte(245))
        ItemBtn.FlatStyle = FlatStyle.Flat
        ItemBtn.Font = New Font("Segoe UI", 11.0F)
        ItemBtn.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        ItemBtn.Location = New Point(75, 110)
        ItemBtn.Name = "ItemBtn"
        ItemBtn.Size = New Size(250, 220)
        ItemBtn.TabIndex = 2
        ItemBtn.Text = "📷" & vbCrLf & vbCrLf & "Click to set image"
        ItemBtn.UseVisualStyleBackColor = False
        ItemBtn.Visible = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
        Label4.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        Label4.Location = New Point(25, 25)
        Label4.Name = "Label4"
        Label4.Size = New Size(189, 35)
        Label4.TabIndex = 0
        Label4.Text = "📝 Item Editor"
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(245))
        pnlMain.Controls.Add(FoodPnl)
        pnlMain.Controls.Add(MenuCategoryPnl)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(450, 90)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(1150, 920)
        pnlMain.TabIndex = 2
        ' 
        ' FoodPnl
        ' 
        FoodPnl.AutoScroll = True
        FoodPnl.BackColor = Color.White
        FoodPnl.Dock = DockStyle.Fill
        FoodPnl.Location = New Point(0, 80)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Padding = New Padding(25)
        FoodPnl.Size = New Size(1150, 840)
        FoodPnl.TabIndex = 1
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.BackColor = Color.White
        MenuCategoryPnl.Dock = DockStyle.Top
        MenuCategoryPnl.Location = New Point(0, 0)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(20, 15, 20, 15)
        MenuCategoryPnl.Size = New Size(1150, 80)
        MenuCategoryPnl.TabIndex = 0
        ' 
        ' Manage_menu
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(245))
        ClientSize = New Size(1600, 1010)
        Controls.Add(pnlMain)
        Controls.Add(pnlSidebar)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 9.0F)
        Name = "Manage_menu"
        Text = "🍽️ Manage Menu - OrderUp!"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlSearch.ResumeLayout(False)
        pnlSearch.PerformLayout()
        pnlSidebar.ResumeLayout(False)
        ItemInfoPnl.ResumeLayout(False)
        ItemInfoPnl.PerformLayout()
        pnlItemActions.ResumeLayout(False)
        pnlItemFields.ResumeLayout(False)
        pnlItemFields.PerformLayout()
        pnlMain.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblHeaderIcon As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents SearchBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents SearchTxtBox As TextBox
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents ItemInfoPnl As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents lblItemPreview As Label
    Friend WithEvents ItemBtn As Button
    Friend WithEvents pnlItemFields As Panel
    Friend WithEvents PriceTxtBox As TextBox
    Friend WithEvents PriceLbl As Label
    Friend WithEvents ItemNameTxtBox As TextBox
    Friend WithEvents ItemNameLbl As Label
    Friend WithEvents pnlItemActions As Panel
    Friend WithEvents UpdateBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents CancelBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents DeleteBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents EditBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents SaveBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlMain As Panel
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
End Class