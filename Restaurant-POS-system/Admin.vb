' Admin Dashboard Form - OrderUp! System
' Features: Audit Log, Sales Report, Menu Management, User Management
' Database: MySQL/MariaDB

Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Admin
    Private currentUserRole As String = "Admin"
    Private navButtons As AdminNavButtons
    Private currentActiveButton As Button = Nothing

    ' Simple PathManager helper class
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
    ''' Form load - initialize dashboard and load audit logs
    ''' </summary>
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize navigation buttons with the buttons from Designer
        navButtons = New AdminNavButtons(Me, btnLogout, Nothing, btnHelp, btnInstructions)

        Me.WindowState = FormWindowState.Maximized
        LoadAuditLogs()
        pnlSalesReport.Visible = False
        pnlManageAccounts.Visible = False
        dtpFrom.Value = DateTime.Now.AddDays(-30)
        dtpTo.Value = DateTime.Now

        ' Initialize archived_users table if not exists
        DatabaseHandler.EnsureArchivedUsersTableExists()

        ' Set initial active button
        SetActiveButton(btnAuditLog)
    End Sub

    ''' <summary>
    ''' Highlight the active dashboard button
    ''' </summary>
    Private Sub SetActiveButton(btn As Button)
        ' Reset previous active button
        If currentActiveButton IsNot Nothing Then
            currentActiveButton.BackColor = GetOriginalButtonColor(currentActiveButton)
            currentActiveButton.FlatAppearance.BorderSize = 1
            currentActiveButton.FlatAppearance.BorderColor = Color.Black
        End If

        ' Set new active button
        currentActiveButton = btn
        currentActiveButton.BackColor = Color.FromArgb(100, 180, 100) ' Darker shade
        currentActiveButton.FlatAppearance.BorderSize = 3
        currentActiveButton.FlatAppearance.BorderColor = Color.DarkGreen
    End Sub

    ''' <summary>
    ''' Get original button color based on button name
    ''' </summary>
    Private Function GetOriginalButtonColor(btn As Button) As Color
        If btn Is btnAuditLog Then Return Color.LightCoral
        If btn Is btnSalesReport Then Return Color.LightGreen
        If btn Is btnManageAccounts Then Return Color.LightBlue
        If btn Is btnManageMenu Then Return Color.LightSalmon
        Return Color.LightGray
    End Function

    ''' <summary>
    ''' Load audit logs with optional filters
    ''' </summary>
    Private Sub LoadAuditLogs(Optional usernameFilter As String = "", Optional dateFrom As DateTime? = Nothing, Optional dateTo As DateTime? = Nothing)
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()
                Dim query As String = "SELECT log_time, username, role, action FROM activity_logs WHERE 1=1"

                Dim cmd As New MySqlCommand()

                ' Add filters
                If Not String.IsNullOrEmpty(usernameFilter) Then
                    query += " AND username LIKE @username"
                    cmd.Parameters.AddWithValue("@username", "%" & usernameFilter & "%")
                End If

                If dateFrom.HasValue Then
                    query += " AND log_time >= @dateFrom"
                    cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value.Date)
                End If

                If dateTo.HasValue Then
                    query += " AND log_time <= @dateTo"
                    cmd.Parameters.AddWithValue("@dateTo", dateTo.Value.Date.AddDays(1).AddSeconds(-1))
                End If

                query += " ORDER BY log_time DESC LIMIT 200"

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
    ''' Filter audit logs based on user input
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
    ''' Generate sales report for specified date range with charts
    ''' </summary>
    Private Sub GenerateSalesReport()
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                ' Get sales summary
                Dim summaryQuery As String = "SELECT COUNT(*) AS OrderCount, SUM(total_amount) AS TotalSales FROM orders WHERE order_date >= @dateFrom AND order_date <= @dateTo"
                Using cmd As New MySqlCommand(summaryQuery, connection)
                    cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblTotalSales.Text = "₱" & If(IsDBNull(reader("TotalSales")), 0, reader("TotalSales")).ToString("N2")
                            lblOrderCount.Text = If(IsDBNull(reader("OrderCount")), 0, reader("OrderCount")).ToString()
                        End If
                    End Using
                End Using

                ' Get detailed transactions
                Dim detailQuery As String = "SELECT * FROM orders WHERE order_date >= @dateFrom AND order_date <= @dateTo ORDER BY order_date DESC"
                Using cmd As New MySqlCommand(detailQuery, connection)
                    cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    dgvSalesReport.DataSource = dt
                    dgvSalesReport.AutoResizeColumns()
                End Using

                ' Generate charts
                GenerateSalesCharts(connection)

            End Using
        Catch ex As Exception
            LogError("GenerateSalesReport", ex.Message)
            MessageBox.Show("Error generating sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generate sales charts - daily sales and top items
    ''' </summary>
    Private Sub GenerateSalesCharts(connection As MySqlConnection)
        Try
            ' Clear existing charts
            chartDailySales.Series.Clear()
            chartTopItems.Series.Clear()

            ' Daily Sales Chart
            Dim dailySalesQuery As String = "SELECT DATE(order_date) as OrderDate, SUM(total_amount) as DailySales FROM orders WHERE order_date >= @dateFrom AND order_date <= @dateTo GROUP BY DATE(order_date) ORDER BY OrderDate"
            Using cmd As New MySqlCommand(dailySalesQuery, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Dim series As New Series("Daily Sales")
                series.ChartType = SeriesChartType.Column
                series.Color = Color.SteelBlue

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim orderDate As Date = Convert.ToDateTime(reader("OrderDate"))
                        Dim sales As Decimal = If(IsDBNull(reader("DailySales")), 0, Convert.ToDecimal(reader("DailySales")))
                        series.Points.AddXY(orderDate.ToString("MM/dd"), sales)
                    End While
                End Using

                chartDailySales.Series.Add(series)
                chartDailySales.ChartAreas(0).AxisX.Title = "Date"
                chartDailySales.ChartAreas(0).AxisY.Title = "Sales (₱)"
                chartDailySales.Titles.Clear()
                chartDailySales.Titles.Add("Daily Sales Trend")
            End Using

            ' Top 5 Items Chart
            Dim topItemsQuery As String = "SELECT item_name, SUM(quantity) as TotalQty FROM order_items oi JOIN orders o ON oi.order_id = o.id WHERE o.order_date >= @dateFrom AND o.order_date <= @dateTo GROUP BY item_name ORDER BY TotalQty DESC LIMIT 5"
            Using cmd As New MySqlCommand(topItemsQuery, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Dim series As New Series("Top Items")
                series.ChartType = SeriesChartType.Pie

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim itemName As String = reader("item_name").ToString()
                        Dim qty As Integer = If(IsDBNull(reader("TotalQty")), 0, Convert.ToInt32(reader("TotalQty")))
                        series.Points.AddXY(itemName, qty)
                    End While
                End Using

                chartTopItems.Series.Add(series)
                chartTopItems.Titles.Clear()
                chartTopItems.Titles.Add("Top 5 Best Selling Items")
                series.IsValueShownAsLabel = True
            End Using

        Catch ex As Exception
            LogError("GenerateSalesCharts", ex.Message)
            ' Don't show error - charts are optional enhancement
        End Try
    End Sub

    ''' <summary>
    ''' Export audit logs to CSV file
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
    ''' Export sales report to CSV file
    ''' </summary>
    Private Sub ExportSalesReportToCsv()
        Try
            If dgvSalesReport.Rows.Count = 0 Then
                MessageBox.Show("No data to export. Please generate a report first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim fileName As String = $"SalesReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            Dim filePath As String = Path.Combine(PathManager.GetExportsPath(), fileName)

            ExportDataGridToCsv(dgvSalesReport, filePath)
            MessageBox.Show($"Sales report exported to: {filePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            LogError("ExportSalesReportToCsv", ex.Message)
            MessageBox.Show("Error exporting sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Helper method to export DataGridView to CSV
    ''' </summary>
    Private Sub ExportDataGridToCsv(dgv As DataGridView, filePath As String)
        Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
            ' Write headers
            Dim headers As String = String.Join(",", dgv.Columns.Cast(Of DataGridViewColumn)().Select(Function(col) $"""{col.HeaderText}"""))
            writer.WriteLine(headers)

            ' Write data rows
            For Each row As DataGridViewRow In dgv.Rows
                If Not row.IsNewRow Then
                    Dim values As String = String.Join(",", row.Cells.Cast(Of DataGridViewCell)().Select(Function(cell) $"""{If(cell.Value, "")}"""))
                    writer.WriteLine(values)
                End If
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Load user accounts for management - card-based display
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

                ' wire events
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

                ' layout
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
    ''' Log error messages to file
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

    ' Event Handlers
    Private Sub btnManageMenu_Click(sender As Object, e As EventArgs) Handles btnManageMenu.Click
        Try
            Dim menuForm As New Manage_menu()
            menuForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening menu management: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAuditLog_Click(sender As Object, e As EventArgs) Handles btnAuditLog.Click
        pnlSalesReport.Visible = False
        pnlManageAccounts.Visible = False
        pnlAuditLog.Visible = True
        SetActiveButton(btnAuditLog)
        LoadAuditLogs()
    End Sub

    Private Sub btnSalesReport_Click(sender As Object, e As EventArgs) Handles btnSalesReport.Click
        pnlAuditLog.Visible = False
        pnlManageAccounts.Visible = False
        pnlSalesReport.Visible = True
        SetActiveButton(btnSalesReport)
    End Sub

    Private Sub btnManageAccounts_Click(sender As Object, e As EventArgs) Handles btnManageAccounts.Click
        pnlAuditLog.Visible = False
        pnlSalesReport.Visible = False
        pnlManageAccounts.Visible = True
        SetActiveButton(btnManageAccounts)
        LoadUserAccounts()
    End Sub

    Private Sub btnFilterAuditLogs_Click(sender As Object, e As EventArgs) Handles btnFilterAuditLogs.Click
        FilterAuditLogs()
    End Sub

    Private Sub btnExportAuditLogs_Click(sender As Object, e As EventArgs) Handles btnExportAuditLogs.Click
        ExportAuditLogsToCsv()
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        GenerateSalesReport()
    End Sub

    Private Sub btnExportSalesReport_Click(sender As Object, e As EventArgs) Handles btnExportSalesReport.Click
        ExportSalesReportToCsv()
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

    Private Sub pnlHeader_Paint(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint
    End Sub

    Private Sub pnlManageAccounts_Paint(sender As Object, e As PaintEventArgs) Handles pnlManageAccounts.Paint
    End Sub
End Class