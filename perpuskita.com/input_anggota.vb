Imports MySql.Data.MySqlClient
Public Class input_anggota
    'LIHAT DATA
    Sub tampildata2()
        koneksi.bukadb()
        da = New MySqlDataAdapter("SELECT * FROM anggota", conn)
        ds = New DataSet
        da.Fill(ds, "anggota")
        DataGridView1.DataSource = ds.Tables("anggota")
        DataGridView1.ReadOnly = True
        With DataGridView1
            .Columns(0).HeaderText = "NIS"
            .Columns(1).HeaderText = "NAMA"
            .Columns(2).HeaderText = "JENIS KELAMIN"
            .Columns(3).HeaderText = "KELAS"
            .Columns(4).HeaderText = "JURUSAN"
            .Columns(5).HeaderText = "TELPON"
            .Columns(6).HeaderText = "ALAMAT"
            .Columns(7).HeaderText = "TANGGAL MASUK"
            .Columns(0).Width = 100
            .Columns(1).Width = 300
            .Columns(2).Width = 100
            .Columns(3).Width = 50
            .Columns(4).Width = 200
            .Columns(5).Width = 100
            .Columns(6).Width = 100
            .Columns(7).Width = 100
        End With
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
    End Sub
    Sub tampildata()
        koneksi.bukadb()
        da = New MySqlDataAdapter("SELECT * FROM anggota", conn)
        ds = New DataSet
        da.Fill(ds, "anggota")
        DataGridView2.DataSource = ds.Tables("anggota")
        DataGridView2.ReadOnly = True
        With DataGridView2
            .Columns(0).HeaderText = "NIS"
            .Columns(1).HeaderText = "NAMA"
            .Columns(2).HeaderText = "JENIS KELAMIN"
            .Columns(3).HeaderText = "KELAS"
            .Columns(4).HeaderText = "JURUSAN"
            .Columns(5).HeaderText = "TELPON"
            .Columns(6).HeaderText = "ALAMAT"
            .Columns(7).HeaderText = "TANGGAL MASUK"
            .Columns(0).Width = 100
            .Columns(1).Width = 200
            .Columns(2).Width = 100
            .Columns(3).Width = 50
            .Columns(4).Width = 50
            .Columns(5).Width = 75
            .Columns(6).Width = 50
            .Columns(7).Width = 75
        End With
        DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
    End Sub

    'BERSIH
    Sub bersih()
        Textbox1.Text = ""
        Textbox2.Text = ""
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        ComboBox1.Text = ""
        Textbox3.Text = ""
        Textbox4.Text = ""
        DateTime1.Value = Now
        PictureBox1.Image = Nothing
        Textbox1.Focus()
    End Sub

    'AKTIF KOMPONEN
    Sub tambah()
        Textbox1.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Textbox2.Enabled = True
        Textbox3.Enabled = True
        Textbox4.Enabled = True
        DateTime1.Enabled = False
        btbrowse.Enabled = True
        Textbox1.Focus()
    End Sub

    'PINDAH DATA
    Private Sub DataGridView2_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        Dim c As New IO.MemoryStream(CType(DataGridView2.Item(8, DataGridView2.CurrentRow.Index).Value, Byte()))
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = Image.FromStream(c)
        Textbox1.Text = DataGridView2.CurrentRow.Cells(0).Value
        Textbox2.Text = DataGridView2.CurrentRow.Cells(1).Value
        If DataGridView2.CurrentRow.Cells(2).Value = "LAKI LAKI" Then
            RadioButton3.Checked = True
        Else
            RadioButton4.Checked = True
        End If
        ComboBox2.Text = DataGridView2.CurrentRow.Cells(3).Value
        ComboBox1.Text = DataGridView2.CurrentRow.Cells(4).Value
        Textbox3.Text = DataGridView2.CurrentRow.Cells(5).Value
        Textbox4.Text = DataGridView2.CurrentRow.Cells(6).Value
        DateTime1.Value = DataGridView2.CurrentRow.Cells(7).Value
        Call tambah()
    End Sub

    'COMBO
    Sub combo()
        ComboBox1.Items.Add("AKNTANSI")
        ComboBox1.Items.Add("OTOMOTIF")
        ComboBox1.Items.Add("TEKNIK KOMPUTER DAN JARINGAN")
        ComboBox1.Items.Add("TEKNIK INSTALASI TENAGA LISTRIK")
        ComboBox1.Items.Add("TEKNIK PENGOLAHAN MIGAS DAN PETROKIMIA")
        ComboBox2.Items.Add("X")
        ComboBox2.Items.Add("XI")
        ComboBox2.Items.Add("XII")
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
    'LOAD
    Private Sub input_anggota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampildata()
        Call tampildata2()
        Call combo()
    End Sub
    'TAMBAH
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call tambah()
        Call bersih()
    End Sub
    'SIMPAN
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call bukadb()   
        cmd = New MySqlCommand("select * from anggota where nim='" & Textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            MsgBox("DATA ANDA MUNGKIN SUDAH ADA DALAM DATABASE", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        ElseIf Textbox1.Text = "" Then
            MsgBox("LENGKAPI DAHULU DATA YANG AKAN ANDA EDIT", MsgBoxStyle.Information, "INFORMASI !!!")
        Else
            Call bukadb()
            simpan = "INSERT INTO anggota(nim,nama_mhs,jenkal,kelas,jurusan,kontak,alamat,tanggal_masuk,foto) VALUES (@1,@2,@3,@kelas,@4,@5,@6,@7,@foto)"
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
                .Parameters.AddWithValue("@kelas", (ComboBox2.Text))
                .Parameters.AddWithValue("@4", (ComboBox1.Text))
                .Parameters.AddWithValue("@5", (Textbox3.Text))
                .Parameters.AddWithValue("@6", (Textbox4.Text))
                .Parameters.AddWithValue("@7", (DateTime1.Value))
                .Parameters.AddWithValue("@foto", IO.File.ReadAllBytes(OpenFileDialog1.FileName))
                .ExecuteNonQuery()
            End With
            MsgBox("DATA ANDA BERHASIL DIINPUT", MsgBoxStyle.Information, "SUKSES")
            Call bersih()
            Call tampildata()
            Call tampildata2()
        End If
    End Sub
    'EDIT DATA
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call tambah()
        If Textbox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN ANDA HAPUS", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        Else
            'Try
            Call bukadb()
            Dim ms As New IO.MemoryStream
            Dim bm As Bitmap = New Bitmap(PictureBox1.Image)
            bm.Save(ms, PictureBox1.Image.RawFormat)
            Dim arrPic() As Byte = ms.GetBuffer()
            edit = "UPDATE anggota set nama_mhs=@nama_mhs,jenkal=@jenkal, kelas=@kelas,jurusan=@jurusan,kontak=@kontak,alamat=@alamat,foto=@foto WHERE nim=@nim"
            cmd = conn.CreateCommand
            With cmd
                .CommandText = edit
                .Connection = conn
                .Parameters.Clear()
                .Parameters.AddWithValue("@nim", (Textbox1.Text))
                .Parameters.AddWithValue("@nama_mhs", (Textbox2.Text))
                If RadioButton3.Checked = True Then
                    .Parameters.AddWithValue("@jenkal", (RadioButton3.Text))
                Else
                    .Parameters.AddWithValue("@jenkal", (RadioButton4.Text))
                End If
                .Parameters.AddWithValue("@kelas", (ComboBox2.Text))
                .Parameters.AddWithValue("@jurusan", (ComboBox1.Text))
                .Parameters.AddWithValue("@kontak", (Textbox3.Text))
                .Parameters.AddWithValue("@alamat", (Textbox4.Text))
                .Parameters.AddWithValue("@foto", arrPic)
                .ExecuteNonQuery()
            End With
            'Catch ex As Exception
            'MsgBox("GAGAL EDIT DATA", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
            'End Try
            MsgBox("DATA ANDA BERHASIL DIUBAH", MsgBoxStyle.Information, "SUKSES")
            Call bersih()
            Call tampildata()
        End If
    End Sub
    'HAPUS DATA
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Textbox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN ANDA HAPUS", MsgBoxStyle.Exclamation, "PERINGATAN !!!")
        Else
            If MsgBox("APAKAH ANDA YAKIN MENGHAPUS DATA INI", MsgBoxStyle.YesNoCancel, "PERINGATAN") = MsgBoxResult.Yes Then
                delete = "DELETE FROM anggota WHERE nim='" & Textbox1.Text & "'"
                cmd = New MySqlCommand(delete, conn)
                cmd.ExecuteNonQuery()
                MsgBox("DATA ANDA BERHASIL DIHAPUS", MsgBoxStyle.Information, "SUKSES")
        Call bersih()
        Call tampildata()
                Call tampildata2()
            End If
        End If
    End Sub
    'CARI
    Private Sub txtcari_OnTextChange(sender As Object, e As EventArgs) Handles txtcari.OnTextChange
        If RadioButton1.Checked = True Then
            Call bukadb()
            da = New MySqlDataAdapter("SELECT * FROM anggota WHERE nim like '%" & txtcari.text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "DAPAT")
            DataGridView1.DataSource = ds.Tables("DAPAT")
            DataGridView1.ReadOnly = True
        End If
        If RadioButton2.Checked = True Then
            da = New MySqlDataAdapter("select * from anggota where nama_mhs like '%" & txtcari.text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "YAK")
            DataGridView1.DataSource = ds.Tables("YAK")
            DataGridView1.ReadOnly = True
        End If
    End Sub
    Private Sub txtcari2_OnTextChange(sender As Object, e As EventArgs) Handles txtcari2.OnTextChange
        Call bukadb()
        da = New MySqlDataAdapter("select * from anggota where nama_mhs  like'%" & txtcari2.text & "%' OR nim like'%" & txtcari2.text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "HORE")
        DataGridView2.DataSource = ds.Tables("HORE")
        DataGridView2.ReadOnly = True
    End Sub

    Private Sub btnctk_Click(sender As Object, e As EventArgs)
        rep_anggota.Show()
    End Sub

    Private Function arrPic() As String
        Throw New NotImplementedException
    End Function

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textbox3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

End Class




















