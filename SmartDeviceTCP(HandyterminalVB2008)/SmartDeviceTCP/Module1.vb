Imports System.Data
Imports System.Data.SqlClient
Module Module1
    Public HostIP As [String]
    Public OPNo As String
    Public QRCode252 As String
    Public SendStatus As String
    Public TableNumber As String
    Public LotNo As String
    Public PKG As String
    Public DeviceName As String
    Public formStatus As String
    Public Enum Status
        Ok
        Cancel
        EndLot
        ScanOP
        ScanQR
        Running
        PleaseSetMachine
        TimeOut
    End Enum
    Friend conn As New SqlConnection("Data Source=172.16.0.102;User ID=dbxuser;Initial Catalog=SECSGEM;")
    Friend cmd As New SqlCommand
    Friend sql As String
    Friend Sub connect_open()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Friend Function cmd_excuteScalar() As SqlDataReader
        connect_open()
        cmd = New SqlCommand(sql, conn)
        Return cmd.ExecuteReader
    End Function
    Friend Function cmd_ExecuteNonQuery() As Integer
        connect_open()
        cmd = New SqlCommand(sql, conn)
        Return cmd.ExecuteNonQuery
    End Function
End Module
