Public Class GLCheck
    Dim p() As Process
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' Process.s("C:\VNC4\vncviewer.exe", "10.28.52.124")
        p = Process.GetProcessesByName("vncviewer")
        If p.Count > 0 Then
            For Each prog As Process In Process.GetProcesses
                If prog.ProcessName = "vncviewer" Then
                    prog.Kill()
                    '   KeyBoardClose()
                End If
            Next
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click
        Form1.Hide()
        p = Process.GetProcessesByName("vncviewer")
        If p.Count > 0 Then
            For Each prog As Process In Process.GetProcesses
                If prog.ProcessName = "vncviewer" Then
                    prog.Kill()

                End If
            Next
        Else
        
        End If
        Dim val As Button = CType(sender, Button)
        Process.Start("C:\VNC4\vncviewer.exe", val.Text)
    End Sub
End Class