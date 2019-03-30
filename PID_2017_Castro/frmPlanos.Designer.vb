<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanos
    Inherits System.Windows.Forms.Form

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pb3 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pb2 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pb4 = New System.Windows.Forms.PictureBox()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.sfd1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnCargar1 = New System.Windows.Forms.Button()
        Me.btnDescomponer = New System.Windows.Forms.Button()
        Me.btnGrabar1 = New System.Windows.Forms.Button()
        Me.btnCargar2 = New System.Windows.Forms.Button()
        Me.btnGuardar2 = New System.Windows.Forms.Button()
        Me.cbPlano = New System.Windows.Forms.ComboBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pb3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.pb4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pb1)
        Me.Panel1.Location = New System.Drawing.Point(33, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 250)
        Me.Panel1.TabIndex = 4
        '
        'pb1
        '
        Me.pb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb1.Location = New System.Drawing.Point(1, 1)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(2, 2)
        Me.pb1.TabIndex = 0
        Me.pb1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pb3)
        Me.Panel2.Location = New System.Drawing.Point(33, 353)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(250, 250)
        Me.Panel2.TabIndex = 4
        '
        'pb3
        '
        Me.pb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb3.Location = New System.Drawing.Point(1, 1)
        Me.pb3.Name = "pb3"
        Me.pb3.Size = New System.Drawing.Size(2, 2)
        Me.pb3.TabIndex = 0
        Me.pb3.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.pb2)
        Me.Panel3.Location = New System.Drawing.Point(359, 43)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(250, 250)
        Me.Panel3.TabIndex = 4
        '
        'pb2
        '
        Me.pb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb2.Location = New System.Drawing.Point(1, 1)
        Me.pb2.Name = "pb2"
        Me.pb2.Size = New System.Drawing.Size(2, 2)
        Me.pb2.TabIndex = 0
        Me.pb2.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.pb4)
        Me.Panel4.Location = New System.Drawing.Point(359, 355)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(250, 250)
        Me.Panel4.TabIndex = 4
        '
        'pb4
        '
        Me.pb4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb4.Location = New System.Drawing.Point(1, 1)
        Me.pb4.Name = "pb4"
        Me.pb4.Size = New System.Drawing.Size(2, 2)
        Me.pb4.TabIndex = 0
        Me.pb4.TabStop = False
        '
        'ofd1
        '
        Me.ofd1.FileName = "OpenFileDialog1"
        '
        'btnCargar1
        '
        Me.btnCargar1.Location = New System.Drawing.Point(33, 12)
        Me.btnCargar1.Name = "btnCargar1"
        Me.btnCargar1.Size = New System.Drawing.Size(75, 23)
        Me.btnCargar1.TabIndex = 5
        Me.btnCargar1.Text = "Cargar"
        Me.btnCargar1.UseVisualStyleBackColor = True
        '
        'btnDescomponer
        '
        Me.btnDescomponer.Location = New System.Drawing.Point(188, 12)
        Me.btnDescomponer.Name = "btnDescomponer"
        Me.btnDescomponer.Size = New System.Drawing.Size(95, 23)
        Me.btnDescomponer.TabIndex = 5
        Me.btnDescomponer.Text = "Descomponer"
        Me.btnDescomponer.UseVisualStyleBackColor = True
        '
        'btnGrabar1
        '
        Me.btnGrabar1.Location = New System.Drawing.Point(534, 12)
        Me.btnGrabar1.Name = "btnGrabar1"
        Me.btnGrabar1.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar1.TabIndex = 5
        Me.btnGrabar1.Text = "Grabar"
        Me.btnGrabar1.UseVisualStyleBackColor = True
        '
        'btnCargar2
        '
        Me.btnCargar2.Location = New System.Drawing.Point(33, 315)
        Me.btnCargar2.Name = "btnCargar2"
        Me.btnCargar2.Size = New System.Drawing.Size(75, 23)
        Me.btnCargar2.TabIndex = 5
        Me.btnCargar2.Text = "Cargar"
        Me.btnCargar2.UseVisualStyleBackColor = True
        '
        'btnGuardar2
        '
        Me.btnGuardar2.Location = New System.Drawing.Point(534, 315)
        Me.btnGuardar2.Name = "btnGuardar2"
        Me.btnGuardar2.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar2.TabIndex = 5
        Me.btnGuardar2.Text = "Grabar"
        Me.btnGuardar2.UseVisualStyleBackColor = True
        '
        'cbPlano
        '
        Me.cbPlano.FormattingEnabled = True
        Me.cbPlano.Items.AddRange(New Object() {"7", "6", "5", "4", "3", "2", "1", "0"})
        Me.cbPlano.Location = New System.Drawing.Point(303, 133)
        Me.cbPlano.Name = "cbPlano"
        Me.cbPlano.Size = New System.Drawing.Size(36, 21)
        Me.cbPlano.TabIndex = 6
        Me.cbPlano.Text = "7"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(302, 466)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(36, 23)
        Me.btnOk.TabIndex = 7
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'cb2
        '
        Me.cb2.FormattingEnabled = True
        Me.cb2.Items.AddRange(New Object() {"7", "6", "5", "4", "3", "2", "1", "0"})
        Me.cb2.Location = New System.Drawing.Point(303, 426)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(35, 21)
        Me.cb2.TabIndex = 8
        Me.cb2.Text = "7"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(59, 697)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "JORGE L. CASTRO"
        '
        'frmPlanos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 741)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cbPlano)
        Me.Controls.Add(Me.btnDescomponer)
        Me.Controls.Add(Me.btnGuardar2)
        Me.Controls.Add(Me.btnGrabar1)
        Me.Controls.Add(Me.btnCargar2)
        Me.Controls.Add(Me.btnCargar1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPlanos"
        Me.Text = "Planos de Bits"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pb3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.pb4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pb3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pb2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents pb4 As System.Windows.Forms.PictureBox
    Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfd1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnCargar1 As System.Windows.Forms.Button
    Friend WithEvents btnDescomponer As System.Windows.Forms.Button
    Friend WithEvents btnGrabar1 As System.Windows.Forms.Button
    Friend WithEvents btnCargar2 As System.Windows.Forms.Button
    Friend WithEvents btnGuardar2 As System.Windows.Forms.Button
    Friend WithEvents cbPlano As System.Windows.Forms.ComboBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents cb2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
