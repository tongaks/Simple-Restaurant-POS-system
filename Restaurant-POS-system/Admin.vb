Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Guna.UI2.WinForms

''' <summary>
''' ENTERPRISE-GRADE Admin Dashboard - OrderUp! System
''' Premium Design with Full Guna2 Capabilities
''' </summary>
Public Class Admin
    Private currentUserRole As String = "Admin"
    Private navButtons As AdminNavButtons
    Private currentActiveButton As ModernNavButton = Nothing
    Private menuButtons As New List(Of ModernNavButton)
    Private currentPanel As Panel = Nothing
    Private fadeTimer As Timer
    Private fadeStep As Integer

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
    ''' Form load - initialize premium dashboard
    ''' </summary>
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize navigation
        navButtons = New AdminNavButtons(Me, btnLogout, Nothing, btnHelp, btnInstructions)

        Me.WindowState = FormWindowState.Maximized

        ' Apply premium enterprise styling
        ApplyPremiumEnterpriseDesign()

        ' Initialize premium sidebar
        InitializePremiumSidebar()

        ' Load initial view
        LoadAuditLogs()
        pnlManageAccounts.Visible = False
        pnlAuditLog.Visible = True
        currentPanel = pnlAuditLog

        ' Initialize database
        DatabaseHandler.EnsureArchivedUsersTableExists()

        ' Set initial active
        If menuButtons.Count > 0 Then
            SetActiveNavButton(menuButtons(0))
        End If

        ' Cinematic entrance animation
        AnimateEntranceEffect()
    End Sub

    ''' <summary>
    ''' Cinematic entrance animation
    ''' </summary>
    Private Sub AnimateEntranceEffect()
        Me.Opacity = 0
        pnlSidebar.Left = -280
        pnlHeader.Top = -100

        fadeStep = 0
        fadeTimer = New Timer With {.Interval = 15}
        AddHandler fadeTimer.Tick, AddressOf OnFadeTimerTick
        fadeTimer.Start()
    End Sub

    Private Sub OnFadeTimerTick(sender As Object, e As EventArgs)
        fadeStep += 1

        ' Fade in form
        If Me.Opacity < 1 Then
            Me.Opacity = Math.Min(1, Me.Opacity + 0.05)
        End If

        ' Slide in sidebar
        If pnlSidebar.Left < 0 Then
            pnlSidebar.Left = Math.Min(0, pnlSidebar.Left + 20)
        End If

        ' Slide down header
        If pnlHeader.Top < 0 Then
            pnlHeader.Top = Math.Min(0, pnlHeader.Top + 10)
        End If

        ' Complete animation
        If fadeStep > 20 Then
            Me.Opacity = 1
            pnlSidebar.Left = 0
            pnlHeader.Top = 0
            fadeTimer.Stop()
            RemoveHandler fadeTimer.Tick, AddressOf OnFadeTimerTick
            fadeTimer.Dispose()
            fadeTimer = Nothing

            ' Animate content panels (simple show; panels don't support Opacity)
            AnimateContentEntry()
        End If
    End Sub

    ''' <summary>
    ''' Animate content panels entrance (panels do not support Opacity — keep simple)
    ''' </summary>
    Private Sub AnimateContentEntry()
        If currentPanel IsNot Nothing Then
            currentPanel.Visible = True
            currentPanel.BringToFront()
        End If
    End Sub

    ''' <summary>
    ''' Initialize premium sidebar with custom nav buttons
    ''' </summary>
    Private Sub InitializePremiumSidebar()
        Try
            flowMenuCards.Controls.Clear()
            menuButtons.Clear()

            ' Create custom modern nav buttons
            Dim btnAudit As New ModernNavButton()
            btnAudit.SetContent("Audit Log", "View system activity", "📋", Color.FromArgb(139, 92, 246))
            AddHandler btnAudit.ButtonClicked, AddressOf MenuButton_Audit_Clicked
            flowMenuCards.Controls.Add(btnAudit)
            menuButtons.Add(btnAudit)

            Dim btnSales As New ModernNavButton()
            btnSales.SetContent("Sales Report", "Revenue analytics", "📊", Color.FromArgb(16, 185, 129))
            AddHandler btnSales.ButtonClicked, AddressOf MenuButton_Sales_Clicked
            flowMenuCards.Controls.Add(btnSales)
            menuButtons.Add(btnSales)

            Dim btnMenu As New ModernNavButton()
            btnMenu.SetContent("Manage Menu", "Food items & pricing", "🍽️", Color.FromArgb(251, 191, 36))
            AddHandler btnMenu.ButtonClicked, AddressOf MenuButton_Menu_Clicked
            flowMenuCards.Controls.Add(btnMenu)
            menuButtons.Add(btnMenu)

            Dim btnAccounts As New ModernNavButton()
            btnAccounts.SetContent("Manage Accounts", "User administration", "👥", Color.FromArgb(59, 130, 246))
            AddHandler btnAccounts.ButtonClicked, AddressOf MenuButton_Accounts_Clicked
            flowMenuCards.Controls.Add(btnAccounts)
            menuButtons.Add(btnAccounts)

        Catch ex As Exception
            MessageBox.Show("Error initializing sidebar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Set active navigation button with premium animation
    ''' </summary>
    Private Sub SetActiveNavButton(btn As ModernNavButton)
        ' Reset all buttons
        For Each menuBtn In menuButtons
            menuBtn.SetInactive()
        Next

        ' Activate selected
        If btn IsNot Nothing Then
            btn.SetActive()
            Dim originalSize = btn.Size
            btn.Size = New Size(originalSize.Width + 10, originalSize.Height + 5)

            Dim scaleTimer As New Timer With {.Interval = 10}
            Dim steps As Integer = 0

            AddHandler scaleTimer.Tick, Sub(s, args)
                                            steps += 1
                                            If steps >= 5 Then
                                                btn.Size = originalSize
                                                scaleTimer.Stop()
                                                scaleTimer.Dispose()
                                            End If
                                        End Sub
            scaleTimer.Start()
        End If

        currentActiveButton = btn
    End Sub

    ''' <summary>
    ''' Apply premium enterprise design system
    ''' </summary>
    Private Sub ApplyPremiumEnterpriseDesign()
        Try
            Me.BackColor = Color.FromArgb(245, 247, 250)
            ApplyGradientHeader()
            ApplySidebarDesign()
            StyleContentPanels()
            StylePremiumDataGrid()
            StylePremiumControls()
        Catch ex As Exception
            LogError("ApplyPremiumEnterpriseDesign", ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Apply gradient to header
    ''' </summary>
    Private Sub ApplyGradientHeader()
        pnlHeader.FillColor = Color.FromArgb(30, 30, 35)
        pnlHeader.ShadowDecoration.Enabled = True
        pnlHeader.ShadowDecoration.Depth = 20
        pnlHeader.ShadowDecoration.Color = Color.FromArgb(100, 0, 0, 0)
        pnlHeader.ShadowDecoration.Shadow = New Padding(0, 5, 0, 0)

        ' Title styling
        lblTitle.ForeColor = Color.White
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)

        lblSubtitle.ForeColor = Color.FromArgb(160, 165, 175)
        lblSubtitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular)

        ' Premium buttons
        StylePremiumButton(btnLogout, Color.FromArgb(239, 68, 68), "🚪 Logout")
        StylePremiumButton(btnInstructions, Color.FromArgb(251, 191, 36), "📖 Guide", Color.FromArgb(20, 20, 20))
        StylePremiumButton(btnHelp, Color.FromArgb(16, 185, 129), "❓ Help")
    End Sub

    ''' <summary>
    ''' Apply sidebar design with gradient
    ''' </summary>
    Private Sub ApplySidebarDesign()
        pnlSidebar.FillColor = Color.FromArgb(25, 28, 35)
        pnlSidebar.ShadowDecoration.Enabled = True
        pnlSidebar.ShadowDecoration.Depth = 25
        pnlSidebar.ShadowDecoration.Color = Color.FromArgb(120, 0, 0, 0)

        lblSidebarTitle.ForeColor = Color.FromArgb(251, 191, 36)
        lblSidebarTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
    End Sub

    ''' <summary>
    ''' Style content panels
    ''' </summary>
    Private Sub StyleContentPanels()
        ' Audit log panel
        pnlAuditLog.FillColor = Color.FromArgb(245, 247, 250)
        lblAuditTitle.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblAuditTitle.ForeColor = Color.FromArgb(20, 25, 35)

        ' Accounts panel
        pnlManageAccounts.FillColor = Color.FromArgb(245, 247, 250)
        lblAccountsTitle.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblAccountsTitle.ForeColor = Color.FromArgb(20, 25, 35)

        ' Filter panels with card style
        StyleFilterPanel(pnlAuditFilters)
        StyleFilterPanel(pnlAccountsToolbar)

        ' Content containers
        pnlAuditContent.FillColor = Color.White
        pnlAuditContent.Radius = 16
        pnlAuditContent.ShadowDepth = 15
        pnlAuditContent.ShadowColor = Color.FromArgb(50, 0, 0, 0)
    End Sub

    ''' <summary>
    ''' Style filter panel as premium card
    ''' </summary>
    Private Sub StyleFilterPanel(panel As Guna2Panel)
        panel.FillColor = Color.White
        panel.BorderRadius = 16
        panel.ShadowDecoration.Enabled = True
        panel.ShadowDecoration.Depth = 10
        panel.ShadowDecoration.Color = Color.FromArgb(40, 0, 0, 0)
        panel.ShadowDecoration.BorderRadius = 16
    End Sub

    ''' <summary>
    ''' Style premium button
    ''' </summary>
    Private Sub StylePremiumButton(btn As Guna2Button, fillColor As Color, text As String, Optional foreColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.White

        With btn
            .FillColor = fillColor
            .ForeColor = foreColor
            .BorderRadius = 14
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .Text = text
            .Animated = True
            .AnimatedGIF = True

            ' Gradient effect
            .UseTransparentBackground = True

            ' Shadow
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 12
            .ShadowDecoration.Color = Color.FromArgb(80, fillColor)
            .ShadowDecoration.BorderRadius = 14

            ' Hover
            .HoverState.FillColor = AdjustBrightness(fillColor, -15)
            ' Do not attempt to set HoverState.ShadowDecoration.* (not supported on Guna2 button state)

            ' Press
            .PressedColor = AdjustBrightness(fillColor, -30)
            .PressedDepth = 5
        End With
    End Sub

    ''' <summary>
    ''' Style premium DataGrid
    ''' </summary>
    Private Sub StylePremiumDataGrid()
        With dgvAuditLogs
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .GridColor = Color.FromArgb(240, 242, 245)
            .RowTemplate.Height = 60
            .ColumnHeadersHeight = 60

            ' Premium header
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .EnableHeadersVisualStyles = False

            Dim headerStyle As New DataGridViewCellStyle()
            headerStyle.BackColor = Color.FromArgb(251, 191, 36)
            headerStyle.ForeColor = Color.FromArgb(20, 20, 20)
            headerStyle.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
            headerStyle.Padding = New Padding(15, 10, 15, 10)
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            headerStyle.SelectionBackColor = Color.FromArgb(251, 191, 36)
            .ColumnHeadersDefaultCellStyle = headerStyle

            ' Premium cells
            Dim cellStyle As New DataGridViewCellStyle()
            cellStyle.BackColor = Color.White
            cellStyle.ForeColor = Color.FromArgb(55, 65, 81)
            cellStyle.Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)
            cellStyle.Padding = New Padding(15, 12, 15, 12)
            cellStyle.SelectionBackColor = Color.FromArgb(254, 243, 199)
            cellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20)
            .DefaultCellStyle = cellStyle

            ' Alternating rows
            Dim altStyle As New DataGridViewCellStyle()
            altStyle.BackColor = Color.FromArgb(249, 250, 251)
            .AlternatingRowsDefaultCellStyle = altStyle

            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    ''' <summary>
    ''' Style premium form controls
    ''' </summary>
    Private Sub StylePremiumControls()
        ' Textboxes
        StylePremiumTextBox(txtUsernameFilter)
        StylePremiumTextBox(txtSearchAccounts)

        ' Buttons
        StylePremiumActionButton(btnFilterAuditLogs, Color.FromArgb(251, 191, 36), "🔍 Filter", Color.FromArgb(20, 20, 20))
        StylePremiumActionButton(btnExportAuditLogs, Color.FromArgb(16, 185, 129), "📊 Export")
        StylePremiumActionButton(btnCreateAccount, Color.FromArgb(16, 185, 129), "➕ Create")
        StylePremiumActionButton(btnViewArchive, Color.FromArgb(245, 158, 11), "📦 Archive")

        ' Date pickers
        StylePremiumDatePicker(dtpAuditFrom)
        StylePremiumDatePicker(dtpAuditTo)

        ' Checkbox
        With chkDateFilter
            .CheckedState.FillColor = Color.FromArgb(251, 191, 36)
            .CheckedState.BorderColor = Color.FromArgb(251, 191, 36)
            .CheckedState.BorderRadius = 4
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)
            .ForeColor = Color.FromArgb(55, 65, 81)
        End With
    End Sub

    ''' <summary>
    ''' Style premium textbox
    ''' </summary>
    Private Sub StylePremiumTextBox(txt As Guna2TextBox)
        With txt
            .BorderRadius = 14
            .BorderThickness = 2
            .BorderColor = Color.FromArgb(229, 231, 235)
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)
            .ForeColor = Color.FromArgb(31, 41, 55)
            .PlaceholderForeColor = Color.FromArgb(156, 163, 175)
            .Height = 50
            .TextOffset = New Point(5, 0)

            ' Focus state
            .FocusedState.BorderColor = Color.FromArgb(251, 191, 36)
            ' FocusedState.BorderThickness is not supported on Guna2TextBox state; keep control-level BorderThickness.
            '.FocusedState.BorderThickness = 3

            ' Hover
            .HoverState.BorderColor = Color.FromArgb(209, 213, 219)

            ' Shadow
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 5
            .ShadowDecoration.Color = Color.FromArgb(20, 0, 0, 0)
            .ShadowDecoration.BorderRadius = 14
        End With
    End Sub

    ''' <summary>
    ''' Style premium action button
    ''' </summary>
    Private Sub StylePremiumActionButton(btn As Guna2Button, fillColor As Color, text As String, Optional foreColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.White

        With btn
            .FillColor = fillColor
            .ForeColor = foreColor
            .BorderRadius = 14
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .Text = text
            .Height = 50
            .Animated = True

            ' Shadow
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 10
            .ShadowDecoration.Color = Color.FromArgb(60, fillColor)
            .ShadowDecoration.BorderRadius = 14

            ' Hover
            .HoverState.FillColor = AdjustBrightness(fillColor, -15)
            ' Do not attempt to set HoverState.ShadowDecoration.* (not supported on Guna2 button state)

            ' Press
            .PressedColor = AdjustBrightness(fillColor, -30)
        End With
    End Sub

    ''' <summary>
    ''' Style premium date picker
    ''' </summary>
    Private Sub StylePremiumDatePicker(dtp As Guna2DateTimePicker)
        With dtp
            .BorderRadius = 14
            .BorderThickness = 2
            .BorderColor = Color.FromArgb(229, 231, 235)
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)
            .FillColor = Color.White
            .ForeColor = Color.FromArgb(31, 41, 55)
            .Height = 50
            .Checked = True

            .FocusedColor = Color.FromArgb(251, 191, 36)
            .HoverState.BorderColor = Color.FromArgb(209, 213, 219)
        End With
    End Sub

    ''' <summary>
    ''' Adjust color brightness
    ''' </summary>
    Private Function AdjustBrightness(color As Color, amount As Integer) As Color
        Dim r As Integer = Math.Max(0, Math.Min(255, color.R + amount))
        Dim g As Integer = Math.Max(0, Math.Min(255, color.G + amount))
        Dim b As Integer = Math.Max(0, Math.Min(255, color.B + amount))
        Return Color.FromArgb(color.A, r, g, b)
    End Function

    ''' <summary>
    ''' Switch panels with smooth transition
    ''' </summary>
    Private Sub SwitchPanel(targetPanel As Panel)
        If currentPanel Is targetPanel Then Return

        If currentPanel IsNot Nothing Then
            currentPanel.Visible = False
        End If

        targetPanel.Visible = True
        targetPanel.BringToFront()
        currentPanel = targetPanel
    End Sub

    ' ===== MENU BUTTON HANDLERS =====
    Private Sub MenuButton_Audit_Clicked(sender As Object, e As EventArgs)
        SetActiveNavButton(TryCast(sender, ModernNavButton))
        SwitchPanel(pnlAuditLog)
        LoadAuditLogs()
    End Sub

    Private Sub MenuButton_Sales_Clicked(sender As Object, e As EventArgs)
        SetActiveNavButton(TryCast(sender, ModernNavButton))
        Try
            Dim salesReportForm As New SalesReport()
            salesReportForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MenuButton_Menu_Clicked(sender As Object, e As EventArgs)
        SetActiveNavButton(TryCast(sender, ModernNavButton))
        Try
            Dim menuForm As New Manage_menu()
            menuForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening menu management: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MenuButton_Accounts_Clicked(sender As Object, e As EventArgs)
        SetActiveNavButton(TryCast(sender, ModernNavButton))
        SwitchPanel(pnlManageAccounts)
        LoadUserAccounts()
    End Sub

    ' ===== ORIGINAL BUSINESS LOGIC (PRESERVED) =====
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

    Private Sub FilterAuditLogs()
        Dim dateFrom As DateTime? = Nothing
        Dim dateTo As DateTime? = Nothing
        If chkDateFilter.Checked Then
            dateFrom = dtpAuditFrom.Value.Date
            dateTo = dtpAuditTo.Value.Date
        End If
        LoadAuditLogs(txtUsernameFilter.Text.Trim(), dateFrom, dateTo)
    End Sub

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

    Private Sub LoadUserAccounts(Optional searchFilter As String = "")
        Try
            pnlAccountCards.Controls.Clear()
            Dim accounts = DatabaseHandler.GetAllUsers(searchFilter)
            Dim yPos As Integer = 10
            For Each account In accounts
                Dim card As New PremiumAccountCard()
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
                                                     Dim result = MessageBox.Show($"Permanently delete user '{a.Username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
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
                                                      Dim result = MessageBox.Show($"Archive user '{a.Username}'?", "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                      If result = DialogResult.Yes Then
                                                          If DatabaseHandler.ArchiveUser(a.ID) Then
                                                              MessageBox.Show("Account archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                              ' Refresh list immediately after successful archive
                                                              LoadUserAccounts(txtSearchAccounts.Text.Trim())
                                                          Else
                                                              MessageBox.Show("Failed to archive account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                          End If
                                                      End If
                                                  End Sub
                card.Location = New Point(10, yPos)
                pnlAccountCards.Controls.Add(card)
                yPos += card.Height + 15
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

    Private Sub LogError(method As String, message As String)
        Try
            Dim logFile As String = Path.Combine(PathManager.GetLogsPath(), "error.txt")
            Using writer As New StreamWriter(logFile, True)
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {method}: {message}")
            End Using
        Catch
        End Try
    End Sub

    ' ===== EVENT HANDLERS =====
    Private Sub btnFilterAuditLogs_Click(sender As Object, e As EventArgs) Handles btnFilterAuditLogs.Click
        FilterAuditLogs()
    End Sub

    Private Sub btnExportAuditLogs_Click(sender As Object, e As EventArgs) Handles btnExportAuditLogs.Click
        ExportAuditLogsToCsv()
    End Sub

    Private Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        Dim createForm As New CreateEditAccountForm
        If createForm.ShowDialog = DialogResult.OK Then
            LoadUserAccounts(txtSearchAccounts.Text.Trim)
        End If
    End Sub

    Private Sub txtSearchAccounts_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAccounts.TextChanged
        LoadUserAccounts(txtSearchAccounts.Text.Trim())
    End Sub

    Private Sub btnViewArchive_Click(sender As Object, e As EventArgs) Handles btnViewArchive.Click
        Try
            Dim archiveForm As New ArchiveStorage()
            ' Subscribe to archive changes so Manage Accounts refreshes automatically when an item is restored/deleted
            AddHandler archiveForm.AccountsChanged, AddressOf OnArchiveAccountsChanged
            archiveForm.ShowDialog(Me)
            ' Unsubscribe (defensive)
            RemoveHandler archiveForm.AccountsChanged, AddressOf OnArchiveAccountsChanged
        Catch ex As Exception
            MessageBox.Show("Error opening archive storage: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Designer-placed Refresh button handler
    Private Sub btnRefreshAccounts_Click(sender As Object, e As EventArgs) Handles btnRefreshAccounts.Click
        LoadUserAccounts(txtSearchAccounts.Text.Trim())
    End Sub



    ' Handler called when ArchiveStorage raises AccountsChanged
    Private Sub OnArchiveAccountsChanged(sender As Object, e As EventArgs)
        ' Only reload if Manage Accounts panel is visible
        If pnlManageAccounts.Visible Then
            LoadUserAccounts(txtSearchAccounts.Text.Trim())
        End If
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