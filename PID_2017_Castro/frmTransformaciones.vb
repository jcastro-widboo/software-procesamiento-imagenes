Public Class frmTransformaciones

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        cargar_imagen(pb1, ofd1)
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        grabar_imagen(pb2, sfd1)
    End Sub

    Private Sub btnOrigenDestino_Click(sender As System.Object, e As System.EventArgs) Handles btnOrigenDestino.Click
        aplicar_metodo("ORIGEN_DESTINO")
    End Sub

    Sub aplicar_metodo(ByRef metodo As String)
        Dim i1, i2 As Bitmap
        Dim factor As Double
        factor = Me.txtfactor.Text

        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = Me.pb1.Image

        Dim w2, h2 As Integer
        If metodo = "ORIGEN_DESTINO" Or metodo = "VECINO_PROXIMO" _
            Or metodo = "BILINEAL" Or metodo = "bicubica" Then

            w2 = i1.Width * factor
            h2 = i1.Height * factor



        End If
        Dim theta, thetar As Double
        If metodo = "rot_origen_destino" Or metodo = "rot_vecino_proximo" Or _
            metodo = "rot_bilineal" Then
            theta = InputBox("ingrese el angulo en grados")
            thetar = theta / 180 * Math.PI
            w2 = i1.Height * Math.Sin(Math.Abs(thetar)) + i1.Width * Math.Cos(Math.Abs(thetar))
            h2 = i1.Height * Math.Cos(Math.Abs(thetar)) + i1.Width * Math.Sin(Math.Abs(thetar))
        End If
        i2 = New Bitmap(w2, h2, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Me.Label3.Text = "dimensiones calculadas w = " & w2 & " h = " & h2
        If metodo = "ORIGEN_DESTINO" Then
            cambiotamaño_origen_destino(i1, i2, factor)
        End If

        If metodo = "VECINO_PROXIMO" Then
            cambiotamaño_vecinoproximo(i1, i2, factor)
        End If

        If metodo = "BILINEAL" Then
            cambiotamaño_interpolacionbilineal(i1, i2, factor)
        End If

        If metodo = "bicubica" Then
            cambiotamaño_interpolacionbicubica(i1, i2, factor)
        End If

        If metodo = "rot_origen_destino" Then
            rotar(i1, i2, theta)
        End If

        If metodo = "rot_vecino_proximo" Then
            rotar1(i1, i2, theta)
        End If


        If metodo = "rot_bilineal" Then
            rotar2(i1, i2, theta)
        End If
        'OTRAS TRANSFORMACIONES
        '...
        '...
        '...

        'mostrar el resultado de la operacion
        Me.pb2.Height = i2.Height
        Me.pb2.Width = i2.Width
        Me.pb2.Image = i2
    End Sub


    Private Sub btnVecinoproximo_Click(sender As System.Object, e As System.EventArgs) Handles btnVecinoproximo.Click
        aplicar_metodo("VECINO_PROXIMO")
    End Sub

    Private Sub btnbilineal_Click(sender As System.Object, e As System.EventArgs) Handles btnbilineal.Click
        aplicar_metodo("BILINEAL")
    End Sub

    Private Sub btnbicubica_Click(sender As System.Object, e As System.EventArgs) Handles btnbicubica.Click
        aplicar_metodo("bicubica")
    End Sub

    Private Sub btn_rot_or_des_Click(sender As System.Object, e As System.EventArgs) Handles btn_rot_or_des.Click
        aplicar_metodo("rot_origen_destino")
    End Sub

    Private Sub btn_rot_vcino_prox_Click(sender As System.Object, e As System.EventArgs) Handles btn_rot_vcino_prox.Click
        aplicar_metodo("rot_vecino_proximo")
    End Sub

    Private Sub btn_rot_bilineal_Click(sender As System.Object, e As System.EventArgs) Handles btn_rot_bilineal.Click
        aplicar_metodo("rot_bilineal")
    End Sub


    Private Sub frmTransformaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class