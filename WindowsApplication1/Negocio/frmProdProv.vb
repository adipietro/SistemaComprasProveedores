Public Class frmProdProv

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

    Public Sub CargarCombos()
        Dim pProv As New BLL.ProveedorBLL
        Dim pProd As New BLL.ProductoBLL

        cmbProd.DataSource = Nothing
        cmbProd.DataSource = pProd.Listar
        cmbProd.DisplayMember = "Nombre"

        cmbProveedor.DataSource = Nothing
        cmbProveedor.DataSource = pProv.Listar
        cmbProveedor.DisplayMember = "Nombre"
    End Sub


    Public Sub CargarDataGrid()
        Dim pProvProd As New BLL.ProductoDetalleBLL

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = pProvProd.ListarSimple
        DataGridView1.Columns(5).Visible = False
        ' DataGridView1.Columns(2).Visible = False
        ' DataGridView1.Columns(7).Visible = False
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub



    Private Sub frmProdProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDataGrid()
        CargarCombos()

        vTraductor.Registrar(Me)
        ActualizarObservador(Me)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim prodporp As New BE.ProductoDetalleBE()
        Dim p As New BLL.ProductoDetalleBLL
        Try

            If Not IsNothing(txtCantidad.Text) Or Not IsNothing(txtDescuento.Text) Or Not IsNothing(txtPrecio.Text) Then

                Dim producto As BE.ProductoBE = cmbProd.SelectedItem
                prodporp.Producto = New BE.ProductoBE
                prodporp.Producto.ID = producto.ID
                prodporp.Producto.Nombre = producto.Nombre

                Dim proveedor As BE.ProveedorBE = cmbProveedor.SelectedItem
                prodporp.Proveedor = New BE.ProveedorBE
                prodporp.Proveedor.ID = proveedor.ID
                prodporp.Proveedor.Nombre = proveedor.Nombre

                prodporp.Precio = txtPrecio.Text
                prodporp.DescuentoCantidad = txtDescuento.Text
                prodporp.CantidadDescuento = txtCantidad.Text

                p.GuardarNuevo(prodporp)
                MessageBox.Show("Se creo asociación Producto-Proveedor")

                CargarDataGrid()
                LimpiarCampos()

            Else
                MessageBox.Show("Todas las celdas deben contener información")
            End If

        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try

            For Each registro In Me.DataGridView1.Rows
                Dim p As Integer
                p = e.RowIndex
                Dim selectedRow As DataGridViewRow
                selectedRow = DataGridView1.Rows(p)
                cmbProd.DataSource = Nothing
                cmbProveedor.DataSource = Nothing

                txtID.Text = selectedRow.Cells(5).Value.ToString


                cmbProd.Text = selectedRow.Cells(0).Value.ToString
                cmbProveedor.Text = selectedRow.Cells(1).Value.ToString
                txtPrecio.Text = selectedRow.Cells(2).Value.ToString
                txtDescuento.Text = selectedRow.Cells(3).Value.ToString
                txtCantidad.Text = selectedRow.Cells(4).Value.ToString

                cmbProd.Enabled = False
                cmbProveedor.Enabled = False


            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LimpiarCampos()
        txtCantidad.Clear()
        txtDescuento.Clear()
        txtPrecio.Clear()
        cmbProd.Text = Nothing
        cmbProveedor.Text = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim p As New BLL.ProductoDetalleBLL

            Dim prodDetalle As New BE.ProductoDetalleBE
            prodDetalle.ID = txtID.Text
            prodDetalle.Producto = cmbProd.SelectedItem
            prodDetalle.Proveedor = cmbProveedor.SelectedItem
            prodDetalle.Precio = txtPrecio.Text
            prodDetalle.DescuentoCantidad = txtDescuento.Text
            prodDetalle.CantidadDescuento = txtCantidad.Text


            p.Eliminar(prodDetalle)
            MessageBox.Show("Se eliminó la relación entre Producto y Proveedor")
            CargarDataGrid()
            LimpiarCampos()

        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
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

    Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
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


    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Try
            Dim p As New BLL.ProductoDetalleBLL

            Dim prodDetalle As New BE.ProductoDetalleBE
            prodDetalle.ID = txtID.Text
            prodDetalle.Producto = cmbProd.SelectedItem
            prodDetalle.Proveedor = cmbProveedor.SelectedItem
            prodDetalle.Precio = txtPrecio.Text
            prodDetalle.DescuentoCantidad = txtDescuento.Text
            prodDetalle.CantidadDescuento = txtCantidad.Text


            p.GuardarMod(prodDetalle)
            MessageBox.Show("Se modificó exitosamente el registro")
            CargarDataGrid()

        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Private Sub btnNvo_Click(sender As Object, e As EventArgs) Handles btnNvo.Click
        CargarCombos()

        cmbProd.Enabled = True
        cmbProveedor.Enabled = True
        txtCantidad.Clear()
        txtDescuento.Clear()
        txtPrecio.Clear()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class