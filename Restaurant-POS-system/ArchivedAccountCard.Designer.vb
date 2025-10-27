<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ArchivedAccountCard
    Inherits System.Windows.Forms.UserControl

    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents btnRestore As Button
    Friend WithEvents btnDeletePermanent As Button

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
        lblUsername = New Label()
        lblRole = New Label()
        lblDate = New Label()
        btnRestore = New Button()
        btnDeletePermanent = New Button()
        pnlMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.White
        pnlMain.BorderStyle = BorderStyle.FixedSingle
        pnlMain.Controls.Add(lblUsername)
        pnlMain.Controls.Add(lblRole)
        pnlMain.Controls.Add(lblDate)
        pnlMain.Controls.Add(btnRestore)
        pnlMain.Controls.Add(btnDeletePermanent)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Padding = New Padding(10)
        pnlMain.Size = New Size(600, 80)
        ' 
        ' lblUsername
        ' 
        lblUsername.Font = New Font("Segoe UI Semibold", 11, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(45, 45, 48)
        lblUsername.Location = New Point(10, 8)
        lblUsername.AutoSize = True
        lblUsername.Text = "Username: user"
        ' 
        ' lblRole
        ' 
        lblRole.Font = New Font("Segoe UI", 10)
        lblRole.ForeColor = Color.Gray
        lblRole.Location = New Point(10, 30)
        lblRole.AutoSize = True
        lblRole.Text = "Role: cashier"
        ' 
        ' lblDate
        ' 
        lblDate.Font = New Font("Segoe UI", 9)
        lblDate.ForeColor = Color.Gray
        lblDate.Location = New Point(10, 50)
        lblDate.AutoSize = True
        lblDate.Text = "Archived: 2025-10-22"
        ' 
        ' btnRestore
        ' 
        btnRestore.Text = "Restore"
        btnRestore.BackColor = Color.FromArgb(16, 185, 129)
        btnRestore.ForeColor = Color.White
        btnRestore.FlatStyle = FlatStyle.Flat
        btnRestore.FlatAppearance.BorderSize = 0
        btnRestore.Size = New Size(90, 30)
        btnRestore.Location = New Point(400, 25)
        ' 
        ' btnDeletePermanent
        ' 
        btnDeletePermanent.Text = "Delete"
        btnDeletePermanent.BackColor = Color.FromArgb(239, 68, 68)
        btnDeletePermanent.ForeColor = Color.White
        btnDeletePermanent.FlatStyle = FlatStyle.Flat
        btnDeletePermanent.FlatAppearance.BorderSize = 0
        btnDeletePermanent.Size = New Size(90, 30)
        btnDeletePermanent.Location = New Point(500, 25)
        ' 
        ' ArchivedAccountCard
        ' 
        Controls.Add(pnlMain)
        Name = "ArchivedAccountCard"
        Size = New Size(600, 80)
        pnlMain.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
End Class