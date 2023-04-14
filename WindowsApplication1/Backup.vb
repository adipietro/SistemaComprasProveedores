Imports BLL

Public Class Backup
    Dim direccion As String

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BackUpBLL.CrearBackup(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If System.IO.Directory.Exists("C:\ProductosProveedores") Then
            OpenFileDialog1.InitialDirectory = "C:\ProductosProveedores"
        End If

        OpenFileDialog1.ShowDialog()

        direccion = OpenFileDialog1.FileName
        TextBox2.Text = direccion
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        BackUpBLL.RestaurarConexion(direccion)
    End Sub
End Class