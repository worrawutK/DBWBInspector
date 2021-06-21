Imports System.IO

'* UserAuthenOP = NOUSE is disable autherization system

Imports System.Net, System.Net.Sockets
Imports System.Reflection
Imports System.Text
Imports InspectorWork.iLibraryService
Imports MessageDialog
'Imports iTextSharp.text.pdf
'Imports iTextSharp.text

Public Class Form1
    'iLibrary Service
    Private c_ServiceiLibrary As ServiceiLibraryClient
    '------------------TCP
    Dim serverSocket As Socket
    Dim clientSocket As Socket
    Dim SocketTCP As Socket
    '-----------------
    Dim CellSelct As New Point
    Dim CountFoscus As New Point
    Dim Dt As DBxDataSet.Inspection_DetailDataTable
    Dim DBWB_InsTbl As DBxDataSet.DBWBINSDataDataTable
    Dim DBWB_InsTblQuery As New DBxDataSetTableAdapters.DBWBINSDataTableAdapter
    Dim LotAlarmQtyTbl As DBxDataSet.LotAlarmQtyDataTable
    Dim LotAlarmQtyTblQuery As New DBxDataSetTableAdapters.LotAlarmQtyTableAdapter
    Dim InspDetail As DBxDataSet.InspectionDetailDataTable
    Dim InspDetailQuery As New DBxDataSetTableAdapters.InspectionDetailTableAdapter

    Dim DetailModeHashTbl As New Hashtable
    Friend Const _ipDbxUser = "172.16.0.102"
    Public OprData As New CommonData
    Dim ModeListCbItem As New List(Of InspectionList)    'Link ModeNo and ModeName for cbxitem to InspectionDetail table


    Dim TimePause As String = "True"
    Dim RHH As Integer
    Dim RMM As Integer
    Dim Rss As Integer
    Dim SPHH As Integer
    Dim SPMM As Integer
    Dim SPss As Integer
    Dim CheckQR As String = ""
    Private Const PathServer As String = "\\172.16.0.115\MachineData\DB\Inspector\"
    Private Const Version As String = "V1.11"
    Dim strHostName As String = System.Net.Dns.GetHostName()


    Dim SaveTime As Boolean = False
    'Dim ModeNoLinkCbitem() As String = {"WB10", "WB1", "WB2", "WB27", "WB27", "WB27", "WB27", "WB27", "DB1", "DB2", "DB3", "DB11", "DB12", "DB13", "DB14"}
    Structure InspectionList
        Dim ModeName As String
        Dim ModdeNo As String
        Dim Process As InspNgType
    End Structure
    Public Enum InspNgType
        DB
        WB
        MARKER
        INSP
    End Enum
    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try
            'apcs pro.
            c_ServiceiLibrary.MachineOnlineState(My.Settings.MachineNo, MachineOnline.Online)
        Catch ex As Exception
            MessageBoxDialog.ShowMessage("MachineOnlineState", ex.Message.ToString, "iLibrary Service")
        End Try


        If My.Settings.SetMasterGLCheck = True Then
            btGLConfirm.Visible = True
        End If
        'lbVersion.Text = My.Settings.Version
        'update ip
        ' GetHostEntry
        '    Dim strIPAddress As String = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        Dim strIPAddress As String = System.Net.Dns.GetHostEntry(strHostName).AddressList(1).ToString()
        Dim str As String = "-"
        Dim DataSplit As String() = strHostName.Split("I")
        Label40.Text = "IP:" & strIPAddress & " V" & System.Windows.Forms.Application.ProductVersion 'Version

        If DataSplit.Length >= 3 Then
            str = "0" & DataSplit(2)
        End If

        'Label41.Text = "Inspection No." & str
        Label41.Text = "No." & My.Settings.MachineNo

        'MachinesTableAdapter1.Fill(DBxDataSet.Machines, strHostName, "WBINS")
        MachinesTableAdapter1.Fill(DBxDataSet.Machines, My.Settings.MachineNo, "WBINS")
        '  MachinesTableAdapter1.Fill(DBxDataSet.Machines, strHostName, "WBINS")
        For Each Data As DBxDataSet.MachinesRow In DBxDataSet.Machines.Rows
            Data.IP = strIPAddress
            Data.SelfConIP = strIPAddress
            MachinesTableAdapter1.Update(Data)
        Next

        '  TabControl1.SelectedTab = TabPage2

        serverSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim IpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Any, 8800)
        serverSocket.Bind(IpEndPoint)
        serverSocket.Listen(1)
        serverSocket.BeginAccept(New AsyncCallback(AddressOf OnAccept), Nothing)

        'slMessage.Width = Me.Width - 180
        'slTimer.Text = Format(Now, "yyyy-MM-dd HH:mm")

        'lbDB01.Text = "-"
        'lbDb04.Text = "-"
        'lbDb06.Text = "-"
        'lbDb07.Text = "-"
        'lbDb14.Text = "-"
        'lbDb16.Text = "-"
        'lbDB99.Text = "-"
        'lbWb01.Text = "-"
        'lbWb02.Text = "-"
        'lbWb04.Text = "-"
        'lbWb17.Text = "-"
        'lbWb18.Text = "-"
        'lbWb19.Text = "-"
        'lbWb99.Text = "-"

        If Not (Directory.Exists(DIR_LOG)) Then
            Directory.CreateDirectory(DIR_LOG)
        End If

        Me.WindowState = FormWindowState.Maximized
        lbProcessTitle.Text = "PROCESS : " & My.Settings.ProcessName

        'Link Mode No data Inspect
        'Dim ModeNoLinkCbitem() As String = {"WB10", "WB1", "WB2", "WB3", "WB27", "WB27", "WB27", "WB27", "WB27", "DB1", "DB2", "DB3", "DB11", "DB12", "DB13", "DB14"}
        ' Dim ModeNoLinkCbitem() As String = {"WB1", "WB2", "WB3", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "DB1", "DB2", "DB3", "DB11", "DB12", "DB13", "DB14", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "WB27", "WB27", "WB27", "WB27", "WB27"}
        '21 item
        '"Chip Kake (Chipping)", "Chip Crack", "Aluminium Scratch", "Preform Over Flow", "Preform Thickness", "Preform Spread", "Preform Zure", "DIE TWIST", "DIE MISALIGNMENT", "SCRATCH", "PREFROM/SOLDER ON CHIP", "PREFROM/SOLDER ON LEAD", "IBUTSU ON CHIP", "IBUTSU ON LEAD", "FRAME BENT", "INNER LEAD BENT", "ZINK BENT", "ISLAND FLOAT", "BAD MAKE", "PAD HAGARE", "DIE DROP OFF", "AU-CUT [WB NG]", "B-HAZURE [WB NG]", "2ND OPEN ALARM [WB NG]", "WB NASHI [WB NG]", "1ST OPEN ALARM [WB NG]", "V-TSUKI ALARM [WB NG]", "1ST OPEN NO ALARM", "2ND OPEN NO ALARM", "B-HAZURE NO ALARM", "NECK CUT", "2ND CUT", "2ND DAKON", "2ND TOOL MARK", "B-ZURE", "2ND ZURE", "WIRE CURL", "WIRE TARE", "WIRE TAORE", "V-TZUKI", "SMASHED BALL", "BALL OFF CENTER", "LOOP LOW", "LOOP HEIGHT", "2ND BUMP NG", "B-TSUBURE", "BENT DOWN WIRE", "WIRE TOUCH CHIP", "CAP TOUCH WIRE", "CLOSESING WIRE", "ISLAND FLOAT", "CHIP KAKE", "LEAD CHANGE COLOUR", "DOUBLE WIRE", "SMALL BALL", "BIG BALL", "ALUMINUM SPREAD", "WIRE SLIP", "WITHOUT CUT MARK", "CUT POSITION MISS", "WIRE CUT", "LANDING SHAPE", "TOOL TOUCH MARK", "STOMPED WIRE", "PARTICLE", "BENT LEAD"})
        Dim ModeNoLinkCbitem() As String = {"DB1", "DB2", "DB3", "DB11", "DB12", "DB13", "DB14", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22", "DB22",
            "WB1", "WB2", "WB27", "WB27", "WB3", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "WB27", "DB22", "DWB"}
        Dim ItemList() As String = {"Chip Kake (Chipping)", "Chip Crack", "Aluminium Scratch", "Preform Over Flow", "Preform Thickness", "Preform Spread", "Preform Zure", "DIE TWIST", "DIE MISALIGNMENT", "SCRATCH", "PREFROM/SOLDER ON CHIP", "PREFROM/SOLDER ON LEAD", "IBUTSU ON CHIP", "IBUTSU ON LEAD", "FRAME BENT", "INNER LEAD BENT", "ZINK BENT", "ISLAND FLOAT", "BAD MAKE", "PAD HAGARE", "DIE DROP OFF",
            "1ST OPEN NO ALARM", "2ND OPEN NO ALARM", "B-HAZURE NO ALARM", "NECK CUT", "2ND CUT", "2ND DAKON", "2ND TOOL MARK", "B-ZURE", "2ND ZURE", "WIRE CURL", "WIRE TARE", "WIRE TAORE", "V-TZUKI", "SMASHED BALL", "BALL OFF CENTER", "LOOP LOW", "LOOP HEIGHT", "2ND BUMP NG", "B-TSUBURE", "BENT DOWN WIRE", "WIRE TOUCH CHIP", "CAP TOUCH WIRE", "CLOSESING WIRE", "ISLAND FLOAT", "CHIP KAKE", "LEAD CHANGE COLOUR", "DOUBLE WIRE", "SMALL BALL", "BIG BALL", "ALUMINUM SPREAD", "WIRE SLIP", "WITHOUT CUT MARK", "CUT POSITION MISS", "WIRE CUT", "LANDING SHAPE", "TOOL TOUCH MARK", "STOMPED WIRE", "PARTICLE", "BENT LEAD",
            "AU-CUT [WB NG]", "B-HAZURE [WB NG]", "2ND OPEN ALARM [WB NG]", "WB NASHI [WB NG]", "1ST OPEN ALARM [WB NG]", "V-TSUKI ALARM [WB NG]", "OP SHORI [WB NG]", "ISLAND FLOAT [WB NG]", "ISLAND FLOAT [WB NG]", "LEAD COLOUR CHANGE [WB NG]", "INNER LEAD BENT [WB NG]", "PAD COLOUR CHANGE [WB NG]", "KAKE [WB NG]", "CRACK [WB NG]", "DIE TWIS [WB NG]T", "DIE MISALIGNMENT [WB NG]", "PREFROM OVER [WB NG]", "P/F ON LEAD [WB NG]", "PASTE BRIDGE [WB NG]", "CHIP OFF [WB NG]", "P/F ON CHIP [WB NG]", "DIE DROP OFF [WB NG]", "BAD MARK [WB NG]", "DOUBLE CHIP [WB NG]", "CHIP OUT [WB NG]", "IBUTSU ON CHIP/LEAD [WB NG]", "HOLIZONTAL CRACK [WB NG]", "DB NG"}
        '"1st Open", "2nd Open", "2nd Cut", "INSPECTOR SHORI", "B-ZURE", "BALL OFF CENTER", "SMASHED BALL", "WIRE TOUCH", "WIRE CURL", "NECK CUT", "2ND ZURE", "ALUMINUM SPREAD", "V-TSUKI", "BALL THICKNESS", "B-HAZURE", "2ND DAGON", "SECURITY BONDING/2ND BONDING", "WIRE SCAR", "LOOP NG", "LOOP HEIGHT", "WIRE TARE", "Chip Kake (Chipping)", "Chip Crack", "Aluminium Scratch", "Preform Over Flow", "Preform Thickness", "Preform Spread", "Preform Zure", "DIE TWIST", "DIE MISALIGNMENT", "SCRATCH", "PREFROM/SOLDER ON CHIP", "PREFROM/SOLDER ON LEAD", "IBUTSU ON CHIP", "IBUTSU ON LEAD", "FRAME BENT", "INNER LEAD BENT", "ZINK BENT", "ISLAND FLOAT", "BAD MAKE", "PAD HAGARE", "DIE DROP OFF", "AU-CUT [WB NG]", "B-HAZURE [WB NG]", "2ND OPEN ALARM [WB NG]", "WB NASHI [WB NG]", "1ST OPEN ALARM [WB NG]", "V-TSUKI ALARM [WB NG]", "1ST OPEN NO ALARM", "2ND OPEN NO ALARM", "B-HAZURE NO ALARM", "NECK CUT", "2ND CUT", "2ND DAKON", "2ND TOOL MARK", "B-ZURE", "2ND ZURE", "WIRE CURL", "WIRE TARE", "WIRE TAORE", "V-TZUKI", "SMASHED BALL", "BALL OFF CENTER", "LOOP LOW", "LOOP HEIGHT", "2ND BUMP NG", "B-TSUBURE", "BENT DOWN WIRE", "WIRE TOUCH CHIP", "CAP TOUCH WIRE", "CLOSESING WIRE", "ISLAND FLOAT", "CHIP KAKE", "LEAD CHANGE COLOUR", "DOUBLE WIRE", "SMALL BALL", "BIG BALL", "ALUMINUM SPREAD", "WIRE SLIP", "WITHOUT CUT MARK", "CUT POSITION MISS", "WIRE CUT", "LANDING SHAPE", "TOOL TOUCH MARK", "STOMPED WIRE", "PARTICLE", "BENT LEAD"})
        cbxItem.Items.Clear()
        For i = 0 To ItemList.Count - 1
            Dim List As New InspectionList
            List.ModeName = ItemList(i)
            cbxItem.Items.Add(ItemList(i))
            List.ModdeNo = ModeNoLinkCbitem(i)
            Dim ngModeName As InspNgType

            If i <= 20 Then 'DB INSP NG
                ngModeName = InspNgType.INSP
            ElseIf i > 20 AndAlso i <= 59 Then 'WB NG
                ngModeName = InspNgType.INSP
            ElseIf i > 59 AndAlso i <= 86 Then 'WB INSP NG
                ngModeName = InspNgType.WB
            ElseIf i = 87 Then
                ngModeName = InspNgType.DB
            Else
                ngModeName = InspNgType.INSP
            End If
            List.Process = ngModeName
            ModeListCbItem.Add(List)
        Next
        'For i = 0 To cbxItem.Items.Count - 1
        '    Dim List As New InspectionList
        '    List.ModeName = cbxItem.Items(i)
        '    List.ModdeNo = ModeNoLinkCbitem(i)
        '    ModeListCbItem.Add(List)
        'Next

        SetDefultItem(ProcessName.WB)
        'TabControl1.TabPages.Remove(TabPage2) '**********


        'If dgvTotal.RowCount > 0 Then
        '    Exit Sub
        'End If
        'dgvTotal.Rows.Add("Total")

    End Sub
    Private Sub LoadTime()
        RHH = My.Settings.RHH
        RMM = My.Settings.RMM
        Rss = My.Settings.Rss
        SPHH = My.Settings.SPHH
        SPMM = My.Settings.SPMM
        SPss = My.Settings.SPss

        lbRUN.Text = RHH.ToString("00") & ":" & RMM.ToString("00") & ":" & Rss.ToString("00")
        lbSTOP.Text = SPHH.ToString("00") & ":" & SPMM.ToString("00") & ":" & SPss.ToString("00")
    End Sub
    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        slMessage.Width = Me.Width - 500
        slTimer.Text = Format(Now, "yyyy-MM-dd HH:mm")
    End Sub
    Private Sub OnAccept(ByVal ar As IAsyncResult)
        clientSocket = serverSocket.EndAccept(ar)

        serverSocket.BeginAccept(New AsyncCallback(AddressOf OnAccept), Nothing)

        'Dim s As Socket = CType(ar.AsyncState, Socket)
        'Dim s2 As Socket = s.EndAccept(ar)
        Dim so2 As New StateObject()
        so2.workSocket = clientSocket
        clientSocket.BeginReceive(so2.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveData), so2)

        AddClient(clientSocket)
    End Sub
    Delegate Sub _AddClient(ByVal client As Socket)
    Private Sub AddClient(ByVal client As Socket)
        If InvokeRequired Then
            Invoke(New _AddClient(AddressOf AddClient), client)
            Exit Sub
        End If
        For Each Item As ListViewItem In lsvClients.Items        'ReConnection with out disconnect
            If Item.Text.Split(":")(0) = client.RemoteEndPoint.ToString.Split(":")(0) Then
                lsvClients.Items.Remove(Item)
            End If
        Next
        Dim lvi As New ListViewItem(client.RemoteEndPoint.ToString)
        lvi.Tag = client
        SocketTCP = client
        lsvClients.Items.Add(lvi)
        stbInfo.Text = "Connected"
    End Sub
    Private Sub ReceiveData(ByVal pIAsyncResult As IAsyncResult)                                        'Receive callback return when have reponse

        Dim content As String = String.Empty
        Dim state As StateObject = CType(pIAsyncResult.AsyncState, StateObject)                 'GetData to buffer,worksocket
        Dim handler As Socket = state.workSocket

        Try
            Dim bytesRead As Integer = handler.EndReceive(pIAsyncResult)
            If bytesRead = 0 Then                                                                                                                         'Return 0 = Client reponse disconnect
                stbInfo.Text = "Disconnect" 'handler.RemoteEndPoint.ToString & " : " &
                'MsgBox(handler.RemoteEndPoint.ToString & " : " & "Disconnect")
                RemoveClient(handler)
                Exit Sub
            End If
            If bytesRead > 0 Then
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead))                      'Binary to ASCII Trans
                DataRead(handler.RemoteEndPoint.ToString, state.sb.ToString)
                'รับข้อมูล
                '   Send(My.Settings.MachineNo, test)
                Array.Clear(state.buffer, 0, state.buffer.Length)
                'Begins to asynchronously receive data from a connected 
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, New AsyncCallback(AddressOf ReceiveData), state)
            Else

            End If


        Catch ex As ArgumentNullException             'buffer is null.
            MsgBox(ex.ToString)
        Catch ex As SocketException                   'An error occurred when attempting to access the socket. 
            stbInfo.Text = handler.RemoteEndPoint.ToString & " : " & "Disconnect"
            'MsgBox(handler.RemoteEndPoint.ToString & " : " & "Disconnect")
            RemoveClient(handler)
        Catch ex As ObjectDisposedException           'Socket has been closed
            MsgBox(ex.ToString)
        Catch ex As ArgumentOutOfRangeException       'Out of Range Error
            MsgBox(ex.ToString)


        End Try
    End Sub
    Delegate Sub _RemoveClient(ByVal client As Socket)
    Private Sub RemoveClient(ByVal client As Socket)
        If InvokeRequired Then
            Invoke(New _RemoveClient(AddressOf RemoveClient), client)
            Exit Sub
        End If

        For Each Item As ListViewItem In lsvClients.Items
            If Item.Text = client.RemoteEndPoint.ToString Then
                lsvClients.Items.Remove(Item)
            End If

        Next

    End Sub
    Private Delegate Sub UpdateTextDelegate1(ByVal IP As String, ByVal Data As String)
    Private m_DataR As UpdateTextDelegate1 = New UpdateTextDelegate1(AddressOf DataRead)
    Private Sub DataRead(ByVal IP As String, ByVal informationText As String)
        If Me.InvokeRequired Then
            'http://kristofverbiest.blogspot.com/2007/02/avoid-invoke-prefer-begininvoke.html
            Me.BeginInvoke(m_DataR, IP, informationText)
            Exit Sub
        End If
        If lbEndTime.Text = "" And lbStartTime.Text <> "StartTime" Then 'แก้กรณีรับข้อมูลโดยยังไม่จบlot
            ' MsgBox("ยังไม่จบ Lot")
            Send(strHostName & ",11", SocketTCP)
            '     SaveCatchLog(strHostName & ",11", "DataRead()ยังไม่จบ Lot")
            Exit Sub
        End If

        ReadData(informationText)
        Try
            tbxRecieve.Text += IP & "  : " & informationText & vbCrLf

            '   tbxQR_OPID.Text = DataSplit(0)
            '  SendKeys.Send("{ENTER}")
        Catch ex As Exception

        End Try

    End Sub
    Dim Check_InputTotal As Boolean
    Private Sub ReadData(ByVal informationText As String)
        Try
            lbDB01.Text = "-"
            lbDb04.Text = "-"
            lbDb06.Text = "-"
            lbDb07.Text = "-"
            lbDb14.Text = "-"
            lbDb16.Text = "-"
            lbDB99.Text = "-"
            lbWb01.Text = "-"
            lbWb02.Text = "-"
            lbWb04.Text = "-"
            lbWb17.Text = "-"
            lbWb18.Text = "-"
            lbWb19.Text = "-"
            lbWb99.Text = "-"

            If informationText <> Nothing Then
                SaveCatchLog(informationText, "ReadData()")
                Dim DataSplit As String() = informationText.Split(CChar(","))
                '   Dim strHostName As String = System.Net.Dns.GetHostName()
                If strHostName <> DataSplit(1) Then
                    Send(strHostName & ",02", SocketTCP)
                    '  SaveCatchLog(strHostName & ",02", "ReadData()Set Machine")
                    Exit Sub
                End If
                OprData.OPID = DataSplit(0)
                btnOPID.Text = OprData.OPID
                QR_OPIDRead()
                btnOPID.ForeColor = Color.Black
                btQR.BackColor = SystemColors.Control
                tbQR_GL.Text = Nothing
                OprData.QrData = DataSplit(2)
            Else

                SaveCatchLog(OprData.OPID & "," & OprData.QrData, "ReadData()")
            End If

            Try
                tbQR_GL.Text = Nothing
                btQR.BackColor = SystemColors.Control
                rbtLotJudgeOK.Checked = False
                rbtLotJudgeNG.Checked = False
                tbJudgeReason.Enabled = False
                slMessage.Text = "QR Work Slip Read Success_" & Format(Now, "HH:mm:ss.fff")
                If Not InspectorPermission(OprData.QrData, OprData.OPID, My.Settings.UserAuthenOP, My.Settings.UserAuthenGL) Then
                    If My.Settings.UserAuthenOP = "NOUSE" Then  'Bypass Auten  Check only Lot automotive
                        GoTo BypassAuter
                    End If
                    MsgBox(ErrMesETG)
                    If ErrMesETG Like "OP*" Then
                        btnOPID.Text = "OPID"
                        lbinspectorID.Text = "OPID"
                    End If
                    '    pbxAutoM.Visible = False
                    Exit Sub
                End If
