Public Class Cliente

    Property Id() As Integer
    Property Nombre() As String
    Property Edad() As Integer
    Property Direccion() As String
    Property Sexo() As String
    Property Telefono() As String
    Sub New()

    End Sub

    Sub New(id As Integer, nombre As String, edad As Integer, direccion As String, sexo As String, telefono As String)
        Me.Id = id
        Me.Nombre = nombre
        Me.Edad = edad
        Me.Direccion = direccion
        Me.Sexo = sexo
        Me.Telefono = telefono
    End Sub
End Class
