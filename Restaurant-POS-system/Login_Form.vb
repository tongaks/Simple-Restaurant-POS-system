Imports System.Data.OleDb
Imports System.Data.Common
Imports System.IO
Imports System.Reflection.Metadata.Ecma335

Public Class Form1
    Public ConnectionString As String

    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectionString = GetGlobalConnectionString()
        Me.WindowState = WindowState.Maximized
    End Sub

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

            If Reader.HasRows = False Then
                MsgBox("Invalid username or password.", MsgBoxStyle.Critical, "Attention")
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
            MsgBox("Please complete the user credentials.", MsgBoxStyle.Critical, "Attention")
            Return
        End If

        If Login(UsernameTxtBox.Text, PasswordTxtBox.Text) Then
            CurrentUser = UsernameTxtBox.Text
            Order.Show(Me)
            'Admin.Show()
            Hide()
        End If
    End Sub

    Private Sub HandleEnter(sender As Object, e As KeyPressEventArgs) Handles UsernameTxtBox.KeyPress, PasswordTxtBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Login(UsernameTxtBox.Text, PasswordTxtBox.Text) Then
                CurrentUser = UsernameTxtBox.Text
                Order.Show()
                'Admin.Show()
                Me.Hide()
            End If
        End If
    End Sub
End Class
