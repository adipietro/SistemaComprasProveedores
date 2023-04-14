Imports DAL
Imports BE

Public Class CategoríaProductoBLL

    Sub New()

    End Sub



    Public Sub Guardar(mBE As BE.CategoríaProductoBE)

        If mBE.ID = 0 Then

            CategoriaProductoDAL.GuardarNuevo(mBE)
        Else

            CategoriaProductoDAL.GuardarModificacion(mBE)
        End If

    End Sub


    Public Sub Eliminar(mBE As BE.CategoríaProductoBE)

        CategoriaProductoDAL.Eliminar(mBE)
    End Sub


    Public Function Listar() As List(Of CategoríaProductoBE)

        Return CategoriaProductoDAL.Listar
    End Function



End Class
