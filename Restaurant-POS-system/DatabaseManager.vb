Imports System.Text
Imports System.Diagnostics
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

''' <summary>
''' DatabaseManager
''' - Idempotently ensures required database, tables and columns exist.
''' - Safe: checks information_schema before altering.
''' - Call DatabaseManager.EnsureSchemaExists() at app startup (before operations that query tables).
''' </summary>
Public Module DatabaseManager

    Private ReadOnly Property ConnString As String
        Get
            ' Reuse project's global connection string provider.
            Return GetGlobalConnectionString()
        End Get
    End Property

    ' Keep track of shown error messages (so each distinct message is shown only once)
    Private ReadOnly shownErrorsLock As New Object()
    Private ReadOnly shownErrors As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

    ' Public helper: show a concise error dialog only once per unique message
    Public Sub ShowErrorOnce(message As String, Optional caption As String = "Database Error")
        If String.IsNullOrEmpty(message) Then Return
        SyncLock shownErrorsLock
            If shownErrors.Contains(message) Then
                Return
            End If
            shownErrors.Add(message)
        End SyncLock

        Try
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch
            ' swallow
        End Try
    End Sub

    ''' <summary>
    ''' Public entry point. Ensures database, core tables, per-category tables and required columns exist.
    ''' Safe to call multiple times.
    ''' </summary>
    Public Sub EnsureSchemaExists()
        Try
            ' If DB doesn't exist, create it first.
            EnsureDatabaseExists()

            ' Ensure core tables
            EnsureTable_Categories()
            EnsureTable_Settings()
            EnsureTable_User()
            EnsureTable_ActivityLogs()
            EnsureTable_ArchivedUsers()

            ' Ensure per-category menu tables (names must match entries in Categories table or default set)
            Dim defaultCategories = New String() {"Foods", "Drinks", "Snacks_Sides", "Desserts"}
            For Each cat In defaultCategories
                EnsureMenuTable(cat)
                EnsureCategoryRow(cat)
            Next

            Debug.WriteLine("DatabaseManager: schema check completed.")
        Catch ex As Exception
            ShowErrorOnce("Failed to verify/create database schema: " & ex.Message)
        End Try
    End Sub

    ' ----------------------------
    ' DATABASE / HELPER FUNCTIONS
    ' ----------------------------
    Private Sub EnsureDatabaseExists()
        Dim cs = ConnString
        Try
            ' Try open with current connection string.
            Using c As New MySqlConnection(cs)
                c.Open()
                c.Close()
            End Using
        Catch mex As MySqlException
            ' Unknown database (1049) or other server-level errors.
            If mex.Number = 1049 Then
                ' Remove database from connection string and create database.
                Dim serverConn = RemoveDatabaseFromConnectionString(cs)
                Using c As New MySqlConnection(serverConn)
                    c.Open()
                    Dim dbName = ExtractDatabaseName(cs)
                    If String.IsNullOrEmpty(dbName) Then
                        Throw New Exception("Cannot determine database name from connection string.")
                    End If

                    Dim createSql As String = $"CREATE DATABASE IF NOT EXISTS `{dbName}` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;"
                    Using cmd As New MySqlCommand(createSql, c)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Else
                Throw
            End If
        End Try
    End Sub

    Private Function RemoveDatabaseFromConnectionString(conn As String) As String
        Dim parts = conn.Split(";"c)
        Dim keep = New List(Of String)
        For Each p In parts
            Dim t = p.Trim()
            If String.IsNullOrEmpty(t) Then Continue For
            Dim lower = t.ToLowerInvariant()
            If lower.StartsWith("database=") OrElse lower.StartsWith("initial catalog=") Then
                Continue For
            End If
            keep.Add(t)
        Next
        Return String.Join(";", keep) & ";"
    End Function

    Private Function ExtractDatabaseName(conn As String) As String
        Dim parts = conn.Split(";"c)
        For Each p In parts
            If String.IsNullOrWhiteSpace(p) Then Continue For
            Dim kv = p.Split("="c, 2)
            If kv.Length <> 2 Then Continue For
            Dim key = kv(0).Trim().ToLowerInvariant()
            Dim val = kv(1).Trim()
            If key = "database" OrElse key = "initial catalog" Then
                Return val
            End If
        Next
        Return ""
    End Function

    Private Function TableExists(tableName As String) As Boolean
        Dim db = ExtractDatabaseName(ConnString)
        Using c As New MySqlConnection(ConnString)
            c.Open()
            Dim sql = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = @db AND table_name = @table"
            Using cmd As New MySqlCommand(sql, c)
                cmd.Parameters.AddWithValue("@db", db)
                cmd.Parameters.AddWithValue("@table", tableName)
                Dim cnt = Convert.ToInt32(cmd.ExecuteScalar())
                Return cnt > 0
            End Using
        End Using
    End Function

    Private Function ColumnExists(tableName As String, columnName As String) As Boolean
        Dim db = ExtractDatabaseName(ConnString)
        Using c As New MySqlConnection(ConnString)
            c.Open()
            Dim sql = "SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = @db AND table_name = @table AND column_name = @col"
            Using cmd As New MySqlCommand(sql, c)
                cmd.Parameters.AddWithValue("@db", db)
                cmd.Parameters.AddWithValue("@table", tableName)
                cmd.Parameters.AddWithValue("@col", columnName)
                Dim cnt = Convert.ToInt32(cmd.ExecuteScalar())
                Return cnt > 0
            End Using
        End Using
    End Function

    Private Function HasAutoIncrementColumn(tableName As String) As Boolean
        Dim db = ExtractDatabaseName(ConnString)
        Using c As New MySqlConnection(ConnString)
            c.Open()
            Dim sql = "SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = @db AND table_name = @table AND extra LIKE '%auto_increment%'"
            Using cmd As New MySqlCommand(sql, c)
                cmd.Parameters.AddWithValue("@db", db)
                cmd.Parameters.AddWithValue("@table", tableName)
                Dim cnt = Convert.ToInt32(cmd.ExecuteScalar())
                Return cnt > 0
            End Using
        End Using
    End Function

    Private Function GetPrimaryKeyColumn(tableName As String) As String
        Dim db = ExtractDatabaseName(ConnString)
        Using c As New MySqlConnection(ConnString)
            c.Open()
            Dim sql = "SELECT column_name FROM information_schema.key_column_usage WHERE table_schema = @db AND table_name = @table AND constraint_name = 'PRIMARY' LIMIT 1"
            Using cmd As New MySqlCommand(sql, c)
                cmd.Parameters.AddWithValue("@db", db)
                cmd.Parameters.AddWithValue("@table", tableName)
                Dim res = cmd.ExecuteScalar()
                If res Is Nothing OrElse res Is DBNull.Value Then
                    Return String.Empty
                End If
                Return res.ToString()
            End Using
        End Using
    End Function

    Private Sub ExecuteNonQuery(sql As String, Optional params As Dictionary(Of String, Object) = Nothing)
        Using c As New MySqlConnection(ConnString)
            c.Open()
            Using cmd As New MySqlCommand(sql, c)
                If params IsNot Nothing Then
                    For Each kv In params
                        cmd.Parameters.AddWithValue(kv.Key, kv.Value)
                    Next
                End If
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' ----------------------------
    ' CORE TABLES ENSURERS
    ' ----------------------------
    Private Sub EnsureTable_Categories()
        Dim t = "Categories"
        If Not TableExists(t) Then
            Dim sql = "
