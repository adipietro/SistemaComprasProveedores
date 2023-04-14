Imports BE
Public Class RolGrupoPermisosDAL


    Public Shared Sub GuardarNuevo(pfamiliaID As Integer, pPatenteID As Integer)
        Dim mCommand As String = "INSERT INTO FamiliaGrupoPatente(familia_id, grupopatente_id) VALUES " &
                                 "(" & pfamiliaID & ", " & pPatenteID & ")"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - FamiliaGrupoPatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub EliminarPorPatente(ppatenteID As Integer)
        Dim mCommand As String = "DELETE FROM FamiliaGrupoPatente WHERE GrupoPatente_id = " & ppatenteID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminar Permiso - FamiliaGrupoPatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub



    Public Shared Sub EliminarPorFamilia(PfamiliaID As Integer)
        Dim mCommand As String = "DELETE FROM FamiliaGrupoPatente WHERE Familia_id = " & PfamiliaID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminar Rol - FamiliaGrupoPatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub Eliminar(PfamiliaID As Integer, ppatenteID As Integer)
        Dim mCommand As String = "DELETE FROM FamiliaGrupoPatente WHERE Familia_id= " & PfamiliaID & "AND GrupoPatente_id= " & ppatenteID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminar Permiso de Rol - FamiliaGrupoPatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub

End Class