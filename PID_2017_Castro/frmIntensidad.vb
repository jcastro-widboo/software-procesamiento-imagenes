Public Class frmIntensidad

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        cargar_imagen(pb1, ofd1)
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        grabar_imagen(pb2, sfd1)
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim funcion As String
        funcion = Me.cbFuncion.Text
        MessageBox.Show("funcion " & funcion)
        Dim i1, i2 As Bitmap
        'xq son de las mismas dimensiones
        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        
        i1 = pb1.Image
        visualizar(i1, i2, funcion)
        Me.pb2.Width = i2.Width
        Me.pb2.Height = i2.Height
        Me.pb2.Image = i2 'le pone en el pb3 para podeer visualizar
    End Sub

    Private Sub sfd1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles sfd1.FileOk

    End Sub

    Private Sub ofd1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofd1.FileOk

    End Sub

    Private Sub cbFuncion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFuncion.SelectedIndexChanged

    End Sub

    Private Sub pb2_Click(sender As Object, e As EventArgs) Handles pb2.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub pb1_Click(sender As Object, e As EventArgs) Handles pb1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class