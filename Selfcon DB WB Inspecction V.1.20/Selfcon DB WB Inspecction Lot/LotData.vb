Public Class LotData
    Private c_Package As String
    Public Property Package() As String
        Get
            Return c_Package
        End Get
        Set(ByVal value As String)
            c_Package = value
        End Set
    End Property
    Private c_LotId As Integer
    Public Property LotId() As Integer
        Get
            Return c_LotId
        End Get
        Set(ByVal value As Integer)
            c_LotId = value
        End Set
    End Property
    Private c_LotNo As String
    Public Property LotNo() As String
        Get
            Return c_LotNo
        End Get
        Set(ByVal value As String)
            c_LotNo = value
        End Set
    End Property
    Private c_ReqDate As DateTime
    Public Property ReqDate() As DateTime
        Get
            Return c_ReqDate
        End Get
        Set(ByVal value As DateTime)
            c_ReqDate = value
        End Set
    End Property
    Private c_RequestMode1 As String
    Public Property RequestMode1() As String
        Get
            Return c_RequestMode1
        End Get
        Set(ByVal value As String)
            c_RequestMode1 = value
        End Set
    End Property
    Private c_RequestModeName1 As String
    Public Property RequestModeName1() As String
        Get
            Return c_RequestModeName1
        End Get
        Set(ByVal value As String)
            c_RequestModeName1 = value
        End Set
    End Property
    Private c_RequestMode2 As String
    Public Property RequestMode2() As String
        Get
            Return c_RequestMode2
        End Get
        Set(ByVal value As String)
            c_RequestMode2 = value
        End Set
    End Property
    Private c_RequestModeName2 As String
    Public Property RequestModeName2() As String
        Get
            Return c_RequestModeName2
        End Get
        Set(ByVal value As String)
            c_RequestModeName2 = value
        End Set
    End Property
    Private c_MCNo As String
    Public Property MCNo() As String
        Get
            Return c_MCNo
        End Get
        Set(ByVal value As String)
            c_MCNo = value
        End Set
    End Property
    Private c_ObjectIns As String
    Public Property ObjectIns() As String
        Get
            Return c_ObjectIns
        End Get
        Set(ByVal value As String)
            c_ObjectIns = value
        End Set
    End Property
    Private c_OPNo As String
    Public Property OPNo() As String
        Get
            Return c_OPNo
        End Get
        Set(ByVal value As String)
            c_OPNo = value
        End Set
    End Property
    Private c_RequestModeRemark1 As String
    Public Property RequestModeRemark1() As String
        Get
            Return c_RequestModeRemark1
        End Get
        Set(ByVal value As String)
            c_RequestModeRemark1 = value
        End Set
    End Property
    Private c_RequestModeRemark2 As String
    Public Property RequestModeRemark2() As String
        Get
            Return c_RequestModeRemark2
        End Get
        Set(ByVal value As String)
            c_RequestModeRemark2 = value
        End Set
    End Property
    Private c_Process As String
    Public Property Process() As String
        Get
            Return c_Process
        End Get
        Set(ByVal value As String)
            c_Process = value
        End Set
    End Property
    Private c_XRayFlow As String
    Public Property XRayFlow() As String
        Get
            Return c_XRayFlow
        End Get
        Set(ByVal value As String)
            c_XRayFlow = value
        End Set
    End Property
End Class
