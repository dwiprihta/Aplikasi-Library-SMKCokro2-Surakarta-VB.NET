Imports CrystalDecisions.CrystalReports.Engine
Public Class rep_buku
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ReportKu As New ReportDocument
        'menentukan lokasi report yang akan ditampilkan
        ReportKu.Load("..\..\lap_buku.rpt")

        'nilai parameter KataKunci di ambil dari inputan txtKataKunci
        ReportKu.SetParameterValue("katakunci", Textbox1.Text)

        'tampilkan ke CrystalReportViewer1
        CrystalReportViewer1.ReportSource = ReportKu
        CrystalReportViewer1.Refresh()
    End Sub
End Class