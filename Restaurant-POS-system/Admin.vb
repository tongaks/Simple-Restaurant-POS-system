Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Guna.UI2.WinForms

Public Class Admin
    Inherits Form

    ' ===== FIELDS =====
    Private currentUserRole As String = "Admin"
    Private navButtons As AdminNavButtons
    Private currentActiveButton As ModernNavButton = Nothing
    Private menuButtons As New List(Of ModernNavButton)
    Private currentPanel As Panel = Nothing
    Private fadeTimer As Timer
    Private fadeStep As Integer

    ' Runtime host panels and cached embedded modules
    Private pnlSalesHost As Guna2Panel = Nothing
    Private pnlManageMenuHost As Guna2Panel = Nothing
    Private salesReportInstance As SalesReport = Nothing       ' SalesReport is a UserControl now
    Private manageMenuInstance As Manage_menu = Nothing        ' Manage_menu is a UserControl

    ' ===== PATH MANAGER =====
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

    ' ===== FORM LIFECYCLE =====
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize navigation helper (uses existing controls from Designer)
        navButtons = New AdminNavButtons(Me, btnLogout, Nothing, btnHelp, btnInstructions)

        Me.WindowState = FormWindowState.Maximized

        ' Apply style and prepare sidebar
        ApplyPremiumEnterpriseDesign()
        InitializePremiumSidebar()

        ' Create runtime hosts for embedded modules
        CreateModuleHosts()

        ' Default view
        LoadAuditLogs()
        pnlManageAccounts.Visible = False
        pnlAuditLog.Visible = True
        currentPanel = pnlAuditLog

        ' Ensure DB artifacts exist
        DatabaseHandler.EnsureArchivedUsersTableExists()

        ' Set initial active nav
        If menuButtons.Count > 0 Then SetActiveNavButton(menuButtons(0))

        ' Entrance animation
        AnimateEntranceEffect()
    End Sub

    ' ===== HOST PANELS CREATION =====
    Private Sub CreateModuleHosts()
        Try
            ' SalesReport host (Form hosting)
            pnlSalesHost = New Guna2Panel() With {
                .Name = "pnlSalesHost",
                .Dock = DockStyle.Fill,
                .FillColor = If(pnlAuditLog IsNot Nothing, pnlAuditLog.FillColor, Color.White),
                .Visible = False,
                .Padding = New Padding(25, 0, 25, 25),
                .AutoScroll = True
            }
            Me.Controls.Add(pnlSalesHost)
            Try
                Dim idx = Me.Controls.GetChildIndex(pnlAuditLog)
                If idx >= 0 Then Me.Controls.SetChildIndex(pnlSalesHost, idx)
            Catch
            End Try
            AddHandler pnlSalesHost.Resize, Sub(s, ev)
                                                Try
                                                    If pnlSalesHost.Controls.Count > 0 Then pnlSalesHost.Controls(0).Size = pnlSalesHost.ClientSize
                                                Catch
                                                End Try
                                            End Sub

            ' Manage_menu host (UserControl hosting)
            pnlManageMenuHost = New Guna2Panel() With {
                .Name = "pnlManageMenuHost",
                .Dock = DockStyle.Fill,
                .FillColor = If(pnlManageAccounts IsNot Nothing, pnlManageAccounts.FillColor, Color.White),
                .Visible = False,
                .Padding = New Padding(25, 0, 25, 25),
                .AutoScroll = True
            }
            Me.Controls.Add(pnlManageMenuHost)
            Try
                Dim idx = Me.Controls.GetChildIndex(pnlAuditLog)
                If idx >= 0 Then Me.Controls.SetChildIndex(pnlManageMenuHost, idx)
            Catch
            End Try
            AddHandler pnlManageMenuHost.Resize, Sub(s, ev)
                                                     Try
                                                         If pnlManageMenuHost.Controls.Count > 0 Then pnlManageMenuHost.Controls(0).Size = pnlManageMenuHost.ClientSize
                                                     Catch
                                                     End Try
                                                 End Sub
        Catch ex As Exception
            LogError("CreateModuleHosts", ex.Message)
        End Try
    End Sub

    ' ===== HOSTING HELPERS =====
    Private Sub HostFormInPanel(frm As Form, hostPanel As Panel)
        If frm Is Nothing OrElse hostPanel Is Nothing Then Return
        Try
            If frm.TopLevel Then frm.TopLevel = False

            If hostPanel.Controls.Contains(frm) Then
                frm.BringToFront()
                frm.Size = hostPanel.ClientSize
                Return
            End If

            frm.FormBorderStyle = FormBorderStyle.None
            frm.AutoScaleMode = AutoScaleMode.Inherit
            frm.Dock = DockStyle.Fill
            frm.Margin = New Padding(0)
            frm.Padding = New Padding(0)

            hostPanel.Controls.Add(frm)
            frm.Show()
            frm.Refresh()
            frm.Size = hostPanel.ClientSize
        Catch ex As Exception
            LogError("HostFormInPanel", ex.Message)
            MessageBox.Show("Error hosting module: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HostControlInPanel(ctrl As Control, hostPanel As Panel)
        If ctrl Is Nothing OrElse hostPanel Is Nothing Then Return
        Try
            If hostPanel.Controls.Contains(ctrl) Then
                ctrl.BringToFront()
                ctrl.Size = hostPanel.ClientSize
                Return
            End If

            ctrl.Dock = DockStyle.Fill
            ctrl.Margin = New Padding(0)
            ctrl.Padding = New Padding(0)

            hostPanel.Controls.Add(ctrl)
            ctrl.BringToFront()
            ctrl.Refresh()
            ctrl.Size = hostPanel.ClientSize
        Catch ex As Exception
            LogError("HostControlInPanel", ex.Message)
            MessageBox.Show("Error hosting control: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== NAVIGATION HELPERS FOR EMBEDDED MODULES =====
    Public Sub ShowAuditView()
        Try
            If menuButtons.Count > 0 Then SetActiveNavButton(menuButtons(0))
            SwitchPanel(pnlAuditLog)
            LoadAuditLogs()
        Catch ex As Exception
            LogError("ShowAuditView", ex.Message)
        End Try
    End Sub

    Public Sub ShowManageMenuView()
        Try
            If menuButtons.Count > 2 Then SetActiveNavButton(menuButtons(2))
            If pnlManageMenuHost IsNot Nothing Then SwitchPanel(pnlManageMenuHost)
        Catch ex As Exception
            LogError("ShowManageMenuView", ex.Message)
        End Try
    End Sub

    ' ===== ANIMATIONS =====
    Private Sub AnimateEntranceEffect()
        ' Keep simple: slide sidebar and header
        pnlSidebar.Left = -280
        pnlHeader.Top = -100

        fadeStep = 0
        fadeTimer = New Timer With {.Interval = 15}
        AddHandler fadeTimer.Tick, AddressOf OnFadeTimerTick
        fadeTimer.Start()
    End Sub

    Private Sub OnFadeTimerTick(sender As Object, e As EventArgs)
        fadeStep += 1

        If pnlSidebar.Left < 0 Then pnlSidebar.Left = Math.Min(0, pnlSidebar.Left + 20)
        If pnlHeader.Top < 0 Then pnlHeader.Top = Math.Min(0, pnlHeader.Top + 10)

        If fadeStep > 20 Then
            pnlSidebar.Left = 0
            pnlHeader.Top = 0
            fadeTimer.Stop()
            RemoveHandler fadeTimer.Tick, AddressOf OnFadeTimerTick
            fadeTimer.Dispose()
            fadeTimer = Nothing
            AnimateContentEntry()
        End If
    End Sub

    Private Sub AnimateContentEntry()
        If currentPanel IsNot Nothing Then
            currentPanel.Visible = True
            currentPanel.BringToFront()
        End If
    End Sub

    ' ===== SIDEBAR INITIALIZATION =====
    Private Sub InitializePremiumSidebar()
        Try
            flowMenuCards.Controls.Clear()
            menuButtons.Clear()

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

    Private Sub SetActiveNavButton(btn As ModernNavButton)
        For Each menuBtn In menuButtons
            menuBtn.SetInactive()
        Next

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

    ' ===== STYLING HELPERS (KEEP YOUR ORIGINALS) =====
    ' Please keep your existing style methods (I include them here to ensure they are declared).
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

    Private Sub ApplyGradientHeader()
        pnlHeader.FillColor = Color.FromArgb(30, 30, 35)
        pnlHeader.ShadowDecoration.Enabled = True
        pnlHeader.ShadowDecoration.Depth = 20
        pnlHeader.ShadowDecoration.Color = Color.FromArgb(100, 0, 0, 0)
        pnlHeader.ShadowDecoration.Shadow = New Padding(0, 5, 0, 0)

        lblTitle.ForeColor = Color.White
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)

        lblSubtitle.ForeColor = Color.FromArgb(160, 165, 175)
        lblSubtitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular)

        StylePremiumButton(btnLogout, Color.FromArgb(239, 68, 68), "🚪 Logout", Nothing)
        StylePremiumButton(btnInstructions, Color.FromArgb(251, 191, 36), "📖 Guide", Color.FromArgb(20, 20, 20))
        StylePremiumButton(btnHelp, Color.FromArgb(16, 185, 129), "❓ Help", Nothing)
    End Sub

    Private Sub ApplySidebarDesign()
        pnlSidebar.FillColor = Color.FromArgb(25, 28, 35)
        pnlSidebar.ShadowDecoration.Enabled = True
        pnlSidebar.ShadowDecoration.Depth = 25
        pnlSidebar.ShadowDecoration.Color = Color.FromArgb(120, 0, 0, 0)

        lblSidebarTitle.ForeColor = Color.FromArgb(251, 191, 36)
        lblSidebarTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
    End Sub

    Private Sub StyleContentPanels()
        pnlAuditLog.FillColor = Color.FromArgb(245, 247, 250)
        lblAuditTitle.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblAuditTitle.ForeColor = Color.FromArgb(20, 25, 35)

        pnlManageAccounts.FillColor = Color.FromArgb(245, 247, 250)
        lblAccountsTitle.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblAccountsTitle.ForeColor = Color.FromArgb(20, 25, 35)

        StyleFilterPanel(pnlAuditFilters)
        StyleFilterPanel(pnlAccountsToolbar)

        pnlAuditContent.FillColor = Color.White
        pnlAuditContent.Radius = 16
        pnlAuditContent.ShadowDepth = 15
        pnlAuditContent.ShadowColor = Color.FromArgb(50, 0, 0, 0)
    End Sub

    Private Sub StyleFilterPanel(panel As Guna2Panel)
        panel.FillColor = Color.White
        panel.BorderRadius = 16
        panel.ShadowDecoration.Enabled = True
        panel.ShadowDecoration.Depth = 10
        panel.ShadowDecoration.Color = Color.FromArgb(40, 0, 0, 0)
        panel.ShadowDecoration.BorderRadius = 16
    End Sub

    Private Sub StylePremiumButton(btn As Guna2Button, fillColor As Color, text As String, Optional foreColor As Color? = Nothing)
        Dim actualFore As Color = If(foreColor.HasValue, foreColor.Value, Color.White)
        With btn
            .FillColor = fillColor
            .ForeColor = actualFore
            .BorderRadius = 14
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .Text = text
            .Animated = True
            .AnimatedGIF = True
            .UseTransparentBackground = True
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 12
            .ShadowDecoration.Color = Color.FromArgb(80, fillColor)
            .ShadowDecoration.BorderRadius = 14
            .HoverState.FillColor = AdjustBrightness(fillColor, -15)
            .PressedColor = AdjustBrightness(fillColor, -30)
            .PressedDepth = 5
        End With
    End Sub

    Private Sub StylePremiumDataGrid()
        With dgvAuditLogs
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .GridColor = Color.FromArgb(240, 242, 245)
            .RowTemplate.Height = 60
            .ColumnHeadersHeight = 60
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

            Dim cellStyle As New DataGridViewCellStyle()
            cellStyle.BackColor = Color.White
            cellStyle.ForeColor = Color.FromArgb(55, 65, 81)
            cellStyle.Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)
            cellStyle.Padding = New Padding(15, 12, 15, 12)
            cellStyle.SelectionBackColor = Color.FromArgb(254, 243, 199)
            cellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20)
            .DefaultCellStyle = cellStyle

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

    Private Sub StylePremiumControls()
        StylePremiumTextBox(txtUsernameFilter)
        StylePremiumTextBox(txtSearchAccounts)
        StylePremiumActionButton(btnFilterAuditLogs, Color.FromArgb(251, 191, 36), "🔍 Filter", Color.FromArgb(20, 20, 20))
        StylePremiumActionButton(btnExportAuditLogs, Color.FromArgb(16, 185, 129), "📊 Export")
        StylePremiumActionButton(btnCreateAccount, Color.FromArgb(16, 185, 129), "➕ Create")
        StylePremiumActionButton(btnViewArchive, Color.FromArgb(245, 158, 11), "📦 Archive")
        StylePremiumDatePicker(dtpAuditFrom)
        StylePremiumDatePicker(dtpAuditTo)
        With chkDateFilter
            .CheckedState.FillColor = Color.FromArgb(251, 191, 36)
            .CheckedState.BorderColor = Color.FromArgb(251, 191, 36)
            .CheckedState.BorderRadius = 4
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Regular)
            .ForeColor = Color.FromArgb(55, 65, 81)
        End With
    End Sub

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
            .FocusedState.BorderColor = Color.FromArgb(251, 191, 36)
            .HoverState.BorderColor = Color.FromArgb(209, 213, 219)
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 5
            .ShadowDecoration.Color = Color.FromArgb(20, 0, 0, 0)
            .ShadowDecoration.BorderRadius = 14
        End With
    End Sub

    Private Sub StylePremiumActionButton(btn As Guna2Button, fillColor As Color, text As String, Optional foreColor As Color? = Nothing)
        Dim actualFore As Color = If(foreColor.HasValue, foreColor.Value, Color.White)
        With btn
            .FillColor = fillColor
            .ForeColor = actualFore
            .BorderRadius = 14
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .Text = text
            .Height = 50
            .Animated = True
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 10
            .ShadowDecoration.Color = Color.FromArgb(60, fillColor)
            .ShadowDecoration.BorderRadius = 14
            .HoverState.FillColor = AdjustBrightness(fillColor, -15)
            .PressedColor = AdjustBrightness(fillColor, -30)
        End With
    End Sub

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

    Private Function AdjustBrightness(color As Color, amount As Integer) As Color
        Dim r As Integer = Math.Max(0, Math.Min(255, color.R + amount))
        Dim g As Integer = Math.Max(0, Math.Min(255, color.G + amount))
        Dim b As Integer = Math.Max(0, Math.Min(255, color.B + amount))
        Return Color.FromArgb(color.A, r, g, b)
    End Function

    ' ===== PANEL SWITCH =====
    Private Sub SwitchPanel(targetPanel As Panel)
        If targetPanel Is Nothing Then Return
        If currentPanel Is targetPanel Then Return

        If currentPanel IsNot Nothing Then currentPanel.Visible = False

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
            If salesReportInstance Is Nothing OrElse salesReportInstance.IsDisposed Then salesReportInstance = New SalesReport()
            ' SalesReport is a UserControl now; host as a control
            HostControlInPanel(salesReportInstance, pnlSalesHost)
            SwitchPanel(pnlSalesHost)
        Catch ex As Exception
            MessageBox.Show("Error loading sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MenuButton_Menu_Clicked(sender As Object, e As EventArgs)
        SetActiveNavButton(TryCast(sender, ModernNavButton))
        Try
            If manageMenuInstance Is Nothing OrElse manageMenuInstance.IsDisposed Then manageMenuInstance = New Manage_menu()
            HostControlInPanel(manageMenuInstance, pnlManageMenuHost)
            SwitchPanel(pnlManageMenuHost)
        Catch ex As Exception
            MessageBox.Show("Error loading menu management: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MenuButton_Accounts_Clicked(sender As Object, e As EventArgs)
        SetActiveNavButton(TryCast(sender, ModernNavButton))
        SwitchPanel(pnlManageAccounts)
        LoadUserAccounts()
    End Sub

    ' ===== DATA & EXPORT =====
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

    ' ===== ACCOUNTS PANEL LOADING =====
    Private Sub LoadUserAccounts(Optional searchFilter As String = "")
        Try
            pnlAccountCards.Controls.Clear()
            Dim accounts = DatabaseHandler.GetAllUsers(searchFilter)
            Dim yPos As Integer = 10
            For Each account In accounts
                Dim card As New PremiumAccountCard()
                card.Width = Math.Max(100, pnlAccountCards.ClientSize.Width - 40)
                card.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                card.SetAccount(account)
                AddHandler card.EditRequested, Sub(a)
                                                   Dim editForm As New CreateEditAccountForm(a)
                                                   If editForm.ShowDialog() = DialogResult.OK Then LoadUserAccounts(txtSearchAccounts.Text.Trim())
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
                Dim lblNoData As New Label() With {
                    .Text = "No accounts found.",
                    .Font = New Font("Segoe UI", 12, FontStyle.Italic),
                    .ForeColor = Color.Gray,
                    .Location = New Point(10, 10),
                    .AutoSize = True
                }
                pnlAccountCards.Controls.Add(lblNoData)
            End If
        Catch ex As Exception
            LogError("LoadUserAccounts", ex.Message)
            MessageBox.Show("Error loading user accounts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== LOGGING =====
    Private Sub LogError(method As String, message As String)
        Try
            Dim logFile As String = Path.Combine(PathManager.GetLogsPath(), "error.txt")
            Using writer As New StreamWriter(logFile, True)
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {method}: {message}")
            End Using
        Catch
        End Try
    End Sub

    ' ===== EVENT HANDLERS (designer) =====
    Private Sub btnFilterAuditLogs_Click(sender As Object, e As EventArgs) Handles btnFilterAuditLogs.Click
        Dim dateFrom As DateTime? = Nothing
        Dim dateTo As DateTime? = Nothing
        If chkDateFilter.Checked Then
            dateFrom = dtpAuditFrom.Value.Date
            dateTo = dtpAuditTo.Value.Date
        End If
        LoadAuditLogs(txtUsernameFilter.Text.Trim(), dateFrom, dateTo)
    End Sub

    Private Sub btnExportAuditLogs_Click(sender As Object, e As EventArgs) Handles btnExportAuditLogs.Click
        Dim fileName As String = $"AuditLogs_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
        Dim filePath As String = Path.Combine(PathManager.GetExportsPath(), fileName)
        ExportDataGridToCsv(dgvAuditLogs, filePath)
        MessageBox.Show($"Audit logs exported to: {filePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        Dim createForm As New CreateEditAccountForm
        If createForm.ShowDialog() = DialogResult.OK Then LoadUserAccounts(txtSearchAccounts.Text.Trim())
    End Sub

    Private Sub txtSearchAccounts_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAccounts.TextChanged
        LoadUserAccounts(txtSearchAccounts.Text.Trim())
    End Sub

    Private Sub btnViewArchive_Click(sender As Object, e As EventArgs) Handles btnViewArchive.Click
        Try
            Dim archiveForm As New ArchiveStorage()
            AddHandler archiveForm.AccountsChanged, AddressOf OnArchiveAccountsChanged
            archiveForm.ShowDialog(Me)
            RemoveHandler archiveForm.AccountsChanged, AddressOf OnArchiveAccountsChanged
        Catch ex As Exception
            MessageBox.Show("Error opening archive storage: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshAccounts_Click(sender As Object, e As EventArgs) Handles btnRefreshAccounts.Click
        LoadUserAccounts(txtSearchAccounts.Text.Trim())
    End Sub

    Private Sub OnArchiveAccountsChanged(sender As Object, e As EventArgs)
        If pnlManageAccounts.Visible Then LoadUserAccounts(txtSearchAccounts.Text.Trim())
    End Sub

    Private Sub chkDateFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateFilter.CheckedChanged
        dtpAuditFrom.Enabled = chkDateFilter.Checked
        dtpAuditTo.Enabled = chkDateFilter.Checked
    End Sub

    ' ===== CLEANUP =====
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        Try
            If salesReportInstance IsNot Nothing AndAlso Not salesReportInstance.IsDisposed Then
                ' SalesReport is a UserControl now — dispose it instead of calling Close()
                salesReportInstance.Dispose()
                salesReportInstance = Nothing
            End If
        Catch
        End Try
        Try
            If manageMenuInstance IsNot Nothing AndAlso Not manageMenuInstance.IsDisposed Then
                manageMenuInstance.Dispose()
                manageMenuInstance = Nothing
            End If
        Catch
        End Try
    End Sub
End Class