BypassAuter:
                If OprData.AutoMotiveLot Then     'CD Machine lot 1:n nouse
                    '      pbxAutoM.Visible = True
                End If

                '----- initial data ----------------------------------------------------------------------------------------
                Dim WorkSlipQR As New WorkingSlipQRCode
                WorkSlipQR.SplitQRCode(OprData.QrData)

                DBWB_InsTbl = New DBxDataSet.DBWBINSDataDataTable
                Dim DR As DBxDataSet.DBWBINSDataRow
                DR = DBWB_InsTbl.NewRow
                If DBWB_InsTblQuery.Fill(DBWB_InsTbl, WorkSlipQR.LotNo) = 0 Then
                    Send(strHostName & ",01", SocketTCP)
                    'SaveCatchLog(strHostName & ",01", "ReadData()No Inspection Request or End Inspection")
                    slMessage.Text = "Lot นี้ยังไม่ได้ ทำการ บันทึก Inspection Request หรือ End Inspection แล้ว"
                    Exit Sub
                End If
                DR = DBWB_InsTbl.Rows(0)                        '  Use DRcan make sure  update only one row to table

                Try
                    Dim layerNo As String = ""
                    If DR.Process.Trim() = "DB" Then
                        'DB M BRARI100%INS 0213
                        layerNo = "0213"
                    End If
                    Dim result As SetupLotResult = c_ServiceiLibrary.SetupLotNoCheckLicenser(WorkSlipQR.LotNo, My.Settings.MachineNo, OprData.OPID, DR.Process.Trim(), layerNo)
                    If result.IsPass = SetupLotResult.Status.NotPass Then
                        MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString, result.ErrorNo)
                        Exit Sub
                    ElseIf result.IsPass = SetupLotResult.Status.Warning Then
                        MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString, result.ErrorNo)
                    End If
                    c_ServiceiLibrary.UpdateMachineState(My.Settings.MachineNo, MachineProcessingState.LotSetUp)
                    c_ServiceiLibrary.StartLot(WorkSlipQR.LotNo, My.Settings.MachineNo, OprData.OPID, result.Recipe)
                    c_ServiceiLibrary.UpdateMachineState(My.Settings.MachineNo, MachineProcessingState.Execute)
                Catch ex As Exception
                    MessageBoxDialog.ShowMessage("SetupLot,StartLot", ex.Message.ToString, "iLibrary Service")
                End Try


                SPss = 0
                SPHH = 0
                SPMM = 0
                RHH = 0
                RMM = 0
                Rss = 0
                lbToVal.Text = Nothing
                lbSTOP.Text = "00:00:00"
                lbSTOP.ForeColor = Color.Black
                btTimePause.Text = "STOP"
                btTimePause.BackColor = Color.Red
                TimerRun.Start()
                TimerStop.Stop()
                lbStartTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
                lbEndTime.Text = ""
                btnWorkSlip.ForeColor = Color.Black
                lbNG.Text = Nothing
                lbGood.Text = Nothing
                lbFinYld.Text = Nothing
                tbJudgeReason.Text = Nothing
                cbxItem.Text = Nothing

                If informationText <> Nothing Then
                    Send(strHostName & ",00", SocketTCP)
                    '  SaveCatchLog(strHostName & ",00", "ReadData()")
                End If




                If DR.IsTotalQtyNull Then
                    KeyNumInput = StatusKey.Total 'Input Qty.if already input in data base will no pop up form
                    Dim lotinfo As LotInformation = c_ServiceiLibrary.GetLotInfo(WorkSlipQR.LotNo, My.Settings.MachineNo)
                    Dim Input As New InputQty(lotinfo.GoPiece)
                    Input.ShowDialog()
                    DR.TotalQty = OprData.InputQtyFrmVal                  'From inputQty Frm

                End If

                If DR.IsStartTimeNull Then     ' If already start time will continue And DR.Process = "" 
                    DR.StartTime = CDate(lbStartTime.Text) 'Format(Now, "yyyy/MM/dd HH:mm:ss")
                End If
                DR.InsName = My.Settings.MachineNo 'strHostName

                lbStartTime.Text = Format(DR.StartTime, "yyyy/MM/dd HH:mm:ss")

                'DB WB Alarm display --- ---- --- --- --- ---- ---- ---- ----

                LotAlarmQtyTbl = New DBxDataSet.LotAlarmQtyDataTable
                'Dim AlDr As DBxDataSet.LotAlarmQtyRow
                'AlDr = LotAlarmQtyTbl.NewRow
                If LotAlarmQtyTblQuery.Fill(LotAlarmQtyTbl, WorkSlipQR.LotNo) <> 0 Then ' Alarm Qty data from record
                    For Each row As DBxDataSet.LotAlarmQtyRow In LotAlarmQtyTbl
                        Select Case row.AlarmNo
                            Case 1, 20
                                If row.AlarmMess Like "*PICK UP*" Then ' If row.Process = "DB" Then
                                    lbDB01.Text = row.Qty
                                Else
                                    lbWb01.Text = row.Qty
                                End If
                            Case 2
                                lbWb02.Text = row.Qty
                            Case 4
                                If row.AlarmMess Like "*PREFORM*" Then ' If row.Process = "DB" Then
                                    lbDb04.Text = row.Qty
                                Else
                                    lbWb04.Text = row.Qty
                                End If
                            Case 6
                                lbDb06.Text = row.Qty
                            Case 7
                                lbDb07.Text = row.Qty
                            Case 14
                                lbDb14.Text = row.Qty
                            Case 16
                                lbDb16.Text = row.Qty
                            Case 17
                                lbWb17.Text = row.Qty
                            Case 18
                                lbWb18.Text = row.Qty
                            Case 19
                                lbWb19.Text = row.Qty
                            Case 99
                                If row.AlarmMess Like "*DB*" Then ' If row.Process = "DB" Then
                                    lbDB99.Text = row.Qty
                                Else
                                    lbWb99.Text = row.Qty

                                End If
                        End Select
                    Next

                End If
                '--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---

                lbLotNo.Text = WorkSlipQR.LotNo
                OprData.LotNo = lbLotNo.Text
                lbPackage.Text = WorkSlipQR.Package
                lbDevice.Text = WorkSlipQR.Device
                If DR.IsMCNoNull = False Then
                    lbMCNo.Text = DR.MCNo
                End If
                If DR.IsRemarkNull = False Then
                    lbRemark.Text = "Remark : " & DR.Remark
                End If


                lbinspectorID.Text = OprData.OPID
                lbObjInsp.Text = DR.ObjectIns
                lbProcess.Text = DR.Process
                DR.InspectorNo = lbinspectorID.Text
                ImageLoad(OprData.OPID)
                'lbLotNo.Text = WorkSlipQR.LotNo
                'lbPackage.Text = WorkSlipQR.Package
                'lbDevice.Text = WorkSlipQR.Device
                'lbinspectorID.Text = OprData.OPID
                'lbObjInsp.Text = DR.ObjectIns
                'lbProcess.Text = DR.Process
                'DR.InspectorNo = lbinspectorID.Text

                If DR.IsStartTimeNull Then     ' If already start time will continue
                    DR.StartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
                End If

                lbTotal.Text = DR.TotalQty
                Check_InputTotal = False
                If DR.ObjectIns <> "ALL" Then
                    lbTotal.BackColor = Color.Red
                Else
                    lbTotal.BackColor = Color.LawnGreen
                End If

                Try
                    'dgvTotal.Item(13, 0).Value = 0                'Gross Total cell
                    lbNG.Text = 0
                    lbGood.Text = CInt(lbTotal.Text) - CInt(lbNG.Text)
                    lbFinYld.Text = FormatNumber((1 - (CInt(lbNG.Text) / CInt(lbTotal.Text))) * 100, 2)
                Catch ex As Exception

                End Try
                If dgvInspDetail.RowCount > 0 Then DBxDataSet.Inspection_Detail.Rows.Clear() 'Clear Inspection_Detail

                If dgvTotal.RowCount > 0 Then dgvTotal.Rows.Clear()

                If Not DR.IsRequestModeName1Null Then                                     'Set initail item Inspection_Detail
                    If DR.RequestModeName1 <> "" Then
                        lbReq1.Text = "1. " & DR.RequestModeName1
                        lbReq1Remark.Text = DR.RequestModeRemark1
                        'DBxDataSet.Inspection_Detail.Rows.Add(DR.RequestModeName1)        'Add to inspection table
                        'DBxDataSet.Inspection_Detail.Rows(DR.RequestModeName1).Item("ModeNo") = DR.RequestMode1
                    End If

                End If
                If Not DR.IsRequestModeName2Null Then
                    If DR.RequestModeName2 <> "" Then
                        lbReq2.Text = "2. " & DR.RequestModeName2
                        lbReq2Remark.Text = DR.RequestModeRemark2
                        'DBxDataSet.Inspection_Detail.Rows.Add(DR.RequestModeName2)          'Add to inspection table
                        'DBxDataSet.Inspection_Detail.Rows(DR.RequestModeName2).Item("ModeNo") = DR.RequestMode2
                    End If
                End If

                Try
                    DBWB_InsTblQuery.Update(DR)   'Update start time and inspector ID

                Catch ex As InvalidOperationException
                    MsgBox("Update Fail : " & ex.ToString)
                    SaveCatchLog(ex.ToString, "DBWB_InsTblQuery.Update(DR)")
                Catch ex As DBConcurrencyException
                    MsgBox("Update Fail : " & ex.ToString)
                    SaveCatchLog(ex.ToString, "DBWB_InsTblQuery.Update(DR)")
                End Try

                '----------------------------------------------------------------------------------------------------------------
                SetDefultItem(ProcessName.WB)
                TabControl1.SelectedTab = TabPage2

                Hilight()
                'Dim Ans = WorkSlipQR.TransactionDataSave(OprData.QrData)
                'If Ans Like "False*" Then
                '    slMessage.Text = Ans
                'End If
                PictureBox2.BackgroundImage = Nothing
                PictureBox1.BackgroundImage = Nothing
                If File.Exists(PathServer & lbProcess.Text & "\" & lbLotNo.Text & "_NG Sample.JPG") Then
                    PictureBox1.BackgroundImage = Image.FromFile(PathServer & lbProcess.Text & "\" & lbLotNo.Text & "_NG Sample.JPG")
                End If

            Catch ex As Exception
                slMessage.Text = "Catch Error ReadData()" & ex.ToString
                SaveCatchLog(ex.ToString, "ReadData()")
            End Try
            dgvTotal.Rows.Add("Total")
        Catch ex As Exception
            slMessage.Text = "Catch Error ReadData()" & ex.ToString
            SaveCatchLog(ex.ToString, "ReadData() main")
        End Try

    End Sub
    Private Sub Send(ByVal msg As String, ByVal client As Socket)

        Try
            Dim sendBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(msg)
            client.BeginSend(sendBytes, 0, sendBytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnSend), client)
            SaveCatchLog(msg, "Send()")
        Catch ex As ArgumentNullException             'buffer is null.
            '   MsgBox(ex.ToString)
            SaveCatchLog(ex.ToString, "Send()")
        Catch ex As SocketException                   'An error occurred when attempting to access the socket. 
            SaveCatchLog(ex.ToString, "Send()")
            '   MsgBox(ex.ToString)
        Catch ex As ObjectDisposedException           'Socket has been closed
            '   MsgBox(ex.ToString)
            SaveCatchLog(ex.ToString, "Send()")
        Catch ex As ArgumentOutOfRangeException       'Out of Range Error
            '     MsgBox(ex.ToString)
            SaveCatchLog(ex.ToString, "Send()")
        Catch ex As Exception
            '  MsgBox(ex.ToString)
            SaveCatchLog(ex.ToString, "Send()")
        End Try
    End Sub
    Private Sub OnSend(ByVal ar As IAsyncResult)
        Dim client As Socket = ar.AsyncState
        client.EndSend(ar)
    End Sub
    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim myPen As Pen
        myPen = New Pen(Color.RoyalBlue, 17)
        e.Graphics.DrawLine(myPen, 0, 10, Me.Width, 10)
        myPen = New Pen(Color.MidnightBlue, 1)
        e.Graphics.DrawLine(myPen, 0, 19, Me.Width, 19)
        myPen = New Pen(Color.PowderBlue, 25)
        e.Graphics.DrawLine(myPen, 0, 110, Me.Width, 110)
        myPen = New Pen(Color.CadetBlue, 1)
        e.Graphics.DrawLine(myPen, 1, 122, Me.Width, 122)
    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        Select Case e.TabPage.Text
            Case "Inspection Record"
                ' Set initial value to varible.
                If lbLotNo.Text.Length <> 10 Then
                    slMessage.Text = "กรุณา INPUT Work Slip"
                    'TabControl1.SelectedTab = TabPage1
                End If

                If dgvTotal.RowCount > 0 Then
                    Exit Sub
                End If
                dgvTotal.Rows.Add("Total")


                'If File.Exists(My.Application.Info.DirectoryPath & "\TableDetail.xml") Then
                '    If MsgBox("ต้องการโหลด ข้อมูลเก่า หรือไม่", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                '        DBxDataSet.Inspection_Detail.ReadXml(My.Application.Info.DirectoryPath & "\TableDetail.xml")
                '        For i = 1 To 12
                '            MagTotal(i)
                '        Next

                '    End If

                'End If



        End Select
    End Sub
    Enum ProcessName
        DB
        WB
    End Enum
    Private Sub SetDefultItem(process As ProcessName)

        Dim itemDbNg As String = "DB NG"
        If Not DBxDataSet.Inspection_Detail.Where(Function(x) x.INSPECTION_ITEM = itemDbNg).Any Then
            Dim nRow1 As DBxDataSet.Inspection_DetailRow
            nRow1 = DBxDataSet.Inspection_Detail.NewInspection_DetailRow
            nRow1.INSPECTION_ITEM = itemDbNg
            nRow1.ModeNo = "DB22"
            DBxDataSet.Inspection_Detail.Rows.Add(nRow1)
        End If


        If process = ProcessName.WB Then
            'Dim itemWBNg As String = "WB NG"
            'If Not DBxDataSet.Inspection_Detail.Where(Function(x) x.INSPECTION_ITEM = itemWBNg).Any Then
            '    Dim nRow3 As DBxDataSet.Inspection_DetailRow
            '    nRow3 = DBxDataSet.Inspection_Detail.NewInspection_DetailRow
            '    nRow3.INSPECTION_ITEM = itemWBNg
            '    nRow3.ModeNo = "WB27"
            '    DBxDataSet.Inspection_Detail.Rows.Add(nRow3)
            'End If
            Dim itemMakerNg As String = "Marker NG"
            If Not DBxDataSet.Inspection_Detail.Where(Function(x) x.INSPECTION_ITEM = itemMakerNg).Any Then
                Dim nRow2 As DBxDataSet.Inspection_DetailRow
                nRow2 = DBxDataSet.Inspection_Detail.NewInspection_DetailRow
                nRow2.INSPECTION_ITEM = itemMakerNg
                nRow2.ModeNo = "WB27"
                DBxDataSet.Inspection_Detail.Rows.Add(nRow2)
            End If
        End If
    End Sub
    Private Sub btnAddItem_Click(sender As System.Object, e As System.EventArgs) Handles btnAddItem.Click
        'SetDefultItem(ProcessName.DB)
        '  btnClear.Text = cbxItem.SelectedIndex
        SaveCatchLog("", "btnAddItem_Click()")
        For Each row As DBxDataSet.Inspection_DetailRow In DBxDataSet.Inspection_Detail.Rows
            If row.INSPECTION_ITEM.ToUpper = cbxItem.Text.Trim.ToUpper Then
                Exit Sub
            End If

        Next
        Dim CHECK As Boolean
        If cbxItem.SelectedIndex = -1 Then

        Else
            If ModeListCbItem(cbxItem.SelectedIndex).ModeName <> cbxItem.Text Then
                CHECK = True
            End If
        End If

        If cbxItem.Text.Trim = "" Then
            Exit Sub
        End If


        '----    Link undefine mode to DB22,WB27 OTHER Case for save to INS.InspectionDetail table
        '----    Link cbxitem select with mode 
        Dim nRow As DBxDataSet.Inspection_DetailRow
        nRow = DBxDataSet.Inspection_Detail.NewInspection_DetailRow
        If cbxItem.SelectedIndex = -1 Or CHECK = True Then              '-1 =  key in
            nRow.INSPECTION_ITEM = cbxItem.Text
            If lbProcess.Text = "DB" Then
                nRow.ModeNo = "DB22"
            Else
                nRow.ModeNo = "WB27"
            End If

            DBxDataSet.Inspection_Detail.Rows.Add(nRow)

        Else


            nRow.INSPECTION_ITEM = ModeListCbItem(cbxItem.SelectedIndex).ModeName
            nRow.ModeNo = ModeListCbItem(cbxItem.SelectedIndex).ModdeNo
            DBxDataSet.Inspection_Detail.Rows.Add(nRow)


        End If

        '-------------------------------------------------
        cbxItem.SelectedIndex = -1
        cbxItem.Text = ""

    End Sub

    Private Sub btnAddAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAll.Click
        SaveCatchLog("", "btnAddAll_Click()")
        'If dgvInspDetail.Rows.Count <> 0 Then
        '    Exit Sub
        'End If
        'SetDefultItem(ProcessName.WB)
        Try
            For i = 0 To ModeListCbItem.Count - 1
                For Each row As DBxDataSet.Inspection_DetailRow In DBxDataSet.Inspection_Detail.Rows    'Already exist in table confor
                    If row.INSPECTION_ITEM.ToUpper = ModeListCbItem(i).ModeName.ToUpper Then
                        GoTo ConFor
                    End If
                Next

                Dim nRow As DBxDataSet.Inspection_DetailRow
                nRow = DBxDataSet.Inspection_Detail.NewRow
                nRow.INSPECTION_ITEM = ModeListCbItem(i).ModeName
                nRow.ModeNo = ModeListCbItem(i).ModdeNo

                DBxDataSet.Inspection_Detail.Rows.Add(nRow)

ConFor:
            Next

        Catch ex As Exception
            SaveCatchLog(ex.Message, "btnAddAll_Click()")
        End Try

    End Sub

    Private Sub btnDB_Click(sender As System.Object, e As System.EventArgs) Handles btnDB.Click
        SaveCatchLog("", "btnDB_Click()")
        'SetDefultItem(ProcessName.DB)
        'If dgvInspDetail.Rows.Count <> 0 Then
        '    Exit Sub
        'End If
        Try
            For i = 7 To ModeListCbItem.Count - 1
                For Each row As DBxDataSet.Inspection_DetailRow In DBxDataSet.Inspection_Detail.Rows    'Already exist in table confor
                    If row.INSPECTION_ITEM.ToUpper = ModeListCbItem(i).ModeName.ToUpper Then
                        GoTo ConFor
                    End If
                Next

                Dim nRow As DBxDataSet.Inspection_DetailRow
                nRow = DBxDataSet.Inspection_Detail.NewRow
                nRow.INSPECTION_ITEM = ModeListCbItem(i).ModeName
                nRow.ModeNo = ModeListCbItem(i).ModdeNo
                DBxDataSet.Inspection_Detail.Rows.Add(nRow)
ConFor:
            Next

        Catch ex As Exception
            SaveCatchLog(ex.Message, "btnDB_Click()")
        End Try

    End Sub
    Private Sub btnWB_Click(sender As System.Object, e As System.EventArgs) Handles btnWB.Click
        'If dgvInspDetail.Rows.Count <> 0 Then
        '    Exit Sub
        'End If
        SaveCatchLog("", "btnWB_Click()")
        'SetDefultItem(ProcessName.WB)
        Try
            For i = 0 To 20
                For Each row As DBxDataSet.Inspection_DetailRow In DBxDataSet.Inspection_Detail.Rows    'Already exist in table confor
                    If row.INSPECTION_ITEM.ToUpper = ModeListCbItem(i).ModeName.ToUpper Then
                        GoTo ConFor
                    End If
                Next
                Dim nRow As DBxDataSet.Inspection_DetailRow
                nRow = DBxDataSet.Inspection_Detail.NewRow
                nRow.INSPECTION_ITEM = ModeListCbItem(i).ModeName
                nRow.ModeNo = ModeListCbItem(i).ModdeNo
                DBxDataSet.Inspection_Detail.Rows.Add(nRow)
ConFor:
            Next

        Catch ex As Exception
            SaveCatchLog(ex.Message, "btnWB_Click()")
        End Try
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs)
        'If dgvTotal.Rows(0).Cells(13).Value IsNot Nothing Then
        '    slMessage.Text = "ไม่สามารถ Clearตาราง ที่มีการบันทึกแล้ว"
        '    Exit Sub
        'End If


        'If Not MsgBox("คูณต้องการลบข้อมูลทั้งหมด", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
        '    Exit Sub
        'End If

        'DBxDataSet.Inspection_Detail.Rows.Clear()
        'dgvTotal.Rows.Clear()
        'dgvTotal.Rows.Add("Total")

        'CountFoscus = New Point

    End Sub

    Private Sub dgvInspDetail_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInspDetail.CellClick
        Try
            If e.ColumnIndex = 13 Then  'TL Column ignor
                Exit Sub
            End If

            lbInspecItem.Text = dgvInspDetail.Item(0, e.RowIndex).Value   ' column 0 inspection item 
            'If e.RowIndex >= M1 And e.RowIndex <= M2 Then

            'Else
            '    Exit Sub
            'End If
            CountFoscus.Y = e.RowIndex
            If e.ColumnIndex <> 0 And e.ColumnIndex <> 13 Then    ' Column name display (except collumn 0)
                GroupBox1.Text = dgvInspDetail.Columns.Item(e.ColumnIndex).HeaderText

                CountFoscus.X = e.ColumnIndex
            End If
            If e.ColumnIndex = 0 Then
                If lbEndTime.Text <> "" Then
                    slMessage.Text = "Lot นี้ End Inspection แล้ว เวลา " & lbEndTime.Text
                    Exit Sub
                End If
                AddCounter()
            End If
            SaveTime = True
        Catch ex As Exception
            SaveCatchLog(ex.Message, "dgvInspDetail_CellClick()")
        End Try
        Try
            If IsDBNull(DBxDataSet.Inspection_Detail.Rows(CountFoscus.Y).Item(CountFoscus.X)) Then
                lbToVal.Text = "0"
            Else
                lbToVal.Text = DBxDataSet.Inspection_Detail.Rows(CountFoscus.Y).Item(CountFoscus.X)
            End If

        Catch ex As Exception
            SaveCatchLog(ex.Message, "dgvInspDetail_CellClick()2")
        End Try



    End Sub

    Private Sub DeleteCellToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteCellToolStripMenuItem.Click
        If Not MsgBox("ต้องการลบ " & dgvInspDetail.Rows(CellSelct.Y).Cells(0).Value, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Exit Sub
        End If
        dgvInspDetail.Rows.Remove(dgvInspDetail.Rows(CellSelct.Y))

    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        OpenFileDialog1.InitialDirectory = My.Settings.DirectoryFile
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox2.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnPlus_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus.Click
        If lbEndTime.Text <> "" Then
            slMessage.Text = "Lot นี้ End Inspection แล้ว เวลา " & lbEndTime.Text
            Exit Sub
        End If
        AddCounter()
    End Sub
    Dim Gtotal As Integer
    Private Sub MagTotal(ByVal ColumnIndex As Integer)


        Dim TotalCount As String = 0
        Gtotal = 0
        'If rbtLotJudgeNG.Checked = True Then

        'Else

        'End If
        Try

            For Each Count As DBxDataSet.Inspection_DetailRow In DBxDataSet.Inspection_Detail.Rows
                If Not IsDBNull(Count.Item(ColumnIndex)) Then
                    TotalCount = TotalCount + CInt(Count.Item(ColumnIndex))
                End If
            Next

            dgvTotal.Item(ColumnIndex, 0).Value = TotalCount


            For i = 1 To 12                                      'Gross Total sum
                If dgvTotal.Item(i, 0).Value <> "" Then
                    Gtotal = dgvTotal.Item(i, 0).Value + Gtotal
                End If
            Next

            dgvTotal.Item(13, 0).Value = Gtotal                'Gross Total cell
            lbNG.Text = Gtotal
            lbGood.Text = CInt(lbTotal.Text) - CInt(lbNG.Text)
            lbFinYld.Text = FormatNumber((1 - (CInt(lbNG.Text) / CInt(lbTotal.Text))) * 100, 2)

        Catch ex As Exception
            SaveCatchLog(ex.Message, "MagTotal()")
        End Try
    End Sub

    Private Sub ModeTotal(ByVal RowIndex As Integer)
        Dim TotalCount As Integer = 0
        Try

            For i = 1 To 12
                If Not IsDBNull(DBxDataSet.Inspection_Detail.Rows(RowIndex).Item(i)) Then
                    TotalCount = DBxDataSet.Inspection_Detail.Rows(RowIndex).Item(i) + TotalCount
                End If

            Next

            DBxDataSet.Inspection_Detail.Rows(RowIndex).Item(13) = TotalCount
            DBxDataSet.Inspection_Detail.Rows(0).Item(14) = lbLotNo.Text
            Inspection_DetailBindingSource.EndEdit()
            DBxDataSet.Inspection_Detail.WriteXml(My.Application.Info.DirectoryPath & "\TableDetail.xml")

            'DBxDataSet.Inspection_Detail.WriteXmlSchema(My.Application.Info.DirectoryPath & "\TableDetailSchema.xml")
        Catch ex As Exception
            SaveCatchLog(ex.Message, "ModeTotal()")
        End Try
    End Sub


    Private Sub AddCounter()
        Dim currentValue As String
        Try
            If CountFoscus.X = 0 And dgvInspDetail.Rows.Count <> 0 Then
                MsgBox("กรูณาเลือก Magazine No.")
                Exit Sub
            End If
            If IsDBNull(DBxDataSet.Inspection_Detail.Rows(CountFoscus.Y).Item(CountFoscus.X)) Then
                DBxDataSet.Inspection_Detail.Rows(CountFoscus.Y).Item(CountFoscus.X) = 0
            End If
            currentValue = DBxDataSet.Inspection_Detail.Rows(CountFoscus.Y).Item(CountFoscus.X)
            currentValue += 1

            'dgvInspDetail.Item(CountFoscus.X, CountFoscus.Y).Value = currentValue

            'DBxDataSet.Inspection_Detail.Rows(CountFoscus.Y).Item(CountFoscus.X) = currentValue

            Dim sum As Double
            Dim sum2 As Double
            sum = Convert.ToDouble(lbVal.Text)
            sum2 = Convert.ToDouble(currentValue)

            If Trim(lbVal.Text) <> "0" Then
                sum2 = sum + sum2 - 1
                'If sum < 0 Then
                '    lbToVal.Text = "0"
                '    lbVal.Text = "0"
                'Else
                '    lbToVal.Text = sum.ToString()
                '    lbVal.Text = "0"
                'End If
                ' lbToVal.Text = sum.ToString()
                lbVal.Text = "1"

            End If
            If sum2 <= 0 Then
                sum2 = 0
            End If
            'sum = sum + sum2
            'lbToVal.Text = currentValue
            DBxDataSet.Inspection_Detail.Rows(CountFoscus.Y).Item(CountFoscus.X) = sum2.ToString()
            lbToVal.Text = sum2.ToString()
            'lbToVal.Text = currentValue

            MagTotal(CountFoscus.X)
            ModeTotal(CountFoscus.Y)
        Catch ex As Exception
            SaveCatchLog(ex.Message, "AddCounter()")

        End Try

    End Sub


    Private Sub btnminus_Click(sender As System.Object, e As System.EventArgs) Handles btnminus.Click
        If lbEndTime.Text <> "" Then
            slMessage.Text = "Lot นี้ End Inspection แล้ว เวลา " & lbEndTime.Text
            Exit Sub
        End If
        Dim currentValue As String
        Try
            If CountFoscus.X = 0 And dgvInspDetail.Rows.Count <> 0 Then
                MsgBox("กรูณาเลือก Magazine No.")
                Exit Sub
            End If

            '------------
            Try
                currentValue = dgvInspDetail.Item(CountFoscus.X, CountFoscus.Y).Value
            Catch ex As Exception
                currentValue = 0
                GoTo EndLoop
            End Try

            If currentValue <> "" Then
                If currentValue = 0 Then

                    dgvInspDetail.Item(CountFoscus.X, CountFoscus.Y).Value = DBNull.Value
                    MagTotal(CountFoscus.X)
                    ModeTotal(CountFoscus.Y)
                    Exit Sub
                    ' GoTo EndLoop
                End If
                If lbVal.Text <> "0" Then
                    'If Not MsgBox("ต้องการลบข้อมูลลง (" & Convert.ToDouble(lbVal.Text) & ")", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    '    Exit Sub
                    'End If
                    currentValue -= Convert.ToDouble(lbVal.Text) '****
                    If currentValue < 0 Then
                        currentValue = 0
                    End If

                    lbToVal.Text = currentValue
                    lbVal.Text = "1"

                Else
                    'If Not MsgBox("ต้องการลบข้อมูลลง (-1)", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    '    Exit Sub
                    'End If
                    currentValue -= 1
                    If currentValue < 0 Then
                        currentValue = 0
                    End If
                    lbToVal.Text = currentValue '****

                End If

            Else
                currentValue = 0
            End If

EndLoop:
            'If currentValue < 0 Then
            '    currentValue = 0
            'End If
            lbVal.Text = "1"
            dgvInspDetail.Item(CountFoscus.X, CountFoscus.Y).Value = currentValue
            MagTotal(CountFoscus.X)
            ModeTotal(CountFoscus.Y)
        Catch ex As Exception

            SaveCatchLog(ex.Message, "btnminus_Click()")
        End Try
    End Sub
    Private Sub GroupBox1_MouseHover(sender As Object, e As System.EventArgs) Handles btnPlus.MouseHover, btnminus.MouseHover
        Try
            dgvInspDetail.ClearSelection()
            dgvInspDetail.Item(CountFoscus.X, CountFoscus.Y).Selected = True
        Catch ex As Exception
            SaveCatchLog(ex.Message, "GroupBox1_MouseHover()")
        End Try

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        Dim frameScrap As Integer = 0
        Dim frmEndAdjust As FormEndLotAdjust = New FormEndLotAdjust(DBxDataSet.Inspection_Detail)
        Dim frmEndAdjustResult As DialogResult = frmEndAdjust.ShowDialog()
        If frmEndAdjustResult = DialogResult.No Then
            Dim frmSrcap As InputAdjustScrapDailog = New InputAdjustScrapDailog(DBxDataSet.Inspection_Detail)
            Dim frmSrcapResult As DialogResult = frmSrcap.ShowDialog()
            If frmSrcapResult <> DialogResult.OK Then
                Exit Sub
            End If
            frameScrap = frmSrcap.FrameScrap.Value
        ElseIf frmEndAdjustResult <> DialogResult.Yes Then
            Exit Sub
        End If


        Dim inspNgAdjustlist As List(Of InspectionDataAdjust) = New List(Of InspectionDataAdjust)
        Dim dbNg As InspectionDataAdjust = New InspectionDataAdjust
        dbNg.InspectionItem = "DB NG"
        dbNg.TotalNg = 0
        dbNg.Scrap = 0
        inspNgAdjustlist.Add(dbNg)
        Dim wbNg As InspectionDataAdjust = New InspectionDataAdjust
        wbNg.InspectionItem = "WB NG"
        wbNg.TotalNg = 0
        wbNg.Scrap = 0
        inspNgAdjustlist.Add(wbNg)
        Dim markerNG As InspectionDataAdjust = New InspectionDataAdjust
        markerNG.InspectionItem = "Marker NG"
        markerNG.TotalNg = 0
        markerNG.Scrap = 0
        inspNgAdjustlist.Add(markerNG)
        Dim inspectionNG As InspectionDataAdjust = New InspectionDataAdjust
        inspectionNG.InspectionItem = "Inspection NG"
        inspectionNG.TotalNg = 0
        inspectionNG.Scrap = 0
        inspNgAdjustlist.Add(inspectionNG)

        'Dim NgList As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)

        'NgList.Add("DB NG", 0)
        'NgList.Add("WB NG", 0)
        'NgList.Add("Marker NG", 0)
        'NgList.Add("Inspection NG", 0)
        For Each lotdata As DBxDataSet.Inspection_DetailRow In DBxDataSet.Inspection_Detail

            If (lotdata.IsTLNull) Then
                lotdata.TL = 0
            End If
            If (lotdata.IsScrapNull) Then
                lotdata.Scrap = 0
            End If

            'Select Case lotdata.INSPECTION_ITEM.ToUpper
            '    Case "DB NG".ToUpper, "WB NG".ToUpper, "Marker NG".ToUpper
            '        NgList(lotdata.INSPECTION_ITEM) = lotdata.TL - lotdata.Scrap
            '    Case Else
            '        NgList("Inspection NG") = NgList("Inspection NG") + lotdata.TL - lotdata.Scrap
            'End Select
            Dim itemName As String
            If lotdata.INSPECTION_ITEM = "DB NG" Then
                itemName = "DB NG"
            ElseIf lotdata.INSPECTION_ITEM = "Marker NG" Then
                itemName = "Marker NG"
            ElseIf lotdata.INSPECTION_ITEM.Contains("[WB NG]") Then
                itemName = "WB NG"
            Else
                itemName = "Inspection NG"
            End If
            Dim data = inspNgAdjustlist.Where(Function(x) x.InspectionItem = itemName).First
            data.TotalNg = lotdata.TL
            data.Scrap = lotdata.Scrap


            'If inspNgAdjustlist.Where(Function(x) x.InspectionItem = lotdata.INSPECTION_ITEM).Any Then
            '    Dim data = inspNgAdjustlist.Where(Function(x) x.InspectionItem = lotdata.INSPECTION_ITEM).First
            '    data.TotalNg = lotdata.TL
            '    data.Scrap = lotdata.Scrap
            'ElseIf inspNgAdjustlist.Where(Function(x) x.InspectionItem = "WB NG").Any Then
            '    Dim data = inspNgAdjustlist.Where(Function(x) x.InspectionItem = "WB NG").First
            '    data.TotalNg = lotdata.TL
            '    data.Scrap = lotdata.Scrap
            'Else
            '    Dim data = inspNgAdjustlist.Where(Function(x) x.InspectionItem = "Inspection NG").First
            '    data.TotalNg += lotdata.TL
            '    data.Scrap += lotdata.Scrap
            'End If
        Next

        SaveCatchLog("", "btnSave_Click()")
        '  btTimePause.Visible = False



        Try
            'If dgvTotal.Item(13, 0).Value = 0 And rbtLotJudgeOK.Checked = False Then              'If no data no action
            '    slMessage.Text = "ไม่มีข้อมูล"
            '    Exit Sub
            'End If

            If rbtLotJudgeNG.Checked Or rbtLotJudgeOK.Checked Then
                If rbtLotJudgeNG.Checked And (tbJudgeReason.Text = "Remark" Or tbJudgeReason.Text = "") Then
                    slMessage.Text = "กรุณาระบุ Remark"
                    Exit Sub
                End If
            Else
                slMessage.Text = "กรุณาตัดสินใจ ในช่อง Lot Judge"
                Exit Sub
            End If
            'Try
            '    tbQR_GL.Text = (Convert.ToInt16(tbQR_GL.Text))
            'Catch ex As Exception
            '    tbQR_GL.Text = ""
            'End Try
            If tbQR_GL.Text.Length <> 6 Then
                slMessage.Text = "กรุณาทำการ GL Check"
                tbQR_GL.Text = ""
                Exit Sub
            End If


            If File.Exists(My.Application.Info.DirectoryPath & "\TableDetail.xml") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TableDetail.xml")
            End If

            If Not My.Computer.Network.IsAvailable Then                'unplug check
                MsgBox("PC Nework point unplug")
                Exit Sub
            End If
            If Not My.Computer.Network.Ping("172.16.0.100") Then            'Can Pink Zion
                MsgBox("การเชื่อมต่อกับ 172.16.0.100 ล้มเหลวไม่สามารถดำเนินการต่อได้")
                Exit Sub
            End If


            Dim dateEnd As Date = Format(Now, "yyyy/MM/dd HH:mm:ss")

            Try

                ''------------------Update End to DBX.INS.DBWBINSData
                DBWB_InsTbl = New DBxDataSet.DBWBINSDataDataTable
                Dim DR As DBxDataSet.DBWBINSDataRow
                DR = DBWB_InsTbl.NewRow
                If DBWB_InsTblQuery.FillBy1(DBWB_InsTbl, lbLotNo.Text, lbProcess.Text) = 0 Then
                    slMessage.Text = "Lot นี้ยังไม่ได้ ทำการ บันทึก Inspection Request หรือ End Inspection แล้ว"
                    Exit Sub
                End If

                Try  'lbLotNo.Text, My.Settings.MachineNo, lbinspectorID.Text, lbGood.Text, lbNG.Text
                    Dim lotInfo = c_ServiceiLibrary.GetLotInfo(lbLotNo.Text, My.Settings.MachineNo)

                    Dim inspDbAdjust As InspectionDataAdjust = inspNgAdjustlist.Where(Function(x) x.InspectionItem = "DB NG").First
                    Dim inspWbAdjust As InspectionDataAdjust = inspNgAdjustlist.Where(Function(x) x.InspectionItem = "WB NG").First
                    Dim inspMarkerAdjust As InspectionDataAdjust = inspNgAdjustlist.Where(Function(x) x.InspectionItem = "Marker NG").First
                    'Dim insFrontNg As Integer = (inspDbAdjust.TotalNg - inspDbAdjust.Scrap) + (inspWbAdjust.TotalNg - inspWbAdjust.Scrap) + (inspMarkerAdjust.TotalNg - inspMarkerAdjust.Scrap)

                    Dim piecePerFrame As Double = lotInfo.GoPiece / lotInfo.FramePass
                    Dim inspAdjust As InspectionDataAdjust = inspNgAdjustlist.Where(Function(x) x.InspectionItem = "Inspection NG").First
                    Dim inspNg As Integer = inspAdjust.TotalNg + ((frameScrap * piecePerFrame) - inspAdjust.Scrap - inspDbAdjust.Scrap - inspWbAdjust.Scrap - inspMarkerAdjust.Scrap)
                    Dim insFrontNg As Integer = inspAdjust.TotalNg - inspAdjust.Scrap
                    Dim fronNgScrap As Integer = inspDbAdjust.Scrap + inspWbAdjust.Scrap + inspMarkerAdjust.Scrap

                    Dim carrierInfo = c_ServiceiLibrary.GetCarrierInfo(My.Settings.MachineNo, lbLotNo.Text, lbinspectorID.Text)
                    Dim endLotSpecial As EndLotSpecialParametersEventArgs = New EndLotSpecialParametersEventArgs
                    endLotSpecial.FrameFail = frameScrap
                    endLotSpecial.FramePass = lotInfo.FramePass - frameScrap
                    endLotSpecial.Front_Ng = insFrontNg
                    endLotSpecial.Front_Ng_Scrap = fronNgScrap
                    'endLotSpecial.MarkerNg = inspMarkerAdjust.TotalNg - inspMarkerAdjust.Scrap
                    'endLotSpecial.Front_Ng = 0
                    'endLotSpecial.PNashi = 0
                    'endLotSpecial.MarkerNg = 0
                    Dim result As EndLotResult = c_ServiceiLibrary.EndLotPhase2(lbLotNo.Text, My.Settings.MachineNo, lbinspectorID.Text, lbGood.Text, inspNg, Licenser.NoCheck, carrierInfo, endLotSpecial)
                    If Not result.IsPass AndAlso result.Type = MessageType.Apcs Then
                        MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString)
                        Exit Sub
                    End If
                    c_ServiceiLibrary.UpdateMachineState(My.Settings.MachineNo, MachineProcessingState.Idle)
                Catch ex As Exception
                    MessageBoxDialog.ShowMessage("EndLot", ex.Message.ToString, "iLibrary Service")
                End Try

                '  lbEndTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
                DR = DBWB_InsTbl.Rows(0)
                DR.TotalQty = lbTotal.Text
                DR.EndTime = dateEnd
                'DR.EndTime = lbEndTime.Text
                DR.NGQty = dgvTotal.Item(13, 0).Value
                DR.FinalYield = lbFinYld.Text
                DR.GoodQty = lbGood.Text

                If rbtLotJudgeOK.Checked Then
                    DR.LotJudg = "OK"
                Else
                    DR.LotJudg = "NG"
                End If
                Dim num As Integer
                For i = 0 To DBxDataSet.Inspection_Detail.Rows.Count - 1
                    If IsDBNull(DBxDataSet.Inspection_Detail.Rows(i).Item("TL")) Or DBxDataSet.Inspection_Detail.Rows(i).Item("TL").ToString() = "0" Then
                    Else
                        num = num + 1

                        DR.Item("ResultMode" & num) = DBxDataSet.Inspection_Detail.Rows(i).Item("ModeNo")
                        DR.Item("ResultModeName" & num) = DBxDataSet.Inspection_Detail.Rows(i).Item(0)
                        DR.Item("ResultQtyMode" & num) = CShort(DBxDataSet.Inspection_Detail.Rows(i).Item("TL"))
                        If num > 4 Then      'workrecord max 5 rec.
                            ' Exit Sub
                            Exit For
                        End If
                    End If
                Next
                DR.JudgeReason = tbJudgeReason.Text
                DR.GLCheck = tbQR_GL.Text
                DBWB_InsTblQuery.Update(DR)
                '-----------------------------------------------------
            Catch ex As Exception
                slMessage.Text = "Save Fail" & ex.ToString
                SaveCatchLog(ex.Message, "btnSave_Click()>>DBWBINSDataDataTable>>")
                Exit Sub
            End Try

            'Select Count
            'Dim CountRow As Integer
            'For i = 0 To DBxDataSet.Inspection_Detail.Rows.Count - 1
            '    If IsDBNull(DBxDataSet.Inspection_Detail.Rows(i).Item("TL")) Or DBxDataSet.Inspection_Detail.Rows(i).Item("TL").ToString() = "0" Then
            '    Else
            '        CountRow = CountRow + 1
            '        If CountRow > 5 Then
            '            MsgBox("INSPECTION ITEM ได้สูงสุด 5 รายการ")
            '            Exit Sub
            '        End If
            '    End If
            'Next

            '------------------Update End to DBX.INS.Detail-------

            'Inspection_Detail  >>  DataTable in software
            'InspectionDetai    >>  Data table in Dbx



            Try
                '---------------------------------------------------------------------------------------
                InspDetail = New DBxDataSet.InspectionDetailDataTable
                For Each row As DBxDataSet.Inspection_DetailRow In DBxDataSet.Inspection_Detail.Rows

                    If Not row.IsTLNull Then

                        Dim Detail As DBxDataSet.InspectionDetailRow
                        Detail = InspDetail.NewRow
                        Detail.LotNo = lbLotNo.Text
                        If PictureBox2.BackgroundImage IsNot Nothing Then
                            Detail.LinkShoko = PathServer & lbProcess.Text & "\" & lbLotNo.Text & "_SHOKONOKOSHI.JPG"
                        End If
                        Detail.Process = lbProcess.Text
                        If Not row.Is_1MNull Then Detail._1M = row._1M
                        If Not row.Is_2MNull Then Detail._2M = row._2M
                        If Not row.Is_3MNull Then Detail._3M = row._3M
                        If Not row.Is_4MNull Then Detail._4M = row._4M
                        If Not row.Is_5MNull Then Detail._5M = row._5M
                        If Not row.Is_6MNull Then Detail._6M = row._6M
                        If Not row.Is_7MNull Then Detail._7M = row._7M
                        If Not row.Is_8MNull Then Detail._8M = row._8M
                        If Not row.Is_9MNull Then Detail._9M = row._9M
                        If Not row.Is_10MNull Then Detail._10M = row._10M
                        If Not row.Is_11MNull Then Detail._11M = row._11M
                        If Not row.Is_12MNull Then Detail._12M = row._12M
                        If Not row.IsScrapNull Then Detail.Scrap = row.Scrap
                        Detail.InspectionItem = row.INSPECTION_ITEM
                        Detail.ModeNo = row.ModeNo
                        'Detail.InsEndTime = DateTime.Parse(lbEndTime.Text)
                        'Detail.InsEndTime = "2560/06/12 10:09:05"


                        Detail.InsEndTime = dateEnd

                        ' Detail.InsEndTime = lbEndTime.Text
                        InspDetail.Rows.Add(Detail)

                    End If
                Next
                Dim a = InspDetailQuery.Update(InspDetail)


                '-----------------------------------------------------
            Catch ex As Exception
                slMessage.Text = "Save Fail" & ex.ToString
                SaveCatchLog(ex.Message, "btnSave_Click()>>InspectionDetailDataTable>>")
                Exit Sub
            End Try

            Try

                '----------------------------------------------
                If PictureBox2.BackgroundImage IsNot Nothing Then
                    PictureBox2.BackgroundImage.Save(PathServer & lbProcess.Text & "\" & lbLotNo.Text & "_SHOKONOKOSHI.JPG")

                End If
            Catch ex As Exception
                'slMessage.Text = "Save Fail" & ex.ToString
                SaveCatchLog(ex.Message, "btnSave_Click()PictureBox2")
            End Try

            'TotalTime
            Me.DbwbinsData1TableAdapter1.Fill(DBxDataSet.DBWBINSData1, lbLotNo.Text, lbProcess.Text)
            For Each DBTotalTime As DBxDataSet.DBWBINSData1Row In DBxDataSet.DBWBINSData1


                DBTotalTime.EndTime = dateEnd 'Format(Format(Now, "yyyy/MM/dd HH:mm:ss"))
                Dim total As Integer = DateDiff(DateInterval.Minute, DBTotalTime.StartTime, DBTotalTime.EndTime)
                If total > 32760 Then
                    Exit For
                End If
                ' Dim str As String =
                Dim StopTime As TimeSpan = New TimeSpan(CInt(lbSTOP.Text.Split(":")(0)), CInt(lbSTOP.Text.Split(":")(1)), 0)
                DBTotalTime.TotalTime = CInt(total - StopTime.TotalMinutes)
                DBTotalTime.StopTime = StopTime.TotalMinutes
                '(MsgBox("เวลาในการใช้งาน " & total & " นาที"))

                '  MsgBox(DateDiff(DateInterval.Minute, x, y).ToString())
                '   Dim aaaa As New TimeSpan(0, 121, 0)
                ' MsgBox(aaaa.Hours & ":" & (aaaa.Minutes Mod 60).ToString("00"))
            Next

            DbwbinsData1TableAdapter1.Update(DBxDataSet.DBWBINSData1)


            'Coding save image part and data inspect to data base
            TimerRun.Stop()
            lbEndTime.Text = dateEnd
            Gtotal = 0
            slMessage.Text = "Save Success"
            TabControl1.SelectedTab = TabPage1
            ClearTime()

            'Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://http://webserv/WBWIP/WBWIP.aspx?LotNo=" & lbLotNo.Text & "&Process=" & lbProcess.Text & "&MCNo=" & lbMCNo.Text & "&OPNo=" & lbinspectorID.Text & "&Package=" & lbPackage.Text & "&NextProcess=WB", AppWinStyle.NormalFocus)
        Catch ex As Exception
            slMessage.Text = "Save Fail" & ex.ToString
            SaveCatchLog(ex.Message, "btnSave_Click()")
        End Try
    End Sub
    Private Sub ClearTime()
        SaveTime = False
        My.Settings.Rss = 0
        My.Settings.RMM = 0
        My.Settings.RHH = 0
        My.Settings.SPss = 0
        My.Settings.SPMM = 0
        My.Settings.SPHH = 0
    End Sub
    Private Sub dgvInspDetail_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInspDetail.CellMouseEnter
        If e.ColumnIndex = 0 Then
            Try
                dgvInspDetail.ClearSelection()
                dgvInspDetail.Item(CountFoscus.X, e.RowIndex).Selected = True

            Catch ex As Exception

            End Try
        End If
        CellSelct.X = e.ColumnIndex
        CellSelct.Y = e.RowIndex
    End Sub
    Private Sub SendToBackToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SendToBackToolStripMenuItem.Click
        Me.SendToBack()
    End Sub
    Private Sub pbxQR_Click(sender As System.Object, e As System.EventArgs) Handles pbxQR.Click, btnWorkSlip.Click

        'If Not IsNumeric(btnOPID.Text) Then
        '    MsgBox("กรุณา Input OPID ก่อน")
        '    Exit Sub
        'End If
        If btnOPID.Text.Length <> 6 Then
            MsgBox("กรุณา Input OPID ก่อน")
            Exit Sub
        End If
        tbxKey.Text = ""
        tbxKey.Focus()
        btnWorkSlip.ForeColor = Color.Green
        'RaiseEvent E_WorkSlipClick()
        slMessage.Text = "Please Read Work Slip QR Data"
    End Sub


    Private Sub tbxKey_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxKey.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If tbxKey.Text.Length = 252 Then
                '     TabControl1.TabPages.Add(TabPage2) '********
                OprData.QrData = tbxKey.Text.ToUpper
                tbxKey.Text = ""

                ' QR_DataRead()
                ReadData(Nothing)
                pbxQR.Focus()
                TimerRun.Start()
                '           lbStartTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
                lbEndTime.Text = ""
            Else
                tbxKey.Text = ""
                slMessage.Text = "QR Slip Read False"
            End If
        End If
        btnWorkSlip.ForeColor = Color.Black
    End Sub
    Private Sub pbxOPID_Click(sender As System.Object, e As System.EventArgs) Handles pbxOPID.Click, btnOPID.Click

        If Not My.Computer.Network.IsAvailable Then                'unplug check
            MsgBox("PC Nework point unplug")
            slMessage.Text = "สาย LAN ไม่ได้เชื่อมต่อ "
            Exit Sub
        End If
        If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Can Pink if Computer Connect only
            MsgBox("การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้")
            slMessage.Text = "การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้ "
            Exit Sub
        End If

        tbxQR_OPID.Text = ""
        tbxQR_OPID.Focus()
        btnOPID.ForeColor = Color.Green
        slMessage.Text = "Please Read OPID QR Data"

    End Sub

    Private Sub tbxQR_OPID_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxQR_OPID.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then

            If tbxQR_OPID.Text.Length = 6 Then                   'OPID Qr length is 6
                'If Not IsNumeric(tbxQR_OPID.Text) Then
                '    Exit Sub
                'End If
                OprData.OPID = tbxQR_OPID.Text
                tbxQR_OPID.Text = ""
                btnOPID.Text = OprData.OPID
                QR_OPIDRead()
                pbxOPID.Focus()
            Else
                slMessage.Text = "OP ID Read False : " & tbxQR_OPID.Text
                tbxQR_OPID.Text = ""

            End If
        End If
        btnOPID.ForeColor = Color.Black

    End Sub

    '    Private Sub QR_DataRead()
    '        Try
    '            btQR.BackColor = SystemColors.Control
    '            rbtLotJudgeOK.Checked = False
    '            rbtLotJudgeNG.Checked = False
    '            slMessage.Text = "QR Work Slip Read Success_" & Format(Now, "HH:mm:ss.fff")
    '            If Not InspectorPermission(OprData.QrData, OprData.OPID, My.Settings.UserAuthenOP, My.Settings.UserAuthenGL) Then
    '                If My.Settings.UserAuthenOP = "NOUSE" Then  'Bypass Auten  Check only Lot automotive
    '                    GoTo BypassAuter
    '                End If
    '                MsgBox(ErrMesETG)
    '                If ErrMesETG Like "OP*" Then
    '                    btnOPID.Text = "OPID"
    '                    lbinspectorID.Text = "OPID"
    '                End If
    '                '   pbxAutoM.Visible = False
    '                Exit Sub
    '            End If
    'BypassAuter:
    '            If OprData.AutoMotiveLot Then     'CD Machine lot 1:n nouse
    '                '   pbxAutoM.Visible = True
    '            End If

    '            '----- initial data ----------------------------------------------------------------------------------------
    '            Dim WorkSlipQR As New WorkingSlipQRCode
    '            WorkSlipQR.SplitQRCode(OprData.QrData)

    '            DBWB_InsTbl = New DBxDataSet.DBWBINSDataDataTable
    '            Dim DR As DBxDataSet.DBWBINSDataRow
    '            DR = DBWB_InsTbl.NewRow
    '            If DBWB_InsTblQuery.Fill(DBWB_InsTbl, WorkSlipQR.LotNo) = 0 Then
    '                slMessage.Text = "Lot นี้ยังไม่ได้ ทำการ บันทึก Inspection Request หรือ End Inspection แล้ว"
    '                Exit Sub
    '            End If
    '            SPss = 0
    '            SPHH = 0
    '            SPMM = 0
    '            RHH = 0
    '            RMM = 0
    '            Rss = 0
    '            lbToVal.Text = Nothing
    '            lbSTOP.Text = "00:00:00"
    '            lbSTOP.ForeColor = Color.Black
    '            TimerRun.Start()
    '            TimerStop.Stop()

    '            lbStartTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
    '            lbEndTime.Text = ""
    '            btnWorkSlip.ForeColor = Color.Black
    '            lbNG.Text = Nothing
    '            lbGood.Text = Nothing
    '            lbFinYld.Text = Nothing
    '            tbRemark.Text = Nothing
    '            cbxItem.Text = Nothing


    '            DR = DBWB_InsTbl.Rows(0)                        '  Use DRcan make sure  update only one row to table


    '            If DR.IsTotalQtyNull Then
    '                'Input Qty.if already input in data base will no pop up form
    '                KeyNumInput = StatusKey.Total
    '                Dim Input As New InputQty
    '                Input.ShowDialog()
    '                DR.TotalQty = OprData.InputQtyFrmVal                  'From inputQty Frm

    '            End If

    '            'DB WB Alarm display --- ---- --- --- --- ---- ---- ---- ----

    '            LotAlarmQtyTbl = New DBxDataSet.LotAlarmQtyDataTable

    '            'Dim AlDr As DBxDataSet.LotAlarmQtyRow
    '            'AlDr = LotAlarmQtyTbl.NewRow
    '            If LotAlarmQtyTblQuery.Fill(LotAlarmQtyTbl, WorkSlipQR.LotNo) <> 0 Then ' Alarm Qty data from record
    '                For Each row As DBxDataSet.LotAlarmQtyRow In LotAlarmQtyTbl
    '                    Select Case row.AlarmNo
    '                        Case 1, 20
    '                            If row.Process = "DB" Then
    '                                lbDB01.Text = row.Qty
    '                            Else
    '                                lbWb01.Text = row.Qty
    '                            End If
    '                        Case 2
    '                            lbWb02.Text = row.Qty
    '                        Case 4
    '                            If row.Process = "DB" Then
    '                                lbDb04.Text = row.Qty
    '                            Else
    '                                lbWb04.Text = row.Qty
    '                            End If
    '                        Case 6
    '                            lbDb06.Text = row.Qty
    '                        Case 7
    '                            lbDb07.Text = row.Qty
    '                        Case 14
    '                            lbDb14.Text = row.Qty
    '                        Case 16
    '                            lbDb16.Text = row.Qty
    '                        Case 17
    '                            lbWb17.Text = row.Qty
    '                        Case 18
    '                            lbWb18.Text = row.Qty
    '                        Case 19
    '                            lbWb19.Text = row.Qty
    '                        Case 99
    '                            If row.Process = "DB" Then
    '                                lbDB99.Text = row.Qty
    '                            Else
    '                                lbWb99.Text = row.Qty

    '                            End If
    '                    End Select
    '                Next

    '            End If
    '            '--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---

    '            lbLotNo.Text = WorkSlipQR.LotNo
    '            OprData.LotNo = lbLotNo.Text
    '            lbPackage.Text = WorkSlipQR.Package
    '            lbDevice.Text = WorkSlipQR.Device
    '            lbinspectorID.Text = OprData.OPID
    '            lbObjInsp.Text = DR.ObjectIns
    '            lbProcess.Text = DR.Process
    '            DR.InspectorNo = lbinspectorID.Text

    '            If DR.IsStartTimeNull Then     ' If already start time will continue
    '                DR.StartTime = Format(Format(Now, "yyyy/MM/dd HH:mm:ss"))
    '            End If

    '            lbStartTime.Text = DR.StartTime


    '            lbTotal.Text = DR.TotalQty
    '            Try
    '                'dgvTotal.Item(13, 0).Value = 0                'Gross Total cell
    '                lbNG.Text = 0
    '                lbGood.Text = CInt(lbTotal.Text) - CInt(lbNG.Text)
    '                lbFinYld.Text = FormatNumber((1 - (CInt(lbNG.Text) / CInt(lbTotal.Text))) * 100, 2)
    '            Catch ex As Exception

    '            End Try

    '            If dgvInspDetail.RowCount > 0 Then DBxDataSet.Inspection_Detail.Rows.Clear() 'Clear Inspection_Detail

    '            If dgvTotal.RowCount > 0 Then dgvTotal.Rows.Clear()

    '            If Not DR.IsRequestModeName1Null Then                                     'Set initail item Inspection_Detail
    '                If DR.RequestModeName1 <> "" Then
    '                    lbReq1.Text = "1. " & DR.RequestModeName1
    '                    'DBxDataSet.Inspection_Detail.Rows.Add(DR.RequestModeName1)        'Add to inspection table
    '                    'DBxDataSet.Inspection_Detail.Rows(DR.RequestModeName1).Item("ModeNo") = DR.RequestMode1
    '                End If

    '            End If
    '            If Not DR.IsRequestModeName2Null Then
    '                If DR.RequestModeName2 <> "" Then
    '                    lbReq2.Text = "2. " & DR.RequestModeName2
    '                    'DBxDataSet.Inspection_Detail.Rows.Add(DR.RequestModeName2)          'Add to inspection table
    '                    'DBxDataSet.Inspection_Detail.Rows(DR.RequestModeName2).Item("ModeNo") = DR.RequestMode2
    '                End If
    '            End If

    '            Try
    '                DBWB_InsTblQuery.Update(DR)   'Update start time and inspector ID

    '            Catch ex As InvalidOperationException
    '                MsgBox("Update Fail : " & ex.ToString)
    '                SaveCatchLog(ex.ToString, "DBWB_InsTblQuery.Update(DR)")
    '            Catch ex As DBConcurrencyException
    '                MsgBox("Update Fail : " & ex.ToString)
    '                SaveCatchLog(ex.ToString, "DBWB_InsTblQuery.Update(DR)")
    '            End Try

    '            '----------------------------------------------------------------------------------------------------------------

    '            TabControl1.SelectedTab = TabPage2
    '            'Dim Ans = WorkSlipQR.TransactionDataSave(OprData.QrData)
    '            'If Ans Like "False*" Then
    '            '    slMessage.Text = Ans
    '            'End If

    '            If File.Exists("\\zion\Inpector\" & lbProcess.Text & "\" & lbLotNo.Text & "_NG Sample.JPG") Then
    '                PictureBox1.BackgroundImage = Image.FromFile("\\zion\Inpector\" & lbProcess.Text & "\" & lbLotNo.Text & "_NG Sample.JPG")
    '            End If

    '        Catch ex As Exception
    '            slMessage.Text = "Catch Error QR_DataRead()" & ex.ToString
    '            SaveCatchLog(ex.ToString, "QR_DataRead()")
    '        End Try
    '        dgvTotal.Rows.Add("Total")
    '    End Sub
    Private Sub QR_OPIDRead()
        slMessage.Text = "QR OPID Read Success_" & Format(Now, "HH:mm:ss.fff")
        'lbInspectorID.Text = OprData.OPID    
        btnOPID.Text = OprData.OPID
    End Sub
    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        SaveCatchLog("", "btnLoad_Click()")

        If File.Exists(My.Application.Info.DirectoryPath & "\TableDetail.xml") Then
            'If dgvTotal.Item(13, 0).Value IsNot Nothing Then
            '    If MsgBox("ข้อมูลปัจจุบันจะถูกลบ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            '        If dgvInspDetail.RowCount > 0 Then DBxDataSet.Inspection_Detail.Rows.Clear()

            '        If dgvTotal.RowCount > 0 Then dgvTotal.Rows.Clear()
            '    Else

            '        Exit Sub
            '    End If

            'End If

            'If MsgBox("ต้องการโหลด ข้อมูลเก่า หรือไม่", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            If lbLotNo.Text = "Lot No." Then
                slMessage.Text = "กรุณา Input LotNo ก่อน"
                Exit Sub
            End If
            DBxDataSet.Inspection_Detail.Rows.Clear()
            DBxDataSet.Inspection_Detail.ReadXml(My.Application.Info.DirectoryPath & "\TableDetail.xml")

            If DBxDataSet.Inspection_Detail.Rows(0).Item(14) <> OprData.LotNo Then 'lbLotNo.Text>>OprData.LotNo

                slMessage.Text = "LotNo ปัจจุบัน = " & lbLotNo.Text & " Load LotNo  =" & DBxDataSet.Inspection_Detail.Rows(0).Item(14) & " ข้อมูลไม่ตรงกัน"
                DBxDataSet.Inspection_Detail.Rows.Clear()
                Exit Sub
            End If
            '  DBxDataSet.Inspection_Detail.Rows.Clear()
            dgvTotal.Rows.Add("Total")

            For i = 1 To 12
                MagTotal(i)
            Next
            'TimerRun.Stop()
            'TimerStop.Stop()
            LoadTime()
        Else
            slMessage.Text = "File not found"
            'File.Delete(My.Application.Info.DirectoryPath & "\TableDetail.xml")
        End If
    End Sub
    Private Sub APCSStaffToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles APCSStaffToolStripMenuItem.Click
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/ApcsStaff", AppWinStyle.NormalFocus)
    End Sub
    Private Sub WorkRecordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WorkRecordToolStripMenuItem.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/ERECORD/", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub AndonToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AndonToolStripMenuItem.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/andontmn", AppWinStyle.NormalFocus) 'Web andon for manual M/C
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        slTimer.Text = Format(Now, "yyyy-MM-dd HH:mm")
    End Sub

    Public DIR_LOG As String = My.Application.Info.DirectoryPath & "\LOG"
    Public Sub SaveCatchLog(ByVal message As String, ByVal fnName As String)
        If Directory.Exists(DIR_LOG & "\BackUp") = False Then
            Directory.CreateDirectory(DIR_LOG & "\BackUp")
        End If
        Dim arr As String() = Directory.GetFiles(DIR_LOG)
        If arr.Length >= 50 Then
            Dim arr1 As String() = Directory.GetFiles(DIR_LOG & "\BackUp")
            For Each strData1 As String In arr1
                File.Delete(strData1)
            Next
            For Each strData As String In arr
                Dim pathSource As String = strData
                Dim pathdes As String = strData.Replace(DIR_LOG, DIR_LOG & "\BackUp")
                File.Move(pathSource, pathdes)
            Next

            Directory.CreateDirectory(DIR_LOG & "\BackUp")
            '    File.Move(arr., DIR_LOG & "\BackUp")
        End If
        'Using sw As StreamReader = New StreamReader(Path.Combine(DIR_LOG, "Catch_" & Now.ToString("yyyyMMdd") & ".log"), True)
        '    sw.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & fnName & ">" & message)
        'End Using

        Using sw As StreamWriter = New StreamWriter(Path.Combine(DIR_LOG, "Catch_" & Now.ToString("yyyyMMdd") & ".log"), True)
            sw.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & fnName & ">" & message)
        End Using
    End Sub

