<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEspejos
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
        Me.btnGuarVert = New System.Windows.Forms.Button()
        Me.btnGuardHoriz = New System.Windows.Forms.Button()
        Me.btnEspejo = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pb3 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pb2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pb4 = New System.Windows.Forms.PictureBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        CType(Me.pb3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.pb4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGuarVert
        '
        Me.btnGuarVert.Location = New System.Drawing.Point(508, 431)
        Me.btnGuarVert.Name = "btnGuarVert"
        Me.btnGuarVert.Size = New System.Drawing.Size(132, 23)
        Me.btnGuarVert.TabIndex = 26
        Me.btnGuarVert.Text = "Guarrdar Vertical"
        Me.btnGuarVert.UseVisualStyleBackColor = True
        '
        'btnGuardHoriz
        '
        Me.btnGuardHoriz.Location = New System.Drawing.Point(508, 373)
        Me.btnGuardHoriz.Name = "btnGuardHoriz"
        Me.btnGuardHoriz.Size = New System.Drawing.Size(132, 23)
        Me.btnGuardHoriz.TabIndex = 25
        Me.btnGuardHoriz.Text = " Guardar Horizontal"
        Me.btnGuardHoriz.UseVisualStyleBackColor = True
        '
        'btnEspejo
        '
        Me.btnEspejo.Location = New System.Drawing.Point(356, 431)
        Me.btnEspejo.Name = "btnEspejo"
        Me.btnEspejo.Size = New System.Drawing.Size(107, 23)
        Me.btnEspejo.TabIndex = 24
        Me.btnEspejo.Text = "Aplicar Espejo"
        Me.btnEspejo.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(356, 373)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(107, 23)
        Me.btnCargar.TabIndex = 23
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.pb3)
        Me.Panel3.Location = New System.Drawing.Point(12, 343)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(325, 325)
        Me.Panel3.TabIndex = 20
        '
        'pb3
        '
        Me.pb3.Location = New System.Drawing.Point(1, 1)
        Me.pb3.Name = "pb3"
        Me.pb3.Size = New System.Drawing.Size(2, 2)
        Me.pb3.TabIndex = 0
        Me.pb3.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pb2)
        Me.Panel2.Location = New System.Drawing.Point(356, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(325, 325)
        Me.Panel2.TabIndex = 21
        '
        'pb2
        '
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
        Me.Panel1.Size = New System.Drawing.Size(325, 325)
        Me.Panel1.TabIndex = 22
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(1, 1)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(2, 2)
        Me.pb1.TabIndex = 0
        Me.pb1.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.pb4)
        Me.Panel4.Location = New System.Drawing.Point(744, 12)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(350, 325)
        Me.Panel4.TabIndex = 27
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
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(756, 431)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(136, 23)
        Me.Button8.TabIndex = 34
        Me.Button8.Text = "PREWITT SOBEL (XY)"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(756, 402)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(136, 23)
        Me.Button7.TabIndex = 32
        Me.Button7.Text = "PREWITT SOBREL (Y)"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(756, 373)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(136, 23)
        Me.Button6.TabIndex = 33
        Me.Button6.Text = "PREWITT SOBEL (X)"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(962, 402)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(132, 23)
        Me.btnGuardar.TabIndex = 31
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(368, 648)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "JORGE L. CASTRO"
        '
        'frmEspejos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 682)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnGuarVert)
        Me.Controls.Add(Me.btnGuardHoriz)
        Me.Controls.Add(Me.btnEspejo)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmEspejos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Espejo - Prewitt Sobel"
        Me.Panel3.ResumeLayout(False)
        CType(Me.pb3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.pb4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGuarVert As Button
    Friend WithEvents btnGuardHoriz As Button
    Friend WithEvents btnEspejo As Button
    Friend WithEvents btnCargar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pb3 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pb2 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pb1 As PictureBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents pb4 As System.Windows.Forms.PictureBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
