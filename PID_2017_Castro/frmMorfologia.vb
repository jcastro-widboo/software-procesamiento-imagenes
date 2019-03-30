Public Class frmMorfologia
    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        cargar_imagen(pb1, ofd1)
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        grabar_imagen(pb2, sfd1)
    End Sub

    Private Sub btnPrincipal_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub btnDilatacion_Click(sender As Object, e As EventArgs) Handles btnDilatacion.Click
        Dim imagen1, imagen2 As Bitmap
        imagen1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagen1 = pb1.Image
        imagen2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim dimension As Integer
        dimension = Convert.ToInt16(InputBox("Ingrese dimension para el elemento estructurante (valor impar mayor o igual a 3) Dilatacion"))
        Dim ee(dimension - 1, dimension - 1), i, j As Integer
        'ee(0, 0) = 0 : ee(0, 1) = 0 : ee(0, 2) = 0
        'ee(1, 0) = 1 : ee(1, 1) = 1 : ee(1, 2) = 1
        'ee(2, 0) = 0 : ee(2, 1) = 0 : ee(2, 2) = 0

        For i = 0 To dimension - 1
            For j = 0 To dimension - 1
                ee(i, j) = InputBox("Ingrese un valor para la posicion (" & i & "-" & j & ")")
            Next
        Next


        dilatacion(imagen1, imagen2, ee)
        pb2.Width = imagen2.Width
        pb2.Height = imagen2.Height
        pb2.Image = imagen2
    End Sub


    Private Sub btnErosion_Click(sender As Object, e As EventArgs) Handles btnErosion.Click
        Dim imagen1, imagen2 As Bitmap
        imagen1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagen1 = pb1.Image
        imagen2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim dimension As Integer
        dimension = Convert.ToInt16(InputBox("Ingrese dimension para el elemento estructurante (valor impar mayor o igual a 3) Erosión "))
        Dim ee(dimension - 1, dimension - 1), i, j As Integer

        'ee(0, 0) = 0 : ee(0, 1) = 0 : ee(0, 2) = 0
        'ee(1, 0) = 0 : ee(1, 1) = 1 : ee(1, 2) = 1
        'ee(2, 0) = 0 : ee(2, 1) = 1 : ee(2, 2) = 1

        For i = 0 To dimension - 1
            For j = 0 To dimension - 1
                ee(i, j) = Convert.ToInt16(InputBox("Ingrese un valor para la posicion (" & i & "-" & j & ")"))
            Next
        Next
        erosion(imagen1, imagen2, ee)
        pb2.Width = imagen2.Width
        pb2.Height = imagen2.Height
        pb2.Image = imagen2
    End Sub


    Private Sub btnApertura_Click(sender As Object, e As EventArgs) Handles btnApertura.Click
        Dim imagen1, imagen2 As Bitmap
        imagen1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagen1 = pb1.Image
        imagen2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)

        Dim dimension As Integer
        dimension = Convert.ToInt16(InputBox("Ingrese dimension para el elemento estructurante (valor impar mayor o igual a 3) Apertura "))
        Dim ee(dimension - 1, dimension - 1), i, j As Integer
        'ee(0, 0) = 1 : ee(0, 1) = 1 : ee(0, 2) = 1
        'ee(1, 0) = 1 : ee(1, 1) = 1 : ee(1, 2) = 1
        'ee(2, 0) = 1 : ee(2, 1) = 1 : ee(2, 2) = 1


        For i = 0 To dimension - 1
            For j = 0 To dimension - 1
                ee(i, j) = Convert.ToInt16(InputBox("Ingrese un valor para la posicion (" & i & "-" & j & ")"))
            Next
        Next
        apertura(imagen1, imagen2, ee)
        pb2.Width = imagen2.Width
        pb2.Height = imagen2.Height
        pb2.Image = imagen2
    End Sub



    Private Sub btnCierre_Click(sender As Object, e As EventArgs) Handles btnCierre.Click
        Dim imagen1, imagen2 As Bitmap
        imagen1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagen1 = pb1.Image
        imagen2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim dimension As Integer
        dimension = Convert.ToInt16(InputBox("Ingrese dimension para el elemento estructurante (valor impar mayor o igual a 3) Cierre"))
        Dim ee(dimension - 1, dimension - 1), i, j As Integer
        'ee(0, 0) = 1 : ee(0, 1) = 1 : ee(0, 2) = 1
        'ee(1, 0) = 1 : ee(1, 1) = 1 : ee(1, 2) = 1
        'ee(2, 0) = 1 : ee(2, 1) = 1 : ee(2, 2) = 1
        For i = 0 To dimension - 1
            For j = 0 To dimension - 1
                ee(i, j) = Convert.ToInt16(InputBox("Ingrese un valor para la posicion (" & i & "-" & j & ")"))
            Next
        Next

        cierre(imagen1, imagen2, ee)
        pb2.Width = imagen2.Width
        pb2.Height = imagen2.Height
        pb2.Image = imagen2
    End Sub

    Private Sub frmMorfologia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class