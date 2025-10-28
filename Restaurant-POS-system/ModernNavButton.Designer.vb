Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

Partial Public Class ModernNavButton
    Inherits UserControl

    ' NOTE: In a real Visual Studio project, this file would be auto-generated and hidden.

    Private components As System.ComponentModel.IContainer

    Private mainContainer As Guna2Panel
    Private btnMain As Guna2Button
    Private iconBadge As Guna2CircleButton
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private glowPanel As Guna2Panel

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
                If mainContainer IsNot Nothing Then mainContainer.Dispose()
                If btnMain IsNot Nothing Then btnMain.Dispose()
                If iconBadge IsNot Nothing Then iconBadge.Dispose()
                If lblTitle IsNot Nothing Then lblTitle.Dispose()
                If lblSubtitle IsNot Nothing Then lblSubtitle.Dispose()
                If glowPanel IsNot Nothing Then glowPanel.Dispose()
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
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Suite.CustomizableEdges()
        mainContainer = New Guna2Panel()
        iconBadge = New Guna2CircleButton()
        lblTitle = New Label()
        lblSubtitle = New Label()
        glowPanel = New Guna2Panel()
        btnMain = New Guna2Button()
        mainContainer.SuspendLayout()
        SuspendLayout()
        ' 
        ' mainContainer
        ' 
        mainContainer.BackColor = Color.Transparent
        mainContainer.BorderRadius = 16
        mainContainer.Controls.Add(iconBadge)
        mainContainer.Controls.Add(lblTitle)
        mainContainer.Controls.Add(lblSubtitle)
        mainContainer.Controls.Add(glowPanel)
        mainContainer.Controls.Add(btnMain)
        mainContainer.CustomizableEdges = CustomizableEdges6
        mainContainer.Dock = DockStyle.Fill
        mainContainer.FillColor = Color.FromArgb(CByte(35), CByte(40), CByte(48))
        mainContainer.Location = New Point(0, 0)
        mainContainer.Name = "mainContainer"
        mainContainer.ShadowDecoration.BorderRadius = 16
        mainContainer.ShadowDecoration.Color = Color.FromArgb(CByte(60), CByte(0), CByte(0), CByte(0))
        mainContainer.ShadowDecoration.CustomizableEdges = CustomizableEdges7
        mainContainer.ShadowDecoration.Depth = 10
        mainContainer.ShadowDecoration.Enabled = True
        mainContainer.Size = New Size(260, 80)
        mainContainer.TabIndex = 0
        ' 
        ' iconBadge
        ' 
        iconBadge.Cursor = Cursors.Hand
        iconBadge.FillColor = Color.FromArgb(CByte(251), CByte(191), CByte(36))
        iconBadge.Font = New Font("Segoe UI", 18.0F)
        iconBadge.ForeColor = Color.White
        iconBadge.Location = New Point(15, 16)
        iconBadge.Name = "iconBadge"
        iconBadge.ShadowDecoration.CustomizableEdges = CustomizableEdges1
        iconBadge.ShadowDecoration.Depth = 8
        iconBadge.ShadowDecoration.Enabled = True
        iconBadge.ShadowDecoration.Mode = Enums.ShadowMode.Circle
        iconBadge.Size = New Size(48, 48)
        iconBadge.TabIndex = 0
        iconBadge.Text = "📊"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Cursor = Cursors.Hand
        lblTitle.Font = New Font("Segoe UI", 11.5F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblTitle.Location = New Point(75, 18)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(115, 28)
        lblTitle.TabIndex = 1
        lblTitle.Text = "Menu Item"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.Transparent
        lblSubtitle.Cursor = Cursors.Hand
        lblSubtitle.Font = New Font("Segoe UI", 9.0F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(150), CByte(155), CByte(165))
        lblSubtitle.Location = New Point(75, 42)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(85, 20)
        lblSubtitle.TabIndex = 2
        lblSubtitle.Text = "Description"
        ' 
        ' glowPanel
        ' 
        glowPanel.BorderColor = Color.Transparent
        glowPanel.BorderRadius = 16
        glowPanel.BorderThickness = 3
        glowPanel.CustomizableEdges = CustomizableEdges2
        glowPanel.Dock = DockStyle.Fill
        glowPanel.FillColor = Color.Transparent
        glowPanel.Location = New Point(0, 0)
        glowPanel.Name = "glowPanel"
        glowPanel.ShadowDecoration.CustomizableEdges = CustomizableEdges3
        glowPanel.Size = New Size(260, 80)
        glowPanel.TabIndex = 3
        glowPanel.Visible = False
        ' 
        ' btnMain
        ' 
        btnMain.BorderColor = Color.Transparent
        btnMain.BorderRadius = 16
        btnMain.Cursor = Cursors.Hand
        btnMain.CustomizableEdges = CustomizableEdges4
        btnMain.Dock = DockStyle.Fill
        btnMain.FillColor = Color.Transparent
        btnMain.Font = New Font("Segoe UI", 9.0F)
        btnMain.ForeColor = Color.White
        btnMain.HoverState.FillColor = Color.FromArgb(CByte(20), CByte(255), CByte(255), CByte(255))
        btnMain.Location = New Point(0, 0)
        btnMain.Name = "btnMain"
        btnMain.PressedColor = Color.FromArgb(CByte(30), CByte(255), CByte(255), CByte(255))
        btnMain.ShadowDecoration.CustomizableEdges = CustomizableEdges5
        btnMain.Size = New Size(260, 80)
        btnMain.TabIndex = 4
        ' 
        ' ModernNavButton
        ' 
        BackColor = Color.Transparent
        Controls.Add(mainContainer)
        Margin = New Padding(10, 8, 10, 8)
        Name = "ModernNavButton"
        Size = New Size(260, 80)
        mainContainer.ResumeLayout(False)
        mainContainer.PerformLayout()
        ResumeLayout(False)
    End Sub

End Class