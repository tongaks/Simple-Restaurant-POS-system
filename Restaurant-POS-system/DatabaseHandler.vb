Imports MySql.Data.MySqlClient
Imports System.Data

''' <summary>
''' Represents a user account with all relevant fields
''' </summary>
Public Class UserAccount
    Public Property ID As Integer
    Public Property Username As String
    Public Property Password As String
    Public Property Role As String
    Public Property DateCreated As DateTime
End Class

''' <summary>
''' Database handler for user account management operations
''' </summary>
Public Class DatabaseHandler

    ''' <summary>
    ''' Ensure archived_users table exists with same structure as users table
    ''' </summary>
    Public Shared Sub EnsureArchivedUsersTableExists()
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

    ''' <summary>
    ''' Get all active users with optional search filter
    ''' </summary>
    Public Shared Function GetAllUsers(Optional searchFilter As String = "") As List(Of UserAccount)
        Dim users As New List(Of UserAccount)()

        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                Dim query As String = "SELECT id, username, password, role, date_created FROM user WHERE 1=1"

                If Not String.IsNullOrEmpty(searchFilter) Then
                    query &= " AND (username LIKE @search OR role LIKE @search)"
                End If

                query &= " ORDER BY date_created DESC"

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
                                .Role = reader("role").ToString(),
                                .DateCreated = Convert.ToDateTime(reader("date_created"))
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return users
    End Function

    ''' <summary>
    ''' Create a new user account
    ''' </summary>
    Public Shared Function CreateUser(username As String, password As String, role As String) As Boolean
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

    ''' <summary>
    ''' Update an existing user account
    ''' </summary>
    Public Shared Function UpdateUser(userId As Integer, username As String, password As String, role As String) As Boolean
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

    ''' <summary>
    ''' Delete a user account permanently
    ''' </summary>
    Public Shared Function DeleteUser(userId As Integer) As Boolean
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

    ''' <summary>
    ''' Archive a user account (move to archived_users table)
    ''' </summary>
    Public Shared Function ArchiveUser(userId As Integer) As Boolean
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

End Class