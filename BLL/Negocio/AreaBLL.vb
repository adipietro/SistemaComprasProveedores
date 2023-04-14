Imports DAL
Imports BE

Public Class AreaBLL


    Sub New()

    End Sub


    Public Sub Guardar(mBE As BE.AreaBE)


        If mBE.ID = 0 Then

            AreaDAL.GuardarNuevo(mBE)
        Else
            AreaDAL.GuardarModificacion(mBE)
        End If
    End Sub


    Public Sub Eliminar(area As BE.AreaBE)

        AreaDAL.Eliminar(area)
    End Sub


    Public Function Listar() As List(Of BE.AreaBE)
        Return AreaDAL.Listar()
    End Function

End Class

