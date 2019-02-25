'*******************************************************************************
'	Operation explanation:This is sample code for communication control.
'
'	Note:This is a sample program, so it is not supported by KEYENCE.
'
'	Copyright(c) 2012-2013 KEYENCE CORPORATION. All rights reserved.
'*******************************************************************************

Imports System.Linq
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports Bt.CommLib
Imports Bt
Imports Bt.SysLib
Imports System

'Imports System.Net.NetworkInformation.Ping

Partial Public Class MainForm1
    Inherits Form
    Public Shared MainForm1Instance As MainForm1

    '*******************************************************************************
    '* [Load form]
    '*******************************************************************************
    Dim strHostName As String = System.Net.Dns.GetHostName()
    Dim strIPAddress As String = System.Net.Dns.GetHostByName(strHostName).AddressList(1).ToString()
    Private Sub MainForm1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load, PictureBox1.Click, Button2.Click, Button1.Click


        '  Dim strIPAddress As String = System.Net.Dns.GetHostByName("dwb-ins-i7.thematrix.net").AddressList(0).ToString()
        '   Dim strIPAddress As String = System.Net.Dns.GetHostByName("dwb-ins-i7.thematrix.net").AddressList()

     

        lbIP.Text = "IP :" & strIPAddress
        'MsgBox(strHostName)
        'MsgBox(strIPAddress)
        tbInput.Focus()
        sql = "UPDATE SECS.Machines set IP='" & strIPAddress & "' ,SelfConIP= '" & strIPAddress & "' Where MCNo = 'DWB-H-01' and MachineType='WBINS'" ' 
        cmd_ExecuteNonQuery()
        '  Dim s As String = Dns.GetHostEntry(Dns.GetHostName).AddressList.FirstOrDefault(() => { },(ip.AddressFamily = AddressFamily.InterNetwork)).ToString
        ' Dim s As String = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(Function(a As IPAddress) Not a.Address AndAlso Not a.AddressFamily AndAlso Not a.ScopeId).First().ToString()
    End Sub

    Private Sub btn_WLANClient_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim disp As [String] = ""


        '*Set to match with the environment being used
        Dim port As Int32 = 8800
        Try
            'disp = "Start wireless LAN server with communication sample (server)."
            'MessageBox.Show(disp, "Client transmission/reception")

            ' Client transmission/reception
            ClientTCP(HostIP, port)
            HostIP = Nothing
            TableNumber = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    '*******************************************************************************
    '* Perform TCP/IP communication with server side.
    '* (Transmit and receive sequentially)
    '*******************************************************************************
    'Private Sub ClientTCP(ByVal hostName1 As [String], ByVal port As Int32)
    '    Dim disp As [String] = ""

    '    '' Dim client As TcpClient = Nothing

    '    Try
    '        ' Specify character code

    '        Dim enc As System.Text.Encoding = Encoding.GetEncoding(932)

    '        ' Connect to server

    '        Using client = New TcpClient()

    '            Try
    '                Dim ipAddress As IPAddress = ipAddress.Parse(hostName1)
    '                client.Connect(ipAddress, port)
    '            Catch generatedExceptionName As FormatException
    '                client.Connect(hostName1, port)
    '            End Try
    '            disp = "A connection with the sever has been established."
    '            ' MessageBox.Show(disp, "Client transmission/reception")
    '            Using ns As NetworkStream = client.GetStream()
    '                ' Data transmission
    '                Dim sendMsg As [String] = OPNo & "," & TableNumber & "," & QRCode252
    '                'If sendMsg.Length <> 266 Then
    '                '    MsgBox("Message Failed")
    '                '    Exit Sub
    '                'End If

    '                Dim sendBytes As [Byte]() = enc.GetBytes(sendMsg)
    '                ns.Write(sendBytes, 0, sendBytes.Length)


    '                disp = "Data to transmit :" & sendMsg & vbCr & vbLf
    '                'MessageBox.Show(disp, "Client transmission/reception")
    '                ' TimeOut.Enabled = True
    '                ' Receive data
    '                Dim ms As New MemoryStream()
    '                Dim resBytes As [Byte]() = New [Byte](255) {}
    '                Dim resSize As Integer
    '                Do
    '                    ' Receive partial data
    '                    resSize = ns.Read(resBytes, 0, resBytes.Length)
    '                    If resSize = 0 Then
    '                        ' Disconnect if there if no received data
    '                        Exit Do
    '                    End If
    '                    ' Store the received data.
    '                    ms.Write(resBytes, 0, resSize)
    '                Loop While ns.DataAvailable

    '                ' Display if cached data exists in MemoryStream
    '                If ms.Length > 0 Then
    '                    Dim resMsg As [String] = enc.GetString(ms.ToArray(), 0, ms.ToArray().Count())
    '                    Dim DataSplit As String() = resMsg.Split(CChar(","))

    '                    If DataSplit(1) = "01" Then '00 ผ่าน, 01 จบlot, 02 ส่งไม่ถูกเครื่อง 
    '                        Buzzer(3, 1)
    '                        Dim frm2 As New GotoINS
    '                        frm2.StatusINS = Status.EndLot
    '                        frm2.ShowDialog()
    '                        ' MsgBox("Lot นี้ยังไม่ได้ ทำการ บันทึก Inspection Request หรือ End Inspection แล้ว")
    '                        Exit Sub
    '                    ElseIf DataSplit(1) = "02" Then
    '                        'MsgBox("กรุณา Set Machine ให้ตรง")
    '                        'Exit Sub
    '                        Buzzer(3, 1)
    '                        Dim frm2 As New GotoINS
    '                        frm2.StatusINS = Status.PleaseSetMachine
    '                        frm2.ShowDialog()
    '                        Exit Sub
    '                    ElseIf DataSplit(1) = "11" Then
    '                        Buzzer(3, 1)
    '                        Dim frm2 As New GotoINS
    '                        frm2.StatusINS = Status.Running
    '                        frm2.ShowDialog()
    '                        Exit Sub
    '                    End If
    '                    ' MsgBox(DataSplit(1))

    '                    ConnectionFailed.Text = Nothing
    '                    disp = "Received data :" & resMsg & vbCr & vbLf
    '                    '    MessageBox.Show(disp, "Client transmission/reception")
    '                    ' MsgBox("สำเร็จ")
    '                    Buzzer(1, 16)
    '                    Dim frm As New GotoINS
    '                    frm.StatusINS = Status.Ok
    '                    frm.ShowDialog()
    '                End If
    '                ' Disconnect after shutdown
    '                client.Client.Shutdown(SocketShutdown.Both)
    '                '  TimeOut.Enabled = False
    '            End Using
    '        End Using
    '    Catch generatedExceptionName As IOException
    '        disp = "Connection is disabled."
    '        ' MessageBox.Show(disp, "Client transmission/reception")
    '        ConnectionFailed.Text = disp
    '    Catch generatedExceptionName As SocketException
    '        ' disp = "The operation to establish a connection failed."
    '        disp = "Connection Failed."
    '        'MessageBox.Show(disp, "Client transmission/reception")
    '        Buzzer(3, 1)
    '        ConnectionFailed.Text = "Connection Failed."
    '        Timer2.Enabled = True

    '    Catch ex As Exception
    '        '  MessageBox.Show(ex.ToString())
    '        Buzzer(3, 1)
    '        ConnectionFailed.Text = "No Machine." 'ไม่มีชื่อเครื่องใน DB SECSGEM (MachineType= WBINS) 
    '        Timer2.Enabled = True
    '        ' MessageBox.Show("No Machine")
    '    End Try
    'End Sub
    Private Sub tbOPNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbInput.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If OPNo = Nothing Then
                If tbInput.Text.Length = 6 Then
                    'showExit

                    If tbInput.Text = Format(Now, "yyMMdd").ToString Then 'Format(Now, "yyMMdd") Then
                        btExit.Visible = True
                        Exit Sub
                    End If
                    btExit.Visible = False
                    '----------
                    OPNo = tbInput.Text
                    tbOPNo.Text = OPNo
                    lbOPNo.ForeColor = Color.SpringGreen
                    lbStatus.Text = "Scan QR Code"
                    'FormMaster.Timer1.Enabled = True
                    tbInput.Text = ""
                Else
                    ' MsgBox("กรุณา Scan OP No. อีกครั้ง")
                    Dim frm As New GotoINS
                    frm.StatusINS = Status.ScanOP
                    frm.ShowDialog()
                    tbInput.Text = ""
                    Exit Sub
                End If
            Else
                If tbInput.Text.Length = 252 Then
                    QRCode252 = tbInput.Text
                    PKG = Trim(QRCode252.Substring(0, 10)).ToUpper
                    DeviceName = Trim(QRCode252.Substring(10, 20)).ToUpper
                    LotNo = Trim(QRCode252.Substring(30, 10)).ToUpper
                    tbPKG.Text = PKG
                    tbDevice.Text = DeviceName
                    tbLotNo.Text = LotNo
                    lbPKG.ForeColor = Color.SpringGreen
                    lbDevice.ForeColor = Color.SpringGreen
                    lbLotNo.ForeColor = Color.SpringGreen
                    lbStatus.Text = "Scan OP No."
                    'FormMaster.Timer1.Enabled = True
                    tbInput.Text = ""
                Else
                    '    MsgBox("กรุณา Scan QR Code. อีกครั้ง")
                    Dim frm As New GotoINS
                    frm.StatusINS = Status.ScanQR
                    frm.ShowDialog()
                    tbInput.Text = ""
                    Exit Sub
                End If
            End If
            ' Me.Close()
            If QRCode252 <> Nothing And OPNo <> Nothing Then
                Dim frm As New SelectAddress
                If frm.ShowDialog() = DialogResult.OK Then

                    Dim disp As [String] = ""

                    ' Dim hostName As [String] = "10.28.41.138"
                    '*Set to match with the environment being used
                    '    Dim port As Int32 = 8800

                    Try
                        'disp = "Start wireless LAN server with communication sample (server)."
                        'MessageBox.Show(disp, "Client transmission/reception")

                        ' Client transmission/reception
                        If SendStatus = Status.Cancel.ToString Then
                            SendStatus = Nothing
                            Clear()
                            ' MsgBox("Cancel")
                            Buzzer(1, 1)
                            Dim frm1 As New GotoINS
                            frm1.StatusINS = Status.Cancel
                            frm1.ShowDialog()
                            Exit Sub
                        End If
                        'Update IP
                        sql = "UPDATE SECS.Machines set IP='" & strIPAddress & "' ,SelfConIP= '" & strIPAddress & "' Where MCNo = 'DWB-H-01' and MachineType='WBINS'" ' 
                        cmd_ExecuteNonQuery()

                        Dim msg As String = OPNo & "," & TableNumber & "," & QRCode252
                        '  ClientTCP(msg, HostIP)
                        Dim IPAddress As String = ""
                        For Each obj In System.Net.Dns.GetHostEntry(HostIP).AddressList()
                            If obj.ToString Like "10.28*" Then
                                IPAddress = obj.ToString
                            End If
                        Next
                        If IPAddress = "" Then
                            MsgBox("Not IP 10.28*")
                            Exit Sub
                        End If
                        ClientTCP(msg, IPAddress)
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString())
                    End Try
                    Clear()
                    'TableNumber = Nothing
                    'OPNo = Nothing
                    'QRCode252 = Nothing
                    'lbOPNo.ForeColor = Color.Gold
                    'lbPKG.ForeColor = Color.Gold
                    'lbDevice.ForeColor = Color.Gold
                    'lbLotNo.ForeColor = Color.Gold
                    ' MsgBox("สำเร็จ")
                End If
            End If

        End If
    End Sub
    Private Sub Clear()
        TableNumber = Nothing
        OPNo = Nothing
        QRCode252 = Nothing
        lbOPNo.ForeColor = Color.Gold
        lbPKG.ForeColor = Color.Gold
        lbDevice.ForeColor = Color.Gold
        lbLotNo.ForeColor = Color.Gold
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        'ConnectionFailed.Text = "Input Password"
        'tbPassExit.Focus()
        Me.Close()

    End Sub

    Dim tick As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If tick = 0 Then
            lbStatus.Visible = True
            ConnectionFailed.Visible = True
            tick = 1
        Else
            lbStatus.Visible = False
            ConnectionFailed.Visible = False
            tick = 0
        End If
        tbInput.Focus()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        ConnectionFailed.Text = Nothing
        Timer2.Enabled = False
    End Sub
 
    Private Sub Buzzer(ByVal count As Integer, ByVal Tone As Integer)
        Dim ret As Int32 = 0
        Dim disp As [String] = ""

        'Buzzer
        Dim stBuzzerSet As New LibDef.BT_BUZZER_PARAM()
        ' Buzzer control structure (Set)
        ' Set to repeat "500 ms on, 500 ms off" 3 times
        stBuzzerSet.dwOn = 500
        ' Rumble time [ms] (1 to 5000)
        stBuzzerSet.dwOff = 500
        ' Stop time [ms] (0 to 5000)
        stBuzzerSet.dwCount = CUInt(count)
        ' Rumble count [times] (0 to 100)
        stBuzzerSet.bTone = Tone
        ' Musical scale (1 to 16)
        stBuzzerSet.bVolume = 3
        ' Buzzer volume (1 to 3)

        ' Vibrator
        Dim stVibSet As New LibDef.BT_VIBRATOR_PARAM()
        stVibSet.dwOn = 500
        ' Rumble time [ms] (1 to 5000)
        stVibSet.dwOff = 500
        ' Stop time [ms] (0 to 5000)
        stVibSet.dwCount = CUInt(count)
        ' Rumble count [times] (0 to 100)
        Try
            ' btBuzzer Rumble
            ret = Device.btBuzzer(1, stBuzzerSet)
            ret = Device.btVibrator(1, stVibSet)
            If ret <> LibDef.BT_OK Then
                disp = "btBuzzer error ret[" & ret & "]"
                MessageBox.Show(disp, "Error")
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Dim WithEvents Client1 As New TcpIpClient
    Private Sub ClientTCP(ByVal msg As String, ByVal ip As String)

        Client1.ReadContinue = False
        Client1.Listener_Click("8800", ip)
        Send(msg)

    End Sub

    Private Sub CmdXmlData(ByVal data As String) Handles Client1.RcvData
        RcvManage(data)
        AccessControl("1", data)
        data = ""
    End Sub

    Delegate Sub AccessControlDelg(ByVal Ctl As String, ByVal data As String)
    Private Sub AccessControl(ByVal Ctl As String, ByVal data As String)
        'If Me.InvokeRequired Then
        '    Me.Invoke(New AccessControlDelg(AddressOf AccessControl), Ctl, data)
        'Else
        '    Select Case Ctl
        '        Case "1"
        '            ' Button1.Text = data
        '            '   Label1.Text = data
        '        Case "2"

        '    End Select
        'End If

    End Sub
    Private Sub RcvManage(ByVal data As String)
        Dim DataSplit As String() = data.Split(CChar(","))

        If DataSplit(1) = "01" Then '00 ผ่าน, 01 จบlot, 02 ส่งไม่ถูกเครื่อง 
            Buzzer(3, 1)
            Dim frm2 As New GotoINS
            frm2.StatusINS = Status.EndLot
            frm2.ShowDialog()
            ' MsgBox("Lot นี้ยังไม่ได้ ทำการ บันทึก Inspection Request หรือ End Inspection แล้ว")
            '    Exit Sub
        ElseIf DataSplit(1) = "02" Then
            'MsgBox("กรุณา Set Machine ให้ตรง")
            'Exit Sub
            Buzzer(3, 1)
            Dim frm2 As New GotoINS
            frm2.StatusINS = Status.PleaseSetMachine
            frm2.ShowDialog()
            '   Exit Sub
        ElseIf DataSplit(1) = "11" Then
            Buzzer(3, 1)
            Dim frm2 As New GotoINS
            frm2.StatusINS = Status.Running
            frm2.ShowDialog()
            '  Exit Sub
        Else
            Buzzer(1, 16)
            Dim frm As New GotoINS
            frm.StatusINS = Status.Ok
            frm.ShowDialog()
        End If

        ' MsgBox(data)
        TimeOut.Enabled = False
    End Sub

    Private Sub TimeOut_Send(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimeOut.Tick
        TimeOut.Enabled = False
        '  MsgBox("timeout")
        Buzzer(3, 1)
        Dim frm2 As New GotoINS
        frm2.StatusINS = Status.TimeOut
        frm2.ShowDialog()

        Client1.Disconnent()
    End Sub


    Private Sub Send(ByVal str As String)
        'If str.Length > 15 Then
        '    MsgBox("message too long")
        '    Exit Sub
        'End If
        'If str.Length < 15 Then
        '    For i = 1 To 15 - str.Length
        '        str += " "
        '    Next
        'End If

        'AccessControl("2", str)

        Client1.btnSend_Click(str)
        TimeOut.Enabled = True
    End Sub


End Class


