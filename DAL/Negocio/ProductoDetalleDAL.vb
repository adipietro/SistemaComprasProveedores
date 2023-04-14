Imports System.Data.SqlClient
Imports BE


Public Class ProductoDetalleDAL


    Public Shared Function CargarBE(ProdprovBE As ProductoDetalleBE, pRow As DataRow) As ProductoDetalleBE
        'ProdprovBE.ID = pRow("Id_Registro")
        ProdprovBE.Producto = New ProductoBE
        ProdprovBE.Producto.ID = pRow("Id_Producto")
        ProdprovBE.Producto.Nombre = pRow("Producto")
        ProdprovBE.Proveedor = New ProveedorBE
        ProdprovBE.Proveedor.ID = pRow("Id_Proveedor")
        ProdprovBE.Proveedor.Nombre = pRow("Proveedor")
        ProdprovBE.Precio = pRow("Precio")
        ProdprovBE.DescuentoCantidad = pRow("DescuentoCantidad")
        ProdprovBE.CantidadDescuento = pRow("CantidadDescuento")
        Return ProdprovBE
    End Function


    Public Shared Function CargarBE2(ProdprovBE As ProductoDetalleBE, pRow As DataRow) As ProductoDetalleBE
        'ProdprovBE.ID = pRow("Id_Registro")
        ProdprovBE.Producto = New ProductoBE
        ProdprovBE.Producto.ID = pRow("Id_Producto")
        ProdprovBE.Producto.Nombre = pRow("Producto")
        ProdprovBE.Proveedor = New ProveedorBE
        ProdprovBE.Proveedor.ID = pRow("Id_Proveedor")
        ProdprovBE.Proveedor.Nombre = pRow("NombreProveedor")
        ProdprovBE.Precio = pRow("Precio")
        ProdprovBE.DescuentoCantidad = pRow("DescuentoCantidad")
        ProdprovBE.CantidadDescuento = pRow("CantidadDescuento")
        Return ProdprovBE
    End Function

    Public Shared Function CargarBESimple(ProdprovBE As ProductoDetalleBE, pRow As DataRow) As ProductoDetalleBE
        ProdprovBE.ID = pRow("Id_Registro")
        ProdprovBE.Producto = New ProductoBE
        ProdprovBE.Producto.ID = pRow("Id_Producto")
        ProdprovBE.Producto.Nombre = pRow("Producto")
        ProdprovBE.Proveedor = New ProveedorBE
        ProdprovBE.Proveedor.ID = pRow("Id_Proveedor")
        ProdprovBE.Proveedor.Nombre = pRow("Proveedor")
        ProdprovBE.Precio = pRow("Precio")
        ProdprovBE.DescuentoCantidad = pRow("DescuentoCantidad")
        ProdprovBE.CantidadDescuento = pRow("CantidadDescuento")


        Return ProdprovBE

    End Function

    Public Shared Function CargarProdProv(ProdprovBE As ProductoDetalleBE, pRow As DataRow) As ProductoDetalleBE
        ProdprovBE.ID = pRow("Id_Registro")
        ProdprovBE.Proveedor = New ProveedorBE
        ProdprovBE.Proveedor.ID = pRow("Id_Proveedor")
        ProdprovBE.Proveedor.Nombre = pRow("Proveedor")
        ProdprovBE.Precio = pRow("Precio")
        ProdprovBE.DescuentoCantidad = pRow("DescuentoCantidad")
        ProdprovBE.CantidadDescuento = pRow("CantidadDescuento")


        Return ProdprovBE

    End Function

    Public Shared Function CargarProductos(ProdprovBE As ProductoDetalleBE, pRow As DataRow) As ProductoDetalleBE

        ProdprovBE.Producto = New ProductoBE
        ProdprovBE.Producto.ID = pRow("Id_Producto")
        ProdprovBE.Producto.Nombre = pRow("Producto")
        Return ProdprovBE

    End Function

    Public Shared Function CargarProveedores(ProdprovBE As ProductoDetalleBE, pRow As DataRow) As ProductoDetalleBE
        ProdprovBE.Proveedor = New ProveedorBE
        ProdprovBE.Proveedor.ID = pRow("Id_Proveedor")
        ProdprovBE.Proveedor.Nombre = pRow("Proveedor")
        Return ProdprovBE

    End Function

    Public Shared Function ObtenerProductoProveedor(ID As Integer) As ProductoDetalleBE
        Dim ProductoProveedorBE As New ProductoDetalleBE
        Dim mCommand As String = "select Proveedor.Proveedor, Producto.Producto, Precio, DescuentoCantidad, CantidadDescuento from proveedor_producto inner join producto on proveedor_producto.Id_Producto=producto.Id_Producto inner join proveedor on proveedor_producto.Id_Proveedor=proveedor.Id_Proveedor WHERE proveedor_producto.Id_Producto  = producto.Id_Producto and proveedor_producto.Id_Proveedor = proveedor.Id_Proveedor"
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", ID)
            }

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                ProductoProveedorBE = CargarBE(ProductoProveedorBE, mDataSet.Tables(0).Rows(0))
                Return ProductoProveedorBE
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - ProductoProveedorDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub GuardarNuevo(ProductoProveedorBE As BE.ProductoDetalleBE)
        Dim prod As New ProductoBE
        Dim prov As New ProveedorBE
        Dim mCommand As String = "INSERT INTO Proveedor_Producto (Id_Producto, Producto, Id_Proveedor, Proveedor, Precio, DescuentoCantidad, CantidadDescuento ) " &
                "VALUES (" & ProductoProveedorBE.Producto.ID & ",'" & ProductoProveedorBE.Producto.Nombre & "'," & ProductoProveedorBE.Proveedor.ID & ",'" & ProductoProveedorBE.Proveedor.Nombre & "','" & ProductoProveedorBE.Precio & "','" & ProductoProveedorBE.DescuentoCantidad & "','" & ProductoProveedorBE.CantidadDescuento & "');SELECT @@Identity"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - ProductoProveedorDAL")
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Shared Sub GuardarModificacion(ProductoProveedorBE As BE.ProductoDetalleBE)
        ' Dim prod As New ProductoBE
        Dim mCommand As String = ""

        mCommand = "UPDATE Proveedor_Producto SET " &
                                "Precio = '" & ProductoProveedorBE.Precio &
                                "', DescuentoCantidad = '" & ProductoProveedorBE.DescuentoCantidad &
                                "', CantidadDescuento = '" & ProductoProveedorBE.CantidadDescuento &
                                  "' WHERE Id_Registro = " & ProductoProveedorBE.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - ProductoProveedorDAL")
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Shared Sub Eliminar(p As ProductoDetalleBE)

        Dim mCommand As String = "DELETE FROM Proveedor_Producto WHERE id_Registro= " & p.ID
        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - ProductoProveedorDAL")
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Function ListarSimple() As List(Of BE.ProductoDetalleBE)

        Dim mCommand As String = "select * from Proveedor_Producto"
        Dim mLista As New List(Of BE.ProductoDetalleBE)
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim MProducto As New ProductoDetalleBE
                    MProducto = CargarBESimple(MProducto, mRow)

                    mLista.Add(MProducto)
                Next

                Return mLista
                Return Nothing
            Else
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ProductoProveedorDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Shared Function Listar() As List(Of BE.ProductoDetalleBE)

        Dim mCommand As String = "select Proveedor.Id_Proveedor, Proveedor.NombreProveedor, Producto.Id_Producto, Producto.Producto, Proveedor_Producto.Precio, Proveedor_Producto.CantidadDescuento, Proveedor_Producto.DescuentoCantidad  from proveedor_producto  inner join producto on proveedor_producto.Id_Producto=producto.Id_Producto inner join proveedor on proveedor_producto.Id_Proveedor=proveedor.Id_Proveedor WHERE proveedor_producto.Id_Producto  = producto.Id_Producto and proveedor_producto.Id_Proveedor = proveedor.id_proveedor"
        Dim mLista As New List(Of BE.ProductoDetalleBE)
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim MProducto As New ProductoDetalleBE
                    MProducto = CargarBE2(MProducto, mRow)

                    mLista.Add(MProducto)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ProductoProveedorDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function listarProductos() As List(Of BE.ProductoDetalleBE)
        Dim prodprov As New BE.ProductoDetalleBE
        Dim Command As String = "SELECT DISTINCT Id_Producto, Producto FROM Proveedor_Producto"

        Dim mLista As New List(Of BE.ProductoDetalleBE)
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(Command)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim MProducto As New ProductoDetalleBE

                    MProducto = CargarProductos(MProducto, mRow)

                    mLista.Add(MProducto)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ProductoProductoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function listarProveedores() As List(Of BE.ProductoDetalleBE)
        Dim prodprov As New BE.ProductoDetalleBE
        Dim Command As String = "SELECT DISTINCT Id_Proveedor, Proveedor FROM Proveedor_Producto"

        Dim mLista As New List(Of BE.ProductoDetalleBE)
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(Command)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim MProv As New ProductoDetalleBE

                    MProv = CargarProveedores(MProv, mRow)

                    mLista.Add(MProv)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ProductoProveedorDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Shared Function ListarSugerencia(producto As String) As List(Of BE.ProductoDetalleBE)

        Dim mCommand As String = "select * from proveedor_producto where proveedor_producto.Producto = '" & producto & "'"
        Dim mLista As New List(Of BE.ProductoDetalleBE)
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim MProducto As New ProductoDetalleBE

                    MProducto = CargarBE(MProducto, mRow)

                    mLista.Add(MProducto)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ProductoProveedorDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function ListarporProductos(proveedor As String) As List(Of BE.ProductoDetalleBE)

        Dim mCommand As String = "select *  from proveedor_producto where proveedor_producto.Proveedor = '" & proveedor & "'"
        Dim mLista As New List(Of BE.ProductoDetalleBE)
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim MProv As New ProductoDetalleBE

                    MProv = CargarBE(MProv, mRow)

                    mLista.Add(MProv)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ProductoProveedorDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class



