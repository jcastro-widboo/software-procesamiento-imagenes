Public Class frmPlanos

    Dim mplanos(2, 2, 7) As Integer 'matriz de planos
    Dim mplanos2(2, 2, 7) As Integer
    Dim m2(2, 2) As Integer 'permite mantener la matriz original de la imagen 
    Dim imgplanos(7) As Bitmap 'imagenes de cada plano 8 planos como imagenes binarias

    Private Sub frmPlanos_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub btnCargar1_Click(sender As Object, e As EventArgs) Handles btnCargar1.Click
        cargar_imagen(pb1, ofd1)
    End Sub

    Private Sub btnDescomponer_Click(sender As Object, e As EventArgs) Handles btnDescomponer.Click
        Dim i1, i2 As Bitmap
        i1 = New Bitmap(Me.pb1.Width, _
                             Me.pb1.Height, _
                             Imaging.PixelFormat.Format24bppRgb)
        i1 = Me.pb1.Image
        Me.pb2.Width = Me.pb1.Width
        Me.pb2.Height = Me.pb1.Height

        i2 = Me.pb2.Image
        Dim i As Integer
        ReDim mplanos(i1.Height - 1, i1.Width - 1, 7)
        ReDim mplanos2(i1.Height - 1, i1.Width - 1, 7)
        For i = 0 To 7
            imgplanos(i) = New Bitmap(Me.pb1.Width, _
                             Me.pb1.Height, _
                             Imaging.PixelFormat.Format24bppRgb)
        Next

        descomponer(i1, mplanos, imgplanos)
        pb2.Image = imgplanos(7)
        mplanos2 = mplanos

    End Sub

    Private Sub cbPlano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPlano.SelectedIndexChanged
        Dim plano As Integer
        plano = Me.cbPlano.Text
        pb2.Image = imgplanos(plano)

    End Sub

    Private Sub btnCargar2_Click(sender As Object, e As EventArgs) Handles btnCargar2.Click
        cargar_imagen(pb3, ofd1)
        Dim i3 As Bitmap
        i3 = New Bitmap(Me.pb3.Width, _
                             Me.pb3.Height, _
                             Imaging.PixelFormat.Format24bppRgb)
        i3 = Me.pb3.Image
        ReDim m2(i3.Height - 1, i3.Width - 1)
        bitmap_to_m(i3, m2)

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim plano As Integer 'plano q vamos a alterar
        plano = Me.cb2.Text
        mplanos2 = mplanos.Clone
        'pasar m2 a planos de planos 2
        copiarmatriz_to_plano(mplanos2, plano, m2)
        Dim i4 As Bitmap
        i4 = New Bitmap(Me.pb1.Width, _
                             Me.pb1.Height, _
                             Imaging.PixelFormat.Format24bppRgb)
        reconstruirimagen(mplanos2, i4)
        Me.pb4.Width = Me.pb1.Width
        Me.pb4.Height = Me.pb1.Height
        Me.pb4.Image = i4


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnGuardar2.Click
        grabar_imagen(pb4, sfd1)
    End Sub

    Private Sub btnGrabar1_Click(sender As Object, e As EventArgs) Handles btnGrabar1.Click
        grabar_imagen(pb3, sfd1)
    End Sub
End Class