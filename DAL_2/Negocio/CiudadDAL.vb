Imports System.Data.SqlClient
Imports BE

Public Class CiudadDAL
    Public Shared Function CargarBE(ciudad As BE.Cuidad, pRow As DataRow) As BE.Cuidad
        ciudad.Nombre = pRow("Nombre")
        ciudad.CP = pRow("CP")
        ciudad.Provincia = New Provincia
        ciudad.Provincia.Nombre = pRow("provincia")
        Return ciudad
    End Function


    Public Shared Function Listar(provincia As String) As List(Of BE.Cuidad)
        Dim mLista As New List(Of BE.Cuidad)
        Dim mCommand As String = ""
        Dim mDataSet As DataSet

        Try
            mCommand = "select * from Ciudad where NombreProvincia = '" & Provincia & "'"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim c As New BE.Cuidad

                    c = CargarBE(c, mRow)

                    mLista.Add(c)
                Next

                Return mLista
            Else
                Return New List(Of BE.Cuidad)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ciudadDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
