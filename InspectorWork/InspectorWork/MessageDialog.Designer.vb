<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MessageDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.panel4 = New System.Windows.Forms.Panel()
        Me.lbProcess = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.pictureBoxGood = New System.Windows.Forms.PictureBox()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.labelAlarmTitle = New System.Windows.Forms.Label()
        Me.pictureBoxTitelBar = New System.Windows.Forms.PictureBox()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.pictureBoxDismiss = New System.Windows.Forms.PictureBox()
        Me.panel1.SuspendLayout()
        Me.panel4.SuspendLayout()
        CType(Me.pictureBoxGood, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel2.SuspendLayout()
        CType(Me.pictureBoxTitelBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel3.SuspendLayout()
        CType(Me.pictureBoxDismiss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.SystemColors.Menu
        Me.panel1.Controls.Add(Me.panel4)
        Me.panel1.Controls.Add(Me.panel2)
        Me.panel1.Controls.Add(Me.panel3)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(685, 398)
        Me.panel1.TabIndex = 3
        '
        'panel4
        '
        Me.panel4.BackColor = System.Drawing.Color.Transparent
        Me.panel4.Controls.Add(Me.lbProcess)
        Me.panel4.Controls.Add(Me.label1)
        Me.panel4.Controls.Add(Me.pictureBoxGood)
        Me.panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel4.Location = New System.Drawing.Point(0, 93)
        Me.panel4.Name = "panel4"
        Me.panel4.Size = New System.Drawing.Size(685, 246)
        Me.panel4.TabIndex = 13
        '
        'lbProcess
        '
        Me.lbProcess.BackColor = System.Drawing.Color.White
        Me.lbProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbProcess.ForeColor = System.Drawing.Color.Green
        Me.lbProcess.Location = New System.Drawing.Point(12, 74)
        Me.lbProcess.Name = "lbProcess"
        Me.lbProcess.Size = New System.Drawing.Size(445, 70)
        Me.lbProcess.TabIndex = 19
        Me.lbProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(131, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(227, 33)
        Me.label1.TabIndex = 17
        Me.label1.Text = "กรุณานำงานไปส่งที่"
        '
        'pictureBoxGood
        '
        Me.pictureBoxGood.BackColor = System.Drawing.Color.Transparent
        Me.pictureBoxGood.Image = Global.InspectorWork.My.Resources.Resources.PictureBoxStickerYeah
        Me.pictureBoxGood.Location = New System.Drawing.Point(472, 16)
        Me.pictureBoxGood.Name = "pictureBoxGood"
        Me.pictureBoxGood.Size = New System.Drawing.Size(186, 204)
        Me.pictureBoxGood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBoxGood.TabIndex = 12
        Me.pictureBoxGood.TabStop = False
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.labelAlarmTitle)
        Me.panel2.Controls.Add(Me.pictureBoxTitelBar)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel2.Location = New System.Drawing.Point(0, 0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(685, 93)
        Me.panel2.TabIndex = 12
        '
        'labelAlarmTitle
        '
        Me.labelAlarmTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labelAlarmTitle.AutoSize = True
        Me.labelAlarmTitle.BackColor = System.Drawing.Color.Transparent
        Me.labelAlarmTitle.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAlarmTitle.ForeColor = System.Drawing.Color.White
        Me.labelAlarmTitle.Location = New System.Drawing.Point(95, 30)
        Me.labelAlarmTitle.Name = "labelAlarmTitle"
        Me.labelAlarmTitle.Size = New System.Drawing.Size(194, 29)
        Me.labelAlarmTitle.TabIndex = 0
        Me.labelAlarmTitle.Text = "INFORMATION"
        '
        'pictureBoxTitelBar
        '
        Me.pictureBoxTitelBar.BackColor = System.Drawing.Color.Transparent
        Me.pictureBoxTitelBar.BackgroundImage = Global.InspectorWork.My.Resources.Resources.Greenbar
        Me.pictureBoxTitelBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureBoxTitelBar.Location = New System.Drawing.Point(0, 0)
        Me.pictureBoxTitelBar.Name = "pictureBoxTitelBar"
        Me.pictureBoxTitelBar.Size = New System.Drawing.Size(685, 93)
        Me.pictureBoxTitelBar.TabIndex = 0
        Me.pictureBoxTitelBar.TabStop = False
        '
        'panel3
        '
        Me.panel3.BackColor = System.Drawing.Color.Transparent
        Me.panel3.Controls.Add(Me.pictureBoxDismiss)
        Me.panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel3.Location = New System.Drawing.Point(0, 339)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(685, 59)
        Me.panel3.TabIndex = 11
        '
        'pictureBoxDismiss
        '
        Me.pictureBoxDismiss.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pictureBoxDismiss.Image = Global.InspectorWork.My.Resources.Resources.btnGreenOK
        Me.pictureBoxDismiss.Location = New System.Drawing.Point(571, 5)
        Me.pictureBoxDismiss.Name = "pictureBoxDismiss"
        Me.pictureBoxDismiss.Size = New System.Drawing.Size(102, 51)
        Me.pictureBoxDismiss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBoxDismiss.TabIndex = 4
        Me.pictureBoxDismiss.TabStop = False
        '
        'MessageDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 398)
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MessageDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MessageDialog"
        Me.panel1.ResumeLayout(False)
        Me.panel4.ResumeLayout(False)
        Me.panel4.PerformLayout()
        CType(Me.pictureBoxGood, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.pictureBoxTitelBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel3.ResumeLayout(False)
        CType(Me.pictureBoxDismiss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pictureBoxTitelBar As PictureBox
    Private WithEvents panel1 As Panel
    Protected WithEvents panel4 As Panel
    Private WithEvents panel2 As Panel
    Private WithEvents labelAlarmTitle As Label
    Private WithEvents panel3 As Panel
    Private WithEvents pictureBoxDismiss As PictureBox
    Private WithEvents pictureBoxGood As PictureBox
    Private WithEvents label1 As Label
    Friend WithEvents lbProcess As Label
End Class
