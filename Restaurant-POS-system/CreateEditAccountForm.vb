Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

''' <summary>
''' Form for creating new user accounts or editing existing ones
''' </summary>
Public Class CreateEditAccountForm
    Inherits Form

    Private _isEditMode As Boolean = False
    Private _editingAccount As UserAccount = Nothing

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

        'If Not _isEditMode Then
        '    cboRole.SelectedIndex = cboRole.Items.Count ' Default to "User"
        'End If
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
        If txtPassword.Text.Length < 8 Then
            MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        pnlMain = New Panel()
        lblFormTitle = New Label()
        lblUsername = New Label()
        txtUsername = New TextBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        lblRole = New Label()
        cboRole = New ComboBox()
        btnSave = New Button()
        btnCancel = New Button()
        pnlMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = SystemColors.Control
        pnlMain.Controls.Add(lblFormTitle)
        pnlMain.Controls.Add(lblUsername)
        pnlMain.Controls.Add(txtUsername)
        pnlMain.Controls.Add(lblPassword)
        pnlMain.Controls.Add(txtPassword)
        pnlMain.Controls.Add(lblRole)
        pnlMain.Controls.Add(cboRole)
        pnlMain.Controls.Add(btnSave)
        pnlMain.Controls.Add(btnCancel)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 0)
        pnlMain.Margin = New Padding(3, 2, 3, 2)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(394, 270)
        pnlMain.TabIndex = 0
        ' 
        ' lblFormTitle
        ' 
        lblFormTitle.AutoSize = True
        lblFormTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblFormTitle.Location = New Point(26, 22)
        lblFormTitle.Name = "lblFormTitle"
        lblFormTitle.Size = New Size(225, 30)
        lblFormTitle.TabIndex = 0
        lblFormTitle.Text = "Create New Account"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 10.0F)
        lblUsername.Location = New Point(26, 75)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(74, 19)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Username:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 10.0F)
        txtUsername.Location = New Point(26, 98)
        txtUsername.Margin = New Padding(3, 2, 3, 2)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(342, 25)
        txtUsername.TabIndex = 2
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 10.0F)
        lblPassword.Location = New Point(26, 128)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(70, 19)
        lblPassword.TabIndex = 3
        lblPassword.Text = "Password:"
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 10.0F)
        txtPassword.Location = New Point(26, 150)
        txtPassword.Margin = New Padding(3, 2, 3, 2)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(342, 25)
        txtPassword.TabIndex = 4
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New Font("Segoe UI", 10.0F)
        lblRole.Location = New Point(26, 180)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(38, 19)
        lblRole.TabIndex = 5
        lblRole.Text = "Role:"
        ' 
        ' cboRole
        ' 
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.Font = New Font("Segoe UI", 10.0F)
        cboRole.FormattingEnabled = True
        cboRole.Location = New Point(26, 202)
        cboRole.Margin = New Padding(3, 2, 3, 2)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(342, 25)
        cboRole.TabIndex = 6
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.LightGreen
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 10.0F)
        btnSave.Location = New Point(192, 232)
        btnSave.Margin = New Padding(3, 2, 3, 2)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(88, 26)
        btnSave.TabIndex = 7
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.LightCoral
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 10.0F)
        btnCancel.Location = New Point(289, 232)
        btnCancel.Margin = New Padding(3, 2, 3, 2)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(79, 26)
        btnCancel.TabIndex = 8
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' CreateEditAccountForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(394, 270)
        Controls.Add(pnlMain)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "CreateEditAccountForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Create/Edit Account"
        pnlMain.ResumeLayout(False)
        pnlMain.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblFormTitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblRole As Label
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button

    Private Sub cboRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRole.SelectedIndexChanged

    End Sub
End Class