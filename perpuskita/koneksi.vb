Imports MySql.Data.MySqlClient
Module koneksi
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public simpan, edit, delete As String
    Public Sub bukadb()
        Try
            Dim sqlconn As String
            sqlconn = "server=localhost;uid=root;password=;database=perpustakaan"
            conn = New MySqlConnection(sqlconn)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MsgBox("KONEKSI ANDA KE DATABASE GAGAL SILAHKAN CEK KEMBALI KONEKSI ANDA")
        End Try
    End Sub
End Module
