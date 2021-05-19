Public Class FormEndLotAdjust
    Private c_InspectionDetall As DBxDataSet.Inspection_DetailDataTable
    Sub New(data As DBxDataSet.Inspection_DetailDataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        c_InspectionDetall = data
    End Sub
    Private Sub FormEndLotAdjust_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dataTable As DataTable = New DataTable

        Dim column As DataColumn = New DataColumn
        column.ColumnName = "InspectionItem"
        column.ReadOnly = True
        dataTable.Columns.Add(column)

        Dim column2 As DataColumn = New DataColumn
        column2.ColumnName = "TotalNg"
        column2.ReadOnly = True
        dataTable.Columns.Add(column2)
        Dim NgList As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)

        NgList.Add("DB NG", 0)
        NgList.Add("WB NG", 0)
        NgList.Add("Marker NG", 0)
        NgList.Add("Inspection NG", 0)

        For Each lotdata As DBxDataSet.Inspection_DetailRow In c_InspectionDetall.Rows

            If (lotdata.IsTLNull) Then
                lotdata.TL = 0
            End If
            Select Case lotdata.INSPECTION_ITEM.ToUpper
                Case "DB NG".ToUpper, "WB NG".ToUpper, "Marker NG".ToUpper
                    NgList(lotdata.INSPECTION_ITEM) = lotdata.TL
                Case Else
                    NgList("Inspection NG") = NgList("Inspection NG") + lotdata.TL
            End Select

        Next
        For Each ngData In NgList
            Dim row As DataRow
            row = dataTable.NewRow
            row("InspectionItem") = ngData.Key
            row("TotalNg") = ngData.Value
            dataTable.Rows.Add(row)
        Next
        dgvInspDetail.DataSource = dataTable

        'Dim row As DataRow
        'row = dataTable.NewRow
        'row("Item") = ""
        'row("NgTotal") = ""

        'dataTable.Rows.Add(row)
    End Sub

    Private Sub ButtonScrap_Click(sender As Object, e As EventArgs) Handles ButtonScrap.Click
        DialogResult = DialogResult.No
    End Sub

    Private Sub ButtonPass_Click(sender As Object, e As EventArgs) Handles ButtonPass.Click
        DialogResult = DialogResult.Yes
    End Sub
End Class