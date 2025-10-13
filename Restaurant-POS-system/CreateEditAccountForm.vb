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
        Me.pnlMain = New Panel()
        Me.lblFormTitle = New Label()
        Me.lblUsername = New Label()
        Me.txtUsername = New TextBox()
        Me.lblPassword = New Label()
        Me.txtPassword = New TextBox()
        Me.lblRole = New Label()
        Me.cboRole = New ComboBox()
        Me.btnSave = New Button()
        Me.btnCancel = New Button()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()

        ' pnlMain
        Me.pnlMain.BackColor = SystemColors.Control
        Me.pnlMain.Controls.Add(Me.lblFormTitle)
        Me.pnlMain.Controls.Add(Me.lblUsername)
        Me.pnlMain.Controls.Add(Me.txtUsername)
        Me.pnlMain.Controls.Add(Me.lblPassword)
        Me.pnlMain.Controls.Add(Me.txtPassword)
        Me.pnlMain.Controls.Add(Me.lblRole)
        Me.pnlMain.Controls.Add(Me.cboRole)
        Me.pnlMain.Controls.Add(Me.btnSave)
        Me.pnlMain.Controls.Add(Me.btnCancel)
        Me.pnlMain.Dock = DockStyle.Fill
        Me.pnlMain.Location = New Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New Size(450, 350)
        Me.pnlMain.TabIndex = 0

        ' lblFormTitle
        Me.lblFormTitle.AutoSize = True
        Me.lblFormTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        Me.lblFormTitle.Location = New Point(30, 30)
        Me.lblFormTitle.Name = "lblFormTitle"
        Me.lblFormTitle.Size = New Size(250, 37)
        Me.lblFormTitle.TabIndex = 0
        Me.lblFormTitle.Text = "Create New Account"

        ' lblUsername
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New Font("Segoe UI", 10.0F)
        Me.lblUsername.Location = New Point(30, 100)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New Size(87, 23)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username:"

        ' txtUsername
        Me.txtUsername.Font = New Font("Segoe UI", 10.0F)
        Me.txtUsername.Location = New Point(30, 130)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New Size(390, 30)
        Me.txtUsername.TabIndex = 2

        ' lblPassword
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New Font("Segoe UI", 10.0F)
        Me.lblPassword.Location = New Point(30, 170)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New Size(84, 23)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Password:"

        ' txtPassword
        Me.txtPassword.Font = New Font("Segoe UI", 10.0F)
        Me.txtPassword.Location = New Point(30, 200)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New Size(390, 30)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.UseSystemPasswordChar = True

        ' lblRole
        Me.lblRole.AutoSize = True
        Me.lblRole.Font = New Font("Segoe UI", 10.0F)
        Me.lblRole.Location = New Point(30, 240)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New Size(46, 23)
        Me.lblRole.TabIndex = 5
        Me.lblRole.Text = "Role:"

        ' cboRole
        Me.cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboRole.Font = New Font("Segoe UI", 10.0F)
        Me.cboRole.FormattingEnabled = True
        Me.cboRole.Location = New Point(30, 270)
        Me.cboRole.Name = "cboRole"
        Me.cboRole.Size = New Size(390, 31)
        Me.cboRole.TabIndex = 6

        ' btnSave
        Me.btnSave.BackColor = Color.LightGreen
        Me.btnSave.FlatStyle = FlatStyle.Flat
        Me.btnSave.Font = New Font("Segoe UI", 10.0F)
        Me.btnSave.Location = New Point(220, 310)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New Size(100, 35)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False

        ' btnCancel
        Me.btnCancel.BackColor = Color.LightCoral
        Me.btnCancel.FlatStyle = FlatStyle.Flat
        Me.btnCancel.Font = New Font("Segoe UI", 10.0F)
        Me.btnCancel.Location = New Point(330, 310)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New Size(90, 35)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False

        ' CreateEditAccountForm
        Me.AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(450, 360)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateEditAccountForm"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "Create/Edit Account"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)
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
End Class