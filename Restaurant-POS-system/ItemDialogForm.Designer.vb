<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ItemDialogForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblItemName As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents pnlContent As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlQuantity As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents btnDecrease As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblQuantity As Label
    Friend WithEvents btnIncrease As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlSummary As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblSubtotalLabel As Label
    Friend WithEvents lblSubtotalAmount As Label
    Friend WithEvents pnlActions As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblQuantityLabel As Label
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents pnlQuantityControls As Panel

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()

        Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(components)
        Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(components)
        Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(components)
        pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        pnlContent = New Guna.UI2.WinForms.Guna2Panel()
        pnlSummary = New Guna.UI2.WinForms.Guna2ShadowPanel()
        lblSubtotalLabel = New Label()
        lblSubtotalAmount = New Label()
        pnlQuantity = New Guna.UI2.WinForms.Guna2ShadowPanel()
        lblQuantityLabel = New Label()
        Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        pnlQuantityControls = New Panel()
        btnDecrease = New Guna.UI2.WinForms.Guna2Button()
        lblQuantity = New Label()
        btnIncrease = New Guna.UI2.WinForms.Guna2Button()
        pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        lblItemName = New Label()
        lblPrice = New Label()
        pnlActions = New Guna.UI2.WinForms.Guna2Panel()
        btnAdd = New Guna.UI2.WinForms.Guna2Button()
        btnCancel = New Guna.UI2.WinForms.Guna2Button()

        pnlMain.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlSummary.SuspendLayout()
        pnlQuantity.SuspendLayout()
        pnlQuantityControls.SuspendLayout()
        pnlHeader.SuspendLayout()
        pnlActions.SuspendLayout()
        SuspendLayout()

        ' 
        ' Guna2Elipse1
        ' 
        Guna2Elipse1.BorderRadius = 20
        Guna2Elipse1.TargetControl = Me

        ' 
        ' Guna2ShadowForm1
        ' 
        Guna2ShadowForm1.BorderRadius = 20
        Guna2ShadowForm1.ShadowColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        Guna2ShadowForm1.TargetForm = Me

        ' 
        ' Guna2DragControl1
        ' 
        Guna2DragControl1.DockIndicatorTransparencyValue = 0.6R
        Guna2DragControl1.TargetControl = pnlHeader
        Guna2DragControl1.UseTransparentDrag = True

        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.Transparent
        pnlMain.BorderRadius = 20
        pnlMain.Controls.Add(pnlContent)
        pnlMain.Controls.Add(pnlHeader)
        pnlMain.Controls.Add(pnlActions)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(249))
        pnlMain.Location = New Point(0, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.ShadowDecoration.BorderRadius = 20
        pnlMain.ShadowDecoration.Depth = 40
        pnlMain.ShadowDecoration.Enabled = True
        pnlMain.ShadowDecoration.Shadow = New Padding(0, 0, 8, 8)
        pnlMain.Size = New Size(520, 600)
        pnlMain.TabIndex = 0

        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.Transparent
        pnlContent.Controls.Add(pnlSummary)
        pnlContent.Controls.Add(pnlQuantity)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(249))
        pnlContent.Location = New Point(0, 120)
        pnlContent.Name = "pnlContent"
        pnlContent.Padding = New Padding(25, 25, 25, 20)
        pnlContent.Size = New Size(520, 370)
        pnlContent.TabIndex = 0

        ' 
        ' pnlSummary
        ' 
        pnlSummary.BackColor = Color.Transparent
        pnlSummary.Controls.Add(lblSubtotalLabel)
        pnlSummary.Controls.Add(lblSubtotalAmount)
        pnlSummary.Dock = DockStyle.Top
        pnlSummary.FillColor = Color.White
        pnlSummary.Location = New Point(25, 225)
        pnlSummary.Name = "pnlSummary"
        pnlSummary.Padding = New Padding(25, 20, 25, 20)
        pnlSummary.Radius = 15
        pnlSummary.ShadowColor = Color.FromArgb(CByte(200), CByte(200), CByte(200))
        pnlSummary.ShadowDepth = 8
        pnlSummary.ShadowShift = 2
        pnlSummary.Size = New Size(470, 90)
        pnlSummary.TabIndex = 0

        ' 
        ' lblSubtotalLabel
        ' 
        lblSubtotalLabel.AutoSize = True
        lblSubtotalLabel.BackColor = Color.Transparent
        lblSubtotalLabel.Font = New Font("Segoe UI", 13.0F, FontStyle.Regular)
        lblSubtotalLabel.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSubtotalLabel.Location = New Point(25, 30)
        lblSubtotalLabel.Name = "lblSubtotalLabel"
        lblSubtotalLabel.Size = New Size(93, 30)
        lblSubtotalLabel.TabIndex = 0
        lblSubtotalLabel.Text = "Subtotal"

        ' 
        ' lblSubtotalAmount
        ' 
        lblSubtotalAmount.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        lblSubtotalAmount.BackColor = Color.Transparent
        lblSubtotalAmount.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblSubtotalAmount.ForeColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        lblSubtotalAmount.Location = New Point(270, 20)
        lblSubtotalAmount.Name = "lblSubtotalAmount"
        lblSubtotalAmount.Size = New Size(175, 50)
        lblSubtotalAmount.TabIndex = 1
        lblSubtotalAmount.Text = "₱0.00"
        lblSubtotalAmount.TextAlign = ContentAlignment.MiddleRight

        ' 
        ' pnlQuantity
        ' 
        pnlQuantity.BackColor = Color.Transparent
        pnlQuantity.Controls.Add(pnlQuantityControls)
        pnlQuantity.Controls.Add(Guna2Separator1)
        pnlQuantity.Controls.Add(lblQuantityLabel)
        pnlQuantity.Dock = DockStyle.Top
        pnlQuantity.FillColor = Color.White
        pnlQuantity.Location = New Point(25, 25)
        pnlQuantity.Name = "pnlQuantity"
        pnlQuantity.Padding = New Padding(25, 20, 25, 20)
        pnlQuantity.Radius = 15
        pnlQuantity.ShadowColor = Color.FromArgb(CByte(200), CByte(200), CByte(200))
        pnlQuantity.ShadowDepth = 8
        pnlQuantity.ShadowShift = 2
        pnlQuantity.Size = New Size(470, 200)
        pnlQuantity.TabIndex = 1

        ' 
        ' lblQuantityLabel
        ' 
        lblQuantityLabel.BackColor = Color.Transparent
        lblQuantityLabel.Dock = DockStyle.Top
        lblQuantityLabel.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold)
        lblQuantityLabel.ForeColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        lblQuantityLabel.Location = New Point(25, 20)
        lblQuantityLabel.Name = "lblQuantityLabel"
        lblQuantityLabel.Size = New Size(420, 30)
        lblQuantityLabel.TabIndex = 0
        lblQuantityLabel.Text = "Select Quantity"
        lblQuantityLabel.TextAlign = ContentAlignment.MiddleLeft

        ' 
        ' Guna2Separator1
        ' 
        Guna2Separator1.BackColor = Color.Transparent
        Guna2Separator1.Dock = DockStyle.Top
        Guna2Separator1.FillColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        Guna2Separator1.FillThickness = 1
        Guna2Separator1.Location = New Point(25, 50)
        Guna2Separator1.Name = "Guna2Separator1"
        Guna2Separator1.Size = New Size(420, 10)
        Guna2Separator1.TabIndex = 1

        ' 
        ' pnlQuantityControls
        ' 
        pnlQuantityControls.BackColor = Color.Transparent
        pnlQuantityControls.Controls.Add(btnDecrease)
        pnlQuantityControls.Controls.Add(lblQuantity)
        pnlQuantityControls.Controls.Add(btnIncrease)
        pnlQuantityControls.Dock = DockStyle.Fill
        pnlQuantityControls.Location = New Point(25, 60)
        pnlQuantityControls.Name = "pnlQuantityControls"
        pnlQuantityControls.Size = New Size(420, 120)
        pnlQuantityControls.TabIndex = 2

        ' 
        ' btnDecrease
        ' 
        btnDecrease.Anchor = AnchorStyles.None
        btnDecrease.Animated = True
        btnDecrease.BackColor = Color.Transparent
        btnDecrease.BorderRadius = 12
        btnDecrease.DisabledState.BorderColor = Color.DarkGray
        btnDecrease.DisabledState.CustomBorderColor = Color.DarkGray
        btnDecrease.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnDecrease.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnDecrease.FillColor = Color.FromArgb(CByte(31), CByte(138), CByte(112))
        btnDecrease.Font = New Font("Segoe UI", 32.0F, FontStyle.Bold)
        btnDecrease.ForeColor = Color.White
        btnDecrease.HoverState.FillColor = Color.FromArgb(CByte(21), CByte(118), CByte(92))
        btnDecrease.Location = New Point(25, 20)
        btnDecrease.Name = "btnDecrease"
        btnDecrease.PressedDepth = 10
        btnDecrease.ShadowDecoration.BorderRadius = 12
        btnDecrease.ShadowDecoration.Color = Color.FromArgb(CByte(31), CByte(138), CByte(112))
        btnDecrease.ShadowDecoration.Depth = 10
        btnDecrease.ShadowDecoration.Enabled = True
        btnDecrease.ShadowDecoration.Shadow = New Padding(0, 2, 3, 3)
        btnDecrease.Size = New Size(80, 80)
        btnDecrease.TabIndex = 0
        btnDecrease.Text = "−"
        btnDecrease.UseTransparentBackground = True

        ' 
        ' lblQuantity
        ' 
        lblQuantity.Anchor = AnchorStyles.None
        lblQuantity.BackColor = Color.Transparent
        lblQuantity.Font = New Font("Segoe UI", 56.0F, FontStyle.Bold)
        lblQuantity.ForeColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        lblQuantity.Location = New Point(105, 0)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(210, 120)
        lblQuantity.TabIndex = 1
        lblQuantity.Text = "1"
        lblQuantity.TextAlign = ContentAlignment.MiddleCenter

        ' 
        ' btnIncrease
        ' 
        btnIncrease.Anchor = AnchorStyles.None
        btnIncrease.Animated = True
        btnIncrease.BackColor = Color.Transparent
        btnIncrease.BorderRadius = 12
        btnIncrease.DisabledState.BorderColor = Color.DarkGray
        btnIncrease.DisabledState.CustomBorderColor = Color.DarkGray
        btnIncrease.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnIncrease.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnIncrease.FillColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        btnIncrease.Font = New Font("Segoe UI", 32.0F, FontStyle.Bold)
        btnIncrease.ForeColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        btnIncrease.HoverState.FillColor = Color.FromArgb(CByte(240), CByte(180), CByte(67))
        btnIncrease.Location = New Point(315, 20)
        btnIncrease.Name = "btnIncrease"
        btnIncrease.PressedDepth = 10
        btnIncrease.ShadowDecoration.BorderRadius = 12
        btnIncrease.ShadowDecoration.Color = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        btnIncrease.ShadowDecoration.Depth = 10
        btnIncrease.ShadowDecoration.Enabled = True
        btnIncrease.ShadowDecoration.Shadow = New Padding(0, 2, 3, 3)
        btnIncrease.Size = New Size(80, 80)
        btnIncrease.TabIndex = 2
        btnIncrease.Text = "+"
        btnIncrease.UseTransparentBackground = True

        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Transparent
        pnlHeader.BorderRadius = 20
        pnlHeader.Controls.Add(lblItemName)
        pnlHeader.Controls.Add(lblPrice)
        pnlHeader.CustomizableEdges.BottomLeft = False
        pnlHeader.CustomizableEdges.BottomRight = False
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.FillColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(30, 20, 30, 20)
        pnlHeader.ShadowDecoration.BorderRadius = 20
        pnlHeader.ShadowDecoration.Depth = 5
        pnlHeader.ShadowDecoration.Enabled = False
        pnlHeader.Size = New Size(520, 120)
        pnlHeader.TabIndex = 1

        ' 
        ' lblItemName
        ' 
        lblItemName.BackColor = Color.Transparent
        lblItemName.Dock = DockStyle.Top
        lblItemName.Font = New Font("Segoe UI", 22.0F, FontStyle.Bold)
        lblItemName.ForeColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        lblItemName.Location = New Point(30, 20)
        lblItemName.Name = "lblItemName"
        lblItemName.Size = New Size(460, 50)
        lblItemName.TabIndex = 0
        lblItemName.Text = "Item"
        lblItemName.TextAlign = ContentAlignment.MiddleLeft

        ' 
        ' lblPrice
        ' 
        lblPrice.BackColor = Color.Transparent
        lblPrice.Dock = DockStyle.Bottom
        lblPrice.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold)
        lblPrice.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblPrice.Location = New Point(30, 70)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(460, 30)
        lblPrice.TabIndex = 1
        lblPrice.Text = "₱0.00 per item"
        lblPrice.TextAlign = ContentAlignment.MiddleLeft

        ' 
        ' pnlActions
        ' 
        pnlActions.BackColor = Color.Transparent
        pnlActions.Controls.Add(btnAdd)
        pnlActions.Controls.Add(btnCancel)
        pnlActions.Dock = DockStyle.Bottom
        pnlActions.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(249))
        pnlActions.Location = New Point(0, 490)
        pnlActions.Name = "pnlActions"
        pnlActions.Padding = New Padding(25, 15, 25, 25)
        pnlActions.Size = New Size(520, 110)
        pnlActions.TabIndex = 2

        ' 
        ' btnAdd
        ' 
        btnAdd.Animated = True
        btnAdd.BackColor = Color.Transparent
        btnAdd.BorderRadius = 12
        btnAdd.DisabledState.BorderColor = Color.DarkGray
        btnAdd.DisabledState.CustomBorderColor = Color.DarkGray
        btnAdd.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnAdd.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnAdd.Dock = DockStyle.Fill
        btnAdd.FillColor = Color.FromArgb(CByte(31), CByte(138), CByte(112))
        btnAdd.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.HoverState.FillColor = Color.FromArgb(CByte(21), CByte(118), CByte(92))
        btnAdd.Location = New Point(25, 15)
        btnAdd.Name = "btnAdd"
        btnAdd.PressedDepth = 15
        btnAdd.ShadowDecoration.BorderRadius = 12
        btnAdd.ShadowDecoration.Color = Color.FromArgb(CByte(31), CByte(138), CByte(112))
        btnAdd.ShadowDecoration.Depth = 12
        btnAdd.ShadowDecoration.Enabled = True
        btnAdd.ShadowDecoration.Shadow = New Padding(0, 3, 4, 4)
        btnAdd.Size = New Size(320, 70)
        btnAdd.TabIndex = 0
        btnAdd.Text = "Add to Order"

        ' 
        ' btnCancel
        ' 
        btnCancel.Animated = True
        btnCancel.BackColor = Color.Transparent
        btnCancel.BorderColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        btnCancel.BorderRadius = 12
        btnCancel.BorderThickness = 2
        btnCancel.DisabledState.BorderColor = Color.DarkGray
        btnCancel.DisabledState.CustomBorderColor = Color.DarkGray
        btnCancel.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnCancel.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnCancel.Dock = DockStyle.Right
        btnCancel.FillColor = Color.White
        btnCancel.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnCancel.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        btnCancel.HoverState.BorderColor = Color.FromArgb(CByte(220), CByte(38), CByte(38))
        btnCancel.HoverState.FillColor = Color.FromArgb(CByte(254), CByte(226), CByte(226))
        btnCancel.HoverState.ForeColor = Color.FromArgb(CByte(220), CByte(38), CByte(38))
        btnCancel.Location = New Point(345, 15)
        btnCancel.Name = "btnCancel"
        btnCancel.PressedDepth = 10
        btnCancel.ShadowDecoration.BorderRadius = 12
        btnCancel.ShadowDecoration.Depth = 6
        btnCancel.ShadowDecoration.Enabled = True
        btnCancel.ShadowDecoration.Shadow = New Padding(0, 2, 2, 2)
        btnCancel.Size = New Size(150, 70)
        btnCancel.TabIndex = 1
        btnCancel.Text = "Cancel"

        ' 
        ' ItemDialogForm
        ' 
        ClientSize = New Size(520, 600)
        Controls.Add(pnlMain)
        FormBorderStyle = FormBorderStyle.None
        Name = "ItemDialogForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Add Item"

        pnlMain.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlSummary.ResumeLayout(False)
        pnlSummary.PerformLayout()
        pnlQuantity.ResumeLayout(False)
        pnlQuantityControls.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlActions.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
End Class