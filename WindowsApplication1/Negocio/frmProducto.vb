Public Class frmProducto

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


    Public Sub CargarCombo()
        Dim categoria As New BLL.CategoríaProductoBLL

        ComboBox1.DataSource = Nothing
        ComboBox1.DataSource = categoria.Listar
        ComboBox1.DisplayMember = "NombreCategoria"

    End Sub

    Public Sub cargarDataGrid()
        Dim pr As New BLL.ProductoBLL

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = pr.Listar
        DataGridView1.Columns(2).Visible = False
        'DataGridView1.Columns(3).Visible = False
    End Sub

    Private Sub frmProducto_load(sender As Object, e As EventArgs) Handles MyBase.Load
        vTraductor.Registrar(Me)
        ActualizarObservador(Me)

        CargarCombo()
        cargarDataGrid()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmCategoria.Show()
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim prod As New BE.ProductoBE
            Dim producto As New BLL.ProductoBLL
            Dim p As New BE.ProveedorBE
            Dim ppbll As New BLL.ProductoDetalleBLL

            prod.ID = txtID.Text
            prod.Nombre = txtNombre.Text

            If MsgBox("Confirma la eliminación del siguiente producto: " & vbNewLine & vbNewLine & prod.Nombre & "", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim lstProdProv As New List(Of BE.ProductoDetalleBE)
                lstProdProv = ppbll.ListarSimple

                For Each i As BE.ProductoDetalleBE In lstProdProv
                    If prod.ID = i.Producto.ID Then
                        ppbll.Eliminar(i)
                    End If
                Next

                producto.Eliminar(prod)

                ComboBox1.Text = Nothing
                txtNombre.Text = ""

                cargarDataGrid()
                MessageBox.Show("El producto se eliminó correctamente")

            End If

        Catch ex As Exception
            MsgBox("Error - Eliminación de Producto")
        End Try

    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim p As New BE.ProductoBE
        Dim prod As New BLL.ProductoBLL
        Try

            If Not IsNothing(p) Then

                p.Nombre = txtNombre.Text
                p.ID = txtID.Text
                prod.Guardar(p)

                MessageBox.Show("Se realizó modificacion con exito")
                cargarDataGrid()

            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try

            For Each registro In Me.DataGridView1.Rows
                Dim p As Integer
                p = e.RowIndex
                Dim selectedRow As DataGridViewRow
                selectedRow = DataGridView1.Rows(p)


                ComboBox1.Text = selectedRow.Cells(0).Value.ToString
                txtID.Text = selectedRow.Cells(2).Value.ToString
                txtNombre.Text = selectedRow.Cells(1).Value.ToString
                btnEliminar.Enabled = True
                btnMod.Enabled = True
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnModRelacion_Click(sender As Object, e As EventArgs)
        frmProdProv.Show()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim prod As New BE.ProductoBE
        Dim producto As New BLL.ProductoBLL
        Try
            Dim cat As BE.CategoríaProductoBE = ComboBox1.SelectedItem
            prod.Categoría = New BE.CategoríaProductoBE
            prod.Categoría.ID = cat.ID
            prod.Categoría.NombreCategoria = cat.NombreCategoria

            prod.Nombre = txtNombre.Text


            producto.Guardar(prod)

            MessageBox.Show("Se dio de alta un nuevo Producto")

            cargarDataGrid()

            ComboBox1.Text = Nothing
            txtNombre.Text = ""

        Catch ex As Exception
            MsgBox("Error - Guardar Producto")
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtNombre.Clear()
        btnEliminar.Enabled = False
        btnMod.Enabled = False
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        CargarCombo()
        cargarDataGrid()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class