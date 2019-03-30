Public Class frmPerfiles
    ' variables globales
    Dim anchoScroll As Integer = 21
    Dim matriz1(100, 100) As Integer
    Dim i1, i2, j1, j2 As Integer 'posicion de la ventana

    '-------------otro mtodo------------
    Dim matriz2(2, 2, 2) As Integer
    Dim img1 As Bitmap
    Dim capa, capa2, capa3 As Graphics
    Dim pluma1, pluma2 As Pen
    Private Sub frmPerfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.trbV.Height = Me.Panel1.Height
        Me.PictureBox2.Width = Me.Panel1.Width
        Me.trbV.Maximum = Me.Panel1.Height - anchoScroll

        Me.trbH.Width = Me.Panel1.Width
        Me.PictureBox3.Height = Me.Panel1.Height
        Me.trbH.Maximum = Me.Panel1.Height - anchoScroll


        '-------------otro mtodo------------
        capa = pb1.CreateGraphics()
        pluma1 = New Pen(Brushes.Aquamarine, 1)
        capa2 = Me.PictureBox2.CreateGraphics()
        pluma2 = New Pen(Brushes.Red, 1)
        capa3 = Me.PictureBox3.CreateGraphics()


    End Sub
    Private Sub btncargar_Click(sender As Object, e As EventArgs) Handles btncargar.Click

        cargar_imagen(pb1, ofd1, tb1)
        Dim imagen1 As Bitmap
        imagen1 = New Bitmap(Me.pb1.Width, Me.pb1.Height, _
                 System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        imagen1 = Me.pb1.Image
        'MessageBox.Show(imagen1.PixelFormat.ToString)
        Dim nf, nc As Integer
        nf = imagen1.Height - 1 : nc = imagen1.Width - 1
        ReDim matriz1(nf, nc)
        bitmap_to_m(imagen1, matriz1)

        If pb1.Width < Panel1.Width Then

            Me.PictureBox2.Width = Me.pb1.Width
            Me.PictureBox3.Height = Me.pb1.Height

        Else


            Me.PictureBox2.Width = Me.Panel1.Width - anchoScroll
            Me.PictureBox3.Height = Me.Panel1.Height - anchoScroll

        End If
        If pb1.Height < Panel1.Height Then
            Me.trbV.Height = Me.pb1.Height + anchoScroll
            Me.trbH.Width = Me.pb1.Width + anchoScroll

            Me.trbV.Maximum = Me.pb1.Height - 1
            Me.trbH.Maximum = Me.pb1.Width - 1
        Else

            Me.trbV.Height = Me.Panel1.Height + 6
            Me.trbH.Width = Me.Panel1.Width + 6

            Me.trbV.Maximum = Me.Panel1.Height - anchoScroll
            Me.trbH.Maximum = Me.Panel1.Width - anchoScroll

        End If
        calcular_rectangulo()

        '------otro metodo------------creacion de objeto bitmap
        img1 = New Bitmap(pb1.Image)
        ReDim matriz2(img1.Height - 1, img1.Width - 1, 2)
        bitmap_to_mRGB1(img1, matriz2)
        If img1.Width < Panel1.Width Then
            PictureBox2.Width = img1.Width
            PictureBox3.Height = img1.Height
        End If
        capa = pb1.CreateGraphics()

    End Sub
    Sub calcular_rectangulo()
        'calcula  fila columna inicial a fila y columna final  (i1, j1) - (i2,j2)
        Debug.Print(pb1.Location.X & "-- " & pb1.Location.Y)
        i1 = 0 : i2 = Panel1.Height
        j1 = 0 : j2 = Panel1.Width
        If pb1.Location.X < 0 Then
            j1 = -pb1.Location.X
            j2 = j1 + Panel1.Width - anchoScroll
        Else
            If pb1.Width < Panel1.Width Then
                j2 = pb1.Width - 1
            End If

        End If
        If pb1.Location.Y < 0 Then
            i1 = -pb1.Location.Y
            i2 = i1 + Panel1.Height - anchoScroll
        Else
            If pb1.Height < Panel1.Height Then
                i2 = pb1.Height - 1
            End If

        End If
    End Sub

    Private Sub Panel1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Panel1.Scroll
        calcular_rectangulo()
    End Sub


    Private Sub tb_vertical_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbV.Scroll
        Me.lblposy.Text = Me.trbV.Maximum - Me.trbV.Value
        Dim area As Graphics
        Dim pluma As Pen
        Dim i, j As Integer
        area = Me.PictureBox2.CreateGraphics
        pluma = New Pen(Color.Red)
        pluma.Width = 1
        i = Me.lblposy.Text - pb1.Location.Y
        If (i < 0) Then i = 0 'si i es menor que 0
        If (i > UBound(matriz1, 1)) Then i = UBound(matriz1, 1)
        area.Clear(Me.PictureBox2.BackColor)
        Dim j3 As Integer
        For j = j1 To j2
            If (j < 0) Then j = 0 'si j es menor que 0
            If (j > UBound(matriz1, 2)) Then j = UBound(matriz1, 2) 'si j se pasa de nc
            j3 = j - j1
            'area.drawline(pñluma, x1,y1,x2,y2)
            area.DrawLine(pluma1, j3, 255 - matriz1(i, j), j3, 255)
        Next
    End Sub


    Private Sub PB1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pb1.MouseClick
        Dim j, i, xi, yi, j1, j2, ng, ng1 As Integer


        If e.Button = Windows.Forms.MouseButtons.Left Then
            capa2.Clear(Me.BackColor)
            capa3.Clear(Me.BackColor)
            capa.DrawLine(pluma1, 0, e.Y, pb1.Width - 1, e.Y)
            capa.DrawLine(pluma2, e.X, 0, e.X, pb1.Height - 1)
            xi = Me.pb1.Location.X
            j1 = 0
            If xi < 0 Then j1 = -xi
            j2 = j1 + 299
            If pb1.Width < 300 Then j2 = pb1.Width - 1
            For j = j1 To j2
                If j > UBound(matriz2, 2) Then
                    ng = 0
                Else
                    ng = matriz2(e.Y, j, 0)
                End If
                capa2.DrawLine(pluma1, j - j1, 255, j - j1, 255 - ng)
            Next
            xi = Me.pb1.Location.Y
            j1 = 0
            If xi < 0 Then j1 = -xi
            j2 = j1 + 299
            If pb1.Height < 300 Then j2 = pb1.Height - 1
            For j = j1 To j2
                If j > UBound(matriz2, 1) Then
                    ng1 = 0
                Else
                    ng1 = matriz2(j, e.X, 0)
                End If
                capa3.DrawLine(pluma2, 0, j - j1, ng1, j - j1)
            Next
            'capa.DrawLine(pluma, 0, e.Y, PB1.Width - 1, e.Y)
        Else
            If e.Button = Windows.Forms.MouseButtons.Right Then
                capa.Dispose()
                capa = pb1.CreateGraphics()
                capa2.Clear(Me.BackColor)
                capa3.Clear(Me.BackColor)
                'capa2 = PictureBox1.CreateGraphics()
                pb1.Image = img1
            End If
        End If
    End Sub

    Private Sub tb_horizontal_Scroll(sender As System.Object, e As System.EventArgs) Handles trbH.Scroll
        'Me.lblposx.Text = Me.tb_horizontal.Maximum - Me.tb_horizontal.Value
        Me.lblposx.Text = Me.trbH.Value
        Dim area As Graphics
        Dim pluma As Pen
        Dim i, j As Integer
        area = Me.PictureBox3.CreateGraphics
        pluma = New Pen(Color.Red)
        pluma.Width = 1
        i = Me.lblposx.Text - pb1.Location.X
        If (i < 0) Then i = 0 'si i es menor que 0
        If (i > UBound(matriz1, 2)) Then i = UBound(matriz1, 2)
        area.Clear(Me.PictureBox3.BackColor)
        Dim j3 As Integer
        For j = i1 To i2
            If (j < 0) Then j = 0 'si j es menor que 0
            If (j > UBound(matriz1, 1)) Then j = UBound(matriz1, 1) 'si j se pasa de nc
            j3 = j - i1
            'area.drawline(pñluma, x1,y1,x2,y2)
            area.DrawLine(pluma2, 0, j3, matriz1(j, i), j3)
        Next
    End Sub


    Private Sub pb1_MouseMove(sender As Object, e As MouseEventArgs) Handles pb1.MouseMove
        Me.lblposx.Text = e.X - pb1.Location.X
        Me.lblposy.Text = e.Y - pb1.Location.Y
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim F2 As New frmPerfiles
        Me.Close()
        F2.Close()
    End Sub
End Class
