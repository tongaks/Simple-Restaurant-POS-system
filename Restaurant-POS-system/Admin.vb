' Admin Dashboard Form - OrderUp! System
' Features: Audit Log, Sales Report, Menu Management, User Management
' Database: MySQL

Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class Admin
    Private currentUserRole As String = "Admin"
    Private navButtons As AdminNavButtons

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
        ' For Admin, pass only logout, help, and instructions buttons (no back button)
        navButtons = New AdminNavButtons(Me, btnLogout, Nothing, btnHelp, btnInstructions)

        Me.WindowState = FormWindowState.Maximized
        LoadAuditLogs()
        pnlSalesReport.Visible = False
        pnlManageAccounts.Visible = False
        dtpFrom.Value = DateTime.Now.AddDays(-30)
        dtpTo.Value = DateTime.Now
    End Sub

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
    ''' Generate sales report for specified date range
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
                            lblTotalSales.Text = "₱" & If(IsDBNull(reader("TotalSales")), 0, reader("TotalSales"))
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

            End Using
        Catch ex As Exception
            LogError("GenerateSalesReport", ex.Message)
            MessageBox.Show("Error generating sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    ''' Load user accounts for management
    ''' </summary>
    Private Sub LoadUserAccounts()
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()
                Dim query As String = "SELECT ID, Username, 'User' AS Role FROM user UNION ALL SELECT ID, Username, 'Admin' AS Role FROM Admin"
                Using cmd As New MySqlCommand(query, connection)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvUsers.DataSource = dt
                    dgvUsers.AutoResizeColumns()
                End Using
            End Using
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
        LoadAuditLogs()
    End Sub

    Private Sub btnSalesReport_Click(sender As Object, e As EventArgs) Handles btnSalesReport.Click
        pnlAuditLog.Visible = False
        pnlManageAccounts.Visible = False
        pnlSalesReport.Visible = True
    End Sub

    Private Sub btnManageAccounts_Click(sender As Object, e As EventArgs) Handles btnManageAccounts.Click
        pnlAuditLog.Visible = False
        pnlSalesReport.Visible = False
        pnlManageAccounts.Visible = True
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

    Private Sub pnlHeader_Paint(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint
        ' Empty handler - can be removed if not needed
    End Sub

    Private Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        ' To be implemented in future version
    End Sub
End Class

''' <summary>
''' Manages navigation buttons for Admin and related forms.
''' Handles Logout, Back, Help, and Instructions functionality.
''' Constructor accepts existing designer buttons (one or more) so logic lives here and forms stay clean.
''' </summary>
