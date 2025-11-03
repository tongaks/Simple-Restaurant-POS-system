<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ArchiveStorage
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnCloseArchive As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtSearchArchive As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pnlArchiveCards As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents TransitionAnimator As Guna.UI2.WinForms.Guna2Transition

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
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim Animation1 As Guna.UI2.AnimatorNS.Animation = New Guna.UI2.AnimatorNS.Animation()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArchiveStorage))
        pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        pnlArchiveCards = New Guna.UI2.WinForms.Guna2Panel()
        txtSearchArchive = New Guna.UI2.WinForms.Guna2TextBox()
        pnlHeader = New Guna.UI2.WinForms.Guna2GradientPanel()
        lblTitle = New Label()
        btnCloseArchive = New Guna.UI2.WinForms.Guna2Button()
        Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(components)
        Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(components)
        Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(components)
        TransitionAnimator = New Guna.UI2.WinForms.Guna2Transition()
        pnlMain.SuspendLayout()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.FromArgb(CByte(247), CByte(250), CByte(252))
        pnlMain.Controls.Add(pnlArchiveCards)
        pnlMain.Controls.Add(txtSearchArchive)
        pnlMain.Controls.Add(pnlHeader)
        pnlMain.CustomizableEdges = CustomizableEdges9
        TransitionAnimator.SetDecoration(pnlMain, Guna.UI2.AnimatorNS.DecorationType.None)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Padding = New Padding(20)
        pnlMain.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        pnlMain.Size = New Size(1000, 700)
        pnlMain.TabIndex = 0
        ' 
        ' pnlArchiveCards
        ' 
        pnlArchiveCards.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlArchiveCards.AutoScroll = True
        pnlArchiveCards.BackColor = Color.Transparent
        pnlArchiveCards.BorderRadius = 20
        pnlArchiveCards.CustomizableEdges = CustomizableEdges1
        TransitionAnimator.SetDecoration(pnlArchiveCards, Guna.UI2.AnimatorNS.DecorationType.None)
        pnlArchiveCards.Location = New Point(20, 200)
        pnlArchiveCards.Name = "pnlArchiveCards"
        pnlArchiveCards.Padding = New Padding(15)
        pnlArchiveCards.ShadowDecoration.BorderRadius = 20
        pnlArchiveCards.ShadowDecoration.Color = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        pnlArchiveCards.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        pnlArchiveCards.ShadowDecoration.Depth = 10
        pnlArchiveCards.ShadowDecoration.Enabled = True
        pnlArchiveCards.ShadowDecoration.Shadow = New Padding(0, 0, 5, 5)
        pnlArchiveCards.Size = New Size(960, 480)
        pnlArchiveCards.TabIndex = 0
        ' 
        ' txtSearchArchive
        ' 
        txtSearchArchive.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSearchArchive.Animated = True
        txtSearchArchive.BackColor = Color.Transparent
        txtSearchArchive.BorderRadius = 15
        txtSearchArchive.Cursor = Cursors.IBeam
        txtSearchArchive.CustomizableEdges = CustomizableEdges3
        TransitionAnimator.SetDecoration(txtSearchArchive, Guna.UI2.AnimatorNS.DecorationType.None)
        txtSearchArchive.DefaultText = ""
        txtSearchArchive.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtSearchArchive.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtSearchArchive.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtSearchArchive.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtSearchArchive.FocusedState.BorderColor = Color.FromArgb(CByte(16), CByte(185), CByte(129))
        txtSearchArchive.Font = New Font("Segoe UI", 11.0F)
        txtSearchArchive.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
        txtSearchArchive.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtSearchArchive.IconLeftOffset = New Point(15, 0)
        txtSearchArchive.IconLeftSize = New Size(22, 22)
        txtSearchArchive.Location = New Point(20, 130)
        txtSearchArchive.Margin = New Padding(4, 6, 4, 6)
        txtSearchArchive.Name = "txtSearchArchive"
        txtSearchArchive.PlaceholderForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        txtSearchArchive.PlaceholderText = "?? Search archived accounts..."
        txtSearchArchive.SelectedText = ""
        txtSearchArchive.ShadowDecoration.BorderRadius = 15
        txtSearchArchive.ShadowDecoration.Color = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        txtSearchArchive.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        txtSearchArchive.ShadowDecoration.Depth = 5
        txtSearchArchive.ShadowDecoration.Enabled = True
        txtSearchArchive.Size = New Size(960, 50)
        txtSearchArchive.TabIndex = 1
        txtSearchArchive.TextOffset = New Point(10, 0)
        ' 
        ' pnlHeader
        ' 
        pnlHeader.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlHeader.BackColor = Color.Transparent
        pnlHeader.BorderRadius = 20
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(btnCloseArchive)
        pnlHeader.CustomizableEdges = CustomizableEdges7
        TransitionAnimator.SetDecoration(pnlHeader, Guna.UI2.AnimatorNS.DecorationType.None)
        pnlHeader.FillColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        pnlHeader.FillColor2 = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        pnlHeader.Location = New Point(20, 20)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(30, 20, 30, 20)
        pnlHeader.ShadowDecoration.BorderRadius = 20
        pnlHeader.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        pnlHeader.ShadowDecoration.Depth = 10
        pnlHeader.ShadowDecoration.Enabled = True
        pnlHeader.Size = New Size(960, 90)
        pnlHeader.TabIndex = 2
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        TransitionAnimator.SetDecoration(lblTitle, Guna.UI2.AnimatorNS.DecorationType.None)
        lblTitle.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(30, 25)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(374, 46)
        lblTitle.TabIndex = 0
        lblTitle.Text = "?? Archived Accounts"
        ' 
        ' btnCloseArchive
        ' 
        btnCloseArchive.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnCloseArchive.Animated = True
        btnCloseArchive.BackColor = Color.Transparent
        btnCloseArchive.BorderRadius = 12
        btnCloseArchive.Cursor = Cursors.Hand
        btnCloseArchive.CustomizableEdges = CustomizableEdges5
        TransitionAnimator.SetDecoration(btnCloseArchive, Guna.UI2.AnimatorNS.DecorationType.None)
        btnCloseArchive.DisabledState.BorderColor = Color.DarkGray
        btnCloseArchive.DisabledState.CustomBorderColor = Color.DarkGray
        btnCloseArchive.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnCloseArchive.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnCloseArchive.FillColor = Color.FromArgb(CByte(239), CByte(68), CByte(68))
        btnCloseArchive.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnCloseArchive.ForeColor = Color.White
        btnCloseArchive.HoverState.FillColor = Color.FromArgb(CByte(220), CByte(38), CByte(38))
        btnCloseArchive.Location = New Point(840, 13)
        btnCloseArchive.Name = "btnCloseArchive"
        btnCloseArchive.ShadowDecoration.BorderRadius = 12
        btnCloseArchive.ShadowDecoration.Color = Color.FromArgb(CByte(239), CByte(68), CByte(68))
        btnCloseArchive.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnCloseArchive.ShadowDecoration.Depth = 8
        btnCloseArchive.ShadowDecoration.Enabled = True
        btnCloseArchive.Size = New Size(101, 52)
        btnCloseArchive.TabIndex = 1
        btnCloseArchive.Text = "? Close"
        ' 
        ' Guna2ShadowForm1
        ' 
        Guna2ShadowForm1.BorderRadius = 20
        Guna2ShadowForm1.ShadowColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        Guna2ShadowForm1.TargetForm = Me
        ' 
        ' Guna2DragControl1
        ' 
        Guna2DragControl1.DockIndicatorTransparencyValue = 0.6R
        Guna2DragControl1.TargetControl = pnlHeader
        Guna2DragControl1.UseTransparentDrag = True
        ' 
        ' Guna2Elipse1
        ' 
        Guna2Elipse1.BorderRadius = 20
        Guna2Elipse1.TargetControl = Me
        ' 
        ' TransitionAnimator
        ' 
        TransitionAnimator.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Scale
        TransitionAnimator.Cursor = Nothing
        Animation1.AnimateOnlyDifferences = True
        Animation1.BlindCoeff = CType(resources.GetObject("Animation1.BlindCoeff"), PointF)
        Animation1.LeafCoeff = 0F
        Animation1.MaxTime = 1.0F
        Animation1.MinTime = 0F
        Animation1.MosaicCoeff = CType(resources.GetObject("Animation1.MosaicCoeff"), PointF)
        Animation1.MosaicShift = CType(resources.GetObject("Animation1.MosaicShift"), PointF)
        Animation1.MosaicSize = 0
        Animation1.Padding = New Padding(0)
        Animation1.RotateCoeff = 0F
        Animation1.RotateLimit = 0F
        Animation1.ScaleCoeff = CType(resources.GetObject("Animation1.ScaleCoeff"), PointF)
        Animation1.SlideCoeff = CType(resources.GetObject("Animation1.SlideCoeff"), PointF)
        Animation1.TimeCoeff = 0F
        Animation1.TransparencyCoeff = 0F
        TransitionAnimator.DefaultAnimation = Animation1
        TransitionAnimator.MaxAnimationTime = 600
        TransitionAnimator.TimeStep = 0.01F
        ' 
        ' ArchiveStorage
        ' 
        ClientSize = New Size(1000, 700)
        Controls.Add(pnlMain)
        TransitionAnimator.SetDecoration(Me, Guna.UI2.AnimatorNS.DecorationType.None)
        FormBorderStyle = FormBorderStyle.None
        Name = "ArchiveStorage"
        StartPosition = FormStartPosition.CenterParent
        Text = "Archive Storage - OrderUp"
        pnlMain.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub
End Class