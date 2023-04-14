
Imports System.Data.SqlClient
Imports System.Data.Common

Public Class Conexion
    Private Shared mConnection As SqlConnection

    Public Shared Function ExecuteDataSet(pcommand As String) As DataSet

        Dim data As New DataSet
        Dim mfactory As New SQLfactory

        Dim cn As DbConnection = mfactory.CrearConexion
        Dim com As DbCommand = mfactory.CrearComando(cn, pcommand)
        Dim madapter As New SqlDataAdapter(com)

        Try
            cn.Open()
            madapter.Fill(data)
            Return data
        Catch ex As Exception
            MsgBox("Error DataSet")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            cn.Close()
        End Try

    End Function
    Public Shared Function ExecuteDataSet(pcommand As String, sqlparams() As SqlParameter) As DataSet

        Dim data As New DataSet
        Dim mfactory As New SQLfactory

        Dim cn As DbConnection = mfactory.CrearConexion
        Dim com As DbCommand = mfactory.CrearComando(cn, pcommand, sqlparams)

        Dim madapter As New SqlDataAdapter(com)


        Try
            cn.Open()
            madapter.Fill(data)
            Return data
        Catch ex As Exception
            MsgBox("Error DataSet")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            cn.Close()
            com.Parameters.Clear()
        End Try

    End Function


    Public Shared Function ExecuteNonQuery(pcommand As String, params() As SqlParameter)
        Dim mfactory As New SQLfactory

        Dim cn As DbConnection = mfactory.CrearConexion
        Dim com As DbCommand = mfactory.CrearComando(cn, pcommand, params)

        Try
            cn.Open()
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error NonQuery")
            MsgBox(ex.Message)

        End Try

    End Function

    Public Shared Sub ExecuteNonQuery(pcommand As String)
        Dim mfactory As New SQLfactory

        Dim cn As DbConnection = mfactory.CrearConexion
        Dim com As DbCommand = mfactory.CrearComando(cn, pcommand)

        Try
            cn.Open()
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error NonQuery")
            MsgBox(ex.Message)

        End Try

    End Sub


    Public Shared Function ExecuteReader(pCommandStr As String) As SqlDataReader
        Dim mReader As SqlDataReader
        Dim mfactory As New SQLfactory

        Try
            Dim mConnection As DbConnection = mfactory.CrearConexion
            Dim mCommand As DbCommand = mfactory.CrearComando(mConnection, pCommandStr)

            mConnection.Open()
            mReader = mCommand.ExecuteReader

            Return mReader
        Catch ex As Exception
            MsgBox("Error - Reader - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            mReader.Close()
            mConnection.Close()
            mConnection.Dispose()
        End Try
    End Function
    Public Shared Function ExecuteScalar(pCommandStr As String, params() As SqlParameter) As Integer
        Dim mfactory As New SQLfactory
        Try
            Dim mConnection As DbConnection = mfactory.CrearConexion
            Dim mCommand As DbCommand = mfactory.CrearComando(mConnection, pCommandStr, params)

            mConnection.Open()
            Return mCommand.ExecuteScalar
        Catch ex As Exception
            MsgBox("Error - Scalar - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            'mConnection.Dispose()
            'mConnection.Close()
        End Try
    End Function

    Public Shared Function ExecuteScalar(pCommandStr As String) As Integer
        Dim mfactory As New SQLfactory
        Try
            Dim mConnection As DbConnection = mfactory.CrearConexion
            Dim mCommand As DbCommand = mfactory.CrearComando(mConnection, pCommandStr)

            mConnection.Open()
            Return mCommand.ExecuteScalar
        Catch ex As Exception
            MsgBox("Error - Scalar - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            'mConnection.Dispose()
            'mConnection.Close()
        End Try
    End Function

    Public Shared Function UltimoID(pTabla As String) As Integer
        Dim mID As Integer
        Dim mfactory As New SQLfactory

        Try
            Dim mConnection As DbConnection = mfactory.CrearConexion
            Dim mCommand As New SqlCommand("SELECT ISNULL(MAX(" & pTabla.ToLower & "_id), 0) FROM " & pTabla, mConnection)

            mConnection.Open()
            mID = mCommand.ExecuteScalar

            Return mID
        Catch ex As Exception
            MsgBox("Error - UltimoID - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            mConnection.Close()
            mConnection.Dispose()
        End Try
    End Function
End Class
