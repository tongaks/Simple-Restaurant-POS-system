Imports System.Windows.Forms

Public Class ArchiveStorage
    Inherits Form

    ' Notify callers when archived accounts change (restore / delete)
    Public Event AccountsChanged(sender As Object, e As EventArgs)

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterParent

        ' Wire event handlers at runtime to avoid ENC0070/edit-in-place issues
        AddHandler Me.Load, AddressOf ArchiveStorage_Load
        AddHandler Me.Shown, AddressOf ArchiveStorage_Shown
        AddHandler txtSearchArchive.TextChanged, AddressOf txtSearchArchive_TextChanged
        AddHandler btnCloseArchive.Click, AddressOf btnCloseArchive_Click

        ' Setup button hover effects
        SetupButtonEffects()
    End Sub

    Private Sub ArchiveStorage_Load(sender As Object, e As EventArgs)
        LoadArchivedAccounts()
    End Sub

    Private Sub ArchiveStorage_Shown(sender As Object, e As EventArgs)
        ' Animate form entrance
        Me.Opacity = 0
        Dim fadeTimer As New Timer With {.Interval = 10}
        AddHandler fadeTimer.Tick, Sub()
                                       Me.Opacity += 0.05
                                       If Me.Opacity >= 1 Then
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()
                                       End If
                                   End Sub
        fadeTimer.Start()

        ' Animate search box entrance
        Dim originalY = txtSearchArchive.Location.Y
        txtSearchArchive.Location = New Point(txtSearchArchive.Location.X, originalY - 30)
        txtSearchArchive.Visible = False

        Dim searchTimer As New Timer With {.Interval = 200}
        AddHandler searchTimer.Tick, Sub()
                                         searchTimer.Stop()
                                         searchTimer.Dispose()
                                         txtSearchArchive.Visible = True
                                         TransitionAnimator.Show(txtSearchArchive)
                                     End Sub
        searchTimer.Start()
    End Sub

    Private Sub SetupButtonEffects()
        ' Add hover effect to close button
        AddHandler btnCloseArchive.MouseEnter, Sub()
                                                   btnCloseArchive.ShadowDecoration.Depth = 15
                                               End Sub
        AddHandler btnCloseArchive.MouseLeave, Sub()
                                                   btnCloseArchive.ShadowDecoration.Depth = 8
                                               End Sub

        ' Add focus effect to search textbox
        AddHandler txtSearchArchive.Enter, Sub()
                                               txtSearchArchive.ShadowDecoration.Depth = 10
                                           End Sub
        AddHandler txtSearchArchive.Leave, Sub()
                                               txtSearchArchive.ShadowDecoration.Depth = 5
                                           End Sub
    End Sub

    Private Sub LoadArchivedAccounts(Optional filter As String = "")
        pnlArchiveCards.Controls.Clear()

        ' Show loading animation
        ShowLoadingIndicator()

        ' Simulate async loading with timer for smooth experience
        Dim loadTimer As New Timer With {.Interval = 100}
        AddHandler loadTimer.Tick, Sub()
                                       loadTimer.Stop()
                                       loadTimer.Dispose()

                                       Dim accounts = DatabaseHandler.GetArchivedUsers(filter)

                                       ' Remove loading indicator
                                       For Each ctrl In pnlArchiveCards.Controls.OfType(Of Label)().ToList()
                                           If ctrl.Text.Contains("Loading") Then
                                               pnlArchiveCards.Controls.Remove(ctrl)
                                               ctrl.Dispose()
                                           End If
                                       Next

                                       If accounts.Count = 0 Then
                                           ShowEmptyState()
                                           Return
                                       End If

                                       ' Add accounts with staggered animation
                                       Dim yPos As Integer = 15
                                       Dim delay As Integer = 0

                                       For Each acc In accounts
                                           Dim card As New ArchivedAccountCard()
                                           card.Width = pnlArchiveCards.ClientSize.Width - 50
                                           card.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                                           card.SetAccount(acc)

                                           AddHandler card.RestoreRequested, Sub(a)
                                                                                 If MessageBox.Show($"Restore user '{a.Username}'?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                                                                     If DatabaseHandler.RestoreArchivedUser(a.ID) Then
                                                                                         ShowSuccessNotification("Account restored successfully!")
                                                                                         LoadArchivedAccounts(txtSearchArchive.Text.Trim())
                                                                                         RaiseEvent AccountsChanged(Me, EventArgs.Empty)
                                                                                     Else
                                                                                         MessageBox.Show("Failed to restore account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                                     End If
                                                                                 End If
                                                                             End Sub

                                           AddHandler card.DeletePermanentRequested, Sub(a)
                                                                                         If MessageBox.Show($"Permanently delete archived user '{a.Username}'? This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                                                                                             If DatabaseHandler.DeleteArchivedUser(a.ID) Then
                                                                                                 ShowSuccessNotification("Archived account deleted permanently!")
                                                                                                 LoadArchivedAccounts(txtSearchArchive.Text.Trim())
                                                                                                 RaiseEvent AccountsChanged(Me, EventArgs.Empty)
                                                                                             Else
                                                                                                 MessageBox.Show("Failed to delete archived account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                                             End If
                                                                                         End If
                                                                                     End Sub

                                           card.Location = New Point(15, yPos)
                                           card.Visible = False
                                           card.Tag = delay
                                           pnlArchiveCards.Controls.Add(card)

                                           ' Animate card entrance
                                           AnimateCardEntrance(card, delay)

                                           yPos += card.Height + 15
                                           delay += 50
                                       Next
                                   End Sub
        loadTimer.Start()
    End Sub

    Private Sub ShowLoadingIndicator()
        Dim loadingLbl As New Label() With {
            .Text = "⏳ Loading archived accounts...",
            .Font = New Font("Segoe UI", 12, FontStyle.Regular),
            .ForeColor = Color.FromArgb(100, 116, 139),
            .AutoSize = True,
            .Location = New Point(30, 30),
            .BackColor = Color.Transparent
        }
        pnlArchiveCards.Controls.Add(loadingLbl)
    End Sub

    Private Sub ShowEmptyState()
        Dim emptyPanel As New Guna.UI2.WinForms.Guna2Panel With {
            .Width = 400,
            .Height = 250,
            .BorderRadius = 20,
            .FillColor = Color.FromArgb(248, 250, 252),
            .Location = New Point((pnlArchiveCards.Width - 400) \ 2, 80)
        }

        Dim emptyIcon As New Label With {
            .Text = "📭",
            .Font = New Font("Segoe UI", 48),
            .AutoSize = True,
            .Location = New Point(160, 40),
            .BackColor = Color.Transparent
        }

        Dim emptyTitle As New Label With {
            .Text = "No Archived Accounts",
            .Font = New Font("Segoe UI", 16, FontStyle.Bold),
            .ForeColor = Color.FromArgb(71, 85, 105),
            .AutoSize = True,
            .Location = New Point(80, 120),
            .BackColor = Color.Transparent
        }

        Dim emptySubtitle As New Label With {
            .Text = "Archive accounts to see them here",
            .Font = New Font("Segoe UI", 11),
            .ForeColor = Color.FromArgb(148, 163, 184),
            .AutoSize = True,
            .Location = New Point(90, 155),
            .BackColor = Color.Transparent
        }

        emptyPanel.Controls.AddRange({emptyIcon, emptyTitle, emptySubtitle})
        pnlArchiveCards.Controls.Add(emptyPanel)

        ' Animate empty state
        emptyPanel.Visible = False
        Dim showTimer As New Timer With {.Interval = 200}
        AddHandler showTimer.Tick, Sub()
                                       showTimer.Stop()
                                       showTimer.Dispose()
                                       emptyPanel.Visible = True
                                       TransitionAnimator.Show(emptyPanel)
                                   End Sub
        showTimer.Start()
    End Sub

    Private Sub AnimateCardEntrance(card As Control, delay As Integer)
        Dim entryTimer As New Timer With {.Interval = delay, .Tag = card}
        AddHandler entryTimer.Tick, Sub(s, e)
                                        Dim timer = DirectCast(s, Timer)
                                        Dim cardCtrl = DirectCast(timer.Tag, Control)
                                        timer.Stop()
                                        timer.Dispose()

                                        cardCtrl.Visible = True
                                        TransitionAnimator.Show(cardCtrl)
                                    End Sub
        entryTimer.Start()
    End Sub

    Private Sub ShowSuccessNotification(message As String)
        ' Create success notification panel
        Dim notification As New Guna.UI2.WinForms.Guna2Panel With {
            .Width = 350,
            .Height = 60,
            .BorderRadius = 15,
            .FillColor = Color.FromArgb(16, 185, 129),
            .Location = New Point(Me.Width - 370, -70)
        }

        notification.ShadowDecoration.BorderRadius = 15
        notification.ShadowDecoration.Depth = 10
        notification.ShadowDecoration.Enabled = True
        notification.ShadowDecoration.Color = Color.FromArgb(16, 185, 129)

        Dim notifLabel As New Label With {
            .Text = "✓ " & message,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = Color.White,
            .AutoSize = False,
            .Size = New Size(330, 40),
            .Location = New Point(10, 10),
            .TextAlign = ContentAlignment.MiddleLeft,
            .BackColor = Color.Transparent
        }

        notification.Controls.Add(notifLabel)
        Me.Controls.Add(notification)
        notification.BringToFront()

        ' Slide in animation
        Dim slideTimer As New Timer With {.Interval = 10}
        Dim targetY As Integer = 20
        AddHandler slideTimer.Tick, Sub()
                                        notification.Location = New Point(notification.Location.X, notification.Location.Y + 5)
                                        If notification.Location.Y >= targetY Then
                                            slideTimer.Stop()
                                            slideTimer.Dispose()

                                            ' Auto-hide after 3 seconds
                                            Dim hideTimer As New Timer With {.Interval = 3000}
                                            AddHandler hideTimer.Tick, Sub()
                                                                           hideTimer.Stop()
                                                                           hideTimer.Dispose()

                                                                           ' Slide out
                                                                           Dim slideOutTimer As New Timer With {.Interval = 10}
                                                                           AddHandler slideOutTimer.Tick, Sub()
                                                                                                              notification.Location = New Point(notification.Location.X, notification.Location.Y - 5)
                                                                                                              If notification.Location.Y <= -70 Then
                                                                                                                  slideOutTimer.Stop()
                                                                                                                  slideOutTimer.Dispose()
                                                                                                                  Me.Controls.Remove(notification)
                                                                                                                  notification.Dispose()
                                                                                                              End If
                                                                                                          End Sub
                                                                           slideOutTimer.Start()
                                                                       End Sub
                                            hideTimer.Start()
                                        End If
                                    End Sub
        slideTimer.Start()
    End Sub

    Private Sub txtSearchArchive_TextChanged(sender As Object, e As EventArgs)
        ' Debounce search for better performance
        Static searchTimer As Timer = Nothing

        If searchTimer IsNot Nothing Then
            searchTimer.Stop()
            searchTimer.Dispose()
        End If

        searchTimer = New Timer With {.Interval = 300}
        AddHandler searchTimer.Tick, Sub()
                                         searchTimer.Stop()
                                         searchTimer.Dispose()
                                         LoadArchivedAccounts(txtSearchArchive.Text.Trim())
                                     End Sub
        searchTimer.Start()
    End Sub

    Private Sub btnCloseArchive_Click(sender As Object, e As EventArgs)
        ' Animate form exit
        Dim fadeTimer As New Timer With {.Interval = 10}
        AddHandler fadeTimer.Tick, Sub()
                                       Me.Opacity -= 0.1
                                       If Me.Opacity <= 0 Then
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()
                                           Me.Close()
                                       End If
                                   End Sub
        fadeTimer.Start()
    End Sub
End Class