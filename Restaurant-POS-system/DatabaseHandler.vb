Imports System.IO
Imports MySql.Data.MySqlClient

Module GlobalFunctions
    Private ReadOnly DirInfo As DirectoryInfo = GetBaseDirectory()
    Public CurrentUser As String
    Public IsAdmin As Boolean

    Public Function GetGlobalConnectionString() As String
        Return "server=localhost;user=root;database=restaurant;port=3306;password=washer22456;"
    End Function




    ' CRUD (Login, Insert activity)
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

    Public Function CreateFoodItemButton(itemName As String, itemPrice As String, imgPath As String) As FlowLayoutPanel
        Dim foodBtn As New Button With {
        .Text = itemName,
        .Size = New Size(100, 100),
        .Margin = New Padding(0),
        .Cursor = Cursors.Hand,
        .Tag = itemPrice
    }

        If Not String.IsNullOrEmpty(imgPath) Then
            Dim image As Image = Image.FromFile(imgPath)
            foodBtn.BackgroundImage = ResizeImageFit(image, foodBtn)
            foodBtn.Tag &= "," & imgPath
        End If

        Dim foodPrice As New Label
        foodPrice.Text = "₱" & itemPrice
        foodPrice.Font = New Font("Segue UI", 18.0F, FontStyle.Regular)
        foodPrice.TextAlign = ContentAlignment.MiddleCenter

        Dim container As New FlowLayoutPanel With {
            .Size = New Size(100, 100 + foodPrice.Size.Height)
        }

        container.Controls.Add(foodBtn)
        container.Controls.Add(foodPrice)

        Return container
    End Function

    Public Function ExtractTag(tag As String)
        Dim price As String
        Dim tagImgPath As String
        If tag.Contains(",") Then
            Dim tagInfo() As String = tag.Split(","c)
            price = tagInfo(0)
            tagImgPath = tagInfo(1)
            Return (price, tagImgPath)
        Else
            price = tag
            Return tag
        End If
    End Function

End Module