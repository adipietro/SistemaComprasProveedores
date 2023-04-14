Imports System.Data.SqlClient
Imports BE


Public Class AreaDAL

    Public Shared Function CargarBE(AreaBE As AreaBE, pRow As DataRow) As AreaBE
        AreaBE.ID = pRow("Id_Area")
        AreaBE.Nombre = pRow("NombreArea")

        Return AreaBE
    End Function


    Public Shared Function ObtenerArea(ID As Integer) As BE.AreaBE
        Dim AreaBE As New AreaBE
        Dim mCommand As String = "SELECT * FROM Area WHERE Id_Area = ID"

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                AreaBE = CargarBE(AreaBE, mDataSet.Tables(0).Rows(0))
                Return AreaBE
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - AreaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub GuardarNuevo(areabe As BE.AreaBE)
        Dim mCommand As String = String.Empty


        mCommand = "INSERT INTO Area (NombreArea) VALUES ('" & areabe.Nombre & "'); SELECT @@Identity"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - AreaDAL")
            MsgBox(ex.Message)
        End Try


    End Sub


    Public Shared Sub GuardarModificacion(areaBE As BE.AreaBE)
        Dim mCommand As String = String.Empty

        mCommand = "UPDATE Area SET NombreArea = '" & areaBE.Nombre & "' WHERE Id_Area = " & areaBE.ID &
                   "UPDATE Empleado SET NombreArea = '" & areaBE.Nombre & "' WHERE Id_Area = " & areaBE.ID
        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - AreaDAL")
            MsgBox(ex.Message)
        End Try


    End Sub


    Public Shared Sub Eliminar(AreaBE As BE.AreaBE)
        Dim mCommand As String = "DELETE FROM Area WHERE Id_Area = " & AreaBE.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - AreaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listar(Optional ID As Integer = -1) As List(Of BE.AreaBE)
        Dim mLista As New List(Of BE.AreaBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", ID)
            }

        Try
            If ID <> -1 Then
                mCommand = "SELECT * FROM Area WHERE Id_Area = @pID"
                mDataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)
            Else
                mCommand = "SELECT * FROM Area"
                mDataSet = Conexion.ExecuteDataSet(mCommand)
            End If

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim Area As New AreaBE

                    Area = CargarBE(Area, mRow)

                    mLista.Add(Area)
                Next

                Return mLista
            Else
                Return New List(Of AreaBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - AreaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class



