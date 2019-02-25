

Partial Public Class DBxDataSet
    Partial Public Class WIPINSToatalDataTable
        Private Sub WIPINSToatalDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.CountNightColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Public Class LotAlarmQtyDataTable
        Private Sub LotAlarmQtyDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.ProcessColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
