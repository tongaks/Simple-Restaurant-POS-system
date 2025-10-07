<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Order
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        NavbarPnl = New Panel()
        SearchTxtBox = New TextBox()
        Label1 = New Label()
        SearchBtn = New Button()
        Button3 = New Button()
        Button2 = New Button()
        TotalPnl = New Panel()
        CreateOrderBtn = New Button()
        TotalLbl = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
        MenuCategoryPnl = New FlowLayoutPanel()
        FoodPnl = New FlowLayoutPanel()
        Panel2 = New Panel()
        DataGridView1 = New DataGridView()
        NavbarPnl.SuspendLayout()
        TotalPnl.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' NavbarPnl
        ' 
        NavbarPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        NavbarPnl.BackColor = Color.DarkSeaGreen
        NavbarPnl.Controls.Add(SearchTxtBox)
        NavbarPnl.Controls.Add(Label1)
        NavbarPnl.Controls.Add(SearchBtn)
        NavbarPnl.Controls.Add(Button3)
        NavbarPnl.Controls.Add(Button2)
        NavbarPnl.Location = New Point(473, 0)
        NavbarPnl.Margin = New Padding(3, 4, 3, 4)
        NavbarPnl.Name = "NavbarPnl"
        NavbarPnl.Size = New Size(717, 91)
        NavbarPnl.TabIndex = 1
        ' 
        ' SearchTxtBox
        ' 
        SearchTxtBox.Font = New Font("Segoe UI", 15F)
        SearchTxtBox.Location = New Point(91, 25)
        SearchTxtBox.Margin = New Padding(3, 4, 3, 4)
        SearchTxtBox.Name = "SearchTxtBox"
        SearchTxtBox.Size = New Size(291, 41)
        SearchTxtBox.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(19, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(70, 28)
        Label1.TabIndex = 6
        Label1.Text = "Search"
        ' 
        ' SearchBtn
        ' 
        SearchBtn.BackColor = Color.FromArgb(CByte(128), CByte(255), CByte(128))
        SearchBtn.FlatStyle = FlatStyle.Flat
        SearchBtn.Location = New Point(402, 28)
        SearchBtn.Margin = New Padding(3, 4, 3, 4)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.Size = New Size(86, 45)
        SearchBtn.TabIndex = 5
        SearchBtn.Text = "Search"
        SearchBtn.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button3.Location = New Point(619, 36)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(86, 31)
        Button3.TabIndex = 3
        Button3.Text = "Settings"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.Location = New Point(527, 36)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(86, 31)
        Button2.TabIndex = 2
        Button2.Text = "Account"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TotalPnl
        ' 
        TotalPnl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        TotalPnl.BackColor = SystemColors.Control
        TotalPnl.BorderStyle = BorderStyle.FixedSingle
        TotalPnl.Controls.Add(CreateOrderBtn)
        TotalPnl.Controls.Add(TotalLbl)
        TotalPnl.Controls.Add(Label2)
        TotalPnl.Location = New Point(-1, 728)
        TotalPnl.Margin = New Padding(3, 4, 3, 4)
        TotalPnl.Name = "TotalPnl"
        TotalPnl.Size = New Size(467, 77)
        TotalPnl.TabIndex = 4
        ' 
        ' CreateOrderBtn
        ' 
        CreateOrderBtn.BackColor = Color.LightGreen
        CreateOrderBtn.FlatStyle = FlatStyle.Flat
        CreateOrderBtn.Location = New Point(310, 12)
        CreateOrderBtn.Margin = New Padding(3, 4, 3, 4)
        CreateOrderBtn.Name = "CreateOrderBtn"
        CreateOrderBtn.Size = New Size(143, 51)
        CreateOrderBtn.TabIndex = 2
        CreateOrderBtn.Text = "Proceed"
        CreateOrderBtn.UseVisualStyleBackColor = False
        ' 
        ' TotalLbl
        ' 
        TotalLbl.AutoSize = True
        TotalLbl.Font = New Font("Segoe UI", 20F)
        TotalLbl.Location = New Point(167, 12)
        TotalLbl.Name = "TotalLbl"
        TotalLbl.Size = New Size(58, 46)
        TotalLbl.TabIndex = 1
        TotalLbl.Text = "₱0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F)
        Label2.Location = New Point(14, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 46)
        Label2.TabIndex = 0
        Label2.Text = "Total"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.DarkGray
        Panel1.Controls.Add(MenuCategoryPnl)
        Panel1.Controls.Add(FoodPnl)
        Panel1.Location = New Point(473, 88)
        Panel1.Margin = New Padding(3, 4, 3, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(718, 717)
        Panel1.TabIndex = 5
        ' 
        ' MenuCategoryPnl
        ' 
        MenuCategoryPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        MenuCategoryPnl.BackColor = Color.WhiteSmoke
        MenuCategoryPnl.Location = New Point(3, 4)
        MenuCategoryPnl.Margin = New Padding(3, 4, 3, 4)
        MenuCategoryPnl.Name = "MenuCategoryPnl"
        MenuCategoryPnl.Padding = New Padding(0, 0, 0, 27)
        MenuCategoryPnl.Size = New Size(717, 80)
        MenuCategoryPnl.TabIndex = 1
        ' 
        ' FoodPnl
        ' 
        FoodPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FoodPnl.BackColor = SystemColors.Control
        FoodPnl.Location = New Point(3, 80)
        FoodPnl.Margin = New Padding(3, 4, 3, 4)
        FoodPnl.Name = "FoodPnl"
        FoodPnl.Size = New Size(714, 637)
        FoodPnl.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel2.BackColor = SystemColors.Control
        Panel2.Controls.Add(DataGridView1)
        Panel2.Location = New Point(2, 1)
        Panel2.Margin = New Padding(3, 4, 3, 4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(463, 727)
        Panel2.TabIndex = 6
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Margin = New Padding(3, 4, 3, 4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(468, 727)
        DataGridView1.TabIndex = 1
        ' 
        ' Order
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1190, 805)
        Controls.Add(Panel2)
        Controls.Add(NavbarPnl)
        Controls.Add(Panel1)
        Controls.Add(TotalPnl)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Order"
        Text = "Order form"
        NavbarPnl.ResumeLayout(False)
        NavbarPnl.PerformLayout()
        TotalPnl.ResumeLayout(False)
        TotalPnl.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents NavbarPnl As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents SearchBtn As Button
    Friend WithEvents TotalPnl As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TotalLbl As Label
    Friend WithEvents TestTable As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuCategoryPnl As FlowLayoutPanel
    Friend WithEvents FoodPnl As FlowLayoutPanel
    Friend WithEvents CreateOrderBtn As Button
    Friend WithEvents SearchTxtBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DataGridView1 As DataGridView
End Class
