Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

Partial Public Class PremiumAccountCard
    Inherits UserControl

    ' NOTE: In a real Visual Studio project, this file would be auto-generated and hidden.

    Private components As System.ComponentModel.IContainer

    ' Control declarations (shared with the main partial class file)
    Private mainCard As Guna2ShadowPanel
    Private headerPanel As Panel
    Private avatarCircle As Guna2CircleButton
    Private lblUsername As Label
    Private lblRole As Label ' Not used in logic, but often present in designer files. Keeping for completeness.
    Private lblDate As Label
    Private actionPanel As Panel
    Private WithEvents btnEdit As Guna2Button
    Private WithEvents btnDelete As Guna2Button
    Private WithEvents btnArchive As Guna2Button
    Private roleBadge As Guna2Chip


    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If

            If disposing Then
                ' Explicitly dispose of controls created in InitializeComponent
                If mainCard IsNot Nothing Then mainCard.Dispose()
                ' Dispose child controls within mainCard if not automatically handled
                If headerPanel IsNot Nothing Then headerPanel.Dispose()
                If avatarCircle IsNot Nothing Then avatarCircle.Dispose()
                If lblUsername IsNot Nothing Then lblUsername.Dispose()
                If lblRole IsNot Nothing Then lblRole.Dispose()
                If lblDate IsNot Nothing Then lblDate.Dispose()
                If actionPanel IsNot Nothing Then actionPanel.Dispose()
                If btnEdit IsNot Nothing Then btnEdit.Dispose()
                If btnDelete IsNot Nothing Then btnDelete.Dispose()
                If btnArchive IsNot Nothing Then btnArchive.Dispose()
                If roleBadge IsNot Nothing Then roleBadge.Dispose()
            End If

        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        mainCard = New Guna2ShadowPanel()
        headerPanel = New Panel()
        avatarCircle = New Guna2CircleButton()
        lblUsername = New Label()
        roleBadge = New Guna2Chip()
        lblDate = New Label()
        actionPanel = New Panel()
        btnEdit = New Guna2Button()
        btnDelete = New Guna2Button()
        btnArchive = New Guna2Button()
        mainCard.SuspendLayout()
        headerPanel.SuspendLayout()
        actionPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' mainCard
        ' 
        mainCard.BackColor = Color.Transparent
        mainCard.Controls.Add(headerPanel)
        mainCard.Controls.Add(actionPanel)
        mainCard.Dock = DockStyle.Fill
        mainCard.FillColor = Color.White
        mainCard.Location = New Point(0, 0)
        mainCard.Name = "mainCard"
        mainCard.Padding = New Padding(25, 20, 25, 20)
        mainCard.Radius = 18
        mainCard.ShadowColor = Color.Black
        mainCard.ShadowDepth = 12
        mainCard.ShadowShift = 4
        mainCard.Size = New Size(757, 160)
        mainCard.TabIndex = 0
        ' 
        ' headerPanel
        ' 
        headerPanel.BackColor = Color.Transparent
        headerPanel.Controls.Add(avatarCircle)
        headerPanel.Controls.Add(lblUsername)
        headerPanel.Controls.Add(roleBadge)
        headerPanel.Controls.Add(lblDate)
        headerPanel.Dock = DockStyle.Top
        headerPanel.Location = New Point(25, 20)
        headerPanel.Name = "headerPanel"
        headerPanel.Size = New Size(707, 65)
        headerPanel.TabIndex = 0
        ' 
        ' avatarCircle
        ' 
        avatarCircle.FillColor = Color.FromArgb(CByte(251), CByte(191), CByte(36))
        avatarCircle.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        avatarCircle.ForeColor = Color.White
        avatarCircle.Location = New Point(0, 0)
        avatarCircle.Name = "avatarCircle"
        avatarCircle.ShadowDecoration.Color = Color.FromArgb(CByte(80), CByte(251), CByte(191), CByte(36))
        avatarCircle.ShadowDecoration.CustomizableEdges = CustomizableEdges1
        avatarCircle.ShadowDecoration.Depth = 10
        avatarCircle.ShadowDecoration.Enabled = True
        avatarCircle.ShadowDecoration.Mode = Enums.ShadowMode.Circle
        avatarCircle.Size = New Size(60, 60)
        avatarCircle.TabIndex = 0
        avatarCircle.Text = "👤"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.BackColor = Color.Transparent
        lblUsername.Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblUsername.Location = New Point(75, 8)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(133, 35)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Username"
        ' 
        ' roleBadge
        ' 
        roleBadge.BackColor = Color.Transparent
        roleBadge.BorderRadius = 8
        roleBadge.CustomizableEdges = CustomizableEdges2
        roleBadge.FillColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        roleBadge.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        roleBadge.ForeColor = Color.White
        roleBadge.Location = New Point(75, 38)
        roleBadge.Name = "roleBadge"
        roleBadge.ShadowDecoration.CustomizableEdges = CustomizableEdges3
        roleBadge.ShadowDecoration.Depth = 5
        roleBadge.ShadowDecoration.Enabled = True
        roleBadge.Size = New Size(100, 30)
        roleBadge.TabIndex = 2
        roleBadge.Text = "Admin"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.BackColor = Color.Transparent
        lblDate.Font = New Font("Segoe UI", 9.5F)
        lblDate.ForeColor = Color.FromArgb(CByte(107), CByte(114), CByte(128))
        lblDate.Location = New Point(190, 43)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(155, 21)
        lblDate.TabIndex = 3
        lblDate.Text = "Created: 2025-10-28"
        ' 
        ' actionPanel
        ' 
        actionPanel.BackColor = Color.Transparent
        actionPanel.Controls.Add(btnEdit)
        actionPanel.Controls.Add(btnDelete)
        actionPanel.Controls.Add(btnArchive)
        actionPanel.Dock = DockStyle.Bottom
        actionPanel.Location = New Point(25, 85)
        actionPanel.Name = "actionPanel"
        actionPanel.Padding = New Padding(0, 10, 0, 0)
        actionPanel.Size = New Size(707, 55)
        actionPanel.TabIndex = 1
        ' 
        ' btnEdit
        ' 
        btnEdit.Animated = True
        btnEdit.BackColor = Color.Transparent
        btnEdit.BorderRadius = 12
        btnEdit.Cursor = Cursors.Hand
        btnEdit.CustomizableEdges = CustomizableEdges4
        btnEdit.FillColor = Color.FromArgb(CByte(251), CByte(191), CByte(36))
        btnEdit.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnEdit.ForeColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        btnEdit.HoverState.FillColor = Color.FromArgb(CByte(240), CByte(180), CByte(67))
        btnEdit.Location = New Point(340, 5)
        btnEdit.Name = "btnEdit"
        btnEdit.ShadowDecoration.Color = Color.FromArgb(CByte(60), CByte(251), CByte(191), CByte(36))
        btnEdit.ShadowDecoration.CustomizableEdges = CustomizableEdges5
        btnEdit.ShadowDecoration.Depth = 8
        btnEdit.ShadowDecoration.Enabled = True
        btnEdit.Size = New Size(110, 45)
        btnEdit.TabIndex = 0
        btnEdit.Text = "✏️ Edit"
        ' 
        ' btnDelete
        ' 
        btnDelete.Animated = True
        btnDelete.BackColor = Color.Transparent
        btnDelete.BorderRadius = 12
        btnDelete.Cursor = Cursors.Hand
        btnDelete.CustomizableEdges = CustomizableEdges6
        btnDelete.FillColor = Color.FromArgb(CByte(239), CByte(68), CByte(68))
        btnDelete.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.HoverState.FillColor = Color.FromArgb(CByte(220), CByte(50), CByte(50))
        btnDelete.Location = New Point(460, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.ShadowDecoration.Color = Color.FromArgb(CByte(60), CByte(239), CByte(68), CByte(68))
        btnDelete.ShadowDecoration.CustomizableEdges = CustomizableEdges7
        btnDelete.ShadowDecoration.Depth = 8
        btnDelete.ShadowDecoration.Enabled = True
        btnDelete.Size = New Size(114, 45)
        btnDelete.TabIndex = 1
        btnDelete.Text = "🗑️ Delete"
        ' 
        ' btnArchive
        ' 
        btnArchive.Animated = True
        btnArchive.BackColor = Color.Transparent
        btnArchive.BorderRadius = 12
        btnArchive.Cursor = Cursors.Hand
        btnArchive.CustomizableEdges = CustomizableEdges8
        btnArchive.FillColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        btnArchive.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnArchive.ForeColor = Color.White
        btnArchive.HoverState.FillColor = Color.FromArgb(CByte(225), CByte(138), CByte(0))
        btnArchive.Location = New Point(580, 5)
        btnArchive.Name = "btnArchive"
        btnArchive.ShadowDecoration.Color = Color.FromArgb(CByte(60), CByte(245), CByte(158), CByte(11))
        btnArchive.ShadowDecoration.CustomizableEdges = CustomizableEdges9
        btnArchive.ShadowDecoration.Depth = 8
        btnArchive.ShadowDecoration.Enabled = True
        btnArchive.Size = New Size(120, 45)
        btnArchive.TabIndex = 2
        btnArchive.Text = "📦 Archive"
        ' 
        ' PremiumAccountCard
        ' 
        BackColor = Color.Transparent
        Controls.Add(mainCard)
        Margin = New Padding(15, 10, 15, 10)
        Name = "PremiumAccountCard"
        Size = New Size(757, 160)
        mainCard.ResumeLayout(False)
        headerPanel.ResumeLayout(False)
        headerPanel.PerformLayout()
        actionPanel.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

End Class