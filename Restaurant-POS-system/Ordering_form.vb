Public Class Order
    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Int32 = 0 To 2
            Dim testBtn As New Button
            testBtn.Text = "Cat " + i.ToString
            testBtn.Size = New System.Drawing.Size(100, 40)
            testBtn.Margin = New Padding(0, 0, 0, 10)
            MenuCategoryPnl.Controls.Add(testBtn)
        Next i


        For i As Int32 = 0 To 10
            Dim foodBtn As New Button
            foodBtn.Text = "Food"
            foodBtn.Size = New System.Drawing.Size(100, 100)
            foodBtn.Margin = New Padding(0, 0, 0, 0)

            Dim foodName As New Label
            foodName.Text = "Food 1"
            foodName.TextAlign = ContentAlignment.MiddleCenter

            Dim FoodContainerPnl As New FlowLayoutPanel
            FoodContainerPnl.Size = New System.Drawing.Size(100, 100 + foodName.Size.Height)
            FoodContainerPnl.Controls.Add(foodBtn)
            FoodContainerPnl.Controls.Add(foodName)

            FoodPnl.Controls.Add(FoodContainerPnl)
        Next i


    End Sub
End Class