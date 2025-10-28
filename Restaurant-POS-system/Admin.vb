Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports Guna.UI2.WinForms

''' <summary>
''' Ultra Modern Admin Dashboard - OrderUp! System
''' Features: Stunning UI, Smooth Animations, Professional Design
''' </summary>
Public Class Admin
    Private currentUserRole As String = "Admin"
    Private navButtons As AdminNavButtons
    Private currentActiveButton As Guna2Button = Nothing
    Private menuButtons As New List(Of Guna2Button)
    Private currentPanel As Panel = Nothing

    ' PathManager helper class
    Public Class PathManager
        Public Shared Function GetExportsPath() As String
            Dim appPath As String = Application.StartupPath
            Dim exportsPath As String = Path.Combine(appPath, "exports")
            If Not Directory.Exists(exportsPath) Then
                Directory.CreateDirectory(exportsPath)
            End If
            Return exportsPath
        End Function

        Public Shared Function GetLogsPath() As String
            Dim appPath As String = Application.StartupPath
            Dim logsPath As String = Path.Combine(appPath, "logs")
            If Not Directory.Exists(logsPath) Then
                Directory.CreateDirectory(logsPath)
            End If
            Return logsPath
        End Function
    End Class

    ''' <summary>
    ''' Form load - initialize ultra modern dashboard
    ''' </summary>
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize navigation buttons
        navButtons = New AdminNavButtons(Me, btnLogout, Nothing, btnHelp, btnInstructions)

        Me.WindowState = FormWindowState.Maximized

        ' Apply stunning modern styling
        ApplyUltraModernStyling()

        ' Initialize modern sidebar menu
        InitializeModernSidebar()

        ' Load initial view
        LoadAuditLogs()
        pnlManageAccounts.Visible = False
        pnlAuditLog.Visible = True
        currentPanel = pnlAuditLog

        ' Initialize archived_users table
        DatabaseHandler.EnsureArchivedUsersTableExists()

        ' Set initial active button
        If menuButtons.Count > 0 Then
            SetActiveButton(menuButtons(0))
        End If

        ' Add smooth fade-in animation
        Me.Opacity = 0
        Dim fadeTimer As New Timer With {.Interval = 10}
        AddHandler fadeTimer.Tick, Sub(s, args)
                                       If Me.Opacity < 1 Then
                                           Me.Opacity += 0.05
                                       Else
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()
                                       End If
                                   End Sub
        fadeTimer.Start()
    End Sub

    ''' <summary>
    ''' Initialize ultra modern sidebar with beautiful buttons
    ''' </summary>
    Private Sub InitializeModernSidebar()
        Try
            flowMenuCards.Controls.Clear()
            menuButtons.Clear()

            ' Create Audit Log Button
            Dim btnAudit As Guna2Button = CreateModernSidebarButton(
                "📋 Audit Log",
                "View system activity",
                Color.FromArgb(139, 92, 246)
            )
            AddHandler btnAudit.Click, AddressOf MenuButton_Audit_Clicked
            flowMenuCards.Controls.Add(btnAudit)
            menuButtons.Add(btnAudit)

            ' Create Sales Report Button
            Dim btnSales As Guna2Button = CreateModernSidebarButton(
                "📊 Sales Report",
                "View revenue analytics",
                Color.FromArgb(16, 185, 129)
            )
            AddHandler btnSales.Click, AddressOf MenuButton_Sales_Clicked
            flowMenuCards.Controls.Add(btnSales)
            menuButtons.Add(btnSales)

            ' Create Manage Menu Button
            Dim btnMenu As Guna2Button = CreateModernSidebarButton(
                "🍽️ Manage Menu",
                "Edit food items",
                Color.FromArgb(251, 191, 36)
            )
            AddHandler btnMenu.Click, AddressOf MenuButton_Menu_Clicked
            flowMenuCards.Controls.Add(btnMenu)
            menuButtons.Add(btnMenu)

            ' Create Manage Accounts Button
            Dim btnAccounts As Guna2Button = CreateModernSidebarButton(
                "👥 Manage Accounts",
                "User management",
                Color.FromArgb(59, 130, 246)
            )
            AddHandler btnAccounts.Click, AddressOf MenuButton_Accounts_Clicked
            flowMenuCards.Controls.Add(btnAccounts)
            menuButtons.Add(btnAccounts)

        Catch ex As Exception
            MessageBox.Show("Error initializing sidebar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Create modern sidebar button with icon and hover effects
    ''' </summary>
    Private Function CreateModernSidebarButton(text As String, tooltip As String, accentColor As Color) As Guna2Button
        Dim btn As New Guna2Button()

        With btn
            .Text = text
            .Size = New Size(240, 70)
            .Margin = New Padding(10, 8, 10, 8)
            .BorderRadius = 15
            .Font = New Font("Segoe UI", 11.5F, FontStyle.Bold)
            .FillColor = Color.FromArgb(37, 42, 52)
            .ForeColor = Color.FromArgb(200, 200, 200)
            .BorderThickness = 0
            .TextAlign = HorizontalAlignment.Left
            .ImageAlign = HorizontalAlignment.Left
            .Cursor = Cursors.Hand
            .Tag = accentColor
            .AutoRoundedCorners = False

            ' Hover effects
            .HoverState.FillColor = Color.FromArgb(45, 50, 62)
            .HoverState.ForeColor = Theme.PrimaryAccent
            .HoverState.BorderColor = Theme.PrimaryAccent

            ' Shadow
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 8
            .ShadowDecoration.Color = Color.FromArgb(50, 0, 0, 0)

            ' Pressed state
            .PressedColor = Color.FromArgb(50, 55, 67)
        End With

        ' Add tooltip
        Dim tip As New ToolTip()
        tip.SetToolTip(btn, tooltip)

        Return btn
    End Function

    ''' <summary>
    ''' Set active button with stunning visual feedback
    ''' </summary>
    Private Sub SetActiveButton(btn As Guna2Button)
        ' Reset all buttons
        For Each menuBtn In menuButtons
            menuBtn.FillColor = Color.FromArgb(37, 42, 52)
            menuBtn.ForeColor = Color.FromArgb(200, 200, 200)
            menuBtn.BorderThickness = 0
            menuBtn.ShadowDecoration.Depth = 8
        Next

        ' Highlight active button with accent color
        If btn IsNot Nothing Then
            Dim accentColor As Color = If(btn.Tag IsNot Nothing, DirectCast(btn.Tag, Color), Theme.PrimaryAccent)

            btn.FillColor = Theme.PrimaryAccent
            btn.ForeColor = Color.FromArgb(30, 30, 30)
            btn.BorderThickness = 3
            btn.BorderColor = accentColor
            btn.ShadowDecoration.Depth = 15
            btn.ShadowDecoration.Color = Color.FromArgb(80, accentColor)

            ' Animate button
            Dim originalSize = btn.Size
            btn.Size = New Size(originalSize.Width - 5, originalSize.Height - 5)
            Dim animTimer As New Timer With {.Interval = 50}
            AddHandler animTimer.Tick, Sub(s, args)
                                           btn.Size = originalSize
                                           animTimer.Stop()
                                           animTimer.Dispose()
                                       End Sub
            animTimer.Start()
        End If

        currentActiveButton = btn
    End Sub

    ''' <summary>
    ''' Apply ultra modern styling to all controls
    ''' </summary>
    Private Sub ApplyUltraModernStyling()
        Try
            ' Main form styling
            Me.BackColor = Color.FromArgb(247, 250, 252)

            ' Header styling
            pnlHeader.FillColor = Color.FromArgb(37, 42, 52)
            pnlHeader.ShadowDecoration.Enabled = True
            pnlHeader.ShadowDecoration.Depth = 15
            pnlHeader.ShadowDecoration.Color = Color.FromArgb(80, 0, 0, 0)

            ' Title and subtitle
            lblTitle.ForeColor = Color.White
            lblTitle.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
            lblSubtitle.ForeColor = Color.FromArgb(180, 180, 180)
            lblSubtitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)

            ' Header buttons with stunning colors
            StyleHeaderButton(btnLogout, Color.FromArgb(220, 38, 38), "🚪 Logout")
            StyleHeaderButton(btnInstructions, Theme.PrimaryAccent, "📖 Guide", Color.FromArgb(30, 30, 30))
            StyleHeaderButton(btnHelp, Color.FromArgb(31, 138, 112), "❓ Help")

            ' Sidebar styling
            pnlSidebar.FillColor = Color.FromArgb(30, 34, 42)
            pnlSidebar.ShadowDecoration.Enabled = True
            pnlSidebar.ShadowDecoration.Depth = 20
            pnlSidebar.ShadowDecoration.Color = Color.FromArgb(100, 0, 0, 0)

            lblSidebarTitle.ForeColor = Theme.PrimaryAccent
            lblSidebarTitle.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)

            ' Audit log panel styling
            pnlAuditLog.FillColor = Color.FromArgb(247, 250, 252)
            lblAuditTitle.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
            lblAuditTitle.ForeColor = Color.FromArgb(37, 42, 52)

            ' Filter controls
            StyleModernTextBox(txtUsernameFilter)
            StyleModernButton(btnFilterAuditLogs, Theme.PrimaryAccent, "🔍 Filter", Color.FromArgb(30, 30, 30))
            StyleModernButton(btnExportAuditLogs, Color.FromArgb(31, 138, 112), "📊 Export CSV")

            ' Date pickers
            StyleDatePicker(dtpAuditFrom)
            StyleDatePicker(dtpAuditTo)

            ' Checkbox styling
            chkDateFilter.CheckedState.FillColor = Theme.PrimaryAccent
            chkDateFilter.CheckedState.BorderColor = Theme.PrimaryAccent
            chkDateFilter.Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)

            ' DataGridView ultra modern styling
            StyleModernDataGrid(dgvAuditLogs)

            ' Audit content panel
            pnlAuditContent.FillColor = Color.White
            pnlAuditContent.ShadowDepth = 12
            pnlAuditContent.ShadowColor = Color.FromArgb(60, 0, 0, 0)
            pnlAuditContent.Radius = 15

            ' Accounts management styling
            pnlManageAccounts.FillColor = Color.FromArgb(247, 250, 252)
            lblAccountsTitle.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
            lblAccountsTitle.ForeColor = Color.FromArgb(37, 42, 52)

            ' Account controls
            StyleModernTextBox(txtSearchAccounts)
            StyleModernButton(btnCreateAccount, Color.FromArgb(31, 138, 112), "➕ Create Account")
            StyleModernButton(btnViewArchive, Color.FromArgb(245, 158, 11), "📦 View Archive")

        Catch ex As Exception
            LogError("ApplyUltraModernStyling", ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Style header button with gradient and shadows
    ''' </summary>
    Private Sub StyleHeaderButton(btn As Guna2Button, fillColor As Color, text As String, Optional foreColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.White

        With btn
            .FillColor = fillColor
            .ForeColor = foreColor
            .BorderRadius = 12
            .Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Bold)
            .Size = New Size(120, 50)
            .Cursor = Cursors.Hand
            .Text = text

            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 10
            .ShadowDecoration.Color = Color.FromArgb(80, 0, 0, 0)

            .HoverState.FillColor = AdjustBrightness(fillColor, -20)
            .PressedColor = AdjustBrightness(fillColor, -40)
        End With
    End Sub

    ''' <summary>
    ''' Style modern textbox with rounded corners and focus effects
    ''' </summary>
    Private Sub StyleModernTextBox(txt As Guna2TextBox)
        With txt
            .BorderRadius = 12
            .BorderThickness = 3                    ' << set thickness on the control, not on FocusedState
            .BorderColor = Color.FromArgb(220, 220, 220)
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)
            .ForeColor = Color.FromArgb(30, 30, 30)
            .PlaceholderForeColor = Color.FromArgb(150, 150, 150)
            .Height = 45

            .FocusedState.BorderColor = Theme.PrimaryAccent
            ' -- removed invalid: .FocusedState.BorderThickness = 3

            .HoverState.BorderColor = Color.FromArgb(180, 180, 180)

            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 5
            .ShadowDecoration.Color = Color.FromArgb(30, 0, 0, 0)
        End With
    End Sub

    ''' <summary>
    ''' Style modern button with shadows and hover effects
    ''' </summary>
    Private Sub StyleModernButton(btn As Guna2Button, fillColor As Color, text As String, Optional foreColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.White

        With btn
            .FillColor = fillColor
            .ForeColor = foreColor
            .BorderRadius = 12
            .Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .Text = text
            .Height = 45

            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 8
            .ShadowDecoration.Color = Color.FromArgb(60, 0, 0, 0)

            .HoverState.FillColor = AdjustBrightness(fillColor, -20)
            .PressedColor = AdjustBrightness(fillColor, -40)
        End With
    End Sub

    ''' <summary>
    ''' Style date picker with modern look
    ''' </summary>
    Private Sub StyleDatePicker(dtp As Guna2DateTimePicker)
        With dtp
            .BorderRadius = 12
            .BorderThickness = 2
            .BorderColor = Color.FromArgb(220, 220, 220)
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
            .FillColor = Color.White
            .ForeColor = Color.FromArgb(30, 30, 30)
            .Height = 45

            .FocusedColor = Theme.PrimaryAccent
        End With
    End Sub

    ''' <summary>
    ''' Style DataGridView with modern professional look
    ''' </summary>
    Private Sub StyleModernDataGrid(dgv As DataGridView)
        With dgv
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.FromArgb(240, 240, 240)
            .RowTemplate.Height = 50

            ' Header styling
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .ColumnHeadersHeight = 55
            .EnableHeadersVisualStyles = False

            Dim headerStyle As New DataGridViewCellStyle()
            headerStyle.BackColor = Theme.PrimaryAccent
            headerStyle.ForeColor = Color.FromArgb(30, 30, 30)
            headerStyle.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
            headerStyle.Padding = New Padding(10)
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            headerStyle.SelectionBackColor = Theme.PrimaryAccent
            .ColumnHeadersDefaultCellStyle = headerStyle

            ' Cell styling
            Dim cellStyle As New DataGridViewCellStyle()
            cellStyle.BackColor = Color.White
            cellStyle.ForeColor = Color.FromArgb(60, 60, 60)
            cellStyle.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
            cellStyle.Padding = New Padding(10, 8, 10, 8)
            cellStyle.SelectionBackColor = Color.FromArgb(255, 245, 200)
            cellStyle.SelectionForeColor = Color.FromArgb(30, 30, 30)
            .DefaultCellStyle = cellStyle

            ' Alternating row colors
            Dim altStyle As New DataGridViewCellStyle()
            altStyle.BackColor = Color.FromArgb(252, 252, 252)
            .AlternatingRowsDefaultCellStyle = altStyle

            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
        End With
    End Sub

    ''' <summary>
    ''' Adjust color brightness for hover effects
    ''' </summary>
    Private Function AdjustBrightness(color As Color, amount As Integer) As Color
        Dim r As Integer = Math.Max(0, Math.Min(255, color.R + amount))
        Dim g As Integer = Math.Max(0, Math.Min(255, color.G + amount))
        Dim b As Integer = Math.Max(0, Math.Min(255, color.B + amount))
        Return Color.FromArgb(color.A, r, g, b)
    End Function

    ''' <summary>
    ''' Switch between panels with smooth transition
    ''' </summary>
    Private Sub SwitchPanel(targetPanel As Panel)
        If currentPanel Is targetPanel Then Return

        ' Hide current panel
        If currentPanel IsNot Nothing Then
            currentPanel.Visible = False
        End If

        ' Show target panel
        targetPanel.Visible = True
        targetPanel.BringToFront()
        currentPanel = targetPanel
    End Sub

    ''' <summary>
    ''' Menu button click handlers
    ''' </summary>
    Private Sub MenuButton_Audit_Clicked(sender As Object, e As EventArgs)
        SetActiveButton(TryCast(sender, Guna2Button))
        SwitchPanel(pnlAuditLog)
        LoadAuditLogs()
    End Sub

    Private Sub MenuButton_Sales_Clicked(sender As Object, e As EventArgs)
        SetActiveButton(TryCast(sender, Guna2Button))
        Try
            Dim salesReportForm As New SalesReport()
            salesReportForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MenuButton_Menu_Clicked(sender As Object, e As EventArgs)
        SetActiveButton(TryCast(sender, Guna2Button))
        Try
            Dim menuForm As New Manage_menu()
            menuForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening menu management: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MenuButton_Accounts_Clicked(sender As Object, e As EventArgs)
        SetActiveButton(TryCast(sender, Guna2Button))
        SwitchPanel(pnlManageAccounts)
        LoadUserAccounts()
    End Sub

    ''' <summary>
    ''' Load audit logs with optional filters (ORIGINAL LOGIC PRESERVED)
    ''' </summary>
    Private Sub LoadAuditLogs(Optional usernameFilter As String = "", Optional dateFrom As DateTime? = Nothing, Optional dateTo As DateTime? = Nothing)
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                Dim query As String = "SELECT DATE_FORMAT(log_time, '%Y-%m-%d %H:%i:%s') AS log_time, username, role, action FROM activity_logs WHERE 1=1"
                Dim cmd As New MySqlCommand()

                If Not String.IsNullOrEmpty(usernameFilter) Then
                    query &= " AND username LIKE @username"
                    cmd.Parameters.AddWithValue("@username", "%" & usernameFilter & "%")
                End If

                If dateFrom.HasValue Then
                    query &= " AND log_time >= @dateFrom"
                    cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value.Date)
                End If

                If dateTo.HasValue Then
                    query &= " AND log_time <= @dateTo"
                    cmd.Parameters.AddWithValue("@dateTo", dateTo.Value.Date.AddDays(1).AddSeconds(-1))
                End If

                query &= " ORDER BY log_time DESC LIMIT 200"

                cmd.CommandText = query
                cmd.Connection = connection

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvAuditLogs.DataSource = dt
                dgvAuditLogs.AutoResizeColumns()
            End Using
        Catch ex As Exception
            LogError("LoadAuditLogs", ex.Message)
            MessageBox.Show("Error loading audit logs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Filter audit logs (ORIGINAL LOGIC PRESERVED)
    ''' </summary>
    Private Sub FilterAuditLogs()
        Dim dateFrom As DateTime? = Nothing
        Dim dateTo As DateTime? = Nothing

        If chkDateFilter.Checked Then
            dateFrom = dtpAuditFrom.Value.Date
            dateTo = dtpAuditTo.Value.Date
        End If

        LoadAuditLogs(txtUsernameFilter.Text.Trim(), dateFrom, dateTo)
    End Sub

    ''' <summary>
    ''' Export audit logs to CSV (ORIGINAL LOGIC PRESERVED)
    ''' </summary>
    Private Sub ExportAuditLogsToCsv()
        Try
            If dgvAuditLogs.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim fileName As String = $"AuditLogs_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            Dim filePath As String = Path.Combine(PathManager.GetExportsPath(), fileName)

            ExportDataGridToCsv(dgvAuditLogs, filePath)
            MessageBox.Show($"Audit logs exported to: {filePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            LogError("ExportAuditLogsToCsv", ex.Message)
            MessageBox.Show("Error exporting audit logs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Export DataGridView to CSV (ORIGINAL LOGIC PRESERVED)
    ''' </summary>
    Private Sub ExportDataGridToCsv(dgv As DataGridView, filePath As String)
        Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
            Dim headers As String = String.Join(",", dgv.Columns.Cast(Of DataGridViewColumn)().Select(Function(col) $"""{col.HeaderText}"""))
            writer.WriteLine(headers)

            For Each row As DataGridViewRow In dgv.Rows
                If Not row.IsNewRow Then
                    Dim values As String = String.Join(",", row.Cells.Cast(Of DataGridViewCell)().Select(Function(cell) $"""{If(cell.Value, "")}"""))
                    writer.WriteLine(values)
                End If
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Load user accounts with modern card display (ORIGINAL LOGIC PRESERVED)
    ''' </summary>
    Private Sub LoadUserAccounts(Optional searchFilter As String = "")
        Try
            pnlAccountCards.Controls.Clear()

            Dim accounts = DatabaseHandler.GetAllUsers(searchFilter)

            Dim yPos As Integer = 10

            For Each account In accounts
                Dim card As New AccountCard()
                card.Width = pnlAccountCards.ClientSize.Width - 40
                card.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                card.SetAccount(account)

                AddHandler card.EditRequested, Sub(a)
                                                   Dim editForm As New CreateEditAccountForm(a)
                                                   If editForm.ShowDialog() = DialogResult.OK Then
                                                       LoadUserAccounts(txtSearchAccounts.Text.Trim())
                                                   End If
                                               End Sub

                AddHandler card.DeleteRequested, Sub(a)
                                                     Dim result = MessageBox.Show($"Are you sure you want to permanently delete user '{a.Username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                                     If result = DialogResult.Yes Then
                                                         If DatabaseHandler.DeleteUser(a.ID) Then
                                                             MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                             LoadUserAccounts(txtSearchAccounts.Text.Trim())
                                                         Else
                                                             MessageBox.Show("Failed to delete account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                         End If
                                                     End If
                                                 End Sub

                AddHandler card.ArchiveRequested, Sub(a)
                                                      Dim result = MessageBox.Show($"Archive user '{a.Username}'? This will move the account to archived storage.", "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                      If result = DialogResult.Yes Then
                                                          If DatabaseHandler.ArchiveUser(a.ID) Then
                                                              MessageBox.Show("Account archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                              LoadUserAccounts(txtSearchAccounts.Text.Trim())
                                                          Else
                                                              MessageBox.Show("Failed to archive account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                          End If
                                                      End If
                                                  End Sub

                card.Location = New Point(10, yPos)
                pnlAccountCards.Controls.Add(card)
                yPos += card.Height + 10
            Next

            If accounts.Count = 0 Then
                Dim lblNoData As New Label()
                lblNoData.Text = "No accounts found."
                lblNoData.Font = New Font("Segoe UI", 12, FontStyle.Italic)
                lblNoData.ForeColor = Color.Gray
                lblNoData.Location = New Point(10, 10)
                lblNoData.AutoSize = True
                pnlAccountCards.Controls.Add(lblNoData)
            End If

        Catch ex As Exception
            LogError("LoadUserAccounts", ex.Message)
            MessageBox.Show("Error loading user accounts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Log error messages to file (ORIGINAL LOGIC PRESERVED)
    ''' </summary>
    Private Sub LogError(method As String, message As String)
        Try
            Dim logFile As String = Path.Combine(PathManager.GetLogsPath(), "error.txt")
            Using writer As New StreamWriter(logFile, True)
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {method}: {message}")
            End Using
        Catch
            ' Silent fail for logging errors
        End Try
    End Sub

    ' ===== ORIGINAL EVENT HANDLERS (PRESERVED) =====

    Private Sub btnFilterAuditLogs_Click(sender As Object, e As EventArgs) Handles btnFilterAuditLogs.Click
        FilterAuditLogs()
    End Sub

    Private Sub btnExportAuditLogs_Click(sender As Object, e As EventArgs) Handles btnExportAuditLogs.Click
        ExportAuditLogsToCsv()
    End Sub

    Private Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        Dim createForm As New CreateEditAccountForm()
        If createForm.ShowDialog() = DialogResult.OK Then
            LoadUserAccounts(txtSearchAccounts.Text.Trim())
        End If
    End Sub

    Private Sub txtSearchAccounts_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAccounts.TextChanged
        LoadUserAccounts(txtSearchAccounts.Text.Trim())
    End Sub

    Private Sub btnViewArchive_Click(sender As Object, e As EventArgs) Handles btnViewArchive.Click
        Try
            Dim archiveForm As New ArchiveStorage()
            archiveForm.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show("Error opening archive storage: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkDateFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateFilter.CheckedChanged
        dtpAuditFrom.Enabled = chkDateFilter.Checked
        dtpAuditTo.Enabled = chkDateFilter.Checked
    End Sub

    Private Sub pnlHeader_Paint(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint
    End Sub

    Private Sub pnlManageAccounts_Paint(sender As Object, e As PaintEventArgs) Handles pnlManageAccounts.Paint
    End Sub
End Class