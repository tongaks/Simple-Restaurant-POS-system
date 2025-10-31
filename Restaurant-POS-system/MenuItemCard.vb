Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

''' <summary>
''' Premium self-contained menu item card with edit capabilities
''' Features: Hover animations, floating action buttons, inline editing, NEW badge
''' </summary>
Public Class MenuItemCard
    Inherits Guna2ShadowPanel

    ' ===== PRIVATE FIELDS =====
    Private _itemId As Integer
    Private _itemName As String
    Private _itemPrice As Decimal
    Private _imagePath As String
    Private _categoryTable As String
    Private _dateAdded As DateTime
    Private _isEditMode As Boolean = False
    Private _isHovering As Boolean = False

    ' ===== UI COMPONENTS =====
    Private pbItemImage As Guna2PictureBox
    Private lblItemName As Label
    Private lblItemPrice As Label
    Private lblNewBadge As Guna2HtmlLabel
    Private btnFloatEdit As Guna2CircleButton
    Private btnFloatDelete As Guna2CircleButton
    Private txtEditName As Guna2TextBox
    Private txtEditPrice As Guna2TextBox
    Private btnSaveEdit As Guna2Button
    Private btnCancelEdit As Guna2Button
    Private btnChangeImage As Guna2Button
    Private pnlImageContainer As Panel
    Private pnlEditControls As Panel

    ' ===== ANIMATION TIMERS =====
    Private hoverTimer As Timer
    Private buttonRevealTimer As Timer
    Private expandTimer As Timer
    Private fadeTimer As Timer

    ' Timer used to delay hiding buttons to avoid flicker when moving between parent and child controls
    Private hideButtonsTimer As Timer

    ' ===== EVENTS =====
    Public Event SaveRequested(itemId As Integer, newName As String, newPrice As Decimal, newImagePath As String)
    Public Event DeleteRequested(itemId As Integer, itemName As String)
    Public Event ImageChangeRequested(itemId As Integer, ByRef newImagePath As String)

    ' ===== PROPERTIES =====
    Public ReadOnly Property ItemId As Integer
        Get
            Return _itemId
        End Get
    End Property

    Public ReadOnly Property ItemName As String
        Get
            Return _itemName
        End Get
    End Property

    Public ReadOnly Property ItemPrice As Decimal
        Get
            Return _itemPrice
        End Get
    End Property

    Public ReadOnly Property IsEditMode As Boolean
        Get
            Return _isEditMode
        End Get
    End Property

    ' ===== CONSTRUCTOR =====
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        ApplyPremiumStyling()
        SetupAnimations()
        SetupEventHandlers()
    End Sub

    ''' <summary>
    ''' Initialize all UI components
    ''' </summary>
    Private Sub InitializeComponent()
        ' Card container properties
        Me.Size = New Size(240, 300)
        Me.BackColor = Color.Transparent
        Me.FillColor = Theme.WhiteSurface
        Me.Radius = 16
        Me.ShadowColor = Color.Black
        Me.ShadowDepth = 8
        Me.ShadowShift = 3
        Me.Cursor = Cursors.Hand

        ' Image container panel
        pnlImageContainer = New Panel()
        pnlImageContainer.Size = New Size(210, 160)
        pnlImageContainer.Location = New Point(15, 15)
        pnlImageContainer.BackColor = Color.FromArgb(245, 247, 250)

        ' Item image
        pbItemImage = New Guna2PictureBox()
        pbItemImage.Dock = DockStyle.Fill
        pbItemImage.SizeMode = PictureBoxSizeMode.Zoom
        pbItemImage.BackColor = Color.FromArgb(245, 247, 250)
        pbItemImage.BorderRadius = 12
        pbItemImage.FillColor = Color.FromArgb(245, 247, 250)
        pnlImageContainer.Controls.Add(pbItemImage)

        ' NEW badge (hidden by default)
        lblNewBadge = New Guna2HtmlLabel()
        lblNewBadge.Size = New Size(60, 28)
        lblNewBadge.Location = New Point(165, 20)
        lblNewBadge.BackColor = Color.FromArgb(231, 76, 60)
        lblNewBadge.ForeColor = Color.White
        lblNewBadge.Text = "<b>NEW</b>"
        lblNewBadge.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblNewBadge.TextAlignment = ContentAlignment.MiddleCenter
        lblNewBadge.AutoSize = False
        lblNewBadge.Visible = False

        ' Item name label
        lblItemName = New Label()
        lblItemName.Location = New Point(15, 185)
        lblItemName.Size = New Size(210, 30)
        lblItemName.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        lblItemName.ForeColor = Theme.DarkText
        lblItemName.TextAlign = ContentAlignment.MiddleLeft
        lblItemName.AutoEllipsis = True

        ' Item price label
        lblItemPrice = New Label()
        lblItemPrice.Location = New Point(15, 220)
        lblItemPrice.Size = New Size(210, 25)
        lblItemPrice.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblItemPrice.ForeColor = Theme.SecondaryAccent
        lblItemPrice.TextAlign = ContentAlignment.MiddleLeft

        ' Floating Edit button (hidden by default)
        btnFloatEdit = New Guna2CircleButton()
        btnFloatEdit.Size = New Size(45, 45)
        btnFloatEdit.Location = New Point(135, 250)
        btnFloatEdit.FillColor = Theme.PrimaryAccent
        btnFloatEdit.Image = Nothing ' Will set icon in code
        btnFloatEdit.ImageSize = New Size(20, 20)
        btnFloatEdit.ShadowDecoration.Enabled = True
        btnFloatEdit.ShadowDecoration.Depth = 10
        btnFloatEdit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        btnFloatEdit.Visible = False
        btnFloatEdit.Cursor = Cursors.Hand
        btnFloatEdit.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        btnFloatEdit.Text = "✏"
        btnFloatEdit.ForeColor = Theme.DarkText

        ' Floating Delete button (hidden by default)
        btnFloatDelete = New Guna2CircleButton()
        btnFloatDelete.Size = New Size(45, 45)
        btnFloatDelete.Location = New Point(190, 250)
        btnFloatDelete.FillColor = Color.FromArgb(231, 76, 60)
        btnFloatDelete.Image = Nothing
        btnFloatDelete.ImageSize = New Size(20, 20)
        btnFloatDelete.ShadowDecoration.Enabled = True
        btnFloatDelete.ShadowDecoration.Depth = 10
        btnFloatDelete.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        btnFloatDelete.Visible = False
        btnFloatDelete.Cursor = Cursors.Hand
        btnFloatDelete.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        btnFloatDelete.Text = "🗑"
        btnFloatDelete.ForeColor = Color.White

        ' Edit mode controls panel (hidden by default)
        pnlEditControls = New Panel()
        pnlEditControls.Location = New Point(15, 185)
        pnlEditControls.Size = New Size(210, 165)
        pnlEditControls.BackColor = Color.Transparent
        pnlEditControls.Visible = False

        ' Edit name textbox
        txtEditName = New Guna2TextBox()
        txtEditName.Location = New Point(0, 0)
        txtEditName.Size = New Size(210, 40)
        txtEditName.BorderRadius = 8
        txtEditName.BorderThickness = 2
        txtEditName.BorderColor = Theme.LightBorder
        txtEditName.Font = New Font("Segoe UI", 10.0F)
        txtEditName.PlaceholderText = "Item name"
        txtEditName.FocusedState.BorderColor = Theme.PrimaryAccent

        ' Edit price textbox
        txtEditPrice = New Guna2TextBox()
        txtEditPrice.Location = New Point(0, 50)
        txtEditPrice.Size = New Size(100, 40)
        txtEditPrice.BorderRadius = 8
        txtEditPrice.BorderThickness = 2
        txtEditPrice.BorderColor = Theme.LightBorder
        txtEditPrice.Font = New Font("Segoe UI", 10.0F)
        txtEditPrice.PlaceholderText = "₱ Price"
        txtEditPrice.FocusedState.BorderColor = Theme.PrimaryAccent

        ' Change image button
        btnChangeImage = New Guna2Button()
        btnChangeImage.Location = New Point(110, 50)
        btnChangeImage.Size = New Size(100, 40)
        btnChangeImage.BorderRadius = 8
        btnChangeImage.FillColor = Theme.SecondaryAccent
        btnChangeImage.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnChangeImage.Text = "📷 Image"
        btnChangeImage.ForeColor = Color.White
        btnChangeImage.Cursor = Cursors.Hand

        ' Save button
        btnSaveEdit = New Guna2Button()
        btnSaveEdit.Location = New Point(0, 100)
        btnSaveEdit.Size = New Size(100, 40)
        btnSaveEdit.BorderRadius = 8
        btnSaveEdit.FillColor = Color.FromArgb(46, 204, 113)
        btnSaveEdit.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnSaveEdit.Text = "💾 Save"
        btnSaveEdit.ForeColor = Color.White
        btnSaveEdit.Cursor = Cursors.Hand

        ' Cancel button
        btnCancelEdit = New Guna2Button()
        btnCancelEdit.Location = New Point(110, 100)
        btnCancelEdit.Size = New Size(100, 40)
        btnCancelEdit.BorderRadius = 8
        btnCancelEdit.FillColor = Color.FromArgb(149, 165, 166)
        btnCancelEdit.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnCancelEdit.Text = "✖ Cancel"
        btnCancelEdit.ForeColor = Color.White
        btnCancelEdit.Cursor = Cursors.Hand

        ' Add edit controls to panel
        pnlEditControls.Controls.AddRange({txtEditName, txtEditPrice, btnChangeImage, btnSaveEdit, btnCancelEdit})

        ' Add all controls to card
        Me.Controls.AddRange({pnlImageContainer, lblNewBadge, lblItemName, lblItemPrice,
                              btnFloatEdit, btnFloatDelete, pnlEditControls})
    End Sub

    ''' <summary>
    ''' Apply premium styling and hover effects
    ''' </summary>
    Private Sub ApplyPremiumStyling()
        ' Apply Guna2 shadow styling
        Me.ShadowColor = Color.FromArgb(30, 0, 0, 0)
        Me.ShadowShift = 3

        ' Hover state colors
        btnFloatEdit.HoverState.FillColor = AdjustBrightness(Theme.PrimaryAccent, -20)
        btnFloatDelete.HoverState.FillColor = AdjustBrightness(Color.FromArgb(231, 76, 60), -20)
        btnSaveEdit.HoverState.FillColor = AdjustBrightness(Color.FromArgb(46, 204, 113), -20)
        btnCancelEdit.HoverState.FillColor = AdjustBrightness(Color.FromArgb(149, 165, 166), -20)
        btnChangeImage.HoverState.FillColor = AdjustBrightness(Theme.SecondaryAccent, -20)
    End Sub

    ''' <summary>
    ''' Setup animation timers
    ''' </summary>
    Private Sub SetupAnimations()
        ' Hover lift animation
        hoverTimer = New Timer()
        hoverTimer.Interval = 15
        AddHandler hoverTimer.Tick, AddressOf OnHoverAnimationTick

        ' Button reveal animation (not used directly but kept for future)
        buttonRevealTimer = New Timer()
        buttonRevealTimer.Interval = 10
        AddHandler buttonRevealTimer.Tick, AddressOf OnButtonRevealTick

        ' Expand animation for edit mode
        expandTimer = New Timer()
        expandTimer.Interval = 10
        AddHandler expandTimer.Tick, AddressOf OnExpandAnimationTick

        ' Delay timer to avoid flicker when moving between card and floating buttons
        hideButtonsTimer = New Timer()
        hideButtonsTimer.Interval = 200 ' 200ms grace period
        AddHandler hideButtonsTimer.Tick, AddressOf OnHideButtonsTick
    End Sub

    ''' <summary>
    ''' Setup event handlers
    ''' </summary>
    Private Sub SetupEventHandlers()
        AddHandler Me.MouseEnter, AddressOf Card_MouseEnter
        AddHandler Me.MouseLeave, AddressOf Card_MouseLeave
        AddHandler btnFloatEdit.Click, AddressOf BtnEdit_Click
        AddHandler btnFloatDelete.Click, AddressOf BtnDelete_Click
        AddHandler btnSaveEdit.Click, AddressOf BtnSave_Click
        AddHandler btnCancelEdit.Click, AddressOf BtnCancel_Click
        AddHandler btnChangeImage.Click, AddressOf BtnChangeImage_Click
        AddHandler txtEditPrice.KeyPress, AddressOf TxtPrice_KeyPress
        AddHandler pbItemImage.MouseEnter, AddressOf Card_MouseEnter
        AddHandler lblItemName.MouseEnter, AddressOf Card_MouseEnter
        AddHandler lblItemPrice.MouseEnter, AddressOf Card_MouseEnter

        ' Crucial: handle floating button enter/leave to keep them stable when cursor moves between card and buttons
        AddHandler btnFloatEdit.MouseEnter, AddressOf Floating_MouseEnter
        AddHandler btnFloatDelete.MouseEnter, AddressOf Floating_MouseEnter
        AddHandler btnFloatEdit.MouseLeave, AddressOf Floating_MouseLeave
        AddHandler btnFloatDelete.MouseLeave, AddressOf Floating_MouseLeave
    End Sub

    ''' <summary>
    ''' Set card data
    ''' </summary>
    Public Sub SetCardData(itemId As Integer, itemName As String, itemPrice As Decimal,
                           imagePath As String, categoryTable As String, Optional dateAdded As DateTime? = Nothing)
        _itemId = itemId
        _itemName = itemName
        _itemPrice = itemPrice
        _imagePath = imagePath
        _categoryTable = categoryTable
        _dateAdded = If(dateAdded, DateTime.Now)

        ' Update UI
        lblItemName.Text = itemName
        lblItemPrice.Text = "₱" & itemPrice.ToString("F2")

        ' Load image
        If Not String.IsNullOrEmpty(imagePath) AndAlso System.IO.File.Exists(imagePath) Then
            Try
                Dim img As Image = Image.FromFile(imagePath)
                pbItemImage.Image = ResizeImageFit(img, pbItemImage)
            Catch
                pbItemImage.Image = Nothing
            End Try
        Else
            pbItemImage.Image = Nothing
        End If

        ' Show NEW badge if item is less than 7 days old
        If (DateTime.Now - _dateAdded).TotalDays <= 7 Then
            lblNewBadge.Visible = True
            StartNewBadgePulse()
        End If
    End Sub

    ''' <summary>
    ''' Start NEW badge pulse animation
    ''' </summary>
    Private Sub StartNewBadgePulse()
        Dim pulseTimer As New Timer()
        pulseTimer.Interval = 30
        Dim pulseStep As Integer = 0
        Dim originalSize As Size = lblNewBadge.Size

        AddHandler pulseTimer.Tick, Sub()
                                        pulseStep += 1
                                        Dim scale As Double = 1.0 + (Math.Sin(pulseStep * 0.1) * 0.05)
                                        lblNewBadge.Size = New Size(CInt(originalSize.Width * scale),
                                                                     CInt(originalSize.Height * scale))
                                    End Sub
        pulseTimer.Start()
    End Sub

    ' ===== MOUSE EVENTS =====
    Private Sub Card_MouseEnter(sender As Object, e As EventArgs)
        If _isEditMode Then Return
        _isHovering = True

        ' Stop any pending hide to avoid flicker
        Try
            hideButtonsTimer?.Stop()
        Catch
        End Try

        hoverTimer.Start()
        RevealFloatingButtons()
    End Sub

    Private Sub Card_MouseLeave(sender As Object, e As EventArgs)
        If _isEditMode Then Return

        ' Start delayed hide — this prevents flicker when cursor moves to floating buttons
        _isHovering = False
        Try
            hideButtonsTimer?.Stop()
            hideButtonsTimer?.Start()
        Catch
        End Try

        ' Animate back to normal shadow (keep independent of hideButtonsTimer)
        Dim resetTimer As New Timer()
        resetTimer.Interval = 10
        Dim steps As Integer = 0

        AddHandler resetTimer.Tick, Sub()
                                        steps += 1
                                        If Me.ShadowDepth > 8 Then
                                            Me.ShadowDepth -= 2
                                        End If
                                        If steps >= 5 Then
                                            Me.ShadowDepth = 8
                                            resetTimer.Stop()
                                            resetTimer.Dispose()
                                        End If
                                    End Sub
        resetTimer.Start()
    End Sub

    Private Sub Floating_MouseEnter(sender As Object, e As EventArgs)
        ' Ensure hovering state while over floating buttons
        If _isEditMode Then Return
        _isHovering = True
        Try
            hideButtonsTimer?.Stop()
        Catch
        End Try
    End Sub

    Private Sub Floating_MouseLeave(sender As Object, e As EventArgs)
        ' When leaving a floating button, start delayed hide — final check happens in OnHideButtonsTick
        If _isEditMode Then Return
        Try
            hideButtonsTimer?.Stop()
            hideButtonsTimer?.Start()
        Catch
        End Try
    End Sub

    Private Sub OnHoverAnimationTick(sender As Object, e As EventArgs)
        If _isHovering AndAlso Me.ShadowDepth < 18 Then
            Me.ShadowDepth += 2
        Else
            hoverTimer.Stop()
        End If
    End Sub

    ''' <summary>
    ''' Reveal floating action buttons with slide-in animation
    ''' </summary>
    Private Sub RevealFloatingButtons()
        ' Stop any pending hide
        Try
            hideButtonsTimer?.Stop()
        Catch
        End Try

        btnFloatEdit.Visible = True
        btnFloatDelete.Visible = True

        ' Start below normal position
        Dim targetEditY As Integer = 250
        Dim targetDeleteY As Integer = 250
        btnFloatEdit.Top = 300
        btnFloatDelete.Top = 300

        Dim slideTimer As New Timer()
        slideTimer.Interval = 10
        Dim steps As Integer = 0

        AddHandler slideTimer.Tick, Sub()
                                        steps += 1
                                        If btnFloatEdit.Top > targetEditY Then
                                            btnFloatEdit.Top -= 5
                                            btnFloatDelete.Top -= 5
                                        Else
                                            btnFloatEdit.Top = targetEditY
                                            btnFloatDelete.Top = targetDeleteY
                                            slideTimer.Stop()
                                            slideTimer.Dispose()
                                        End If
                                    End Sub
        slideTimer.Start()
    End Sub

    ''' <summary>
    ''' Hide floating action buttons immediately (used after the grace period)
    ''' </summary>
    Private Sub HideFloatingButtons()
        Try
            btnFloatEdit.Visible = False
            btnFloatDelete.Visible = False
        Catch
        End Try
    End Sub

    Private Sub OnButtonRevealTick(sender As Object, e As EventArgs)
        ' Animation handled in RevealFloatingButtons
    End Sub

    ' Called by hideButtonsTimer — only hide if cursor is outside the card bounds
    Private Sub OnHideButtonsTick(sender As Object, e As EventArgs)
        Try
            hideButtonsTimer.Stop()
        Catch
        End Try

        If Not IsCursorOverControl() Then
            HideFloatingButtons()
        Else
            ' If cursor is over control, keep buttons visible and ensure hovering state
            _isHovering = True
        End If
    End Sub

    ' Helper: is mouse currently over this card (client rectangle)
    Private Function IsCursorOverControl() As Boolean
        Try
            Dim pt = Me.PointToClient(Cursor.Position)
            Return Me.ClientRectangle.Contains(pt)
        Catch
            Return False
        End Try
    End Function

    ' ===== BUTTON CLICK EVENTS =====
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs)
        EnterEditMode()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)
        RaiseEvent DeleteRequested(_itemId, _itemName)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        If ValidateInput() Then
            Dim newName As String = txtEditName.Text.Trim()
            Dim newPrice As Decimal = Decimal.Parse(txtEditPrice.Text)
            RaiseEvent SaveRequested(_itemId, newName, newPrice, _imagePath)
            ExitEditMode()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        ExitEditMode()
    End Sub

    Private Sub BtnChangeImage_Click(sender As Object, e As EventArgs)
        Dim newPath As String = _imagePath
        RaiseEvent ImageChangeRequested(_itemId, newPath)
        If Not String.IsNullOrEmpty(newPath) Then
            _imagePath = newPath
            Try
                Dim img As Image = Image.FromFile(newPath)
                pbItemImage.Image = ResizeImageFit(img, pbItemImage)
            Catch
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Enter edit mode with expansion animation
    ''' </summary>
    Private Sub EnterEditMode()
        _isEditMode = True
        Me.Cursor = Cursors.Default

        ' Hide normal display
        lblItemName.Visible = False
        lblItemPrice.Visible = False
        btnFloatEdit.Visible = False
        btnFloatDelete.Visible = False

        ' Show edit controls
        pnlEditControls.Visible = True
        txtEditName.Text = _itemName
        txtEditPrice.Text = _itemPrice.ToString("F2")

        ' Expand card height
        Dim targetHeight As Integer = 380
        expandTimer.Tag = New Object() {Me.Height, targetHeight, True}
        expandTimer.Start()

        ' Add yellow border
        ' Note: Guna2ShadowPanel doesn't have BorderColor, simulate with increased shadow
        Me.ShadowDepth = 25
        Me.ShadowColor = Theme.PrimaryAccent

        ' Notify parent to dim other cards
        Me.BringToFront()
    End Sub

    ''' <summary>
    ''' Exit edit mode with collapse animation
    ''' </summary>
    Private Sub ExitEditMode()
        _isEditMode = False
        Me.Cursor = Cursors.Hand

        ' Show normal display
        lblItemName.Visible = True
        lblItemPrice.Visible = True

        ' Hide edit controls
        pnlEditControls.Visible = False

        ' Collapse card height
        Dim targetHeight As Integer = 300
        expandTimer.Tag = New Object() {Me.Height, targetHeight, False}
        expandTimer.Start()

        ' Remove yellow border
        Me.ShadowDepth = 8
        Me.ShadowColor = Color.Black
    End Sub

    Private Sub OnExpandAnimationTick(sender As Object, e As EventArgs)
        Dim data As Object() = CType(expandTimer.Tag, Object())
        Dim currentHeight As Integer = CInt(data(0))
        Dim targetHeight As Integer = CInt(data(1))
        Dim isExpanding As Boolean = CBool(data(2))

        If isExpanding Then
            If Me.Height < targetHeight Then
                Me.Height += 8
                data(0) = Me.Height
            Else
                Me.Height = targetHeight
                expandTimer.Stop()
            End If
        Else
            If Me.Height > targetHeight Then
                Me.Height -= 8
                data(0) = Me.Height
            Else
                Me.Height = targetHeight
                expandTimer.Stop()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Validate edit inputs
    ''' </summary>
    Private Function ValidateInput() As Boolean
        ' Check name
        If String.IsNullOrWhiteSpace(txtEditName.Text) Then
            MessageBox.Show("Item name cannot be empty.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEditName.Focus()
            Return False
        End If

        ' Check price
        Dim price As Decimal
        If Not Decimal.TryParse(txtEditPrice.Text, price) OrElse price <= 0 Then
            MessageBox.Show("Please enter a valid price greater than zero.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEditPrice.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Only allow numbers and decimal point in price field
    ''' </summary>
    Private Sub TxtPrice_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Only allow one decimal point
        If e.KeyChar = "."c AndAlso txtEditPrice.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Update card display after save
    ''' </summary>
    Public Sub UpdateDisplay(newName As String, newPrice As Decimal)
        _itemName = newName
        _itemPrice = newPrice
        lblItemName.Text = newName
        lblItemPrice.Text = "₱" & newPrice.ToString("F2")
    End Sub

    ''' <summary>
    ''' Adjust color brightness
    ''' </summary>
    Private Function AdjustBrightness(color As Color, amount As Integer) As Color
        Dim r As Integer = Math.Max(0, Math.Min(255, color.R + amount))
        Dim g As Integer = Math.Max(0, Math.Min(255, color.G + amount))
        Dim b As Integer = Math.Max(0, Math.Min(255, color.B + amount))
        Return Color.FromArgb(color.A, r, g, b)
    End Function

    ''' <summary>
    ''' Resize image to fit picture box while maintaining aspect ratio
    ''' </summary>
    Private Function ResizeImageFit(img As Image, pb As PictureBox) As Image
        Dim ratioX As Double = CDbl(pb.Width) / img.Width
        Dim ratioY As Double = CDbl(pb.Height) / img.Height
        Dim ratio As Double = Math.Min(ratioX, ratioY)

        Dim newWidth As Integer = CInt(img.Width * ratio)
        Dim newHeight As Integer = CInt(img.Height * ratio)

        Dim newImage As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(newImage)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using

        Return newImage
    End Function

    ''' <summary>
    ''' Cleanup
    ''' </summary>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            hoverTimer?.Dispose()
            buttonRevealTimer?.Dispose()
            expandTimer?.Dispose()
            fadeTimer?.Dispose()
            hideButtonsTimer?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class