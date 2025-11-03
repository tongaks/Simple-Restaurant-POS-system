Imports System.Globalization

Partial Public Class ItemDialogForm
    Inherits Form

    Private _pricePerItem As Decimal
    Private _quantity As Integer = 1

    Public Property Quantity As Integer
        Get
            Return _quantity
        End Get
        Set(value As Integer)
            _quantity = Math.Max(1, value)
            lblQuantity.Text = _quantity.ToString()
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

        ' Set item details
        lblItemName.Text = itemName

        ' Parse price (handle ₱ symbol and various formats)
        Dim cleaned = price.Replace("₱", "").Replace(",", "").Trim()
        If Not Decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, _pricePerItem) Then
            _pricePerItem = 0D
        End If

        ' Set initial quantity
        _quantity = Math.Max(1, initialQuantity)
        lblQuantity.Text = _quantity.ToString()

        ' Display price
        lblPrice.Text = $"₱{_pricePerItem:N2} per item"

        ' Wire events and setup
        WireHandlers()
        UpdateSubtotal()

        ' Smooth entrance animation
        Me.Opacity = 0
        AnimateEntrance()
    End Sub

    Private Sub WireHandlers()
        ' Button click handlers
        AddHandler btnIncrease.Click, AddressOf BtnIncrease_Click
        AddHandler btnDecrease.Click, AddressOf BtnDecrease_Click
        AddHandler btnAdd.Click, AddressOf BtnAdd_Click
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click

        ' Keyboard shortcuts
        Me.KeyPreview = True
        AddHandler Me.KeyDown, Sub(s, e)
                                   If e.KeyCode = Keys.Enter Then
                                       ' Enter = Add to order
                                       BtnAdd_Click(btnAdd, EventArgs.Empty)
                                   ElseIf e.KeyCode = Keys.Escape Then
                                       ' Escape = Cancel
                                       BtnCancel_Click(btnCancel, EventArgs.Empty)
                                   ElseIf e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus Then
                                       ' + key = increase
                                       BtnIncrease_Click(btnIncrease, EventArgs.Empty)
                                   ElseIf e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus Then
                                       ' - key = decrease
                                       BtnDecrease_Click(btnDecrease, EventArgs.Empty)
                                   End If
                               End Sub
    End Sub

    Private Sub UpdateSubtotal()
        Dim subtotal = _pricePerItem * _quantity
        lblSubtotalAmount.Text = $"₱{subtotal:N2}"

        ' Pulse animation for visual feedback
        PulseControl(lblSubtotalAmount, 1.08F)
    End Sub

    Private Sub BtnIncrease_Click(sender As Object, e As EventArgs)
        _quantity += 1
        lblQuantity.Text = _quantity.ToString()
        UpdateSubtotal()

        ' Visual feedback
        PulseControl(lblQuantity, 1.15F)
        FlashButton(btnIncrease)
    End Sub

    Private Sub BtnDecrease_Click(sender As Object, e As EventArgs)
        If _quantity > 1 Then
            _quantity -= 1
            lblQuantity.Text = _quantity.ToString()
            UpdateSubtotal()

            ' Visual feedback
            PulseControl(lblQuantity, 1.15F)
            FlashButton(btnDecrease)
        Else
            ' Visual shake when can't decrease further
            ShakeControl(btnDecrease)
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        ' Success animation before closing
        btnAdd.FillColor = Color.FromArgb(21, 118, 92)
        AnimateExit(DialogResult.OK)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        AnimateExit(DialogResult.Cancel)
    End Sub

    ' ========== ANIMATION METHODS ==========

    Private Sub AnimateEntrance()
        ' Fade in animation
        Dim timer As New Timer With {.Interval = 15}
        AddHandler timer.Tick, Sub(s, ev)
                                   If Me.Opacity < 1.0 Then
                                       Me.Opacity += 0.08
                                   Else
                                       timer.Stop()
                                       timer.Dispose()
                                   End If
                               End Sub
        timer.Start()
    End Sub

    Private Sub AnimateExit(result As DialogResult)
        ' Fade out animation
        Dim timer As New Timer With {.Interval = 15}
        AddHandler timer.Tick, Sub(s, ev)
                                   If Me.Opacity > 0.0 Then
                                       Me.Opacity -= 0.12
                                   Else
                                       timer.Stop()
                                       timer.Dispose()
                                       Me.DialogResult = result
                                       Me.Close()
                                   End If
                               End Sub
        timer.Start()
    End Sub

    Private Sub PulseControl(ctrl As Control, scaleFactor As Single)
        ' Quick pulse animation
        Dim originalFont = ctrl.Font
        Dim pulseFont = New Font(originalFont.FontFamily, originalFont.Size * scaleFactor, originalFont.Style)

        ctrl.Font = pulseFont

        ' Reset after delay
        Dim resetTimer As New Timer With {.Interval = 120}
        AddHandler resetTimer.Tick, Sub(s, e)
                                        ctrl.Font = originalFont
                                        resetTimer.Stop()
                                        resetTimer.Dispose()
                                    End Sub
        resetTimer.Start()
    End Sub

    Private Sub FlashButton(btn As Guna.UI2.WinForms.Guna2Button)
        ' Quick color flash for feedback
        Dim originalColor = btn.FillColor
        Dim flashColor = If(btn Is btnIncrease,
                           Color.FromArgb(240, 180, 67),
                           Color.FromArgb(21, 118, 92))

        btn.FillColor = flashColor

        Dim resetTimer As New Timer With {.Interval = 100}
        AddHandler resetTimer.Tick, Sub(s, e)
                                        btn.FillColor = originalColor
                                        resetTimer.Stop()
                                        resetTimer.Dispose()
                                    End Sub
        resetTimer.Start()
    End Sub

    Private Sub ShakeControl(ctrl As Control)
        ' Shake animation for invalid action
        Dim originalX = ctrl.Location.X
        Dim shakeAmount = 5
        Dim shakeCount = 0
        Dim maxShakes = 6

        Dim shakeTimer As New Timer With {.Interval = 30}
        AddHandler shakeTimer.Tick, Sub(s, e)
                                        If shakeCount < maxShakes Then
                                            Dim offset = If(shakeCount Mod 2 = 0, shakeAmount, -shakeAmount)
                                            ctrl.Location = New Point(originalX + offset, ctrl.Location.Y)
                                            shakeCount += 1
                                        Else
                                            ctrl.Location = New Point(originalX, ctrl.Location.Y)
                                            shakeTimer.Stop()
                                            shakeTimer.Dispose()
                                        End If
                                    End Sub
        shakeTimer.Start()
    End Sub
End Class