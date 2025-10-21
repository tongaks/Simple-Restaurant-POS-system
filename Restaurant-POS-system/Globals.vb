Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Module Globals
    ' Application-wide current user and admin flag
    Public CurrentUser As String = String.Empty
    Public IsAdmin As Boolean = False

    Public Structure UserAccount
        Public Property ID As Integer
        Public Property Username As String
        Public Property Password As String
        Public Property Role As String
        Public Property DateCreated As DateTime
    End Structure

    ' Resize an Image to fit inside a control preserving aspect ratio
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


    ' Textbox things
    Public Sub HandleNumberOnly(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And Not Asc(e.KeyChar) = 8 Then
            e.Handled = True
        End If
    End Sub


    ' for ordering form for menu panel
    Public Function CreateFoodItemButton(itemName As String, itemPrice As String, imgPath As String) As FlowLayoutPanel
        ' Defensive defaults from settings (centralized)
        Dim btnSize As Integer = 100
        Dim fontSize As Single = 12.0F
        Try
            If DatabaseHandler.SettingsConfig.MenuItemButtonSize > 0 Then
                btnSize = DatabaseHandler.SettingsConfig.MenuItemButtonSize
            End If
            If DatabaseHandler.SettingsConfig.MenuItemFontSize > 0 Then
                fontSize = CSng(DatabaseHandler.SettingsConfig.MenuItemFontSize)
            End If
        Catch
            ' if SettingsConfig not initialized, use defaults
            btnSize = 100
            fontSize = 12.0F
        End Try

        ' Create the main button
        Dim foodBtn As New Button With {
            .Name = "btnFood",
            .Text = itemName,
            .Size = New Size(btnSize, btnSize),
            .Margin = New Padding(0),
            .Cursor = Cursors.Hand,
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.White,
            .ForeColor = Color.FromArgb(45, 45, 48)
        }
        foodBtn.FlatAppearance.BorderSize = 3
        foodBtn.FlatAppearance.BorderColor = Color.Gray

        ' Store data in Tag (use a consistent format)
        foodBtn.Tag = itemPrice
        If Not String.IsNullOrEmpty(imgPath) AndAlso File.Exists(imgPath) Then
            Try
                Using image As Image = Image.FromFile(imgPath)
                    Dim scaled = ResizeImageFit(image, foodBtn)
                    foodBtn.BackgroundImage = scaled
                    foodBtn.BackgroundImageLayout = ImageLayout.Stretch
                End Using
                foodBtn.Tag &= "," & imgPath
            Catch ex As Exception
                MsgBox("Error loading image: " & ex.Message, MsgBoxStyle.Critical, "Image Load Error")
            End Try
        End If

        ' Price label
        Dim resolvedFont As Font
        Try
            resolvedFont = New Font("Segoe UI", fontSize, FontStyle.Regular)
        Catch
            resolvedFont = New Font("Segoe UI", 12.0F, FontStyle.Regular)
        End Try

        Dim foodPrice As New Label With {
            .Text = "₱" & itemPrice,
            .Font = resolvedFont,
            .TextAlign = ContentAlignment.MiddleCenter,
            .AutoSize = False,
            .Width = btnSize,
            .Height = CInt(resolvedFont.GetHeight() * 1.8)
        }

        Dim foodNameLabel As New Label With {
            .Text = itemName,
            .Font = resolvedFont,
            .TextAlign = ContentAlignment.MiddleCenter,
            .AutoSize = False,
            .Width = btnSize,
            .Height = CInt(resolvedFont.GetHeight() * 1.8)
        }

        ' Container panel for button + labels
        Dim container As New FlowLayoutPanel With {
            .Size = New Size(btnSize, btnSize + foodNameLabel.Height + foodPrice.Height + 8),
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .AutoSize = False,
            .Margin = New Padding(8),
            .BackColor = Color.Transparent
        }

        container.Controls.Add(foodBtn)
        container.Controls.Add(foodNameLabel)
        container.Controls.Add(foodPrice)

        Return container
    End Function

    ' for extracting tag from buttons
    Public Function ExtractTag(tag As Object) As DatabaseHandler.TagData
        Dim raw As String = If(tag Is Nothing, String.Empty, tag.ToString())
        Dim result As New DatabaseHandler.TagData()

        If raw.Contains(",") Then
            Dim tagInfo() As String = raw.Split(","c)
            result.Price = tagInfo(0).Trim()
            result.TagImagePath = tagInfo(1).Trim()
        Else
            result.Price = raw.Trim()
            result.TagImagePath = String.Empty
        End If

        Return result
    End Function
End Module