Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

''' <summary>
''' Manages navigation buttons for Admin and related forms.
''' Handles Logout, Back, Help, and Instructions functionality.
''' Constructor accepts existing designer buttons (one or more) so logic lives here and forms stay clean.
''' </summary>
Public Class AdminNavButtons
    Private ReadOnly _parentForm As Form
    Private ReadOnly _logoutBtn As Button
    Private ReadOnly _backBtn As Button
    Private ReadOnly _helpBtn As Button
    Private ReadOnly _instructionsBtn As Button

    ''' <summary>
    ''' Initialize the navigation button handler.
    ''' Pass only the buttons that exist on the target form (back/help/instructions optional).
    ''' </summary>
    Public Sub New(parentForm As Form, logoutBtn As Button, Optional backBtn As Button = Nothing, Optional helpBtn As Button = Nothing, Optional instructionsBtn As Button = Nothing)
        _parentForm = parentForm
        _logoutBtn = logoutBtn
        _backBtn = backBtn
        _helpBtn = helpBtn
        _instructionsBtn = instructionsBtn

        ' Style buttons for consistent UI at runtime (designer still shows them in designer)
        StyleButton(_logoutBtn, Color.LightCoral)
        If _backBtn IsNot Nothing Then StyleButton(_backBtn, Color.LightSkyBlue)
        If _helpBtn IsNot Nothing Then StyleButton(_helpBtn, Color.LightGreen)
        If _instructionsBtn IsNot Nothing Then StyleButton(_instructionsBtn, Color.LightYellow)

        ' Wire up event handlers conditionally
        AddHandler _logoutBtn.Click, AddressOf HandleLogout
        If _backBtn IsNot Nothing Then AddHandler _backBtn.Click, AddressOf HandleBack
        If _helpBtn IsNot Nothing Then AddHandler _helpBtn.Click, AddressOf HandleHelp
        If _instructionsBtn IsNot Nothing Then AddHandler _instructionsBtn.Click, AddressOf HandleInstructions
    End Sub

    Private Sub StyleButton(btn As Button, backColor As Color)
        If btn Is Nothing Then Return
        btn.FlatStyle = FlatStyle.Flat
        btn.Font = New Drawing.Font("Segoe UI", 10.0F, Drawing.FontStyle.Regular)
        btn.BackColor = backColor
        btn.ForeColor = Color.Black
        btn.FlatAppearance.BorderSize = 1
        btn.Padding = New Padding(6, 4, 6, 4)
        btn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btn.Visible = True
    End Sub

    ''' <summary>
    ''' Handles logout - returns to login form
    ''' </summary>
    Private Sub HandleLogout(sender As Object, e As EventArgs)
        Dim result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                ' Log the logout action (best-effort)
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
                    ' swallow - do not block logout for logging failure
                End Try

                ' Clear current user and return to login
                CurrentUser = String.Empty

                _parentForm.Hide()
                Form1.Show()
            Catch ex As Exception
                MessageBox.Show("Error during logout: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Handles back navigation - closes current form. On Manage_menu this will return to Admin.
    ''' </summary>
    Private Sub HandleBack(sender As Object, e As EventArgs)
        Dim result = MessageBox.Show("Are you sure you want to go back? Any unsaved changes will be lost.", "Confirm Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ' If the parent is Manage_menu, show Admin form instead of exiting
            If TypeOf _parentForm Is Manage_menu Then
                _parentForm.Hide()
                Try
                    ' If Admin is already open, just show it; otherwise, create a new one
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
                    ' fallback: create and show new Admin form
                    Dim adminForm As New Admin()
                    adminForm.Show()
                End Try
            Else
                ' For other forms, just close
                _parentForm.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Shows help information
    ''' </summary>
    Private Sub HandleHelp(sender As Object, e As EventArgs)
        Dim helpMessage As String = "Admin Dashboard Help" & vbCrLf & vbCrLf &
            "Features:" & vbCrLf &
            "• Audit Log - View system activity logs with filtering options" & vbCrLf &
            "• Sales Report - Generate and export sales reports by date range" & vbCrLf &
            "• Manage Menu - Add, edit, or delete menu items" & vbCrLf &
            "• Manage Accounts - View all user accounts" & vbCrLf & vbCrLf
        MessageBox.Show(helpMessage, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Shows detailed instructions
    ''' </summary>
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
            "1. Click 'Manage Menu Items' button" & vbCrLf &
            "2. Select category and item to edit" & vbCrLf &
            "3. Use Edit, Delete, or Add buttons" & vbCrLf & vbCrLf &
            "Manage Accounts:" & vbCrLf &
            "1. View all user and admin accounts" & vbCrLf &
            "2. Account creation feature coming soon"
        MessageBox.Show(instructions, "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class