Public Class InputCarrierDialog
    Private c_MaxValue As Integer = 11
    Private c_FullCode As String
    Public Property FullCode As String
        Get
            Return c_FullCode
        End Get
        Set(ByVal value As String)
            c_FullCode = value
        End Set
    End Property
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'lbDisplay.Text = "กรุณา Scan QR Carrier No."
    End Sub
    Private Sub TextBoxQrCodeInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxQrCodeInput.KeyPress
        ProgressBarManual((panel3.Size.Width + 0.0) / c_MaxValue)

        If e.KeyChar = Convert.ToChar(13) Then
            If TextBoxQrCodeInput.Text = "NULL" Then
                TextBoxQrCodeInput.Text = "-"
            ElseIf c_MaxValue <> TextBoxQrCodeInput.Text.Length Then

                MessageBox.Show("ขนาดของ QR ไม่ถูกต้อง (" & TextBoxQrCodeInput.Text.Length & ")", "Read Qr Code")
                Return
            ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxQrCodeInput.Text, "^([a-zA-Z]|\d){3}-\d{2}-([a-zA-Z]|\d){4}$") Then
                MessageBox.Show("format QR ไม่ถูกต้อง (" & TextBoxQrCodeInput.Text & ")", "Read Qr Code")
                Return
            End If
            FullCode = TextBoxQrCodeInput.Text
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub ProgressBarManual(count As Double)
        labelTextScan.Visible = False
        Dim sizeMax As Size = panel3.Size
        Dim point As Point = pictureBox2.Location
        point.X += CType(Math.Ceiling(count), Integer)
        pictureBox2.Location = point
        Dim size As Size = label1.Size
        size.Width += CType(Math.Ceiling(count), Integer)
        label1.Size = size
        If label1.BackColor <> Color.LimeGreen Then
            label1.BackColor = Color.LimeGreen
        End If


        If sizeMax.Width <= label1.Size.Width Then
            Dim point2 As Point = pictureBox2.Location
            point2.X += pictureBox2.Width
            pictureBox2.Location = point2
        End If

    End Sub

    Private Sub PictureboxQrCodeInputCheck_Click(sender As Object, e As EventArgs) Handles PictureboxQrCodeInputCheck.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class