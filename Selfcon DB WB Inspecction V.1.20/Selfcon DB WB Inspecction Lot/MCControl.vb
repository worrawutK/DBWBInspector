Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.IO

<Serializable()> _
Public Class MCControl

    Private m_Data As TPData

    Sub New(ByVal mcNo As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_Data = New TPData
        m_Data.McNo = mcNo
        lbNameMC.Text = mcNo

    End Sub

    Public ReadOnly Property Data() As TPData
        Get
            Return m_Data
        End Get
    End Property

    Private m_MapMouter As DBxDataSet.MAPPKGMTDataRow
    Public Property MapMouter() As DBxDataSet.MAPPKGMTDataRow
        Get
            Return m_MapMouter
        End Get
        Set(ByVal value As DBxDataSet.MAPPKGMTDataRow)
            m_MapMouter = value
        End Set
    End Property
    Public Sub SetLotStartData()
        If m_MapMouter IsNot Nothing Then
            m_MapMouter.LotNo = SelfConData.Data.LotNo
            m_MapMouter.MCNo = "MAP-" & SelfConData.Data.McNo
            m_MapMouter.LotStartTime = SelfConData.Data.StartTime
            m_MapMouter.OPNo = SelfConData.Data.OpNo
            m_MapMouter.InputQty = SelfConData.Data.InputQty
            m_MapMouter.MCType = SelfConData.Data.MCtype
        End If
    End Sub


    Public Sub SetlotEndData()
        If m_MapMouter IsNot Nothing Then
            Dim Data As TPData = SelfConData.Data
            With Frmmain
                m_MapMouter.BubbleBe = .BubbleBeforeLabel1.Text
                m_MapMouter.BubbleAf = .BubbleAfterLabel1.Text
                m_MapMouter.CrackChippingBe = .CrarkBeforeLabel1.Text
                m_MapMouter.CrackChippingAf = .CrackAfterLabel1.Text
                m_MapMouter.AlmFrameRemainQty = CInt(.FrameRemainTextBox.Text)
                m_MapMouter.AlmRingRemainQty = CInt(.RingRemainTextBox.Text)
                m_MapMouter.AlmOtherName = .AlmNameTextBox.Text
                m_MapMouter.AlmOtherQty = CInt(.FrequencyTextBox.Text)
                m_MapMouter.AdjustClean = .AdjustLabel1.Text
                m_MapMouter.TapeCutChange = .TapeCutterLabel1.Text
                m_MapMouter.RollerChange = .RollerLabel1.Text
                m_MapMouter.TableChange = .TableChangeLabel1.Text
                m_MapMouter.ExpandTapeChange = .ExpandTapeLabel1.Text
                m_MapMouter.ExpandTapeType = .TapeTypeTextBox.Text
                m_MapMouter.ExpandTapeNo = .LotNoInspTextBox.Text
                m_MapMouter.Andon = .AndonInsLabel1.Text
                m_MapMouter.Remark = .RemarkInspTextBox.Text
                m_MapMouter.LotJudgement = .LotJodgeLabel1.Text
                m_MapMouter.GLCheck = .lbGLCheck.Text
                m_MapMouter.OPJudgement = Data.OPJudgement
                m_MapMouter.SelfConVersion = "V.1.10"
                m_MapMouter.TotalNG = .TotalNGTextBox.Text
                m_MapMouter.TotalGood = CInt(.lbInput.Text) - CInt(.TotalNGTextBox.Text)
                m_MapMouter.LotEndTime = Format(Now, "yyyy/MM/dd HH:mm:ss")

            End With
        End If

    End Sub

    Public Sub SaveData()
        Dim xfile As String = Path.Combine(Application.StartupPath & "\TempMachine", m_Data.McNo & ".bin")
        Using fs As New IO.FileStream(xfile, IO.FileMode.Create)
            Dim bs As New SoapFormatter
            bs.Serialize(fs, m_Data)
        End Using
    End Sub

    Public Sub LoadData()
        Dim xfile As String = Path.Combine(Application.StartupPath & "\TempMachine", m_Data.McNo & ".bin")
        Using fs As New IO.FileStream(xfile, IO.FileMode.Open)
            Dim bs As New SoapFormatter
            m_Data = bs.Deserialize(fs)
        End Using
    End Sub

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNameMC.Click
        OnClick(e)
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        
        If MsgBox("คุณต้องการจะลบชื่อเครื่องนี้ออกหรือไม่ ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If frmpassword.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Parent.Controls.Remove(Me)
            End If
        End If
    End Sub
    Private Sub CheckBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        OnClick(e)
    End Sub
End Class
