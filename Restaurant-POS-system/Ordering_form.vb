Imports System.ComponentModel.DataAnnotations
Imports System.Data.OleDb
Imports System.Drawing.Text
Imports System.IO
Imports System.Reflection.Metadata
Imports System.Transactions
Imports System.Windows.Forms.Design
Imports System.Windows.Xps.Packaging
Imports System.Xml
Imports FontAwesome.Sharp
Imports Guna.UI2.WinForms
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Mysqlx.Resultset
Imports Mysqlx.XDevAPI.Common
Imports Org.BouncyCastle.Asn1.Cms
Imports PdfiumViewer
Imports PdfSharp.Drawing
Imports PdfSharp.Fonts
Imports PdfSharp.Pdf
Imports PdfSharp.Pdf.Content.Objects
Imports PdfSharp.Quality
Imports ZstdSharp.Unsafe


Public Class Order
    Dim CurrentTotal As Double
    Dim CurrentSubTotal As Double
    Dim DiscountValue As Double = 0
    Dim CurrentFocusedItem As String
    Dim currentIndex As Integer = 0
    Dim CurrentFocused As Guna2PictureBox = Nothing

    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSettingsConfig()

        Me.KeyPreview = True
        GlobalFontSettings.UseWindowsFontsUnderWindows = True
        Me.WindowState = WindowState.Maximized
        CurrentTotal = 0

        ' data grid view essentials
        LoadMenuCategories(MenuContainerPnl)
        For Each btn As Guna2Button In MenuContainerPnl.Controls
            AddHandler btn.Click, AddressOf HandleCategorylick
        Next

        LoadMenuItems("Foods", FoodPnl)
        For Each btn As Guna2PictureBox In MenuItems
            AddHandler btn.Click, AddressOf HandleItemClick
        Next


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

        OrderPnl.HorizontalScroll.Enabled = False
        Guna2Panel1.HorizontalScroll.Enabled = False

        CurrentCategory = MenuCategories(0)
        CurrentCategory.FillColor = Color.SteelBlue
        CurrentCategory.ForeColor = Color.White

    End Sub
    Private Sub Order_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        ' close parent when child closes
        Form1.Dispose()
    End Sub
    Private Sub OrderForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If SettingsConfig.EnableShortcutKeys Then
        HandleKeydownSelect(sender, e)
        'End If
    End Sub



    ' Form dialog for increasing/decreasing item amount
    ' WIP
    'Private Function DisplayItemDialogForm(ByVal itemAmount As Integer)
    '    'Dim itemAmount As Integer = 1

    '    Dim itemDialog As New Form
    '    'itemDialog.Size = New System.Drawing.Size(500, 150)
    '    itemDialog.StartPosition = FormStartPosition.CenterScreen
    '    itemDialog.KeyPreview = True
    '    itemDialog.AutoSize = True
    '    itemDialog.Text = "Edit item quantity"

    '    Dim mainPanel As New FlowLayoutPanel
    '    mainPanel.FlowDirection = FlowDirection.TopDown
    '    mainPanel.AutoSize = True

    '    Dim itemButtonPanel As New FlowLayoutPanel()
    '    itemButtonPanel.FlowDirection = FlowDirection.LeftToRight
    '    itemButtonPanel.AutoSize = True
    '    itemButtonPanel.Margin = New Padding(30, 10, 0, 0)

    '    Dim itemNameLabel As New Label()
    '    itemNameLabel.Text = CurrentFocused.Text
    '    itemNameLabel.Font = New Font("Arial", 30, FontStyle.Bold)
    '    itemNameLabel.AutoSize = True

    '    Dim itemAmountLabel As New Label()
    '    itemAmountLabel.Text = itemAmount.ToString
    '    itemAmountLabel.Font = New Font("Arial", 50, FontStyle.Bold)
    '    itemAmountLabel.AutoSize = True

    '    Dim amountWrapper As New Panel()
    '    amountWrapper.Size = New Size(itemAmountLabel.PreferredWidth + 10, itemButtonPanel.Height)
    '    itemAmountLabel.Location = New Point(0, ((itemButtonPanel.Height - itemAmountLabel.Height) \ 2) - 30)
    '    amountWrapper.Controls.Add(itemAmountLabel)

    '    Dim increaseButton As New Button()
    '    increaseButton.Text = "+"
    '    increaseButton.Tag = CurrentFocusedItem
    '    increaseButton.BackColor = Color.Green
    '    increaseButton.Size = New Size(100, 100)
    '    AddHandler increaseButton.Click, Sub()
    '                                         itemAmount += 1
    '                                         itemAmountLabel.Text = itemAmount.ToString
    '                                     End Sub

    '    Dim decreaseButton As New Button()
    '    decreaseButton.Text = "-"
    '    decreaseButton.Tag = CurrentFocusedItem
    '    decreaseButton.BackColor = Color.Red
    '    decreaseButton.ForeColor = Color.White
    '    decreaseButton.Size = New Size(100, 100)
    '    AddHandler decreaseButton.Click, Sub()
    '                                         itemAmount = If((itemAmount > 1), itemAmount - 1, itemAmount)
    '                                         itemAmountLabel.Text = itemAmount.ToString
    '                                     End Sub

    '    itemButtonPanel.Controls.Add(increaseButton)
    '    itemButtonPanel.Controls.Add(amountWrapper)
    '    itemButtonPanel.Controls.Add(decreaseButton)

    '    Dim buttonPnl As New FlowLayoutPanel
    '    buttonPnl.FlowDirection = FlowDirection.LeftToRight
    '    buttonPnl.Margin = New Padding(0, 30, 0, 0)
    '    buttonPnl.Padding = New Padding(50, 0, 0, 0)
    '    buttonPnl.AutoSize = True

    '    Dim addItemBtn As New Button
    '    addItemBtn.Text = "Add"
    '    addItemBtn.Size = New Size(100, 60)
    '    addItemBtn.FlatStyle = FlatStyle.Flat
    '    addItemBtn.BackColor = Color.SpringGreen
    '    'addItemBtn.Margin = New Padding(60, 30, 0, 0)
    '    AddHandler addItemBtn.Click, Sub()
    '                                     itemDialog.DialogResult = DialogResult.OK
    '                                     itemDialog.Close()
    '                                 End Sub

    '    Dim cancelItemBtn As New Button
    '    cancelItemBtn.Text = "Cancel"
    '    cancelItemBtn.Size = New Size(100, 60)
    '    cancelItemBtn.FlatStyle = FlatStyle.Flat
    '    cancelItemBtn.BackColor = Color.Gray
    '    'cancelItemBtn.Margin = New Padding(60, 30, 0, 0)
    '    AddHandler cancelItemBtn.Click, Sub()
    '                                        itemDialog.DialogResult = DialogResult.Cancel
    '                                        itemDialog.Close()
    '                                    End Sub

    '    buttonPnl.Controls.Add(addItemBtn)
    '    buttonPnl.Controls.Add(cancelItemBtn)

    '    mainPanel.Controls.Add(itemNameLabel)
    '    mainPanel.Controls.Add(itemButtonPanel)
    '    mainPanel.Controls.Add(buttonPnl)
    '    itemDialog.Controls.Add(mainPanel)
    '    'itemDialog.Size = New System.Drawing.Size(mainPanel.Width + 50, mainPanel.Height + 50)

    '    AddHandler itemDialog.KeyDown, Sub(sender As Object, e As KeyEventArgs)
    '                                       If e.Control AndAlso e.KeyCode = Keys.Enter Then
    '                                           itemDialog.DialogResult = DialogResult.OK
    '                                           itemDialog.Close()
    '                                       ElseIf e.KeyCode = Keys.Escape Then
    '                                           itemDialog.DialogResult = DialogResult.Cancel
    '                                           itemDialog.Close()
    '                                       End If
    '                                   End Sub

    '    If itemDialog.ShowDialog() = DialogResult.OK Then
    '        Return itemAmount
    '    Else
    '        Return -1
    '    End If
    'End Function
    Private Sub DisplayRecentOrders()
        Dim recentDialog As New Form
        recentDialog.Size = New System.Drawing.Size(1000, 500)

        Dim pnlRecentOrders As New Panel
        pnlRecentOrders.Size = New System.Drawing.Size(recentDialog.Width, recentDialog.Height)
        pnlRecentOrders.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        ' connection for loading the transactions to be passed on LoadTransactionDetails
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Connection.Open()

        ' need to create an instance of SalesReport class to be able to use the LoadTrandsactionDetails
        Dim salereport As New SalesReport
        salereport.LoadTransactionDetails(Connection, pnlRecentOrders)

        recentDialog.Controls.Add(pnlRecentOrders)
        recentDialog.ShowDialog()
    End Sub
    Private Function DisplayItemDialogForm(ByVal itemAmount As Integer) As Integer
        If CurrentFocused Is Nothing Then Return -1
        Dim tagData As TagData = ExtractTag(CurrentFocused.Tag)
        Dim dlg As New ItemDialogForm(CurrentFocused.Text, tagData.Price, itemAmount)
        If dlg.ShowDialog() = DialogResult.OK Then
            Return dlg.Quantity
        Else
            Return -1
        End If
    End Function





    ' CRUD functions
    'Private Sub LoadMenuCategories()
    '    Dim Connection As New MySqlConnection(GetGlobalConnectionString)
    '    Dim Reader As MySqlDataReader

    '    Try
    '        Connection.Open()
    '        Dim Query As String = "SELECT * FROM Categories"
    '        Dim Command As New MySqlCommand(Query, Connection)
    '        Reader = Command.ExecuteReader

    '        While Reader.Read
    '            Dim catBtn As New Guna2Button
    '            catBtn.Text = Reader("CategoryName")
    '            'catBtn.Size = New System.Drawing.Size(100, 50)
    '            catBtn.AutoSize = True
    '            catBtn.Padding = New Padding(10)

    '            catBtn.ForeColor = Color.Navy
    '            catBtn.Font = New Font("Segoe UI", 12, FontStyle.Regular)

    '            catBtn.BorderRadius = 10
    '            catBtn.ShadowDecoration.Enabled = True
    '            catBtn.ShadowDecoration.BorderRadius = 10
    '            catBtn.ShadowDecoration.Color = Color.DimGray
    '            catBtn.ShadowDecoration.Depth = 20
    '            catBtn.ShadowDecoration.Shadow = New Padding(-1, -1, 5, 5)

    '            catBtn.FillColor = Color.LightSteelBlue
    '            catBtn.Cursor = Cursors.Hand


    '            AddHandler catBtn.Click, AddressOf HandleCategorylick

    '            MenuContainerPnl.Controls.Add(catBtn)
    '            MenuCategories.Add(catBtn)
    '        End While

    '    Catch ex As Exception
    '        MsgBox("Error: " + ex.ToString, MsgBoxStyle.Critical, "ERROR")
    '    Finally
    '        If Connection.State = ConnectionState.Open Then
    '            Connection.Close()
    '        End If
    '    End Try
    'End Sub
    'Private Sub LoadMenuItems(table As String)
    '    Dim Connection As New MySqlConnection(GetGlobalConnectionString)
    '    Dim Reader As MySqlDataReader
    '    MenuItems.Clear()
    '    currentIndex = 0

    '    Try
    '        Connection.Open()
    '        Dim Query As String = "SELECT * FROM `" & table & "`"
    '        Dim Command As New MySqlCommand(Query, Connection)
    '        Reader = Command.ExecuteReader

    '        FoodPnl.Controls.Clear()

    '        While Reader.Read
    '            Dim cardWidth As Integer = 160
    '            Dim cardHeight As Integer = 200
    '            Dim paddingVal As Integer = 10
    '            Dim fontSize As Integer = 11

    '            Dim Card As New Guna.UI2.WinForms.Guna2Panel With {
    '            .Width = cardWidth,
    '            .Height = cardHeight,
    '            .BorderRadius = 12,
    '            .BackColor = Color.White,
    '            .FillColor = Color.White,
    '            .Margin = New Padding(10),
    '            .Tag = Reader("ItemName")
    '        }

    '            Card.ShadowDecoration.Enabled = True
    '            Card.ShadowDecoration.BorderRadius = 12
    '            Card.ShadowDecoration.Color = Color.Silver
    '            Card.ShadowDecoration.Depth = 10
    '            Card.ShadowDecoration.Shadow = New Padding(2, 2, 4, 4)

    '            Dim foodImg As New Guna.UI2.WinForms.Guna2PictureBox With {
    '            .Size = New Size(cardWidth - (paddingVal * 2), 100),
    '            .Location = New Point(paddingVal, paddingVal),
    '            .SizeMode = PictureBoxSizeMode.Zoom,
    '            .BorderRadius = 10,
    '            .FillColor = Color.WhiteSmoke,
    '            .Cursor = Cursors.Hand,
    '            .Tag = Reader("ItemPrice"),
    '            .Text = Reader("ItemName")
    '        }

    '            Dim hasImage As Boolean = False

    '            If Not IsDBNull(Reader("ImagePath")) Then
    '                Dim imagePath As String = Reader("ImagePath").ToString()
    '                If imagePath <> "N/A" AndAlso File.Exists(imagePath) Then
    '                    foodImg.Image = Image.FromFile(imagePath)
    '                    foodImg.Tag &= "," & imagePath
    '                    hasImage = True
    '                End If
    '            End If

    '            If Not hasImage Then
    '                foodImg.Image = Nothing
    '                foodImg.FillColor = Color.LightGray

    '                Dim noImageLbl As New Label With {
    '                .Text = "No Image",
    '                .Font = New Font("Segoe UI", 10, FontStyle.Italic),
    '                .ForeColor = Color.DimGray,
    '                .BackColor = Color.Transparent,
    '                .AutoSize = False,
    '                .TextAlign = ContentAlignment.MiddleCenter
    '            }
    '                '.Dock = DockStyle.Fill
    '                foodImg.Controls.Add(noImageLbl)
    '            End If

    '            Dim foodName As New Label With {
    '            .Text = Reader("ItemName").ToString(),
    '            .Font = New Font("Segoe UI Semibold", fontSize, FontStyle.Bold),
    '            .AutoSize = False,
    '            .TextAlign = ContentAlignment.MiddleCenter,
    '            .Width = cardWidth - (paddingVal * 2),
    '            .Height = 30,
    '            .Location = New Point(paddingVal, foodImg.Bottom + 5)
    '        }

    '            Dim foodPrice As New Label With {
    '            .Text = "₱" & Reader("ItemPrice").ToString(),
    '            .Font = New Font("Segoe UI", 14, FontStyle.Regular),
    '            .ForeColor = Color.Navy,
    '            .AutoSize = False,
    '            .TextAlign = ContentAlignment.MiddleCenter,
    '            .Width = cardWidth - (paddingVal * 2),
    '            .Height = 25,
    '            .Location = New Point(paddingVal, foodName.Bottom)
    '        }

    '            AddHandler Card.MouseEnter, Sub()
    '                                            Card.FillColor = Color.FromArgb(245, 245, 245)
    '                                            Card.ShadowDecoration.Color = Color.LightGray
    '                                        End Sub
    '            AddHandler Card.MouseLeave, Sub()
    '                                            Card.FillColor = Color.White
    '                                            Card.ShadowDecoration.Color = Color.Silver
    '                                        End Sub

    '            AddHandler foodImg.Click, AddressOf HandleItemClick

    '            Card.Controls.Add(foodImg)
    '            Card.Controls.Add(foodName)
    '            Card.Controls.Add(foodPrice)
    '            FoodPnl.Controls.Add(Card)
    '        End While

    '    Catch ex As Exception
    '        MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "ERROR")
    '    Finally
    '        If Connection.State = ConnectionState.Open Then
    '            Connection.Close()
    '        End If
    '    End Try
    'End Sub
    Private Sub SearchItem(itemName As String)
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Dim Reader As MySqlDataReader
        'FoodPnl.Controls.Clear()

        Try
            If MenuItems.Count > 0 Then MenuItems.Clear()

            Connection.Open()
            Dim Query As String = "SELECT ItemName, ItemPrice, ImagePath FROM (SELECT ItemName, ItemPrice, ImagePath FROM `restaurant`.foods UNION ALL SELECT ItemName, ItemPrice, ImagePath FROM `restaurant`.drinks UNION ALL SELECT ItemName, ItemPrice, ImagePath FROM `restaurant`.`Snacks/Sides`) AS CombinedItems WHERE ItemName LIKE CONCAT('%', @itemName, '%')"
            Dim Command As New MySqlCommand(Query, Connection)
            Command.Parameters.AddWithValue("@itemName", SearchTxtBox.Text)
            Reader = Command.ExecuteReader

            If Reader.HasRows Then
                FoodPnl.Controls.Clear()
            Else
                MsgBox("No item found", MsgBoxStyle.Information, "Notice")
                Return
            End If

            While Reader.Read
                Dim foodName = Reader("ItemName")
                Dim foodPrice = Reader("ItemPrice")
                Dim imagePath = If(IsDBNull(Reader("ImagePath")), "", Reader("ImagePath"))

                Dim container As Guna2Panel = CreateFoodItemCard(foodName, foodPrice, imagePath)
                For Each btn As Guna2PictureBox In container.Controls.OfType(Of Guna2PictureBox)()
                    AddHandler btn.Click, AddressOf HandleItemClick
                Next

                FoodPnl.Controls.Add(container)
            End While

        Catch ex As Exception

        End Try
    End Sub





    ' Menu item/category click handlers
    Private Sub HandleItemClick(sender As Object, e As EventArgs)
        Dim button As Guna2PictureBox = CType(sender, Guna2PictureBox)
        CurrentFocusedItem = button.Text
        CurrentFocused = button

        'MsgBox("Clicked")

        Dim exists As Boolean = False
        Dim itemAmount As Integer = 0
        If DataGridView1.RowCount > 0 Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(1).Value = CurrentFocusedItem Then
                    exists = True
                    itemAmount = Integer.Parse(row.Cells(0).Value)
                    Exit For
                End If
            Next
        End If

        itemAmount = DisplayItemDialogForm(If((exists), itemAmount, 1))
        If itemAmount = -1 Then
            Return
        End If

        Dim itemName = button.Text
        Dim tagData As TagData = ExtractTag(button.Tag)
        Dim itemPrice As String = tagData.Price
        Dim itemImage As String = tagData.TagImagePath
        HandleIfItemExistsInOrder(itemName, itemPrice, itemImage, itemAmount)
        Compute() ' compute total again
    End Sub
    Public Sub HandleCategorylick(sender As Object, e As EventArgs)
        Dim catName = CType(sender, Guna2Button)

        PrevCategory = CurrentCategory
        CurrentCategory = catName

        PrevCategory.FillColor = Color.LightSteelBlue
        PrevCategory.ForeColor = Color.Navy

        CurrentCategory.FillColor = Color.SteelBlue
        CurrentCategory.ForeColor = Color.White

        FoodPnl.Controls.Clear()
        FoodPnl.Focus()

        LoadMenuItems(CurrentCategory.Text, FoodPnl)
        For Each btn As Guna2PictureBox In MenuItems
            AddHandler btn.Click, AddressOf HandleItemClick
        Next
    End Sub





    ' Display the items
    Private Function AddItemToOrderList(ByVal itemName As String, ByVal itemPrice As String, ByVal itemAmount As String, ByVal itemImage As String) As FlowLayoutPanel
        ' Create the main FlowLayoutPanel
        Dim mainPanel As New FlowLayoutPanel()
        mainPanel.FlowDirection = FlowDirection.LeftToRight
        mainPanel.WrapContents = False
        mainPanel.Width = OrderPnl.Width
        mainPanel.Height = 100
        'mainPanel.BackColor = Color.LightSteelBlue
        'mainPanel.BackColor = Color.White
        mainPanel.BackColor = Color.WhiteSmoke
        'mainPanel.Padding = New Padding(10)
        mainPanel.AutoSize = False

        ' PictureBox
        Dim pictureBox As New Guna2PictureBox()
        pictureBox.Size = New Size(80, 80)

        pictureBox.Image = If(String.IsNullOrEmpty(itemImage), Nothing, Image.FromFile(itemImage))

        If pictureBox.Image Is Nothing Then
            pictureBox.FillColor = Color.LightGray

            Dim noImageLbl As New Label With {
         .Text = "No Image",
         .Font = New Font("Segoe UI", 10, FontStyle.Italic),
         .ForeColor = Color.DimGray,
         .BackColor = Color.Transparent,
         .AutoSize = False,
         .Size = pictureBox.Size,
         .Location = New Point(0, 0),
         .TextAlign = ContentAlignment.MiddleCenter
        }

            pictureBox.Controls.Add(noImageLbl)
        End If


        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        'pictureBox.Margin = New Padding(5)

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
        itemInfoPanel.Margin = New Padding(0, 20, 0, 0)

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

        ' Buttons (increase/decrease)
        Dim itemButtonPanel As New FlowLayoutPanel()
        itemButtonPanel.FlowDirection = FlowDirection.LeftToRight
        itemButtonPanel.AutoSize = True
        itemButtonPanel.Margin = New Padding(0, 20, 0, 0)


        Dim increaseButton As New Guna2CircleButton()
        increaseButton.Tag = itemName
        increaseButton.FillColor = Color.Green
        increaseButton.Size = New Size(40, 40)
        increaseButton.Text = "✚"
        increaseButton.Cursor = Cursors.Hand
        AddHandler increaseButton.Click, AddressOf IncreaseButtonHandler


        Dim decreaseButton As New Guna2CircleButton()
        decreaseButton.Tag = itemName
        decreaseButton.FillColor = Color.Red
        decreaseButton.ForeColor = Color.White
        decreaseButton.Size = New Size(40, 40)
        decreaseButton.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
        decreaseButton.Text = "➖"
        decreaseButton.Cursor = Cursors.Hand
        AddHandler decreaseButton.Click, AddressOf DecreaseButtonHandler


        Dim deleteButton As New Guna2CircleButton()
        deleteButton.Tag = itemName
        deleteButton.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
        deleteButton.Text = "🗑"
        deleteButton.FillColor = Color.DarkRed
        deleteButton.ForeColor = Color.White
        deleteButton.Size = New Size(40, 40)
        deleteButton.Cursor = Cursors.Hand
        AddHandler deleteButton.Click, AddressOf RemoveItemHandler

        ' Spacer to push buttons to the right
        Dim spacer As New Panel()
        ' holy shit this took me hours to figure out (im so stupid)
        Dim remainingWidth = mainPanel.Width - (pictureBox.Width + itemInfoPanel.PreferredSize.Width)
        spacer.Width = Integer.Abs(remainingWidth - itemButtonPanel.Width)
        spacer.Height = 10
        spacer.Margin = New Padding(0)

        itemButtonPanel.Controls.Add(increaseButton)
        itemButtonPanel.Controls.Add(amountWrapper)
        itemButtonPanel.Controls.Add(decreaseButton)
        itemButtonPanel.Controls.Add(deleteButton)

        ' Add controls to main panel
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

        ' Instead of refreshing everything, just loop through the orderpnl then
        ' per panel children, iterate through it again or just name the panel with the name
        ' of the item. After finding the name, change that panel's amount instead of everything

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim itemAmount = CInt(row.Cells(0).Value)
            Dim itemName As String = CStr(row.Cells(1).Value)
            Dim itemPrice As String = CStr(row.Cells(2).Value)
            Dim itemImage As String = CStr(row.Cells(4).Value)
            Dim item As FlowLayoutPanel = AddItemToOrderList(itemName, itemPrice, itemAmount, itemImage)
            OrderPnl.Controls.Add(item)
            OrderPnl.ScrollControlIntoView(item)
        Next row
    End Sub




    ' Buttons
    Private Sub CreateOrderBtn_Click(sender As Object, e As EventArgs) Handles CreateOrderBtn.Click
        If Not DataGridView1.Rows.Count > 0 Then
            MsgBox("Please create an order first", MsgBoxStyle.Critical, "Warning")
            Return
        End If

        If Not MsgBox("Create order?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Information, "Attention") = MsgBoxResult.Yes Then
            Return
        End If


        Dim ConnectionString = GetGlobalConnectionString()
        Dim Connection As New MySqlConnection(ConnectionString)

        Dim TotalAmount = Double.Parse(TotalLbl.Text.Substring(1))

        Try
            Connection.Open()
            Dim Query = "INSERT INTO orders (order_date, order_time, username, total_amount) VALUES (@date, @time, @user, @total)"
            Dim Command As New MySqlCommand(Query, Connection)
            Command.Parameters.AddWithValue("@date", Date.Now.ToString("yyyy-MM-dd"))
            Command.Parameters.AddWithValue("@time", Date.Now.ToString("HH:mm:ss"))
            Command.Parameters.AddWithValue("@user", CurrentUser)
            Command.Parameters.AddWithValue("@total", TotalAmount)

            If Command.ExecuteNonQuery > 0 Then
                MsgBox("Order created", MsgBoxStyle.Information, "Success")
                Dim receiptName = CreateReceiptPDF()

                ' display receipt
                Dim receiptForm As New Form
                receiptForm.Size = New System.Drawing.Size(500, 800)
                receiptForm.KeyPreview = True
                receiptForm.Text = "Receipt"
                receiptForm.StartPosition = FormStartPosition.CenterScreen
                AddHandler receiptForm.KeyPress, Sub()
                                                     receiptForm.Close()
                                                 End Sub

                Dim pdfViewer1 = New PdfiumViewer.PdfViewer()
                pdfViewer1.Dock = DockStyle.Fill
                receiptForm.Controls.Add(pdfViewer1)
                pdfViewer1.Document = PdfiumViewer.PdfDocument.Load(receiptName)
                pdfViewer1.ZoomMode = PdfViewerZoomMode.FitWidth

                receiptForm.Height = pdfViewer1.Height
                receiptForm.ShowDialog()


                InsertActivityLog("Created an order with total of " & CurrentTotal)

                CurrentTotal = 0
                CurrentSubTotal = 0
                DiscountValue = 0

                SubtotalLbl.Text = "₱" & CurrentSubTotal
                DiscountLbl.Text = "%" & DiscountValue
                TotalLbl.Text = "₱" & CurrentTotal

                DataGridView1.Rows.Clear()
                UpdateItemOrderList()
                pnlwas.Focus()
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
        Dim itemName As String = CType(sender, Guna2CircleButton).Tag.ToString()

        Dim itemBtnName As String = CType(sender, Guna2CircleButton).Tag
        Dim price As String = HandleItemAmountUpdate(True, itemBtnName)

        UpdateItemOrderList()
        Compute()
    End Sub
    Private Sub DecreaseButtonHandler(sender As Object, e As EventArgs)
        Dim itemName As String = CType(sender, Guna2CircleButton).Tag.ToString()

        Dim itemBtnName As String = CType(sender, Guna2CircleButton).Tag
        Dim price As String = HandleItemAmountUpdate(False, itemBtnName)

        UpdateItemOrderList()
        Compute()
    End Sub
    Private Sub ApplyDiscount_Click(sender As Object, e As EventArgs) Handles DiscountBtn.Click
        Dim applyVoucherForm As New ApplyVoucher

        If applyVoucherForm.ShowDialog() = DialogResult.OK Then
            Dim discountType As String = ""

            For Each cntrl As Control In applyVoucherForm.DiscountPnl.Controls
                If TypeOf cntrl Is TextBox Then
                    Dim txtBox As TextBox = CType(cntrl, TextBox)
                    Dim val As Double = 0.0

                    If Double.TryParse(txtBox.Text, val) Then
                        DiscountValue = val / 100
                        DiscountLbl.Text = "%" & txtBox.Text
                    End If

                ElseIf TypeOf cntrl Is ComboBox Then
                    Dim cmbBox As ComboBox = CType(cntrl, ComboBox)

                    If Not cmbBox.Text.Contains("Select") Then
                        discountType = cmbBox.Text
                    End If

                End If
            Next

            Dim activityStatement As String = "Applied discount: " & DiscountValue
            If Not String.IsNullOrEmpty(discountType) Then
                activityStatement &= " Type: " & discountType
            End If

            InsertActivityLog(activityStatement)
            Dim appliedDiscount = (DiscountValue * CurrentTotal)
            CurrentTotal = If((Not DiscountValue = 0), Integer.Abs(appliedDiscount - CurrentSubTotal), CurrentSubTotal)
            TotalLbl.Text = "₱" + CurrentTotal.ToString
        End If

        ' need to log the apllying of voucher
    End Sub
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        If Not DataGridView1.Rows.Count > 0 Then
            MsgBox("Cannot cancel, No order created.", MsgBoxStyle.Critical, "Error")
            Return
        End If

        If Not MsgBox("Are you sure you want to cancel the order?", MsgBoxStyle.YesNoCancel, "Notice") = MsgBoxResult.Yes Then
            Return
        End If

        DataGridView1.Rows.Clear()
        OrderPnl.Controls.Clear()

        CurrentTotal = 0
        CurrentSubTotal = 0
        DiscountValue = 0

        SubtotalLbl.Text = "₱" & CurrentSubTotal
        DiscountLbl.Text = "%" & DiscountValue
        TotalLbl.Text = "₱" & CurrentTotal

        'CurrentFocused = Nothing
        'CurrentFocusedItem = ""
    End Sub
    Private Sub ShortcutKeys_Click(sender As Object, e As EventArgs) Handles ShortCutKeysBtn.Click
        Dim msg As String = "For selecting menu items: Use arrow key left/right and press enter to select" & vbCrLf & vbCrLf & "For adjusting the item's quantity: Use arrow key left/right and press enter to increase/decrease and Ctrl + Enter to continue" & vbCrLf & vbCrLf & "Shortcut keys can be enabled/disabled in the settings"
        MsgBox(msg, MsgBoxStyle.Information, "Shortcut keys")
    End Sub
    Private Sub RecentOrdersBtn_Click(sender As Object, e As EventArgs) Handles RecentOrdersBtn.Click
        DisplayRecentOrders()
    End Sub



    ' Create receipt
    Private Function CreateReceiptPDF()
        Dim receipt As New PdfSharp.Pdf.PdfDocument
        Dim page As PdfPage = receipt.AddPage()
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        Dim regFont As New XFont("Arial", 12, XFontStyleEx.Regular)
        Dim textBrush As XBrush = XBrushes.Black

        Dim currentDate As String = Date.Now.ToString

        gfx.DrawString("Cashier: " & CurrentUser, regFont, textBrush, New XRect(50, 50, 200, 100), XStringFormats.TopLeft)
        gfx.DrawString("Date & time: " & currentDate, regFont, textBrush, New XRect(50, 80, 200, 100), XStringFormats.TopLeft)

        Dim posY As Integer = 120
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim itemName As String = row.Cells(1).Value.ToString
            Dim itemPrice As String = row.Cells(2).Value.ToString
            Dim itemAmount As String = row.Cells(0).Value.ToString
            Dim orderFormat As String = itemAmount & "  " & itemName & "    ₱" & itemPrice
            gfx.DrawString(orderFormat, regFont, textBrush, New XRect(50, posY, 200, 100), XStringFormats.TopLeft)
            posY += 30
        Next

        gfx.DrawString("Sub total: ₱" & CurrentSubTotal, regFont, textBrush, New XRect(50, posY + 50, 200, 100), XStringFormats.TopLeft)
        gfx.DrawString("Discount: %" & DiscountValue, regFont, textBrush, New XRect(50, posY + 80, 200, 100), XStringFormats.TopLeft)
        gfx.DrawString("Total: ₱" & CurrentTotal, regFont, textBrush, New XRect(50, posY + 110, 200, 100), XStringFormats.TopLeft)

        Dim receiptID As String = ""

        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Try
            Connection.Open()
            Dim Query As String = "SELECT COUNT(*) AS `TOTAL` FROM restaurant.orders"
            Dim Command As New MySqlCommand(Query, Connection)
            Dim Reader As MySqlDataReader = Command.ExecuteReader

            If Reader.Read Then
                receiptID = Reader("TOTAL")
            End If

            'MsgBox("total number of orders: " & idCount)
            'receiptID = idCount

        Catch ex As Exception
            MsgBox("Error from db: " & ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try

        Dim basePath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ' Using MyDocuments as a dynamic base path
        Dim receiptsFolder As String = Path.Combine(basePath, "Receipts")

        If Not Directory.Exists(receiptsFolder) Then
            Directory.CreateDirectory(receiptsFolder)
        End If

        Dim filename As String = "Receipt" & receiptID & ".pdf"
        Dim receiptPath As String = Path.Combine(receiptsFolder, filename)
        receipt.Save(receiptPath)

        MsgBox("A receipt has been created at: " & receiptPath)
        Return receiptPath
    End Function



    ' listeners & handlers
    Private Sub HandleSearchTxtBoxEnter(sender As Object, e As KeyPressEventArgs) Handles SearchTxtBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(SearchTxtBox.Text) Then
                SearchItem(SearchTxtBox.Text)
            End If
        End If
    End Sub
    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        Dim res = MsgBox("Are you sure you wnat to log out?", MsgBoxStyle.YesNoCancel, "Notice")
        If res = MsgBoxResult.Yes Then
            CurrentUser = ""
            IsAdmin = Nothing
            Form1.Show()
            Me.Hide()
        End If
    End Sub
    Private Function HandleItemAmountUpdate(ByVal isIncrease As Boolean, ByVal itemName As String)
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = itemName Then

                Dim newval As Integer = 0
                Dim currentAmount = CInt(row.Cells(0).Value)

                If isIncrease Then
                    newval = CInt(row.Cells(0).Value) + 1
                Else
                    If currentAmount > 0 And Not (currentAmount - 1) = 0 Then
                        row.Cells(0).Value = currentAmount - 1
                        Return CStr(row.Cells(2).Value)
                    Else
                        MsgBox("Deleted row: item amount is equal to 0")
                        DataGridView1.Rows.RemoveAt(row.Index)
                    End If
                End If

                row.Cells(0).Value = newval

                Return CStr(row.Cells(2).Value) ' return item price
                Exit For
            End If
        Next

        Return "0"
    End Function
    Private Sub RemoveItemHandler(sender As Object, e As EventArgs)
        Dim btn As Guna2CircleButton = CType(sender, Guna2CircleButton)

        Dim index As Integer = 0
        For Each row In DataGridView1.Rows
            If row.cells(1).value = btn.Tag Then
                DataGridView1.Rows.RemoveAt(index)
                Exit For
            Else index += 1
            End If
        Next

        UpdateItemOrderList()
        Compute()
    End Sub
    Private Sub HandleKeydownSelect(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.Enter Then
            CreateOrderBtn_Click(sender, e)
            'ElseIf e.KeyCode = Keys.Left Then
            '    If currentIndex > 0 Then
            '        'MenuItems(currentIndex).FlatAppearance.BorderColor = Color.Gray
            '        currentIndex -= 1
            '    End If

            'ElseIf e.KeyCode = Keys.Right Then
            '    If currentIndex < MenuItems.Count - 1 Then
            '        'MenuItems(currentIndex).FlatAppearance.BorderColor = Color.Gray
            '        currentIndex += 1
            '    End If

            'ElseIf e.KeyCode = Keys.Enter Then
            '    Dim btnSelected As Guna2PictureBox = MenuItems(currentIndex)
            '    HandleItemClick(btnSelected, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.C Then
            CancelBtn_Click(sender, e) ' cancel order
        ElseIf e.Control AndAlso e.KeyCode = Keys.D Then
            ApplyDiscount_Click(sender, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.O Then
            RecentOrdersBtn_Click(sender, e)
            'Else
            '    Me.Focus()
        End If

        ' handle current focused item
        'MenuItems(currentIndex).FlatAppearance.BorderColor = Color.Red

        ' get the currrent focused btn instead of using btn.focus()
        'CurrentFocusedItem = MenuItems(currentIndex).Text
        'For Each btn As Guna2PictureBox In MenuItems
        '    If btn.Text = CurrentFocusedItem Then
        '        CurrentFocused = btn
        '    End If
        'Next
    End Sub
    Private Sub HandleIfItemExistsInOrder(ByVal itemName As String, ByVal itemPrice As String, ByVal tagImgPath As String, ByVal itemAmount As Integer)
        Dim nameExists As Boolean = False

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = itemName Then
                nameExists = True
                row.Cells(0).Value = itemAmount ' set item amount
                row.Cells(3).Value = CInt(row.Cells(3).Value) + Integer.Parse(itemPrice) ' set item total
                Exit For
            End If
        Next

        ' create new row if doesn't exists
        If Not nameExists Then
            Dim newRow As New DataGridViewRow()
            newRow.CreateCells(DataGridView1, itemAmount, itemName, itemPrice, itemPrice * itemAmount, tagImgPath)
            DataGridView1.Rows.Add(newRow)

            Dim item As FlowLayoutPanel = AddItemToOrderList(itemName, itemPrice, itemAmount, tagImgPath)
            OrderPnl.Controls.Add(item)
            OrderPnl.ScrollControlIntoView(item)
        ElseIf nameExists Then
            UpdateItemOrderList()  ' just update the order list if it exists
        End If

    End Sub
    Private Sub Compute()
        ' reset for computation
        CurrentTotal = 0
        CurrentSubTotal = 0

        If DataGridView1.Rows.Count = 0 Then
            TotalLbl.Text = "₱" & CurrentTotal
            SubtotalLbl.Text = "₱" & CurrentSubTotal
            Return
        End If

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim itemAmount As Integer = Integer.Parse(row.Cells(0).Value) ' item amount
            Dim itemPrice As Integer = Integer.Parse(row.Cells(2).Value) ' item price

            HandleDiscount(itemPrice * itemAmount)
        Next

    End Sub
    Private Sub HandleDiscount(ByVal itemPrice As String)
        CurrentSubTotal += Integer.Parse(itemPrice)
        SubtotalLbl.Text = "₱" & CurrentSubTotal

        Dim appliedDiscount = (DiscountValue * CurrentSubTotal)
        CurrentTotal = If((Not DiscountValue = 0), Integer.Abs(appliedDiscount - CurrentSubTotal), CurrentSubTotal)
        TotalLbl.Text = "₱" & CurrentTotal
    End Sub

End Class