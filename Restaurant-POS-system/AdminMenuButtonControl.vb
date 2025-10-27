Imports System.Drawing
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

''' <summary>
''' Reusable UserControl for Admin Dashboard menu buttons
''' Modern card-style button with icon, title, and subtitle
''' </summary>
Partial Public Class AdminMenuButtonControl
    Inherits UserControl

    ' ===== EVENTS =====
    Public Event Clicked(sender As Object, e As EventArgs)

    Private _title As String = "Menu Item"
    Private _subtitle As String = "Description"
    Private _iconText As String = "📊"
    Private _badgeColor As Color = Theme.PrimaryAccent

    ' ===== PROPERTIES =====
    Public Property Title As String
        Get
            Return _title
        End Get
        Set(value As String)
            _title = value
            If lblTitle IsNot Nothing Then lblTitle.Text = value
        End Set
    End Property

    Public Property Subtitle As String
        Get
            Return _subtitle
        End Get
        Set(value As String)
            _subtitle = value
            If lblSubtitle IsNot Nothing Then lblSubtitle.Text = value
        End Set
    End Property

    Public Property IconText As String
        Get
            Return _iconText
        End Get
        Set(value As String)
            _iconText = value
            If pnlIconBadge IsNot Nothing Then pnlIconBadge.Text = value
        End Set
    End Property

    Public Property BadgeColor As Color
        Get
            Return _badgeColor
        End Get
        Set(value As Color)
            _badgeColor = value
            If pnlIconBadge IsNot Nothing Then pnlIconBadge.FillColor = value
        End Set
    End Property

    ' ===== CONSTRUCTOR =====
    Public Sub New()
        InitializeComponent()
        ApplyStyling()

        ' Ensure accessible keyboard focus and hover visualization
        If clickableButton IsNot Nothing Then
            AddHandler clickableButton.KeyDown, AddressOf OnClickableButtonKeyDown
        End If
        AddHandler Me.Enter, AddressOf OnControlEnter
        AddHandler Me.Leave, AddressOf OnControlLeave
    End Sub

    ' ===== STYLING (runtime adjustments) =====
    Private Sub ApplyStyling()
        Me.BackColor = Theme.NeutralBackground
        If mainCard IsNot Nothing Then
            mainCard.FillColor = Theme.WhiteSurface
            mainCard.BackColor = Theme.WhiteSurface
        End If

        If lblArrow IsNot Nothing Then lblArrow.ForeColor = Theme.PrimaryAccent

        If pnlIconBadge IsNot Nothing Then
            Theme.ApplyCircularBadge(pnlIconBadge, _iconText, _badgeColor)
        End If
    End Sub

    ' ===== PUBLIC HELPERS =====
    Public Sub UpdateFromData(title As String, subtitle As String, iconText As String, Optional badgeColor As Color = Nothing)
        Me.Title = title
        Me.Subtitle = subtitle
        Me.IconText = iconText
        If Not badgeColor.Equals(Nothing) Then
            Me.BadgeColor = badgeColor
        End If
    End Sub

    Public Sub SetBadgeColorByIndex(index As Integer)
        Me.BadgeColor = Theme.GetBadgeColor(index)
    End Sub

    Public Sub SetIconImage(img As Image)
        If pnlIconBadge Is Nothing Then Return
        pnlIconBadge.Image = img
        pnlIconBadge.Text = String.Empty
        pnlIconBadge.ImageSize = New Size(28, 28)
    End Sub

    Public Sub ToggleArrowVisible(isVisible As Boolean)
        If lblArrow IsNot Nothing Then lblArrow.Visible = isVisible
    End Sub

    ' ===== EVENT HANDLERS =====
    Private Sub OnButtonClick(sender As Object, e As EventArgs)
        ' Visual feedback: brief shadow increase
        Try
            If mainCard IsNot Nothing Then
                mainCard.ShadowDepth = Theme.CardShadowDepth + 2
                Dim t As New Timer With {.Interval = 120}
                AddHandler t.Tick, Sub(s, a)
                                       t.Stop()
                                       t.Dispose()
                                       If mainCard IsNot Nothing Then mainCard.ShadowDepth = Theme.CardShadowDepth
                                   End Sub
                t.Start()
            End If
        Catch
        End Try

        RaiseEvent Clicked(Me, EventArgs.Empty)
    End Sub

    Private Sub OnClickableButtonKeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Space Then
            OnButtonClick(sender, EventArgs.Empty)
            e.Handled = True
        End If
    End Sub

    Private Sub OnControlEnter(sender As Object, e As EventArgs)
        If mainCard IsNot Nothing Then
            mainCard.ShadowColor = Color.FromArgb(60, Theme.PrimaryAccent)
            mainCard.ShadowDepth = Theme.CardShadowDepth + 2
        End If
    End Sub

    Private Sub OnControlLeave(sender As Object, e As EventArgs)
        If mainCard IsNot Nothing Then
            mainCard.ShadowColor = Color.Black
            mainCard.ShadowDepth = Theme.CardShadowDepth
        End If
    End Sub
End Class