Imports CrystalDecisions.CrystalReports.Engine
Public Class rep_kartu
   

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ReportKu As New ReportDocument
        'menentukan lokasi report yang akan ditampilkan
        ReportKu.Load("..\..\xyz.rpt")

        'nilai parameter KataKunci di ambil dari inputan txtKataKunci
        ReportKu.SetParameterValue("cetak_kartu", Textbox1.Text)

        'tampilkan ke CrystalReportViewer1
        CrystalReportViewer1.ReportSource = ReportKu
        CrystalReportViewer1.Refresh()
        Textbox1.Text = ""
    End Sub
End Class