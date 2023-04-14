Imports BLL
Public Class frmAltaUsuarios
    Implements iObservador

    Dim mUsuarioSelec As BLL.UsuarioBLL


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

    Public Sub Cargar()
        Dim uss As New UsuarioBLL

       
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = uss.ListarUsuarios

        DataGridView1.Columns(4).Visible = False
    
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim mUsuario As New UsuarioBLL
        Dim uss As New BE.UsuarioBE


        uss.nombre = txtNombre.Text
        uss.Apellido = txtApellido.Text
        uss.usuario = txtUsuario.Text
       
        If txtContraseña.Text = txtContraseñaRep.Text Then
            uss.contraseña = txtContraseña.Text
            MessageBox.Show("Se dio de alta con éxito un nuevo usuario: " & uss.usuario)
            mUsuario.Guardar(uss)
            Cargar()
            LimpiarCampos()

        Else
            MessageBox.Show("Las contraseñas no coinciden", "Error")
            txtContraseña.Text = ""
            txtContraseñaRep.Text = ""

        End If


    End Sub

    Private Sub frmAltaUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vTraductor.Registrar(Me)
        ActualizarObservador(Me)
        Cargar()

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim uss As New BE.UsuarioBE
        Dim mUsuario As New BLL.UsuarioBLL
        If MsgBox("Esta seguro que desea eliminar el usuario?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            
            uss.ID = TXTid.Text

            MsgBox("El usuario se eliminó con exito", MsgBoxStyle.Information)

            mUsuario.Eliminar(uss)
            Cargar()
            LimpiarCampos()

        End If
    End Sub

    Public Sub LimpiarCampos()
        TXTid.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtUsuario.Text = ""
        txtContraseña.Text = ""
        txtContraseñaRep.Text = ""
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim uss As New BLL.UsuarioBLL
        Dim usuario As New BE.UsuarioBE

        If Not IsNothing(usuario) Then
            usuario.ID = TXTid.Text
            usuario.nombre = txtNombre.Text
            usuario.Apellido = txtApellido.Text
            usuario.usuario = txtUsuario.Text
            usuario.contraseña = txtContraseña.Text
          

            uss.Guardar(usuario)
            Cargar()


            MessageBox.Show("Modificación exitosa")
        End If

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try
            For Each registro In Me.DataGridView1.Rows
                Dim p As Integer
                p = e.RowIndex
                Dim selectedRow As DataGridViewRow
                selectedRow = DataGridView1.Rows(p)

                TXTid.Text = selectedRow.Cells(4).Value.ToString
                txtNombre.Text = selectedRow.Cells(2).Value.ToString
                txtApellido.Text = selectedRow.Cells(3).Value.ToString
                txtUsuario.Text = selectedRow.Cells(0).Value.ToString
                txtContraseña.Text = selectedRow.Cells(1).Value.ToString
                txtContraseñaRep.Text = selectedRow.Cells(1).Value.ToString


            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

  
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
