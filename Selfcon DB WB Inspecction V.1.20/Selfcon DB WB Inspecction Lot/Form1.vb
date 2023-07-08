Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports System.Runtime.InteropServices




Public Class Frmmain
    Private m_Numpad As New NumPadForm
    Public m_offlineMode As String = "Online"
    Public CheckOldData As Boolean   'Odd=true and New = false 
    Dim StatusLot As String 'Input Lot , Inspection , GL Confirm , LotSet
    Dim m_DbWbInsp As DBxDataSet.DBWBINSDataRow
    Dim m_LotAlarmQty As DBxDataSet.LotAlarmQtyRow
    'Dim m_DbWbInsp As DBxDataSet.DBWBINSDataRow
    Dim HeaderMCNo As String = Environment.MachineName
    Dim key As FrmKeyBoard





    Private Sub MinimizeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizeButton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BtExit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExit2.Click
        Dim z2 As MsgBoxResult = MsgBox("Do You Want Exit", MsgBoxStyle.YesNo, "Exit")
        If z2 = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
#Region "=====ToolBar & Common Button"
    Private Sub lbAndon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAndon.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/andontmn", AppWinStyle.NormalFocus) 'Web andon for manual M/C
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lbWkRecd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbWkRecd.Click


        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/ERECORD/default.aspx", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region



    Private Sub lbSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSetting.Click
        ContextMenuStrip2.Show(lbSetting, New Point(0, lbSetting.Height))

    End Sub

    Private Sub OnLineModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnLineModeToolStripMenuItem.Click
        If frmpassword.ShowDialog = Windows.Forms.DialogResult.OK Then
            lbStatus.Text = "ONLINE"
            lbStatus.BackColor = Color.Lime
            m_offlineMode = lbStatus.Text
            Config_Set(m_offlineMode, My.Application.Info.DirectoryPath & "\OfflineMode.txt")
        End If
    End Sub

    Private Sub OffLineModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OffLineModeToolStripMenuItem.Click
        If frmpassword.ShowDialog = Windows.Forms.DialogResult.OK Then
            lbStatus.Text = "OFFLINE"
            lbStatus.BackColor = Color.Red
            m_offlineMode = lbStatus.Text
            Config_Set(m_offlineMode, My.Application.Info.DirectoryPath & "\OfflineMode.txt")
        End If
    End Sub

    Sub Config_Set(ByVal strConf As String, ByVal File As String)
        Dim fInfo As New IO.FileInfo(File)
        Try
            Dim StmWr As IO.StreamWriter = fInfo.CreateText
            StmWr.Write(strConf)
            StmWr.Flush()
            StmWr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub





    Public Function FindDataLot(ByVal lot As String) As Boolean
        Dim ret As Boolean = False
        Dim LotNo As String = lot.ToUpper

        For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
            Try
                If row.LotNo = LotNo AndAlso row.IsTotalQtyNull = True AndAlso row.IsGoodQtyNull = True AndAlso row.IsTotalQtyNull = True Then
                    ClearAll()
                    SetPara(row)
                    'lbStart.BackColor = Color.Lime
                    StatusLot = "Inspection"
                    Status(StatusLot)
                    'MsgBox("status Start")
                    'AddComLog("Insp Login," & frmInputQR.QROpNo & "," & lbMC.Text & "," & lbLot.Text & "," & lbOP.Text & "," & "Req," & SelectInspDefect(True, cbbReq1.Text) & "," & SelectInspDefect(True, cbbReq2.Text) & "," & SelectInspDefect(True, cbbReq3.Text) & "," & SelectInspDefect(True, cbbReq4.Text) & "," & "Urgent," & rdYes.Checked)
                    ret = True
                ElseIf row.LotNo = LotNo AndAlso row.IsTotalQtyNull = False AndAlso row.IsInspectorNoNull = True Then
                    ClearAll()
                    SetPara(row)
                    'lbStart.BackColor = Color.Lime
                    StatusLot = "Inspection"
                    Status(StatusLot)
                    ret = True
                ElseIf row.LotNo = LotNo AndAlso row.IsInspectorNoNull = False AndAlso row.IsLotJudgNull = True Then
                    'MsgBox("status Insp")
                    ClearAll()
                    SetPara(row)
                    'lbStarttime.BackColor = Color.Lime
                    StatusLot = "Inspection"
                    Status(StatusLot)



                    ret = True
                End If
            Catch ex As Exception

            End Try
        Next
        Return ret
    End Function


    Private Sub Status(ByVal dataStatatus As String)
        Select Case dataStatatus


            Case "LotSet"

                TB_ReqName1.Enabled = False
                TB_ReqName2.Enabled = False
                btOK.Enabled = False
                TB_ReqName1.BackColor = Color.GreenYellow
                TB_ReqName2.BackColor = Color.GreenYellow
                TB_Process.Enabled = False
                tbMCNo.Enabled = False
                tbMCNo.BackColor = Color.FloralWhite
                TB_ModeReq1.Enabled = False
                TB_OTherRemak1.Enabled = False
                TB_ModeReq2.Enabled = False
                TB_OTherRemak2.Enabled = False
                TB_PICKUP.Enabled = False
                TB_PREFORM.Enabled = False
                TB_FRAMEOUT.Enabled = False
                TB_BONDER.Enabled = False
                TB_PASTEINS.Enabled = False
                TB_PREFORMINS.Enabled = False
                TB_AUCUTSHORT.Enabled = False
                TB_PADNIN.Enabled = False
                TB_LEADNIN.Enabled = False
                TB_BPM.Enabled = False
                TB_NSOP.Enabled = False
                TB_NSOL.Enabled = False
                PBNGSample.Enabled = False
                PictureBox1.Visible = False
                PictureBox2.Visible = False
                Tb_Remark.Enabled = False
            Case "Input Lot"

                TB_ReqName1.Enabled = True
                TB_ReqName2.Enabled = False
                btOK.Enabled = True
                TB_ReqName1.BackColor = Color.Yellow
                TB_ModeReq1.BackColor = Color.Yellow
                'tbInput.BackColor = Color.WhiteSmoke
                TB_ReqName2.BackColor = Color.WhiteSmoke
                TB_ModeReq2.BackColor = Color.WhiteSmoke
                TB_PICKUP.Enabled = True
                TB_PREFORM.Enabled = True
                TB_FRAMEOUT.Enabled = True
                TB_BONDER.Enabled = True
                TB_PASTEINS.Enabled = True
                TB_PREFORMINS.Enabled = True
                TB_AUCUTSHORT.Enabled = True
                TB_PADNIN.Enabled = True
                TB_LEADNIN.Enabled = True
                TB_BPM.Enabled = True
                TB_NSOP.Enabled = True
                TB_NSOL.Enabled = True
                PBNGSample.Enabled = True
                Tb_Remark.Enabled = True

                'If TB_Process.Text = "DB" Then
                TB_PICKUP.BackColor = Color.Yellow
                TB_PREFORM.BackColor = Color.Yellow
                TB_FRAMEOUT.BackColor = Color.Yellow
                TB_BONDER.BackColor = Color.Yellow
                TB_PASTEINS.BackColor = Color.Yellow
                TB_PREFORMINS.BackColor = Color.Yellow

                'TB_AUCUTSHORT.Text = "-"
                'TB_PADNIN.Text = "-"
                'TB_LEADNIN.Text = "-"
                'TB_BPM.Text = "-"
                'TB_NSOP.Text = "-"
                'TB_NSOL.Text = "-"

                'TB_AUCUTSHORT.Enabled = False
                'TB_PADNIN.Enabled = False
                'TB_LEADNIN.Enabled = False
                'TB_BPM.Enabled = False
                'TB_NSOP.Enabled = False
                'TB_NSOL.Enabled = False
                'End If

                'If TB_Process.Text = "WB" Then
                'TB_PICKUP.Text = "-"
                'TB_PREFORM.Text = "-"
                'TB_FRAMEOUT.Text = "-"
                'TB_BONDER.Text = "-"
                'TB_PASTEINS.Text = "-"
                'TB_PREFORMINS.Text = "-"

                'TB_PICKUP.Enabled = False
                'TB_PREFORM.Enabled = False
                'TB_FRAMEOUT.Enabled = False
                'TB_BONDER.Enabled = False
                'TB_PASTEINS.Enabled = False
                'TB_PREFORMINS.Enabled = False

                TB_AUCUTSHORT.BackColor = Color.Yellow
                TB_PADNIN.BackColor = Color.Yellow
                TB_LEADNIN.BackColor = Color.Yellow
                TB_BPM.BackColor = Color.Yellow
                TB_NSOP.BackColor = Color.Yellow
                TB_NSOL.BackColor = Color.Yellow

                'End If


            Case "Inspection"

                TB_ReqName1.Enabled = False
                TB_ReqName2.Enabled = False
                btOK.Enabled = False
                TB_ReqName1.BackColor = Color.WhiteSmoke
                TB_ModeReq1.BackColor = Color.WhiteSmoke
                TB_ReqName2.BackColor = Color.WhiteSmoke
                TB_ModeReq2.BackColor = Color.WhiteSmoke
                tbMCNo.Enabled = False
                tbMCNo.BackColor = Color.FloralWhite

                TB_PICKUP.Enabled = False
                TB_PREFORM.Enabled = False
                TB_FRAMEOUT.Enabled = False
                TB_BONDER.Enabled = False
                TB_PASTEINS.Enabled = False
                TB_PREFORMINS.Enabled = False
                TB_AUCUTSHORT.Enabled = False
                TB_PADNIN.Enabled = False
                TB_LEADNIN.Enabled = False
                TB_BPM.Enabled = False
                TB_NSOP.Enabled = False
                TB_NSOL.Enabled = False

                PBNGSample.Enabled = False
                Tb_Remark.Enabled = False

        End Select
    End Sub
    Private Sub SetPara(ByVal row As DBxDataSet.DBWBINSDataRow)

        'lb_LotNo.Text = row.LotNo

        ''If row.StartTime <> row.ReqDate Then
        ''    lbStarttime.Text = row.StartTime
        ''End If
        'If row.IsPackageNull = False Then
        '    lbPackage.Text = row.Package
        'End If
        'If row.IsOPNoNull = False Then
        '    lbOpNo.Text = row.OPNo
        'End If
        'If row.IsMCNoNull = False Then
        '    tbMCNo.Text = row.MCNo
        'End If
        ''If row.IsEndTimeNull = False Then
        ''    lbEndtime.Text = row.EndTime
        ''End If
        'If row.IsReqDateNull = False Then
        '    lbLotintime.Text = row.ReqDate
        'End If
        'If row.IsNGMode1Null = False Then
        '    TB_ReqName1.Text = row.NGMode1
        'End If
        'If row.IsNGMode2Null = False Then
        '    TB_ReqName2.Text = row.NGMode2
        'End If
        'If row.IsInspMagQtyNull = False Then
        '    lb_Objectins.Text = row.InspMagQty
        'End If

    End Sub

    Private Function FindMCNo(ByVal LotNo As String, ByVal Process As String) As String
        Dim ret As String = ""
        If Process = "DB" Then
            DBDataTableAdapter.FillBy(DBxDataSet.DBData, LotNo)
            For Each row As DBxDataSet.DBDataRow In DBxDataSet.DBData
                If row.MCNo <> "" Then
                    ret = row.MCNo
                End If
            Next
        Else
            WBDataTableAdapter.FillBy(DBxDataSet.WBData, LotNo)
            For Each row As DBxDataSet.WBDataRow In DBxDataSet.WBData
                If row.MCNo <> "" Then
                    ret = row.MCNo
                End If
            Next
        End If
        Return ret
    End Function

    Private Function CheckLotInDBx(ByVal LotNo As String, ByVal Process As String) As Boolean
        Dim LotNoDBx As Boolean = False
        Dim Query As DBxDataSetTableAdapters.QueriesTableAdapter = New DBxDataSetTableAdapters.QueriesTableAdapter
        Dim strLotNo As Integer = Query.CheckLotNo(LotNo, Process)
        If strLotNo <> 0 Then 'มีข้อมูล
            LotNoDBx = True
        Else 'ไม่มีข้อมูล
            LotNoDBx = False
        End If

        Return LotNoDBx
    End Function







    Private Sub AddComLog(ByVal m As String)
        Dim logfile As String = My.Application.Info.DirectoryPath & "\LOG\ComLoG.txt"
        Try
            Dim outfile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(logfile, True)
            outfile.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " " & m)
            outfile.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim sr As StreamReader = File.OpenText(logfile)
        If sr.BaseStream.Length > 1000000 Then
            sr.Close()
            If File.Exists(My.Application.Info.DirectoryPath & "\LOG\ComLoG1.txt ") Then
                File.Delete(My.Application.Info.DirectoryPath & "\LOG\ComLoG1.txt")
            End If
            File.Copy(logfile, My.Application.Info.DirectoryPath & "\LOG\ComLoG1.txt")
            File.Delete(logfile)
        End If
        sr.Close()
    End Sub
    Private Sub AddComLogLotAlmQty(ByVal m As String)
        Dim logfile As String = My.Application.Info.DirectoryPath & "\LOG\ComLoGLotAlmQty.txt"
        Try
            Dim outfile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(logfile, True)
            outfile.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " " & m)
            outfile.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim sr As StreamReader = File.OpenText(logfile)
        If sr.BaseStream.Length > 1000000 Then
            sr.Close()
            If File.Exists(My.Application.Info.DirectoryPath & "\LOG\ComLoGLotAlmQty1.txt ") Then
                File.Delete(My.Application.Info.DirectoryPath & "\LOG\ComLoGLotAlmQty1.txt")
            End If
            File.Copy(logfile, My.Application.Info.DirectoryPath & "\LOG\ComLoGLotAlmQty1.txt")
            File.Delete(logfile)
        End If
        sr.Close()
    End Sub




    Private Sub ClearAll()
        'Input Lot

        tbMCNo.Text = ""
        TB_Process.Text = ""
        lb_Objectins.Text = ""
        lbLotintime.Text = ""
        TB_ReqName1.Text = ""
        TB_ModeReq1.Text = ""
        TB_OTherRemak1.Text = ""
        TB_ReqName2.Text = ""
        TB_ModeReq2.Text = ""
        TB_OTherRemak2.Text = ""



        TB_PICKUP.Text = ""
        TB_PREFORM.Text = ""
        TB_FRAMEOUT.Text = ""
        TB_BONDER.Text = ""
        TB_PASTEINS.Text = ""
        TB_PREFORMINS.Text = ""
        TB_AUCUTSHORT.Text = ""
        TB_PADNIN.Text = ""
        TB_LEADNIN.Text = ""
        TB_BPM.Text = ""
        TB_NSOP.Text = ""
        TB_NSOL.Text = ""

        PBNGSample.Image = Nothing

        Tb_Remark.Text = ""
    End Sub

    Private Sub Frmmain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        SaveDataLotBin()
    End Sub



    Private Sub Frmmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Dim processes As Process() = Process.GetProcessesByName("machine")

        'If processes.Length = 0 Then
        '    Me.m_TDCProcess = Process.Start(My.Application.Info.DirectoryPath & "\Modules\TDC\machine.exe")
        '    m_TDCProcess.WaitForInputIdle(My.Settings.TDCWaitTimeOut)
        'Else
        '    m_TDCProcess = processes(0)
        'End If
        m_Numpad = New NumPadForm()
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then        'One application run only 130205
            Me.Close()
        End If

        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                MsgBox("ไม่สามาถเชื่อมต่อ ไปที่ Server 172.16.0.102 ได้ ,ติดต่อ PM Check Network.")
                LoadDataLotBin()
                Status("LotSet")
                Exit Sub
            End If
        Else
            'LAN
            MsgBox("ไม่สามาถเชื่อมต่อ Networkได้ ,โปรดตรวจเช็คสาย LAN")
            LoadDataLotBin()
            Status("LotSet")

            Exit Sub

        End If

        LoadDataLotBin()
        CountListData()
        Status("LotSet")
        btOK.Hide()
        BtCancleLotConfirm.Hide()
        NameINSTime.Hide()
        NameEndTime.Hide()
        NameRemark.Hide()
        LbTimeInspec.Hide()
        LbTimeEnd.Hide()
        LbRemark.Hide()


    End Sub


    'Private Sub AddInspToTable1()
    '    For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
    '        Try

    '            If row.LotNo = lbLotNo.Text AndAlso row.StartTime = lbLotintime.Text Then
    '                row.TotalQty = tbInput.Text
    '                row.StartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
    '                row.Start = Format(Now, "yyyy/MM/dd HH:mm:ss")
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    Next
    '    DBWBINSDataTableAdapter.Update(DBxDataSet.DBWBINSData)
    'End Sub

    Private Sub btInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInput.Click

        EngLang()

        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                MsgBox("ไม่สามาถเชื่อมต่อ ไปที่ Server 172.16.0.102 ได้ ,ติดต่อ PM Check Network.")
                Exit Sub
            End If

        Else
            'LAN
            MsgBox("ไม่สามาถเชื่อมต่อ Networkได้ ,โปรดตรวจเช็คสาย LAN")
            Exit Sub

        End If



        frmInputQR.Caption = "SCAN QR CODE"
        If frmInputQR.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim QR As String = frmInputQR.QRCode.ToUpper
            Dim OPNo As String = frmInputQR.QROpNo
            Dim Package As String = Trim(QR.Substring(0, 10))
            Dim Device As String = Trim(QR.Substring(10, 20))
            Dim LotNo As String = Trim(QR.Substring(30, 10))
            Dim ProcessDBWB As String = frmDataNG.SelectProcess
            Dim InputMag As String = frmDataNG.Mag
            Dim LotInTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss")
            Dim NameMC As String = frmDataNG.NameMC

            If ProcessDBWB <> "SP" Then
                Dim LotNoInDBx As String = CheckLotInDBx(LotNo, ProcessDBWB)
                If LotNoInDBx = True Then
                    MsgBox("LOTNO." & LotNo & " มีการ INPUT เข้าไปใน PROCESS " & ProcessDBWB & "ไม่สามารถ INPUT ซ้ำได้")

                    Exit Sub

                End If
            End If
            If CheckOldData = False Then

                '///////// By Pass Function FindMCNo

                'Dim MCNo As String = FindMCNo(LotNo, ProcessDBWB)
                'If MCNo = "" Then
                '    MsgBox("Lotนี้หา M/C ในระบบไม่เจอกรุณาป้อน Neme M/C")
                '    'Exit Sub 
                '    tbMCNo.Enabled = True
                '    tbMCNo.BackColor = Color.Yellow
                'End If

                ClearAll()
                TB_Process.Text = ProcessDBWB
                'tbMCNo.Text = MCNO
                tbMCNo.Text = NameMC
                lbPackage.Text = Package
                lbDevice.Text = Device
                lb_LotNo.Text = LotNo
                lbOpNo.Text = OPNo

                lb_Objectins.Text = InputMag
                lbLotintime.Text = LotInTime
                StatusLot = "Input Lot"
                Status(StatusLot)
                CheckOldData = False
                LB_Status.Text = frmDataNG.Status
                'AddComLog("InputLot:" & MCNo & "," & LotNo & "," & OPNo)
            Else
                lbPackage.Text = Package
                lbDevice.Text = Device
                CheckOldData = True
            End If

        End If

        If LB_Status.Text = "NORMAL" Then
            LB_Status.BackColor = Color.LimeGreen
        ElseIf LB_Status.Text = "URGENT" Then
            LB_Status.BackColor = Color.Crimson
        End If


        btOK.Show()

        BtCancleLotConfirm.Hide()
        NameINSTime.Hide()
        NameEndTime.Hide()
        NameRemark.Hide()
        LbTimeInspec.Hide()
        LbTimeEnd.Hide()
        LbRemark.Hide()
    End Sub

    Private Declare Function LoadKeyboardLayout Lib "user32" Alias "LoadKeyboardLayoutA" _
