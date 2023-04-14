Imports DAL
Imports BE


Public Class EmpleadoBLL
    Sub New()

    End Sub


    Public Sub Guardar(mBE As Empleado)


        If mBE.ID = 0 Then

            EmpleadoDAL.GuardarNuevo(mBE)
        Else
            EmpleadoDAL.GuardarModificacion(mBE)
        End If
    End Sub


    Public Sub Eliminar(Empleado As Empleado)

        EmpleadoDAL.Eliminar(Empleado)
    End Sub


    Public Function Listar() As List(Of Empleado)
        Return EmpleadoDAL.Listar
    End Function

    Public Function ListarEspecial(Area As String) As List(Of Empleado)
        Return EmpleadoDAL.ListarEspecial(Area)
    End Function

End Class
