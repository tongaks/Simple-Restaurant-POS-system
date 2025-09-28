Imports System.IO

Module GlobalFunctions
    Private ReadOnly DirInfo As DirectoryInfo = GetBaseDirectory()
    Public CurrentUser As String

    Public Function GetGlobalConnectionString() As String
        Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & DirInfo.FullName & "\MSAccess\Restaurant.accdb ;Persist Security Info=False;"
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
End Module