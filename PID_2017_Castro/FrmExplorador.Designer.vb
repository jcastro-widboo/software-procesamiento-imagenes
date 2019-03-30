<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExplorador
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.PictureBox()
        Me.lblFormato = New System.Windows.Forms.Label()
        Me.lblposicion = New System.Windows.Forms.Label()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.btncargar = New System.Windows.Forms.Button()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pb1)
        Me.Panel1.Location = New System.Drawing.Point(12, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 300)
        Me.Panel1.TabIndex = 0
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(3, 3)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(1, 1)
        Me.pb1.TabIndex = 0
        Me.pb1.TabStop = False
        '
        'lblFormato
        '
        Me.lblFormato.AutoSize = True
        Me.lblFormato.Location = New System.Drawing.Point(12, 376)
        Me.lblFormato.Name = "lblFormato"
        Me.lblFormato.Size = New System.Drawing.Size(0, 13)
        Me.lblFormato.TabIndex = 1
        '
        'lblposicion
        '
        Me.lblposicion.AutoSize = True
        Me.lblposicion.Location = New System.Drawing.Point(12, 411)
        Me.lblposicion.Name = "lblposicion"
        Me.lblposicion.Size = New System.Drawing.Size(0, 13)
        Me.lblposicion.TabIndex = 2
        '
        'txtInfo
        '
        Me.txtInfo.Location = New System.Drawing.Point(15, 454)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfo.Size = New System.Drawing.Size(307, 95)
        Me.txtInfo.TabIndex = 3
        '
        'btncargar
        '
        Me.btncargar.Location = New System.Drawing.Point(108, 318)
        Me.btncargar.Name = "btncargar"
        Me.btncargar.Size = New System.Drawing.Size(90, 32)
        Me.btncargar.TabIndex = 4
        Me.btncargar.Text = "CARGAR"
        Me.btncargar.UseVisualStyleBackColor = True
        '
        'ofd1
        '
        Me.ofd1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(685, 519)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 30)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "SALIR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(512, 523)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "JORGE L. CASTRO"
        '
        'FrmExplorador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btncargar)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.lblposicion)
        Me.Controls.Add(Me.lblFormato)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmExplorador"
        Me.Text = "FrmExplorador"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblFormato As System.Windows.Forms.Label
    Friend WithEvents lblposicion As System.Windows.Forms.Label
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents btncargar As System.Windows.Forms.Button
    Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
