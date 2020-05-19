Public Class index_admin
    Private Sub DATABUKUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATABUKUToolStripMenuItem.Click
        input_buku.MdiParent = Me
        input_buku.Show()
    End Sub
    Private Sub DATAANGGOTAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATAANGGOTAToolStripMenuItem.Click
        input_anggota.MdiParent = Me
        input_anggota.Show()
    End Sub

    Private Sub KATEGORIBUKUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KATEGORIBUKUToolStripMenuItem.Click
        input_kategori_buku.MdiParent = Me
        input_kategori_buku.Show()
    End Sub

    Private Sub DATAKARYAWANToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATAKARYAWANToolStripMenuItem.Click
        input_petugas.MdiParent = Me
        input_petugas.Show()
    End Sub

    Private Sub DATAPENERBITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATAPENERBITToolStripMenuItem.Click
        input_penerbit.MdiParent = Me
        input_penerbit.Show()
    End Sub

    Private Sub DATARAKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATARAKToolStripMenuItem.Click
        input_rak.MdiParent = Me
        input_rak.Show()
    End Sub

    Private Sub PToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PToolStripMenuItem.Click
        If MsgBox("APAKAH ANDA AKAN KELUAR DARI APLIKASI INI", MsgBoxStyle.YesNoCancel, "PERINGATAN") = MsgBoxResult.Yes Then
            Me.Close()
        Else
            '
        End If
    End Sub

    Private Sub DATAPINJAMToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DATAPINJAMToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DATAPINJAMToolStripMenuItem.Click
        input_pinjam.MdiParent = Me
        input_pinjam.Show()
    End Sub

    Private Sub DATAKEMBALIToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DATAKEMBALIToolStripMenuItem1.Click
        input_kembali.MdiParent = Me
        input_kembali.Show()
    End Sub

    Private Sub LAPORANTRANSAKSIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LAPORANTRANSAKSIToolStripMenuItem.Click
        rep_buku.Show()
    End Sub

    Private Sub LAPORANDATAANGGOTAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LAPORANDATAANGGOTAToolStripMenuItem.Click
        rep_anggota.Show()
    End Sub

    Private Sub DATAKEMBALIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATAKEMBALIToolStripMenuItem.Click
        rep_trans.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub LAPORANBUKUDIPINJAMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LAPORANBUKUDIPINJAMToolStripMenuItem.Click
        rep_pinjam.Show()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        input_pinjam.MdiParent = Me
        input_pinjam.Show()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        input_kembali.MdiParent = Me
        input_kembali.Show()
    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.ButtonClick

    End Sub

    Private Sub DATABUKUToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DATABUKUToolStripMenuItem1.Click
        rep_buku.Show()
    End Sub

    Private Sub DATAANGGOTAToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DATAANGGOTAToolStripMenuItem1.Click
        rep_anggota.Show()
    End Sub

    Private Sub DATATRANSAKSIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATATRANSAKSIToolStripMenuItem.Click
        rep_trans.Show()
    End Sub

    Private Sub index_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DATABUKUDIPINJAMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATABUKUDIPINJAMToolStripMenuItem.Click
        rep_pinjam.Show()
    End Sub

    Private Sub KARTUANGGOTAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KARTUANGGOTAToolStripMenuItem.Click
        rep_kartu.Show()
    End Sub
End Class
