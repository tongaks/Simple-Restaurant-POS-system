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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        btnBack = New Button()
        btnLogout = New Button()
        pnlControls = New Panel()
        btnPrint = New Button()
        btnExportPdf = New Button()
        btnExportCsv = New Button()
        btnGenerateReport = New Button()
        dtpTo = New DateTimePicker()
        dtpFrom = New DateTimePicker()
        Label2 = New Label()
        Label1 = New Label()
        pnlMetrics = New Panel()
        pnlAvgOrder = New Panel()
        Label10 = New Label()
        lblAvgOrder = New Label()
        Label8 = New Label()
        pnlOrderCount = New Panel()
        Label9 = New Label()
        lblOrderCount = New Label()
        Label6 = New Label()
        pnlTotalSales = New Panel()
        lblTotalsalesicon = New Label()
        lblTotalSales = New Label()
        Label3 = New Label()
        pnlCharts = New Panel()
        pnlRevenueChart = New Panel()
        Label7 = New Label()
        pnlDailySalesChart = New Panel()
        Label4 = New Label()
        pnlTransactions = New Panel()
        dgvTransactions = New DataGridView()
        lblTransactions = New Label()
        pnlHeader.SuspendLayout()
        pnlControls.SuspendLayout()
        pnlMetrics.SuspendLayout()
        pnlAvgOrder.SuspendLayout()
        pnlOrderCount.SuspendLayout()
        pnlTotalSales.SuspendLayout()
        pnlCharts.SuspendLayout()
        pnlRevenueChart.SuspendLayout()
        pnlDailySalesChart.SuspendLayout()
        pnlTransactions.SuspendLayout()
        CType(dgvTransactions, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(180))
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(btnBack)
        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(3, 2, 3, 2)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1225, 60)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(10, 8)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(259, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "📊 Sales Report"
        ' 
        ' btnBack
        ' 
        btnBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnBack.BackColor = Color.SteelBlue
        btnBack.FlatAppearance.BorderColor = Color.SteelBlue
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnBack.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(192))
        btnBack.Location = New Point(1093, 6)
        btnBack.Margin = New Padding(3, 2, 3, 2)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(57, 46)
        btnBack.TabIndex = 1
        btnBack.Text = "➜]"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BackColor = Color.SteelBlue
        btnLogout.FlatAppearance.BorderColor = Color.SteelBlue
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Showcard Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogout.ForeColor = Color.Red
        btnLogout.Location = New Point(1160, 5)
        btnLogout.Margin = New Padding(3, 2, 3, 2)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(55, 46)
        btnLogout.TabIndex = 2
        btnLogout.Text = CStr(ChrW(9211))
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' pnlControls
        ' 
        pnlControls.BackColor = Color.WhiteSmoke
        pnlControls.BorderStyle = BorderStyle.FixedSingle
        pnlControls.Controls.Add(btnPrint)
        pnlControls.Controls.Add(btnExportPdf)
        pnlControls.Controls.Add(btnExportCsv)
        pnlControls.Controls.Add(btnGenerateReport)
        pnlControls.Controls.Add(dtpTo)
        pnlControls.Controls.Add(dtpFrom)
        pnlControls.Controls.Add(Label2)
        pnlControls.Controls.Add(Label1)
        pnlControls.Dock = DockStyle.Top
        pnlControls.Location = New Point(0, 60)
        pnlControls.Margin = New Padding(3, 2, 3, 2)
        pnlControls.Name = "pnlControls"
        pnlControls.Padding = New Padding(18, 11, 18, 11)
        pnlControls.Size = New Size(1225, 60)
        pnlControls.TabIndex = 1
        ' 
        ' btnPrint
        ' 
        btnPrint.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnPrint.BackColor = Color.FromArgb(CByte(189), CByte(189), CByte(189))
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnPrint.Location = New Point(1050, 15)
        btnPrint.Margin = New Padding(3, 2, 3, 2)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(105, 30)
        btnPrint.TabIndex = 7
        btnPrint.Text = "🖨️ Print"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' btnExportPdf
        ' 
        btnExportPdf.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportPdf.BackColor = Color.FromArgb(CByte(255), CByte(107), CByte(107))
        btnExportPdf.FlatStyle = FlatStyle.Flat
        btnExportPdf.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnExportPdf.ForeColor = Color.White
        btnExportPdf.Location = New Point(932, 15)
        btnExportPdf.Margin = New Padding(3, 2, 3, 2)
        btnExportPdf.Name = "btnExportPdf"
        btnExportPdf.Size = New Size(105, 30)
        btnExportPdf.TabIndex = 6
        btnExportPdf.Text = "📄 PDF"
        btnExportPdf.UseVisualStyleBackColor = False
        ' 
        ' btnExportCsv
        ' 
        btnExportCsv.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportCsv.BackColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnExportCsv.FlatStyle = FlatStyle.Flat
        btnExportCsv.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnExportCsv.ForeColor = Color.White
        btnExportCsv.Location = New Point(814, 15)
        btnExportCsv.Margin = New Padding(3, 2, 3, 2)
        btnExportCsv.Name = "btnExportCsv"
        btnExportCsv.Size = New Size(105, 30)
        btnExportCsv.TabIndex = 5
        btnExportCsv.Text = "📊 CSV"
        btnExportCsv.UseVisualStyleBackColor = False
        ' 
        ' btnGenerateReport
        ' 
        btnGenerateReport.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(180))
        btnGenerateReport.FlatStyle = FlatStyle.Flat
        btnGenerateReport.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnGenerateReport.ForeColor = Color.White
        btnGenerateReport.Location = New Point(455, 15)
        btnGenerateReport.Margin = New Padding(3, 2, 3, 2)
        btnGenerateReport.Name = "btnGenerateReport"
        btnGenerateReport.Size = New Size(157, 30)
        btnGenerateReport.TabIndex = 4
        btnGenerateReport.Text = "Generate Report"
        btnGenerateReport.UseVisualStyleBackColor = False
        ' 
        ' dtpTo
        ' 
        dtpTo.Font = New Font("Segoe UI", 10F)
        dtpTo.Format = DateTimePickerFormat.Short
        dtpTo.Location = New Point(289, 19)
        dtpTo.Margin = New Padding(3, 2, 3, 2)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(132, 25)
        dtpTo.TabIndex = 3
        ' 
        ' dtpFrom
        ' 
        dtpFrom.Font = New Font("Segoe UI", 10F)
        dtpFrom.Format = DateTimePickerFormat.Short
        dtpFrom.Location = New Point(88, 19)
        dtpFrom.Margin = New Padding(3, 2, 3, 2)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(132, 25)
        dtpFrom.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.Location = New Point(245, 22)
        Label2.Name = "Label2"
        Label2.Size = New Size(29, 19)
        Label2.TabIndex = 2
        Label2.Text = "To:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label1.Location = New Point(26, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(48, 19)
        Label1.TabIndex = 0
        Label1.Text = "From:"
        ' 
        ' pnlMetrics
        ' 
        pnlMetrics.BackColor = Color.White
        pnlMetrics.Controls.Add(pnlAvgOrder)
        pnlMetrics.Controls.Add(pnlOrderCount)
        pnlMetrics.Controls.Add(pnlTotalSales)
        pnlMetrics.Dock = DockStyle.Top
        pnlMetrics.Location = New Point(0, 120)
        pnlMetrics.Margin = New Padding(3, 2, 3, 2)
        pnlMetrics.Name = "pnlMetrics"
        pnlMetrics.Padding = New Padding(18, 15, 18, 8)
        pnlMetrics.Size = New Size(1225, 107)
        pnlMetrics.TabIndex = 2
        ' 
        ' pnlAvgOrder
        ' 
        pnlAvgOrder.BackColor = Color.FromArgb(CByte(255), CByte(218), CByte(185))
        pnlAvgOrder.BorderStyle = BorderStyle.FixedSingle
        pnlAvgOrder.Controls.Add(Label10)
        pnlAvgOrder.Controls.Add(lblAvgOrder)
        pnlAvgOrder.Controls.Add(Label8)
        pnlAvgOrder.Location = New Point(822, 22)
        pnlAvgOrder.Margin = New Padding(3, 2, 3, 2)
        pnlAvgOrder.Name = "pnlAvgOrder"
        pnlAvgOrder.Size = New Size(350, 76)
        pnlAvgOrder.TabIndex = 2
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 36F)
        Label10.ForeColor = Color.SaddleBrown
        Label10.Location = New Point(-1, 4)
        Label10.Name = "Label10"
        Label10.Size = New Size(94, 65)
        Label10.TabIndex = 2
        Label10.Text = "🛍️"
        ' 
        ' lblAvgOrder
        ' 
        lblAvgOrder.AutoSize = True
        lblAvgOrder.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblAvgOrder.ForeColor = Color.FromArgb(CByte(139), CByte(69), CByte(19))
        lblAvgOrder.Location = New Point(95, 26)
        lblAvgOrder.Name = "lblAvgOrder"
        lblAvgOrder.Size = New Size(58, 45)
        lblAvgOrder.TabIndex = 1
        lblAvgOrder.Text = "₱0"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Britannic Bold", 16.2F)
        Label8.ForeColor = Color.FromArgb(CByte(139), CByte(69), CByte(19))
        Label8.Location = New Point(99, 3)
        Label8.Name = "Label8"
        Label8.Size = New Size(151, 25)
        Label8.TabIndex = 0
        Label8.Text = "Average Order"
        ' 
        ' pnlOrderCount
        ' 
        pnlOrderCount.BackColor = Color.FromArgb(CByte(173), CByte(216), CByte(230))
        pnlOrderCount.BorderStyle = BorderStyle.FixedSingle
        pnlOrderCount.Controls.Add(Label9)
        pnlOrderCount.Controls.Add(lblOrderCount)
        pnlOrderCount.Controls.Add(Label6)
        pnlOrderCount.Location = New Point(429, 22)
        pnlOrderCount.Margin = New Padding(3, 2, 3, 2)
        pnlOrderCount.Name = "pnlOrderCount"
        pnlOrderCount.Size = New Size(350, 76)
        pnlOrderCount.TabIndex = 1
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 36F)
        Label9.ForeColor = Color.MidnightBlue
        Label9.Location = New Point(-4, 3)
        Label9.Name = "Label9"
        Label9.Size = New Size(91, 65)
        Label9.TabIndex = 2
        Label9.Text = "📈"
        ' 
        ' lblOrderCount
        ' 
        lblOrderCount.AutoSize = True
        lblOrderCount.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderCount.ForeColor = Color.FromArgb(CByte(25), CByte(25), CByte(112))
        lblOrderCount.Location = New Point(91, 26)
        lblOrderCount.Name = "lblOrderCount"
        lblOrderCount.Size = New Size(38, 45)
        lblOrderCount.TabIndex = 1
        lblOrderCount.Text = "0"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Britannic Bold", 16.2F)
        Label6.ForeColor = Color.FromArgb(CByte(25), CByte(25), CByte(112))
        Label6.Location = New Point(94, 2)
        Label6.Name = "Label6"
        Label6.Size = New Size(130, 25)
        Label6.TabIndex = 0
        Label6.Text = "Order Count"
        ' 
        ' pnlTotalSales
        ' 
        pnlTotalSales.BackColor = Color.PaleGreen
        pnlTotalSales.BorderStyle = BorderStyle.FixedSingle
        pnlTotalSales.Controls.Add(lblTotalsalesicon)
        pnlTotalSales.Controls.Add(lblTotalSales)
        pnlTotalSales.Controls.Add(Label3)
        pnlTotalSales.Location = New Point(35, 22)
        pnlTotalSales.Margin = New Padding(3, 2, 3, 2)
        pnlTotalSales.Name = "pnlTotalSales"
        pnlTotalSales.Size = New Size(350, 76)
        pnlTotalSales.TabIndex = 0
        ' 
        ' lblTotalsalesicon
        ' 
        lblTotalsalesicon.AutoSize = True
        lblTotalsalesicon.Font = New Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalsalesicon.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        lblTotalsalesicon.Location = New Point(-5, 3)
        lblTotalsalesicon.Name = "lblTotalsalesicon"
        lblTotalsalesicon.Size = New Size(94, 65)
        lblTotalsalesicon.TabIndex = 2
        lblTotalsalesicon.Text = "📶"
        lblTotalsalesicon.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblTotalSales
        ' 
        lblTotalSales.AutoSize = True
        lblTotalSales.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblTotalSales.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        lblTotalSales.Location = New Point(94, 32)
        lblTotalSales.Name = "lblTotalSales"
        lblTotalSales.Size = New Size(58, 45)
        lblTotalSales.TabIndex = 1
        lblTotalSales.Text = "₱0"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Britannic Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        Label3.Location = New Point(94, 7)
        Label3.Name = "Label3"
        Label3.Size = New Size(118, 25)
        Label3.TabIndex = 0
        Label3.Text = "Total Sales"
        ' 
        ' pnlCharts
        ' 
        pnlCharts.BackColor = Color.White
        pnlCharts.Controls.Add(pnlRevenueChart)
        pnlCharts.Controls.Add(pnlDailySalesChart)
        pnlCharts.Dock = DockStyle.Top
        pnlCharts.Location = New Point(0, 227)
        pnlCharts.Margin = New Padding(3, 2, 3, 2)
        pnlCharts.Name = "pnlCharts"
        pnlCharts.Padding = New Padding(18, 8, 18, 8)
        pnlCharts.Size = New Size(1225, 300)
        pnlCharts.TabIndex = 3
        ' 
        ' pnlRevenueChart
        ' 
        pnlRevenueChart.BackColor = Color.WhiteSmoke
        pnlRevenueChart.BorderStyle = BorderStyle.FixedSingle
        pnlRevenueChart.Controls.Add(Label7)
        pnlRevenueChart.Dock = DockStyle.Fill
        pnlRevenueChart.Location = New Point(613, 8)
        pnlRevenueChart.Margin = New Padding(3, 2, 3, 2)
        pnlRevenueChart.Name = "pnlRevenueChart"
        pnlRevenueChart.Padding = New Padding(9, 8, 9, 8)
        pnlRevenueChart.Size = New Size(594, 284)
        pnlRevenueChart.TabIndex = 2
        ' 
        ' Label7
        ' 
        Label7.BackColor = Color.FromArgb(CByte(50), CByte(205), CByte(50))
        Label7.Dock = DockStyle.Top
        Label7.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(9, 8)
        Label7.Name = "Label7"
        Label7.Padding = New Padding(9, 4, 9, 4)
        Label7.Size = New Size(574, 30)
        Label7.TabIndex = 0
        Label7.Text = "📈 Revenue Trend"
        Label7.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' pnlDailySalesChart
        ' 
        pnlDailySalesChart.BackColor = Color.WhiteSmoke
        pnlDailySalesChart.BorderStyle = BorderStyle.FixedSingle
        pnlDailySalesChart.Controls.Add(Label4)
        pnlDailySalesChart.Dock = DockStyle.Left
        pnlDailySalesChart.Location = New Point(18, 8)
        pnlDailySalesChart.Margin = New Padding(3, 2, 3, 2)
        pnlDailySalesChart.Name = "pnlDailySalesChart"
        pnlDailySalesChart.Padding = New Padding(9, 8, 9, 8)
        pnlDailySalesChart.Size = New Size(595, 284)
        pnlDailySalesChart.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(180))
        Label4.Dock = DockStyle.Top
        Label4.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(9, 8)
        Label4.Name = "Label4"
        Label4.Padding = New Padding(9, 4, 9, 4)
        Label4.Size = New Size(575, 30)
        Label4.TabIndex = 0
        Label4.Text = "📊 Daily Sales"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' pnlTransactions
        ' 
        pnlTransactions.BackColor = Color.White
        pnlTransactions.Controls.Add(dgvTransactions)
        pnlTransactions.Controls.Add(lblTransactions)
        pnlTransactions.Dock = DockStyle.Fill
        pnlTransactions.Location = New Point(0, 527)
        pnlTransactions.Margin = New Padding(3, 2, 3, 2)
        pnlTransactions.Name = "pnlTransactions"
        pnlTransactions.Padding = New Padding(18, 15, 18, 15)
        pnlTransactions.Size = New Size(1225, 134)
        pnlTransactions.TabIndex = 4
        ' 
        ' dgvTransactions
        ' 
        dgvTransactions.AllowUserToAddRows = False
        dgvTransactions.AllowUserToDeleteRows = False
        dgvTransactions.BackgroundColor = Color.White
        dgvTransactions.ColumnHeadersHeight = 35
        dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvTransactions.Dock = DockStyle.Fill
        dgvTransactions.Location = New Point(18, 59)
        dgvTransactions.Margin = New Padding(3, 2, 3, 2)
        dgvTransactions.Name = "dgvTransactions"
        dgvTransactions.ReadOnly = True
        dgvTransactions.RowHeadersWidth = 51
        dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTransactions.Size = New Size(1189, 60)
        dgvTransactions.TabIndex = 1
        ' 
        ' lblTransactions
        ' 
        lblTransactions.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(180))
        lblTransactions.Dock = DockStyle.Top
        lblTransactions.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTransactions.ForeColor = Color.White
        lblTransactions.Location = New Point(18, 15)
        lblTransactions.Name = "lblTransactions"
        lblTransactions.Padding = New Padding(9, 8, 9, 8)
        lblTransactions.Size = New Size(1189, 44)
        lblTransactions.TabIndex = 0
        lblTransactions.Text = "📋 Recent Transactions"
        lblTransactions.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' SalesReport
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1225, 661)
        Controls.Add(pnlTransactions)
        Controls.Add(pnlCharts)
        Controls.Add(pnlMetrics)
        Controls.Add(pnlControls)
        Controls.Add(pnlHeader)
        Margin = New Padding(3, 2, 3, 2)
        Name = "SalesReport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Sales Report - OrderUp!"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlControls.ResumeLayout(False)
        pnlControls.PerformLayout()
        pnlMetrics.ResumeLayout(False)
        pnlAvgOrder.ResumeLayout(False)
        pnlAvgOrder.PerformLayout()
        pnlOrderCount.ResumeLayout(False)
        pnlOrderCount.PerformLayout()
        pnlTotalSales.ResumeLayout(False)
        pnlTotalSales.PerformLayout()
        pnlCharts.ResumeLayout(False)
        pnlRevenueChart.ResumeLayout(False)
        pnlDailySalesChart.ResumeLayout(False)
        pnlTransactions.ResumeLayout(False)
        CType(dgvTransactions, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents pnlControls As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents btnExportCsv As Button
    Friend WithEvents btnExportPdf As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents pnlMetrics As Panel
    Friend WithEvents pnlTotalSales As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalSales As Label
    Friend WithEvents pnlOrderCount As Panel
    Friend WithEvents lblOrderCount As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlAvgOrder As Panel
    Friend WithEvents lblAvgOrder As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents pnlCharts As Panel
    Friend WithEvents pnlDailySalesChart As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlRevenueChart As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlTransactions As Panel
    Friend WithEvents lblTransactions As Label
    Friend WithEvents dgvTransactions As DataGridView
    Friend WithEvents lblTotalsalesicon As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
End Class