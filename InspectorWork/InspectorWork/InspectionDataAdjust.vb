Public Class InspectionDataAdjust
    Private c_InspectionItem As String
    Public Property InspectionItem() As String
        Get
            Return c_InspectionItem
        End Get
        Set(ByVal value As String)
            c_InspectionItem = value
        End Set
    End Property
    Private c_TotalNg As Integer
    Public Property TotalNg() As Integer
        Get
            Return c_TotalNg
        End Get
        Set(ByVal value As Integer)
            c_TotalNg = value
        End Set
    End Property
    Private c_Scrap As Integer
    Public Property Scrap() As Integer
        Get
            Return c_Scrap
        End Get
        Set(ByVal value As Integer)
            c_Scrap = value
        End Set
    End Property
End Class
