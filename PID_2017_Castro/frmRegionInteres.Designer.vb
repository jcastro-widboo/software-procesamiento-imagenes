<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegionInteres
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
        Me.btncarga1 = New System.Windows.Forms.Button()
        Me.btncorrelacion = New System.Windows.Forms.Button()
        Me.btnCargar2 = New System.Windows.Forms.Button()
        Me.btguardar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pb2 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pb3 = New System.Windows.Forms.PictureBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pb3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btncarga1
        '
        Me.btncarga1.Location = New System.Drawing.Point(677, 245)
        Me.btncarga1.Name = "btncarga1"
        Me.btncarga1.Size = New System.Drawing.Size(75, 23)
        Me.btncarga1.TabIndex = 0
        Me.btncarga1.Text = "Guardar"
        Me.btncarga1.UseVisualStyleBackColor = True
        '
        'btncorrelacion
        '
        Me.btncorrelacion.Location = New System.Drawing.Point(406, 245)
        Me.btncorrelacion.Name = "btncorrelacion"
        Me.btncorrelacion.Size = New System.Drawing.Size(75, 23)
        Me.btncorrelacion.TabIndex = 1
        Me.btncorrelacion.Text = "Cargar"
        Me.btncorrelacion.UseVisualStyleBackColor = True
        '
        'btnCargar2
        '
        Me.btnCargar2.Location = New System.Drawing.Point(33, 245)
        Me.btnCargar2.Name = "btnCargar2"
        Me.btnCargar2.Size = New System.Drawing.Size(75, 23)
        Me.btnCargar2.TabIndex = 2
        Me.btnCargar2.Text = "Cargar"
        Me.btnCargar2.UseVisualStyleBackColor = True
        '
        'btguardar
        '
        Me.btguardar.Location = New System.Drawing.Point(269, 245)
        Me.btguardar.Name = "btguardar"
        Me.btguardar.Size = New System.Drawing.Size(75, 23)
        Me.btguardar.TabIndex = 3
        Me.btguardar.Text = "Correlacion"
        Me.btguardar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pb1)
        Me.Panel1.Location = New System.Drawing.Point(29, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(315, 207)
        Me.Panel1.TabIndex = 4
        '
        'pb1
        '
        Me.pb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb1.Location = New System.Drawing.Point(4, 4)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(308, 200)
        Me.pb1.TabIndex = 0
        Me.pb1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pb2)
        Me.Panel2.Location = New System.Drawing.Point(408, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(359, 204)
        Me.Panel2.TabIndex = 5
        '
        'pb2
        '
        Me.pb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb2.Location = New System.Drawing.Point(4, 4)
        Me.pb2.Name = "pb2"
        Me.pb2.Size = New System.Drawing.Size(352, 197)
        Me.pb2.TabIndex = 0
        Me.pb2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pb3)
        Me.Panel3.Location = New System.Drawing.Point(406, 291)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(360, 225)
        Me.Panel3.TabIndex = 6
        '
        'pb3
        '
        Me.pb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb3.Location = New System.Drawing.Point(4, 4)
        Me.pb3.Name = "pb3"
        Me.pb3.Size = New System.Drawing.Size(353, 218)
        Me.pb3.TabIndex = 0
        Me.pb3.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 295)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "                                  "
        '
        'Guardar
        '
        Me.Guardar.Location = New System.Drawing.Point(279, 490)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Guardar.TabIndex = 8
        Me.Guardar.Text = "Button1"
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(486, 519)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "JORGE L. CASTRO"
        '
        'frmRegionInteres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 543)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btguardar)
        Me.Controls.Add(Me.btnCargar2)
        Me.Controls.Add(Me.btncorrelacion)
        Me.Controls.Add(Me.btncarga1)
        Me.Name = "frmRegionInteres"
        Me.Text = "frmRegionInteres"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.pb3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btncarga1 As System.Windows.Forms.Button
    Friend WithEvents btncorrelacion As System.Windows.Forms.Button
    Friend WithEvents btnCargar2 As System.Windows.Forms.Button
    Friend WithEvents btguardar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pb2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pb3 As System.Windows.Forms.PictureBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Guardar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
