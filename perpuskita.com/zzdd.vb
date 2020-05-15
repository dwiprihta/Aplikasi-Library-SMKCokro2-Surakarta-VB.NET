Public Class zzdd

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub zzdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = input_kembali.texthariv.Text
        Label4.Text = input_kembali.Textdenda.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        input_kembali.bersih()
        Me.Close()
    End Sub
End Class