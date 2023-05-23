Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.Odbc


Public MustInherit Class ADOfactory

    Public MustOverride Function CrearConexion() As SqlConnection

    Public MustOverride Function CrearComando(pconexion As DbConnection, pcommand As String) As DbCommand
    Public MustOverride Function CrearComando(pconexion As Common.DbConnection, pcommand As String, params As SqlParameter()) As Common.DbCommand

End Class