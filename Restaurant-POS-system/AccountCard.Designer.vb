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
        Me.pnlMain = New Panel()
        Me.btnArchive = New Button()
        Me.btnDelete = New Button()
        Me.btnEdit = New Button()
        Me.lblDate = New Label()
        Me.lblRole = New Label()
        Me.lblUsername = New Label()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        ' pnlMain
        '
        Me.pnlMain.BackColor = Color.White
        Me.pnlMain.BorderStyle = BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.btnArchive)
        Me.pnlMain.Controls.Add(Me.btnDelete)
        Me.pnlMain.Controls.Add(Me.btnEdit)
        Me.pnlMain.Controls.Add(Me.lblDate)
        Me.pnlMain.Controls.Add(Me.lblRole)
        Me.pnlMain.Controls.Add(Me.lblUsername)
        Me.pnlMain.Dock = DockStyle.Fill
        Me.pnlMain.Location = New Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New Size(500, 80)
        Me.pnlMain.TabIndex = 0
        '
        ' btnArchive
        '
        Me.btnArchive.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Me.btnArchive.BackColor = Color.LightGoldenrodYellow
        Me.btnArchive.FlatStyle = FlatStyle.Flat
        Me.btnArchive.Location = New Point(390, 25)
        Me.btnArchive.Name = "btnArchive"
        Me.btnArchive.Size = New Size(75, 30)
        Me.btnArchive.TabIndex = 5
        Me.btnArchive.Text = "Archive"
        Me.btnArchive.UseVisualStyleBackColor = False
        '
        ' btnDelete
        '
        Me.btnDelete.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Me.btnDelete.BackColor = Color.LightCoral
        Me.btnDelete.FlatStyle = FlatStyle.Flat
        Me.btnDelete.Location = New Point(310, 25)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New Size(75, 30)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        ' btnEdit
        '
        Me.btnEdit.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Me.btnEdit.BackColor = Color.LightBlue
        Me.btnEdit.FlatStyle = FlatStyle.Flat
        Me.btnEdit.Location = New Point(230, 25)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New Size(75, 30)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        ' lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New Font("Segoe UI", 8.0F)
        Me.lblDate.ForeColor = Color.DimGray
        Me.lblDate.Location = New Point(10, 45)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New Size(140, 19)
        Me.lblDate.TabIndex = 2
        Me.lblDate.Text = "Created: 0000-00-00"
        '
        ' lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Font = New Font("Segoe UI", 9.0F)
        Me.lblRole.Location = New Point(10, 30)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New Size(40, 20)
        Me.lblRole.TabIndex = 1
        Me.lblRole.Text = "Role:"
        '
        ' lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Me.lblUsername.Location = New Point(10, 8)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New Size(135, 25)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username: x"
        '
        ' AccountCard
        '
        Me.AutoScaleMode = AutoScaleMode.None
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "AccountCard"
        Me.Size = New Size(500, 80)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
End Class