Imports System.Reflection.Metadata
Imports PdfSharp.Drawing
Imports PdfSharp.Fonts
Imports PdfSharp.Pdf
Imports PdfSharp.Quality

Public Class Receipt_form
    Public Sub CreateSimplePdf()
        Dim document As New PdfDocument()
        document.Info.Title = "Created with PDFsharp in VB.NET"
        GlobalFontSettings.UseWindowsFontsUnderWindows = True
        Dim page As PdfPage = document.AddPage()

        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)

        Dim font As New XFont("Arial", 20, XFontStyleEx.Regular)
        Dim textBrush As XBrush = XBrushes.Black

        gfx.DrawString("Hello, PDFsharp in VB.NET!", font, textBrush, New XRect(50, 50, page.Width, page.Height), XStringFormats.TopLeft)

        Const filename As String = "Receipt.pdf"
        document.Save("C:\Users\Administrator\Documents\" & filename)
    End Sub

    Private Sub CreateReceiptPDF()
        Dim receipt As New PdfDocument
        Dim page As PdfPage = receipt.AddPage()
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        Dim regFont As New XFont("Arial", 12, XFontStyleEx.Regular)
        Dim textBrush As XBrush = XBrushes.Black

    End Sub


    Private Sub Receipt_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalFontSettings.UseWindowsFontsUnderWindows = True
        CreateSimplePdf()
    End Sub
End Class