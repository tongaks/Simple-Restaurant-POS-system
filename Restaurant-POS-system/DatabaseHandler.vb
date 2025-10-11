Imports System.IO
'Imports System.Windows.Controls
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Module GlobalFunctions
    Public Structure TagData
        Public Price As String
        Public TagImagePath As String
    End Structure

    Public Structure SettingsConfigStruct
        Public MenuItemButtonSize As Integer
        Public MenuItemFontSize As Integer
        Public EnableShortcutKeys As Boolean
    End Structure

    Public CurrentUser As String
    Public IsAdmin As Boolean
    Public SettingsConfig As SettingsConfigStruct


    ' For mysqlconnection
    Public Function GetGlobalConnectionString() As String
        Return "server=localhost;user=root;database=restaurant;port=3306;password=washer22456;"
    End Function




    ' CRUD (Login, Insert activity, get settings confonig)
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


    ' Textbox things
    Public Sub TextHint(ByVal txtbox As TextBox, ByVal text As String)
        If Not txtbox.Focused And String.IsNullOrEmpty(txtbox.Text) Then
            txtbox.ForeColor = Color.Gray
            txtbox.Text = text
        Else
            txtbox.ForeColor = Color.Black
            txtbox.Clear()
        End If
    End Sub
    Public Sub HandleNumberOnly(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And Not Asc(e.KeyChar) = 8 Then
            e.Handled = True
        End If
    End Sub


    ' Image resize
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


    ' random
    Public Function CreateFoodItemButton(itemName As String, itemPrice As String, imgPath As String) As FlowLayoutPanel
        ' Create the main button
        Dim foodBtn As New Button With {
            .Text = itemName,
            .Size = New Size(100, 100),
            .Margin = New Padding(0),
            .Cursor = Cursors.Hand,
            .FlatStyle = FlatStyle.Flat
        }

        ' Store data in Tag (use a consistent format or create a TagData class)
        foodBtn.Tag = itemPrice
        If Not String.IsNullOrEmpty(imgPath) AndAlso File.Exists(imgPath) Then
            Try
                Using image As Image = Image.FromFile(imgPath)
                    foodBtn.BackgroundImage = ResizeImageFit(image, foodBtn)
                    foodBtn.BackgroundImageLayout = ImageLayout.Stretch
                End Using
                foodBtn.Tag &= "," & imgPath
            Catch ex As Exception
                MsgBox("Error loading image: " & ex.Message, MsgBoxStyle.Critical, "Image Load Error")
            End Try
        End If

        ' Price label
        Dim foodPrice As New Label With {
        .Text = "₱" & itemPrice,
        .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
        .TextAlign = ContentAlignment.MiddleCenter,
        .AutoSize = False,
        .Width = 100,
        .Height = 25
    }

        ' Container panel for button + label
        Dim container As New FlowLayoutPanel With {
        .Size = New Size(100, 125),
        .FlowDirection = FlowDirection.TopDown,
        .WrapContents = False,
        .AutoSize = False,
        .Margin = New Padding(5)
    }

        container.Controls.Add(foodBtn)
        container.Controls.Add(foodPrice)

        Return container
    End Function

    Public Function ExtractTag(tag As String) As TagData
        Dim result As New TagData()

        If tag.Contains(",") Then
            Dim tagInfo() As String = tag.Split(","c)
            result.Price = tagInfo(0).Trim()
            result.TagImagePath = tagInfo(1).Trim()
        Else
            result.Price = tag.Trim()
            result.TagImagePath = String.Empty ' or Nothing
        End If

        Return result
    End Function


End Module