
Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports System.IO

Public Class frmProveedor

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

    Public Sub CargarComboPais()
        Dim p As New BE.Pais
        Dim pbll As New BLL.PaisBLL

        cmbPais.DataSource = Nothing
        cmbPais.DataSource = pbll.Listar
        cmbPais.ValueMember = "NombrePais"
        cmbPais.SelectedIndex = 0
    End Sub


    Private Sub frmProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDataGrid()
        CargarComboPais()
        vTraductor.Registrar(Me)
        ActualizarObservador(Me)
        cmbCiudad.Text = ""
        cmbPais.Text = ""
        cmbPcia.Text = ""
        txtCP.Text = ""
    End Sub


    Public Sub CargarDataGrid()
        Dim p As New BE.ProveedorBE
        Dim prov As New BLL.ProveedorBLL

        DataGridView1.MultiSelect = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = prov.Listar
        DataGridView1.Columns(9).Visible = False
        ' DataGridView1.Columns(10).Visible = False

    End Sub

    Public Sub PuedeGuardar()
        If txtCUIT.TextLength > 0 And txtDireccion.TextLength > 0 And txtMail.TextLength > 0 And txtNombre.TextLength > 0 And msktxtCel.TextLength > 0 And msktxtTel.TextLength > 0 Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim prov As New BE.ProveedorBE
        Dim p As New BLL.ProveedorBLL

        Try

            If txtCUIT.TextLength.ToString > 0 And txtDireccion.TextLength.ToString And txtMail.TextLength.ToString > 0 And txtNombre.TextLength.ToString > 0 And msktxtCel.TextLength.ToString > 0 And msktxtTel.TextLength.ToString > 0 Then

                prov.Nombre = txtNombre.Text
                prov.CUIT = txtCUIT.Text
                prov.Direccion = txtDireccion.Text
                prov.Ciudad = New BE.Cuidad
                prov.Ciudad.Nombre = cmbCiudad.SelectedItem.ToString
                prov.Ciudad.CP = txtCP.Text
                prov.Provincia = New BE.Provincia
                prov.Provincia.Nombre = cmbPcia.SelectedItem.ToString
                prov.Pais = New BE.Pais
                prov.Pais.NombrePais = cmbPais.SelectedItem.ToString
                prov.Telefono = msktxtTel.Text
                prov.Celular = msktxtCel.Text
                prov.CorreoElectronico = txtMail.Text


                p.Guardar(prov)

                MessageBox.Show("Se dió de alta nuevo Proveedor: " & prov.Nombre)

                CargarDataGrid()

            Else
                btnGuardar.Enabled = False
                MessageBox.Show("Debes completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                HabilitarCampos()

            End If
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

        Dim frm As New frmProdProv
        frm.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnMod.Click
        Dim prov As New BLL.ProveedorBLL
        Dim p As New BE.ProveedorBE

        If Not IsNothing(p) Then
            p.ID = txtID.Text
            p.Nombre = txtNombre.Text
            p.Celular = msktxtCel.Text
            p.Ciudad = New BE.Cuidad
            p.Ciudad.Nombre = cmbCiudad.SelectedItem.ToString
            p.Ciudad.CP = txtCP.Text
            p.CorreoElectronico = txtMail.Text
            p.CUIT = txtCUIT.Text
            p.Direccion = txtDireccion.Text
            p.Pais = New BE.Pais
            p.Pais.NombrePais = cmbPais.SelectedItem.ToString
            p.Provincia = New BE.Provincia
            p.Provincia.Nombre = cmbPcia.SelectedItem.ToString
            p.Telefono = msktxtTel.Text

            prov.Guardar(p)
            CargarDataGrid()

            MessageBox.Show("Modificación exitosa")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try

            Dim evBLL As New BLL.EvaluacionBLL
            Dim prov As New BLL.ProveedorBLL
            Dim p As New BE.ProveedorBE
            Dim prodProv As New BE.ProductoDetalleBE
            Dim ppBLL As New BLL.ProductoDetalleBLL

            If MsgBox("Confirma la eliminación del proveedor seleccionado?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim lstEvaluaciones As New List(Of BE.EvaluaciónProveedorBE)
                lstEvaluaciones = evBLL.ListarTodas()

                p.ID = txtID.Text

                For Each evaluacion As BE.EvaluaciónProveedorBE In lstEvaluaciones
                    If evaluacion.Proveedor.ID = p.ID Then
                        evBLL.EliminarPorProveedor(evaluacion)
                    End If
                Next

                Dim lstProdProv As New List(Of BE.ProductoDetalleBE)
                lstProdProv = ppBLL.Listar

                For Each i As BE.ProductoDetalleBE In lstProdProv
                    If p.ID = i.ID Then
                        ppBLL.Eliminar(i)
                    End If
                Next

                prov.Eliminar(p)

                DeshabilitarCampos()

                MessageBox.Show("Se eliminó correctamente el registro seleccionado")
            End If
            CargarDataGrid()
            Limpiar()
        Catch ex As Exception
            MsgBox("Error en Eliminacion", MsgBoxStyle.AbortRetryIgnore, AcceptButton)
        End Try

    End Sub

    Public Sub Limpiar()
        txtID.Text = ""
        txtNombre.Text = ""
        txtCUIT.Text = ""
        txtDireccion.Text = ""
        txtCP.Text = ""
        msktxtTel.Text = ""
        msktxtCel.Text = ""
        txtMail.Text = ""
        cmbPais.Text = ""
        cmbCiudad.Text = ""
        cmbPcia.Text = ""
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            For Each registro In Me.DataGridView1.Rows
                Dim p As Integer
                p = e.RowIndex
                Dim selectedRow As DataGridViewRow
                selectedRow = DataGridView1.Rows(p)

                txtID.Text = selectedRow.Cells(9).Value.ToString
                txtNombre.Text = selectedRow.Cells(1).Value.ToString
                txtCUIT.Text = selectedRow.Cells(0).Value.ToString
                txtDireccion.Text = selectedRow.Cells(2).Value.ToString
                cmbCiudad.Text = selectedRow.Cells(3).Value.ToString
                txtCP.Text = "-"
                cmbPcia.Text = selectedRow.Cells(4).Value.ToString
                cmbPais.Text = selectedRow.Cells(5).Value.ToString
                msktxtTel.Text = selectedRow.Cells(6).Value.ToString
                msktxtCel.Text = selectedRow.Cells(7).Value.ToString
                txtMail.Text = selectedRow.Cells(8).Value.ToString

                BtnEliminar.Enabled = True
                BtnMod.Enabled = True

                HabilitarCampos()

                btnGuardar.Enabled = True
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        MessageBox.Show("La evaluación de proveedores permitirá comparar entre diferentes caracteristicas puntuadas del proveedor, esto logrará una elección mas correcta de acuerdo a las necesidades de compra", "Evaluación de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim Prov As New BE.ProveedorBE
            Prov.Nombre = txtNombre.Text
            Prov.ID = txtID.Text
            Prov.Pais = New BE.Pais
            Prov.Pais.NombrePais = cmbPais.SelectedItem.ToString
            Prov.Provincia = New BE.Provincia
            Prov.Provincia.Nombre = cmbPcia.SelectedItem.ToString
            Prov.Telefono = msktxtTel.Text
            Prov.Celular = msktxtCel.Text
            Prov.CorreoElectronico = txtMail.Text
            Prov.CUIT = txtCUIT.Text
            Prov.Ciudad = New BE.Cuidad
            Prov.Ciudad = cmbCiudad.SelectedItem
            Prov.Ciudad.CP = txtCP.Text

            Dim mFIleStream As Stream = File.Create("Proveedor.xml")
            Dim Serializador As XmlSerializer = New XmlSerializer(GetType(BE.ProveedorBE))
            Serializador.Serialize(mFIleStream, Prov)
            mFIleStream.Close()
            MsgBox("Se realizó serialización con éxito")
        Catch ex As Exception
            MsgBox("Debe seleccionar un Proveedor para serializar")
        End Try
        
    End Sub

    Public Sub HabilitarCampos()
        txtNombre.Enabled = True
        cmbCiudad.Enabled = True
        txtMail.Enabled = True
        txtCUIT.Enabled = True
        'txtCP.Enabled = True
        txtDireccion.Enabled = True
        cmbPais.Enabled = True
        cmbPcia.Enabled = True
        msktxtCel.Enabled = True
        msktxtTel.Enabled = True
        btnGuardar.Enabled = True
        cmbCiudad.Enabled = True
        cmbPais.Enabled = True
        cmbPcia.Enabled = True
    End Sub
    Public Sub DeshabilitarCampos()
        txtNombre.Enabled = False
        cmbCiudad.Enabled = False
        txtMail.Enabled = False
        txtCUIT.Enabled = False
        txtCP.Enabled = False
        txtDireccion.Enabled = False
        cmbPais.Enabled = False
        cmbPcia.Enabled = False
        msktxtCel.Enabled = False
        msktxtTel.Enabled = False
        btnGuardar.Enabled = False

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        HabilitarCampos()
        Limpiar()
    End Sub

    Private Sub txtCP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress
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

    
    Private Sub msktxtTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles msktxtTel.KeyPress
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

    Private Sub msktxtCel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles msktxtCel.KeyPress
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

    Private Sub txtCUIT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCUIT.KeyPress
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

   

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        cmbPcia.Text = ""
        cmbCiudad.Text = ""
        Dim prov As New BLL.ProvinciaBLL
        Dim pais As New BE.Pais

        pais = cmbPais.SelectedItem
        cmbPcia.DataSource = prov.ListarEspecial(pais.NombrePais)
    End Sub

    Private Sub cmbPcia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPcia.SelectedIndexChanged
        cmbCiudad.Text = ""
        Dim ciudad As New BLL.CIUDADBLL
        Dim provincia As New BE.Provincia

        provincia = cmbPcia.SelectedItem
        cmbCiudad.DataSource = ciudad.Listar(provincia.Nombre)
        cmbCiudad.ValueMember = "Nombre"
    End Sub

    Private Sub cmbCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCiudad.SelectedIndexChanged
        txtCP.Text = ""
        Dim ciudad As New BE.Cuidad
        ciudad = cmbCiudad.SelectedItem
        txtCP.Text = ciudad.CP
    End Sub
End Class
