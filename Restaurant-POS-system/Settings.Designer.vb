<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        ItemBtnSizeTxtBox = New TextBox()
        Label3 = New Label()
        ShortcutKeyChckBox = New CheckBox()
        Panel1 = New Panel()
        SaveBtn = New FontAwesome.Sharp.IconButton()
        CancelBtn = New FontAwesome.Sharp.IconButton()
        EditBtn = New FontAwesome.Sharp.IconButton()
        Label4 = New Label()
        ConfigPnl = New Panel()
        Label6 = New Label()
        ComboBox1 = New ComboBox()
        SelectPictureBtn = New FontAwesome.Sharp.IconButton()
        ImagePathTxtBox = New TextBox()
        Label5 = New Label()
        FontSizeTxtBtn = New TextBox()
        Label2 = New Label()
        Panel1.SuspendLayout()
        ConfigPnl.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(17, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(126, 15)
        Label1.TabIndex = 0
        Label1.Text = "Menu item button size"
        ' 
        ' ItemBtnSizeTxtBox
        ' 
        ItemBtnSizeTxtBox.Location = New Point(150, 24)
        ItemBtnSizeTxtBox.Name = "ItemBtnSizeTxtBox"
        ItemBtnSizeTxtBox.Size = New Size(100, 23)
        ItemBtnSizeTxtBox.TabIndex = 1
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(27, 98)
        Label3.Name = "Label3"
        Label3.Size = New Size(115, 15)
        Label3.TabIndex = 4
        Label3.Text = "Enable shortcut keys"
        ' 
        ' ShortcutKeyChckBox
        ' 
        ShortcutKeyChckBox.AutoSize = True
        ShortcutKeyChckBox.Location = New Point(150, 101)
        ShortcutKeyChckBox.Name = "ShortcutKeyChckBox"
        ShortcutKeyChckBox.Size = New Size(15, 14)
        ShortcutKeyChckBox.TabIndex = 5
        ShortcutKeyChckBox.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.DarkSeaGreen
        Panel1.Controls.Add(SaveBtn)
        Panel1.Controls.Add(CancelBtn)
        Panel1.Controls.Add(EditBtn)
        Panel1.Controls.Add(Label4)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(803, 64)
        Panel1.TabIndex = 6
        ' 
        ' SaveBtn
        ' 
        SaveBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SaveBtn.BackColor = Color.SpringGreen
        SaveBtn.Enabled = False
        SaveBtn.FlatStyle = FlatStyle.Flat
        SaveBtn.IconChar = FontAwesome.Sharp.IconChar.Save
        SaveBtn.IconColor = Color.Black
        SaveBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SaveBtn.IconSize = 30
        SaveBtn.ImageAlign = ContentAlignment.MiddleRight
        SaveBtn.Location = New Point(519, 12)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Size = New Size(75, 38)
        SaveBtn.TabIndex = 10
        SaveBtn.Text = "Save"
        SaveBtn.TextAlign = ContentAlignment.MiddleLeft
        SaveBtn.UseVisualStyleBackColor = False
        ' 
        ' CancelBtn
        ' 
        CancelBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CancelBtn.BackColor = SystemColors.AppWorkspace
        CancelBtn.Enabled = False
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.IconChar = FontAwesome.Sharp.IconChar.LongArrowAltRight
        CancelBtn.IconColor = Color.Black
        CancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        CancelBtn.IconSize = 30
        CancelBtn.ImageAlign = ContentAlignment.MiddleRight
        CancelBtn.Location = New Point(707, 13)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(81, 38)
        CancelBtn.TabIndex = 9
        CancelBtn.Text = "Cancel"
        CancelBtn.TextAlign = ContentAlignment.MiddleLeft
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' EditBtn
        ' 
        EditBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        EditBtn.BackColor = Color.Khaki
        EditBtn.FlatStyle = FlatStyle.Flat
        EditBtn.IconChar = FontAwesome.Sharp.IconChar.Pencil
        EditBtn.IconColor = Color.Black
        EditBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        EditBtn.IconSize = 30
        EditBtn.ImageAlign = ContentAlignment.MiddleRight
        EditBtn.Location = New Point(614, 13)
        EditBtn.Name = "EditBtn"
        EditBtn.Size = New Size(75, 38)
        EditBtn.TabIndex = 8
        EditBtn.Text = "Edit"
        EditBtn.TextAlign = ContentAlignment.MiddleLeft
        EditBtn.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 20F)
        Label4.ForeColor = SystemColors.ButtonFace
        Label4.Location = New Point(12, 13)
        Label4.Name = "Label4"
        Label4.Size = New Size(112, 37)
        Label4.TabIndex = 7
        Label4.Text = "Settings"
        ' 
        ' ConfigPnl
        ' 
        ConfigPnl.Controls.Add(Label6)
        ConfigPnl.Controls.Add(ComboBox1)
        ConfigPnl.Controls.Add(SelectPictureBtn)
        ConfigPnl.Controls.Add(ImagePathTxtBox)
        ConfigPnl.Controls.Add(Label5)
        ConfigPnl.Controls.Add(FontSizeTxtBtn)
        ConfigPnl.Controls.Add(Label2)
        ConfigPnl.Controls.Add(ItemBtnSizeTxtBox)
        ConfigPnl.Controls.Add(Label1)
        ConfigPnl.Controls.Add(ShortcutKeyChckBox)
        ConfigPnl.Controls.Add(Label3)
        ConfigPnl.Enabled = False
        ConfigPnl.Location = New Point(21, 85)
        ConfigPnl.Name = "ConfigPnl"
        ConfigPnl.Size = New Size(739, 314)
        ConfigPnl.TabIndex = 7
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(62, 178)
        Label6.Name = "Label6"
        Label6.Size = New Size(85, 15)
        Label6.TabIndex = 13
        Label6.Text = "Change theme"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Blue", "Green", "Pink", "Red"})
        ComboBox1.Location = New Point(150, 174)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(172, 23)
        ComboBox1.TabIndex = 12
        ' 
        ' SelectPictureBtn
        ' 
        SelectPictureBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SelectPictureBtn.BackColor = Color.Khaki
        SelectPictureBtn.FlatStyle = FlatStyle.Flat
        SelectPictureBtn.IconChar = FontAwesome.Sharp.IconChar.PhotoFilm
        SelectPictureBtn.IconColor = Color.Black
        SelectPictureBtn.IconFont = FontAwesome.Sharp.IconFont.Auto
        SelectPictureBtn.IconSize = 20
        SelectPictureBtn.ImageAlign = ContentAlignment.MiddleRight
        SelectPictureBtn.Location = New Point(410, 135)
        SelectPictureBtn.Name = "SelectPictureBtn"
        SelectPictureBtn.Size = New Size(75, 23)
        SelectPictureBtn.TabIndex = 11
        SelectPictureBtn.Text = "Select"
        SelectPictureBtn.TextAlign = ContentAlignment.MiddleLeft
        SelectPictureBtn.UseVisualStyleBackColor = False
        ' 
        ' ImagePathTxtBox
        ' 
        ImagePathTxtBox.Location = New Point(151, 135)
        ImagePathTxtBox.Name = "ImagePathTxtBox"
        ImagePathTxtBox.Size = New Size(243, 23)
        ImagePathTxtBox.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(3, 138)
        Label5.Name = "Label5"
        Label5.Size = New Size(147, 15)
        Label5.TabIndex = 8
        Label5.Text = "Change login page picture"
        ' 
        ' FontSizeTxtBtn
        ' 
        FontSizeTxtBtn.Location = New Point(150, 59)
        FontSizeTxtBtn.Name = "FontSizeTxtBtn"
        FontSizeTxtBtn.Size = New Size(100, 23)
        FontSizeTxtBtn.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(30, 62)
        Label2.Name = "Label2"
        Label2.Size = New Size(112, 15)
        Label2.TabIndex = 6
        Label2.Text = "Menu item font size"
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(ConfigPnl)
        Controls.Add(Panel1)
        Name = "Settings"
        Text = "Settings"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ConfigPnl.ResumeLayout(False)
        ConfigPnl.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ItemBtnSizeTxtBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ShortcutKeyChckBox As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CancelBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents EditBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents Label4 As Label
    Friend WithEvents SaveBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents ConfigPnl As Panel
    Friend WithEvents FontSizeTxtBtn As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SelectPictureBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents ImagePathTxtBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
