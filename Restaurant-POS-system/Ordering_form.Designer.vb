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
        Button5 = New Button()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        AccountPicBox = New PictureBox()
        SettingsPicBox = New PictureBox()
        FoodPnl = New FlowLayoutPanel()
        Panel1 = New Panel()
        Button6 = New Button()
        MenuCategoryPnl = New FlowLayoutPanel()
        Button1 = New Button()
        TextBox1 = New TextBox()
        Label1 = New Label()
        OrderPnl = New FlowLayoutPanel()
        DataGridView1 = New DataGridView()
        TotalPnl = New Panel()
        TotalLbl = New Label()
        Label2 = New Label()
        NavbarPnl.SuspendLayout()
        CType(AccountPicBox, ComponentModel.ISupportInitialize).BeginInit()
        CType(SettingsPicBox, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        OrderPnl.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TotalPnl.SuspendLayout()
        SuspendLayout()
        ' 
        ' NavbarPnl
        ' 
        NavbarPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        NavbarPnl.BackColor = Color.Salmon
        NavbarPnl.Controls.Add(Button5)
        NavbarPnl.Controls.Add(Button4)
        NavbarPnl.Controls.Add(Button3)
        NavbarPnl.Controls.Add(Button2)
        NavbarPnl.Controls.Add(AccountPicBox)
        NavbarPnl.Controls.Add(SettingsPicBox)
        NavbarPnl.Location = New Point(-1, 0)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(1046, 68)
        NavbarPnl.TabIndex = 1
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(13, 23)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 23)
        Button5.TabIndex = 5
        Button5.Text = "Menu"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(617, 23)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 23)
        Button4.TabIndex = 4
        Button4.Text = "Hide"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(779, 23)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 3
        Button3.Text = "Settings"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(698, 23)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 2
        Button2.Text = "Account"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' AccountPicBox
        ' 
        AccountPicBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AccountPicBox.Location = New Point(983, 12)
        AccountPicBox.Name = "AccountPicBox"
        AccountPicBox.Size = New Size(47, 42)
        AccountPicBox.TabIndex = 1
        AccountPicBox.TabStop = False
        ' 
        ' SettingsPicBox
        ' 
        SettingsPicBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SettingsPicBox.Location = New Point(915, 12)
        SettingsPicBox.Name = "SettingsPicBox"
        SettingsPicBox.Size = New Size(47, 42)
        SettingsPicBox.TabIndex = 0
        SettingsPicBox.TabStop = False
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.BackColor = SystemColors.Control
        FoodPnl.BorderStyle = BorderStyle.FixedSingle
        FoodPnl.Location = New Point(397, 174)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Padding = New Padding(10)
        FoodPnl.Size = New Size(648, 430)
        FoodPnl.TabIndex = 2
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = SystemColors.Control
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Button6)
        Panel1.Controls.Add(MenuCategoryPnl)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(397, 66)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(645, 538)
        Panel1.TabIndex = 1
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.Salmon
        Button6.Location = New Point(480, 16)
        Button6.Name = "Button6"
        Button6.Size = New Size(75, 23)
        Button6.TabIndex = 6
        Button6.Text = "Hide"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.BorderStyle = BorderStyle.FixedSingle
        MenuCategoryPnl.Location = New Point(0, 58)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(10)
        MenuCategoryPnl.Size = New Size(645, 51)
        MenuCategoryPnl.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.SpringGreen
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(399, 16)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 2
        Button1.Text = "Search"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(84, 16)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(304, 23)
        TextBox1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(25, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 21)
        Label1.TabIndex = 0
        Label1.Text = "Search"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' OrderPnl
        ' 
        OrderPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        OrderPnl.BackColor = SystemColors.Control
        OrderPnl.BorderStyle = BorderStyle.FixedSingle
        OrderPnl.Controls.Add(DataGridView1)
        OrderPnl.FlowDirection = FlowDirection.TopDown
        OrderPnl.Location = New Point(-1, 66)
        OrderPnl.Name = "OrderPnl"
        OrderPnl.Size = New Size(392, 480)
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
        TotalPnl.Controls.Add(TotalLbl)
        TotalPnl.Controls.Add(Label2)
        TotalPnl.Location = New Point(-1, 546)
        TotalPnl.Name = "TotalPnl"
        TotalPnl.Size = New Size(392, 58)
        TotalPnl.TabIndex = 4
        ' 
        ' TotalLbl
        ' 
        TotalLbl.AutoSize = True
        TotalLbl.Font = New Font("Segoe UI", 20F)
        TotalLbl.Location = New Point(316, 11)
        TotalLbl.Name = "TotalLbl"
        TotalLbl.Size = New Size(48, 37)
        TotalLbl.TabIndex = 1
        TotalLbl.Text = "₱0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F)
        Label2.Location = New Point(12, 11)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 37)
        Label2.TabIndex = 0
        Label2.Text = "Total"
        ' 
        ' Order
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1041, 604)
        Controls.Add(TotalPnl)
        Controls.Add(NavbarPnl)
        Controls.Add(OrderPnl)
        Controls.Add(FoodPnl)
        Controls.Add(Panel1)
        Name = "Order"
        Text = "Order form"
        NavbarPnl.ResumeLayout(False)
        CType(AccountPicBox, ComponentModel.ISupportInitialize).EndInit()
        CType(SettingsPicBox, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        OrderPnl.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        TotalPnl.ResumeLayout(False)
        TotalPnl.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents NavbarPnl As Panel
    Friend WithEvents SettingsPicBox As PictureBox
    Friend WithEvents AccountPicBox As PictureBox
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents OrderPnl As FlowLayoutPanel
    Friend WithEvents TotalPnl As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TotalLbl As Label
    Friend WithEvents TestTable As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
End Class
