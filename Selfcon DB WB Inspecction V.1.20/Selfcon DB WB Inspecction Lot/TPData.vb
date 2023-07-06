<Serializable()> _
Public Class TPData

    Private _QR As String
    Public Property QR() As String
        Get
            Return _QR
        End Get
        Set(ByVal value As String)
            _QR = value
        End Set
    End Property

    Private _mcNum As String
    Public Property McNo() As String
        Get
            Return _mcNum
        End Get
        Set(ByVal value As String)
            _mcNum = value
        End Set
    End Property

    Private _OpNum As String
    Public Property OpNo() As String
        Get
            Return _OpNum
        End Get
        Set(ByVal value As String)
            _OpNum = value
        End Set
    End Property

    Private _lotNum As String
    Public Property LotNo() As String
        Get
            Return _lotNum
        End Get
        Set(ByVal value As String)
            _lotNum = value
        End Set
    End Property
    Private _InputQty As Integer
    Public Property InputQty() As Integer
        Get
            Return _InputQty
        End Get
        Set(ByVal value As Integer)
            _InputQty = value
        End Set
    End Property

    Private _Package As String
    Public Property Package() As String
        Get
            Return _Package
        End Get
        Set(ByVal value As String)
            _Package = value
        End Set
    End Property
    Private _Device As String
    Public Property Device() As String
        Get
            Return _Device
        End Get
        Set(ByVal value As String)
            _Device = value
        End Set
    End Property

    Private _GoodQty As Integer
    Public Property GoodQty() As Integer
        Get
            Return _GoodQty
        End Get
        Set(ByVal value As Integer)
            _GoodQty = value
        End Set
    End Property

    Private _NgQty As String
    Public Property NgQty() As String
        Get
            Return _NgQty
        End Get
        Set(ByVal value As String)
            _NgQty = value
        End Set
    End Property

    Private _StartTime As String
    Public Property StartTime() As String
        Get
            Return _StartTime
        End Get
        Set(ByVal value As String)
            _StartTime = value
        End Set
    End Property

    Private _EndTime As String
    Public Property EndTime() As String
        Get
            Return _EndTime
        End Get
        Set(ByVal value As String)
            _EndTime = value
        End Set
    End Property

    Private _BubbleBefore As String
    Public Property BubbleBefore() As String
        Get
            Return _BubbleBefore
        End Get
        Set(ByVal value As String)
            _BubbleBefore = value
        End Set
    End Property
    Private _BubbleAfter As String
    Public Property BubbleAfter() As String
        Get
            Return _BubbleAfter
        End Get
        Set(ByVal value As String)
            _BubbleAfter = value
        End Set
    End Property

    Private _CrackBefore As String
    Public Property CrackBefore() As String
        Get
            Return _CrackBefore
        End Get
        Set(ByVal value As String)
            _CrackBefore = value
        End Set
    End Property

    Private _CrackAfter As String
    Public Property CrackAfter() As String
        Get
            Return _CrackAfter
        End Get
        Set(ByVal value As String)
            _CrackAfter = value
        End Set
    End Property

    Private _MajorAlmRing As Integer
    Public Property MajorAlmRing() As Integer
        Get
            Return _MajorAlmRing
        End Get
        Set(ByVal value As Integer)
            _MajorAlmRing = value
        End Set
    End Property

    Private _MajorAlmFrame As Integer
    Public Property MajorAlmFrame() As Integer
        Get
            Return _MajorAlmFrame
        End Get
        Set(ByVal value As Integer)
            _MajorAlmFrame = value
        End Set
    End Property

    Private _NameAlmOhter As String
    Public Property NameAlmOhter() As String
        Get
            Return _NameAlmOhter
        End Get
        Set(ByVal value As String)
            _NameAlmOhter = value
        End Set
    End Property
    Private _FreqAlm As Integer
    Public Property FreqAlm() As Integer
        Get
            Return _FreqAlm
        End Get
        Set(ByVal value As Integer)
            _FreqAlm = value
        End Set
    End Property
    Private _AdjClean As String
    Public Property AdjClean() As String
        Get
            Return _AdjClean
        End Get
        Set(ByVal value As String)
            _AdjClean = value
        End Set
    End Property
    Private _TapeChange As String
    Public Property TapeChange() As String
        Get
            Return _TapeChange
        End Get
        Set(ByVal value As String)
            _TapeChange = value
        End Set
    End Property

    Private _RollerChange As String
    Public Property RollerChange() As String
        Get
            Return _RollerChange
        End Get
        Set(ByVal value As String)
            _RollerChange = value
        End Set
    End Property
    Private _TableChange As String
    Public Property TableChange() As String
        Get
            Return _TableChange
        End Get
        Set(ByVal value As String)
            _TableChange = value
        End Set
    End Property
    Private _ExpandChange As String
    Public Property ExpandChange() As String
        Get
            Return _ExpandChange
        End Get
        Set(ByVal value As String)
            _ExpandChange = value
        End Set
    End Property
    Private _TapeTypeChange As String
    Public Property TapeTypeChange() As String
        Get
            Return _TapeTypeChange
        End Get
        Set(ByVal value As String)
            _TapeTypeChange = value
        End Set
    End Property
    Private _LotNoChange As String
    Public Property LotNoChange() As String
        Get
            Return _LotNoChange
        End Get
        Set(ByVal value As String)
            _LotNoChange = value
        End Set
    End Property



    Private _Andon As String
    Public Property Andon() As String
        Get
            Return _Andon
        End Get
        Set(ByVal value As String)
            _Andon = value
        End Set
    End Property

    Private _Remark As String
    Public Property Remark() As String
        Get
            Return _Remark
        End Get
        Set(ByVal value As String)
            _Remark = value
        End Set
    End Property

    Private _Lotjudge As String
    Public Property Lotjudge() As String
        Get
            Return _Lotjudge
        End Get
        Set(ByVal value As String)
            _Lotjudge = value
        End Set
    End Property
    Private _GLCheck As String
    Public Property GLCheck() As String
        Get
            Return _GLCheck
        End Get
        Set(ByVal value As String)
            _GLCheck = value
        End Set
    End Property
    Private _InitialCheckNumber As Double
    Public Property InitialCheckNumber() As Double
        Get
            Return _InitialCheckNumber
        End Get
        Set(ByVal value As Double)
            _InitialCheckNumber = value
        End Set
    End Property
    Private _InitialCheckMode As String
    Public Property InitialCheckMode() As String
        Get
            Return _InitialCheckMode
        End Get
        Set(ByVal value As String)
            _InitialCheckMode = value
        End Set
    End Property

    Private _CountMC As Integer
    Public Property CountMC() As Integer
        Get
            Return _CountMC
        End Get
        Set(ByVal value As Integer)
            _CountMC = value
        End Set
    End Property

    Private _LotInform As String
    Public Property LotInform() As String
        Get
            Return _LotInform
        End Get
        Set(ByVal value As String)
            _LotInform = value
        End Set
    End Property

    Private _MCtype As String
    Public Property MCtype() As String
        Get
            Return _MCtype
        End Get
        Set(ByVal value As String)
            _MCtype = value
        End Set
    End Property

    Private _StatusLot As String
    Public Property StatusLot() As String
        Get
            Return _StatusLot
        End Get
        Set(ByVal value As String)
            _StatusLot = value
        End Set
    End Property

    Private _OPJudgement As String
    Public Property OPJudgement() As String
        Get
            Return _OPJudgement
        End Get
        Set(ByVal value As String)
            _OPJudgement = value
        End Set
    End Property
    Sub clear()
        _lotNum = ""
        _StartTime = ""
        _OpNum = ""
        _InputQty = 0
        _Remark = ""
        _GLCheck = ""
        _OPJudgement = ""
        _NgQty = 0
        _GoodQty = 0
        _EndTime = ""
    End Sub
End Class
