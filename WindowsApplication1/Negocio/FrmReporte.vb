Public Class FrmReporte

    Private Sub FrmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DataSet1.OrdenCompra' Puede moverla o quitarla según sea necesario.
        Me.OrdenCompraTableAdapter.Fill(Me.DataSet1.OrdenCompra)
        'TODO: esta línea de código carga datos en la tabla 'DataSet1.RegistroCompras' Puede moverla o quitarla según sea necesario.
        Me.RegistroCompraTableAdapter.Fill(Me.DataSet1.RegistroCompra)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub OrdenCompraBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles OrdenCompraBindingSource.CurrentChanged

    End Sub
End Class