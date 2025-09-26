Imports System.Data.OleDb
Imports System.Data.Common
Imports System.IO
Imports System.Reflection.Metadata.Ecma335

Public Class Form1
    Dim ConnectionString As String

    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CurrentPath As String = Directory.GetCurrentDirectory()
        Dim DirInfo As New DirectoryInfo(CurrentPath)

        ' move 4 up para tumutok sa parent dir ng project
        For i As Integer = 1 To 4
            If DirInfo.Parent IsNot Nothing Then
                DirInfo = DirInfo.Parent
            Else
                Exit For
            End If
        Next

        ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & DirInfo.FullName & "\MSAccess\Restaurant.accdb ;Persist Security Info=False;"
    End Sub

    Public Function GetConnectionString()
        Return ConnectionString
    End Function

    Private Function Login(uname As String, passw As String)
        Dim Connection As New OleDbConnection(ConnectionString)
        Dim Reader As OleDbDataReader

        Try
            Connection.Open()
            Dim Query As String = "SELECT * from Admin WHERE Username = @Username AND Password = @Password"
            Dim Command As New OleDbCommand(Query, Connection)

            Command.Parameters.AddWithValue("@Username", uname)
            Command.Parameters.AddWithValue("@Password", passw)

            Reader = Command.ExecuteReader()

            If Reader.HasRows Then
                MsgBox("Successful login")
            Else
                MsgBox("Invalid username or password")
                Return False
            End If

        Catch ex As Exception
            MsgBox("Error on trying to login: " + ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try

        Return True
    End Function

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        If String.IsNullOrWhiteSpace(UsernameTxtBox.Text) Or String.IsNullOrWhiteSpace(PasswordTxtBox.Text) Then
            MsgBox("Please complete the credentials.")
            Return
        End If

        If Login(UsernameTxtBox.Text, PasswordTxtBox.Text) Then
            Order.Show(Me)
            Hide()
        End If
    End Sub
End Class
