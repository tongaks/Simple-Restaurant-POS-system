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
        UsernameTxtBox = New TextBox()
        PasswordTxtBox = New TextBox()
        LoginBtn = New FontAwesome.Sharp.IconButton()
        Label1 = New Label()
        Label2 = New Label()
        LoginPnl = New Panel()
        Label3 = New Label()
        DiscountPnl = New Panel()
        ApplyVoucherBtn = New FontAwesome.Sharp.IconButton()
        DiscountTxtBox = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        Panel1 = New Panel()
        ComboBox1 = New ComboBox()
        Label6 = New Label()
        LoginPnl.SuspendLayout()
        DiscountPnl.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' UsernameTxtBox
        ' 
        UsernameTxtBox.Font = New Font("Segoe UI", 15F)
        UsernameTxtBox.Location = New Point(53, 121)
        UsernameTxtBox.Name = "UsernameTxtBox"
        UsernameTxtBox.Size = New Size(296, 34)
        UsernameTxtBox.TabIndex = 0
        ' 
        ' PasswordTxtBox
        ' 
        PasswordTxtBox.Font = New Font("Segoe UI", 15F)
        PasswordTxtBox.Location = New Point(55, 195)
        PasswordTxtBox.Name = "PasswordTxtBox"
        PasswordTxtBox.PasswordChar = "·"c
        PasswordTxtBox.Size = New Size(296, 34)
        PasswordTxtBox.TabIndex = 1
        ' 
        ' LoginBtn
        ' 
        LoginBtn.BackColor = Color.SpringGreen
        LoginBtn.FlatStyle = FlatStyle.Flat
        LoginBtn.IconChar = FontAwesome.Sharp.IconChar.None
        LoginBtn.IconColor = Color.Black
        LoginBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        LoginBtn.Location = New Point(276, 246)
        LoginBtn.Name = "LoginBtn"
        LoginBtn.Size = New Size(75, 33)
        LoginBtn.TabIndex = 2
        LoginBtn.Text = "Login"
        LoginBtn.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14F)
        Label1.Location = New Point(53, 94)
        Label1.Name = "Label1"
        Label1.Size = New Size(155, 25)
        Label1.TabIndex = 3
        Label1.Text = "Admin username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 14F)
        Label2.Location = New Point(55, 168)
        Label2.Name = "Label2"
        Label2.Size = New Size(152, 25)
        Label2.TabIndex = 4
        Label2.Text = "Admin password"
        ' 
        ' LoginPnl
        ' 
        LoginPnl.Controls.Add(PasswordTxtBox)
        LoginPnl.Controls.Add(Label2)
        LoginPnl.Controls.Add(UsernameTxtBox)
        LoginPnl.Controls.Add(Label1)
        LoginPnl.Controls.Add(LoginBtn)
        LoginPnl.Location = New Point(1, 1)
        LoginPnl.Name = "LoginPnl"
        LoginPnl.Size = New Size(401, 298)
        LoginPnl.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 15F)
        Label3.ForeColor = SystemColors.ButtonHighlight
        Label3.Location = New Point(15, 7)
        Label3.Name = "Label3"
        Label3.Size = New Size(161, 28)
        Label3.TabIndex = 5
        Label3.Text = "Admin credential"
        ' 
        ' DiscountPnl
        ' 
        DiscountPnl.Controls.Add(Label6)
        DiscountPnl.Controls.Add(ComboBox1)
        DiscountPnl.Controls.Add(ApplyVoucherBtn)
        DiscountPnl.Controls.Add(DiscountTxtBox)
        DiscountPnl.Controls.Add(Label4)
        DiscountPnl.Enabled = False
        DiscountPnl.Location = New Point(1, 305)
        DiscountPnl.Name = "DiscountPnl"
        DiscountPnl.Size = New Size(405, 179)
        DiscountPnl.TabIndex = 6
        ' 
        ' ApplyVoucherBtn
        ' 
        ApplyVoucherBtn.BackColor = Color.SpringGreen
        ApplyVoucherBtn.FlatStyle = FlatStyle.Flat
        ApplyVoucherBtn.IconChar = FontAwesome.Sharp.IconChar.None
        ApplyVoucherBtn.IconColor = Color.Black
        ApplyVoucherBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        ApplyVoucherBtn.Location = New Point(265, 104)
        ApplyVoucherBtn.Name = "ApplyVoucherBtn"
        ApplyVoucherBtn.Size = New Size(109, 35)
        ApplyVoucherBtn.TabIndex = 6
        ApplyVoucherBtn.Text = "Apply"
        ApplyVoucherBtn.UseVisualStyleBackColor = False
        ' 
        ' DiscountTxtBox
        ' 
        DiscountTxtBox.Font = New Font("Segoe UI", 15F)
        DiscountTxtBox.Location = New Point(53, 124)
        DiscountTxtBox.Name = "DiscountTxtBox"
        DiscountTxtBox.Size = New Size(164, 34)
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
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.ButtonHighlight
        Label5.Location = New Point(15, 37)
        Label5.Name = "Label5"
        Label5.Size = New Size(377, 21)
        Label5.TabIndex = 6
        Label5.Text = "Enter the admin's credentials to apply the discount"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkSeaGreen
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(1, -1)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(398, 72)
        Panel1.TabIndex = 7
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 15F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(53, 42)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(162, 36)
        ComboBox1.TabIndex = 8
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
        ' ApplyVoucher
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(398, 496)
        Controls.Add(Panel1)
        Controls.Add(DiscountPnl)
        Controls.Add(LoginPnl)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "ApplyVoucher"
        Text = "ApplyVoucher"
        LoginPnl.ResumeLayout(False)
        LoginPnl.PerformLayout()
        DiscountPnl.ResumeLayout(False)
        DiscountPnl.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents UsernameTxtBox As TextBox
    Friend WithEvents PasswordTxtBox As TextBox
    Friend WithEvents LoginBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LoginPnl As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents DiscountPnl As Panel
    Friend WithEvents ApplyVoucherBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents DiscountTxtBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label6 As Label
End Class
