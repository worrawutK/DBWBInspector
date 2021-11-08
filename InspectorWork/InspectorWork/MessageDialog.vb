Public Class MessageDialog
    Private c_Process As String
    Sub New(process As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        c_Process = process
        labelAlarmTitle.Parent = pictureBoxTitelBar

    End Sub

    Private Sub MessageDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbProcess.Text = c_Process
    End Sub

    Private Sub PictureBoxDismiss_Click(sender As Object, e As EventArgs) Handles pictureBoxDismiss.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class