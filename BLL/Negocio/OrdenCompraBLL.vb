Imports DAL
Imports BE

Public Class OrdenCompraBLL

    Sub New()

    End Sub

    Sub New(oc As String)
        CargarPropiedades(oc)
    End Sub

    Private Sub CargarPropiedades(OC As String)
        Dim mBE As BE.OrdenCompraBE = OrdenCompraDAL.ObtenerOC(OC)
        CalcularDH.VerificarDV(mBE.Fecha & mBE.Proveedor.Nombre & mBE.Area.Nombre & mBE.Importe, mBE.dvh)
    End Sub


    Public Sub Guardar(mBE As BE.OrdenCompraBE)

        mBE.dvh = CalcularDH.CalcularDV(mBE.Fecha & mBE.Proveedor.Nombre & mBE.Area.Nombre & mBE.Importe)
        If mBE.ID = 0 Then
            OrdenCompraDAL.GuardarNuevo(mBE)
            DigitoVerticalBLL.GuardarNuevo("OrdenCompra", DigitoVerticalBLL.CalcularDVV("OrdenCompra"))
        Else
            ' OrdenCompraDAL.GuardarModificacion(mBE)
            DigitoVerticalBLL.ModificarDigito("OrdenCompra", DigitoVerticalBLL.CalcularDVV("OrdenCompra"))
        End If

    End Sub


    Public Sub Eliminar()

        Dim mbe As New BE.OrdenCompraBE()
        
        OrdenCompraDAL.Eliminar(mbe)
        DigitoVerticalBLL.ModificarDigito("OrdenCompra", DigitoVerticalBLL.CalcularDVV("OrdenCompra"))
    End Sub

    

    Public Function Listar() As List(Of BE.OrdenCompraBE)
        Return OrdenCompraDAL.Listar()
    End Function

    Public Function ObtenerUltimaOC()
        Return OrdenCompraDAL.ObtenerUltimaOC()
    End Function
   
End Class

