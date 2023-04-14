Public Class frmABMevaluacion
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


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim evaluacion As New BLL.EvaluacionBLL
        For Each registro In Me.DataGridView1.Rows
            Dim p As Integer
            p = e.RowIndex
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(p)

            'DataGridView2.DataSource = evaluacion.ListarSimple

            cmbProveedor.Text = selectedRow.Cells(0).Value.ToString
            txtTiempos.Text = selectedRow.Cells(1).Value.ToString
            txtAtencion.Text = selectedRow.Cells(2).Value.ToString
            txtCom.Text = selectedRow.Cells(3).Value.ToString
            txtCalidad.Text = selectedRow.Cells(4).Value.ToString
            txtID.Text = selectedRow.Cells(8).Value.ToString

        Next

    End Sub

    Public Sub Cargar()
        Dim evaluacion As New BLL.EvaluacionBLL

        DataGridView2.DataSource = Nothing
        DataGridView2.DataSource = evaluacion.ListarSimple

        'DataGridView2.Columns(1).Visible = False
        'DataGridView2.Columns(2).Visible = False
        'DataGridView2.Columns(3).Visible = False
        'DataGridView2.Columns(4).Visible = False
        'DataGridView2.Columns(7).Visible = False
        'DataGridView2.Columns(8).Visible = False


    End Sub

    Public Sub CargarCombo()
        Dim provBE As New BE.ProveedorBE
        Dim provBLL As New BLL.ProveedorBLL


        cmbProveedor.DataSource = Nothing
        cmbProveedor.DataSource = provBLL.Listar
        '  cmbProveedor.ValueMember = provBE.ID
        cmbProveedor.DisplayMember = "Nombre"


    End Sub

    Private Sub frmABMevaluacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar()
        CargarCombo()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim evaluacion As New BE.EvaluaciónProveedorBE
        Dim evaluacionBLL As New BLL.EvaluacionBLL

        Try
            Dim proveedor As BE.ProveedorBE = cmbProveedor.SelectedItem

            evaluacion.Proveedor = proveedor

            If txtTiempos.Text = "" Or txtAtencion.Text = "" Or txtCalidad.Text = "" Or txtCom.Text = "" Then

                MessageBox.Show("No puede dejar celdas en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                evaluacion.CalificacionTiempos = Convert.ToInt16(txtTiempos.Text)
                'evaluacion.CalificacionTiempos = txtTiempos.Text
                evaluacion.CalificacionComunicacion = Convert.ToInt16(txtCom.Text)
                'evaluacion.CalificacionComunicacion = txtCom.Text
                evaluacion.CalificacionCalidad = Convert.ToInt16(txtCalidad.Text)
                evaluacion.CalificacionAtencion = Convert.ToInt16(txtAtencion.Text)
                evaluacion.Fecha = Date.Now.ToString

                If evaluacion.CalificacionAtencion <= 6 And evaluacion.CalificacionCalidad <= 6 And evaluacion.CalificacionComunicacion <= 6 And evaluacion.CalificacionTiempos <= 6 Then
                    Dim prom As Double = evaluacion.Promedio

                    evaluacionBLL.Guardar(evaluacion)
                    MessageBox.Show("Se dio de alta nueva evaluación")
                    DataGridView1.DataSource = Nothing
                    Cargar()
                    limpiar()

                Else
                    MessageBox.Show("No puede ingresar calificaciones mayores a 5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    limpiar()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error carga de Evalución")
        End Try
    End Sub

    Public Sub limpiar()
        txtCalidad.Text = ""
        txtTiempos.Text = ""
        txtAtencion.Text = ""
        txtCom.Text = ""


    End Sub

#Region "Validacion"
    Private Sub txtTiempos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTiempos.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTiempos_TextChanged(sender As Object, e As EventArgs) Handles txtTiempos.TextChanged

    End Sub

    Private Sub txtAtencion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAtencion.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAtencion_TextChanged(sender As Object, e As EventArgs) Handles txtAtencion.TextChanged

    End Sub

    Private Sub txtCom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCom.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCom_TextChanged(sender As Object, e As EventArgs) Handles txtCom.TextChanged

    End Sub

    Private Sub txtCalidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCalidad.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCalidad_TextChanged(sender As Object, e As EventArgs) Handles txtCalidad.TextChanged

    End Sub
#End Region


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim evBE As New BE.EvaluaciónProveedorBE
            Dim evBLL As New BLL.EvaluacionBLL

            evBE.ID = txtID.Text
           
            evBLL.Eliminar(evBE)

            MessageBox.Show("La evaluación se eliminó correctamente")

            Cargar()

            limpiar()

        Catch ex As Exception
            MsgBox("Error - Eliminación de Producto")
        End Try
    End Sub

    
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim EV As New BE.EvaluaciónProveedorBE
        Dim evBLL As New BLL.EvaluacionBLL
        Try
            For Each registro In Me.DataGridView2.Rows
                Dim p As Integer
                p = e.RowIndex
                Dim selectedRow As DataGridViewRow
                selectedRow = DataGridView2.Rows(p)
                EV.Proveedor = New BE.ProveedorBE
                EV.Proveedor = selectedRow.Cells(0).Value
                DataGridView1.DataSource = evBLL.Listar(EV.Proveedor)


                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(6).Visible = False
                DataGridView1.Columns(8).Visible = False
            Next
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
        
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        limpiar()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class