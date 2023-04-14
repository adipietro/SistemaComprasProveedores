Imports System.Data.SqlClient
Imports BE
Public Class GrupoPatenteDAL

    Public Shared Function proximoID() As Integer
        Return Conexion.ExecuteScalar("Select isnull (max(grupopatente_id), 0) from grupopatente")
    End Function

   

    'Public Shared Function Obtenergrupopatente(pID As Integer) As GrupoPatenteBE
    '    Dim mgrupopatente As New GrupoPatenteBE
    '    Dim mCommand As String = "SELECT grupopatente_id, Nombre, Formulario, Padre FROM grupopatente WHERE grupopatente_id = @pID"
    '    Dim sqlParams() As SqlParameter = New SqlParameter() _
    '        {
    '             New SqlParameter("@pID", pID)
    '        }


    '    Try
    '        Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

    '        If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
    '            mgrupopatente = CargarDTO(mgrupopatente, mDataSet.Tables(0).Rows(0))
    '            Return mgrupopatente
    '        Else
    '            Return Nothing
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error - DataSet - grupopatenteDAL")
    '        MsgBox(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function


    'Public Shared Sub GuardarNuevo(pgrupopatente As GrupoPatenteBE)
    '    Dim mCommand As String = String.Empty
    '    Dim cmdText As String = String.Empty
    '    Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter() _
    '        {
    '         New SqlParameter("@nombre", If(pgrupopatente.nombre Is Nothing, DBNull.Value, pgrupopatente.nombre)),
    '         New SqlParameter("@formulario", If(pgrupopatente.formulario Is Nothing, DBNull.Value, pgrupopatente.formulario))
    '    }

    '    cmdText = "INSERT INTO grupopatente(nombre, formulario, padre) VALUES (@nombre, @formulario, @padre);"

    '    Try
    '        Conexion.ExecuteNonQuery(cmdText, sqlParams)
    '    Catch ex As Exception
    '        MsgBox("Error - Nuevo - PatenteDAL")
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub


    'Public Shared Sub GuardarModificacion(pgrupopatente As GrupoPatenteBE)
    '    Dim mCommand As String = "UPDATE grupopatente SET " &
    '                             ", Nombre = '" & pgrupopatente.nombre &
    '                              "', formulario = '" & pgrupopatente.formulario &
    '                               "' WHERE grupopatente_id = " & pgrupopatente.ID


    '    Try
    '        Conexion.ExecuteNonQuery(mCommand)
    '    Catch ex As Exception
    '        MsgBox("Error - Modificacion - grupopatenteDAL")
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub


    'Public Shared Sub Eliminar(pgrupopatente As GrupoPatenteBE)
    '    Dim mCommand As String = "DELETE FROM GrupoPatente WHERE grupopatente_id = " & pgrupopatente.id

    '    Try
    '        Conexion.ExecuteNonQuery(mCommand)
    '    Catch ex As Exception
    '        MsgBox("Error - Eliminacion - grupopatenteDAL")
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub


    'Public Shared Function Listar(Optional pPadreID As Integer = -1) As List(Of BE.GrupoPatenteBE)
    '    Dim mLista As New List(Of BE.GrupoPatenteBE)
    '    Dim mCommand As String = " "
    '    Dim mDataSet As DataSet

    '    If pPadreID <> -1 Then
    '        mCommand = "SELECT grupopatente_id, nombre, formulario, padre FROM grupopatente WHERE padre = " & pPadreID

    '    Else
    '        mCommand = "SELECT grupopatente_id, nombre, formulario, padre FROM grupopatente"
    '    End If

    '    Try
    '        mDataSet = Conexion.ExecuteDataSet(mCommand)

    '        If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
    '            For Each mRow As DataRow In mDataSet.Tables(0).Rows
    '                Dim Mgrupopatente As New GrupoPatenteBE

    '                Mgrupopatente = CargarDTO(Mgrupopatente, mRow)

    '                mLista.Add(Mgrupopatente)
    '            Next

    '            Return mLista
    '        Else
    '            Return Nothing
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error - Listar - patenteDAL")
    '        MsgBox(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

End Class
