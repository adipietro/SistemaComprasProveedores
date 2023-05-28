Imports System.Data.SqlClient
Imports BE

Public Class CategoriaProductoDAL


    Public Shared Function CargarBE(CategoriaProductoBE As BE.CategoríaProductoBE, pRow As DataRow) As BE.CategoríaProductoBE
        CategoriaProductoBE.ID = pRow("Id_Categoria")
        CategoriaProductoBE.NombreCategoria = pRow("Nombre")

        Return CategoriaProductoBE
    End Function



    Public Shared Function ObtenerCategoria(cat As BE.CategoríaProductoBE)
        Dim CategoriaProductoBE As New BE.CategoríaProductoBE
        Dim mCommand As String = "SELECT Id_Categoria, Nombre FROM Categoria WHERE Id_Categoria = " & cat.ID
       
        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                CategoriaProductoBE = CargarBE(CategoriaProductoBE, mDataSet.Tables(0).Rows(0))
                Return CategoriaProductoBE
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - CategoriaProductoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub GuardarNuevo(CategoriaProductoBE As BE.CategoríaProductoBE)
        Dim mCommand As String = String.Empty


        mCommand = "INSERT INTO Categoria (Nombre) VALUES ('" & CategoriaProductoBE.NombreCategoria & "'); SELECT @@Identity"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - CategoriaProductoDAL")
            MsgBox(ex.Message)
        End Try


    End Sub
    Public Shared Sub GuardarModificacion(CategoriaProductoBE As BE.CategoríaProductoBE)
        Dim mCommand As String = String.Empty

        mCommand = "UPDATE Categoria SET Nombre = '" & CategoriaProductoBE.NombreCategoria & "' WHERE Id_Categoria = " & CategoriaProductoBE.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - CategoriaProductoDAL")
            MsgBox(ex.Message)
        End Try


    End Sub


    Public Shared Sub Eliminar(CategoriaProductoBE As BE.CategoríaProductoBE)
        Dim mCommand As String = "DELETE FROM Categoria WHERE Id_Categoria = " & CategoriaProductoBE.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - CategoriaProductoDAL")
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Shared Function Listar(Optional ID As Integer = -1) As List(Of BE.CategoríaProductoBE)
        Dim mLista As New List(Of BE.CategoríaProductoBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", ID)
            }

        Try
            If ID <> -1 Then
                mCommand = "SELECT * FROM Categoria WHERE Id_Categoria = @pID"
                mDataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)
            Else
                mCommand = "SELECT * FROM Categoria"
                mDataSet = Conexion.ExecuteDataSet(mCommand)
            End If


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim Categoria As New CategoríaProductoBE

                    Categoria = CargarBE(Categoria, mRow)

                    mLista.Add(Categoria)
                Next

                Return mLista
            Else
                Return New List(Of CategoríaProductoBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - CategoriaProductoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class




