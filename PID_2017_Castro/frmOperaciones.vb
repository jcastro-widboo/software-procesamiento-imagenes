Public Class frmOperaciones

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim F2 As New frmOperaciones
        Me.Close()
        F2.Close()
    End Sub


    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim operacion As Integer
        operacion = Me.cbOperacion.SelectedIndex + 1
        MessageBox.Show("operacion" & operacion)
        Dim i1, i2, i3 As Bitmap
        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i3 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = pb1.Image
        i2 = pb2.Image
        OPERACIONES(i1, i2, i3, operacion)
        Me.pb3.Width = i3.Width
        Me.pb3.Height = i3.Height
        Me.pb3.Image = i3
    End Sub

    Private Sub btnCargarI1_Click(sender As Object, e As EventArgs) Handles btnCargarI1.Click
        cargar_imagen(pb1, ofd1)
    End Sub
    Private Sub btnCargarI2_Click(sender As Object, e As EventArgs) Handles btnCargarI2.Click
        cargar_imagen(pb2, ofd1)
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        grabar_imagen(pb3, sfd1)
    End Sub
End Class