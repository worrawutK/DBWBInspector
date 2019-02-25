Imports System.IO
Imports System.Data.SqlClient

Public Class SelectAddress
    'Function ReadTextBoxNum(ByVal MachineNo As String) As String 'function อ่านชื่อ machine in text
    '    Using PathBoxNum As New StreamReader("\Cellcon\INSTCPIP\" & MachineNo & ".txt")
    '        Return PathBoxNum.ReadLine()
    '    End Using
    'End Function
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbQR.KeyPress
        Clear()
   
        Select Case e.KeyChar
            Case Convert.ToChar(49)
                ' TableNumber = ReadTextBoxNum("MachineNo01")
                TableNumber = "DWB-" & INSI1.Text
                INSI1.BackColor = Color.SpringGreen
            Case Convert.ToChar(50)
                ' TableNumber = ReadTextBoxNum("MachineNo02")
                TableNumber = "DWB-" & INSI2.Text
                INSI2.BackColor = Color.SpringGreen
            Case Convert.ToChar(51)
                TableNumber = "DWB-" & INSI3.Text
                INSI3.BackColor = Color.SpringGreen
            Case Convert.ToChar(52)
                TableNumber = "DWB-" & INSI4.Text
                INSI4.BackColor = Color.SpringGreen
            Case Convert.ToChar(53)
                TableNumber = "DWB-" & INSI5.Text
                INSI5.BackColor = Color.SpringGreen
            Case Convert.ToChar(54)
                TableNumber = "DWB-" & INSI6.Text
                INSI6.BackColor = Color.SpringGreen
            Case Convert.ToChar(55)
                TableNumber = "DWB-" & INSI7.Text
                INSI7.BackColor = Color.SpringGreen
            Case Convert.ToChar(56)
                TableNumber = "DWB-" & INSI8.Text
                ' TableNumber = INSI8.Text
                INSI8.BackColor = Color.SpringGreen
            Case Convert.ToChar(13)
                If TableNumber <> Nothing Then
                    'sent to client
                    SendStatus = Status.Ok.ToString
                    ' TableNumber = Nothing
                    GotoMainForm()
                Else
                    Clear()
                    MsgBox("กดตัวเลขเพื่อเลือกโต๊ะ INS")
                End If
            Case Convert.ToChar(8)
                'msg confirm
                Dim msgRslt As MsgBoxResult = MsgBox("คุณต้องการที่จะยกเลิก ?.", MsgBoxStyle.YesNo)
                If msgRslt = MsgBoxResult.Yes Then
                    SendStatus = Status.Cancel.ToString
                    GotoMainForm()
                ElseIf msgRslt = MsgBoxResult.No Then
                    '  MsgBox("You must be at least 21 years old to join.")
                End If
      
                'SendStatus = Status.Cancel.ToString
                'GotoMainForm()
            Case Else
                Clear()
                TableNumber = Nothing
                MsgBox("กดตัวเลขเพื่อเลือกโต๊ะ INS")
        End Select
        CheckData(TableNumber)
        e.Handled = True
        '     Me.DialogResult = DialogResult.OK
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSI1.Click, INSI8.Click, INSI7.Click, INSI6.Click, INSI5.Click, INSI4.Click, INSI3.Click, INSI2.Click
        tbQR.Focus()
        Dim val As Button = CType(sender, Button)
        Clear()
        val.BackColor = Color.SpringGreen
        TableNumber = "DWB-" & val.Text
        ' TableNumber = val.Text
        CheckData(TableNumber)

        'Dim strData As String = ""
        'Dim DataPath As String = ""
        'Using sw As New StreamWriter(DataPath, True)
        '    sw.WriteLine(strData)
        'End Using
    End Sub

    Private Sub CheckData(ByVal Machine As String)
        Try
            '---------
            '  sql = "SELECT  TOP (200) MCNo, MachineType, IP, SelfConIP FROM SECS.Machines WHERE MCNo = '" & "DWB-" & Val.Text & "';"
            sql = "SELECT  TOP (200) MCNo, MachineType, IP, SelfConIP FROM SECS.Machines WHERE MCNo = '" & Machine & "';"
            Dim data As SqlDataReader = cmd_excuteScalar()

            While data.Read

                ' MsgBox(data("IP").ToString)
                HostIP = data("IP").ToString
            End While
            conn.Close()
            '-------
            If TableNumber <> Nothing Then
                btOk.Enabled = True
                btOk.BackColor = Color.SpringGreen
            End If
        Catch ex As Exception

        End Try
      
    End Sub


    Private Sub GotoMainForm()
        Me.DialogResult = DialogResult.OK
    End Sub
    Private Sub Clear()
        tbQR.Text = Nothing

        INSI1.BackColor = Color.Black
        '  INSI1.BackColor = SystemColors.Control
        INSI2.BackColor = Color.Black
        INSI3.BackColor = Color.Black
        INSI4.BackColor = Color.Black
        INSI5.BackColor = Color.Black
        INSI6.BackColor = Color.Black
        INSI7.BackColor = Color.Black
        INSI8.BackColor = Color.Black

        btOk.Enabled = False
        btOk.BackColor = Color.Black
    End Sub
    Private Sub SelectAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Button11.Click
        tbQR.Focus()

    End Sub


    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click, btCancel.Click
        Dim val As Button = CType(sender, Button)

        If val.Name.ToString = "btCancel" Then
            Dim msgRslt As MsgBoxResult = MsgBox("คุณต้องการที่จะยกเลิก ?.", MsgBoxStyle.YesNo)
            If msgRslt = MsgBoxResult.Yes Then
                SendStatus = Status.Cancel.ToString
                GotoMainForm()
            ElseIf msgRslt = MsgBoxResult.No Then
                Exit Sub
                '  MsgBox("You must be at least 21 years old to join.")
            End If
            '  SendStatus = Status.Cancel.ToString
        End If
        GotoMainForm()
    End Sub

 
End Class