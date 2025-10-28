Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Guna.UI2.WinForms

''' <summary>
''' Premium Enterprise Account Card UserControl
''' Beautiful design with gradients, shadows, and animations
''' </summary>
Partial Public Class PremiumAccountCard
    Inherits UserControl

    ' Public Events
    Public Event EditRequested(account As UserAccount)
    Public Event DeleteRequested(account As UserAccount)
    Public Event ArchiveRequested(account As UserAccount)

    ' Private Fields
    Private _account As UserAccount

    ' NOTE: Control declarations are in the Designer.vb file

    Public Sub New()
        ' This calls the designer-generated code to create and position controls
        InitializeComponent()
        ApplyPremiumStyling()
    End Sub

    ''' <summary>
    ''' Applies custom premium styling like hover shadow effects.
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

    ''' <summary>
    ''' Sets the account data and updates the card UI accordingly.
    ''' </summary>
    Public Sub SetAccount(account As UserAccount)
        _account = account

        lblUsername.Text = account.Username
        lblDate.Text = $"Created: {account.DateCreated:yyyy-MM-dd}"

        ' Set role badge
        Dim role As String = If(String.IsNullOrEmpty(account.Role), "User", account.Role)
        roleBadge.Text = role

        ' Color code by role
        Select Case role.ToLower()
            Case "admin"
                roleBadge.FillColor = Color.FromArgb(239, 68, 68)
                avatarCircle.FillColor = Color.FromArgb(239, 68, 68)
                avatarCircle.Text = "👑"
            Case "cashier"
                roleBadge.FillColor = Color.FromArgb(16, 185, 129)
                avatarCircle.FillColor = Color.FromArgb(16, 185, 129)
                avatarCircle.Text = "💼"
            Case Else
                roleBadge.FillColor = Color.FromArgb(59, 130, 246)
                avatarCircle.FillColor = Color.FromArgb(59, 130, 246)
                avatarCircle.Text = "👤"
        End Select
    End Sub

    ''' <summary>
    ''' Provides read-only access to the associated account data.
    ''' </summary>
    Public ReadOnly Property Account As UserAccount
        Get
            Return _account
        End Get
    End Property

    ' --- Event Handlers (Click logic) ---

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        RaiseEvent EditRequested(_account)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        RaiseEvent DeleteRequested(_account)
    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        RaiseEvent ArchiveRequested(_account)
    End Sub

End Class