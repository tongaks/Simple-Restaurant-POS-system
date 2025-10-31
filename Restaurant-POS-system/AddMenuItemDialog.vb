Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.IO
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Globalization
Imports System.Text.RegularExpressions

''' <summary>
''' Premium UserControl for adding new menu items
''' Features: Real-time validation, image preview, database integration
''' NOTE: UI components are defined in AddMenuItemDialog.Designer.vb
''' </summary>
Partial Public Class AddMenuItemDialog
    ' CRITICAL FIX: Must explicitly inherit from UserControl to match Designer.vb
    Inherits System.Windows.Forms.UserControl

    ' ===== PRIVATE FIELDS =====
    Private _selectedImagePath As String = ""
    Private _selectedCategory As String = ""
    Private _categories As List(Of String)
    Private _fadeInTimer As Timer
    Private _fadeStep As Integer = 0

    ' ===== CONSTRUCTOR =====
    Public Sub New(Optional defaultCategory As String = "")
        ' CRITICAL: Call MyBase.New() before InitializeComponent
        MyBase.New()

        ' Controls initialized by Designer partial
        InitializeComponent()

        _selectedCategory = If(String.IsNullOrWhiteSpace(defaultCategory), String.Empty, defaultCategory)

        SetupAnimations()
        ApplyPremiumStyling()
        ApplyHoverStyles()

        ' Load categories (safe)
        LoadCategories()

        ' Finalize after control is loaded onto a Form
        AddHandler Me.Load, AddressOf AddMenuItemControl_Load
    End Sub

    ' ===== PROPERTIES =====
    Public ReadOnly Property SavedItemName As String
        Get
            Return txtItemName.Text.Trim()
        End Get
    End Property

    Public ReadOnly Property SavedItemPrice As Decimal
        Get
            Dim price As Decimal
            Decimal.TryParse(txtItemPrice.Text, price)
            Return price
        End Get
    End Property

    Public ReadOnly Property SavedImagePath As String
        Get
            Return _selectedImagePath
        End Get
    End Property

    Public ReadOnly Property SavedCategory As String
        Get
            Return _selectedCategory
        End Get
    End Property

    ' ===== LOAD EVENT =====
    Private Sub AddMenuItemControl_Load(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(_selectedCategory) AndAlso cmbCategory.Items.Contains(_selectedCategory) Then
                cmbCategory.SelectedItem = _selectedCategory
            ElseIf cmbCategory.Items.Count > 0 Then
                cmbCategory.SelectedIndex = 0
                _selectedCategory = cmbCategory.SelectedItem.ToString()
            End If

            ' Start host fade-in if host exists
            Dim host = Me.FindForm()
            If host IsNot Nothing Then
                Try
                    host.Opacity = Math.Max(0.0, Math.Min(1.0, host.Opacity))
                    _fadeInTimer?.Start()
                Catch
                End Try
            End If
        Catch
        End Try
    End Sub

    ' ===== SETUP METHODS =====
    Private Sub SetupAnimations()
        _fadeInTimer = New Timer()
        _fadeInTimer.Interval = 15
        AddHandler _fadeInTimer.Tick, AddressOf OnFadeInTick
    End Sub

    Private Sub OnFadeInTick(sender As Object, e As EventArgs)
        Dim host = Me.FindForm()
        If host Is Nothing Then
            _fadeInTimer.Stop()
            Return
        End If

        Try
            If host.Opacity < 1.0 Then
                host.Opacity = Math.Min(1.0, host.Opacity + 0.1)
            Else
                _fadeInTimer.Stop()
                txtItemName.Focus()
            End If
        Catch
            _fadeInTimer.Stop()
        End Try
    End Sub

    Private Sub ApplyPremiumStyling()
        ' Additional styling can be added here if needed
    End Sub

    Private Sub ApplyHoverStyles()
        Try
            btnUploadImage.HoverState.FillColor = AdjustBrightness(Color.FromArgb(52, 152, 219), -20)
            btnSave.HoverState.FillColor = AdjustBrightness(Color.FromArgb(46, 204, 113), -20)
            btnCancel.HoverState.FillColor = AdjustBrightness(Color.FromArgb(149, 165, 166), -20)
        Catch
        End Try
    End Sub

    Private Sub LoadCategories()
        _categories = New List(Of String)()
        Try
            Dim cs = GetGlobalConnectionString()
            If Not String.IsNullOrEmpty(cs) Then
                Using conn As New MySqlConnection(cs)
                    conn.Open()
                    Using cmd As New MySqlCommand("SELECT CategoryName FROM Categories ORDER BY CategoryName;", conn)
                        Using rdr = cmd.ExecuteReader()
                            While rdr.Read()
                                _categories.Add(rdr.GetString(0))
                            End While
                        End Using
                    End Using
                End Using
            End If
        Catch
        End Try

        If _categories.Count = 0 Then
            _categories.AddRange(New String() {"Foods", "Drinks", "Snacks_Sides", "Desserts"})
        End If

        Try
            cmbCategory.Items.Clear()
            For Each c In _categories
                cmbCategory.Items.Add(c)
            Next
        Catch
        End Try
    End Sub

    Private Function GetGlobalConnectionString() As String
        ' Use central DatabaseHandler connection string to avoid mismatched/placeholder strings.
        ' Ensure DatabaseHandler.GetGlobalConnectionString() is configured for your DB (database name, blank password, SslMode if needed).
        Return DatabaseHandler.GetGlobalConnectionString()
    End Function

    ' ===== EVENT HANDLERS (USING HANDLES) =====
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseHostAs(DialogResult.Cancel)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CloseHostAs(DialogResult.Cancel)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateForm() Then
            If SaveToDatabase() Then
                CloseHostAs(DialogResult.OK)
            End If
        End If
    End Sub

    Private Sub btnUploadImage_Click(sender As Object, e As EventArgs) Handles btnUploadImage.Click
        Using dlg As New OpenFileDialog()
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*"
            dlg.Title = "Select Item Image"

            If dlg.ShowDialog() = DialogResult.OK Then
                _selectedImagePath = dlg.FileName
                Try
                    Dim img = Image.FromFile(_selectedImagePath)
                    If pbImagePreview.Image IsNot Nothing Then
                        pbImagePreview.Image.Dispose()
                    End If
                    pbImagePreview.Image = ResizeImageFit(img, pbImagePreview)
                    lblImagePlaceholder.Visible = False
                    lblImageError.Visible = False
                Catch ex As Exception
                    MessageBox.Show("Error loading image: " & ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    _selectedImagePath = ""
                End Try
            End If
        End Using
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
        If Not String.IsNullOrWhiteSpace(txtItemName.Text) Then
            txtItemName.BorderColor = Color.FromArgb(222, 226, 230)
            lblNameError.Visible = False
        End If
    End Sub

    Private Sub txtItemPrice_TextChanged(sender As Object, e As EventArgs) Handles txtItemPrice.TextChanged
        Dim price As Decimal
        If Decimal.TryParse(txtItemPrice.Text, price) AndAlso price >= 0D Then
            txtItemPrice.BorderColor = Color.FromArgb(222, 226, 230)
            lblPriceError.Visible = False
        End If
    End Sub

    Private Sub txtItemPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItemPrice.KeyPress
        ' Only allow numbers, decimal point, and control characters
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Only allow one decimal point
        If e.KeyChar = "."c AndAlso txtItemPrice.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    ' ===== VALIDATION =====
    Private Function ValidateForm() As Boolean
        Dim ok = True
        ClearAllErrors()

        If String.IsNullOrWhiteSpace(txtItemName.Text) Then
            ShowError(txtItemName, lblNameError, "Item name is required")
            ok = False
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtItemPrice.Text, price) Then
            ShowError(txtItemPrice, lblPriceError, "Please enter a valid price")
            ok = False
        ElseIf price <= 0D Then
            ShowError(txtItemPrice, lblPriceError, "Price must be greater than zero")
            ok = False
        End If

        If cmbCategory.SelectedItem Is Nothing Then
            ShowError(cmbCategory, lblCategoryError, "Please select a category")
            ok = False
        End If

        Return ok
    End Function

    Private Sub ShowError(control As Control, errorLabel As Label, message As String)
        Try
            If TypeOf control Is Guna2TextBox Then
                CType(control, Guna2TextBox).BorderColor = Color.FromArgb(231, 76, 60)
            ElseIf TypeOf control Is Guna2ComboBox Then
                CType(control, Guna2ComboBox).BorderColor = Color.FromArgb(231, 76, 60)
            End If
            errorLabel.Text = "⚠ " & message
            errorLabel.Visible = True
        Catch
        End Try
    End Sub

    Private Sub ClearAllErrors()
        Try
            txtItemName.BorderColor = Color.FromArgb(222, 226, 230)
            txtItemPrice.BorderColor = Color.FromArgb(222, 226, 230)
            cmbCategory.BorderColor = Color.FromArgb(222, 226, 230)

            lblNameError.Visible = False
            lblPriceError.Visible = False
            lblCategoryError.Visible = False
            lblImageError.Visible = False
        Catch
        End Try
    End Sub

    ' ===== DATABASE =====
    Private Function SaveToDatabase() As Boolean
        ' Declare tableName at method scope so Catch blocks can reference it.
        Dim tableName As String = ""
        Try
            If cmbCategory.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a category before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            tableName = cmbCategory.SelectedItem.ToString()

            ' Validate and normalize price
            Dim priceValue As Decimal
            If Not Decimal.TryParse(txtItemPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, priceValue) Then
                MessageBox.Show("Please enter a valid numeric price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Prevent overflow for typical DECIMAL(10,2)
            Const MAX_PRICE As Decimal = 99999999.99D
            If priceValue <= 0D OrElse priceValue > MAX_PRICE Then
                MessageBox.Show($"Price must be > 0 and <= {MAX_PRICE:F2}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Using conn As New MySqlConnection(GetGlobalConnectionString())
                conn.Open()

                ' Sanitize category -> safe table name (replace invalid chars with underscore)
                Dim safeTableName As String = Regex.Replace(tableName.Trim(), "[^A-Za-z0-9_]", "_")
                If String.IsNullOrWhiteSpace(safeTableName) Then
                    MessageBox.Show("Computed table name is invalid. Please rename the category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                ' Ensure table exists. If not, create with expected schema.
                Dim checkSql As String = "SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = @tname"
                Using cmdCheck As New MySqlCommand(checkSql, conn)
                    cmdCheck.Parameters.AddWithValue("@tname", safeTableName)
                    Dim exists = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0
                    If Not exists Then
                        Dim createSql As String =
                            "CREATE TABLE IF NOT EXISTS `" & safeTableName & "` (" &
                            "ItemId INT AUTO_INCREMENT PRIMARY KEY, " &
                            "ItemName VARCHAR(255) NOT NULL, " &
                            "ItemPrice DECIMAL(10,2) NOT NULL, " &
                            "ImagePath TEXT, " &
                            "DateAdded DATETIME NOT NULL" &
                            ")"
                        Using cmdCreate As New MySqlCommand(createSql, conn)
                            cmdCreate.ExecuteNonQuery()
                        End Using
                    End If
                End Using

                ' IMPORTANT: set a session flag so triggers can detect and skip conflict-causing behavior.
                Using cmdFlagOn As New MySqlCommand("SET @SKIP_TRIGGER = 1;", conn)
                    cmdFlagOn.ExecuteNonQuery()
                End Using

                Try
                    ' Insert using the safe table name
                    Dim sql = "INSERT INTO `" & safeTableName & "` (ItemName, ItemPrice, ImagePath, DateAdded) " &
                              "VALUES (@name, @price, @image, @date);"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@name", txtItemName.Text.Trim())
                        ' Ensure decimal parameter uses invariant formatting (driver handles parameter type)
                        cmd.Parameters.AddWithValue("@price", priceValue)
                        cmd.Parameters.AddWithValue("@image", If(String.IsNullOrEmpty(_selectedImagePath), "N/A", _selectedImagePath))
                        cmd.Parameters.AddWithValue("@date", DateTime.Now)

                        Dim rows = cmd.ExecuteNonQuery()

                        If rows > 0 Then
                            Return True
                        Else
                            MessageBox.Show("Failed to add menu item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If
                    End Using

                Finally
                    ' Always reset the session flag
                    Try
                        Using cmdFlagOff As New MySqlCommand("SET @SKIP_TRIGGER = NULL;", conn)
                            cmdFlagOff.ExecuteNonQuery()
                        End Using
                    Catch
                        ' swallow - non-critical
                    End Try
                End Try
            End Using

        Catch mex As MySqlException
            Dim details = $"MySQL Error {mex.Number}: {mex.Message}"
            ' Provide the full exception text to make debugging reproducible (non-sensitive)
            If mex.Number = 1442 Then
                MessageBox.Show("Failed to save item: Trigger conflict (error 1442)." & vbCrLf & vbCrLf & details & vbCrLf & vbCrLf &
                                "Fix: modify the database trigger(s) to check the session variable @SKIP_TRIGGER and skip the section that updates the same table.",
                                "Trigger Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf mex.Number = 1045 OrElse mex.Message.ToLower().Contains("access denied") Then
                MessageBox.Show("Failed to save item: Authentication failed for the database user." & vbCrLf & vbCrLf & details &
                                vbCrLf & vbCrLf & "Check DatabaseHandler.GetGlobalConnectionString().", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Failed to save item: " & details & vbCrLf & vbCrLf & mex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show("Failed to save item: Fatal error encountered during command execution." & vbCrLf & vbCrLf & ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' ===== UTILITY FUNCTIONS =====
    Private Function ResizeImageFit(img As Image, pb As PictureBox) As Image
        Dim ratioX = CDbl(pb.Width) / img.Width
        Dim ratioY = CDbl(pb.Height) / img.Height
        Dim ratio = Math.Min(ratioX, ratioY)

        Dim newW = CInt(img.Width * ratio)
        Dim newH = CInt(img.Height * ratio)

        Dim bmp As New Bitmap(newW, newH)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newW, newH)
        End Using

        Return bmp
    End Function

    Private Function AdjustBrightness(color As Color, amount As Integer) As Color
        Dim r = Math.Max(0, Math.Min(255, color.R + amount))
        Dim g = Math.Max(0, Math.Min(255, color.G + amount))
        Dim b = Math.Max(0, Math.Min(255, color.B + amount))
        Return Color.FromArgb(color.A, r, g, b)
    End Function

    Private Sub CloseHostAs(result As DialogResult)
        Dim host = Me.FindForm()
        If host IsNot Nothing Then
            Try
                host.DialogResult = result
            Catch
            End Try
            Try
                host.Close()
            Catch
            End Try
        End If
    End Sub
End Class