<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMorfologia
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.sfd1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnCierre = New System.Windows.Forms.Button()
        Me.btnApertura = New System.Windows.Forms.Button()
        Me.btnErosion = New System.Windows.Forms.Button()
        Me.btnDilatacion = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pb2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(422, 368)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(76, 27)
        Me.btnGuardar.TabIndex = 29
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(12, 368)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(77, 27)
        Me.btnCargar.TabIndex = 28
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'ofd1
        '
        Me.ofd1.FileName = "OpenFileDialog1"
        '
        'btnCierre
        '
        Me.btnCierre.Location = New System.Drawing.Point(431, 422)
        Me.btnCierre.Name = "btnCierre"
        Me.btnCierre.Size = New System.Drawing.Size(102, 23)
        Me.btnCierre.TabIndex = 45
        Me.btnCierre.Text = "Cierre"
        Me.btnCierre.UseVisualStyleBackColor = True
        '
        'btnApertura
        '
        Me.btnApertura.Location = New System.Drawing.Point(294, 422)
        Me.btnApertura.Name = "btnApertura"
        Me.btnApertura.Size = New System.Drawing.Size(102, 23)
        Me.btnApertura.TabIndex = 44
        Me.btnApertura.Text = "Apertura"
        Me.btnApertura.UseVisualStyleBackColor = True
        '
        'btnErosion
        '
        Me.btnErosion.Location = New System.Drawing.Point(150, 422)
        Me.btnErosion.Name = "btnErosion"
        Me.btnErosion.Size = New System.Drawing.Size(102, 23)
        Me.btnErosion.TabIndex = 43
        Me.btnErosion.Text = "Erosion"
        Me.btnErosion.UseVisualStyleBackColor = True
        '
        'btnDilatacion
        '
        Me.btnDilatacion.Location = New System.Drawing.Point(12, 422)
        Me.btnDilatacion.Name = "btnDilatacion"
        Me.btnDilatacion.Size = New System.Drawing.Size(102, 23)
        Me.btnDilatacion.TabIndex = 42
        Me.btnDilatacion.Text = "Dilatacion"
        Me.btnDilatacion.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pb2)
        Me.Panel2.Location = New System.Drawing.Point(395, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(350, 350)
        Me.Panel2.TabIndex = 41
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
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pb1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(350, 350)
        Me.Panel1.TabIndex = 40
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(578, 425)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "JORGE L. CASTRO"
        '
        'frmMorfologia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 457)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCierre)
        Me.Controls.Add(Me.btnApertura)
        Me.Controls.Add(Me.btnErosion)
        Me.Controls.Add(Me.btnDilatacion)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCargar)
        Me.Name = "frmMorfologia"
        Me.Text = "frmMorfologia"
        Me.Panel2.ResumeLayout(False)
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfd1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnCierre As System.Windows.Forms.Button
    Friend WithEvents btnApertura As System.Windows.Forms.Button
    Friend WithEvents btnErosion As System.Windows.Forms.Button
    Friend WithEvents btnDilatacion As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pb2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
