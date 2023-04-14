Public Class frmListaOC

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub frmListaOC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDataGrid()

    End Sub

    Public Sub CargarDataGrid()
        Dim OC As New BLL.OrdenCompraBLL

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = OC.Listar

        DataGridView1.Columns(4).Visible = False
        'DataGridView1.Columns(5).Visible = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim RC As New BE.RegistroCompraBE
        Dim rcBLL As New BLL.RegistroCompraBLL

        For Each registro In Me.DataGridView1.Rows
            Dim p As Integer
            p = e.RowIndex
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(p)
            RC.OrdenCompra = New BE.OrdenCompraBE
            RC.OrdenCompra.ID = selectedRow.Cells(5).Value.ToString
            Label2.Text = RC.OrdenCompra.ID
            DataGridView2.DataSource = rcBLL.ListarRegistros(RC.OrdenCompra.ID)
            DataGridView2.Columns(6).Visible = False

        Next

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

End Class