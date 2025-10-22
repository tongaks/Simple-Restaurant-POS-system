Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Manage_menu
    Private IsEdit As Boolean = False
    Private CurrentTable As String = "Foods"
    Private ImagePath As String = ""
    Private navButtons As AdminNavButtons

    Private Sub Manage_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        ' Initialize navigation buttons with BACK button support
        navButtons = New AdminNavButtons(Me, btnLogout, btnBack, btnHelp, Nothing)

        ' Load menu items
        LoadMenuCategories()
        LoadMenuItems(CurrentTable)

        ' Make sure the item info panel is visible but in default state
        ItemInfoPnl.Visible = True
        pnlItemActions.Visible = True
        pnlItemFields.Visible = True

        ' Set initial state - all buttons disabled until item selected
        DisableForm()

        ' Show the placeholder label
        lblItemPreview.Visible = True
        ItemBtn.Visible = False
    End Sub

    Private Sub HandleFormClose(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        ' Return to Admin form when closing
        For Each f As Form In Application.OpenForms
            If TypeOf f Is Admin Then
                f.Show()
                f.BringToFront()
                Return
            End If
        Next
        ' If no Admin form found, create one
        Dim adminForm As New Admin()
        adminForm.Show()
    End Sub

    Private Sub ClearMenuItemForm()
        ItemNameTxtBox.Text = String.Empty
        PriceTxtBox.Text = String.Empty
        ItemBtn.Text = String.Empty

        If ItemBtn.BackgroundImage IsNot Nothing Then
            ItemBtn.BackgroundImage.Dispose()
            ItemBtn.BackgroundImage = Nothing
        End If

        ImagePath = String.Empty
    End Sub

    Private Function ValidateInputs() As Boolean
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
        ' Disable input controls
        ItemNameTxtBox.Enabled = False
        PriceTxtBox.Enabled = False
        ItemBtn.Enabled = False

        ' Disable action buttons
        EditBtn.Enabled = False
        UpdateBtn.Enabled = False
        DeleteBtn.Enabled = False
        SaveBtn.Enabled = False
        CancelBtn.Enabled = False

        ' Keep panels visible but controls disabled
        pnlItemFields.Visible = True
        pnlItemActions.Visible = True
    End Sub

    Private Sub ShowForm()
        ' Show all panels
        pnlItemFields.Visible = True
        pnlItemActions.Visible = True

        ' Show labels and controls
        lblItemPreview.Visible = False
        ItemBtn.Visible = True
        ItemNameLbl.Visible = True
        PriceLbl.Visible = True
        ItemNameTxtBox.Visible = True
        PriceTxtBox.Visible = True

        ' Show action buttons
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
        SaveBtn.Enabled = False
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
        ItemBtn.BackgroundImageLayout = ImageLayout.Stretch

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
                command.Parameters.AddWithValue("@Path", If(String.IsNullOrEmpty(ImagePath), "N/A", ImagePath))

                Try
                    connection.Open()
                    If command.ExecuteNonQuery() > 0 Then
                        MsgBox("Successfully added new item!", MsgBoxStyle.Information, "Success")
                        LoadMenuItems(CurrentTable)
                        ClearMenuItemForm()
                        DisableForm()
                        lblItemPreview.Visible = True
                        ItemBtn.Visible = False
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
                command.Parameters.AddWithValue("@imgpath", If(String.IsNullOrEmpty(ImagePath), "N/A", ImagePath))
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
                        lblItemPreview.Visible = True
                        ItemBtn.Visible = False
                    Else
                        MsgBox("Failed to update the item.", MsgBoxStyle.Critical, "Failed")
                    End If
                Catch ex As Exception
                    MsgBox("Error updating item: " & ex.Message, MsgBoxStyle.Critical, "Error")
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
                        DisableForm()
                        lblItemPreview.Visible = True
                        ItemBtn.Visible = False
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

    Private Sub SearchItem(itemName As String)
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Dim Reader As MySqlDataReader

        Try
            Connection.Open()
            Dim Query As String = "SELECT ItemName, ItemPrice, ImagePath FROM (SELECT ItemName, ItemPrice, ImagePath FROM `restaurant`.foods UNION ALL SELECT ItemName, ItemPrice, ImagePath FROM `restaurant`.drinks UNION ALL SELECT ItemName, ItemPrice, ImagePath FROM `restaurant`.`Snacks/Sides`) AS CombinedItems WHERE ItemName LIKE CONCAT('%', @itemName, '%')"
            Dim Command As New MySqlCommand(Query, Connection)
            Command.Parameters.AddWithValue("@itemName", SearchTxtBox.Text)
            Reader = Command.ExecuteReader

            If Reader.HasRows Then
                FoodPnl.Controls.Clear()
            Else
                Return
            End If

            While Reader.Read
                Dim foodName = Reader("ItemName")
                Dim foodPrice = Reader("ItemPrice")
                Dim imagePath = If(IsDBNull(Reader("ImagePath")), "", Reader("ImagePath"))

                Dim container As FlowLayoutPanel = CreateFoodItemButton(foodName, foodPrice, imagePath)
                For Each btn As Button In container.Controls.OfType(Of Button)()
                    AddHandler btn.Click, AddressOf HandleItemClick
                Next

                FoodPnl.Controls.Add(container)
            End While

        Catch ex As Exception
            MessageBox.Show("Search error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
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
                            .Size = New Size(120, 50),
                            .FlatStyle = FlatStyle.Flat,
                            .BackColor = Color.FromArgb(72, 118, 255),
                            .ForeColor = Color.White,
                            .Font = New Font("Segoe UI Semibold", 11, FontStyle.Bold),
                            .Cursor = Cursors.Hand,
                            .Margin = New Padding(5)
                        }
                        catBtn.FlatAppearance.BorderSize = 0
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
                        Dim panel As FlowLayoutPanel = CreateFoodItemButton(reader("ItemName").ToString(), reader("ItemPrice").ToString(), imagePath)
                        For Each btn As Button In panel.Controls.OfType(Of Button)()
                            AddHandler btn.Click, AddressOf HandleItemClick
                        Next

                        FoodPnl.Controls.Add(panel)
                    End While
                End Using

                ' Add "Add new item" button with modern style
                Dim addNewPanel As FlowLayoutPanel = CreateFoodItemButton("➕ Add New", "0", String.Empty)
                For Each btn As Button In addNewPanel.Controls.OfType(Of Button)()
                    btn.BackColor = Color.FromArgb(46, 204, 113)
                    btn.ForeColor = Color.White
                    btn.Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
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
                ItemBtn.BackgroundImageLayout = ImageLayout.Stretch
            End If
        End Using
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        IsEdit = True

        EditBtn.Enabled = False
        CancelBtn.Enabled = True
        DeleteBtn.Enabled = True
        UpdateBtn.Enabled = False

        ' Enable the form
        ItemBtn.Enabled = True
        PriceTxtBox.Enabled = True
        ItemNameTxtBox.Enabled = True
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If ValidateInputs() Then
            AddNewMenuItem(ItemNameTxtBox.Text, PriceTxtBox.Text)
        End If
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If String.IsNullOrEmpty(ItemBtn.Text) Then
            MsgBox("Please select an item", MsgBoxStyle.Critical, "Error")
            Return
        End If

        DeleteMenuItem(ItemBtn.Text)
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
            lblItemPreview.Visible = True
            ItemBtn.Visible = False
        End If
    End Sub

    Private Sub SearchBtn_Click(sender As Object, e As EventArgs) Handles SearchBtn.Click
        If Not String.IsNullOrEmpty(SearchTxtBox.Text) Then
            SearchItem(SearchTxtBox.Text)
        End If
    End Sub

    ' Listeners for events
    Private Sub HandleFormInput(sender As Object, e As EventArgs) Handles ItemNameTxtBox.TextChanged, PriceTxtBox.TextChanged
        If IsEdit Then
            UpdateBtn.Enabled = True
        End If
    End Sub

    Private Sub HandleLettersOnly(sender As Object, e As KeyPressEventArgs) Handles ItemNameTxtBox.KeyPress
        ' Allow letters, spaces, and control characters
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub HandleNumbersOnly(sender As Object, e As KeyPressEventArgs) Handles PriceTxtBox.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub HandleSearchTxtBoxEnter(sender As Object, e As KeyPressEventArgs) Handles SearchTxtBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(SearchTxtBox.Text) Then
                SearchItem(SearchTxtBox.Text)
            End If
        End If
    End Sub
End Class