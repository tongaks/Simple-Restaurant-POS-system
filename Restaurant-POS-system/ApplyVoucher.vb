Imports MySql.Data.MySqlClient

Public Class ApplyVoucher

    Private Sub ApplyVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    ' Validation
    Private Function ValidateInputs()
        If String.IsNullOrEmpty(UsernameTxtBox.Text) Or String.IsNullOrEmpty(PasswordTxtBox.Text) Then
            Return False
        Else Return True
        End If
    End Function

    ' Buttons
    Private Sub LoginAdmin_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
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
    End Sub
    Private Sub ApplyVoucherClick_Click(sender As Object, e As EventArgs) Handles ApplyVoucherBtn.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class