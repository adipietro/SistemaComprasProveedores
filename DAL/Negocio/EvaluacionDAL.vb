Imports System.Data.SqlClient
Imports BE


Public Class EvaluacionDAL

    Public Shared Function CargarBE(EvaluacionBE As EvaluaciónProveedorBE, pRow As DataRow) As EvaluaciónProveedorBE
        
        EvaluacionBE.Proveedor = New ProveedorBE
        EvaluacionBE.Proveedor.ID = pRow("Proveedor")
        EvaluacionBE.Proveedor.Nombre = pRow("NombreProveedor")
        EvaluacionBE.Cantidad = pRow("Cantidad")

        Return EvaluacionBE
    End Function

    Public Shared Function CargarBE2(EvaluacionBE As EvaluaciónProveedorBE, pRow As DataRow) As EvaluaciónProveedorBE

        EvaluacionBE.ID = pRow("Id_Evaluacion")

        EvaluacionBE.Proveedor = New ProveedorBE
        EvaluacionBE.Proveedor.ID = pRow("Proveedor")
        EvaluacionBE.Proveedor.Nombre = pRow("NombreProveedor")

        EvaluacionBE.CalificacionTiempos = pRow("Tiempo")
        EvaluacionBE.CalificacionComunicacion = pRow("Comunicacion")
        EvaluacionBE.CalificacionCalidad = pRow("Calidad")
        EvaluacionBE.CalificacionAtencion = pRow("Atencion")
        EvaluacionBE.Fecha = pRow("Fecha")
        Return EvaluacionBE
    End Function


    Public Shared Function ObtenerEvaluacion(ID As Integer) As EvaluaciónProveedorBE
        Dim EvaluacionBE As New EvaluaciónProveedorBE
        Dim mCommand As String = "SELECT * FROM Evaluacion WHERE Id_Evaluacion = @pID"
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", ID)
            }

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                EvaluacionBE = CargarBE(EvaluacionBE, mDataSet.Tables(0).Rows(0))
                Return EvaluacionBE
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - EvaluacionDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub GuardarNuevo(evaluacionBE As BE.EvaluaciónProveedorBE)
        Dim mCommand As String = ""


        mCommand = "INSERT INTO Evaluacion (Proveedor, NombreProveedor, Tiempo, Comunicacion, Calidad, Atencion, Fecha) " &
                    "VALUES (" & evaluacionBE.Proveedor.ID & ",'" & evaluacionBE.Proveedor.Nombre & "', " & evaluacionBE.CalificacionTiempos & " , " & evaluacionBE.CalificacionComunicacion & ", " & evaluacionBE.CalificacionCalidad & ", " & evaluacionBE.CalificacionAtencion & " , '" & evaluacionBE.Fecha & "'); SELECT @@Identity"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - EvaluacionDAL")
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Shared Sub Eliminar(EvaluacionBE As BE.EvaluaciónProveedorBE)
        Dim mCommand As String = "DELETE FROM Evaluacion WHERE Id_evaluacion = " & EvaluacionBE.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - EvaluacionDAL")
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub EliminarPorProveedor(EvaluacionBE As BE.EvaluaciónProveedorBE)
        Dim mCommand As String = "DELETE FROM Evaluacion WHERE Proveedor = " & EvaluacionBE.Proveedor.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - EliminacionPorProveedor - EvaluacionDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function ListarSimple() As List(Of BE.EvaluaciónProveedorBE)
        Dim mLista As New List(Of BE.EvaluaciónProveedorBE)
        Dim mCommand As String = ""
        Dim mDataSet As DataSet

        Try
            mCommand = "select evaluacion.Proveedor, evaluacion.nombreProveedor, count(Proveedor)as Cantidad, SUM(Promedio)/count(Proveedor) AS Promedio from evaluacion group by evaluacion.Proveedor,evaluacion.nombreProveedor"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim evaluacion As New EvaluaciónProveedorBE

                    evaluacion = CargarBE(evaluacion, mRow)

                    mLista.Add(evaluacion)
                Next

                Return mLista
            Else
                Return New List(Of EvaluaciónProveedorBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - EvalucionDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function ListarTodas() As List(Of BE.EvaluaciónProveedorBE)
        Dim mLista As New List(Of BE.EvaluaciónProveedorBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet

        Try
            mCommand = "select * from evaluacion"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim evaluacion As New EvaluaciónProveedorBE

                    evaluacion = CargarBE2(evaluacion, mRow)

                    mLista.Add(evaluacion)
                Next

                Return mLista
            Else
                Return New List(Of EvaluaciónProveedorBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - EvalucionDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Listar(proveedor As BE.ProveedorBE) As List(Of BE.EvaluaciónProveedorBE)
        Dim mLista As New List(Of BE.EvaluaciónProveedorBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet

        Try
            mCommand = "select * from Evaluacion where NombreProveedor = '" & proveedor.Nombre & "'"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim evaluacion As New EvaluaciónProveedorBE

                    evaluacion = CargarBE2(evaluacion, mRow)

                    mLista.Add(evaluacion)
                Next

                Return mLista
            Else
                Return New List(Of EvaluaciónProveedorBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - EvalucionDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class
