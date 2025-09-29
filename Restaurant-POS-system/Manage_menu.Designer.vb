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
        Panel1 = New Panel()
        MenuCategoryPnl = New FlowLayoutPanel()
        FoodPnl = New FlowLayoutPanel()
        Panel2 = New Panel()
        ItemInfoPnl = New Panel()
        Label4 = New Label()
        PriceTxtBox = New TextBox()
        ItemNameTxtBox = New TextBox()
        DeleteBtn = New Button()
        EditBtn = New Button()
        ItemBtn = New Button()
        PriceLbl = New Label()
        ItemNameLbl = New Label()
        Button1 = New Button()
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
        NavbarPnl.Location = New Point(414, 0)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(627, 68)
        NavbarPnl.TabIndex = 7
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
        Panel1.Size = New Size(628, 538)
        Panel1.TabIndex = 9
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        MenuCategoryPnl.BackColor = Color.WhiteSmoke
        MenuCategoryPnl.Location = New Point(3, 3)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(0, 0, 0, 20)
        MenuCategoryPnl.Size = New Size(1055, 60)
        MenuCategoryPnl.TabIndex = 1
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.BackColor = SystemColors.Control
        FoodPnl.Location = New Point(3, 60)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Size = New Size(1053, 916)
        FoodPnl.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel2.BackColor = SystemColors.ControlLight
        Panel2.Controls.Add(ItemInfoPnl)
        Panel2.Location = New Point(1, 1)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(405, 603)
        Panel2.TabIndex = 10
        ' 
        ' ItemInfoPnl
        ' 
        ItemInfoPnl.BackColor = SystemColors.ButtonFace
        ItemInfoPnl.Controls.Add(Button1)
        ItemInfoPnl.Controls.Add(Label4)
        ItemInfoPnl.Controls.Add(PriceTxtBox)
        ItemInfoPnl.Controls.Add(ItemNameTxtBox)
        ItemInfoPnl.Controls.Add(DeleteBtn)
        ItemInfoPnl.Controls.Add(EditBtn)
        ItemInfoPnl.Controls.Add(ItemBtn)
        ItemInfoPnl.Controls.Add(PriceLbl)
        ItemInfoPnl.Controls.Add(ItemNameLbl)
        ItemInfoPnl.Location = New Point(23, 65)
        ItemInfoPnl.Name = "ItemInfoPnl"
        ItemInfoPnl.Size = New Size(359, 444)
        ItemInfoPnl.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 15F)
        Label4.Location = New Point(60, 34)
        Label4.Name = "Label4"
        Label4.Size = New Size(240, 28)
        Label4.TabIndex = 9
        Label4.Text = "Select an item to edit here"
        ' 
        ' PriceTxtBox
        ' 
        PriceTxtBox.Enabled = False
        PriceTxtBox.Location = New Point(127, 275)
        PriceTxtBox.Name = "PriceTxtBox"
        PriceTxtBox.Size = New Size(71, 23)
        PriceTxtBox.TabIndex = 8
        PriceTxtBox.Visible = False
        ' 
        ' ItemNameTxtBox
        ' 
        ItemNameTxtBox.Enabled = False
        ItemNameTxtBox.Location = New Point(127, 226)
        ItemNameTxtBox.Name = "ItemNameTxtBox"
        ItemNameTxtBox.Size = New Size(169, 23)
        ItemNameTxtBox.TabIndex = 7
        ItemNameTxtBox.Visible = False
        ' 
        ' DeleteBtn
        ' 
        DeleteBtn.BackColor = Color.IndianRed
        DeleteBtn.FlatStyle = FlatStyle.Flat
        DeleteBtn.Location = New Point(241, 388)
        DeleteBtn.Name = "DeleteBtn"
        DeleteBtn.Size = New Size(106, 44)
        DeleteBtn.TabIndex = 6
        DeleteBtn.Text = "Delete"
        DeleteBtn.UseVisualStyleBackColor = False
        DeleteBtn.Visible = False
        ' 
        ' EditBtn
        ' 
        EditBtn.BackColor = Color.SpringGreen
        EditBtn.FlatStyle = FlatStyle.Flat
        EditBtn.Location = New Point(127, 388)
        EditBtn.Name = "EditBtn"
        EditBtn.Size = New Size(106, 44)
        EditBtn.TabIndex = 5
        EditBtn.Text = "Edit"
        EditBtn.UseVisualStyleBackColor = False
        EditBtn.Visible = False
        ' 
        ' ItemBtn
        ' 
        ItemBtn.Enabled = False
        ItemBtn.Location = New Point(103, 34)
        ItemBtn.Name = "ItemBtn"
        ItemBtn.Size = New Size(148, 138)
        ItemBtn.TabIndex = 2
        ItemBtn.Text = "Button1"
        ItemBtn.UseVisualStyleBackColor = True
        ItemBtn.Visible = False
        ' 
        ' PriceLbl
        ' 
        PriceLbl.AutoSize = True
        PriceLbl.Font = New Font("Segoe UI", 15F)
        PriceLbl.Location = New Point(67, 270)
        PriceLbl.Name = "PriceLbl"
        PriceLbl.Size = New Size(54, 28)
        PriceLbl.TabIndex = 1
        PriceLbl.Text = "Price"
        PriceLbl.Visible = False
        ' 
        ' ItemNameLbl
        ' 
        ItemNameLbl.AutoSize = True
        ItemNameLbl.Font = New Font("Segoe UI", 15F)
        ItemNameLbl.Location = New Point(17, 218)
        ItemNameLbl.Name = "ItemNameLbl"
        ItemNameLbl.Size = New Size(104, 28)
        ItemNameLbl.TabIndex = 0
        ItemNameLbl.Text = "Item name"
        ItemNameLbl.Visible = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.ControlDark
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(15, 388)
        Button1.Name = "Button1"
        Button1.Size = New Size(106, 44)
        Button1.TabIndex = 10
        Button1.Text = "Cancel"
        Button1.UseVisualStyleBackColor = False
        Button1.Visible = False
        ' 
        ' Manage_menu
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1041, 604)
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
    Friend WithEvents PriceLbl As Label
    Friend WithEvents ItemNameLbl As Label
    Friend WithEvents DeleteBtn As Button
    Friend WithEvents EditBtn As Button
    Friend WithEvents PriceTxtBox As TextBox
    Friend WithEvents ItemNameTxtBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
End Class
