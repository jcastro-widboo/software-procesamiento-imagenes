Public Class frmDescomposicionRGB

    Private Sub frmDescomposicionRGB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        cargar_imagen(pb, ofd1)
        Dim imagen1 As Bitmap
        imagen1 = New Bitmap(Me.pb.Width, Me.pb.Height, _
                 System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagen1 = Me.pb.Image
        'MessageBox.Show(imagen1.PixelFormat.ToString)
        Dim nf, nc As Integer
        nf = imagen1.Height - 1 : nc = imagen1.Width - 1
        Dim matriz1(nf, nc, 2) As Integer
        bitmap_to_mRGB1(imagen1, matriz1)
        Dim imagenR, imagenG, imagenB As Bitmap
        imagenR = New Bitmap(Me.pb.Width, Me.pb.Height, _
                 System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagenG = New Bitmap(Me.pb.Width, Me.pb.Height, _
                 System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagenB = New Bitmap(Me.pb.Width, Me.pb.Height, _
                 System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim colori, colorR, colorG, colorB As Color
        For i = 0 To nf
            For j = 0 To nc
                colori = imagen1.GetPixel(j, i) 'coordenadas x y'
                colorR = Color.FromArgb(colori.R, 0, 0)
                colorG = Color.FromArgb(0, colori.G, 0)
                colorB = Color.FromArgb(0, 0, colori.B)
                imagenR.SetPixel(j, i, colorR)
                imagenG.SetPixel(j, i, colorG)
                imagenB.SetPixel(j, i, colorB)
            Next j
        Next i
        pbRojo.Width = imagen1.Width
        pbVerde.Width = imagen1.Width
        pbazul.Width = imagen1.Width
        pbRojo.Height = imagen1.Height
        pbVerde.Height = imagen1.Height
        pbazul.Height = imagen1.Height
        pbRojo.Image = imagenR
        pbVerde.Image = imagenG
        pbazul.Image = imagenB

    End Sub

    Private Sub btnCargarR_Click(sender As Object, e As EventArgs) Handles btnCargarR.Click
        cargar_imagen(pb, ofd1)
        Dim imagen1 As Bitmap
        imagen1 = New Bitmap(Me.pb.Width, Me.pb.Height, _
                 System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagen1 = Me.pb.Image
        Dim nf, nc As Integer
        nf = imagen1.Height - 1 : nc = imagen1.Width - 1
        Dim matriz1(nf, nc, 2) As Integer
        bitmap_to_mRGB1(imagen1, matriz1)
        Dim imagenR, imagenG, imagenB As Bitmap
        imagenR = New Bitmap(Me.pb.Width, Me.pb.Height, _
                 System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagenG = New Bitmap(Me.pb.Width, Me.pb.Height, _
                 System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagenB = New Bitmap(Me.pb.Width, Me.pb.Height, _
                 System.Drawing.Imaging.PixelFormat.Format24bppRgb)

        descomponerRGB(imagen1, imagenR, imagenG, imagenB)



        pbRojo.Width = imagen1.Width
        pbVerde.Width = imagen1.Width
        pbAzul.Width = imagen1.Width
        pbRojo.Height = imagen1.Height
        pbVerde.Height = imagen1.Height
        pbAzul.Height = imagen1.Height
        pbRojo.Image = imagenR
        pbVerde.Image = imagenG
        pbAzul.Image = imagenB

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim F2 As New frmDescomposicionRGB
        Me.Close()
        F2.Close()
    End Sub
End Class