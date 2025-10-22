Imports System.ComponentModel.DataAnnotations
Imports System.Data.OleDb
Imports System.Drawing.Text
Imports System.IO
Imports System.Reflection.Metadata
Imports System.Transactions
Imports System.Windows.Forms.Design
Imports System.Xml
Imports FontAwesome.Sharp
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
Imports PdfSharp.Quality
Imports ZstdSharp.Unsafe

Public Class Order
    Dim CurrentTotal As Integer
    Dim CurrentSubTotal As Integer
    Dim DiscountValue As Double = 0
    Dim CurrentFocusedItem As String
    Dim MenuItems As New List(Of Button)
    Dim currentIndex As Integer = 0
    Dim CurrentFocused As Button = Nothing

    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSettingsConfig()

        ' Defensive defaults: ensure settings produce valid sizes/fonts
        If SettingsConfig.MenuItemButtonSize <= 0 Then
            SettingsConfig.MenuItemButtonSize = 100
        End If
        If SettingsConfig.MenuItemFontSize <= 0 Then
            SettingsConfig.MenuItemFontSize = 12
        End If

        Me.KeyPreview = True
        GlobalFontSettings.UseWindowsFontsUnderWindows = True
        Me.WindowState = WindowState.Maximized
        CurrentTotal = 0

        ' data grid view essentials
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
    End Sub

    Private Sub Order_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Form1.Dispose()
    End Sub

    Private Sub OrderForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If SettingsConfig.EnableShortcutKeys Then
            HandleKeydownSelect(sender, e)
        End If
    End Sub

    ''' <summary>
    ''' ✨ PROFESSIONAL Restaurant POS Order Dialog
    ''' Clean, intuitive, and fully functional ordering interface
    ''' </summary>
    Private Function DisplayItemDialogForm(ByVal itemAmount As Integer) As Integer
        ' Main dialog window
        Dim itemDialog As New Form With {
            .Size = New Size(500, 550),
            .StartPosition = FormStartPosition.CenterScreen,
            .KeyPreview = True,
            .FormBorderStyle = FormBorderStyle.None,
            .BackColor = Color.FromArgb(240, 242, 245)
        }

        ' Main container
        Dim mainPanel As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.White,
            .Padding = New Padding(0)
        }

        ' 🎨 Header Section - Clean & Professional
        Dim headerPanel As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 90,
            .BackColor = Color.FromArgb(37, 42, 52),
            .Padding = New Padding(25, 20, 25, 20)
        }

        Dim itemNameLabel As New Label With {
            .Text = CurrentFocused.Text,
            .Font = New Font("Segoe UI", 22, FontStyle.Bold),
            .ForeColor = Color.White,
            .Dock = DockStyle.Top,
            .Height = 35
        }

        Dim itemPriceLabel As New Label With {
            .Font = New Font("Segoe UI", 12, FontStyle.Regular),
            .ForeColor = Color.FromArgb(148, 163, 184),
            .Dock = DockStyle.Bottom,
            .Height = 25
        }

        ' Get price from tag
        Dim tagData As TagData = ExtractTag(CurrentFocused.Tag)
        itemPriceLabel.Text = "₱" & tagData.Price & " per item"

        headerPanel.Controls.AddRange({itemNameLabel, itemPriceLabel})

        ' 📦 Content Section - Quantity Controls
        Dim contentPanel As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.White,
            .Padding = New Padding(40, 50, 40, 30)
        }

        ' Quantity label
        Dim lblQtyTitle As New Label With {
            .Text = "Quantity",
            .Font = New Font("Segoe UI", 11, FontStyle.Regular),
            .ForeColor = Color.FromArgb(100, 116, 139),
            .Location = New Point(40, 40),
            .AutoSize = True
        }

        ' Quantity display with controls
        Dim quantityControlPanel As New Panel With {
            .Size = New Size(420, 120),
            .Location = New Point(40, 75),
            .BackColor = Color.FromArgb(248, 250, 252)
        }

        ' Decrease button (-)
        Dim decreaseButton As New Button With {
            .Size = New Size(100, 120),
            .Location = New Point(0, 0),
            .BackColor = Color.FromArgb(248, 250, 252),
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 36, FontStyle.Bold),
            .ForeColor = Color.FromArgb(100, 116, 139),
            .Text = "−",
            .Cursor = Cursors.Hand,
            .TabStop = False
        }
        decreaseButton.FlatAppearance.BorderSize = 0
        decreaseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240)

        ' Quantity display
        Dim itemAmountLabel As New Label With {
            .Text = itemAmount.ToString(),
            .Font = New Font("Segoe UI", 52, FontStyle.Bold),
            .ForeColor = Color.FromArgb(37, 42, 52),
            .Size = New Size(220, 120),
            .Location = New Point(100, 0),
            .TextAlign = ContentAlignment.MiddleCenter,
            .BackColor = Color.White
        }

        ' Increase button (+)
        Dim increaseButton As New Button With {
            .Size = New Size(100, 120),
            .Location = New Point(320, 0),
            .BackColor = Color.FromArgb(248, 250, 252),
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 36, FontStyle.Bold),
            .ForeColor = Color.FromArgb(100, 116, 139),
            .Text = "+",
            .Cursor = Cursors.Hand,
            .TabStop = False
        }
        increaseButton.FlatAppearance.BorderSize = 0
        increaseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240)

        quantityControlPanel.Controls.AddRange({decreaseButton, itemAmountLabel, increaseButton})
        contentPanel.Controls.AddRange({lblQtyTitle, quantityControlPanel})

        ' 💰 Order Summary Section
        Dim summaryPanel As New Panel With {
            .Size = New Size(420, 80),
            .Location = New Point(40, 230),
            .BackColor = Color.FromArgb(241, 245, 249),
            .Padding = New Padding(20)
        }

        Dim lblSubtotal As New Label With {
            .Text = "Subtotal",
            .Font = New Font("Segoe UI", 11, FontStyle.Regular),
            .ForeColor = Color.FromArgb(100, 116, 139),
            .Dock = DockStyle.Left,
            .AutoSize = True
        }

        Dim lblSubtotalAmount As New Label With {
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.FromArgb(37, 42, 52),
            .Dock = DockStyle.Right,
            .TextAlign = ContentAlignment.MiddleRight,
            .AutoSize = True
        }

        ' Calculate and display subtotal
        Dim CalculateSubtotal = Sub()
                                    Dim price As Integer = Integer.Parse(tagData.Price)
                                    Dim subtotal As Integer = price * itemAmount
                                    lblSubtotalAmount.Text = "₱" & subtotal.ToString()
                                End Sub
        CalculateSubtotal()

        summaryPanel.Controls.AddRange({lblSubtotal, lblSubtotalAmount})
        contentPanel.Controls.Add(summaryPanel)

        ' 🎯 Action Buttons Section
        Dim btnPanel As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 100,
            .BackColor = Color.White,
            .Padding = New Padding(40, 20, 40, 25)
        }

        ' Add to Order button
        Dim confirmBtn As New Button With {
            .Text = "Add to Order",
            .Dock = DockStyle.Fill,
            .Height = 55,
            .BackColor = Color.FromArgb(16, 185, 129),
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .ForeColor = Color.White,
            .Cursor = Cursors.Hand,
            .TabStop = False
        }
        confirmBtn.FlatAppearance.BorderSize = 0
        confirmBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(5, 150, 105)

        ' Cancel button
        Dim cancelBtn As New Button With {
            .Text = "Cancel",
            .Dock = DockStyle.Right,
            .Width = 140,
            .Height = 55,
            .BackColor = Color.FromArgb(226, 232, 240),
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = Color.FromArgb(71, 85, 105),
            .Cursor = Cursors.Hand,
            .Margin = New Padding(0, 0, 15, 0),
            .TabStop = False
        }
        cancelBtn.FlatAppearance.BorderSize = 0
        cancelBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(203, 213, 225)

        btnPanel.Controls.AddRange({confirmBtn, cancelBtn})

        ' Event Handlers
        AddHandler increaseButton.Click, Sub()
                                             itemAmount += 1
                                             itemAmountLabel.Text = itemAmount.ToString()
                                             CalculateSubtotal()
                                         End Sub

        AddHandler decreaseButton.Click, Sub()
                                             If itemAmount > 1 Then
                                                 itemAmount -= 1
                                                 itemAmountLabel.Text = itemAmount.ToString()
                                                 CalculateSubtotal()
                                             End If
                                         End Sub

        AddHandler confirmBtn.Click, Sub()
                                         itemDialog.DialogResult = DialogResult.OK
                                         itemDialog.Close()
                                     End Sub

        AddHandler cancelBtn.Click, Sub()
                                        itemDialog.DialogResult = DialogResult.Cancel
                                        itemDialog.Close()
                                    End Sub

        ' Keyboard shortcuts
        AddHandler itemDialog.KeyDown, Sub(s As Object, e As KeyEventArgs)
                                           If e.KeyCode = Keys.Enter Then
                                               itemDialog.DialogResult = DialogResult.OK
                                               itemDialog.Close()
                                           ElseIf e.KeyCode = Keys.Escape Then
                                               itemDialog.DialogResult = DialogResult.Cancel
                                               itemDialog.Close()
                                           ElseIf e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus OrElse e.KeyCode = Keys.Up Then
                                               itemAmount += 1
                                               itemAmountLabel.Text = itemAmount.ToString()
                                               CalculateSubtotal()
                                           ElseIf (e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Down) AndAlso itemAmount > 1 Then
                                               itemAmount -= 1
                                               itemAmountLabel.Text = itemAmount.ToString()
                                               CalculateSubtotal()
                                           End If
                                       End Sub

        mainPanel.Controls.AddRange({headerPanel, contentPanel, btnPanel})
        itemDialog.Controls.Add(mainPanel)

        If itemDialog.ShowDialog() = DialogResult.OK Then
            Return itemAmount
        Else
            Return -1
        End If
    End Function

    Private Sub DisplayRecentOrders()
        Dim recentDialog As New Form
        recentDialog.Size = New System.Drawing.Size(1000, 500)

        Dim pnlRecentOrders As New Panel
        pnlRecentOrders.Size = New System.Drawing.Size(recentDialog.Width, recentDialog.Height)
        pnlRecentOrders.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        Dim Connection As New MySqlConnection(GetGlobalConnectionString)
        Connection.Open()

        Dim salereport As New SalesReport
        salereport.LoadTransactionDetails(Connection, pnlRecentOrders)

        recentDialog.Controls.Add(pnlRecentOrders)
        recentDialog.ShowDialog()
    End Sub

    ' CRUD functions (unchanged)
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
        MenuItems.Clear()
        currentIndex = 0

        Try
            Connection.Open()
            Dim Query As String = "SELECT * FROM `" & table & "`"
            Dim Command As New MySqlCommand(Query, Connection)
            Reader = Command.ExecuteReader

            While Reader.Read
                Dim settingsSize As Integer = If(SettingsConfig.MenuItemButtonSize > 0, SettingsConfig.MenuItemButtonSize, 100)
                Dim fontSize As Single = If(SettingsConfig.MenuItemFontSize > 0, CSng(SettingsConfig.MenuItemFontSize), 12.0F)

                Dim foodBtn As New Button
                foodBtn.Size = New System.Drawing.Size(settingsSize, settingsSize)
                foodBtn.Margin = New Padding(0, 0, 0, 0)
                foodBtn.Text = Reader("ItemName")
                foodBtn.Tag = Reader("ItemPrice")
                foodBtn.Cursor = Cursors.Hand
                foodBtn.FlatStyle = FlatStyle.Flat
                foodBtn.FlatAppearance.BorderSize = 3
                foodBtn.FlatAppearance.BorderColor = Color.Gray
                foodBtn.TabStop = True

                If Not IsDBNull(Reader("ImagePath")) Then
                    If Not Reader("ImagePath") = "N/A" Then
                        Dim image As Image = Image.FromFile(Reader("ImagePath"))
                        foodBtn.Image = ResizeImageFit(image, foodBtn)
                        foodBtn.Tag &= "," & Reader("ImagePath")
                        foodBtn.ForeColor = Color.Transparent
                    End If
                End If

                AddHandler foodBtn.Click, AddressOf HandleItemClick

                Dim foodFont As New Font("Segoe UI", fontSize, FontStyle.Regular)

                Dim foodName As New Label
                foodName.Text = Reader("ItemName")
                foodName.Font = foodFont
                foodName.AutoSize = False
                foodName.MinimumSize = New Size(foodName.PreferredWidth, foodName.PreferredHeight)
                foodName.TextAlign = ContentAlignment.MiddleCenter

                Dim foodPrice As New Label
                foodPrice.Text = "₱" & Reader("ItemPrice")
                foodPrice.Font = foodFont
                foodName.AutoSize = False
                foodPrice.TextAlign = ContentAlignment.MiddleCenter

                Dim FoodContainerPnl As New FlowLayoutPanel
                FoodContainerPnl.FlowDirection = FlowDirection.TopDown
                FoodContainerPnl.Size = New System.Drawing.Size(settingsSize, settingsSize + foodName.Height + foodPrice.Height)
                FoodContainerPnl.Controls.Add(foodBtn)
                FoodContainerPnl.Controls.Add(foodName)
                FoodContainerPnl.Controls.Add(foodPrice)

                FoodPnl.Controls.Add(FoodContainerPnl)
                MenuItems.Add(foodBtn)
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
            ' Silent fail
        End Try
    End Sub

    ' Menu item/category click handlers
    Private Sub HandleItemClick(sender As Object, e As EventArgs)
        Dim button As Button = CType(sender, Button)
        CurrentFocusedItem = button.Text
        CurrentFocused = button

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
        Compute()
    End Sub

    Private Sub HandleCatClick(sender As Object, e As EventArgs)
        Dim catName = CType(sender, Button)
        FoodPnl.Controls.Clear()
        FoodPnl.Focus()
        LoadMenuItems(catName.Text)
    End Sub

    ' Display the items
    Private Function AddItemToOrderList(ByVal itemName As String, ByVal itemPrice As String, ByVal itemAmount As String, ByVal itemImage As String) As FlowLayoutPanel
        Dim mainPanel As New FlowLayoutPanel()
        mainPanel.FlowDirection = FlowDirection.LeftToRight
        mainPanel.WrapContents = False
        mainPanel.Width = OrderPnl.Width
        mainPanel.Height = 100
        mainPanel.BackColor = Color.LightGray
        mainPanel.AutoSize = False

        Dim pictureBox As New PictureBox()
        pictureBox.Size = New Size(80, 80)
        pictureBox.Image = If(String.IsNullOrEmpty(itemImage), Nothing, Image.FromFile(itemImage))
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage

        Dim itemAmountLabel As New Label()
        itemAmountLabel.Text = itemAmount
        itemAmountLabel.Font = New Font("Arial", 16, FontStyle.Bold)
        itemAmountLabel.AutoSize = True

        Dim amountWrapper As New Panel()
        amountWrapper.Size = New Size(itemAmountLabel.PreferredWidth + 10, mainPanel.Height)
        itemAmountLabel.Location = New Point(0, ((mainPanel.Height - itemAmountLabel.Height) \ 2) - 30)
        amountWrapper.Controls.Add(itemAmountLabel)

        Dim itemInfoPanel As New FlowLayoutPanel()
        itemInfoPanel.FlowDirection = FlowDirection.TopDown
        itemInfoPanel.AutoSize = True

        Dim labelName As New Label()
        labelName.Text = itemName
        labelName.Font = New Font("Arial", 14, FontStyle.Bold)
        labelName.AutoSize = True

        Dim labelPrice As New Label()
        labelPrice.Text = "₱" & itemPrice
        labelPrice.Font = New Font("Arial", 12, FontStyle.Bold)
        labelPrice.AutoSize = True

        itemInfoPanel.Controls.Add(labelName)
        itemInfoPanel.Controls.Add(labelPrice)

        Dim itemButtonPanel As New FlowLayoutPanel()
        itemButtonPanel.FlowDirection = FlowDirection.LeftToRight
        itemButtonPanel.AutoSize = True

        Dim increaseButton As New IconButton()
        increaseButton.IconChar = IconChar.PlusCircle
        increaseButton.IconSize = 25
        increaseButton.IconColor = Color.White
        increaseButton.Tag = itemName
        increaseButton.BackColor = Color.Green
        increaseButton.Size = New Size(40, 40)
        AddHandler increaseButton.Click, AddressOf IncreaseButtonHandler

        Dim decreaseButton As New IconButton()
        decreaseButton.IconChar = IconChar.MinusCircle
        decreaseButton.IconSize = 25
        decreaseButton.IconColor = Color.White
        decreaseButton.Tag = itemName
        decreaseButton.BackColor = Color.Red
        decreaseButton.ForeColor = Color.White
        decreaseButton.Size = New Size(40, 40)
        AddHandler decreaseButton.Click, AddressOf DecreaseButtonHandler

        Dim deleteButton As New IconButton()
        deleteButton.IconChar = IconChar.Trash
        deleteButton.IconSize = 25
        deleteButton.IconColor = Color.White
        deleteButton.Tag = itemName
        deleteButton.BackColor = Color.Red
        deleteButton.ForeColor = Color.White
        deleteButton.Size = New Size(40, 40)
        AddHandler deleteButton.Click, AddressOf RemoveItemHandler

        Dim spacer As New Panel()
        Dim remainingWidth = mainPanel.Width - (pictureBox.Width + itemInfoPanel.PreferredSize.Width)
        spacer.Width = Integer.Abs(remainingWidth - itemButtonPanel.Width)
        spacer.Height = 10
        spacer.Margin = New Padding(0)

        itemButtonPanel.Controls.Add(increaseButton)
        itemButtonPanel.Controls.Add(amountWrapper)
        itemButtonPanel.Controls.Add(decreaseButton)
        itemButtonPanel.Controls.Add(deleteButton)

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
            Dim item As FlowLayoutPanel = AddItemToOrderList(itemName, itemPrice, itemAmount, itemImage)
            OrderPnl.Controls.Add(item)
            OrderPnl.ScrollControlIntoView(item)
        Next row
    End Sub

    ' Buttons (rest of the code continues...)
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
        Dim TotalAmount = Integer.Parse(TotalLbl.Text.Substring(1))

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

                ' Generate PDF receipt
                Dim receiptPath = CreateReceiptPDF()

                ' ===== NEW CODE: Launch modern Receipt form =====
                Try
                    ' Build order data from current order
                    Dim orderData As New Receipt.OrderData With {
                        .OrderId = GetLatestOrderId(), ' Helper function to get latest order ID
                        .OrderDate = Date.Now,
                        .CashierName = CurrentUser,
                        .Items = New List(Of Receipt.OrderItem),
                        .Subtotal = CDec(CurrentSubTotal),
                        .DiscountPercent = DiscountValue * 100,
                        .Total = CDec(CurrentTotal),
                        .PaymentMethod = "Cash"
                    }

                    ' Populate items from DataGridView
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        Dim item As New Receipt.OrderItem With {
                            .Name = If(row.Cells(1).Value IsNot Nothing, row.Cells(1).Value.ToString(), ""),
                            .Amount = If(row.Cells(0).Value IsNot Nothing, CInt(row.Cells(0).Value), 0),
                            .Price = If(row.Cells(2).Value IsNot Nothing, CDec(row.Cells(2).Value), 0D),
                            .Total = If(row.Cells(3).Value IsNot Nothing, CDec(row.Cells(3).Value), 0D)
                        }
                        orderData.Items.Add(item)
                    Next

                    ' Show the modern receipt form (native UI + PDF preview)
                    Dim receiptForm As New Receipt()
                    receiptForm.LoadReceipt(orderData, receiptPath)
                    receiptForm.ShowDialog(Me)

                Catch ex As Exception
                    ' Fallback to basic message if receipt form fails
                    MessageBox.Show("Receipt created but could not display preview: " & ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
                ' ===== END NEW CODE =====

                InsertActivityLog("Created an order with total of " & CurrentTotal)

                ' Reset form
                CurrentTotal = 0
                CurrentSubTotal = 0
                DiscountValue = 0

                SubtotalLbl.Text = "₱" & CurrentSubTotal
                DiscountLbl.Text = "%" & DiscountValue
                TotalLbl.Text = "₱" & CurrentTotal

                DataGridView1.Rows.Clear()
                UpdateItemOrderList()
                FoodPnl.Focus()
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
        Dim price As String = HandleItemAmountUpdate(True, itemBtnName)
        UpdateItemOrderList()
        Compute()
    End Sub

    Private Sub DecreaseButtonHandler(sender As Object, e As EventArgs)
        Dim itemName As String = CType(sender, Button).Tag.ToString()
        Dim itemBtnName As String = CType(sender, Button).Tag
        Dim price As String = HandleItemAmountUpdate(False, itemBtnName)
        UpdateItemOrderList()
        Compute()
    End Sub

    Private Sub ApplyDiscount_Click(sender As Object, e As EventArgs) Handles DiscountBtn.Click
        Dim applyVoucherForm As New ApplyVoucher

        If applyVoucherForm.ShowDialog() = DialogResult.OK Then
            ' Read selected discount from the dialog (public properties)
            Dim selectedPercent As Double = applyVoucherForm.SelectedDiscountPercent
            Dim discountType As String = applyVoucherForm.SelectedDiscountType

            If selectedPercent <= 0 Then
                MessageBox.Show("No discount selected.", "Discount", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Apply discount (store as fraction 0.2 for 20%)
            DiscountValue = selectedPercent / 100.0
            DiscountLbl.Text = "%" & selectedPercent.ToString("0.##")

            ' Log activity
            Dim activityStatement As String = "Applied discount: " & (selectedPercent.ToString("0.##") & "%")
            If Not String.IsNullOrEmpty(discountType) Then
                activityStatement &= " Type: " & discountType
            End If
            InsertActivityLog(activityStatement)

            ' Recalculate totals: discount applies to subtotal
            Dim appliedDiscount = (DiscountValue * CurrentSubTotal)
            CurrentTotal = CInt(Math.Round(CurrentSubTotal - appliedDiscount))
            TotalLbl.Text = "₱" & CurrentTotal.ToString()

        End If
    End Sub

    Private Sub SettingsBtn_Click(sender As Object, e As EventArgs) Handles SettingsBtn.Click
        If Settings.ShowDialog() = DialogResult.OK Then
            FoodPnl.Controls.Clear()
            LoadMenuItems("foods")
        End If
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
    End Sub

    Private Sub ShortcutKeys_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        Dim msg As String = "For selecting menu items: Use arrow key left/right and press enter to select" & vbCrLf & vbCrLf & "For adjusting the item's quantity: Use arrow key left/right and press enter to increase/decrease and Ctrl + Enter to continue" & vbCrLf & vbCrLf & "Shortcut keys can be enabled/disabled in the settings"
        MsgBox(msg, MsgBoxStyle.Information, "Shortcut keys")
    End Sub

    Private Sub RecentOrdersBtn_Click(sender As Object, e As EventArgs) Handles RecentOrdersBtn.Click
        DisplayRecentOrders()
    End Sub

    ' Create receipt
    Private Function CreateReceiptPDF() As String
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
            Dim itemName As String = If(row.Cells(1).Value IsNot Nothing, row.Cells(1).Value.ToString(), "")
            Dim itemPrice As String = If(row.Cells(2).Value IsNot Nothing, row.Cells(2).Value.ToString(), "0")
            Dim itemAmount As String = If(row.Cells(0).Value IsNot Nothing, row.Cells(0).Value.ToString(), "0")
            Dim orderFormat As String = itemAmount & "  " & itemName & "    ₱" & itemPrice
            gfx.DrawString(orderFormat, regFont, textBrush, New XRect(50, posY, 400, 100), XStringFormats.TopLeft)
            posY += 30
        Next

        gfx.DrawString("Sub total: ₱" & CurrentSubTotal, regFont, textBrush, New XRect(50, posY + 50, 200, 100), XStringFormats.TopLeft)
        gfx.DrawString("Discount: %" & DiscountValue, regFont, textBrush, New XRect(50, posY + 80, 200, 100), XStringFormats.TopLeft)
        gfx.DrawString("Total: ₱" & CurrentTotal, regFont, textBrush, New XRect(50, posY + 110, 200, 100), XStringFormats.TopLeft)

        ' Determine receipt ID (count)
        Dim receiptID As String = ""
        Try
            Using Connection As New MySqlConnection(GetGlobalConnectionString())
                Connection.Open()
                Dim Query As String = "SELECT COUNT(*) AS `TOTAL` FROM restaurant.orders"
                Using Command As New MySqlCommand(Query, Connection)
                    Dim result = Command.ExecuteScalar()
                    receiptID = If(result IsNot Nothing, result.ToString(), "0")
                End Using
            End Using
        Catch ex As Exception
            ' If DB read fails, fallback to timestamp to avoid overwrite
            receiptID = DateTime.Now.ToString("yyyyMMddHHmmss")
        End Try

        ' Build a safe receipts directory under the user's Documents and ensure it exists
        Dim receiptsDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Receipts")
        Try
            If Not Directory.Exists(receiptsDir) Then
                Directory.CreateDirectory(receiptsDir)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to create receipts folder: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        End Try

        Dim filename As String = "Receipt" & receiptID & ".pdf"
        Dim receiptPath As String = Path.Combine(receiptsDir, filename)

        Try
            receipt.Save(receiptPath)
            MessageBox.Show("A receipt has been created at: " & receiptPath, "Receipt Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return receiptPath
        Catch ex As Exception
            MessageBox.Show("Failed to save receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        End Try
    End Function

    ' listeners & handlers
    Private Sub HandleSearchTxtBoxEnter(sender As Object, e As KeyPressEventArgs) Handles SearchTxtBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(SearchTxtBox.Text) Then
                SearchItem(SearchTxtBox.Text)
            End If
        End If
    End Sub

    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        Dim res = MsgBox("Are you sure you want to log out?", MsgBoxStyle.YesNoCancel, "Notice")
        If res = MsgBoxResult.Yes Then
            Try
                ' Record logout activity (use existing CurrentUser and IsAdmin)
                InsertActivityLog("Logged out")
            Catch
                ' ignore logging failure
            End Try

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
                Return CStr(row.Cells(2).Value)
                Exit For
            End If
        Next

        Return "0"
    End Function

    Private Sub RemoveItemHandler(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim index As Integer = 0
        For Each row In DataGridView1.Rows
            If row.cells(1).value = btn.Tag Then
                DataGridView1.Rows.RemoveAt(index)
                Exit For
            Else
                index += 1
            End If
        Next

        UpdateItemOrderList()
        Compute()
    End Sub

    Private Sub HandleKeydownSelect(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.Enter Then
            CreateOrderBtn_Click(sender, e)
        ElseIf e.KeyCode = Keys.Left Then
            If currentIndex > 0 Then
                MenuItems(currentIndex).FlatAppearance.BorderColor = Color.Gray
                currentIndex -= 1
            End If
        ElseIf e.KeyCode = Keys.Right Then
            If currentIndex < MenuItems.Count - 1 Then
                MenuItems(currentIndex).FlatAppearance.BorderColor = Color.Gray
                currentIndex += 1
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            Dim btnSelected As Button = MenuItems(currentIndex)
            HandleItemClick(btnSelected, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.C Then
            CancelBtn_Click(sender, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.D Then
            ApplyDiscount_Click(sender, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.O Then
            RecentOrdersBtn_Click(sender, e)
        Else
            Me.Focus()
        End If

        MenuItems(currentIndex).FlatAppearance.BorderColor = Color.Red
        CurrentFocusedItem = MenuItems(currentIndex).Text
        For Each btn As Button In MenuItems
            If btn.Text = CurrentFocusedItem Then
                CurrentFocused = btn
            End If
        Next
    End Sub

    Private Sub HandleIfItemExistsInOrder(ByVal itemName As String, ByVal itemPrice As String, ByVal tagImgPath As String, ByVal itemAmount As Integer)
        Dim nameExists As Boolean = False

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = itemName Then
                nameExists = True
                row.Cells(0).Value = itemAmount
                row.Cells(3).Value = CInt(row.Cells(3).Value) + Integer.Parse(itemPrice)
                Exit For
            End If
        Next

        If Not nameExists Then
            Dim newRow As New DataGridViewRow()
            newRow.CreateCells(DataGridView1, itemAmount, itemName, itemPrice, itemPrice * itemAmount, tagImgPath)
            DataGridView1.Rows.Add(newRow)

            Dim item As FlowLayoutPanel = AddItemToOrderList(itemName, itemPrice, itemAmount, tagImgPath)
            OrderPnl.Controls.Add(item)
            OrderPnl.ScrollControlIntoView(item)
        ElseIf nameExists Then
            UpdateItemOrderList()
        End If
    End Sub

    Private Sub Compute()
        CurrentTotal = 0
        CurrentSubTotal = 0

        If DataGridView1.Rows.Count = 0 Then
            TotalLbl.Text = "₱" & CurrentTotal
            SubtotalLbl.Text = "₱" & CurrentSubTotal
            Return
        End If

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim itemAmount As Integer = Integer.Parse(row.Cells(0).Value)
            Dim itemPrice As Integer = Integer.Parse(row.Cells(2).Value)
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
    Private Sub ClosePreviewFormOnKeyPress(sender As Object, e As KeyPressEventArgs)
        Try
            Dim f = TryCast(sender, Form)
            If f IsNot Nothing Then
                f.Close()
            End If
        Catch
            ' ignore
        End Try
    End Sub

    ''' <summary>
    ''' Get the latest order ID from database
    ''' </summary>
    Private Function GetLatestOrderId() As String
        Try
            Using conn As New MySqlConnection(GetGlobalConnectionString())
                conn.Open()
                Dim query As String = "SELECT IFNULL(MAX(order_id), 0) FROM orders"
                Using cmd As New MySqlCommand(query, conn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return result.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Fallback to timestamp if query fails
            Return DateTime.Now.ToString("yyyyMMddHHmmss")
        End Try
        Return "0"
    End Function
End Class