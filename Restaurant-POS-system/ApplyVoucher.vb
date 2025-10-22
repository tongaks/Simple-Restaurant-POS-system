Imports System.Reflection.Metadata
Imports MySql.Data.MySqlClient

Public Class ApplyVoucher
    Dim IsCancelled = True

    ' expose selected discount to the caller
    Private _selectedDiscountPercent As Double = 0
    Private _selectedDiscountType As String = String.Empty

    Public ReadOnly Property SelectedDiscountPercent As Double
        Get
            Return _selectedDiscountPercent
        End Get
    End Property

    Public ReadOnly Property SelectedDiscountType As String
        Get
            Return _selectedDiscountType
        End Get
    End Property

    ' form stuffs
    Private Sub OnFormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing And IsCancelled Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub ApplyVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make discount textbox readonly (no manual input) and suppress keypress
        DiscountTxtBox.ReadOnly = True
        DiscountTxtBox.TabStop = False
        AddHandler DiscountTxtBox.KeyPress, AddressOf SuppressKeyPress

        ' Populate discount types with explicit percentages (no duplicate student entry)
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(New Object() {
                                   "Senior (20%)",
                                   "PWD (20%)",
                                   "Student (10%)"
                                 })
        ComboBox1.Text = "Select type"
        AddHandler ComboBox1.SelectedIndexChanged, AddressOf ComboBox1_SelectedIndexChanged

        UsernameTxtBox.Focus()
    End Sub

    Private Sub SuppressKeyPress(sender As Object, e As KeyPressEventArgs)
        ' Prevent any typing/pasting into DiscountTxtBox
        e.Handled = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim sel = ComboBox1.SelectedItem
        If sel Is Nothing Then
            DiscountTxtBox.Text = String.Empty
            _selectedDiscountPercent = 0
            _selectedDiscountType = String.Empty
            Return
        End If

        Dim txt = sel.ToString()
        Select Case True
            Case txt.ToLowerInvariant().Contains("senior")
                DiscountTxtBox.Text = "20"
                _selectedDiscountPercent = 20
                _selectedDiscountType = "Senior"
            Case txt.ToLowerInvariant().Contains("pwd")
                DiscountTxtBox.Text = "20"
                _selectedDiscountPercent = 20
                _selectedDiscountType = "PWD"
            Case txt.ToLowerInvariant().Contains("student")
                DiscountTxtBox.Text = "10"
                _selectedDiscountPercent = 10
                _selectedDiscountType = "Student"
            Case Else
                DiscountTxtBox.Text = String.Empty
                _selectedDiscountPercent = 0
                _selectedDiscountType = String.Empty
        End Select
    End Sub

    ' Validation
    Private Function ValidateInputs()
        If String.IsNullOrEmpty(UsernameTxtBox.Text) Or String.IsNullOrEmpty(PasswordTxtBox.Text) Then
            MsgBox("Please provide all the credentials of the admin", MsgBoxStyle.Critical, "Error")
            Return False
        Else Return True
        End If
    End Function

    Private Sub HandleEnterCredential(sender As Object, e As KeyPressEventArgs) Handles UsernameTxtBox.KeyPress, PasswordTxtBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not ValidateInputs() Then
                Return
            End If

            If Login(UsernameTxtBox.Text, PasswordTxtBox.Text, "admin") = False Then
                MsgBox("Invalid username or password.", MsgBoxStyle.Critical, "Error")
                Return
            Else
                DiscountPnl.Enabled = True
                LoginPnl.Enabled = False
                ' Focus the combo box so user selects a type (auto-fill)
                ComboBox1.Focus()
            End If
        ElseIf Asc(e.KeyChar) = 27 Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub HandleEnterDisocunt(sender As Object, e As KeyPressEventArgs) Handles DiscountTxtBox.KeyPress
        ' DiscountTxtBox is readonly now; this will not be triggered for input
        If Asc(e.KeyChar) = 13 Then
            HandleApplyVoucher()
        End If
    End Sub

    ' Buttons
    Private Sub LoginAdmin_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        If Not ValidateInputs Then
            Return
        End If

        If Login(UsernameTxtBox.Text, PasswordTxtBox.Text, "admin") Then
            ' Successful login path handled in HandleEnterCredential or here if used
            DiscountPnl.Enabled = True
            LoginPnl.Enabled = False
            ComboBox1.Focus()
        Else
            MsgBox("Invalid username or password.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub ApplyVoucherClick_Click(sender As Object, e As EventArgs) Handles ApplyVoucherBtn.Click
        HandleApplyVoucher()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Handlers
    Private Function HandleApplyVoucher()
        If _selectedDiscountPercent > 0 Then
            IsCancelled = False
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Please select the discount type.", MsgBoxStyle.Critical, "Error")
            ComboBox1.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub PasswordTxtBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTxtBox.TextChanged

    End Sub
End Class