Imports System.Reflection.Metadata
Imports MySql.Data.MySqlClient

Public Class ApplyVoucher
    Dim IsCancelled = True
    Dim discountValues As New List(Of Double)

    ' fomr stuffs
    Private Sub OnFormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing And IsCancelled Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub
    Private Sub ApplyVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'GetSettingsConfig()
        AddHandler DiscountTxtBox.KeyPress, AddressOf HandleNumberOnly

        Dim fuck = RetrieveDiscounts()
        For Each d As Discounts In fuck
            ComboBox1.Items.Add(d.DiscountType)
            discountValues.Add(d.DiscountValue)
        Next

    End Sub




    ' ignore keypress discount textbox
    Private Sub HandleEnterDisocunt(sender As Object, e As KeyPressEventArgs) Handles DiscountTxtBox.KeyPress
        e.Handled = True
        Return
    End Sub




    ' Buttons
    Private Sub ApplyVoucherClick_Click(sender As Object, e As EventArgs) Handles ApplyVoucherBtn.Click
        HandleApplyVoucher
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
    Private Sub HandleDiscountTypeSelect(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim sel = ComboBox1.SelectedItem
        DiscountTxtBox.Text = discountValues(ComboBox1.SelectedIndex) * 100
    End Sub
End Class