#Region "===AuthenticationUser"


    'Dim ETC2 As String                          'From QR Code ,Check ETC2 = BDXX-M/BJ/C is auto motive
    'Dim strNextOperatorNo As String              'OP No.
    'Dim GetUserAuthenGroupByMCType As String       'M/C Type ( Refer with DBx.Group)
    'Dim GL_Group As String                         'GL Gruop ( Refer with DBx.Group)
    'Dim Process As String                        'Process Ex. "FL"
    'Dim MCNo As String                           'MC No Ex "FL-V-01"
    Friend ErrMesETG As String
    Friend Function PermiisionCheck(ByVal ETC2 As String, ByVal strNextOperatorNo As String, ByVal GetUserAuthenGroupByMCType As String, ByVal GL_Group As String, ByVal Procees As String, ByVal MCNo As String) As Boolean
        Dim permission As New AuthenticationUser.AuthenUser
        Dim AuthenPass As Boolean
        ErrMesETG = ""
        Try


            If permission.CheckAutomotiveLot(ETC2) Then
                OprData.AutoMotiveLot = True
                'This lot is Automotive
                If Not permission.CheckMachineAutomotive(Procees, MCNo) Then          '(EQP.Machine.MCNo = @MCNo) AND (LSIProcess.Name = @ProcessName) AND (EQP.Machine.Automotive = 'true')
                    ErrMesETG = "MC No.นี้ไม่สามารถรัน Lot Automotive ได้ "
                    '_OperatorAlarm = "Machine cannot run the automotive lot,Please contact ETG"
                    'MsgBox("MC No.นี้ไม่สามารถรัน Lot Automotive ได้  กรุณาติดต่อ ETG/SYSTEM")
                    Return False
                End If

                AuthenPass = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType) And permission.AuthenUser(strNextOperatorNo, "AUTOMOTIVE")
                If AuthenPass = False Then AuthenPass = permission.AuthenUser(strNextOperatorNo, GL_Group) 'GL Can run every condition
                If AuthenPass = False Then
                    ErrMesETG = "OP No.นี้ไม่สามารถรัน Lot Automotive ได้" 'MsgBox("OP No.นี้ไม่สามารถรัน Lot Automotive ได้  กรุณาติดต่อ ETG/SYSTEM")
                    '_OperatorAlarm = "OP No cannot run the automotive lot ,Please contact ETG"
                End If

            Else
                OprData.AutoMotiveLot = False
                'This lot isn't Automotive
                AuthenPass = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType)
                If AuthenPass = False Then AuthenPass = permission.AuthenUser(strNextOperatorNo, GL_Group)
                If AuthenPass = False Then
                    ErrMesETG = "OP No.นี้ไม่สามารถรันได้ license หมดอายุ หรือ ไม่มี license " 'MsgBox("OP No.นี้ไม่สามารถรันได้  กรุณาติดต่อ ETG/SYSTEM")
                    '_OperatorAlarm = "OP No cannot run ,Please contact ETG"
                End If

            End If

            Return AuthenPass
        Catch ex As Exception 'Network Error
            ErrMesETG = "Connection Error"
            SaveCatchLog(ex.ToString, "PermiisionCheck()")
            Return False

        End Try
    End Function


    Public Function UserAuthen(ByVal strNextOperatorNo As String, ByVal GetUserAuthenGroupByMCType As String, ByVal GL_Group As String) As Boolean
        Dim permission As New AuthenticationUser.AuthenUser
        Dim AuthenPass As Boolean

        AuthenPass = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType)
        If AuthenPass = False Then AuthenPass = permission.AuthenUser(strNextOperatorNo, GL_Group)
        If AuthenPass = False Then
            ErrMesETG = "OP No.นี้ไม่สามารถรันได้  " 'MsgBox("OP No.นี้ไม่สามารถรันได้  กรุณาติดต่อ ETG/SYSTEM")
            '_OperatorAlarm = "OP No cannot run ,Please contact ETG"
        End If

        Return AuthenPass
    End Function


    Private Function InspectorPermission(ByVal ETC2 As String, ByVal strNextOperatorNo As String, ByVal GetUserAuthenGroupByMCType As String, ByVal GL_Group As String) As Boolean
        Dim permission As New AuthenticationUser.AuthenUser
        Dim AuthenPass As Boolean
        ErrMesETG = ""
        Try

            If permission.CheckAutomotiveLot(ETC2) Then
                OprData.AutoMotiveLot = True
                AuthenPass = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType) And permission.AuthenUser(strNextOperatorNo, "AUTOMOTIVE")
                If AuthenPass = False Then AuthenPass = permission.AuthenUser(strNextOperatorNo, GL_Group) 'GL Can run every condition
                If AuthenPass = False Then
                    ErrMesETG = "OP No.นี้ไม่สามารถรัน Lot Automotive ได้" 'MsgBox("OP No.นี้ไม่สามารถรัน Lot Automotive ได้  กรุณาติดต่อ ETG/SYSTEM")
                    '_OperatorAlarm = "OP No cannot run the automotive lot ,Please contact ETG"
                End If
            Else
                OprData.AutoMotiveLot = False
                'This lot isn't Automotive
                AuthenPass = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType)
                If AuthenPass = False Then AuthenPass = permission.AuthenUser(strNextOperatorNo, GL_Group)
                If AuthenPass = False Then
                    ErrMesETG = "OP No.นี้ไม่สามารถรันได้ license หมดอายุ หรือ ไม่มี license " 'MsgBox("OP No.นี้ไม่สามารถรันได้  กรุณาติดต่อ ETG/SYSTEM")
                    '_OperatorAlarm = "OP No cannot run ,Please contact ETG"
                End If
            End If
            Return AuthenPass
        Catch ex As Exception
            ErrMesETG = "Connection Error"
            Return False
        End Try
    End Function



