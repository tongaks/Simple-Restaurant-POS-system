<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ApplyVoucher
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblSubtitle = New Label()
        lblTitle = New Label()
        pnlMain = New Panel()
        DiscountPnl = New Panel()
        ApplyVoucherBtn = New FontAwesome.Sharp.IconButton()
        pnlDiscountFields = New Panel()
        DiscountTxtBox = New TextBox()
        Label4 = New Label()
        ComboBox1 = New ComboBox()
        Label6 = New Label()
        LoginPnl = New Panel()
        LoginBtn = New FontAwesome.Sharp.IconButton()
        pnlLoginFields = New Panel()
        PasswordTxtBox = New TextBox()
        Label2 = New Label()
        UsernameTxtBox = New TextBox()
        Label1 = New Label()
        pnlActions = New Panel()
        CancelBtn = New Button()
        pnlHeader.SuspendLayout()
        pnlMain.SuspendLayout()
        DiscountPnl.SuspendLayout()
        pnlDiscountFields.SuspendLayout()
        LoginPnl.SuspendLayout()
        pnlLoginFields.SuspendLayout()
        pnlActions.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(30, 20, 30, 10)
        pnlHeader.Size = New Size(500, 100)
        pnlHeader.TabIndex = 0
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Dock = DockStyle.Top
        lblSubtitle.Font = New Font("Segoe UI", 10F)
        lblSubtitle.ForeColor = Color.White
        lblSubtitle.Location = New Point(30, 57)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Padding = New Padding(0, 5, 0, 0)
        lblSubtitle.Size = New Size(357, 28)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Enter admin credentials to apply the discount"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(30, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(213, 37)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Apply Discount"
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlMain.Controls.Add(DiscountPnl)
        pnlMain.Controls.Add(LoginPnl)
        pnlMain.Controls.Add(pnlActions)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 100)
        pnlMain.Name = "pnlMain"
        pnlMain.Padding = New Padding(30, 20, 30, 20)
        pnlMain.Size = New Size(500, 450)
        pnlMain.TabIndex = 1
        ' 
        ' DiscountPnl
        ' 
        DiscountPnl.BackColor = Color.White
        DiscountPnl.BorderStyle = BorderStyle.FixedSingle
        DiscountPnl.Controls.Add(ApplyVoucherBtn)
        DiscountPnl.Controls.Add(pnlDiscountFields)
        DiscountPnl.Dock = DockStyle.Top
        DiscountPnl.Enabled = False
        DiscountPnl.Location = New Point(30, 220)
        DiscountPnl.Name = "DiscountPnl"
        DiscountPnl.Padding = New Padding(30, 20, 30, 20)
        DiscountPnl.Size = New Size(440, 180)
        DiscountPnl.TabIndex = 1
        ' 
        ' ApplyVoucherBtn
        ' 
        ApplyVoucherBtn.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        ApplyVoucherBtn.Cursor = Cursors.Hand
        ApplyVoucherBtn.Dock = DockStyle.Bottom
        ApplyVoucherBtn.FlatAppearance.BorderSize = 0
        ApplyVoucherBtn.FlatStyle = FlatStyle.Flat
        ApplyVoucherBtn.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        ApplyVoucherBtn.ForeColor = Color.White
        ApplyVoucherBtn.IconChar = FontAwesome.Sharp.IconChar.Check
        ApplyVoucherBtn.IconColor = Color.White
        ApplyVoucherBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        ApplyVoucherBtn.IconSize = 24
        ApplyVoucherBtn.ImageAlign = ContentAlignment.MiddleLeft
        ApplyVoucherBtn.Location = New Point(30, 118)
        ApplyVoucherBtn.Name = "ApplyVoucherBtn"
        ApplyVoucherBtn.Padding = New Padding(10, 0, 10, 0)
        ApplyVoucherBtn.Size = New Size(378, 40)
        ApplyVoucherBtn.TabIndex = 1
        ApplyVoucherBtn.Text = "Apply Discount"
        ApplyVoucherBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ApplyVoucherBtn.UseVisualStyleBackColor = False
        ' 
        ' pnlDiscountFields
        ' 
        pnlDiscountFields.Controls.Add(DiscountTxtBox)
        pnlDiscountFields.Controls.Add(Label4)
        pnlDiscountFields.Controls.Add(ComboBox1)
        pnlDiscountFields.Controls.Add(Label6)
        pnlDiscountFields.Dock = DockStyle.Top
        pnlDiscountFields.Location = New Point(30, 20)
        pnlDiscountFields.Name = "pnlDiscountFields"
        pnlDiscountFields.Size = New Size(378, 100)
        pnlDiscountFields.TabIndex = 0
        ' 
        ' DiscountTxtBox
        ' 
        DiscountTxtBox.Font = New Font("Segoe UI", 11F)
        DiscountTxtBox.Location = New Point(200, 53)
        DiscountTxtBox.Name = "DiscountTxtBox"
        DiscountTxtBox.Size = New Size(170, 32)
        DiscountTxtBox.TabIndex = 3
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F)
        Label4.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label4.Location = New Point(10, 55)
        Label4.Name = "Label4"
        Label4.Size = New Size(124, 23)
        Label4.TabIndex = 2
        Label4.Text = "Discount Value"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 11F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Senior", "Student", "PWD"})
        ComboBox1.Location = New Point(200, 3)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(170, 33)
        ComboBox1.TabIndex = 1
        ComboBox1.Text = "Select type"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F)
        Label6.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label6.Location = New Point(10, 5)
        Label6.Name = "Label6"
        Label6.Size = New Size(117, 23)
        Label6.TabIndex = 0
        Label6.Text = "Discount Type"
        ' 
        ' LoginPnl
        ' 
        LoginPnl.BackColor = Color.White
        LoginPnl.BorderStyle = BorderStyle.FixedSingle
        LoginPnl.Controls.Add(LoginBtn)
        LoginPnl.Controls.Add(pnlLoginFields)
        LoginPnl.Dock = DockStyle.Top
        LoginPnl.Location = New Point(30, 20)
        LoginPnl.Name = "LoginPnl"
        LoginPnl.Padding = New Padding(30, 20, 30, 20)
        LoginPnl.Size = New Size(440, 200)
        LoginPnl.TabIndex = 0
        ' 
        ' LoginBtn
        ' 
        LoginBtn.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        LoginBtn.Cursor = Cursors.Hand
        LoginBtn.Dock = DockStyle.Bottom
        LoginBtn.FlatAppearance.BorderSize = 0
        LoginBtn.FlatStyle = FlatStyle.Flat
        LoginBtn.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        LoginBtn.ForeColor = Color.White
        LoginBtn.IconChar = FontAwesome.Sharp.IconChar.SignIn
        LoginBtn.IconColor = Color.White
        LoginBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        LoginBtn.IconSize = 24
        LoginBtn.ImageAlign = ContentAlignment.MiddleLeft
        LoginBtn.Location = New Point(30, 140)
        LoginBtn.Name = "LoginBtn"
        LoginBtn.Padding = New Padding(10, 0, 10, 0)
        LoginBtn.Size = New Size(378, 38)
        LoginBtn.TabIndex = 1
        LoginBtn.Text = "Login as Admin"
        LoginBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        LoginBtn.UseVisualStyleBackColor = False
        ' 
        ' pnlLoginFields
        ' 
        pnlLoginFields.Controls.Add(PasswordTxtBox)
        pnlLoginFields.Controls.Add(Label2)
        pnlLoginFields.Controls.Add(UsernameTxtBox)
        pnlLoginFields.Controls.Add(Label1)
        pnlLoginFields.Dock = DockStyle.Top
        pnlLoginFields.Location = New Point(30, 20)
        pnlLoginFields.Name = "pnlLoginFields"
        pnlLoginFields.Size = New Size(378, 120)
        pnlLoginFields.TabIndex = 0
        ' 
        ' PasswordTxtBox
        ' 
        PasswordTxtBox.Font = New Font("Segoe UI", 11.0F)
        PasswordTxtBox.Location = New Point(10, 85)
        PasswordTxtBox.Name = "PasswordTxtBox"
        PasswordTxtBox.PasswordChar = "●"c
        PasswordTxtBox.Size = New Size(360, 32)
        PasswordTxtBox.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.0F)
        Label2.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label2.Location = New Point(10, 62)
        Label2.Name = "Label2"
        Label2.Size = New Size(135, 23)
        Label2.TabIndex = 2
        Label2.Text = "Admin Password"
        ' 
        ' UsernameTxtBox
        ' 
        UsernameTxtBox.Font = New Font("Segoe UI", 11F)
        UsernameTxtBox.Location = New Point(10, 30)
        UsernameTxtBox.Name = "UsernameTxtBox"
        UsernameTxtBox.Size = New Size(360, 32)
        UsernameTxtBox.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label1.Location = New Point(10, 5)
        Label1.Name = "Label1"
        Label1.Size = New Size(142, 23)
        Label1.TabIndex = 0
        Label1.Text = "Admin Username"
        ' 
        ' pnlActions
        ' 
        pnlActions.Controls.Add(CancelBtn)
        pnlActions.Dock = DockStyle.Bottom
        pnlActions.Location = New Point(30, 370)
        pnlActions.Name = "pnlActions"
        pnlActions.Padding = New Padding(0, 10, 0, 0)
        pnlActions.Size = New Size(440, 60)
        pnlActions.TabIndex = 2
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        CancelBtn.Cursor = Cursors.Hand
        CancelBtn.Dock = DockStyle.Fill
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        CancelBtn.ForeColor = Color.White
        CancelBtn.Location = New Point(0, 10)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(440, 50)
        CancelBtn.TabIndex = 0
        CancelBtn.Text = "Cancel"
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' ApplyVoucher
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(500, 550)
        Controls.Add(pnlMain)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 9F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "ApplyVoucher"
        StartPosition = FormStartPosition.CenterParent
        Text = "Apply Discount - OrderUp!"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlMain.ResumeLayout(False)
        DiscountPnl.ResumeLayout(False)
        pnlDiscountFields.ResumeLayout(False)
        pnlDiscountFields.PerformLayout()
        LoginPnl.ResumeLayout(False)
        pnlLoginFields.ResumeLayout(False)
        pnlLoginFields.PerformLayout()
        pnlActions.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents LoginPnl As Panel
    Friend WithEvents LoginBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlLoginFields As Panel
    Friend WithEvents PasswordTxtBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents UsernameTxtBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DiscountPnl As Panel
    Friend WithEvents ApplyVoucherBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlDiscountFields As Panel
    Friend WithEvents DiscountTxtBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents CancelBtn As Button
End Class