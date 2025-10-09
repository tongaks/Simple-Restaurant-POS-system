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
        TextBox1 = New TextBox()
        Label4 = New Label()
        LoginPnl.SuspendLayout()
        DiscountPnl.SuspendLayout()
        SuspendLayout()
        ' 
        ' UsernameTxtBox
        ' 
        UsernameTxtBox.Location = New Point(54, 76)
        UsernameTxtBox.Name = "UsernameTxtBox"
        UsernameTxtBox.Size = New Size(296, 23)
        UsernameTxtBox.TabIndex = 0
        ' 
        ' PasswordTxtBox
        ' 
        PasswordTxtBox.Location = New Point(54, 131)
        PasswordTxtBox.Name = "PasswordTxtBox"
        PasswordTxtBox.Size = New Size(296, 23)
        PasswordTxtBox.TabIndex = 1
        ' 
        ' LoginBtn
        ' 
        LoginBtn.IconChar = FontAwesome.Sharp.IconChar.None
        LoginBtn.IconColor = Color.Black
        LoginBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        LoginBtn.Location = New Point(275, 171)
        LoginBtn.Name = "LoginBtn"
        LoginBtn.Size = New Size(75, 23)
        LoginBtn.TabIndex = 2
        LoginBtn.Text = "Login"
        LoginBtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(54, 58)
        Label1.Name = "Label1"
        Label1.Size = New Size(98, 15)
        Label1.TabIndex = 3
        Label1.Text = "Admin username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(54, 113)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 15)
        Label2.TabIndex = 4
        Label2.Text = "Admin password"
        ' 
        ' LoginPnl
        ' 
        LoginPnl.Controls.Add(Label3)
        LoginPnl.Controls.Add(PasswordTxtBox)
        LoginPnl.Controls.Add(Label2)
        LoginPnl.Controls.Add(UsernameTxtBox)
        LoginPnl.Controls.Add(Label1)
        LoginPnl.Controls.Add(LoginBtn)
        LoginPnl.Location = New Point(1, 1)
        LoginPnl.Name = "LoginPnl"
        LoginPnl.Size = New Size(401, 208)
        LoginPnl.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(20, 20)
        Label3.Name = "Label3"
        Label3.Size = New Size(98, 15)
        Label3.TabIndex = 5
        Label3.Text = "Admin credential"
        ' 
        ' DiscountPnl
        ' 
        DiscountPnl.Controls.Add(ApplyVoucherBtn)
        DiscountPnl.Controls.Add(TextBox1)
        DiscountPnl.Controls.Add(Label4)
        DiscountPnl.Enabled = False
        DiscountPnl.Location = New Point(0, 225)
        DiscountPnl.Name = "DiscountPnl"
        DiscountPnl.Size = New Size(405, 129)
        DiscountPnl.TabIndex = 6
        ' 
        ' ApplyVoucherBtn
        ' 
        ApplyVoucherBtn.IconChar = FontAwesome.Sharp.IconChar.None
        ApplyVoucherBtn.IconColor = Color.Black
        ApplyVoucherBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        ApplyVoucherBtn.Location = New Point(276, 84)
        ApplyVoucherBtn.Name = "ApplyVoucherBtn"
        ApplyVoucherBtn.Size = New Size(75, 23)
        ApplyVoucherBtn.TabIndex = 6
        ApplyVoucherBtn.Text = "Apply"
        ApplyVoucherBtn.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(53, 37)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(164, 23)
        TextBox1.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(53, 19)
        Label4.Name = "Label4"
        Label4.Size = New Size(85, 15)
        Label4.TabIndex = 7
        Label4.Text = "Discount value"
        ' 
        ' ApplyVoucher
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(398, 450)
        Controls.Add(DiscountPnl)
        Controls.Add(LoginPnl)
        Name = "ApplyVoucher"
        Text = "ApplyVoucher"
        LoginPnl.ResumeLayout(False)
        LoginPnl.PerformLayout()
        DiscountPnl.ResumeLayout(False)
        DiscountPnl.PerformLayout()
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
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
End Class
