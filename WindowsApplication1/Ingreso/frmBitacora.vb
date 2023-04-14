Public Class frmBitacora

    Private Sub bitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DataGridView1
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DataSource = BLL.BitacoraBLL.Listarbitacora
            .Columns(3).Visible = False
        End With

    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub

   
    Private Sub frmBitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class