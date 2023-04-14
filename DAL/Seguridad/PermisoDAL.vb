Imports System.Data.SqlClient
Imports BE
Public Class PermisoDAL


    Public Shared Function Cargarbe(Ppatente As PermisoBE, pRow As DataRow) As PermisoBE
        Ppatente.id = pRow("patente_id")
        Ppatente.nombre = pRow("Nombre")
        If TypeOf (pRow("formulario")) Is DBNull Then
            Ppatente.formulario = ""
        Else
            Ppatente.formulario = pRow("Formulario")
        End If

        If TypeOf (pRow("padre")) Is DBNull Then
            Ppatente.padre = 0
        Else
            Ppatente.padre = pRow("padre")
        End If
        Return Ppatente
    End Function

    Public Shared Function proximoID() As Integer
        Return Conexion.ExecuteScalar("Select isnull (max(patente_id), 0) from patente")
    End Function


    Public Shared Function Obtenerpatente(pID As Integer) As PermisoBE
        Dim Mpatente As New PermisoBE
        Dim mCommand As String = "SELECT patente_id, Nombre, formulario, padre FROM patente WHERE patente_id = " & pID

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                Mpatente = Cargarbe(Mpatente, mDataSet.Tables(0).Rows(0))
                Return Mpatente
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - patenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub GuardarNuevo(Ppatente As BE.PermisoBE)
        Dim mCommand As String = ""


        mCommand = "INSERT INTO patente(nombre, formulario, padre) " &
                    "VALUES ('" & Ppatente.nombre & "' , '" & Ppatente.formulario & "' , " & Ppatente.padre & ");"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - PatenteDAL")
            MsgBox(ex.Message)
        End Try


    End Sub
    Public Shared Sub GuardarModificacion(Ppatente As BE.PermisoBE)
        Dim mCommand As String = ""

        mCommand = "UPDATE Patente SET " &
                                                    "patente_id = " & Ppatente.id &
                                 ", Nombre = '" & Ppatente.nombre &
                                 "', Formulario = '" & Ppatente.formulario &
                                 "', padre= " & Ppatente.padre &
                                  " WHERE patente_id = " & Ppatente.id

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - PatenteDAL")
            MsgBox(ex.Message)
        End Try


    End Sub


    Public Shared Sub Eliminar(Ppatente As BE.PermisoAbsBE)
        Dim mCommand As String = ""

        If TypeOf (Ppatente) Is PermisoBE Then
            RolPermisoDAL.EliminarPorPermiso(Ppatente.id)
            mCommand = "DELETE FROM Patente WHERE patente_id = " & Ppatente.id
        ElseIf TypeOf (Ppatente) Is GrupoPermisosBE Then
            For Each mPermiso As PermisoAbsBE In CType(Ppatente, GrupoPermisosBE).listapatentes
                Eliminar(mPermiso)
            Next
            RolGrupoPermisosDAL.EliminarPorPatente(Ppatente.id)
            mCommand = "DELETE FROM GrupoPatente WHERE GrupoPatente_id = " & Ppatente.id
        End If

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - PatenteDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listar(Optional pPadreID As Integer = -1) As List(Of BE.PermisoBE)
        Dim mLista As New List(Of BE.PermisoBE)
        Dim mCommand As String = " "
        Dim mDataSet As DataSet
        ' Dim sqlParams() As SqlParameter = New SqlParameter() _
        '     {
        '          New SqlParameter("@pID", pPadreID)
        '     }
        '
        Try

            If pPadreID <> -1 Then
                mCommand = "SELECT Patente_id, nombre, formulario, padre FROM Patente WHERE padre = " & pPadreID
                'mDataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)
                mDataSet = Conexion.ExecuteDataSet(mCommand)

            Else
                mCommand = "SELECT Patente_id, nombre, formulario, padre FROM patente"
                mDataSet = Conexion.ExecuteDataSet(mCommand)
            End If

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim Mpatente As New PermisoBE

                    Mpatente = Cargarbe(Mpatente, mRow)

                    mLista.Add(Mpatente)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - patenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class
