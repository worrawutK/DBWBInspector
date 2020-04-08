Imports System.Data.SqlClient
Public Class CheckWip
    Private Sub btQuery_Click(sender As Object, e As EventArgs) Handles btQuery.Click

        Dim dateData As DateTime = DateTimePicker1.Value.Date
        Dim process As String = ""
        If rbDB.Checked Then
            process = "DB"
        ElseIf rbWB.Checked Then
            process = "WB"
        End If

        dgListwip.DataSource = GetWIPData(dateData.AddHours(8), process)
    End Sub

    Private Sub CheckWip_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Function GetWIPData(dateTime As DateTime, process As String) As List(Of InspData)
        Dim data As DataTable = New DataTable
        Using con As New SqlConnection("Data Source=172.16.0.102;Initial Catalog=DBx;User ID=dbxuser")
            Dim cmd As SqlCommand = New SqlCommand()
            con.Open()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select CASE WHEN TransactionData.Device IS NULL THEN ' ' ELSE TransactionData.Device END AS Device,ins.DBWBINSData.LotNo,ins.DBWBINSData.Package,ins.DBWBINSData.ReqDate,ins.DBWBINSData.StartTime,
ins.DBWBINSData.EndTime ,ins.DBWBINSData.RequestModeName1,ins.DBWBINSData.RequestModeName2,ins.DBWBINSData.Process,case when ins.DBWBINSData.[Status] is NULL then '' else ins.DBWBINSData.[Status] end as [Status],
ins.DBWBINSData.RequestMode1,ins.DBWBINSData.RequestMode2,ins.DBWBINSData.TotalQty ,INS.DBWBINSData.GoodQty,ins.DBWBINSData.NGQty,ins.DBWBINSData.InsName 
from ins.DBWBINSData 
inner join TransactionData on 
TransactionData.LotNo = ins.DBWBINSData.LotNo
where EndTime >= @dateTime and ReqDate < @dateTime and INS.DBWBINSData.Remark != 'CANCEL LOT'"

            cmd.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = dateTime
            cmd.Connection = con

            Dim result = cmd.ExecuteReader
            data.Load(result)

            con.Close()

        End Using
        Dim inspDatas As List(Of InspData) = New List(Of InspData)
        For Each row As DataRow In data.Rows
            Dim insData As InspData = New InspData
            If Not row("LotNo") Is DBNull.Value Then
                insData.LotNo = CType(row("LotNo"), String)
            End If
            If Not row("Device") Is DBNull.Value Then
                insData.Device = CType(row("Device"), String)
            End If
            If Not row("Package") Is DBNull.Value Then
                insData.Package = CType(row("Package"), String)
            End If
            If Not row("Process") Is DBNull.Value Then
                insData.ProcessName = CType(row("Process"), String)
            End If
            If Not row("InsName") Is DBNull.Value Then
                insData.MachineNo = CType(row("InsName"), String)
            End If
            If Not row("StartTime") Is DBNull.Value Then
                insData.LotStartTime = CType(row("StartTime"), DateTime)
            End If
            If Not row("EndTime") Is DBNull.Value Then
                insData.LotEndTime = CType(row("EndTime"), DateTime)
            End If
            If Not row("ReqDate") Is DBNull.Value Then
                insData.LotRequestTime = CType(row("ReqDate"), DateTime)
            End If
            If Not row("GoodQty") Is DBNull.Value Then
                insData.GoodQty = CType(row("GoodQty"), Integer)
            End If
            If Not row("NgQty") Is DBNull.Value Then
                insData.NgQty = CType(row("NgQty"), Integer)
            End If
            If Not row("TotalQty") Is DBNull.Value Then
                insData.TotalQty = CType(row("TotalQty"), Integer)
            End If
            If Not row("Status") Is DBNull.Value Then
                insData.LotStatus = CType(row("Status"), String)
            End If
            If Not row("RequestMode1") Is DBNull.Value Then
                insData.RequestMode1 = CType(row("RequestMode1"), String)
            End If
            If Not row("RequestMode2") Is DBNull.Value Then
                insData.RequestMode2 = CType(row("RequestMode2"), String)
            End If
            If Not row("RequestModeName1") Is DBNull.Value Then
                insData.RequestModeName1 = CType(row("RequestModeName1"), String)
            End If
            If Not row("RequestModeName2") Is DBNull.Value Then
                insData.RequestModeName2 = CType(row("RequestModeName2"), String)
            End If
            inspDatas.Add(insData)
        Next
        If String.IsNullOrEmpty(process) Then
            Return inspDatas
        Else
            Return inspDatas.Where(Function(x) x.ProcessName = process).ToList
        End If

    End Function

    Private Sub dgListwip_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgListwip.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgListwip.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
End Class