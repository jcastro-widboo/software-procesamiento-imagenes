Public Class frmEtiquetamiento

    Dim tdc(20000, 2) As Integer
    Dim m1(2, 2) As Integer
    Dim objetos(20000, 7) As Integer
    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        cargar_imagen(pb1, ofd1)
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        grabar_imagen(pb2, sfd1)
    End Sub
    Private Sub btnPrincipal_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim i1, i2 As Bitmap
        i1 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i2 = New Bitmap(pb1.Width, pb1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        i1 = Me.pb1.Image
        ReDim m1(i1.Height - 1, i1.Width - 1)
        etiquetar(i1, i2, tdc, m1, "si")
        'mostrar el resultado de la operacion
        Me.pb2.Height = Me.pb1.Height
        Me.pb2.Width = Me.pb1.Width
        Me.pb2.Image = i2
    End Sub

    Private Sub frmEtiquetamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'genera la tabla de colores
        Dim i, j, k As Integer
        tdc(0, 0) = 0
        tdc(0, 1) = 0
        tdc(0, 2) = 0
        Dim r As New Random
        For i = 1 To 20000
            For j = 0 To 2
                tdc(i, j) = r.Next(255)
            Next
        Next
    End Sub

    Sub mostrar_propiedades(ByRef m1(,) As Integer, ByRef objetos(,) As Integer, ByRef Textbox As TextBox, ByRef pb As PictureBox)
        Dim nobjetos As Integer
        nobjetos = 0
        propiedades_objetos(m1, objetos, nobjetos)
        Dim Txt_res As String
        Dim Titulos(9) As String
        Dim Puntos(20000) As Point
        Txt_res = "Numero de Objetos=" & nobjetos
        Txt_res = Txt_res & vbCrLf
        '                      0    1    2   3    4     5    6    7    8 
        Txt_res = Txt_res & "--------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf
        Txt_res = Txt_res & "|" + Space(5) + "i" + Space(6) & vbTab + "etqt." + Space(6) & vbTab + "area" + Space(6) & vbTab +
            "xcg" + Space(6) & vbTab + "ycg" + Space(6) & vbTab + "x-in" + Space(6) & vbTab + "y-in" + Space(6) & vbTab + "x-fi" + Space(6) & vbTab + "y-fi  |" & vbCrLf
        Txt_res = Txt_res & "--------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf

        Txt_res = Txt_res & vbCrLf
        For i = 0 To nobjetos - 1
            Txt_res = Txt_res & (i + 1).ToString("#####").PadLeft(5) & vbTab
            For j = 0 To 7
                Puntos(i) = New Point(objetos(i, 2) - 5, objetos(i, 3))
                Txt_res = Txt_res & objetos(i, j).ToString("#####").PadLeft(5) & vbTab
            Next
            Txt_res = Txt_res & vbCrLf
        Next
        Textbox.Text = Txt_res
        'graficacion()
        Dim pluma As Pen
        pluma = New Pen(Brushes.White, 1)
        Dim g As Graphics


        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.White)

        g = pb2.CreateGraphics
        For i = 0 To nobjetos - 1
            g.DrawLine(pluma, objetos(i, 2) - 5, objetos(i, 3), objetos(i, 2) + 5, objetos(i, 3))
            g.DrawLine(pluma, objetos(i, 2), objetos(i, 3) - 5, objetos(i, 2), objetos(i, 3) + 5)
            g.DrawLine(pluma, objetos(i, 4), objetos(i, 5), objetos(i, 6), objetos(i, 5))
            g.DrawLine(pluma, objetos(i, 6), objetos(i, 5), objetos(i, 6), objetos(i, 7))
            g.DrawLine(pluma, objetos(i, 4), objetos(i, 7), objetos(i, 6), objetos(i, 7))
            g.DrawLine(pluma, objetos(i, 4), objetos(i, 5), objetos(i, 4), objetos(i, 7))
            g.DrawString(i + 1, drawFont, drawBrush, Puntos(i))
            g.DrawEllipse(pluma, Puntos(i).X, Puntos(i).Y, 20, 20)
        Next
        'TextBox1.TextAlign = HorizontalAlignment.Right
        Textbox.Text = Txt_res

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        mostrar_propiedades(m1, objetos, Me.txtResultado, Me.pb2)
    End Sub
End Class