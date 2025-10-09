Imports System.Data.OleDb
Imports System.Data.Common
Imports System.IO
Imports System.Reflection.Metadata.Ecma335
Imports MySql.Data.MySqlClient

Public Class Form1
    Public ConnectionString As String

    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectionString = GetGlobalConnectionString()
        Me.WindowState = WindowState.Maximized
        IsAdmin = False
    End Sub


    ' Button
    Private Sub LoginAsAdmin_Click(sender As Object, e As EventArgs) Handles LoginAsAdminBtn.Click
        If IsAdmin = False Then
            IsAdmin = True
            UsernameLbl.Text = "Admin username"
            PasswordLbl.Text = "Admin password"
            LoginAsAdminBtn.Text = "Login as User"
        Else
            IsAdmin = False
            UsernameLbl.Text = "Username"
            PasswordLbl.Text = "Password"
            LoginAsAdminBtn.Text = "Login as Admin"
        End If
    End Sub
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Dim table As String = If((IsAdmin), "admin", "user")

        If String.IsNullOrWhiteSpace(UsernameTxtBox.Text) Or String.IsNullOrWhiteSpace(PasswordTxtBox.Text) Then
            MsgBox("Please complete the user credentials.", MsgBoxStyle.Critical, "Attention")
            Return
        End If

        HandleLogin(table)
    End Sub


    ' Handlers
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
            Dim Connection As New MySqlConnection(ConnectionString)

            Try
                Connection.Open()
                Dim Query As String = "INSERT INTO loginlogs (Username, DateLogin, TimeLogin, Role) VALUES (@uname, @date, @time, @role)"
                Dim Command As New MySqlCommand(Query, Connection)
                Command.Parameters.AddWithValue("@uname", CurrentUser)
                Command.Parameters.AddWithValue("@date", DateTime.Now.Date)
                Command.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay)
                Command.Parameters.AddWithValue("@role", If(IsAdmin, "admin", "user"))

                If Command.ExecuteNonQuery() > 0 Then
                    If IsAdmin Then
                        Admin.Show()
                    Else
                        Order.Show(Me)
                    End If
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
