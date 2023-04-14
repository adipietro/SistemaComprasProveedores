
Public Class frmEmpleado

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

    Public Sub CargarDataGrid()
        Dim Empleado As New BLL.EmpleadoBLL

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = Empleado.Listar
        DataGridView1.Columns(4).Visible = False
    End Sub

    Public Sub CargarCombo()
        Dim Area As New BLL.AreaBLL

        cmbAreas.DataSource = Nothing
        cmbAreas.DataSource = Area.Listar
        cmbAreas.ValueMember = "Nombre"
    End Sub

    Public Sub LimpiarCeldas()
        txtApellido.Text = ""
        txtCargo.Text = ""
        txtNombre.Text = ""
        cmbAreas.Text = ""
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Try
            

        Dim empleadoBE As New BE.Empleado
        Dim empleadoBLL As New BLL.EmpleadoBLL

        If txtNombre.Text = "" Or txtApellido.Text = "" Or txtCargo.Text = "" Then

            MessageBox.Show("No puede dejar celdas vacias", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        Else
            empleadoBE.nombre = txtNombre.Text
            empleadoBE.Apellido = txtApellido.Text
            empleadoBE.Cargo = txtCargo.Text
            empleadoBE.Area = cmbAreas.SelectedItem

            empleadoBLL.Guardar(empleadoBE)
            MessageBox.Show("Se dió de alta un nuevo empleado", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarDataGrid()

            LimpiarCeldas()

        End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDataGrid()
        CargarCombo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim empleado As New BE.Empleado
        Dim empleadoBLL As New BLL.EmpleadoBLL

        Try

        
        empleado.ID = Label3.Text


        If MsgBox("Confirma la eliminación del proveedor seleccionado?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            empleadoBLL.Eliminar(empleado)
            LimpiarCeldas()
            CargarDataGrid()

            MessageBox.Show("Se eliminó registro con Exito", "Confirmación de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmarea.Show()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try

            For Each registro In Me.DataGridView1.Rows
                Dim p As Integer
                p = e.RowIndex
                Dim selectedRow As DataGridViewRow
                selectedRow = DataGridView1.Rows(p)

                Label3.Text = selectedRow.Cells(4).Value.ToString
                txtNombre.Text = selectedRow.Cells(2).Value.ToString
                txtApellido.Text = selectedRow.Cells(3).Value.ToString
                txtCargo.Text = selectedRow.Cells(0).Value.ToString
                cmbAreas.Text = ""

                HabilitarCampos()
                btnAlta.Enabled = False
                btnEliminar.Enabled = True
                btnMod.Enabled = True

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

   
    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim empleado As New BE.Empleado
        Dim empleadoBLL As New BLL.EmpleadoBLL
        Try
            empleado.ID = Label3.Text
            empleado.nombre = txtNombre.Text
            empleado.Apellido = txtApellido.Text
            empleado.Cargo = txtCargo.Text
            empleado.Area = cmbAreas.SelectedItem


            empleadoBLL.Guardar(empleado)
            MessageBox.Show("Modificacion exitosa", "Modificacion de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarDataGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
        LimpiarCeldas()

    End Sub

    Public Sub HabilitarCampos()
        txtApellido.Enabled = True
        txtCargo.Enabled = True
        txtNombre.Enabled = True
        cmbAreas.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        HabilitarCampos()
        btnAlta.Enabled = True
        btnEliminar.Enabled = False
        btnMod.Enabled = False
        LimpiarCeldas()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class