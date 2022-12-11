Imports MySql.Data.MySqlClient
Imports System.Data.Odbc

Module Module1
    Public konek As OdbcConnection
    Public comm As OdbcCommand
    Public datread As OdbcDataReader
    Public datad As OdbcDataAdapter
    Public datset As DataSet
    Public str As String

    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet

    Sub koneksiodbc()
        Try
            konek = New OdbcConnection("DSN=odbctiga;MultipleActiveResultSets=True")
            If konek.State = ConnectionState.Closed Then
                konek.Open()
            End If
        Catch ex As Exception
            MsgBox("Koneksi Gagal", vbExclamation, "Koneksi Gagal")

        End Try
    End Sub
    Sub tutup()
        konek.Close()
        konek.Dispose()
    End Sub

End Module
