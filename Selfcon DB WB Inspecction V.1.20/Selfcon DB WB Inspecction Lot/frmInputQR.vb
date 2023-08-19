Imports System.Data.SqlClient

Public Class frmInputQR
    Public QRCode As String
    Public QROpNo As String
    Public QRGLNo As String
    Public InputQtyOSFT As Integer
    Public inputTPQr As Integer
    Public Caption As String
    Public InputPickUp As Integer
    Public DeviecDLot As String




    Private Sub tbRevQR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbRevQR.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Return) Then
            If tbRevQR.Text.Length = 252 AndAlso lbCaption.Text = "SCAN QR CODE" Then

                'DBDataTableAdapter.FillBy(DBxDataSet.DBData, LotNo)
                'For Each row As DBxDataSet.DBDataRow In DBxDataSet.DBData
                '    If row.MCNo <> "" Then
                '        ret = row.MCNo
                '    End If
                'Next

                QRCode = ""
                QRCode = tbRevQR.Text
                'Dim input As Integer
                lbCaption.Text = "SCAN OP No."
                ProgressBar1.Value = 0
                tbRevQR.Clear()


            ElseIf tbRevQR.Text.Length = 6 AndAlso lbCaption.Text = "SCAN OP No." AndAlso IsNumeric(tbRevQR.Text) = True Then
                QROpNo = ""
                QROpNo = tbRevQR.Text
                tbRevQR.Clear()
                Timer1.Stop()
                ProgressBar1.Value = 0
                Dim LotNo As String = Trim(QRCode.Substring(30, 10))

                ' Frmmain.CheckOldData = Frmmain.FindDataLot(LotNo)
                If Frmmain.CheckOldData = False Then
                    If frmDataNG.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        Me.Close()
                    End If
                Else
                    Me.Close()
                End If

            ElseIf tbRevQR.Text.Length = 6 AndAlso lbCaption.Text = "SCAN GL No." AndAlso IsNumeric(tbRevQR.Text) = True Then
                QRGLNo = ""
                QRGLNo = tbRevQR.Text
                QROpNo = QRGLNo
                tbRevQR.Clear()
                'Timer1.Stop()
                ProgressBar1.Value = 0

                If OperatorPermit(QRGLNo, "PDWBGL") Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    ProgressBar1.Value = 0
                    tbRevQR.Clear()
                    MsgBox("QRCode : " & QRGLNo & " นี้ไม่มีสิทธิ์ PDGL กรุณาตรวจสอบ")
                End If


            ElseIf tbRevQR.Text.Length = 252 AndAlso lbCaption.Text = "SCAN QR CODE LOT EDIT" = True Then

                QRCode = ""
                QRCode = tbRevQR.Text
                ProgressBar1.Value = 0
                tbRevQR.Clear()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            ElseIf tbRevQR.Text.Length = 252 AndAlso lbCaption.Text = "SCAN QR LOT CANCEL" = True Then

                QRCode = ""
                QRCode = tbRevQR.Text
                ProgressBar1.Value = 0
                tbRevQR.Clear()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else
                ProgressBar1.Value = 0
                tbRevQR.Clear()
                MsgBox("QRCode ไม่ถูกต้องกรุณาสแกนใหม่")
            End If
        End If

    End Sub

    Private Sub frmInputQR_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        tbRevQR.Focus()
    End Sub


    Private Sub frmInputQR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbCaption.Text = Caption
        Timer1.Start()
        tbRevQR.Focus()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If lbCaption.Text = "SCAN QR CODE" Then
                ProgressBar1.Value = (tbRevQR.Text.Length / 252) * 100
            ElseIf lbCaption.Text = "SCAN OP No." Then
                ProgressBar1.Value = (tbRevQR.Text.Length / 6) * 100
            ElseIf lbCaption.Text = "SCAN GL No." Then
                ProgressBar1.Value = (tbRevQR.Text.Length / 6) * 100
            End If

        Catch ex As Exception

        End Try
    End Sub


    Function OperatorPermit(ByVal OpNo As String, ByVal role As String) As Boolean
        Dim ret As Boolean = False
        Dim query As String = "SELECT APCSProDB.man.user_roles.user_id, APCSProDB.man.user_roles.role_id, APCSProDB.man.user_roles.expired_on, APCSProDB.man.users.emp_num, APCSProDB.man.roles.name FROM  APCSProDB.man.user_roles INNER JOIN APCSProDB.man.users On APCSProDB.man.user_roles.user_id = APCSProDB.man.users.id INNER JOIN APCSProDB.man.roles On APCSProDB.man.user_roles.role_id = APCSProDB.man.roles.id WHERE (APCSProDB.man.users.emp_num = @opno) and (APCSProDB.man.roles.name = 'PDDBGL' or APCSProDB.man.roles.name = 'PDWBGL')"
        'Dim query As String = "SELECT APCSProDB.man.user_roles.user_id, APCSProDB.man.user_roles.role_id, APCSProDB.man.user_roles.expired_on, APCSProDB.man.users.emp_num, APCSProDB.man.roles.name FROM  APCSProDB.man.user_roles INNER JOIN APCSProDB.man.users ON APCSProDB.man.user_roles.user_id = APCSProDB.man.users.id INNER JOIN APCSProDB.man.roles ON APCSProDB.man.user_roles.role_id = APCSProDB.man.roles.id WHERE (APCSProDB.man.users.emp_num = @opno) and APCSProDB.man.roles.name = @rolename"
        'Dim query As String = "SELECT * FROM ชื่อตาราง WHERE ชื่อคอลัมน์ = @ConditionValue" ' ใช้ @parameter

        Using connection As New SqlConnection(My.Settings.DBxConnectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()

                ' กำหนดค่าของ @parameter
                command.Parameters.AddWithValue("@opno", OpNo)
                'command.Parameters.AddWithValue("@rolename", role)


                Using reader As SqlDataReader = command.ExecuteReader()
                    Dim tb As DataTable = New DataTable()
                    tb.Load(reader)
                    If tb.Rows.Count <> 0 Then
                        Dim exp As String = tb(0)("expired_on").ToString()

                        ret = True
                    End If
                End Using
            End Using
        End Using

        Return ret
    End Function

    Private Sub timerCheckText_Tick(sender As Object, e As EventArgs) Handles timerCheckText.Tick
        tbRevQR.Text = ""
    End Sub
    Private cloetimer As Boolean = False
    Private Sub tbRevQR_TextChanged(sender As Object, e As EventArgs) Handles tbRevQR.TextChanged
        If tbRevQR.Text = "***" Then
            timerCheckText.Stop()
            Label1.Text = "Timer Stop"
            cloetimer = True
            tbRevQR.Text = ""

        Else
            If cloetimer = False Then
                timerCheckText.Stop()
                timerCheckText.Start()

            End If
        End If
    End Sub
End Class