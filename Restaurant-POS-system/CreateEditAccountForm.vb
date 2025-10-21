Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

''' <summary>
''' Form for creating new user accounts or editing existing ones
''' </summary>
Public Class CreateEditAccountForm
    Inherits Form

    Private _isEditMode As Boolean = False
    Private _editingAccount As UserAccount = Nothing

    ' Designer components
    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblFormTitle As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlFields As Panel
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblRole As Label
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button

    ''' <summary>
    ''' Constructor for creating a new account
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        _isEditMode = False
        Me.Text = "Create New Account"
        lblFormTitle.Text = "Create New Account"
    End Sub

    ''' <summary>
    ''' Constructor for editing an existing account
    ''' </summary>
    Public Sub New(account As UserAccount)
        InitializeComponent()
        _isEditMode = True
        _editingAccount = account
        Me.Text = "Edit Account"
        lblFormTitle.Text = "Edit Account"

        ' Load existing data
        txtUsername.Text = account.Username
        txtPassword.Text = account.Password
        cboRole.SelectedItem = account.Role
    End Sub

    Private Sub CreateEditAccountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate role dropdown
        cboRole.Items.Clear()
        cboRole.Items.Add("Admin")
        cboRole.Items.Add("Cashier")
        cboRole.Items.Add("User")

        If Not _isEditMode Then
            cboRole.SelectedIndex = 2 ' Default to "User"
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate input
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        If cboRole.SelectedIndex = -1 Then
            MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRole.Focus()
            Return
        End If

        ' Validate password length
        If txtPassword.Text.Length < 4 Then
            MessageBox.Show("Password must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        ' Validate username length
        If txtUsername.Text.Length < 3 Then
            MessageBox.Show("Username must be at least 3 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        ' Save or update account
        Dim success As Boolean = False

        If _isEditMode Then
            success = DatabaseHandler.UpdateUser(_editingAccount.ID, txtUsername.Text.Trim(), txtPassword.Text.Trim(), cboRole.SelectedItem.ToString())
            If success Then
                MessageBox.Show("Account updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            success = DatabaseHandler.CreateUser(txtUsername.Text.Trim(), txtPassword.Text.Trim(), cboRole.SelectedItem.ToString())
            If success Then
                MessageBox.Show("Account created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        If success Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblFormTitle = New Label()
        pnlMain = New Panel()
        pnlActions = New Panel()
        btnCancel = New Button()
        btnSave = New Button()
        pnlFields = New Panel()
        cboRole = New ComboBox()
        lblRole = New Label()
        txtPassword = New TextBox()
        lblPassword = New Label()
        txtUsername = New TextBox()
        lblUsername = New Label()
        pnlHeader.SuspendLayout()
        pnlMain.SuspendLayout()
        pnlActions.SuspendLayout()
        pnlFields.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        pnlHeader.Controls.Add(lblFormTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(30, 20, 30, 20)
        pnlHeader.Size = New Size(500, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' lblFormTitle
        ' 
        lblFormTitle.AutoSize = True
        lblFormTitle.Dock = DockStyle.Left
        lblFormTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblFormTitle.ForeColor = Color.White
        lblFormTitle.Location = New Point(30, 20)
        lblFormTitle.Name = "lblFormTitle"
        lblFormTitle.Size = New Size(278, 37)
        lblFormTitle.TabIndex = 0
        lblFormTitle.Text = "Create New Account"
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlMain.Controls.Add(pnlActions)
        pnlMain.Controls.Add(pnlFields)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 80)
        pnlMain.Name = "pnlMain"
        pnlMain.Padding = New Padding(30, 30, 30, 20)
        pnlMain.Size = New Size(500, 370)
        pnlMain.TabIndex = 1
        ' 
        ' pnlActions
        ' 
        pnlActions.Controls.Add(btnCancel)
        pnlActions.Controls.Add(btnSave)
        pnlActions.Dock = DockStyle.Bottom
        pnlActions.Location = New Point(30, 280)
        pnlActions.Name = "pnlActions"
        pnlActions.Padding = New Padding(0, 10, 0, 0)
        pnlActions.Size = New Size(440, 70)
        pnlActions.TabIndex = 1
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        btnCancel.Cursor = Cursors.Hand
        btnCancel.Dock = DockStyle.Right
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(140, 10)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(150, 60)
        btnCancel.TabIndex = 1
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSave.Cursor = Cursors.Hand
        btnSave.Dock = DockStyle.Right
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(290, 10)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(150, 60)
        btnSave.TabIndex = 0
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' pnlFields
        ' 
        pnlFields.BackColor = Color.White
        pnlFields.BorderStyle = BorderStyle.FixedSingle
        pnlFields.Controls.Add(cboRole)
        pnlFields.Controls.Add(lblRole)
        pnlFields.Controls.Add(txtPassword)
        pnlFields.Controls.Add(lblPassword)
        pnlFields.Controls.Add(txtUsername)
        pnlFields.Controls.Add(lblUsername)
        pnlFields.Dock = DockStyle.Top
        pnlFields.Location = New Point(30, 30)
        pnlFields.Name = "pnlFields"
        pnlFields.Padding = New Padding(30, 20, 30, 20)
        pnlFields.Size = New Size(440, 240)
        pnlFields.TabIndex = 0
        ' 
        ' cboRole
        ' 
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.Font = New Font("Segoe UI", 11.0F)
        cboRole.FormattingEnabled = True
        cboRole.Location = New Point(30, 185)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(378, 33)
        cboRole.TabIndex = 5
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New Font("Segoe UI", 10.0F)
        lblRole.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblRole.Location = New Point(30, 160)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(47, 23)
        lblRole.TabIndex = 4
        lblRole.Text = "Role:"
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 11.0F)
        txtPassword.Location = New Point(30, 115)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(378, 32)
        txtPassword.TabIndex = 3
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 10.0F)
        lblPassword.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblPassword.Location = New Point(30, 90)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(84, 23)
        lblPassword.TabIndex = 2
        lblPassword.Text = "Password:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 11.0F)
        txtUsername.Location = New Point(30, 45)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(378, 32)
        txtUsername.TabIndex = 1
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 10.0F)
        lblUsername.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblUsername.Location = New Point(30, 20)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(91, 23)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Username:"
        ' 
        ' CreateEditAccountForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(500, 450)
        Controls.Add(pnlMain)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 9.0F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "CreateEditAccountForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Create/Edit Account - OrderUp!"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlMain.ResumeLayout(False)
        pnlActions.ResumeLayout(False)
        pnlFields.ResumeLayout(False)
        pnlFields.PerformLayout()
        ResumeLayout(False)
    End Sub
End Class