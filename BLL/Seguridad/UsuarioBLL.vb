Imports DAL
Imports BE
Public Class UsuarioBLL


    Public Sub Guardar(mBE As BE.UsuarioBE)

        If mBE.ID = 0 Then

            UsuarioDAL.GuardarNuevo(mBE)
        Else

            UsuarioDAL.GuardarModificacion(mBE)
        End If
    End Sub


    Public Sub Eliminar(mBe As BE.UsuarioBE)

        UsuarioDAL.Eliminar(mBe)
    End Sub


    Public Function ListarUsuarios() As List(Of UsuarioBE)
        Return UsuarioDAL.ListarUsuarios()
    End Function

    Public Function ObtenerUsuarioPorId(usuario_id As String) As UsuarioBE
        Return UsuarioDAL.ObtenerUsuario(usuario_id)
    End Function

End Class
