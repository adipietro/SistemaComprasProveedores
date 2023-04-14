Public Class frmarea

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


    Public Sub cargarDataGrid()
        Dim area As New BLL.AreaBLL

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = area.Listar

        DataGridView1.Columns(1).Visible = False

    End Sub

    Private Sub frmArea_load(sender As Object, e As EventArgs) Handles MyBase.Load
        vTraductor.Registrar(Me)
        ActualizarObservador(Me)

        cargarDataGrid()
    End Sub


    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim a As New BE.AreaBE
        Dim aBLL As New BLL.AreaBLL
        Dim empleado As New BE.Empleado

        Try
            If Not IsNothing(a) Then
                a.Nombre = txtNombre.Text
                a.ID = txtID.Text

                aBLL.Guardar(a)

                MessageBox.Show("Se realizó modificacion con exito")
                cargarDataGrid()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try

            For Each registro In Me.DataGridView1.Rows
                Dim p As Integer
                p = e.RowIndex
                Dim selectedRow As DataGridViewRow
                selectedRow = DataGridView1.Rows(p)

                txtID.Text = selectedRow.Cells(1).Value.ToString
                txtNombre.Text = selectedRow.Cells(0).Value.ToString

                txtNombre.Enabled = True
                btnAlta.Enabled = False
                btnBaja.Enabled = True
                btnMod.Enabled = True


            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim area As New BE.AreaBE
        Dim areaBLL As New BLL.AreaBLL


        If txtNombre.Text = "" Then

            MessageBox.Show("Debes completar el nombre del Area a dar de alta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            area.Nombre = txtNombre.Text
            
            areaBLL.Guardar(area)

            MessageBox.Show("Se dio de alta nueva Area", "Alta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

            cargarDataGrid()

            txtNombre.Text = ""
          
        End If

    End Sub

    Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        Try
            Dim a As New BE.AreaBE
            Dim aBLL As New BLL.AreaBLL

            a.ID = txtID.Text
            a.Nombre = txtNombre.Text

            MessageBox.Show("El Area que esta intentando eliminar puede tener personal asignado." & vbNewLine & "Le sugerimos ingresar al modulo 'Empleados' para realizar la modificación correspondiente, caso contrario se eliminará el personal asociado a dicha Área.", "Información importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            If MsgBox("Confirma la eliminación del Siguiente Area : " & vbNewLine & vbNewLine & a.Nombre & "", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim empBLL As New BLL.EmpleadoBLL
                Dim lstEmpleados As New List(Of BE.Empleado)
                lstEmpleados = empBLL.Listar
                For Each i As BE.Empleado In lstEmpleados
                    If i.Area.Nombre = a.Nombre Then
                        empBLL.Eliminar(i)
                    End If
                Next

                aBLL.Eliminar(a)

                txtID.Text = ""
                txtNombre.Text = ""

                cargarDataGrid()
                MessageBox.Show("Registro eliminado correctamente", "Eliminacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If

        Catch ex As Exception
            MsgBox("Error al intentar eliminar Area")
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        txtID.Text = ""
        txtNombre.Text = ""
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        frmOrganigrama.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtNombre.Enabled = True
        btnAlta.Enabled = True
        btnBaja.Enabled = False
        btnMod.Enabled = False
        txtNombre.Text = ""
    End Sub
End Class