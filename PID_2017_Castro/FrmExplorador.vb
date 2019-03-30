Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Image
Imports System.Math

Public Class FrmExplorador
    'variables globales
    Dim matriz1(200, 200, 2) As Integer 'almacena los valores de los pixeles r g b
    Dim valorpixel(6, 6, 2) As TextBox  ' matriz de cuadros de texto para mostrar los valores de la imagen
    Private Sub btncargar_Click(sender As Object, e As EventArgs) Handles btncargar.Click
        Dim imagen As Bitmap 'define el objeto bitmap
        imagen = New Bitmap(Me.pb1.Width, Me.pb1.Height) 'define ancho y alto del pic
        With Me.ofd1
            '.InitialDirectory = "C:\"
            .Filter = "All Image Formats (*.bmp;*.jpg;*.jpeg;*.gif;*.tif)|" & "*.bmp;*.jpg;*.jpeg;*.gif;*.tif|Bitmaps (*.bmp)|*.bmp|" & "GIFs (*.gif)|*.gif|JPEGs (*.jpg)|*.jpg;*.jpeg|TIFs (*.tif)|*.tif"
            .FilterIndex = 1
        End With
        If ofd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            imagen = FromFile(ofd1.FileName)
        End If
        ReDim matriz1(imagen.Height - 1, imagen.Width - 1, 2)

        'mostrar el formato de la imagen
        'MessageBox.Show(imagen.PixelFormat & vbCr _
        '               & imagen.PixelFormat.ToString)

        'bitmap_to_mRGB(imagen, matriz1) 'usa bitmapdata

        bitmap_to_mRGB1(imagen, matriz1) 'usa getpixel
        'mostrar el formato de la imagen
        Me.lblFormato.Text = imagen.PixelFormat & " --> " & _
                         imagen.PixelFormat.ToString
        'bitmap_to_mRGB(imagen, matriz1) 'usa bitmapdata


        Me.pb1.Width = imagen.Width      'cambia el ancho y el alto del picturebox
        Me.pb1.Height = imagen.Height   'para mostrar la imagen
        Me.pb1.Image = imagen                  'coloca la imagen en el picture box
        miimagen = New Bitmap(Me.pb1.Image)
        Me.txtInfo.Text = ofd1.FileName & "  ancho= " & imagen.Width _
        & " alto= " & imagen.Height _
        & " h res= " & imagen.HorizontalResolution _
        & " v res= " & imagen.VerticalResolution

    End Sub

    Dim miimagen As Bitmap              'objeto bitmap que contiene a la imagen

    Private Sub FrmExplorador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' se produce cuando se carga por primera vez el formulario
        Dim ubicacion As Point 'crea objeto de tipo punto punto.x  punto.y
        Dim i, j, k As Integer  'inidces de una matriz
        For k = 0 To 2
            For i = 0 To 6          'bucles para creas los arreglos de text box
                For j = 0 To 6
                    valorpixel(i, j, k) = New TextBox      'instancia
                    Me.Controls.Add(valorpixel(i, j, k))   'añade a la coleccion controls
                    valorpixel(i, j, k).Text = " "         'establece propiedades
                    valorpixel(i, j, k).Width = 30
                    valorpixel(i, j, k).Height = 20
                    ubicacion.X = 450 + (j - 1) * valorpixel(i, j, k).Width + 1 'muestra ubicacion x
                    ubicacion.Y = 30 + k * 150 + (i - 1) * valorpixel(i, j, k).Height + 1   'muestra ubicacion y
                    valorpixel(i, j, k).BorderStyle = BorderStyle.FixedSingle
                    valorpixel(i, j, k).Location = ubicacion   'muestra el textbox
                Next j
            Next i
            valorpixel(3, 3, k).ForeColor = Color.CadetBlue 'pixel central
        Next k

    End Sub


    Private Sub pb1_MouseMove(sender As Object, e As MouseEventArgs) Handles pb1.MouseMove
        Dim i, j, x, y, valor1, i1, j1, k1 As Integer
        If Me.txtInfo.Text = "" Then Exit Sub
        x = e.X - 3
        y = e.Y - 3
        'obtencion de los colores de la imagen

        Dim color As New Color
        color = miimagen.GetPixel(e.X, e.Y)
        Me.lblposicion.Text = "X=" & e.X & " , Y=" & e.Y & "  r=" & color.R & "  g=" & color.G _
                                                    & "  b=" & color.B

        For k1 = 0 To 2
            For j1 = 0 To 6
                For i1 = 0 To 6
                    If (j1 + x) < 0 Or (i1 + y) < 0 Or (j1 + x) > UBound(matriz1, 2) Or (i1 + y) > UBound(matriz1, 1) Then
                        valorpixel(i1, j1, k1).Text = "-"
                    Else

                        valor1 = matriz1(i1 + y, j1 + x, k1) 'k maneja planos'
                        valorpixel(i1, j1, k1).Text = valor1
                    End If
                Next i1
            Next j1
        Next k1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim F2 As New FrmExplorador
        Me.Close()
        F2.Close()
    End Sub
End Class