#End Region

    Private Sub lbVal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbVal.Click
        KeyNumInput = StatusKey.InPutMag
        Dim input As New InputQty
        input.ShowDialog()
        lbVal.Text = OprData.InputQtyFrmVal

    End Sub

    Private Sub btTimePause_Click(sender As System.Object, e As System.EventArgs) Handles btTimePause.Click

        If TimePause = "True" Then
            TimePause = "False"
            btTimePause.Text = "RUN"
            btTimePause.BackColor = Color.LawnGreen
            lbRUN.ForeColor = Color.Black
            lbSTOP.ForeColor = Color.Green
            TimerRun.Stop()
            TimerStop.Start()
            ' Timer1.Enabled = False
        Else
            TimePause = "True"
            btTimePause.Text = "STOP"
            btTimePause.BackColor = Color.Red
            lbRUN.ForeColor = Color.Green
            lbSTOP.ForeColor = Color.Black
            TimerRun.Start()
            TimerStop.Stop()
            ' Timer1.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles TimerRun.Tick

        Rss += 1
        If Rss = 60 Then
            RMM += 1
            Rss = 0
        End If
        If RMM = 60 Then
            RHH += 1
            RMM = 0
        End If
        lbRUN.Text = RHH.ToString("00") & ":" & RMM.ToString("00") & ":" & Rss.ToString("00")
        If SaveTime = True Then
            My.Settings.Rss = Rss
            My.Settings.RMM = RMM
            My.Settings.RHH = RHH
            My.Settings.Save()
        End If
        'My.Settings.Rss += 1
        'If My.Settings.Rss = 60 Then
        '    My.Settings.RMM += 1
        '    My.Settings.Rss = 0
        'End If
        'If My.Settings.RMM = 60 Then
        '    My.Settings.RHH += 1
        '    My.Settings.RMM = 0
        'End If
        'lbRUN.Text = My.Settings.RHH.ToString("00") & ":" & My.Settings.RMM.ToString("00") & ":" & My.Settings.Rss.ToString("00")
        'My.Settings.Save()
    End Sub
    Private Sub TimerStop_Tick(sender As System.Object, e As System.EventArgs) Handles TimerStop.Tick
        SPss += 1
        If SPss = 60 Then
            SPMM += 1
            SPss = 0
        End If
        If SPMM = 60 Then
            SPHH += 1
            SPMM = 0
        End If
        lbSTOP.Text = SPHH.ToString("00") & ":" & SPMM.ToString("00") & ":" & SPss.ToString("00")
        If SaveTime = True Then
            My.Settings.SPss = SPss
            My.Settings.SPMM = SPMM
            My.Settings.SPHH = SPHH
            My.Settings.Save()
        End If
    End Sub
    Public KeyNumInput As String
    Public Enum StatusKey
        Total
        InPutMag
        Remark
        AddItem

    End Enum
    Private Sub btQR_Click(sender As System.Object, e As System.EventArgs) Handles btQR.Click
        SaveCatchLog("", "btQR_Click()")
        ' btQR.Text = "กรุณาทำการ GL Check"
        'btQR.ForeColor = Color.Green
        'tbQR_GL.Focus()
        'tbQR_GL.Text = ""

        Dim frm As New GLConfirm
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            btQR.BackColor = Color.LawnGreen
        End If

        'KeyNumInput = StatusKey.GLCheck
        'Dim frm As New InputQty
        'frm.ShowDialog()

    End Sub
    'Private Sub rbtLotJudgeOK_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtLotJudgeOK.CheckedChanged
    '    'Dim fm As New Keyboad 'ชื่อ form ที่ตั้งไว้
    '    'fm.Show()
    '    tbRemark.Text = ""
    '    tbRemark.Enabled = False
    'End Sub
    'Private Sub rbtLotJudgeNG_Click(sender As System.Object, e As System.EventArgs) Handles rbtLotJudgeNG.Click

    '    Try
    '        dgvTotal.Item(13, 0).Value = Gtotal                'Gross Total cell
    '        lbNG.Text = Gtotal
    '        lbGood.Text = CInt(lbTotal.Text) - CInt(lbNG.Text)
    '        lbFinYld.Text = FormatNumber((1 - (CInt(lbNG.Text) / CInt(lbTotal.Text))) * 100, 2)
    '        tbJudgeReason.Enabled = True
    '    Catch ex As Exception

    '    End Try

    '    '' Dim tb As TextBox
    '    tbJudgeReason.Enabled = True
    '    PanelNG.Visible = True
    '    'tbRemark.Text = "Remark"
    '    'tbRemark.Focus()
    '    'Dim frm As New KeyRemark
    '    'frm.Key = StatusKey.Remark
    '    'frm.TargetTextBox = tbRemark
    '    'frm.Show()

    'End Sub
    Private Sub tbQR_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbQR_GL.KeyPress
        If e.KeyChar = Chr(13) Then
            If tbQR_GL.Text.Length = 6 Then
                MsgBox("GL Check สำเร็จ")
                'Me.DialogResult = DialogResult.OK
            Else
                MsgBox("กรุณา GL Check ใหม่")
                tbQR_GL.Text = ""
            End If

        End If
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btGLConfirm.Click
        'Process.Start("C:\VNC4\vncviewer.exe", "10.28.52.124")
        'Me.Hide()
        Dim frm As New GLCheck
        frm.ShowDialog()
        Me.Show()
    End Sub
    Private Sub BtExit2_Click(sender As System.Object, e As System.EventArgs) Handles BtExit2.Click
        Dim z2 As MsgBoxResult = MsgBox("Do You Want Exit", MsgBoxStyle.YesNo, "Exit")
        If z2 = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub MinimizeButton_Click(sender As System.Object, e As System.EventArgs) Handles MinimizeButton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnKeyBoard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyBoard.Click
        SaveCatchLog("", "btnKeyBoard_Click()")
        'Dim frm As New KeyRemark
        'frm.Key = "AddItem"

        'frm.Show()
        Dim frm As New KeyRemark
        frm.Key = StatusKey.AddItem
        frm.Show()

        'If tbRemark.Enabled = False Then
        '    cbxItem.Focus()
        'Else
        '    tbRemark.Focus()
        'End If

        'System.Diagnostics.Process.Start("osk.exe")
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click


        CountListData()
        'Try
        '    arr = lbObjInsp.Text.Split("-")
        '    If arr.Length = 2 Then
        '        '    arr(0).Trim()
        '        M1 = CInt((arr(0).Trim().Split("F"))(0).Replace("M", ""))
        '        M2 = CInt((arr(1).Trim().Split("F"))(0).Replace("M", ""))
        '        For i = M1 To M2
        '            dgvInspDetail.Columns(i).DefaultCellStyle.BackColor = Color.Red
        '        Next

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub CountListData()
        ltBefore.Items.Clear()
        'ltWaitGL.Items.Clear()
        'ltInspec.Items.Clear()
        Dim countUpdate As Integer = 0
        Dim count As Integer = 0
        Dim countGL As Integer = 0
        'DBWBINSDataTableAdapter.FillDataTable(DBxDataSet.DBWBINSData, "4/1/2016")
        DbwbinsData2TableAdapter1.Fill(DBxDataSet.DBWBINSData2)
        'For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
        'For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
        For Each row As DBxDataSet.DBWBINSData2Row In DBxDataSet.DBWBINSData2
            Try


                '  If row.LotNo <> "" AndAlso row.IsStartTimeNull = True Then 'Before  row.IsTotalQtyNull  row.IsStartTimeNull row.IsTotalQtyNull
                ltBefore.Items.Add(row.LotNo & "," & row.Package)
                count += 1

                '   End If
            Catch ex As Exception

            End Try
        Next
        'lbInspection.Text = countUpdate
        lbCountUpdate.Text = count
        'lbGLCheck.Text = countGL
    End Sub

    Private Sub rbtLotJudgeOK_Click(sender As System.Object, e As System.EventArgs) Handles rbtLotJudgeOK.Click, rbtLotJudgeNG.Click

        Dim val As RadioButton = CType(sender, RadioButton)
        SaveCatchLog(val.Name, "rbtLotJudge_Click()")
        If Check_InputTotal = False And lbObjInsp.Text <> "ALL" Then

            MsgBox("กรุราตรวจสอบ Input Total")
            SetTotal()
            If Check_InputTotal <> False Then
                lbTotal.BackColor = Color.LawnGreen
            End If
            rbtLotJudgeOK.Checked = False
            rbtLotJudgeNG.Checked = False
            Exit Sub
        End If
        If val.Text = "OK" Then
            tbJudgeReason.Enabled = False
            tbJudgeReason.Text = Nothing

        Else
            Try
                dgvTotal.Item(13, 0).Value = Gtotal                'Gross Total cell
                lbNG.Text = Gtotal
                lbGood.Text = CInt(lbTotal.Text) - CInt(lbNG.Text)
                lbFinYld.Text = FormatNumber((1 - (CInt(lbNG.Text) / CInt(lbTotal.Text))) * 100, 2)
                tbJudgeReason.Enabled = True
            Catch ex As Exception

            End Try

            '' Dim tb As TextBox
            tbJudgeReason.Enabled = True
            PanelNG.Visible = True

        End If








        ' PanelNG.Visible = False
        'Try
        '    dgvTotal.Item(13, 0).Value = 0                'Gross Total cell
        '    lbNG.Text = 0
        '    lbGood.Text = CInt(lbTotal.Text) - CInt(lbNG.Text)
        '    lbFinYld.Text = FormatNumber((1 - (CInt(lbNG.Text) / CInt(lbTotal.Text))) * 100, 2)
        'Catch ex As Exception

        'End Try



    End Sub


    Private Sub tbRemark_Click(sender As System.Object, e As System.EventArgs) Handles tbJudgeReason.Click
        ' tbRemark.Text = ""


        Dim frm As New KeyRemark
        frm.Key = StatusKey.Remark
        frm.TargetTextBox = tbJudgeReason
        frm.Show()
        tbJudgeReason.Text = ""
        'tbRemark.ForeColor = Color.Black
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbJudgeReason.GotFocus
        If tbJudgeReason.Text = "Remark" Then
            tbJudgeReason.Text = ""
            tbJudgeReason.ForeColor = Color.Black
        End If
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbJudgeReason.LostFocus, rbtLotJudgeNG.Click
        If tbJudgeReason.Text = "" Then
            tbJudgeReason.Text = "Remark"
            tbJudgeReason.ForeColor = Color.DarkGray
        End If
    End Sub
    Dim arr As String()
    Dim MagStart As Integer
    Dim MagEND As Integer
    Dim MagMAX As Integer = 12

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        c_ServiceiLibrary = New ServiceiLibraryClient()
    End Sub

    Private Sub Hilight()
        Try
            arr = lbObjInsp.Text.Split("-")
            For i = 1 To MagMAX
                dgvInspDetail.Columns(i).DefaultCellStyle.BackColor = SystemColors.Window
            Next
            If arr.Length = 2 Then
                '    arr(0).Trim()
                MagStart = CInt((arr(0).Trim().Split("F"))(0).Replace("M", ""))
                MagEND = CInt((arr(1).Trim().Split("F"))(0).Replace("M", ""))
                'For i = M1 To M2
                '    dgvInspDetail.Columns(i).DefaultCellStyle.BackColor = Color.Red
                'Next
                For i = 1 To (MagStart - 1)
                    dgvInspDetail.Columns(i).DefaultCellStyle.BackColor = Color.Silver
                Next
                For i = (MagEND + 1) To MagMAX
                    dgvInspDetail.Columns(i).DefaultCellStyle.BackColor = Color.Silver
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageLoad(ByVal file As String)
        ' Dim id As String = "007336"
        Try
            Try
                Dim folder As String = "\Image"
                Dim filename As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath & folder, file & ".jpg")
                PictureBox3.BackgroundImage = Image.FromFile(filename)
            Catch ex As Exception
                Dim folder As String = "\Image"
                Dim filename As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath & folder, "user" & ".png")
                PictureBox3.BackgroundImage = Image.FromFile(filename)
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lbTotal_Click(sender As Object, e As EventArgs) Handles lbTotal.Click

        SetTotal()

        If Check_InputTotal <> False Then
            lbTotal.BackColor = Color.LawnGreen
        Else
            lbTotal.BackColor = Color.Red
        End If


    End Sub
    Private Sub SetTotal()
        If TimerRun.Enabled = False And TimerStop.Enabled = False Then
            Exit Sub
        End If
        KeyNumInput = StatusKey.Total 'Input Qty.if already input in data base will no pop up form
        Dim Input As New InputQty
        Input.ShowDialog()
        lbTotal.Text = OprData.InputQtyFrmVal                  'From inputQty Frm
        Check_InputTotal = True
        Try
            dgvTotal.Item(13, 0).Value = Gtotal                'Gross Total cell
            lbNG.Text = Gtotal
            lbGood.Text = CInt(lbTotal.Text) - CInt(lbNG.Text)
            lbFinYld.Text = FormatNumber((1 - (CInt(lbNG.Text) / CInt(lbTotal.Text))) * 100, 2)
            tbJudgeReason.Enabled = True
        Catch ex As Exception

        End Try


        DBWB_InsTbl = New DBxDataSet.DBWBINSDataDataTable
        Dim DR As DBxDataSet.DBWBINSDataRow
        DR = DBWB_InsTbl.NewRow
        DBWB_InsTblQuery.FillBy1(DBWB_InsTbl, lbLotNo.Text, lbProcess.Text)
        DR = DBWB_InsTbl.Rows(0)
        DR.TotalQty = lbTotal.Text
        DBWB_InsTblQuery.Update(DR)
    End Sub

    Private Sub WBWIP_Click(sender As Object, e As EventArgs) Handles WBWIP.Click
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/WBWIP/CheckWBWIP.aspx", AppWinStyle.NormalFocus)
    End Sub

    Private Sub btAQI_Click(sender As Object, e As EventArgs) Handles btAQI.Click
        'Dim _tableData As New DBxDataSet.InspectionDetailDataTable
        'For Each Detail As DBxDataSet.Inspection_DetailRow In DBxDataSet.Inspection_Detail
        '    Dim Row As DBxDataSet.InspectionDetailRow = _tableData.NewRow
        '    '      Row._1M = Detail._1M
        '    Row.InspectionItem = Detail.INSPECTION_ITEM
        '    Row.Process = "DB"
        '    Row.LotNo = "Detail"
        '    Row.InsEndTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
        '    If Not Detail.Is_1MNull Then Row._1M = Detail._1M
        '    If Not Detail.Is_2MNull Then Row._2M = Detail._2M
        '    If Not Detail.Is_3MNull Then Row._3M = Detail._3M
        '    If Not Detail.Is_4MNull Then Row._4M = Detail._4M
        '    If Not Detail.Is_5MNull Then Row._5M = Detail._5M
        '    If Not Detail.Is_6MNull Then Row._6M = Detail._6M
        '    If Not Detail.Is_7MNull Then Row._7M = Detail._7M
        '    If Not Detail.Is_8MNull Then Row._8M = Detail._8M
        '    If Not Detail.Is_9MNull Then Row._9M = Detail._9M
        '    If Not Detail.Is_10MNull Then Row._10M = Detail._10M
        '    If Not Detail.Is_11MNull Then Row._11M = Detail._11M
        '    If Not Detail.Is_12MNull Then Row._12M = Detail._12M

        '    'Row.INSPECTION_ITEM = Detail.INSPECTION_ITEM
        '    '   Detail.ModeNo = Row.ModeNo
        '    _tableData.Rows.Add(Row)
        'Next


        Dim _TbData As DataTable = New DataTable
        _TbData.Columns.Add("NG_Mode")
        _TbData.Columns.Add("MAG1")
        _TbData.Columns.Add("MAG2")
        _TbData.Columns.Add("MAG3")
        _TbData.Columns.Add("MAG4")
        _TbData.Columns.Add("MAG5")
        _TbData.Columns.Add("MAG6")
        _TbData.Columns.Add("MAG7")
        _TbData.Columns.Add("MAG8")
        _TbData.Columns.Add("MAG9")
        _TbData.Columns.Add("MAG10")
        _TbData.Columns.Add("MAG11")
        _TbData.Columns.Add("MAG12")
        _TbData.Columns.Add("TOTAL")

        Dim _TbDataTotal As DataTable = New DataTable
        _TbDataTotal.Columns.Add("NG_ModeTotal")
        _TbDataTotal.Columns.Add("MAG1Total")
        _TbDataTotal.Columns.Add("MAG2Total")
        _TbDataTotal.Columns.Add("MAG3Total")
        _TbDataTotal.Columns.Add("MAG4Total")
        _TbDataTotal.Columns.Add("MAG5Total")
        _TbDataTotal.Columns.Add("MAG6Total")
        _TbDataTotal.Columns.Add("MAG7Total")
        _TbDataTotal.Columns.Add("MAG8Total")
        _TbDataTotal.Columns.Add("MAG9Total")
        _TbDataTotal.Columns.Add("MAG10Total")
        _TbDataTotal.Columns.Add("MAG11Total")
        _TbDataTotal.Columns.Add("MAG12Total")
        _TbDataTotal.Columns.Add("TOTAL2")
        Dim MAG1Total As Integer
        Dim MAG2Total As Integer
        Dim MAG3Total As Integer
        Dim MAG4Total As Integer
        Dim MAG5Total As Integer
        Dim MAG6Total As Integer
        Dim MAG7Total As Integer
        Dim MAG8Total As Integer
        Dim MAG9Total As Integer
        Dim MAG10Total As Integer
        Dim MAG11Total As Integer
        Dim MAG12Total As Integer
        Dim Total2 As Integer


        For Each Detail As DBxDataSet.Inspection_DetailRow In DBxDataSet.Inspection_Detail
            Dim Row As DataRow = _TbData.NewRow

            If Not Detail.IsTLNull Then
                Row("NG_Mode") = Detail.INSPECTION_ITEM

                If Not Detail.Is_1MNull Then
                    Row("MAG1") = Detail._1M
                    MAG1Total += Detail._1M
                End If
                If Not Detail.Is_2MNull Then
                    Row("MAG2") = Detail._2M
                    MAG2Total += Detail._2M
                End If
                If Not Detail.Is_3MNull Then
                    Row("MAG3") = Detail._3M
                    MAG3Total += Detail._3M
                End If
                If Not Detail.Is_4MNull Then
                    Row("MAG4") = Detail._4M
                    MAG4Total += Detail._4M
                End If
                If Not Detail.Is_5MNull Then
                    Row("MAG5") = Detail._5M
                    MAG5Total += Detail._5M
                End If
                If Not Detail.Is_6MNull Then
                    Row("MAG6") = Detail._6M
                    MAG6Total += Detail._6M
                End If
                If Not Detail.Is_7MNull Then
                    Row("MAG7") = Detail._7M
                    MAG7Total += Detail._7M
                End If
                If Not Detail.Is_8MNull Then
                    Row("MAG8") = Detail._8M
                    MAG8Total += Detail._8M
                End If
                If Not Detail.Is_9MNull Then
                    Row("MAG9") = Detail._9M
                    MAG9Total += Detail._9M
                End If
                If Not Detail.Is_10MNull Then
                    Row("MAG10") = Detail._10M
                    MAG10Total += Detail._10M
                End If
                If Not Detail.Is_11MNull Then
                    Row("MAG11") = Detail._11M
                    MAG11Total += Detail._11M
                End If
                If Not Detail.Is_12MNull Then
                    Row("MAG12") = Detail._12M
                    MAG12Total += Detail._12M
                End If
                Row("TOTAL") = Detail.TL
                Total2 += Detail.TL
                _TbData.Rows.Add(Row)
            End If
        Next
        Dim RowTotal As DataRow = _TbDataTotal.NewRow
        RowTotal("NG_ModeTotal") = "TOTAL(PCS.)"
        RowTotal("MAG1Total") = MAG1Total
        RowTotal("MAG2Total") = MAG2Total
        RowTotal("MAG3Total") = MAG3Total
        RowTotal("MAG4Total") = MAG4Total
        RowTotal("MAG5Total") = MAG5Total
        RowTotal("MAG6Total") = MAG6Total
        RowTotal("MAG7Total") = MAG7Total
        RowTotal("MAG8Total") = MAG8Total
        RowTotal("MAG9Total") = MAG9Total
        RowTotal("MAG10Total") = MAG10Total
        RowTotal("MAG11Total") = MAG11Total
        RowTotal("MAG12Total") = MAG12Total
        RowTotal("TOTAL2") = Total2
        _TbDataTotal.Rows.Add(RowTotal)



        Dim frm As AQI = New AQI
        Try
            frm.Loaddata(lbPackage.Text, lbDevice.Text, lbLotNo.Text, lbReq1.Text.Split(".")(1), lbReq1Remark.Text, lbReq2.Text.Split(".")(1), lbReq2Remark.Text, lbMCNo.Text _
                     , lbStartTime.Text, lbinspectorID.Text, lbNG.Text, _TbData, _TbDataTotal)
            'frm.ShowDialog()
        Catch ex As Exception
            MsgBox("กรุณากรอกข้อมูลให้ครบ")
        End Try



    End Sub

    Private Sub dgvInspDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInspDetail.CellContentClick





    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Try
            'apcs pro.
            c_ServiceiLibrary.MachineOnlineState(My.Settings.MachineNo, MachineOnline.Offline)
        Catch ex As Exception
            MessageBoxDialog.ShowMessage("MachineOnlineState", ex.Message.ToString, "iLibrary Service")
        End Try
    End Sub
End Class
Public Class StateObject
    'Client  socket.
    Public workSocket As Socket = Nothing
    'Size of receive buffer.
    Public Const BufferSize As Integer = 65536
    'Receive buffer.
    Public buffer(BufferSize) As Byte
    'Received data string.
    Public sb As New StringBuilder

    Public Name As String = ""
End Class 'StateObject