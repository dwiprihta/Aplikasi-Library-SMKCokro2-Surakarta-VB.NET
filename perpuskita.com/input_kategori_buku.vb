Imports MySql.Data.MySqlClient
Public Class input_kategori_buku
    Sub bersih()
        Textbox1.Text = ""
        Textbox1.Focus()
    End Sub
    'lihat data
    Sub lihatdata()
        Call bukadb()
        da = New MySqlDataAdapter("SELECT * from kategori_buku", conn)
        ds = New DataSet
        da.Fill(ds, "kategori_buku")
        datagridview1.DataSource = ds.Tables("kategori_buku")
        DataGridView1.ReadOnly = True
        With DataGridView1
            .Columns(0).HeaderText = "ID KATEGORI"
            .Columns(1).HeaderText = "NAMA KATEGORI"
            .Columns(0).Width = 150
            .Columns(1).Width = 200
        End With
    End Sub
    'kirim data ke textbox
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Textbox1.Text = DataGridView1.CurrentRow.Cells(1).Value
        textid.Text = DataGridView1.CurrentRow.Cells(0).Value
        Textbox1.Enabled = True
    End Sub
    'load
    Private Sub input_kategori_buku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call bersih()
        Call lihatdata()
    End Sub
    'tambah
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call bersih()
        Textbox1.Enabled = True
        Textbox1.Focus()
    End Sub
    'simpan
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call bukadb()
        cmd = New MySqlCommand("select * from kategori_buku where id_kategori='" & textid.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            MsgBox("DATA ANDA MUNGKIN SUDAH ADA DALAM DATABASE", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        ElseIf Textbox1.Text = "" Then
            MsgBox("ISI DAHULU DATA YANG AKAN ANDA INPUTKAN", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        Else
            Try
                Call bukadb()
                simpan = "INSERT INTO kategori_buku (nama_kategori) VALUES (@p1)"
                cmd = conn.CreateCommand
                With cmd
                    .CommandText = simpan
                    .Connection = conn
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@p1", (Textbox1.Text))
                    .ExecuteNonQuery()
                End With
                MsgBox("DATA ANDA BERHASIL DIINPUT", MsgBoxStyle.Information, "SUKSES")
                Call bersih()
                Call lihatdata()
            Catch ex As Exception
                MsgBox("KESALAHAN SAAT MENYIMPAN DATA", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
            End Try
        End If
    End Sub
    'edit
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Textbox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN ANDA EDIT", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        Else
            Call bukadb()
            edit = "UPDATE kategori_buku SET nama_kategori='" & Textbox1.Text & "' where id_kategori='" & textid.Text & "'"
            cmd = New MySqlCommand(edit, conn)
            cmd.ExecuteNonQuery()
            MsgBox("DATA ANDA BERHASIL DIUBAH", MsgBoxStyle.Information, "SUKSES")
            Call bersih()
            Call lihatdata()
        End If
    End Sub
    'hapus
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Textbox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN ANDA HAPUS", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        Else
            If MsgBox("APA ANDA YAKIN AKAN MENGHAPUS DATA INI?", MsgBoxStyle.YesNo, "PERINGHATAN PENGHAPUSAN") = MsgBoxResult.Yes Then ' If you select yes in the MsgBox then it will close the window
                ' Close the window
                Call bukadb()
                delete = "DELETE from kategori_buku where id_kategori='" & textid.Text & "'"
                cmd = New MySqlCommand(delete, conn)
                cmd.ExecuteNonQuery()
                MsgBox("DATA ANDA BERHASIL DIHAPUS", MsgBoxStyle.Information, "SUKSES")
                Call bersih()
                Call lihatdata()
            Else
                ' Will not close the application
            End If
        End If
    End Sub
    'lihat data
    Private Sub txtcari_OnTextChange(sender As Object, e As EventArgs) Handles txtcari.OnTextChange
        Call bukadb()
        da = New MySqlDataAdapter("select * from kategori_buku where nama_kategori like '%" & txtcari.text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "ok")
        DataGridView1.DataSource = ds.Tables("ok")
        DataGridView1.ReadOnly = True
    End Sub
End Class