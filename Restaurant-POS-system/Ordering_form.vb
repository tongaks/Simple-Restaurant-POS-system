Imports System.Data.OleDb
Imports System.IO

Public Class Order
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
                Dim testbtn As New Button
                testbtn.Text = Reader("CategoryName")
                testbtn.Size = New System.Drawing.Size(100, 40)
                testbtn.Margin = New Padding(0, 0, 0, 10)
                MenuCategoryPnl.Controls.Add(testbtn)
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

    Private Sub HandleItemClick(sender As Object, e As EventArgs)
        Dim name = CType(sender, Button).Text
        Dim price = CType(sender, Button).Tag

        Dim label As New Label
        label.Text = name & " " & price
        OrderPnl.Controls.Add(label)
    End Sub

    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMenuCategories()
        LoadMenuItems("Foods")
    End Sub
End Class