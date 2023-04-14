Imports BLL

Public Class Usuarios
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


    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        Dim patente_seleccionada = DirectCast(lstTodasPatentes.SelectedItem, BE.PatenteAbsBE)
        Dim usuario_seleccionado = DirectCast(cmbUsuarios.SelectedItem, BE.UsuarioBE)
        PatenteBLL.agregarPatenteAUsuario(usuario_seleccionado, patente_seleccionada)
        ''lstPatentesUsuario.Items.Add(lstTodasPatentes.Items.Item(lstTodasPatentes.SelectedIndex))

        Dim patentesDelUsuario = PatenteBLL.listarPatentesUsuario(usuario_seleccionado)
        lstPatentesUsuario.DataSource = patentesDelUsuario.ToList

        'Me.Refresh()
        'Dim uss As New BE.UsuarioBE
        'Dim famBll As New BLL.FamiliaBLL
        'Dim ussBLL As New BLL.UsuarioBLL

        'uss = cmbUsuarios.SelectedItem
        ''famBll = cmbFamilias.SelectedItem

        'uss.familia = famBll.id_familia

        'ussBLL.Guardar(uss)
        'MessageBox.Show("La Familia se asignó con éxito")


    End Sub

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ussBLL As New BLL.UsuarioBLL
        If cmbUsuarios.DataSource Is Nothing Then
            cmbUsuarios.DataSource = ussBLL.ListarUsuarios
            cmbUsuarios.DisplayMember = "Usuario"


            vTraductor.Registrar(Me)
            ActualizarObservador(Me)

            lstTodasPatentes.DataSource = PatenteBLL.listarPatentesTotales().ToList
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


  
    'Public Sub ActualizarPermisos()
    '    If Not IsNothing(mfamiliaSelec) Then
    '        TreePermisos.Nodes.Clear()

    '        Dim mPermisoRaiz As New BLL.GrupoPatenteBLL(0)
    '        mPermisoRaiz.MostrarEnTreeview(Me.TreePermisos)

    '        For Each mNodo As TreeNode In TreePermisos.Nodes
    '            For Each mPermiso As BLL.PatenteAbsBLL In mfamiliaSelec.mlistaPatentes
    '                SeleccionarNodos(mNodo, mPermiso)
    '            Next
    '        Next

    '        TreePermisos.ExpandAll()
    '    End If
    'End Sub
    'Public Sub SeleccionarNodos(pNodo As TreeNode, pPermiso As BLL.PatenteAbsBLL)
    '    If TypeOf (pNodo.Tag) Is BLL.GrupoPatenteBLL Then
    '        If CType(pNodo.Tag, BLL.PatenteAbsBLL).nombrePatente = pPermiso.nombrePatente Then
    '            SeleccionNodoRaiz(pNodo)
    '        Else
    '            For Each mNodo As TreeNode In pNodo.Nodes
    '                SeleccionarNodos(mNodo, pPermiso)
    '            Next
    '        End If
    '    ElseIf TypeOf (pNodo.Tag) Is BLL.PatenteBLL Then
    '        If CType(pNodo.Tag, BLL.PatenteAbsBLL).nombrePatente = pPermiso.nombrePatente Then
    '            pNodo.Checked = True
    '        End If
    '    End If
    'End Sub

    'Public Sub SeleccionNodoRaiz(pNodo As TreeNode)
    '    pNodo.Checked = True

    '    For Each mNodo As TreeNode In pNodo.Nodes
    '        SeleccionNodoRaiz(mNodo)
    '    Next
    'End Sub

    Private Sub btnROL_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usuarioSeleccionado As BE.UsuarioBE
        usuarioSeleccionado = cmbUsuarios.SelectedItem
        Dim patenteUsuario = lstPatentesUsuario.SelectedItem
        PatenteBLL.removerPatenteAUsuario(usuarioSeleccionado, patenteUsuario)
        Dim patentesDelUsuario = PatenteBLL.listarPatentesUsuario(usuarioSeleccionado)
        lstPatentesUsuario.DataSource = patentesDelUsuario.ToList
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Dim usuarioSeleccionado As BE.UsuarioBE
        usuarioSeleccionado = cmbUsuarios.SelectedItem
        Dim patentesDelUsuario = PatenteBLL.listarPatentesUsuario(usuarioSeleccionado)
        lstPatentesUsuario.DataSource = patentesDelUsuario.ToList
    End Sub


End Class