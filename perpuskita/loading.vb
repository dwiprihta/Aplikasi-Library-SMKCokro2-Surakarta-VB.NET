Public Class loading
    'ini asli
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 4
        If ProgressBar1.Value = 100 Then
            Timer1.Dispose()
            Me.Visible = False
            login.Show()
        End If
    End Sub

   
End Class