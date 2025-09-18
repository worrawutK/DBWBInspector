Imports System.IO
Public Class Form1
    Dim LotAlarmQtyTbl As DBxDataSet.LotAlarmQtyDataTable
    Dim LotAlarmQtyTblQuery As New DBxDataSetTableAdapters.LotAlarmQtyTableAdapter
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.WindowState = FormWindowState.Maximized
        ' DateTimePicker1.Value = Now
        lbProcessTitle.Text = "PROCESS : DB&WB INSPECTOR"
        DateTimePicker1.Value = Now
        '   loadDate(True)
        SearchLotNo.Focus()
        'lbVersion.Text = My.Settings.Version
        '   lbProcessTitle.Text = "Width:" & ViewData.Width & "-Hight:" & ViewData.Height & ">>" & "Width:" & PanelNG.Width & "-Hight:" & PanelNG.Height
        Dim data = GetProcessList()
        ComboBoxProcessName.Items.Clear()
        For Each processName As String In data
            ComboBoxProcessName.Items.Add(processName)
        Next



    End Sub
    Private Function GetProcessList() As List(Of String)
        Dim processList As List(Of String) = New List(Of String)
        Dim data As DataTable = New DataTable()
        Using cmd As New SqlClient.SqlCommand()
            cmd.Connection = New SqlClient.SqlConnection("Server=172.16.0.110;Database=DBx;User Id=system;Password=p@$$w0rd")
            cmd.CommandText = "SELECT distinct Process FROM [DBx].[INS].[DBWBINSData] order by Process"
            cmd.Connection.Open()
            Dim reader = cmd.ExecuteReader()
            data.Load(reader)
            cmd.Connection.Close()
        End Using
        For Each rowData As DataRow In data.Rows
            If rowData("Process") IsNot Nothing Then
                processList.Add(rowData("Process").ToString)
            End If

        Next
        Return processList
    End Function
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

    Private Sub BMRequestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub AndonToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AndonToolStripMenuItem.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/andontmn", AppWinStyle.NormalFocus) 'Web andon for manual M/C
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Public DIR_LOG As String = My.Application.Info.DirectoryPath & "\LOG"
    Public Sub SaveCatchLog(ByVal message As String, ByVal fnName As String)
        Using sw As StreamWriter = New StreamWriter(Path.Combine(DIR_LOG, "Catch_" & Now.ToString("yyyyMMdd") & ".log"), True)
            sw.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & fnName & ">" & message)
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        readData()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SearchLotNo.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If SearchLotNo.Text.Length >= 252 Then
                SearchLotNo.Text = SearchLotNo.Text.Substring(30, 10).Trim
                readData()
            Else
                readData()
            End If

        End If

    End Sub
    Private Sub Clear()
        '    DataGridView1.ClearSelection()
        lbDevice.Text = Nothing
        lbMCNo.Text = Nothing
        lbStartTime.Text = Nothing
        lbEndTime.Text = Nothing
        lbPackage.Text = Nothing
        lbinspectorID.Text = Nothing
        lbProcess.Text = Nothing
        lbLotNo.Text = Nothing
        lbTotal.Text = Nothing
        lbNG.Text = Nothing
        lbGood.Text = Nothing
        lbFinYld.Text = Nothing
        lbObjInsp.Text = Nothing
        btQR.Text = Nothing
        lbRUN.Text = Nothing
        rbtLotJudgeNG.Checked = False
        rbtLotJudgeOK.Checked = False
        PictureBox1.BackgroundImage = Nothing
        PictureBox2.BackgroundImage = Nothing
        lbWb01.Text = Nothing
        lbWb02.Text = Nothing
        lbWb04.Text = Nothing
        lbWb17.Text = Nothing
        lbWb18.Text = Nothing
        lbWb19.Text = Nothing
        lbWb99.Text = Nothing
        lbDB01.Text = Nothing
        lbDb04.Text = Nothing
        lbDb06.Text = Nothing
        lbDb07.Text = Nothing
        lbDb14.Text = Nothing
        lbDb16.Text = Nothing
        lbDB99.Text = Nothing
        lbReq1.Text = Nothing
        lbReq2.Text = Nothing

    End Sub
    Private Sub readData()
        Try
            Clear()
            If SearchLotNo.Text = Nothing Then
                MsgBox("กรุณาใส่ Lot No.")
                SearchLotNo.Text = ""
                SearchLotNo.Focus()
                Exit Sub
            End If
            Dim process As String = ComboBoxProcessName.Text
            'If RadioDB.Checked Then
            '    process = RadioDB.Text
            'Else
            '    '  RadioWB.Checked
            '    process = RadioWB.Text
            'End If

            'If DBxDataSet1.InspectionDetail.Rows.Count < 1 Then
            '    MsgBox("ไม่ได้ INS ใน Process นี้")
            '    '   Exit Sub
            'End If
            Dim insp_Endtime As Date = Nothing
            DbwbinsData1TableAdapter1.Fill(DBxDataSet1.DBWBINSData1, SearchLotNo.Text, process)
            For Each Data As DBxDataSet.DBWBINSData1Row In DBxDataSet1.DBWBINSData1
                If Data.IsStartTimeNull Or Data.IsEndTimeNull Then
                    MsgBox("ยังไม่จบ Lot")
                    SearchLotNo.Text = ""
                    SearchLotNo.Focus()
                    Exit Sub
                End If
                'If Data.Remark = "CANCEL LOT" OrElse Data.Remark = "RE-INPUT" Then
                '    Exit For
                'End If
                insp_Endtime = Data.EndTime
                If Data.IsStartTimeNull = True Then
                    lbStartTime.Text = "-"
                Else
                    lbStartTime.Text = Data.StartTime
                End If
                If Data.IsEndTimeNull = True Then
                    lbEndTime.Text = "-"
                Else
                    lbEndTime.Text = Data.EndTime.ToString.Trim
                End If
                If Data.IsEndTimeNull = True Then
                    lbEndTime.Text = "-"
                Else
                    lbEndTime.Text = Data.EndTime.ToString.Trim
                End If
                If Data.IsInspectorNoNull = True Then
                    lbinspectorID.Text = "-"
                Else
                    lbinspectorID.Text = Data.InspectorNo 'Data.OPNo
                End If
                lbPackage.Text = Data.Package

                lbProcess.Text = Data.Process
                lbLotNo.Text = Data.LotNo
                If Data.IsDeviceNull = False Then
                    lbDevice.Text = Data.Device
                Else
                    ' lbDevice.Text = "No data TransactionData"
                End If

                If Data.IsMCNoNull = False Then
                    lbMCNo.Text = Data.MCNo
                End If

                If Data.IsRemarkNull = False Then
                    lbRemark.Text = "Remark : " & Data.Remark
                End If
                If Data.IsGLCheckNull = False Then
                    LabelGL.Text = "GL : " & Data.GLCheck
                End If

                If Data.IsJudgeReasonNull = False Then
                    tbJudgeReason.Text = Data.JudgeReason
                End If

                If Data.IsTotalQtyNull = True Then
                    lbTotal.Text = "-"
                Else
                    lbTotal.Text = "3024" ' Data.TotalQty
                End If
                If Data.IsNGQtyNull = True Then
                    lbNG.Text = "-"
                Else
                    lbNG.Text = Data.NGQty
                End If
                If Data.IsGoodQtyNull = True Then
                    lbGood.Text = "-"
                Else
                    lbGood.Text = "3024" 'Data.GoodQty
                End If
                If Data.IsFinalYieldNull = True Then
                    lbFinYld.Text = "-"
                Else
                    lbFinYld.Text = Data.FinalYield
                End If
                If Data.IsObjectInsNull = True Then
                    lbObjInsp.Text = "-"
                Else
                    lbObjInsp.Text = Data.ObjectIns
                End If
                If Data.IsGLCheckNull = True Then
                    btQR.Text = "_"
                Else
                    btQR.Text = Data.GLCheck
                End If

                If Data.IsLotJudgNull = True Then

                Else
                    If Data.LotJudg = "NG" Then
                        rbtLotJudgeNG.Checked = True
                        rbtLotJudgeOK.Checked = False
                    Else
                        rbtLotJudgeNG.Checked = False
                        rbtLotJudgeOK.Checked = True
                    End If
                End If

                Dim start As TimeSpan
                start = CDate(lbEndTime.Text) - CDate(lbStartTime.Text)
                lbRUN.Text = start.ToString 'Data.TotalTime & " นาที"
                If File.Exists("\\172.16.0.115\MachineData\DB\Inspector\" & lbProcess.Text & "\" & lbLotNo.Text & "_NG Sample.JPG") Then
                    PictureBox1.BackgroundImage = Image.FromFile("\\172.16.0.115\MachineData\DB\Inspector\" & lbProcess.Text & "\" & lbLotNo.Text & "_NG Sample.JPG")
                End If
                If File.Exists("\\172.16.0.115\MachineData\DB\Inspector\" & lbProcess.Text & "\" & lbLotNo.Text & "_SHOKONOKOSHI.JPG") Then
                    PictureBox2.BackgroundImage = Image.FromFile("\\172.16.0.115\MachineData\DB\Inspector\" & lbProcess.Text & "\" & lbLotNo.Text & "_SHOKONOKOSHI.JPG")
                End If

                If Not Data.IsRequestModeName1Null Then                                     'Set initail item Inspection_Detail
                    If Data.RequestModeName1 <> "" Then
                        lbReq1.Text = "1. " & Data.RequestModeName1
                        'DBxDataSet.Inspection_Detail.Rows.Add(DR.RequestModeName1)        'Add to inspection table
                        'DBxDataSet.Inspection_Detail.Rows(DR.RequestModeName1).Item("ModeNo") = DR.RequestMode1
                    End If

                End If
                If Not Data.IsRequestModeName2Null Then
                    If Data.RequestModeName2 <> "" Then
                        lbReq2.Text = "2. " & Data.RequestModeName2
                        'DBxDataSet.Inspection_Detail.Rows.Add(DR.RequestModeName2)          'Add to inspection table
                        'DBxDataSet.Inspection_Detail.Rows(DR.RequestModeName2).Item("ModeNo") = DR.RequestMode2
                    End If
                End If

            Next
            If insp_Endtime = Nothing Then
                Exit Sub
            End If
            InspectionDetailTableAdapter1.Fill(DBxDataSet1.InspectionDetail, SearchLotNo.Text, process, insp_Endtime)
            LotAlarmQtyTbl = New DBxDataSet.LotAlarmQtyDataTable
            'Dim AlDr As DBxDataSet.LotAlarmQtyRow
            'AlDr = LotAlarmQtyTbl.NewRow
            If LotAlarmQtyTblQuery.Fill(LotAlarmQtyTbl, SearchLotNo.Text) <> 0 Then ' Alarm Qty data from record
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
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Clear()
        End Try
        SetViewTotal()
        SearchLotNo.Text = ""
        SearchLotNo.Focus()

    End Sub

    Private Sub BtExit2_Click(sender As Object, e As EventArgs) Handles BtExit2.Click
        Me.Close()
    End Sub

    Private Sub MinimizeButton_Click(sender As Object, e As EventArgs) Handles MinimizeButton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Dim startTime As Date

    Dim endDay As Date

    Dim endNight As Date

    Private Sub loadDate() 'ByVal load As Boolean
        '  DateTimePicker1.Value = DateTimePicker1.MinDate

        Dim startTime1 As Date = DateTimePicker1.Value
        startTime = CDate(startTime1.ToShortDateString).AddHours(8)
        '  endDay = startTime.AddHours(12)
        endDay = CDate(startTime1.ToShortDateString).AddHours(20)

        endNight = CDate(startTime1.ToShortDateString).AddHours(32)
        Dim tableWIP As DataTable

        tableWIP = New DataTable


        '   tableWIP.Columns.Add("Number")
        tableWIP.Columns.Add("Package")
        tableWIP.Columns.Add("In_Day")
        tableWIP.Columns.Add("Out_Day")
        tableWIP.Columns.Add("WIP_Day")

        tableWIP.Columns.Add("In_Night")
        tableWIP.Columns.Add("Out_Night")

        tableWIP.Columns.Add("Total_In")
        tableWIP.Columns.Add("Total_Out")
        tableWIP.Columns.Add("WIP_Night")
        Dim Process As String
        '    WipinsTableAdapter1.Fill(DBxDataSet1.WIPINS, startTime, endDay, endNight)


        ' SumwipTableAdapter1.Fill(DBxDataSet1.SUMWIP, startTime, endDay, endNight)

        '   SumwipTableAdapter1.FillTotalINOUT(DBxDataSet1.SUMWIP, startTime, endDay, endNight)
        'If all = True Then
        '    WiplotTableAdapter1.FillAll(DBxDataSet1.WIPLOT, endNight)
        'Else

        'End If
        If DBpkgwip.Checked Then
            Process = "DB" 'DBpkgwip.Text
            '  WipinsTableAdapter1.FillProcess(DBxDataSet1.WIPINS, startTime, endDay, endNight, Process)
            WipinsToatalTableAdapter1.FillProcess(DBxDataSet1.WIPINSToatal, startTime, endDay, endNight, Process)
            'SumwipTableAdapter1.FillProcess(DBxDataSet1.SUMWIP, startTime, endDay, endNight, Process)
            SumwipTotalTableAdapter1.FillProcess(DBxDataSet1.SUMWIPTotal, startTime, endDay, endNight, Process)
        ElseIf WBpkgwip.Checked Then
            Process = "WB" 'WBpkgwip.Text
            '  WipinsTableAdapter1.FillProcess(DBxDataSet1.WIPINS, startTime, endDay, endNight, Process)
            WipinsToatalTableAdapter1.FillProcess(DBxDataSet1.WIPINSToatal, startTime, endDay, endNight, Process)
            '     SumwipTableAdapter1.FillProcess(DBxDataSet1.SUMWIP, startTime, endDay, endNight, Process)
            SumwipTotalTableAdapter1.FillProcess(DBxDataSet1.SUMWIPTotal, startTime, endDay, endNight, Process)
        ElseIf Allpkgwip.Checked Then
            '    Process = RadioButton3.Text
            WipinsToatalTableAdapter1.Fill(DBxDataSet1.WIPINSToatal, startTime, endDay, endNight)
            SumwipTotalTableAdapter1.Fill(DBxDataSet1.SUMWIPTotal, startTime, endDay, endNight)
        End If
        Dim number As Integer

        '     WipinsTableAdapter1.Fill(DBxDataSet1.WIPINS, startTime, endDay, endNight, Process)
        ' WipinsTableAdapter1.Fill(DBxDataSet1.WIPINS, startTime, endDay, endNight)
        '   WipinsTableAdapter1.Fill(DBxDataSet1.WIPINS, "2016-10-26 08:00:00", "2016-10-26 20:00:00", "2016-10-27 08:00:00")
        For Each data As DBxDataSet.WIPINSToatalRow In DBxDataSet1.WIPINSToatal
            number += 1
            Dim rowWIP As DataRow = tableWIP.NewRow
            If data.Package = "SUM" Then
                ' rowWIP("Number") = Nothing
                rowWIP("Package") = "SUM"
            Else
                '  rowWIP("Number") = number
                rowWIP("Package") = data.Package
            End If

            If data.IsCountDayNull = False Then
                rowWIP("In_Day") = data.CountDay
            Else
                rowWIP("In_Day") = ""
            End If

            If data.IsCountDayOutNull = False Then
                rowWIP("Out_Day") = data.CountDayOut
            Else
                rowWIP("Out_Day") = ""
            End If


            If data.IsCountNightNull = False Then
                rowWIP("In_Night") = data.CountNight
            Else
                rowWIP("In_Night") = ""
            End If
            If data.IsCountNightOutNull = False Then
                rowWIP("Out_Night") = data.CountNightOut
            Else
                rowWIP("Out_Night") = ""
            End If


            If data.IsWIPNull = False Then
                If data.WIP = 0 Or Now < startTime Then
                    rowWIP("WIP_Day") = ""
                Else
                    rowWIP("WIP_Day") = data.WIP
                End If
            Else
                rowWIP("WIP_Day") = ""
            End If

            If data.IsWIPNightNull = False Then
                If data.WIPNight = 0 Or Now < endDay Then
                    rowWIP("WIP_Night") = ""
                Else
                    rowWIP("WIP_Night") = data.WIPNight
                End If

            Else
                rowWIP("WIP_Night") = ""
            End If
            If data.TotalLotIN = "0" Then
                rowWIP("Total_In") = ""
            Else
                rowWIP("Total_In") = data.TotalLotIN
            End If
            If data.TotalLotOut = "0" Then
                rowWIP("Total_Out") = ""
            Else
                rowWIP("Total_Out") = data.TotalLotOut
            End If


            If rowWIP("In_Day") = "" AndAlso rowWIP("Out_Day") = "" AndAlso rowWIP("In_Night") = "" AndAlso rowWIP("Out_Night") = "" AndAlso rowWIP("WIP_Day") = "" AndAlso rowWIP("WIP_Night") = "" Then

            Else
                tableWIP.Rows.Add(rowWIP)
            End If





        Next

        dgWIP.DataSource = tableWIP
        '  Dim NewRoww As DBxDataSet.SUMWIPTotalRow = DBxDataSet1.SUMWIPTotal.NewSUMWIPTotalRow
        '  DBxDataSet1.SUMWIPTotal.Rows.Add(NewRoww)


        dgSumWip.DataSource = DBxDataSet1.SUMWIPTotal
        '   If load = True Then
        '   DataGridView2.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        '    DataGridView2.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        '  DataGridView2.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        '  DataGridView2.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        '  DataGridView2.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        '  DataGridView2.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        '  DataGridView2.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        'dataGridView1.Columns[0].HeaderText = "VeryLong " + "LongLong" + Environment.NewLine + "LongLongLong";
        ' dgWIP.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '  dgWIP.Columns(1).HeaderText = "T1" + Environment.NewLine + "T2"
        'dgWIP.Columns(2).Width = 30
        'dgWIP.Columns(3).Width = 50
        'dgWIP.Columns(4).Width = 50
        'dgWIP.Columns(5).Width = 50
        'dgWIP.Columns(6).Width = 50
        'dgWIP.Columns(7).Width = 50
        'dgWIP.Columns(8).Width = 50
        'DataGridView3.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DataGridView3.Columns(1).Width = 50
        'DataGridView3.Columns(2).Width = 50
        'DataGridView3.Columns(3).Width = 50
        'DataGridView3.Columns(4).Width = 50
        'DataGridView3.Columns(5).Width = 50
        'DataGridView3.Columns(6).Width = 50
        'DataGridView3.Columns(7).Width = 50
        'DataGridView3.Columns(8).Width = 50

        'DataGridView2.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        'DataGridView2.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        'DataGridView2.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


        ' End If


    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlApp = New Microsoft.Office.Interop.Excel.Application 'Microsoft.Office.Interop.Excel.ApplicationClass
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            Dim aaa As Stopwatch = New Stopwatch
            aaa.Start()
            '  Dim ass As Integer
            '   Dim timeS As Date = Date.Now
            '    Dim timeE As Date
            Dim TickHeader As Boolean = True
            Dim TickSUM As Boolean = False
            For i = 0 To dgWIP.RowCount - 1
                'If i = DataGridView2.RowCount - 1 Then 'sum
                '    For k = 0 To DataGridView3.ColumnCount - 1

                '        xlWorkSheet.Cells(i + 2, k + 1) = DataGridView3(k, 0).Value.ToString()

                '    Next
                'Else
                For j = 0 To dgWIP.ColumnCount - 1
                    If TickHeader = True Then
                        'For k As Integer = 1 To DataGridView2.Columns.Count
                        '    xlWorkSheet.Cells(1, k) = DataGridView2.Columns(k - 1).HeaderText
                        'Next
                        'TickHeader = False
                        ' For k As Integer = 1 To DataGridView2.Columns.Count
                        xlWorkSheet.Cells(1, j + 1) = dgWIP.Columns(j).HeaderText
                        '   Next

                    End If

                    'For k As Integer = 1 To DataGridView2.Columns.Count
                    '  xlWorkSheet.Cells(1, k) = DataGridView2.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j + 1) = dgWIP(j, i).Value.ToString()

                    ' Next
                Next
                ' End If

                TickHeader = False
            Next

            aaa.Stop()

            Debug.Print(aaa.Elapsed.ToString)


            Dim savefile As New SaveFileDialog
            ' Dim resp As MsgBoxResult
            Dim fileName As String = "WIP"
            '  resp = MessageBox.Show("ส่งออก เอ้ก", "ส่งเอกสาร", MessageBoxButtons.YesNo)
            '   If resp = MsgBoxResult.Yes Then
            savefile.Filter = "Excel file |*.xlsx"
            savefile.Title = "save an Excel File"
            savefile.FileName = "WIP PLAN"
            ' If savefile.FileName <> "" Then

            ' End If
            If savefile.ShowDialog() = DialogResult.OK Then

                fileName = savefile.FileName
                Try
                    xlWorkSheet.DisplayAlerts = False
                Catch ex As Exception

                End Try

                xlWorkSheet.SaveAs(fileName)
                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)
            End If

            ' End If


            '  MsgBox("You can find the file D:\vbexcel.xlsx")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            ' MsgBox("กรุณาติดตั้ง Microsoft excel")
        End Try

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgWIP.CellClick
        If e.RowIndex <> "-1" Then
            Dim value As String = dgWIP.Rows(e.RowIndex).Cells(0).Value
            CellClick(value)
        End If

    End Sub
    Private Sub CellClick(ByVal value As String)
        Try
            Dim sumDay As Integer
            Dim sumNight As Integer


            Dim TB_WIPLOT As DataTable = New DataTable
            TB_WIPLOT.Columns.Add("Package")
            TB_WIPLOT.Columns.Add("Device")
            TB_WIPLOT.Columns.Add("LotNo")
            TB_WIPLOT.Columns.Add("RequestMode1")
            TB_WIPLOT.Columns.Add("RequestMode2")
            TB_WIPLOT.Columns.Add("Day")
            TB_WIPLOT.Columns.Add("Night")
            TB_WIPLOT.Columns.Add("Status")


            Dim TB_WIPLOT_SUM As DataTable = New DataTable
            TB_WIPLOT_SUM.Columns.Add("TOTAL WIP")


            TB_WIPLOT_SUM.Columns.Add("DAY")
            TB_WIPLOT_SUM.Columns.Add("Night")
            TB_WIPLOT_SUM.Columns.Add("TOTAL")
            ' TB_WIPLOT_SUM.Columns.Add("column")
            '  TB_WIPLOT_SUM.Columns.Add("Request Mode1")
            '   TB_WIPLOT_SUM.Columns.Add("Request Mode2")



            If ProcessLot = True Then
                If WBlotwip.Checked Then
                    WiplotTableAdapter1.FillProcess(DBxDataSet1.WIPLOT, endNight, WBlotwip.Text)
                ElseIf DBlotwip.Checked Then
                    WiplotTableAdapter1.FillProcess(DBxDataSet1.WIPLOT, endNight, DBlotwip.Text)
                ElseIf Alllotwip.Checked Then
                    WiplotTableAdapter1.FillAll(DBxDataSet1.WIPLOT, endNight)
                End If

                'ElseIf all
            Else
                If DBpkgwip.Checked Then
                    WiplotTableAdapter1.FillPKGProcess(DBxDataSet1.WIPLOT, endNight, value, DBpkgwip.Text)
                ElseIf WBpkgwip.Checked Then
                    WiplotTableAdapter1.FillPKGProcess(DBxDataSet1.WIPLOT, endNight, value, WBpkgwip.Text)
                Else
                    WiplotTableAdapter1.Fill(DBxDataSet1.WIPLOT, endNight, value)
                End If
            End If





            For Each Data As DBxDataSet.WIPLOTRow In DBxDataSet1.WIPLOT
                Dim Rows As DataRow = TB_WIPLOT.NewRow
                Rows("Package") = Data.Package
                Rows("Device") = Data.Device
                Rows("LotNo") = Data.LotNo
                Rows("RequestMode1") = Data.RequestModeName1
                Rows("RequestMode2") = Data.RequestModeName2
                Rows("Status") = Data.Status
                Dim timee As TimeSpan = New TimeSpan(0, 20, 0, 0, 0)
                Dim dateQry As String = (Data.ReqDate.Year & "/" & Data.ReqDate.Month & "/" & Data.ReqDate.Day & " ")
                ' dateQry = dateQry & "08:00:00"
                Dim DayIN As Date = dateQry & "08:00:00"
                Dim DayOut As Date = dateQry & "20:00:00"
                DayIN.AddDays(Data.ReqDate.Day)
                DayIN.AddHours(Data.ReqDate.Hour)

                If Data.ReqDate > DayIN And Data.ReqDate < DayOut Then
                    sumDay += 1
                    Rows("Day") = Data.ReqDate.ToString("MMMM/dd HH:mm") 'DateTime.ParseExact(theTime, "HHmm", Nothing).ToString("MMMM/dd hh:mm") '.TimeOfDay
                    Rows("Night") = ""
                Else
                    sumNight += 1
                    Rows("Day") = ""
                    Rows("Night") = Data.ReqDate.ToString("MMMM/dd HH:mm") '.TimeOfDay
                End If

                TB_WIPLOT.Rows.Add(Rows)
                '   Rows("Request Mode1")=Data.
            Next
            DataGridView4.DataSource = TB_WIPLOT 'DBxDataSet1.WIPLOT
            ' DataGridView4.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'DataGridView4.Columns(0).Width = 100
            '' DataGridView4.Columns(1).Width = 100
            'DataGridView4.Columns(2).Width = 100
            'DataGridView4.Columns(3).Width = 100
            'DataGridView4.Columns(4).Width = 100
            'DataGridView4.Columns(5).Width = 90
            'DataGridView4.Columns(6).Width = 90
            'DataGridView4.Columns(7).Width = 80



            Dim Rows_SUM As DataRow = TB_WIPLOT_SUM.NewRow
            Rows_SUM("TOTAL WIP") = "TOTAL WIP"
            Rows_SUM("Day") = sumDay & "(Day)"
            Rows_SUM("Night") = sumNight & "(Night)"
            Rows_SUM("TOTAL") = sumDay + sumNight & "(Total)"
            '   Rows_SUM("column") = ""
            TB_WIPLOT_SUM.Rows.Add(Rows_SUM)
            '  Rows_SUM("Request Mode1") = "-"
            'Rows_SUM("Request Mode2") = "-"


            DataGridView5.DataSource = TB_WIPLOT_SUM 'DBxDataSet1.WIPLOT

            DataGridView5.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    DataGridView5.Columns(0).Width = 125
            'DataGridView5.Columns(1).Width = 200
            'DataGridView5.Columns(2).Width = 200
            'DataGridView5.Columns(3).Width = 200
            ' DataGridView5.Columns(4).Width = 80

            ' DataGridView4.Columns(6).Width = 125
            'If IsDBNull(value) Then
            '    Button1.Text = "" ' blank if dbnull values
            'Else
            '    Button1.Text = CType(value, String)
            'End If
            'WippkgTableAdapter1.Fill(DataSet11.WIPPKG, value)
            'DataGridView2.DataSource = DataSet11.WIPPKG
            '   DataGridView2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loadDate()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles Allpkgwip.CheckedChanged, WBpkgwip.CheckedChanged, DBpkgwip.CheckedChanged
        loadDate()
    End Sub
    Dim ProcessLot As Boolean = False
    Private Sub RadioButton6_Click(sender As Object, e As EventArgs) Handles DBlotwip.Click, WBlotwip.Click, Alllotwip.Click
        ProcessLot = True

        CellClick(ProcessLot)

        ProcessLot = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim bmp As Bitmap = New Bitmap(Me.TabControl1.Width, Me.TabControl1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.CopyFromScreen(Me.TabControl1.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(Me.TabControl1.Width, Me.TabControl1.Height))

        End Using
        '  bmp.Save("tesgt.jpg")

        Dim savefiledialog1 As New SaveFileDialog
        Try
            savefiledialog1.Title = "Save File"
            savefiledialog1.FileName = Now.ToString("yyyy-MM-dd") & "_"
            savefiledialog1.Filter = "JPEG |*.jpg " '| Bitmap |*.bmp
            '   savefiledialog1.Filter = "j |*.jpg"

            If savefiledialog1.ShowDialog() = DialogResult.OK Then
                ' PictureBox1.Image.Save(savefiledialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
                bmp.Save(savefiledialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        'Dim bmp As Bitmap = New Bitmap(Me.Width, Me.Height) ''fullscreen
        'Using g As Graphics = Graphics.FromImage(bmp)
        '    g.CopyFromScreen(Me.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(Me.Width, Me.Height))

        'End Using
        'bmp.Save("tesgt.jpg")
    End Sub
    Private Sub SetViewTotal()
        Dim M1 As Integer = 0
        Dim M2 As Integer = 0
        Dim M3 As Integer = 0
        Dim M4 As Integer = 0
        Dim M5 As Integer = 0
        Dim M6 As Integer = 0
        Dim M7 As Integer = 0
        Dim M8 As Integer = 0
        Dim M9 As Integer = 0
        Dim M10 As Integer = 0
        Dim M11 As Integer = 0
        Dim M12 As Integer = 0
        Dim Total As Integer = 0

        For Each DataGrid As DataGridViewRow In ViewData.Rows
            DataGrid.Cells(13).Value = 0
            For i = 1 To 12
                If DBNull.Value IsNot DataGrid.Cells(i).Value Then
                    DataGrid.Cells(13).Value += CInt(DataGrid.Cells(i).Value)

                End If
            Next
            If DBNull.Value IsNot DataGrid.Cells(1).Value Then
                M1 += CInt(DataGrid.Cells(1).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(2).Value Then
                M2 += CInt(DataGrid.Cells(2).Value)
            End If

            If DBNull.Value IsNot DataGrid.Cells(3).Value Then
                M3 += CInt(DataGrid.Cells(3).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(4).Value Then
                M4 += CInt(DataGrid.Cells(4).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(5).Value Then
                M5 += CInt(DataGrid.Cells(5).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(6).Value Then
                M6 += CInt(DataGrid.Cells(6).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(7).Value Then
                M7 += CInt(DataGrid.Cells(7).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(8).Value Then
                M8 += CInt(DataGrid.Cells(8).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(9).Value Then
                M9 += CInt(DataGrid.Cells(9).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(10).Value Then
                M10 += CInt(DataGrid.Cells(10).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(11).Value Then
                M11 += CInt(DataGrid.Cells(11).Value)
            End If
            If DBNull.Value IsNot DataGrid.Cells(12).Value Then
                M12 += CInt(DataGrid.Cells(12).Value)
            End If
            Total += DataGrid.Cells(13).Value

        Next
        Dim _TbleTotal As DataTable = New DataTable
        _TbleTotal.Columns.Add("SUM")
        _TbleTotal.Columns.Add("M1")
        _TbleTotal.Columns.Add("M2")
        _TbleTotal.Columns.Add("M3")
        _TbleTotal.Columns.Add("M4")
        _TbleTotal.Columns.Add("M5")
        _TbleTotal.Columns.Add("M6")
        _TbleTotal.Columns.Add("M7")
        _TbleTotal.Columns.Add("M8")
        _TbleTotal.Columns.Add("M9")
        _TbleTotal.Columns.Add("M10")
        _TbleTotal.Columns.Add("M11")
        _TbleTotal.Columns.Add("M12")
        _TbleTotal.Columns.Add("Total")
        Dim rows As DataRow = _TbleTotal.NewRow
        rows("SUM") = "Total"
        rows("M1") = M1
        rows("M2") = M2
        rows("M3") = M3
        rows("M4") = M4
        rows("M5") = M5
        rows("M6") = M6
        rows("M7") = M7
        rows("M8") = M8
        rows("M9") = M9
        rows("M10") = M10
        rows("M11") = M11
        rows("M12") = M12
        rows("Total") = Total
        _TbleTotal.Rows.Add(rows)


        dgvTotal.DataSource = _TbleTotal

        dgvTotal.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgvTotal.Columns(1).Width = 30
        'dgvTotal.Columns(2).Width = 30
        'dgvTotal.Columns(3).Width = 30
        'dgvTotal.Columns(4).Width = 30
        'dgvTotal.Columns(5).Width = 30
        'dgvTotal.Columns(6).Width = 30
        'dgvTotal.Columns(7).Width = 30
        'dgvTotal.Columns(8).Width = 30
        'dgvTotal.Columns(9).Width = 30
        'dgvTotal.Columns(10).Width = 30
        'dgvTotal.Columns(11).Width = 30
        'dgvTotal.Columns(12).Width = 30
        'dgvTotal.Columns(13).Width = 40

    End Sub
    Dim rs As New Resizer
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        '  lbProcessTitle.Text = "Width:" & Me.Width & "-Hight:" & Me.Height & ">>" & "Width:" & PanelNG.Width & "-Hight:" & PanelNG.Height
        rs.ResizeAllControls(Me)
        ' lbProcessTitle.Text = "Width:" & Me.Width & "-Hight:" & Me.Height & ">>" & "Width:" & PanelNG.Width & "-Hight:" & PanelNG.Height
    End Sub

    Private Sub pbxLogo_Click(sender As Object, e As EventArgs) Handles pbxLogo.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RadioWB_CheckedChanged(sender As Object, e As EventArgs)
        SearchLotNo.Focus()
    End Sub

    Private Sub RadioDB_CheckedChanged(sender As Object, e As EventArgs)
        SearchLotNo.Focus()
    End Sub
    Dim frm As QueryWIP = New QueryWIP
    Private Sub btQuery_Click(sender As Object, e As EventArgs) Handles btQuery.Click
        Dim frm As CheckWip = New CheckWip()
        frm.ShowDialog()
        'If frm.Visible = False Then
        '    If frm.IsDisposed = True Then
        '        frm = New QueryWIP
        '    End If
        '    frm.Visible = True
        'Else
        '    frm.Focus()
        'End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value = DateTimePicker1.MinDate Then
            ' DateTimePicker1.Value = Now
        Else
            '  loadDate()
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

    End Sub
End Class
