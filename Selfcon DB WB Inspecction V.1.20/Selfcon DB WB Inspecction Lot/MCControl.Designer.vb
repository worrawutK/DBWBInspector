<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MCControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lbNameMC = New System.Windows.Forms.Label
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbNameMC
        '
        Me.lbNameMC.AutoSize = True
        Me.lbNameMC.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lbNameMC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbNameMC.Location = New System.Drawing.Point(12, 12)
        Me.lbNameMC.Name = "lbNameMC"
        Me.lbNameMC.Size = New System.Drawing.Size(46, 20)
        Me.lbNameMC.TabIndex = 0
        Me.lbNameMC.Text = "RT-X"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(114, 26)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(70, -1)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'MCControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.lbNameMC)
        Me.Name = "MCControl"
        Me.Size = New System.Drawing.Size(84, 43)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbNameMC As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