(ByVal pwszKLID As String, ByVal flags As Long) As Long

    Sub ThaiLang()
        Dim Ret As Long
        Ret = LoadKeyboardLayout("0000041E", 1)
    End Sub

    Sub EngLang()
        Dim Ret As Long
        Ret = LoadKeyboardLayout("00000409", 1)
    End Sub


    Private Sub btOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOK.Click
        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                MsgBox("ไม่สามาถเชื่อมต่อ ไปที่ Server 172.16.0.102 ได้ ,ติดต่อ PM Check Network.")
                Exit Sub
            End If

        Else
            'LAN
            MsgBox("ไม่สามาถเชื่อมต่อ Networkได้ ,โปรดตรวจเช็คสาย LAN")
            Exit Sub

        End If

        If tbMCNo.Text = "" Then
            MsgBox("กรุณาป้อน Name M/C")
            Exit Sub
        End If
        If TB_ReqName1.Text = "" Then
            MsgBox("กรุณาเลือกค่า Mode NG Request")
            Exit Sub
        End If
        If TB_ReqName2.Text = "" Then
            TB_ReqName2.Text = "-"
        End If

        If TB_PICKUP.Text = "" Then
            MsgBox("กรุณาป้อนค่า DB M/C ALM #01 PICKUP.")
            Exit Sub
        End If
        If TB_PREFORM.Text = "" Then
            MsgBox("กรุณาป้อนค่า DB M/C ALM #04 PREFORM.")
            Exit Sub
        End If
        If TB_FRAMEOUT.Text = "" Then
            MsgBox("กรุณาป้อนค่า DB M/C ALM #06 FRAMEOUT.")
            Exit Sub
        End If
        If TB_BONDER.Text = "" Then
            MsgBox("กรุณาป้อนค่า DB M/C ALM #07 BONDER.")
            Exit Sub
        End If
        If TB_PASTEINS.Text = "" Then
            MsgBox("กรุณาป้อนค่า DB M/C ALM #14 PASTE BRIDGE INSPEC.")
            Exit Sub
        End If
        If TB_PREFORMINS.Text = "" Then
            MsgBox("กรุณาป้อนค่า DB M/C ALM #16 PREFORM INSPECTION.")
            Exit Sub
        End If

        If TB_AUCUTSHORT.Text = "" Then
            MsgBox("กรุณาป้อนค่า WB M/C ALM #01,#20 AU-CUT,SHORT TAIL.")
            Exit Sub
        End If
        If TB_PADNIN.Text = "" Then
            MsgBox("กรุณาป้อนค่า WB M/C ALM #02 PAD NINSHIKI.")
            Exit Sub
        End If
        If TB_LEADNIN.Text = "" Then
            MsgBox("กรุณาป้อนค่า WB M/C ALM #04 LEAD NINSHIKI.")
            Exit Sub
        End If
        If TB_BPM.Text = "" Then
            MsgBox("กรุณาป้อนค่า WB M/C ALM #17 BPM.")
            Exit Sub
        End If
        If TB_NSOP.Text = "" Then
            MsgBox("กรุณาป้อนค่า WB M/C ALM #18 NSOP.")
            Exit Sub
        End If
        If TB_NSOL.Text = "" Then
            MsgBox("กรุณาป้อนค่า WB M/C ALM #19 NSOL.")
            Exit Sub
        End If


        If PBNGSample.Image IsNot Nothing Then
            If TB_Process.Text = "DB" Then
                PBNGSample.Image.Save("\\172.16.0.115\MachineData\DB\Inspector\DB\" & lb_LotNo.Text & "_NG Sample.JPG")
            End If
            If TB_Process.Text = "WB" Then
                PBNGSample.Image.Save("\\172.16.0.115\MachineData\DB\Inspector\WB\" & lb_LotNo.Text & "_NG Sample.JPG")
            End If
        End If
        StatusLot = "Inspection"
        Status(StatusLot)
        SaveDBWBInsdatatoDBx(lb_LotNo.Text)
        CheckLotAlmQtySavetoDBx()


        SaveDataLotBin()
        AddComLog("Input Lot:" & lbPackage.Text & "," & lbDevice.Text & "," & lb_LotNo.Text & "," & "OP ON." & lbOpNo.Text & "," & tbMCNo.Text & ",Ins(MAG)" & lb_Objectins.Text _
         & ",ReqMode:" & TB_ReqName1.Text & "," & TB_ReqName2.Text & ",")                            '& tbReq3.Text & "," & tbReq4.Text & "," & tbReq5.Text)
        If m_offlineMode = "Online" Then
            SendPostMessage("@LOTREQ" & "|" & HeaderMCNo & "|" & lb_LotNo.Text & "," & lbOpNo.Text & ",00")   'Normal
        End If
        CountListData()
        btOK.Hide()


    End Sub
    Private Sub CheckLotAlmQtySavetoDBx()
        'DB
        Dim LotNo As String
        Dim ProcessAlm As String
        Dim AlmNo As String
        Dim AlmMess As String
        Dim AlmQty As String


        If TB_PICKUP.Text <> "" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "01"
            AlmMess = "PICK UP"
            AlmQty = TB_PICKUP.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_PREFORM.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "04"
            AlmMess = "PREFORM"
            AlmQty = TB_PREFORM.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_FRAMEOUT.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "06"
            AlmMess = "FRAME OUT"
            AlmQty = TB_FRAMEOUT.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_BONDER.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "07"
            AlmMess = "BONDER"
            AlmQty = TB_BONDER.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_PASTEINS.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "14"
            AlmMess = "PASTE BRIDGE INSPEC"
            AlmQty = TB_PASTEINS.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_PREFORMINS.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "16"
            AlmMess = "PREFORM INSPECTION"
            AlmQty = TB_PREFORMINS.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        'If TB_PREFORMINS.Text <> "" Then
        '    LotNo = lb_LotNo.Text
        '    ProcessAlm = "DB"
        '    AlmNo = "16"
        '    AlmMess = "PREFORM INSPECTION"
        '    AlmQty = TB_PREFORMINS.Text
        '    AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
        'End If

        'WB
        If TB_AUCUTSHORT.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "01"
            AlmMess = "AU-CUT,SHORT TAIL"
            AlmQty = TB_AUCUTSHORT.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_PADNIN.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "02"
            AlmMess = "PAD NINSHIKI"
            AlmQty = TB_PADNIN.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_LEADNIN.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "04"
            AlmMess = "LEAD NINSHIKI"
            AlmQty = TB_LEADNIN.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_BPM.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "17"
            AlmMess = "BPM"
            AlmQty = TB_BPM.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_NSOP.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "18"
            AlmMess = "NSOP"
            AlmQty = TB_NSOP.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If
        If TB_NSOL.Text <> "-" Then
            LotNo = lb_LotNo.Text
            ProcessAlm = TB_Process.Text
            AlmNo = "19"
            AlmMess = "NSOL"
            AlmQty = TB_NSOL.Text
            AddlotAlmQtytoDBx(LotNo, ProcessAlm, AlmNo, AlmMess, AlmQty)
            AddComLogLotAlmQty("LotNo : " & LotNo & " , ProcessAlm : " & ProcessAlm & " , AlmNo : " & AlmNo & " : " & AlmMess & " , Qty : " & AlmQty)
        End If




    End Sub



    Private Sub AddlotAlmQtytoDBx(ByVal Lotno As String, ByVal LotAlarmQty As String, ByVal AlmNo As String, ByVal AlmMess As String, ByVal AlmQty As String)
        If CheckOldData = False Then
            Dim newRow As DBxDataSet.LotAlarmQtyRow = DBxDataSet.LotAlarmQty.NewLotAlarmQtyRow()
            m_LotAlarmQty = newRow
            If m_LotAlarmQty IsNot Nothing Then
                m_LotAlarmQty.LotNo = Lotno
                m_LotAlarmQty.Process = LotAlarmQty
                m_LotAlarmQty.AlarmNo = AlmNo
                m_LotAlarmQty.AlarmMess = AlmMess
                m_LotAlarmQty.Qty = AlmQty
                m_LotAlarmQty.CreateTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
            End If
            'DBxDataSet.DBWBINSData.Rows.Add(m_DbWbInsp)
            DBxDataSet.LotAlarmQty.Rows.Add(m_LotAlarmQty)
            LotAlarmQtyTableAdapter.Update(DBxDataSet.LotAlarmQty)

        Else
            For Each row As DBxDataSet.LotAlarmQtyRow In DBxDataSet.LotAlarmQty
                If row.LotNo = lb_LotNo.Text Then
                    ClearAll()
                    FindDataLot(Lotno)
                End If
            Next
        End If
    End Sub



    Private Sub SaveDBWBInsdatatoDBx(ByVal lotNo As String)

        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                Exit Sub
            End If
            'LAN
        Else
            Exit Sub

        End If


        If CheckOldData = False Then
            Dim newRow As DBxDataSet.DBWBINSDataRow = DBxDataSet.DBWBINSData.NewDBWBINSDataRow()
            m_DbWbInsp = newRow
            If m_DbWbInsp IsNot Nothing Then
                m_DbWbInsp.LotNo = lb_LotNo.Text
                m_DbWbInsp.Process = TB_Process.Text
                m_DbWbInsp.MCNo = tbMCNo.Text
                m_DbWbInsp.OPNo = lbOpNo.Text
                '   m_DbWbInsp.StartTime = lbLotintime.Text
                m_DbWbInsp.ReqDate = lbLotintime.Text
                m_DbWbInsp.RequestModeName1 = TB_ReqName1.Text
                m_DbWbInsp.RequestModeName2 = TB_ReqName2.Text
                m_DbWbInsp.RequestMode1 = TB_ModeReq1.Text
                m_DbWbInsp.RequestMode2 = TB_ModeReq2.Text
                m_DbWbInsp.RequestModeRemark1 = TB_OTherRemak1.Text
                m_DbWbInsp.RequestModeRemark2 = TB_OTherRemak2.Text
                m_DbWbInsp.ObjectIns = lb_Objectins.Text
                m_DbWbInsp.Package = lbPackage.Text
                m_DbWbInsp.ComName = System.Net.Dns.GetHostName
                m_DbWbInsp.Status = LB_Status.Text
                m_DbWbInsp.Remark = Tb_Remark.Text

            End If
            'DBxDataSet.DBWBINSData.Rows.Add(m_DbWbInsp)
            DBxDataSet.DBWBINSData.Rows.Add(m_DbWbInsp)
            DBWBINSDataTableAdapter.Update(DBxDataSet.DBWBINSData)
        Else
            For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
                If row.LotNo = lb_LotNo.Text AndAlso row.StartTime = lbLotintime.Text Then
                    ClearAll()
                    FindDataLot(lotNo)
                End If
            Next
        End If
    End Sub
    Private Sub SaveDatatoDBx()

        If m_offlineMode = "Offline" Then
            Exit Sub
        End If

        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                Exit Sub
            End If
            'LAN
        Else
            Exit Sub

        End If

        Dim removeList As List(Of DataRow) = New List(Of DataRow)
        For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
            If row.LotNo = lb_LotNo.Text AndAlso row.LotJudg <> "" Then
                Try
                    Dim fillAffectedRow As Integer = DBWBINSDataTableAdapter.Update(row)
                    If fillAffectedRow = 1 Then
                        removeList.Add(row)
                    End If
                Catch ex As Exception
                    SaveDataError(row)
                    removeList.Add(row)
                End Try
            End If
        Next

        For Each row As DataRow In removeList
            DBxDataSet.DBWBINSData.Rows.Remove(row)
        Next

    End Sub
    Public Sub SaveDataError(ByVal row As DBxDataSet.DBWBINSDataRow)


        Dim randomFileName As String = Guid.NewGuid().ToString() & ".xml"
        Dim folder As String = Path.Combine(My.Application.Info.DirectoryPath, "DataError")
        If Not Directory.Exists(folder) Then
            Directory.CreateDirectory(folder)
        End If

        Using table As DBxDataSet.DBWBINSDataDataTable = New DBxDataSet.DBWBINSDataDataTable
            table.ImportRow(row)
            Using sw As StreamWriter = New StreamWriter(Path.Combine(folder, randomFileName))
                table.WriteXml(sw.BaseStream)
            End Using
        End Using
    End Sub
    Private Sub CountListData()
        ltBefore.Items.Clear()
        'ltWaitGL.Items.Clear()
        'ltInspec.Items.Clear()
        Dim countUpdate As Integer = 0
        Dim count As Integer = 0
        Dim countGL As Integer = 0
        'DBWBINSDataTableAdapter.FillDataTable(DBxDataSet.DBWBINSData, "4/1/2016")

        Dim tb As DBxDataSet.DBWBINSDataDataTable = New DBxDataSet.DBWBINSDataDataTable
        Dim db As New DBxDataSetTableAdapters.DBWBINSDataTableAdapter
        db.FillWip(tb)


        For Each row As DBxDataSet.DBWBINSDataRow In tb
            Try


                If row.LotNo <> "" AndAlso row.IsEndTimeNull = True Then 'Before
                    ltBefore.Items.Add(row.LotNo & " , " & row.Package & " , " & row.Status)
                    count += 1
                    'ElseIf row.LotNo <> "" AndAlso row.IsInspectorNoNull = True AndAlso row.IsTotalQtyNull = False Then 'Inspection
                    '    ltInspec.Items.Add(row.LotNo & "," & row.Package)
                    '    countUpdate += 1
                    'ElseIf row.LotNo <> "" AndAlso row.IsLotJudgNull = True AndAlso row.IsInspectorNoNull = False Then 'Gl Wait
                    '    ltWaitGL.Items.Add(row.LotNo & "," & row.Package)
                    '    countGL += 1
                End If
            Catch ex As Exception

            End Try
        Next
        'lbInspection.Text = countUpdate
        lbCountUpdate.Text = count
        'lbGLCheck.Text = countGL
    End Sub


    'Private Sub tbInput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbInsNGNum2.Click
    '    Dim tb As TextBox = CType(sender, TextBox)
    '    tb = CType(sender, TextBox)

    '    m_Numpad.TargetTextBox = tb
    '    If Not m_Numpad.Visible Then
    '        m_Numpad.Show(Me)
    '        m_Numpad.Left = Me.Right - 500
    '        m_Numpad.Top = Me.Bottom - 420
    '    End If

    'End Sub


    Dim target As TextBox
    Dim strProcess As String
    Private Sub tbReq1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_ReqName2.Click, TB_ReqName1.Click
        Dim tb As TextBox = CType(sender, TextBox)
        ContextMenuStrip3.Show(tb, New Point(0, tb.Height))
        target = tb


        If TB_ReqName1.Text = "" Then
            TB_ReqName1.BackColor = Color.GreenYellow
            TB_ReqName2.Enabled = True
            TB_ReqName2.BackColor = Color.Yellow
        End If

    End Sub




    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMCNo.Click
        Dim tb As TextBox
        Dim key As FrmKeyBoard = New FrmKeyBoard
        tb = CType(sender, TextBox)
        key.TargetText = tb
        key.Show()

    End Sub



    Private Sub tbReq1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_ReqName1.TextChanged
        If TB_ReqName1.Text <> "" Then
            TB_ReqName1.BackColor = Color.GreenYellow
            TB_ModeReq1.BackColor = Color.GreenYellow
            TB_ReqName2.Enabled = True
            TB_ReqName2.BackColor = Color.Yellow
            TB_ModeReq2.BackColor = Color.Yellow
            TB_ReqName2.Focus()
        End If




    End Sub
    Private Sub tbReq2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_ReqName2.TextChanged

        If TB_ReqName2.Text <> "" Then
            TB_ReqName2.BackColor = Color.GreenYellow
            TB_ModeReq2.BackColor = Color.GreenYellow

        End If


    End Sub



    Private Sub SaveDataLotBin()
        Using sw As StreamWriter = New StreamWriter("DBWBINSPData.bin")
            Dim b As BinaryFormatter = New BinaryFormatter()
            b.Serialize(sw.BaseStream, DBxDataSet.DBWBINSData)
        End Using
    End Sub

    Private Sub LoadDataLotBin()
        If File.Exists(My.Application.Info.DirectoryPath & "\DBWBINSPData.bin") = False Then
            Exit Sub
        End If
        Using sw As StreamReader = New StreamReader("DBWBINSPData.bin")
            Dim b As BinaryFormatter = New BinaryFormatter()
            Dim dt As DBxDataSet.DBWBINSDataDataTable = CType(b.Deserialize(sw.BaseStream), DBxDataSet.DBWBINSDataDataTable)
            For Each row As DBxDataSet.DBWBINSDataRow In dt.Rows
                DBxDataSet.DBWBINSData.ImportRow(row)
            Next
        End Using
    End Sub
#Region "=== TDC (APCS DATA BASE)"

    Private strRecv As String
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function
    Private Declare Function PostMessage Lib "user32.dll" Alias "PostMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private m_TDCProcess As Process
    Private Const WM_CUSTOMMESSAGE As Long = &H400
    Private Const WM_CUSTOMMESSAGE_END As Long = &HD
    Delegate Sub DelegateLoadSimFile(ByVal fpath As String, ByRef listControl As ListBox)
    Private dLoadSimFile As DelegateLoadSimFile

    Private Sub SendString(ByVal hWnd As Integer, ByVal strSend As String)
        'create byte array
        Dim ba() As Byte
        ba = Encoding.UTF8.GetBytes(strSend)
        For i As Integer = 0 To ba.Length - 1
            PostMessage(hWnd, WM_CUSTOMMESSAGE, 0, ba(i))
        Next
        PostMessage(hWnd, WM_CUSTOMMESSAGE, 0, WM_CUSTOMMESSAGE_END)

    End Sub
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        MyBase.WndProc(m)
        If m.Msg = WM_CUSTOMMESSAGE Then
            If m.LParam <> &HD Then
                Dim tmp(0) As Byte
                tmp(0) = m.LParam
                strRecv = strRecv & (Encoding.UTF8.GetString(tmp))
            Else
                Me.txtPostMSGRecv.Text = strRecv
                strRecv = ""
            End If
        End If
    End Sub
    Public Sub SendPostMessage(ByVal strSend As String)

        If m_offlineMode = "Offline" Then
            Exit Sub
        End If

        Dim tWnd As Long
        tWnd = FindWindow(vbNullString, "TDC")
        If tWnd <> 0 And strSend <> "" Then
            Dim i As Integer
            For i = 1 To Len(strSend)
                Call PostMessage(tWnd, WM_CUSTOMMESSAGE, 0, Asc(Mid(strSend, i, 1)))
            Next
            Call PostMessage(tWnd, WM_CUSTOMMESSAGE, 0, WM_CUSTOMMESSAGE_END)       ' Send [CR] Code

        End If
    End Sub
    Private Sub txtPostMSGRecv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPostMSGRecv.TextChanged

        Dim PMSRecvData As String
        Dim SplitData() As String
        Dim HEADER As String
        Dim Content1 As String
        Dim Content() As String
        Dim ContentMCNo() As String

        PMSRecvData = txtPostMSGRecv.Text
        SplitData = Split(PMSRecvData, "|")
        If SplitData.Length > 3 Then                        'Concatenate string back block 3
            For i = 3 To SplitData.Length - 1
                SplitData(2) = SplitData(2) & "|" & SplitData(i)
            Next
        End If
        If SplitData(0) = "" Then
            Exit Sub
        End If
        Try
            HEADER = SplitData(0)
            ContentMCNo = Split(SplitData(1), "-")
            HeaderMCNo = ContentMCNo(0) & "-" & ContentMCNo(1) & "-" & ContentMCNo(2)
            Content1 = SplitData(2)

        Catch ex As Exception
            Exit Sub
        End Try
        Select Case HEADER
            Case "@CNTREQ"                                  '***  TDC Commu: Get Reply -> Lot Setup Report  ***
                If SplitData(2) = "00" Then

                ElseIf SplitData(2) = "01" Then
                    MsgBox("Not Connect To TDC", 48, "Connect TDC")
                End If


            Case "@LOTRPT"                          '***  TDC Commu: Get Reply -> Lot Information Request  ***
                Content = Split(Content1, ",")
                If UBound(Content) >= 2 Then        ' LotReport  Return OK
                    'Dim data As TPData = SelfConData.Data
                    SendPostMessage("@LOTRPT|" & HeaderMCNo & "|" & "00")   '***  TDC Commu: ACK Lot Information Request  ***
                    SendPostMessage("@LOTSET|" & HeaderMCNo & "|" & lb_LotNo.Text & "," & lbLotintime.Text & ",00")   ' TDC lotstart 
                    'SelfConData.Data.LotInform = "00 : Running Normal"          '130809

                ElseIf UBound(Content) = 1 Then       'LotReport Return NG 


                    SendPostMessage("@LOTRPT|" & HeaderMCNo & "|" & "00")
                    SendPostMessage("@LOTSET|" & HeaderMCNo & "|" & lb_LotNo.Text & "," & lbLotintime.Text & ",00")   ' TDC lotstart 


                    If Content(0) = "01" Then         'Error 01 Not Found


                    ElseIf Content(0) = "02" Then     'Error 02 Running


                    ElseIf Content(0) = "04" Then     'Error 04 Machine not found


                    ElseIf Content(0) = "05" Then


                    ElseIf Content(0) = "06" Then


                    ElseIf Content(0) = "70" Then


                    ElseIf Content(0) = "71" Then


                    ElseIf Content(0) = "72" Then


                    ElseIf Content(0) = "73" Then


                    ElseIf Content(0) = "99" Then
                    End If
                    'SelfConData.Data.LotInform = Content(0) & ":" & Content(1)
                    'AddComLog(SelfConData.Data.LotInform)
                End If


            Case "@LOTSET"                                  '***  TDC No Handle For Right Now


            Case "@STRRPT"                                  '***  TDC Commu: Get Reply -> Lot Setup Report  ***
                SendPostMessage("@STRRPT" & "|" & HeaderMCNo & "|" & "00")         '***  TDC Commu: ACK Start Information Request  **

            Case "@LOTEND"                                  '***  TDC No Handle For Right Now


            Case "@ENDINF"                                  '***  TDC Commu: Get Reply -> Lot END Report  ***
                Content = Split(Content1, ",")
                SendPostMessage("@ENDINF|" & HeaderMCNo & "|" & "00")          '***  TDC Commu: ACK End Information Request  ***
                'If IsNumeric(Content(0)) Then
                '    AddComLog(lbLot.Text & " , " & PMSRecvData)
                'End If
        End Select                                                                     'Show SelconM data change
        txtPostMSGRecv.Text = ""
    End Sub
#End Region

    Private Sub lbHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbHelp.Click
        If File.Exists("D:\SelfCon\Operation  Standardx Inspec DBWB.pdf") Then
            Process.Start("D:\SelfCon\Operation  Standardx Inspec DBWB.pdf")
        Else
            MsgBox("Find ''D:\SelfCon\Operation  Standardx Inspec DBWB.pdf")

        End If

    End Sub

    'Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
    '    DBWBINSData1TableAdapter.FillTop10(DBxDataSet.DBWBINSData1)
    'End Sub
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        ', OPENMODEToolStripMenuItem.Click, NECKCUTNECKSTRESSToolStripMenuItem.Click, BALLZUREToolStripMenuItem.Click _
        ', WIRINGMISToolStripMenuItem.Click

        Dim bt As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        target.Text = strProcess & bt.Text.Substring(0, 3)
    End Sub


    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBToolStripMenuItem.Click, OTToolStripMenuItem.Click, DBToolStripMenuItem.Click
        Dim bt As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        strProcess = bt.Text
    End Sub
    Private Sub tbMCNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMCNo.TextChanged
        If tbMCNo.Text <> "" Then
            tbMCNo.BackColor = Color.FloralWhite
        End If
    End Sub

    Private Sub btupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btupdate.Click


        If m_offlineMode = "Offline" Then
            Exit Sub
        End If

        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                Exit Sub
            End If
            'LAN
        Else
            Exit Sub

        End If

        Dim removeList As List(Of DataRow) = New List(Of DataRow)



        For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
            Try
                Dim fillAffectedRow As Integer = DBWBINSDataTableAdapter.Update(row)
                If fillAffectedRow = 1 Then
                    removeList.Add(row)
                End If
            Catch ex As Exception
                SaveDataError(row)
                removeList.Add(row)
            End Try

        Next

        For Each row As DataRow In removeList
            DBxDataSet.DBWBINSData.Rows.Remove(row)
        Next

        LotAlarmQtyTableAdapter.Update(DBxDataSet.LotAlarmQty)
        DBxDataSet.LotAlarmQty.Clear()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim timenew As Date = Format(Now, "yyyy/MM/dd HH:mm:ss")
        Dim DataTaCSV As String = ""
        Dim CountWip As Integer = 0

        DBWBINSDataTableAdapter.Fill(DBxDataSet.DBWBINSData)
        For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
            Try


                If row.LotNo <> "" AndAlso row.IsEndTimeNull = True Then

                    LB_CheckWip.Items.Add(row.LotNo & "," & row.Package & "," & row.ReqDate & ", Request 1 : " & row.RequestModeName1 & ",  Request 2 : " & row.RequestModeName2)
                    DataTaCSV &= (row.LotNo & "," & row.Package & "," & row.ReqDate & ", Request 1 : " & row.RequestModeName1 & ",  Request 2 : " & row.RequestModeName2) & vbCrLf
                    CountWip += 1
                End If



            Catch ex As Exception

            End Try
        Next

        ' WritetoCSV(My.Application.Info.Description & "WIP INSPECTION" & Format(Now, "yyyyMMdd") & ".CSV", DataTaCSV)
        WritetoCSV(My.Application.Info.DirectoryPath & "\WIP\" & "WIPINSPECTION" & Format(Now, "yyyyMMdd") & ".CSV", DataTaCSV)
        ' WritetoCSV(My.Application.Info.Description & "WIP INSPECTION.CSV", DataTaCSV)
        Timer1.Enabled = False
        LB_CheckWipToCSV.Text = CountWip

    End Sub



    Private Sub WritetoCSV(ByVal fileName As String, ByVal m As String)
        Using sw As New StreamWriter(fileName, False)
            sw.Write(m)
        End Using
    End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim aa As String = ""
    '    For Each strdata As String In LB_CheckWip.Items
    '        aa &= strdata & vbCrLf
    '    Next
    '    WritetoCSV(My.Application.Info.Description & "AAA.csv", aa)

    'End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                MsgBox("ไม่สามาถเชื่อมต่อ ไปที่ Server 172.16.0.102 ได้ ,ติดต่อ PM Check Network.")
                Exit Sub
            End If

        Else
            'LAN
            MsgBox("ไม่สามาถเชื่อมต่อ Networkได้ ,โปรดตรวจเช็คสาย LAN")
            Exit Sub

        End If

        LB_CheckWip.Items.Clear()
        Timer1.Enabled = True


    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' DBWBINSData1TableAdapter.FillTop10(DBxDataSet.DBWBINSData1)
    End Sub


    Private Sub ToolStripMenuItem2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles WBToolStripMenuItem9.MouseLeave, WBToolStripMenuItem8.MouseLeave, WBToolStripMenuItem7.MouseLeave, WBToolStripMenuItem6.MouseLeave, WBToolStripMenuItem5.MouseLeave, WBToolStripMenuItem4.MouseLeave, WBToolStripMenuItem3.MouseLeave, WBToolStripMenuItem26.MouseLeave, WBToolStripMenuItem25.MouseLeave, WBToolStripMenuItem24.MouseLeave, WBToolStripMenuItem23.MouseLeave, WBToolStripMenuItem22.MouseLeave, WBToolStripMenuItem21.MouseLeave, WBToolStripMenuItem20.MouseLeave, WBToolStripMenuItem2.MouseLeave, WBToolStripMenuItem19.MouseLeave, WBToolStripMenuItem18.MouseLeave, WBToolStripMenuItem17.MouseLeave, WBToolStripMenuItem16.MouseLeave, WBToolStripMenuItem15.MouseLeave, WBToolStripMenuItem14.MouseLeave, WBToolStripMenuItem13.MouseLeave, WBToolStripMenuItem12.MouseLeave, WBToolStripMenuItem11.MouseLeave, WBToolStripMenuItem10.MouseLeave, WBToolStripMenuItem1.MouseLeave, DBToolStripMenuItem9.MouseLeave, DBToolStripMenuItem8.MouseLeave, DBToolStripMenuItem7.MouseLeave, DBToolStripMenuItem6.MouseLeave, DBToolStripMenuItem5.MouseLeave, DBToolStripMenuItem4.MouseLeave, DBToolStripMenuItem3.MouseLeave, DBToolStripMenuItem21.MouseLeave, DBToolStripMenuItem20.MouseLeave, DBToolStripMenuItem2.MouseLeave, DBToolStripMenuItem19.MouseLeave, DBToolStripMenuItem18.MouseLeave, DBToolStripMenuItem17.MouseLeave, DBToolStripMenuItem16.MouseLeave, DBToolStripMenuItem15.MouseLeave, DBToolStripMenuItem14.MouseLeave, DBToolStripMenuItem13.MouseLeave, DBToolStripMenuItem12.MouseLeave, DBToolStripMenuItem11.MouseLeave, DBToolStripMenuItem10.MouseLeave, DBToolStripMenuItem1.MouseLeave












        PictureBox1.Visible = False
        PictureBox2.Visible = False
    End Sub


    Private Sub ToolStripMenuItem1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem1.MouseMove
        PictureBox1.Image = My.Resources.DB1
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub

    Private Sub ToolStripMenuItem2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem2.MouseMove
        PictureBox1.Image = My.Resources.DB2
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem3.MouseMove
        PictureBox1.Image = My.Resources.DB3
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem4.MouseMove
        PictureBox1.Image = My.Resources.DB4
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem5.MouseMove
        PictureBox1.Image = My.Resources.DB5
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem6.MouseMove
        PictureBox1.Image = My.Resources.DB6
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem7_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem7.MouseMove
        PictureBox1.Image = My.Resources.DB7
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem8_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem8.MouseMove
        PictureBox1.Image = My.Resources.DB8
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem9_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem9.MouseMove
        PictureBox1.Image = My.Resources.DB9
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem10_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem10.MouseMove
        PictureBox1.Image = My.Resources.DB10
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem11_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem11.MouseMove
        PictureBox1.Image = My.Resources.DB11
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem12_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem12.MouseMove
        PictureBox1.Image = My.Resources.DB12
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem13_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem13.MouseMove
        PictureBox1.Image = My.Resources.DB13
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem14_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem14.MouseMove
        PictureBox1.Image = My.Resources.DB14
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem15_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem15.MouseMove
        PictureBox1.Image = My.Resources.DB15
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem16_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem16.MouseMove
        PictureBox1.Image = My.Resources.DB16
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem17_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem17.MouseMove
        PictureBox1.Image = My.Resources.DB17
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem18_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem18.MouseMove
        PictureBox1.Image = My.Resources.DB18
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem19_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem19.MouseMove
        PictureBox1.Image = My.Resources.DB19
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem20_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem20.MouseMove
        PictureBox1.Image = My.Resources.DB20
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub ToolStripMenuItem21_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBToolStripMenuItem21.MouseMove
        PictureBox1.Image = My.Resources.DB21
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub

    Private Sub WBToolStripMenuItem1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem1.MouseMove
        PictureBox1.Image = My.Resources.WB1
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem2.MouseMove
        PictureBox1.Image = My.Resources.WB2
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem3.MouseMove
        PictureBox1.Image = My.Resources.WB3
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem4_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem4.MouseMove
        PictureBox1.Image = My.Resources.WB4
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem5_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem5.MouseMove
        PictureBox1.Image = My.Resources.WB5
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem6_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem6.MouseMove
        PictureBox1.Image = My.Resources.WB6
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem7_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem7.MouseMove
        PictureBox1.Image = My.Resources.WB7
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem8_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem8.MouseMove
        PictureBox1.Image = My.Resources.WB8
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem9_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem9.MouseMove
        PictureBox1.Image = My.Resources.WB9
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem10_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem10.MouseMove
        PictureBox1.Image = My.Resources.WB10
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem11_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem11.MouseMove
        PictureBox1.Image = My.Resources.WB11
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem12_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem12.MouseMove
        PictureBox1.Image = My.Resources.WB12
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem13_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem13.MouseMove
        PictureBox1.Image = My.Resources.WB13
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem14_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem14.MouseMove
        PictureBox1.Image = My.Resources.WB14
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem15_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem15.MouseMove
        PictureBox1.Image = My.Resources.WB15
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem16_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem16.MouseMove
        PictureBox1.Image = My.Resources.WB16
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem17_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem17.MouseMove
        PictureBox1.Image = My.Resources.WB17
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem18_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem18.MouseMove
        PictureBox1.Image = My.Resources.WB18
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem19_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem19.MouseMove
        PictureBox1.Image = My.Resources.WB19
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem20_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem20.MouseMove
        PictureBox1.Image = My.Resources.WB20
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem21_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem21.MouseMove
        PictureBox1.Image = My.Resources.WB21
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem22_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem22.MouseMove
        PictureBox1.Image = My.Resources.WB22
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem23_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem23.MouseMove
        PictureBox1.Image = My.Resources.WB23
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem24_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem24.MouseMove
        PictureBox1.Image = My.Resources.WB24
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem25_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem25.MouseMove
        PictureBox1.Image = My.Resources.WB25
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub
    Private Sub WBToolStripMenuItem26_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WBToolStripMenuItem26.MouseMove
        PictureBox1.Image = My.Resources.WB26
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub


    Private Sub DBToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBToolStripMenuItem12.Click, WBToolStripMenuItem9.Click, WBToolStripMenuItem8.Click, WBToolStripMenuItem7.Click, WBToolStripMenuItem6.Click, WBToolStripMenuItem5.Click, WBToolStripMenuItem4.Click, WBToolStripMenuItem3.Click, WBToolStripMenuItem26.Click, WBToolStripMenuItem25.Click, WBToolStripMenuItem24.Click, WBToolStripMenuItem23.Click, WBToolStripMenuItem22.Click, WBToolStripMenuItem21.Click, WBToolStripMenuItem20.Click, WBToolStripMenuItem2.Click, WBToolStripMenuItem19.Click, WBToolStripMenuItem18.Click, WBToolStripMenuItem17.Click, WBToolStripMenuItem16.Click, WBToolStripMenuItem15.Click, WBToolStripMenuItem14.Click, WBToolStripMenuItem13.Click, WBToolStripMenuItem12.Click, WBToolStripMenuItem11.Click, WBToolStripMenuItem10.Click, WBToolStripMenuItem1.Click, OTToolStripMenuItem3.Click, OTToolStripMenuItem2.Click, OTToolStripMenuItem1.Click, MAToolStripMenuItem4.Click, MAToolStripMenuItem3.Click, MAToolStripMenuItem2.Click, MAToolStripMenuItem1.Click, DBToolStripMenuItem9.Click, DBToolStripMenuItem8.Click, DBToolStripMenuItem7.Click, DBToolStripMenuItem6.Click, DBToolStripMenuItem5.Click, DBToolStripMenuItem4.Click, DBToolStripMenuItem3.Click, DBToolStripMenuItem21.Click, DBToolStripMenuItem20.Click, DBToolStripMenuItem2.Click, DBToolStripMenuItem19.Click, DBToolStripMenuItem18.Click, DBToolStripMenuItem17.Click, DBToolStripMenuItem16.Click, DBToolStripMenuItem15.Click, DBToolStripMenuItem14.Click, DBToolStripMenuItem13.Click, DBToolStripMenuItem11.Click, DBToolStripMenuItem10.Click, DBToolStripMenuItem1.Click, ADToolStripMenuItem4.Click, ADToolStripMenuItem3.Click, ADToolStripMenuItem2.Click, ADToolStripMenuItem1.Click










        Dim tb As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        target.Text = tb.Text

        If tb.Text = TB_ReqName1.Text Then
            CompareNameReqeust(tb.Text)
            TB_ModeReq1.Text = ModeReq
            TB_OTherRemak1.Text = ""
            TB_OTherRemak1.Enabled = False
        End If
        If tb.Text = TB_ReqName2.Text Then
            CompareNameReqeust(tb.Text)
            TB_ModeReq2.Text = ModeReq
            TB_OTherRemak2.Text = ""
            TB_OTherRemak2.Enabled = False
        End If
    End Sub
    Private Sub DBToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBToolStripMenuItem22.Click

        Dim tb As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        target.Text = tb.Text


        If key Is Nothing Then
            key = New FrmKeyBoard
        End If

        If tb.Text = TB_ReqName1.Text Then
            TB_OTherRemak1.Enabled = True
            ' Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak1
            key.Show()
            target.Select()
            TB_ModeReq1.Text = "DB22"
        End If

        If tb.Text = TB_ReqName2.Text Then
            TB_OTherRemak2.Enabled = True
            ' Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak2
            key.Show()
            target.Select()
            TB_ModeReq2.Text = "DB22"
        End If

    End Sub
    Private Sub WBToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBToolStripMenuItem27.Click

        Dim tb As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        target.Text = tb.Text

        If key Is Nothing Then
            key = New FrmKeyBoard
        End If

        If tb.Text = TB_ReqName1.Text Then
            TB_OTherRemak1.Enabled = True
            ' Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak1
            key.Show()
            target.Select()
            TB_ModeReq1.Text = "WB27"

        End If
        If tb.Text = TB_ReqName2.Text Then
            TB_OTherRemak2.Enabled = True
            ' Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak2
            key.Show()
            target.Select()
            TB_ModeReq2.Text = "WB27"
        End If
    End Sub

    Private Sub ADToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADToolStripMenuItem5.Click
        Dim tb As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        target.Text = tb.Text

        If key Is Nothing Then
            key = New FrmKeyBoard
        End If

        If tb.Text = TB_ReqName1.Text Then
            TB_OTherRemak1.Enabled = True
            'Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak1
            key.Show()
            target.Select()
            TB_ModeReq1.Text = "AD5"

        End If
        If tb.Text = TB_ReqName2.Text Then
            TB_OTherRemak2.Enabled = True
            'Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak2
            key.Show()
            target.Select()
            TB_ModeReq2.Text = "AD5"
        End If
    End Sub

    Private Sub MAToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MAToolStripMenuItem5.Click
        Dim tb As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        target.Text = tb.Text

        If key Is Nothing Then
            key = New FrmKeyBoard
        End If

        If tb.Text = TB_ReqName1.Text Then
            TB_OTherRemak1.Enabled = True
            'Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak1
            key.Show()
            target.Select()
            TB_ModeReq1.Text = "MA5"

        End If
        If tb.Text = TB_ReqName2.Text Then
            TB_OTherRemak2.Enabled = True
            'Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak2
            key.Show()
            target.Select()
            TB_ModeReq2.Text = "MA5"
        End If
    End Sub

    Private Sub OTToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OTToolStripMenuItem4.Click
        Dim tb As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        target.Text = tb.Text

        If key Is Nothing Then
            key = New FrmKeyBoard
        End If

        If tb.Text = TB_ReqName1.Text Then
            TB_OTherRemak1.Enabled = True
            'Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak1
            key.Show()
            target.Select()
            TB_ModeReq1.Text = "OT4"

        End If
        If tb.Text = TB_ReqName2.Text Then
            TB_OTherRemak2.Enabled = True
            'Dim key As FrmKeyBoard = New FrmKeyBoard
            key.TargetText = TB_OTherRemak2
            key.Show()
            target.Select()
            TB_ModeReq2.Text = "OT4"
        End If
    End Sub

    Dim ModeReq As String

    Private Sub CompareNameReqeust(ByVal NGModeReq As String)

        Select Case NGModeReq
            'DB NG Mode
            Case "Chip Kake (Chipping)"
                ModeReq = "DB1"

            Case "Chip Crack"
                ModeReq = "DB2"

            Case "Aluminium Scratch"
                ModeReq = "DB3"

            Case "Back Side Chipping"
                ModeReq = "DB4"

            Case "Stained Die (IBUTSU)"
                ModeReq = "DB5"

            Case "Die Twist"
                ModeReq = "DB6"

            Case "Die Drop Off"
                ModeReq = "DB7"

            Case "Die Misorientation"
                ModeReq = "DB8"

            Case "Die Misalignment (Chip Zure)"
                ModeReq = "DB9"

            Case "Chip Bad Mark"
                ModeReq = "DB10"

            Case "Preform Over Flow"
                ModeReq = "DB11"

            Case "Preform Thickness"
                ModeReq = "DB12"

            Case "Preform Spread"
                ModeReq = "DB13"

            Case "Preform Zure"
                ModeReq = "DB14"

            Case "Lead Frame Plating NG."
                ModeReq = "DB15"

            Case "Frame Bent"
                ModeReq = "DB16"

            Case "Inner Lead Bent"
                ModeReq = "DB17"

            Case "Pad Colour Change"
                ModeReq = "DB18"

            Case "Back Side Metal Bari"
                ModeReq = "DB19"

            Case "Missing Die ( Chip Off )"
                ModeReq = "DB20"

            Case "The Impacted Needle Smash Of Back Side Chip"
                ModeReq = "DB21"

                'Case ("22.OTHER")
                '    ModeReq = "DB22"


                'WB NG Mode
            Case "1st Open"
                ModeReq = "WB1"

            Case "2nd Open"
                ModeReq = "WB2"

            Case "2nd Cut"
                ModeReq = "WB3"

            Case "2nd  Zure"
                ModeReq = "WB4"

            Case "2nd Dagon"
                ModeReq = "WB5"

            Case "2nd Mekure"
                ModeReq = "WB6"

            Case "2nd Tail Width"
                ModeReq = "WB7"

            Case "Aluminum Spread"
                ModeReq = "WB8"

            Case "Ball Zure"
                ModeReq = "WB9"

            Case "Ball Hazure"
                ModeReq = "WB10"

            Case "Ball Off Center"
                ModeReq = "WB11"

            Case "Wire Pull Test NG"
                ModeReq = "WB12"

            Case "Ball Shear Test NG"
                ModeReq = "WB13"

            Case "Ball Thickness"
                ModeReq = "WB14"

            Case "Big Ball"
                ModeReq = "WB15"

            Case "Loop NG"
                ModeReq = "WB16"

            Case "Neck Cut"
                ModeReq = "WB17"

            Case "Neck Stress"
                ModeReq = "WB18"

            Case "Security Bonding , 2nd Bonding"
                ModeReq = "WB19"

            Case "Small Ball"
                ModeReq = "WB20"

            Case "V-Tsuki"
                ModeReq = "WB21"

            Case "WB Nashi"
                ModeReq = "WB22"

            Case "Wire Curl"
                ModeReq = "WB23"

            Case "Wire Scar"
                ModeReq = "WB24"

            Case "Wire Tare"
                ModeReq = "WB25"

            Case "Wire Touch"
                ModeReq = "WB26"

                'Case "27.OTHER"
                '    ModeReq = "WB27"


                'AUTOMOTIVE DEVICE NG Mode

            Case "DENSO DEVICE"
                ModeReq = "AD1"

            Case "H-RANK DEVICE"
                ModeReq = "AD2"

            Case "CLAIM COUNTERMEASURE"
                ModeReq = "AD3"

            Case "CHRONIC NG"
                ModeReq = "AD4"

                'Case "5.OTHER"
                '    ModeReq = "AD5"

                'MACHINE ABNORMAL NG Mode

            Case "BM"
                ModeReq = "MA1"

            Case "FEED BACK LOT"
                ModeReq = "MA2"

            Case "ALARM OVER STANDARDS"
                ModeReq = "MA3"

            Case "M/C STOP LONG TIME"
                ModeReq = "MA4"

                'Case "5.OTHER"
                '    ModeReq = "MA5"

                'OTHER
            Case "EVALUATION"
                ModeReq = "OT1"

            Case "NEW DEVICE/CS-LOT"
                ModeReq = "OT2"

            Case "CLAIM"
                ModeReq = "OT3"

                'Case "4.OTHER"
                '    ModeReq = "OT4"

        End Select
    End Sub

    Private Sub PBNGSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBNGSample.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PBNGSample.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub tbInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_PREFORMINS.Enter, TB_PREFORMINS.Click, TB_PREFORM.Enter, TB_PREFORM.Click, TB_PICKUP.Click, TB_PASTEINS.Enter, TB_PASTEINS.Click, TB_PADNIN.Enter, TB_PADNIN.Click, TB_NSOP.Enter, TB_NSOP.Click, TB_NSOL.Enter, TB_NSOL.Click, TB_LEADNIN.Enter, TB_LEADNIN.Click, TB_FRAMEOUT.Enter, TB_FRAMEOUT.Click, TB_BPM.Enter, TB_BPM.Click, TB_BONDER.Enter, TB_BONDER.Click, TB_AUCUTSHORT.Enter, TB_AUCUTSHORT.Click

        Dim tb As TextBox = CType(sender, TextBox)
        tb = CType(sender, TextBox)

        m_Numpad.TargetTextBox = tb
        If Not m_Numpad.Visible Then
            m_Numpad.Show(Me)
            m_Numpad.Left = Me.Right - 500
            m_Numpad.Top = Me.Bottom - 420
        End If
    End Sub



    Private Sub TB_OTherRemak1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_OTherRemak1.TextChanged
        If TB_OTherRemak1.Text <> "" Then
            TB_OTherRemak1.BackColor = Color.GreenYellow
        Else
            TB_OTherRemak1.BackColor = Color.White
        End If
    End Sub


    Private Sub TB_OTherRemak2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_OTherRemak2.TextChanged
        If TB_OTherRemak2.Text <> "" Then
            TB_OTherRemak2.BackColor = Color.GreenYellow
        Else
            TB_OTherRemak2.BackColor = Color.White
        End If
    End Sub

    Private Sub TB_PICKUP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_PICKUP.TextChanged
        If TB_PICKUP.Text = "" Then
            TB_PICKUP.BackColor = Color.Yellow
        Else
            TB_PICKUP.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_PREFORM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_PREFORM.TextChanged
        If TB_PREFORM.Text = "" Then
            TB_PREFORM.BackColor = Color.Yellow
        Else
            TB_PREFORM.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_FRAMEOUT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_FRAMEOUT.TextChanged
        If TB_FRAMEOUT.Text = "" Then
            TB_FRAMEOUT.BackColor = Color.Yellow
        Else
            TB_FRAMEOUT.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_BONDER_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_BONDER.TextChanged
        If TB_BONDER.Text = "" Then
            TB_BONDER.BackColor = Color.Yellow
        Else
            TB_BONDER.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_PASTEINS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_PASTEINS.TextChanged
        If TB_PASTEINS.Text = "" Then
            TB_PASTEINS.BackColor = Color.Yellow
        Else
            TB_PASTEINS.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_PREFORMINS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_PREFORMINS.TextChanged
        If TB_PREFORMINS.Text = "" Then
            TB_PREFORMINS.BackColor = Color.Yellow
        Else
            TB_PREFORMINS.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_AUCUTSHORT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_AUCUTSHORT.TextChanged
        If TB_AUCUTSHORT.Text = "" Then
            TB_AUCUTSHORT.BackColor = Color.Yellow
        Else
            TB_AUCUTSHORT.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_PADNIN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_PADNIN.TextChanged
        If TB_PADNIN.Text = "" Then
            TB_PADNIN.BackColor = Color.Yellow
        Else
            TB_PADNIN.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_LEADNIN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_LEADNIN.TextChanged
        If TB_LEADNIN.Text = "" Then
            TB_LEADNIN.BackColor = Color.Yellow
        Else
            TB_LEADNIN.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_BPM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_BPM.TextChanged
        If TB_BPM.Text = "" Then
            TB_BPM.BackColor = Color.Yellow
        Else
            TB_BPM.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_NSOP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_NSOP.TextChanged
        If TB_NSOP.Text = "" Then
            TB_NSOP.BackColor = Color.Yellow
        Else
            TB_NSOP.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub TB_NSOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_NSOL.TextChanged
        If TB_NSOL.Text = "" Then
            TB_NSOL.BackColor = Color.Yellow
        Else
            TB_NSOL.BackColor = Color.GreenYellow
        End If
    End Sub


    Private Sub btGLConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGLConfirm.Click
        Dim frm As New GLCheck
        frm.ShowDialog()
        Me.Show()
    End Sub



    Private Function CheckLotEdit(ByVal LotNolotEdit As String)
        Dim LotNoDBx As Boolean = False


        Dim InsWBTable As DBxDataSet.DBWBINSDataDataTable = DBWBINSDataTableAdapter.GetTableCheckLotEdit(LotNolotEdit)

        InsWBTable = DBWBINSDataTableAdapter.GetTableCheckLotEdit(LotNolotEdit)
        If InsWBTable.Rows.Count <> 0 Then
            For Each strData As DBxDataSet.DBWBINSDataRow In InsWBTable.Rows


                lbPackage.Text = strData.Package
                lb_LotNo.Text = strData.LotNo
                lbOpNo.Text = strData.OPNo
                tbMCNo.Text = strData.MCNo
                TB_Process.Text = strData.Process
                lb_Objectins.Text = strData.ObjectIns
                lbLotintime.Text = strData.ReqDate


                TB_ReqName1.Text = strData.RequestModeName1
                TB_ModeReq1.Text = strData.RequestMode1
                TB_OTherRemak1.Text = strData.RequestModeRemark1
                TB_ReqName2.Text = strData.RequestModeName2
                TB_ModeReq2.Text = strData.RequestMode2
                TB_OTherRemak2.Text = strData.RequestModeRemark2

                PBNGSample.Image = Nothing




                TB_ReqName1.Enabled = True
                TB_ReqName2.Enabled = True
                btOK.Enabled = True
                TB_ReqName1.BackColor = Color.Yellow
                TB_ModeReq1.BackColor = Color.Yellow
                'tbInput.BackColor = Color.WhiteSmoke
                TB_ReqName2.BackColor = Color.WhiteSmoke
                TB_ModeReq2.BackColor = Color.WhiteSmoke

                TB_PICKUP.Enabled = True
                TB_PREFORM.Enabled = True
                TB_FRAMEOUT.Enabled = True
                TB_BONDER.Enabled = True
                TB_PASTEINS.Enabled = True
                TB_PREFORMINS.Enabled = True
                TB_AUCUTSHORT.Enabled = True
                TB_PADNIN.Enabled = True
                TB_LEADNIN.Enabled = True
                TB_BPM.Enabled = True
                TB_NSOP.Enabled = True
                TB_NSOL.Enabled = True
                PBNGSample.Enabled = True


                If TB_Process.Text = "DB" Then
                    TB_PICKUP.BackColor = Color.Yellow
                    TB_PREFORM.BackColor = Color.Yellow
                    TB_FRAMEOUT.BackColor = Color.Yellow
                    TB_BONDER.BackColor = Color.Yellow
                    TB_PASTEINS.BackColor = Color.Yellow
                    TB_PREFORMINS.BackColor = Color.Yellow

                    TB_AUCUTSHORT.Text = "-"
                    TB_PADNIN.Text = "-"
                    TB_LEADNIN.Text = "-"
                    TB_BPM.Text = "-"
                    TB_NSOP.Text = "-"
                    TB_NSOL.Text = "-"

                    TB_AUCUTSHORT.Enabled = False
                    TB_PADNIN.Enabled = False
                    TB_LEADNIN.Enabled = False
                    TB_BPM.Enabled = False
                    TB_NSOP.Enabled = False
                    TB_NSOL.Enabled = False
                End If

                If TB_Process.Text = "WB" Then
                    TB_PICKUP.Text = "-"
                    TB_PREFORM.Text = "-"
                    TB_FRAMEOUT.Text = "-"
                    TB_BONDER.Text = "-"
                    TB_PASTEINS.Text = "-"
                    TB_PREFORMINS.Text = "-"

                    TB_PICKUP.Enabled = False
                    TB_PREFORM.Enabled = False
                    TB_FRAMEOUT.Enabled = False
                    TB_BONDER.Enabled = False
                    TB_PASTEINS.Enabled = False
                    TB_PREFORMINS.Enabled = False

                    TB_AUCUTSHORT.BackColor = Color.Yellow
                    TB_PADNIN.BackColor = Color.Yellow
                    TB_LEADNIN.BackColor = Color.Yellow
                    TB_BPM.BackColor = Color.Yellow
                    TB_NSOP.BackColor = Color.Yellow
                    TB_NSOL.BackColor = Color.Yellow

                End If



            Next


            'AddDataLotEdit()

            'มีข้อมูล
            LotNoDBx = True
        Else 'ไม่มีข้อมูล
            LotNoDBx = False
            MsgBox("ไม่มี LOTNO." & LotNolotEdit & "ในระบบ")
        End If

        Return LotNoDBx
    End Function

    Private Sub AddDataLotEdit()
        'Input Lot

        tbMCNo.Text = ""
        TB_Process.Text = ""
        lb_Objectins.Text = ""
        lbLotintime.Text = ""
        TB_ReqName1.Text = ""
        TB_ModeReq1.Text = ""
        TB_OTherRemak1.Text = ""
        TB_ReqName2.Text = ""
        TB_ModeReq2.Text = ""
        TB_OTherRemak2.Text = ""



        TB_PICKUP.Text = ""
        TB_PREFORM.Text = ""
        TB_FRAMEOUT.Text = ""
        TB_BONDER.Text = ""
        TB_PASTEINS.Text = ""
        TB_PREFORMINS.Text = ""
        TB_AUCUTSHORT.Text = ""
        TB_PADNIN.Text = ""
        TB_LEADNIN.Text = ""
        TB_BPM.Text = ""
        TB_NSOP.Text = ""
        TB_NSOL.Text = ""

        PBNGSample.Image = Nothing


    End Sub


    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        DBWBINSDataTableAdapter.FillWip(DBxDataSet.DBWBINSData)
    End Sub

    Private Sub BtCancelLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelLot.Click
        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                MsgBox("ไม่สามาถเชื่อมต่อ ไปที่ Server 172.16.0.102 ได้ ,ติดต่อ PM Check Network.")
                Exit Sub
            End If

        Else
            'LAN
            MsgBox("ไม่สามาถเชื่อมต่อ Networkได้ ,โปรดตรวจเช็คสาย LAN")
            Exit Sub

        End If

        'frmInputQR.Caption = "SCAN QR LOT CANCEL"
        'If frmInputQR.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Dim QR As String = frmInputQR.QRCode.ToUpper
        '    Dim LotNolotCancle As String = Trim(QR.Substring(30, 10))
        '    Dim Device As String = Trim(QR.Substring(10, 20))
        '    Dim ret As Boolean = False
        '    lbDevice.Text = Device

        If CheckLotCancle(Tb_LotNoCancelLot.Text) = False Then


            Exit Sub
        End If

        TabControl1.SelectTab(TabPage1)
        btOK.Hide()
        BtCancleLotConfirm.Show()
        NameINSTime.Show()
        NameEndTime.Show()
        NameRemark.Show()
        LbTimeInspec.Show()
        LbTimeEnd.Show()
        LbRemark.Show()
        LbTimeInspec.Text = ""
        LbTimeEnd.Text = ""
        LbRemark.Text = ""
        TB_ReqName2.Enabled = False
        TB_ReqName1.BackColor = Color.Gainsboro
        TB_ReqName2.BackColor = Color.Gainsboro
        TB_ModeReq1.BackColor = Color.Gainsboro
        TB_ModeReq2.BackColor = Color.Gainsboro

    End Sub
    Private Function CheckLotCancle(ByVal LotNolotCancle As String)
        Dim LotNoDBx As Boolean = False


        Dim InsDBWBTable As DBxDataSet.DBWBINSDataDataTable = DBWBINSDataTableAdapter.GetTableCancleLot(LotNolotCancle)

        InsDBWBTable = DBWBINSDataTableAdapter.GetTableCancleLot(LotNolotCancle)
        If InsDBWBTable.Rows.Count <> 0 Then
            For Each CancleLotData As DBxDataSet.DBWBINSDataRow In InsDBWBTable.Rows


                lbPackage.Text = CancleLotData.Package
                lb_LotNo.Text = CancleLotData.LotNo
                lbOpNo.Text = CancleLotData.OPNo
                tbMCNo.Text = CancleLotData.MCNo
                TB_Process.Text = CancleLotData.Process
                lb_Objectins.Text = CancleLotData.ObjectIns
                lbLotintime.Text = CancleLotData.ReqDate


                TB_ReqName1.Text = CancleLotData.RequestModeName1
                TB_ModeReq1.Text = CancleLotData.RequestMode1
                TB_OTherRemak1.Text = CancleLotData.RequestModeRemark1
                TB_ReqName2.Text = CancleLotData.RequestModeName2
                TB_ModeReq2.Text = CancleLotData.RequestMode2
                TB_OTherRemak2.Text = CancleLotData.RequestModeRemark2

                Tb_Remark.Text = CancleLotData.Remark


                PBNGSample.Image = Nothing



            Next

            LotNoDBx = True
        Else 'ไม่มีข้อมูล
            LotNoDBx = False
            MsgBox("ไม่มี LOTNO." & LotNolotCancle & "ในระบบ")

        End If

        Return LotNoDBx

    End Function

    Private Sub BtCancleLotConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancleLotConfirm.Click
        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                MsgBox("ไม่สามาถเชื่อมต่อ ไปที่ Server 172.16.0.102 ได้ ,ติดต่อ PM Check Network.")
                Exit Sub
            End If

        Else
            'LAN
            MsgBox("ไม่สามาถเชื่อมต่อ Networkได้ ,โปรดตรวจเช็คสาย LAN")
            Exit Sub

        End If
        Dim glno As String
        Dim frmQR As frmInputQR = New frmInputQR
        frmQR.Caption = "SCAN GL No."
        If frmQR.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        glno = frmQR.QRGLNo

        LbTimeInspec.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        LbTimeEnd.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        LbRemark.Text = "CANCEL LOT"


        Dim LotNoDBx As Boolean = False
        Dim InsDBWBTable As DBxDataSet.DBWBINSDataDataTable = DBWBINSDataTableAdapter.GetTableCancleLot(lb_LotNo.Text)

        InsDBWBTable = DBWBINSDataTableAdapter.GetTableCancleLot(lb_LotNo.Text)
        If InsDBWBTable.Rows.Count <> 0 Then
            For Each CancleLotData As DBxDataSet.DBWBINSDataRow In InsDBWBTable.Rows
                If CancleLotData.IsStartTimeNull Then
                    CancleLotData.StartTime = LbTimeInspec.Text
                End If
                CancleLotData.EndTime = LbTimeEnd.Text
                CancleLotData.Remark = LbRemark.Text
                CancleLotData.GLCheck = glno
            Next


            DBWBINSDataTableAdapter.Update(InsDBWBTable)
            CountListData()
            BtCancleLotConfirm.Hide()

            '    For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
            '        If row.LotNo = lb_LotNo.Text AndAlso row.StartTime = lbLotintime.Text Then
            '            ClearAll()
            '            FindDataLot(lb_LotNo.Text)
            '        End If
            '    Next
            'End If

            LotNoDBx = True
        Else 'ไม่มีข้อมูล
            LotNoDBx = False
        End If

        'Return LotNoDBx

    End Sub


    Private Sub lbCountUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCountUpdate.Click
        CountListData()
    End Sub




    Private Sub Tb_LotNoCancelLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tb_LotNoCancelLot.Click
        Dim tb As TextBox
        Dim key As FrmKeyBoard = New FrmKeyBoard
        tb = CType(sender, TextBox)
        key.TargetText = tb
        key.Show()
    End Sub

    Private Sub Tb_Remark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tb_Remark.Click
        Dim tb As TextBox
        Dim key As FrmKeyBoard = New FrmKeyBoard

        If key Is Nothing Then
            key = New FrmKeyBoard
        End If

        tb = CType(sender, TextBox)
        key.TargetText = tb
        key.Show()
    End Sub



    Private Sub BtSaveCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSaveCSV.Click
        If My.Computer.Network.IsAvailable Then
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                'Network
                MsgBox("ไม่สามาถเชื่อมต่อ ไปที่ Server 172.16.0.102 ได้ ,ติดต่อ PM Check Network.")
                Exit Sub
            End If

        Else
            'LAN
            MsgBox("ไม่สามาถเชื่อมต่อ Networkได้ ,โปรดตรวจเช็คสาย LAN")
            Exit Sub

        End If


        LB_CheckWip.Items.Clear()

        Dim timenew As String = Format(Now, "yyyyMMdd HHmmss")
        Dim DataToCSV As String = ""
        DataToCSV &= ("LotNo" & "," & "Package" & "," & "ReqDate" & "," & "RequestMode1" & "," & "RequestModeName1" & "," & "RequestMode2" & "," & "RequestModeName2" _
                       & "," & "MCNo" & "," & "ObjectIns" & "," & "OPNo" & "," & "Process") & vbCrLf
        Dim CountWip As Integer = 0

        DBWBINSDataTableAdapter.Fill(DBxDataSet.DBWBINSData)
        For Each row As DBxDataSet.DBWBINSDataRow In DBxDataSet.DBWBINSData
            Try


                If row.LotNo <> "" AndAlso row.IsEndTimeNull = True Then

                    LB_CheckWip.Items.Add(row.LotNo & "," & row.Package & "," & row.ReqDate & ", Request 1 : " & row.RequestModeName1 & ",  Request 2 : " & row.RequestModeName2)

                    DataToCSV &= (row.LotNo & "," & row.Package & "," & row.ReqDate & "," & row.RequestMode1 & "," & row.RequestModeName1 & "," & row.RequestMode2 & "," & row.RequestModeName2 _
                                  & "," & row.MCNo & "," & row.ObjectIns & "," & row.OPNo & "," & row.Process) & vbCrLf
                    CountWip += 1

                End If



            Catch ex As Exception

            End Try
        Next


        WritetoCSV("C:\Wip Inspection DB WB\" & "WIP " & timenew & ".CSV", DataToCSV)

        LB_CheckWipToCSV.Text = CountWip
        MsgBox("Save ไฟล์ C:\Wip Inspection DB WB\" & "WIP " & timenew & ".CSV เรียบร้อย")
    End Sub
End Class

