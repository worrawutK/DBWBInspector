﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputCarrierDialog
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
        Me.components = New System.ComponentModel.Container()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.PictureboxQrCodeInput = New System.Windows.Forms.PictureBox()
        Me.TextBoxQrCodeInput = New System.Windows.Forms.TextBox()
        Me.lbDisplay = New System.Windows.Forms.Label()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.label1 = New System.Windows.Forms.Label()
        Me.panel4 = New System.Windows.Forms.Panel()
        Me.labelTextScan = New System.Windows.Forms.Label()
        Me.pictureBox2 = New System.Windows.Forms.PictureBox()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureboxQrCodeInputCheck = New System.Windows.Forms.PictureBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        CType(Me.PictureboxQrCodeInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel3.SuspendLayout()
        Me.panel4.SuspendLayout()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureboxQrCodeInputCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.panel2)
        Me.panel1.Location = New System.Drawing.Point(15, 86)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(58, 57)
        Me.panel1.TabIndex = 67
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.PictureboxQrCodeInput)
        Me.panel2.Location = New System.Drawing.Point(8, 8)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(42, 42)
        Me.panel2.TabIndex = 59
        '
        'PictureboxQrCodeInput
        '
        Me.PictureboxQrCodeInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureboxQrCodeInput.Image = Global.InspectorWork.My.Resources.Resources.PictureBoxQrCode
        Me.PictureboxQrCodeInput.Location = New System.Drawing.Point(0, 0)
        Me.PictureboxQrCodeInput.Name = "PictureboxQrCodeInput"
        Me.PictureboxQrCodeInput.Size = New System.Drawing.Size(42, 42)
        Me.PictureboxQrCodeInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureboxQrCodeInput.TabIndex = 55
        Me.PictureboxQrCodeInput.TabStop = False
        '
        'TextBoxQrCodeInput
        '
        Me.TextBoxQrCodeInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxQrCodeInput.Location = New System.Drawing.Point(13, 152)
        Me.TextBoxQrCodeInput.Name = "TextBoxQrCodeInput"
        Me.TextBoxQrCodeInput.Size = New System.Drawing.Size(60, 20)
        Me.TextBoxQrCodeInput.TabIndex = 66
        '
        'lbDisplay
        '
        Me.lbDisplay.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDisplay.ForeColor = System.Drawing.Color.Black
        Me.lbDisplay.Location = New System.Drawing.Point(108, 11)
        Me.lbDisplay.Name = "lbDisplay"
        Me.lbDisplay.Size = New System.Drawing.Size(343, 31)
        Me.lbDisplay.TabIndex = 68
        Me.lbDisplay.Text = "กรุณา Scan QR Carrier No."
        Me.lbDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panel3
        '
        Me.panel3.Controls.Add(Me.label1)
        Me.panel3.Location = New System.Drawing.Point(79, 148)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(365, 52)
        Me.panel3.TabIndex = 71
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.SystemColors.Control
        Me.label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.label1.Location = New System.Drawing.Point(0, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(1, 52)
        Me.label1.TabIndex = 63
        '
        'panel4
        '
        Me.panel4.Controls.Add(Me.labelTextScan)
        Me.panel4.Controls.Add(Me.pictureBox2)
        Me.panel4.Location = New System.Drawing.Point(79, 86)
        Me.panel4.Name = "panel4"
        Me.panel4.Size = New System.Drawing.Size(365, 56)
        Me.panel4.TabIndex = 72
        '
        'labelTextScan
        '
        Me.labelTextScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labelTextScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTextScan.ForeColor = System.Drawing.Color.DarkOrange
        Me.labelTextScan.Location = New System.Drawing.Point(0, 0)
        Me.labelTextScan.Name = "labelTextScan"
        Me.labelTextScan.Size = New System.Drawing.Size(365, 56)
        Me.labelTextScan.TabIndex = 63
        Me.labelTextScan.Text = "Please scan qr code"
        Me.labelTextScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pictureBox2
        '
        Me.pictureBox2.Location = New System.Drawing.Point(-70, 0)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(70, 53)
        Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox2.TabIndex = 62
        Me.pictureBox2.TabStop = False
        '
        'timer1
        '
        Me.timer1.Enabled = True
        Me.timer1.Interval = 250
        '
        'PictureboxQrCodeInputCheck
        '
        Me.PictureboxQrCodeInputCheck.Image = Global.InspectorWork.My.Resources.Resources.PictureBoxWrong
        Me.PictureboxQrCodeInputCheck.Location = New System.Drawing.Point(457, 11)
        Me.PictureboxQrCodeInputCheck.Name = "PictureboxQrCodeInputCheck"
        Me.PictureboxQrCodeInputCheck.Size = New System.Drawing.Size(40, 40)
        Me.PictureboxQrCodeInputCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureboxQrCodeInputCheck.TabIndex = 70
        Me.PictureboxQrCodeInputCheck.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.InspectorWork.My.Resources.Resources.PicturBoxRohmLogo
        Me.pictureBox1.Location = New System.Drawing.Point(13, 11)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(77, 60)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox1.TabIndex = 69
        Me.pictureBox1.TabStop = False
        '
        'InputCarrierDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SpringGreen
        Me.ClientSize = New System.Drawing.Size(511, 211)
        Me.ControlBox = False
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.TextBoxQrCodeInput)
        Me.Controls.Add(Me.lbDisplay)
        Me.Controls.Add(Me.panel3)
        Me.Controls.Add(Me.PictureboxQrCodeInputCheck)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.panel4)
        Me.Name = "InputCarrierDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InputCarrierDialog"
        Me.TopMost = True
        Me.panel1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.PictureboxQrCodeInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel3.ResumeLayout(False)
        Me.panel4.ResumeLayout(False)
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureboxQrCodeInputCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents panel1 As Panel
    Private WithEvents panel2 As Panel
    Private WithEvents PictureboxQrCodeInput As PictureBox
    Private WithEvents TextBoxQrCodeInput As TextBox
    Friend WithEvents lbDisplay As Label
    Private WithEvents pictureBox2 As PictureBox
    Private WithEvents panel3 As Panel
    Private WithEvents label1 As Label
    Private WithEvents PictureboxQrCodeInputCheck As PictureBox
    Private WithEvents pictureBox1 As PictureBox
    Private WithEvents panel4 As Panel
    Private WithEvents labelTextScan As Label
    Private WithEvents timer1 As Timer
End Class
