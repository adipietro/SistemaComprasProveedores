Public Class frmAltaFamilia


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BLL.PatenteBLL.altaDeGrupoPatente(txtNombreFamilia.Text)
        Me.Close()
    End Sub
End Class