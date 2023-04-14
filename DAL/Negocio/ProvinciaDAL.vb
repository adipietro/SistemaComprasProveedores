Imports System.Data.SqlClient
Imports BE

Public Class ProvinciaDAL
    Public Shared Function CargarBE(pcia As BE.Provincia, pRow As DataRow) As Provincia
        pcia.Nombre = pRow("Nombre")
        Return pcia
    End Function


    Public Shared Function ListarEspecial(PAIS As String) As List(Of BE.Provincia)
        Dim mLista As New List(Of BE.Provincia)
        Dim mCommand As String = ""
        Dim mDataSet As DataSet

        Try
            mCommand = "select Nombre from Provincia where NombrePais = '" & PAIS & "'"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim prov As New Provincia

                    prov = CargarBE(prov, mRow)

                    mLista.Add(prov)
                Next

                Return mLista
            Else
                Return New List(Of BE.Provincia)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - PciaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


End Class
