Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.Odbc
Imports System.Configuration
Imports System.Linq

Public Class SQLfactory
    Inherits ADOfactory

    Public Overrides Function CrearComando(pconexion As Common.DbConnection, pcommand As String) As Common.DbCommand
        Dim mcom As New SqlCommand
        mcom.Connection = pconexion
        mcom.CommandText = pcommand
        mcom.CommandType = CommandType.Text

        Return mcom

    End Function

    Public Overrides Function CrearComando(pconexion As Common.DbConnection, pcommand As String, params As SqlParameter()) As Common.DbCommand
        Dim mcom As New SqlCommand
        mcom.Connection = pconexion
        mcom.CommandText = pcommand
        mcom.CommandType = CommandType.Text
        mcom.Parameters.AddRange(params)

        Return mcom

    End Function

    Public Overrides Function CrearConexion() As SqlClient.SqlConnection
        Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString)
        Return cn
    End Function
End Class