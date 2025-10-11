Imports System.Reflection.Metadata
Imports MySql.Data.MySqlClient

Public Class ApplyVoucher
    Dim IsCancelled = True

    Private Sub OnFormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing And IsCancelled Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub



    ' Validation
    Private Function ValidateInputs()
        If String.IsNullOrEmpty(UsernameTxtBox.Text) Or String.IsNullOrEmpty(PasswordTxtBox.Text) Then
            MsgBox("Please provide all the credentials of the admin", MsgBoxStyle.Critical, "Error")
            Return False
        Else Return True
        End If
    End Function
    Private Sub HandleNumberOnly(sender As Object, e As KeyPressEventArgs) Handles DiscountTxtBox.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Asc(e.KeyChar) = 8 Then
            e.Handled = True
        End If
    End Sub
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
            End If
        ElseIf Asc(e.KeyChar) = 27 Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub HandleEnterDisocunt(sender As Object, e As KeyPressEventArgs) Handles DiscountTxtBox.KeyPress
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
        Else
            DiscountPnl.Enabled = True
            LoginPnl.Enabled = False
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
        If Not String.IsNullOrEmpty(DiscountTxtBox.Text) Then
            IsCancelled = False
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Please enter the discount value.", MsgBoxStyle.Critical, "Error")
            DiscountTxtBox.Focus()
            Return False
        End If

        Return True
    End Function

End Class