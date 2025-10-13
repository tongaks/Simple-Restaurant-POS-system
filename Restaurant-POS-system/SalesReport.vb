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

        ' --- Make Logout and Power buttons look exactly like in Designer ---
        'ican't edit it in button so i add this thing'

        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.BackColor = Color.Transparent
        btnBack.UseVisualStyleBackColor = True
        btnBack.ForeColor = Color.Black
        btnBack.Font = New Font("Segoe UI Symbol", 17, FontStyle.Regular)

        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.BackColor = Color.Transparent
        btnLogout.UseVisualStyleBackColor = True
        btnLogout.ForeColor = Color.Black
        btnLogout.Font = New Font("Segoe UI Symbol", 17, FontStyle.Regular)


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

            ' === 🌟 Daily Sales Chart (Professional Modern Style) ===
            chartDailySales = New Chart()
            chartDailySales.Dock = DockStyle.Fill
            chartDailySales.BackColor = Color.White
            chartDailySales.BorderlineDashStyle = ChartDashStyle.Solid
            chartDailySales.BorderlineColor = Color.LightGray
            chartDailySales.BorderlineWidth = 1

            ' --- Chart Area ---
            Dim dailyArea As New ChartArea("DailyArea")
            With dailyArea
                .BackColor = Color.FromArgb(250, 252, 255)
                .BackGradientStyle = GradientStyle.TopBottom
                .BackSecondaryColor = Color.White
                .BorderColor = Color.Transparent

                .AxisX.MajorGrid.LineColor = Color.FromArgb(235, 235, 235)
                .AxisY.MajorGrid.LineColor = Color.FromArgb(235, 235, 235)
                .AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot
                .AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot

                .AxisX.LineColor = Color.FromArgb(180, 180, 180)
                .AxisY.LineColor = Color.FromArgb(180, 180, 180)
                .AxisX.LabelStyle.Font = New Font("Segoe UI", 10)
                .AxisY.LabelStyle.Font = New Font("Segoe UI", 10)
                .AxisX.Title = "Date"
                .AxisY.Title = "Sales Amount (₱)"
                .AxisX.TitleFont = New Font("Segoe UI Semibold", 10)
                .AxisY.TitleFont = New Font("Segoe UI Semibold", 10)
                .AxisX.TitleForeColor = Color.FromArgb(64, 64, 64)
                .AxisY.TitleForeColor = Color.FromArgb(64, 64, 64)
            End With
            chartDailySales.ChartAreas.Add(dailyArea)

            ' --- Legend ---
            Dim dailyLegend As New Legend("DailyLegend")
            With dailyLegend
                .Font = New Font("Segoe UI", 9)
                .BackColor = Color.Transparent
                .Docking = Docking.Top
                .Alignment = StringAlignment.Center
            End With
            chartDailySales.Legends.Add(dailyLegend)

            ' --- Title ---
            chartDailySales.Titles.Add(New Title("Daily Sales Performance",
                                     Docking.Top,
                                     New Font("Segoe UI Semibold", 13, FontStyle.Bold),
                                     Color.FromArgb(45, 45, 48)))

            ' --- Default Preview Style ---
            Dim previewSeries As New Series("Daily Sales")
            With previewSeries
                .ChartType = SeriesChartType.Column
                .Color = Color.FromArgb(72, 118, 255)
                .BackSecondaryColor = Color.FromArgb(30, 144, 255)
                .BackGradientStyle = GradientStyle.TopBottom
                .BorderWidth = 0
                .ShadowColor = Color.FromArgb(80, 0, 0, 0)
                .ShadowOffset = 3
                .IsValueShownAsLabel = True
                .Font = New Font("Segoe UI", 9)
                .CustomProperties = "DrawingStyle=Cylinder, PointWidth=0.5"
                .Points.AddXY("Sample", 0)
            End With
            chartDailySales.Series.Add(previewSeries)

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
    ''' Prepare the FlowLayoutPanel container for recent transaction cards.
    ''' </summary>
    Private Sub InitializeTransactionPanel()
        ' Use existing panel on your form where the DataGridView used to be.
        ' I assume it's named pnlTransactions (use the actual name in your form).
        pnlTransactions.Controls.Clear()

        Dim flow As New FlowLayoutPanel() With {
        .Name = "flowRecentTransactions",
        .Dock = DockStyle.Fill,
        .AutoScroll = True,
        .WrapContents = True,
        .FlowDirection = FlowDirection.LeftToRight,
        .BackColor = Color.WhiteSmoke,
        .Padding = New Padding(10)
    }

        pnlTransactions.Controls.Add(flow)
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
    ''' <summary>
    ''' Generate Daily Sales Column Chart (Professional Dashboard Style)
    ''' </summary>
    Private Sub GenerateDailySalesChart(connection As MySqlConnection)
        Try
            chartDailySales.Series.Clear()
            chartDailySales.Titles.Clear()

            ' === Data Query ===
            Dim query As String = "
            SELECT DATE(order_date) AS OrderDate,
                   SUM(total_amount) AS DailySales
            FROM orders
            WHERE order_date >= @dateFrom AND order_date <= @dateTo
            GROUP BY DATE(order_date)
            ORDER BY OrderDate;"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Dim series As New Series("Daily Sales") With {
                .ChartType = SeriesChartType.Column,
                .Color = Color.FromArgb(72, 118, 255),
                .BackSecondaryColor = Color.FromArgb(30, 144, 255),
                .BackGradientStyle = GradientStyle.TopBottom,
                .BorderWidth = 0,
                .ShadowColor = Color.FromArgb(60, 0, 0, 0),
                .ShadowOffset = 3,
                .IsValueShownAsLabel = True,
                .Font = New Font("Segoe UI", 9),
                .CustomProperties = "DrawingStyle=Cylinder, PointWidth=0.5"
            }

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim orderDate As Date = Convert.ToDateTime(reader("OrderDate"))
                        Dim sales As Decimal = If(IsDBNull(reader("DailySales")), 0, Convert.ToDecimal(reader("DailySales")))
                        series.Points.AddXY(orderDate.ToString("MMM dd"), sales)
                    End While
                End Using

                chartDailySales.Series.Add(series)
            End Using

            ' === Reapply Modern Style ===
            With chartDailySales
                .BackColor = Color.White
                .ChartAreas(0).BackColor = Color.FromArgb(250, 252, 255)
                .ChartAreas(0).BackGradientStyle = GradientStyle.TopBottom
                .ChartAreas(0).BackSecondaryColor = Color.White
                .ChartAreas(0).AxisX.MajorGrid.LineColor = Color.FromArgb(235, 235, 235)
                .ChartAreas(0).AxisY.MajorGrid.LineColor = Color.FromArgb(235, 235, 235)
                .ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot
                .ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
                .ChartAreas(0).AxisX.LabelStyle.Font = New Font("Segoe UI", 10)
                .ChartAreas(0).AxisY.LabelStyle.Font = New Font("Segoe UI", 10)
                .ChartAreas(0).AxisX.Title = "Date"
                .ChartAreas(0).AxisY.Title = "Sales Amount (₱)"
                .ChartAreas(0).AxisX.TitleFont = New Font("Segoe UI Semibold", 10)
                .ChartAreas(0).AxisY.TitleFont = New Font("Segoe UI Semibold", 10)
                .ChartAreas(0).AxisX.TitleForeColor = Color.FromArgb(64, 64, 64)
                .ChartAreas(0).AxisY.TitleForeColor = Color.FromArgb(64, 64, 64)
            End With

            ' === Add Styled Title ===
            chartDailySales.Titles.Add(New Title("Daily Sales Performance",
                                  Docking.Top,
                                  New Font("Segoe UI Semibold", 13, FontStyle.Bold),
                                  Color.FromArgb(45, 45, 48)))

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
    ''' Generate Revenue Trend Line Chart (Professional Dashboard Style)
    ''' </summary>
    Private Sub GenerateRevenueTrendChart(connection As MySqlConnection)
        Try
            chartRevenueTrend.Series.Clear()
            chartRevenueTrend.Titles.Clear()

            ' === Data Query ===
            Dim query As String = "
            SELECT DATE(order_date) AS OrderDate,
                   SUM(total_amount) AS TotalRevenue
            FROM orders
            WHERE order_date >= @dateFrom AND order_date <= @dateTo
            GROUP BY DATE(order_date)
            ORDER BY OrderDate;"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Dim series As New Series("Revenue Trend") With {
                .ChartType = SeriesChartType.Line,
                .BorderWidth = 3,
                .Color = Color.FromArgb(52, 152, 219),
                .ShadowOffset = 1,
                .MarkerStyle = MarkerStyle.Circle,
                .MarkerSize = 8,
                .MarkerColor = Color.White,
                .MarkerBorderColor = Color.FromArgb(52, 152, 219),
                .IsValueShownAsLabel = False,
                .BorderDashStyle = ChartDashStyle.Solid
            }

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim orderDate As Date = Convert.ToDateTime(reader("OrderDate"))
                        Dim totalRevenue As Decimal = If(IsDBNull(reader("TotalRevenue")), 0, Convert.ToDecimal(reader("TotalRevenue")))
                        series.Points.AddXY(orderDate.ToString("MMM dd"), totalRevenue)
                    End While
                End Using

                chartRevenueTrend.Series.Add(series)
            End Using

            ' === Apply Modern Design ===
            With chartRevenueTrend
                .BackColor = Color.White
                .ChartAreas(0).BackColor = Color.FromArgb(250, 252, 255)
                .ChartAreas(0).BackGradientStyle = GradientStyle.TopBottom
                .ChartAreas(0).BackSecondaryColor = Color.White

                ' Grid and Axis
                .ChartAreas(0).AxisX.MajorGrid.LineColor = Color.FromArgb(235, 235, 235)
                .ChartAreas(0).AxisY.MajorGrid.LineColor = Color.FromArgb(235, 235, 235)
                .ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot
                .ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
                .ChartAreas(0).AxisX.LineColor = Color.FromArgb(200, 200, 200)
                .ChartAreas(0).AxisY.LineColor = Color.FromArgb(200, 200, 200)

                ' Axis labels and titles
                .ChartAreas(0).AxisX.LabelStyle.Font = New Font("Segoe UI", 10)
                .ChartAreas(0).AxisY.LabelStyle.Font = New Font("Segoe UI", 10)
                .ChartAreas(0).AxisX.Title = "Date"
                .ChartAreas(0).AxisY.Title = "Revenue (₱)"
                .ChartAreas(0).AxisX.TitleFont = New Font("Segoe UI Semibold", 10)
                .ChartAreas(0).AxisY.TitleFont = New Font("Segoe UI Semibold", 10)
                .ChartAreas(0).AxisX.TitleForeColor = Color.FromArgb(64, 64, 64)
                .ChartAreas(0).AxisY.TitleForeColor = Color.FromArgb(64, 64, 64)
            End With

            ' === Add Modern Chart Title ===
            chartRevenueTrend.Titles.Add(New Title("Revenue Trend",
                                   Docking.Top,
                                   New Font("Segoe UI Semibold", 13, FontStyle.Bold),
                                   Color.FromArgb(45, 45, 48)))

            ' === Add Light Gradient Fill Below the Line ===
            Dim area As ChartArea = chartRevenueTrend.ChartAreas(0)
            Dim gradientSeries As New Series("Revenue Fill") With {
            .ChartType = SeriesChartType.Area,
            .Color = Color.FromArgb(60, 52, 152, 219),
            .BorderWidth = 0
        }

            ' Copy points from the main line for the gradient fill
            For Each pt As DataPoint In chartRevenueTrend.Series("Revenue Trend").Points
                gradientSeries.Points.AddXY(pt.XValue, pt.YValues(0))
            Next

            chartRevenueTrend.Series.Insert(0, gradientSeries)

        Catch ex As Exception
            MessageBox.Show("Error generating revenue trend chart: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    ''' <summary>
    ''' Load recent transactions and show as cards in the FlowLayoutPanel.
    ''' Replaces DataGridView visuals only; does NOT touch charts.
    ''' </summary>
    Private Sub LoadTransactionDetails(connection As MySqlConnection)
        Try
            ' === 1️⃣ Title Label (Recent Transactions) ===
            Dim lbl As Label = pnlTransactions.Controls.OfType(Of Label)().
            FirstOrDefault(Function(l) l.Name = "lblTransactions")

            If lbl Is Nothing Then
                lbl = New Label With {
                .Name = "lblTransactions",
                .Text = "Recent Transactions",
                .Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold),
                .ForeColor = Color.FromArgb(45, 45, 48),
                .Dock = DockStyle.Top,
                .Height = 35,
                .TextAlign = ContentAlignment.MiddleLeft,
                .Padding = New Padding(10, 0, 0, 0),
                .BackColor = Color.White
            }
                pnlTransactions.Controls.Add(lbl)
            End If

            ' === 2️⃣ FlowLayoutPanel (cards container) ===
            Dim flow As FlowLayoutPanel = pnlTransactions.Controls.OfType(Of FlowLayoutPanel)().
            FirstOrDefault(Function(f) f.Name = "flowRecentTransactions")

            If flow Is Nothing Then
                flow = New FlowLayoutPanel With {
                .Name = "flowRecentTransactions",
                .Dock = DockStyle.Fill,
                .AutoScroll = True,
                .FlowDirection = FlowDirection.LeftToRight,
                .WrapContents = True,
                .Padding = New Padding(50),
                .BackColor = Color.WhiteSmoke
            }
                pnlTransactions.Controls.Add(flow)
                flow.BringToFront()
            Else
                flow.Controls.Clear()
            End If

            ' === 3️⃣ Make sure title stays on top ===
            lbl.BringToFront()

            ' === 4️⃣ Load 10 recent orders as cards ===
            Dim query As String = "SELECT order_id, order_date AS `date`, order_time AS `time`, username AS `user`, total_amount AS `amount` " &
                              "FROM orders " &
                              "WHERE order_date >= @dateFrom AND order_date <= @dateTo " &
                              "ORDER BY order_date DESC, order_time DESC LIMIT 10;"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim card As New Panel With {
                        .Width = 240,
                        .Height = 100,
                        .BackColor = Color.White,
                        .Margin = New Padding(8),
                        .Padding = New Padding(10),
                        .BorderStyle = BorderStyle.FixedSingle
                    }

                        Dim lblDate As New Label With {
                        .AutoSize = True,
                        .Text = Convert.ToDateTime(reader("date")).ToString("dd/MM/yyyy") & "  " & reader("time").ToString(),
                        .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                        .ForeColor = Color.Gray,
                        .Location = New Point(8, 8)
                    }

                        Dim lblUser As New Label With {
                        .AutoSize = True,
                        .Text = "User: " & reader("user").ToString(),
                        .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                        .ForeColor = Color.FromArgb(45, 45, 48),
                        .Location = New Point(8, 30)
                    }

                        Dim lblAmount As New Label With {
                        .AutoSize = False,
                        .Size = New Size(card.Width - 16, 28),
                        .Text = "₱" & Convert.ToDecimal(reader("amount")).ToString("N2"),
                        .Font = New Font("Segoe UI Semibold", 11, FontStyle.Bold),
                        .ForeColor = Color.FromArgb(52, 152, 219),
                        .TextAlign = ContentAlignment.MiddleRight,
                        .Location = New Point(8, 60)
                    }

                        card.Controls.Add(lblDate)
                        card.Controls.Add(lblUser)
                        card.Controls.Add(lblAmount)

                        flow.Controls.Add(card)
                    End While
                End Using
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

    Private Sub pnlDailySalesChart_Paint_1(sender As Object, e As PaintEventArgs) Handles pnlDailySalesChart.Paint

    End Sub

    Private Sub lblTransactions_Click(sender As Object, e As EventArgs) Handles lblTransactions.Click

    End Sub

    Private Sub dgvTransactions_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransactions.CellContentClick

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class