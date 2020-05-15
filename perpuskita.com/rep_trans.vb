Imports CrystalDecisions.CrystalReports.Engine
Public Class rep_trans
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ReportKu As New ReportDocument
        'menentukan lokasi report yang akan ditampilkan
        ReportKu.Load("..\..\rep_trans.rpt")

        'nilai parameter TanggalMulai di ambil dari inputan dtpTanggalMulai
        ReportKu.SetParameterValue("tglawal", DateTimePicker1.Text)
        'nilai parameter TanggalSelesai di ambil dari inputan dtpTanggalSelesai
        ReportKu.SetParameterValue("tglakhir", DateTimePicker2.Text)

        'tampilkan ke CrystalReportViewer1
        CrystalReportViewer1.ReportSource = ReportKu
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class