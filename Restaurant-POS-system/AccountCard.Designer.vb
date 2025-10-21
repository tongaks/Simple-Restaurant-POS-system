<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AccountCard
    Inherits System.Windows.Forms.UserControl

    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnArchive As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlActions As Panel

    <System.Diagnostics.DebuggerNonUserCode()>
    Private Sub InitializeComponent()
        pnlMain = New Panel()
        pnlActions = New Panel()
        btnArchive = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        lblDate = New Label()
        lblRole = New Label()
        pnlHeader = New Panel()
        lblUsername = New Label()
        pnlMain.SuspendLayout()
        pnlActions.SuspendLayout()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.White
        pnlMain.Controls.Add(pnlActions)
        pnlMain.Controls.Add(lblDate)
        pnlMain.Controls.Add(lblRole)
        pnlMain.Controls.Add(pnlHeader)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 0)
        pnlMain.Margin = New Padding(10)
        pnlMain.Name = "pnlMain"
        pnlMain.Padding = New Padding(20, 15, 20, 15)
        pnlMain.Size = New Size(600, 120)
        pnlMain.TabIndex = 0
        ' 
        ' pnlActions
        ' 
        pnlActions.Controls.Add(btnArchive)
        pnlActions.Controls.Add(btnDelete)
        pnlActions.Controls.Add(btnEdit)
        pnlActions.Dock = DockStyle.Right
        pnlActions.Location = New Point(310, 60)
        pnlActions.Name = "pnlActions"
        pnlActions.Size = New Size(270, 45)
        pnlActions.TabIndex = 5
        ' 
        ' btnArchive
        ' 
        btnArchive.BackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        btnArchive.Cursor = Cursors.Hand
        btnArchive.FlatAppearance.BorderSize = 0
        btnArchive.FlatStyle = FlatStyle.Flat
        btnArchive.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
        btnArchive.ForeColor = Color.White
        btnArchive.Location = New Point(180, 5)
        btnArchive.Name = "btnArchive"
        btnArchive.Size = New Size(85, 35)
        btnArchive.TabIndex = 5
        btnArchive.Text = "Archive"
        btnArchive.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnDelete.Cursor = Cursors.Hand
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(90, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(80, 35)
        btnDelete.TabIndex = 4
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnEdit.Cursor = Cursors.Hand
        btnEdit.FlatAppearance.BorderSize = 0
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
        btnEdit.ForeColor = Color.White
        btnEdit.Location = New Point(0, 5)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(80, 35)
        btnEdit.TabIndex = 3
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Font = New Font("Segoe UI", 9F)
        lblDate.ForeColor = Color.Gray
        lblDate.Location = New Point(35, 93)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(144, 20)
        lblDate.TabIndex = 2
        lblDate.Text = "Created: 0000-00-00"
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New Font("Segoe UI", 10F)
        lblRole.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblRole.Location = New Point(35, 70)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(47, 23)
        lblRole.TabIndex = 1
        lblRole.Text = "Role:"
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(72), CByte(118), CByte(255))
        pnlHeader.Controls.Add(lblUsername)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(20, 15)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(15, 10, 15, 10)
        pnlHeader.Size = New Size(560, 45)
        pnlHeader.TabIndex = 0
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Dock = DockStyle.Left
        lblUsername.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblUsername.ForeColor = Color.White
        lblUsername.Location = New Point(15, 10)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(125, 28)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Username: x"
        ' 
        ' AccountCard
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        Controls.Add(pnlMain)
        Margin = New Padding(10)
        Name = "AccountCard"
        Size = New Size(600, 120)
        pnlMain.ResumeLayout(False)
        pnlMain.PerformLayout()
        pnlActions.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub
End Class