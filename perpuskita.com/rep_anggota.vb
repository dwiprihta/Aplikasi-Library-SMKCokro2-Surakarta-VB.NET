Imports CrystalDecisions.CrystalReports.Engine
Public Class rep_anggota
  
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim reportku As New ReportDocument
        'menentukan posisi report
        reportku.Load("..\..\lap_anggota.rpt")

        'nilai inputan parameter diambil dari textbox
        reportku.SetParameterValue("woyo", Textbox1.Text)

        'tampilkan crystalreport ke crviewer
        CrystalReportViewer1.ReportSource = reportku
        CrystalReportViewer1.Refresh()
        Textbox1.Text = ""
    End Sub

    
End Class