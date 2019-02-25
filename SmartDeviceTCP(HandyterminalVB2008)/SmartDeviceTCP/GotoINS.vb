Public Class GotoINS
    Public StatusINS As String
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub GotoINS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If StatusINS = Status.Ok Then
            Label1.Text = "ส่งไปยังโต๊ะ INS เรียบร้อย"
            Me.BackColor = Color.LawnGreen
        ElseIf StatusINS = Status.EndLot Then
            Me.BackColor = Color.Red
            Label1.Text = "Lot นี้ยังไม่ได้ ทำการ บันทึก Inspection Request"
            Label2.Text = "หรือ End Inspection แล้ว"
        ElseIf StatusINS = Status.ScanOP Then
            Me.BackColor = Color.Red
            Label1.Text = "กรุณา Scan OP No. อีกครั้ง"
        ElseIf StatusINS = Status.ScanQR Then
            Me.BackColor = Color.Red
            Label1.Text = "กรุณา Scan QR อีกครั้ง"
        ElseIf StatusINS = Status.Running Then
            Me.BackColor = Color.Red
            Label1.Text = "กรุณาจบ Inspection ก่อน"
        ElseIf StatusINS = Status.Cancel Then
            Me.BackColor = Color.Orange
            Label1.Text = "ยกเลิก"
        ElseIf StatusINS = Status.PleaseSetMachine Then
            Me.BackColor = Color.Red
            Label1.Text = "กรุณา Set Machine ให้ตรง"
        ElseIf StatusINS = Status.TimeOut Then
            Me.BackColor = Color.Red
            Label1.Text = "กรุณาตรวจสอบสัญญาณ"
        End If

    End Sub
End Class