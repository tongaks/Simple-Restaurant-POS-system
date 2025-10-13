Imports System.Windows.Forms

Public Class AccountCard
    Inherits UserControl

    Public Event EditRequested(account As UserAccount)
    Public Event DeleteRequested(account As UserAccount)
    Public Event ArchiveRequested(account As UserAccount)

    Private _account As UserAccount

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub SetAccount(ac As UserAccount)
        _account = ac
        lblUsername.Text = "Username: " & ac.Username
        lblRole.Text = "Role: " & ac.Role
        lblDate.Text = "Created: " & ac.DateCreated.ToString("yyyy-MM-dd")
    End Sub

    Public ReadOnly Property Account As UserAccount
        Get
            Return _account
        End Get
    End Property

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