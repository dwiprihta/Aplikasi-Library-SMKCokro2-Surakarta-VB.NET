Imports MySql.Data.MySqlClient
Public Class input_kembali

    'BERSIH
    Sub bersih()
        Textbox1.Text = ""
        TEXTBOX3.Text = ""
        'tkembali.Text = ""
        jumlahitem.Text = ""
        texthariv.Text = "0"
        Textdenda.Text = "0"
        DateTime1.Value = Now
        DateTime2.Value = Now
        DataGridView2.Refresh()
        Textbox1.Focus()
        DataGridView2.Columns.Clear()
    End Sub

    'TAMPIL DATA
    Sub tampil()
        Call bukadb()
        '"SELECT a.id_pinjam,d.nama_mhs,c.judul_buku,a.jumlah_item,b.tgl_pinjam FROM detil_pinjam a,pinjam b,tbl_buku c,anggota d where a.id_pinjam=b.id_pinjam and a.nim=d.nim and c.id_buku=a.id_buku ORDER BY id_pinjam desc"
        da = New MySqlDataAdapter("SELECT * FROM detil_kembali", conn)
        ds = New DataSet
        da.Fill(ds, "detil_pinjam,pinjam,tbl_buku,anggota")
        DataGridView1.DataSource = ds.Tables("detil_pinjam,pinjam,tbl_buku,anggota")
        DataGridView1.ReadOnly = True
        With DataGridView1
            .Columns(0).HeaderText = "ID KEMBALI"
            .Columns(1).HeaderText = "NAMA PEMNJAM"
            .Columns(2).HeaderText = "JUDUL BUKU"
            .Columns(3).HeaderText = "JUMLAH ITEM"
            .Columns(4).HeaderText = "TANGGAL PINJAM"
            .Columns(5).HeaderText = "TANGGAL KEMBALI"
            .Columns(0).Width = 100
            .Columns(1).Width = 200
            .Columns(2).Width = 200
            .Columns(3).Width = 100
            .Columns(4).Width = 100
            .Columns(5).Width = 100
        End With
        'DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Yellow
    End Sub

    'TAMPIL DATA2
    Sub tampil2()
        Call bukadb()
        da = New MySqlDataAdapter("SELECT * from detil_kembali", conn)
        ds = New DataSet
        da.Fill(ds, "detil_kembali")
        DataGridView1.DataSource = ds.Tables("detil_kembali")
        DataGridView1.ReadOnly = True
        With DataGridView1

            .Columns(0).HeaderText = "ID TRANSAKSI"
            .Columns(1).HeaderText = "NAMA PEMINJAM"
            .Columns(2).HeaderText = "JUDUL BUKU"
            .Columns(3).HeaderText = "JUMLAH ITEM"
            .Columns(4).HeaderText = "TANGGAL KEMBALI"
            .Columns(5).HeaderText = "TANGGAL KEMBALI"
            .Columns(0).Width = 100
            .Columns(1).Width = 250
            .Columns(2).Width = 220
            .Columns(3).Width = 80
            .Columns(4).Width = 90
            .Columns(5).Width = 90
        End With
        'DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Yellow
    End Sub

    'HITUNG DENDA
    Sub hitungdd()
        texthariv.Text = DateDiff(DateInterval.Day, DateTime2.Value, Today()) & " Hari"
        texthari.Text = DateDiff(DateInterval.Day, DateTime2.Value, Today())
        If texthari.Text <= 0 Then
            Textdenda.Text = "0"
            texthari.Text = "0"
            texthariv.Text = "0 Hari"
        Else
            Textdenda.Text = "Rp " & 5000 * texthari.Text
        End If
    End Sub

    'AMBIL ID PINJAM
    Sub ambilid()
        Call bukadb()
        cmd = New MySqlCommand("select * from v_transaksi where id_pinjam='" & Textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TEXTBOX3.Text = dr.Item(1)
            DateTime1.Text = dr.Item(4)
            DateTime2.Text = dr.Item(5)
        Else
            'WKWKW
        End If
    End Sub

    'HITUNG ITEM
    Sub hitungItem()
        Dim cari As Integer = 0
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            cari = cari + DataGridView2.Rows(i).Cells(3).Value
            jumlahitem.Text = cari
        Next
    End Sub

    'TAMPILKAN DATA TRANSAKSI DI DGV
    Sub tampiltdgv()
        Call bukadb()
        'SELECT a.id_pinjam,d.nama_mhs,c.judul_buku,a.jumlah_item,b.tgl_pinjam FROM detil_pinjam a,pinjam b,tbl_buku c,anggota d where a.id_pinjam=b.id_pinjam and a.nim=d.nim and c.id_buku=a.id_buku ORDER BY id_pinjam desc
        da = New MySqlDataAdapter("select * from v_transaksi where id_pinjam like '%" & Textbox1.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "HEM")
        DataGridView2.DataSource = ds.Tables("HEM")
        DataGridView2.ReadOnly = False
        With DataGridView2
            .Columns(0).HeaderText = "ID TRANSAKSI"
            .Columns(1).HeaderText = "NAMA PEMINJAM"
            .Columns(2).HeaderText = "JUDUL BUKU"
            .Columns(3).HeaderText = "JUMLAH ITEM"
            .Columns(4).HeaderText = "TANGGAL PINJAM"
            .Columns(5).HeaderText = "TANGGAL KEMBALI"

            .Columns(0).Width = 100
            .Columns(1).Width = 200
            .Columns(2).Width = 200
            .Columns(3).Width = 100
            .Columns(4).Width = 100
            .Columns(5).Width = 100

        End With
        DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
    End Sub

    'AUTONUMBER
    'RUWET
    Private Sub input_kembali_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampil2()
        Call bukadb()
        'Call autonum()
        'Call hitungdd()
    End Sub

    Private Sub Textbox1_OnValueChanged(sender As Object, e As EventArgs) Handles Textbox1.OnValueChanged
        Call ambilid()
        Call tampiltdgv()
        Call hitungItem()
        Call hitungdd()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call bersih()
    End Sub

    'SIMPAN DATA KEMBALI
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Textbox1.Text = "" Then
            MsgBox("Nomor Pinjam di isi !!! ", MsgBoxStyle.Exclamation,
            "Peringatan")
        Else
            Dim simpan1 As String
            Call bukadb()
            'simpan = "INSERT INTO kembali (id_kembali,nim,id_buku) VALUES (@p1,@p2,@p3)"
            simpan1 = "INSERT INTO detil_kembali (id_pinjam,nim,id_buku,jumlah_item,tgl_pinjam,tgl_kembali) VALUES (@pin,@p8,@p9,@jumit,@ptin,@ptout)"
            edit = "UPDATE tbl_buku SET jumlah_buku=jumlah_buku+@p10 WHERE id_buku = @p11"

            cmd = conn.CreateCommand
            With cmd
                '.CommandText = simpan
                '.Connection = conn
                '.Parameters.Add("p1", MySqlDbType.String).Value = tkembali.Text
                '.Parameters.Add("p2", MySqlDbType.String).Value = TEXTBOX3.Text
                '.Parameters.Add("p3", MySqlDbType.UInt32).Value = idbuk.Text
                '.Parameters.Add("p4", MySqlDbType.DateTime).Value = DateTime1.Value
                '.Parameters.Add("p5", MySqlDbType.DateTime).Value = DateTime2.Value
                '.ExecuteNonQuery()
            End With
            For i As Integer = 0 To DataGridView2.Rows.Count - 2
                cmd = conn.CreateCommand
                With cmd
                    .CommandText = simpan1
                    .Connection = conn
                    '.Parameters.Add("p7", MySqlDbType.String).Value =
                    'tkembali.Text
                    .Parameters.Add("pin", MySqlDbType.String).Value =
                  Textbox1.Text
                    .Parameters.Add("p8", MySqlDbType.String).Value =
                   TEXTBOX3.Text
                    .Parameters.Add("p9", MySqlDbType.String).Value = DataGridView2.Rows(i).Cells(2).Value
                    .Parameters.Add("jumit", MySqlDbType.UInt32).Value = jumlahitem.Text
                    .Parameters.Add("ptin", MySqlDbType.DateTime).Value = DateTime1.Value
                    .Parameters.Add("ptout", MySqlDbType.DateTime).Value = DateTime2.Value
                    .ExecuteNonQuery()
                End With
                cmd = conn.CreateCommand
                With cmd
                    .CommandText = edit
                    .Connection = conn
                    .Parameters.Add("p10", MySqlDbType.UInt32).Value = jumlahitem.Text
                    .Parameters.Add("p11", MySqlDbType.String).Value =
                    DataGridView2.Rows(i).Cells(2).Value
                    .ExecuteNonQuery()
                End With
                delete = "DELETE FROM pinjam WHERE id_pinjam='" & Textbox1.Text & "'"
                cmd = New MySqlCommand(delete, conn)
                cmd.ExecuteNonQuery()

                delete = "DELETE FROM detil_pinjam WHERE id_pinjam='" & Textbox1.Text & "'"
                cmd = New MySqlCommand(delete, conn)
                cmd.ExecuteNonQuery()
            Next
            conn.Close()
            cmd.Dispose()
            'Call autonum()
            Call tampil2()
            Call hitungdd()
            If Textdenda.Text = "0" Then
                MsgBox("TRANSAKSI PENGEMBALIAN BERHASIL DILAKUKAN ", MsgBoxStyle.Information,
                 "INFORMATION")
            Else
                zzdd.Show()
            End If
            'bersih()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cari_pinjam.Show()
    End Sub

    Private Function i() As Integer
        Throw New NotImplementedException
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Textdenda.Text = "0" Then
            MsgBox("TRANSAKSI PENGEMBALIAN BERHASIL DILAKUKAN ", MsgBoxStyle.Information,
             "INFORMATION")
        Else
            zzdd.Show()
        End If
    End Sub

    

End Class