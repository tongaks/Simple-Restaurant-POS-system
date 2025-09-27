Imports System.ComponentModel.DataAnnotations
Imports System.Data.OleDb
Imports System.IO
Imports System.Transactions
Imports System.Windows.Forms.Design
Imports System.Xml


Public Class Order
    Dim CurrentTotal As Integer
    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CurrentTotal = 0
        LoadMenuCategories()
        LoadMenuItems("Foods")

        DataGridView1.ColumnCount = 3
        DataGridView1.Columns(0).Name = "ItemAmount"
        DataGridView1.Columns("ItemAmount").ValueType = GetType(Integer)

        DataGridView1.Columns(1).Name = "ItemName"

        DataGridView1.Columns(2).Name = "ItemPrice"
        DataGridView1.Columns("ItemPrice").ValueType = GetType(Integer)
    End Sub

    Private Sub Order_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        ' close parent when child closes
        Form1.Dispose()
    End Sub

    Private Sub LoadMenuCategories()
        Dim Connection As New OleDbConnection(GetGlobalConnectionString)
        Dim Reader As OleDbDataReader

        Try
            Connection.Open()
            Dim Query As String = "SELECT * FROM Categories"
            Dim Command As New OleDbCommand(Query, Connection)
            Reader = Command.ExecuteReader

            While Reader.Read
                Dim catBtn As New Button
                catBtn.Text = Reader("CategoryName")
                catBtn.Size = New System.Drawing.Size(100, 40)
                catBtn.Margin = New Padding(0, 0, 0, 10)
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
        Dim Connection As New OleDbConnection(GetGlobalConnectionString)
        Dim Reader As OleDbDataReader

        Try
            Connection.Open()
            Dim Query As String = "SELECT * FROM [" & table & "]"
            Dim Command As New OleDbCommand(Query, Connection)
            Reader = Command.ExecuteReader

            While Reader.Read
                Dim foodBtn As New Button
                foodBtn.Text = Reader("ItemName")
                foodBtn.Size = New System.Drawing.Size(100, 100)
                foodBtn.Margin = New Padding(0, 0, 0, 0)
                foodBtn.Tag = Reader("ItemPrice")
                foodBtn.Cursor = Cursors.Hand
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

    Private Sub AddItemToOrderPanel()
        OrderPnl.Controls.Clear()

        For Each row In DataGridView1.Rows
            If row.Cells(0).value = Nothing Then
                Exit For
            End If

            Dim amount = row.Cells(0).value.ToString
            Dim name = row.Cells(1).value.ToString
            Dim price = row.Cells(2).value.ToString

            Dim totalPnlWidth As Integer = OrderPnl.Width
            Dim itemNameWidth As Integer = CInt(totalPnlWidth * 0.45)
            Dim itemPriceWidth As Integer = CInt(totalPnlWidth * 0.25)
            Dim buttonWidth As Integer = 30
            Dim itemCountWidth As Integer = 35

            Dim itemCount As New Label
            itemCount.Text = amount
            itemCount.Font = New Font("Segue UI", 16.0F, FontStyle.Regular)
            itemCount.Size = New System.Drawing.Size(itemCountWidth, 30)
            itemCount.TextAlign = ContentAlignment.MiddleCenter

            Dim itemName As New Label
            itemName.Text = name
            itemName.Size = New System.Drawing.Size(itemNameWidth, 30)
            itemName.Font = New Font("Segue UI", 16.0F, FontStyle.Regular)
            itemName.AutoEllipsis = True

            Dim itemPrice As New Label
            itemPrice.Text = "₱" & price
            itemPrice.Size = New System.Drawing.Size(itemPriceWidth, 30)
            itemPrice.Font = New Font("Segue UI", 16.0F, FontStyle.Regular)
            itemPrice.TextAlign = ContentAlignment.MiddleRight

            Dim increaseBtn As New Button
            increaseBtn.Text = "+"
            increaseBtn.BackColor = Color.SpringGreen
            increaseBtn.FlatStyle = FlatStyle.Flat
            increaseBtn.Width = buttonWidth
            increaseBtn.Height = 30
            increaseBtn.Cursor = Cursors.Hand
            increaseBtn.Tag = itemCount.Text

            Dim decreaseBtn As New Button
            decreaseBtn.Text = "-"
            decreaseBtn.BackColor = Color.Salmon
            decreaseBtn.FlatStyle = FlatStyle.Flat
            decreaseBtn.Width = buttonWidth
            decreaseBtn.Height = 30
            decreaseBtn.Cursor = Cursors.Hand
            decreaseBtn.Tag = itemCount.Text

            Dim panel As New FlowLayoutPanel
            panel.BackColor = Color.LightBlue
            panel.FlowDirection = FlowDirection.LeftToRight
            panel.WrapContents = False
            panel.Margin = New Padding(0)
            panel.Controls.Add(itemCount)
            panel.Controls.Add(itemName)
            panel.Controls.Add(itemPrice)
            panel.Controls.Add(increaseBtn)
            panel.Controls.Add(decreaseBtn)
            panel.Size = New System.Drawing.Size(totalPnlWidth, itemName.Height + 5)
            panel.Padding = New Padding(0, 0, 0, 5)
            OrderPnl.Controls.Add(panel)
        Next
    End Sub

    Private Sub HandleItemClick(sender As Object, e As EventArgs)
        Dim name = CType(sender, Button).Text
        Dim price = CType(sender, Button).Tag

        Dim nameExists As Boolean = False

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = name Then
                nameExists = True
                row.Cells(0).Value = CInt(row.Cells(0).Value) + 1
                Exit For
            End If
        Next

        If Not nameExists Then
            Dim newRow As New DataGridViewRow()
            newRow.CreateCells(DataGridView1, 1, name, price)
            DataGridView1.Rows.Add(newRow)
        End If

        AddItemToOrderPanel()

        CurrentTotal += Integer.Parse(price)
        TotalLbl.Text = "₱" + CStr(CurrentTotal)
    End Sub

    Private Sub HandleCatClick(sender As Object, e As EventArgs)
        Dim catName = CType(sender, Button).Text
        FoodPnl.Controls.Clear()
        LoadMenuItems(catName)
    End Sub
End Class