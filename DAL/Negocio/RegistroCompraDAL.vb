Imports System.Data.SqlClient
Imports BE


Public Class RegistroCompraDAL


    Public Shared Function CargarBE(rc As RegistroCompraBE, pRow As DataRow) As BE.RegistroCompraBE
        rc.ID = pRow("Id_Registro")
        rc.producto = New BE.ProductoBE
        rc.producto.Nombre = pRow("Producto")
        rc.PrecioUnitario = pRow("Precio")
        rc.Cantidad = pRow("Cantidad")
        rc.Descuento = pRow("Descuento")
        rc.PrecioTotal = pRow("Total")
        rc.OrdenCompra = New BE.OrdenCompraBE
        rc.OrdenCompra.ID = pRow("OrdenCompra")
        Return rc
    End Function


    Public Shared Function ObtenerPedido(ID As Integer) As BE.RegistroCompraBE
        Dim dvBE As New BE.RegistroCompraBE
        Dim mCommand As String = "SELECT * FROM RegistroCompra WHERE Id_Registro = @pID"
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", ID)
            }

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                dvBE = CargarBE(dvBE, mDataSet.Tables(0).Rows(0))
                Return dvBE
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - RegistroCompraDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub GuardarNuevo(rc As BE.RegistroCompraBE)
        Dim mCommand As String = ""


        mCommand = "INSERT INTO RegistroCompra (Producto, Precio, Cantidad, Descuento, Total, OrdenCompra) " &
                    "VALUES ('" & rc.producto.Nombre & "','" & rc.PrecioUnitario & "','" & rc.Cantidad & "','" & rc.Descuento & "','" & rc.PrecioTotal & "','" & rc.OrdenCompra.ID & "');SELECT @@Identity"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - RegistroCompraDAL")
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Shared Sub Eliminar(dv As BE.RegistroCompraBE)
        Dim mCommand As String = "DELETE FROM RegistroCompra WHERE Id_Registro = " & dv.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - RegistroComprDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listar(Optional ID As Integer = -1) As List(Of BE.RegistroCompraBE)
        Dim mLista As New List(Of BE.RegistroCompraBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", ID)
            }

        Try
            If ID <> -1 Then
                mCommand = "SELECT * FROM RegistroCompra WHERE Id_Registro= @pID"
                mDataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)
            Else
                mCommand = "SELECT * FROM RegistroCompra"
                mDataSet = Conexion.ExecuteDataSet(mCommand)
            End If

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim dvBE As New RegistroCompraBE

                    dvBE = CargarBE(dvBE, mRow)

                    mLista.Add(dvBE)
                Next

                Return mLista
            Else
                Return New List(Of RegistroCompraBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - RegistroCompraDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Dim rc As New RegistroCompraBE

    Public Shared Function ListarPorOrden(id As Integer) As List(Of BE.RegistroCompraBE)
        Dim mLista As New List(Of BE.RegistroCompraBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet

        Try

            mCommand = "SELECT * FROM RegistroCompra WHERE OrdenCompra= " & id
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim dvBE As New RegistroCompraBE

                    dvBE = CargarBE(dvBE, mRow)

                    mLista.Add(dvBE)
                Next

                Return mLista
            Else
                Return New List(Of RegistroCompraBE)
            End If
        Catch ex As Exception
            MsgBox("Error - ListarPorOrden - RegistroCompraDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class
