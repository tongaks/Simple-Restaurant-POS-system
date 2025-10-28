Imports System.Drawing
Imports System.Windows.Forms
Imports Guna.UI2.WinForms ' NEW: Added Guna Imports

Public Class ArchivedAccountCard
    Inherits UserControl

    ' Public Events (Maintained 100% functionality)
    Public Event RestoreRequested(account As UserAccount)
    Public Event DeletePermanentRequested(account As UserAccount)

    Private _account As UserAccount

    Public Sub New()
        InitializeComponent()

        ' Wire handlers at runtime to avoid Edit&Continue/ENC0070 issues (Maintained 100% functionality)
        AddHandler btnRestore.Click, AddressOf btnRestore_Click
        AddHandler btnDeletePermanent.Click, AddressOf btnDeletePermanent_Click

        ' NEW: Apply the premium styling effects on hover, matching the template
        ApplyPremiumStyling()
    End Sub

    ''' <summary>
    ''' Applies custom premium styling like hover shadow effects. Modeled after PremiumAccountCard.
    ''' </summary>
    Private Sub ApplyPremiumStyling()
        ' Enhanced shadow on hover
        AddHandler Me.MouseEnter, Sub(s, e)
                                      mainCard.ShadowDepth = 18
                                      mainCard.ShadowColor = Color.FromArgb(100, 0, 0, 0)
                                  End Sub

        AddHandler Me.MouseLeave, Sub(s, e)
                                      mainCard.ShadowDepth = 12
                                      mainCard.ShadowColor = Color.Black
                                  End Sub
    End Sub

    Public Sub SetAccount(ac As UserAccount)
        _account = ac
        lblUsername.Text = ac.Username ' No longer includes "Username: " prefix for cleaner look

        ' NEW: Use the Guna2Chip (roleBadge) to display the role with modern styling
        SetRoleStyles(ac.Role)

        lblDate.Text = "Archived: " & ac.DateCreated.ToString("yyyy-MM-dd")

        ' The original lblRole remains a component but is not explicitly set here, 
        ' as its display function is taken over by the roleBadge for modernization.
    End Sub

    ''' <summary>
    ''' Applies specific colors and icons to the avatar and role badge based on the user's role.
    ''' Modeled after PremiumAccountCard.Designer.vb.
    ''' </summary>
    Private Sub SetRoleStyles(role As String)
        roleBadge.Text = role

        ' Color code by role
        Select Case role.ToLower()
            Case "admin"
                roleBadge.FillColor = Color.FromArgb(239, 68, 68) ' Red
                avatarCircle.FillColor = Color.FromArgb(239, 68, 68)
                avatarCircle.Text = "👑"
            Case "cashier"
                roleBadge.FillColor = Color.FromArgb(16, 185, 129) ' Green
                avatarCircle.FillColor = Color.FromArgb(16, 185, 129)
                avatarCircle.Text = "💼"
            Case Else
                roleBadge.FillColor = Color.FromArgb(59, 130, 246) ' Blue (Default)
                avatarCircle.FillColor = Color.FromArgb(59, 130, 246)
                avatarCircle.Text = "👤"
        End Select
    End Sub

    Public ReadOnly Property Account As UserAccount
        Get
            Return _account
        End Get
    End Property

    ' Event Handlers (Maintained 100% functionality)
    Private Sub btnRestore_Click(sender As Object, e As EventArgs)
        RaiseEvent RestoreRequested(_account)
    End Sub

    Private Sub btnDeletePermanent_Click(sender As Object, e As EventArgs)
        RaiseEvent DeletePermanentRequested(_account)
    End Sub

    Private Sub lblDate_Click(sender As Object, e As EventArgs) Handles lblDate.Click

    End Sub

    Private Sub lblRole_Click(sender As Object, e As EventArgs) Handles lblRole.Click

    End Sub

    Private Sub btnRestore_Click_1(sender As Object, e As EventArgs) Handles btnRestore.Click

    End Sub
End Class
