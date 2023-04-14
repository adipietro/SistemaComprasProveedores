Imports DAL
Imports BE

Public Class ProductoDetalleBLL


    Sub New()

    End Sub

    Sub New(Producto As String)
        CargarPropiedades(Producto)
    End Sub



    Private Sub CargarPropiedades(ProductoPropv As String)
        Dim mBE As BE.ProductoDetalleBE = ProductoDetalleDAL.ObtenerProductoProveedor(ProductoPropv)

    End Sub


    Public Sub GuardarNuevo(mBE As BE.ProductoDetalleBE)

        ProductoDetalleDAL.GuardarNuevo(mBE)

    End Sub
    Public Sub GuardarMod(mBE As BE.ProductoDetalleBE)

        ProductoDetalleDAL.GuardarModificacion(mBE)
    End Sub


    Public Sub Eliminar(PRODPROV As BE.ProductoDetalleBE)
        ProductoDetalleDAL.Eliminar(PRODPROV)
    End Sub


    Public Function Listar() As List(Of ProductoDetalleBE)

        Return ProductoDetalleDAL.Listar

    End Function
    Public Function ListarSimple() As List(Of ProductoDetalleBE)

        Return ProductoDetalleDAL.ListarSimple

    End Function

    Public Function ListarProveedores() As List(Of ProductoDetalleBE)

        Return ProductoDetalleDAL.listarProveedores

    End Function

    Public Function ListarProductos() As List(Of ProductoDetalleBE)
        Return ProductoDetalleDAL.listarProductos

    End Function

    Public Function listarSugerencia(Producto As String) As List(Of ProductoDetalleBE)
        Dim mlista As List(Of ProductoDetalleBE) = ProductoDetalleDAL.ListarSugerencia(Producto)


        Dim mprod As New ProductoDetalleBE
        mlista.Add(mprod)

        Return mlista
    End Function


    Public Function listarporProducto(proveedor As String) As List(Of ProductoDetalleBE)
        Dim mlista As List(Of ProductoDetalleBE) = ProductoDetalleDAL.ListarporProductos(proveedor)

        'Dim mprov As New ProductoDetalleBE
        'mlista.Add(mprov)

        Return mlista
    End Function

End Class
