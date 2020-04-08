Public Class InspData
    Private c_Package As String
    Public Property Package() As String
        Get
            Return c_Package
        End Get
        Set(ByVal value As String)
            c_Package = value
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
    Private c_MachineNo As String
    Public Property MachineNo() As String
        Get
            Return c_MachineNo
        End Get
        Set(ByVal value As String)
            c_MachineNo = value
        End Set
    End Property
    Private c_Device As String
    Public Property Device() As String
        Get
            Return c_Device
        End Get
        Set(ByVal value As String)
            c_Device = value
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
    Private c_RequestMode2 As String
    Public Property RequestMode2() As String
        Get
            Return c_RequestMode2
        End Get
        Set(ByVal value As String)
            c_RequestMode2 = value
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
    Private c_RequsetModeName2 As String
    Public Property RequestModeName2() As String
        Get
            Return c_RequsetModeName2
        End Get
        Set(ByVal value As String)
            c_RequsetModeName2 = value
        End Set
    End Property
    Private c_LotStartTime As DateTime?
    Public Property LotStartTime() As DateTime?
        Get
            Return c_LotStartTime
        End Get
        Set(ByVal value As DateTime?)
            c_LotStartTime = value
        End Set
    End Property
    Private c_LotEndTime As DateTime?
    Public Property LotEndTime() As DateTime?
        Get
            Return c_LotEndTime
        End Get
        Set(ByVal value As DateTime?)
            c_LotEndTime = value
        End Set
    End Property
    Private c_LotRequestTime As DateTime?
    Public Property LotRequestTime() As DateTime?
        Get
            Return c_LotRequestTime
        End Get
        Set(ByVal value As DateTime?)
            c_LotRequestTime = value
        End Set
    End Property
    Private c_LotStatus As String
    Public Property LotStatus() As String
        Get
            Return c_LotStatus
        End Get
        Set(ByVal value As String)
            c_LotStatus = value
        End Set
    End Property
    Private c_ProcessName As String
    Public Property ProcessName() As String
        Get
            Return c_ProcessName
        End Get
        Set(ByVal value As String)
            c_ProcessName = value
        End Set
    End Property
    Private c_TotalQty As Integer
    Public Property TotalQty() As Integer
        Get
            Return c_TotalQty
        End Get
        Set(ByVal value As Integer)
            c_TotalQty = value
        End Set
    End Property
    Private c_GoodQty As Integer
    Public Property GoodQty() As Integer
        Get
            Return c_GoodQty
        End Get
        Set(ByVal value As Integer)
            c_GoodQty = value
        End Set
    End Property
    Private c_NgQty As Integer
    Public Property NgQty() As Integer
        Get
            Return c_NgQty
        End Get
        Set(ByVal value As Integer)
            c_NgQty = value
        End Set
    End Property

End Class
