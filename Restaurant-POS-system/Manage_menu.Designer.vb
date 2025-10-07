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
        SearchTxtBox = New TextBox()
        Label1 = New Label()
        SearchBtn = New Button()
        Button3 = New Button()
        Button2 = New Button()
        btnBack = New Button()
        btnLogout = New Button()
        Panel1 = New Panel()
        MenuCategoryPnl = New FlowLayoutPanel()
        FoodPnl = New FlowLayoutPanel()
        Panel2 = New Panel()
        ItemInfoPnl = New Panel()
        SaveBtn = New Button()
        UpdateBtn = New Button()
        CancelBtn = New Button()
        Label4 = New Label()
        PriceTxtBox = New TextBox()
        ItemNameTxtBox = New TextBox()
        DeleteBtn = New Button()
        EditBtn = New Button()
        ItemBtn = New Button()
        PriceLbl = New Label()
        ItemNameLbl = New Label()
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
        NavbarPnl.Controls.Add(SearchTxtBox)
        NavbarPnl.Controls.Add(Label1)
        NavbarPnl.Controls.Add(SearchBtn)
        NavbarPnl.Controls.Add(Button3)
        NavbarPnl.Controls.Add(Button2)
        NavbarPnl.Controls.Add(btnBack)
        NavbarPnl.Controls.Add(btnLogout)
        NavbarPnl.Location = New Point(473, 0)
        NavbarPnl.Margin = New Padding(3, 4, 3, 4)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(717, 91)
        NavbarPnl.TabIndex = 7
        ' 
        ' SearchTxtBox
        ' 
        SearchTxtBox.Font = New Font("Segoe UI", 15F)
        SearchTxtBox.Location = New Point(91, 25)
        SearchTxtBox.Margin = New Padding(3, 4, 3, 4)
        SearchTxtBox.Name = "SearchTxtBox"
        SearchTxtBox.Size = New Size(291, 41)
        SearchTxtBox.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(19, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(70, 28)
        Label1.TabIndex = 6
        Label1.Text = "Search"
        ' 
        ' SearchBtn
        ' 
        SearchBtn.BackColor = Color.FromArgb(CByte(128), CByte(255), CByte(128))
        SearchBtn.FlatStyle = FlatStyle.Flat
        SearchBtn.Location = New Point(402, 28)
        SearchBtn.Margin = New Padding(3, 4, 3, 4)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.Size = New Size(86, 45)
        SearchBtn.TabIndex = 5
        SearchBtn.Text = "Search"
        SearchBtn.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button3.Location = New Point(1107, 36)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(86, 31)
        Button3.TabIndex = 3
        Button3.Text = "Settings"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.Location = New Point(1015, 36)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(86, 31)
        Button2.TabIndex = 2
        Button2.Text = "Account"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnBack.BackColor = Color.LightSkyBlue
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 10F)
        btnBack.Location = New Point(491, 21)
        btnBack.Margin = New Padding(3, 4, 3, 4)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(91, 48)
        btnBack.TabIndex = 20
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BackColor = Color.LightCoral
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 10F)
        btnLogout.Location = New Point(594, 21)
        btnLogout.Margin = New Padding(3, 4, 3, 4)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(91, 48)
        btnLogout.TabIndex = 21
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.DarkGray
        Panel1.Controls.Add(MenuCategoryPnl)
        Panel1.Controls.Add(FoodPnl)
        Panel1.Location = New Point(473, 88)
        Panel1.Margin = New Padding(3, 4, 3, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(718, 717)
        Panel1.TabIndex = 9
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        MenuCategoryPnl.BackColor = Color.WhiteSmoke
        MenuCategoryPnl.Location = New Point(3, 4)
        MenuCategoryPnl.Margin = New Padding(3, 4, 3, 4)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(0, 0, 0, 27)
        MenuCategoryPnl.Size = New Size(718, 80)
        MenuCategoryPnl.TabIndex = 1
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.BackColor = SystemColors.Control
        FoodPnl.Location = New Point(3, 80)
        FoodPnl.Margin = New Padding(3, 4, 3, 4)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Size = New Size(714, 640)
        FoodPnl.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel2.BackColor = SystemColors.ControlLight
        Panel2.Controls.Add(ItemInfoPnl)
        Panel2.Location = New Point(1, 1)
        Panel2.Margin = New Padding(3, 4, 3, 4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(463, 804)
        Panel2.TabIndex = 10
        ' 
        ' ItemInfoPnl
        ' 
        ItemInfoPnl.BackColor = SystemColors.ButtonFace
        ItemInfoPnl.Controls.Add(SaveBtn)
        ItemInfoPnl.Controls.Add(UpdateBtn)
        ItemInfoPnl.Controls.Add(CancelBtn)
        ItemInfoPnl.Controls.Add(Label4)
        ItemInfoPnl.Controls.Add(PriceTxtBox)
        ItemInfoPnl.Controls.Add(ItemNameTxtBox)
        ItemInfoPnl.Controls.Add(DeleteBtn)
        ItemInfoPnl.Controls.Add(EditBtn)
        ItemInfoPnl.Controls.Add(ItemBtn)
        ItemInfoPnl.Controls.Add(PriceLbl)
        ItemInfoPnl.Controls.Add(ItemNameLbl)
        ItemInfoPnl.Location = New Point(26, 87)
        ItemInfoPnl.Margin = New Padding(3, 4, 3, 4)
        ItemInfoPnl.Name = "ItemInfoPnl"
        ItemInfoPnl.Size = New Size(410, 676)
        ItemInfoPnl.TabIndex = 0
        ' 
        ' SaveBtn
        ' 
        SaveBtn.BackColor = Color.SpringGreen
        SaveBtn.Enabled = False
        SaveBtn.FlatStyle = FlatStyle.Flat
        SaveBtn.Location = New Point(15, 517)
        SaveBtn.Margin = New Padding(3, 4, 3, 4)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Size = New Size(121, 59)
        SaveBtn.TabIndex = 12
        SaveBtn.Text = "Add"
        SaveBtn.UseVisualStyleBackColor = False
        SaveBtn.Visible = False
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.BackColor = Color.LightBlue
        UpdateBtn.Enabled = False
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Location = New Point(81, 599)
        UpdateBtn.Margin = New Padding(3, 4, 3, 4)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Size = New Size(121, 59)
        UpdateBtn.TabIndex = 11
        UpdateBtn.Text = "Update"
        UpdateBtn.UseVisualStyleBackColor = False
        UpdateBtn.Visible = False
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = SystemColors.ControlDark
        CancelBtn.Enabled = False
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Location = New Point(217, 599)
        CancelBtn.Margin = New Padding(3, 4, 3, 4)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(121, 59)
        CancelBtn.TabIndex = 10
        CancelBtn.Text = "Cancel"
        CancelBtn.UseVisualStyleBackColor = False
        CancelBtn.Visible = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 15F)
        Label4.Location = New Point(69, 45)
        Label4.Name = "Label4"
        Label4.Size = New Size(305, 35)
        Label4.TabIndex = 9
        Label4.Text = "Select an item to edit here"
        ' 
        ' PriceTxtBox
        ' 
        PriceTxtBox.Enabled = False
        PriceTxtBox.Location = New Point(145, 367)
        PriceTxtBox.Margin = New Padding(3, 4, 3, 4)
        PriceTxtBox.Name = "PriceTxtBox"
        PriceTxtBox.Size = New Size(81, 27)
        PriceTxtBox.TabIndex = 8
        PriceTxtBox.Visible = False
        ' 
        ' ItemNameTxtBox
        ' 
        ItemNameTxtBox.Enabled = False
        ItemNameTxtBox.Location = New Point(145, 301)
        ItemNameTxtBox.Margin = New Padding(3, 4, 3, 4)
        ItemNameTxtBox.Name = "ItemNameTxtBox"
        ItemNameTxtBox.Size = New Size(193, 27)
        ItemNameTxtBox.TabIndex = 7
        ItemNameTxtBox.Visible = False
        ' 
        ' DeleteBtn
        ' 
        DeleteBtn.BackColor = Color.IndianRed
        DeleteBtn.Enabled = False
        DeleteBtn.FlatStyle = FlatStyle.Flat
        DeleteBtn.Location = New Point(275, 517)
        DeleteBtn.Margin = New Padding(3, 4, 3, 4)
        DeleteBtn.Name = "DeleteBtn"
        DeleteBtn.Size = New Size(121, 59)
        DeleteBtn.TabIndex = 6
        DeleteBtn.Text = "Delete"
        DeleteBtn.UseVisualStyleBackColor = False
        DeleteBtn.Visible = False
        ' 
        ' EditBtn
        ' 
        EditBtn.BackColor = Color.Goldenrod
        EditBtn.Enabled = False
        EditBtn.FlatStyle = FlatStyle.Flat
        EditBtn.Location = New Point(147, 517)
        EditBtn.Margin = New Padding(3, 4, 3, 4)
        EditBtn.Name = "EditBtn"
        EditBtn.Size = New Size(121, 59)
        EditBtn.TabIndex = 5
        EditBtn.Text = "Edit"
        EditBtn.UseVisualStyleBackColor = False
        EditBtn.Visible = False
        ' 
        ' ItemBtn
        ' 
        ItemBtn.Enabled = False
        ItemBtn.Location = New Point(118, 45)
        ItemBtn.Margin = New Padding(3, 4, 3, 4)
        ItemBtn.Name = "ItemBtn"
        ItemBtn.Size = New Size(169, 184)
        ItemBtn.TabIndex = 2
        ItemBtn.Text = "Button1"
        ItemBtn.UseVisualStyleBackColor = True
        ItemBtn.Visible = False
        ' 
        ' PriceLbl
        ' 
        PriceLbl.AutoSize = True
        PriceLbl.Font = New Font("Segoe UI", 15F)
        PriceLbl.Location = New Point(77, 360)
        PriceLbl.Name = "PriceLbl"
        PriceLbl.Size = New Size(69, 35)
        PriceLbl.TabIndex = 1
        PriceLbl.Text = "Price"
        PriceLbl.Visible = False
        ' 
        ' ItemNameLbl
        ' 
        ItemNameLbl.AutoSize = True
        ItemNameLbl.Font = New Font("Segoe UI", 15F)
        ItemNameLbl.Location = New Point(19, 291)
        ItemNameLbl.Name = "ItemNameLbl"
        ItemNameLbl.Size = New Size(134, 35)
        ItemNameLbl.TabIndex = 0
        ItemNameLbl.Text = "Item name"
        ItemNameLbl.Visible = False
        ' 
        ' Manage_menu
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1190, 805)
        Controls.Add(NavbarPnl)
        Controls.Add(Panel1)
        Controls.Add(Panel2)
        Margin = New Padding(3, 4, 3, 4)
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
    ' new buttons on Manage_menu
    Friend WithEvents btnBack As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ItemInfoPnl As Panel
    Friend WithEvents ItemBtn As Button
    Friend WithEvents PriceLbl As Label
    Friend WithEvents ItemNameLbl As Label
    Friend WithEvents DeleteBtn As Button
    Friend WithEvents EditBtn As Button
    Friend WithEvents PriceTxtBox As TextBox
    Friend WithEvents ItemNameTxtBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CancelBtn As Button
    Friend WithEvents UpdateBtn As Button
    Friend WithEvents SaveBtn As Button
End Class
