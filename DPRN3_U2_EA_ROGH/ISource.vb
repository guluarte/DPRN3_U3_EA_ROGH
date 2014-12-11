Public Interface ISource
    Function GetListaClientes() As Object
    Function GetCliente(id As Integer) As Cliente
    Sub Add(Cliente As Cliente)
    Sub Remove(id As Integer)
    Sub Save()
    Function Count() As Integer
End Interface
