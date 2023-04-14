Imports DAL
Imports BE

Public Class RegistroCompraBLL


    Sub New()

    End Sub

    Sub New(DV As String)
        CargarPropiedades(DV)
    End Sub



    Private Sub CargarPropiedades(DV As String)
        Dim mBE As BE.RegistroCompraBE = RegistroCompraDAL.ObtenerPedido(DV)

    End Sub


    Public Sub Guardar(mBE As BE.RegistroCompraBE)

        RegistroCompraDAL.GuardarNuevo(mBE)

    End Sub


    Public Function Listar() As List(Of BE.RegistroCompraBE)
        Return RegistroCompraDAL.Listar()



    End Function

    Public Function ListarRegistros(ID As Integer) As List(Of BE.RegistroCompraBE)
        Dim mlista As List(Of RegistroCompraBE) = RegistroCompraDAL.ListarPorOrden(ID)
        Dim rc As New RegistroCompraBE
        mlista.Add(rc)

        Return mlista

    End Function

    Public Function CalcularDescuento(unDescuento As Double, unPrecio As Double, unaCantidad As Double, unaCantDesc As Double) As Double

        Dim total As Double


        If unaCantidad >= unaCantDesc Then
            total = ((unPrecio * unaCantidad) * unDescuento) / 100

            Return total
        Else
            total = 0
        End If
        Return total
    End Function

    Public Function CalcularSubTotal(unaCantidad As Double, unPrecio As Double)
        Dim rc As New BE.RegistroCompraBE
        Dim prodProv As New BE.ProductoDetalleBE
        Dim total As Double

        rc.Cantidad = unaCantidad
        prodProv.Precio = unPrecio

        total = unaCantidad * unPrecio

        Return total
    End Function

    Public Function CalcularTotal(unPrecio As Double, unDescuento As Double, unaCantidad As Integer, unaCantidadDesc As Double)

        Dim Total As Double
        If unaCantidad >= unaCantidadDesc Then
            Total = (unPrecio * unaCantidad) - ((unPrecio * unaCantidad) * unDescuento) / 100
        Else
            Total = (unPrecio * unaCantidad)
        End If

        Return Total

    End Function

    Public Function CalcularTotalOC(unTotal As Double, unResultado As Double)
        Dim totalOC As Double

        totalOC = unTotal + unResultado
        Return totalOC
    End Function

    Public Sub Eliminar(dv As BE.RegistroCompraBE)

        RegistroCompraDAL.Eliminar(dv)
    End Sub


End Class
