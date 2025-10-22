<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Receipt
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSave As ToolStripButton
    Friend WithEvents tsFitWidth As ToolStripButton
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents pdfViewer As PdfiumViewer.PdfViewer

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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsFitWidth = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.pdfViewer = New PdfiumViewer.PdfViewer()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        ' ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsFitWidth, Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(8, 0, 1, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 38)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "toolStrip1"
        '
        ' tsSave
        '
        Me.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsSave.Image = System.Drawing.SystemIcons.Information.ToBitmap()
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(29, 35)
        Me.tsSave.Text = "Save As"
        '
        ' tsFitWidth
        '
        Me.tsFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsFitWidth.Image = System.Drawing.SystemIcons.Application.ToBitmap()
        Me.tsFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFitWidth.Name = "tsFitWidth"
        Me.tsFitWidth.Size = New System.Drawing.Size(29, 35)
        Me.tsFitWidth.Text = "Fit Width"
        '
        ' tsClose
        '
        Me.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsClose.Image = System.Drawing.SystemIcons.Error.ToBitmap()
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(29, 35)
        Me.tsClose.Text = "Close"
        '
        ' pdfViewer
        '
        Me.pdfViewer.BackColor = System.Drawing.Color.White
        Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewer.Location = New System.Drawing.Point(0, 38)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.Size = New System.Drawing.Size(800, 412)
        Me.pdfViewer.TabIndex = 1
        Me.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth
        '
        ' Receipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pdfViewer)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Receipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Receipt"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
