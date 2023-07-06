Public Class frmDataNG

    Private m_Numpad As New NumPadForm
    Public DataNG As String
    Public SelectProcess As String
    Public Mag As String
    Public Status As String
    Public NameMC As String
    'Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim CB As CheckBox = CType(sender, CheckBox)
    '        Dim CBName As String = CoverName(CB.Name)

    '        If CB.Checked = True Then
    '            ListBox1.Items.Add(CBName)
    '        Else
    '            For i = 0 To ListBox1.Items.Count - 1
    '                If ListBox1.Items(i) = CBName Then
    '                    ListBox1.Items.RemoveAt(i)
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Function CoverName(ByVal N As String) As String
        Dim strN As String = N
        strN = strN.Insert(3, ".")
        strN = strN.Insert(2, " ")
        Return strN
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Try
            DataNG = ""
            'For i = 0 To ListBox1.Items.Count - 1
            '    If i <> ListBox1.Items.Count - 1 Then
            '        DataNG &= ListBox1.Items(i) & " , "
            '    Else
            '        DataNG &= ListBox1.Items(i)
            '    End If

            'Next
            'If DataNG = "" Then
            '    MsgBox("กรุณาเลือก MODE DATA NG.")
            '    Exit Sub
            If SelectProcess = "" Then
                MsgBox("กรุณาเลือก PROCEES ")
                Exit Sub
                'ElseIf tbMag.Text = "" Then
                '    MsgBox("กรุณาใส่จำนวน MAG ")
                '    Exit Sub
                'ElseIf IsNumeric(tbMag.Text) And CInt(tbMag.Text) > 13 = True Then
                '    MsgBox("กรุณาป้อนค่า  NSPECTION QTY ใหม่ คุณป้อนค่าเกิน  13 MAG")
                '    tbMag.Clear()
                '    Exit Sub
            ElseIf CbAll.Checked = True Then




            ElseIf CbMagfirst.Text = "" Then
                MsgBox("กรุณาใส่  FirstMagInspection")
                Exit Sub
            ElseIf CbFramefirst.Text = "" Then
                MsgBox("กรุณาใส่  FirstFrameInspection")
                Exit Sub
            ElseIf CbMagfinish.Text = "" Then
                MsgBox("กรุณาใส่  FinishtMagInspection")
                Exit Sub
            ElseIf CbFramefinish.Text = "" Then
                MsgBox("กรุณาใส่  FinishFrameInspection")
                Exit Sub


            Else


            End If
            If CbMagfirst.Text = "ALL" Then
                Mag = "ALL"
            Else
                Mag = "M" & CbMagfirst.Text & "F" & CbFramefirst.Text & " - " & "M" & CbMagfinish.Text & "F" & CbFramefinish.Text
            End If

            ' Status = BT_Status.Text
            If TbNameMC.Text = "" Then
                MsgBox("กรุณาคีย์ NAME M/C ")
                Exit Sub
            Else
                NameMC = TbNameMC.Text
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDB.Click
        BtDB.BackColor() = Color.Lime
        BtWB.BackColor() = Color.WhiteSmoke
        BtSP.BackColor() = Color.WhiteSmoke
        SelectProcess = "DB"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtWB.Click
        BtDB.BackColor() = Color.WhiteSmoke
        BtWB.BackColor() = Color.Lime
        BtSP.BackColor() = Color.WhiteSmoke
        SelectProcess = "WB"
    End Sub
    Private Sub BtSP_Click(sender As Object, e As EventArgs) Handles BtSP.Click
        BtDB.BackColor() = Color.WhiteSmoke
        BtWB.BackColor() = Color.WhiteSmoke
        BtSP.BackColor() = Color.Lime
        SelectProcess = "SP"
    End Sub

    Private Sub tbfre_othalm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        tb = CType(sender, TextBox)
        m_Numpad.TargetTextBox = tb
        If Not m_Numpad.Visible Then
            m_Numpad.Show(Me)
            m_Numpad.Left = 730  '+ Me.Width
            m_Numpad.Top = Me.Top
        End If
    End Sub

    Private Sub frmDataNG_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        m_Numpad.Visible = False
    End Sub


    Private Sub frmDataNG_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DataNG = ""
        SelectProcess = ""
        Mag = ""
        NameMC = ""
        Status = ""
        'tbMag.Text = ""
        BtDB.BackColor = Color.WhiteSmoke
        BtWB.BackColor = Color.WhiteSmoke
        BtSP.BackColor = Color.WhiteSmoke
        CbAll.Checked = False

        CbMagfirst.Text = Nothing
        CbFramefirst.Text = Nothing
        CbMagfinish.Text = Nothing
        CbFramefinish.Text = Nothing
        CbMagfirst.Enabled = True
        CbFramefirst.Enabled = True
        CbMagfinish.Enabled = True
        CbFramefinish.Enabled = True

        TbNameMC.Text = ""

        BT_Status.BackColor = Color.Gainsboro
        Status = "NORMAL"

    End Sub
    




    Private Sub CbAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbAll.Click
        If CbAll.Checked = True Then

            CbMagfirst.Enabled = False
            CbMagfirst.Text = "ALL"
            CbFramefirst.Enabled = False
            CbFramefirst.Text = ""
            CbMagfinish.Enabled = False
            CbMagfinish.Text = ""
            CbFramefinish.Enabled = False
            CbFramefinish.Text = ""
        Else
            CbMagfirst.Enabled = True
            CbMagfirst.Text = ""
            CbFramefirst.Enabled = True
            CbFramefirst.Text = ""
            CbMagfinish.Enabled = True
            CbMagfinish.Text = ""
            CbFramefinish.Enabled = True
            CbFramefinish.Text = ""

        End If
       

    End Sub

   
    Private Sub BT_Status_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Status.Click
        If BT_Status.BackColor = Color.Gainsboro Then
            Status = "URGENT"
            BT_Status.BackColor = Color.Crimson

        ElseIf BT_Status.BackColor = Color.Crimson Then
            Status = "NORMAL"
            BT_Status.BackColor = Color.Gainsboro
        End If

    End Sub

    
    Private Sub TbNameMC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNameMC.Click
        Dim tb As TextBox
        Dim key As FrmKeyBoard = New FrmKeyBoard
        tb = CType(sender, TextBox)
        key.TargetText = tb
        key.Show()
    End Sub


End Class
