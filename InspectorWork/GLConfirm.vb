Public Class GLConfirm

    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If TextBox1.Text.Length = 6 Then
                Form1.tbQR_GL.Text = TextBox1.Text
                Me.DialogResult = DialogResult.OK
            Else
                TextBox1.Text = Nothing
                MsgBox("กรุณา Scan อีกครั้ง")
            End If
        End If
        If TextBox1.TextLength <= 5 Then
            ProgressBar1.Value = TextBox1.TextLength + 1
        End If
    End Sub
    Private Sub ProgressBar1_Click(sender As System.Object, e As System.EventArgs) Handles ProgressBar1.Click
        Dim frmkey As New INPUTGLCHECK
        frmkey.TargetTextBox = TextBox1
        frmkey.Show()
        TextBox1.Focus()
    End Sub

    Private Sub GLConfirm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()

    End Sub
End Class