
Imports MySql.Data.MySqlClient

Public Class DatabaseSource : Implements ISource
    Private _dataset As New DataSet()
    Private _dataadapter As MySqlDataAdapter
    Private _cn As MySqlConnection


    Private _nextId As Integer = Integer.MaxValue


    Sub New()
        _cn = New MySqlConnection(My.Settings.dbContactos)
        _dataadapter = New MySqlDataAdapter("SELECT * FROM contactos", _cn)
        BuildCommands()
        _dataadapter.Fill(_dataset, "Contactos")
    End Sub

    Public Sub BuildCommands()
        _dataadapter.SelectCommand = New MySqlCommand("SELECT * FROM contactos;", _cn)
        _dataadapter.InsertCommand = New MySqlCommand("INSERT INTO contactos (Nombre, Edad, Sexo, Direccion, Telefono)" _
                                                                  & "VALUES (@Nombre, @Edad, @Sexo, @Direccion, @Telefono)", _cn)

        _dataadapter.InsertCommand.Parameters.Add("@Nombre", MySqlDbType.VarChar, 150, "Nombre")
        _dataadapter.InsertCommand.Parameters.Add("@Edad", MySqlDbType.Int16, 3, "Edad")
        _dataadapter.InsertCommand.Parameters.Add("@Direccion", MySqlDbType.VarChar, 250, "Direccion")
        _dataadapter.InsertCommand.Parameters.Add("@Telefono", MySqlDbType.VarChar, 20, "Telefono")
        _dataadapter.InsertCommand.Parameters.Add("@Sexo", MySqlDbType.Set, 20, "Sexo")


        _dataadapter.DeleteCommand = New MySqlCommand("DELETE FROM contactos WHERE Id = @Id", _cn)
        _dataadapter.DeleteCommand.Parameters.Add("@Id", MySqlDbType.Int32, 11, "Id")


        _dataadapter.UpdateCommand = New MySqlCommand("UPDATE contactos  SET `Nombre` = @Nombre, `Edad` = @Edad, `Sexo` = @Sexo, `Direccion` = @Direccion, `Telefono` = @Telefono WHERE Id = @Id", _cn)
        _dataadapter.UpdateCommand.Parameters.Add("@Nombre", MySqlDbType.VarChar, 150, "Nombre")
        _dataadapter.UpdateCommand.Parameters.Add("@Edad", MySqlDbType.Int16, 3, "Edad")
        _dataadapter.UpdateCommand.Parameters.Add("@Direccion", MySqlDbType.VarChar, 250, "Direccion")
        _dataadapter.UpdateCommand.Parameters.Add("@Telefono", MySqlDbType.VarChar, 20, "Telefono")
        _dataadapter.UpdateCommand.Parameters.Add("@Id", MySqlDbType.Int32, 11, "Id")
        _dataadapter.UpdateCommand.Parameters.Add("@Sexo", MySqlDbType.Set, 20, "Sexo")
    End Sub

    Public Function GetListaClientes() As Object Implements ISource.GetListaClientes
        Dim table = _dataset.Tables("Contactos")
        Return table
    End Function

    Public Function GetCliente(ByVal id As Integer) As Cliente Implements ISource.GetCliente
        Dim row As DataRow = GetClienteRow(id)
        Return BuildClienteFromRow(row)
    End Function

    Private Function GetClienteRow(ByVal id As Integer) As DataRow

        Dim table = _dataset.Tables("Contactos")
        Dim query = From cliente In table.AsEnumerable()
                Where cliente.RowState <> DataRowState.Deleted AndAlso
                      cliente.Field(Of Integer)("Id") = id
                Select cliente
        Return query.Single()
    End Function

    Private Function BuildClienteFromRow(ByVal row As DataRow) As Cliente

        Return New Cliente(id:=row("Id"), nombre:=row("Nombre"), edad:=row("Edad"), telefono:=row("Telefono"), _
                           sexo:=row("Sexo"), direccion:=row("Direccion"))
    End Function

    Public Sub Add(cliente As Cliente) Implements ISource.Add
        Dim table = _dataset.Tables("Contactos")

        Dim row = table.NewRow
        If cliente.Id > 0 Then
            row("Id") = cliente.Id
        Else
            _nextId -= 1
            row("Id") = _nextId
        End If
        row("Nombre") = cliente.Nombre
        row("Direccion") = cliente.Direccion
        row("Telefono") = cliente.Telefono
        row("Sexo") = cliente.Sexo
        row("Edad") = cliente.Edad

        table.Rows.Add(row)


    End Sub

    Public Sub Remove(ByVal id As Integer) Implements ISource.Remove
        Dim row As DataRow = GetClienteRow(id)
        row.Delete()
    End Sub

    Public Sub Save() Implements ISource.Save
        Try
            _cn = New MySqlConnection(My.Settings.dbContactos)
            _cn.Open()
            _dataadapter.Update(_dataset, "Contactos")

            _cn.Close()
            _dataset.Clear()
            _dataadapter.Fill(_dataset, "Contactos")

        Catch ex As Exception
            If _cn IsNot Nothing Then
                _cn.Dispose()
            End If
            Throw ex
        End Try
    End Sub

    Public Function Count() As Integer Implements ISource.Count
        Dim table = _dataset.Tables("Contactos")
        Return table.Rows.Count
    End Function
End Class
