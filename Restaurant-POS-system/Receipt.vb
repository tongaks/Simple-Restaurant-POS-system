Imports System.IO
Imports PdfiumViewer

Public Class Receipt
    Private _pdfPath As String
    Private _fitWidth As Boolean = True

    Public Sub New()
        InitializeComponent()
    End Sub

    ' Load a PDF file into the designer Receipt window
    Public Sub LoadPdf(path As String)
        If String.IsNullOrEmpty(path) OrElse Not File.Exists(path) Then
            Throw New FileNotFoundException("PDF not found", path)
        End If

        _pdfPath = path
        Try
            Me.pdfViewer.Document = PdfDocument.Load(path)
            Me.pdfViewer.ZoomMode = PdfViewerZoomMode.FitWidth
            _fitWidth = True
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub tsSave_Click(sender As Object, e As EventArgs) Handles tsSave.Click
        If String.IsNullOrEmpty(_pdfPath) OrElse Not File.Exists(_pdfPath) Then
            MessageBox.Show("No receipt to save.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dlg As New SaveFileDialog()
            dlg.Filter = "PDF Files (*.pdf)|*.pdf"
            dlg.FileName = Path.GetFileName(_pdfPath)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                Try
                    File.Copy(_pdfPath, dlg.FileName, True)
                    MessageBox.Show("Receipt saved to: " & dlg.FileName, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to save receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub tsFitWidth_Click(sender As Object, e As EventArgs) Handles tsFitWidth.Click
        Try
            If _fitWidth Then
                pdfViewer.ZoomMode = PdfViewerZoomMode.FitHeight
            Else
                pdfViewer.ZoomMode = PdfViewerZoomMode.FitWidth
            End If
            _fitWidth = Not _fitWidth
        Catch ex As Exception
            ' silent
        End Try
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub
End Class