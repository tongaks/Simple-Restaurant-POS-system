<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesReport
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnBack As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents btnLogout As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents pnlControls As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnPrint As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportPdf As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportCsv As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnGenerateReport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dtpTo As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents dtpFrom As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlMetrics As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents cardAvgOrder As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label10 As Label
    Friend WithEvents lblAvgOrder As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cardOrderCount As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents lblOrderCount As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cardTotalSales As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblTotalsalesicon As Label
    Friend WithEvents lblTotalSales As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlCharts As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlRevenueChart As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlTopItemsChart As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlDailySalesChart As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlTransactions As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dgvTransactions As DataGridView
    Friend WithEvents lblTransactions As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        lblTitle = New Label()
        btnBack = New Guna.UI2.WinForms.Guna2CircleButton()
        btnLogout = New Guna.UI2.WinForms.Guna2CircleButton()
        pnlControls = New Guna.UI2.WinForms.Guna2Panel()
        btnPrint = New Guna.UI2.WinForms.Guna2Button()
        btnExportPdf = New Guna.UI2.WinForms.Guna2Button()
        btnExportCsv = New Guna.UI2.WinForms.Guna2Button()
        btnGenerateReport = New Guna.UI2.WinForms.Guna2Button()
        dtpTo = New Guna.UI2.WinForms.Guna2DateTimePicker()
        dtpFrom = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Label2 = New Label()
        Label1 = New Label()
        pnlMetrics = New Guna.UI2.WinForms.Guna2Panel()
        cardAvgOrder = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Label10 = New Label()
        lblAvgOrder = New Label()
        Label8 = New Label()
        cardOrderCount = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Label9 = New Label()
        lblOrderCount = New Label()
        Label6 = New Label()
        cardTotalSales = New Guna.UI2.WinForms.Guna2ShadowPanel()
        lblTotalsalesicon = New Label()
        lblTotalSales = New Label()
        Label3 = New Label()
        pnlCharts = New Guna.UI2.WinForms.Guna2Panel()
        pnlRevenueChart = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Label7 = New Label()
        pnlTopItemsChart = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Label5 = New Label()
        pnlDailySalesChart = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Label4 = New Label()
        pnlTransactions = New Guna.UI2.WinForms.Guna2Panel()
        dgvTransactions = New DataGridView()
        lblTransactions = New Label()

        pnlHeader.SuspendLayout()
        pnlControls.SuspendLayout()
        pnlMetrics.SuspendLayout()
        cardAvgOrder.SuspendLayout()
        cardOrderCount.SuspendLayout()
        cardTotalSales.SuspendLayout()
        pnlCharts.SuspendLayout()
        pnlRevenueChart.SuspendLayout()
        pnlTopItemsChart.SuspendLayout()
        pnlDailySalesChart.SuspendLayout()
        pnlTransactions.SuspendLayout()
        CType(dgvTransactions, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()

        ' ===== pnlHeader =====
        pnlHeader.BackColor = Theme.SecondaryAccent
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(btnBack)
        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1400, 80)
        pnlHeader.TabIndex = 0
        pnlHeader.ShadowDecoration.Enabled = True
        pnlHeader.ShadowDecoration.Depth = 5

        ' ===== lblTitle =====
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(12, 18)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(325, 54)
        lblTitle.TabIndex = 0
        lblTitle.Text = "📊 Sales Report"

        ' ===== btnBack (Circular icon button) =====
        btnBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnBack.FillColor = Theme.PrimaryAccent
        btnBack.Font = New Font("Segoe UI Symbol", 16.0F, FontStyle.Bold)
        btnBack.ForeColor = Theme.DarkText
        btnBack.Location = New Point(1249, 15)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(50, 50)
        btnBack.TabIndex = 1
        btnBack.Text = "◄"
        btnBack.ShadowDecoration.Enabled = True
        btnBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle

        ' ===== btnLogout (Circular icon button) =====
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.FillColor = Color.FromArgb(220, 38, 38)
        btnLogout.Font = New Font("Segoe UI Symbol", 16.0F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(1315, 15)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(50, 50)
        btnLogout.TabIndex = 2
        btnLogout.Text = "⏻"
        btnLogout.ShadowDecoration.Enabled = True
        btnLogout.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle

        ' ===== pnlControls =====
        pnlControls.BackColor = Theme.WhiteSurface
        pnlControls.BorderColor = Theme.LightBorder
        pnlControls.Controls.Add(btnPrint)
        pnlControls.Controls.Add(btnExportPdf)
        pnlControls.Controls.Add(btnExportCsv)
        pnlControls.Controls.Add(btnGenerateReport)
        pnlControls.Controls.Add(dtpTo)
        pnlControls.Controls.Add(dtpFrom)
        pnlControls.Controls.Add(Label2)
        pnlControls.Controls.Add(Label1)
        pnlControls.Dock = DockStyle.Top
        pnlControls.Location = New Point(0, 80)
        pnlControls.Name = "pnlControls"
        pnlControls.Padding = New Padding(20, 15, 20, 15)
        pnlControls.Size = New Size(1400, 80)
        pnlControls.TabIndex = 1

        ' ===== Label1 =====
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label1.ForeColor = Theme.DarkText
        Label1.Location = New Point(30, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 23)
        Label1.TabIndex = 0
        Label1.Text = "From:"

        ' ===== dtpFrom =====
        dtpFrom.BorderRadius = Theme.DefaultBorderRadius
        dtpFrom.Checked = True
        dtpFrom.FillColor = Theme.WhiteSurface
        dtpFrom.Font = New Font("Segoe UI", 10.0F)
        dtpFrom.Format = DateTimePickerFormat.Short
        dtpFrom.Location = New Point(100, 25)
        dtpFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        dtpFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(150, 30)
        dtpFrom.TabIndex = 1
        dtpFrom.Value = New Date(2025, 10, 26, 0, 0, 0, 0)

        ' ===== Label2 =====
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label2.ForeColor = Theme.DarkText
        Label2.Location = New Point(280, 30)
        Label2.Name = "Label2"
        Label2.Size = New Size(33, 23)
        Label2.TabIndex = 2
        Label2.Text = "To:"

        ' ===== dtpTo =====
        dtpTo.BorderRadius = Theme.DefaultBorderRadius
        dtpTo.Checked = True
        dtpTo.FillColor = Theme.WhiteSurface
        dtpTo.Font = New Font("Segoe UI", 10.0F)
        dtpTo.Format = DateTimePickerFormat.Short
        dtpTo.Location = New Point(330, 25)
        dtpTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        dtpTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(150, 30)
        dtpTo.TabIndex = 3
        dtpTo.Value = New Date(2025, 10, 26, 0, 0, 0, 0)

        ' ===== btnGenerateReport =====
        btnGenerateReport.BorderRadius = Theme.DefaultBorderRadius
        btnGenerateReport.Cursor = Cursors.Hand
        btnGenerateReport.FillColor = Theme.SecondaryAccent
        btnGenerateReport.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnGenerateReport.ForeColor = Color.White
        btnGenerateReport.Location = New Point(520, 20)
        btnGenerateReport.Name = "btnGenerateReport"
        btnGenerateReport.Size = New Size(179, 40)
        btnGenerateReport.TabIndex = 4
        btnGenerateReport.Text = "Generate Report"
        Theme.ApplySecondaryButton(btnGenerateReport)

        ' ===== btnExportCsv =====
        btnExportCsv.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportCsv.BorderRadius = Theme.DefaultBorderRadius
        btnExportCsv.Cursor = Cursors.Hand
        btnExportCsv.FillColor = Theme.PrimaryAccent
        btnExportCsv.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnExportCsv.ForeColor = Theme.DarkText
        btnExportCsv.Location = New Point(1070, 20)
        btnExportCsv.Name = "btnExportCsv"
        btnExportCsv.Size = New Size(90, 40)
        btnExportCsv.TabIndex = 5
        btnExportCsv.Text = "📊 CSV"

        ' ===== btnExportPdf =====
        btnExportPdf.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportPdf.BorderRadius = Theme.DefaultBorderRadius
        btnExportPdf.Cursor = Cursors.Hand
        btnExportPdf.FillColor = Color.FromArgb(239, 68, 68)
        btnExportPdf.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnExportPdf.ForeColor = Color.White
        btnExportPdf.Location = New Point(1175, 20)
        btnExportPdf.Name = "btnExportPdf"
        btnExportPdf.Size = New Size(90, 40)
        btnExportPdf.TabIndex = 6
        btnExportPdf.Text = "📄 PDF"

        ' ===== btnPrint =====
        btnPrint.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnPrint.BorderRadius = Theme.DefaultBorderRadius
        btnPrint.BorderColor = Theme.LightBorder
        btnPrint.BorderThickness = 2
        btnPrint.Cursor = Cursors.Hand
        btnPrint.FillColor = Color.Transparent
        btnPrint.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnPrint.ForeColor = Theme.GrayText
        btnPrint.Location = New Point(1280, 20)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(90, 40)
        btnPrint.TabIndex = 7
        btnPrint.Text = "🖨️ Print"
        Theme.ApplyOutlinedButton(btnPrint, False)

        ' ===== pnlMetrics =====
        pnlMetrics.BackColor = Theme.NeutralBackground
        pnlMetrics.Controls.Add(cardAvgOrder)
        pnlMetrics.Controls.Add(cardOrderCount)
        pnlMetrics.Controls.Add(cardTotalSales)
        pnlMetrics.Dock = DockStyle.Top
        pnlMetrics.Location = New Point(0, 160)
        pnlMetrics.Name = "pnlMetrics"
        pnlMetrics.Padding = New Padding(20, 20, 20, 10)
        pnlMetrics.Size = New Size(1400, 160)
        pnlMetrics.TabIndex = 2

        ' ===== cardTotalSales =====
        cardTotalSales.BackColor = Color.Transparent
        cardTotalSales.Controls.Add(lblTotalsalesicon)
        cardTotalSales.Controls.Add(lblTotalSales)
        cardTotalSales.Controls.Add(Label3)
        cardTotalSales.FillColor = Theme.WhiteSurface
        cardTotalSales.Location = New Point(40, 30)
        cardTotalSales.Name = "cardTotalSales"
        cardTotalSales.Padding = New Padding(20, 15, 20, 15)
        cardTotalSales.Radius = Theme.DefaultBorderRadius
        cardTotalSales.ShadowColor = Color.Black
        cardTotalSales.ShadowDepth = Theme.CardShadowDepth
        cardTotalSales.ShadowShift = 3
        cardTotalSales.Size = New Size(400, 110)
        cardTotalSales.TabIndex = 0

        ' ===== lblTotalsalesicon =====
        lblTotalsalesicon.AutoSize = True
        lblTotalsalesicon.Font = New Font("Segoe UI", 32.0F)
        lblTotalsalesicon.ForeColor = Theme.SecondaryAccent
        lblTotalsalesicon.Location = New Point(15, 25)
        lblTotalsalesicon.Name = "lblTotalsalesicon"
        lblTotalsalesicon.Size = New Size(80, 72)
        lblTotalsalesicon.TabIndex = 0
        lblTotalsalesicon.Text = "💰"

        ' ===== Label3 =====
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 13.0F, FontStyle.Bold)
        Label3.ForeColor = Theme.GrayText
        Label3.Location = New Point(110, 20)
        Label3.Name = "Label3"
        Label3.Size = New Size(118, 30)
        Label3.TabIndex = 1
        Label3.Text = "Total Sales"

        ' ===== lblTotalSales =====
        lblTotalSales.AutoSize = True
        lblTotalSales.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblTotalSales.ForeColor = Theme.SecondaryAccent
        lblTotalSales.Location = New Point(110, 50)
        lblTotalSales.Name = "lblTotalSales"
        lblTotalSales.Size = New Size(68, 50)
        lblTotalSales.TabIndex = 2
        lblTotalSales.Text = "₱0"

        ' ===== cardOrderCount =====
        cardOrderCount.BackColor = Color.Transparent
        cardOrderCount.Controls.Add(Label9)
        cardOrderCount.Controls.Add(lblOrderCount)
        cardOrderCount.Controls.Add(Label6)
        cardOrderCount.FillColor = Theme.WhiteSurface
        cardOrderCount.Location = New Point(490, 30)
        cardOrderCount.Name = "cardOrderCount"
        cardOrderCount.Padding = New Padding(20, 15, 20, 15)
        cardOrderCount.Radius = Theme.DefaultBorderRadius
        cardOrderCount.ShadowColor = Color.Black
        cardOrderCount.ShadowDepth = Theme.CardShadowDepth
        cardOrderCount.ShadowShift = 3
        cardOrderCount.Size = New Size(400, 110)
        cardOrderCount.TabIndex = 1

        ' ===== Label9 =====
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 32.0F)
        Label9.ForeColor = Theme.PrimaryAccent
        Label9.Location = New Point(15, 25)
        Label9.Name = "Label9"
        Label9.Size = New Size(80, 72)
        Label9.TabIndex = 0
        Label9.Text = "📈"

        ' ===== Label6 =====
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 13.0F, FontStyle.Bold)
        Label6.ForeColor = Theme.GrayText
        Label6.Location = New Point(110, 20)
        Label6.Name = "Label6"
        Label6.Size = New Size(135, 30)
        Label6.TabIndex = 1
        Label6.Text = "Order Count"

        ' ===== lblOrderCount =====
        lblOrderCount.AutoSize = True
        lblOrderCount.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblOrderCount.ForeColor = Theme.PrimaryAccent
        lblOrderCount.Location = New Point(110, 50)
        lblOrderCount.Name = "lblOrderCount"
        lblOrderCount.Size = New Size(43, 50)
        lblOrderCount.TabIndex = 2
        lblOrderCount.Text = "0"

        ' ===== cardAvgOrder =====
        cardAvgOrder.BackColor = Color.Transparent
        cardAvgOrder.Controls.Add(Label10)
        cardAvgOrder.Controls.Add(lblAvgOrder)
        cardAvgOrder.Controls.Add(Label8)
        cardAvgOrder.FillColor = Theme.WhiteSurface
        cardAvgOrder.Location = New Point(940, 30)
        cardAvgOrder.Name = "cardAvgOrder"
        cardAvgOrder.Padding = New Padding(20, 15, 20, 15)
        cardAvgOrder.Radius = Theme.DefaultBorderRadius
        cardAvgOrder.ShadowColor = Color.Black
        cardAvgOrder.ShadowDepth = Theme.CardShadowDepth
        cardAvgOrder.ShadowShift = 3
        cardAvgOrder.Size = New Size(400, 110)
        cardAvgOrder.TabIndex = 2

        ' ===== Label10 =====
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 32.0F)
        Label10.ForeColor = Color.FromArgb(100, 149, 237)
        Label10.Location = New Point(15, 25)
        Label10.Name = "Label10"
        Label10.Size = New Size(80, 72)
        Label10.TabIndex = 0
        Label10.Text = "🛍️"

        ' ===== Label8 =====
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Semibold", 13.0F, FontStyle.Bold)
        Label8.ForeColor = Theme.GrayText
        Label8.Location = New Point(110, 20)
        Label8.Name = "Label8"
        Label8.Size = New Size(157, 30)
        Label8.TabIndex = 1
        Label8.Text = "Average Order"

        ' ===== lblAvgOrder =====
        lblAvgOrder.AutoSize = True
        lblAvgOrder.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblAvgOrder.ForeColor = Color.FromArgb(100, 149, 237)
        lblAvgOrder.Location = New Point(110, 50)
        lblAvgOrder.Name = "lblAvgOrder"
        lblAvgOrder.Size = New Size(68, 50)
        lblAvgOrder.TabIndex = 2
        lblAvgOrder.Text = "₱0"

        ' ===== pnlCharts =====
        pnlCharts.BackColor = Theme.NeutralBackground
        pnlCharts.Controls.Add(pnlRevenueChart)
        pnlCharts.Controls.Add(pnlTopItemsChart)
        pnlCharts.Controls.Add(pnlDailySalesChart)
        pnlCharts.Dock = DockStyle.Top
        pnlCharts.Location = New Point(0, 320)
        pnlCharts.Name = "pnlCharts"
        pnlCharts.Padding = New Padding(20, 10, 20, 10)
        pnlCharts.Size = New Size(1400, 400)
        pnlCharts.TabIndex = 3

        ' ===== pnlDailySalesChart =====
        pnlDailySalesChart.BackColor = Color.Transparent
        pnlDailySalesChart.Controls.Add(Label4)
        pnlDailySalesChart.Dock = DockStyle.Left
        pnlDailySalesChart.FillColor = Theme.WhiteSurface
        pnlDailySalesChart.Location = New Point(20, 10)
        pnlDailySalesChart.Name = "pnlDailySalesChart"
        pnlDailySalesChart.Padding = New Padding(10)
        pnlDailySalesChart.Radius = Theme.DefaultBorderRadius
        pnlDailySalesChart.ShadowColor = Color.Black
        pnlDailySalesChart.ShadowDepth = Theme.CardShadowDepth
        pnlDailySalesChart.ShadowShift = 3
        pnlDailySalesChart.Size = New Size(450, 380)
        pnlDailySalesChart.TabIndex = 0

        ' ===== Label4 =====
        Label4.BackColor = Theme.SecondaryAccent
        Label4.Dock = DockStyle.Top
        Label4.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(10, 10)
        Label4.Name = "Label4"
        Label4.Padding = New Padding(10, 5, 10, 5)
        Label4.Size = New Size(430, 40)
        Label4.TabIndex = 0
        Label4.Text = "📊 Daily Sales"
        Label4.TextAlign = ContentAlignment.MiddleLeft

        ' ===== pnlTopItemsChart =====
        pnlTopItemsChart.BackColor = Color.Transparent
        pnlTopItemsChart.Controls.Add(Label5)
        pnlTopItemsChart.Dock = DockStyle.Left
        pnlTopItemsChart.FillColor = Theme.WhiteSurface
        pnlTopItemsChart.Location = New Point(470, 10)
        pnlTopItemsChart.Name = "pnlTopItemsChart"
        pnlTopItemsChart.Padding = New Padding(10)
        pnlTopItemsChart.Radius = Theme.DefaultBorderRadius
        pnlTopItemsChart.ShadowColor = Color.Black
        pnlTopItemsChart.ShadowDepth = Theme.CardShadowDepth
        pnlTopItemsChart.ShadowShift = 3
        pnlTopItemsChart.Size = New Size(450, 380)
        pnlTopItemsChart.TabIndex = 1

        ' ===== Label5 =====
        Label5.BackColor = Theme.PrimaryAccent
        Label5.Dock = DockStyle.Top
        Label5.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Label5.ForeColor = Theme.DarkText
        Label5.Location = New Point(10, 10)
        Label5.Name = "Label5"
        Label5.Padding = New Padding(10, 5, 10, 5)
        Label5.Size = New Size(430, 40)
        Label5.TabIndex = 0
        Label5.Text = "🏆 Top 5 Items"
        Label5.TextAlign = ContentAlignment.MiddleLeft

        ' ===== pnlRevenueChart =====
        pnlRevenueChart.BackColor = Color.Transparent
        pnlRevenueChart.Controls.Add(Label7)
        pnlRevenueChart.Dock = DockStyle.Fill
        pnlRevenueChart.FillColor = Theme.WhiteSurface
        pnlRevenueChart.Location = New Point(920, 10)
        pnlRevenueChart.Name = "pnlRevenueChart"
        pnlRevenueChart.Padding = New Padding(10)
        pnlRevenueChart.Radius = Theme.DefaultBorderRadius
        pnlRevenueChart.ShadowColor = Color.Black
        pnlRevenueChart.ShadowDepth = Theme.CardShadowDepth
        pnlRevenueChart.ShadowShift = 3
        pnlRevenueChart.Size = New Size(460, 380)
        pnlRevenueChart.TabIndex = 2

        ' ===== Label7 =====
        Label7.BackColor = Color.FromArgb(100, 149, 237)
        Label7.Dock = DockStyle.Top
        Label7.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(10, 10)
        Label7.Name = "Label7"
        Label7.Padding = New Padding(10, 5, 10, 5)
        Label7.Size = New Size(440, 40)
        Label7.TabIndex = 0
        Label7.Text = "📈 Revenue Trend"
        Label7.TextAlign = ContentAlignment.MiddleLeft

        ' ===== pnlTransactions =====
        pnlTransactions.BackColor = Theme.NeutralBackground
        pnlTransactions.Controls.Add(dgvTransactions)
        pnlTransactions.Controls.Add(lblTransactions)
        pnlTransactions.Dock = DockStyle.Fill
        pnlTransactions.Location = New Point(0, 720)
        pnlTransactions.Name = "pnlTransactions"
        pnlTransactions.Padding = New Padding(20)
        pnlTransactions.Size = New Size(1400, 335)
        pnlTransactions.TabIndex = 4

        ' ===== lblTransactions =====
        lblTransactions.BackColor = Theme.SecondaryAccent
        lblTransactions.Dock = DockStyle.Top
        lblTransactions.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblTransactions.ForeColor = Color.White
        lblTransactions.Location = New Point(20, 20)
        lblTransactions.Name = "lblTransactions"
        lblTransactions.Padding = New Padding(10)
        lblTransactions.Size = New Size(1360, 45)
        lblTransactions.TabIndex = 0
        lblTransactions.Text = "📋 Recent Transactions"
        lblTransactions.TextAlign = ContentAlignment.MiddleLeft

        ' ===== dgvTransactions =====
        dgvTransactions.AllowUserToAddRows = False
        dgvTransactions.AllowUserToDeleteRows = False
        dgvTransactions.BackgroundColor = Theme.WhiteSurface
        dgvTransactions.BorderStyle = BorderStyle.None
        dgvTransactions.ColumnHeadersHeight = 35
        dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvTransactions.Dock = DockStyle.Fill
        dgvTransactions.GridColor = Theme.LightBorder
        dgvTransactions.Location = New Point(20, 65)
        dgvTransactions.Name = "dgvTransactions"
        dgvTransactions.ReadOnly = True
        dgvTransactions.RowHeadersWidth = 51
        dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTransactions.Size = New Size(1360, 250)
        dgvTransactions.TabIndex = 1

        ' ===== SalesReport =====
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Theme.NeutralBackground
        ClientSize = New Size(1400, 1055)
        Controls.Add(pnlTransactions)
        Controls.Add(pnlCharts)
        Controls.Add(pnlMetrics)
        Controls.Add(pnlControls)
        Controls.Add(pnlHeader)
        Name = "SalesReport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Sales Report - OrderUp!"

        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlControls.ResumeLayout(False)
        pnlControls.PerformLayout()
        pnlMetrics.ResumeLayout(False)
        cardAvgOrder.ResumeLayout(False)
        cardAvgOrder.PerformLayout()
        cardOrderCount.ResumeLayout(False)
        cardOrderCount.PerformLayout()
        cardTotalSales.ResumeLayout(False)
        cardTotalSales.PerformLayout()
        pnlCharts.ResumeLayout(False)
        pnlRevenueChart.ResumeLayout(False)
        pnlTopItemsChart.ResumeLayout(False)
        pnlDailySalesChart.ResumeLayout(False)
        pnlTransactions.ResumeLayout(False)
        CType(dgvTransactions, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
End Class