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
        OrderPnl = New Panel()
        NavbarPnl = New Panel()
        AccountPicBox = New PictureBox()
        SettingsPicBox = New PictureBox()
        FoodPnl = New FlowLayoutPanel()
        Panel1 = New Panel()
        MenuCategoryPnl = New FlowLayoutPanel()
        Button1 = New Button()
        TextBox1 = New TextBox()
        Label1 = New Label()
        NavbarPnl.SuspendLayout()
        CType(AccountPicBox, ComponentModel.ISupportInitialize).BeginInit()
        CType(SettingsPicBox, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' OrderPnl
        ' 
        OrderPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        OrderPnl.BackColor = SystemColors.Control
        OrderPnl.Location = New Point(2, 66)
        OrderPnl.Name = "OrderPnl"
        OrderPnl.Size = New Size(392, 538)
        OrderPnl.TabIndex = 0
        ' 
        ' NavbarPnl
        ' 
        NavbarPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        NavbarPnl.BackColor = Color.Salmon
        NavbarPnl.Controls.Add(AccountPicBox)
        NavbarPnl.Controls.Add(SettingsPicBox)
        NavbarPnl.Location = New Point(-1, 0)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(1046, 68)
        NavbarPnl.TabIndex = 1
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
        Panel1.Controls.Add(MenuCategoryPnl)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(397, 66)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(645, 538)
        Panel1.TabIndex = 1
        ' 
        ' MenuCategoryPnl
        ' 
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
        ' Order
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1041, 604)
        Controls.Add(NavbarPnl)
        Controls.Add(FoodPnl)
        Controls.Add(Panel1)
        Controls.Add(OrderPnl)
        Name = "Order"
        Text = "Order form"
        NavbarPnl.ResumeLayout(False)
        CType(AccountPicBox, ComponentModel.ISupportInitialize).EndInit()
        CType(SettingsPicBox, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents OrderPnl As Panel
    Friend WithEvents NavbarPnl As Panel
    Friend WithEvents SettingsPicBox As PictureBox
    Friend WithEvents AccountPicBox As PictureBox
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
    Friend WithEvents Button1 As Button
End Class
