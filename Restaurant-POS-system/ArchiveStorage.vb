Imports System.Windows.Forms

Public Class ArchiveStorage
    Inherits Form

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterParent

        ' Wire event handlers at runtime to avoid ENC0070/edit-in-place issues
        AddHandler Me.Load, AddressOf ArchiveStorage_Load
        AddHandler txtSearchArchive.TextChanged, AddressOf txtSearchArchive_TextChanged
        AddHandler btnCloseArchive.Click, AddressOf btnCloseArchive_Click
    End Sub

    Private Sub ArchiveStorage_Load(sender As Object, e As EventArgs)
        LoadArchivedAccounts()
    End Sub

    Private Sub LoadArchivedAccounts(Optional filter As String = "")
        pnlArchiveCards.Controls.Clear()
        Dim accounts = DatabaseHandler.GetArchivedUsers(filter)

        If accounts.Count = 0 Then
            Dim lbl As New Label() With {
                .Text = "No archived accounts.",
                .Font = New Font("Segoe UI", 12, FontStyle.Italic),
                .ForeColor = Color.Gray,
                .AutoSize = True,
                .Location = New Point(20, 20)
            }
            pnlArchiveCards.Controls.Add(lbl)
            Return
        End If

        Dim yPos As Integer = 10
        For Each acc In accounts
            Dim card As New ArchivedAccountCard()
            card.Width = pnlArchiveCards.ClientSize.Width - 40
            card.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            card.SetAccount(acc)
            AddHandler card.RestoreRequested, Sub(a)
                                                  If MessageBox.Show($"Restore user '{a.Username}'?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                                      If DatabaseHandler.RestoreArchivedUser(a.ID) Then
                                                          MessageBox.Show("Account restored.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                          LoadArchivedAccounts(txtSearchArchive.Text.Trim())
                                                      Else
                                                          MessageBox.Show("Failed to restore account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                      End If
                                                  End If
                                              End Sub

            AddHandler card.DeletePermanentRequested, Sub(a)
                                                          If MessageBox.Show($"Permanently delete archived user '{a.Username}'? This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                                                              If DatabaseHandler.DeleteArchivedUser(a.ID) Then
                                                                  MessageBox.Show("Archived account deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                                  LoadArchivedAccounts(txtSearchArchive.Text.Trim())
                                                              Else
                                                                  MessageBox.Show("Failed to delete archived account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                              End If
                                                          End If
                                                      End Sub

            card.Location = New Point(10, yPos)
            pnlArchiveCards.Controls.Add(card)
            yPos += card.Height + 10
        Next
    End Sub

    Private Sub txtSearchArchive_TextChanged(sender As Object, e As EventArgs)
        LoadArchivedAccounts(txtSearchArchive.Text.Trim())
    End Sub

    Private Sub btnCloseArchive_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class