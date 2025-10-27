<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Receipt
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlMain = New Panel()
        pnlContent = New Panel()
        pnlNativeReceipt = New Panel()
        pnlReceiptScroll = New Panel()
        flowItemsContainer = New FlowLayoutPanel()
        pnlReceiptFooter = New Panel()
        pnlTotalsCard = New Panel()
        pnlTotalRow = New Panel()
        lblTotalAmount = New Label()
        lblTotalLabel = New Label()
        pnlDiscountRow = New Panel()
        lblDiscountAmount = New Label()
        lblDiscountLabel = New Label()
        pnlSubtotalRow = New Panel()
        lblSubtotalAmount = New Label()
        lblSubtotalLabel = New Label()
        pnlReceiptHeader = New Panel()
        pnlHeaderInfo = New Panel()
        lblPaymentMethod = New Label()
        lblCashier = New Label()
        lblDateTime = New Label()
        lblOrderId = New Label()
        pnlLogo = New Panel()
        lblAppTitle = New Label()
        lblAppSubtitle = New Label()
        pnlPdfViewer = New Panel()
        pdfViewer = New PdfiumViewer.PdfViewer()
        pnlPdfToolbar = New Panel()
        btnPdfZoom = New FontAwesome.Sharp.IconButton()
        pnlHeader = New Panel()
        pnlViewToggle = New Panel()
        btnViewPdf = New FontAwesome.Sharp.IconButton()
        btnViewNative = New FontAwesome.Sharp.IconButton()
        lblHeaderTitle = New Label()
        pnlActions = New Panel()
        btnEmail = New FontAwesome.Sharp.IconButton()
        btnPrint = New FontAwesome.Sharp.IconButton()
        btnSavePdf = New FontAwesome.Sharp.IconButton()
        btnClose = New FontAwesome.Sharp.IconButton()
        pnlMain.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlNativeReceipt.SuspendLayout()
        pnlReceiptScroll.SuspendLayout()
        pnlReceiptFooter.SuspendLayout()
        pnlTotalsCard.SuspendLayout()
        pnlTotalRow.SuspendLayout()
        pnlDiscountRow.SuspendLayout()
        pnlSubtotalRow.SuspendLayout()
        pnlReceiptHeader.SuspendLayout()
        pnlHeaderInfo.SuspendLayout()
        pnlLogo.SuspendLayout()
        pnlPdfViewer.SuspendLayout()
        pnlPdfToolbar.SuspendLayout()
        pnlHeader.SuspendLayout()
        pnlViewToggle.SuspendLayout()
        pnlActions.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.FromArgb(CByte(247), CByte(250), CByte(252))
        pnlMain.Controls.Add(pnlContent)
        pnlMain.Controls.Add(pnlHeader)
        pnlMain.Controls.Add(pnlActions)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(1400, 900)
        pnlMain.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.Controls.Add(pnlNativeReceipt)
        pnlContent.Controls.Add(pnlPdfViewer)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 90)
        pnlContent.Name = "pnlContent"
        pnlContent.Padding = New Padding(30, 20, 30, 20)
        pnlContent.Size = New Size(1400, 710)
        pnlContent.TabIndex = 1
        ' 
        ' pnlNativeReceipt
        ' 
        pnlNativeReceipt.BackColor = Color.White
        pnlNativeReceipt.Controls.Add(pnlReceiptScroll)
        pnlNativeReceipt.Controls.Add(pnlReceiptFooter)
        pnlNativeReceipt.Controls.Add(pnlReceiptHeader)
        pnlNativeReceipt.Dock = DockStyle.Fill
        pnlNativeReceipt.Location = New Point(30, 20)
        pnlNativeReceipt.Name = "pnlNativeReceipt"
        pnlNativeReceipt.Size = New Size(1340, 670)
        pnlNativeReceipt.TabIndex = 0
        ' 
        ' pnlReceiptScroll
        ' 
        pnlReceiptScroll.AutoScroll = True
        pnlReceiptScroll.Controls.Add(flowItemsContainer)
        pnlReceiptScroll.Dock = DockStyle.Fill
        pnlReceiptScroll.Location = New Point(0, 200)
        pnlReceiptScroll.Name = "pnlReceiptScroll"
        pnlReceiptScroll.Padding = New Padding(40, 20, 40, 20)
        pnlReceiptScroll.Size = New Size(1340, 270)
        pnlReceiptScroll.TabIndex = 1
        ' 
        ' flowItemsContainer
        ' 
        flowItemsContainer.AutoSize = True
        flowItemsContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flowItemsContainer.Dock = DockStyle.Top
        flowItemsContainer.FlowDirection = FlowDirection.TopDown
        flowItemsContainer.Location = New Point(40, 20)
        flowItemsContainer.Name = "flowItemsContainer"
        flowItemsContainer.Size = New Size(1260, 0)
        flowItemsContainer.TabIndex = 0
        flowItemsContainer.WrapContents = False
        ' 
        ' pnlReceiptFooter
        ' 
        pnlReceiptFooter.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlReceiptFooter.Controls.Add(pnlTotalsCard)
        pnlReceiptFooter.Dock = DockStyle.Bottom
        pnlReceiptFooter.Location = New Point(0, 470)
        pnlReceiptFooter.Name = "pnlReceiptFooter"
        pnlReceiptFooter.Padding = New Padding(40, 30, 40, 30)
        pnlReceiptFooter.Size = New Size(1340, 200)
        pnlReceiptFooter.TabIndex = 2
        ' 
        ' pnlTotalsCard
        ' 
        pnlTotalsCard.BackColor = Color.White
        pnlTotalsCard.Controls.Add(pnlTotalRow)
        pnlTotalsCard.Controls.Add(pnlDiscountRow)
        pnlTotalsCard.Controls.Add(pnlSubtotalRow)
        pnlTotalsCard.Dock = DockStyle.Right
        pnlTotalsCard.Location = New Point(840, 30)
        pnlTotalsCard.Name = "pnlTotalsCard"
        pnlTotalsCard.Size = New Size(460, 140)
        pnlTotalsCard.TabIndex = 0
        ' 
        ' pnlTotalRow
        ' 
        pnlTotalRow.Controls.Add(lblTotalAmount)
        pnlTotalRow.Controls.Add(lblTotalLabel)
        pnlTotalRow.Dock = DockStyle.Top
        pnlTotalRow.Location = New Point(0, 80)
        pnlTotalRow.Name = "pnlTotalRow"
        pnlTotalRow.Padding = New Padding(25, 8, 25, 8)
        pnlTotalRow.Size = New Size(460, 60)
        pnlTotalRow.TabIndex = 2
        ' 
        ' lblTotalAmount
        ' 
        lblTotalAmount.Dock = DockStyle.Right
        lblTotalAmount.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        lblTotalAmount.ForeColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        lblTotalAmount.Location = New Point(260, 8)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(175, 44)
        lblTotalAmount.TabIndex = 1
        lblTotalAmount.Text = "₱0.00"
        lblTotalAmount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblTotalLabel
        ' 
        lblTotalLabel.AutoSize = True
        lblTotalLabel.Dock = DockStyle.Left
        lblTotalLabel.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblTotalLabel.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblTotalLabel.Location = New Point(25, 8)
        lblTotalLabel.Name = "lblTotalLabel"
        lblTotalLabel.Size = New Size(82, 37)
        lblTotalLabel.TabIndex = 0
        lblTotalLabel.Text = "Total"
        ' 
        ' pnlDiscountRow
        ' 
        pnlDiscountRow.Controls.Add(lblDiscountAmount)
        pnlDiscountRow.Controls.Add(lblDiscountLabel)
        pnlDiscountRow.Dock = DockStyle.Top
        pnlDiscountRow.Location = New Point(0, 40)
        pnlDiscountRow.Name = "pnlDiscountRow"
        pnlDiscountRow.Padding = New Padding(25, 8, 25, 8)
        pnlDiscountRow.Size = New Size(460, 40)
        pnlDiscountRow.TabIndex = 1
        ' 
        ' lblDiscountAmount
        ' 
        lblDiscountAmount.Dock = DockStyle.Right
        lblDiscountAmount.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        lblDiscountAmount.ForeColor = Color.FromArgb(CByte(239), CByte(68), CByte(68))
        lblDiscountAmount.Location = New Point(310, 8)
        lblDiscountAmount.Name = "lblDiscountAmount"
        lblDiscountAmount.Size = New Size(125, 24)
        lblDiscountAmount.TabIndex = 1
        lblDiscountAmount.Text = "-₱0.00"
        lblDiscountAmount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblDiscountLabel
        ' 
        lblDiscountLabel.AutoSize = True
        lblDiscountLabel.Dock = DockStyle.Left
        lblDiscountLabel.Font = New Font("Segoe UI", 11F)
        lblDiscountLabel.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblDiscountLabel.Location = New Point(25, 8)
        lblDiscountLabel.Name = "lblDiscountLabel"
        lblDiscountLabel.Size = New Size(129, 25)
        lblDiscountLabel.TabIndex = 0
        lblDiscountLabel.Text = "Discount (0%)"
        ' 
        ' pnlSubtotalRow
        ' 
        pnlSubtotalRow.Controls.Add(lblSubtotalAmount)
        pnlSubtotalRow.Controls.Add(lblSubtotalLabel)
        pnlSubtotalRow.Dock = DockStyle.Top
        pnlSubtotalRow.Location = New Point(0, 0)
        pnlSubtotalRow.Name = "pnlSubtotalRow"
        pnlSubtotalRow.Padding = New Padding(25, 8, 25, 8)
        pnlSubtotalRow.Size = New Size(460, 40)
        pnlSubtotalRow.TabIndex = 0
        ' 
        ' lblSubtotalAmount
        ' 
        lblSubtotalAmount.Dock = DockStyle.Right
        lblSubtotalAmount.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        lblSubtotalAmount.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
        lblSubtotalAmount.Location = New Point(310, 8)
        lblSubtotalAmount.Name = "lblSubtotalAmount"
        lblSubtotalAmount.Size = New Size(125, 24)
        lblSubtotalAmount.TabIndex = 1
        lblSubtotalAmount.Text = "₱0.00"
        lblSubtotalAmount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblSubtotalLabel
        ' 
        lblSubtotalLabel.AutoSize = True
        lblSubtotalLabel.Dock = DockStyle.Left
        lblSubtotalLabel.Font = New Font("Segoe UI", 11F)
        lblSubtotalLabel.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSubtotalLabel.Location = New Point(25, 8)
        lblSubtotalLabel.Name = "lblSubtotalLabel"
        lblSubtotalLabel.Size = New Size(82, 25)
        lblSubtotalLabel.TabIndex = 0
        lblSubtotalLabel.Text = "Subtotal"
        ' 
        ' pnlReceiptHeader
        ' 
        pnlReceiptHeader.BackColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        pnlReceiptHeader.Controls.Add(pnlHeaderInfo)
        pnlReceiptHeader.Controls.Add(pnlLogo)
        pnlReceiptHeader.Dock = DockStyle.Top
        pnlReceiptHeader.Location = New Point(0, 0)
        pnlReceiptHeader.Name = "pnlReceiptHeader"
        pnlReceiptHeader.Padding = New Padding(40, 30, 40, 30)
        pnlReceiptHeader.Size = New Size(1340, 200)
        pnlReceiptHeader.TabIndex = 0
        ' 
        ' pnlHeaderInfo
        ' 
        pnlHeaderInfo.Controls.Add(lblPaymentMethod)
        pnlHeaderInfo.Controls.Add(lblCashier)
        pnlHeaderInfo.Controls.Add(lblDateTime)
        pnlHeaderInfo.Controls.Add(lblOrderId)
        pnlHeaderInfo.Dock = DockStyle.Fill
        pnlHeaderInfo.Location = New Point(440, 30)
        pnlHeaderInfo.Name = "pnlHeaderInfo"
        pnlHeaderInfo.Padding = New Padding(20, 10, 0, 10)
        pnlHeaderInfo.Size = New Size(860, 140)
        pnlHeaderInfo.TabIndex = 1
        ' 
        ' lblPaymentMethod
        ' 
        lblPaymentMethod.AutoSize = True
        lblPaymentMethod.Font = New Font("Segoe UI", 11F)
        lblPaymentMethod.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblPaymentMethod.Location = New Point(25, 100)
        lblPaymentMethod.Name = "lblPaymentMethod"
        lblPaymentMethod.Size = New Size(134, 25)
        lblPaymentMethod.TabIndex = 3
        lblPaymentMethod.Text = "Payment: Cash"
        ' 
        ' lblCashier
        ' 
        lblCashier.AutoSize = True
        lblCashier.Font = New Font("Segoe UI", 11F)
        lblCashier.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblCashier.Location = New Point(25, 70)
        lblCashier.Name = "lblCashier"
        lblCashier.Size = New Size(120, 25)
        lblCashier.TabIndex = 2
        lblCashier.Text = "Cashier: user"
        ' 
        ' lblDateTime
        ' 
        lblDateTime.AutoSize = True
        lblDateTime.Font = New Font("Segoe UI", 11F)
        lblDateTime.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblDateTime.Location = New Point(25, 40)
        lblDateTime.Name = "lblDateTime"
        lblDateTime.Size = New Size(229, 25)
        lblDateTime.TabIndex = 1
        lblDateTime.Text = "Date: 2025-10-22 09:13:15"
        ' 
        ' lblOrderId
        ' 
        lblOrderId.AutoSize = True
        lblOrderId.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblOrderId.ForeColor = Color.White
        lblOrderId.Location = New Point(20, 10)
        lblOrderId.Name = "lblOrderId"
        lblOrderId.Size = New Size(171, 32)
        lblOrderId.TabIndex = 0
        lblOrderId.Text = "Order #12345"
        ' 
        ' pnlLogo
        ' 
        pnlLogo.Controls.Add(lblAppTitle)
        pnlLogo.Controls.Add(lblAppSubtitle)
        pnlLogo.Dock = DockStyle.Left
        pnlLogo.Location = New Point(40, 30)
        pnlLogo.Name = "pnlLogo"
        pnlLogo.Size = New Size(400, 140)
        pnlLogo.TabIndex = 0
        ' 
        ' lblAppTitle
        ' 
        lblAppTitle.AutoSize = True
        lblAppTitle.Font = New Font("Segoe UI", 32F, FontStyle.Bold)
        lblAppTitle.ForeColor = Color.White
        lblAppTitle.Location = New Point(0, 30)
        lblAppTitle.Name = "lblAppTitle"
        lblAppTitle.Size = New Size(247, 72)
        lblAppTitle.TabIndex = 0
        lblAppTitle.Text = "OrderUp"
        ' 
        ' lblAppSubtitle
        ' 
        lblAppSubtitle.AutoSize = True
        lblAppSubtitle.Font = New Font("Segoe UI", 12F)
        lblAppSubtitle.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblAppSubtitle.Location = New Point(5, 100)
        lblAppSubtitle.Name = "lblAppSubtitle"
        lblAppSubtitle.Size = New Size(218, 28)
        lblAppSubtitle.TabIndex = 1
        lblAppSubtitle.Text = "Restaurant Point of Sale"
        ' 
        ' pnlPdfViewer
        ' 
        pnlPdfViewer.BackColor = Color.White
        pnlPdfViewer.Controls.Add(pdfViewer)
        pnlPdfViewer.Controls.Add(pnlPdfToolbar)
        pnlPdfViewer.Dock = DockStyle.Fill
        pnlPdfViewer.Location = New Point(30, 20)
        pnlPdfViewer.Name = "pnlPdfViewer"
        pnlPdfViewer.Size = New Size(1340, 670)
        pnlPdfViewer.TabIndex = 1
        pnlPdfViewer.Visible = False
        ' 
        ' pdfViewer
        ' 
        pdfViewer.BackColor = Color.FromArgb(CByte(240), CByte(242), CByte(245))
        pdfViewer.Dock = DockStyle.Fill
        pdfViewer.Location = New Point(0, 50)
        pdfViewer.Margin = New Padding(4, 5, 4, 5)
        pdfViewer.Name = "pdfViewer"
        pdfViewer.Size = New Size(1340, 620)
        pdfViewer.TabIndex = 1
        pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth
        ' 
        ' pnlPdfToolbar
        ' 
        pnlPdfToolbar.BackColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        pnlPdfToolbar.Controls.Add(btnPdfZoom)
        pnlPdfToolbar.Dock = DockStyle.Top
        pnlPdfToolbar.Location = New Point(0, 0)
        pnlPdfToolbar.Name = "pnlPdfToolbar"
        pnlPdfToolbar.Padding = New Padding(15, 8, 15, 8)
        pnlPdfToolbar.Size = New Size(1340, 50)
        pnlPdfToolbar.TabIndex = 0
        ' 
        ' btnPdfZoom
        ' 
        btnPdfZoom.BackColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        btnPdfZoom.Cursor = Cursors.Hand
        btnPdfZoom.Dock = DockStyle.Left
        btnPdfZoom.FlatAppearance.BorderSize = 0
        btnPdfZoom.FlatStyle = FlatStyle.Flat
        btnPdfZoom.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnPdfZoom.ForeColor = Color.White
        btnPdfZoom.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus
        btnPdfZoom.IconColor = Color.White
        btnPdfZoom.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPdfZoom.IconSize = 18
        btnPdfZoom.ImageAlign = ContentAlignment.MiddleLeft
        btnPdfZoom.Location = New Point(15, 8)
        btnPdfZoom.Name = "btnPdfZoom"
        btnPdfZoom.Padding = New Padding(5, 0, 5, 0)
        btnPdfZoom.Size = New Size(120, 34)
        btnPdfZoom.TabIndex = 0
        btnPdfZoom.Text = "Fit Width"
        btnPdfZoom.TextImageRelation = TextImageRelation.ImageBeforeText
        btnPdfZoom.UseVisualStyleBackColor = False
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        pnlHeader.Controls.Add(pnlViewToggle)
        pnlHeader.Controls.Add(lblHeaderTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(40, 20, 40, 20)
        pnlHeader.Size = New Size(1400, 90)
        pnlHeader.TabIndex = 0
        ' 
        ' pnlViewToggle
        ' 
        pnlViewToggle.Controls.Add(btnViewPdf)
        pnlViewToggle.Controls.Add(btnViewNative)
        pnlViewToggle.Dock = DockStyle.Right
        pnlViewToggle.Location = New Point(1080, 20)
        pnlViewToggle.Name = "pnlViewToggle"
        pnlViewToggle.Size = New Size(280, 50)
        pnlViewToggle.TabIndex = 1
        ' 
        ' btnViewPdf
        ' 
        btnViewPdf.BackColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        btnViewPdf.Cursor = Cursors.Hand
        btnViewPdf.Dock = DockStyle.Right
        btnViewPdf.FlatAppearance.BorderSize = 0
        btnViewPdf.FlatStyle = FlatStyle.Flat
        btnViewPdf.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnViewPdf.ForeColor = Color.White
        btnViewPdf.IconChar = FontAwesome.Sharp.IconChar.FilePdf
        btnViewPdf.IconColor = Color.White
        btnViewPdf.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnViewPdf.IconSize = 20
        btnViewPdf.ImageAlign = ContentAlignment.MiddleLeft
        btnViewPdf.Location = New Point(140, 0)
        btnViewPdf.Name = "btnViewPdf"
        btnViewPdf.Padding = New Padding(8, 0, 8, 0)
        btnViewPdf.Size = New Size(140, 50)
        btnViewPdf.TabIndex = 1
        btnViewPdf.Text = "PDF View"
        btnViewPdf.TextImageRelation = TextImageRelation.ImageBeforeText
        btnViewPdf.UseVisualStyleBackColor = False
        ' 
        ' btnViewNative
        ' 
        btnViewNative.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        btnViewNative.Cursor = Cursors.Hand
        btnViewNative.Dock = DockStyle.Left
        btnViewNative.FlatAppearance.BorderSize = 0
        btnViewNative.FlatStyle = FlatStyle.Flat
        btnViewNative.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnViewNative.ForeColor = Color.White
        btnViewNative.IconChar = FontAwesome.Sharp.IconChar.Receipt
        btnViewNative.IconColor = Color.White
        btnViewNative.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnViewNative.IconSize = 20
        btnViewNative.ImageAlign = ContentAlignment.MiddleLeft
        btnViewNative.Location = New Point(0, 0)
        btnViewNative.Name = "btnViewNative"
        btnViewNative.Padding = New Padding(8, 0, 8, 0)
        btnViewNative.Size = New Size(140, 50)
        btnViewNative.TabIndex = 0
        btnViewNative.Text = "Receipt"
        btnViewNative.TextImageRelation = TextImageRelation.ImageBeforeText
        btnViewNative.UseVisualStyleBackColor = False
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Color.White
        lblHeaderTitle.Location = New Point(40, 25)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(259, 41)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = ChrW(55358) & ChrW(56830) & " Order Receipt"
        ' 
        ' pnlActions
        ' 
        pnlActions.BackColor = Color.White
        pnlActions.BorderStyle = BorderStyle.FixedSingle
        pnlActions.Controls.Add(btnEmail)
        pnlActions.Controls.Add(btnPrint)
        pnlActions.Controls.Add(btnSavePdf)
        pnlActions.Controls.Add(btnClose)
        pnlActions.Dock = DockStyle.Bottom
        pnlActions.Location = New Point(0, 800)
        pnlActions.Name = "pnlActions"
        pnlActions.Padding = New Padding(40, 15, 40, 15)
        pnlActions.Size = New Size(1400, 100)
        pnlActions.TabIndex = 2
        ' 
        ' btnEmail
        ' 
        btnEmail.BackColor = Color.FromArgb(CByte(99), CByte(102), CByte(241))
        btnEmail.Cursor = Cursors.Hand
        btnEmail.FlatAppearance.BorderSize = 0
        btnEmail.FlatStyle = FlatStyle.Flat
        btnEmail.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnEmail.ForeColor = Color.White
        btnEmail.IconChar = FontAwesome.Sharp.IconChar.Envelope
        btnEmail.IconColor = Color.White
        btnEmail.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEmail.IconSize = 24
        btnEmail.ImageAlign = ContentAlignment.MiddleLeft
        btnEmail.Location = New Point(720, 20)
        btnEmail.Name = "btnEmail"
        btnEmail.Padding = New Padding(12, 0, 12, 0)
        btnEmail.Size = New Size(200, 58)
        btnEmail.TabIndex = 3
        btnEmail.Text = "Email"
        btnEmail.TextImageRelation = TextImageRelation.ImageBeforeText
        btnEmail.UseVisualStyleBackColor = False
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        btnPrint.Cursor = Cursors.Hand
        btnPrint.FlatAppearance.BorderSize = 0
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnPrint.ForeColor = Color.White
        btnPrint.IconChar = FontAwesome.Sharp.IconChar.Print
        btnPrint.IconColor = Color.White
        btnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPrint.IconSize = 24
        btnPrint.ImageAlign = ContentAlignment.MiddleLeft
        btnPrint.Location = New Point(490, 20)
        btnPrint.Name = "btnPrint"
        btnPrint.Padding = New Padding(12, 0, 12, 0)
        btnPrint.Size = New Size(200, 58)
        btnPrint.TabIndex = 2
        btnPrint.Text = "Print"
        btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' btnSavePdf
        ' 
        btnSavePdf.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        btnSavePdf.Cursor = Cursors.Hand
        btnSavePdf.FlatAppearance.BorderSize = 0
        btnSavePdf.FlatStyle = FlatStyle.Flat
        btnSavePdf.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnSavePdf.ForeColor = Color.White
        btnSavePdf.IconChar = FontAwesome.Sharp.IconChar.Download
        btnSavePdf.IconColor = Color.White
        btnSavePdf.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSavePdf.IconSize = 24
        btnSavePdf.ImageAlign = ContentAlignment.MiddleLeft
        btnSavePdf.Location = New Point(260, 20)
        btnSavePdf.Name = "btnSavePdf"
        btnSavePdf.Padding = New Padding(12, 0, 12, 0)
        btnSavePdf.Size = New Size(200, 58)
        btnSavePdf.TabIndex = 1
        btnSavePdf.Text = "Save PDF"
        btnSavePdf.TextImageRelation = TextImageRelation.ImageBeforeText
        btnSavePdf.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        btnClose.Cursor = Cursors.Hand
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnClose.ForeColor = Color.White
        btnClose.IconChar = FontAwesome.Sharp.IconChar.Close
        btnClose.IconColor = Color.White
        btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnClose.IconSize = 24
        btnClose.ImageAlign = ContentAlignment.MiddleLeft
        btnClose.Location = New Point(1160, 20)
        btnClose.Name = "btnClose"
        btnClose.Padding = New Padding(12, 0, 12, 0)
        btnClose.Size = New Size(180, 58)
        btnClose.TabIndex = 0
        btnClose.Text = "Close"
        btnClose.TextImageRelation = TextImageRelation.ImageBeforeText
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' Receipt
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1400, 900)
        Controls.Add(pnlMain)
        Font = New Font("Segoe UI", 9F)
        KeyPreview = True
        MinimumSize = New Size(1000, 600)
        Name = "Receipt"
        StartPosition = FormStartPosition.CenterParent
        Text = "Order Receipt - OrderUp"
        pnlMain.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlNativeReceipt.ResumeLayout(False)
        pnlReceiptScroll.ResumeLayout(False)
        pnlReceiptScroll.PerformLayout()
        pnlReceiptFooter.ResumeLayout(False)
        pnlTotalsCard.ResumeLayout(False)
        pnlTotalRow.ResumeLayout(False)
        pnlTotalRow.PerformLayout()
        pnlDiscountRow.ResumeLayout(False)
        pnlDiscountRow.PerformLayout()
        pnlSubtotalRow.ResumeLayout(False)
        pnlSubtotalRow.PerformLayout()
        pnlReceiptHeader.ResumeLayout(False)
        pnlHeaderInfo.ResumeLayout(False)
        pnlHeaderInfo.PerformLayout()
        pnlLogo.ResumeLayout(False)
        pnlLogo.PerformLayout()
        pnlPdfViewer.ResumeLayout(False)
        pnlPdfToolbar.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlViewToggle.ResumeLayout(False)
        pnlActions.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlNativeReceipt As Panel
    Friend WithEvents pnlReceiptHeader As Panel
    Friend WithEvents pnlLogo As Panel
    Friend WithEvents lblAppTitle As Label
    Friend WithEvents lblAppSubtitle As Label
    Friend WithEvents pnlHeaderInfo As Panel
    Friend WithEvents lblOrderId As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents lblCashier As Label
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents pnlReceiptScroll As Panel
    Friend WithEvents flowItemsContainer As FlowLayoutPanel
    Friend WithEvents pnlReceiptFooter As Panel
    Friend WithEvents pnlTotalsCard As Panel
    Friend WithEvents pnlSubtotalRow As Panel
    Friend WithEvents lblSubtotalLabel As Label
    Friend WithEvents lblSubtotalAmount As Label
    Friend WithEvents pnlDiscountRow As Panel
    Friend WithEvents lblDiscountLabel As Label
    Friend WithEvents lblDiscountAmount As Label
    Friend WithEvents pnlTotalRow As Panel
    Friend WithEvents lblTotalLabel As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents pnlPdfViewer As Panel
    Friend WithEvents pdfViewer As PdfiumViewer.PdfViewer
    Friend WithEvents pnlPdfToolbar As Panel
    Friend WithEvents btnPdfZoom As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlViewToggle As Panel
    Friend WithEvents btnViewNative As FontAwesome.Sharp.IconButton
    Friend WithEvents btnViewPdf As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnSavePdf As FontAwesome.Sharp.IconButton
    Friend WithEvents btnPrint As FontAwesome.Sharp.IconButton
    Friend WithEvents btnEmail As FontAwesome.Sharp.IconButton
    Friend WithEvents btnClose As FontAwesome.Sharp.IconButton
End Class