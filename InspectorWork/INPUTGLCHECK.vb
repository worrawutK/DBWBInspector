Public Class INPUTGLCHECK
    Public TargetTextBox As TextBox
    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button12.Click, Button10.Click, Button1.Click
        TargetTextBox.Focus()
        Dim bt As Button = CType(sender, Button)
        '   TextBox1.Focus()
        If bt.Text = "Clear" Then
            '  SendKeys.Send("{BS}")
            TargetTextBox.Text = Nothing
            'ElseIf bt.Text = "CLEAR" Then
            '    TargetTextBox.Text = ""
            '    'TextBox1.Text = Nothing
            'ElseIf bt.Text = "+" Then
            '    SendKeys.Send("{ADD}")
            'ElseIf bt.Text = "Left" Then
            '    SendKeys.Send("{LEFT}")
            'ElseIf bt.Text = "Right" Then
            '    SendKeys.Send("{RIGHT}")
        ElseIf bt.Text = "ENTER" Then
            SendKeys.Send("{ENTER}")
            Me.Close()
        Else

            SendKeys.Send(bt.Text)
        End If
    End Sub
End Class