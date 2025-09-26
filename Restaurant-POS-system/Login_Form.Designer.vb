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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        PictureBox1 = New PictureBox()
        LoginBtn = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' UsernameTxtBox
        ' 
        UsernameTxtBox.Location = New Point(72, 219)
        UsernameTxtBox.Name = "UsernameTxtBox"
        UsernameTxtBox.Size = New Size(385, 23)
        UsernameTxtBox.TabIndex = 0
        ' 
        ' PasswordTxtBox
        ' 
        PasswordTxtBox.Location = New Point(69, 310)
        PasswordTxtBox.Name = "PasswordTxtBox"
        PasswordTxtBox.Size = New Size(385, 23)
        PasswordTxtBox.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(75, 201)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 15)
        Label1.TabIndex = 2
        Label1.Text = "Username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(72, 292)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 15)
        Label2.TabIndex = 3
        Label2.Text = "Password"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(72, 91)
        Label3.Name = "Label3"
        Label3.Size = New Size(55, 15)
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
        LoginBtn.Location = New Point(267, 397)
        LoginBtn.Name = "LoginBtn"
        LoginBtn.Size = New Size(190, 23)
        LoginBtn.TabIndex = 6
        LoginBtn.Text = "Login"
        LoginBtn.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1041, 604)
        Controls.Add(LoginBtn)
        Controls.Add(PictureBox1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
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
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LoginBtn As Button

End Class
