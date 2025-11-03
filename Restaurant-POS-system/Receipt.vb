Imports System.IO
Imports System.Drawing.Printing
Imports PdfiumViewer
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class Receipt
    ' Data structures
    Public Class OrderItem
        Public Property Name As String
        Public Property Amount As Integer
        Public Property Price As Decimal
        Public Property Total As Decimal
    End Class

    Public Class OrderData
        Public Property OrderId As String
        Public Property OrderDate As DateTime
        Public Property CashierName As String
        Public Property Items As List(Of OrderItem)
        Public Property Subtotal As Decimal
        Public Property DiscountPercent As Double
        Public Property Total As Decimal
        Public Property PaymentMethod As String
    End Class

    ' Private fields
    Private _pdfPath As String = String.Empty
    Private _orderData As OrderData
    Private _fitWidth As Boolean = True
    Private _currentView As String = "native" ' "native" or "pdf"

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Load, AddressOf Receipt_Load
        AddHandler Me.KeyDown, AddressOf Receipt_KeyDown
        AddHandler Me.Shown, AddressOf Receipt_Shown
    End Sub

    Private Sub Receipt_Load(sender As Object, e As EventArgs)
        ' Show native view by default
        ShowNativeView()

        ' Initial button hover effects setup
        SetupButtonHoverEffects()
    End Sub

    Private Sub Receipt_Shown(sender As Object, e As EventArgs)
        ' Animate form entrance
        Me.Opacity = 0
        Dim fadeTimer As New Timer With {.Interval = 10}
        AddHandler fadeTimer.Tick, Sub()
                                       Me.Opacity += 0.05
                                       If Me.Opacity >= 1 Then
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()
                                       End If
                                   End Sub
        fadeTimer.Start()
    End Sub

    Private Sub SetupButtonHoverEffects()
        ' Add smooth hover effects to all buttons
        For Each btn As Guna.UI2.WinForms.Guna2Button In {btnSavePdf, btnPrint, btnEmail, btnClose, btnViewNative, btnViewPdf, btnPdfZoom}
            AddHandler btn.MouseEnter, AddressOf Button_MouseEnter
            AddHandler btn.MouseLeave, AddressOf Button_MouseLeave
        Next
    End Sub

    Private Sub Button_MouseEnter(sender As Object, e As EventArgs)
        Dim btn = TryCast(sender, Guna.UI2.WinForms.Guna2Button)
        If btn IsNot Nothing Then
            btn.ShadowDecoration.Depth = 15
        End If
    End Sub

    Private Sub Button_MouseLeave(sender As Object, e As EventArgs)
        Dim btn = TryCast(sender, Guna.UI2.WinForms.Guna2Button)
        If btn IsNot Nothing Then
            btn.ShadowDecoration.Depth = 8
        End If
    End Sub

    ''' <summary>
    ''' Main entry point - Load receipt with order data and optional PDF path
    ''' </summary>
    Public Sub LoadReceipt(orderData As OrderData, Optional pdfPath As String = "")
        Try
            If orderData Is Nothing Then
                MessageBox.Show("No order data provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            _orderData = orderData
            _pdfPath = pdfPath

            ' Populate native receipt view
            PopulateNativeReceipt()

            ' Try to load PDF if path is valid
            If Not String.IsNullOrEmpty(pdfPath) AndAlso File.Exists(pdfPath) Then
                Try
                    pdfViewer.Document = PdfiumViewer.PdfDocument.Load(pdfPath)
                    pdfViewer.ZoomMode = PdfViewerZoomMode.FitWidth
                    _fitWidth = True
                Catch ex As Exception
                    ' PDF load failed, but native view still works
                    MessageBox.Show("Could not load PDF preview, showing digital receipt only." & vbCrLf & vbCrLf & "Error: " & ex.Message, "PDF Load Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ' Disable PDF view button
                    btnViewPdf.Enabled = False
                    btnViewPdf.FillColor = Color.FromArgb(71, 85, 105)
                End Try
            Else
                ' No PDF available
                btnViewPdf.Enabled = False
                btnViewPdf.FillColor = Color.FromArgb(71, 85, 105)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Populate the native receipt UI with order data
    ''' </summary>
    Private Sub PopulateNativeReceipt()
        Try
            ' Header information
            lblOrderId.Text = "Order #" & _orderData.OrderId
            lblDateTime.Text = "Date: " & _orderData.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")
            lblCashier.Text = "Cashier: " & _orderData.CashierName
            lblPaymentMethod.Text = "Payment: " & _orderData.PaymentMethod

            ' Clear items
            flowItemsContainer.Controls.Clear()

            ' Add items with staggered animation
            If _orderData.Items IsNot Nothing Then
                Dim delay As Integer = 0
                For Each item In _orderData.Items
                    Dim itemCard = CreateItemCard(item)
                    itemCard.Tag = delay
                    flowItemsContainer.Controls.Add(itemCard)

                    ' Animate item entrance
                    AnimateItemEntrance(itemCard, delay)
                    delay += 50
                Next
            End If

            ' Totals with animation
            AnimateTotalsUpdate()

            lblSubtotalAmount.Text = "₱" & _orderData.Subtotal.ToString("N2")

            Dim discountAmount As Decimal = (_orderData.DiscountPercent / 100) * _orderData.Subtotal
            lblDiscountLabel.Text = "Discount (" & _orderData.DiscountPercent.ToString("0.0") & "%)"
            lblDiscountAmount.Text = "-₱" & discountAmount.ToString("N2")

            lblTotalAmount.Text = "₱" & _orderData.Total.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("Error populating receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AnimateItemEntrance(itemCard As Panel, delay As Integer)
        itemCard.Location = New Point(itemCard.Location.X - 50, itemCard.Location.Y)
        itemCard.Visible = False

        Dim entryTimer As New Timer With {.Interval = delay, .Tag = itemCard}
        AddHandler entryTimer.Tick, Sub(s, e)
                                        Dim timer = DirectCast(s, Timer)
                                        Dim card = DirectCast(timer.Tag, Panel)
                                        timer.Stop()
                                        timer.Dispose()

                                        card.Visible = True
                                        TransitionAnimator.Show(card)
                                    End Sub
        entryTimer.Start()
    End Sub

    Private Sub AnimateTotalsUpdate()
        ' Pulse animation for total amount
        Dim pulseTimer As New Timer With {.Interval = 50}
        Dim pulseCount As Integer = 0
        Dim originalSize = lblTotalAmount.Font.Size

        AddHandler pulseTimer.Tick, Sub()
                                        pulseCount += 1
                                        If pulseCount <= 5 Then
                                            lblTotalAmount.Font = New Font(lblTotalAmount.Font.FontFamily, originalSize + 2, FontStyle.Bold)
                                        ElseIf pulseCount <= 10 Then
                                            lblTotalAmount.Font = New Font(lblTotalAmount.Font.FontFamily, originalSize, FontStyle.Bold)
                                        Else
                                            pulseTimer.Stop()
                                            pulseTimer.Dispose()
                                        End If
                                    End Sub
        pulseTimer.Start()
    End Sub

    ''' <summary>
    ''' Create a modern card UI for each order item
    ''' </summary>
    Private Function CreateItemCard(item As OrderItem) As Guna.UI2.WinForms.Guna2Panel
        Dim card As New Guna.UI2.WinForms.Guna2Panel With {
            .Width = flowItemsContainer.ClientSize.Width - 20,
            .Height = 80,
            .BorderRadius = 15,
            .FillColor = Color.FromArgb(248, 250, 252),
            .Margin = New Padding(0, 0, 0, 12)
        }

        card.ShadowDecoration.BorderRadius = 15
        card.ShadowDecoration.Depth = 5
        card.ShadowDecoration.Enabled = True
        card.ShadowDecoration.Color = Color.FromArgb(200, 200, 200)

        ' Quantity badge with gradient
        Dim qtyBadge As New Guna.UI2.WinForms.Guna2GradientPanel With {
            .Size = New Size(60, 60),
            .Location = New Point(15, 10),
            .BorderRadius = 12,
            .FillColor = Color.FromArgb(16, 185, 129),
            .FillColor2 = Color.FromArgb(5, 150, 105),
            .GradientMode = Drawing2D.LinearGradientMode.ForwardDiagonal
        }

        Dim qtyLabel As New Label With {
            .Text = item.Amount.ToString(),
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Dock = DockStyle.Fill,
            .BackColor = Color.Transparent
        }
        qtyBadge.Controls.Add(qtyLabel)

        ' Item name
        Dim nameLabel As New Label With {
            .Text = item.Name,
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .ForeColor = Color.FromArgb(30, 41, 59),
            .Location = New Point(90, 15),
            .AutoSize = True,
            .MaximumSize = New Size(600, 0),
            .BackColor = Color.Transparent
        }

        ' Unit price
        Dim priceLabel As New Label With {
            .Text = "₱" & item.Price.ToString("N2") & " each",
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .ForeColor = Color.FromArgb(100, 116, 139),
            .Location = New Point(90, 45),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }

        ' Line total
        Dim totalLabel As New Label With {
            .Text = "₱" & item.Total.ToString("N2"),
            .Font = New Font("Segoe UI Semibold", 16, FontStyle.Bold),
            .ForeColor = Color.FromArgb(15, 23, 42),
            .Location = New Point(card.Width - 180, 25),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }

        card.Controls.AddRange({qtyBadge, nameLabel, priceLabel, totalLabel})

        ' Hover effect
        AddHandler card.MouseEnter, Sub()
                                        card.ShadowDecoration.Depth = 10
                                        card.FillColor = Color.White
                                    End Sub
        AddHandler card.MouseLeave, Sub()
                                        card.ShadowDecoration.Depth = 5
                                        card.FillColor = Color.FromArgb(248, 250, 252)
                                    End Sub

        Return card
    End Function

    ' View toggle handlers with animation
    Private Sub btnViewNative_Click(sender As Object, e As EventArgs) Handles btnViewNative.Click
        ShowNativeView()
    End Sub

    Private Sub btnViewPdf_Click(sender As Object, e As EventArgs) Handles btnViewPdf.Click
        ShowPdfView()
    End Sub

    Private Sub ShowNativeView()
        If _currentView = "native" Then Return

        _currentView = "native"
        TransitionAnimator.Hide(pnlPdfViewer)
        pnlPdfViewer.Visible = False
        pnlNativeReceipt.Visible = True
        TransitionAnimator.Show(pnlNativeReceipt)

        btnViewNative.FillColor = Color.FromArgb(16, 185, 129)
        btnViewPdf.FillColor = Color.FromArgb(71, 85, 105)
    End Sub

    Private Sub ShowPdfView()
        If Not btnViewPdf.Enabled Then
            MessageBox.Show("PDF preview is not available.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If _currentView = "pdf" Then Return

        _currentView = "pdf"
        TransitionAnimator.Hide(pnlNativeReceipt)
        pnlNativeReceipt.Visible = False
        pnlPdfViewer.Visible = True
        TransitionAnimator.Show(pnlPdfViewer)

        btnViewNative.FillColor = Color.FromArgb(71, 85, 105)
        btnViewPdf.FillColor = Color.FromArgb(16, 185, 129)
    End Sub

    ' PDF zoom toggle
    Private Sub btnPdfZoom_Click(sender As Object, e As EventArgs) Handles btnPdfZoom.Click
        Try
            If _fitWidth Then
                pdfViewer.ZoomMode = PdfViewerZoomMode.FitHeight
                btnPdfZoom.Text = "Fit Height"
            Else
                pdfViewer.ZoomMode = PdfViewerZoomMode.FitWidth
                btnPdfZoom.Text = "Fit Width"
            End If
            _fitWidth = Not _fitWidth
        Catch ex As Exception
            ' Silent fail
        End Try
    End Sub

    ' Action buttons
    Private Sub btnSavePdf_Click(sender As Object, e As EventArgs) Handles btnSavePdf.Click
        Try
            ' If we have a PDF, save it
            If Not String.IsNullOrEmpty(_pdfPath) AndAlso File.Exists(_pdfPath) Then
                Using dlg As New SaveFileDialog()
                    dlg.Filter = "PDF Files (*.pdf)|*.pdf"
                    dlg.FileName = "Receipt_" & _orderData.OrderId & ".pdf"
                    dlg.DefaultExt = "pdf"
                    If dlg.ShowDialog(Me) = DialogResult.OK Then
                        File.Copy(_pdfPath, dlg.FileName, True)
                        MessageBox.Show("Receipt saved successfully to:" & vbCrLf & dlg.FileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Else
                ' Generate PDF from native receipt data
                Dim generatedPdf = GeneratePdfFromOrderData()
                If Not String.IsNullOrEmpty(generatedPdf) Then
                    Using dlg As New SaveFileDialog()
                        dlg.Filter = "PDF Files (*.pdf)|*.pdf"
                        dlg.FileName = "Receipt_" & _orderData.OrderId & ".pdf"
                        dlg.DefaultExt = "pdf"
                        If dlg.ShowDialog(Me) = DialogResult.OK Then
                            File.Copy(generatedPdf, dlg.FileName, True)
                            MessageBox.Show("Receipt saved successfully to:" & vbCrLf & dlg.FileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If pdfViewer.Document IsNot Nothing Then
                ' Print using PdfiumViewer
                Using printDialog As New PrintDialog()
                    If printDialog.ShowDialog(Me) = DialogResult.OK Then
                        Dim printDoc = pdfViewer.Document.CreatePrintDocument()
                        printDoc.PrinterSettings = printDialog.PrinterSettings
                        printDoc.Print()
                        MessageBox.Show("Receipt sent to printer.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Else
                MessageBox.Show("No PDF document available for printing." & vbCrLf & vbCrLf & "Please save the receipt first, then open and print it.", "Print Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error printing: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Try
            ' Note: mailto: doesn't support attachments due to security restrictions
            ' Best practice: Save file and show instructions
            MessageBox.Show("To email this receipt:" & vbCrLf & vbCrLf &
                          "1. Click 'Save PDF' button" & vbCrLf &
                          "2. Attach the saved file to your email" & vbCrLf & vbCrLf &
                          "Note: Due to browser security, we cannot automatically attach files to email.",
                          "Email Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        ' Animate form exit
        Dim fadeTimer As New Timer With {.Interval = 10}
        AddHandler fadeTimer.Tick, Sub()
                                       Me.Opacity -= 0.1
                                       If Me.Opacity <= 0 Then
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()
                                           Me.Close()
                                       End If
                                   End Sub
        fadeTimer.Start()
    End Sub

    ' Keyboard shortcuts
    Private Sub Receipt_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            btnClose_Click(sender, EventArgs.Empty)
        ElseIf e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrint_Click(sender, EventArgs.Empty)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Enter Then
            btnSavePdf_Click(sender, EventArgs.Empty)
            e.Handled = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSavePdf_Click(sender, EventArgs.Empty)
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Generate a PDF from order data (fallback when no PDF path provided)
    ''' </summary>
    Private Function GeneratePdfFromOrderData() As String
        Try
            Dim pdfDoc As New PdfSharp.Pdf.PdfDocument()
            Dim page As PdfPage = pdfDoc.AddPage()
            Dim gfx As XGraphics = XGraphics.FromPdfPage(page)

            Dim titleFont As New XFont("Arial", 18, XFontStyleEx.Bold)
            Dim headerFont As New XFont("Arial", 12, XFontStyleEx.Bold)
            Dim regFont As New XFont("Arial", 11, XFontStyleEx.Regular)
            Dim textBrush As XBrush = XBrushes.Black

            Dim yPos As Integer = 50

            ' Header
            gfx.DrawString("OrderUp - Receipt", titleFont, textBrush, New XRect(50, yPos, 500, 30), XStringFormats.TopLeft)
            yPos += 40

            gfx.DrawString("Order ID: " & _orderData.OrderId, regFont, textBrush, New XRect(50, yPos, 400, 20), XStringFormats.TopLeft)
            yPos += 25
            gfx.DrawString("Date: " & _orderData.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"), regFont, textBrush, New XRect(50, yPos, 400, 20), XStringFormats.TopLeft)
            yPos += 25
            gfx.DrawString("Cashier: " & _orderData.CashierName, regFont, textBrush, New XRect(50, yPos, 400, 20), XStringFormats.TopLeft)
            yPos += 25
            gfx.DrawString("Payment: " & _orderData.PaymentMethod, regFont, textBrush, New XRect(50, yPos, 400, 20), XStringFormats.TopLeft)
            yPos += 40

            ' Items header
            gfx.DrawString("Items:", headerFont, textBrush, New XRect(50, yPos, 200, 20), XStringFormats.TopLeft)
            yPos += 30

            ' Items
            For Each item In _orderData.Items
                Dim itemLine = item.Amount.ToString() & "x  " & item.Name & "  @₱" & item.Price.ToString("N2") & "  =  ₱" & item.Total.ToString("N2")
                gfx.DrawString(itemLine, regFont, textBrush, New XRect(70, yPos, 450, 20), XStringFormats.TopLeft)
                yPos += 25
            Next

            yPos += 20

            ' Totals
            gfx.DrawString("Subtotal: ₱" & _orderData.Subtotal.ToString("N2"), headerFont, textBrush, New XRect(50, yPos, 400, 20), XStringFormats.TopLeft)
            yPos += 25

            Dim discountAmt = (_orderData.DiscountPercent / 100) * _orderData.Subtotal
            gfx.DrawString("Discount (" & _orderData.DiscountPercent.ToString("0.0") & "%): -₱" & discountAmt.ToString("N2"), regFont, textBrush, New XRect(50, yPos, 400, 20), XStringFormats.TopLeft)
            yPos += 30

            gfx.DrawString("TOTAL: ₱" & _orderData.Total.ToString("N2"), titleFont, textBrush, New XRect(50, yPos, 400, 30), XStringFormats.TopLeft)

            ' Save to temp file
            Dim tempPath = Path.Combine(Path.GetTempPath(), "Receipt_" & _orderData.OrderId & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".pdf")
            pdfDoc.Save(tempPath)

            Return tempPath

        Catch ex As Exception
            MessageBox.Show("Error generating PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        End Try
    End Function
End Class