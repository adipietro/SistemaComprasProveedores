Imports DAL
Imports BE

Public Class ProductoBLL

    Sub New()

    End Sub

    Sub New(Producto As String)
        CargarPropiedades(Producto)
    End Sub

    Private Sub CargarPropiedades(Producto As String)
        Dim mBE As BE.ProductoBE = ProductoDAL.ObtenerProducto(Producto)
    End Sub

    Public Sub Guardar(mBE As BE.ProductoBE)
        If mBE.ID = 0 Then
            ProductoDAL.GuardarNuevo(mBE)
        Else
            ProductoDAL.GuardarModificacion(mBE)
        End If
    End Sub

    Public Sub Eliminar(unProducto As BE.ProductoBE)
        ProductoDAL.Eliminar(unProducto)
    End Sub

    Public Function Listar() As List(Of BE.ProductoBE)
        Return ProductoDAL.Listar()
    End Function

End Class
