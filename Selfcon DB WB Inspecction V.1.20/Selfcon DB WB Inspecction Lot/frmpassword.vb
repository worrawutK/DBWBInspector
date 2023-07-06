Public Class frmpassword

    Dim PW As String = Format(Now, "yyyyMMdd")
    Dim PassWord As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button12.Click, Button11.Click, Button10.Click
        Dim bt As Button = CType(sender, Button)
        Dim Text As String = bt.Text
        If bt.Text <> "OK" AndAlso bt.Text <> "CLR" Then
            tbPassword.Text &= "*"
            PassWord &= bt.Text
        Else
            If Text = "CLR" Then
                tbPassword.Clear()
                PassWord = ""
            ElseIf Text = "OK" Then
                If PW <> PassWord Then
                    MsgBox("รหัสผิดพลาด")
                Else
                    PassWord = tbPassword.Text
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub frmpassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbPassword.Clear()
        PassWord = ""
    End Sub
End Class