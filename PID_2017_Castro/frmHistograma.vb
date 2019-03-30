Public Class frmHistograma

    Private Sub frmHistograma_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles lbl50a.Click

    End Sub


    Private Sub btnc1_Click(sender As Object, e As EventArgs) Handles btnc1.Click
        cargar_imagen(pb1, ofd1)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        grabar_imagen(pb2, sfd1)
    End Sub

    Private Sub btnHistograma_Click(sender As Object, e As EventArgs) Handles btnHistograma.Click
        Dim i1 As Bitmap
        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = Me.pb1.Image
        histo1(i1, PictureBox1, lbl100, lbl75, lbl50, lbl25, 0)
        histoacumulado(i1, PictureBox2, lbl100a, lbl75a, lbl50a, lbl25a, 0)

    End Sub

    Private Sub btnEcualizar_Click(sender As Object, e As EventArgs) Handles btnEcualizar.Click
        Dim i1, i2 As Bitmap
        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = Me.pb1.Image
        ecualizar(i1, i2, 1 + ComboBox1.SelectedIndex, txtHistograma)
        'mostrar el resultado de la operacion
        Me.pb2.Height = Me.pb1.Height
        Me.pb2.Width = Me.pb1.Width
        Me.pb2.Image = i2
    End Sub


    Private Sub btnHisEc_Click(sender As Object, e As EventArgs) Handles btnHisEc.Click
        Dim i1 As Bitmap
        i1 = New Bitmap(pb2.Width, pb2.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)

        i1 = Me.pb2.Image
        histo1(i1, PictureBox1, lbl100, lbl75, lbl50, lbl25, 0)
        histoacumulado(i1, PictureBox2, lbl100a, lbl75a, lbl50a, lbl25a, 0)

    End Sub

    Private Sub btnExpandirContraer_Click(sender As Object, e As EventArgs) Handles btnExpandirContraer.Click
        Dim i1, i2 As Bitmap
        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i2 = i1
        i1 = Me.pb1.Image
        Dim v1, v2 As Integer
        v1 = Me.txtvin.Text : v2 = Me.txtvsup.Text
        contraer_expandir_histo(i1, i2, v1, v2)

        pb2.Width = i2.Width
        Pb2.Height = i2.Height
        pb2.Image = i2
        histo1(i1, PictureBox1, lbl100, lbl75, lbl50, lbl25, 0)
        histo1(i2, PictureBox2, lbl100a, lbl75a, lbl50a, lbl25a, 0)
    End Sub


End Class