Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Image
Imports System.Drawing.Imaging
Imports System.Math
Imports System.Runtime.InteropServices
Module util_abr_2017
    Sub rectangulo_extract(ByRef MIMAPA As Bitmap, ByRef MIMAPA2 As Bitmap, _
                               ByRef P1 As Point, ByRef P2 As Point)
        Dim i, i1, j, j1 As Integer
        Dim micolor As Color
        i = 0
        Debug.Print(MIMAPA2.Width & " " & MIMAPA2.Height)
        For i1 = P1.Y To P2.Y
            j = 0
            For j1 = P1.X To P2.X
                micolor = MIMAPA.GetPixel(j1, i1)

                MIMAPA2.SetPixel(j, i, micolor)
                j += 1
            Next
            i += 1
        Next
    End Sub

    Sub rectangulo_extractm(ByRef m(,,) As Integer, ByRef MIMAPA2 As Bitmap, _
                           ByRef P1 As Point, ByRef P2 As Point)
        Dim i, i1, j, j1 As Integer
        Dim nf2, nc2 As Integer
        nc2 = P2.X - P1.X
        nf2 = P2.Y - P1.Y
        Dim m2(nf2, nc2, 2) As Integer
        i = 0
        Debug.Print(MIMAPA2.Width & " " & MIMAPA2.Height)
        For i1 = P1.Y To P2.Y
            j = 0
            For j1 = P1.X To P2.X

                For k = 0 To 2
                    m2(i, j, k) = m(i1, j1, k)
                Next k

                j += 1

            Next j1

            i += 1

        Next

        mint3d_to_bitmap(m2, MIMAPA2)

    End Sub

    Sub correlacion_mat(ByRef matriz1(,) As Integer, ByRef matriz2(,) As Integer, ByRef matriz3(,) As Integer)
        Dim i, j, j1, i1, nf, nc, nfsub, ncsub As Integer
        Dim maxi, maxj As Integer
        Dim sumsub As Integer, mediasub As Single
        nf = UBound(matriz1, 1)
        nc = UBound(matriz1, 2)
        nfsub = UBound(matriz2, 1)
        ncsub = UBound(matriz2, 2)
        Dim matriztrabajo(nf, nc) As Double

        Dim matriz2trab(nfsub, ncsub) As Double
        Dim suma_matriz2trab2 As Double
        '       preparacion de datos de la matriz de trabajo
        'suma de niveles de gris de subimagen
        sumsub = 0


        For i = 0 To nfsub
            For j = 0 To ncsub
                sumsub = sumsub + matriz2(i, j)
            Next
        Next
        mediasub = sumsub / ((nfsub + 1) * (ncsub + 1))
        suma_matriz2trab2 = 0

        For i = 0 To nfsub
            For j = 0 To ncsub
                matriz2trab(i, j) = matriz2(i, j) - mediasub


                suma_matriz2trab2 = suma_matriz2trab2 + matriz2trab(i, j) _
                                                        * matriz2trab(i, j)
            Next
        Next
        'proceso de la matriz 1
        Dim numerador, denominador, VALOR, SUMVALOR, VALORM As Single
        maxi = -1
        maxj = -1
        Dim maxvalor As Single
        maxvalor = -100.0
        For i = 0 To nf
            For j = 0 To nc
                numerador = 0.0
                denominador = 0.0
                SUMVALOR = 0.0
                For i1 = 0 To nfsub
                    For j1 = 0 To ncsub
                        If (j + j1) > nc Or (i + i1 > nf) Then
                            VALOR = 0.0
                        Else
                            VALOR = matriz1(i + i1, j + j1)
                        End If
                        SUMVALOR = SUMVALOR + VALOR
                    Next
                Next
                VALORM = SUMVALOR / ((nfsub + 1) * (ncsub + 1))
                For i1 = 0 To nfsub
                    For j1 = 0 To ncsub
                        If (j + j1) > nc Or (i + i1 > nf) Then
                            VALOR = 0.0
                        Else
                            VALOR = matriz1(i + i1, j + j1)
                        End If
                        VALOR = VALOR - VALORM


                        numerador = numerador + VALOR * matriz2trab(i1, j1)



                        denominador = denominador + VALOR * VALOR
                    Next
                Next
                'Debug.Write(numerador & "-" & denominador)
                matriztrabajo(i, j) = numerador / Math.Sqrt(denominador * suma_matriz2trab2)

                If matriztrabajo(i, j) > maxvalor Then
                    maxvalor = matriztrabajo(i, j)
                    maxi = i
                    maxj = j
                End If
            Next
        Next
        MessageBox.Show("fin correlacionn" & vbCrLf & _
                       "MAXIMO = " & maxvalor & "   i = " & maxi & " j = " & maxj)
        normalizar255(matriztrabajo, matriz3)

    End Sub

    Sub normalizar255(ByRef mat1(,) As Double, ByRef mat_int(,) As Integer)
        Dim i, j, nc, nf As Integer
        Dim maximo, minimo As Double
        maximo = -99999.999
        minimo = 999999.999

        nf = UBound(mat1, 1)
        nc = UBound(mat1, 2)
        ' determinacionde maximo y minimo
        For i = 0 To nf
            For j = 0 To nc
                If mat1(i, j) > maximo Then maximo = mat1(i, j)
                If mat1(i, j) < minimo Then minimo = mat1(i, j)
            Next
        Next
        ' resta del minimo
        maximo = maximo - minimo
        For i = 0 To nf
            For j = 0 To nc
                mat1(i, j) = mat1(i, j) - minimo
                If Double.IsNaN(mat1(i, j)) = True Then mat1(i, j) = 0.0
                mat_int(i, j) = Convert.ToInt32(mat1(i, j) * 255 / maximo)
                If mat_int(i, j) > 255 Then mat_int(i, j) = 255
                If mat_int(i, j) < 0 Then mat_int(i, j) = 0
            Next
        Next
    End Sub

    Sub correl_imagenes(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef i3 As Bitmap)
        Dim nf, nc, nf2, nc2 As Integer
        nf = i1.Height - 1
        nc = i1.Width - 1
        nf2 = i2.Height - 1
        nc2 = i2.Width - 1
        Dim m1(nf, nc), m2(nf2, nc2), m3(nf, nc) As Integer
        bitmap_to_mint(i1, m1)
        bitmap_to_mint(i2, m2)
        correlacion_mat(m1, m2, m3)
        mint_to_bitmap(m3, i3)
    End Sub

    Sub cargar_imagen(ByRef pb As PictureBox, ByRef OFD As OpenFileDialog)
        Dim i1 As Bitmap
        OFD.ShowDialog()
        i1 = New Bitmap(OFD.FileName)
        pb.Width = i1.Width
        pb.Height = i1.Height
        pb.Image = i1
    End Sub

    Sub sobelxy(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef i5 As Bitmap, ByRef i6 As Bitmap, ByRef i7 As Bitmap)

        Dim ancho, alto As Integer
        Dim valor As Double
        Dim forma As String
        forma = "binarizacion"
        ancho = i1.Width
        alto = i1.Height
        Dim filtx(2, 2) As Double
        Dim filty(2, 2) As Double
        filtx(0, 0) = -1 : filtx(0, 1) = 0 : filtx(0, 2) = 1
        filtx(1, 0) = -2 : filtx(1, 1) = 0 : filtx(1, 2) = 2
        filtx(2, 0) = -1 : filtx(2, 1) = 0 : filtx(2, 2) = 1

        filty(0, 0) = -1 : filty(0, 1) = -2 : filty(0, 2) = -1
        filty(1, 0) = 0 : filty(1, 1) = 0 : filty(1, 2) = 0
        filty(2, 0) = 1 : filty(2, 1) = 2 : filty(2, 2) = 1

        Dim m1(alto - 1, ancho - 1, 2) As Double
        Dim m2(alto - 1, ancho - 1, 2) As Double 'Suma de m2x + m2y
        Dim m3(alto - 1, ancho - 1, 2) As Double
        Dim m4(alto - 1, ancho - 1, 2) As Double
        Dim m5(alto - 1, ancho - 1, 2) As Double
        Dim m6(alto - 1, ancho - 1, 2) As Double
        bitmap_to_mRGB(i1, m1)
        'fin paso 1
        'aplicacion del filtro
        Dim nff, ncf As Integer
        Dim vpixel, sumpixel As Double
        nff = UBound(filty, 1)
        ncf = UBound(filty, 2)
        Dim i, j, k, i3, j3 As Integer
        For k = 0 To 2 'para recorrer los planos r g b
            For i = 0 To alto - 1 'filas
                For j = 0 To ancho - 1 'columnas
                    sumpixel = 0.0
                    '5 , 6, 7   para i,j 
                    For i3 = i - nff / 2 To i + nff / 2
                        For j3 = j - ncf / 2 To j + ncf / 2
                            If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                                vpixel = m1(i, j, k) ' puede ser 0
                            Else
                                vpixel = m1(i3, j3, k)
                            End If
                            sumpixel = sumpixel + vpixel * filty(i3 - (i - nff / 2), j3 - (j - ncf / 2))
                        Next
                    Next
                    sumpixel = sumpixel / 1
                    m2(i, j, k) = sumpixel
                Next
            Next
        Next k
        ' PASAR LA MATRIZ REAL A UN BITMAP
        mdouble3d_to_bitmap(m2, i2)

        nff = UBound(filtx, 1)
        ncf = UBound(filtx, 2)

        For k = 0 To 2 'para recorrer los planos r g b
            For i = 0 To alto - 1 'filas
                For j = 0 To ancho - 1 'columnas
                    sumpixel = 0.0
                    '5 , 6, 7   para i,j 
                    For i3 = i - nff / 2 To i + nff / 2
                        For j3 = j - ncf / 2 To j + ncf / 2
                            If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                                vpixel = m1(i, j, k) ' puede ser 0
                            Else
                                vpixel = m1(i3, j3, k)
                            End If
                            sumpixel = sumpixel + vpixel * filtx(i3 - (i - nff / 2), j3 - (j - ncf / 2))
                        Next
                    Next
                    sumpixel = sumpixel / 1
                    m3(i, j, k) = sumpixel
                Next
            Next
        Next k
        mdouble3d_to_bitmap(m3, i5)


        'suma 
        bitmap_to_mRGB(i2, m2)
        bitmap_to_mRGB(i5, m3)
        For k = 0 To 2 'Recorrer los planos
            For i = 0 To alto - 1 'Recorre las filas
                For j = 0 To ancho - 1 'Recorre las columnas

                    m4(i, j, k) = Convert.ToDouble(m2(i, j, k) + m3(i, j, k))

                Next j
            Next i
        Next k
        'normalizacion de m3 a valores de 0 a 255
        normalizar_0_255(m4)
        'Debug.Print("RASTREO M3 " & m1(100, 100, 0) & " " & m2(100, 100, 0) & " " & m3(100, 100, 0))
        mdouble3d_to_bitmap(m4, i6)




        Dim nf, nc, i10, j10, k10 As Integer

        nf = i2.Height - 1
        nc = i2.Width - 1

        'pasar i1 a m1
        bitmap_to_mRGB(i6, m4)
        'CALCULO EN M2

        forma = "binarizacion"
        valor = InputBox("Ingrese un Valor para transformacion " & forma)

        For i10 = 0 To nf
            For j10 = 0 To nc
                For k10 = 0 To 2
                    Select Case forma

                        Case "binarizacion"
                            'm2(i, j, k) = i1.GetPixel(j, i).R
                            If m4(i10, j10, k10) < valor Then m5(i10, j10, k10) = 0 Else m5(i10, j10, k10) = 255
                    End Select
                Next
            Next
        Next

        mdouble3d_to_bitmap(m5, i7)

    End Sub

    Sub espejo(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef i3 As Bitmap)
        Dim nf, nc As Integer
        nf = i1.Height - 1 : nc = i1.Width - 1
        'dimensionamiento de matrices
        Dim m1(nf, nc, 2), m2(nf, nc, 2), m3(nf, nc, 2) As Integer
        bitmap_to_mRGB(i1, m1)
        For i = 0 To nf
            For j = 0 To nc
                For k = 0 To 2
                    m2(i, j, k) = m1(i, nc - j, k)
                    m3(i, j, k) = m1(nf - i, j, k)
                Next
            Next
        Next
        mint3d_to_bitmap(m2, i2)
        mint3d_to_bitmap(m3, i3)
    End Sub

    Sub grabar_imagen(ByRef pb As PictureBox, ByRef SFD As SaveFileDialog)
        Dim i1 As Bitmap
        i1 = New Bitmap(pb.Width, pb.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = pb.Image
        SFD.ShowDialog()
        i1.Save(SFD.FileName)
    End Sub
    Sub cargar_imagen(ByRef pb As PictureBox, _
                      ByRef OFD As OpenFileDialog, _
                      ByRef tb As TextBox)
        Dim i1 As Bitmap
        OFD.ShowDialog()
        i1 = New Bitmap(OFD.FileName)
        pb.Width = i1.Width
        pb.Height = i1.Height
        pb.Image = i1
        tb.Text = "Nombre= " & OFD.FileName & "  " & vbCrLf & _
                  "ancho=  " & i1.Size.Width & " " & vbCrLf & _
                  "alto=  " & i1.Size.Height & " " & vbCrLf & _
                  "res x=  " & i1.HorizontalResolution & " " & vbCrLf & _
                  "res y=  " & i1.VerticalResolution & " " & vbCrLf & _
                  "formato = " & i1.PixelFormat & i1.PixelFormat.ToString

    End Sub
    Sub bitmap_to_mRGB1(ByRef imagen As Bitmap, _
                   ByRef mat(,,) As Integer)
        Dim micolor As Color
        Dim i, j As Integer
        For i = 0 To imagen.Height - 1
            For j = 0 To imagen.Width - 1
                micolor = imagen.GetPixel(j, i) 'getpixel(x,y)
                mat(i, j, 0) = micolor.R
                mat(i, j, 1) = micolor.G
                mat(i, j, 2) = micolor.B
            Next
        Next
    End Sub
    Sub bitmap_to_m(ByRef imagen As Bitmap,
                   ByRef mat(,) As Integer)
        Dim micolor As Color
        Dim i, j As Integer
        For i = 0 To imagen.Height - 1
            For j = 0 To imagen.Width - 1
                micolor = imagen.GetPixel(j, i) 'getpixel(x,y)
                mat(i, j) = micolor.R
            Next
        Next
    End Sub

    Public Sub descomponerRGB(ByRef imagen As Bitmap, ByRef iR As Bitmap, iG As Bitmap, iB As Bitmap) '

        'usa bitmapdata
        'byRef pasamos la imagen por referencia
        'pasa cada componente a una imagen distinta

        Dim datos As BitmapData  'inf de valores de pixeles

        Dim datosR As BitmapData  'inf de valores de pixeles
        Dim datosG As BitmapData  'inf de valores de pixeles
        Dim datosB As BitmapData  'inf de valores de pixeles

        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer 'indice para barrer todos los pix de la imagen
        ' Lock the bitmap's bits, get a BitmapData object
        Dim rect As New Rectangle(0, 0, width, height) 'define un rectangulo
        '                                               del tamaño de la imagen
        Dim rectR As New Rectangle(0, 0, width, height)
        Dim rectG As New Rectangle(0, 0, width, height)
        Dim rectB As New Rectangle(0, 0, width, height)

        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)
        datosR = iR.LockBits(rectR, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                iR.PixelFormat)
        datosG = iG.LockBits(rectG, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                iG.PixelFormat)
        datosB = iB.LockBits(rectB, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                iB.PixelFormat)

        'paso todos los pixeles a datos
        ' Get the address of its first scan line
        Dim ptr As IntPtr = datos.Scan0  'dirección de datos __ puntero hacia los datos de la imagen original
        Dim ptrR As IntPtr = datosR.Scan0
        Dim ptrG As IntPtr = datosG.Scan0
        Dim ptrB As IntPtr = datosB.Scan0

        ' Prepare an array that will receive all the pixels
        Dim bytes As Integer = datos.Stride * height 'num total de pix del bitmapdata (Ancho x alto)
        Dim pixels(bytes) As Byte 'arreglo de tantos bits tiene la imagen original
        Dim pixelsR(bytes) As Byte 'para la componente R
        Dim pixelsG(bytes) As Byte 'para la componente G
        Dim pixelsB(bytes) As Byte 'para la componente B

        ' Copy the pixels into the array
        Marshal.Copy(ptr, pixels, 0, bytes) 'coge un puntero y pasa el num de pixeles (0-bytes)
        Marshal.Copy(ptrR, pixelsR, 0, bytes)
        Marshal.Copy(ptrG, pixelsG, 0, bytes)
        Marshal.Copy(ptrB, pixelsB, 0, bytes)

        ' Now we have the data in a buffer, we can process it much more quickly than GetPixel/SetPixel
        ' The buffer elements now contain RGB data thus:
        ' R1 G1 B1 R2 G2 B2 R3 G3 B3...Rn Gn Bn
        ' so we traverse the array in steps of 3.  (Note: this is because it's 3 bytes per pixel.  Change this for other formats)
        Dim i, j As Integer

        For i = 0 To height - 1
            For j = 0 To width - 1
                index = (i * datos.Stride) + (j * 3) ' 3 bytes per pixel

                pixelsR(index) = pixels(index)
                pixelsR(index + 1) = 0
                pixelsR(index + 2) = 0

                pixelsG(index) = 0
                pixelsG(index + 1) = pixels(index + 1)
                pixelsG(index + 2) = 0

                pixelsB(index) = 0
                pixelsB(index + 1) = 0
                pixelsB(index + 2) = pixels(index + 2)


            Next
        Next
        Marshal.Copy(pixelsR, 0, ptrR, bytes) 'proceso inverso
        Marshal.Copy(pixelsG, 0, ptrG, bytes)
        Marshal.Copy(pixelsB, 0, ptrB, bytes)
        imagen.UnlockBits(datos)

        'liberar

        iR.UnlockBits(datosR)
        iG.UnlockBits(datosG)
        iB.UnlockBits(datosB)

    End Sub

    'Método generar_imagen tiene como parametros (
    'A la variable ancho se le asigna el valor del TextBox (ANCHO (PIX)),
    'A la variable alto se le asigna el valor del TextBox (ALTO (PIX)),
    'A la viariable xi se le asigna el valor del TextBox (X INF),
    'A la viariable xs se le asigna el valor del TextBox (X SUP),
    'A la viariable yi se le asigna el valor del TextBox (Y INF),
    'A la viariable ys se le asigna el valor del TextBox (Y SUP),
    'A la viariable pb se le asigna el PictureBox,
    'A la viariable funcion se le asigna el valor del ComboBox de la Función,
    'A la viariable ponercolor se le asigna el estado del CheckBox del Color,
    'A la viariable tcolor(,) se le asigna el valor del ComboBox del color.
    ')
    Sub generar_imagen(ByRef ancho As Integer, _
                   ByRef alto As Integer, _
                   ByRef xi As Double, _
                   ByRef xs As Double, _
                   ByRef yi As Double, _
                   ByRef ys As Double, _
                   ByRef pb As PictureBox, _
                   ByRef funcion As Integer,
                   ByRef ponercolor As Boolean,
                   ByRef tcolor(,) As Integer)

        'Declara las variables i, j, nf, nc de tipo Integer.
        Dim i, j, nf, nc As Integer

        'Se asigna a la variable nf el valor del alto -1.
        nf = alto - 1

        'Se asigna a la variable nc el valor del ancho -1.
        nc = ancho - 1

        'Declara la matriz mreal que contiene el alto y ancho de la imagen que se va a generar.
        Dim mreal(nf, nc) As Double

        'Declara la variable i1 de tipo Btimap.
        Dim i1 As Bitmap

        'Se asigna a la variable i1 el ancho, alto y el formato de Pixeles 24bppRgb.
        i1 = New Bitmap(ancho, alto, System.Drawing.Imaging.PixelFormat.Format24bppRgb)

        'Funcion = 1 sin(x) + cos(y).
        'Delcara x, y, dx, dy de tipo Double que son utilizados para la Funcion = 1 sin(x) + cos(y).
        Dim x, y, dx, dy As Double
        'Se asigan a dx el resultado de la operacion.
        dx = (xs - xi) / nc
        'Se asigan a dy el resultado de la operacion.
        dy = (ys - yi) / nf
        'Se asigan a dx el valor de yi.
        y = yi
        'Declara la variable dis de tipo Double.
        Dim dis As Double
        'Declara la variable porc de tipo Double.
        Dim porc As Double
        'Declara las variables nfranjac, dng de tipo Double.
        Dim nfranjac, dng As Double
        'Declara las variables w1, h1, x1, x2, y1, y2 de tipo Integer.
        Dim w1, h1, x1, x2, y1, y2 As Integer

        'Condicional del caso 6.
        If funcion = 6 Then
            'Se muestra un mensaje emergente que pide ingresar valores entre 0 y 1 para la Función del rectangulo.
            porc = Convert.ToDouble(InputBox("Valor del Porcentaje entre (0,1)"))
            'Se asigan a w1 el resultado de la operacion del ancho del rectangulo.
            w1 = porc * nc : x1 = (nc - w1) / 2 : x2 = x1 + w1
            'Se asigan a h1 el resultado de la operacion del ancho del rectangulo.
            h1 = porc * nf : y1 = (nf - h1) / 2 : y2 = y1 + h1
        End If
        'Fin del condicional del caso 6.

        'Condicional del caso 7.
        If funcion = 7 Then
            'Se muestra un mensaje emergente que pide ingresar valores entre 1 y 25.
            nfranjac = Convert.ToDouble(InputBox("Numero de franjas entre(1 y 25)"))
            'Se asigan a dx el resultado de la operacion.
            dx = nc / nfranjac + 1
            'Se asigan a dng el resultado de la operacion.
            dng = 1 / (nfranjac - 1)
        End If
        'Fin del condicional del caso 7.

        'Condicional del caso 8.
        If funcion = 8 Then
            'Se muestra un mensaje emergente que pide ingresar valores entre 1 y 25.
            nfranjac = Convert.ToDouble(InputBox("Numero de franjas entre(1 y 25)"))
            'Se asigan a dy el resultado de la operacion.
            dy = nf / nfranjac + 1
            'Se asigan a dng el resultado de la operacion.
            dng = 1 / (nfranjac - 1)
        End If
        'Fin del condicional del caso 8.

        'Declara col1, col2, aux de tipo Integer.
        Dim col1, col2, aux As Integer

        'Condicional del caso 9.
        If funcion = 9 Then
            w1 = nc / 8
            h1 = nf / 8 : y2 = h1
            col1 = 1
            col2 = 0
            If w1 Mod 2 = 0 Then
                x2 = w1
            Else
                w1 = w1 + 1
                x2 = w1
            End If

        End If
        'Fin del condicional del caso 9.

        'Condicional del caso 11.
        If funcion = 11 Then

            'cuadrado
            'nfranjac = 8
            'dx = nc / nfranjac + 1
            'dng = 1 / (nfranjac - 1)
            'col1 = 1
            'col2 = 0
            'triangulo
            'porc = Convert.ToDouble(InputBox("Valor del Porcentaje entre (0,1)"))
            'w1 = porc * nc : x1 = nc / 2 : x2 = x1
            'h1 = porc * nf : y1 = (nf - h1) / 2 : y2 = y1 + h1

            'circunferencias media.
            y2 = nf / 2

        End If
        'Fin del condicional del caso 11.

        'Genera la funcion.
        'Bucles pirncipales.
        For i = 0 To nf 'Filas

            x = xi

            For j = 0 To nc 'Columnas.

                Select Case funcion

                    Case 1 'Funcion, Sin(x) + Cos(y)
                        mreal(i, j) = Sin(x) + Cos(y)

                    Case 2 'Función, i + j
                        mreal(i, j) = i + j

                    Case 3  'Funcion, Log10((i + 1) * (i + 1) / (j + 1))
                        mreal(i, j) = (i - nf / 2) * (i - nf / 2) + (j - nc / 2) * (j - nc / 2)

                    Case 4 'Función, nf * nc / 4 - Sqrt((i - nf / 2) ^ 2 + (j - nc / 2) ^ 2)
                        dis = nf * nc / 4 - Sqrt((i - nf / 2) ^ 2 + (j - nc / 2) ^ 2)
                        mreal(i, j) = dis

                    Case 5 'Función de Circunferencias, Sqrt((i - nf / 2) ^ 2 + (j - nc / 2) ^ 2)
                        dis = Sqrt((i - nf / 2) ^ 2 + (j - nc / 2) ^ 2)
                        If dis < nc / 2 * 0.5 Then
                            mreal(i, j) = 1
                        Else
                            mreal(i, j) = 0
                        End If

                    Case 6 'Función del Rectangulo, rectangulo  i.
                        If i <= y2 And i >= y1 And j >= x1 And j <= x2 Then
                            mreal(i, j) = i
                        Else
                            mreal(i, j) = j
                        End If

                    Case 7 'Franajas verticales.
                        nfranjac = Math.Floor(j / dx)
                        mreal(i, j) = nfranjac * dng

                    Case 8 'Franajas horizontales.
                        nfranjac = Math.Floor(i / dy)
                        mreal(i, j) = nfranjac * dng

                    Case 9 'Calculos del caso 9.
                        If j > x2 Then
                            x2 = x2 + w1
                            aux = col1
                            col1 = col2
                            col2 = aux
                        End If
                        If j = 0 Then
                            x2 = w1
                            aux = col1
                            col1 = col2
                            col2 = aux
                        End If
                        If i > y2 Then
                            y2 = y2 + h1
                            aux = col1
                            col1 = col2
                            col2 = aux
                        End If
                        If i <= y2 And j <= x2 Then
                            mreal(i, j) = col1
                        Else
                            mreal(i, j) = col2
                        End If

                    Case 10 'Calculos del caso 10.
                        mreal(i, j) = Sin(x * y) / (2 * i + nc * nf)

                    Case 11 'Circunferencias media.
                        dis = Sqrt((i - nf / 2) ^ 2 + (j - nc / 2) ^ 2)
                        If dis < nc / 2 * 0.5 And i <= y2 Then
                            mreal(i, j) = 1
                        Else
                            mreal(i, j) = 0
                        End If
                        dis = Sqrt((i - nf / 2) ^ 2 + (j - nc / 2) ^ 2) * 2
                        If dis < nc / 2 * 0.5 And i <= y2 Then
                            mreal(i, j) = 0
                        End If

                    Case 12 'Calculos del caso 12.
                        Dim c As Integer
                        c = 10
                        mreal(i, j) = (1 / c) * (E ^ (-0.5 * (x ^ 2 + y ^ 2) / (c ^ 2)))

                End Select

                x = x + dx

            Next

            If funcion = 11 Then

                If i <= y2 And i >= y1 Then
                    x2 = x2 + 1
                    x1 = x1 - 1
                End If

            End If

            y = y + dy

        Next

        'Convertir la matriz generada en imagen.
        mdouble_to_bitmap(mreal, i1)

        'i1 es una umagen en escala de grises.
        If ponercolor Then

            colorear_imagen(i1, tcolor)

        End If

        'Ajusta el ancho de como se muestra la imagen generada en el PictureBox.
        pb.Width = i1.Width
        'Ajusta el alto de como se muestra la imagen generada en el PictureBox.
        pb.Height = i1.Height
        'Se asigna la imagen en el PictureBox.
        pb.Image = i1

    End Sub

    'Método colorear_imagen tiene como parametros (La imagen generada, el color asignado).
    Sub colorear_imagen(ByRef i1 As Bitmap, ByRef tcolor(,) As Integer)

        'Declara las variables i, j, valor, de tipo Integer.
        Dim i, j, valor As Integer

        'Declara ña variable micolor, de tipo Color.
        Dim micolor As Color

        'Inicia un bucle que empieza en i = 0 y termina con el valor del ancho -1 de la imagen.
        For i = 0 To i1.Width - 1

            'Inicia un bucle que empieza en j = 0 y termina con el valor del alto -1 de la imagen.
            For j = 0 To i1.Height - 1

                'Se asigna a la variable micolor los pixeles de la imagen.
                micolor = i1.GetPixel(j, i)

                'Se asigna a la variable valor el color.
                valor = micolor.R

                'Se asigna el color respectivo.
                micolor = Color.FromArgb(tcolor(valor, 0), tcolor(valor, 1), tcolor(valor, 2))
                i1.SetPixel(j, i, micolor)

            Next 'Fin del bucle del alto.

        Next 'Fin del bucle del ancho.

    End Sub

    'Método mdouble_to_bitmap tiene como parametros (El arreglo del alto y ancho de la imagen, el color asignado).
    Sub mdouble_to_bitmap(ByRef mr(,) As Double, ByVal imagen As Bitmap)

        'Pasa una matriz de doubles a imagen.
        Dim i, j, nf, nc, ng As Integer

        'Numero de filas y columnas de la matriz para los indices.
        nf = UBound(mr, 1)
        nc = UBound(mr, 2)

        'Obtencion de valmin y valmax de mr.
        Dim vmin, vmax As Double
        vmin = mr(0, 0) : vmax = mr(0, 0)
        For i = 0 To nf
            For j = 0 To nc
                If mr(i, j) > vmax Then vmax = mr(i, j)
                If mr(i, j) < vmin Then vmin = mr(i, j)
            Next
        Next

        'Uso de bitmapdata.
        'Define los datos.
        Dim datos As BitmapData
        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer

        'Lock the bitmap's bits, get a BitmapData object.
        Dim rect As New Rectangle(0, 0, width, height)
        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)

        'Obtener la dirección de su primera línea de exploración
        Dim ptr As IntPtr = datos.Scan0

        'Prepara una matriz que reciba todos los píxeles
        Dim bytes As Integer = datos.Stride * height
        Dim pixels(bytes) As Byte
        Dim nbpp As Integer
        nbpp = 3
        vmax = vmax - vmin
        For i = 0 To nf
            For j = 0 To nc
                mr(i, j) = mr(i, j) - vmin
                index = (i * datos.Stride) + (j * nbpp) 'Numero de bytes por pixel
                ng = Convert.ToInt16(mr(i, j) / vmax * 255)
                If ng < 0 Then ng = 0
                If ng > 255 Then ng = 255
                'Para 24 bits
                pixels(index) = ng 'R
                pixels(index + 1) = ng 'G
                pixels(index + 2) = ng 'B
            Next
        Next

        Marshal.Copy(pixels, 0, ptr, bytes)  'Se pasa datos a bitmap
        imagen.UnlockBits(datos)

    End Sub

    Sub OPERACIONES(ByRef I1 As Bitmap, ByRef I2 As Bitmap, ByRef I3 As Bitmap, _
                    ByRef oper As Integer)
        'i1, i2 imagenes de entrada
        'i3 imagen resultado
        'oper operador 1 suma 2 resta 3 mult 4 division 5 mascara 6 maximos, 7 minimos, 
        'oper promedios

        'tamaños de i1, i2, i3 son iguales
        Dim nf, nc, i, j, k As Integer
        nf = I1.Height - 1 : nc = I1.Width - 1
        Dim m1(nf, nc, 2), m2(nf, nc, 2) As Integer
        Dim m3(nf, nc, 2) As Double

        'pasar imagenes a matrices
        bitmap_to_mRGB(I1, m1)
        'Debug.Print("RASTREO M1 " & m1(100, 100, 0) & " " & m1(100, 100, 1) & " " & m2(100, 100, 2))
        bitmap_to_mRGB(I2, m2)
        Dim s, l As Integer
        If oper = 13 Then
            s = Convert.ToDouble(InputBox("Valor de k"))
            l = Convert.ToDouble(InputBox("Valor de l"))
        End If
        For k = 0 To 2
            For i = 0 To nf
                For j = 0 To nc
                    Select Case oper
                        Case 1
                            m3(i, j, k) = Convert.ToDouble(m1(i, j, k) + m2(i, j, k))

                        Case 2
                            m3(i, j, k) = m1(i, j, k) - m2(i, j, k)
                        Case 3
                            m3(i, j, k) = m1(i, j, k) * m2(i, j, k)
                        Case 4
                            m3(i, j, k) = Convert.ToDouble(m1(i, j, k)) / Convert.ToDouble((m2(i, j, k) + 1))
                        Case 5
                            'mascara, i2 es  la mascara

                            If (m2(i, j, k) = 255) Then m3(i, j, k) = m1(i, j, k)
                        Case 6 'And
                            m3(i, j, k) = 0
                            If m1(i, j, k) = 255 And m2(i, j, k) = 255 Then
                                m3(i, j, k) = 255
                            End If
                        Case 7 'XOR
                            m3(i, j, k) = 0
                            'If (m1(i, j, k) = 255 And m2(i, j, k) = 0) Or (m1(i, j, k) = 0 And m2(i, j, k) = 255) Then
                            If m1(i, j, k) = 255 Xor m2(i, j, k) = 255 Then
                                m3(i, j, k) = 255
                            End If
                        Case 8 'C=(A+B)/2
                            m3(i, j, k) = (m1(i, j, k) + m2(i, j, k)) / 2
                        Case 9 'C=(MAX(A,B))
                            m3(i, j, k) = Convert.ToDouble(Max(m1(i, j, k), m2(i, j, k)))
                        Case 10 'C=(MIN(A,B))
                            m3(i, j, k) = Convert.ToDouble(Min(m1(i, j, k), m2(i, j, k)))
                        Case 11 'OR
                            m3(i, j, k) = 0
                            If m1(i, j, k) = 255 Or m2(i, j, k) = 255 Then
                                m3(i, j, k) = 255
                            End If
                        Case 12 'COMPLEMENTO: C=A SI B=0;B IMAGEN BINARIA
                            If m2(i, j, k) = 0 Then m3(i, j, k) = m1(i, j, k)
                        Case 13 'C=K*A+LB,K,L SON CONSTANTES
                            m3(i, j, k) = Convert.ToDouble(m1(i, j, k) * s + m2(i, j, k) * l)
                    End Select
                Next j
            Next i

        Next k
        'normalizacion de m3 a valores de 0 a 255
        normalizar_0_255(m3)
        'Debug.Print("RASTREO M3 " & m1(100, 100, 0) & " " & m2(100, 100, 0) & " " & m3(100, 100, 0))
        mdouble3d_to_bitmap(m3, I3)
    End Sub
    Sub normalizar_0_255(ByRef m2(,,) As Double)
        Dim i, j, k As Integer
        Dim nf, nc, np As Integer
        nf = UBound(m2, 1)
        nc = UBound(m2, 2)
        np = UBound(m2, 3)
        'obtencion de valmin y valmax de mr
        Dim vmin, vmax As Double
        For k = 0 To np
            vmin = m2(0, 0, k) : vmax = m2(0, 0, k)
            For i = 0 To nf
                For j = 0 To nc
                    If m2(i, j, k) > vmax Then vmax = m2(i, j, k)
                    If m2(i, j, k) < vmin Then vmin = m2(i, j, k)
                Next
            Next
            vmax = vmax - vmin
            For i = 0 To nf
                For j = 0 To nc
                    m2(i, j, k) = m2(i, j, k) - vmin
                    m2(i, j, k) = m2(i, j, k) * 255 / vmax
                    If m2(i, j, k) < 0 Then m2(i, j, k) = 0
                    If m2(i, j, k) > 255 Then m2(i, j, k) = 255
                Next
            Next
        Next k
    End Sub
    Sub mdouble3d_to_bitmap(ByRef mr(,,) As Double, ByVal imagen As Bitmap)
        ' pasa una matriz de doubles en 3d a imagen
        ' mr debe estar entre 0 Y  255
        ' no realiza el cambio de escala de 0 a 255
        Dim i, j, k, nf, nc, ng As Integer
        'numero de filas y columnas de la matriz para los indices
        nf = UBound(mr, 1)
        nc = UBound(mr, 2)

        ' uso de bitmapdata
        ' define los datos
        Dim datos As BitmapData
        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer
        ' Lock the bitmap's bits, get a BitmapData object
        Dim rect As New Rectangle(0, 0, width, height)
        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)
        'MessageBox.Show(imagen.PixelFormat.ToString)
        ' Get the address of its first scan line
        Dim ptr As IntPtr = datos.Scan0
        ' Prepare an array that will receive all the pixels
        Dim bytes As Integer = datos.Stride * height
        Dim pixels(bytes) As Byte
        Dim nbpp As Integer
        nbpp = 3
        For k = 0 To 2
            For i = 0 To nf
                For j = 0 To nc
                    index = (i * datos.Stride) + (j * nbpp) ' num bytes per pixel
                    ng = Convert.ToInt16(mr(i, j, k))
                    If ng < 0 Then ng = 0
                    If ng > 255 Then ng = 255
                    pixels(index + k) = ng 'r
                Next
            Next
        Next k 'fin for k
        Marshal.Copy(pixels, 0, ptr, bytes)  'paso de datos a bitmap
        imagen.UnlockBits(datos)
    End Sub
    Sub bitmap_to_mRGB(ByRef imagen As Bitmap, ByRef mat(,,) As Integer)
        'usa bitmapdata
        'pasa los tres planos a una matriz de tres dimensiones


        Dim datos As BitmapData  'inf de valores de pixeles
        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer 'indice para barrer todos los pix de la imagen
        ' Lock the bitmap's bits, get a BitmapData object
        Dim rect As New Rectangle(0, 0, width, height) 'define un rectangulo
        '                                               del tamaño de la imagen
        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)
        'paso todos los pixeles a datos
        ' Get the address of its first scan line
        Dim ptr As IntPtr = datos.Scan0  'dirección de datos

        ' Prepare an array that will receive all the pixels
        Dim bytes As Integer = datos.Stride * height 'num total de pix del bitmapdata
        Dim pixels(bytes) As Byte

        ' Copy the pixels into the array
        Marshal.Copy(ptr, pixels, 0, bytes)

        ' Now we have the data in a buffer, we can process it much more quickly than GetPixel/SetPixel
        ' The buffer elements now contain RGB data thus:
        ' R1 G1 B1 R2 G2 B2 R3 G3 B3...Rn Gn Bn
        ' so we traverse the array in steps of 3.  (Note: this is because it's 3 bytes per pixel.  Change this for other formats)
        Dim i, j As Integer

        For i = 0 To height - 1
            For j = 0 To width - 1
                index = (i * datos.Stride) + (j * 3) ' 3 bytes per pixel

                mat(i, j, 0) = pixels(index)
                mat(i, j, 1) = pixels(index + 1)
                mat(i, j, 2) = pixels(index + 2)
            Next
        Next
        imagen.UnlockBits(datos)
    End Sub
    Sub bitmap_to_mRGB(ByRef imagen As Bitmap, ByRef mat(,,) As Double)
        'usa bitmapdata
        'pasa los tres planos a una matriz de tres dimensiones


        Dim datos As BitmapData  'inf de valores de pixeles
        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer 'indice para barrer todos los pix de la imagen
        ' Lock the bitmap's bits, get a BitmapData object
        Dim rect As New Rectangle(0, 0, width, height) 'define un rectangulo
        '                                               del tamaño de la imagen
        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)
        'paso todos los pixeles a datos
        ' Get the address of its first scan line
        Dim ptr As IntPtr = datos.Scan0  'dirección de datos

        ' Prepare an array that will receive all the pixels
        Dim bytes As Integer = datos.Stride * height 'num total de pix del bitmapdata
        Dim pixels(bytes) As Byte

        ' Copy the pixels into the array
        Marshal.Copy(ptr, pixels, 0, bytes)

        ' Now we have the data in a buffer, we can process it much more quickly than GetPixel/SetPixel
        ' The buffer elements now contain RGB data thus:
        ' R1 G1 B1 R2 G2 B2 R3 G3 B3...Rn Gn Bn
        ' so we traverse the array in steps of 3.  (Note: this is because it's 3 bytes per pixel.  Change this for other formats)
        Dim i, j As Integer

        For i = 0 To height - 1
            For j = 0 To width - 1
                index = (i * datos.Stride) + (j * 3) ' 3 bytes per pixel
                mat(i, j, 0) = pixels(index)
                mat(i, j, 1) = pixels(index + 1)
                mat(i, j, 2) = pixels(index + 2)
            Next
        Next
        imagen.UnlockBits(datos)
    End Sub
    Sub descomponer(ByRef img As Bitmap, ByRef matbin(,,) As Integer, ByRef a_img() As Bitmap)
        Dim i, j, k As Integer
        Dim nf, nc As Integer
        nf = img.Height - 1 : nc = img.Width - 1
        Dim m1(nf, nc) As Integer
        bitmap_to_m(img, m1)
        'matbin debe estar con las dimensiones apropiadas
        matriz_to_planos(m1, matbin)
        'convertir los planos binarios a imagen
        For k = 0 To 7
            matrizplano_to_bitmap(matbin, k, a_img(k), "24ppp")
        Next
        MsgBox("Proceso de Descomposicion Finlizado")
    End Sub
    Sub copiarmatriz_to_plano(ByRef matrizplanos(,,) As Integer, _
                           ByRef plano As Integer, _
                           ByRef matrizbinaria(,) As Integer)
        'matrizplanos  --> matriz de planos
        'plano que se desea modificar
        'matrizbinaria matriz a ser pasada
        Dim i, j, k, nf, nc As Integer
        nf = UBound(matrizbinaria, 1)
        nc = UBound(matrizbinaria, 2)
        For i = 0 To nf
            For j = 0 To nc
                If matrizbinaria(i, j) = 255 Then
                    matrizplanos(i, j, plano) = 1
                Else
                    matrizplanos(i, j, plano) = 0
                End If
            Next
        Next
    End Sub
    Sub copiarplanobinario_to_matriz(ByRef matrizplanos(,,) As Integer, _
                         ByRef plano As Integer, _
                         ByRef matrizbinaria(,) As Double)
        'matrizplanos  --> matriz de planos
        'plano que se desea modificar
        'matrizbinaria matriz a ser pasada
        Dim i, j, k, nf, nc As Integer
        nf = UBound(matrizbinaria, 1)
        nc = UBound(matrizbinaria, 2)
        For i = 0 To nf
            For j = 0 To nc
                matrizbinaria(i, j) = matrizplanos(i, j, plano)
            Next
        Next
    End Sub
    Sub reconstruirimagen(ByRef matrizplanos(,,) As Integer, _
                            ByRef img2 As Bitmap)
        Dim i, j, k, nf, nc As Integer
        nf = UBound(matrizplanos, 1)
        nc = UBound(matrizplanos, 2)
        Dim matrizimag(nf, nc) As Integer
        For i = 0 To nf
            For j = 0 To nc
                matrizimag(i, j) = 0
                For k = 0 To 7
                    'recnctruye los valores binarios
                    matrizimag(i, j) += matrizplanos(i, j, k) * 2 ^ k
                Next
            Next
        Next
        matrizint_to_bitmap(matrizimag, img2, "24bbp")
    End Sub
    Sub matrizint_to_bitmap(ByVal m(,) As Integer, _
                             ByRef imagen As Bitmap, _
                             ByRef formato As String)
        'pasa mr (,) a imagen, usa formato
        ' este es el proceso inverso del bitmap_to_matrizRGB 
        'valores normalizados de VMIN A VMAX
        Dim i, j, nf, nc, ng As Integer
        'numero de filas y columnas de la matriz para los indices
        nf = UBound(m, 1)
        nc = UBound(m, 2)
        ' uso de bitmapdata
        ' define los datos
        Dim datos As BitmapData
        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer
        ' Lock the bitmap's bits, get a BitmapData object
        Dim rect As New Rectangle(0, 0, width, height)
        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)
        'MessageBox.Show(imagen.PixelFormat.ToString)


        ' Get the address of its first scan line
        Dim ptr As IntPtr = datos.Scan0

        ' Prepare an array that will receive all the pixels
        Dim bytes As Integer = datos.Stride * height
        Dim pixels(bytes) As Byte
        Dim nbpp As Integer = 3
        If formato = "32bpp" Then nbpp = 4
        For i = 0 To nf
            For j = 0 To nc
                index = (i * datos.Stride) + (j * nbpp) ' num bytes per pixel
                ng = m(i, j)
                'para 24 bits
                pixels(index) = ng 'r
                pixels(index + 1) = ng 'g
                pixels(index + 2) = ng 'b
                If formato = "32bpp" Then
                    pixels(index + 3) = 255
                End If
            Next
        Next
        Marshal.Copy(pixels, 0, ptr, bytes)
        imagen.UnlockBits(datos)
    End Sub
    Sub matrizplano_to_bitmap(ByVal m(,,) As Integer, _
                              ByVal plano As Integer, _
                             ByRef imagen As Bitmap, _
                             ByRef formato As String)
        'pasa m (,,) a imagen, usa formato
        ' matriz binaria
        'plano: plano a graficar
        Dim i, j, nf, nc, ng As Integer
        'numero de filas y columnas de la matriz para los indices
        nf = UBound(m, 1)
        nc = UBound(m, 2)
        ' uso de bitmapdata
        ' define los datos
        Dim datos As BitmapData
        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer
        ' Lock the bitmap's bits, get a BitmapData object
        Dim rect As New Rectangle(0, 0, width, height)
        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)
        'MessageBox.Show(imagen.PixelFormat.ToString)


        ' Get the address of its first scan line
        Dim ptr As IntPtr = datos.Scan0

        ' Prepare an array that will receive all the pixels
        Dim bytes As Integer = datos.Stride * height
        Dim pixels(bytes) As Byte
        Dim nbpp As Integer = 3
        Dim valor As Integer
        If formato = "32bpp" Then nbpp = 4
        For i = 0 To nf
            For j = 0 To nc
                index = (i * datos.Stride) + (j * nbpp) ' num bytes per pixel
                ng = m(i, j, plano)
                If ng = 1 Then
                    valor = 255
                Else
                    valor = 0
                End If

                'para 24 bits
                pixels(index) = valor 'r
                pixels(index + 1) = valor 'g
                pixels(index + 2) = valor 'b
                If formato = "32bpp" Then
                    pixels(index + 3) = 255
                End If
            Next
        Next
        Marshal.Copy(pixels, 0, ptr, bytes)
        imagen.UnlockBits(datos)
    End Sub
    Sub matriz_to_planos(ByRef m1(,) As Integer, ByRef m1p(,,) As Integer)
        'decompone matriz de enteros en 8 planos binarios
        Dim i, j, k As Integer
        Dim nf, nc, valor As Integer
        nf = UBound(m1, 1)
        nc = UBound(m1, 2)
        Dim pot2 As Integer
        For i = 0 To nf
            For j = 0 To nc
                valor = m1(i, j)
                pot2 = 256
                For k = 7 To 0 Step -1
                    pot2 = pot2 / 2
                    If valor >= pot2 Then
                        m1p(i, j, k) = 1
                        valor = valor - pot2
                    Else
                        m1p(i, j, k) = 0
                    End If
                Next
            Next
        Next

    End Sub
    'Histograma
    Sub visualizar(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef forma As String)
        Dim nf, nc, i, j, k As Integer
        Dim valor As Double
        nf = i1.Height - 1
        nc = i1.Width - 1
        Dim m1(nf, nc, 2), m2(nf, nc, 2) As Double
        'pasar i1 a m1
        bitmap_to_mRGB(i1, m1)
        'CALCULO EN M2
        If forma = "Gamma" Or forma = "Constantes" Or forma = "Constantes 2" Or forma = "Binarizacion" Then
            valor = InputBox("Ingrese un Valor para transformacion " & forma)
        End If
        For i = 0 To nf
            For j = 0 To nc
                For k = 0 To 2
                    Select Case forma
                        Case "Log"
                            m2(i, j, k) = Math.Log10(m1(i, j, k) + 1)
                        Case "Ln"
                            m2(i, j, k) = 255 * Math.Log(m1(i, j, k) + 1) / Math.Log(256)
                        Case "Raiz Cuadrada"
                            m2(i, j, k) = Math.Sqrt(m1(i, j, k) * 255)
                        Case "Cuadrado"
                            m2(i, j, k) = (m1(i, j, k)) * (m1(i, j, k)) / 255
                        Case "Negativo"
                            m2(i, j, k) = 255 - (m1(i, j, k))
                        Case "Gamma"
                            m2(i, j, k) = m1(i, j, k) ^ valor
                        Case "Constantes"
                            m2(i, j, k) = m1(i, j, k) + valor
                        Case "Constantes 2"
                            m2(i, j, k) = m1(i, j, k) + valor
                            If m2(i, j, k) > 255 Then m2(i, j, k) = 255
                            If m2(i, j, k) < 0 Then m2(i, j, k) = 0
                        Case "Gris 1"
                            'convertir una imagen de color a gris
                            '                   rojo             azul                verde
                            m2(i, j, k) = m1(i, j, 0) * 0.3 + m1(i, j, 1) * 0.59 + m1(i, j, 2) * 0.11
                        Case "Gris 2"
                            'convertir una imagen de color a gris
                            m2(i, j, k) = m1(i, j, 0) * 0.33333333 + m1(i, j, 1) * 0.33333333 + m1(i, j, 2) * 0.33333333
                        Case "Binarizacion"
                            'm2(i, j, k) = i1.GetPixel(j, i).R
                            If m1(i, j, k) < valor Then m2(i, j, k) = 0 Else m2(i, j, k) = 255
                    End Select
                Next
            Next
        Next
        'pasar m2 a i2
        Select Case forma
            Case "Log"
                normalizar_0_255(m2)
            Case "Raiz Cuadrada"
                normalizar_0_255(m2)
            Case "Cuadrado"
                normalizar_0_255(m2)
            Case "Gamma"
                normalizar_0_255(m2)
            Case "Constantes"
                normalizar_0_255(m2)
        End Select
        mdouble3d_to_bitmap(m2, i2)
    End Sub

    Sub histo1(ByVal imagen As Bitmap, ByRef picturebox As PictureBox,
             ByRef tex100 As Label, ByRef tex75 As Label,
             ByRef text50 As Label, ByRef text25 As Label,
             ByRef plano As Integer)
        Dim ancho, alto, i, j, nivelgris As Integer
        Dim color1 As Color
        Dim NIVELES(256) As Long
        ancho = imagen.Width
        alto = imagen.Height


        Dim m1(alto - 1, ancho - 1, 2) As Integer

        'bitmap_to_mRGB(imagen, m1)
        bitmap_to_mRGB(imagen, m1)
        Dim nf, nc As Integer
        nf = alto - 1
        nc = ancho - 1

        For i = 0 To nf
            For j = 0 To nc
                nivelgris = (m1(i, j, plano))
                NIVELES(nivelgris) += 1
            Next  'J
        Next 'I

        'BUSQUEDA DEL MAYOR
        Dim maxval As Long
        maxval = NIVELES(0)
        For i = 1 To 255
            If (maxval < NIVELES(i)) Then
                maxval = NIVELES(i)
            End If
        Next

        tex100.Text = maxval
        tex75.Text = maxval * 3 / 4
        text50.Text = maxval / 2
        text25.Text = maxval / 4
        'factor de escala
        Dim factor As Single
        factor = 200 / maxval
        For i = 0 To 255
            NIVELES(i) = Convert.ToInt32(Convert.ToSingle(NIVELES(i)) * factor)

        Next
        'graficar  
        Dim area As Graphics
        Dim pluma As Pen

        area = picturebox.CreateGraphics
        If plano = 0 Then color1 = Color.Red
        If plano = 1 Then color1 = Color.Green
        If plano = 2 Then color1 = Color.Blue

        pluma = New Pen(color1)

        pluma.Width = 1
        area.Clear(picturebox.BackColor)
        For j = 0 To 255
            area.DrawLine(pluma, j + 4, 200 - NIVELES(j), j + 4, 200)

        Next
    End Sub
    Sub ecualizar(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef var As Integer, ByRef texto As TextBox)
        Dim ancho, alto, i, j, nivelgris As Integer
        Dim NIVELES(255) As Long
        Dim histoacum(255) As Double
        ancho = i1.Width
        alto = i1.Height
        Dim m1(alto - 1, ancho - 1, 2) As Integer
        Dim m2(alto - 1, ancho - 1, 2) As Double
        'bitmap_to_mRGB(imagen, m1)
        bitmap_to_mRGB(i1, m1)
        Dim k, nf, nc As Integer
        nf = alto - 1
        nc = ancho - 1
        Dim v1, alpha As Double
        alpha = 0.5
        For k = 0 To 2
            'calcula histrogram de cada plano
            For i = 0 To 255 : NIVELES(i) = 0 : Next i
            For i = 0 To nf
                For j = 0 To nc
                    nivelgris = (m1(i, j, k))
                    NIVELES(nivelgris) += 1
                Next  'J
            Next 'I
            'calculo del histograma acumulado normalizado
            histoacum(0) = NIVELES(0)
            For i = 1 To 255
                histoacum(i) = histoacum(i - 1) + NIVELES(i)
            Next i
            'normalizacion
            For i = 0 To 255
                histoacum(i) = histoacum(i) / (ancho * alto)
            Next
            'proceso de ecualizacion

            For i = 0 To nf
                For j = 0 To nc
                    nivelgris = (m1(i, j, k))
                    v1 = histoacum(nivelgris)
                    Select Case var
                        Case 1
                            m2(i, j, k) = 255 * v1
                        Case 2
                            m2(i, j, k) = 255 * v1 * v1
                        Case 3
                            m2(i, j, k) = 255 * Sqrt(v1)
                        Case 4
                            m2(i, j, k) = Exp(v1 * Log(256)) - 1
                        Case 5 'cubica
                            m2(i, j, k) = 255 * v1 * v1 * v1
                        Case 6
                            m2(i, j, k) = (255 * 255 * (v1 * 1 / 3))
                        Case 7
                            m2(i, j, k) = 255 * (Log(1 + v1) / Log(1 + 255))
                        Case 8
                            m2(i, j, k) = (255 / 2) * (1 + (1 / Sin(alpha * (PI / 2)) * Sin(alpha * (PI / 2) * ((v1 / 255) - (1 / 2)))))
                        Case 9
                            m2(i, j, k) = (255 / 2) * (1 + (1 / Tan(alpha * (PI / 2)) * Tan(alpha * (PI / 2) * ((v1 / 255) - (1 / 2)))))
                    End Select
                Next  'J
            Next 'I
        Next k  'fin de cada plano
        'Stop
        mdouble3d_to_bitmap(m2, i2)
        'mostrar resultados
        Dim cadena As String
        cadena = "-ng- ---num px---" & vbCrLf
        For i = 0 To 255
            cadena = cadena & i & vbTab
            cadena = cadena & NIVELES(i) & vbCrLf 'vbTab
        Next
        texto.Text = cadena
    End Sub
    Sub histoacumulado(ByVal imagen As Bitmap, ByRef picturebox As PictureBox,
                   ByRef tex100 As Label, ByRef tex75 As Label,
                   ByRef text50 As Label, ByRef text25 As Label,
                    ByRef plano As Integer)
        Dim ancho, alto, i, j, nivelgris As Integer
        Dim color1 As Color
        Dim NIVELES(256) As Long
        ancho = imagen.Width
        alto = imagen.Height


        Dim m1(alto - 1, ancho - 1, 2),
                     m2(alto - 1, ancho - 1, 2) _
                     As Double

        bitmap_to_mRGB(imagen, m1)
        Dim nf, nc As Integer
        nf = alto - 1
        nc = ancho - 1

        For i = 0 To nf
            For j = 0 To nc
                nivelgris = Convert.ToInt32(m1(i, j, plano))
                NIVELES(nivelgris) += 1
            Next  'J
        Next 'I
        'histograma acumulado
        For i = 1 To 255
            NIVELES(i) = NIVELES(i) + NIVELES(i - 1)
        Next

        Dim maxval As Long
        maxval = NIVELES(255)


        tex100.Text = maxval
        tex75.Text = maxval * 3 / 4
        text50.Text = maxval / 2
        text25.Text = maxval / 4
        'factor de escala
        Dim factor As Single
        factor = 200 / maxval
        For i = 0 To 255
            NIVELES(i) = Convert.ToInt32(Convert.ToSingle(NIVELES(i)) _
                                         * factor)
        Next
        'graficar  
        Dim area As Graphics
        Dim pluma As Pen
        area = picturebox.CreateGraphics
        If plano = 0 Then color1 = Color.Red
        If plano = 1 Then color1 = Color.Green
        If plano = 2 Then color1 = Color.Blue
        pluma = New Pen(color1)
        pluma.Width = 1
        area.Clear(picturebox.BackColor)
        For j = 0 To 255
            area.DrawLine(pluma, j, 200 - NIVELES(j), j, 200)
        Next
    End Sub
    Sub contraer_expandir_histo(ByRef imagen As Bitmap, ByRef i2 As Bitmap, ByRef v1 As Integer, ByRef v2 As Integer)
        Dim NIVELES(256) As Long
        Dim ancho, alto, nivelgris, vmaxh, vminh As Integer
        ancho = imagen.Width
        alto = imagen.Height


        Dim m1(alto - 1, ancho - 1) As Integer
        Dim m2(alto - 1, ancho - 1) As Integer

        'bitmap_to_mRGB(imagen, m1)
        bitmap_to_m(imagen, m1)
        Dim nf, nc As Integer
        nf = alto - 1
        nc = ancho - 1

        For i = 0 To nf
            For j = 0 To nc
                nivelgris = m1(i, j)
                NIVELES(nivelgris) += 1
            Next  'J
        Next 'I
        vmaxh = 255
        vminh = 0
        For i = 0 To 255
            If NIVELES(i) > 0 Then
                vminh = i
                Exit For
            End If
        Next i
        For i = 255 To 0 Step -1
            If NIVELES(i) > 0 Then
                vmaxh = i
                Exit For
            End If
        Next i
        'proceso de la matriz

        For i = 0 To nf
            For j = 0 To nc
                nivelgris = m1(i, j)
                m2(i, j) = Convert.ToInt32(Convert.ToDouble((nivelgris - vminh) * (v2 - v1)) / Convert.ToDouble((vmaxh - vminh)) + v1)
            Next  'J
        Next 'I
        matrizint_to_bitmap(m2, i2, "24bpp")

    End Sub
    'Trnasformaciones Geometricas 
    Sub cambiotamaño_origen_destino(ByRef i1 As Bitmap, _
                                  ByRef i2 As Bitmap, _
                                  ByRef factor As Double)
        'i1, i2 son imagenes a color, 3 planos
        Dim nf1, nc1, nf2, nc2 As Integer
        nf1 = i1.Height - 1 : nc1 = i1.Width - 1
        nf2 = i2.Height - 1 : nc2 = i2.Width - 1
        'dimensionamiento de matrices
        Dim m1(nf1, nc1, 2), m2(nf2, nc2, 2) As Integer
        bitmap_to_mRGB(i1, m1)
        'calculo de m2
        Dim ior, jor, ides, jdes As Integer
        For ior = 0 To nf1  'bucles de barrido en m1
            ides = ior * factor
            If ides > nf2 Then ides = nf2
            If ides < 0 Then ides = 0 'redundante
            For jor = 0 To nc1
                jdes = jor * factor
                If jdes > nc2 Then jdes = nc2
                If jdes < 0 Then jdes = 0
                For k = 0 To 2
                    m2(ides, jdes, k) = m1(ior, jor, k)
                Next
            Next
        Next
        'pasar m2 a imagen
        mint3d_to_bitmap(m2, i2)

    End Sub
    Sub cambiotamaño_vecinoproximo(ByRef i1 As Bitmap, _
                                   ByRef i2 As Bitmap, _
                                   ByRef factor As Double)
        'i1, i2 son imagenes a color, 3 planos
        Dim nf1, nc1, nf2, nc2 As Integer
        nf1 = i1.Height - 1 : nc1 = i1.Width - 1
        nf2 = i2.Height - 1 : nc2 = i2.Width - 1
        'dimensionamiento de matrices
        Dim m1(nf1, nc1, 2), m2(nf2, nc2, 2) As Integer
        bitmap_to_mRGB(i1, m1)
        'calculo de m2
        Dim ior, jor As Integer
        'barre en el destino y calcula ior jor
        For i = 0 To nf2         'bucles de barrido en m2
            ior = Convert.ToInt32(Convert.ToDouble(i) / factor)
            If ior > nf1 Then ior = nf1
            If ior < 0 Then ior = 0
            For j = 0 To nc2
                jor = Convert.ToInt32(Convert.ToDouble(j) / factor)
                If jor > nc1 Then jor = nc1
                If jor < 0 Then jor = 0
                For k = 0 To 2
                    m2(i, j, k) = m1(ior, jor, k)
                Next
            Next
        Next
        'pasar m2 a imagen
        mint3d_to_bitmap(m2, i2)

    End Sub
    Sub cambiotamaño_interpolacionbilineal(ByRef i1 As Bitmap, _
                                  ByRef i2 As Bitmap, _
                                  ByRef factor As Double)
        'i1, i2 son imagenes a color, 3 planos
        Dim nf1, nc1, nf2, nc2 As Integer
        nf1 = i1.Height - 1 : nc1 = i1.Width - 1
        nf2 = i2.Height - 1 : nc2 = i2.Width - 1
        'dimensionamiento de matrices
        Dim m1(nf1, nc1, 2), m2(nf2, nc2, 2) As Integer
        bitmap_to_mRGB(i1, m1)
        'calculo de m2
        Dim ior, jor As Integer  'indices correspondientes en m1
        Dim dx, dy As Double
        Dim v1, v2, v3, v4, incx, incy As Integer
        For i = 0 To nf2         'bucles de barrido en m2
            ior = Math.Floor(Convert.ToDouble(i) / factor)
            dy = Convert.ToDouble(i) / factor - ior
            If ior > nf1 Then ior = nf1
            If ior < 0 Then ior = 0
            incy = 1
            If ior + incy > nf1 Then incy = 0

            For j = 0 To nc2
                jor = Math.Floor(Convert.ToDouble(j) / factor)
                dx = Convert.ToDouble(j) / factor - jor
                If jor > nc1 Then jor = nc1
                If jor < 0 Then jor = 0
                incx = 1
                If jor + incx > nc1 Then incx = 0
                For k = 0 To 2
                    v1 = m1(ior, jor, k)
                    v2 = m1(ior, jor + incx, k)
                    v3 = m1(ior + incy, jor, k)
                    v4 = m1(ior + incy, jor + incx, k)



                    m2(i, j, k) = interp_valor(v1, v2, v3, v4, dx, dy)
                    'If j = 102 And i = 102 Then
                    '    Debug.Print("VALORES DE INTERPOLACION" & vbCrLf _
                    '                & "I = " & i & ",  J = " & j & vbCrLf _
                    '                & "IOR = " & ior & ",  JOR = " & jor & vbCrLf _
                    '                & "DX = " & dx & ",  DY = " & dy & vbCrLf)
                    'End If
                Next
            Next
        Next
        'pasar m2 a imagen
        mint3d_to_bitmap(m2, i2)

    End Sub
    Sub cambiotamaño_interpolacionbicubica(ByRef i1 As Bitmap, _
                                 ByRef i2 As Bitmap, _
                                 ByRef factor As Double)
        'i1, i2 son imagenes a color, 3 planos
        Dim nf1, nc1, nf2, nc2, iiaux, jjaux As Integer
        nf1 = i1.Height - 1 : nc1 = i1.Width - 1
        nf2 = i2.Height - 1 : nc2 = i2.Width - 1
        'dimensionamiento de matrices
        Dim m1(nf1, nc1, 2), m2(nf2, nc2, 2) As Integer
        bitmap_to_mRGB(i1, m1)
        'calculo de m2
        Dim ior, jor As Integer  'indices correspondientes en m1
        Dim dx, dy As Double
        Dim v1, v2, v3, v4, incx, incy, ii1, jj1 As Integer
        Dim valores(3, 3) As Double
        Dim icont, jcont As Integer
        'metodo destino origen
        'barrer matris destino y calcular valor de matriz origen
        For i = 0 To nf2         'bucles de barrido en m2
            ior = Math.Floor(Convert.ToDouble(i) / factor)
            dy = Convert.ToDouble(i) / factor - ior
            If ior > nf1 Then ior = nf1
            If ior < 0 Then ior = 0


            For j = 0 To nc2
                jor = Math.Floor(Convert.ToDouble(j) / factor)
                dx = Convert.ToDouble(j) / factor - jor
                If jor > nc1 Then jor = nc1
                If jor < 0 Then jor = 0

                For k = 0 To 2
                    icont = 0
                    'recuperar los 16 pixeles para la interpolacion
                    For ii1 = ior - 1 To ior + 2
                        If ii1 < 0 Or ii1 > nf1 Then
                            iiaux = ior
                        Else
                            iiaux = ii1
                        End If
                        jcont = 0
                        For jj1 = jor - 1 To jor + 2
                            If jj1 < 0 Or jj1 > nc1 Then
                                jjaux = jor
                            Else
                                jjaux = jj1
                            End If

                            valores(icont, jcont) = m1(iiaux, jjaux, k)
                            jcont += 1
                        Next jj1
                        icont += 1
                    Next ii1

                    'interpolacion

                    m2(i, j, k) = interp_bicubica(valores, dx, dy)



                    'If j = 102 And i = 102 Then
                    '    Debug.Print("VALORES DE INTERPOLACION" & vbCrLf _
                    '                & "I = " & i & ",  J = " & j & vbCrLf _
                    '                & "IOR = " & ior & ",  JOR = " & jor & vbCrLf _
                    '                & "DX = " & dx & ",  DY = " & dy & vbCrLf)
                    'End If
                Next k
            Next j 'de m2
        Next i 'de m2
        'pasar m2 a imagen
        mint3d_to_bitmap(m2, i2)

    End Sub
    Function interp_valor(ByRef v1 As Integer, ByRef v2 As Integer, _
                          ByRef v3 As Integer, ByRef v4 As Integer, _
                          ByVal dx As Double, ByVal dy As Double) As Integer
        Dim v1v2, v3v4, v As Double

        v1v2 = v1 + (v2 - v1) * dx
        v3v4 = v3 + (v4 - v3) * dx
        v = v1v2 + (v3v4 - v1v2) * dy
        If (v > 255.0) Then v = 255.0
        interp_valor = Convert.ToInt16(v)
    End Function
    Sub mint3d_to_bitmap(ByRef mr(,,) As Integer, ByVal imagen As Bitmap)
        ' pasa una matriz de enteros en 3d a imagen
        ' mr debe estar entre 0 Y  255
        ' no realiza el cambio de escala de 0 a 255
        Dim i, j, k, nf, nc, ng As Integer
        'numero de filas y columnas de la matriz para los indices
        nf = UBound(mr, 1)
        nc = UBound(mr, 2)

        ' uso de bitmapdata
        ' define los datos
        Dim datos As BitmapData
        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer
        ' Lock the bitmap's bits, get a BitmapData object
        Dim rect As New Rectangle(0, 0, width, height)
        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)
        'MessageBox.Show(imagen.PixelFormat.ToString)
        ' Get the address of its first scan line
        Dim ptr As IntPtr = datos.Scan0
        ' Prepare an array that will receive all the pixels
        Dim bytes As Integer = datos.Stride * height
        Dim pixels(bytes) As Byte
        Dim nbpp As Integer
        nbpp = 3
        For k = 0 To 2
            For i = 0 To nf
                For j = 0 To nc
                    index = (i * datos.Stride) + (j * nbpp) ' num bytes per pixel
                    ng = Convert.ToInt16(mr(i, j, k))
                    If ng < 0 Then ng = 0
                    If ng > 255 Then ng = 255
                    pixels(index + k) = ng 'r
                Next
            Next
        Next k 'fin for k
        Marshal.Copy(pixels, 0, ptr, bytes)  'paso de datos a bitmap
        imagen.UnlockBits(datos)
    End Sub
    Sub rotar(ByRef i1 As Bitmap, _
        ByRef i2 As Bitmap, _
                                   ByRef alfa As Double)
        'i1, i2 son imagenes a color, 3 planos
        'alfa es angulo en grados
        'rotacvion origen destino
        Dim alfar As Double
        'alfar angulo en radianes
        alfar = alfa * Math.PI / 180.0
        Dim nf1, nc1, nf2, nc2 As Integer
        Dim calfar, salfar As Double
        calfar = Math.Cos(alfar) : salfar = Math.Sin(alfar)

        nf1 = i1.Height - 1 : nc1 = i1.Width - 1
        nf2 = i2.Height - 1 : nc2 = i2.Width - 1
        'dimensionamiento de matrices
        'i2 ya tiene calculadas las dimensiones
        Dim m1(nf1, nc1, 2), m2(nf2, nc2, 2) As Integer
        bitmap_to_mRGB(i1, m1)
        'calculo de m2

        Dim i1cx, i1cy, i2cx, i2cy, dx, dy, x2, y2 As Double
        'centro de i1
        i1cx = nc1 / 2 : i1cy = nf1 / 2
        'centro de i2
        i2cx = nc2 / 2 : i2cy = nf2 / 2
        Dim in2, jn2 As Integer
        For i = 0 To nf1         'bucles de barrido en m1
            For j = 0 To nc1
                'proceso de rotacion
                dx = j - i1cx : dy = i - i1cy
                x2 = dx * calfar - dy * salfar
                y2 = dx * salfar + dy * calfar
                in2 = i2cy + y2
                jn2 = i2cx + x2
                'If (i = 40 And j = 40) Then
                '    'Debug.Print(dx & " " & dy & " " &  
                'End If
                'verificacion fuera de rango
                If Not (in2 < 0 Or in2 > nf2 Or jn2 < 0 Or jn2 > nc2) Then
                    For k = 0 To 2
                        m2(in2, jn2, k) = m1(i, j, k)
                    Next
                End If

            Next
        Next
        'pasar m2 a imagen
        mint3d_to_bitmap(m2, i2)

    End Sub
    Sub rotar1(ByRef i1 As Bitmap, _
    ByRef i2 As Bitmap, _
                               ByRef alfa As Double)
        'rotacion destino origen
        'vecino mas proximo
        'i1, i2 son imagenes a color, 3 planos
        'alfa es angulo en grados
        Dim alfar As Double
        'alfar angulo en radianes
        alfar = alfa * Math.PI / 180.0
        Dim nf1, nc1, nf2, nc2 As Integer
        Dim calfar, salfar As Double
        calfar = Math.Cos(alfar) : salfar = Math.Sin(alfar)

        nf1 = i1.Height - 1 : nc1 = i1.Width - 1
        nf2 = i2.Height - 1 : nc2 = i2.Width - 1
        'dimensionamiento de matrices
        'i2 ya tiene calculadas las dimensiones
        Dim m1(nf1, nc1, 2), m2(nf2, nc2, 2) As Integer
        bitmap_to_mRGB(i1, m1)
        'calculo de m2

        Dim i1cx, i1cy, i2cx, i2cy, dx, dy, x2, y2 As Double
        'centro de i1
        i1cx = nc1 / 2 : i1cy = nf1 / 2
        'centro de i2
        i2cx = nc2 / 2 : i2cy = nf2 / 2
        Dim in2, jn2, i, j As Integer
        For in2 = 0 To nf2         'bucles de barrido en m2
            For jn2 = 0 To nc2
                'proceso de rotacion
                y2 = in2 - i2cy
                x2 = jn2 - i2cx
                dy = y2 * calfar - x2 * salfar
                dx = y2 * salfar + x2 * calfar
                j = dx + i1cx : i = dy + i1cy

                'If (i = 40 And j = 40) Then
                '    'Debug.Print(dx & " " & dy & " " &  
                'End If
                'verificacion fuera de rango
                If Not (i < 0 Or i > nf1 Or j < 0 Or j > nc1) Then
                    For k = 0 To 2
                        m2(in2, jn2, k) = m1(i, j, k)
                    Next
                End If

            Next
        Next
        'pasar m2 a imagen
        mint3d_to_bitmap(m2, i2)

    End Sub
    Sub rotar2(ByRef i1 As Bitmap, _
    ByRef i2 As Bitmap, _
                               ByRef alfa As Double)
        'rotacion en destino origen
        'vecino interpolacion bilineal, barrido en m2
        'i1, i2 son imagenes a color, 3 planos
        'alfa es angulo en grados
        Dim alfar As Double
        'alfar angulo en radianes
        alfar = alfa * Math.PI / 180.0
        Dim nf1, nc1, nf2, nc2 As Integer
        Dim calfar, salfar As Double
        calfar = Math.Cos(alfar) : salfar = Math.Sin(alfar)

        nf1 = i1.Height - 1 : nc1 = i1.Width - 1
        nf2 = i2.Height - 1 : nc2 = i2.Width - 1
        'dimensionamiento de matrices
        'i2 ya tiene calculadas las dimensiones
        Dim m1(nf1, nc1, 2), m2(nf2, nc2, 2) As Integer
        bitmap_to_mRGB(i1, m1)
        'calculo de m2

        Dim i1cx, i1cy, i2cx, i2cy, dx, dy, x2, y2 As Double
        'centro de i1
        i1cx = nc1 / 2 : i1cy = nf1 / 2
        'centro de i2
        i2cx = nc2 / 2 : i2cy = nf2 / 2
        Dim in2, jn2, ior, jor, incy, incx As Integer
        Dim i, j, deltax, deltay As Double
        Dim v1, v2, v3, v4 As Integer
        For in2 = 0 To nf2         'bucles de barrido en m2
            For jn2 = 0 To nc2
                'proceso de rotacion
                y2 = in2 - i2cy
                x2 = jn2 - i2cx
                dy = y2 * calfar - x2 * salfar
                dx = y2 * salfar + x2 * calfar
                j = dx + i1cx : i = dy + i1cy
                ior = Math.Floor(i) : jor = Math.Floor(j)
                deltax = j - jor : deltay = i - ior

                'verificacion fuera de rango
                If Not (i < 0 Or i > nf1 Or j < 0 Or j > nc1) Then
                    incy = 1
                    If ior + 1 > nf1 Then incy = 0
                    incx = 1
                    If jor + 1 > nc1 Then incx = 0

                    For k = 0 To 2
                        v1 = m1(ior, jor, k) : v2 = m1(ior, jor + incx, k)
                        v3 = m1(ior + incy, jor, k) : v4 = m1(ior + incy, jor + incx, k)
                        m2(in2, jn2, k) = interp_valor(v1, v2, v3, v4, deltax, deltay)
                    Next
                    If (in2 = 100 And jn2 = 100) Then
                        Debug.Print(" dx" & dx & " dy" & dy & " ior" & ior & "  jor" & jor & "  deltax" & deltax & "  delta y" & deltay & "  I=" & i & "  j=" & j)
                    End If
                End If

            Next
        Next
        'pasar m2 a imagen
        mint3d_to_bitmap(m2, i2)

    End Sub
    Function interp_bicubica(ByRef v(,) As Double, _
                                ByRef dx As Double, ByRef dy As Double) As Integer
        Dim vc, vc1, vc2, vc3, vc4 As Double
        Dim ng As Integer
        vc1 = INTERP_CUBICA(v(0, 0), v(0, 1), v(0, 2), v(0, 3), dx)
        vc2 = INTERP_CUBICA(v(1, 0), v(1, 1), v(1, 2), v(1, 3), dx)
        vc3 = INTERP_CUBICA(v(2, 0), v(2, 1), v(2, 2), v(2, 3), dx)
        vc4 = INTERP_CUBICA(v(3, 0), v(3, 1), v(3, 2), v(3, 3), dx)

        vc = INTERP_CUBICA(vc1, vc2, vc3, vc4, dy)

        ng = Convert.ToInt32(vc)
        If ng < 0 Then ng = 0
        If ng > 255 Then ng = 255


        Return ng
    End Function
    Function INTERP_CUBICA(ByRef V1 As Double, _
        ByRef V2 As Double, _
            ByRef V3 As Double, _
            ByRef V4 As Double, _
            ByRef delta As Double)
        Dim vc, a, b, c, d As Double

        a = (-3.0 * V3 + 3.0 * V2 - V1 + V4) / 6.0
        b = (V3 + V1 - 2.0 * V2) / 2.0
        c = (-2 * V1 - 3 * V2 + 6 * V3 - V4) / 6.0
        d = V2

        'vc = a * delta ^ 3 + b * delta ^ 2 + c * delta + d
        vc = ((a * delta + b) * delta + c) * delta + d
        Return vc
    End Function
    'Correccion de Perspectiva


    'filtros
    Sub aplica_filtro(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef filt(,) As Double, ByRef fact As Double)
        '   1.- pasar i1 a una matriz m1 double
        '   2.- aplicacion del filtro usando la convolucion en m1 y se genera m2
        '   4.- pasar m2 a i2

        Dim ancho, alto As Integer
        ancho = i1.Width
        alto = i1.Height

        ' paso 1
        Dim m1(alto - 1, ancho - 1, 2) As Double
        Dim m2(alto - 1, ancho - 1, 2) As Double

        bitmap_to_mRGB(i1, m1)

        'fin paso 1

        'aplicacion del filtro

        Dim nff, ncf As Integer
        Dim vpixel, sumpixel As Double
        nff = UBound(filt, 1)
        ncf = UBound(filt, 2)
        Dim i, j, k, i3, j3 As Integer
        For k = 0 To 2 'para recorrer los planos r g b
            For i = 0 To alto - 1 'filas
                For j = 0 To ancho - 1 'columnas
                    sumpixel = 0.0
                    '        5 , 6, 7   para i,j 
                    For i3 = i - nff / 2 To i + nff / 2
                        For j3 = j - ncf / 2 To j + ncf / 2
                            If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                                vpixel = m1(i, j, k) ' puede ser 0
                            Else
                                vpixel = m1(i3, j3, k)
                            End If
                            sumpixel = sumpixel + vpixel * filt(i3 - (i - nff / 2), j3 - (j - ncf / 2))
                        Next
                    Next
                    sumpixel = sumpixel / fact
                    m2(i, j, k) = sumpixel
                Next
            Next
        Next k
        ' PASAR LA MATRIZ REAL A UN BITMAP
        mdouble3d_to_bitmap(m2, i2)

    End Sub
    Sub filtro_mediana(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef nff As Integer, ByRef ncf As Integer, ByRef tipf As String)
        '   1.- pasar i1 a una matriz m1 enteros 2d
        '   2.- para cada pixel se obtiene la matriz de entorno, se ordenan los pixeles
        '       y se obtiene la mediana, término central y se lo coloca en m2  
        '   4.- pasar m2 a i2
        Dim ancho, alto As Integer
        ancho = i1.Width
        alto = i1.Height
        ' paso 1
        Dim m1(alto - 1, ancho - 1) As Integer
        Dim m2(alto - 1, ancho - 1) As Integer
        bitmap_to_mint(i1, m1)
        'fin paso 1

        'aplicacion del filtro
        Dim vector(nff * ncf - 1)
        Dim i, j, i3, j3, iv, vpixel, i4, itemp As Integer
        For i = 0 To alto - 1
            For j = 0 To ancho - 1
                iv = 0
                '        5 , 6, 7   
                For i3 = i - (nff - 1) / 2 To i + (nff - 1) / 2
                    For j3 = j - (ncf - 1) / 2 To j + (ncf - 1) / 2
                        If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                            vpixel = m1(i, j)
                        Else
                            vpixel = m1(i3, j3)
                        End If
                        vector(iv) = vpixel
                        iv = iv + 1
                    Next
                Next
                ' algoritmo de ordenacion
                For i3 = 0 To UBound(vector, 1) - 1
                    For i4 = i3 + 1 To UBound(vector, 1)
                        If vector(i3) > vector(i4) Then
                            itemp = vector(i3)
                            vector(i3) = vector(i4)
                            vector(i4) = itemp
                        End If
                    Next
                Next
                Select Case tipf
                    Case "Max"
                        m2(i, j) = vector(UBound(vector, 1)) 'max
                    Case "Min"
                        m2(i, j) = vector(0) 'min
                    Case "Mediana"
                        m2(i, j) = vector(UBound(vector, 1) / 2) 'para obtener la mediana
                End Select
            Next
        Next

        ' PASAR LA MATRIZ REAL A UN BITMAP
        mint_to_bitmap(m2, i2)

    End Sub
    'ruido
    Sub ruido(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef porc As Double)
        '   1.- pasar i1 a una matriz m1 enteros 2d
        '   2.- para cada pixel se obtiene la matriz de entorno, se ordenan los pixeles
        '       y se obtiene la mediana, término central y se lo coloca en m2  
        '   4.- pasar m2 a i2

        Dim ancho, alto As Integer
        ancho = i1.Width
        alto = i1.Height

        ' paso 1
        Dim m1(alto - 1, ancho - 1) As Integer
        Dim m2(alto - 1, ancho - 1) As Integer

        bitmap_to_mint(i1, m1)

        'fin paso 1
        Dim i, j, k As Integer
        For i = 0 To alto - 1
            For j = 0 To ancho - 1
                m2(i, j) = m1(i, j)
            Next j
        Next i
        'agregamos ruido en m2
        Dim numero As Integer
        numero = porc * ancho * alto
        For k = 1 To numero
            i = Rnd() * (alto - 1)
            j = Rnd() * (ancho - 1)
            If (i + j) Mod 2 = 0 Then
                m2(i, j) = 255
            Else
                m2(i, j) = 0
            End If
        Next k
        ' PASAR LA MATRIZ REAL A UN BITMAP
        mint_to_bitmap(m2, i2)

    End Sub
    Sub bitmap_to_mint(ByRef imagen As Bitmap, ByRef mat(,) As Integer)
        'usa bitmapdata
        'pasa los tres planos a una matriz de tres dimensiones


        Dim datos As BitmapData  'inf de valores de pixeles
        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer 'indice para barrer todos los pix de la imagen
        ' Lock the bitmap's bits, get a BitmapData object
        Dim rect As New Rectangle(0, 0, width, height) 'define un rectangulo
        '                                               del tamaño de la imagen
        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)
        'paso todos los pixeles a datos
        ' Get the address of its first scan line
        Dim ptr As IntPtr = datos.Scan0  'dirección de datos

        ' Prepare an array that will receive all the pixels
        Dim bytes As Integer = datos.Stride * height 'num total de pix del bitmapdata
        Dim pixels(bytes) As Byte

        ' Copy the pixels into the array
        Marshal.Copy(ptr, pixels, 0, bytes)

        ' Now we have the data in a buffer, we can process it much more quickly than GetPixel/SetPixel
        ' The buffer elements now contain RGB data thus:
        ' R1 G1 B1 R2 G2 B2 R3 G3 B3...Rn Gn Bn
        ' so we traverse the array in steps of 3.  (Note: this is because it's 3 bytes per pixel.  Change this for other formats)
        Dim i, j As Integer

        For i = 0 To height - 1
            For j = 0 To width - 1
                index = (i * datos.Stride) + (j * 3) ' 3 bytes per pixel
                mat(i, j) = pixels(index)

            Next
        Next
        imagen.UnlockBits(datos)
    End Sub
    Sub mint_to_bitmap(ByRef mr(,) As Integer, ByVal imagen As Bitmap)
        ' pasa una matriz de doubles a imagen
        Dim i, j, nf, nc, ng As Integer
        'numero de filas y columnas de la matriz para los indices
        nf = UBound(mr, 1)
        nc = UBound(mr, 2)

        ' uso de bitmapdata
        ' define los datos
        Dim datos As BitmapData
        Dim width As Integer = imagen.Width
        Dim height As Integer = imagen.Height
        Dim index As Integer
        ' Lock the bitmap's bits, get a BitmapData object
        Dim rect As New Rectangle(0, 0, width, height)
        datos = imagen.LockBits(rect, _
                                Drawing.Imaging.ImageLockMode.ReadWrite, _
                                imagen.PixelFormat)
        ' MessageBox.Show(imagen.PixelFormat.ToString)


        ' Get the address of its first scan line
        Dim ptr As IntPtr = datos.Scan0
        ' Prepare an array that will receive all the pixels
        Dim bytes As Integer = datos.Stride * height
        Dim pixels(bytes) As Byte
        Dim nbpp As Integer
        nbpp = 3
        For i = 0 To nf
            For j = 0 To nc

                index = (i * datos.Stride) + (j * nbpp) ' num bytes per pixel
                ng = mr(i, j)
                If ng < 0 Then ng = 0
                If ng > 255 Then ng = 255
                'para 24 bits
                pixels(index) = ng 'r
                pixels(index + 1) = ng 'g
                pixels(index + 2) = ng 'b
            Next
        Next
        Marshal.Copy(pixels, 0, ptr, bytes)  'paso de datos a bitmap
        imagen.UnlockBits(datos)
    End Sub
    'Correccion examen
    Sub prueba22(ByRef I1 As Bitmap, ByRef I3 As Bitmap)

        Dim nf, nc, i, j, k, nf2, nc2 As Integer
        nf = I1.Height - 1 : nc = I1.Width - 1
        nf2 = I3.Height - 1 : nc2 = I3.Width - 1
        Dim m1(nf, nc, 2) As Double
        Dim m3(nf2, nc2, 2) As Double
        'pasar imagenes a matrices
        bitmap_to_mRGB(I1, m1)
        'Debug.Print("RASTREO M1 " & m1(100, 100, 0) & " " & m1(100, 100, 1) & " " & m2(100, 100, 2))
        Dim cont, cont2, cont3, cont4 As Integer
        cont = nc2
        cont2 = nf2 + 1
        cont3 = 0
        cont4 = 0
        'MessageBox.Show(nc2)
        'MessageBox.Show(nf2)
        For k = 0 To 2 'primer for
            For i = 0 To nf2  'segundo for
                cont2 = cont2 - 1
                For j = 0 To nc2  ' tercer fot
                    m3(i, j, k) = m1(i, cont, k)
                    cont = cont - 1
                Next j
                cont = nc2
            Next i
            cont2 = nf2

        Next k
        'normalizacion de m3 a valores de 0 a 255
        normalizar_0_255(m3)
        'Debug.Print("RASTREO M3 " & m1(100, 100, 0) & " " & m2(100, 100, 0) & " " & m3(100, 100, 0))
        mdouble3d_to_bitmap(m3, I3)

    End Sub
    Sub prueba23(ByRef I1 As Bitmap, ByRef I3 As Bitmap, ini As Integer,
                 inij As Integer)

        Dim nf, nc, i, j, k, nf2, nc2 As Integer
        nf = I1.Height - 1 : nc = I1.Width - 1
        nf2 = I3.Height - 1 : nc2 = I3.Width - 1
        Dim m1(nf, nc, 2) As Double
        Dim m3(nf2, nc2, 2) As Double
        'pasar imagenes a matrices
        bitmap_to_mRGB(I1, m1)
        'Debug.Print("RASTREO M1 " & m1(100, 100, 0) & " " & m1(100, 100, 1) & " " & m2(100, 100, 2))
        Dim cont, cont2, cont3, cont4 As Integer
        cont = inij
        cont2 = ini
        cont3 = 0
        cont4 = 0
        'MessageBox.Show(nc2)
        'MessageBox.Show(nf2)
        For k = 0 To 2 'primer for
            For i = 0 To nf2  'segundo for
                For j = 0 To nc2 ' tercer fot
                    m3(i, j, k) = m1(cont2, cont, k)
                    cont = cont + 1
                Next j
                cont = inij
                cont2 = cont2 + 1
            Next i
            cont2 = ini
        Next k
        'normalizacion de m3 a valores de 0 a 255
        normalizar_0_255(m3)
        'Debug.Print("RASTREO M3 " & m1(100, 100, 0) & " " & m2(100, 100, 0) & " " & m3(100, 100, 0))
        mdouble3d_to_bitmap(m3, I3)

    End Sub
    Sub espejo(ByRef I1 As Bitmap, ByRef I2 As Bitmap, ByRef I3 As Bitmap, ByRef I4 As Bitmap,
               ByRef I5 As Bitmap, ByRef I6 As Bitmap)

        Dim nf, nc, i, j, k, nf2, nc2 As Integer
        nf = I1.Height - 1 : nc = I1.Width - 1
        nf2 = I2.Height - 1 : nc2 = I2.Width - 1

        Dim m1(nf, nc, 2) As Double
        Dim m2(nf2, nc2, 2) As Double


        'pasar imagenes a matrices
        bitmap_to_mRGB(I1, m1)
        'Debug.Print("RASTREO M1 " & m1(100, 100, 0) & " " & m1(100, 100, 1) & " " & m2(100, 100, 2))
        Dim cont, cont2, cont3, cont4, cont5, cont6 As Integer
        Dim cont31, cont41, cont51, cont61 As Integer
        cont = 0 ' original
        cont2 = 0 ' original 

        cont3 = I3.Width - 1
        cont4 = I4.Width - 1
        cont5 = I5.Width - 1
        cont6 = I6.Width - 1

        cont31 = I3.Height - 1
        cont41 = I4.Height - 1
        cont51 = I5.Height - 1
        cont61 = I6.Height - 1

        Dim m3(cont31, cont3, 2) As Double
        Dim m4(cont41, cont4, 2) As Double
        Dim m5(cont51, cont5, 2) As Double
        Dim m6(cont61, cont6, 2) As Double
        'bitmap_to_mRGB(I2, m2)
        bitmap_to_mRGB(I3, m3)
        bitmap_to_mRGB(I4, m4)
        bitmap_to_mRGB(I5, m5)
        bitmap_to_mRGB(I6, m6)
        cont3 = 0
        cont4 = 0
        cont5 = 0
        cont6 = 0

        cont31 = 0
        cont41 = 0
        cont51 = 0
        cont61 = 0
        Dim cont8, cont81, cont9, cont91, cont10, cont101, cont11, cont111 As Integer
        cont8 = 0
        cont9 = 0
        cont10 = 0
        cont11 = 0

        cont81 = (I3.Height * 0.25) - 1
        cont91 = (I4.Height * 0.25) - 1
        cont101 = I3.Height - 1
        cont111 = (I4.Height) - 1
        For k = 0 To 2 'primer for
            For i = 0 To nf2 'segundo for
                If (i >= nf * 0.25) Then
                    cont2 = cont2 + 1
                End If

                For j = 0 To nc2 ' tercer fot

                    If (cont < nc And cont2 < nf) Then
                        If (j >= nc * 0.25 And i >= nf * 0.25) Then
                            m2(i, j, k) = m1(cont2, cont, k) ' original 
                            cont = cont + 1
                        End If
                        If (j > nc * 0.25 And j < nc * 1.25 And i < nf * 0.25) Then
                            m2(i, j, k) = m5(cont51, cont5, k)
                            cont5 = cont5 + 1
                            'MessageBox.Show("entro")
                        End If
                        If (j < (nc * 0.25) - 1 And i >= (nf * 0.25) And i <= nf * 1.25) Then
                            m2(i, j, k) = m3(cont31, cont3, k)
                            cont3 = cont3 + 1
                        End If



                    Else
                        If (j >= nc * 0.25 And j < nc * 1.25 And i > nf * 1.25 And i < nf2) Then
                            m2(i, j, k) = m6(cont61, cont6, k)
                            cont6 = cont6 + 1
                            'MessageBox.Show(nf2)
                            'MessageBox.Show(nf * 1.25)
                            'MessageBox.Show(nf)
                            'MessageBox.Show(i)
                        End If
                        If (j > nc * 1.25 And j < nc2 And i > nf * 0.25 And i < nf * 1.25) Then
                            m2(i, j, k) = m4(cont41, cont4, k)
                            cont4 = cont4 + 1
                            'MessageBox.Show("cuadro 4")

                        End If

                    End If

                    If (j < (nc * 0.25) - 1 And i < nf * 0.25) Then
                        m2(i, j, k) = m3(cont81, cont8, k)
                        cont8 = cont8 + 1
                    End If
                    If (j < (nc * 0.25) - 1 And i > nf * 1.25 And i < nf2) Then
                        m2(i, j, k) = m3(cont101, cont10, k)
                        cont10 = cont10 + 1
                    End If
                    If (j > nc * 1.25 And j < nc2 And i < nf * 0.25) Then
                        m2(i, j, k) = m4(cont91, cont9, k)
                        cont9 = cont9 + 1

                    End If
                    If (j > nc * 1.25 And j < nc2 And i > nf * 1.25 And i < nf2) Then
                        m2(i, j, k) = m4(cont111, cont11, k)
                        cont11 = cont11 + 1

                    End If
                Next j
                cont = 0
                If (i < nf * 0.25) Then
                    cont51 = cont51 + 1
                End If
                If (i > nf * 0.25 And i < nf * 1.25) Then

                    cont31 = cont31 + 1
                End If
                If (i > nf * 1.25 And i < nf2) Then
                    cont61 = cont61 + 1

                End If
                If (i > nf * 0.25 And i < nf * 1.25) Then
                    cont41 = cont41 + 1

                End If
                If (i < nf * 0.25) Then

                    cont81 = cont81 - 1
                End If
                If (i > nf * 1.25 And i < nf2) Then

                    cont101 = cont101 - 1
                End If
                If (i < nf * 0.25) Then

                    cont91 = cont91 - 1
                End If
                If (i > nf * 1.25 And i < nf2) Then
                    cont111 = cont111 - 1

                End If
                cont5 = 0
                cont3 = 0
                cont6 = 0
                cont4 = 0
                cont8 = 0
                cont10 = 0
                cont9 = 0
                cont11 = 0
            Next i
            cont2 = 0
            cont51 = 0
            cont31 = 0
            cont61 = 0
            cont41 = 0
            cont81 = (I3.Height * 0.25) - 1
            cont101 = (I3.Height) - 1
            cont91 = (I4.Height * 0.25) - 1
            cont111 = (I4.Height) - 1
        Next k
        cont = 0
        cont2 = 0

        'normalizacion de m3 a valores de 0 a 255
        normalizar_0_255(m2)
        'Debug.Print("RASTREO M3 " & m1(100, 100, 0) & " " & m2(100, 100, 0) & " " & m3(100, 100, 0))
        mdouble3d_to_bitmap(m2, I2)

    End Sub
    Sub espejo33(ByRef I1 As Bitmap, ByRef I2 As Bitmap, ini As Integer, inij As Integer, fin As Integer, finj As Integer)

        Dim nf, nc, i, j, k, nf2, nc2 As Integer
        nf = I1.Height - 1 : nc = I1.Width - 1
        nf2 = I2.Height - 1 : nc2 = I2.Width - 1

        Dim m1(nf, nc, 2) As Double
        Dim m2(nf2, nc2, 2) As Double


        'pasar imagenes a matrices
        bitmap_to_mRGB(I1, m1)
        bitmap_to_mRGB(I2, m2)
        'Debug.Print("RASTREO M1 " & m1(100, 100, 0) & " " & m1(100, 100, 1) & " " & m2(100, 100, 2))

        For k = 0 To 2 'primer for
            For i = ini To fin 'segundo for

                For j = inij To finj ' tercer for
                    m2(i, j, k) = m1(i, j, k)
                Next j

            Next i

        Next k
        For k = 0 To 2 'primer for
            For i = 0 To nf2 'segundo for

                For j = 0 To nf2 ' tercer for
                    m2(i, j, k) = m1(0, 0, 0)
                Next j

            Next i

        Next k

        'normalizacion de m3 a valores de 0 a 255
        normalizar_0_255(m2)
        'Debug.Print("RASTREO M3 " & m1(100, 100, 0) & " " & m2(100, 100, 0) & " " & m3(100, 100, 0))
        mdouble3d_to_bitmap(m2, I2)

    End Sub
    Sub rotar11(ByRef im1 As Bitmap, _
                              ByRef im2 As Bitmap, _
                              ByRef alfa As Double)
        'i1, i2 son imagenes a color, 3 planos
        'rota angulo alfa imagen1 en imagen 2
        'procedimiento mapeo de m1 a m2 
        'mapeo directo
        Dim nf1, nc1, nf2, nc2 As Integer
        nf1 = im1.Height - 1 : nc1 = im1.Width - 1
        nf2 = im2.Height - 1 : nc2 = im2.Width - 1
        'dimensionamiento de matrices
        Dim m1(nf1, nc1, 2), m2(nf2, nc2, 2) As Integer
        bitmap_to_mRGB(im1, m1)
        'calculo de m2
        Dim i, j, i1, i2, j1, j2 As Integer
        Dim di, dj, di2, dj2, ic1, jc1, ic2, jc2 As Double
        Dim sina, cosa As Double
        sina = Math.Sin(alfa) : cosa = Math.Cos(alfa)
        ic1 = im1.Height / 2 : jc1 = im1.Width / 2
        ic2 = im2.Height / 2 : jc2 = im2.Width / 2
        For i = 0 To nf1        'bucles de barrido en m1 filas
            di = i - ic1         'coordenada vertical respecto al centro   
            For j = 0 To nc1
                dj = j - jc1     'cord horizon respecto al centro de i1 
                'rotacion de di dj
                dj2 = dj * cosa - di * sina
                di2 = di * cosa + dj * sina
                i2 = di2 + ic2 : j2 = dj2 + jc2
                If i2 > nf2 Then i2 = nf2
                If j2 > nc2 Then j2 = nc2
                If i2 < 0 Then i2 = 0
                If j2 < 0 Then j2 = 0

                For k = 0 To 2
                    m2(i2, j2, k) = m1(i, j, k)
                Next
            Next
        Next
        'pasar m2 a imagen
        mint3d_to_bitmap(m2, im2)

    End Sub

    Sub etiquetar(ByRef i1 As Bitmap, ByRef i2 As Bitmap, _
               ByRef tdc(,) As Integer, _
                 ByRef m1(,) As Integer, _
                 ByRef opcioncolor As String)

        Dim nf, nc, netiq, existe As Integer
        Dim tequita(20000) As Integer
        Dim tequiv(20000, 1), ntequiv As Integer
        Dim pizq, psup As Integer
        nf = i1.Height - 1
        nc = i1.Width - 1

        bitmap_to_mint(i1, m1)
        netiq = 0
        ntequiv = 0
        'etiquetado conectividad 4p
        For i = 0 To nf
            For j = 0 To nc
                'el pixel en analisis es el (i,j)
                If m1(i, j) = 255 Then

                    If (j - 1 < 0) Then
                        pizq = 0
                    End If
                    If (i - 1 < 0) Then
                        psup = 0
                    End If
                    If j - 1 >= 0 And i - 1 >= 0 Then
                        pizq = m1(i, j - 1)
                        psup = m1(i - 1, j)
                    End If
                    'caso 1 pizq y  psup = 0
                    If (pizq = 0 And psup = 0) Then
                        netiq += 1
                        m1(i, j) = netiq
                    End If
                    'caso 2 pizq = 0 y psup <> 0 
                    If pizq = 0 And psup <> 0 Then
                        m1(i, j) = psup
                    End If
                    'caso 3 pizq <> 0 y psup = 0
                    If pizq <> 0 And psup = 0 Then
                        m1(i, j) = pizq
                    End If
                    'caso 4 pizq = psup y <> de cero
                    If pizq <> 0 And pizq = psup Then
                        m1(i, j) = psup
                    End If
                    'caso 5 piz <> 0 psupo <> 0 y pizq <> psup 
                    If (pizq > 0 And psup > 0 And pizq <> psup) Then

                        m1(i, j) = psup
                        ' agregar a tabla de equivalencias
                        ' verificacion de que no existe entrada en tquiv
                        If ntequiv = 0 Then
                            tequiv(ntequiv, 0) = psup
                            tequiv(ntequiv, 1) = pizq
                            ntequiv += 1
                        Else
                            existe = 1
                            For l = 0 To ntequiv - 1
                                If (tequiv(l, 0) = psup And _
                                    tequiv(l, 1) = pizq) Or _
                                    (tequiv(l, 1) = psup And _
                                    tequiv(l, 0) = pizq) Then
                                    existe = 0
                                End If
                            Next l
                            If existe = 1 Then
                                tequiv(ntequiv, 0) = psup
                                tequiv(ntequiv, 1) = pizq
                                ntequiv += 1
                            End If
                        End If
                    End If
                End If 'fin if m1(i,j)

            Next j
        Next i
        'fin del etiquetado




        'resolucion de tabla de  equivalencias
        Dim mequiv(netiq, netiq) As Integer
        Dim vmin As Integer
        Dim menor As Integer

        'simetrica
        'armado de la matriz
        'para cada entrada de tequiv, se realizan dos entradas en matriz
        For i = 0 To ntequiv - 1
            menor = tequiv(i, 0)
            If tequiv(i, 1) < menor Then menor = tequiv(i, 1)

            mequiv(tequiv(i, 0), tequiv(i, 1)) = menor 'ojo
            mequiv(tequiv(i, 1), tequiv(i, 0)) = menor 'ojo
        Next

        'reflexiva
        'armar diagonal
        For i = 0 To netiq
            mequiv(i, i) = i
        Next

        For ietiq = 1 To 3 '// bucle principal
            For i = 1 To netiq 'ida
                vmin = 999999
                'recorre fila i    
                For j = 1 To netiq
                    If mequiv(i, j) <> 0 Then
                        If mequiv(i, j) < vmin Then vmin = mequiv(i, j)
                    End If
                Next
                'recorrer columna i
                For j = 1 To netiq
                    If mequiv(j, i) <> 0 Then
                        If mequiv(j, i) < vmin Then vmin = mequiv(j, i)
                    End If
                Next
                'reemplazo
                'recorre fila i    
                For j = 1 To netiq
                    If mequiv(i, j) <> 0 Then
                        mequiv(i, j) = vmin
                    End If
                Next
                'recorrer columna i
                For j = 1 To netiq
                    If mequiv(j, i) <> 0 Then
                        mequiv(j, i) = vmin
                    End If
                Next
            Next i ' fin bucle ida
            For i = netiq To 1 Step -1 'regreso
                vmin = 999999
                'recorre fila i    
                For j = 1 To netiq
                    If mequiv(i, j) <> 0 Then
                        If mequiv(i, j) < vmin Then vmin = mequiv(i, j)
                    End If
                Next
                'recorrer columna i
                For j = 1 To netiq
                    If mequiv(j, i) <> 0 Then
                        If mequiv(j, i) < vmin Then vmin = mequiv(j, i)
                    End If
                Next
                'reemplazo
                'recorre fila i    
                For j = 1 To netiq
                    If mequiv(i, j) <> 0 Then
                        mequiv(i, j) = vmin
                    End If
                Next
                'recorrer columna i
                For j = 1 To netiq
                    If mequiv(j, i) <> 0 Then
                        mequiv(j, i) = vmin
                    End If
                Next
            Next i ' fin bucle regreso
        Next ietiq
        'fin  resolucion equivalencia



        'reemplazo de qtiquetas en matriz de imagen
        For i = 0 To nf
            For j = 0 To nc
                If m1(i, j) <> 0 Then
                    m1(i, j) = mequiv(m1(i, j), m1(i, j))
                End If
            Next
        Next

        If opcioncolor = "no" Then
            'imagen en escala de grises
            mint_to_bitmap(m1, i2)
            'tabla de colores
        Else
            Dim m2(nf, nc, 2) As Double
            For i = 0 To nf
                For j = 0 To nc
                    m2(i, j, 0) = tdc(m1(i, j), 0)
                    m2(i, j, 1) = tdc(m1(i, j), 1)
                    m2(i, j, 2) = tdc(m1(i, j), 2)
                Next
            Next
            mdouble3d_to_bitmap(m2, i2)
        End If
    End Sub

    Sub propiedades_objetos(ByRef m1(,) As Integer, _
                                ByRef objetos(,) As Integer, _
                                ByRef numero As Integer _
                                )



        Dim nf, nc, i, j, nivelgris, plano As Integer

        '1.- identificar cuantas etiquetas diferentes 

        Dim nivmax As Long
        Dim NIVELES(200000) As Long

        nf = UBound(m1, 1) 'num filas
        nc = UBound(m1, 2) 'num de col
        For i = 0 To nf
            For j = 0 To nc
                nivelgris = (m1(i, j))
                If nivelgris > nivmax Then nivmax = nivelgris
                NIVELES(nivelgris) += 1
            Next  'J
        Next 'I
        'conteo de objetos
        numero = 0
        For i = 1 To nivmax
            If NIVELES(i) <> 0 Then
                numero += 1
            End If
        Next
        'para cada objeto se necesita etiqu, area, xcg (col), ycg(fil), pix, piy, pfx,pfy
        '                    columnas   0      1      2         3        4    5     6  7

        numero = 0              'contador de objetos
        For i = 1 To nivmax
            If NIVELES(i) <> 0 Then
                objetos(numero, 0) = i  'nivel de gris de cada objeto
                objetos(numero, 1) = NIVELES(i) 'area del objeto
                numero += 1
            End If
        Next
        'bucle inicial para calculo de xcg, ygc,  pix,piy,pfx,pfy

        For i = 0 To numero - 1
            objetos(i, 2) = 0 : objetos(i, 3) = 0
            objetos(i, 4) = 99999 : objetos(i, 5) = 99999 'busqueda de minimos
            objetos(i, 6) = -99999 : objetos(i, 7) = -99999 'busqueda de maximos
        Next
        Dim k, nobj As Integer
        For i = 0 To nf
            For j = 0 To nc
                nivelgris = (m1(i, j))
                If nivelgris <> 0 Then
                    'identificar a que objeto corresponde el nivel de gris nivelgris
                    For k = 0 To numero - 1
                        If nivelgris = objetos(k, 0) Then
                            nobj = k
                            Exit For
                        End If
                    Next k
                    'sumatorias sum(i), sum(j)
                    objetos(nobj, 2) += j 'xcg
                    objetos(nobj, 3) += i 'ycg
                    ' coordenadas iniciales
                    If j < objetos(nobj, 4) Then objetos(nobj, 4) = j
                    If i < objetos(nobj, 5) Then objetos(nobj, 5) = i
                    'coordenadas finales
                    If j > objetos(nobj, 6) Then objetos(nobj, 6) = j
                    If i > objetos(nobj, 7) Then objetos(nobj, 7) = i
                End If
            Next  'J
        Next 'I

        For i = 0 To numero - 1
            objetos(i, 2) = objetos(i, 2) / objetos(i, 1) 'xcg
            objetos(i, 3) = objetos(i, 3) / objetos(i, 1) 'ycg
        Next


    End Sub


    ''Morfologia
    Sub erosion(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef filt(,) As Integer)
        '   1.- pasar i1 a una matriz m1 double
        '   2.- aplicacion del filtro usando la convolucion en m1 y se genera m2
        '   4.- pasar m2 a i2

        Dim ancho, alto As Integer
        ancho = i1.Width
        alto = i1.Height

        ' paso 1
        Dim m1(alto - 1, ancho - 1) As Integer
        Dim m2(alto - 1, ancho - 1) As Integer

        bitmap_to_mint(i1, m1)

        'fin paso 1

        'aplicacion del filtro

        Dim nff, ncf As Integer
        Dim vpixel As Integer
        Dim prodpixel As Double
        nff = UBound(filt, 1)
        ncf = UBound(filt, 2)
        Dim i, j, k, i3, j3 As Integer

        For i = 0 To alto - 1 'filas
            For j = 0 To ancho - 1 'columnas
                m2(i, j) = 0
                prodpixel = 1
                '        5 , 6, 7   para i,j 
                For i3 = i - nff / 2 To i + nff / 2
                    For j3 = j - ncf / 2 To j + ncf / 2

                        If filt(i3 - (i - nff / 2), j3 - (j - ncf / 2)) = 1 Then
                            If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                                vpixel = m1(i, j) ' puede ser 0
                            Else
                                vpixel = m1(i3, j3)
                            End If
                            prodpixel = prodpixel * vpixel * filt(i3 - (i - nff / 2), j3 - (j - ncf / 2))
                        End If

                    Next
                Next
                If prodpixel > 0 Then
                    m2(i, j) = 255
                End If

            Next
        Next

        ' PASAR LA MATRIZ REAL A UN BITMAP
        mint_to_bitmap(m2, i2)

    End Sub
    Sub apertura(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef filt(,) As Integer)
        ' hacer Aplicar erosión y después dilatación: (BxE)+E


        Dim ancho, alto, SUMPIXEL As Integer
        ancho = i1.Width
        alto = i1.Height

        ' paso 1
        Dim m1(alto - 1, ancho - 1) As Integer
        Dim m2(alto - 1, ancho - 1) As Integer
        Dim m3(alto - 1, ancho - 1) As Integer

        bitmap_to_mint(i1, m1)

        'fin paso 1

        'aplicacion del filtro

        Dim nff, ncf As Integer
        Dim vpixel As Integer
        Dim prodpixel As Double
        nff = UBound(filt, 1)
        ncf = UBound(filt, 2)
        Dim i, j, k, i3, j3 As Integer




        'erosion
        For i = 0 To alto - 1 'filas
            For j = 0 To ancho - 1 'columnas
                m2(i, j) = 0
                prodpixel = 1
                '        5 , 6, 7   para i,j 
                For i3 = i - nff / 2 To i + nff / 2
                    For j3 = j - ncf / 2 To j + ncf / 2

                        If filt(i3 - (i - nff / 2), j3 - (j - ncf / 2)) = 1 Then
                            If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                                vpixel = m1(i, j) ' puede ser 0
                            Else
                                vpixel = m1(i3, j3)
                            End If
                            prodpixel = prodpixel * vpixel * filt(i3 - (i - nff / 2), j3 - (j - ncf / 2))
                        End If

                    Next
                Next
                If prodpixel > 0 Then
                    m2(i, j) = 255
                End If

            Next
        Next
        'fin erosion
        'dilatacion
        For i = 0 To alto - 1 'filas
            For j = 0 To ancho - 1 'columnas
                m3(i, j) = m2(i, j)
                SUMPIXEL = 0
                '        5 , 6, 7   para i,j 
                For i3 = i - nff / 2 To i + nff / 2
                    For j3 = j - ncf / 2 To j + ncf / 2
                        If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                            vpixel = m2(i, j) ' puede ser 0
                        Else
                            vpixel = m2(i3, j3)
                        End If
                        SUMPIXEL = SUMPIXEL + vpixel * filt(i3 - (i - nff / 2), j3 - (j - ncf / 2))
                    Next
                Next
                If SUMPIXEL > 0 Then
                    m3(i, j) = 255
                End If

            Next
        Next

        ' PASAR LA MATRIZ REAL A UN BITMAP
        mint_to_bitmap(m3, i2)

    End Sub
    Sub cierre(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef filt(,) As Integer)
        ' hacer Aplicar dilatacion y después erosion: (B+E)xE


        Dim ancho, alto, SUMPIXEL As Integer
        ancho = i1.Width
        alto = i1.Height

        ' paso 1
        Dim m1(alto - 1, ancho - 1) As Integer
        Dim m2(alto - 1, ancho - 1) As Integer
        Dim m3(alto - 1, ancho - 1) As Integer

        bitmap_to_mint(i1, m1)

        'fin paso 1

        'aplicacion del filtro

        Dim nff, ncf As Integer
        Dim vpixel As Integer
        Dim prodpixel As Double
        nff = UBound(filt, 1)
        ncf = UBound(filt, 2)
        Dim i, j, k, i3, j3 As Integer

        'dilatacion
        For i = 0 To alto - 1 'filas
            For j = 0 To ancho - 1 'columnas
                m2(i, j) = m1(i, j)
                SUMPIXEL = 0
                '        5 , 6, 7   para i,j 
                For i3 = i - nff / 2 To i + nff / 2
                    For j3 = j - ncf / 2 To j + ncf / 2
                        If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                            vpixel = m1(i, j) ' puede ser 0
                        Else
                            vpixel = m1(i3, j3)
                        End If
                        SUMPIXEL = SUMPIXEL + vpixel * filt(i3 - (i - nff / 2), j3 - (j - ncf / 2))
                    Next
                Next
                If SUMPIXEL > 0 Then
                    m2(i, j) = 255
                End If

            Next
        Next
        'fin dilatacion


        'erosion
        For i = 0 To alto - 1 'filas
            For j = 0 To ancho - 1 'columnas
                m3(i, j) = 0
                prodpixel = 1
                '        5 , 6, 7   para i,j 
                For i3 = i - nff / 2 To i + nff / 2
                    For j3 = j - ncf / 2 To j + ncf / 2

                        If filt(i3 - (i - nff / 2), j3 - (j - ncf / 2)) = 1 Then
                            If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                                vpixel = m2(i, j) ' puede ser 0
                            Else
                                vpixel = m2(i3, j3)
                            End If
                            prodpixel = prodpixel * vpixel * filt(i3 - (i - nff / 2), j3 - (j - ncf / 2))
                        End If

                    Next
                Next
                If prodpixel > 0 Then
                    m3(i, j) = 255
                End If

            Next
        Next
        'fin erosion


        ' PASAR LA MATRIZ REAL A UN BITMAP
        mint_to_bitmap(m3, i2)

    End Sub
    Sub dilatacion(ByRef i1 As Bitmap, ByRef i2 As Bitmap, ByRef filt(,) As Integer)
        '   1.- pasar i1 a una matriz m1 double
        '   2.- aplicacion del filtro usando la convolucion en m1 y se genera m2
        '   4.- pasar m2 a i2

        Dim ancho, alto As Integer
        ancho = i1.Width
        alto = i1.Height

        ' paso 1
        Dim m1(alto - 1, ancho - 1) As Integer
        Dim m2(alto - 1, ancho - 1) As Integer

        bitmap_to_mint(i1, m1)

        'fin paso 1

        'aplicacion del filtro

        Dim nff, ncf As Integer
        Dim vpixel, sumpixel As Integer
        nff = UBound(filt, 1)
        ncf = UBound(filt, 2)
        Dim i, j, k, i3, j3 As Integer

        For i = 0 To alto - 1 'filas
            For j = 0 To ancho - 1 'columnas
                m2(i, j) = m1(i, j)
                sumpixel = 0
                '        5 , 6, 7   para i,j 
                For i3 = i - nff / 2 To i + nff / 2
                    For j3 = j - ncf / 2 To j + ncf / 2
                        If i3 < 0 Or j3 < 0 Or i3 > alto - 1 Or j3 > ancho - 1 Then
                            vpixel = m1(i, j) ' puede ser 0
                        Else
                            vpixel = m1(i3, j3)
                        End If
                        sumpixel = sumpixel + vpixel * filt(i3 - (i - nff / 2), j3 - (j - ncf / 2))
                    Next
                Next
                If sumpixel > 0 Then
                    m2(i, j) = 255
                End If

            Next
        Next

        ' PASAR LA MATRIZ REAL A UN BITMAP
        mint_to_bitmap(m2, i2)

    End Sub


End Module
