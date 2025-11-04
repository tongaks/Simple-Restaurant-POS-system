Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms
Imports System.Text.RegularExpressions

''' <summary>
''' ULTRA-MODERN MENU MANAGEMENT - PROFESSIONAL GRADE
''' Premium UI/UX with glassmorphism, gradients, and smooth animations
''' </summary>
Public Class Manage_menu
    ' ===== PRIVATE FIELDS =====
    Private currentCategory As String = "Foods"
    Private currentCategoryTable As String = "Foods"
    Private allMenuItems As New List(Of MenuItemData)
    Private displayedCards As New List(Of MenuItemCard)
    Private categoryButtons As New List(Of Guna2Button)
    Private navButtons As AdminNavButtons
    Private searchTimer As Timer
    Private currentSort As String = "All Items"
    Private isLoading As Boolean = False
    Private glowTimer As Timer
    Private glowDirection As Integer = 1

    Private hasShownRuntimeError As Boolean = False
    Private shownLoadError As Boolean = False

    ' ===== MENU ITEM DATA STRUCTURE =====
    Private Class MenuItemData
        Public Property ItemId As Integer
        Public Property ItemName As String
        Public Property ItemPrice As Decimal
        Public Property ImagePath As String
        Public Property CategoryTable As String
        Public Property DateAdded As DateTime
    End Class

    ' ===== CONTROL LOAD =====
    Private Sub Manage_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim parentForm As Form = Me.FindForm()
            If parentForm IsNot Nothing Then
                If TypeOf parentForm Is Admin Then
                    navButtons = New AdminNavButtons(parentForm, btnLogout, btnBack, btnHelp, Nothing)
                End If
                Me.AutoScaleMode = AutoScaleMode.Inherit
            Else
                Me.AutoScaleMode = AutoScaleMode.Font
            End If

            If searchTimer Is Nothing Then
                searchTimer = New Timer()
                searchTimer.Interval = 300
                AddHandler searchTimer.Tick, AddressOf SearchTimer_Tick
            End If

            ApplyUltraModernStyling()
            StartTitleGlowAnimation()
            LoadCategoryTabs()
            LoadMenuItems(currentCategoryTable)
            AnimateEntrance()

        Catch ex As Exception
            MessageBox.Show("Error initializing control: " & ex.Message, "Initialization Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Apply ultra-modern professional styling
    ''' </summary>
    Private Sub ApplyUltraModernStyling()
        ' Control styling
        Me.BackColor = Theme.NeutralBackground

        ' Main content area - subtle gradient
        pnlMain.FillColor = Theme.NeutralBackground

        ' Loading overlay - frosted glass effect
        pnlLoadingOverlay.FillColor = Color.FromArgb(240, Theme.NeutralBackground.R,
                                                       Theme.NeutralBackground.G,
                                                       Theme.NeutralBackground.B)

        ' Add subtle shine to category tabs container
        flowCategoryTabs.BackColor = Color.Transparent
    End Sub

    ''' <summary>
    ''' Animated glow effect on title
    ''' </summary>
    Private Sub StartTitleGlowAnimation()
        glowTimer = New Timer()
        glowTimer.Interval = 30
        Dim glowIntensity As Integer = 40

        AddHandler glowTimer.Tick, Sub()
                                       glowIntensity += (2 * glowDirection)

                                       If glowIntensity >= 80 Then
                                           glowDirection = -1
                                       ElseIf glowIntensity <= 40 Then
                                           glowDirection = 1
                                       End If

                                       Try
                                           pnlTitleGlow.FillColor = Color.FromArgb(glowIntensity, 255, 200, 87)
                                       Catch
                                       End Try
                                   End Sub
        glowTimer.Start()
    End Sub

    ''' <summary>
    ''' Enhanced entrance animation with stagger
    ''' </summary>
    Private Sub AnimateEntrance()
        pnlTopBar.Top = -164

        Dim fadeTimer As New Timer()
        fadeTimer.Interval = 12
        Dim steps As Integer = 0

        AddHandler fadeTimer.Tick, Sub()
                                       steps += 1

                                       If pnlTopBar.Top < 0 Then
                                           pnlTopBar.Top = Math.Min(0, pnlTopBar.Top + 12)
                                       End If

                                       If steps >= 15 Then
                                           pnlTopBar.Top = 0
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()
                                           AnimateContentEntrance()
                                       End If
                                   End Sub
        fadeTimer.Start()
    End Sub

    ''' <summary>
    ''' Animate content cards with enhanced stagger
    ''' </summary>
    Private Sub AnimateContentEntrance()
        For i As Integer = 0 To displayedCards.Count - 1
            Dim card = displayedCards(i)
            Dim delay = i * 60

            Dim timer As New Timer()
            timer.Interval = If(delay <= 0, 1, delay)
            timer.Tag = card

            AddHandler timer.Tick, Sub(s, e)
                                       Try
                                           Dim c = CType(CType(s, Timer).Tag, MenuItemCard)
                                           c.Visible = True
                                           AnimateCardSlideUp(c)
                                       Catch ex As Exception
                                           If Not hasShownRuntimeError Then
                                               hasShownRuntimeError = True
                                               MessageBox.Show("Animation error: " & ex.Message,
                                                               "Animation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                           End If
                                       Finally
                                           Try
                                               CType(s, Timer).Stop()
                                               CType(s, Timer).Dispose()
                                           Catch
                                           End Try
                                       End Try
                                   End Sub
            timer.Start()
        Next
    End Sub

    Private Sub AnimateCardSlideUp(card As MenuItemCard)
        Dim originalY = card.Top
        card.Top = originalY + 40

        Dim slideTimer As New Timer()
        slideTimer.Interval = 8
        Dim steps As Integer = 0

        AddHandler slideTimer.Tick, Sub()
                                        steps += 1
                                        If card.Top > originalY Then
                                            card.Top = Math.Max(originalY, card.Top - 4)
                                        Else
                                            card.Top = originalY
                                            slideTimer.Stop()
                                            slideTimer.Dispose()
                                        End If
                                    End Sub
        slideTimer.Start()
    End Sub

    ' ===== CATEGORY TAB MANAGEMENT - ULTRA MODERN =====
    Private Sub LoadCategoryTabs()
        Try
            flowCategoryTabs.Controls.Clear()
            categoryButtons.Clear()

            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()
                Dim query As String = "SELECT CategoryName FROM Categories ORDER BY CategoryName"

                Using command As New MySqlCommand(query, connection)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim categoryName As String = reader("CategoryName").ToString()
                            Dim safeName As String = Regex.Replace(categoryName.Trim(), "[^A-Za-z0-9_]", "_")
                            If String.IsNullOrWhiteSpace(safeName) Then safeName = "Category_" & Guid.NewGuid().ToString("N").Substring(0, 6)
                            CreateModernCategoryTab(categoryName, safeName)
                        End While
                    End Using
                End Using
            End Using

            If categoryButtons.Count > 0 Then
                SetActiveCategoryTab(categoryButtons(0))
                Dim t = CType(categoryButtons(0).Tag, Tuple(Of String, String))
                currentCategory = t.Item1
                currentCategoryTable = t.Item2
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            CreateModernCategoryTab("Foods", "Foods")
            CreateModernCategoryTab("Drinks", "Drinks")
            CreateModernCategoryTab("Snacks/Sides", "Snacks_Sides")
            CreateModernCategoryTab("Desserts", "Desserts")

            If categoryButtons.Count > 0 Then
                SetActiveCategoryTab(categoryButtons(0))
                Dim t = CType(categoryButtons(0).Tag, Tuple(Of String, String))
                currentCategory = t.Item1
                currentCategoryTable = t.Item2
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Create ultra-modern category tab with glassmorphism
    ''' </summary>
    Private Sub CreateModernCategoryTab(categoryDisplayName As String, safeTableName As String)
        Dim btnCategory As New Guna2Button()

        With btnCategory
            .Size = New Size(140, 48)
            .BorderRadius = 24 ' More rounded
            .Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .Text = GetCategoryIcon(categoryDisplayName) & " " & categoryDisplayName
            .Tag = Tuple.Create(categoryDisplayName, safeTableName)
            .Animated = True
            .Margin = New Padding(6, 0, 6, 0)

            ' Inactive state - glassmorphism
            .FillColor = Color.FromArgb(30, 255, 255, 255)
            .BorderColor = Color.FromArgb(60, 255, 255, 255)
            .BorderThickness = 2
            .ForeColor = Color.White

            ' Hover state - brighter glass
            .HoverState.FillColor = Color.FromArgb(50, 255, 255, 255)
            .HoverState.BorderColor = Color.FromArgb(100, 255, 255, 255)

            ' Shadow
            .ShadowDecoration.Enabled = False
        End With

        AddHandler btnCategory.Click, AddressOf CategoryTab_Click
        flowCategoryTabs.Controls.Add(btnCategory)
        categoryButtons.Add(btnCategory)
    End Sub

    Private Function GetCategoryIcon(categoryName As String) As String
        Select Case categoryName.ToLower()
            Case "foods"
                Return "🍔"
            Case "pizza"
                Return "🍕"
            Case "snacks/sides", "snacks"
                Return "🍟"
            Case "drinks"
                Return "☕"
            Case "desserts"
                Return "🍦"
            Case Else
                Return "🍽️"
        End Select
    End Function

    Private Sub CategoryTab_Click(sender As Object, e As EventArgs)
        Dim clickedButton = CType(sender, Guna2Button)
        SetActiveCategoryTab(clickedButton)

        Dim tuple = CType(clickedButton.Tag, Tuple(Of String, String))
        currentCategory = tuple.Item1
        currentCategoryTable = tuple.Item2

        FadeOutCards()

        Dim loadTimer As New Timer()
        loadTimer.Interval = 250
        AddHandler loadTimer.Tick, Sub()
                                       LoadMenuItems(currentCategoryTable)
                                       loadTimer.Stop()
                                       loadTimer.Dispose()
                                   End Sub
        loadTimer.Start()
    End Sub

    ''' <summary>
    ''' Ultra-modern active tab styling with gradient
    ''' </summary>
    Private Sub SetActiveCategoryTab(activeButton As Guna2Button)
        For Each btn In categoryButtons
            btn.FillColor = Color.FromArgb(30, 255, 255, 255)
            btn.BorderColor = Color.FromArgb(60, 255, 255, 255)
            btn.BorderThickness = 2
            btn.ForeColor = Color.White
            btn.ShadowDecoration.Enabled = False
        Next

        With activeButton
            .FillColor = Color.FromArgb(255, 200, 87)
            .BorderColor = Color.FromArgb(255, 200, 87)
            .BorderThickness = 0
            .ForeColor = Color.FromArgb(30, 30, 30)
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 15
            .ShadowDecoration.Color = Color.FromArgb(100, 255, 200, 87)
        End With
    End Sub

    ' ===== MENU ITEMS LOADING =====
    Private Sub LoadMenuItems(categoryTable As String)
        If isLoading Then Return

        Try
            isLoading = True
            ShowLoadingOverlay()

            allMenuItems.Clear()
            displayedCards.Clear()
            flowMenuItems.Controls.Clear()

            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                Dim query As String = "SELECT ItemId, ItemName, ItemPrice, ImagePath, " &
                                      "COALESCE(DateAdded, NOW()) as DateAdded " &
                                      "FROM `" & categoryTable & "` ORDER BY ItemName"

                Using command As New MySqlCommand(query, connection)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Try
                                Dim itemId As Integer = 0
                                Dim itemName As String = String.Empty
                                Dim itemPrice As Decimal = 0D
                                Dim imagePath As String = String.Empty
                                Dim dateAdded As DateTime = DateTime.Now

                                Try
                                    Dim idx = reader.GetOrdinal("ItemId")
                                    If Not reader.IsDBNull(idx) Then itemId = Convert.ToInt32(reader.GetValue(idx))
                                Catch ex As Exception
                                    Throw New Exception("Missing or invalid ItemId column: " & ex.Message, ex)
                                End Try

                                Try
                                    Dim idx = reader.GetOrdinal("ItemName")
                                    If Not reader.IsDBNull(idx) Then itemName = reader.GetString(idx)
                                Catch
                                End Try

                                Try
                                    Dim idx = reader.GetOrdinal("ItemPrice")
                                    If Not reader.IsDBNull(idx) Then itemPrice = Convert.ToDecimal(reader.GetValue(idx))
                                Catch
                                End Try

                                Try
                                    Dim idx = reader.GetOrdinal("ImagePath")
                                    If Not reader.IsDBNull(idx) Then imagePath = reader.GetString(idx)
                                Catch
                                End Try

                                Try
                                    Dim idx = reader.GetOrdinal("DateAdded")
                                    If Not reader.IsDBNull(idx) Then dateAdded = Convert.ToDateTime(reader.GetValue(idx))
                                Catch
                                End Try

                                If String.IsNullOrWhiteSpace(imagePath) OrElse imagePath = "N/A" Then imagePath = String.Empty

                                allMenuItems.Add(New MenuItemData() With {
                                    .ItemId = itemId,
                                    .ItemName = itemName,
                                    .ItemPrice = itemPrice,
                                    .ImagePath = imagePath,
                                    .CategoryTable = categoryTable,
                                    .DateAdded = dateAdded
                                })
                            Catch rowEx As Exception
                                If Not shownLoadError Then
                                    shownLoadError = True
                                    MessageBox.Show("Error loading menu items: " & rowEx.Message, "Database Error",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                                Exit While
                            End Try
                        End While
                    End Using
                End Using
            End Using

            ApplySortFilter()
            CreateMenuCards()
            HideLoadingOverlay()
            isLoading = False

        Catch ex As MySqlException
            HideLoadingOverlay()
            isLoading = False
            If Not shownLoadError Then
                shownLoadError = True
                MessageBox.Show("Database error loading menu items: " & ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            HideLoadingOverlay()
            isLoading = False
            If Not shownLoadError Then
                shownLoadError = True
                MessageBox.Show("Error loading menu items: " & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub CreateMenuCards()
        flowMenuItems.SuspendLayout()

        For Each itemData In allMenuItems
            Dim card As New MenuItemCard()
            card.SetCardData(itemData.ItemId, itemData.ItemName, itemData.ItemPrice,
                             itemData.ImagePath, itemData.CategoryTable, itemData.DateAdded)
            card.Margin = New Padding(12)
            card.Visible = False

            AddHandler card.SaveRequested, AddressOf Card_SaveRequested
            AddHandler card.DeleteRequested, AddressOf Card_DeleteRequested
            AddHandler card.ImageChangeRequested, AddressOf Card_ImageChangeRequested

            flowMenuItems.Controls.Add(card)
            displayedCards.Add(card)
        Next

        If allMenuItems.Count = 0 Then
            ShowEmptyState()
        End If

        flowMenuItems.ResumeLayout()
        AnimateContentEntrance()
    End Sub

    Private Sub ShowEmptyState()
        Dim lblEmpty As New Label()
        lblEmpty.Text = "✨ No items in this category yet" & vbCrLf & vbCrLf &
                        "Click 'Add New' to create your first item"
        lblEmpty.Font = New Font("Segoe UI Semibold", 15.0F, FontStyle.Regular)
        lblEmpty.ForeColor = Color.FromArgb(120, 120, 120)
        lblEmpty.TextAlign = ContentAlignment.MiddleCenter
        lblEmpty.AutoSize = False
        lblEmpty.Size = New Size(450, 140)
        lblEmpty.Location = New Point((flowMenuItems.Width - 450) \ 2, 180)
        flowMenuItems.Controls.Add(lblEmpty)
    End Sub

    Private Sub ShowLoadingOverlay()
        pnlLoadingOverlay.Visible = True
        pnlLoadingOverlay.BringToFront()

        Dim progressTimer As New Timer()
        progressTimer.Interval = 25
        Dim progressValue As Integer = 0

        AddHandler progressTimer.Tick, Sub()
                                           progressValue = (progressValue + 5) Mod 100
                                           pbLoadingSpinner.Value = progressValue
                                       End Sub
        progressTimer.Start()
        pnlLoadingOverlay.Tag = progressTimer
    End Sub

    Private Sub HideLoadingOverlay()
        If pnlLoadingOverlay.Tag IsNot Nothing Then
            Dim timer = CType(pnlLoadingOverlay.Tag, Timer)
            Try
                timer.Stop()
                timer.Dispose()
            Catch
            End Try
            pnlLoadingOverlay.Tag = Nothing
        End If

        pnlLoadingOverlay.Visible = False
    End Sub

    ' ===== CARD EVENT HANDLERS =====
    Private Sub Card_SaveRequested(itemId As Integer, newName As String, newPrice As Decimal, newImagePath As String)
        Try
            Using connection As New MySqlConnection(GetGlobalConnectionString())
                connection.Open()

                Dim query As String = "UPDATE `" & currentCategoryTable & "` " &
                                      "SET ItemName = @name, ItemPrice = @price, ImagePath = @imagePath " &
                                      "WHERE ItemId = @id"

                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@name", newName)
                    command.Parameters.AddWithValue("@price", newPrice)
                    command.Parameters.AddWithValue("@imagePath", If(String.IsNullOrEmpty(newImagePath), "N/A", newImagePath))
                    command.Parameters.AddWithValue("@id", itemId)

                    Dim rowsAffected = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        ShowSuccessToast("✨ Item updated successfully!")

                        Dim itemData = allMenuItems.FirstOrDefault(Function(x) x.ItemId = itemId)
                        If itemData IsNot Nothing Then
                            itemData.ItemName = newName
                            itemData.ItemPrice = newPrice
                            itemData.ImagePath = newImagePath
                        End If
                    Else
                        MessageBox.Show("Failed to update item.", "Update Failed",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating item: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Card_DeleteRequested(itemId As Integer, itemName As String)
        Dim result = MessageBox.Show(
            $"Are you sure you want to delete '{itemName}'?" & vbCrLf & vbCrLf &
            "This action cannot be undone.",
            "Confirm Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(GetGlobalConnectionString())
                    connection.Open()

                    Dim query As String = "DELETE FROM `" & currentCategoryTable & "` WHERE ItemId = @id"

                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.AddWithValue("@id", itemId)

                        Dim rowsAffected = command.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            ShowSuccessToast("🗑️ Item deleted successfully!")

                            Dim card = displayedCards.FirstOrDefault(Function(c) c.ItemId = itemId)
                            If card IsNot Nothing Then
                                AnimateCardFadeOut(card)
                            End If

                            allMenuItems.RemoveAll(Function(x) x.ItemId = itemId)
                        Else
                            MessageBox.Show("Failed to delete item.", "Delete Failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting item: " & ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Card_ImageChangeRequested(itemId As Integer, ByRef newImagePath As String)
        Using fileDialog As New OpenFileDialog()
            fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*"
            fileDialog.Title = "Select Item Image"

            If fileDialog.ShowDialog() = DialogResult.OK Then
                newImagePath = fileDialog.FileName
            End If
        End Using
    End Sub

    Private Sub AnimateCardFadeOut(card As MenuItemCard)
        Dim fadeTimer As New Timer()
        fadeTimer.Interval = 15
        Dim steps As Integer = 0
        Dim originalSize = card.Size

        AddHandler fadeTimer.Tick, Sub()
                                       steps += 1

                                       Dim scale = 1.0 - (steps * 0.06)
                                       If scale > 0.4 Then
                                           card.Size = New Size(CInt(originalSize.Width * scale),
                                                                CInt(originalSize.Height * scale))
                                       Else
                                           flowMenuItems.Controls.Remove(card)
                                           displayedCards.Remove(card)
                                           card.Dispose()
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()
                                       End If
                                   End Sub
        fadeTimer.Start()
    End Sub

    ' ===== SEARCH FUNCTIONALITY =====
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            If searchTimer Is Nothing Then
                searchTimer = New Timer()
                searchTimer.Interval = 300
                AddHandler searchTimer.Tick, AddressOf SearchTimer_Tick
            End If

            searchTimer.Stop()
            searchTimer.Start()
        Catch ex As Exception
            If Not hasShownRuntimeError Then
                hasShownRuntimeError = True
                MessageBox.Show("Search handler error: " & ex.Message, "Runtime Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Try
                ApplySearchFilter()
            Catch
            End Try
        End Try
    End Sub

    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs)
        Try
            searchTimer?.Stop()
            ApplySearchFilter()
        Catch ex As Exception
            If Not hasShownRuntimeError Then
                hasShownRuntimeError = True
                MessageBox.Show("Search timer error: " & ex.Message, "Runtime Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub ApplySearchFilter()
        Dim searchText = ""
        Try
            searchText = If(txtSearch IsNot Nothing, txtSearch.Text.Trim().ToLower(), "")
        Catch
            searchText = ""
        End Try

        If String.IsNullOrEmpty(searchText) Then
            For Each card In displayedCards
                card.Visible = True
            Next
        Else
            For Each card In displayedCards
                Dim matches = False
                Try
                    matches = card.ItemName.ToLower().Contains(searchText)
                Catch
                End Try
                card.Visible = matches
            Next
        End If
    End Sub

    ' ===== SORT/FILTER FUNCTIONALITY =====
    Private Sub cmbSortFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSortFilter.SelectedIndexChanged
        currentSort = cmbSortFilter.SelectedItem.ToString()
        ApplySortFilter()

        flowMenuItems.Controls.Clear()
        displayedCards.Clear()
        CreateMenuCards()
    End Sub

    Private Sub ApplySortFilter()
        Select Case currentSort
            Case "All Items"
                ' No filtering

            Case "New Items"
                Dim thirtyDaysAgo = DateTime.Now.AddDays(-30)
                allMenuItems = allMenuItems.Where(Function(x) x.DateAdded >= thirtyDaysAgo).ToList()

            Case "Price: Low to High"
                allMenuItems = allMenuItems.OrderBy(Function(x) x.ItemPrice).ToList()

            Case "Price: High to Low"
                allMenuItems = allMenuItems.OrderByDescending(Function(x) x.ItemPrice).ToList()
        End Select
    End Sub

    ' ===== ADD NEW ITEM =====
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Using addCtrl As New AddMenuItemDialog(currentCategory)
            Dim hostForm As New Form()
            hostForm.FormBorderStyle = FormBorderStyle.FixedDialog
            hostForm.StartPosition = FormStartPosition.CenterParent
            hostForm.MinimizeBox = False
            hostForm.MaximizeBox = False
            hostForm.ShowInTaskbar = False
            hostForm.AutoScaleMode = AutoScaleMode.None

            If addCtrl.Width > 0 AndAlso addCtrl.Height > 0 Then
                hostForm.ClientSize = addCtrl.Size
            Else
                hostForm.ClientSize = New Size(Math.Max(600, Me.Width \ 2), Math.Max(400, Me.Height \ 2))
            End If

            addCtrl.Dock = DockStyle.Fill
            hostForm.Controls.Add(addCtrl)
            hostForm.BackColor = Me.BackColor

            If hostForm.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                ShowSuccessToast("✨ New item added successfully!")
                LoadMenuItems(currentCategoryTable)
                NotifyOrderingForms()
            End If
        End Using
    End Sub

    Private Sub NotifyOrderingForms()
        Try
            For Each f As Form In Application.OpenForms
                If f Is Nothing Then Continue For
                Dim tName = f.GetType().Name
                If String.Equals(tName, "Ordering_Form", StringComparison.OrdinalIgnoreCase) OrElse String.Equals(tName, "OrderingForm", StringComparison.OrdinalIgnoreCase) Then
                    Dim mi = f.GetType().GetMethod("ReloadMenuItems", Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance)
                    If mi IsNot Nothing Then
                        mi.Invoke(f, Nothing)
                        Continue For
                    End If

                    mi = f.GetType().GetMethod("RefreshMenu", Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance)
                    If mi IsNot Nothing Then
                        mi.Invoke(f, Nothing)
                        Continue For
                    End If

                    mi = f.GetType().GetMethod("RefreshMenuItems", Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance)
                    If mi IsNot Nothing Then
                        mi.Invoke(f, Nothing)
                        Continue For
                    End If
                End If
            Next
        Catch
        End Try
    End Sub

    ' ===== ANIMATION HELPERS =====
    Private Sub FadeOutCards()
        For Each card In displayedCards
            Dim fadeTimer As New Timer()
            fadeTimer.Interval = 8
            fadeTimer.Tag = card

            AddHandler fadeTimer.Tick, Sub(s, ev)
                                           Dim c = CType(CType(s, Timer).Tag, MenuItemCard)
                                           If c.Visible Then
                                               c.Visible = False
                                           End If
                                           CType(s, Timer).Stop()
                                           CType(s, Timer).Dispose()
                                       End Sub
            fadeTimer.Start()
        Next
    End Sub

    ''' <summary>
    ''' Ultra-modern success toast with gradient
    ''' </summary>
    Private Sub ShowSuccessToast(message As String)
        Dim toast As New Guna2GradientPanel()
        toast.Size = New Size(380, 70)
        toast.Location = New Point(Me.Width - 400, Me.Height - 90)
        toast.FillColor = Color.FromArgb(31, 138, 112)
        toast.FillColor2 = Color.FromArgb(46, 204, 113)
        toast.GradientMode = LinearGradientMode.Horizontal
        toast.BorderRadius = 16
        toast.ShadowDecoration.Enabled = True
        toast.ShadowDecoration.Depth = 20
        toast.ShadowDecoration.Color = Color.FromArgb(100, 31, 138, 112)

        Dim lblMessage As New Label()
        lblMessage.Text = message
        lblMessage.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold)
        lblMessage.ForeColor = Color.White
        lblMessage.AutoSize = False
        lblMessage.Size = New Size(360, 50)
        lblMessage.Location = New Point(10, 10)
        lblMessage.TextAlign = ContentAlignment.MiddleLeft

        toast.Controls.Add(lblMessage)
        Me.Controls.Add(toast)
        toast.BringToFront()

        ' Slide in animation
        Dim slideInTimer As New Timer()
        slideInTimer.Interval = 10
        Dim startX = Me.Width
        toast.Left = startX
        Dim targetX = Me.Width - 400

        AddHandler slideInTimer.Tick, Sub()
                                          If toast.Left > targetX Then
                                              toast.Left -= 15
                                          Else
                                              toast.Left = targetX
                                              slideInTimer.Stop()
                                              slideInTimer.Dispose()
                                          End If
                                      End Sub
        slideInTimer.Start()

        ' Auto-hide after 3 seconds
        Dim hideTimer As New Timer()
        hideTimer.Interval = 3000
        hideTimer.Tag = toast

        AddHandler hideTimer.Tick, Sub(s, ev)
                                       Dim t = CType(CType(s, Timer).Tag, Guna2GradientPanel)

                                       ' Slide out animation
                                       Dim slideOutTimer As New Timer()
                                       slideOutTimer.Interval = 10
                                       slideOutTimer.Tag = t

                                       AddHandler slideOutTimer.Tick, Sub(s2, ev2)
                                                                          Dim panel = CType(CType(s2, Timer).Tag, Guna2GradientPanel)
                                                                          If panel.Left < Me.Width Then
                                                                              panel.Left += 15
                                                                          Else
                                                                              Me.Controls.Remove(panel)
                                                                              panel.Dispose()
                                                                              CType(s2, Timer).Stop()
                                                                              CType(s2, Timer).Dispose()
                                                                          End If
                                                                      End Sub
                                       slideOutTimer.Start()

                                       CType(s, Timer).Stop()
                                       CType(s, Timer).Dispose()
                                   End Sub
        hideTimer.Start()
    End Sub

    ' ===== CLEANUP ====
End Class