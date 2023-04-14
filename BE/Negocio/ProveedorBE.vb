<Serializable> _
Public Class ProveedorBE
    Inherits ID

    Public Property CUIT As String
    Public Property Nombre As String
    Public Property Direccion As String
    Public Property Ciudad As BE.Cuidad
    Public Property Provincia As BE.Provincia
    Public Property Pais As BE.Pais
    Public Property Telefono As String
    Public Property Celular As String
    Public Property CorreoElectronico As String




    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function


    Sub New()

    End Sub


End Class
