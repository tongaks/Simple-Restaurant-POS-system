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
        PictureBox1 = New PictureBox()
        LoginBtn = New Button()
        LoginAsAdminBtn = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' UsernameTxtBox
        ' 
        UsernameTxtBox.Font = New Font("Segoe UI", 20F)
        UsernameTxtBox.Location = New Point(72, 255)
        UsernameTxtBox.Name = "UsernameTxtBox"
        UsernameTxtBox.Size = New Size(385, 43)
        UsernameTxtBox.TabIndex = 0
        UsernameTxtBox.Text = "user"
        ' 
        ' PasswordTxtBox
        ' 
        PasswordTxtBox.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        PasswordTxtBox.Location = New Point(72, 368)
        PasswordTxtBox.Name = "PasswordTxtBox"
        PasswordTxtBox.PasswordChar = "·"c
        PasswordTxtBox.Size = New Size(385, 43)
        PasswordTxtBox.TabIndex = 1
        PasswordTxtBox.Text = "user"
        ' 
        ' UsernameLbl
        ' 
        UsernameLbl.AutoSize = True
        UsernameLbl.Font = New Font("Segoe UI", 20F)
        UsernameLbl.Location = New Point(72, 215)
        UsernameLbl.Name = "UsernameLbl"
        UsernameLbl.Size = New Size(136, 37)
        UsernameLbl.TabIndex = 2
        UsernameLbl.Text = "Username"
        ' 
        ' PasswordLbl
        ' 
        PasswordLbl.AutoSize = True
        PasswordLbl.Font = New Font("Segoe UI", 20F)
        PasswordLbl.Location = New Point(72, 328)
        PasswordLbl.Name = "PasswordLbl"
        PasswordLbl.Size = New Size(128, 37)
        PasswordLbl.TabIndex = 3
        PasswordLbl.Text = "Password"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 30F)
        Label3.Location = New Point(72, 115)
        Label3.Name = "Label3"
        Label3.Size = New Size(188, 54)
        Label3.TabIndex = 4
        Label3.Text = "OrderUp!"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(669, 185)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(199, 190)
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' LoginBtn
        ' 
        LoginBtn.BackColor = Color.SpringGreen
        LoginBtn.FlatStyle = FlatStyle.Flat
        LoginBtn.Location = New Point(267, 442)
        LoginBtn.Name = "LoginBtn"
        LoginBtn.Size = New Size(190, 48)
        LoginBtn.TabIndex = 6
        LoginBtn.Text = "Login"
        LoginBtn.UseVisualStyleBackColor = False
        ' 
        ' LoginAsAdminBtn
        ' 
        LoginAsAdminBtn.BackColor = Color.DarkSeaGreen
        LoginAsAdminBtn.FlatStyle = FlatStyle.Flat
        LoginAsAdminBtn.Location = New Point(72, 442)
        LoginAsAdminBtn.Name = "LoginAsAdminBtn"
        LoginAsAdminBtn.Size = New Size(122, 48)
        LoginAsAdminBtn.TabIndex = 7
        LoginAsAdminBtn.Text = "Login as admin"
        LoginAsAdminBtn.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1041, 604)
        Controls.Add(LoginAsAdminBtn)
        Controls.Add(LoginBtn)
        Controls.Add(PictureBox1)
        Controls.Add(Label3)
        Controls.Add(PasswordLbl)
        Controls.Add(UsernameLbl)
        Controls.Add(PasswordTxtBox)
        Controls.Add(UsernameTxtBox)
        Name = "Form1"
        Text = "OrderUp!"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents UsernameTxtBox As TextBox
    Friend WithEvents PasswordTxtBox As TextBox
    Friend WithEvents UsernameLbl As Label
    Friend WithEvents PasswordLbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LoginBtn As Button
    Friend WithEvents LoginAsAdminBtn As Button

End Class
