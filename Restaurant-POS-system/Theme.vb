Imports System.Drawing
Imports Guna.UI2.WinForms

''' <summary>
''' Central theme configuration for Restaurant POS System
''' Defines the strict 3-color palette and styling helpers
''' </summary>
Public Module Theme
    ' ===== STRICT 3-COLOR PALETTE =====
    ''' <summary>Primary Accent - Yellow for highlights, active states, CTAs</summary>
    Public ReadOnly Property PrimaryAccent As Color
        Get
            Return Color.FromArgb(255, 200, 87) ' #FFC857
        End Get
    End Property

    ''' <summary>Secondary Accent - Teal/Deep Green for secondary actions, borders</summary>
    Public ReadOnly Property SecondaryAccent As Color
        Get
            Return Color.FromArgb(31, 138, 112) ' #1F8A70
        End Get
    End Property

    ''' <summary>Neutral Background - Light gray for surfaces and backgrounds</summary>
    Public ReadOnly Property NeutralBackground As Color
        Get
            Return Color.FromArgb(247, 247, 249) ' #F7F7F9
        End Get
    End Property

    ' ===== DERIVED SHADES (For depth, not brand colors) =====
    ''' <summary>White surface color for cards and panels</summary>
    Public ReadOnly Property WhiteSurface As Color
        Get
            Return Color.White
        End Get
    End Property

    ''' <summary>Dark text color for readability (near-black)</summary>
    Public ReadOnly Property DarkText As Color
        Get
            Return Color.FromArgb(30, 30, 30)
        End Get
    End Property

    ''' <summary>Gray text for secondary information</summary>
    Public ReadOnly Property GrayText As Color
        Get
            Return Color.FromArgb(120, 120, 120)
        End Get
    End Property

    ''' <summary>Light border color for subtle separation</summary>
    Public ReadOnly Property LightBorder As Color
        Get
            Return Color.FromArgb(220, 220, 220)
        End Get
    End Property

    ' ===== TYPOGRAPHY =====
    Public ReadOnly Property DefaultFont As Font
        Get
            Return New Font("Segoe UI", 9.0F, FontStyle.Regular)
        End Get
    End Property

    Public ReadOnly Property HeadingFont As Font
        Get
            Return New Font("Segoe UI Semibold", 14.0F, FontStyle.Bold)
        End Get
    End Property

    Public ReadOnly Property SubheadingFont As Font
        Get
            Return New Font("Segoe UI", 11.0F, FontStyle.Regular)
        End Get
    End Property

    ' ===== CONTROL STYLING CONSTANTS =====
    Public Const DefaultBorderRadius As Integer = 12
    Public Const CardShadowDepth As Integer = 8
    Public Const ButtonShadowDepth As Integer = 4
    Public Const DefaultPadding As Integer = 15

    ' ===== HELPER METHODS =====

    ''' <summary>
    ''' Apply primary button styling (Yellow with hover effects)
    ''' </summary>
    Public Sub ApplyPrimaryButton(btn As Guna2Button)
        With btn
            .FillColor = PrimaryAccent
            .ForeColor = DarkText
            .BorderRadius = DefaultBorderRadius
            .Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = ButtonShadowDepth
            .ShadowDecoration.Color = Color.FromArgb(50, 0, 0, 0)
            .Cursor = Cursors.Hand
            .HoverState.FillColor = Color.FromArgb(240, 180, 67) ' Slightly darker yellow
            .PressedColor = Color.FromArgb(220, 160, 47)
        End With
    End Sub

    ''' <summary>
    ''' Apply secondary button styling (Teal with hover effects)
    ''' </summary>
    Public Sub ApplySecondaryButton(btn As Guna2Button)
        With btn
            .FillColor = SecondaryAccent
            .ForeColor = Color.White
            .BorderRadius = DefaultBorderRadius
            .Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = ButtonShadowDepth
            .ShadowDecoration.Color = Color.FromArgb(50, 0, 0, 0)
            .Cursor = Cursors.Hand
            .HoverState.FillColor = Color.FromArgb(21, 118, 92) ' Slightly darker teal
            .PressedColor = Color.FromArgb(16, 98, 72)
        End With
    End Sub

    ''' <summary>
    ''' Apply outlined button styling (Border only, transparent fill)
    ''' </summary>
    Public Sub ApplyOutlinedButton(btn As Guna2Button, Optional useSecondary As Boolean = True)
        With btn
            .FillColor = Color.Transparent
            .BorderColor = If(useSecondary, SecondaryAccent, PrimaryAccent)
            .BorderThickness = 2
            .ForeColor = If(useSecondary, SecondaryAccent, PrimaryAccent)
            .BorderRadius = DefaultBorderRadius
            .Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .HoverState.BorderColor = If(useSecondary, Color.FromArgb(21, 118, 92), Color.FromArgb(240, 180, 67))
            .HoverState.ForeColor = If(useSecondary, Color.FromArgb(21, 118, 92), Color.FromArgb(240, 180, 67))
        End With
    End Sub

    ''' <summary>
    ''' Apply card panel styling with shadow and rounded corners
    ''' </summary>
    Public Sub ApplyCardPanel(panel As Guna2ShadowPanel)
        With panel
            .BackColor = WhiteSurface
            .ShadowColor = Color.Black
            .ShadowDepth = CardShadowDepth
            .ShadowShift = 3
            .Padding = New Padding(DefaultPadding)
            .FillColor = WhiteSurface
            .Radius = DefaultBorderRadius
        End With
    End Sub

    ''' <summary>
    ''' Apply modern textbox styling
    ''' </summary>
    Public Sub ApplyTextBox(txt As Guna2TextBox)
        With txt
            .BorderRadius = DefaultBorderRadius
            .BorderColor = LightBorder
            .BorderThickness = 1
            .Font = DefaultFont
            .ForeColor = DarkText
            .PlaceholderForeColor = GrayText
            .FocusedState.BorderColor = SecondaryAccent
            .HoverState.BorderColor = Color.FromArgb(180, 180, 180)
        End With
    End Sub

    ''' <summary>
    ''' Apply pill-style filter button (for All/On Process/Completed filters)
    ''' </summary>
    Public Sub ApplyFilterPill(btn As Guna2Button, isActive As Boolean)
        With btn
            .BorderRadius = 20 ' More rounded for pill shape
            .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            .Size = New Size(110, 38)
            .Cursor = Cursors.Hand

            If isActive Then
                ' Active state: Teal fill with white text
                .FillColor = SecondaryAccent
                .ForeColor = Color.White
                .BorderThickness = 0
            Else
                ' Inactive state: Outlined neutral
                .FillColor = Color.Transparent
                .BorderColor = LightBorder
                .BorderThickness = 2
                .ForeColor = GrayText
            End If
        End With
    End Sub

    ''' <summary>
    ''' Apply status badge styling (small pill for card status)
    ''' </summary>
    Public Sub ApplyStatusBadge(lbl As Guna2HtmlLabel, statusText As String, statusColor As Color)
        With lbl
            .Text = statusText
            .BackColor = statusColor
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            .AutoSize = False
            .Size = New Size(90, 24)
            .TextAlignment = ContentAlignment.MiddleCenter
        End With
    End Sub

    ''' <summary>
    ''' Apply sidebar button styling (for navigation)
    ''' </summary>
    Public Sub ApplySidebarButton(btn As Guna2Button, isSelected As Boolean)
        With btn
            .BorderRadius = DefaultBorderRadius
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)
            .TextAlign = HorizontalAlignment.Left
            .ImageAlign = HorizontalAlignment.Left
            .Cursor = Cursors.Hand
            .Size = New Size(200, 50)

            If isSelected Then
                ' Selected: Yellow pill with teal icon/text
                .FillColor = PrimaryAccent
                .ForeColor = SecondaryAccent
                .ImageOffset = New Point(10, 0)
                .TextOffset = New Point(20, 0)
            Else
                ' Unselected: Transparent with gray text
                .FillColor = Color.Transparent
                .ForeColor = GrayText
                .HoverState.FillColor = Color.FromArgb(20, PrimaryAccent)
                .ImageOffset = New Point(10, 0)
                .TextOffset = New Point(20, 0)
            End If
        End With
    End Sub

    ''' <summary>
    ''' Apply search box styling with icon
    ''' </summary>
    Public Sub ApplySearchBox(txt As Guna2TextBox)
        With txt
            .BorderRadius = DefaultBorderRadius
            .BorderColor = LightBorder
            .BorderThickness = 1
            .Font = DefaultFont
            .PlaceholderText = "🔍 Search..."
            .PlaceholderForeColor = GrayText
            .FocusedState.BorderColor = SecondaryAccent
            .IconLeft = Nothing
            .IconLeftOffset = New Point(10, 0)
            .TextOffset = New Point(10, 0)
        End With
    End Sub

    ''' <summary>
    ''' Apply circular avatar/initials badge styling
    ''' </summary>
    Public Sub ApplyCircularBadge(panel As Guna2CircleButton, initials As String, badgeColor As Color)
        With panel
            .FillColor = badgeColor
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
            .Text = initials
            .Size = New Size(50, 50)
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        End With
    End Sub

    ''' <summary>
    ''' Get a color for card badges (cycles through predefined set)
    ''' </summary>
    Public Function GetBadgeColor(index As Integer) As Color
        Dim colors As Color() = {
            PrimaryAccent,
            SecondaryAccent,
            Color.FromArgb(100, 149, 237), ' Cornflower blue
            Color.FromArgb(255, 127, 80),  ' Coral
            Color.FromArgb(147, 112, 219)  ' Medium purple
        }
        Return colors(index Mod colors.Length)
    End Function
End Module