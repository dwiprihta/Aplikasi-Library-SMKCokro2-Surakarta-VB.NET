Imports MySql.Data.MySqlClient
Public Class input_rak
    'TAMPIL DATA
    Sub tampildata()
        Call bukadb()
        da = New MySqlDataAdapter("select * from rak", conn)
        ds = New DataSet
        da.Fill(ds, "rak")
        DataGridView1.DataSource = ds.Tables("rak")
        DataGridView1.ReadOnly = True
        With DataGridView1
            .Columns(0).HeaderText = "ID RAK"
            .Columns(1).HeaderText = "NAMA RAK"
            .Columns(0).Width = 100
            .Columns(1).Width = 230
        End With
    End Sub
    'BERSIH
    Sub bersih()
        Textbox1.Text = ""
        textid.Text = ""
    End Sub
    'TAMBAH
    Sub tambah()
        Textbox1.Enabled = True
        Textbox1.Focus()
    End Sub
    Private Sub input_rak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampildata()
        Call bersih()
    End Sub
    'PINDAH DATA'
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Textbox1.Text = DataGridView1.CurrentRow.Cells(1).Value
        textid.Text = DataGridView1.CurrentRow.Cells(0).Value
        Textbox1.Enabled = True
    End Sub
    'TAMBAH
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call tambah()
    End Sub
    'SIMPAN
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call bukadb()
        cmd = New MySqlCommand("select * from rak where nama_rak='" & Textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            MsgBox("DATA YANG ANDA MASUKAN MUNGKKIN SUDAH ADA", MsgBoxStyle.Exclamation, "PERINGATAN")
        ElseIf Textbox1.Text = "" Then
            MsgBox("LENGKAPI DAHULU DATA YANG AKAN ANDA SIMPAN", MsgBoxStyle.Exclamation, "PERINGATAN")
        Else
            Try
                Call bukadb()
                simpan = "insert into rak (nama_rak)values(@p1)"
                cmd = conn.CreateCommand
                With cmd
                    .CommandText = simpan
                    .Connection = conn
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@p1", (Textbox1.Text))
                    .ExecuteNonQuery()
                    MsgBox("DATA ANDA BERHASIL DIINPUT", MsgBoxStyle.Information, "SUKSES")
                    Call bersih()
                    Call tampildata()
                End With
            Catch ex As Exception
                MsgBox("DATA ANDA GAGAL KAMI INPUTKAN", MsgBoxStyle.Exclamation, "PERINGATAN")
            End Try
        End If
    End Sub
    'EDIT
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Textbox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN ANDA EDIT", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        Else
            Call bukadb()
            edit = "UPDATE rak SET nama_rak='" & Textbox1.Text & "' where id_rak='" & textid.Text & "'"
            cmd = New MySqlCommand(edit, conn)
            cmd.ExecuteNonQuery()
            MsgBox("DATA ANDA BERHASIL DIUBAH", MsgBoxStyle.Information, "SUKSES")
            Call bersih()
            Call tampildata()
        End If
    End Sub
    'HAPUS
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Textbox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN ANDA HAPUS", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        Else
            If MsgBox("APA ANDA YAKIN AKAN MENGHAPUS DATA INI?", MsgBoxStyle.YesNo, "PERINGHATAN PENGHAPUSAN") = MsgBoxResult.Yes Then ' If you select yes in the MsgBox then it will close the window
                ' Close the window
                Call bukadb()
                delete = "delete from rak where id_rak='" & textid.Text & "'"
                cmd = New MySqlCommand(delete, conn)
                cmd.ExecuteNonQuery()
                MsgBox("DATA ANDA BERHASIL DIHAPUS", MsgBoxStyle.Information, "SUKSES")
                Call bersih()
                Call tampildata()
            Else
                'CLSE WINDOWS
            End If
        End If
    End Sub

    Private Sub txtcari_OnTextChange(sender As Object, e As EventArgs) Handles txtcari.OnTextChange
        Call bukadb()
        Call bukadb()
        da = New MySqlDataAdapter("select * from rak where nama_rak like '%" & txtcari.text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "ok")
        DataGridView1.DataSource = ds.Tables("ok")
        DataGridView1.ReadOnly = True
    End Sub
End Class