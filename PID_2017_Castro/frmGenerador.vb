'Sentencia de inicio de la clase frmGenerador
Public Class frmGenerador

    'Declaración de variables de tipo Integer que serán utilizadas para seleccionar el color en el ComboBox de Color.
    'La variable tcolor envía 2 agrumentos el primero es el numero de pixeles, y el segundo genera el color.
    Dim tcolor1(255, 2) As Integer
    Dim tcolor2(255, 2) As Integer
    Dim tcolor3(255, 2) As Integer
    Dim tcolor4(255, 2) As Integer
    Dim tcolor5(255, 2) As Integer
    Dim tcolor6(255, 2) As Integer
    Dim tcolors(255, 2) As Integer


    'Código del boton guardar.
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

        'Llama al metodo grabar_imagen y envía dos argumentos (PictureBox y SaveFileDialog).
        'Envía como argumento el PictureBox para capturar la imágen generada.
        'Envía como argumento el SaveFileDialog para mostrar la ventana emergente que permita guardar la imagen.
        grabar_imagen(pb1, sfd1)

    End Sub

    'Método llamar_generador recibe como parametros (La funcion seleccionada, el estado del CheckBox y el color seleccionado).
    Sub llamar_generador(ByRef valorf As Integer, ByRef colorsino As Boolean, ByRef tcolor(,) As Integer)

        'Declaración de la vairable ancho y alto de tipo Integer.
        Dim ancho, alto As Integer

        'Declaración de la variable x1, x2, yi, ys de tipo Double
        Dim xi, xs, yi, ys As Double

        'A la variable ancho se le asigna el valor del TextBox (ANCHO (PIX)).
        ancho = Me.txtancho.Text

        'A la variable alto se le asigna el valor del TextBox (ALTO (PIX)).
        alto = txtalto.Text

        'A la viariable xi se le asigna el valor del TextBox (X INF).
        'A la viariable xs se le asigna el valor del TextBox (X SUP).
        'A la viariable yi se le asigna el valor del TextBox (Y INF).
        'A la viariable ys se le asigna el valor del TextBox (Y SUP).
        xi = txtxi.Text : xs = txtxs.Text : yi = txtyi.Text : ys = txtys.Text

        'Llama al metodo generar_imagen y envía como argumento las variables antes descritas.
        generar_imagen(ancho, alto, xi, xs, yi, ys, pb1, valorf, colorsino, tcolor)

    End Sub

    'Código del boton salir.
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        'Declara la variable de tipo objeto frmGenerador.
        Dim F2 As New frmGenerador

        'Cierra el formulario frmGenerador mediante el metodo Close().
        Me.Close()
        F2.Close()

    End Sub

    'Método que se ejecuta cada vez que se carga el formulario frmGenerador.
    Private Sub frmGenerador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'No dejar escojer la lista de colores la variable esta en False.
        cbxlColor.Enabled = False

        'Genera la tabla de colores, declara las viariables i, j de tipo Integer.
        Dim i, j As Integer

        'Declara la variable r de tipo Random.
        Dim r As New Random

        'Inicia un bucle con i = 0 y un tope de 255, que va a recorrer los colores segun el tipo de color seleccionado.
        For i = 0 To 255

            tcolor1(i, 0) = i                           'Color rojo.
            tcolor1(i, 1) = 255 - i                     'Color verde.
            tcolor1(i, 2) = 255                         'Color azul.
            '----------------------------------------------------------
            tcolor2(i, 0) = 255 - i                     'Color rojo.
            tcolor2(i, 1) = 255                         'Color verde.
            tcolor2(i, 2) = i                           'Color azul.
            '----------------------------------------------------------
            tcolor3(i, 0) = r.Next(255)                 'Color rojo.
            tcolor3(i, 1) = r.Next(255)                 'Color verde.
            tcolor3(i, 2) = r.Next(255)                 'Color azul.
            '----------------------------------------------------------
            tcolor4(i, 0) = 255                         'Color rojo.
            tcolor4(i, 1) = i                           'Color verde.
            tcolor4(i, 2) = 255 - i                     'Color azul.
            '----------------------------------------------------------
            tcolor5(i, 0) = r.Next(125) + r.Next(130)   'Color rojo.
            tcolor5(i, 1) = r.Next(125) + r.Next(130)   'Color verde.
            tcolor5(i, 2) = r.Next(125) + r.Next(130)   'Color azul.
            '----------------------------------------------------------
            tcolor6(i, 0) = r.Next(130) + 125           'Color rojo.
            tcolor6(i, 1) = r.Next(130) + r.Next(125)   'Color verde.
            tcolor6(i, 2) = r.Next(125)                 'Color azul.

        Next
        'Fin del bucle.

    End Sub

    'Código del CheckBox. 
    Private Sub cbxActDes_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxActDes.CheckedChanged

        'Condicional que activa o desactiva el CheckBox.
        If cbxActDes.Checked = True Then

            'Inicialmente el CheckBox se encuentra Desactivado.
            cbxlColor.Enabled = True
            cbxActDes.Text = "Desactivar"

        Else

            'Con esta opción el CheckBox se activa.
            cbxActDes.Text = "Activar"
            cbxlColor.Enabled = False

        End If
        'Fin del condicional.

    End Sub

    'Código del boton Generar.
    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click

        'Condicional que verifica el estado del ComboBox del Color, si esta activo envia el color respectivo,
        'en caso contrario envia el color blanco y negro.
        If cbxlColor.Text = "" Then

            'Llama al método llamar_generador y envía (La funcion seleccionada, el estado del CheckBox y el color seleccionado).
            llamar_generador(cbxlFuncion.SelectedIndex + 1, False, tcolors)

        Else

            'Llama al método tabla_color y envía los argumentos (El numero del color en el ComboBox y el color).
            tabla_color(cbxlColor.SelectedIndex, tcolors)

            'Llama al método llamar_generador y envía (La funcion seleccionada, el estado del CheckBox y el color seleccionado).
            llamar_generador(cbxlFuncion.SelectedIndex + 1, cbxActDes.Checked, tcolors)

        End If
        'Fin del condicional.

    End Sub

    'Método tabla_color que tiene como parámetros (El numero del color en el ComboBox, y el color).
    Sub tabla_color(numero As Integer, ByRef tcolors(,) As Integer)

        'En caso de seleccionar un color se envía un número que lo representa.
        Select Case numero
            Case 0
                tcolors = tcolor1
            Case 1
                tcolors = tcolor2
            Case 2
                tcolors = tcolor3
            Case 3
                tcolors = tcolor4
            Case 4
                tcolors = tcolor5
            Case 5
                tcolors = tcolor6
        End Select

    End Sub

End Class 'Fin de la clase frmGenerador.


