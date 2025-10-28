<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AccountCard
    Inherits System.Windows.Forms.UserControl

    Private components As System.ComponentModel.IContainer
    Friend WithEvents mainCard As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnArchive As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlActions As System.Windows.Forms.Panel
    Friend WithEvents lblRoleBadge As Guna.UI2.WinForms.Guna2CircleButton

    <System.Diagnostics.DebuggerNonUserCode()>
    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        mainCard = New Guna.UI2.WinForms.Guna2ShadowPanel()
        pnlActions = New Panel()
        btnArchive = New Guna.UI2.WinForms.Guna2Button()
        btnDelete = New Guna.UI2.WinForms.Guna2Button()
        btnEdit = New Guna.UI2.WinForms.Guna2Button()
        lblDate = New Label()
        lblRole = New Label()
        pnlHeader = New Panel()
        lblRoleBadge = New Guna.UI2.WinForms.Guna2CircleButton()
        lblUsername = New Label()
        mainCard.SuspendLayout()
        pnlActions.SuspendLayout()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' mainCard
        ' 
        mainCard.BackColor = Color.Transparent
        mainCard.Controls.Add(pnlActions)
        mainCard.Controls.Add(lblDate)
        mainCard.Controls.Add(lblRole)
        mainCard.Controls.Add(pnlHeader)
        mainCard.Dock = DockStyle.Fill
        mainCard.FillColor = Color.White
        mainCard.Location = New Point(0, 0)
        mainCard.Margin = New Padding(10)
        mainCard.Name = "mainCard"
        mainCard.Padding = New Padding(20, 15, 20, 15)
        mainCard.Radius = 12
        mainCard.ShadowColor = Color.Black
        mainCard.ShadowDepth = 8
        mainCard.ShadowShift = 3
        mainCard.Size = New Size(650, 140)
        mainCard.TabIndex = 0
        ' 
        ' pnlActions
        ' 
        pnlActions.BackColor = Color.Transparent
        pnlActions.Controls.Add(btnArchive)
        pnlActions.Controls.Add(btnDelete)
        pnlActions.Controls.Add(btnEdit)
        pnlActions.Location = New Point(340, 75)
        pnlActions.Name = "pnlActions"
        pnlActions.Size = New Size(290, 45)
        pnlActions.TabIndex = 5
        ' 
        ' btnArchive
        ' 
        btnArchive.BackColor = Color.Transparent
        btnArchive.BorderRadius = 10
        btnArchive.Cursor = Cursors.Hand
        btnArchive.CustomizableEdges = CustomizableEdges1
        btnArchive.DisabledState.BorderColor = Color.DarkGray
        btnArchive.DisabledState.CustomBorderColor = Color.DarkGray
        btnArchive.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnArchive.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnArchive.FillColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        btnArchive.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
        btnArchive.ForeColor = Color.White
        btnArchive.Location = New Point(190, 5)
        btnArchive.Name = "btnArchive"
        btnArchive.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnArchive.ShadowDecoration.Enabled = True
        btnArchive.Size = New Size(95, 38)
        btnArchive.TabIndex = 2
        btnArchive.Text = "📦 Archive"
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.BorderRadius = 10
        btnDelete.Cursor = Cursors.Hand
        btnDelete.CustomizableEdges = CustomizableEdges3
        btnDelete.DisabledState.BorderColor = Color.DarkGray
        btnDelete.DisabledState.CustomBorderColor = Color.DarkGray
        btnDelete.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnDelete.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnDelete.FillColor = Color.FromArgb(CByte(220), CByte(38), CByte(38))
        btnDelete.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(95, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnDelete.ShadowDecoration.Enabled = True
        btnDelete.Size = New Size(90, 38)
        btnDelete.TabIndex = 1
        btnDelete.Text = "🗑️ Delete"
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.Transparent
        btnEdit.BorderRadius = 10
        btnEdit.Cursor = Cursors.Hand
        btnEdit.CustomizableEdges = CustomizableEdges5
        btnEdit.DisabledState.BorderColor = Color.DarkGray
        btnEdit.DisabledState.CustomBorderColor = Color.DarkGray
        btnEdit.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnEdit.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnEdit.FillColor = Color.FromArgb(CByte(255), CByte(200), CByte(87))
        btnEdit.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
        btnEdit.ForeColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        btnEdit.Location = New Point(0, 5)
        btnEdit.Name = "btnEdit"
        btnEdit.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnEdit.ShadowDecoration.Enabled = True
        btnEdit.Size = New Size(90, 38)
        btnEdit.TabIndex = 0
        btnEdit.Text = "✏️ Edit"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.BackColor = Color.Transparent
        lblDate.Font = New Font("Segoe UI", 9.0F)
        lblDate.ForeColor = Color.Gray
        lblDate.Location = New Point(85, 100)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(144, 20)
        lblDate.TabIndex = 2
        lblDate.Text = "Created: 0000-00-00"
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.BackColor = Color.Transparent
        lblRole.Font = New Font("Segoe UI", 10.5F)
        lblRole.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblRole.Location = New Point(85, 75)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(50, 25)
        lblRole.TabIndex = 1
        lblRole.Text = "Role:"
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Transparent
        pnlHeader.Controls.Add(lblRoleBadge)
        pnlHeader.Controls.Add(lblUsername)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(20, 15)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(610, 55)
        pnlHeader.TabIndex = 0
        ' 
        ' lblRoleBadge
        ' 
        lblRoleBadge.DisabledState.BorderColor = Color.DarkGray
        lblRoleBadge.DisabledState.CustomBorderColor = Color.DarkGray
        lblRoleBadge.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        lblRoleBadge.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        lblRoleBadge.FillColor = Color.FromArgb(CByte(31), CByte(138), CByte(112))
        lblRoleBadge.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblRoleBadge.ForeColor = Color.White
        lblRoleBadge.Location = New Point(5, 5)
        lblRoleBadge.Name = "lblRoleBadge"
        lblRoleBadge.ShadowDecoration.CustomizableEdges = CustomizableEdges7
        lblRoleBadge.ShadowDecoration.Enabled = True
        lblRoleBadge.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        lblRoleBadge.Size = New Size(55, 55)
        lblRoleBadge.TabIndex = 1
        lblRoleBadge.Text = "👤"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI Semibold", 14.0F, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        lblUsername.Location = New Point(70, 15)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(124, 32)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Username"
        ' 
        ' AccountCard
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.Transparent
        Controls.Add(mainCard)
        Margin = New Padding(10)
        Name = "AccountCard"
        Size = New Size(650, 140)
        mainCard.ResumeLayout(False)
        mainCard.PerformLayout()
        pnlActions.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
End Class