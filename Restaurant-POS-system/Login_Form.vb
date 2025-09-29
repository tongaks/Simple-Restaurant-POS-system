Imports System.Data.OleDb
Imports System.Data.Common
Imports System.IO
Imports System.Reflection.Metadata.Ecma335

Public Class Form1
    Public ConnectionString As String

    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectionString = GetGlobalConnectionString()
        Me.WindowState = WindowState.Maximized
        IsAdmin = False
    End Sub

    Private Function Login(uname As String, passw As String, table As String)
        Dim Connection As New OleDbConnection(ConnectionString)
        Dim Reader As OleDbDataReader

        Try
            Connection.Open()
            Dim Query As String = "SELECT * from [" & table & "] WHERE Username = @Username AND Password = @Password"
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

    Private Sub LoginAsAdmin_Click(sender As Object, e As EventArgs) Handles LoginAsAdminBtn.Click
        If IsAdmin = False Then
            IsAdmin = True
            UsernameLbl.Text = "Admin username"
            PasswordLbl.Text = "Admin password"
        Else
            IsAdmin = False
            UsernameLbl.Text = "Username"
            PasswordLbl.Text = "Password"
        End If
    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Dim table As String = If((IsAdmin), "Admin", "User")
        MsgBox("table: " & table)

        If String.IsNullOrWhiteSpace(UsernameTxtBox.Text) Or String.IsNullOrWhiteSpace(PasswordTxtBox.Text) Then
            MsgBox("Please complete the user credentials.", MsgBoxStyle.Critical, "Attention")
            Return
        End If

        HandleLogin(table)
    End Sub

    Private Sub HandleEnter(sender As Object, e As KeyPressEventArgs) Handles UsernameTxtBox.KeyPress, PasswordTxtBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim table As String = If((IsAdmin), "Admin", "User")
            MsgBox("table: " & table)
            HandleLogin(table)
        End If
    End Sub

    Private Sub HandleLogin(table As String)
        If Login(UsernameTxtBox.Text, PasswordTxtBox.Text, table) Then
            CurrentUser = UsernameTxtBox.Text
            Dim Connection As New OleDbConnection(ConnectionString)

            Try
                Connection.Open()
                Dim Query As String = "INSERT INTO LoginLogs (Username, DateLogin, TimeLogin, Role) VALUES (?, ?, ?, ?)"
                Dim Command As New OleDbCommand(Query, Connection)
                Command.Parameters.AddWithValue("?", CurrentUser)
                Command.Parameters.AddWithValue("?", DateTime.Now.Date)
                Command.Parameters.AddWithValue("?", DateTime.Now.TimeOfDay)
                Command.Parameters.AddWithValue("?", "Role here")

                If Command.ExecuteNonQuery() > 0 Then
                    Order.Show(Me)
                    Me.Hide()
                Else
                    MsgBox("Failed to login", MsgBoxStyle.Critical, "Error logging in")
                End If

            Catch ex As Exception
                MsgBox("Error creating login log: " + ex.ToString, MsgBoxStyle.Critical, "Error creating log")

            Finally
                If Connection.State = ConnectionState.Open Then
                    Connection.Close()
                End If
            End Try

        End If
    End Sub
End Class
