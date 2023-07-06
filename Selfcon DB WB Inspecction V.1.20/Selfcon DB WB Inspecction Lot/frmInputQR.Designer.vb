<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputQR
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
        Me.components = New System.ComponentModel.Container
        Me.tbRevQR = New System.Windows.Forms.TextBox
        Me.lbCaption = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'tbRevQR
        '
        Me.tbRevQR.ForeColor = System.Drawing.Color.White
        Me.tbRevQR.Location = New System.Drawing.Point(612, 21)
        Me.tbRevQR.Name = "tbRevQR"
        Me.tbRevQR.Size = New System.Drawing.Size(10, 20)
        Me.tbRevQR.TabIndex = 0
        '
        'lbCaption
        '
        Me.lbCaption.AutoSize = True
        Me.lbCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbCaption.Location = New System.Drawing.Point(77, 9)
        Me.lbCaption.Name = "lbCaption"
        Me.lbCaption.Size = New System.Drawing.Size(108, 31)
        Me.lbCaption.TabIndex = 1
        Me.lbCaption.Text = "Caption"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 71)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(442, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'frmInputQR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 125)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lbCaption)
        Me.Controls.Add(Me.tbRevQR)
        Me.Name = "frmInputQR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmInputQR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbRevQR As System.Windows.Forms.TextBox
    Friend WithEvents lbCaption As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
