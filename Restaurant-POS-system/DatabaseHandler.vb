Imports System.IO

Module GlobalFunctions
    Private ReadOnly DirInfo As DirectoryInfo = GetBaseDirectory()
    Public CurrentUser As String
    Public IsAdmin As Boolean

    Public Function GetGlobalConnectionString() As String
        'Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & DirInfo.FullName & "\MSAccess\Restaurant.accdb ;Persist Security Info=False;"
        Return "server=localhost;user=root;database=restaurant;port=3306;password=;"
    End Function

    Public Function GetOrdersConnectionString() As String
        Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & DirInfo.FullName & "\MSAccess\Orders.accdb ;Persist Security Info=False;"
    End Function

    Private Function GetBaseDirectory() As DirectoryInfo
        Dim currentDir As New DirectoryInfo(Directory.GetCurrentDirectory())

        For i As Integer = 1 To 4
            If currentDir.Parent IsNot Nothing Then
                currentDir = currentDir.Parent
            Else
                Exit For
            End If
        Next

        Return currentDir
    End Function

    Public Function ResizeImageFit(img As Image, btn As Button) As Image
        Dim newWidth As Integer = btn.ClientSize.Width
        Dim newHeight As Integer = btn.ClientSize.Height

        Dim bmp As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using
        Return bmp
    End Function

    Public Sub FormCloseParent(sender As Object, e As EventArgs)
        Form1.Dispose()
    End Sub

End Module