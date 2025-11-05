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
''' Converted to a UserControl for embedding inside Admin
''' </summary>
Public Class SalesReport
    Inherits UserControl

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
        Try
            ' If hosted inside a Form, create AdminNavButtons with the parent form (only if parent is Admin)
            Dim parentForm As Form = Me.FindForm()
            If parentForm IsNot Nothing Then
                If TypeOf parentForm Is Admin Then
                    navButtons = New AdminNavButtons(parentForm, btnLogout, btnBack, Nothing, Nothing)
                End If
                ' Inherit scaling/layout from parent for better responsiveness when embedded
                Me.AutoScaleMode = AutoScaleMode.Inherit

                ' Make the user control fill its container when used inside Admin
                Me.Dock = DockStyle.Fill
            Else
                ' Designer or standalone load
                Me.AutoScaleMode = AutoScaleMode.Font
            End If

            ' Ensure chart panels fill container when hosted
            chartDailySales = Nothing
            chartTopItems = Nothing
            chartRevenueTrend = Nothing

            ' --- Date Picker Logic ---

            ' Define yesterday as the maximum allowed date
            Dim maxSelectableDate As DateTime = DateTime.Today.AddDays(0)

            ' Define the absolute minimum (floor) date: August 1, 2025
            Dim minSelectableDate As DateTime = New DateTime(2025, 8, 1)

            ' 1. Set the "To" date picker
            dtpTo.MaxDate = maxSelectableDate  ' Max selectable date is yesterday
            dtpTo.Value = maxSelectableDate    ' Default value is yesterday

            ' 2. Set the "From" date picker
            dtpFrom.MaxDate = dtpTo.Value      ' Max selectable date is the current "To" date
            dtpFrom.MinDate = minSelectableDate ' Set the absolute minimum date

            ' Calculate default "From" (30 days before "To")
            Dim defaultFromDate As DateTime = dtpTo.Value.AddDays(-30)

            ' If default "From" is before our new floor, use the floor date instead
            If defaultFromDate < minSelectableDate Then
                dtpFrom.Value = minSelectableDate
            Else
                dtpFrom.Value = defaultFromDate
            End If

            ' 3. Set MinDate for "To" to prevent picking a date before "From"
            ' This must be set *after* dtpFrom.Value is finalized
            dtpTo.MinDate = dtpFrom.Value

            ' 4. Add handlers to link the date pickers
            AddHandler dtpFrom.ValueChanged, AddressOf dtpFrom_ValueChanged
            AddHandler dtpTo.ValueChanged, AddressOf dtpTo_ValueChanged

            InitializeCharts()
            ShowLoadingState()
            GenerateSalesReport()
            HideLoadingState()
        Catch ex As Exception
            MessageBox.Show("Error initializing SalesReport control: " & ex.Message, "Initialization Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== DATEPICKER VALIDATION HANDLERS =====

    ''' <summary>
    ''' When "From" date changes, set the "To" date's minimum to match it.
    ''' </summary>
    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs)
        ' Ensure "To" date cannot be before "From" date
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    ''' <summary>
    ''' When "To" date changes, set the "From" date's maximum to match it.
    ''' </summary>
    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs)
        ' Ensure "From" date cannot be after "To" date
        dtpFrom.MaxDate = dtpTo.Value
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
            ' Ignore header/invalid clicks
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

            Dim viewCol = dgvTransactions.Columns("colViewReceipt")
            If viewCol Is Nothing Then Return

            If e.ColumnIndex = viewCol.Index Then
                Dim cellVal = dgvTransactions.Rows(e.RowIndex).Cells("colOrderId").Value
                If cellVal Is Nothing OrElse String.IsNullOrWhiteSpace(cellVal.ToString()) Then
                    MessageBox.Show("Order id not found for this row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim orderId As Integer = Convert.ToInt32(cellVal)
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
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                ' Load header info from orders table (do not rely only on transactionData)
                Dim headerQuery As String = "SELECT id, order_date, order_time, username, total_amount FROM orders WHERE id = @orderId LIMIT 1"
                Dim orderDate As DateTime = DateTime.Now
                Dim username As String = ""
                Dim finalTotalAmount As Decimal = 0D ' This is the FINAL total

                Using hdrCmd As New MySqlCommand(headerQuery, connection)
                    hdrCmd.Parameters.AddWithValue("@orderId", orderId)
                    Using rdr As MySqlDataReader = hdrCmd.ExecuteReader()
                        If rdr.Read() Then
                            orderDate = If(IsDBNull(rdr("order_date")), DateTime.Now, Convert.ToDateTime(rdr("order_date")))
                            username = If(IsDBNull(rdr("username")), "", rdr("username").ToString())
                            finalTotalAmount = If(IsDBNull(rdr("total_amount")), 0D, Convert.ToDecimal(rdr("total_amount")))
                        Else
                            MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using
                End Using

                ' Load order_items
                Dim items As New List(Of OrderItem)
                Dim itemsQuery As String = "SELECT item_name, quantity, price FROM order_items WHERE order_id = @orderId"

                Using itemsCmd As New MySqlCommand(itemsQuery, connection)
                    itemsCmd.Parameters.AddWithValue("@orderId", orderId)
                    Using rdr As MySqlDataReader = itemsCmd.ExecuteReader()
                        While rdr.Read()
                            Dim it As New OrderItem With {
                            .ItemName = If(IsDBNull(rdr("item_name")), "",
rdr("item_name").ToString()),
                            .Quantity = If(IsDBNull(rdr("quantity")), 0, Convert.ToInt32(rdr("quantity"))),
                            .Price = If(IsDBNull(rdr("price")), 0D, Convert.ToDecimal(rdr("price"))),
                            .Total = If(IsDBNull(rdr("quantity")), 0, Convert.ToInt32(rdr("quantity"))) * If(IsDBNull(rdr("price")), 0D,
Convert.ToDecimal(rdr("price")))
                        }
                            items.Add(it)
                        End While
                    End Using
                End Using

                ' --- MODIFICATION START ---
                ' We must recalculate the Subtotal and Discount from the items,
                ' as this data is not stored in your 'orders' table.

                Dim calculatedSubtotal As Decimal = 0D
                For Each it In items
                    calculatedSubtotal += it.Total
                Next

                Dim discountAmount As Decimal = calculatedSubtotal - finalTotalAmount
                Dim discountPercent As Double = 0D

                If calculatedSubtotal > 0 Then
                    ' Calculate the percentage
                    discountPercent = (CDbl(discountAmount) / CDbl(calculatedSubtotal)) * 100D
                End If
                ' --- MODIFICATION END ---


                ' Build orderData (NOW WITH CORRECT VALUES)
                Dim orderData As New Receipt.OrderData With {
                .OrderId = orderId.ToString(),
                .OrderDate = orderDate,
        .CashierName = username,
                .Items = New List(Of Receipt.OrderItem),
                .Subtotal = calculatedSubtotal,  ' <-- FIXED
                .DiscountPercent = discountPercent, ' <-- FIXED
                .Total = finalTotalAmount,
                .PaymentMethod = "Cash" ' <-- Assuming 'Cash'
    }

                For Each it In items
                    orderData.Items.Add(New Receipt.OrderItem With {
                    .Name = it.ItemName,
            .Amount = it.Quantity,
                    .Price = it.Price,
                    .Total = it.Total
                })
                Next

                ' If no DB items, try to locate
                ' saved PDF named Receipt_{orderId}.pdf in Documents\Receipts (created by ordering form)
                Dim pdfPath As String = String.Empty
                ' --- MODIFICATION: Updated this logic to look for the correct file name ---
                Dim receiptsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Receipts")
                Dim candidate = Path.Combine(receiptsDir, "Receipt" & orderId.ToString() & ".pdf") ' <-- Fixed filename format

                If File.Exists(candidate) Then
                    pdfPath = candidate
                Else
                    ' try other common patterns (backup)
                    If Directory.Exists(receiptsDir) Then
                        Dim files = Directory.GetFiles(receiptsDir, "Receipt*" & orderId.ToString() & "*.pdf")
                        If files.Length > 0 Then pdfPath = files(0)
                    End If
                End If
                ' --- END MODIFICATION ---

                ' Show receipt: prefer native (items present) but pass pdfPath so pdf view is available
                Dim receiptForm As New Receipt()
                receiptForm.LoadReceipt(orderData, If(String.IsNullOrEmpty(pdfPath), String.Empty, pdfPath))

                ' Show as modal (without owner to avoid activation issues)
                receiptForm.ShowDialog()

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
            ' If hosted inside Admin, ask Admin to show audit view instead of creating new Admin instance
            Dim parentForm = Me.FindForm()
            If parentForm IsNot Nothing AndAlso TypeOf parentForm Is Admin Then
                DirectCast(parentForm, Admin).ShowAuditView()
                Return
            End If

            Dim admin As Admin = Nothing
            For Each f As Form In Application.OpenForms
                If TypeOf f Is Admin Then
                    admin = DirectCast(f, Admin)
                    Exit For
                End If
            Next

            If admin Is Nothing Then
                admin = New Admin()
                admin.Show()
            Else
                If admin.WindowState = FormWindowState.Minimized Then
                    admin.WindowState = FormWindowState.Normal
                End If
                admin.Show()
                admin.BringToFront()
                admin.Focus()
            End If

            ' If embedded, remove the control from its parent (do not call Close on a UserControl)
            If Me.Parent IsNot Nothing Then
                Me.Parent.Controls.Remove(Me)
            End If

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

    ' Add this public method to allow external controls to request a refresh
    Public Sub RefreshReport()
        Try
            ShowLoadingState()
            GenerateSalesReport()
            HideLoadingState()
        Catch ex As Exception
            ' non-fatal: show the error so developer knows why refresh failed
            MessageBox.Show("Error refreshing sales report: " & ex.Message, "Refresh Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class