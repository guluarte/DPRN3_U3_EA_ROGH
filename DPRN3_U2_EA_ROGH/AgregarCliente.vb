Imports System.Windows.Forms.VisualStyles
Imports System.Diagnostics.Contracts

Public Class AgregarCliente
    Property Source() As ISource
    Property BindingSource() As BindingSource

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ResetForm()

    End Sub

    Private Sub ResetForm()
        TextBoxDireccion.Text = ""
        TextBoxEdad.Text = ""
        TextBoxNombre.Text = ""
        TextBoxTelefono.Text = ""
        ComboBoxSexo.SelectedIndex = 0

    End Sub
    Function ValidarMe() As Boolean
        If String.IsNullOrWhiteSpace(TextBoxDireccion.Text) Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBoxNombre.Text) Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBoxEdad.Text) Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBoxTelefono.Text) Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(ComboBoxSexo.Text) Then
            Return False
        End If


        Return True
    End Function
    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click
        Me.DialogResult = DialogResult.Abort
        If _Source IsNot Nothing And ValidarMe() Then

            Try
                Dim cliente As New Cliente()
                cliente.Direccion = TextBoxDireccion.Text
                cliente.Nombre = TextBoxNombre.Text
                cliente.Edad = Convert.ToInt16(TextBoxEdad.Text)
                cliente.Sexo = ComboBoxSexo.Text
                cliente.Telefono = TextBoxTelefono.Text
                _Source.Add(cliente)
                Me.DialogResult = DialogResult.OK

                _Source.Save()
                MessageBox.Show("Cliente agregado con exito", "OK")
                Me.Hide()
            Catch ex As Exception
                MessageBox.Show("Hubo un error al agregar al cliente", "Error")
                Throw ex
            End Try


        Else
            MessageBox.Show("Por favor complete el formulario", "Error")
        End If
    End Sub
End Class