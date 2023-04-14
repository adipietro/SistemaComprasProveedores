
Imports Microsoft.Reporting.WinForms
Public Class frmRealizarPedido
    Implements iObservador

    Dim vTraductor As Traductor = Traductor.GetInstance

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each mControl As Control In Me.Controls
            Try
                CargarTags(mControl)
            Catch ex As Exception

            End Try
        Next
    End Sub

    Public Sub CargarTags(pControl As Control)
        pControl.Tag = pControl.Text

        If pControl.Controls.Count > 0 Then
            For Each mControl As Control In pControl.Controls
                CargarTags(mControl)
            Next
        End If
    End Sub

    Public Sub ActualizarObservador(Optional pControl As Control = Nothing) Implements iObservador.ActualizarObservador
        For Each mControl As Control In pControl.Controls
            Try
                mControl.Text = vTraductor.IdiomaSeleccionado.Diccionario.Item(mControl.Tag)
            Catch ex As Exception

            Finally
                If mControl.Controls.Count > 0 Then
                    ActualizarObservador(mControl)
                End If
            End Try
        Next
    End Sub


    Private Sub frmOC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim frm As New frmRealizarPedido
        frm.StartPosition = FormStartPosition.CenterParent

        vTraductor.Registrar(Me)
        ActualizarObservador(Me)
        CargarCombos()
        cmbArea.Text = ""

        ' frmReporte2.Refresh()

    End Sub

    Public Sub CargarDataGrid()
        Dim pbll As New BLL.ProductoDetalleBLL
        Dim prod As New BE.ProductoBE
        Dim evBE As New BE.EvaluaciónProveedorBE

        Dim prodprov As BE.ProductoDetalleBE = cmbProd2.SelectedItem
        prod = prodprov.Producto
        DataGridView1.DataSource = pbll.listarSugerencia(prod.Nombre)

        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(5).Visible = False


    End Sub


    Public Sub cargarProductos()

        Dim pbll As New BLL.ProductoDetalleBLL
        Dim prov As New BE.ProveedorBE

        Dim prodprov As BE.ProductoDetalleBE = cmbProv.SelectedItem
        prov.Nombre = prodprov.Proveedor.Nombre
        DataGridView2.DataSource = pbll.listarporProducto(prodprov.Proveedor.Nombre)
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(5).Visible = False
        
    End Sub


    Public Sub cargarPedido()
        Dim ocBLL As New BLL.OrdenCompraBLL
        Dim pbll As New BLL.ProductoDetalleBLL
        Dim prov As New BE.ProveedorBE

        Dim prodprov As BE.ProductoDetalleBE = cmbProv.SelectedItem
        prov.ID = prodprov.ID
        DataGridView3.DataSource = ocBLL.Listar

    End Sub

    Public Sub CargarCombos()
        Dim pProv As New BLL.ProveedorBLL
        Dim pProd As New BLL.ProductoBLL
        Dim pArea As New BLL.AreaBLL
        Dim pp As New BLL.ProductoDetalleBLL

        Dim ppbe As New BE.ProductoDetalleBE

        cmbProd2.DataSource = Nothing
        cmbProd2.DataSource = pp.ListarProductos
        cmbProd2.DisplayMember = "Producto"

        cmbProv.DataSource = Nothing
        cmbProv.DataSource = pp.ListarProveedores
        cmbProv.DisplayMember = "Proveedor"

        cmbArea.DataSource = Nothing
        cmbArea.DataSource = pArea.Listar
        cmbArea.DisplayMember = "Nombre"
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        frmProdProv.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim P As BE.ProveedorBE = cmbProv.SelectedItem
        Dim PROD As New BE.ProductoBE
        Dim Area As BE.AreaBE = cmbArea.SelectedItem
        Dim ocBE As New BE.OrdenCompraBE
        Dim oc As New BLL.OrdenCompraBLL


        cmbProv.SelectedText = P.Nombre


        cmbArea.SelectedText = Area.Nombre
        ocBE.Area.ID = Area.ID

        oc.Guardar(ocBE)

        MessageBox.Show("Se creó nueva orden de compra con fecha: " & DateTimePicker1.Text)

    End Sub

    Private Sub btnSugerir_Click(sender As Object, e As EventArgs) Handles btnSugerir.Click
        CargarDataGrid()

        Dim oc As New BE.OrdenCompraBE
        Dim evaluacion As New BE.EvaluaciónProveedorBE
        Dim prod As BE.ProductoDetalleBE = cmbProd2.SelectedItem

        txtSugerencia.Text = "Usted ha seleccionado el siguiente producto: " & prod.Producto.Nombre & ControlChars.CrLf & _
            " " & ControlChars.CrLf & _
           "A continuación podrá visualizar los proveedores que ofrecen este producto, el precio de venta y sus correspondientes descuentos"

    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        For Each registro In Me.DataGridView2.Rows
            Dim p As Integer
            p = e.RowIndex
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView2.Rows(p)
            LimpiarTexbox()

            txtProd.Text = selectedRow.Cells(1).Value.ToString
            txtDescuento.Text = selectedRow.Cells(3).Value.ToString
            txtCantidadDesc.Text = selectedRow.Cells(4).Value.ToString
            txtPrecio.Text = selectedRow.Cells(2).Value.ToString

            btnAgregarDetalle.Enabled = True
            btnBorrar.Enabled = True
        Next
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        Dim rc As New BE.RegistroCompraBE
        Dim dvBLL As New BLL.RegistroCompraBLL
        Dim provProd As New BE.ProductoDetalleBE
        Dim oc As New BE.OrdenCompraBE

        Try
            rc.producto = New BE.ProductoBE
            rc.producto.Nombre = txtProd.Text
            rc.Cantidad = txtCantidad.Text

            provProd.CantidadDescuento = txtCantidadDesc.Text
            provProd.DescuentoCantidad = txtDescuento.Text
            provProd.Precio = txtPrecio.Text

            Dim totalDescuento As Double
            totalDescuento = dvBLL.CalcularDescuento(provProd.DescuentoCantidad, provProd.Precio, rc.Cantidad, provProd.CantidadDescuento)
            txtTotalDesc.Text = totalDescuento

            Dim subTotal As Double
            subTotal = dvBLL.CalcularSubTotal(rc.Cantidad, provProd.Precio)
            txtSubTotal.Text = subTotal

            Dim total As Double
            total = dvBLL.CalcularTotal(provProd.Precio, provProd.DescuentoCantidad, rc.Cantidad, provProd.CantidadDescuento)
            txtTotal.Text = total

            btnAgregarDetalle.Enabled = True
            btnBorrar.Enabled = True
        Catch ex As Exception
            MsgBox("Recuerde que todos los campos deben estar completos")
        End Try

    End Sub

    Public Sub LimpiarTexbox()
        txtCantidad.Text = ""
        txtCantidadDesc.Text = ""
        txtDescuento.Text = ""
        txtPrecio.Text = ""
        txtProd.Text = ""
        txtSubTotal.Text = ""
        txtTotal.Text = ""
        txtTotalDesc.Text = ""

    End Sub

    Dim lstRegistros As New List(Of BE.RegistroCompraBE)

    Private Sub btnAgregarDetalle_Click(sender As Object, e As EventArgs) Handles btnAgregarDetalle.Click
        Try
            If txtCantidad.Text <> Nothing Then
                DataGridView3.Rows.Add(txtProd.Text, txtCantidad.Text, txtPrecio.Text, txtTotalDesc.Text, txtSubTotal.Text)
                LimpiarTexbox()
            Else
                MsgBox("Debe completar el campo 'Cantidad'")
            End If
        Catch ex As Exception
            MsgBox("Error en la carga del detalle")
        End Try
    End Sub

    Private Function Sumar(clmTotal As String, Dgv As DataGridView) As Double
        Dim total As Double = 0

        Try
            For i As Integer = 0 To Dgv.RowCount - 1
                total = total + CDbl(Dgv.Item(clmTotal.ToLower, i).Value)
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        Return total

    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)





    End Sub

    Public Sub limpiarOC()

    End Sub


    Private Sub btnTotalDetalle_Click(sender As Object, e As EventArgs) Handles btnTotalDetalle.Click
        txtTotalPedido.Text = Format(Sumar("clmTotal", DataGridView3), "c").ToString
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try

            If DataGridView3.Rows.Count > 0 Then
                Dim dv As New BE.RegistroCompraBE
                Dim dvBLL As New BLL.RegistroCompraBLL

                DataGridView3.Rows.Remove(DataGridView3.CurrentRow)
            Else
                MsgBox("La tabla no posee filas para borrar")

            End If

        Catch ex As Exception
            MsgBox("Seleccione la fila a eliminar")
        End Try

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()

    End Sub

 

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim frm As New FrmReporte
        frm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frmOC As New frmListaOC
        frmOC.Show()

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub cmbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArea.SelectedIndexChanged
        Dim Area As New BE.AreaBE
        Dim EmpleadoBLL As New BLL.EmpleadoBLL

        Area = cmbArea.SelectedItem
        cmbEmpleados.DataSource = Nothing
        cmbEmpleados.DataSource = EmpleadoBLL.ListarEspecial(Area.Nombre)
    End Sub



    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        frmProveedor.Show()
    End Sub

  

    Private Sub btnCargarProveedor_Click_1(sender As Object, e As EventArgs) Handles btnCargarProveedor.Click, btnCargarProveedor.Click
        cargarProductos()
       
        btnCalcular.Enabled = True
    End Sub

  
    Private Sub btnGuardarOC_Click(sender As Object, e As EventArgs) Handles btnGuardarOC.Click
        Try
            Dim oc As New BE.OrdenCompraBE
            Dim ocBLL As New BLL.OrdenCompraBLL

            oc.Fecha = DateTimePicker1.Text
            oc.Proveedor = New BE.ProveedorBE
            oc.Proveedor.Nombre = cmbProv.Text
            oc.Area = New BE.AreaBE
            oc.Area.Nombre = cmbArea.Text

            oc.Importe = txtTotalPedido.Text

            ocBLL.Guardar(oc)


            Dim UltimaOC As New BE.OrdenCompraBE
            UltimaOC = ocBLL.ObtenerUltimaOC()
            Label2.Text = UltimaOC.ID

            For Each row As DataGridViewRow In DataGridView3.Rows
                If (row.IsNewRow) Then Continue For

                Dim rcBLL As New BLL.RegistroCompraBLL
                Dim rcBE As New BE.RegistroCompraBE

                rcBE.producto = New BE.ProductoBE
                rcBE.producto.Nombre = Convert.ToString(row.Cells(0).Value)
                rcBE.Cantidad = Convert.ToString(row.Cells(1).Value)
                rcBE.PrecioUnitario = Convert.ToString(row.Cells(2).Value)
                rcBE.PrecioTotal = Convert.ToString(row.Cells(4).Value)
                rcBE.Descuento = Convert.ToString(row.Cells(3).Value)
                rcBE.OrdenCompra = New BE.OrdenCompraBE
                rcBE.OrdenCompra.ID = Label2.Text
                rcBLL.Guardar(rcBE)
            Next

            MessageBox.Show("Se dió de alta Orden de compra: " & Label2.Text & " por un total de: $" & oc.Importe)
            btnImprimir.Enabled = True
        Catch ex As Exception
            MsgBox("Error - No se completo toda la información requerida")
        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class