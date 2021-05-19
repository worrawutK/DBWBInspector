Public Class KeyRemark
    Public Shared TargetTextBox As TextBox

    Public Shared Key As String
    Public Shared Sub ShowkeyBoard(txtBox As TextBox)
        Dim frm As KeyRemark = New KeyRemark
        frm.Show()
        Key = Form1.StatusKey.Remark
        TargetTextBox = txtBox
    End Sub
    Public Shared c_TextBox As TextBox
    Public Shared newKeyboard As Boolean
    Private Sub ClickButtoN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt0.Click, Bt1.Click, Bt2.Click, Bt3.Click _
                                 , Bt4.Click, Bt5.Click, Bt6.Click, Bt7.Click, Bt8.Click, Bt9.Click, BtA.Click, BtB.Click, BtC.Click _
                                 , BtD.Click, BtE.Click, BtF.Click, BtG.Click, BtH.Click, BtI.Click, BtJ.Click, BtK.Click, BtL.Click _
                                 , BtM.Click, BtN.Click, BtO.Click, BtP.Click, BtQ.Click, BtR.Click, BtS.Click, Btt.Click, BtU.Click _
                                 , BtV.Click, BtW.Click, BtX.Click, BtY.Click, BtZ.Click, BtBS.Click, BtMinus.Click, BtClear.Click, BtPlus.Click, BtLeft.Click, BtRight.Click
        'If c_TextBox IsNot Nothing Then
        '    c_TextBox.Text += sender.text
        '    Exit Sub
        'End If
        If Key = Form1.StatusKey.Remark Then
            TargetTextBox.Focus()
            Dim bt As Button = CType(sender, Button)
            '   TextBox1.Focus()
            If bt.Text = "BACKSPACE" Then
                SendKeys.Send("{BS}")
            ElseIf bt.Text = "CLEAR" Then
                TargetTextBox.Text = ""
                'TextBox1.Text = Nothing
                'ElseIf bt.Text = "+" Then
                '    SendKeys.Send("{ADD}")
            ElseIf bt.Text = "SPACEBAR" Then
                SendKeys.Send(" ")
            ElseIf bt.Text = "Left" Then
                SendKeys.Send("{LEFT}")
            ElseIf bt.Text = "Right" Then
                SendKeys.Send("{RIGHT}")
            Else
                SendKeys.Send(bt.Text)
            End If
        ElseIf Key = Form1.StatusKey.AddItem Then
            '-----------------
            Dim val As String
            val = sender.text
            If val = "BACKSPACE" Then
                If Form1.cbxItem.Text.Length > 0 Then
                    Form1.cbxItem.Text = Form1.cbxItem.Text.Substring(0, Form1.cbxItem.Text.Length - 1)
                End If
            ElseIf val = "SPACEBAR" Then
                Form1.cbxItem.Text += " "
            ElseIf val = "CLEAR" Then
                Form1.cbxItem.Text = ""
            ElseIf val = "Left" Then
                'TargetTextBox.Text = ""
            ElseIf val = "Right" Then
                ' TargetTextBox.Text = ""
            Else
                Form1.cbxItem.Text += val
            End If
            '--------------------
        End If
     
      
    End Sub

 

    'Private Sub BtLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtLeft.Click
    '    'Form1.CtlFocust.Focus()
    '    TargetTextBox.Focus()
    '    My.Computer.Keyboard.SendKeys("{LEFT}", True)
    'End Sub

    'Private Sub BtRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRight.Click
    '    'Form1.CtlFocust.Focus()
    '    TargetTextBox.Focus()
    '    My.Computer.Keyboard.SendKeys("{RIGHT}", True)
    'End Sub

    

    Private Sub BtEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEnter.Click
        '  TargetTextBox.Focus()
        ' My.Computer.Keyboard.SendKeys("{ENTER}", True)

        'If Key = "AddItem" Then
        '    Form1.cbxItem.Text = TextBox1.Text
        'Else
        '    Form1.tbRemark.Text = TextBox1.Text
        'End If
        If Key = Form1.StatusKey.Remark Then

            SendKeys.Send("{ENTER}")

        End If
        Me.Close()
    End Sub
    'Protected Overrides ReadOnly Property CreateParams() As CreateParams   'Disable Close(x) Button
    '    Get
    '        Dim param As CreateParams = MyBase.CreateParams
    '        param.ClassStyle = param.ClassStyle Or &H200
    '        Return param
    '    End Get
    'End Property
  
    
    Private Sub KeyRemark_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' TextBox1.Focus()
    End Sub


End Class