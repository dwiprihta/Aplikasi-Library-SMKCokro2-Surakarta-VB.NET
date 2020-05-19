Imports MySql.Data.MySqlClient
Public Class input_penerbit
    'BERSIH
    Sub BERSIH()
        textbox5.Text = ""
        Textbox2.Text = ""
        Textbox3.Text = ""
        Textbox4.Text = ""
        Textbox2.Focus()
    End Sub
    'tambah
    Sub tambah()
        textbox5.Enabled = True
        Textbox2.Enabled = True
        Textbox3.Enabled = True
        Textbox4.Enabled = True
        Textbox2.Focus()
    End Sub
    'lihat data
    Sub lihatdata()
        Call bukadb()
        da = New MySqlDataAdapter("select * from tbl_penerbit", conn)
        ds = New DataSet
        da.Fill(ds, "tbl_penerbit")
        DataGridview1.DataSource = ds.Tables("tbl_penerbit")
        DataGridview1.ReadOnly = True
        With DataGridview1
            .Columns(0).HeaderText = "ID"
            .Columns(1).HeaderText = "NAMA"
            .Columns(2).HeaderText = "ALAMAT"
            .Columns(3).HeaderText = "TELPON"
            .Columns(4).HeaderText = "EMAIL"
            .Columns(0).Width = 50
            .Columns(1).Width = 150
            .Columns(2).Width = 150
            .Columns(3).Width = 100
            .Columns(4).Width = 100
        End With
    End Sub

    'pindah data
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Textbox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        Textbox3.Text = DataGridView1.CurrentRow.Cells(2).Value
        Textbox4.Text = DataGridView1.CurrentRow.Cells(3).Value
        textbox5.Text = DataGridView1.CurrentRow.Cells(4).Value
        Call tambah()
    End Sub

    'load
    Private Sub input_penerbit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call BERSIH()
        Call lihatdata()
    End Sub
    'tambah
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call tambah()
        Call BERSIH()
    End Sub
    'simpan
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Textbox2.Text = "" Then
            MsgBox("LENGKAPI DAHULU DATA YANG AKAN ANDA INPUTKAN", MsgBoxStyle.Exclamation, "PERIGATAN!!!")
        Else
            Call bukadb()
            simpan = "insert into tbl_penerbit (nama_penerbit,alamat_penerbit,telp_penerbit,email) values (@2,@3,@4,@5)"
            cmd = conn.CreateCommand
            With cmd
                .CommandText = simpan
                .Connection = conn
                .Parameters.Clear()
                .Parameters.AddWithValue("@2", (Textbox2.Text))
                .Parameters.AddWithValue("@3", (Textbox3.Text))
                .Parameters.AddWithValue("@4", (Textbox4.Text))
                .Parameters.AddWithValue("@5", (textbox5.Text))
                .ExecuteNonQuery()
                Call BERSIH()
                Call lihatdata()
            End With
        End If
    End Sub
    'edit
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Textbox2.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN ANDA EDIT", MsgBoxStyle.Exclamation, "PERHATIAN !!!")
        Else
            Call bukadb()
            Try
                edit = "UPDATE tbl_penerbit set nama_penerbit='" & Textbox2.Text & "',alamat_penerbit='" & Textbox3.Text & "',telp_penerbit='" & Textbox4.Text & "',email='" & textbox5.Text & "' where id_penerbit='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
                cmd = New MySqlCommand(edit, conn)
                cmd.ExecuteNonQueryAsync()
                Call BERSIH()
                Call lihatdata()
            Catch ex As Exception
                MsgBox("DATA ANDA GAGAL KAMI EDIT", MsgBoxStyle.Exclamation, "PERHATIAN !!!")
            End Try
        End If
    End Sub
    'hapus
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Textbox2.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN ANDA HAPUS", MsgBoxStyle.Exclamation, "PERHATIAN !!!")
        Else
            If MsgBox("APAKAH ANDA YAKIN AKAN MENGHAPUS DATA INI ?", MsgBoxStyle.YesNo, "PERINGATAN PENGHAPUSAN") = MsgBoxResult.Yes Then
                Call bukadb()
                Try
                    delete = "DELETE FROM tbl_penerbit where id_penerbit='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
                    cmd = New MySqlCommand(delete, conn)
                    cmd.ExecuteNonQuery()
                    Call lihatdata()
                    Call BERSIH()
                Catch ex As Exception
                    MsgBox("DATA ANDA GAGAL KAMI HAPUS", MsgBoxStyle.Exclamation, "PERHATIAN !!!")
                End Try
            Else
                'WILL NOT APP
            End If
        End If
    End Sub
    'CARI
    Private Sub txtcari2_OnTextChange(sender As Object, e As EventArgs) Handles txtcari2.OnTextChange
        Call bukadb()
        da = New MySqlDataAdapter("SELECT * FROM tbl_penerbit where nama_penerbit like '%" & txtcari2.text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "HEM")
        DataGridView1.DataSource = ds.Tables("HEM")
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs)
        rep_penerbit.Show()
    End Sub
End Class