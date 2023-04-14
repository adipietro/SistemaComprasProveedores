Imports BLL

Public Class DeclararFamilias
    Implements iobservador
    Dim vTraductor As Traductor = Traductor.GetInstance
    'Dim mfamiliaSelec As BLL.FamiliaBLL

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


    ''' <summary>
    ''' Carga en pControl.Tag el texto que tiene pControl al momento de instanciar el Form
    ''' </summary>
    ''' <param name="pControl"></param>
    Public Sub CargarTags(pControl As Control)
        pControl.Tag = pControl.Text

        If pControl.Controls.Count > 0 Then
            For Each mControl As Control In pControl.Controls
                CargarTags(mControl)
            Next
        End If
    End Sub


#Region "Observer"

    Public Sub ActualizarObservador(Optional pObservador As Control = Nothing) Implements iobservador.ActualizarObservador
        For Each mControl As Control In pObservador.Controls
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

#End Region


#Region "Eventos Form"
    Private Sub Formfamiliaes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim gruposPatentes = PatenteBLL.listarTodosGruposPatentes()
        lstGruposPatentes.DataSource = gruposPatentes.ToList
        vTraductor.Registrar(Me)
        ActualizarObservador(Me)
    End Sub
#End Region


    'Private Sub BtnNvoRol_Click(sender As Object, e As EventArgs) Handles BtnNvoRol.Click
    '    Dim mfamilia As New BLL.FamiliaBLL


    '    mfamilia.nombreFamilia = InputBox("Ingrese el nombre de la familia:")

    '    mfamilia.Alta()

    '    ActualizarRoles()
    'End Sub



    'Private Sub BtnRenombrar_Click(sender As Object, e As EventArgs)

    '    mfamiliaSelec.nombreFamilia = InputBox("Ingrese el nuevo nombre para la familia:")

    '    mfamiliaSelec.Alta()

    '    ActualizarRoles()
    'End Sub




    'Public Sub ActualizarRoles()
    '    Dim famBLL As New BLL.FamiliaBLL
    '    ListRoles.DataSource = Nothing
    '    ListRoles.DataSource = famBLL.listar
    'End Sub


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


    'Public Sub CargarPermisosSelec(pNodo As TreeNode, pLista As List(Of BLL.PatenteAbsBLL))
    '    If TypeOf (pNodo.Tag) Is BLL.GrupoPatenteBLL Then
    '        If pNodo.Checked = True Then
    '            pLista.Add(pNodo.Tag)
    '        Else
    '            For Each mNodo In pNodo.Nodes
    '                CargarPermisosSelec(mNodo, pLista)
    '            Next
    '        End If
    '    ElseIf TypeOf (pNodo.Tag) Is BLL.PatenteBLL Then
    '        If pNodo.Checked = True Then
    '            pLista.Add(pNodo.Tag)
    '        End If
    '    End If
    ' End Sub

    

    'Private Sub BtnGuardar_Click_1(sender As Object, e As EventArgs) Handles BtnGuardar.Click
    '    Dim mListaPermisos As New List(Of BLL.PatenteAbsBLL)

    '    For Each mNodo As TreeNode In TreePermisos.Nodes
    '        'Llena la lista con los permisos que hay seleccionados en el treeview
    '        CargarPermisosSelec(mNodo, mListaPermisos)
    '    Next

    '    mfamiliaSelec.mlistaPatentes = mListaPermisos

    '    mfamiliaSelec.Alta()

    '    ActualizarRoles()
    'End Sub

    'Private Sub BtnEliminar_Click_1(sender As Object, e As EventArgs) Handles BtnEliminar.Click
    '    If MsgBox("Esta seguro que desea eliminar la familia", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '        mfamiliaSelec.baja()
    '    End If

    '    ActualizarRoles()
    'End Sub

    'Private Sub BtnDeshacer_Click_1(sender As Object, e As EventArgs) Handles BtnDeshacer.Click
    '    ActualizarPermisos()
    'End Sub


    'Private Sub ListRoles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListRoles.SelectedIndexChanged

    'End Sub

    Private Sub BtnNvoRol_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lstGruposPatentes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstGruposPatentes.SelectedIndexChanged
        Dim grupoPatenteSeleccionado = DirectCast(lstGruposPatentes.SelectedItem, BE.GrupoPatenteBE)
        Dim patentesDeGrupoPatente = PatenteBLL.listarPatentesDeGrupoPatente(grupoPatenteSeleccionado)
        Dim todasLasPatentes = PatenteBLL.listarPatentesTotales()
        treePermisos.Nodes.Clear()
        For Each patente In todasLasPatentes
            Dim node = treePermisos.Nodes.Add(patente.nombre)
            node.Tag = patente
            node.Checked = patentesDeGrupoPatente.Contains(patente)
            If patente.GetType() = GetType(BE.GrupoPatenteBE) Then
                'node.BackColor = Color.AliceBlue
                node.ForeColor = Color.Blue
                node.Text = node.Text & " (Familia)"
            End If
        Next
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim grupoPatenteSeleccionado = DirectCast(lstGruposPatentes.SelectedItem, BE.GrupoPatenteBE)

        Dim patentes As New HashSet(Of BE.PatenteAbsBE)
        For Each node In treePermisos.Nodes
            If node.Checked Then
                patentes.Add(node.Tag)
            End If
        Next
        PatenteBLL.modificarPatentesHijas(grupoPatenteSeleccionado, patentes)
    End Sub
End Class

