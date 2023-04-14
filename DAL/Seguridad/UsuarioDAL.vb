Imports BE
Imports System.Data.SqlClient

Public Class UsuarioDAL


    Private Shared mProximoID As Integer
    Public Shared Function GetProximoID() As Integer
        Return Conexion.ExecuteScalar("select isnull(max(Usuario_id), 0) from Usuario") + 1
    End Function

    Private Shared Function CargarBE(pRow As DataRow) As BE.UsuarioBE
        Dim pUsuario As New BE.UsuarioBE
        pUsuario.ID = pRow("Usuario_id")
        pUsuario.nombre = pRow("Nombre")
        pUsuario.Apellido = pRow("Apellido")
        pUsuario.usuario = pRow("Usuario")
        pUsuario.contraseña = pRow("Contraseña")

        Return pUsuario
    End Function


    Public Shared Function ObtenerUsuario(pUser As String) As BE.UsuarioBE
        Dim mUsuario As BE.UsuarioBE
        Dim mCommand As String = "SELECT * FROM Usuario WHERE usuario  LIKE  @puser"
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@puser", pUser)
            }
        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mUsuario = CargarBE(mDataSet.Tables(0).Rows(0))
                Return mUsuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - UsuarioDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pUsuario As BE.UsuarioBE)
        Dim mCommand As String = "INSERT INTO Usuario( nombre, apellido,usuario, contraseña)" &
                                 "VALUES ('" & pUsuario.nombre & "', '" & pUsuario.Apellido & "','" & pUsuario.usuario & "', '" & pUsuario.contraseña & "');"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - UsuarioDAL")
            MsgBox(ex.Message)
        End Try
    End Sub



    Public Shared Sub GuardarModificacion(pUsuario As BE.UsuarioBE)
        Dim mCommand As String = "UPDATE Usuario SET " &
                                 "Nombre = '" & pUsuario.nombre &
                                 "', Apellido = '" & pUsuario.Apellido &
                                   "', Usuario = '" & pUsuario.usuario &
                                 "', Contraseña = '" & pUsuario.contraseña &
                                 "' WHERE Usuario_id = " & pUsuario.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - UsuarioDAL")
            MsgBox(ex.Message)
        End Try
    End Sub



    Public Shared Sub Eliminar(pUsuario As BE.UsuarioBE)
        Dim mCommand As String = "DELETE FROM Usuario WHERE Usuario_id = " & pUsuario.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - UsuarioDAL")
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Function ListarUsuarios() As List(Of BE.UsuarioBE)
        Dim mLista As New List(Of BE.UsuarioBE)
        Dim mCommand As String = "SELECT * FROM Usuario"
        Dim mDataSet As DataSet
        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand)
            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mUsuario As BE.UsuarioBE
                    mUsuario = CargarBE(mRow)
                    mLista.Add(mUsuario)
                Next
                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - UsuarioDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
