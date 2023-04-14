Imports DAL
Public Class BackUpBLL



    Public Shared Sub CrearBackup(pNombre As String)
        If (Not System.IO.Directory.Exists("C:\ProductosProveedores")) Then
            System.IO.Directory.CreateDirectory("C:\ProductosProveedores")
        End If

        Dim mCommand As String = "backup database [ProductosProveedores] to disk = 'C:\ProductosProveedores\BackupProductosProveedores.bak' with noFormat, noInit, name = 'Backup_ProductosProveedores', skip, noRewind, noUnload, stats = 10;"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Crear Backup")
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub RestaurarConexion(pDireccion As String)
        Dim mDataSources As DataTable = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources

        Dim mConnection As String = "Data Source=" & mDataSources.Rows(0).Item(0) & "\" & mDataSources.Rows(0).Item(1) & ";Initial Catalog=ProductosProveedores;Integrated Security=true"
        Dim mCommand As String = "restore database [ProductosProveedores] from disk = '" & pDireccion & "';"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Restaurar Conexion")
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
