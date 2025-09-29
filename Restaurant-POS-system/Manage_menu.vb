Imports System.Data.OleDb
Imports System.Reflection.Metadata
Imports System.Runtime.InteropServices
Imports Windows.Win32.UI.Input

Public Class Manage_menu
    Dim IsEdit As Boolean

    Private Sub Manage_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = WindowState.Maximized

        IsEdit = False

        LoadMenuCategories()
        LoadMenuItems("Foods")
    End Sub

    Public Function CreateFoodItemButton(itemName As String, itemPrice As String, imgPath As String)
        Dim foodBtn As New Button
        foodBtn.Text = itemName
        foodBtn.Size = New System.Drawing.Size(100, 100)
        foodBtn.Margin = New Padding(0, 0, 0, 0)
        foodBtn.Tag = itemPrice
        foodBtn.Cursor = Cursors.Hand

        If Not imgPath = Nothing Then
            Dim image As Image = Image.FromFile(imgPath)
            foodBtn.Image = ResizeImageFit(image, foodBtn)
        End If

        AddHandler foodBtn.Click, AddressOf HandleItemClick


        Dim foodPrice As New Label
        foodPrice.Text = "₱" & itemPrice
        foodPrice.Font = New Font("Segue UI", 18.0F, FontStyle.Regular)
        foodPrice.TextAlign = ContentAlignment.MiddleCenter

        Dim FoodContainerPnl As New FlowLayoutPanel
        FoodContainerPnl.Size = New System.Drawing.Size(100, 100 + foodPrice.Size.Height)
        FoodContainerPnl.Controls.Add(foodBtn)
        FoodContainerPnl.Controls.Add(foodPrice)

        Return FoodContainerPnl
    End Function

    Private Sub HandleItemClick(sender As Object, e As EventArgs)
        Label4.Visible = False
        ItemBtn.Visible = True
        ItemNameLbl.Visible = True
        PriceLbl.Visible = True
        ItemNameTxtBox.Visible = True
        PriceTxtBox.Visible = True
        EditBtn.Visible = True
        DeleteBtn.Visible = True

        Dim item As Button = CType(sender, Button)
        Dim price As String = item.Tag

        ItemBtn.Text = item.Text

        If item.Image IsNot Nothing Then
            ItemBtn.Image = ResizeImageFit(item.Image, ItemBtn)
        Else
            ItemBtn.Image = Nothing
        End If

        ItemNameTxtBox.Text = item.Text
        PriceTxtBox.Text = price
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
                Dim imagePath = If((Reader("ImagePath") = "N/A"), Nothing, Reader("ImagePath"))

                Dim panel As FlowLayoutPanel = CreateFoodItemButton(Reader("ItemName"), Reader("ItemPrice"), imagePath)
                FoodPnl.Controls.Add(panel)
            End While

            Dim addNewPanel As FlowLayoutPanel = CreateFoodItemButton("Add new item", "", "")
            FoodPnl.Controls.Add(addNewPanel)

        Catch ex As Exception
            MsgBox("Error: " + ex.ToString, MsgBoxStyle.Critical, "ERROR")
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
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

    Private Sub HandleCatClick(sender As Object, e As EventArgs)
        Dim catName = CType(sender, Button).Text
        FoodPnl.Controls.Clear()
        LoadMenuItems(catName)
    End Sub

    Private Sub SetItemImage_Click(sender As Object, e As EventArgs) Handles ItemBtn.Click
        Dim FileDialog As New OpenFileDialog
        FileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;|All Files|*.*"

        If FileDialog.ShowDialog() = DialogResult.OK Then
            Dim path As String = FileDialog.FileName
            MsgBox(path)

            Dim image As Image = Image.FromFile(path)
            ItemBtn.Image = ResizeImageFit(image, ItemBtn)
        End If
    End Sub

    Private Sub EditClick(sender As Object, e As EventArgs) Handles EditBtn.Click
        IsEdit = If((IsEdit = False), True, False)
    End Sub
End Class