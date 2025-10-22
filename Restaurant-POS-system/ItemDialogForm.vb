Imports System.Globalization

Partial Public Class ItemDialogForm
    Inherits Form

    Private _pricePerItem As Decimal

    Public Property Quantity As Integer
        Get
            Return Integer.Parse(lblQuantity.Text)
        End Get
        Set(value As Integer)
            lblQuantity.Text = value.ToString()
            UpdateSubtotal()
        End Set
    End Property

    Public Sub New()
        ' Parameterless ctor required for Designer
        InitializeComponent()
        WireHandlers()
    End Sub

    Public Sub New(itemName As String, price As String, initialQuantity As Integer)
        InitializeComponent()
        lblItemName.Text = itemName
        Dim cleaned = price.Replace("₱", "").Trim()
        Decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, _pricePerItem)
        If _pricePerItem = 0D Then Decimal.TryParse(price, NumberStyles.Any, CultureInfo.InvariantCulture, _pricePerItem)
        Quantity = Math.Max(1, initialQuantity)
        lblPrice.Text = $"₱{_pricePerItem:N2} per item"
        WireHandlers()
        UpdateSubtotal()
    End Sub

    Private Sub WireHandlers()
        AddHandler btnIncrease.Click, AddressOf BtnIncrease_Click
        AddHandler btnDecrease.Click, AddressOf BtnDecrease_Click
        AddHandler btnAdd.Click, AddressOf BtnAdd_Click
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click
        Me.KeyPreview = True
        AddHandler Me.KeyDown, Sub(s, e)
                                   If e.KeyCode = Keys.Enter Then
                                       Me.DialogResult = DialogResult.OK
                                       Me.Close()
                                   ElseIf e.KeyCode = Keys.Escape Then
                                       Me.DialogResult = DialogResult.Cancel
                                       Me.Close()
                                   End If
                               End Sub
    End Sub

    Private Sub UpdateSubtotal()
        Dim subtotal = _pricePerItem * Quantity
        lblSubtotalAmount.Text = $"₱{subtotal:N2}"
    End Sub

    Private Sub BtnIncrease_Click(sender As Object, e As EventArgs)
        Quantity += 1
    End Sub

    Private Sub BtnDecrease_Click(sender As Object, e As EventArgs)
        If Quantity > 1 Then Quantity -= 1
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class