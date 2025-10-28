<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ArchivedAccountCard
    Inherits System.Windows.Forms.UserControl

    Private components As System.ComponentModel.IContainer

    ' NOTE: Control declarations updated to match Guna style and component types
    Friend WithEvents mainCard As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents headerPanel As Panel ' New Structural Panel
    Friend WithEvents avatarCircle As Guna.UI2.WinForms.Guna2CircleButton ' New Guna Component
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblRole As Label ' Kept for compatibility but role display is handled by roleBadge
    Friend WithEvents lblDate As Label
    Friend WithEvents actionPanel As Panel ' New Structural Panel
    Friend WithEvents roleBadge As Guna.UI2.WinForms.Guna2Chip ' New Guna Component
    Friend WithEvents btnRestore As Guna.UI2.WinForms.Guna2Button ' Changed type to Guna2Button
    Friend WithEvents btnDeletePermanent As Guna.UI2.WinForms.Guna2Button ' Changed type to Guna2Button

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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        mainCard = New Guna.UI2.WinForms.Guna2ShadowPanel()
        actionPanel = New Panel()
        btnDeletePermanent = New Guna.UI2.WinForms.Guna2Button()
        btnRestore = New Guna.UI2.WinForms.Guna2Button()
        headerPanel = New Panel()
        lblDate = New Label()
        lblRole = New Label()
        lblUsername = New Label()
        roleBadge = New Guna.UI2.WinForms.Guna2Chip()
        avatarCircle = New Guna.UI2.WinForms.Guna2CircleButton()
        mainCard.SuspendLayout()
        actionPanel.SuspendLayout()
        headerPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' mainCard
        ' 
        mainCard.BackColor = Color.Transparent
        mainCard.Controls.Add(actionPanel)
        mainCard.Controls.Add(headerPanel)
        mainCard.FillColor = Color.White
        mainCard.Location = New Point(0, 0)
        mainCard.Name = "mainCard"
        mainCard.Radius = 16
        mainCard.ShadowColor = Color.Black
        mainCard.ShadowDepth = 12
        mainCard.ShadowShift = 3
        mainCard.Size = New Size(590, 93)
        mainCard.TabIndex = 0
        ' 
        ' actionPanel
        ' 
        actionPanel.Controls.Add(btnDeletePermanent)
        actionPanel.Controls.Add(btnRestore)
        actionPanel.Dock = DockStyle.Fill
        actionPanel.Location = New Point(310, 0)
        actionPanel.Name = "actionPanel"
        actionPanel.Size = New Size(280, 93)
        actionPanel.TabIndex = 1
        ' 
        ' btnDeletePermanent
        ' 
        btnDeletePermanent.Animated = True
        btnDeletePermanent.BorderRadius = 12
        btnDeletePermanent.CustomizableEdges = CustomizableEdges1
        btnDeletePermanent.FillColor = Color.FromArgb(CByte(239), CByte(68), CByte(68))
        btnDeletePermanent.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnDeletePermanent.ForeColor = Color.White
        btnDeletePermanent.HoverState.FillColor = Color.FromArgb(CByte(200), CByte(48), CByte(48))
        btnDeletePermanent.Location = New Point(137, 18)
        btnDeletePermanent.Margin = New Padding(3, 2, 3, 2)
        btnDeletePermanent.Name = "btnDeletePermanent"
        btnDeletePermanent.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnDeletePermanent.Size = New Size(118, 45)
        btnDeletePermanent.TabIndex = 1
        btnDeletePermanent.Text = "🗑️ Delete"
        ' 
        ' btnRestore
        ' 
        btnRestore.Animated = True
        btnRestore.BorderRadius = 12
        btnRestore.CustomizableEdges = CustomizableEdges3
        btnRestore.FillColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        btnRestore.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnRestore.ForeColor = Color.White
        btnRestore.HoverState.FillColor = Color.FromArgb(CByte(10), CByte(155), CByte(100))
        btnRestore.Location = New Point(10, 18)
        btnRestore.Margin = New Padding(3, 2, 3, 2)
        btnRestore.Name = "btnRestore"
        btnRestore.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnRestore.Size = New Size(121, 45)
        btnRestore.TabIndex = 0
        btnRestore.Text = "🔄 Restore"
        ' 
        ' headerPanel
        ' 
        headerPanel.Controls.Add(lblDate)
        headerPanel.Controls.Add(lblRole)
        headerPanel.Controls.Add(lblUsername)
        headerPanel.Controls.Add(roleBadge)
        headerPanel.Controls.Add(avatarCircle)
        headerPanel.Dock = DockStyle.Left
        headerPanel.Location = New Point(0, 0)
        headerPanel.Name = "headerPanel"
        headerPanel.Padding = New Padding(15, 0, 0, 0)
        headerPanel.Size = New Size(310, 93)
        headerPanel.TabIndex = 0
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDate.ForeColor = Color.DimGray
        lblDate.Location = New Point(80, 62)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(166, 20)
        lblDate.TabIndex = 4
        lblDate.Text = "Archived: YYYY-MM-DD"
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRole.ForeColor = Color.Gray
        lblRole.Location = New Point(80, 38)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(42, 20)
        lblRole.TabIndex = 3
        lblRole.Text = "Role:"
        lblRole.Visible = False
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblUsername.Location = New Point(80, 10)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(104, 28)
        lblUsername.TabIndex = 2
        lblUsername.Text = "username"
        ' 
        ' roleBadge
        ' 
        roleBadge.CustomizableEdges = CustomizableEdges5
        roleBadge.DefaultAutoSize = True
        roleBadge.FillColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        roleBadge.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        roleBadge.ForeColor = Color.White
        roleBadge.Location = New Point(190, 10)
        roleBadge.Margin = New Padding(0)
        roleBadge.Name = "roleBadge"
        roleBadge.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        roleBadge.Size = New Size(93, 32)
        roleBadge.TabIndex = 5
        roleBadge.Text = "ROLE"
        ' 
        ' avatarCircle
        ' 
        avatarCircle.Animated = True
        avatarCircle.BorderColor = SystemColors.WindowText
        avatarCircle.DisabledState.BorderColor = Color.DarkGray
        avatarCircle.DisabledState.CustomBorderColor = Color.DarkGray
        avatarCircle.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        avatarCircle.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        avatarCircle.FillColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        avatarCircle.Font = New Font("Segoe UI", 18.0F)
        avatarCircle.ForeColor = Color.White
        avatarCircle.Location = New Point(15, 15)
        avatarCircle.Name = "avatarCircle"
        avatarCircle.PressedColor = Color.Brown
        avatarCircle.ShadowDecoration.CustomizableEdges = CustomizableEdges7
        avatarCircle.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        avatarCircle.Size = New Size(59, 50)
        avatarCircle.TabIndex = 0
        avatarCircle.Text = "👤"
        avatarCircle.TextOffset = New Point(2, 0)
        ' 
        ' ArchivedAccountCard
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.Transparent
        Controls.Add(mainCard)
        Name = "ArchivedAccountCard"
        Size = New Size(618, 97)
        mainCard.ResumeLayout(False)
        actionPanel.ResumeLayout(False)
        headerPanel.ResumeLayout(False)
        headerPanel.PerformLayout()
        ResumeLayout(False)

    End Sub

End Class