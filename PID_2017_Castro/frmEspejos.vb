Public Class frmEspejos
    Dim img1, img2, img3 As Bitmap
    Dim matriz(1, 1, 2) As Integer
    Dim matrizh(1, 1, 2) As Integer
    Dim matrizv(1, 1, 2) As Integer
    Dim i, j, k, valh, valv, posh, posv As Integer

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        cargar_imagen(pb1, OpenFileDialog1)
    End Sub

    Private Sub btnGuardHoriz_Click(sender As Object, e As EventArgs) Handles btnGuardHoriz.Click
        grabar_imagen(pb2, SaveFileDialog1)
    End Sub

    Private Sub btnGuardVert_Click(sender As Object, e As EventArgs) Handles btnGuardHoriz.Click
        grabar_imagen(pb3, SaveFileDialog1)
    End Sub

    Private Sub btnEspejo_Click(sender As Object, e As EventArgs) Handles btnEspejo.Click
        img1 = New Bitmap(pb1.Width, pb1.Height, Imaging.PixelFormat.Format24bppRgb)
        img1 = Me.pb1.Image
        img2 = New Bitmap(img1.Width, img1.Height, Imaging.PixelFormat.Format24bppRgb)
        img3 = New Bitmap(img1.Width, img1.Height, Imaging.PixelFormat.Format24bppRgb)

        espejo(img1, img2, img3)

        Me.pb2.Height = img2.Height
        Me.pb2.Width = img2.Width
        Me.pb2.Image = img2

        Me.pb3.Height = img3.Height
        Me.pb3.Width = img3.Width
        Me.pb3.Image = img3
    End Sub

    Private Sub Ejercicio2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGuarVert_Click(sender As Object, e As EventArgs) Handles btnGuarVert.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim i1, i2 As Bitmap
        Dim factor As Double
        Dim filtro(2, 2) As Double
        factor = 1.0
        filtro(0, 0) = -1 : filtro(0, 1) = -2 : filtro(0, 2) = -1
        filtro(1, 0) = 0 : filtro(1, 1) = 0 : filtro(1, 2) = 0
        filtro(2, 0) = 1 : filtro(2, 1) = 2 : filtro(2, 2) = 1

        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = pb1.Image
        aplica_filtro(i1, i2, filtro, factor)
        Me.pb4.Width = i2.Width
        Me.pb4.Height = i2.Height
        Me.pb4.Image = i2
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim i1, i2 As Bitmap
        Dim factor As Double
        Dim filtro(2, 2) As Double
        factor = 1.0
        filtro(0, 0) = -1 : filtro(0, 1) = 0 : filtro(0, 2) = 1
        filtro(1, 0) = -2 : filtro(1, 1) = 0 : filtro(1, 2) = 2
        filtro(2, 0) = -1 : filtro(2, 1) = 0 : filtro(2, 2) = 1

        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = pb1.Image
        aplica_filtro(i1, i2, filtro, factor)
        Me.pb4.Width = i2.Width
        Me.pb4.Height = i2.Height
        Me.pb4.Image = i2
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim i1, i2, i3, i4, i5 As Bitmap
        'Resalta las diferencias o cambios bruscos de los niveles de gris
        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = Me.pb1.Image
        i2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i3 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i4 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i5 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        'Creacion del filtro 
        sobelxy(i1, i2, i3, i4, i5)
        pb4.Width = i5.Width
        pb4.Height = i5.Height
        pb4.Image = i5
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        grabar_imagen(pb4, SaveFileDialog1)
    End Sub
End Class