Imports bll

Public Class frmLogin
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


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmAltaUsuarios.Show()

    End Sub

    Dim mBitacora As New BE.Bitacora
    Dim contador As Integer

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim ussBLL As New BLL.UsuarioBLL
        Dim usuario_usuario = txtUsuario.Text
        Dim usuario_contraseña = txtContraseña.Text

        If usuario_usuario <> Nothing And usuario_contraseña <> Nothing Then
            Dim usuario = ussBLL.ObtenerUsuarioPorId(usuario_usuario)
            If Not (usuario Is Nothing) Then
                Dim frm As New MDIParent1
                Dim bitBLL As New BLL.BitacoraBLL

                If usuario_usuario = usuario.usuario And usuario_contraseña = usuario.contraseña Then
                    mBitacora.usuario = usuario
                    mBitacora.fecha = System.DateTime.Now.Date
                    mBitacora.accion = "Ingreso al sistema"

                    bitBLL.Guardarnuevo(mBitacora)

                    Me.DialogResult = DialogResult.OK
                    MDIParent1.UsuarioActivo = usuario

                Else
                    contador += 1
                    If contador >= 3 Then
                        MsgBox("Ah ingresado mal sus datos de registro mas de 3 veces. El sistema se cerrará")
                        Me.Close()
                    End If
                    MessageBox.Show("Error en usuario o contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
            Else
                contador += 1
                If contador >= 3 Then
                    MsgBox("Ah ingresado mal sus datos de registro mas de 3 veces. El sistema se cerrará")
                    Me.Close()
                End If
                MessageBox.Show("Error en usuario o contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            txtUsuario.Clear()
            txtContraseña.Clear()
        Else
            MsgBox("Los campos no pueden quedar en blanco")
        End If

    End Sub



    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vTraductor.Registrar(Me)
        txtUsuario.Text = "adipietro"
        txtContraseña.Text = "123"
        ActualizarObservador(Me)
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing And Not Me.DialogResult = DialogResult.OK Then
            Application.Exit()
        End If
    End Sub



End Class