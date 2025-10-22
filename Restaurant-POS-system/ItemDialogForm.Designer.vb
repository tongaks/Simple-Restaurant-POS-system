<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ItemDialogForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblItemName As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlQuantity As Panel
    Friend WithEvents btnDecrease As Button
    Friend WithEvents lblQuantity As Label
    Friend WithEvents btnIncrease As Button
    Friend WithEvents pnlSummary As Panel
    Friend WithEvents lblSubtotalLabel As Label
    Friend WithEvents lblSubtotalAmount As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button

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
        pnlMain = New Panel()
        pnlContent = New Panel()
        pnlSummary = New Panel()
        lblSubtotalLabel = New Label()
        lblSubtotalAmount = New Label()
        pnlQuantity = New Panel()
        btnDecrease = New Button()
        lblQuantity = New Label()
        btnIncrease = New Button()
        pnlHeader = New Panel()
        lblItemName = New Label()
        lblPrice = New Label()
        pnlActions = New Panel()
        btnAdd = New Button()
        btnCancel = New Button()
        pnlMain.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlSummary.SuspendLayout()
        pnlQuantity.SuspendLayout()
        pnlHeader.SuspendLayout()
        pnlActions.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.White
        pnlMain.Controls.Add(pnlContent)
        pnlMain.Controls.Add(pnlHeader)
        pnlMain.Controls.Add(pnlActions)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Padding = New Padding(12)
        pnlMain.Size = New Size(480, 520)
        pnlMain.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.Controls.Add(pnlSummary)
        pnlContent.Controls.Add(pnlQuantity)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(12, 112)
        pnlContent.Name = "pnlContent"
        pnlContent.Padding = New Padding(12)
        pnlContent.Size = New Size(456, 316)
        pnlContent.TabIndex = 0
        ' 
        ' pnlSummary
        ' 
        pnlSummary.Controls.Add(lblSubtotalLabel)
        pnlSummary.Controls.Add(lblSubtotalAmount)
        pnlSummary.Dock = DockStyle.Top
        pnlSummary.Location = New Point(12, 152)
        pnlSummary.Name = "pnlSummary"
        pnlSummary.Padding = New Padding(8)
        pnlSummary.Size = New Size(432, 64)
        pnlSummary.TabIndex = 0
        ' 
        ' lblSubtotalLabel
        ' 
        lblSubtotalLabel.AutoSize = True
        lblSubtotalLabel.Dock = DockStyle.Left
        lblSubtotalLabel.Font = New Font("Segoe UI", 11.0F)
        lblSubtotalLabel.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSubtotalLabel.Location = New Point(8, 8)
        lblSubtotalLabel.Name = "lblSubtotalLabel"
        lblSubtotalLabel.Size = New Size(82, 25)
        lblSubtotalLabel.TabIndex = 0
        lblSubtotalLabel.Text = "Subtotal"
        ' 
        ' lblSubtotalAmount
        ' 
        lblSubtotalAmount.Dock = DockStyle.Right
        lblSubtotalAmount.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblSubtotalAmount.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
        lblSubtotalAmount.Location = New Point(324, 8)
        lblSubtotalAmount.Name = "lblSubtotalAmount"
        lblSubtotalAmount.Size = New Size(100, 48)
        lblSubtotalAmount.TabIndex = 1
        lblSubtotalAmount.Text = "₱0.00"
        lblSubtotalAmount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' pnlQuantity
        ' 
        pnlQuantity.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlQuantity.Controls.Add(btnDecrease)
        pnlQuantity.Controls.Add(lblQuantity)
        pnlQuantity.Controls.Add(btnIncrease)
        pnlQuantity.Dock = DockStyle.Top
        pnlQuantity.Location = New Point(12, 12)
        pnlQuantity.Name = "pnlQuantity"
        pnlQuantity.Padding = New Padding(8)
        pnlQuantity.Size = New Size(432, 140)
        pnlQuantity.TabIndex = 1
        ' 
        ' btnDecrease
        ' 
        btnDecrease.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        btnDecrease.FlatAppearance.BorderSize = 0
        btnDecrease.FlatStyle = FlatStyle.Flat
        btnDecrease.Font = New Font("Segoe UI", 28.0F, FontStyle.Bold)
        btnDecrease.Location = New Point(8, 16)
        btnDecrease.Name = "btnDecrease"
        btnDecrease.Size = New Size(96, 96)
        btnDecrease.TabIndex = 0
        btnDecrease.Text = "−"
        btnDecrease.UseVisualStyleBackColor = False
        ' 
        ' lblQuantity
        ' 
        lblQuantity.Font = New Font("Segoe UI", 48.0F, FontStyle.Bold)
        lblQuantity.Location = New Point(112, 16)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(200, 96)
        lblQuantity.TabIndex = 1
        lblQuantity.Text = "1"
        lblQuantity.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnIncrease
        ' 
        btnIncrease.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        btnIncrease.FlatAppearance.BorderSize = 0
        btnIncrease.FlatStyle = FlatStyle.Flat
        btnIncrease.Font = New Font("Segoe UI", 28.0F, FontStyle.Bold)
        btnIncrease.Location = New Point(328, 16)
        btnIncrease.Name = "btnIncrease"
        btnIncrease.Size = New Size(96, 96)
        btnIncrease.TabIndex = 2
        btnIncrease.Text = "+"
        btnIncrease.UseVisualStyleBackColor = False
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        pnlHeader.Controls.Add(lblItemName)
        pnlHeader.Controls.Add(lblPrice)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(12, 12)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(12)
        pnlHeader.Size = New Size(456, 100)
        pnlHeader.TabIndex = 1
        ' 
        ' lblItemName
        ' 
        lblItemName.Dock = DockStyle.Top
        lblItemName.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblItemName.ForeColor = Color.White
        lblItemName.Location = New Point(12, 12)
        lblItemName.Name = "lblItemName"
        lblItemName.Size = New Size(432, 40)
        lblItemName.TabIndex = 0
        lblItemName.Text = "Item"
        ' 
        ' lblPrice
        ' 
        lblPrice.Dock = DockStyle.Bottom
        lblPrice.Font = New Font("Segoe UI", 10.0F)
        lblPrice.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblPrice.Location = New Point(12, 64)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(432, 24)
        lblPrice.TabIndex = 1
        lblPrice.Text = "₱0.00 per item"
        ' 
        ' pnlActions
        ' 
        pnlActions.Controls.Add(btnAdd)
        pnlActions.Controls.Add(btnCancel)
        pnlActions.Dock = DockStyle.Bottom
        pnlActions.Location = New Point(12, 428)
        pnlActions.Name = "pnlActions"
        pnlActions.Padding = New Padding(12)
        pnlActions.Size = New Size(456, 80)
        pnlActions.TabIndex = 2
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        btnAdd.Dock = DockStyle.Fill
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(12, 12)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(312, 56)
        btnAdd.TabIndex = 0
        btnAdd.Text = "Add to Order"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        btnCancel.Dock = DockStyle.Right
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnCancel.Location = New Point(324, 12)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(120, 56)
        btnCancel.TabIndex = 1
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' ItemDialogForm
        ' 
        ClientSize = New Size(480, 520)
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
        pnlHeader.ResumeLayout(False)
        pnlActions.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
End Class