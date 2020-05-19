Imports MySql.Data.MySqlClient
Public Class login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'TEMPAT LOGIN
        If Textbox1.Text = "" Or Textbox2.Text = "" Then
            MsgBox("LENGKAPI DAHULU USERNAME ATAU PASSWORD ANDA", MsgBoxStyle.Exclamation, "PERINGATAN!!!")
        Else
            Call bukadb()
            cmd = New MySqlCommand("select * from petugas where username='" & Textbox1.Text & "' and password='" & Textbox2.Text & "'", conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Me.Hide()
                If dr("hak_akses").ToString = "administrator" Then
                    index_admin.Show()
                Else
                    index_admin.Show()
                End If
            Else
                MsgBox("DATA YANG ANDA INPUTKAN SALAH", MsgBoxStyle.Exclamation, "Silahkan Cek Kembali Username Atau Passwor anda")
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Close()
    End Sub
End Class