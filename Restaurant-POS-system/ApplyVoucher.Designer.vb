<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApplyVoucher
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        DiscountPnl = New Panel()
        Label6 = New Label()
        ComboBox1 = New ComboBox()
        ApplyVoucherBtn = New Guna.UI2.WinForms.Guna2Button()
        DiscountTxtBox = New Guna.UI2.WinForms.Guna2TextBox()
        Label4 = New Label()
        CancelBtn = New Guna.UI2.WinForms.Guna2Button()
        Panel1 = New Panel()
        Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Label3 = New Label()
        DiscountPnl.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DiscountPnl
        ' 
        DiscountPnl.Controls.Add(Label6)
        DiscountPnl.Controls.Add(ComboBox1)
        DiscountPnl.Controls.Add(ApplyVoucherBtn)
        DiscountPnl.Controls.Add(DiscountTxtBox)
        DiscountPnl.Controls.Add(Label4)
        DiscountPnl.Location = New Point(-1, 78)
        DiscountPnl.Name = "DiscountPnl"
        DiscountPnl.Size = New Size(405, 179)
        DiscountPnl.TabIndex = 6
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 14F)
        Label6.Location = New Point(49, 14)
        Label6.Name = "Label6"
        Label6.Size = New Size(127, 25)
        Label6.TabIndex = 9
        Label6.Text = "Discount type"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 15F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(53, 42)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(255, 36)
        ComboBox1.TabIndex = 8
        ComboBox1.Text = "Select discount type here"
        ' 
        ' ApplyVoucherBtn
        ' 
        ApplyVoucherBtn.BackColor = Color.Transparent
        ApplyVoucherBtn.BorderRadius = 10
        ApplyVoucherBtn.CustomizableEdges = CustomizableEdges1
        ApplyVoucherBtn.FillColor = Color.ForestGreen
        ApplyVoucherBtn.Font = New Font("Segoe UI Semibold", 9.75F)
        ApplyVoucherBtn.ForeColor = Color.White
        ApplyVoucherBtn.Location = New Point(266, 124)
        ApplyVoucherBtn.Name = "ApplyVoucherBtn"
        ApplyVoucherBtn.ShadowDecoration.BorderRadius = 10
        ApplyVoucherBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        ApplyVoucherBtn.ShadowDecoration.Enabled = True
        ApplyVoucherBtn.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        ApplyVoucherBtn.Size = New Size(109, 35)
        ApplyVoucherBtn.TabIndex = 6
        ApplyVoucherBtn.Text = "Apply"
        ' 
        ' DiscountTxtBox
        ' 
        DiscountTxtBox.CustomizableEdges = CustomizableEdges3
        DiscountTxtBox.DefaultText = ""
        DiscountTxtBox.Font = New Font("Segoe UI", 15F)
        DiscountTxtBox.ForeColor = Color.Black
        DiscountTxtBox.Location = New Point(53, 124)
        DiscountTxtBox.Name = "DiscountTxtBox"
        DiscountTxtBox.PlaceholderText = ""
        DiscountTxtBox.SelectedText = ""
        DiscountTxtBox.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        DiscountTxtBox.Size = New Size(191, 34)
        DiscountTxtBox.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 14F)
        Label4.Location = New Point(49, 96)
        Label4.Name = "Label4"
        Label4.Size = New Size(136, 25)
        Label4.TabIndex = 7
        Label4.Text = "Discount value"
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.Transparent
        CancelBtn.BorderRadius = 10
        CancelBtn.CustomizableEdges = CustomizableEdges5
        CancelBtn.FillColor = Color.Gray
        CancelBtn.Font = New Font("Segoe UI Semibold", 9F)
        CancelBtn.ForeColor = Color.White
        CancelBtn.Location = New Point(12, 267)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.ShadowDecoration.BorderRadius = 10
        CancelBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        CancelBtn.ShadowDecoration.Enabled = True
        CancelBtn.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        CancelBtn.Size = New Size(374, 33)
        CancelBtn.TabIndex = 5
        CancelBtn.Text = "Cancel"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.SteelBlue
        Panel1.Controls.Add(Guna2Button1)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(1, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(398, 72)
        Panel1.TabIndex = 8
        ' 
        ' Guna2Button1
        ' 
        Guna2Button1.BackColor = Color.Transparent
        Guna2Button1.BorderRadius = 10
        Guna2Button1.CustomizableEdges = CustomizableEdges7
        Guna2Button1.FillColor = Color.Gold
        Guna2Button1.Font = New Font("Segoe UI Semibold", 9F)
        Guna2Button1.ForeColor = Color.Black
        Guna2Button1.Location = New Point(276, 21)
        Guna2Button1.Name = "Guna2Button1"
        Guna2Button1.ShadowDecoration.BorderRadius = 10
        Guna2Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Guna2Button1.ShadowDecoration.Enabled = True
        Guna2Button1.ShadowDecoration.Shadow = New Padding(1, 1, 5, 5)
        Guna2Button1.Size = New Size(109, 35)
        Guna2Button1.TabIndex = 10
        Guna2Button1.Text = "Edit discounts"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 15F)
        Label3.ForeColor = SystemColors.ButtonHighlight
        Label3.Location = New Point(26, 21)
        Label3.Name = "Label3"
        Label3.Size = New Size(148, 28)
        Label3.TabIndex = 5
        Label3.Text = "Apply discount"
        ' 
        ' ApplyVoucher
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(398, 312)
        Controls.Add(Panel1)
        Controls.Add(CancelBtn)
        Controls.Add(DiscountPnl)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "ApplyVoucher"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ApplyVoucher"
        DiscountPnl.ResumeLayout(False)
        DiscountPnl.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents DiscountPnl As Panel
    Friend WithEvents ApplyVoucherBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents DiscountTxtBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CancelBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
End Class
