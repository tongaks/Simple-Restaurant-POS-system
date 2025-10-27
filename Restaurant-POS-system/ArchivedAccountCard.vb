Imports System.Windows.Forms

Public Class ArchivedAccountCard
    Inherits UserControl

    Public Event RestoreRequested(account As UserAccount)
    Public Event DeletePermanentRequested(account As UserAccount)

    Private _account As UserAccount

    Public Sub New()
        InitializeComponent()

        ' Wire handlers at runtime to avoid Edit&Continue/ENC0070 issues
        AddHandler btnRestore.Click, AddressOf btnRestore_Click
        AddHandler btnDeletePermanent.Click, AddressOf btnDeletePermanent_Click
    End Sub

    Public Sub SetAccount(ac As UserAccount)
        _account = ac
        lblUsername.Text = "Username: " & ac.Username
        lblRole.Text = "Role: " & ac.Role
        lblDate.Text = "Archived: " & ac.DateCreated.ToString("yyyy-MM-dd")
    End Sub

    Public ReadOnly Property Account As UserAccount
        Get
            Return _account
        End Get
    End Property

    Private Sub btnRestore_Click(sender As Object, e As EventArgs)
        RaiseEvent RestoreRequested(_account)
    End Sub

    Private Sub btnDeletePermanent_Click(sender As Object, e As EventArgs)
        RaiseEvent DeletePermanentRequested(_account)
    End Sub
End Class