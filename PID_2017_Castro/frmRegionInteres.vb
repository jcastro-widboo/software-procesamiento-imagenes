Public Class frmRegionInteres
    Dim igrande As Bitmap
    Dim m1(2, 2, 2) As Integer
    Private Sub btncarga1_Click(sender As System.Object, e As System.EventArgs) Handles btncarga1.Click
        cargar_imagen(PB1, OpenFileDialog1)
        igrande = New Bitmap(PB1.Width, PB1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        igrande = pb1.Image
        Dim nf, nc As Integer
        nf = igrande.Height - 1
        nc = igrande.Width - 1
        ReDim m1(nf, nc, 2)
        bitmap_to_mRGB(igrande, m1)
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btncorrelacion.Click
        grabar_imagen(pb2, SaveFileDialog1)
    End Sub

    Private Sub PB1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PB1.MouseMove
        Dim area As Graphics, mipluma As Pen
        Dim FINALX, FINALY As Integer
        Static MIMAPA As Bitmap
        Static minx = 32000, miny = 32000, maxx = -1, maxy = -1
        mipluma = New Pen(Color.Red, 1)
        area = Me.PB1.CreateGraphics
        If Not (Me.PB1.Image Is Nothing) Then
            MIMAPA = New Bitmap(Me.PB1.Image)
            If e.Button = MouseButtons.Left Then
                Debug.Write(e.X & " " & e.Y & vbCrLf)
                If e.X > maxx Then maxx = e.X
                If e.Y > maxy Then maxy = e.Y
                If e.X < minx Then minx = e.X
                If e.Y < miny Then miny = e.Y
                Me.PB1.Image = MIMAPA
                area.DrawRectangle(mipluma, minx, miny, maxx - minx, maxy - miny)
            End If
            'boton derecho borra el area
            If e.Button = MouseButtons.Right Then
                Me.PB1.Image = MIMAPA
                minx = 32000 : miny = 32000 : maxx = -1 : maxy = -1
            End If
        End If
        If minx <> 32000 Then
            Dim MIMAPA2 As Bitmap, P1, P2 As Point

            P1.X = minx : P1.Y = miny : P2.X = maxx : P2.Y = maxy
            MIMAPA2 = New Bitmap(P2.X - P1.X + 1, P2.Y - P1.Y + 1, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            area.DrawRectangle(mipluma, minx, miny, maxx - minx, maxy - miny)
            Debug.Write("FIN " & minx & " " & miny & " " & maxx & " " & maxy & vbCrLf)
            'extrae parte de la imagen

            'rectangulo_extract(MIMAPA, MIMAPA2, P1, P2)
            rectangulo_extractm(m1, MIMAPA2, P1, P2)
            Me.pb2.Width = maxx - minx + 1
            Me.pb2.Height = maxy - miny + 1
            Me.pb2.Image = MIMAPA2
            Me.Label1.Text = "P1 = (" & P1.X & "," & P1.Y & ") - P2=(" & P2.X & "," & P2.Y & ")   "

        End If

    End Sub

    Private Sub btguardar_Click_1(sender As Object, e As EventArgs) Handles btguardar.Click
        Dim i1, i2, i3 As Bitmap

        ' i1 = New Bitmap(PB1.Width, PB1.Height, _
        '                System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i2 = New Bitmap(pb2.Width, pb2.Height, _
                        System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = pb1.Image
        i2 = pb2.Image
        i3 = New Bitmap(i1.Width, i1.Height, _
                        System.Drawing.Imaging.PixelFormat.Format24bppRgb)

        correl_imagenes(igrande, i2, i3)
        Me.pb3.Width = i3.Width
        Me.pb3.Height = i3.Height
        Me.pb3.Image = i3
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        grabar_imagen(pb3, SaveFileDialog1)
    End Sub

    Private Sub btnCargar2_Click(sender As Object, e As EventArgs) Handles btnCargar2.Click
        cargar_imagen(pb1, OpenFileDialog1)
    End Sub
End Class