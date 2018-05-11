Public Class InputQty
   

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click, Button10.Click, Button11.Click, Button12.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        Dim val As String
        val = sender.text
        If val = "BS" Then
            If DisplayInput.Text.Length > 0 Then
                DisplayInput.Text = DisplayInput.Text.Substring(0, DisplayInput.Text.Length - 1)
            End If

        Else
            If DisplayInput.Text.Length >= 6 Then

            Else
                DisplayInput.Text += val
            End If

        End If

    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        'Form1.btQR.Text = Label1.Text
        'Me.DialogResult = DialogResult.OK
        If DisplayInput.Text = "" Then
            MsgBox("กรุณา ใส่ จำนวน InputQty")
            Exit Sub
        End If


        If CInt(DisplayInput.Text) = 0 Then
            MsgBox("กรุณา ใส่ จำนวน InputQty")
            DisplayInput.Text = ""
            Exit Sub
        End If
        If Form1.KeyNumInput = Form1.StatusKey.Total Then
            '  MsgBox("GL Check")

            Form1.KeyNumInput = Form1.StatusKey.InPutMag
            Label1.Text = "INPUT NG Q'TY"
            'DisplayInput.Text = ""


        Else
            Label1.Text = "Input total Q'ty (pcs.)"
            '  End If
        End If
        Form1.OprData.InputQtyFrmVal = DisplayInput.Text
        Me.Close()
    End Sub
    'Protected Overrides ReadOnly Property CreateParams() As CreateParams   'Disable Close(x) Button
    '    Get
    '        Dim param As CreateParams = MyBase.CreateParams
    '        param.ClassStyle = param.ClassStyle Or &H200
    '        Return param
    '    End Get
    'End Property


    Private Sub InputQty_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'If Form1.KeyNumInput = Form1.StatusKey.GLCheck Then
        '    '    DisplayInput.PasswordChar = "x"
        '    DisplayInput.UseSystemPasswordChar = True
        'End If
        If Form1.KeyNumInput = Form1.StatusKey.InPutMag Then
            Label1.Text = "INPUT NG Q'TY"
        End If

    End Sub
End Class