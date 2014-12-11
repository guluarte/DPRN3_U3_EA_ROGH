Imports System.Windows.Forms.VisualStyles

Public Class Contactos
    Private _currentSource As ISource
    Private _bindingSource As New BindingSource()

    Dim _isNew As Boolean = False

    Private Sub Contactos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LabelId.Text = "0"
        _currentSource = New DatabaseSource()

        ' Object source para pruebas
        '_currentSource = New ObjectSource()

        If _currentSource.Count() < 1 Then
            _isNew = True
        Else
            _isNew = False
        End If

        _bindingSource.DataSource = _currentSource.GetListaClientes()
        AddFormControlDataBindings()


    End Sub

    Private Sub AddFormControlDataBindings()
        ClearFormControlDataBindings()
        _bindingSource.DataSource = _currentSource.GetListaClientes()
        LabelId.DataBindings.Add("Text", _bindingSource, "Id", True)
        TextBoxNombre.DataBindings.Add("Text", _bindingSource, "Nombre", True)
        TextBoxEdad.DataBindings.Add("Text", _bindingSource, "Edad", True)
        TextBoxDireccion.DataBindings.Add("Text", _bindingSource, "Direccion", True)
        TextBoxTelefono.DataBindings.Add("Text", _bindingSource, "Telefono", True)
        ComboBoxSexo.DataBindings.Add("Text", _bindingSource, "Sexo", True)

        DataGridView.DataSource = _bindingSource
    End Sub

    Private Sub ClearFormControlDataBindings()
        LabelId.DataBindings.Clear()
        ComboBoxSexo.DataBindings.Clear()
        TextBoxNombre.DataBindings.Clear()
        TextBoxEdad.DataBindings.Clear()
        TextBoxDireccion.DataBindings.Clear()
        TextBoxTelefono.DataBindings.Clear()
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        GuardarContacto()
    End Sub

    Private Sub Guardar()
        If ValidarForm() = False Then
            MessageBox.Show("LLene correctamente el formulario", "Error")
            Return
        End If
        GuardarContacto()
    End Sub

    Private Function ValidarForm() As Boolean

        If String.IsNullOrWhiteSpace(TextBoxNombre.Text) Then
            Return False
        End If
        Try
            Dim edad As Integer = Convert.ToInt16(TextBoxEdad.Text)
            If edad <= 0 Or edad >= 130 Then
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        If String.IsNullOrWhiteSpace(TextBoxDireccion.Text) Then
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


    Private Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        Dim agregarClienteForm = New AgregarCliente()
        agregarClienteForm.BindingSource = _bindingSource
        agregarClienteForm.Source = _currentSource
        agregarClienteForm.Show()
        If agregarClienteForm.DialogResult = DialogResult.OK Then
            
        End If

        AddFormControlDataBindings()
        _bindingSource.MoveLast()

    End Sub

    Private Sub ResetForm()
        _isNew = True
        ClearFormControlDataBindings()
        LabelId.Text = "0"
        TextBoxNombre.Text = ""
        TextBoxEdad.Text = ""
        TextBoxDireccion.Text = ""
        TextBoxTelefono.Text = ""
        ComboBoxSexo.SelectedIndex = -1
    End Sub

    Private Sub ToolStripButtonBack_Click(sender As Object, e As EventArgs) Handles ToolStripButtonBack.Click
        'AddFormControlDataBindings()
        _bindingSource.MovePrevious()
        If _currentSource.Count() < 1 Then
            _isNew = True
        Else
            _isNew = False
        End If
    End Sub

    Private Sub ToolStripButtonNext_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNext.Click
        'AddFormControlDataBindings()
        _bindingSource.MoveNext()

        If _currentSource.Count() < 1 Then
            _isNew = True
        Else
            _isNew = False
        End If

    End Sub


    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs)
        Guardar()
    End Sub

    Private Sub GuardarContacto()
        ' Al parecer hay que moverse dentro del bindingsource
        ' para que este propague los cambios....
        Dim pos As Integer = _bindingSource.Position
        _bindingSource.MovePrevious()
        _bindingSource.Position = pos
        _currentSource.Save()
        If _bindingSource.Count = 0 Then
            MessageBox.Show("Por favor agregue un contacto", "Error")
        Else
            MessageBox.Show("Contacto Guardado", "OK")
        End If

    End Sub

    Private Sub ToolStripButtonDelete_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDelete.Click
        Try
            _currentSource.Remove(LabelId.Text)
            _currentSource.Save()
            AddFormControlDataBindings()
            If _currentSource.Count() < 1 Then
                'HabilitaNavegacion(False)
                ResetForm()
            Else
                _bindingSource.MoveFirst()
                'AddFormControlDataBindings()
            End If
        Catch ex As Exception
            Throw ex
        End Try

        MessageBox.Show("Contacto Eliminado", "OK")



    End Sub

    Private Sub HabilitaNavegacion(enable As Boolean)
        ToolStripButtonNew.Enabled = enable
        ToolStripButtonDelete.Enabled = enable
        ToolStripButtonNext.Enabled = enable
        ToolStripButtonBack.Enabled = enable
    End Sub

    Private Sub Contactos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _bindingSource.MovePrevious()
        _currentSource.Save()
    End Sub

    Private Sub ButtonGuardar_Click_1(sender As Object, e As EventArgs) Handles ButtonGuardar.Click
        GuardarContacto()
    End Sub
End Class
