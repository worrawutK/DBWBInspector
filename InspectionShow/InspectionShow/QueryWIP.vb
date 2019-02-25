Public Class QueryWIP
    Dim _Tb As DBxDataSet.DBWBINS_Query_DataDataTable
    Dim _TbSumWIP As DBxDataSet.Query_SumWIPDataTable

    Private Sub Loaddata()


        Dim num As Integer = 0

        For i = 0 To CInt(CountDate.Days)
            val += 1
            '   DBWBINSDataTableAdapter.Fill(DBxDataSet.DBWBINSData, EndDateWIP)
            Dim count_wipday As Integer = 0
            Dim count_wipnight As Integer = 0
            If SelectProcess = Process.All Then
                DBWBINS_QueryTableAdapter.Fill(DBxDataSet.DBWBINS_Query, EndDateWIP.AddDays(-i))
            Else
                DBWBINS_QueryTableAdapter.FillProcess(DBxDataSet.DBWBINS_Query, EndDateWIP.AddDays(-i), SelectProcess.ToString)
            End If

            For Each dayWIP As DBxDataSet.DBWBINS_QueryRow In DBxDataSet.DBWBINS_Query
                num += 1  'setKey
                Dim row As DBxDataSet.DBWBINS_Query_DataRow = _Tb.NewRow

                If Not dayWIP.IsDeviceNull Then
                    row.Device = dayWIP.Device
                End If

                row.LotNo = dayWIP.LotNo

                If Not dayWIP.IsPackageNull Then
                    row.Package = dayWIP.Package
                End If

                row.ReqDate = dayWIP.ReqDate

                If Not dayWIP.IsStartTimeNull Then
                    row.StartTime = dayWIP.StartTime
                End If

                If Not dayWIP.IsEndTimeNull Then
                    row.EndTime = dayWIP.EndTime
                End If

                If Not dayWIP.IsRequestModeName1Null Then
                    row.RequestModeName1 = dayWIP.RequestModeName1
                End If

                If Not dayWIP.IsRequestModeName2Null Then
                    row.RequestModeName2 = dayWIP.RequestModeName2
                End If

                If Not dayWIP.IsProcessNull Then
                    row.Process = dayWIP.Process
                End If

                If Not dayWIP.IsStatusNull Then
                    row.Status = dayWIP.Status
                End If
                row.DateWIP = EndDateWIP.AddDays(-(i + 1))
                row.Number = num

                ' Dim timee As TimeSpan = New TimeSpan(0, 20, 0, 0, 0)
                Dim dateQry As String = (dayWIP.ReqDate.Year & "/" & dayWIP.ReqDate.Month & "/" & dayWIP.ReqDate.Day & " ")
                ' dateQry = dateQry & "08:00:00"
                Dim DayIN As Date = dateQry & "08:00:00"
                Dim DayOut As Date = dateQry & "20:00:00"
                DayIN.AddDays(dayWIP.ReqDate.Day)
                DayIN.AddHours(dayWIP.ReqDate.Hour)

                If dayWIP.ReqDate > DayIN And dayWIP.ReqDate < DayOut Then
                    '  sumDay += 1
                    count_wipday += 1
                    row.Day = dayWIP.ReqDate 'DateTime.ParseExact(theTime, "HHmm", Nothing).ToString("MMMM/dd hh:mm") '.TimeOfDay
                    ' row.Night = "-"
                    'Rows("Night") = ""
                Else
                    ' sumNight += 1
                    count_wipnight += 1
                    '  row.Day = "-"
                    row.Night = dayWIP.ReqDate 'dayWIP.ReqDate.ToString("MMMM/dd HH:mm") '.TimeOfDay
                End If

                _Tb.Rows.Add(row)
            Next


            Dim sumRow As DBxDataSet.Query_SumWIPRow = _TbSumWIP.NewRow
            sumRow._Date = EndDateWIP.AddDays(-(i + 1))
            sumRow.Day = CInt(count_wipday)
            sumRow.Night = CInt(count_wipnight)
            sumRow.Total = CInt(count_wipday) + CInt(count_wipnight)
            _TbSumWIP.Rows.Add(sumRow)
        Next

        '  _Tb = DBxDataSet.DBWBINSData    
        'DataGridView2.DataSource = _Tb
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker2.Value = Now
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles gvDaywip.RowPostPaint
        Using b As SolidBrush = New SolidBrush(gvDaywip.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using

        '  e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)

    End Sub

    Private Sub DataGridView2_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgListwip.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgListwip.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub DataGridView3_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgWipSumDay.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgWipSumDay.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
    Enum Process
        DB
        WB
        All
    End Enum
    Dim SelectProcess As Process = Process.All
    Private Sub rbAll_CheckedChanged(sender As Object, e As EventArgs) Handles rbAll.CheckedChanged
        SelectProcess = Process.All
    End Sub

    Private Sub rbDB_CheckedChanged(sender As Object, e As EventArgs) Handles rbDB.CheckedChanged
        SelectProcess = Process.DB
    End Sub

    Private Sub rbWB_CheckedChanged(sender As Object, e As EventArgs) Handles rbWB.CheckedChanged
        SelectProcess = Process.WB
    End Sub
    Dim val As Integer
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        val = 0
        Loaddata()

        'For i = 0 To x
        '      Debug.Print(i & ":" & x)
        '    ' x += 1
        '    count = i
        'Next
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        dgListwip.DataSource = _Tb
        dgWipSumDay.DataSource = _TbSumWIP
        ' MsgBox("Comp")
    End Sub
    Dim StartDate As Date
    Dim ToEndDate As Date
    Dim EndDateWIP As Date
    Dim StartDateWIP As Date
    Dim CountDate As TimeSpan
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btQuery.Click
        If Timer1.Enabled = True Then
            Exit Sub
        End If
        StartDate = DateTimePicker1.Value
        StartDateWIP = CDate(StartDate.ToShortDateString).AddHours(32)

        ToEndDate = DateTimePicker2.Value
        EndDateWIP = CDate(ToEndDate.ToShortDateString).AddHours(32)

        CountDate = CDate(EndDateWIP.ToShortDateString) - CDate(StartDateWIP.ToShortDateString)
        If CInt(CountDate.Days) < 0 Then
            MsgBox("กรุณาระบุวันที่ให้ถูกต้อง")
            Exit Sub
        End If
        ProgressBar1.Maximum = CInt(CountDate.Days) + 1
        _Tb = New DBxDataSet.DBWBINS_Query_DataDataTable
        _TbSumWIP = New DBxDataSet.Query_SumWIPDataTable
        ' Dim summ As DBxDataSet.SumWIPDataTable = New DBxDataSet.SumWIPDataTable
        '  DBxDataSet.Query_SumWIP.Clear()
        Dim Max As Boolean = False
        If CInt(CountDate.Days) > 31 Then
            If InputBox("Input Password") = CStr(Now.Year) & Now.Month.ToString("00") & CStr(CInt(Now.Day) Mod 7) Then
                Max = True
            Else
                MsgBox("กรุณาติดต่อ System เนื่องจากมีการ Query จำนวนมาก '" & CStr(CInt(CountDate.Days) + 1) & "'ครั้ง " _
                       & vbCrLf & "เพื่อขออนุญาติในการ Query (PW> yyyy:MM:ddMod7)")
                Exit Sub
            End If

        End If
        Timer1.Start()
        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = val
        lbLoad.Text = ((val / (CInt(CountDate.Days) + 1)) * 100).ToString("00") & "%"
        If ProgressBar1.Value = CInt(CountDate.Days) + 1 Then
            Timer1.Stop()
        End If

    End Sub


End Class