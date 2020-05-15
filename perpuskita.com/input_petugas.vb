Imports MySql.Data.MySqlClient
Public Class input_petugas
    'combo
    Sub combo()
        ComboBox1.Items.Add("ADMINISTRASI")
        ComboBox1.Items.Add("KEMAHASISWAAN")
        ComboBox1.Items.Add("SUPERADMIN")
    End Sub

    'bersih
    Sub bersih()
        txtpoto.Text = ""
        txtid.Text = ""
        Textbox1.Text = ""
        Textbox2.Text = ""
        Textbox3.Text = ""
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        Textbox4.Text = ""
        Textbox5.Text = ""
        Textbox6.Text = ""
        ComboBox1.Text = ""
        Textbox1.Focus()
        PictureBox1.Image = Nothing

    End Sub

    'tambah
    Sub tambah()
        Textbox1.Enabled = True
        Textbox2.Enabled = True
        Textbox3.Enabled = True
        Textbox4.Enabled = True
        Textbox5.Enabled = True
        Textbox6.Enabled = True
        ComboBox1.Enabled = True
        Textbox1.Focus()
        btbrowse.Enabled = True
    End Sub
    'BUTTON 1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call tambah()
        Call bersih()
    End Sub

    'tampilkan data
    Sub tampildata()
        Call bukadb()
        da = New MySqlDataAdapter("select * from petugas", conn)
        ds = New DataSet
        da.Fill(ds, "petugas")
        DataGridView2.DataSource = ds.Tables("petugas")
        DataGridView2.ReadOnly = True
        With DataGridView2
            .Columns(0).HeaderText = "ID"
            .Columns(1).HeaderText = "NIP"
            .Columns(2).HeaderText = "NAMA"
            .Columns(3).HeaderText = "JENIS KELAMIN"
            .Columns(4).HeaderText = "TGL MASUK"
            .Columns(5).HeaderText = "ALAMAT"
            .Columns(6).HeaderText = "TELPON"
            .Columns(7).HeaderText = "USERNAME"
            .Columns(8).HeaderText = "PASSWORD"
            .Columns(9).HeaderText = "JABATAN"
            .Columns(10).HeaderText = "FOTO"
        End With
        DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
    End Sub

    'pinddahkan data dari database ke textbox
    Private Sub DataGridView2_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        Dim c As New IO.MemoryStream(CType(DataGridView2.Item(10, DataGridView2.CurrentRow.Index).Value, Byte()))
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = Image.FromStream(c)
        txtid.Text = DataGridView2.CurrentRow.Cells(0).Value
        Textbox1.Text = DataGridView2.CurrentRow.Cells(1).Value
        Textbox2.Text = DataGridView2.CurrentRow.Cells(2).Value
        If DataGridView2.CurrentRow.Cells(3).Value = "LAKI LAKI" Then
            RadioButton3.Checked = True
            RadioButton4.Checked = False
        Else
            RadioButton4.Checked = True
            RadioButton3.Checked = False
        End If
        ComboBox1.Text = DataGridView2.CurrentRow.Cells(4).Value
        Textbox3.Text = DataGridView2.CurrentRow.Cells(5).Value
        Textbox4.Text = DataGridView2.CurrentRow.Cells(6).Value
        Textbox5.Text = DataGridView2.CurrentRow.Cells(7).Value
        Textbox6.Text = DataGridView2.CurrentRow.Cells(8).Value
        ComboBox1.Text = DataGridView2.CurrentRow.Cells(9).Value
        Call tambah()
    End Sub

    'inputkan foto
    Private Sub btbrowse_Click(sender As Object, e As EventArgs) Handles btbrowse.Click
        Dim pictureLocation As String
        OpenFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|TIFF Files (*.tiff)|*.tiff"
        pictureLocation = OpenFileDialog1.FileName
        Try
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PictureBox1.Image = New Bitmap(OpenFileDialog1.FileName)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                txtpoto.Text = OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'LOAD FORM
    Private Sub input_petugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call bersih()
        Call tampildata()
        Call combo()
    End Sub

    'SIMPAN DATA
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call bukadb()
        cmd = New MySqlCommand("select * from petugas where nip='" & Textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            MsgBox("DATA ANDA MUNGKIN SUDAH ADA DALAM DATABASE", MsgBoxStyle.Information, "INFORMASI !!!")
        ElseIf txtpoto.Text = "" Or Textbox1.Text = "" Then
            MsgBox("LENGKAPI DAHULU DATA YANG AKAN ANDA SIMPAN", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        Else
            Call bukadb()
            simpan = "INSERT INTO petugas(nip,nama_petugas,jenis_kelamin,tgl_masuk,alamat,telpon,username,password,hak_akses,foto) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@image)"
            cmd = conn.CreateCommand
            With cmd
                .CommandText = simpan
                .Connection = conn
                .Parameters.Clear()
                .Parameters.AddWithValue("@1", (Textbox1.Text))
                .Parameters.AddWithValue("@2", (Textbox2.Text))
                If RadioButton3.Checked = True Then
                    .Parameters.AddWithValue("@3", (RadioButton3.Text))
                Else
                    .Parameters.AddWithValue("@3", (RadioButton4.Text))
                End If
                .Parameters.AddWithValue("@4", (DateTime1.Value))
                .Parameters.AddWithValue("@5", (Textbox3.Text))
                .Parameters.AddWithValue("@6", (Textbox4.Text))
                .Parameters.AddWithValue("@7", (Textbox5.Text))
                .Parameters.AddWithValue("@8", (Textbox6.Text))
                .Parameters.AddWithValue("@9", (ComboBox1.Text))
                .Parameters.AddWithValue("@image", IO.File.ReadAllBytes(OpenFileDialog1.FileName))
                .ExecuteNonQuery()
            End With
            MsgBox("DATA ANDA BERHASIL DIINPUT", MsgBoxStyle.Information, "SUKSES")
            Call bersih()
            Call tampildata()
        End If
    End Sub
    'HAPUS
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Textbox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG ANKAN ANDA HAPUS", MsgBoxStyle.Information, "INFORMASI !!!")
        Else
            If MsgBox("APA ANDA YAKIN AKAN MENGHAPUS DATA INI?", MsgBoxStyle.YesNo, "PERINGHATAN PENGHAPUSAN") = MsgBoxResult.Yes Then
                Call bukadb()
                Try
                    'If MsgBox("APAKAH ANDA YAKIN MENGHAPUS DATA INI", MsgBoxStyle.YesNoCancel, "PERINGATAN") = MsgBoxResult.Yes Then
                    delete = "DELETE from petugas where nip='" & Textbox1.Text & "'"
                    cmd = New MySqlCommand(delete, conn)
                    cmd.ExecuteNonQuery()
                    MsgBox("DATA ANDA BERHASIL DIHAPUS", MsgBoxStyle.Information, "SUKSES")
                    Call bersih()
                    Call tampildata()
                    'End If
                Catch ex As Exception
                    MsgBox("DATA ANDA GAGAL KAMI HAPUS", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
                End Try
            Else
                'ASDFGH
            End If
        End If
    End Sub

    'EDIT
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Textbox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN DIEDIT", MsgBoxStyle.Information, "INFORMASI!!!")
        Else
            Try
                Call bukadb()
                Dim ms As New IO.MemoryStream
                Dim bm As Bitmap = New Bitmap(PictureBox1.Image)
                bm.Save(ms, PictureBox1.Image.RawFormat)
                Dim arrPic() As Byte = ms.GetBuffer()
                edit = "UPDATE petugas SET nip=@nip,nama_petugas=@nama,jenis_kelamin=@jenkal,tgl_masuk=@tglmsk,alamat=@alamat,telpon=@telpon,username=@username,password=@password,hak_akses=@hak,foto=@Image WHERE id_petugas=@id_petugas"
                cmd = conn.CreateCommand
                With cmd
                    .CommandText = edit
                    .Connection = conn
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@id_petugas", (txtid.Text))
                    .Parameters.AddWithValue("@nip", (Textbox1.Text))
                    .Parameters.AddWithValue("@nama", (Textbox2.Text))
                    If RadioButton3.Checked = True Then
                        .Parameters.AddWithValue("@jenkal", (RadioButton3.Text))
                    Else
                        .Parameters.AddWithValue("@jenkal", (RadioButton4.Text))
                    End If
                    .Parameters.AddWithValue("@tglmsk", (DateTime1.Value))
                    .Parameters.AddWithValue("@alamat", (Textbox3.Text))
                    .Parameters.AddWithValue("@telpon", (Textbox4.Text))
                    .Parameters.AddWithValue("@username", (Textbox5.Text))
                    .Parameters.AddWithValue("@password", (Textbox6.Text))
                    .Parameters.AddWithValue("@hak", (ComboBox1.Text))
                    .Parameters.AddWithValue("@image", arrPic)
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                MsgBox("GAGAL EDIT DATA", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
            End Try
            MsgBox("DATA ANDA BERHASIL DIUBAH", MsgBoxStyle.Information, "SUKSES")
            Call bersih()
            Call tampildata()
        End If
    End Sub
    'CARI
    Private Sub txtcari2_OnTextChange(sender As Object, e As EventArgs) Handles txtcari2.OnTextChange
        If RadioButton1.Checked = True Then
            Call bukadb()
            da = New MySqlDataAdapter("SELECT * FROM petugas WHERE nip like '%" & txtcari2.text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "DAPAT")
            DataGridView2.DataSource = ds.Tables("DAPAT")
            DataGridView2.ReadOnly = True
        End If
        If RadioButton2.Checked = True Then
            Call bukadb()
            da = New MySqlDataAdapter("select * from petugas where nama_petugas like '%" & txtcari2.text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "YAK")
            DataGridView2.DataSource = ds.Tables("YAK")
            DataGridView2.ReadOnly = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textbox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
   
End Class