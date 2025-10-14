<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        UsernameTxtBox = New TextBox()
        PasswordTxtBox = New TextBox()
        UsernameLbl = New Label()
        PasswordLbl = New Label()
        Label3 = New Label()
        LoginAsAdminBtn = New PictureBox()
        LoginBtn = New Button()
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        CType(LoginAsAdminBtn, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' UsernameTxtBox
        ' 
        UsernameTxtBox.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        UsernameTxtBox.Font = New Font("Segoe UI", 20F)
        UsernameTxtBox.Location = New Point(45, 234)
        UsernameTxtBox.Name = "UsernameTxtBox"
        UsernameTxtBox.Size = New Size(385, 43)
        UsernameTxtBox.TabIndex = 0
        UsernameTxtBox.Text = "user"
        ' 
        ' PasswordTxtBox
        ' 
        PasswordTxtBox.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        PasswordTxtBox.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        PasswordTxtBox.Location = New Point(45, 347)
        PasswordTxtBox.Name = "PasswordTxtBox"
        PasswordTxtBox.PasswordChar = "·"c
        PasswordTxtBox.Size = New Size(385, 43)
        PasswordTxtBox.TabIndex = 1
        PasswordTxtBox.Text = "user"
        ' 
        ' UsernameLbl
        ' 
        UsernameLbl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        UsernameLbl.AutoSize = True
        UsernameLbl.Font = New Font("Segoe UI", 20F)
        UsernameLbl.Location = New Point(45, 194)
        UsernameLbl.Name = "UsernameLbl"
        UsernameLbl.Size = New Size(136, 37)
        UsernameLbl.TabIndex = 2
        UsernameLbl.Text = "Username"
        ' 
        ' PasswordLbl
        ' 
        PasswordLbl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        PasswordLbl.AutoSize = True
        PasswordLbl.Font = New Font("Segoe UI", 20F)
        PasswordLbl.Location = New Point(45, 307)
        PasswordLbl.Name = "PasswordLbl"
        PasswordLbl.Size = New Size(128, 37)
        PasswordLbl.TabIndex = 3
        PasswordLbl.Text = "Password"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Label3.AutoSize = True
        Label3.Font = New Font("Showcard Gothic", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(45, 94)
        Label3.Name = "Label3"
        Label3.Size = New Size(272, 60)
        Label3.TabIndex = 4
        Label3.Text = "OrderUp!"
        ' 
        ' LoginAsAdminBtn
        ' 
        LoginAsAdminBtn.Anchor = AnchorStyles.Top
        LoginAsAdminBtn.Image = My.Resources.Resources.admin_icon
        LoginAsAdminBtn.Location = New Point(420, 13)
        LoginAsAdminBtn.Name = "LoginAsAdminBtn"
        LoginAsAdminBtn.Size = New Size(39, 39)
        LoginAsAdminBtn.SizeMode = PictureBoxSizeMode.StretchImage
        LoginAsAdminBtn.TabIndex = 5
        LoginAsAdminBtn.TabStop = False
        ' 
        ' LoginBtn
        ' 
        LoginBtn.BackColor = Color.SpringGreen
        LoginBtn.FlatStyle = FlatStyle.Flat
        LoginBtn.Location = New Point(240, 421)
        LoginBtn.Name = "LoginBtn"
        LoginBtn.Size = New Size(190, 48)
        LoginBtn.TabIndex = 6
        LoginBtn.Text = "Login"
        LoginBtn.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel1.BackColor = Color.MediumSeaGreen
        Panel1.Controls.Add(LoginAsAdminBtn)
        Panel1.Controls.Add(UsernameTxtBox)
        Panel1.Controls.Add(PasswordTxtBox)
        Panel1.Controls.Add(UsernameLbl)
        Panel1.Controls.Add(LoginBtn)
        Panel1.Controls.Add(PasswordLbl)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(-1, -1)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(471, 608)
        Panel1.TabIndex = 8
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.Image = My.Resources.Resources.login_page_photo
        PictureBox1.Location = New Point(471, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(573, 606)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1041, 604)
        Controls.Add(PictureBox1)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "OrderUp!"
        CType(LoginAsAdminBtn, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents UsernameTxtBox As TextBox
    Friend WithEvents PasswordTxtBox As TextBox
    Friend WithEvents UsernameLbl As Label
    Friend WithEvents PasswordLbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LoginAsAdminBtn As PictureBox
    Friend WithEvents LoginBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox

End Class
