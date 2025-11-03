Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.IO
Imports PdfSharp.Pdf
Imports PdfSharp.Drawing
Imports Guna.UI2.WinForms

''' <summary>
''' ULTRA-MODERN Enterprise Sales Analytics Dashboard
''' Professional, responsive, and feature-rich reporting interface
''' </summary>
Public Class SalesReport
    Private chartDailySales As Chart
    Private chartTopItems As Chart
    Private chartRevenueTrend As Chart
    Private navButtons As AdminNavButtons
    Private transactionData As New Dictionary(Of Integer, TransactionDetails)

    ' Transaction detail structure for receipt viewing
    Private Structure TransactionDetails
        Public OrderId As Integer
        Public OrderDate As DateTime
        Public OrderTime As String
        Public Username As String
        Public TotalAmount As Decimal
        Public Items As List(Of OrderItem)
    End Structure

    Private Structure OrderItem
        Public ItemName As String
        Public Quantity As Integer
        Public Price As Decimal
        Public Total As Decimal
    End Structure

    Private Sub SalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.Dpi
        Me.WindowState = FormWindowState.Maximized

        navButtons = New AdminNavButtons(Me, btnLogout, btnBack, Nothing, Nothing)

        dtpFrom.Value = DateTime.Now.AddDays(-30)
        dtpTo.Value = DateTime.Now

        InitializeCharts()
        ShowLoadingState()
        GenerateSalesReport()
        HideLoadingState()
    End Sub

    Private Sub ShowLoadingState()
        Me.Cursor = Cursors.WaitCursor
    End Sub

    Private Sub HideLoadingState()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub InitializeCharts()
        Try
            ' Clear existing charts
            For Each ctrl In pnlDailySalesChart.Controls.OfType(Of Chart)().ToList()
                ctrl.Dispose()
            Next
            For Each ctrl In pnlTopItemsChart.Controls.OfType(Of Chart)().ToList()
                ctrl.Dispose()
            Next
            For Each ctrl In pnlRevenueChart.Controls.OfType(Of Chart)().ToList()
                ctrl.Dispose()
            Next

            ' === DAILY SALES CHART ===
            chartDailySales = New Chart()
            chartDailySales.Dock = DockStyle.Fill
            chartDailySales.BackColor = Color.White
            chartDailySales.BorderlineColor = Color.Transparent

            Dim dailyArea As New ChartArea("DailyArea")
            With dailyArea
                .BackColor = Color.White
                .AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240)
                .AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240)
                .AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
                .AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
                .AxisX.LineColor = Color.FromArgb(200, 200, 200)
                .AxisY.LineColor = Color.FromArgb(200, 200, 200)
                .AxisX.LabelStyle.Font = New Font("Segoe UI", 10)
                .AxisY.LabelStyle.Font = New Font("Segoe UI", 10)
                .AxisX.LabelStyle.ForeColor = Color.FromArgb(120, 120, 120)
                .AxisY.LabelStyle.ForeColor = Color.FromArgb(120, 120, 120)
            End With
            chartDailySales.ChartAreas.Add(dailyArea)

            Dim dailyLegend As New Legend("DailyLegend")
            dailyLegend.Font = New Font("Segoe UI", 10)
            dailyLegend.BackColor = Color.Transparent
            dailyLegend.Docking = Docking.Top
            chartDailySales.Legends.Add(dailyLegend)

            pnlDailySalesChart.Controls.Add(chartDailySales)

            ' === PIE CHART ===
            chartTopItems = New Chart()
            chartTopItems.Dock = DockStyle.Fill
            chartTopItems.BackColor = Color.White

            Dim topArea As New ChartArea("TopArea")
            topArea.BackColor = Color.White
            topArea.Area3DStyle.Enable3D = True
            topArea.Area3DStyle.Inclination = 15
            topArea.Area3DStyle.Rotation = 10
            topArea.Area3DStyle.LightStyle = LightStyle.Realistic
            chartTopItems.ChartAreas.Add(topArea)

            Dim topLegend As New Legend("TopLegend")
            topLegend.Font = New Font("Segoe UI", 10)
            topLegend.BackColor = Color.Transparent
            topLegend.Docking = Docking.Bottom
            chartTopItems.Legends.Add(topLegend)

            pnlTopItemsChart.Controls.Add(chartTopItems)

            ' === LINE CHART ===
            chartRevenueTrend = New Chart()
            chartRevenueTrend.Dock = DockStyle.Fill
            chartRevenueTrend.BackColor = Color.White

            Dim revenueArea As New ChartArea("RevenueArea")
            With revenueArea
                .BackColor = Color.White
                .AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240)
                .AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240)
                .AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
                .AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
                .AxisX.LineColor = Color.FromArgb(200, 200, 200)
                .AxisY.LineColor = Color.FromArgb(200, 200, 200)
                .AxisX.LabelStyle.Font = New Font("Segoe UI", 10)
                .AxisY.LabelStyle.Font = New Font("Segoe UI", 10)
                .AxisX.LabelStyle.ForeColor = Color.FromArgb(120, 120, 120)
                .AxisY.LabelStyle.ForeColor = Color.FromArgb(120, 120, 120)
            End With
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

    Private Sub GenerateSalesReport()
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                LoadSummaryMetrics(connection)
                GenerateDailySalesChart(connection)
                GenerateTopItemsChart(connection)
                GenerateRevenueTrendChart(connection)
                LoadTransactionDetailsGrid(connection)

                HideLoadingState()
            End Using

            If String.IsNullOrWhiteSpace(lblTotalSales.Text) Then lblTotalSales.Text = "₱0.00"
            If String.IsNullOrWhiteSpace(lblOrderCount.Text) Then lblOrderCount.Text = "0"
            If String.IsNullOrWhiteSpace(lblAvgOrder.Text) Then lblAvgOrder.Text = "₱0.00"

        Catch ex As Exception
            HideLoadingState()
            MessageBox.Show("Error generating sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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

    Private Sub GenerateDailySalesChart(connection As MySqlConnection)
        Try
            chartDailySales.Series.Clear()

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
                    .Color = Color.FromArgb(255, 200, 87),
                    .BackSecondaryColor = Color.FromArgb(255, 170, 51),
                    .BackGradientStyle = GradientStyle.VerticalCenter,
                    .BorderWidth = 0,
                    .ShadowOffset = 2,
                    .IsValueShownAsLabel = True,
                    .LabelForeColor = Color.FromArgb(30, 30, 30),
                    .Font = New Font("Segoe UI Semibold", 9, FontStyle.Bold),
                    .CustomProperties = "PointWidth=0.7"
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

        Catch ex As Exception
            MessageBox.Show("Error generating daily sales chart: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateTopItemsChart(connection As MySqlConnection)
        Try
            chartTopItems.Series.Clear()

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

                Dim series As New Series("Top Items") With {
                    .ChartType = SeriesChartType.Pie,
                    .IsValueShownAsLabel = True,
                    .Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
                }

                series("PieLabelStyle") = "Outside"
                series("PieLineColor") = "Black"

                Dim colorPalette() As Color = {
                    Color.FromArgb(255, 200, 87),
                    Color.FromArgb(31, 138, 112),
                    Color.FromArgb(239, 68, 68),
                    Color.FromArgb(59, 130, 246),
                    Color.FromArgb(168, 85, 247)
                }

                Dim colorIndex As Integer = 0

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim itemName As String = reader("item_name").ToString()
                        Dim qty As Integer = If(IsDBNull(reader("TotalQty")), 0, Convert.ToInt32(reader("TotalQty")))

                        Dim point As New DataPoint()
                        point.SetValueXY(itemName, qty)
                        point.Label = "#PERCENT{P0}"
                        point.LegendText = String.Format("{0} ({1})", itemName, qty)
                        point.Color = colorPalette(colorIndex Mod colorPalette.Length)
                        series.Points.Add(point)

                        colorIndex += 1
                    End While
                End Using

                chartTopItems.Series.Add(series)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating top items chart: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateRevenueTrendChart(connection As MySqlConnection)
        Try
            chartRevenueTrend.Series.Clear()

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
                    .ChartType = SeriesChartType.SplineArea,
                    .BorderWidth = 3,
                    .Color = Color.FromArgb(100, 31, 138, 112),
                    .BorderColor = Color.FromArgb(31, 138, 112),
                    .MarkerStyle = MarkerStyle.Circle,
                    .MarkerSize = 8,
                    .MarkerColor = Color.White,
                    .MarkerBorderColor = Color.FromArgb(31, 138, 112),
                    .MarkerBorderWidth = 2,
                    .IsValueShownAsLabel = False
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

        Catch ex As Exception
            MessageBox.Show("Error generating revenue trend chart: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Enhanced transaction grid with "View Receipt" button functionality
    ''' </summary>
    Private Sub LoadTransactionDetailsGrid(connection As MySqlConnection)
        Try
            transactionData.Clear()
            dgvTransactions.Columns.Clear()
            dgvTransactions.Rows.Clear()

            ' Configure columns
            dgvTransactions.Columns.Add("colDate", "Date")
            dgvTransactions.Columns.Add("colTime", "Time")
            dgvTransactions.Columns.Add("colUser", "Cashier")
            dgvTransactions.Columns.Add("colAmount", "Amount")

            ' Add View Receipt button column
            Dim btnCol As New DataGridViewButtonColumn()
            btnCol.Name = "colViewReceipt"
            btnCol.HeaderText = "Action"
            btnCol.Text = "📄 View Receipt"
            btnCol.UseColumnTextForButtonValue = True
            btnCol.Width = 150
            btnCol.DefaultCellStyle.BackColor = Color.FromArgb(31, 138, 112)
            btnCol.DefaultCellStyle.ForeColor = Color.White
            btnCol.DefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
            btnCol.DefaultCellStyle.SelectionBackColor = Color.FromArgb(21, 118, 92)
            btnCol.DefaultCellStyle.SelectionForeColor = Color.White
            dgvTransactions.Columns.Add(btnCol)

            ' Hidden column for Order ID
            dgvTransactions.Columns.Add("colOrderId", "OrderId")
            dgvTransactions.Columns("colOrderId").Visible = False

            ' Set column widths for professional appearance
            dgvTransactions.Columns("colDate").Width = 120
            dgvTransactions.Columns("colTime").Width = 100
            dgvTransactions.Columns("colUser").Width = 150
            dgvTransactions.Columns("colAmount").Width = 150
            dgvTransactions.Columns("colAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Dim query As String = "SELECT id, order_date, order_time, username, total_amount " &
                                  "FROM orders " &
                                  "WHERE order_date >= @dateFrom AND order_date <= @dateTo " &
                                  "ORDER BY order_date DESC, order_time DESC LIMIT 20;"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim orderId As Integer = Convert.ToInt32(reader("id"))
                        Dim orderDate As String = Convert.ToDateTime(reader("order_date")).ToString("dd/MM/yyyy")
                        Dim orderTime As String = reader("order_time").ToString()
                        Dim username As String = reader("username").ToString()
                        Dim totalAmount As Decimal = Convert.ToDecimal(reader("total_amount"))

                        ' Store basic transaction info
                        Dim trans As New TransactionDetails With {
                            .OrderId = orderId,
                            .OrderDate = Convert.ToDateTime(reader("order_date")),
                            .OrderTime = orderTime,
                            .Username = username,
                            .TotalAmount = totalAmount
                        }
                        transactionData(orderId) = trans

                        dgvTransactions.Rows.Add(orderDate, orderTime, username, "₱" & totalAmount.ToString("N2"), Nothing, orderId)
                    End While
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Handle View Receipt button click in DataGridView
    ''' </summary>
    Private Sub dgvTransactions_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransactions.CellContentClick
        Try
            ' Check if the clicked cell is in the "View Receipt" button column
            If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvTransactions.Columns("colViewReceipt").Index Then
                Dim orderId As Integer = Convert.ToInt32(dgvTransactions.Rows(e.RowIndex).Cells("colOrderId").Value)
                ShowReceiptForOrder(orderId)
            End If
        Catch ex As Exception
            MessageBox.Show("Error viewing receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Display receipt for a specific order using the Receipt form
    ''' </summary>
    Private Sub ShowReceiptForOrder(orderId As Integer)
        Try
            ' Load complete order details including items
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                Dim trans As TransactionDetails
                If transactionData.ContainsKey(orderId) Then
                    trans = transactionData(orderId)
                Else
                    MessageBox.Show("Transaction details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' Load order items
                trans.Items = New List(Of OrderItem)
                Dim itemsQuery As String = "SELECT item_name, quantity, price FROM order_items WHERE order_id = @orderId"

                Using cmd As New MySqlCommand(itemsQuery, connection)
                    cmd.Parameters.AddWithValue("@orderId", orderId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New OrderItem With {
                                .ItemName = reader("item_name").ToString(),
                                .Quantity = Convert.ToInt32(reader("quantity")),
                                .Price = Convert.ToDecimal(reader("price")),
                                .Total = Convert.ToInt32(reader("quantity")) * Convert.ToDecimal(reader("price"))
                            }
                            trans.Items.Add(item)
                        End While
                    End Using
                End Using

                ' Build order data for Receipt form
                Dim orderData As New Receipt.OrderData With {
                    .OrderId = orderId.ToString(),
                    .OrderDate = trans.OrderDate,
                    .CashierName = trans.Username,
                    .Items = New List(Of Receipt.OrderItem),
                    .Subtotal = trans.TotalAmount,
                    .DiscountPercent = 0,
                    .Total = trans.TotalAmount,
                    .PaymentMethod = "Cash"
                }

                ' Convert items
                For Each item In trans.Items
                    orderData.Items.Add(New Receipt.OrderItem With {
                        .Name = item.ItemName,
                        .Amount = item.Quantity,
                        .Price = item.Price,
                        .Total = item.Total
                    })
                Next

                ' Show receipt form
                Dim receiptForm As New Receipt()
                receiptForm.LoadReceipt(orderData, String.Empty)
                receiptForm.ShowDialog(Me)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error displaying receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Export functions
    Private Sub ExportToPdf()
        MessageBox.Show("PDF export feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

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
                        Dim headers As New List(Of String)
                        For Each col As DataGridViewColumn In dgvTransactions.Columns
                            If col.Visible Then
                                headers.Add("""" & col.HeaderText & """")
                            End If
                        Next
                        writer.WriteLine(String.Join(",", headers))

                        For Each row As DataGridViewRow In dgvTransactions.Rows
                            If Not row.IsNewRow Then
                                Dim values As New List(Of String)
                                For Each cell As DataGridViewCell In row.Cells
                                    If dgvTransactions.Columns(cell.ColumnIndex).Visible Then
                                        values.Add("""" & If(cell.Value, "").ToString() & """")
                                    End If
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

    ' Button event handlers
    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        ShowLoadingState()
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

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Handled by AdminNavButtons
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Try
            Dim adminForm As Admin = Nothing

            If Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is Admin Then
                adminForm = DirectCast(Me.Owner, Admin)
            Else
                For Each f As Form In Application.OpenForms
                    If TypeOf f Is Admin Then
                        adminForm = DirectCast(f, Admin)
                        Exit For
                    End If
                Next
            End If

            If adminForm Is Nothing Then
                adminForm = New Admin()
                adminForm.Show()
            Else
                If adminForm.WindowState = FormWindowState.Minimized Then
                    adminForm.WindowState = FormWindowState.Normal
                End If
                adminForm.Show()
                adminForm.BringToFront()
                adminForm.Focus()
            End If

            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error returning to Admin: " & ex.Message, "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Hover effects for modern buttons
    Private Sub btnBack_MouseEnter(sender As Object, e As EventArgs) Handles btnBack.MouseEnter
        btnBack.FillColor = Color.FromArgb(120, 255, 255, 255)
        btnBack.ShadowDecoration.Depth = 15
    End Sub

    Private Sub btnBack_MouseLeave(sender As Object, e As EventArgs) Handles btnBack.MouseLeave
        btnBack.FillColor = Color.FromArgb(80, 255, 255, 255)
        btnBack.ShadowDecoration.Depth = 10
    End Sub

    Private Sub btnLogout_MouseEnter(sender As Object, e As EventArgs) Handles btnLogout.MouseEnter
        btnLogout.FillColor = Color.FromArgb(220, 38, 38)
        btnLogout.ShadowDecoration.Depth = 15
    End Sub

    Private Sub btnLogout_MouseLeave(sender As Object, e As EventArgs) Handles btnLogout.MouseLeave
        btnLogout.FillColor = Color.FromArgb(239, 68, 68)
        btnLogout.ShadowDecoration.Depth = 10
    End Sub

    Private Sub btnGenerateReport_MouseEnter(sender As Object, e As EventArgs) Handles btnGenerateReport.MouseEnter
        btnGenerateReport.FillColor = Color.FromArgb(245, 185, 70)
        btnGenerateReport.ShadowDecoration.Depth = 18
    End Sub

    Private Sub btnGenerateReport_MouseLeave(sender As Object, e As EventArgs) Handles btnGenerateReport.MouseLeave
        btnGenerateReport.FillColor = Color.FromArgb(255, 200, 87)
        btnGenerateReport.ShadowDecoration.Depth = 12
    End Sub

    Private Sub btnExportCsv_MouseEnter(sender As Object, e As EventArgs) Handles btnExportCsv.MouseEnter
        btnExportCsv.FillColor = Color.FromArgb(21, 118, 92)
        btnExportCsv.ShadowDecoration.Depth = 15
    End Sub

    Private Sub btnExportCsv_MouseLeave(sender As Object, e As EventArgs) Handles btnExportCsv.MouseLeave
        btnExportCsv.FillColor = Color.FromArgb(31, 138, 112)
        btnExportCsv.ShadowDecoration.Depth = 10
    End Sub

    Private Sub btnExportPdf_MouseEnter(sender As Object, e As EventArgs) Handles btnExportPdf.MouseEnter
        btnExportPdf.FillColor = Color.FromArgb(220, 38, 38)
        btnExportPdf.ShadowDecoration.Depth = 15
    End Sub

    Private Sub btnExportPdf_MouseLeave(sender As Object, e As EventArgs) Handles btnExportPdf.MouseLeave
        btnExportPdf.FillColor = Color.FromArgb(239, 68, 68)
        btnExportPdf.ShadowDecoration.Depth = 10
    End Sub

    Private Sub btnPrint_MouseEnter(sender As Object, e As EventArgs) Handles btnPrint.MouseEnter
        btnPrint.FillColor = Color.FromArgb(107, 114, 128)
        btnPrint.ShadowDecoration.Depth = 15
    End Sub

    Private Sub btnPrint_MouseLeave(sender As Object, e As EventArgs) Handles btnPrint.MouseLeave
        btnPrint.FillColor = Color.FromArgb(156, 163, 175)
        btnPrint.ShadowDecoration.Depth = 10
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
    End Sub

    ' Keep legacy LoadTransactionDetails method for compatibility
    Public Sub LoadTransactionDetails(connection As MySqlConnection, ByVal pnl As Panel)
        Try
            Dim flow As FlowLayoutPanel = pnl.Controls.OfType(Of FlowLayoutPanel)().FirstOrDefault(Function(f) f.Name = "flowRecentTransactions")

            If flow Is Nothing Then
                flow = New FlowLayoutPanel With {
                    .Name = "flowRecentTransactions",
                    .Location = New Point(25, 75),
                    .Size = New Size(1430, 320),
                    .AutoScroll = False,
                    .FlowDirection = FlowDirection.LeftToRight,
                    .WrapContents = True,
                    .Padding = New Padding(12),
                    .BackColor = Color.Transparent
                }
                pnl.Controls.Add(flow)
                flow.BringToFront()
            Else
                flow.Controls.Clear()
            End If

            Dim query As String = "SELECT id, order_date AS `date`, order_time AS `time`, username AS `user`, total_amount AS `amount` " &
                                  "FROM orders " &
                                  "WHERE order_date >= @dateFrom AND order_date <= @dateTo " &
                                  "ORDER BY order_date DESC, order_time DESC LIMIT 10;"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim orderId As Integer = Convert.ToInt32(reader("id"))

                        Dim card As New Guna2ShadowPanel With {
                            .Width = 280,
                            .Height = 140,
                            .FillColor = Color.White,
                            .Margin = New Padding(12),
                            .Padding = New Padding(18),
                            .ShadowColor = Color.Black,
                            .ShadowDepth = 10,
                            .ShadowShift = 3,
                            .Radius = 15,
                            .Tag = orderId,
                            .Cursor = Cursors.Hand
                        }

                        ' Add click handler to card for viewing receipt
                        AddHandler card.Click, Sub(s, ev) ShowReceiptForOrder(orderId)

                        Dim lblDate As New Label With {
                            .AutoSize = True,
                            .Text = Convert.ToDateTime(reader("date")).ToString("dd/MM/yyyy") & "  " & reader("time").ToString(),
                            .Font = New Font("Segoe UI", 9.5F, FontStyle.Regular),
                            .ForeColor = Color.FromArgb(120, 120, 120),
                            .Location = New Point(12, 12)
                        }

                        Dim lblUser As New Label With {
                            .AutoSize = True,
                            .Text = "👤 " & reader("user").ToString(),
                            .Font = New Font("Segoe UI Semibold", 11, FontStyle.Bold),
                            .ForeColor = Color.FromArgb(30, 30, 30),
                            .Location = New Point(12, 40)
                        }

                        Dim lblAmount As New Label With {
                            .AutoSize = False,
                            .Size = New Size(card.Width - 24, 35),
                            .Text = "₱" & Convert.ToDecimal(reader("amount")).ToString("N2"),
                            .Font = New Font("Segoe UI", 15, FontStyle.Bold),
                            .ForeColor = Color.FromArgb(31, 138, 112),
                            .TextAlign = ContentAlignment.MiddleRight,
                            .Location = New Point(12, 72)
                        }

                        Dim lblClickHint As New Label With {
                            .AutoSize = True,
                            .Text = "📄 Click to view receipt",
                            .Font = New Font("Segoe UI", 8.0F, FontStyle.Italic),
                            .ForeColor = Color.FromArgb(150, 150, 150),
                            .Location = New Point(12, 112)
                        }

                        card.Controls.Add(lblDate)
                        card.Controls.Add(lblUser)
                        card.Controls.Add(lblAmount)
                        card.Controls.Add(lblClickHint)

                        flow.Controls.Add(card)
                    End While
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class