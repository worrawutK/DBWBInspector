Public Class InspItem
    Private c_ItemName As String
    Public Property ItemName() As String
        Get
            Return c_ItemName
        End Get
        Set(ByVal value As String)
            c_ItemName = value
        End Set
    End Property
    Private c_ModeNo As String
    Public Property ModeNo() As String
        Get
            Return c_ModeNo
        End Get
        Set(ByVal value As String)
            c_ModeNo = value
        End Set
    End Property



End Class
