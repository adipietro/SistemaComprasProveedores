Imports System.Data.SqlClient
Imports BE

Public Class PaisDAL
    Public Shared Function CargarBE(pais As BE.Pais, pRow As DataRow) As Pais

        pais.NombrePais = pRow("Nombre")
        Return pais
    End Function


    Public Shared Function Listar() As List(Of BE.Pais)
        Dim mLista As New List(Of BE.Pais)
        Dim mCommand As String = ""
        Dim mDataSet As DataSet

        Try
            mCommand = "select * from Pais"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim pais As New Pais

                    pais = CargarBE(pais, mRow)

                    mLista.Add(pais)
                Next

                Return mLista
            Else
                Return New List(Of Pais)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - PaisDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class
