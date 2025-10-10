Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.IO

''' <summary>
''' Modern Sales Report Form with Advanced Charts and Analytics
''' </summary>
Public Class SalesReport
    Private chartDailySales As Chart
    Private chartTopItems As Chart
    Private chartRevenueTrend As Chart
    Private navButtons As AdminNavButtons

    Private Sub SalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        ' Initialize navigation buttons
        navButtons = New AdminNavButtons(Me, btnLogout, btnBack, Nothing, Nothing)

        ' Set default date range (last 30 days)
        dtpFrom.Value = DateTime.Now.AddDays(-30)
        dtpTo.Value = DateTime.Now

        ' Initialize charts
        InitializeCharts()

        ' Load initial data
        GenerateSalesReport()
    End Sub

    ''' <summary>
    ''' Initialize all chart controls with modern styling
    ''' </summary>
    Private Sub InitializeCharts()
        Try
            ' Clear existing controls
            pnlDailySalesChart.Controls.Clear()
            pnlTopItemsChart.Controls.Clear()
            pnlRevenueChart.Controls.Clear()

            ' === Daily Sales Chart (Column Chart) ===
            chartDailySales = New Chart()
            chartDailySales.Dock = DockStyle.Fill
            chartDailySales.BackColor = Color.WhiteSmoke

            Dim dailyArea As New ChartArea("DailyArea")
            dailyArea.BackColor = Color.White
            dailyArea.BorderColor = Color.LightGray
            dailyArea.BorderWidth = 1
            dailyArea.AxisX.MajorGrid.LineColor = Color.LightGray
            dailyArea.AxisY.MajorGrid.LineColor = Color.LightGray
            dailyArea.AxisX.LabelStyle.Font = New Font("Segoe UI", 9)
            dailyArea.AxisY.LabelStyle.Font = New Font("Segoe UI", 9)
            chartDailySales.ChartAreas.Add(dailyArea)

            Dim dailyLegend As New Legend("DailyLegend")
            dailyLegend.Font = New Font("Segoe UI", 10)
            dailyLegend.BackColor = Color.Transparent
            dailyLegend.Docking = Docking.Top
            chartDailySales.Legends.Add(dailyLegend)

            pnlDailySalesChart.Controls.Add(chartDailySales)

            ' === Top Items Chart (Pie Chart) ===
            chartTopItems = New Chart()
            chartTopItems.Dock = DockStyle.Fill
            chartTopItems.BackColor = Color.WhiteSmoke

            Dim topArea As New ChartArea("TopArea")
            topArea.BackColor = Color.White
            topArea.BorderColor = Color.LightGray
            topArea.BorderWidth = 1
            topArea.Area3DStyle.Enable3D = True
            topArea.Area3DStyle.Inclination = 20
            chartTopItems.ChartAreas.Add(topArea)

            Dim topLegend As New Legend("TopLegend")
            topLegend.Font = New Font("Segoe UI", 9)
            topLegend.BackColor = Color.Transparent
            topLegend.Docking = Docking.Right
            chartTopItems.Legends.Add(topLegend)

            pnlTopItemsChart.Controls.Add(chartTopItems)

            ' === Revenue Trend Chart (Line Chart) ===
            chartRevenueTrend = New Chart()
            chartRevenueTrend.Dock = DockStyle.Fill
            chartRevenueTrend.BackColor = Color.WhiteSmoke

            Dim revenueArea As New ChartArea("RevenueArea")
            revenueArea.BackColor = Color.White
            revenueArea.BorderColor = Color.LightGray
            revenueArea.BorderWidth = 1
            revenueArea.AxisX.MajorGrid.LineColor = Color.LightGray
            revenueArea.AxisY.MajorGrid.LineColor = Color.LightGray
            revenueArea.AxisX.LabelStyle.Font = New Font("Segoe UI", 9)
            revenueArea.AxisY.LabelStyle.Font = New Font("Segoe UI", 9)
            chartRevenueTrend.ChartAreas.Add(revenueArea)

            Dim revenueLegend As New Legend("RevenueLegend")
            revenueLegend.Font = New Font("Segoe UI", 10)
            revenueLegend.BackColor = Color.Transparent
            revenueLegend.Docking = Docking.Top
            chartRevenueTrend.Legends.Add(revenueLegend)

            pnlRevenueChart.Controls.Add(chartRevenueTrend)

        Catch ex As Exception
            MessageBox.Show("Error initializing charts: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generate comprehensive sales report with all charts and metrics
    ''' </summary>
    Private Sub GenerateSalesReport()
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                ' Get summary metrics
                LoadSummaryMetrics(connection)

                ' Generate all charts
                GenerateDailySalesChart(connection)
                GenerateTopItemsChart(connection)
                GenerateRevenueTrendChart(connection)

                ' Load detailed transaction grid
                LoadTransactionDetails(connection)

            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load summary metrics (Total Sales, Order Count, Average Order)
    ''' </summary>
    Private Sub LoadSummaryMetrics(connection As MySqlConnection)
        Try
            Dim query As String = "SELECT COUNT(*) AS OrderCount, 
                                         SUM(total_amount) AS TotalSales, 
                                         AVG(total_amount) AS AvgOrder 
                                  FROM orders 
                                  WHERE order_date >= @dateFrom AND order_date <= @dateTo"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim totalSales As Decimal = If(IsDBNull(reader("TotalSales")), 0, Convert.ToDecimal(reader("TotalSales")))
                        Dim orderCount As Integer = If(IsDBNull(reader("OrderCount")), 0, Convert.ToInt32(reader("OrderCount")))
                        Dim avgOrder As Decimal = If(IsDBNull(reader("AvgOrder")), 0, Convert.ToDecimal(reader("AvgOrder")))

                        lblTotalSales.Text = "₱" & totalSales.ToString("N2")
                        lblOrderCount.Text = orderCount.ToString("N0")
                        lblAvgOrder.Text = "₱" & avgOrder.ToString("N2")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading metrics: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generate Daily Sales Column Chart
    ''' </summary>
    Private Sub GenerateDailySalesChart(connection As MySqlConnection)
        Try
            chartDailySales.Series.Clear()
            chartDailySales.Titles.Clear()

            Dim query As String = "SELECT DATE(order_date) as OrderDate, 
                                         SUM(total_amount) as DailySales,
                                         COUNT(*) as OrderCount
                                  FROM orders 
                                  WHERE order_date >= @dateFrom AND order_date <= @dateTo 
                                  GROUP BY DATE(order_date) 
                                  ORDER BY OrderDate"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Dim series As New Series("Daily Sales")
                series.ChartType = SeriesChartType.Column
                series.Color = Color.FromArgb(70, 130, 180) ' Steel Blue
                series.BorderWidth = 2
                series.IsValueShownAsLabel = True
                series.LabelFormat = "₱#,##0"
                series.Font = New Font("Segoe UI", 8, FontStyle.Bold)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim orderDate As Date = Convert.ToDateTime(reader("OrderDate"))
                        Dim sales As Decimal = If(IsDBNull(reader("DailySales")), 0, Convert.ToDecimal(reader("DailySales")))
                        series.Points.AddXY(orderDate.ToString("MMM dd"), sales)
                    End While
                End Using

                chartDailySales.Series.Add(series)
                chartDailySales.Titles.Add(New Title("Daily Sales Performance", Docking.Top, New Font("Segoe UI", 12, FontStyle.Bold), Color.FromArgb(70, 130, 180)))

                If chartDailySales.ChartAreas.Count > 0 Then
                    chartDailySales.ChartAreas(0).AxisX.Title = "Date"
                    chartDailySales.ChartAreas(0).AxisY.Title = "Sales Amount (₱)"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating daily sales chart: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generate Top 5 Items Pie Chart
    ''' </summary>
    Private Sub GenerateTopItemsChart(connection As MySqlConnection)
        Try
            chartTopItems.Series.Clear()
            chartTopItems.Titles.Clear()

            Dim query As String = "SELECT item_name, 
                                         SUM(quantity) as TotalQty,
                                         SUM(quantity * price) as TotalRevenue
                                  FROM order_items oi 
                                  JOIN orders o ON oi.order_id = o.id 
                                  WHERE o.order_date >= @dateFrom AND o.order_date <= @dateTo 
                                  GROUP BY item_name 
                                  ORDER BY TotalQty DESC 
                                  LIMIT 5"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Dim series As New Series("Top Items")
                series.ChartType = SeriesChartType.Pie
                series.IsValueShownAsLabel = True
                series("PieLabelStyle") = "Outside"
                series.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                series.LabelFormat = "{0} ({1} units)"

                Dim colorPalette() As Color = {
                    Color.FromArgb(255, 127, 80),   ' Coral
                    Color.FromArgb(135, 206, 250),  ' Sky Blue
                    Color.FromArgb(152, 251, 152),  ' Pale Green
                    Color.FromArgb(255, 218, 185),  ' Peach
                    Color.FromArgb(221, 160, 221)   ' Plum
                }

                Dim colorIndex As Integer = 0

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim itemName As String = reader("item_name").ToString()
                        Dim qty As Integer = If(IsDBNull(reader("TotalQty")), 0, Convert.ToInt32(reader("TotalQty")))

                        Dim point As New DataPoint()
                        point.SetValueXY(itemName, qty)
                        point.Label = String.Format("{0}#PERCENT{P0}#ENDPERCENT", itemName)
                        point.LegendText = String.Format("{0} ({1} units)", itemName, qty)
                        point.Color = colorPalette(colorIndex Mod colorPalette.Length)
                        series.Points.Add(point)

                        colorIndex += 1
                    End While
                End Using

                chartTopItems.Series.Add(series)
                chartTopItems.Titles.Add(New Title("Top 5 Best Selling Items", Docking.Top, New Font("Segoe UI", 12, FontStyle.Bold), Color.FromArgb(255, 127, 80)))
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating top items chart: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generate Revenue Trend Line Chart
    ''' </summary>
    Private Sub GenerateRevenueTrendChart(connection As MySqlConnection)
        Try
            chartRevenueTrend.Series.Clear()
            chartRevenueTrend.Titles.Clear()

            Dim query As String = "SELECT DATE(order_date) as OrderDate, 
                                         SUM(total_amount) as Revenue
                                  FROM orders 
                                  WHERE order_date >= @dateFrom AND order_date <= @dateTo 
                                  GROUP BY DATE(order_date) 
                                  ORDER BY OrderDate"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Dim series As New Series("Revenue Trend")
                series.ChartType = SeriesChartType.Line
                series.Color = Color.FromArgb(50, 205, 50) ' Lime Green
                series.BorderWidth = 3
                series.MarkerStyle = MarkerStyle.Circle
                series.MarkerSize = 8
                series.MarkerColor = Color.DarkGreen

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim orderDate As Date = Convert.ToDateTime(reader("OrderDate"))
                        Dim revenue As Decimal = If(IsDBNull(reader("Revenue")), 0, Convert.ToDecimal(reader("Revenue")))
                        series.Points.AddXY(orderDate.ToString("MMM dd"), revenue)
                    End While
                End Using

                chartRevenueTrend.Series.Add(series)
                chartRevenueTrend.Titles.Add(New Title("Revenue Trend Analysis", Docking.Top, New Font("Segoe UI", 12, FontStyle.Bold), Color.FromArgb(50, 205, 50)))

                If chartRevenueTrend.ChartAreas.Count > 0 Then
                    chartRevenueTrend.ChartAreas(0).AxisX.Title = "Date"
                    chartRevenueTrend.ChartAreas(0).AxisY.Title = "Revenue (₱)"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating revenue trend chart: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load detailed transaction data into DataGridView
    ''' </summary>
    Private Sub LoadTransactionDetails(connection As MySqlConnection)
        Try
            Dim query As String = "SELECT id, order_date AS 'Date', order_time AS 'Time', 
                                         username AS 'User', total_amount AS 'Amount' 
                                  FROM orders 
                                  WHERE order_date >= @dateFrom AND order_date <= @dateTo 
                                  ORDER BY order_date DESC, order_time DESC"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvTransactions.DataSource = dt
                dgvTransactions.AutoResizeColumns()

                ' Format the Amount column
                If dgvTransactions.Columns.Contains("Amount") Then
                    dgvTransactions.Columns("Amount").DefaultCellStyle.Format = "₱#,##0.00"
                    dgvTransactions.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Export report to PDF (placeholder - implement with a PDF library)
    ''' </summary>
    Private Sub ExportToPdf()
        MessageBox.Show("PDF export feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Export transactions to CSV
    ''' </summary>
    Private Sub ExportToCsv()
        Try
            If dgvTransactions.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "CSV Files (*.csv)|*.csv"
                saveDialog.FileName = $"SalesReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    Using writer As New StreamWriter(saveDialog.FileName)
                        ' Headers
                        Dim headers As New List(Of String)
                        For Each col As DataGridViewColumn In dgvTransactions.Columns
                            headers.Add("""" & col.HeaderText & """")
                        Next
                        writer.WriteLine(String.Join(",", headers))

                        ' Data
                        For Each row As DataGridViewRow In dgvTransactions.Rows
                            If Not row.IsNewRow Then
                                Dim values As New List(Of String)
                                For Each cell As DataGridViewCell In row.Cells
                                    values.Add("""" & If(cell.Value, "").ToString() & """")
                                Next
                                writer.WriteLine(String.Join(",", values))
                            End If
                        Next
                    End Using

                    MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error exporting report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Button Event Handlers
    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        GenerateSalesReport()
    End Sub

    Private Sub btnExportPdf_Click(sender As Object, e As EventArgs) Handles btnExportPdf.Click
        ExportToPdf()
    End Sub

    Private Sub btnExportCsv_Click(sender As Object, e As EventArgs) Handles btnExportCsv.Click
        ExportToCsv()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        MessageBox.Show("Print feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub pnlDailySalesChart_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub pnlTopItemsChart_Paint(sender As Object, e As PaintEventArgs) Handles pnlTopItemsChart.Paint

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label9_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pnlOrderCount_Paint(sender As Object, e As PaintEventArgs) Handles pnlOrderCount.Paint

    End Sub


    Private Sub Label9_Click_3(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub lblTotalsalesicon_Click(sender As Object, e As EventArgs) Handles lblTotalsalesicon.Click

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

    End Sub
End Class