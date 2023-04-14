Imports System.Data.SqlClient

Public Class DiccionarioDAL
    Private Shared Function CargarBE(pdiccionario As BE.Diccionario, pRow As DataRow) As BE.Diccionario
        pdiccionario.id_diccionario = pRow("id_diccionario")
        pdiccionario.id_idioma = pRow("id_idioma")
        pdiccionario.valor = pRow("valor")

        Return pdiccionario
    End Function


    Public Shared Function Obtenerdiccionario(pid As String) As BE.Diccionario
        Dim mdiccionario As New BE.Diccionario
        Dim mCommand As String = "SELECT id_idioma, valor FROM idioma_diccionario WHERE id_idioma  = @pID"
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", pid)
            }

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mdiccionario = CargarBE(mdiccionario, mDataSet.Tables(0).Rows(0))
                Return mdiccionario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet -DiccionarioDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pdiccionario As BE.Diccionario)
        Dim mCommand As String = "INSERT INTO idioma_diccionario( valor, id_idioma,id_diccionario )" &
                                 "VALUES ('" & pdiccionario.valor & "', " & pdiccionario.id_idioma & ", " & pdiccionario.id_diccionario & " );"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - DiccionarioDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    'Modifica un registro de la tabla Usuario
    Public Shared Sub GuardarModificacion(pdiccionario As BE.Diccionario)
        Dim mCommand As String = "UPDATE idioma_diccionario SET " &
                                 "id_diccionario = " & pdiccionario.id_diccionario &
                                 ", id_idioma = " & pdiccionario.id_idioma &
                                 ", valor = '" & pdiccionario.valor &
                                 "' WHERE id_idioma = " & pdiccionario.id_idioma

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - diccionarioDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    'Elimina un registro de la tabla Idioma_diccionario
    Public Shared Sub Eliminar(pidioma As Integer)
        Dim mCommand As String = "DELETE FROM idioma_diccionario WHERE id_idioma = " & pidioma

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - diccionarioDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    'Devuelve una lista de objetos be.diccionario con los datos de cada registro de la tabla idioma_diccionario
    Public Shared Function Listardiccionarios(pidioma As Integer) As List(Of BE.Diccionario)
        Dim mLista As New List(Of BE.Diccionario)
        Dim mCommand As String = "SELECT id_idioma, id_diccionario, valor FROM idioma_diccionario where id_idioma  = @pidioma"
        Dim mDataSet As DataSet
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pidioma", pidioma)
            }


        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mdiccionario As New BE.Diccionario

                    mdiccionario = CargarBE(mdiccionario, mRow)

                    mLista.Add(mdiccionario)
                Next

                Return mLista
            Else
                Return New List(Of BE.Diccionario)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - diccionarioDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
