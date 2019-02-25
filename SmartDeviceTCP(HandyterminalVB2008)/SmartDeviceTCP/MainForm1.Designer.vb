<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainForm1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm1))
        Me.tbInput = New System.Windows.Forms.TextBox
        Me.serialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.lbStatus = New System.Windows.Forms.Label
        Me.lbOPNo = New System.Windows.Forms.Label
        Me.lbLotNo = New System.Windows.Forms.Label
        Me.lbPKG = New System.Windows.Forms.Label
        Me.lbDevice = New System.Windows.Forms.Label
        Me.btExit = New System.Windows.Forms.Button
        Me.tbOPNo = New System.Windows.Forms.Label
        Me.tbLotNo = New System.Windows.Forms.Label
        Me.tbPKG = New System.Windows.Forms.Label
        Me.tbDevice = New System.Windows.Forms.Label
        Me.ConnectionFailed = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Timer2 = New System.Windows.Forms.Timer
        Me.lbIP = New System.Windows.Forms.Label
        Me.TimeOut = New System.Windows.Forms.Timer
        Me.SuspendLayout()
        '
        'tbInput
        '
        Me.tbInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tbInput.Font = New System.Drawing.Font("Tahoma", 1.0!, System.Drawing.FontStyle.Regular)
        Me.tbInput.Location = New System.Drawing.Point(308, 179)
        Me.tbInput.Name = "tbInput"
        Me.tbInput.Size = New System.Drawing.Size(1, 8)
        Me.tbInput.TabIndex = 88
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 26.0!, System.Drawing.FontStyle.Regular)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(10, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(460, 61)
        Me.Button1.TabIndex = 86
        Me.Button1.Text = "Inspection"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(176, 78)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(123, 104)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Orange
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.Button2.Location = New System.Drawing.Point(166, 69)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 120)
        Me.Button2.TabIndex = 86
        '
        'lbStatus
        '
        Me.lbStatus.BackColor = System.Drawing.Color.Black
        Me.lbStatus.Font = New System.Drawing.Font("Tahoma", 20.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lbStatus.ForeColor = System.Drawing.Color.SpringGreen
        Me.lbStatus.Location = New System.Drawing.Point(145, 192)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(188, 42)
        Me.lbStatus.Text = "Scan OP No."
        Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbOPNo
        '
        Me.lbOPNo.BackColor = System.Drawing.Color.Black
        Me.lbOPNo.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.lbOPNo.ForeColor = System.Drawing.Color.Orange
        Me.lbOPNo.Location = New System.Drawing.Point(29, 265)
        Me.lbOPNo.Name = "lbOPNo"
        Me.lbOPNo.Size = New System.Drawing.Size(115, 42)
        Me.lbOPNo.Text = "OP No."
        '
        'lbLotNo
        '
        Me.lbLotNo.BackColor = System.Drawing.Color.Black
        Me.lbLotNo.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.lbLotNo.ForeColor = System.Drawing.Color.Orange
        Me.lbLotNo.Location = New System.Drawing.Point(29, 314)
        Me.lbLotNo.Name = "lbLotNo"
        Me.lbLotNo.Size = New System.Drawing.Size(115, 42)
        Me.lbLotNo.Text = "Lot No."
        '
        'lbPKG
        '
        Me.lbPKG.BackColor = System.Drawing.Color.Black
        Me.lbPKG.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.lbPKG.ForeColor = System.Drawing.Color.Orange
        Me.lbPKG.Location = New System.Drawing.Point(29, 376)
        Me.lbPKG.Name = "lbPKG"
        Me.lbPKG.Size = New System.Drawing.Size(115, 42)
        Me.lbPKG.Text = "PKG."
        '
        'lbDevice
        '
        Me.lbDevice.BackColor = System.Drawing.Color.Black
        Me.lbDevice.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.lbDevice.ForeColor = System.Drawing.Color.Orange
        Me.lbDevice.Location = New System.Drawing.Point(29, 431)
        Me.lbDevice.Name = "lbDevice"
        Me.lbDevice.Size = New System.Drawing.Size(115, 42)
        Me.lbDevice.Text = "Device"
        '
        'btExit
        '
        Me.btExit.BackColor = System.Drawing.Color.Black
        Me.btExit.Font = New System.Drawing.Font("Tahoma", 26.0!, System.Drawing.FontStyle.Regular)
        Me.btExit.ForeColor = System.Drawing.Color.White
        Me.btExit.Location = New System.Drawing.Point(368, 527)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(92, 61)
        Me.btExit.TabIndex = 86
        Me.btExit.Text = "Exit"
        Me.btExit.Visible = False
        '
        'tbOPNo
        '
        Me.tbOPNo.BackColor = System.Drawing.Color.White
        Me.tbOPNo.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.tbOPNo.Location = New System.Drawing.Point(163, 265)
        Me.tbOPNo.Name = "tbOPNo"
        Me.tbOPNo.Size = New System.Drawing.Size(262, 34)
        Me.tbOPNo.Text = "  -"
        '
        'tbLotNo
        '
        Me.tbLotNo.BackColor = System.Drawing.Color.White
        Me.tbLotNo.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.tbLotNo.Location = New System.Drawing.Point(163, 319)
        Me.tbLotNo.Name = "tbLotNo"
        Me.tbLotNo.Size = New System.Drawing.Size(262, 34)
        Me.tbLotNo.Text = "  -"
        '
        'tbPKG
        '
        Me.tbPKG.BackColor = System.Drawing.Color.White
        Me.tbPKG.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.tbPKG.Location = New System.Drawing.Point(163, 375)
        Me.tbPKG.Name = "tbPKG"
        Me.tbPKG.Size = New System.Drawing.Size(262, 34)
        Me.tbPKG.Text = "  -"
        '
        'tbDevice
        '
        Me.tbDevice.BackColor = System.Drawing.Color.White
        Me.tbDevice.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.tbDevice.Location = New System.Drawing.Point(163, 431)
        Me.tbDevice.Name = "tbDevice"
        Me.tbDevice.Size = New System.Drawing.Size(262, 34)
        Me.tbDevice.Text = "  -"
        '
        'ConnectionFailed
        '
        Me.ConnectionFailed.BackColor = System.Drawing.Color.Black
        Me.ConnectionFailed.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.ConnectionFailed.ForeColor = System.Drawing.Color.Red
        Me.ConnectionFailed.Location = New System.Drawing.Point(64, 478)
        Me.ConnectionFailed.Name = "ConnectionFailed"
        Me.ConnectionFailed.Size = New System.Drawing.Size(361, 42)
        Me.ConnectionFailed.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'Timer2
        '
        Me.Timer2.Interval = 5000
        '
        'lbIP
        '
        Me.lbIP.ForeColor = System.Drawing.Color.White
        Me.lbIP.Location = New System.Drawing.Point(17, 569)
        Me.lbIP.Name = "lbIP"
        Me.lbIP.Size = New System.Drawing.Size(100, 20)
        Me.lbIP.Text = "IP Address"
        '
        'TimeOut
        '
        Me.TimeOut.Interval = 5000
        '
        'MainForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.ClientSize = New System.Drawing.Size(478, 615)
        Me.Controls.Add(Me.lbIP)
        Me.Controls.Add(Me.tbDevice)
        Me.Controls.Add(Me.tbPKG)
        Me.Controls.Add(Me.tbLotNo)
        Me.Controls.Add(Me.tbOPNo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ConnectionFailed)
        Me.Controls.Add(Me.lbDevice)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lbPKG)
        Me.Controls.Add(Me.lbLotNo)
        Me.Controls.Add(Me.lbOPNo)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.tbInput)
        Me.Controls.Add(Me.btExit)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainForm1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbInput As System.Windows.Forms.TextBox
    Private WithEvents serialPort1 As System.IO.Ports.SerialPort
    Private WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents lbOPNo As System.Windows.Forms.Label
    Friend WithEvents lbLotNo As System.Windows.Forms.Label
    Friend WithEvents lbPKG As System.Windows.Forms.Label
    Friend WithEvents lbDevice As System.Windows.Forms.Label
    Private WithEvents btExit As System.Windows.Forms.Button
    Friend WithEvents tbOPNo As System.Windows.Forms.Label
    Friend WithEvents tbLotNo As System.Windows.Forms.Label
    Friend WithEvents tbPKG As System.Windows.Forms.Label
    Friend WithEvents tbDevice As System.Windows.Forms.Label
    Friend WithEvents ConnectionFailed As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lbIP As System.Windows.Forms.Label
    Friend WithEvents TimeOut As System.Windows.Forms.Timer

End Class
