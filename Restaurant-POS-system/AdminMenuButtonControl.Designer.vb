<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminMenuButtonControl
    Inherits System.Windows.Forms.UserControl

    Private components As System.ComponentModel.IContainer
    Friend WithEvents mainCard As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents clickableButton As Guna.UI2.WinForms.Guna2Button
    Friend lblTitle As System.Windows.Forms.Label
    Friend lblSubtitle As System.Windows.Forms.Label
    Friend pnlIconBadge As Guna.UI2.WinForms.Guna2CircleButton
    Friend lblArrow As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Size = New System.Drawing.Size(280, 140)
        Me.Margin = New Padding(15)
        Me.BackColor = Color.Transparent

        ' Main card shadow panel
        mainCard = New Guna.UI2.WinForms.Guna2ShadowPanel()
        mainCard.Dock = DockStyle.Fill
        mainCard.BackColor = Theme.WhiteSurface
        mainCard.FillColor = Theme.WhiteSurface
        mainCard.ShadowColor = Color.Black
        mainCard.ShadowDepth = Theme.CardShadowDepth
        mainCard.ShadowShift = 3
        mainCard.Radius = Theme.DefaultBorderRadius
        mainCard.Padding = New Padding(Theme.DefaultPadding)

        ' Clickable transparent button overlay
        clickableButton = New Guna.UI2.WinForms.Guna2Button()
        clickableButton.Dock = DockStyle.Fill
        clickableButton.FillColor = Color.Transparent
        clickableButton.BorderColor = Color.Transparent
        clickableButton.HoverState.FillColor = Color.FromArgb(12, Theme.PrimaryAccent)
        clickableButton.PressedColor = Color.FromArgb(20, Theme.PrimaryAccent)
        clickableButton.Cursor = Cursors.Hand
        clickableButton.TabStop = True
        clickableButton.TabIndex = 0
        AddHandler clickableButton.Click, AddressOf OnButtonClick
        AddHandler clickableButton.KeyDown, AddressOf OnClickableButtonKeyDown

        ' Icon badge (circular)
        pnlIconBadge = New Guna.UI2.WinForms.Guna2CircleButton()
        pnlIconBadge.Size = New Size(60, 60)
        pnlIconBadge.Location = New Point(15, 15)
        pnlIconBadge.FillColor = Theme.PrimaryAccent
        pnlIconBadge.Font = New Font("Segoe UI", 24.0F, FontStyle.Regular)
        pnlIconBadge.ForeColor = Color.White
        pnlIconBadge.Text = "📊"
        pnlIconBadge.ShadowDecoration.Enabled = True
        pnlIconBadge.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        pnlIconBadge.Cursor = Cursors.Hand
        AddHandler pnlIconBadge.Click, AddressOf OnButtonClick

        ' Title label
        lblTitle = New Label()
        lblTitle.Location = New Point(90, 20)
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI Semibold", 13.0F, FontStyle.Bold)
        lblTitle.ForeColor = Theme.DarkText
        lblTitle.Text = "Menu Item"
        lblTitle.Cursor = Cursors.Hand
        AddHandler lblTitle.Click, AddressOf OnButtonClick

        ' Subtitle label
        lblSubtitle = New Label()
        lblSubtitle.Location = New Point(90, 48)
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        lblSubtitle.ForeColor = Theme.GrayText
        lblSubtitle.Text = "Description"
        lblSubtitle.MaximumSize = New Size(170, 0)
        lblSubtitle.Cursor = Cursors.Hand
        AddHandler lblSubtitle.Click, AddressOf OnButtonClick

        ' Arrow icon
        lblArrow = New Label()
        lblArrow.Text = "→"
        lblArrow.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblArrow.ForeColor = Theme.PrimaryAccent
        lblArrow.Location = New Point(235, 50)
        lblArrow.AutoSize = True
        lblArrow.Cursor = Cursors.Hand
        AddHandler lblArrow.Click, AddressOf OnButtonClick

        ' Apply theme helpers
        Theme.ApplyCardPanel(mainCard)
        Theme.ApplyCircularBadge(pnlIconBadge, pnlIconBadge.Text, pnlIconBadge.FillColor)

        ' Add controls to card
        mainCard.Controls.Add(pnlIconBadge)
        mainCard.Controls.Add(lblTitle)
        mainCard.Controls.Add(lblSubtitle)
        mainCard.Controls.Add(lblArrow)
        mainCard.Controls.Add(clickableButton)
        clickableButton.BringToFront()

        Me.Controls.Add(mainCard)
    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
End Class