Public Class ObjectSource : Implements ISource

    Private ReadOnly clientes As New List(Of Cliente)

    Sub New()
        Dim cliente As Cliente = New Cliente(id:=1, nombre:="Rodolfo", sexo:="Masculino", edad:=29, direccion:="No tiene", telefono:="1234567")
        clientes.Add(cliente)

        Dim cliente2 As Cliente = New Cliente(id:=2, nombre:="Josefa Quintero", sexo:="Masculino", edad:=29, direccion:="No tiene", telefono:="1234567")
        clientes.Add(cliente2)
    End Sub

    Public Function GetListaClientes() As Object Implements ISource.GetListaClientes
        Return clientes
    End Function

    Public Function GetCliente(id As Integer) As Cliente Implements ISource.GetCliente
        Dim query = From cliente In clientes Where cliente.Id = id Select cliente
        Return query.FirstOrDefault()
    End Function

    Public Sub Add(cliente As Cliente) Implements ISource.Add
        If clientes.Contains(cliente) = 0 Then
            clientes.Add(cliente)
            'bindingSource.Add(cliente)
        End If
    End Sub

    Public Sub Remove(id As Integer) Implements ISource.Remove
        Dim cliente As Cliente
        cliente = GetCliente(id)
        If clientes.Contains(cliente) <> 0 Then
            clientes.Remove(cliente)
            'bindingSource.Remove(cliente)
        End If
    End Sub

    Public Sub Save() Implements ISource.Save
        'Nothing, todo esta guardado en memoria
    End Sub

    Public Function Count() As Integer Implements ISource.Count
        Return GetListaClientes().Count
    End Function
End Class
