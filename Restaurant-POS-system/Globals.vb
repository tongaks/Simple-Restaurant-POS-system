Imports System.Drawing
Imports System.IO
'Imports System.Windows.Controls
Imports System.Windows.Forms
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Module Globals
    ' Application-wide current user and admin flag
    Public CurrentUser As String = String.Empty
    Public IsAdmin As Boolean = False


    ' for food ordering/manage
    Public MenuItems As New List(Of Guna2PictureBox)
    Public MenuCategories As New List(Of Guna2Button)
    Public CurrentCategory As Guna2Button = Nothing
    Public PrevCategory As Guna2Button = Nothing

    Public Structure UserAccount
        Public Property ID As Integer
        Public Property Username As String
        Public Property Password As String
        Public Property Role As String
        Public Property DateCreated As DateTime
    End Structure

    ' for theme
    Public BackPanel() As Panel
    Public FlowPanel() As Panel

    Public Sub SetTheme()
        If BackPanel.Length > 0 Or FlowPanel.Length > 0 Then
            SetBackTheme(BackPanel)
            SetFlowTheme(FlowPanel)
        Else
            MsgBox("Panels are empty", MsgBoxStyle.Critical, "Error")
            Return
        End If
    End Sub
    Public Sub SetBackTheme(panels() As Panel)
        For Each pnl As Control In panels
            If pnl IsNot Nothing Then
                pnl.BackColor = ColorTranslator.FromHtml(SettingsConfig.BarTheme)
            End If
        Next
    End Sub
    Public Sub SetFlowTheme(panels() As Panel)
        For Each pnl As Control In panels
            If pnl IsNot Nothing Then
                pnl.BackColor = ColorTranslator.FromHtml(SettingsConfig.BackgroundTheme)
            End If
        Next
    End Sub


    Public Sub EnsureItemPictureDirectoryExists()
        Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        Dim itemPicturePath As String = Path.Combine(documentsPath, "OrderUp", "ItemPicture")

        If Not Directory.Exists(itemPicturePath) Then
            Directory.CreateDirectory(itemPicturePath)
        End If
    End Sub





    ' for ordering/manage form for menu panel
    Public Function CreateFoodItemCard(itemName As String, itemPrice As String, imgPath As String) As Guna.UI2.WinForms.Guna2Panel
        Dim cardWidth As Integer = 160
        Dim cardHeight As Integer = 200
        Dim paddingVal As Integer = 10
        Dim fontSize As Integer = 11

        ' Create the card panel
        Dim foodCard As New Guna.UI2.WinForms.Guna2Panel With {
        .Width = cardWidth,
        .Height = cardHeight,
        .BorderRadius = 12,
        .BackColor = Color.White,
        .FillColor = Color.White,
        .Margin = New Padding(10),
        .Tag = itemName
    }

        ' Add shadow to the card
        foodCard.ShadowDecoration.Enabled = True
        foodCard.ShadowDecoration.BorderRadius = 12
        foodCard.ShadowDecoration.Color = Color.Silver
        foodCard.ShadowDecoration.Depth = 10
        foodCard.ShadowDecoration.Shadow = New Padding(2, 2, 4, 4)

        ' Create the picture box for the food image
        Dim foodImg As New Guna.UI2.WinForms.Guna2PictureBox With {
        .Size = New Size(cardWidth - (paddingVal * 2), 100),
        .Location = New Point(paddingVal, paddingVal),
        .SizeMode = PictureBoxSizeMode.Zoom,
        .BorderRadius = 10,
        .FillColor = Color.WhiteSmoke,
        .Cursor = Cursors.Hand,
        .Tag = itemPrice,
        .Text = itemName
    }

        ' Check if an image path is provided
        Dim hasImage As Boolean = False
        If Not String.IsNullOrEmpty(imgPath) AndAlso imgPath <> "N/A" AndAlso File.Exists(imgPath) Then
            foodImg.Image = Image.FromFile(imgPath)
            foodImg.Tag &= "," & imgPath
            hasImage = True
        End If

        ' If no image, show "No Image" label
        If Not hasImage Then
            foodImg.Image = Nothing
            foodImg.FillColor = Color.LightGray

            Dim noImageLbl As New Label With {
            .Text = "No Image",
            .Font = New Font("Segoe UI", 10, FontStyle.Italic),
            .ForeColor = Color.DimGray,
            .BackColor = Color.Transparent,
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleCenter
        }
            foodImg.Controls.Add(noImageLbl)
        End If

        ' Create the label for the food name
        Dim foodName As New Label With {
        .Text = itemName,
        .Font = New Font("Segoe UI Semibold", fontSize, FontStyle.Bold),
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Width = cardWidth - (paddingVal * 2),
        .Height = 30,
        .Location = New Point(paddingVal, foodImg.Bottom + 5)
    }

        ' Create the label for the food price
        Dim foodPrice As New Label With {
        .Text = "₱" & itemPrice,
        .Font = New Font("Segoe UI", 14, FontStyle.Regular),
        .ForeColor = Color.Navy,
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Width = cardWidth - (paddingVal * 2),
        .Height = 25,
        .Location = New Point(paddingVal, foodName.Bottom)
    }

        ' Add the controls to the card
        foodCard.Controls.Add(foodImg)
        foodCard.Controls.Add(foodName)
        foodCard.Controls.Add(foodPrice)

        ' Add mouse enter and leave events for hover effects
        AddHandler foodCard.MouseEnter, Sub()
                                            foodCard.FillColor = Color.FromArgb(245, 245, 245)
                                            foodCard.ShadowDecoration.Color = Color.LightGray
                                        End Sub
        AddHandler foodCard.MouseLeave, Sub()
                                            foodCard.FillColor = Color.White
                                            foodCard.ShadowDecoration.Color = Color.Silver
                                        End Sub

        MenuItems.Add(foodImg)
        Return foodCard
    End Function
    Public Sub LoadMenuCategories(panel As FlowLayoutPanel)
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Dim Reader As MySqlDataReader
        MenuCategories.Clear()

        Try
            Connection.Open()
            Dim Query As String = "SELECT * FROM Categories"
            Dim Command As New MySqlCommand(Query, Connection)
            Reader = Command.ExecuteReader

            While Reader.Read
                Dim catBtn As New Guna2Button
                catBtn.Text = Reader("CategoryName")
                'catBtn.Size = New System.Drawing.Size(100, 50)
                catBtn.AutoSize = True
                catBtn.Padding = New Padding(10)

                catBtn.ForeColor = Color.Navy
                catBtn.Font = New Font("Segoe UI", 12, FontStyle.Regular)

                catBtn.BorderRadius = 10
                catBtn.ShadowDecoration.Enabled = True
                catBtn.ShadowDecoration.BorderRadius = 10
                catBtn.ShadowDecoration.Color = Color.DimGray
                catBtn.ShadowDecoration.Depth = 20
                catBtn.ShadowDecoration.Shadow = New Padding(-1, -1, 5, 5)

                catBtn.FillColor = Color.LightSteelBlue
                catBtn.Cursor = Cursors.Hand

                panel.Controls.Add(catBtn)
                MenuCategories.Add(catBtn)

            End While

        Catch ex As Exception
            MsgBox("Error: " + ex.ToString, MsgBoxStyle.Critical, "ERROR")
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Sub
    Public Sub LoadMenuItems(table As String, panel As FlowLayoutPanel)
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Dim Reader As MySqlDataReader

        If MenuItems.Count > 0 Then MenuItems.Clear()

        Try
            Connection.Open()
            Dim Query As String = "SELECT * FROM `" & table & "`"
            Dim Command As New MySqlCommand(Query, Connection)
            Reader = Command.ExecuteReader

            panel.Controls.Clear()

            While Reader.Read
                Dim imgPath As String = If(IsDBNull(Reader("ImagePath")), "N/A", Reader("ImagePath"))
                Dim item As Guna2Panel = CreateFoodItemCard(Reader("ItemName"), Reader("ItemPrice"), imgPath)
                panel.Controls.Add(item)
            End While

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "ERROR")
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Sub




    ' uncategorixzed global functions/sub
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
    Public Function ResizeImageFit(img As Image, ctrl As Control) As Image
        If img Is Nothing OrElse ctrl Is Nothing OrElse ctrl.Width = 0 OrElse ctrl.Height = 0 Then
            Return Nothing
        End If

        Dim targetW = ctrl.Width
        Dim targetH = ctrl.Height
        Dim ratio = Math.Min(targetW / img.Width, targetH / img.Height)
        Dim newW = Math.Max(1, CInt(img.Width * ratio))
        Dim newH = Math.Max(1, CInt(img.Height * ratio))

        Dim bmp As New Bitmap(newW, newH)
        Using g = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newW, newH)
        End Using
        Return bmp
    End Function
    Public Sub FormCloseParent(sender As Object, e As FormClosedEventArgs)
        Dim frm = TryCast(sender, Form)
        If frm Is Nothing Then Return
        Try
            If frm.Owner IsNot Nothing Then
                frm.Owner.Close()
            End If
        Catch
            ' silent
        End Try
    End Sub
    Public Sub HandleNumberOnly(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And Not Asc(e.KeyChar) = 8 Then
            e.Handled = True
        End If
    End Sub

End Module