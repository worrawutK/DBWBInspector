Public Class CommonData

    Public Enum Level
        OP
        ADMIN
    End Enum
    Private _OPID As String
    Public Property OPID() As String
        Get
            Return _OPID
        End Get
        Set(ByVal value As String)
            _OPID = value

        End Set
    End Property


    Private _UserID As String
    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(ByVal value As String)
            _UserID = value

        End Set
    End Property

    Private _InputQty As String
    Public Property InputQtyFrmVal() As String
        Get
            Return _InputQty
        End Get
        Set(ByVal value As String)
            _InputQty = value

        End Set
    End Property



    Private _UserLoginResult As Boolean
    Public Property UserLoginResult() As Boolean
        Get
            Return _UserLoginResult
        End Get
        Set(ByVal value As Boolean)
            _UserLoginResult = value

        End Set
    End Property

    Private _UserLevel As Level
    Public Property UserLevel() As Level
        Get
            Return _UserLevel
        End Get
        Set(ByVal value As Level)
            _UserLevel = value

        End Set
    End Property
    Private _QrData As String
    Public Property QrData() As String
        Get
            Return _QrData
        End Get
        Set(ByVal value As String)
            _QrData = value

        End Set
    End Property

    Private _AutoMotiveLot As Boolean
    Public Property AutoMotiveLot() As Boolean
        Get
            Return _AutoMotiveLot
        End Get
        Set(ByVal value As Boolean)
            _AutoMotiveLot = value

        End Set
    End Property

    Private _LotNo As String
    Public Property LotNo() As String
        Get
            Return _LotNo
        End Get
        Set(ByVal value As String)
            _LotNo = value

        End Set
    End Property

End Class
