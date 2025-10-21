Imports MySql.Data.MySqlClient

Public Class Settings
    Dim IsEdit As Boolean = False
    Dim HasUpdate As Boolean = False


    ' SettingsConfigStruct are in DatabaseHandler


    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' load configs
        GetSettingsConfig()
        ItemBtnSizeTxtBox.Text = SettingsConfig.MenuItemButtonSize
        FontSizeTxtBtn.Text = SettingsConfig.MenuItemFontSize
        ImagePathTxtBox.Text = SettingsConfig.LoginImagePath
        ShortcutKeyChckBox.Checked = SettingsConfig.EnableShortcutKeys
        ComboBox1.Text = SettingsConfig.Theme

        If Not IsAdmin Then
            ImagePathTxtBox.Enabled = False
            SelectPictureBtn.Enabled = False
        End If

        Me.WindowState = WindowState.Maximized

        ' add handlers for number only
        AddHandler ItemBtnSizeTxtBox.KeyPress, AddressOf HandleNumberOnly
        AddHandler FontSizeTxtBtn.KeyPress, AddressOf HandleNumberOnly

        BackPanel = {Panel1}
        FlowPanel = {}
        SetTheme()
    End Sub
    Private Sub HandleFormClose(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.DialogResult = If((HasUpdate), DialogResult.OK, DialogResult.Cancel)
        HasUpdate = False

        EditBtn.Enabled = True
        SaveBtn.Enabled = False
        ConfigPnl.Enabled = False
    End Sub



    ' buttons
    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        IsEdit = True
        ConfigPnl.Enabled = True

        EditBtn.Enabled = False
    End Sub
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        IsEdit = False
        EditBtn.Enabled = True
        SaveBtn.Enabled = False
        HasUpdate = False

        ' reset the form (and change it back to previos config)
        ConfigPnl.Enabled = False
        ItemBtnSizeTxtBox.Text = SettingsConfig.MenuItemButtonSize
        ShortcutKeyChckBox.Checked = SettingsConfig.EnableShortcutKeys
    End Sub
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim Connection As New MySqlConnection(GetGlobalConnectionString)

        Try
            Connection.Open()
            Dim Query As String = "UPDATE restaurant.settings SET MenuItemButtonSize = @btnsize, MenuItemFontSize = @fontsize, EnableShortcutKeys = @shrtky, LoginImagePath = @imgpath, Theme = @theme"
            Dim Command As New MySqlCommand(Query, Connection)
            Command.Parameters.AddWithValue("@btnsize", ItemBtnSizeTxtBox.Text)
            Command.Parameters.AddWithValue("@fontsize", FontSizeTxtBtn.Text)
            Command.Parameters.AddWithValue("@shrtky", ShortcutKeyChckBox.Checked)
            Command.Parameters.AddWithValue("@imgpath", ImagePathTxtBox.Text)
            Command.Parameters.AddWithValue("@theme", ComboBox1.Text)

            If Command.ExecuteNonQuery > 0 Then
                HasUpdate = True
                MsgBox("Successfully updated the configurations!", MsgBoxStyle.Information, "Success")
                GetSettingsConfig() ' refresh SettingsConfig struct data
            End If

        Catch ex As Exception
            MsgBox("Failed to update the configurations", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub SelectPictureBtn_Click(sender As Object, e As EventArgs) Handles SelectPictureBtn.Click
        Dim mngMenuForm As New Manage_menu
        Dim path As String = mngMenuForm.ItemBtnSetImage(sender, e)
        If Not String.IsNullOrEmpty(path) Then
            ImagePathTxtBox.Text = path
        End If
    End Sub



    ' handlers/listeners
    Private Sub ConfigChanges(sender As Object, e As EventArgs) Handles ItemBtnSizeTxtBox.TextChanged, ShortcutKeyChckBox.Click, ImagePathTxtBox.TextChanged, ComboBox1.TextChanged
        If IsEdit Then
            SaveBtn.Enabled = True
        End If
    End Sub
End Class