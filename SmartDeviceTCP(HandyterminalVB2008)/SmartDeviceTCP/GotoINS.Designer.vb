<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class GotoINS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(408, 152)
        Me.Button1.TabIndex = 5
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 3500
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 40)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label2.Location = New System.Drawing.Point(16, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(384, 40)
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GotoINS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Red
        Me.ClientSize = New System.Drawing.Size(414, 135)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(32, 200)
        Me.Name = "GotoINS"
        Me.Text = "MsgBox"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
