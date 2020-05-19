Imports MySql.Data.MySqlClient
Public Class cari_pinjam

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
    'PINDAH DATA DARI DG KE FORM
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        input_kembali.Textbox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        input_kembali.idbuk.Text = DataGridView1.CurrentRow.Cells(2).Value
        Me.Close()
    End Sub

    Private Sub cari_pinjam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampil()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class