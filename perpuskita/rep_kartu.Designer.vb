<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rep_kartu
    Inherits DevComponents.DotNetBar.OfficeForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.xyz1 = New perpuskita.com.xyz()
        Me.lap_buku1 = New perpuskita.com.lap_buku()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Textbox1 = New ns1.BunifuMetroTextbox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = 0
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.CachedPageNumberPerDoc = 10
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = Me.xyz1
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(917, 440)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Controls.Add(Me.Textbox1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 129)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SORTIR KARTU ANGGOTA"
        '
        'Textbox1
        '
        Me.Textbox1.BackColor = System.Drawing.Color.White
        Me.Textbox1.BorderColorFocused = System.Drawing.Color.Teal
        Me.Textbox1.BorderColorIdle = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Textbox1.BorderColorMouseHover = System.Drawing.Color.Teal
        Me.Textbox1.BorderThickness = 1
        Me.Textbox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Textbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Textbox1.ForeColor = System.Drawing.Color.Teal
        Me.Textbox1.isPassword = False
        Me.Textbox1.Location = New System.Drawing.Point(7, 29)
        Me.Textbox1.Margin = New System.Windows.Forms.Padding(4)
        Me.Textbox1.Name = "Textbox1"
        Me.Textbox1.Size = New System.Drawing.Size(172, 33)
        Me.Textbox1.TabIndex = 23
        Me.Textbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkCyan
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(7, 81)
        Me.Button2.MaximumSize = New System.Drawing.Size(200, 200)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(173, 33)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "PREVIEW"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'rep_kartu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 440)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.DoubleBuffered = True
        Me.Name = "rep_kartu"
        Me.Text = "LAPORAN DATA BUKU"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lap_buku1 As perpuskita.com.lap_buku
    Friend WithEvents xyz1 As perpuskita.com.xyz
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Textbox1 As ns1.BunifuMetroTextbox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class