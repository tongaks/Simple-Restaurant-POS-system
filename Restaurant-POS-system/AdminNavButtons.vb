Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms

''' <summary>
''' Manages navigation buttons for Admin and related forms.
''' Handles Logout, Back, Help, and Instructions functionality.
''' Accepts parent control (Form or UserControl) so it works when a UserControl hosts navigation buttons.
''' </summary>
Public Class AdminNavButtons
    Private ReadOnly _parentControl As Control
    Private ReadOnly _logoutBtn As Control
    Private ReadOnly _backBtn As Control
    Private ReadOnly _helpBtn As Control
    Private ReadOnly _instructionsBtn As Control

    Public Sub New(parentControl As Control, logoutBtn As Control, Optional backBtn As Control = Nothing, Optional helpBtn As Control = Nothing, Optional instructionsBtn As Control = Nothing)
        _parentControl = parentControl
        _logoutBtn = logoutBtn
        _backBtn = backBtn
        _helpBtn = helpBtn
        _instructionsBtn = instructionsBtn

        If _logoutBtn IsNot Nothing Then
            StyleButton(_logoutBtn, Color.FromArgb(220, 38, 38))
            AddHandler _logoutBtn.Click, AddressOf HandleLogout
        End If

        If _backBtn IsNot Nothing Then
            StyleButton(_backBtn, Color.LightSkyBlue)
            AddHandler _backBtn.Click, AddressOf HandleBack
        End If

        If _helpBtn IsNot Nothing Then
            StyleButton(_helpBtn, Color.FromArgb(31, 138, 112))
            AddHandler _helpBtn.Click, AddressOf HandleHelp
        End If

        If _instructionsBtn IsNot Nothing Then
            StyleButton(_instructionsBtn, Color.FromArgb(255, 200, 87))
            AddHandler _instructionsBtn.Click, AddressOf HandleInstructions
        End If
    End Sub

    Private Sub StyleButton(btn As Control, backColor As Color)
        If btn Is Nothing Then Return

        If TypeOf btn Is Guna.UI2.WinForms.Guna2Button Then
            Dim gbtn = DirectCast(btn, Guna.UI2.WinForms.Guna2Button)
            gbtn.BorderRadius = Theme.DefaultBorderRadius
            gbtn.Cursor = Cursors.Hand
            gbtn.FillColor = backColor
            gbtn.Font = New Drawing.Font("Segoe UI Semibold", 10.0F, Drawing.FontStyle.Bold)
            gbtn.ForeColor = Color.White
            gbtn.Size = If(gbtn.Size = Size.Empty, New Size(100, 40), gbtn.Size)
            gbtn.Visible = True
            Return
        End If

        If TypeOf btn Is Button Then
            Dim sbtn = DirectCast(btn, Button)
            sbtn.FlatStyle = FlatStyle.Flat
            sbtn.Font = New Drawing.Font("Segoe UI", 10.0F, Drawing.FontStyle.Regular)
            sbtn.BackColor = backColor
            sbtn.ForeColor = Color.Black
            sbtn.FlatAppearance.BorderSize = 1
            sbtn.Padding = New Padding(6, 4, 6, 4)
            sbtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            sbtn.Visible = True
            Return
        End If

        Try
            btn.BackColor = backColor
            btn.ForeColor = Color.Black
        Catch
        End Try
    End Sub

    Private Sub HandleLogout(sender As Object, e As EventArgs)
        Dim result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Try
                Try
                    Using connection As New MySqlConnection(GetGlobalConnectionString())
                        connection.Open()
                        Dim query As String = "INSERT INTO activity_logs (log_time, username, role, action) VALUES (@time, @username, @role, @action)"
                        Using cmd As New MySqlCommand(query, connection)
                            cmd.Parameters.AddWithValue("@time", DateTime.Now)
                            cmd.Parameters.AddWithValue("@username", CurrentUser)
                            cmd.Parameters.AddWithValue("@role", If(IsAdmin, "Admin", "User"))
                            cmd.Parameters.AddWithValue("@action", "Logged out")
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                Catch
                End Try

                CurrentUser = String.Empty

                Dim parentForm = _parentControl?.FindForm()
                If parentForm IsNot Nothing Then
                    parentForm.Hide()
                End If
                Form1.Show()
            Catch ex As Exception
                MessageBox.Show("Error during logout: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub HandleBack(sender As Object, e As EventArgs)
        Dim result = MessageBox.Show("Are you sure you want to go back? Any unsaved changes will be lost.", "Confirm Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim parentForm = _parentControl?.FindForm()
            If parentForm IsNot Nothing Then
                ' If parent is actually a Manage_menu UserControl host (unlikely here), just show Admin
                If TypeOf _parentControl Is Manage_menu Then
                    Try
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is Admin Then
                                f.Show()
                                f.BringToFront()
                                Return
                            End If
                        Next
                        Dim adminForm As New Admin()
                        adminForm.Show()
                    Catch
                        Dim adminForm As New Admin()
                        adminForm.Show()
                    End Try
                Else
                    parentForm.Close()
                End If
            End If
        End If
    End Sub

    Private Sub HandleHelp(sender As Object, e As EventArgs)
        Dim helpMessage As String = "Admin Dashboard Help" & vbCrLf & vbCrLf &
            "Features:" & vbCrLf & "• Audit Log - View system activity logs with filtering options" & vbCrLf &
            "• Sales Report - Generate and export sales reports by date range" & vbCrLf &
            "• Manage Menu - Add, edit, or delete menu items" & vbCrLf &
            "• Manage Accounts - View all user accounts" & vbCrLf & vbCrLf
        MessageBox.Show(helpMessage, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub HandleInstructions(sender As Object, e As EventArgs)
        Dim instructions As String = "Admin Dashboard Instructions" & vbCrLf & vbCrLf &
            "Audit Log:" & vbCrLf &
            "1. Filter logs by username or date range" & vbCrLf &
            "2. Click 'Filter' to apply filters" & vbCrLf &
            "3. Click 'Export to CSV' to save logs" & vbCrLf & vbCrLf &
            "Sales Report:" & vbCrLf &
            "1. Select date range (From/To)" & vbCrLf &
            "2. Click 'Generate Report' to view data" & vbCrLf &
            "3. Click 'Export to CSV' to save report" & vbCrLf & vbCrLf &
            "Manage Menu:" & vbCrLf &
            "1. Click 'Manage Menu' on the sidebar" & vbCrLf &
            "2. Select category and item to edit" & vbCrLf &
            "3. Use Edit, Delete, or Add buttons" & vbCrLf & vbCrLf &
            "Manage Accounts:" & vbCrLf &
            "1. View all user and admin accounts" & vbCrLf &
            "2. Account creation feature coming soon"
        MessageBox.Show(instructions, "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class