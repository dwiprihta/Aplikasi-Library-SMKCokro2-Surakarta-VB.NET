Imports System.Data.OleDb
Imports System.IO
Imports System.Text


Public Class exporttotxt


Dim conn As OleDbConnection
Dim da As OleDbDataAdapter
Dim ds As DataSet
Dim cmd As OleDbCommand
Dim dr As OleDbDataReader

 

Sub koneksidb()
conn = New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=dht.mdb")
conn.Open()
End Sub

 

Private Sub exporttotxt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
Label1.Text = ""
Call koneksidb()
da = New OleDbDataAdapter("select * from TBLtest", conn)
ds = New DataSet
da.Fill(ds)
DGV.DataSource = ds.Tables(0)
DGV.ReadOnly = True
'TextBox2.Text = DGV.RowCount - 1
End Sub

 

Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
SaveFileDialog1.Filter = "*.txt|*.txt"
SaveFileDialog1.ShowDialog()
Label1.Text = SaveFileDialog1.FileName
End Sub

 

Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

If Label1.Text = "" Then
MsgBox("tentukan nama file dan lokasinya")
SaveFileDialog1.Filter = "*.txt|*.txt"
SaveFileDialog1.ShowDialog()
Label1.Text = SaveFileDialog1.FileName
Exit Sub
End If

Call koneksidb()
Dim hasil As New DataTable
'da = New OleDbDataAdapter(TextBox1.Text, conn)
da = New OleDbDataAdapter("select * from TBLtest", conn)
da.Fill(hasil)
conn.Close()

Dim writer As New StreamWriter(Label1.Text)
Try
Dim sb As New StringBuilder

For Each row As DataRow In hasil.Rows
sb = New StringBuilder
For Each col As DataColumn In hasil.Columns
sb.Append(row(col.ColumnName) & ",")
Next
writer.WriteLine(sb.ToString())
Next
Catch ex As Exception
Throw ex
Finally
If Not writer Is Nothing Then writer.Close()
End Try

MsgBox("konversi ke file txt sukses")
If MessageBox.Show("buka file hasil konversi...", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
System.Windows.Forms.Help.ShowHelp(Me, Label1.Text)
Me.Close()
Else
Label1.Text = ""
End If
End Sub

 

Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
If e.KeyCode = Keys.Enter Then
Try
Call koneksidb()
da = New OleDbDataAdapter(TextBox1.Text, conn)
ds = New DataSet
da.Fill(ds)
DGV.DataSource = ds.Tables(0)
DGV.ReadOnly = True
conn.Close()
Catch ex As Exception
MsgBox(ex.Message)
End Try
End If
End Sub

End Class


 