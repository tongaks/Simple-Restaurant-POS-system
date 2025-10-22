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

    <System.Diagnostics.DebuggerNonUserCode()>
    Private Sub InitializeComponent()
        pnlMain = New Panel()
        btnArchive = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        lblDate = New Label()
        lblRole = New Label()
        lblUsername = New Label()
        pnlMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.White
        pnlMain.BorderStyle = BorderStyle.FixedSingle
        pnlMain.Controls.Add(btnArchive)
        pnlMain.Controls.Add(btnDelete)
        pnlMain.Controls.Add(btnEdit)
        pnlMain.Controls.Add(lblDate)
        pnlMain.Controls.Add(lblRole)
        pnlMain.Controls.Add(lblUsername)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(500, 80)
        pnlMain.TabIndex = 0
        ' 
        ' btnArchive
        ' 
        btnArchive.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnArchive.BackColor = Color.LightGoldenrodYellow
        btnArchive.FlatStyle = FlatStyle.Flat
        btnArchive.Location = New Point(390, 25)
        btnArchive.Name = "btnArchive"
        btnArchive.Size = New Size(75, 30)
        btnArchive.TabIndex = 5
        btnArchive.Text = "Archive"
        btnArchive.UseVisualStyleBackColor = False
        btnArchive.Visible = False
        ' 
        ' btnDelete
        ' 
        btnDelete.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDelete.BackColor = Color.LightCoral
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Location = New Point(310, 25)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 30)
        btnDelete.TabIndex = 4
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEdit.BackColor = Color.LightBlue
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.Location = New Point(230, 25)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(75, 30)
        btnEdit.TabIndex = 3
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Font = New Font("Segoe UI", 8F)
        lblDate.ForeColor = Color.DimGray
        lblDate.Location = New Point(10, 45)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(109, 13)
        lblDate.TabIndex = 2
        lblDate.Text = "Created: 0000-00-00"
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New Font("Segoe UI", 9F)
        lblRole.Location = New Point(10, 30)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(33, 15)
        lblRole.TabIndex = 1
        lblRole.Text = "Role:"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        lblUsername.Location = New Point(10, 8)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(96, 20)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Username: x"
        ' 
        ' AccountCard
        ' 
        AutoScaleMode = AutoScaleMode.None
        Controls.Add(pnlMain)
        Name = "AccountCard"
        Size = New Size(500, 80)
        pnlMain.ResumeLayout(False)
        pnlMain.PerformLayout()
        ResumeLayout(False)
    End Sub
End Class