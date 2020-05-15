Imports MySql.Data.MySqlClient
Public Class input_buku
    'LIHAT DATA
    Sub tampildata()
        koneksi.bukadb()
        da = New MySqlDataAdapter("SELECT a.id_buku,a.judul_buku,b.nama_kategori,a.penulis,c.nama_penerbit,a.tahun_terbit,a.tanggal_input,a.jumlah_buku,a.jumlah_halaman,d.nama_rak FROM tbl_buku a, kategori_buku b, tbl_penerbit c, rak d where a.id_kategori=b.id_kategori and a.id_penerbit=c.id_penerbit and a.id_rak=d.id_rak", conn)
        ds = New DataSet
        da.Fill(ds, "tbl_buku,kategori_buku,tbl_penerbit,rak")
        DataGridView1.DataSource = ds.Tables("tbl_buku,kategori_buku,tbl_penerbit,rak")
        DataGridView1.ReadOnly = True
        With DataGridView1
            .Columns(0).HeaderText = "ID BUKU"
            .Columns(1).HeaderText = "JUDUL BUKU"
            .Columns(2).HeaderText = "KATEGORI"
            .Columns(3).HeaderText = "PENULIS"
            .Columns(4).HeaderText = "PENERBIT"
            .Columns(5).HeaderText = "TAHUN TERBIT"
            .Columns(6).HeaderText = "TANGGAL INPUT"
            .Columns(7).HeaderText = "EXEMPLAR"
            .Columns(8).HeaderText = "JUMLAH HALAMAN"
            .Columns(9).HeaderText = "RAK"
            .Columns(0).Width = 100
            .Columns(1).Width = 200
            .Columns(2).Width = 100
            .Columns(3).Width = 200
            .Columns(9).Width = 50
            .Columns(5).Width = 75
        End With
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
    End Sub
    Sub tampildata2()
        koneksi.bukadb()
        da = New MySqlDataAdapter("SELECT a.id_buku,a.judul_buku,b.nama_kategori,a.penulis,c.nama_penerbit,a.tahun_terbit,a.tanggal_input,a.jumlah_buku,a.jumlah_halaman,d.nama_rak FROM tbl_buku a, kategori_buku b, tbl_penerbit c, rak d where a.id_kategori=b.id_kategori and a.id_penerbit=c.id_penerbit and a.id_rak=d.id_rak", conn)
        ds = New DataSet
        da.Fill(ds, "tbl_buku,kategori_buku,tbl_penerbit,rak")
        DataGridView2.DataSource = ds.Tables("tbl_buku,kategori_buku,tbl_penerbit,rak")
        DataGridView2.ReadOnly = True
        With DataGridView2
            .Columns(0).HeaderText = "ID BUKU"
            .Columns(1).HeaderText = "JUDUL BUKU"
            .Columns(2).HeaderText = "KATEGORI"
            .Columns(3).HeaderText = "PENULIS"
            .Columns(4).HeaderText = "PENERBIT"
            .Columns(5).HeaderText = "TAHUN TERBIT"
            .Columns(6).HeaderText = "TANGGAL INPUT"
            .Columns(7).HeaderText = "EXEMPLAR"
            .Columns(8).HeaderText = "JUMLAH HALAMAN"
            .Columns(9).HeaderText = "RAK"
            .Columns(0).Width = 100
            .Columns(1).Width = 230
            .Columns(2).Width = 0
            .Columns(3).Width = 0
            .Columns(4).Width = 0
            .Columns(5).Width = 0
            .Columns(6).Width = 0
            .Columns(7).Width = 0
            .Columns(8).Width = 0
            .Columns(9).Width = 0
        End With
        DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
    End Sub

    'PINDAH DATA DARI DG KE FORM
    Private Sub DataGridView2_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        Textbox1.Text = DataGridView2.CurrentRow.Cells(0).Value
        Textbox2.Text = DataGridView2.CurrentRow.Cells(1).Value
        ComboBox1.Text = DataGridView2.CurrentRow.Cells(2).Value
        Textbox3.Text = DataGridView2.CurrentRow.Cells(3).Value
        ComboBox2.Text = DataGridView2.CurrentRow.Cells(4).Value
        Textbox4.Text = DataGridView2.CurrentRow.Cells(5).Value
        DateTime1.Value = DataGridView2.CurrentRow.Cells(6).Value
        Textbox5.Text = DataGridView2.CurrentRow.Cells(7).Value
        Textbox6.Text = DataGridView2.CurrentRow.Cells(8).Value
        ComboBox3.Text = DataGridView2.CurrentRow.Cells(9).Value
        Call displayedit()
    End Sub
    
    'AKTIF KOMPONEN
    Sub tambah()
        'Textbox1.Enabled = False
        ComboBox1.Enabled = True
        Textbox2.Enabled = True
        ComboBox2.Enabled = True
        Textbox3.Enabled = True
        Textbox4.Enabled = True
        Textbox5.Enabled = True
        Textbox6.Enabled = True
        ComboBox3.Enabled = True
        'DateTime1.Enabled = False
        TextBox1.Focus()
    End Sub
    Sub displayedit()
        Textbox1.Enabled = False
        ComboBox1.Enabled = True
        Textbox2.Enabled = True
        ComboBox2.Enabled = True
        Textbox3.Enabled = True
        Textbox4.Enabled = True
        Textbox5.Enabled = True
        Textbox6.Enabled = True
        ComboBox3.Enabled = True
        DateTime1.Enabled = False
        Textbox2.Focus()
    End Sub

    'MEMBERSIHKAN FORM
    Sub bersih()
        ComboBox1.Text = ""
        Textbox2.Text = ""
        ComboBox2.Text = ""
        Textbox3.Text = ""
        Textbox4.Text = ""
        Textbox5.Text = ""
        Textbox6.Text = ""
        ComboBox3.Text = ""
        DateTime1.Value = Now
        Textbox2.Focus()
    End Sub

    'COMBOBOX
    Sub opencombo1()
        Call bukadb()
        da = New MySqlDataAdapter("select id_kategori,nama_kategori from kategori_buku", conn)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            ComboBox1.DataSource = dt
            ComboBox1.ValueMember = "id_kategori"
            ComboBox1.DisplayMember = "nama_kategori"
        Catch ex As Exception
            MsgBox("DATA KATEGORI ANDA GAGAL DITAMPILKAN", MsgBoxStyle.Exclamation, "PERINGATAN!!!")
        End Try
    End Sub
    Sub opencombo2()
        Call bukadb()
        da = New MySqlDataAdapter("select id_penerbit,nama_penerbit from tbl_penerbit order by nama_penerbit", conn)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            ComboBox2.DataSource = dt
            ComboBox2.ValueMember = "id_penerbit"
            ComboBox2.DisplayMember = "nama_penerbit"
        Catch ex As Exception
            MsgBox("DATA PENERBIT GAGAL DITAMPILKAN", MsgBoxStyle.Exclamation, "PERINGATAN!!!")
        End Try
    End Sub
    Sub opencombo3()
        Call bukadb()
        da = New MySqlDataAdapter("SELECT id_rak, nama_rak from rak order by nama_rak", conn)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            ComboBox3.DataSource = dt
            ComboBox3.ValueMember = "id_rak"
            ComboBox3.DisplayMember = "nama_rak"
        Catch ex As Exception
            MsgBox("DATA RAK ANDA GAGAL DITAMPILKAN", MsgBoxStyle.Information, "INFORMASI")
        End Try
    End Sub

    'AUTONUMBER
    Sub autonum()
        Try
            Call bukadb()
            cmd = New MySqlCommand("select * from tbl_buku order by id_buku DESC",
            conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                Textbox1.Text = "BK" + "0001"
            Else
                Textbox1.Text = Val(Microsoft.VisualBasic.Mid(dr.Item("id_buku").ToString, 4, 3)) + 1
                If Len(Textbox1.Text) = 1 Then
                    Textbox1.Text = "BK000" & Textbox1.Text & ""
                ElseIf Len(Textbox1.Text) = 2 Then
                    Textbox1.Text = "BK00" & Textbox1.Text & ""
                ElseIf Len(Textbox1.Text) = 3 Then
                    Textbox1.Text = "BK0" & Textbox1.Text & ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi Kesalahan : " & ex.Message, "Pesan Peringatan",
            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'LOAD
    Private Sub input_buku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampildata()
        Call tampildata2()
        Call opencombo1()
        Call opencombo2()
        Call opencombo3()
        Call autonum()
    End Sub
    'TAMBAH
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call autonum()
        Call tambah()
        Call bersih()
    End Sub
    'SIMPAN
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call bukadb()
        cmd = New MySqlCommand("select id_buku from tbl_buku where id_buku='" & Textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            MsgBox("DATA YANG ANDA INPUTKAN MUNGKIN SUDAAH ADA", MsgBoxStyle.Information, "PERINGATAN!!!")
        ElseIf Textbox2.Text = "" Or Textbox1.Text = "" Then
            MsgBox("LENGKAPI DAHULU DATA ANDA", MsgBoxStyle.Information, "PERINGATAN!!!")
        Else
            Call bukadb()
            Try
                simpan = "insert into tbl_buku (id_buku,judul_buku,id_kategori,penulis,id_penerbit,tahun_terbit,tanggal_input,jumlah_buku,jumlah_halaman,id_rak)values('" & Textbox1.Text & "','" & Textbox2.Text & "','" & ComboBox1.SelectedValue & "','" & Textbox3.Text & "','" & ComboBox2.SelectedValue & "','" & Textbox4.Text & "','" & Format(DateTime1.Value, "yyyy-MM-dd") & "','" & Textbox5.Text & "','" & Textbox6.Text & "','" & ComboBox3.SelectedValue & "')"
                cmd = New MySqlCommand(simpan, conn)
                cmd.ExecuteNonQuery()
                MsgBox("DATA ANDA BERHASIL DIINPUT", MsgBoxStyle.Information, "SUKSES")
                Call autonum()
                Call bersih()
                Call tampildata()
                Call tampildata2()
            Catch ex As Exception
                MsgBox("DATA ANDA GAGAL KAMI INPUTKAN", MsgBoxStyle.Exclamation, "PERINGATAN!!!")
            End Try
        End If
    End Sub
    'EDIT
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Textbox2.Text = "" Then
            MsgBox("PILIH DAHULU DATA DARI DATABASE UNTUK EDIT", MsgBoxStyle.Information, "PERHATIAN !!!")
        Else
            Call bukadb()
            Try
                edit = "update tbl_buku set judul_buku='" & Textbox2.Text & "',id_kategori='" & ComboBox1.SelectedValue & "',penulis='" & Textbox3.Text & "',id_penerbit='" & ComboBox2.SelectedValue & "',tahun_terbit='" & Textbox4.Text & "',tanggal_input='" & Format(DateTime1.Value, "yyyy-MM-dd") & "',jumlah_buku='" & Textbox5.Text & "',jumlah_halaman='" & Textbox6.Text & "',id_rak='" & ComboBox3.SelectedValue & "' where id_buku='" & Textbox1.Text & "'"
                cmd = New MySqlCommand(edit, conn)
                cmd.ExecuteNonQuery()
                MsgBox("DATA ANDA BERHASIL DIUBAH", MsgBoxStyle.Information, "SUKSES")
                Call bersih()
                Call tampildata()
                Call tampildata2()
                Call autonum()
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub
    'HAPUS
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Textbox2.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN DIHAPUS", MsgBoxStyle.Exclamation, "PERINGATAN")
        Else
            Try
                Call bukadb()
                If MsgBox("APAKAH ANDA YAKIN MENGHAPUS DATA INI", MsgBoxStyle.YesNoCancel, "PERINGATAN") = MsgBoxResult.Yes Then
                    delete = "DELETE FROM tbl_buku WHERE id_buku='" & Textbox1.Text & "'"
                    cmd = New MySqlCommand(delete, conn)
                    cmd.ExecuteNonQuery()
                MsgBox("DATA ANDA BERHASIL DIHAPUS", MsgBoxStyle.Information, "SUKSES")
                Call bersih()
                Call tampildata()
                Call tampildata2()
                Call autonum()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, "TERJADI KESALAHAN")
            End Try
        End If
    End Sub
    'CARI
    Private Sub txtcari_OnTextChange(sender As Object, e As EventArgs) Handles txtcari.OnTextChange
        If RadioButton1.Checked = True Then
            Call bukadb()
            da = New MySqlDataAdapter("select * from tbl_buku where id_buku like '%" & txtcari.text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "KETEMU")
            DataGridView1.DataSource = ds.Tables("KETEMU")
            DataGridView1.ReadOnly = True
        End If
        If RadioButton2.Checked = True Then
            Call bukadb()
            da = New MySqlDataAdapter("select * from tbl_buku where judul_buku like '%" & txtcari.text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "DAPAT")
            DataGridView1.DataSource = ds.Tables("DAPAT")
            DataGridView1.ReadOnly = True
        End If
    End Sub
   
    'CARI 2
    Private Sub BunifuTextbox1_OnTextChange(sender As Object, e As EventArgs) Handles BunifuTextbox1.OnTextChange
        Call bukadb()
        da = New MySqlDataAdapter("select * from tbl_buku where id_buku like '%" & BunifuTextbox1.text & "%' or judul_buku like '%" & BunifuTextbox1.text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "HEM")
        DataGridView2.DataSource = ds.Tables("HEM")
        DataGridView2.ReadOnly = True
    End Sub

    'VALIDASI INPUTAN ANGKA
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textbox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textbox5.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textbox6.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class
