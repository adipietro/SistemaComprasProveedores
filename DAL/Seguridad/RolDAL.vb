Imports System.Data.SqlClient
Imports BE
Public Class RolDAL



    Public Shared Function proximoID() As Integer
        Return Conexion.ExecuteScalar("Select isnull (max(familia_id), 0) from familia") + 1
    End Function

    Private Shared Function CargarDTO(pfamilia As RolBE, pRow As DataRow) As RolBE
        pfamilia.familia_id = pRow("Familia_id")
        pfamilia.nombre = pRow("NombreFamilia")
        pfamilia.listapatentes = ObtenerPermisos(pfamilia.familia_id)

        Return pfamilia
    End Function


    Public Shared Function Obtenerfamilia(pID As Integer) As RolBE
        Dim mfamilia As New RolBE
        Dim mCommand As String = "SELECT familia_id, NombreFamilia FROM familia WHERE Familia_id =  @pID"
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", pID)
            }

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mfamilia = CargarDTO(mfamilia, mDataSet.Tables(0).Rows(0))
                Return mfamilia
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - FamiliaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pfamilia As RolBE)
        Dim mCommand As String = "INSERT INTO Familia(Familia_id, nombrefamilia) VALUES (" & pfamilia.familia_id & ", '" & pfamilia.nombre & "');"

        Try
            Conexion.ExecuteNonQuery(mCommand)

            CrearRelaciones(pfamilia)
        Catch ex As Exception
            MsgBox("Error - Nuevo - familia")
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Shared Sub CrearRelaciones(pRol As BE.RolBE)
        Dim mID As Integer = ObtenerID(pRol)

        If pRol.listapatentes.Count > 0 Then
            For Each mPermiso As BE.PermisoAbsBE In pRol.listapatentes
                If TypeOf (mPermiso) Is BE.PermisoBE Then
                    RolPermisoDAL.GuardarNuevo(mID, mPermiso.id)
                Else
                    RolGrupoPermisosDAL.GuardarNuevo(mID, mPermiso.id)
                End If
            Next
        End If
    End Sub


    Private Shared Function ObtenerID(pRol As BE.RolBE) As Integer
        Dim mCommand As String = "select familia_id from familia where nombrefamilia like '" & pRol.nombre & "'"
        Return (Conexion.ExecuteScalar(mCommand))
    End Function


    Public Shared Sub GuardarModificacion(pfamilia As RolBE)
        Dim mCommand As String = "UPDATE Familia SET " & _
                                 "Familia_id = " & pfamilia.familia_id & _
                                 ", NombreFamilia = '" & pfamilia.nombre & _
                                  "' WHERE Familia_id = " & pfamilia.familia_id

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - FamiliaDAL")
            MsgBox(ex.Message)
        End Try


    End Sub


    Public Shared Sub Eliminar(pfamilia As RolBE)
        Dim mCommand As String = "DELETE FROM Familia WHERE Familia_id = " & pfamilia.familia_id

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - FamiliaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function listarfamilia() As List(Of RolBE)
        Dim mLista As New List(Of RolBE)
        Dim mCommand As String = "SELECT Familia_id, NombreFamilia FROM Familia"
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mfamilia As New RolBE

                    mfamilia = CargarDTO(mfamilia, mRow)

                    mLista.Add(mfamilia)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - FamiliaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function ObtenerPermisos(pID As Integer) As List(Of BE.PermisoAbsBE)

        Dim mLista As New List(Of BE.PermisoAbsBE)
        Dim mCommand As String = "select Patente.patente_id, nombre, formulario, padre " &
                                 "from patente " &
                                 "inner join familiaPatente on familiaPatente.Patente_id = patente.patente_id " &
                                 "where familiaPatente.familia_id = @pID"

        Dim mCommandComp As String = "select grupoPatente.grupoPatente_id, nombre, formulario, padre " &
                                     "from grupoPatente " &
                                     "inner join familiaGrupoPatente on familiaGrupoPatente.grupoPatente_id = grupoPatente.grupoPatente_id " &
                                     "where familiaGrupoPatente.familia_id = @pID"

        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", pID)
            }

        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mBE As New BE.PermisoBE

                    mLista.Add(PermisoDAL.Cargarbe(mBE, mRow))
                Next
            End If


            mDataSet = Conexion.ExecuteDataSet(mCommandComp, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mBE As New BE.GrupoPermisosBE

                    mLista.Add(GrupoPermisosDAL.CargarDTO(mBE, mRow))
                Next
            End If

            Return mLista
        Catch ex As Exception
            MsgBox("Error - ObtenerPermisos - RolDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class

