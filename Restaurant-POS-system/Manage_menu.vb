Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms
Imports System.Text.RegularExpressions

''' <summary>
''' ULTRA-MODERN MENU MANAGEMENT FORM
''' Enterprise-grade UI with card-based layout, smooth animations, and inline editing
''' Redesigned from ground up to match 2025 standards
''' </summary>
Public Class Manage_menu
    ' ===== PRIVATE FIELDS =====
    Private currentCategory As String = "Foods"               ' display name
    Private currentCategoryTable As String = "Foods"         ' safe table name
    Private allMenuItems As New List(Of MenuItemData)
    Private displayedCards As New List(Of MenuItemCard)
    Private categoryButtons As New List(Of Guna2Button)
    Private navButtons As AdminNavButtons
    Private searchTimer As Timer
    Private currentSort As String = "All Items"
    Private isLoading As Boolean = False

    ' Prevent the same runtime error message from spamming repeatedly
    Private hasShownRuntimeError As Boolean = False
    Private shownLoadError As Boolean = False ' guard to avoid infinite spam of load errors

    ' ===== MENU ITEM DATA STRUCTURE =====
    Private Class MenuItemData
        Public Property ItemId As Integer
        Public Property ItemName As String
        Public Property ItemPrice As Decimal
        Public Property ImagePath As String
        Public Property CategoryTable As String
        Public Property DateAdded As DateTime
    End Class

    ' ===== FORM LOAD =====
    Private Sub Manage_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized

            ' Initialize navigation buttons
            navButtons = New AdminNavButtons(Me, btnLogout, btnBack, btnHelp, Nothing)

            ' Setup search timer for debouncing (ensure it's always available)
            If searchTimer Is Nothing Then
                searchTimer = New Timer()
                searchTimer.Interval = 300 ' 300ms debounce
                AddHandler searchTimer.Tick, AddressOf SearchTimer_Tick
            End If

            ' Apply premium styling
            ApplyPremiumStyling()

            ' Load categories and create tabs
            LoadCategoryTabs()

            ' Load initial category items
            LoadMenuItems(currentCategoryTable)

            ' Start entrance animation
            AnimateEntrance()

        Catch ex As Exception
            MessageBox.Show("Error initializing form: " & ex.Message, "Initialization Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Apply premium enterprise styling to all components
    ''' </summary>
    Private Sub ApplyPremiumStyling()
        ' Form styling
        Me.BackColor = Theme.NeutralBackground

        ' Top bar styling is already handled by Designer
        ' Apply additional runtime styling if needed

        ' Main content area styling
        pnlMain.FillColor = Theme.NeutralBackground

        ' Loading overlay styling
        pnlLoadingOverlay.FillColor = Color.FromArgb(200, Theme.NeutralBackground.R,
                                                       Theme.NeutralBackground.G,
                                                       Theme.NeutralBackground.B)
    End Sub

    ''' <summary>
    ''' Cinematic entrance animation
    ''' </summary>
    Private Sub AnimateEntrance()
        Me.Opacity = 0
        pnlTopBar.Top = -120

        Dim fadeTimer As New Timer()
        fadeTimer.Interval = 15
        Dim steps As Integer = 0

        AddHandler fadeTimer.Tick, Sub()
                                       steps += 1

                                       ' Fade in form
                                       If Me.Opacity < 1 Then
                                           Me.Opacity = Math.Min(1, Me.Opacity + 0.05)
                                       End If

                                       ' Slide down top bar
                                       If pnlTopBar.Top < 0 Then
                                           pnlTopBar.Top = Math.Min(0, pnlTopBar.Top + 10)
                                       End If

                                       ' Complete animation
                                       If steps >= 20 Then
                                           Me.Opacity = 1
                                           pnlTopBar.Top = 0
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()

                                           ' Trigger content entrance
                                           AnimateContentEntrance()
                                       End If
                                   End Sub
        fadeTimer.Start()
    End Sub

    ''' <summary>
    ''' Animate content cards entrance with stagger
    ''' NOTE: Timer.Interval must be > 0. guard against 0 by using at least 1.
    ''' Also wrap handler to avoid unhandled exceptions that spam the dialog.
    ''' </summary>
    Private Sub AnimateContentEntrance()
        For i As Integer = 0 To displayedCards.Count - 1
            Dim card = displayedCards(i)
            Dim delay = i * 50 ' 50ms stagger per card

            Dim timer As New Timer()
            ' Timer.Interval must be > 0; use 1ms for immediate execution when delay is 0
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

    ''' <summary>
    ''' Animate single card slide up from bottom
    ''' </summary>
    Private Sub AnimateCardSlideUp(card As MenuItemCard)
        Dim originalY = card.Top
        card.Top = originalY + 30

        Dim slideTimer As New Timer()
        slideTimer.Interval = 10
        Dim steps As Integer = 0

        AddHandler slideTimer.Tick, Sub()
                                        steps += 1
                                        If card.Top > originalY Then
                                            card.Top = Math.Max(originalY, card.Top - 3)
                                        Else
                                            card.Top = originalY
                                            slideTimer.Stop()
                                            slideTimer.Dispose()
                                        End If
                                    End Sub
        slideTimer.Start()
    End Sub

    ' ===== CATEGORY TAB MANAGEMENT =====
    ''' <summary>
    ''' Load category tabs from database and create UI buttons
    ''' </summary>
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
                            CreateCategoryTab(categoryName, safeName)
                        End While
                    End Using
                End Using
            End Using

            ' Set first category as active
            If categoryButtons.Count > 0 Then
                SetActiveCategoryTab(categoryButtons(0))
                ' initialize currentCategory/currentCategoryTable from first button
                Dim t = CType(categoryButtons(0).Tag, Tuple(Of String, String))
                currentCategory = t.Item1
                currentCategoryTable = t.Item2
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Fallback categories (create with safe names)
            CreateCategoryTab("Foods", Regex.Replace("Foods", "[^A-Za-z0-9_]", "_"))
            CreateCategoryTab("Drinks", Regex.Replace("Drinks", "[^A-Za-z0-9_]", "_"))
            CreateCategoryTab("Snacks/Sides", Regex.Replace("Snacks_Sides", "[^A-Za-z0-9_]", "_"))
            CreateCategoryTab("Desserts", Regex.Replace("Desserts", "[^A-Za-z0-9_]", "_"))

            If categoryButtons.Count > 0 Then
                SetActiveCategoryTab(categoryButtons(0))
                Dim t = CType(categoryButtons(0).Tag, Tuple(Of String, String))
                currentCategory = t.Item1
                currentCategoryTable = t.Item2
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Create a single category tab button
    ''' </summary>
    Private Sub CreateCategoryTab(categoryDisplayName As String, safeTableName As String)
        Dim btnCategory As New Guna2Button()

        With btnCategory
            .Size = New Size(130, 40)
            .BorderRadius = 20 ' Pill shape
            .Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .Text = GetCategoryIcon(categoryDisplayName) & " " & categoryDisplayName
            ' store display and safe name as a tuple in Tag
            .Tag = Tuple.Create(categoryDisplayName, safeTableName)
            .Animated = True
            .Margin = New Padding(5, 0, 5, 0)

            ' Inactive state (default)
            .FillColor = Color.Transparent
            .BorderColor = Theme.LightBorder
            .BorderThickness = 2
            .ForeColor = Theme.GrayText

            ' Hover state
            .HoverState.FillColor = Color.FromArgb(20, Theme.PrimaryAccent.R,
                                                     Theme.PrimaryAccent.G,
                                                     Theme.PrimaryAccent.B)
            .HoverState.BorderColor = Theme.PrimaryAccent

            ' Shadow
            .ShadowDecoration.Enabled = False ' Only show shadow when active
        End With

        AddHandler btnCategory.Click, AddressOf CategoryTab_Click
        flowCategoryTabs.Controls.Add(btnCategory)
        categoryButtons.Add(btnCategory)
    End Sub

    ''' <summary>
    ''' Get emoji icon for category
    ''' </summary>
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

    ''' <summary>
    ''' Handle category tab click
    ''' </summary>
    Private Sub CategoryTab_Click(sender As Object, e As EventArgs)
        Dim clickedButton = CType(sender, Guna2Button)
        SetActiveCategoryTab(clickedButton)

        Dim tuple = CType(clickedButton.Tag, Tuple(Of String, String))
        currentCategory = tuple.Item1
        currentCategoryTable = tuple.Item2

        ' Load items with fade transition
        FadeOutCards()

        Dim loadTimer As New Timer()
        loadTimer.Interval = 300 ' Wait for fade out
        AddHandler loadTimer.Tick, Sub()
                                       LoadMenuItems(currentCategoryTable)
                                       loadTimer.Stop()
                                       loadTimer.Dispose()
                                   End Sub
        loadTimer.Start()
    End Sub

    ''' <summary>
    ''' Set active category tab with visual feedback
    ''' </summary>
    Private Sub SetActiveCategoryTab(activeButton As Guna2Button)
        ' Reset all buttons to inactive state
        For Each btn In categoryButtons
            btn.FillColor = Color.Transparent
            btn.BorderColor = Theme.LightBorder
            btn.BorderThickness = 2
            btn.ForeColor = Theme.GrayText
            btn.ShadowDecoration.Enabled = False
        Next

        ' Set active button style
        With activeButton
            .FillColor = Theme.PrimaryAccent
            .BorderColor = Theme.PrimaryAccent
            .BorderThickness = 0
            .ForeColor = Theme.DarkText
            .ShadowDecoration.Enabled = True
            .ShadowDecoration.Depth = 8
            .ShadowDecoration.Color = Color.FromArgb(80, Theme.PrimaryAccent.R,
                                                       Theme.PrimaryAccent.G,
                                                       Theme.PrimaryAccent.B)
        End With
    End Sub

    ' ===== MENU ITEMS LOADING =====
    ''' <summary>
    ''' Load menu items from database for specified category
    ''' </summary>
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

                ' Query with DateAdded field (add if doesn't exist)
                Dim query As String = "SELECT ItemId, ItemName, ItemPrice, ImagePath, " &
                                      "COALESCE(DateAdded, NOW()) as DateAdded " &
                                      "FROM `" & categoryTable & "` ORDER BY ItemName"

                Using command As New MySqlCommand(query, connection)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Try
                                ' Safely read each column and handle DBNull
                                Dim itemId As Integer = 0
                                Dim itemName As String = String.Empty
                                Dim itemPrice As Decimal = 0D
                                Dim imagePath As String = String.Empty
                                Dim dateAdded As DateTime = DateTime.Now

                                Try
                                    Dim idx = reader.GetOrdinal("ItemId")
                                    If Not reader.IsDBNull(idx) Then itemId = Convert.ToInt32(reader.GetValue(idx))
                                Catch ex As Exception
                                    ' if field missing or cannot cast, skip row but continue
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

                                ' Normalize image path
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
                                ' Show load error once and stop loading further rows to avoid spamming
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

            ' Apply current sort/filter
            ApplySortFilter()

            ' Create cards for filtered items
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

    ''' <summary>
    ''' Create menu item cards from data
    ''' </summary>
    Private Sub CreateMenuCards()
        flowMenuItems.SuspendLayout()

        For Each itemData In allMenuItems
            Dim card As New MenuItemCard()
            card.SetCardData(itemData.ItemId, itemData.ItemName, itemData.ItemPrice,
                             itemData.ImagePath, itemData.CategoryTable, itemData.DateAdded)
            card.Margin = New Padding(10)
            card.Visible = False ' Hidden for entrance animation

            ' Wire up events
            AddHandler card.SaveRequested, AddressOf Card_SaveRequested
            AddHandler card.DeleteRequested, AddressOf Card_DeleteRequested
            AddHandler card.ImageChangeRequested, AddressOf Card_ImageChangeRequested

            flowMenuItems.Controls.Add(card)
            displayedCards.Add(card)
        Next

        ' Show empty state if no items
        If allMenuItems.Count = 0 Then
            ShowEmptyState()
        End If

        flowMenuItems.ResumeLayout()

        ' Trigger entrance animation
        AnimateContentEntrance()
    End Sub

    ''' <summary>
    ''' Show empty state when no items exist
    ''' </summary>
    Private Sub ShowEmptyState()
        Dim lblEmpty As New Label()
        lblEmpty.Text = "No items in this category yet" & vbCrLf & vbCrLf &
                        "Click '➕ Add New' to create your first item"
        lblEmpty.Font = New Font("Segoe UI", 14.0F, FontStyle.Italic)
        lblEmpty.ForeColor = Theme.GrayText
        lblEmpty.TextAlign = ContentAlignment.MiddleCenter
        lblEmpty.AutoSize = False
        lblEmpty.Size = New Size(400, 120)
        lblEmpty.Location = New Point((flowMenuItems.Width - 400) \ 2, 150)
        flowMenuItems.Controls.Add(lblEmpty)
    End Sub

    ''' <summary>
    ''' Show loading overlay
    ''' </summary>
    Private Sub ShowLoadingOverlay()
        pnlLoadingOverlay.Visible = True
        pnlLoadingOverlay.BringToFront()

        ' Animate progress bar
        Dim progressTimer As New Timer()
        progressTimer.Interval = 30
        Dim progressValue As Integer = 0

        AddHandler progressTimer.Tick, Sub()
                                           progressValue = (progressValue + 5) Mod 100
                                           pbLoadingSpinner.Value = progressValue
                                       End Sub
        progressTimer.Start()
        pnlLoadingOverlay.Tag = progressTimer ' Store for cleanup
    End Sub

    ''' <summary>
    ''' Hide loading overlay
    ''' </summary>
    Private Sub HideLoadingOverlay()
        ' Stop progress animation
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
    ''' <summary>
    ''' Handle card save request (update item)
    ''' </summary>
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
                        ShowSuccessToast("Item updated successfully!")

                        ' Update in-memory data
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

    ''' <summary>
    ''' Handle card delete request
    ''' </summary>
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
                            ShowSuccessToast("Item deleted successfully!")

                            ' Remove from UI with animation
                            Dim card = displayedCards.FirstOrDefault(Function(c) c.ItemId = itemId)
                            If card IsNot Nothing Then
                                AnimateCardFadeOut(card)
                            End If

                            ' Remove from data
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

    ''' <summary>
    ''' Handle image change request from card
    ''' </summary>
    Private Sub Card_ImageChangeRequested(itemId As Integer, ByRef newImagePath As String)
        Using fileDialog As New OpenFileDialog()
            fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*"
            fileDialog.Title = "Select Item Image"

            If fileDialog.ShowDialog() = DialogResult.OK Then
                newImagePath = fileDialog.FileName
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Animate card fade out and removal
    ''' </summary>
    Private Sub AnimateCardFadeOut(card As MenuItemCard)
        Dim fadeTimer As New Timer()
        fadeTimer.Interval = 20
        Dim steps As Integer = 0
        Dim originalSize = card.Size

        AddHandler fadeTimer.Tick, Sub()
                                       steps += 1

                                       ' Scale down
                                       Dim scale = 1.0 - (steps * 0.05)
                                       If scale > 0.5 Then
                                           card.Size = New Size(CInt(originalSize.Width * scale),
                                                                CInt(originalSize.Height * scale))
                                       Else
                                           ' Remove from UI
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
            ' Ensure searchTimer is initialized (TextChanged can fire before Load)
            If searchTimer Is Nothing Then
                searchTimer = New Timer()
                searchTimer.Interval = 300
                AddHandler searchTimer.Tick, AddressOf SearchTimer_Tick
            End If

            ' Debounce search
            searchTimer.Stop()
            searchTimer.Start()
        Catch ex As Exception
            ' Prevent spammed error dialogs by showing only once and falling back
            If Not hasShownRuntimeError Then
                hasShownRuntimeError = True
                MessageBox.Show("Search handler error: " & ex.Message, "Runtime Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' Safe fallback: apply filter immediately (best-effort)
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

    ''' <summary>
    ''' Apply search filter to displayed items
    ''' </summary>
    Private Sub ApplySearchFilter()
        Dim searchText = ""
        Try
            searchText = If(txtSearch IsNot Nothing, txtSearch.Text.Trim().ToLower(), "")
        Catch
            searchText = ""
        End Try

        If String.IsNullOrEmpty(searchText) Then
            ' Show all cards
            For Each card In displayedCards
                card.Visible = True
            Next
        Else
            ' Filter cards
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

        ' Reload display
        flowMenuItems.Controls.Clear()
        displayedCards.Clear()
        CreateMenuCards()
    End Sub

    ''' <summary>
    ''' Apply sort/filter to menu items
    ''' </summary>
    Private Sub ApplySortFilter()
        Select Case currentSort
            Case "All Items"
                ' No filtering, items already loaded

            Case "New Items"
                ' Filter items added within last 30 days
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
        ' AddMenuItemDialog is implemented as a UserControl. Host it in a modal Form so ShowDialog works.
        Using addCtrl As New AddMenuItemDialog(currentCategory)
            Dim hostForm As New Form()
            hostForm.FormBorderStyle = FormBorderStyle.FixedDialog
            hostForm.StartPosition = FormStartPosition.CenterParent
            hostForm.MinimizeBox = False
            hostForm.MaximizeBox = False
            hostForm.ShowInTaskbar = False
            hostForm.AutoScaleMode = AutoScaleMode.None

            ' Size the host to the control. If control has not been measured, set a reasonable default.
            If addCtrl.Width > 0 AndAlso addCtrl.Height > 0 Then
                hostForm.ClientSize = addCtrl.Size
            Else
                hostForm.ClientSize = New Size(Math.Max(600, Me.Width \ 2), Math.Max(400, Me.Height \ 2))
            End If

            addCtrl.Dock = DockStyle.Fill
            hostForm.Controls.Add(addCtrl)
            hostForm.BackColor = Me.BackColor

            If hostForm.ShowDialog(Me) = DialogResult.OK Then
                ShowSuccessToast("New item added successfully!")

                ' Reload current category (safe table name)
                LoadMenuItems(currentCategoryTable)

                ' Notify ordering form(s) to reload their menu if they expose a public refresh method
                NotifyOrderingForms()
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Notify any open Ordering_Form instances to reload menu data.
    ''' Uses reflection to avoid hard dependency.
    ''' </summary>
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
            ' Non-critical; do not surface to user
        End Try
    End Sub

    ' ===== ANIMATION HELPERS =====
    ''' <summary>
    ''' Fade out all cards
    ''' </summary>
    Private Sub FadeOutCards()
        For Each card In displayedCards
            Dim fadeTimer As New Timer()
            fadeTimer.Interval = 10
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
    ''' Show success toast notification
    ''' </summary>
    Private Sub ShowSuccessToast(message As String)
        Dim toast As New Guna2Panel()
        toast.Size = New Size(350, 60)
        toast.Location = New Point(Me.Width - 370, Me.Height - 80)
        toast.FillColor = Color.FromArgb(46, 204, 113)
        toast.BorderRadius = 12
        toast.ShadowDecoration.Enabled = True
        toast.ShadowDecoration.Depth = 15

        Dim lblMessage As New Label()
        lblMessage.Text = "✓ " & message
        lblMessage.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        lblMessage.ForeColor = Color.White
        lblMessage.AutoSize = False
        lblMessage.Size = New Size(330, 40)
        lblMessage.Location = New Point(10, 10)
        lblMessage.TextAlign = ContentAlignment.MiddleLeft

        toast.Controls.Add(lblMessage)
        Me.Controls.Add(toast)
        toast.BringToFront()

        ' Auto-hide after 3 seconds
        Dim hideTimer As New Timer()
        hideTimer.Interval = 3000
        hideTimer.Tag = toast

        AddHandler hideTimer.Tick, Sub(s, ev)
                                       Dim t = CType(CType(s, Timer).Tag, Guna2Panel)
                                       Me.Controls.Remove(t)
                                       t.Dispose()
                                       CType(s, Timer).Stop()
                                       CType(s, Timer).Dispose()
                                   End Sub
        hideTimer.Start()
    End Sub

    ' ===== CLEANUP =====
    Private Sub Manage_menu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Cleanup timers
        Try
            searchTimer?.Stop()
            searchTimer?.Dispose()
        Catch
        End Try

        ' Cleanup cards
        For Each card In displayedCards
            card.Dispose()
        Next
    End Sub
End Class