Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports System.Transactions
Imports System.Windows.Forms.Design
Imports System.Xml
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Mysqlx.Resultset
Imports ZstdSharp.Unsafe

Public Class Order
    Dim CurrentTotal As Integer
    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = WindowState.Maximized

        CurrentTotal = 0
        LoadMenuCategories()
        LoadMenuItems("Foods")

        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "ItemAmount"
        DataGridView1.Columns("ItemAmount").ValueType = GetType(Integer)

        DataGridView1.Columns(1).Name = "ItemName"

        DataGridView1.Columns(2).Name = "ItemPrice"
        DataGridView1.Columns("ItemPrice").ValueType = GetType(Integer)

        DataGridView1.Columns(3).Name = "Total"
        DataGridView1.Columns("Total").ValueType = GetType(Integer)

        DataGridView1.Columns(4).Name = "ImagePath"
        DataGridView1.Columns("ImagePath").ValueType = GetType(String)

        'DataGridView1.DefaultCellStyle.Font = New Font("Segue UI", 15.0F, FontStyle.Regular)
        'DataGridView1.Rows(0).Height = 20
    End Sub
    Private Sub Order_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        ' close parent when child closes
        Form1.Dispose()
    End Sub



    ' CRUD functions
    Private Sub LoadMenuCategories()
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Dim Reader As MySqlDataReader

        Try
            Connection.Open()
            Dim Query As String = "SELECT * FROM Categories"
            Dim Command As New MySqlCommand(Query, Connection)
            Reader = Command.ExecuteReader

            While Reader.Read
                Dim catBtn As New Button
                catBtn.Text = Reader("CategoryName")
                catBtn.Size = New System.Drawing.Size(100, 50)
                catBtn.FlatStyle = FlatStyle.Flat
                AddHandler catBtn.Click, AddressOf HandleCatClick
                MenuCategoryPnl.Controls.Add(catBtn)
            End While

        Catch ex As Exception
            MsgBox("Error: " + ex.ToString, MsgBoxStyle.Critical, "ERROR")
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Sub
    Private Sub LoadMenuItems(table As String)
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Dim Reader As MySqlDataReader

        Try
            Connection.Open()
            Dim Query As String = "SELECT * FROM `" & table & "`"
            Dim Command As New MySqlCommand(Query, Connection)
            Reader = Command.ExecuteReader

            While Reader.Read
                Dim foodBtn As New Button
                foodBtn.Text = Reader("ItemName")
                foodBtn.Size = New System.Drawing.Size(100, 100)
                foodBtn.Margin = New Padding(0, 0, 0, 0)
                foodBtn.Tag = Reader("ItemPrice")
                foodBtn.Cursor = Cursors.Hand

                If Not IsDBNull(Reader("ImagePath")) Then
                    If Not Reader("ImagePath") = "N/A" Then
                        Dim image As Image = Image.FromFile(Reader("ImagePath"))
                        foodBtn.Image = ResizeImageFit(image, foodBtn)
                        foodBtn.Tag &= "," & Reader("ImagePath")
                    End If
                End If

                AddHandler foodBtn.Click, AddressOf HandleItemClick

                Dim foodPrice As New Label
                foodPrice.Text = "₱" & Reader("ItemPrice")
                foodPrice.Font = New Font("Segue UI", 18.0F, FontStyle.Regular)
                foodPrice.TextAlign = ContentAlignment.MiddleCenter

                Dim FoodContainerPnl As New FlowLayoutPanel
                FoodContainerPnl.Size = New System.Drawing.Size(100, 100 + foodPrice.Size.Height)
                FoodContainerPnl.Controls.Add(foodBtn)
                FoodContainerPnl.Controls.Add(foodPrice)

                FoodPnl.Controls.Add(FoodContainerPnl)
            End While

        Catch ex As Exception
            MsgBox("Error: " + ex.ToString, MsgBoxStyle.Critical, "ERROR")
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
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
            Else Return
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

        End Try
    End Sub



    ' Menu item/category click handlers
    Private Sub HandleItemClick(sender As Object, e As EventArgs)
        Dim name = CType(sender, Button).Text

        Dim tag As String = CType(sender, Button).Tag.ToString()
        Dim price As String
        Dim tagImgPath As String = Nothing

        If tag.Contains(",") Then
            Dim tagInfo() As String = tag.Split(","c)
            price = tagInfo(0)
            tagImgPath = tagInfo(1)
        Else
            price = tag
        End If

        Dim nameExists As Boolean = False

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = name Then
                nameExists = True
                row.Cells(0).Value = CInt(row.Cells(0).Value) + 1
                row.Cells(3).Value = CInt(row.Cells(3).Value) + Integer.Parse(price)
                Exit For
            End If
        Next

        If Not nameExists Then
            Dim newRow As New DataGridViewRow()
            newRow.CreateCells(DataGridView1, 1, name, price, price, tagImgPath)
            DataGridView1.Rows.Add(newRow)

            Dim image As Image = CType(sender, Button).BackgroundImage
            OrderPnl.Controls.Add(AddItemToOrderList(name, price, "1", tagImgPath))
        ElseIf nameExists Then
            UpdateItemOrderList()
        End If

        CurrentTotal += Integer.Parse(price)
        TotalLbl.Text = "₱" + CStr(CurrentTotal)
    End Sub
    Private Sub HandleCatClick(sender As Object, e As EventArgs)
        Dim catName = CType(sender, Button).Text
        FoodPnl.Controls.Clear()
        LoadMenuItems(catName)
    End Sub



    ' Display the items
    Private Function AddItemToOrderList(ByVal itemName As String, ByVal itemPrice As String, ByVal itemAmount As String, ByVal itemImage As String) As FlowLayoutPanel
        ' Create the main FlowLayoutPanel
        Dim mainPanel As New FlowLayoutPanel()
        mainPanel.FlowDirection = FlowDirection.LeftToRight
        mainPanel.WrapContents = False
        mainPanel.Width = OrderPnl.Width
        mainPanel.Height = 100 ' Make sure the height is fixed for layout
        mainPanel.BackColor = Color.LightGray
        mainPanel.Padding = New Padding(10)
        mainPanel.AutoSize = False

        ' PictureBox
        Dim pictureBox As New PictureBox()
        pictureBox.Size = New Size(80, 80)
        pictureBox.Image = If(String.IsNullOrEmpty(itemImage), Nothing, Image.FromFile(itemImage))
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        pictureBox.Margin = New Padding(5)

        ' Item amount label (wrapped in a Panel for vertical alignment)
        Dim itemAmountLabel As New Label()
        itemAmountLabel.Text = itemAmount
        itemAmountLabel.Font = New Font("Arial", 16, FontStyle.Bold)
        itemAmountLabel.AutoSize = True

        Dim amountWrapper As New Panel()
        amountWrapper.Size = New Size(itemAmountLabel.PreferredWidth + 10, mainPanel.Height)
        itemAmountLabel.Location = New Point(0, ((mainPanel.Height - itemAmountLabel.Height) \ 2) - 30)
        amountWrapper.Controls.Add(itemAmountLabel)

        ' Container for labels (item name and item price)
        Dim itemInfoPanel As New FlowLayoutPanel()
        itemInfoPanel.FlowDirection = FlowDirection.TopDown
        itemInfoPanel.AutoSize = True
        itemInfoPanel.Margin = New Padding(10, 10, 10, 10)

        ' Item name label
        Dim labelName As New Label()
        labelName.Text = itemName
        labelName.Font = New Font("Arial", 14, FontStyle.Bold)
        labelName.AutoSize = True

        ' Item price label
        Dim labelPrice As New Label()
        labelPrice.Text = "₱" & itemPrice
        labelPrice.Font = New Font("Arial", 12, FontStyle.Bold)
        labelPrice.AutoSize = True

        itemInfoPanel.Controls.Add(labelName)
        itemInfoPanel.Controls.Add(labelPrice)

        ' Spacer to push buttons to the right
        Dim spacer As New Panel()
        spacer.Width = mainPanel.Width - (amountWrapper.Width + pictureBox.Width + itemInfoPanel.PreferredSize.Width + 180)
        spacer.Height = 10
        spacer.Margin = New Padding(0)

        ' Buttons (increase/decrease)
        Dim itemButtonPanel As New FlowLayoutPanel()
        itemButtonPanel.FlowDirection = FlowDirection.LeftToRight
        itemButtonPanel.AutoSize = True
        itemButtonPanel.Margin = New Padding(0, 10, 0, 0)

        Dim increaseButton As New Button()
        increaseButton.Text = "+"
        increaseButton.Tag = itemName
        increaseButton.BackColor = Color.Green
        increaseButton.Size = New Size(50, 50)
        AddHandler increaseButton.Click, AddressOf IncreaseButtonHandler

        Dim decreaseButton As New Button()
        decreaseButton.Text = "-"
        decreaseButton.Tag = itemName
        decreaseButton.BackColor = Color.Orange
        decreaseButton.Size = New Size(50, 50)
        AddHandler decreaseButton.Click, AddressOf DecreaseButtonHandler

        itemButtonPanel.Controls.Add(increaseButton)
        itemButtonPanel.Controls.Add(amountWrapper)
        itemButtonPanel.Controls.Add(decreaseButton)

        ' Add controls to main panel
        'mainPanel.Controls.Add(amountWrapper)
        mainPanel.Controls.Add(pictureBox)
        mainPanel.Controls.Add(itemInfoPanel)
        mainPanel.Controls.Add(spacer)
        mainPanel.Controls.Add(itemButtonPanel)

        Return mainPanel
    End Function
    Private Sub UpdateItemOrderList()
        If OrderPnl.HasChildren Then
            OrderPnl.Controls.Clear()
        End If

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim itemAmount = CInt(row.Cells(0).Value)
            Dim itemName As String = CStr(row.Cells(1).Value)
            Dim itemPrice As String = CStr(row.Cells(2).Value)
            Dim itemImage As String = CStr(row.Cells(4).Value)
            OrderPnl.Controls.Add(AddItemToOrderList(itemName, itemPrice, itemAmount, itemImage))
        Next row
    End Sub



    ' Buttons
    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Panel1.Hide()
    End Sub
    Private Sub CreateOrderBtn_Click(sender As Object, e As EventArgs) Handles CreateOrderBtn.Click
        Dim ConnectionString = GetGlobalConnectionString()
        Dim Connection As New MySqlConnection(ConnectionString)

        Dim TotalAmount As Integer = Integer.Parse(TotalLbl.Text.Substring(1))

        Try
            Connection.Open()
            Dim Query As String = "INSERT INTO orders (order_date, order_time, username, total_amount) VALUES (@date, @time, @user, @total)"
            Dim Command As New MySqlCommand(Query, Connection)
            Command.Parameters.AddWithValue("@date", DateTime.Now.Date)
            Command.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay)
            Command.Parameters.AddWithValue("@user", CurrentUser)
            Command.Parameters.AddWithValue("@total", TotalAmount)

            If Command.ExecuteNonQuery() > 0 Then
                MsgBox("Order created", MsgBoxStyle.Information, "Success")
            End If

        Catch ex As Exception
            MsgBox("Failed to create order: " + ex.ToString, MsgBoxStyle.Critical, "Error")
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Sub
    Private Sub SearchBtn_Click(sender As Object, e As EventArgs) Handles SearchBtn.Click
        If Not String.IsNullOrEmpty(SearchTxtBox.Text) Then
            SearchItem(SearchTxtBox.Text)
        End If
    End Sub
    Private Sub IncreaseButtonHandler(sender As Object, e As EventArgs)
        Dim itemName As String = CType(sender, Button).Tag.ToString()

        Dim itemBtnName As String = CType(sender, Button).Tag
        Dim price As String = "0"

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = itemName Then
                row.Cells(0).Value = CInt(row.Cells(0).Value) + 1
                price = CStr(row.Cells(2).Value)
                Exit For
            End If
        Next

        UpdateItemOrderList()

        CurrentTotal += Integer.Parse(price)
        TotalLbl.Text = "₱" + CStr(CurrentTotal)
    End Sub
    Private Sub DecreaseButtonHandler(sender As Object, e As EventArgs)
        Dim itemName As String = CType(sender, Button).Tag.ToString()

        Dim itemBtnName As String = CType(sender, Button).Tag
        Dim price As String = "0"

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = itemName Then
                Dim currentAmount = CInt(row.Cells(0).Value)
                If currentAmount > 0 And Not (currentAmount - 1) = 0 Then
                    row.Cells(0).Value = currentAmount - 1
                    price = CStr(row.Cells(2).Value)
                Else
                    MsgBox("Deleted row: item amount is equal to 0")
                    DataGridView1.Rows.RemoveAt(row.Index)
                End If

                Exit For
            End If
        Next

        UpdateItemOrderList()
        CurrentTotal -= Integer.Parse(price)
        TotalLbl.Text = "₱" + CStr(CurrentTotal)
    End Sub



    ' listeners
    Private Sub HandleSearchTxtBoxEnter(sender As Object, e As KeyPressEventArgs) Handles SearchTxtBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(SearchTxtBox.Text) Then
                SearchItem(SearchTxtBox.Text)
            End If
        End If
    End Sub
End Class