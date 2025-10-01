Imports System.IO
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Tls

Public Class Manage_menu
    Private IsEdit As Boolean = False
    Private CurrentTable As String = "Foods"
    Private ImagePath As String = ""
    Private navButtons As AdminNavButtons ' reuse nav logic

    Private Sub Manage_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' add this function so that when this form is closed, the parent form as well
        AddHandler MyBase.FormClosed, AddressOf FormCloseParent
        Me.WindowState = FormWindowState.Maximized

        ' Initialize nav buttons (only Back + Logout exist on this form)
        navButtons = New AdminNavButtons(Me, btnLogout, btnBack)

        ' load menu items
        LoadMenuCategories()
        LoadMenuItems(CurrentTable)
    End Sub
    Private Function CreateFoodItemButton(itemName As String, itemPrice As String, imgPath As String, isItem As Boolean) As FlowLayoutPanel
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

        If isItem Then
            AddHandler foodBtn.Click, AddressOf HandleItemClick
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
    Private Sub ClearMenuItemForm()
        ItemNameTxtBox.Text = String.Empty
        PriceTxtBox.Text = String.Empty
        ItemBtn.Text = String.Empty

        If ItemBtn.BackgroundImage IsNot Nothing Then
            ItemBtn.BackgroundImage.Dispose()
            ItemBtn.BackgroundImage = Nothing
        End If
    End Sub
    Private Function ValidateInputs()
        If String.IsNullOrEmpty(ItemNameTxtBox.Text) Then
            MsgBox("Item name is invalid", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        Dim itemPrice As Integer
        If Not Integer.TryParse(PriceTxtBox.Text, itemPrice) Then
            MsgBox("Item price is invalid", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        Return True
    End Function
    Private Sub DisableForm()
        ItemNameTxtBox.Enabled = False
        PriceTxtBox.Enabled = False
        ItemBtn.Enabled = False
        EditBtn.Enabled = False
        UpdateBtn.Enabled = False
        DeleteBtn.Enabled = False
        SaveBtn.Enabled = False
        CancelBtn.Enabled = False
    End Sub
    Private Sub ShowForm()
        Label4.Visible = False
        ItemBtn.Visible = True
        ItemNameLbl.Visible = True
        PriceLbl.Visible = True
        ItemNameTxtBox.Visible = True
        PriceTxtBox.Visible = True
        EditBtn.Visible = True
        DeleteBtn.Visible = True
        UpdateBtn.Visible = True
        CancelBtn.Visible = True
        SaveBtn.Visible = True
    End Sub


    ' Handlers for menu item/category clicks
    Private Sub HandleCategoryClick(sender As Object, e As EventArgs)
        Dim catName As String = CType(sender, Button).Text
        CurrentTable = catName
        LoadMenuItems(catName)
    End Sub
    Private Sub HandleItemClick(sender As Object, e As EventArgs)
        EditBtn.Enabled = True
        ShowForm()

        Dim item As Button = CType(sender, Button)
        Dim tag As String = item.Tag.ToString()
        Dim price As String
        Dim tagImgPath As String = ""

        If tag.Contains(",") Then
            Dim tagInfo() As String = tag.Split(","c)
            price = tagInfo(0)
            tagImgPath = tagInfo(1)
        Else
            price = tag
        End If

        ItemBtn.Text = item.Text
        ImagePath = If(String.IsNullOrEmpty(tagImgPath), Nothing, tagImgPath)
        ItemBtn.BackgroundImage = If(item.BackgroundImage IsNot Nothing AndAlso Not String.IsNullOrEmpty(ImagePath),
                                 ResizeImageFit(item.BackgroundImage, ItemBtn),
                                 Nothing)

        ItemNameTxtBox.Text = item.Text
        PriceTxtBox.Text = price
    End Sub
    Private Sub HandleAddNewItem(sender As Object, e As EventArgs)
        ShowForm()
        ClearMenuItemForm()

        EditBtn.Enabled = False
        DeleteBtn.Enabled = False
        UpdateBtn.Enabled = False

        ItemNameTxtBox.Enabled = True
        PriceTxtBox.Enabled = True
        ItemBtn.Enabled = True
        SaveBtn.Enabled = True
        CancelBtn.Enabled = True

        ItemBtn.Text = "Click here to set the image"
    End Sub



    ' CRUD functions
    Private Sub AddNewMenuItem(itemName As String, itemPrice As String)

        Dim sqlQuery As String = "INSERT INTO `" & CurrentTable & "` (ItemName, ItemPrice, ImagePath) VALUES (@Name, @Price, @Path)"

        Using connection As New MySqlConnection(GetGlobalConnectionString())
            Using command As New MySqlCommand(sqlQuery, connection)
                command.Parameters.AddWithValue("@Name", ItemNameTxtBox.Text)
                command.Parameters.AddWithValue("@Price", itemPrice)
                command.Parameters.AddWithValue("@Path", ImagePath)

                Try
                    connection.Open()
                    If command.ExecuteNonQuery() > 0 Then
                        MsgBox("Successfully added new item!", MsgBoxStyle.Information, "Success")
                        LoadMenuItems(CurrentTable)
                        ClearMenuItemForm()
                        'DisableForm()
                    End If
                Catch ex As MySqlException
                    MessageBox.Show("Database Error: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
    Private Sub UpdateMenuItem(itemName As String, itemPrice As String)
        Dim sqlQuery As String = "UPDATE `" & CurrentTable & "` SET ItemName = @itemName, ItemPrice = @price, ImagePath = @imgpath WHERE ItemName = @itemOldName"

        Using connection As New MySqlConnection(GetGlobalConnectionString())
            Using command As New MySqlCommand(sqlQuery, connection)
                command.Parameters.AddWithValue("@imgpath", ImagePath)
                command.Parameters.AddWithValue("@itemName", ItemNameTxtBox.Text)
                command.Parameters.AddWithValue("@itemOldName", ItemBtn.Text)
                command.Parameters.AddWithValue("@price", PriceTxtBox.Text)

                Try
                    connection.Open()
                    If command.ExecuteNonQuery() > 0 Then
                        MsgBox("Successfully updated the item!", MsgBoxStyle.Information, "Success")
                        LoadMenuItems(CurrentTable)

                        IsEdit = False
                        ClearMenuItemForm()
                        DisableForm()
                    Else
                        MsgBox("Failed to update the item.", MsgBoxStyle.Critical, "Failed")
                    End If
                Catch ex As Exception
                    MsgBox("Error updating item image: " & ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End Using
        End Using
    End Sub
    Private Sub DeleteMenuItem(itemName As String)
        Dim result = MessageBox.Show($"Are you sure you want to permanently delete the item: '{itemName}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Return

        Dim sqlQuery = "DELETE FROM `" & CurrentTable & "` WHERE ItemName = @Name"

        Using connection As New MySqlConnection(GetGlobalConnectionString)
            Using command As New MySqlCommand(sqlQuery, connection)
                command.Parameters.AddWithValue("@Name", itemName)
                Try
                    connection.Open()
                    Dim rowsAffected = command.ExecuteNonQuery
                    If rowsAffected > 0 Then
                        MessageBox.Show($"Item '{itemName}' was successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearMenuItemForm()
                        LoadMenuItems(CurrentTable)
                    Else
                        MessageBox.Show($"Item '{itemName}' was not found or could not be deleted.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As MySqlException
                    MessageBox.Show("Database Error: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
    Private Sub LoadMenuCategories()
        MenuCategoryPnl.Controls.Clear()

        Using connection As New MySqlConnection(GetGlobalConnectionString())
            Dim query As String = "SELECT * FROM Categories"
            Dim command As New MySqlCommand(query, connection)

            Try
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim catBtn As New Button With {
                        .Text = reader("CategoryName").ToString(),
                        .Size = New Size(100, 50),
                        .FlatStyle = FlatStyle.Flat
                    }
                        AddHandler catBtn.Click, AddressOf HandleCategoryClick
                        MenuCategoryPnl.Controls.Add(catBtn)
                    End While
                End Using
            Catch ex As Exception
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "ERROR")
            End Try
        End Using
    End Sub
    Private Sub LoadMenuItems(table As String)
        FoodPnl.Controls.Clear()

        Using connection As New MySqlConnection(GetGlobalConnectionString())
            Dim query As String = "SELECT * FROM `" & table & "`"
            Dim command As New MySqlCommand(query, connection)

            Try
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim imagePath As String = If(IsDBNull(reader("ImagePath")) OrElse reader("ImagePath").ToString() = "N/A", Nothing, reader("ImagePath").ToString())
                        Dim panel As FlowLayoutPanel = CreateFoodItemButton(reader("ItemName").ToString(), reader("ItemPrice").ToString(), imagePath, True)
                        FoodPnl.Controls.Add(panel)
                    End While
                End Using

                ' Add "Add new item" button
                Dim addNewPanel As FlowLayoutPanel = CreateFoodItemButton("Add new item", "0", String.Empty, False)
                ' iterate through the panel's controls to get the button
                For Each btn As Button In addNewPanel.Controls.OfType(Of Button)()
                    AddHandler btn.Click, AddressOf HandleAddNewItem
                Next
                FoodPnl.Controls.Add(addNewPanel)

            Catch ex As Exception
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "ERROR")
            End Try
        End Using
    End Sub



    ' Buttons
    Private Sub ItemBtnSetImage(sender As Object, e As EventArgs) Handles ItemBtn.Click
        Using fileDialog As New OpenFileDialog()
            fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*"
            If fileDialog.ShowDialog() = DialogResult.OK Then
                ImagePath = fileDialog.FileName
                Dim image As Image = Image.FromFile(ImagePath)
                ItemBtn.BackgroundImage = ResizeImageFit(image, ItemBtn)
            End If
        End Using
    End Sub
    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        IsEdit = True

        EditBtn.Enabled = False
        CancelBtn.Enabled = True
        DeleteBtn.Enabled = True

        ' enable the form
        ItemBtn.Enabled = True
        PriceTxtBox.Enabled = True
        ItemNameTxtBox.Enabled = True
    End Sub
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If ValidateInputs() Then
            AddNewMenuItem(ItemNameTxtBox.Text, PriceTxtBox.Text)
            ClearMenuItemForm()
            DisableForm()
        End If
    End Sub
    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If String.IsNullOrEmpty(ItemBtn.Text) Then
            MsgBox("Please select an item", MsgBoxStyle.Critical, "Error")
            Return
        End If

        DeleteMenuItem(ItemBtn.Text)
        ClearMenuItemForm()
        DisableForm()
    End Sub
    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        If ValidateInputs() Then
            UpdateMenuItem(ItemNameTxtBox.Text, PriceTxtBox.Text)
        End If
    End Sub
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Dim res = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.YesNo, "Notice")

        If res = MsgBoxResult.Yes Then
            IsEdit = False
            ClearMenuItemForm()
            DisableForm()
        End If
    End Sub


    'listeners for events
    Private Sub HandleFormInput(sender As Object, e As EventArgs) Handles ItemNameTxtBox.KeyPress, PriceTxtBox.KeyPress, ItemBtn.BackgroundImageChanged
        If IsEdit Then
            UpdateBtn.Enabled = True
        Else
            UpdateBtn.Enabled = False
        End If
    End Sub
    Private Sub HandleLettersOnly(sender As Object, e As KeyPressEventArgs) Handles ItemNameTxtBox.KeyPress
        If Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub HandleNumbersOnly(sender As Object, e As KeyPressEventArgs) Handles PriceTxtBox.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
