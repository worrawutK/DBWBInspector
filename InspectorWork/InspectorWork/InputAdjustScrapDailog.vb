Public Class InputAdjustScrapDailog
    Private c_InspectionDetall As DBxDataSet.Inspection_DetailDataTable
    Private c_FrameFail As Integer?
    Public Property FrameScrap() As Integer?
        Get
            Return c_FrameFail
        End Get
        Set(ByVal value As Integer?)
            c_FrameFail = value
        End Set
    End Property
    Sub New(data As DBxDataSet.Inspection_DetailDataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '  ScrapDatas = data

        c_InspectionDetall = data
    End Sub
    Private oskProcess As Process
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '  Dim dataTable As DataTable = New DataTable
        'Inspection_DetailBindingSource = bindingData
        ComboBoxMultiplier.SelectedIndex = 0
        dgvInspDetail.DataSource = c_InspectionDetall
        'Dim old As Long
        'If Environment.Is64BitOperatingSystem Then
        '    If Wow64DisableWow64FsRedirection(old) Then
        '        If Me.oskProcess Is Nothing OrElse Me.oskProcess.HasExited Then
        '            If Me.oskProcess IsNot Nothing AndAlso Me.oskProcess.HasExited Then
        '                Me.oskProcess.Close()
        '            End If

        '            Me.oskProcess = Process.Start(osk)
        '        End If
        '        '  Process.Start(osk)
        '        Wow64EnableWow64FsRedirection(old)
        '    End If
        'Else
        '    If Me.oskProcess Is Nothing OrElse Me.oskProcess.HasExited Then
        '        If Me.oskProcess IsNot Nothing AndAlso Me.oskProcess.HasExited Then
        '            Me.oskProcess.Close()
        '        End If

        '        Me.oskProcess = Process.Start(osk)
        '    End If
        'End If
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If Not IsNumeric(TextBoxFrameScrap.Text) OrElse Integer.Parse(TextBoxFrameScrap.Text) <= 0 Then
            MessageBox.Show("กรุณากรอกจำนวน Frame Scrap เลขมากกว่า 0")
            Exit Sub
        End If
        FrameScrap = Integer.Parse(TextBoxFrameScrap.Text)
        'If Not IsNumeric(TextBoxFrameScrap.Text) Then
        '    MessageBox.Show("กรุณากรอกข้อมูลที่เป็นตัวเลขเท่านั้น!")
        '    Exit Sub
        'End If


        'If Me.oskProcess IsNot Nothing Then
        '    If Not Me.oskProcess.HasExited Then
        '        'CloseMainWindow would generally be preferred but the OSK doesn't respond.
        '        Me.oskProcess.Kill()
        '    End If

        '    Me.oskProcess.Close()
        '    Me.oskProcess = Nothing
        'End If

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub DgvInspDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInspDetail.CellContentClick

        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 Then
            If (e.ColumnIndex = 0) Then 'positive
                If IsDBNull(c_InspectionDetall.Rows(e.RowIndex).Item("TL")) OrElse c_InspectionDetall.Rows(e.RowIndex).Item("TL") = "0" Then
                    c_InspectionDetall.Rows(e.RowIndex).Item("Scrap") = 0
                    Exit Sub
                End If

                If IsDBNull(c_InspectionDetall.Rows(e.RowIndex).Item("Scrap")) Then
                    c_InspectionDetall.Rows(e.RowIndex).Item("Scrap") = 0
                End If
                If (c_InspectionDetall.Rows(e.RowIndex).Item("Scrap") + (1 * CInt(ComboBoxMultiplier.Text))) <= c_InspectionDetall.Rows(e.RowIndex).Item("TL") Then
                    c_InspectionDetall.Rows(e.RowIndex).Item("Scrap") += 1 * CInt(ComboBoxMultiplier.Text)
                Else
                    c_InspectionDetall.Rows(e.RowIndex).Item("Scrap") = c_InspectionDetall.Rows(e.RowIndex).Item("TL")
                End If

                'Dim data = senderGrid.Columns(e.ColumnIndex)
                'TODO - Button Clicked - Execute Code Here
            ElseIf (e.ColumnIndex = 1) Then 'negative
                If IsDBNull(c_InspectionDetall.Rows(e.RowIndex).Item("Scrap")) OrElse c_InspectionDetall.Rows(e.RowIndex).Item("Scrap") - (1 * CInt(ComboBoxMultiplier.Text)) <= 0 Then
                    c_InspectionDetall.Rows(e.RowIndex).Item("Scrap") = 0
                    Exit Sub
                End If
                c_InspectionDetall.Rows(e.RowIndex).Item("Scrap") -= 1 * CInt(ComboBoxMultiplier.Text)
            End If
        End If

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub TextBoxFrameScrap_Click(sender As Object, e As EventArgs) Handles TextBoxFrameScrap.Click
        KeyRemark.ShowkeyBoard(TextBoxFrameScrap)
    End Sub
End Class