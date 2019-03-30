<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerador
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
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxlFuncion = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbxActDes = New System.Windows.Forms.CheckBox()
        Me.cbxlColor = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtancho = New System.Windows.Forms.TextBox()
        Me.txtxi = New System.Windows.Forms.TextBox()
        Me.txtxs = New System.Windows.Forms.TextBox()
        Me.txtyi = New System.Windows.Forms.TextBox()
        Me.txtys = New System.Windows.Forms.TextBox()
        Me.txtalto = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.PictureBox()
        Me.sfd1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(35, 517)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(68, 23)
        Me.btnGenerar.TabIndex = 0
        Me.btnGenerar.Text = "GENERAR"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(107, 517)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ANCHO (PIX)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(80, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "X INF"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(75, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "X SUP"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(79, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Y INF"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(74, 241)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Y SUP"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "ALTO (PIX)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxlFuncion)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 275)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(147, 87)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FUNCIÓN"
        '
        'cbxlFuncion
        '
        Me.cbxlFuncion.FormattingEnabled = True
        Me.cbxlFuncion.Items.AddRange(New Object() {"Sin(x) + Cos(y)", "i + j", "Log10((i + 1) * (i + 1) / (j + 1))", "nf * nc / 4 - Sqrt((i - nf / 2) ^ 2 + (j - nc / 2) ^ 2)", "Sqrt((i - nf / 2) ^ 2 + (j - nc / 2) ^ 2)", "rectangulo  i"})
        Me.cbxlFuncion.Location = New System.Drawing.Point(20, 37)
        Me.cbxlFuncion.Name = "cbxlFuncion"
        Me.cbxlFuncion.Size = New System.Drawing.Size(105, 21)
        Me.cbxlFuncion.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbxActDes)
        Me.GroupBox2.Controls.Add(Me.cbxlColor)
        Me.GroupBox2.Location = New System.Drawing.Point(35, 383)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(147, 101)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "COLOR"
        '
        'cbxActDes
        '
        Me.cbxActDes.AutoSize = True
        Me.cbxActDes.Location = New System.Drawing.Point(19, 35)
        Me.cbxActDes.Name = "cbxActDes"
        Me.cbxActDes.Size = New System.Drawing.Size(112, 17)
        Me.cbxActDes.TabIndex = 12
        Me.cbxActDes.Text = "ACTIVAR COLOR"
        Me.cbxActDes.UseVisualStyleBackColor = True
        '
        'cbxlColor
        '
        Me.cbxlColor.FormattingEnabled = True
        Me.cbxlColor.Items.AddRange(New Object() {"tColor1", "tColor2", "tColor3", "tColor4", "tColor5", "tColor6"})
        Me.cbxlColor.Location = New System.Drawing.Point(20, 58)
        Me.cbxlColor.Name = "cbxlColor"
        Me.cbxlColor.Size = New System.Drawing.Size(105, 21)
        Me.cbxlColor.TabIndex = 11
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(592, 517)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "SALIR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtancho
        '
        Me.txtancho.Location = New System.Drawing.Point(129, 70)
        Me.txtancho.Name = "txtancho"
        Me.txtancho.Size = New System.Drawing.Size(53, 20)
        Me.txtancho.TabIndex = 11
        '
        'txtxi
        '
        Me.txtxi.Location = New System.Drawing.Point(129, 137)
        Me.txtxi.Name = "txtxi"
        Me.txtxi.Size = New System.Drawing.Size(53, 20)
        Me.txtxi.TabIndex = 12
        '
        'txtxs
        '
        Me.txtxs.Location = New System.Drawing.Point(129, 172)
        Me.txtxs.Name = "txtxs"
        Me.txtxs.Size = New System.Drawing.Size(53, 20)
        Me.txtxs.TabIndex = 13
        '
        'txtyi
        '
        Me.txtyi.Location = New System.Drawing.Point(129, 205)
        Me.txtyi.Name = "txtyi"
        Me.txtyi.Size = New System.Drawing.Size(53, 20)
        Me.txtyi.TabIndex = 14
        '
        'txtys
        '
        Me.txtys.Location = New System.Drawing.Point(129, 238)
        Me.txtys.Name = "txtys"
        Me.txtys.Size = New System.Drawing.Size(53, 20)
        Me.txtys.TabIndex = 15
        '
        'txtalto
        '
        Me.txtalto.Location = New System.Drawing.Point(129, 102)
        Me.txtalto.Name = "txtalto"
        Me.txtalto.Size = New System.Drawing.Size(53, 20)
        Me.txtalto.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pb1)
        Me.Panel1.Location = New System.Drawing.Point(222, 70)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 414)
        Me.Panel1.TabIndex = 17
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(1, 1)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(2, 2)
        Me.pb1.TabIndex = 0
        Me.pb1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(71, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(566, 31)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "GENERADOR DE IMÁGENES DIGITALES"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(339, 517)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(167, 20)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "JORGE L. CASTRO"
        '
        'frmGenerador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 567)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtalto)
        Me.Controls.Add(Me.txtys)
        Me.Controls.Add(Me.txtyi)
        Me.Controls.Add(Me.txtxs)
        Me.Controls.Add(Me.txtxi)
        Me.Controls.Add(Me.txtancho)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnGenerar)
        Me.Name = "frmGenerador"
        Me.Text = "frmGenerador"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxlFuncion As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxActDes As System.Windows.Forms.CheckBox
    Friend WithEvents cbxlColor As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtancho As System.Windows.Forms.TextBox
    Friend WithEvents txtxi As System.Windows.Forms.TextBox
    Friend WithEvents txtxs As System.Windows.Forms.TextBox
    Friend WithEvents txtyi As System.Windows.Forms.TextBox
    Friend WithEvents txtys As System.Windows.Forms.TextBox
    Friend WithEvents txtalto As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.PictureBox
    Friend WithEvents sfd1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
