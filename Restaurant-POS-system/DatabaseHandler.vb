Imports System.IO
'Imports System.Windows.Controls
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Module DatabaseHandler
    Public Structure TagData
        Public Price As String
        Public TagImagePath As String
    End Structure

    Public Structure SettingsConfigStruct
        Public MenuItemButtonSize As Integer
        Public MenuItemFontSize As Integer
        Public EnableShortcutKeys As Boolean
    End Structure

    Public SettingsConfig As SettingsConfigStruct


    ' For mysqlconnection
    Public Function GetGlobalConnectionString() As String
        'Return "server=localhost;userid=root;password=;database=restaurant;SslMode=none;"
        Return "server=localhost;user=root;database=restaurant;port=3306;password=washer22456;"
    End Function


    ' CRUD  related
    Public Function Login(uname As String, passw As String, table As String)
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Dim Reader As MySqlDataReader

        Try
            Connection.Open()
            Dim Query As String = "SELECT * from " & table & " WHERE Username = @Username AND Password = @Password"
            Dim Command As New MySqlCommand(Query, Connection)

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
    Public Sub InsertActivityLog(ByVal action As String)
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)

        Try
            Connection.Open()
            Dim Query As String = "INSERT INTO restaurant.activity_logs (username, role, action, log_time) VALUES (@user, @role, @action, @time)"
            Dim Command As New MySqlCommand(Query, Connection)
            Command.Parameters.AddWithValue("@user", CurrentUser)
            Command.Parameters.AddWithValue("@role", If((IsAdmin), "admin", "cashier"))
            Command.Parameters.AddWithValue("@action", action)

            Dim timeAndDate As String = Date.Now.ToString("MM/dd/yyyy HH:mm:ss")
            Command.Parameters.AddWithValue("@time", timeAndDate)

            If Not Command.ExecuteNonQuery > 0 Then
                MsgBox("Failed to insert activity log", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Failed to insert activity log: " & ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub GetSettingsConfig()
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)

        Try
            Connection.Open()
            Dim Query As String = "SELECT * FROM restaurant.settings"
            Dim Command As New MySqlCommand(Query, Connection)
            Dim Reader As MySqlDataReader
            Reader = Command.ExecuteReader

            If Reader.HasRows = False Then
                MsgBox("Settings configuration is unitialized", MsgBoxStyle.Critical, "Error")
                Return
            End If

            While Reader.Read
                SettingsConfig.MenuItemButtonSize = Reader("MenuItemButtonSize")
                SettingsConfig.MenuItemFontSize = Reader("MenuItemFontSize")
                SettingsConfig.EnableShortcutKeys = Reader("EnableShortcutKeys")
            End While

        Catch ex As Exception
            MsgBox("Failed to get the settings configureations", MsgBoxStyle.Critical, "Error")
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Sub
    ' CRUD  Archive functions
    Public Sub EnsureArchivedUsersTableExists()
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                Dim createTableQuery As String = "
                    CREATE TABLE IF NOT EXISTS archived_users (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        username VARCHAR(50) NOT NULL,
                        password VARCHAR(255) NOT NULL,
                        role VARCHAR(20) NOT NULL,
                        date_created DATETIME NOT NULL,
                        archived_date DATETIME DEFAULT CURRENT_TIMESTAMP
                    )"

                Using cmd As New MySqlCommand(createTableQuery, connection)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Log error but don't throw - table might already exist
            Console.WriteLine("EnsureArchivedUsersTableExists Error: " & ex.Message)
        End Try
    End Sub
    Public Function GetAllUsers(Optional searchFilter As String = "") As List(Of UserAccount)
        Dim users As New List(Of UserAccount)()

        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                'Dim query As String = "SELECT id, username, password, role, date_created FROM user WHERE 1=1"
                Dim query As String = "SELECT * FROM restaurant.user WHERE 1=1"

                If Not String.IsNullOrEmpty(searchFilter) Then
                    query &= " AND (username LIKE @search OR role LIKE @search)"
                End If

                'query &= " ORDER BY date_created DESC"

                Using cmd As New MySqlCommand(query, connection)
                    If Not String.IsNullOrEmpty(searchFilter) Then
                        cmd.Parameters.AddWithValue("@search", "%" & searchFilter & "%")
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            users.Add(New UserAccount With {
                                .ID = Convert.ToInt32(reader("id")),
                                .Username = reader("username").ToString(),
                                .Password = reader("password").ToString(),
                                .Role = "",
                                .DateCreated = Date.Now
                            })

                            '.Role = reader("role").ToString(),
                            '.DateCreated = Convert.ToDateTime(reader("date_created"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return users
    End Function
    Public Function CreateUser(username As String, password As String, role As String) As Boolean
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                ' Check if username already exists
                Dim checkQuery As String = "SELECT COUNT(*) FROM user WHERE username = @username"
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@username", username)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using

                ' Insert new user
                Dim insertQuery As String = "INSERT INTO user (username, password, role, date_created) VALUES (@username, @password, @role, @date)"
                Using cmd As New MySqlCommand(insertQuery, connection)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password) ' Note: In production, hash this password!
                    cmd.Parameters.AddWithValue("@role", role)
                    cmd.Parameters.AddWithValue("@date", DateTime.Now)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error creating user: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function UpdateUser(userId As Integer, username As String, password As String, role As String) As Boolean
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                ' Check if new username already exists (excluding current user)
                Dim checkQuery As String = "SELECT COUNT(*) FROM user WHERE username = @username AND id <> @id"
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@username", username)
                    checkCmd.Parameters.AddWithValue("@id", userId)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using

                ' Update user
                Dim updateQuery As String = "UPDATE user SET username = @username, password = @password, role = @role WHERE id = @id"
                Using cmd As New MySqlCommand(updateQuery, connection)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password) ' Note: In production, hash this password!
                    cmd.Parameters.AddWithValue("@role", role)
                    cmd.Parameters.AddWithValue("@id", userId)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating user: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function DeleteUser(userId As Integer) As Boolean
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                Dim deleteQuery As String = "DELETE FROM user WHERE id = @id"
                Using cmd As New MySqlCommand(deleteQuery, connection)
                    cmd.Parameters.AddWithValue("@id", userId)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting user: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function ArchiveUser(userId As Integer) As Boolean
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                ' Start transaction to ensure both operations succeed or fail together
                Using transaction As MySqlTransaction = connection.BeginTransaction()
                    Try
                        ' Get user data
                        Dim selectQuery As String = "SELECT username, password, role, date_created FROM user WHERE id = @id"
                        Dim username As String = ""
                        Dim password As String = ""
                        Dim role As String = ""
                        Dim dateCreated As DateTime

                        Using selectCmd As New MySqlCommand(selectQuery, connection, transaction)
                            selectCmd.Parameters.AddWithValue("@id", userId)

                            Using reader As MySqlDataReader = selectCmd.ExecuteReader()
                                If reader.Read() Then
                                    username = reader("username").ToString()
                                    password = reader("password").ToString()
                                    role = reader("role").ToString()
                                    dateCreated = Convert.ToDateTime(reader("date_created"))
                                Else
                                    Return False
                                End If
                            End Using
                        End Using

                        ' Insert into archived_users
                        Dim insertQuery As String = "INSERT INTO archived_users (username, password, role, date_created, archived_date) VALUES (@username, @password, @role, @dateCreated, @archivedDate)"
                        Using insertCmd As New MySqlCommand(insertQuery, connection, transaction)
                            insertCmd.Parameters.AddWithValue("@username", username)
                            insertCmd.Parameters.AddWithValue("@password", password)
                            insertCmd.Parameters.AddWithValue("@role", role)
                            insertCmd.Parameters.AddWithValue("@dateCreated", dateCreated)
                            insertCmd.Parameters.AddWithValue("@archivedDate", DateTime.Now)
                            insertCmd.ExecuteNonQuery()
                        End Using

                        ' Delete from user
                        Dim deleteQuery As String = "DELETE FROM user WHERE id = @id"
                        Using deleteCmd As New MySqlCommand(deleteQuery, connection, transaction)
                            deleteCmd.Parameters.AddWithValue("@id", userId)
                            deleteCmd.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                        Return True

                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error archiving user: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


End Module