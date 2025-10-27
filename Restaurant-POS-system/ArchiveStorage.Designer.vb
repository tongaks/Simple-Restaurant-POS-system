<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ArchiveStorage
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnCloseArchive As Button
    Friend WithEvents txtSearchArchive As TextBox
    Friend WithEvents pnlArchiveCards As Panel

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
        pnlMain = New Panel()
        pnlArchiveCards = New Panel()
        txtSearchArchive = New TextBox()
        pnlHeader = New Panel()
        lblTitle = New Label()
        btnCloseArchive = New Button()
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
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Padding = New Padding(20)
        pnlMain.Size = New Size(937, 600)
        pnlMain.TabIndex = 0
        ' 
        ' pnlArchiveCards
        ' 
        pnlArchiveCards.AutoScroll = True
        pnlArchiveCards.BackColor = Color.White
        pnlArchiveCards.Location = New Point(20, 140)
        pnlArchiveCards.Name = "pnlArchiveCards"
        pnlArchiveCards.Size = New Size(860, 420)
        pnlArchiveCards.TabIndex = 0
        ' 
        ' txtSearchArchive
        ' 
        txtSearchArchive.Location = New Point(40, 100)
        txtSearchArchive.Name = "txtSearchArchive"
        txtSearchArchive.PlaceholderText = "Search archived accounts..."
        txtSearchArchive.Size = New Size(320, 27)
        txtSearchArchive.TabIndex = 1
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(37), CByte(42), CByte(52))
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(btnCloseArchive)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(20, 20)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(20)
        pnlHeader.Size = New Size(897, 80)
        pnlHeader.TabIndex = 2
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(20, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(271, 41)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Archived Accounts"
        ' 
        ' btnCloseArchive
        ' 
        btnCloseArchive.BackColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        btnCloseArchive.FlatAppearance.BorderSize = 0
        btnCloseArchive.FlatStyle = FlatStyle.Flat
        btnCloseArchive.ForeColor = Color.White
        btnCloseArchive.Location = New Point(780, 22)
        btnCloseArchive.Name = "btnCloseArchive"
        btnCloseArchive.Size = New Size(90, 36)
        btnCloseArchive.TabIndex = 1
        btnCloseArchive.Text = "Close"
        btnCloseArchive.UseVisualStyleBackColor = False
        ' 
        ' ArchiveStorage
        ' 
        ClientSize = New Size(937, 600)
        Controls.Add(pnlMain)
        Name = "ArchiveStorage"
        Text = "Archive Storage - OrderUp"
        pnlMain.ResumeLayout(False)
        pnlMain.PerformLayout()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub
End Class