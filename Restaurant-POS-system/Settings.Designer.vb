<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        pnlMain = New Panel()
        pnlActions = New Panel()
        CancelBtn = New Button()
        SaveBtn = New Button()
        EditBtn = New Button()
        ConfigPnl = New Panel()
        pnlShortcutKeys = New Panel()
        ShortcutKeyChckBox = New CheckBox()
        lblShortcutKeys = New Label()
        pnlFontSize = New Panel()
        FontSizeTxtBtn = New TextBox()
        lblFontSize = New Label()
        pnlButtonSize = New Panel()
        ItemBtnSizeTxtBox = New TextBox()
        lblButtonSize = New Label()
        lblConfigTitle = New Label()
        pnlHeader.SuspendLayout()
        pnlMain.SuspendLayout()
        pnlActions.SuspendLayout()
        ConfigPnl.SuspendLayout()
        pnlShortcutKeys.SuspendLayout()
        pnlFontSize.SuspendLayout()
        pnlButtonSize.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(30, 20, 30, 20)
        pnlHeader.Size = New Size(800, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Dock = DockStyle.Left
        lblTitle.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lblTitle.Location = New Point(30, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(150, 46)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Settings"
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlMain.Controls.Add(pnlActions)
        pnlMain.Controls.Add(ConfigPnl)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 80)
        pnlMain.Name = "pnlMain"
        pnlMain.Padding = New Padding(40)
        pnlMain.Size = New Size(800, 520)
        pnlMain.TabIndex = 1
        ' 
        ' pnlActions
        ' 
        pnlActions.Controls.Add(CancelBtn)
        pnlActions.Controls.Add(SaveBtn)
        pnlActions.Controls.Add(EditBtn)
        pnlActions.Dock = DockStyle.Bottom
        pnlActions.Location = New Point(40, 380)
        pnlActions.Name = "pnlActions"
        pnlActions.Padding = New Padding(0, 20, 0, 0)
        pnlActions.Size = New Size(720, 100)
        pnlActions.TabIndex = 1
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        CancelBtn.Cursor = Cursors.Hand
        CancelBtn.Dock = DockStyle.Right
        CancelBtn.Enabled = False
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        CancelBtn.ForeColor = Color.White
        CancelBtn.Location = New Point(280, 20)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(150, 80)
        CancelBtn.TabIndex = 2
        CancelBtn.Text = "Cancel"
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' SaveBtn
        ' 
        SaveBtn.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        SaveBtn.Cursor = Cursors.Hand
        SaveBtn.Dock = DockStyle.Right
        SaveBtn.Enabled = False
        SaveBtn.FlatAppearance.BorderSize = 0
        SaveBtn.FlatStyle = FlatStyle.Flat
        SaveBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        SaveBtn.ForeColor = Color.White
        SaveBtn.Location = New Point(430, 20)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Size = New Size(150, 80)
        SaveBtn.TabIndex = 1
        SaveBtn.Text = "Save Changes"
        SaveBtn.UseVisualStyleBackColor = False
        ' 
        ' EditBtn
        ' 
        EditBtn.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        EditBtn.Cursor = Cursors.Hand
        EditBtn.Dock = DockStyle.Right
        EditBtn.FlatAppearance.BorderSize = 0
        EditBtn.FlatStyle = FlatStyle.Flat
        EditBtn.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        EditBtn.ForeColor = Color.White
        EditBtn.Location = New Point(580, 20)
        EditBtn.Name = "EditBtn"
        EditBtn.Size = New Size(140, 80)
        EditBtn.TabIndex = 0
        EditBtn.Text = "Edit"
        EditBtn.UseVisualStyleBackColor = False
        ' 
        ' ConfigPnl
        ' 
        ConfigPnl.BackColor = Color.White
        ConfigPnl.BorderStyle = BorderStyle.FixedSingle
        ConfigPnl.Controls.Add(pnlShortcutKeys)
        ConfigPnl.Controls.Add(pnlFontSize)
        ConfigPnl.Controls.Add(pnlButtonSize)
        ConfigPnl.Controls.Add(lblConfigTitle)
        ConfigPnl.Dock = DockStyle.Top
        ConfigPnl.Enabled = False
        ConfigPnl.Location = New Point(40, 40)
        ConfigPnl.Name = "ConfigPnl"
        ConfigPnl.Padding = New Padding(30, 20, 30, 20)
        ConfigPnl.Size = New Size(720, 320)
        ConfigPnl.TabIndex = 0
        ' 
        ' pnlShortcutKeys
        ' 
        pnlShortcutKeys.Controls.Add(ShortcutKeyChckBox)
        pnlShortcutKeys.Controls.Add(lblShortcutKeys)
        pnlShortcutKeys.Dock = DockStyle.Top
        pnlShortcutKeys.Location = New Point(30, 207)
        pnlShortcutKeys.Name = "pnlShortcutKeys"
        pnlShortcutKeys.Padding = New Padding(0, 10, 0, 10)
        pnlShortcutKeys.Size = New Size(658, 70)
        pnlShortcutKeys.TabIndex = 3
        ' 
        ' ShortcutKeyChckBox
        ' 
        ShortcutKeyChckBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ShortcutKeyChckBox.AutoSize = True
        ShortcutKeyChckBox.Location = New Point(618, 18)
        ShortcutKeyChckBox.Name = "ShortcutKeyChckBox"
        ShortcutKeyChckBox.Size = New Size(18, 17)
        ShortcutKeyChckBox.TabIndex = 1
        ShortcutKeyChckBox.UseVisualStyleBackColor = True
        ' 
        ' lblShortcutKeys
        ' 
        lblShortcutKeys.AutoSize = True
        lblShortcutKeys.Font = New Font("Segoe UI", 11F)
        lblShortcutKeys.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblShortcutKeys.Location = New Point(10, 15)
        lblShortcutKeys.Name = "lblShortcutKeys"
        lblShortcutKeys.Size = New Size(188, 25)
        lblShortcutKeys.TabIndex = 0
        lblShortcutKeys.Text = "Enable Shortcut Keys"
        ' 
        ' pnlFontSize
        ' 
        pnlFontSize.Controls.Add(FontSizeTxtBtn)
        pnlFontSize.Controls.Add(lblFontSize)
        pnlFontSize.Dock = DockStyle.Top
        pnlFontSize.Location = New Point(30, 137)
        pnlFontSize.Name = "pnlFontSize"
        pnlFontSize.Padding = New Padding(0, 10, 0, 10)
        pnlFontSize.Size = New Size(658, 70)
        pnlFontSize.TabIndex = 2
        ' 
        ' FontSizeTxtBtn
        ' 
        FontSizeTxtBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        FontSizeTxtBtn.Font = New Font("Segoe UI", 11F)
        FontSizeTxtBtn.Location = New Point(500, 12)
        FontSizeTxtBtn.Name = "FontSizeTxtBtn"
        FontSizeTxtBtn.Size = New Size(150, 32)
        FontSizeTxtBtn.TabIndex = 1
        ' 
        ' lblFontSize
        ' 
        lblFontSize.AutoSize = True
        lblFontSize.Font = New Font("Segoe UI", 11F)
        lblFontSize.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblFontSize.Location = New Point(10, 15)
        lblFontSize.Name = "lblFontSize"
        lblFontSize.Size = New Size(184, 25)
        lblFontSize.TabIndex = 0
        lblFontSize.Text = "Menu Item Font Size"
        ' 
        ' pnlButtonSize
        ' 
        pnlButtonSize.Controls.Add(ItemBtnSizeTxtBox)
        pnlButtonSize.Controls.Add(lblButtonSize)
        pnlButtonSize.Dock = DockStyle.Top
        pnlButtonSize.Location = New Point(30, 67)
        pnlButtonSize.Name = "pnlButtonSize"
        pnlButtonSize.Padding = New Padding(0, 10, 0, 10)
        pnlButtonSize.Size = New Size(658, 70)
        pnlButtonSize.TabIndex = 1
        ' 
        ' ItemBtnSizeTxtBox
        ' 
        ItemBtnSizeTxtBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ItemBtnSizeTxtBox.Font = New Font("Segoe UI", 11F)
        ItemBtnSizeTxtBox.Location = New Point(500, 12)
        ItemBtnSizeTxtBox.Name = "ItemBtnSizeTxtBox"
        ItemBtnSizeTxtBox.Size = New Size(150, 32)
        ItemBtnSizeTxtBox.TabIndex = 1
        ' 
        ' lblButtonSize
        ' 
        lblButtonSize.AutoSize = True
        lblButtonSize.Font = New Font("Segoe UI", 11F)
        lblButtonSize.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblButtonSize.Location = New Point(10, 15)
        lblButtonSize.Name = "lblButtonSize"
        lblButtonSize.Size = New Size(203, 25)
        lblButtonSize.TabIndex = 0
        lblButtonSize.Text = "Menu Item Button Size"
        ' 
        ' lblConfigTitle
        ' 
        lblConfigTitle.AutoSize = True
        lblConfigTitle.Dock = DockStyle.Top
        lblConfigTitle.Font = New Font("Segoe UI Semibold", 14F, FontStyle.Bold)
        lblConfigTitle.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblConfigTitle.Location = New Point(30, 20)
        lblConfigTitle.Name = "lblConfigTitle"
        lblConfigTitle.Padding = New Padding(0, 0, 0, 15)
        lblConfigTitle.Size = New Size(234, 47)
        lblConfigTitle.TabIndex = 0
        lblConfigTitle.Text = "Menu Configuration"
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(800, 600)
        Controls.Add(pnlMain)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 9F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "Settings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings - OrderUp!"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlMain.ResumeLayout(False)
        pnlActions.ResumeLayout(False)
        ConfigPnl.ResumeLayout(False)
        ConfigPnl.PerformLayout()
        pnlShortcutKeys.ResumeLayout(False)
        pnlShortcutKeys.PerformLayout()
        pnlFontSize.ResumeLayout(False)
        pnlFontSize.PerformLayout()
        pnlButtonSize.ResumeLayout(False)
        pnlButtonSize.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents ConfigPnl As Panel
    Friend WithEvents lblConfigTitle As Label
    Friend WithEvents pnlButtonSize As Panel
    Friend WithEvents ItemBtnSizeTxtBox As TextBox
    Friend WithEvents lblButtonSize As Label
    Friend WithEvents pnlFontSize As Panel
    Friend WithEvents FontSizeTxtBtn As TextBox
    Friend WithEvents lblFontSize As Label
    Friend WithEvents pnlShortcutKeys As Panel
    Friend WithEvents ShortcutKeyChckBox As CheckBox
    Friend WithEvents lblShortcutKeys As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents CancelBtn As Button
    Friend WithEvents SaveBtn As Button
    Friend WithEvents EditBtn As Button
End Class