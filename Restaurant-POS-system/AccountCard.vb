Imports System.Windows.Forms
Imports System.Drawing

''' <summary>
''' Modern Account Card UserControl with Guna2 styling
''' Displays user account information in a professional card layout
''' </summary>
Public Class AccountCard
    Inherits UserControl

    Public Event EditRequested(account As UserAccount)
    Public Event DeleteRequested(account As UserAccount)
    Public Event ArchiveRequested(account As UserAccount)

    Private _account As UserAccount

    Public Sub New()
        InitializeComponent()
        ApplyModernStyling()
    End Sub

    ''' <summary>
    ''' Set account data and update UI
    ''' </summary>
    Public Sub SetAccount(ac As UserAccount)
        _account = ac
        lblUsername.Text = ac.Username
        lblRole.Text = "Role: " & ac.Role
        lblDate.Text = "Created: " & ac.DateCreated.ToString("yyyy-MM-dd")

        ' Set role badge color
        UpdateRoleBadge(ac.Role)
    End Sub

    ''' <summary>
    ''' Update role badge styling based on role type
    ''' </summary>
    Private Sub UpdateRoleBadge(role As String)
        If lblRoleBadge IsNot Nothing Then
            Select Case role.ToLower()
                Case "admin"
                    lblRoleBadge.FillColor = Color.FromArgb(220, 38, 38)
                    lblRoleBadge.Text = "👑"
                Case "cashier"
                    lblRoleBadge.FillColor = Theme.SecondaryAccent
                    lblRoleBadge.Text = "💼"
                Case Else
                    lblRoleBadge.FillColor = Theme.PrimaryAccent
                    lblRoleBadge.Text = "👤"
            End Select
        End If
    End Sub

    ''' <summary>
    ''' Apply modern Guna2 styling to card
    ''' </summary>
    Private Sub ApplyModernStyling()
        If mainCard IsNot Nothing Then
            Theme.ApplyCardPanel(mainCard)
        End If

        If btnEdit IsNot Nothing Then
            Theme.ApplyPrimaryButton(btnEdit)
            btnEdit.Text = "✏️ Edit"
        End If

        If btnDelete IsNot Nothing Then
            btnDelete.FillColor = Color.FromArgb(220, 38, 38)
            btnDelete.BorderRadius = Theme.DefaultBorderRadius
            btnDelete.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
            btnDelete.ForeColor = Color.White
            btnDelete.Text = "🗑️ Delete"
            btnDelete.ShadowDecoration.Enabled = True
            btnDelete.Cursor = Cursors.Hand
        End If

        If btnArchive IsNot Nothing Then
            btnArchive.FillColor = Color.FromArgb(245, 158, 11)
            btnArchive.BorderRadius = Theme.DefaultBorderRadius
            btnArchive.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
            btnArchive.ForeColor = Color.White
            btnArchive.Text = "📦 Archive"
            btnArchive.ShadowDecoration.Enabled = True
            btnArchive.Cursor = Cursors.Hand
        End If
    End Sub

    Public ReadOnly Property Account As UserAccount
        Get
            Return _account
        End Get
    End Property

    ' ===== EVENT HANDLERS (Preserved from original) =====
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