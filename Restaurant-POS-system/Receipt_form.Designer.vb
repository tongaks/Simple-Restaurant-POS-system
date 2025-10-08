<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Receipt_form
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
        OrderPnl = New FlowLayoutPanel()
        TotalPnl = New Panel()
        CreateOrderBtn = New Button()
        TotalLbl = New Label()
        Label2 = New Label()
        TotalPnl.SuspendLayout()
        SuspendLayout()
        ' 
        ' OrderPnl
        ' 
        OrderPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        OrderPnl.BackColor = SystemColors.Control
        OrderPnl.FlowDirection = FlowDirection.TopDown
        OrderPnl.Location = New Point(1, 2)
        OrderPnl.Name = "OrderPnl"
        OrderPnl.Size = New Size(469, 549)
        OrderPnl.TabIndex = 8
        ' 
        ' TotalPnl
        ' 
        TotalPnl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        TotalPnl.BackColor = SystemColors.Control
        TotalPnl.BorderStyle = BorderStyle.FixedSingle
        TotalPnl.Controls.Add(CreateOrderBtn)
        TotalPnl.Controls.Add(TotalLbl)
        TotalPnl.Controls.Add(Label2)
        TotalPnl.Location = New Point(476, 2)
        TotalPnl.Name = "TotalPnl"
        TotalPnl.Size = New Size(470, 58)
        TotalPnl.TabIndex = 7
        ' 
        ' CreateOrderBtn
        ' 
        CreateOrderBtn.BackColor = Color.LightGreen
        CreateOrderBtn.FlatStyle = FlatStyle.Flat
        CreateOrderBtn.Location = New Point(318, 11)
        CreateOrderBtn.Name = "CreateOrderBtn"
        CreateOrderBtn.Size = New Size(141, 38)
        CreateOrderBtn.TabIndex = 2
        CreateOrderBtn.Text = "Proceed to checkout"
        CreateOrderBtn.UseVisualStyleBackColor = False
        ' 
        ' TotalLbl
        ' 
        TotalLbl.AutoSize = True
        TotalLbl.Font = New Font("Segoe UI", 20F)
        TotalLbl.Location = New Point(146, 9)
        TotalLbl.Name = "TotalLbl"
        TotalLbl.Size = New Size(48, 37)
        TotalLbl.TabIndex = 1
        TotalLbl.Text = "₱0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F)
        Label2.Location = New Point(12, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 37)
        Label2.TabIndex = 0
        Label2.Text = "Total"
        ' 
        ' Receipt_form
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1041, 604)
        Controls.Add(TotalPnl)
        Controls.Add(OrderPnl)
        Name = "Receipt_form"
        Text = "Receipt_form"
        TotalPnl.ResumeLayout(False)
        TotalPnl.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents OrderPnl As FlowLayoutPanel
    Friend WithEvents TotalPnl As Panel
    Friend WithEvents CreateOrderBtn As Button
    Friend WithEvents TotalLbl As Label
    Friend WithEvents Label2 As Label
End Class
