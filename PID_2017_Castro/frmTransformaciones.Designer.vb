<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransformaciones
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
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pb2 = New System.Windows.Forms.PictureBox()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtfactor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.sfd1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnOrigenDestino = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnVecinoproximo = New System.Windows.Forms.Button()
        Me.btnbilineal = New System.Windows.Forms.Button()
        Me.btnbicubica = New System.Windows.Forms.Button()
        Me.btn_rot_or_des = New System.Windows.Forms.Button()
        Me.btn_rot_vcino_prox = New System.Windows.Forms.Button()
        Me.btn_rot_bilineal = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnguardar
        '
        Me.btnguardar.Location = New System.Drawing.Point(515, 496)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(75, 23)
        Me.btnguardar.TabIndex = 17
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pb2)
        Me.Panel2.Location = New System.Drawing.Point(395, 81)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(350, 350)
        Me.Panel2.TabIndex = 14
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
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(100, 437)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(75, 23)
        Me.btnCargar.TabIndex = 13
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pb1)
        Me.Panel1.Location = New System.Drawing.Point(23, 81)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(350, 350)
        Me.Panel1.TabIndex = 12
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(394, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Factor"
        '
        'txtfactor
        '
        Me.txtfactor.Location = New System.Drawing.Point(100, 505)
        Me.txtfactor.Name = "txtfactor"
        Me.txtfactor.Size = New System.Drawing.Size(85, 20)
        Me.txtfactor.TabIndex = 20
        Me.txtfactor.Text = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 512)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Factor"
        '
        'ofd1
        '
        Me.ofd1.FileName = "OpenFileDialog1"
        '
        'btnOrigenDestino
        '
        Me.btnOrigenDestino.Location = New System.Drawing.Point(43, 551)
        Me.btnOrigenDestino.Name = "btnOrigenDestino"
        Me.btnOrigenDestino.Size = New System.Drawing.Size(75, 48)
        Me.btnOrigenDestino.TabIndex = 21
        Me.btnOrigenDestino.Text = "Origen Destino"
        Me.btnOrigenDestino.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 476)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Ampliacion reduccion"
        '
        'btnVecinoproximo
        '
        Me.btnVecinoproximo.Location = New System.Drawing.Point(124, 551)
        Me.btnVecinoproximo.Name = "btnVecinoproximo"
        Me.btnVecinoproximo.Size = New System.Drawing.Size(75, 48)
        Me.btnVecinoproximo.TabIndex = 21
        Me.btnVecinoproximo.Text = "Vecino Proximo"
        Me.btnVecinoproximo.UseVisualStyleBackColor = True
        '
        'btnbilineal
        '
        Me.btnbilineal.Location = New System.Drawing.Point(205, 551)
        Me.btnbilineal.Name = "btnbilineal"
        Me.btnbilineal.Size = New System.Drawing.Size(87, 48)
        Me.btnbilineal.TabIndex = 21
        Me.btnbilineal.Text = "Interpolacion Bilineal"
        Me.btnbilineal.UseVisualStyleBackColor = True
        '
        'btnbicubica
        '
        Me.btnbicubica.Location = New System.Drawing.Point(298, 551)
        Me.btnbicubica.Name = "btnbicubica"
        Me.btnbicubica.Size = New System.Drawing.Size(89, 48)
        Me.btnbicubica.TabIndex = 21
        Me.btnbicubica.Text = "Interpolacion bicubica"
        Me.btnbicubica.UseVisualStyleBackColor = True
        '
        'btn_rot_or_des
        '
        Me.btn_rot_or_des.Location = New System.Drawing.Point(408, 551)
        Me.btn_rot_or_des.Name = "btn_rot_or_des"
        Me.btn_rot_or_des.Size = New System.Drawing.Size(75, 23)
        Me.btn_rot_or_des.TabIndex = 21
        Me.btn_rot_or_des.Text = "Button1"
        Me.btn_rot_or_des.UseVisualStyleBackColor = True
        '
        'btn_rot_vcino_prox
        '
        Me.btn_rot_vcino_prox.Location = New System.Drawing.Point(499, 605)
        Me.btn_rot_vcino_prox.Name = "btn_rot_vcino_prox"
        Me.btn_rot_vcino_prox.Size = New System.Drawing.Size(75, 23)
        Me.btn_rot_vcino_prox.TabIndex = 21
        Me.btn_rot_vcino_prox.Text = "Button1"
        Me.btn_rot_vcino_prox.UseVisualStyleBackColor = True
        '
        'btn_rot_bilineal
        '
        Me.btn_rot_bilineal.Location = New System.Drawing.Point(499, 551)
        Me.btn_rot_bilineal.Name = "btn_rot_bilineal"
        Me.btn_rot_bilineal.Size = New System.Drawing.Size(75, 23)
        Me.btn_rot_bilineal.TabIndex = 21
        Me.btn_rot_bilineal.Text = "Button1"
        Me.btn_rot_bilineal.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(605, 721)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "JORGE L. CASTRO"
        '
        'frmTransformaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 750)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_rot_bilineal)
        Me.Controls.Add(Me.btn_rot_vcino_prox)
        Me.Controls.Add(Me.btn_rot_or_des)
        Me.Controls.Add(Me.btnbicubica)
        Me.Controls.Add(Me.btnbilineal)
        Me.Controls.Add(Me.btnVecinoproximo)
        Me.Controls.Add(Me.btnOrigenDestino)
        Me.Controls.Add(Me.txtfactor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTransformaciones"
        Me.Text = "Transformaciones Geometricas"
        Me.Panel2.ResumeLayout(False)
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pb2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pb1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtfactor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfd1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnOrigenDestino As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnVecinoproximo As System.Windows.Forms.Button
    Friend WithEvents btnbilineal As System.Windows.Forms.Button
    Friend WithEvents btnbicubica As System.Windows.Forms.Button
    Friend WithEvents btn_rot_or_des As System.Windows.Forms.Button
    Friend WithEvents btn_rot_vcino_prox As System.Windows.Forms.Button
    Friend WithEvents btn_rot_bilineal As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
