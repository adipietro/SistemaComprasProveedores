Imports System.Data.SqlClient
Imports BE


Public Class ProveedorDAL


    Public Shared Function CargarBE(ProveedorBE As ProveedorBE, pRow As DataRow) As ProveedorBE
        ProveedorBE.ID = pRow("Id_Proveedor")
        ProveedorBE.Nombre = pRow("NombreProveedor")
        ProveedorBE.CUIT = pRow("CUIT")
        ProveedorBE.Direccion = pRow("Direccion")
        ProveedorBE.Ciudad = New Cuidad
        ProveedorBE.Ciudad.Nombre = pRow("Ciudad")
        ProveedorBE.Ciudad.CP = pRow("CodigoPostal")
        ProveedorBE.Provincia = New Provincia
        ProveedorBE.Provincia.Nombre = pRow("Provincia")
        ProveedorBE.Pais = New Pais
        ProveedorBE.Pais.NombrePais = pRow("Pais")
        ProveedorBE.Telefono = pRow("Telefono")
        ProveedorBE.Celular = pRow("Celular")
        ProveedorBE.CorreoElectronico = pRow("CorreoElectronico")

        Return ProveedorBE
    End Function

    


    Public Shared Function proximoID() As Integer
        Return Conexion.ExecuteScalar("Select isnull (max(Id_Proveedor), 0) from Proveedor")
    End Function


    Public Shared Function ObtenerProveedor(ID As Integer) As ProveedorBE
        Dim ProveedorBE As New ProveedorBE
        Dim mCommand As String = "SELECT Id_Proveedor, NombreProveedor, CUIT, Direccion, Ciudad, CodigoPostal, Provincia, Pais, Telefono, Celular, CorreoElectronico FROM Proveedor WHERE Id_Proveedor = @pID"
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", ID)
            }

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                ProveedorBE = CargarBE(ProveedorBE, mDataSet.Tables(0).Rows(0))
                Return ProveedorBE
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - ProductoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub GuardarNuevo(ProveedorBE As BE.ProveedorBE)
        Dim mCommand As String = ""


        mCommand = "INSERT INTO Proveedor (NombreProveedor, CUIT, Direccion, Ciudad, CodigoPostal, Provincia, Pais, Telefono, Celular, CorreoElectronico) " &
                    "VALUES ('" & ProveedorBE.Nombre & "' , '" & ProveedorBE.CUIT & "' , '" & ProveedorBE.Direccion & "','" & ProveedorBE.Ciudad.Nombre & "','" & ProveedorBE.Ciudad.CP & "','" & ProveedorBE.Provincia.Nombre & "','" & ProveedorBE.Pais.NombrePais & "','" & ProveedorBE.Telefono & "','" & ProveedorBE.Celular & "','" & ProveedorBE.CorreoElectronico & "');SELECT @@Identity"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - ProveedorDAL")
            MsgBox(ex.Message)
        End Try


    End Sub
    Public Shared Sub GuardarModificacion(ProveedorBE As BE.ProveedorBE)
        Dim mCommand As String = "UPDATE Proveedor SET " &
                                "NombreProveedor= '" & ProveedorBE.Nombre &
                                 "', CUIT= '" & ProveedorBE.CUIT &
                                 "', Direccion = '" & ProveedorBE.Direccion &
                                 "', Ciudad= '" & ProveedorBE.Ciudad.Nombre &
                                 "', CodigoPostal= '" & ProveedorBE.Ciudad.CP &
                                 "', Provincia= '" & ProveedorBE.Provincia.Nombre &
                                 "', Pais= '" & ProveedorBE.Pais.NombrePais &
                                 "', Telefono= '" & ProveedorBE.Telefono &
                                 "', Celular= '" & ProveedorBE.Celular &
                                 "', CorreoElectronico= '" & ProveedorBE.CorreoElectronico &
                                          "' WHERE Id_Proveedor = " & ProveedorBE.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - ProveedorDAL")
            MsgBox(ex.Message)
        End Try


    End Sub



    Public Shared Sub Eliminar(ProveedorBE As BE.ProveedorBE)
        Dim mCommand As String = "DELETE FROM Proveedor WHERE Id_Proveedor = " & ProveedorBE.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - ProveedorDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listar(Optional ID As Integer = -1) As List(Of BE.ProveedorBE)
        Dim mLista As New List(Of BE.ProveedorBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", ID)
            }

        Try
            If ID <> -1 Then
                mCommand = "SELECT * FROM Proveedor WHERE Id_Proveedor = @pID"
                mDataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)
            Else
                mCommand = "SELECT * FROM Proveedor"
                mDataSet = Conexion.ExecuteDataSet(mCommand)
            End If

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim MProv As New ProveedorBE

                    MProv = CargarBE(MProv, mRow)

                    mLista.Add(MProv)
                Next

                Return mLista
            Else
                Return New List(Of ProveedorBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ProveedorDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function listarPorProveedor(idProd As Integer) As List(Of BE.ProveedorBE)
        Dim Command As String = "select Proveedor.NombreProveedor, Proveedor_Producto.Precio, Proveedor_Producto.CantidadDescuento, Proveedor_Producto.DescuentoCantidad from proveedor_producto  inner join producto on proveedor_producto.Id_Producto=producto.Id_Producto inner join proveedor on proveedor_producto.Id_Proveedor = proveedor.Id_Proveedor WHERE proveedor_producto.Id_Producto = " & idProd
        Dim mLista As New List(Of BE.ProveedorBE)
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(Command)

            For Each mRow As DataRow In mDataSet.Tables(0).Rows
                Dim mproveedor As New ProveedorBE
                CargarBE(mproveedor, mRow)
                mLista.Add(mproveedor)
            Next

            Return mLista

        Catch ex As Exception
            MsgBox("Error - Listar - ProductoProveedorDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function





End Class


