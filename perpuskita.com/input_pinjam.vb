Imports MySql.Data.MySqlClient
Public Class input_pinjam

    'TAMPIL
    Sub tampil()
        Call bukadb()
        da = New MySqlDataAdapter("SELECT a.id_pinjam,d.nama_mhs,c.judul_buku,a.jumlah_item,b.tgl_pinjam,b.tgl_kembali FROM detil_pinjam a,pinjam b,tbl_buku c,anggota d where a.id_pinjam=b.id_pinjam and a.nim=d.nim and c.id_buku=a.id_buku ORDER BY id_pinjam desc", conn)
        ds = New DataSet
        da.Fill(ds, "detil_pinjam,pinjam,tbl_buku,anggota")
        DataGridView1.DataSource = ds.Tables("detil_pinjam,pinjam,tbl_buku,anggota")
        DataGridView1.ReadOnly = True
        With DataGridView1
            .Columns(0).HeaderText = "NO TRANSAKSI"
            .Columns(1).HeaderText = "NAMA PEMINJAM"
            .Columns(2).HeaderText = "JUDUL BUKU"
            .Columns(3).HeaderText = "JUMLAH ITEM"
            .Columns(4).HeaderText = "TANGGAL PINJAM"
            .Columns(5).HeaderText = "TANGGAL PENGEMBALIAN"
            .Columns(0).Width = 100
            .Columns(1).Width = 250
            .Columns(2).Width = 250
            .Columns(3).Width = 50
            .Columns(4).Width = 100
            .Columns(5).Width = 100

        End With
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
    End Sub

    'BERSIH
    Sub bersih()
        Textbox1.Text = ""
        Textbox2.Text = ""
        Textbox1.Text = ""
        Textbox2.Text = ""
        'item.Text = ""
        text1.Text = ""
        text2.Text = ""
        text3.Text = ""
        text4.Text = ""
        DataGridView2.Rows.Clear()
    End Sub

    'ISI JUDUL BUKU
    Sub ambiljdlbuku()
        Call bukadb()
        
        cmd = New MySqlCommand("select * from tbl_buku WHERE id_buku= '" & text1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            text2.Text = dr.Item(1)
            text3.Text = dr.Item(7)
            text4.Text = text3.Text - item.Text
        Else
            '
        End If
    End Sub
    'INPUT DATA DARI DATAGRIDVIEW
    Private Sub text1_OnValueChanged(sender As Object, e As EventArgs) Handles text1.OnValueChanged
        Call ambiljdlbuku()
    End Sub

    'ISI NAMA PEMINJAM
    Sub ambilnamapnjm()
        Call bukadb()
        cmd = New MySqlCommand("select nama_mhs from anggota where nim='" & Textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            Textbox2.Text = dr.Item(0)
        Else
            Textbox2.Text = ""
        End If
    End Sub
    'AMBIL IDENTITAS PEMINJAM
    Private Sub Textbox3_OnValueChanged(sender As Object, e As EventArgs) Handles Textbox1.OnValueChanged
        Call ambilnamapnjm()
    End Sub

    'HITUNG ITEM
    Sub hitungItem()
        Dim cari As Integer = 0
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            cari = cari + DataGridView2.Rows(i).Cells(2).Value
            item.Text = cari
        Next
    End Sub
    'AUTONUMBER
    Sub autonum()
        Try
            Call bukadb()
            cmd = New MySqlCommand("select * from pinjam order by id_pinjam DESC",
            conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TEXTBOX3.Text = "PJ" + "0001"
            Else
                TEXTBOX3.Text = Val(Microsoft.VisualBasic.Mid(dr.Item("id_pinjam").ToString, 4, 3)) + 1
                If Len(TEXTBOX3.Text) = 1 Then
                    TEXTBOX3.Text = "PJ000" & TEXTBOX3.Text & ""
                ElseIf Len(TEXTBOX3.Text) = 2 Then
                    TEXTBOX3.Text = "PJ00" & TEXTBOX3.Text & ""
                ElseIf Len(TEXTBOX3.Text) = 3 Then
                    TEXTBOX3.Text = "PJ0" & TEXTBOX3.Text & ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi Kesalahan : " & ex.Message, "Pesan Peringatan",
            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'LOAD
    Private Sub input_pinjam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call bersih()
        Call autonum()
        Call tampil()
        item.Text = 1
        DateTime2.Value = (DateAdd(DateInterval.Day, 7, DateTime1.Value))
    End Sub

    'BERSIHKAN SEMUA
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call bersih()
    End Sub

    'INPUT DATA DARI DATAGRIDVIEW
    Private Sub DataGridView2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellEndEdit
        If e.ColumnIndex = 0 Then
            DataGridView2.Rows(e.RowIndex).Cells(0).Value = UCase(DataGridView2.Rows(e.RowIndex).Cells(0).Value)
            Call bukadb()
            cmd = New MySqlCommand("SELECT * from tbl_buku WHERE id_buku = '" &
            DataGridView2.Rows(e.RowIndex).Cells(0).Value & "'", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                DataGridView2.Rows(e.RowIndex).Cells(1).Value = dr.Item("judul_buku")
                DataGridView2.Rows(e.RowIndex).Cells(2).Value = 1
                DataGridView2.Rows(e.RowIndex).Cells(3).Value = dr.Item("jumlah_buku")
                DataGridView2.Rows(e.RowIndex).Cells(4).Value = DataGridView2.Rows(e.RowIndex).Cells(3).Value - DataGridView2.Rows(e.RowIndex).Cells(2).Value
                'DataGridView1.Rows(e.RowIndex).Cells(5).Value = 0
                'DataGridView1.Rows(e.RowIndex).Cells(6).Value = 0
                'DataGridView1.Rows(e.RowIndex).Cells(7).Value = 0
            Else
                MsgBox("MAAF,DATA YANG ANDA MAKSUD TIDAK BISA KAMI TEMUKAN", MsgBoxStyle.Exclamation, "PERINATAN")
                DataGridView2.Focus()
            End If
        End If
        If e.ColumnIndex = 2 Then
            DataGridView2.Rows(e.RowIndex).Cells(4).Value = DataGridView2.Rows(e.RowIndex).Cells(3).Value - DataGridView2.Rows(e.RowIndex).Cells(2).Value
        End If
        Call hitungItem()

        'menghitung item
        If e.ColumnIndex = 3 Then
            DataGridView2.Rows(e.RowIndex).Cells(4).Value = DataGridView2.Rows(e.RowIndex).Cells(3).Value - DataGridView2.Rows(e.RowIndex).Cells(2).Value
        End If
        Call hitungItem()

        'hapus item
        If (DataGridView2.Rows(e.RowIndex).Cells(0).Value = "") Then
            DataGridView2.Rows(e.RowIndex).Cells(1).Value = ""
            DataGridView2.Rows(e.RowIndex).Cells(2).Value = ""
            DataGridView2.Rows(e.RowIndex).Cells(3).Value = ""
            DataGridView2.Rows(e.RowIndex).Cells(4).Value = ""
        Else
            '
        End If
    End Sub
    'SIMPAN
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Textbox1.Text = "" Or text1.Text = "" Then
            MsgBox("LENGKAPI DATA PINJAM ANDA ! ", MsgBoxStyle.Exclamation,
            "Peringatan")
        Else
            Dim simpan1 As String
            Call bukadb()
            simpan = "INSERT INTO pinjam (id_pinjam,nim,totalitem,tgl_pinjam,tgl_kembali) VALUES (@p1,@p2,@p3,@p4,@p5)"
            simpan1 = "INSERT INTO detil_pinjam (id_pinjam,nim,id_buku,jumlah_item) VALUES (@p7,@p8,@p9,@jumit)"
            edit = "UPDATE tbl_buku SET jumlah_buku=jumlah_buku-@p10 WHERE id_buku = @p11"
            cmd = conn.CreateCommand
            With cmd
                .CommandText = simpan
                .Connection = conn
                .Parameters.Add("p1", MySqlDbType.String, 20).Value = TEXTBOX3.Text
                .Parameters.Add("p2", MySqlDbType.String, 10).Value = Textbox1.Text
                .Parameters.Add("p3", MySqlDbType.UInt32).Value = item.Text
                .Parameters.Add("p4", MySqlDbType.DateTime).Value = DateTime1.Value
                .Parameters.Add("p5", MySqlDbType.DateTime).Value = DateTime2.Value
                .ExecuteNonQuery()
            End With

            ' For i As Integer = 0 To DataGridView2.Rows.Count - 2
            cmd = conn.CreateCommand
            With cmd
                .CommandText = simpan1
                .Connection = conn
                .Parameters.Add("p7", MySqlDbType.String).Value =
              TEXTBOX3.Text
                .Parameters.Add("p8", MySqlDbType.String).Value =
               Textbox1.Text
                .Parameters.Add("p9", MySqlDbType.String).Value = text1.Text
                .Parameters.Add("jumit", MySqlDbType.UInt32).Value = item.Text
                '.Parameters.Add("p9", MySqlDbType.String).Value = DataGridView2.Rows(i).Cells(0).Value
                '.Parameters.Add("jumit", MySqlDbType.UInt32).Value = DataGridView2.Rows(i).Cells(2).Value
                .ExecuteNonQuery()
            End With
            cmd = conn.CreateCommand
            With cmd
                .CommandText = edit
                .Connection = conn
                .Parameters.Add("p10", MySqlDbType.UInt32).Value = item.Text
                .Parameters.Add("p11", MySqlDbType.String).Value = text1.Text
                '.Parameters.Add("p10", MySqlDbType.UInt32).Value =
                ' DataGridView2.Rows(i).Cells(2).Value
                '.Parameters.Add("p11", MySqlDbType.String).Value =
                'DataGridView2.Rows(i).Cells(0).Value
                .ExecuteNonQuery()
            End With
            'Next
            conn.Close()
            cmd.Dispose()
            MsgBox("TRANSAKSI PEMINJAMAN BERHASIL DILAKUKAN ", MsgBoxStyle.Information,
            "INFORMATION")
            bersih()
            Call autonum()
            Call tampil()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub
    ' CARI
    Private Sub txtcari2_OnTextChange(sender As Object, e As EventArgs) Handles txtcari2.OnTextChange
        If RadioButton1.Checked = True Then
            Call bukadb()
            da = New MySqlDataAdapter("select * from v_transaksi where id_pinjam like '%" & txtcari2.text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "KETEMU")
            DataGridView1.DataSource = ds.Tables("KETEMU")
            DataGridView1.ReadOnly = True
        End If
        If RadioButton2.Checked = True Then
            Call bukadb()
            da = New MySqlDataAdapter("select * from v_transaksi where judul_buku like '%" & txtcari2.text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "KETEMU")
            DataGridView1.DataSource = ds.Tables("KETEMU")
            DataGridView1.ReadOnly = True
        End If
        If RadioButton3.Checked = True Then
            Call bukadb()
            da = New MySqlDataAdapter("select * from v_transaksi where nama_mhs  like '%" & txtcari2.text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "KETEMU")
            DataGridView1.DataSource = ds.Tables("KETEMU")
            DataGridView1.ReadOnly = True
        End If

    End Sub

    'CAR PINJAM
    'PINDAH DATA DARI DG KE FORM
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        input_kembali.Textbox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        input_kembali.idbuk.Text = DataGridView1.CurrentRow.Cells(2).Value
        Me.Close()
    End Sub

End Class