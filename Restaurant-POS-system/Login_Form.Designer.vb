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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        UsernameTxtBox = New Guna.UI2.WinForms.Guna2TextBox()
        PasswordTxtBox = New Guna.UI2.WinForms.Guna2TextBox()
        UsernameLbl = New Label()
        PasswordLbl = New Label()
        LoginAsAdminBtn = New PictureBox()
        LoginBtn = New Guna.UI2.WinForms.Guna2Button()
        Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        PictureBox2 = New PictureBox()
        CType(LoginAsAdminBtn, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' UsernameTxtBox
        ' 
        UsernameTxtBox.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        UsernameTxtBox.BackColor = Color.Transparent
        UsernameTxtBox.BorderRadius = 10
        UsernameTxtBox.CustomizableEdges = CustomizableEdges1
        UsernameTxtBox.DefaultText = "user"
        UsernameTxtBox.Font = New Font("Segoe UI", 20F)
        UsernameTxtBox.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        UsernameTxtBox.Location = New Point(45, 234)
        UsernameTxtBox.Name = "UsernameTxtBox"
        UsernameTxtBox.PlaceholderText = ""
        UsernameTxtBox.SelectedText = ""
        UsernameTxtBox.ShadowDecoration.BorderRadius = 10
        UsernameTxtBox.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        UsernameTxtBox.ShadowDecoration.Depth = 20
        UsernameTxtBox.ShadowDecoration.Enabled = True
        UsernameTxtBox.ShadowDecoration.Shadow = New Padding(1, 1, 6, 6)
        UsernameTxtBox.Size = New Size(385, 43)
        UsernameTxtBox.TabIndex = 0
        ' 
        ' PasswordTxtBox
        ' 
        PasswordTxtBox.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        PasswordTxtBox.BackColor = Color.Transparent
        PasswordTxtBox.BorderRadius = 10
        PasswordTxtBox.CustomizableEdges = CustomizableEdges3
        PasswordTxtBox.DefaultText = "user"
        PasswordTxtBox.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        PasswordTxtBox.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        PasswordTxtBox.Location = New Point(45, 347)
        PasswordTxtBox.Name = "PasswordTxtBox"
        PasswordTxtBox.PasswordChar = "·"c
        PasswordTxtBox.PlaceholderText = ""
        PasswordTxtBox.SelectedText = ""
        PasswordTxtBox.ShadowDecoration.BorderRadius = 10
        PasswordTxtBox.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        PasswordTxtBox.ShadowDecoration.Depth = 20
        PasswordTxtBox.ShadowDecoration.Enabled = True
        PasswordTxtBox.ShadowDecoration.Shadow = New Padding(1, 1, 6, 6)
        PasswordTxtBox.Size = New Size(385, 43)
        PasswordTxtBox.TabIndex = 1
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
        LoginBtn.BackColor = Color.Transparent
        LoginBtn.BorderRadius = 10
        LoginBtn.Cursor = Cursors.Hand
        LoginBtn.CustomizableEdges = CustomizableEdges5
        LoginBtn.FillColor = Color.YellowGreen
        LoginBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LoginBtn.ForeColor = Color.White
        LoginBtn.Location = New Point(240, 421)
        LoginBtn.Name = "LoginBtn"
        LoginBtn.ShadowDecoration.BorderRadius = 10
        LoginBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        LoginBtn.ShadowDecoration.Depth = 20
        LoginBtn.ShadowDecoration.Enabled = True
        LoginBtn.ShadowDecoration.Shadow = New Padding(1, 1, 6, 6)
        LoginBtn.Size = New Size(190, 48)
        LoginBtn.TabIndex = 6
        LoginBtn.Text = "Login"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.Transparent
        Panel1.BorderRadius = 10
        Panel1.Controls.Add(LoginAsAdminBtn)
        Panel1.Controls.Add(UsernameTxtBox)
        Panel1.Controls.Add(PasswordTxtBox)
        Panel1.Controls.Add(UsernameLbl)
        Panel1.Controls.Add(LoginBtn)
        Panel1.Controls.Add(PasswordLbl)
        Panel1.Controls.Add(PictureBox2)
        Panel1.CustomizableEdges = CustomizableEdges7
        Panel1.FillColor = Color.SteelBlue
        Panel1.Location = New Point(268, 80)
        Panel1.Name = "Panel1"
        Panel1.ShadowDecoration.BorderRadius = 10
        Panel1.ShadowDecoration.Color = Color.DimGray
        Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Panel1.ShadowDecoration.Enabled = True
        Panel1.ShadowDecoration.Shadow = New Padding(1, 2, 7, 7)
        Panel1.Size = New Size(471, 523)
        Panel1.TabIndex = 8
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.BOLD_removebg_preview
        PictureBox2.Location = New Point(23, -11)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(426, 248)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 7
        PictureBox2.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        ClientSize = New Size(1041, 682)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "OrderUp!"
        CType(LoginAsAdminBtn, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents UsernameTxtBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents PasswordTxtBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents UsernameLbl As Label
    Friend WithEvents PasswordLbl As Label
    Friend WithEvents LoginAsAdminBtn As PictureBox
    Friend WithEvents LoginBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel1 As Guna.UI2.WinForms.Guna2Panel

End Class
