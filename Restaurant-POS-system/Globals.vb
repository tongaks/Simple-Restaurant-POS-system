Imports System.Drawing
Imports System.Windows.Forms

Module Globals
    ' Application-wide current user and admin flag
    Public CurrentUser As String = String.Empty
    Public IsAdmin As Boolean = False

    ' Returns the app's main connection string.
    ' Replace the string below with your production connection string or keep it for local dev.
    Public Function GetGlobalConnectionString() As String
        Return "server=localhost;userid=root;password=;database=restaurant;SslMode=none;"
    End Function

    ' Placeholder for order store connection string (OleDb/other).
    Public Function GetOrdersConnectionString() As String
        Return GetGlobalConnectionString()
    End Function

    ' Resize an Image to fit inside a control preserving aspect ratio
    Public Function ResizeImageFit(img As Image, ctrl As Control) As Image
        If img Is Nothing OrElse ctrl Is Nothing OrElse ctrl.Width = 0 OrElse ctrl.Height = 0 Then
            Return Nothing
        End If

        Dim targetW = ctrl.Width
        Dim targetH = ctrl.Height
        Dim ratio = Math.Min(targetW / img.Width, targetH / img.Height)
        Dim newW = Math.Max(1, CInt(img.Width * ratio))
        Dim newH = Math.Max(1, CInt(img.Height * ratio))

        Dim bmp As New Bitmap(newW, newH)
        Using g = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newW, newH)
        End Using
        Return bmp
    End Function

    ' Used as an AddHandler target for FormClosed to close the owner/parent form safely
    Public Sub FormCloseParent(sender As Object, e As FormClosedEventArgs)
        Dim frm = TryCast(sender, Form)
        If frm Is Nothing Then Return
        Try
            If frm.Owner IsNot Nothing Then
                frm.Owner.Close()
            End If
        Catch
            ' silent
        End Try
    End Sub
End Module