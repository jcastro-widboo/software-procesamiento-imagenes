<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperaciones
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
        Me.pb2 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pb3 = New System.Windows.Forms.PictureBox()
        Me.btnCargarI1 = New System.Windows.Forms.Button()
        Me.btnCargarI2 = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.cbOperacion = New System.Windows.Forms.ComboBox()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.sfd1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pb3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pb1)
        Me.Panel1.Location = New System.Drawing.Point(8, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 300)
        Me.Panel1.TabIndex = 7
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(3, 3)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(1, 1)
        Me.pb1.TabIndex = 0
        Me.pb1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pb2)
        Me.Panel2.Location = New System.Drawing.Point(327, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(300, 300)
        Me.Panel2.TabIndex = 8
        '
        'pb2
        '
        Me.pb2.Location = New System.Drawing.Point(3, 3)
        Me.pb2.Name = "pb2"
        Me.pb2.Size = New System.Drawing.Size(1, 1)
        Me.pb2.TabIndex = 0
        Me.pb2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.pb3)
        Me.Panel3.Location = New System.Drawing.Point(645, 23)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(300, 300)
        Me.Panel3.TabIndex = 9
        '
        'pb3
        '
        Me.pb3.Location = New System.Drawing.Point(3, 3)
        Me.pb3.Name = "pb3"
        Me.pb3.Size = New System.Drawing.Size(1, 1)
        Me.pb3.TabIndex = 0
        Me.pb3.TabStop = False
        '
        'btnCargarI1
        '
        Me.btnCargarI1.Location = New System.Drawing.Point(103, 341)
        Me.btnCargarI1.Name = "btnCargarI1"
        Me.btnCargarI1.Size = New System.Drawing.Size(75, 23)
        Me.btnCargarI1.TabIndex = 10
        Me.btnCargarI1.Text = "CARGAR_I1"
        Me.btnCargarI1.UseVisualStyleBackColor = True
        '
        'btnCargarI2
        '
        Me.btnCargarI2.Location = New System.Drawing.Point(426, 341)
        Me.btnCargarI2.Name = "btnCargarI2"
        Me.btnCargarI2.Size = New System.Drawing.Size(75, 23)
        Me.btnCargarI2.TabIndex = 11
        Me.btnCargarI2.Text = "CARGAR_I2"
        Me.btnCargarI2.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(277, 482)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 12
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(771, 341)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(885, 580)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "SALIR"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'cbOperacion
        '
        Me.cbOperacion.FormattingEnabled = True
        Me.cbOperacion.Items.AddRange(New Object() {"1  Suma", "2  Resta", "3  Multiplicacion", "4  Division ", "5  Mascara,i2 Binaria", "6 And", "7 XOR", "8  C=(A+B)/2", "9  C=(MAX(A,B))", "10 C=(MIN(A,B))", "11 OR", "12 Complemento", "13 C=K*A+LB"})
        Me.cbOperacion.Location = New System.Drawing.Point(249, 390)
        Me.cbOperacion.Name = "cbOperacion"
        Me.cbOperacion.Size = New System.Drawing.Size(121, 21)
        Me.cbOperacion.TabIndex = 15
        '
        'ofd1
        '
        Me.ofd1.FileName = "OpenFileDialog1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(368, 580)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "JORGE L. CASTRO"
        '
        'frmOperaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 606)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbOperacion)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCargarI2)
        Me.Controls.Add(Me.btnCargarI1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmOperaciones"
        Me.Text = "frmOperaciones"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.pb3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pb2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pb3 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCargarI1 As System.Windows.Forms.Button
    Friend WithEvents btnCargarI2 As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents cbOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfd1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