CREATE TABLE IF NOT EXISTS `Categories` (
  `CategoryName` VARCHAR(100) NOT NULL PRIMARY KEY
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"
            ExecuteNonQuery(sql)
        End If
    End Sub

    Private Sub EnsureCategoryRow(category As String)
        Using c As New MySqlConnection(ConnString)
            c.Open()
            Dim sql = "SELECT COUNT(*) FROM `Categories` WHERE CategoryName = @name"
            Using cmd As New MySqlCommand(sql, c)
                cmd.Parameters.AddWithValue("@name", category)
                Dim cnt = Convert.ToInt32(cmd.ExecuteScalar())
                If cnt = 0 Then
                    Using ins As New MySqlCommand("INSERT INTO `Categories` (CategoryName) VALUES (@name)", c)
                        ins.Parameters.AddWithValue("@name", category)
                        ins.ExecuteNonQuery()
                    End Using
                End If
            End Using
        End Using
    End Sub

    Private Sub EnsureTable_Settings()
        Dim t = "settings"
        If Not TableExists(t) Then
            Dim sql = "
CREATE TABLE IF NOT EXISTS `settings` (
  `MenuItemButtonSize` INT DEFAULT 100,
  `MenuItemFontSize` INT DEFAULT 10,
  `EnableShortcutKeys` TINYINT(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"
            ExecuteNonQuery(sql)
        End If
    End Sub

    Private Sub EnsureTable_User()
        Dim t = "user"
        If Not TableExists(t) Then
            Dim sql = "
CREATE TABLE IF NOT EXISTS `user` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `username` VARCHAR(50) NOT NULL UNIQUE,
  `password` VARCHAR(255) NOT NULL,
  `role` VARCHAR(20) DEFAULT 'cashier',
  `date_created` DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"
            ExecuteNonQuery(sql)
        End If
    End Sub

    Private Sub EnsureTable_ActivityLogs()
        Dim t = "activity_logs"
        If Not TableExists(t) Then
            Dim sql = "
CREATE TABLE IF NOT EXISTS `activity_logs` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `username` VARCHAR(50),
  `role` VARCHAR(20),
  `action` TEXT,
  `log_time` DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"
            ExecuteNonQuery(sql)
        End If
    End Sub

    Private Sub EnsureTable_ArchivedUsers()
        Dim t = "archived_users"
        If Not TableExists(t) Then
            Dim sql = "
CREATE TABLE IF NOT EXISTS `archived_users` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `username` VARCHAR(50) NOT NULL,
  `password` VARCHAR(255) NOT NULL,
  `role` VARCHAR(20),
  `date_created` DATETIME,
  `archived_date` DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"
            ExecuteNonQuery(sql)
        End If
    End Sub

    ' ----------------------------
    ' MENU TABLE ENSURER
    ' ----------------------------
    Private Sub EnsureMenuTable(tableName As String)
        ' Name is expected to be safe (no slashes). If your Categories rows use different display names,
        ' either migrate Categories to match table names, or change the mapping in code.
        If Not TableExists(tableName) Then
            Dim sql = $"
CREATE TABLE IF NOT EXISTS `{tableName}` (
  `ItemId` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `ItemName` VARCHAR(255) NOT NULL,
  `ItemPrice` DECIMAL(10,2) NOT NULL DEFAULT 0.00,
  `ImagePath` VARCHAR(1024) DEFAULT 'N/A',
  `DateAdded` DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"
            ExecuteNonQuery(sql)
            Return
        End If

        ' If table exists, ensure required columns exist and add them if missing.
        If Not ColumnExists(tableName, "ItemId") Then
            Try
                ' If table already has a standard 'id' column, add ItemId column and keep it synchronized.
                If ColumnExists(tableName, "id") Then
                    ' Add nullable ItemId, populate existing rows, create AFTER INSERT trigger to keep ItemId set for new rows.
                    ExecuteNonQuery($"ALTER TABLE `{tableName}` ADD COLUMN `ItemId` INT NULL;")
                    ExecuteNonQuery($"UPDATE `{tableName}` SET `ItemId` = `id` WHERE `ItemId` IS NULL;")

                    ' Drop any existing trigger with same name then create a trigger that keeps ItemId populated after insert.
                    Try
                        ExecuteNonQuery($"DROP TRIGGER IF EXISTS `{tableName}_set_itemid`;")
                        Dim createTrig As String = $"
CREATE TRIGGER `{tableName}_set_itemid` AFTER INSERT ON `{tableName}`
FOR EACH ROW
BEGIN
  UPDATE `{tableName}` SET `ItemId` = NEW.id WHERE id = NEW.id;
END;"
                        ExecuteNonQuery(createTrig)
                    Catch trigEx As Exception
                        ' trigger creation might fail on some environments/privileges; log but continue
                        Debug.WriteLine($"DatabaseManager: failed to create trigger for {tableName}: {trigEx.Message}")
                    End Try

                ElseIf Not HasAutoIncrementColumn(tableName) Then
                    ' Safe to create an AUTO_INCREMENT primary key if no auto column exists
                    ExecuteNonQuery($"ALTER TABLE `{tableName}` ADD COLUMN `ItemId` INT NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;")
                Else
                    ' Table has some auto-increment PK already (different name). Try to find PK and populate a nullable ItemId
                    Dim pkCol = GetPrimaryKeyColumn(tableName)
                    If Not String.IsNullOrEmpty(pkCol) Then
                        ExecuteNonQuery($"ALTER TABLE `{tableName}` ADD COLUMN `ItemId` INT NULL;")
                        ExecuteNonQuery($"UPDATE `{tableName}` SET `ItemId` = `{pkCol}` WHERE `ItemId` IS NULL;")
                    Else
                        ' Fallback: add nullable ItemId and notify user (only once)
                        ExecuteNonQuery($"ALTER TABLE `{tableName}` ADD COLUMN `ItemId` INT NULL;")
                        ShowErrorOnce($"Added nullable ItemId to table '{tableName}'. Please populate it or adjust schema manually.")
                    End If
                End If
            Catch ex As Exception
                Debug.WriteLine($"DatabaseManager: failed to add ItemId to {tableName}: {ex.Message}")
                ShowErrorOnce($"Failed to add ItemId column to table `{tableName}`. Error: {ex.Message}")
            End Try
        End If

        If Not ColumnExists(tableName, "ItemName") Then
            ExecuteNonQuery($"ALTER TABLE `{tableName}` ADD COLUMN `ItemName` VARCHAR(255) NOT NULL AFTER `ItemId`;")
        End If

        If Not ColumnExists(tableName, "ItemPrice") Then
            ExecuteNonQuery($"ALTER TABLE `{tableName}` ADD COLUMN `ItemPrice` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `ItemName`;")
        End If

        If Not ColumnExists(tableName, "ImagePath") Then
            ExecuteNonQuery($"ALTER TABLE `{tableName}` ADD COLUMN `ImagePath` VARCHAR(1024) DEFAULT 'N/A' AFTER `ItemPrice`;")
        End If

        If Not ColumnExists(tableName, "DateAdded") Then
            ExecuteNonQuery($"ALTER TABLE `{tableName}` ADD COLUMN `DateAdded` DATETIME DEFAULT CURRENT_TIMESTAMP AFTER `ImagePath`;")
        End If
    End Sub

End Module