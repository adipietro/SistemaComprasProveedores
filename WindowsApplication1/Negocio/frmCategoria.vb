Imports BLL

Public Class frmCategoria
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

    Public Sub Cargar()
        Dim cat As New BLL.CategoríaProductoBLL

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = cat.Listar
        DataGridView1.Columns(1).Visible = False

    End Sub

    Public Sub CargarCombo()
        Dim frmprod As New frmProducto
        frmprod.CargarCombo()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        For Each registro In Me.DataGridView1.Rows
            Dim p As Integer
            p = e.RowIndex
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(p)

            txtID.Text = selectedRow.Cells(1).Value.ToString
            txtNombre.Text = selectedRow.Cells(0).Value.ToString
            btnMod.Enabled = True
            btnEliminar.Enabled = True
            btnGuardar.Enabled = False

        Next
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim cat As New BE.CategoríaProductoBE
        Dim categorias As New BLL.CategoríaProductoBLL


        cat.NombreCategoria = txtNombre.Text
        categorias.Guardar(cat)

        Cargar()
        CargarCombo()
        txtNombre.Clear()


    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CargarCombo()
        Me.Close()
    End Sub

    Private Sub frmCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vTraductor.Registrar(Me)
        ActualizarObservador(Me)
        Cargar()


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim cat As New BLL.CategoríaProductoBLL
        Dim c As New BE.CategoríaProductoBE

        Try
            If Not IsNothing(c) Then
                c.ID = txtID.Text
                c.NombreCategoria = txtNombre.Text
                cat.Guardar(c)

                MessageBox.Show("Modificación exitosa")

                Cargar()
                CargarCombo()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cat As New BE.CategoríaProductoBE
        Dim categ As New BLL.CategoríaProductoBLL
        Dim prodBLL As New BLL.ProductoBLL
        Dim Prod As New BE.ProductoBE
        Dim lst As New List(Of BE.ProductoBE)
        Dim lstProductos As New List(Of BE.ProductoBE)
        Dim frmProd As New frmProducto
        lstProductos = prodBLL.Listar


        Dim SB As New System.Text.StringBuilder
        Try
            cat.ID = txtID.Text
            For Each p As BE.ProductoBE In lstProductos
                If p.Categoría.ID = cat.ID Then
                    lst.Add(p)
                    SB.Append(p.Nombre & " - ")
                End If
            Next
            If lst.ToList.Count <> 0 Then
                If MsgBox("ATENCIÓN" & vbNewLine & "Esta categoria posee los siguientes productos asociados: " & vbNewLine & vbNewLine & SB.ToString & vbCrLf & vbNewLine & "Si la elimina tambien se eliminaran los productos que la contengan. Esta seguro de dicha eliminación?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    For Each p As BE.ProductoBE In lstProductos
                        If p.Categoría.ID = cat.ID Then
                            prodBLL.Eliminar(p)
                        End If
                    Next

                    categ.Eliminar(cat)
                    MessageBox.Show("Se elimino registro con exito")
                    txtNombre.Text = ""
                    txtNombre.Enabled = False
                    Cargar()
                    frmProd.CargarCombo()
                    frmProd.cargarDataGrid()

                End If
            Else
                categ.Eliminar(cat)
                MessageBox.Show("Se elimino registro con exito")
                txtNombre.Text = ""
                txtNombre.Enabled = False
                Cargar()
                frmProd.CargarCombo()
                frmProd.cargarDataGrid()
            End If

        Catch ex As Exception
            MsgBox("ERROR AL eliminar")
        End Try



    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        btnGuardar.Enabled = True
        txtNombre.Enabled = True
        btnMod.Enabled = False
        btnEliminar.Enabled = False
        txtNombre.Clear()

    End Sub
End Class