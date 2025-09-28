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
        SearchTxtBox = New TextBox()
        Label1 = New Label()
        SearchBtn = New Button()
        Button3 = New Button()
        Button2 = New Button()
        OrderPnl = New FlowLayoutPanel()
        DataGridView1 = New DataGridView()
        TotalPnl = New Panel()
        Button1 = New Button()
        TotalLbl = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
        MenuCategoryPnl = New FlowLayoutPanel()
        FoodPnl = New FlowLayoutPanel()
        NavbarPnl.SuspendLayout()
        OrderPnl.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TotalPnl.SuspendLayout()
        Panel1.SuspendLayout()
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
        NavbarPnl.TabIndex = 1
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
        Label1.Location = New Point(17, 25)
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
        Button3.Location = New Point(542, 27)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 3
        Button3.Text = "Settings"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.Location = New Point(461, 27)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 2
        Button2.Text = "Account"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' OrderPnl
        ' 
        OrderPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        OrderPnl.BackColor = SystemColors.Control
        OrderPnl.BorderStyle = BorderStyle.FixedSingle
        OrderPnl.Controls.Add(DataGridView1)
        OrderPnl.FlowDirection = FlowDirection.TopDown
        OrderPnl.Location = New Point(-1, 0)
        OrderPnl.Name = "OrderPnl"
        OrderPnl.Size = New Size(409, 546)
        OrderPnl.TabIndex = 3
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(3, 3)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(240, 150)
        DataGridView1.TabIndex = 0
        DataGridView1.Visible = False
        ' 
        ' TotalPnl
        ' 
        TotalPnl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        TotalPnl.BackColor = SystemColors.Control
        TotalPnl.BorderStyle = BorderStyle.FixedSingle
        TotalPnl.Controls.Add(Button1)
        TotalPnl.Controls.Add(TotalLbl)
        TotalPnl.Controls.Add(Label2)
        TotalPnl.Location = New Point(-1, 546)
        TotalPnl.Name = "TotalPnl"
        TotalPnl.Size = New Size(409, 58)
        TotalPnl.TabIndex = 4
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.LightGreen
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(271, 9)
        Button1.Name = "Button1"
        Button1.Size = New Size(125, 38)
        Button1.TabIndex = 2
        Button1.Text = "Proceed"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TotalLbl
        ' 
        TotalLbl.AutoSize = True
        TotalLbl.Font = New Font("Segoe UI", 20F)
        TotalLbl.Location = New Point(146, 9)
        TotalLbl.Name = "TotalLbl"
        TotalLbl.Size = New Size(48, 37)
        TotalLbl.TabIndex = 1
        TotalLbl.Text = "₱0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F)
        Label2.Location = New Point(12, 7)
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
        Panel1.Location = New Point(414, 66)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(628, 538)
        Panel1.TabIndex = 5
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        MenuCategoryPnl.BackColor = Color.WhiteSmoke
        MenuCategoryPnl.Location = New Point(3, 3)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(0, 0, 0, 20)
        MenuCategoryPnl.Size = New Size(627, 60)
        MenuCategoryPnl.TabIndex = 1
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.BackColor = SystemColors.Control
        FoodPnl.Location = New Point(3, 60)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Size = New Size(625, 478)
        FoodPnl.TabIndex = 2
        ' 
        ' Order
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1041, 604)
        Controls.Add(NavbarPnl)
        Controls.Add(Panel1)
        Controls.Add(TotalPnl)
        Controls.Add(OrderPnl)
        Name = "Order"
        Text = "Order form"
        NavbarPnl.ResumeLayout(False)
        NavbarPnl.PerformLayout()
        OrderPnl.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        TotalPnl.ResumeLayout(False)
        TotalPnl.PerformLayout()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents NavbarPnl As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents SearchBtn As Button
    Friend WithEvents OrderPnl As FlowLayoutPanel
    Friend WithEvents TotalPnl As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TotalLbl As Label
    Friend WithEvents TestTable As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents SearchTxtBox As TextBox
    Friend WithEvents Label1 As Label
End Class
