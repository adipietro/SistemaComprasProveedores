Imports BLL

Public Class Patentes

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


    'Private Sub IngresarPatenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarPatenteToolStripMenuItem.Click
    '    Dim mSelectedNode As TreeNode = Me.TreeView1.SelectedNode
    '    Try

    '        If TypeOf mSelectedNode.Tag Is BLL.GrupoPatenteBLL Then

    '            Dim mPadre As BLL.GrupoPatenteBLL = mSelectedNode.Tag

    '            Dim mForm As New DialogoPatentes
    '            mForm.ShowDialog()

    '            Dim mNombrePermiso As String = mForm.Nombre
    '            Dim mNombreFormulario As String = mForm.Formulario

    '            If (mNombrePermiso.Length > 0) And (mNombreFormulario.Length > 0) Then

    '                Dim mPermiso As New BLL.PatenteBLL
    '                Dim mNodoNuevo As New TreeNode

    '                mNodoNuevo.Text = mNombrePermiso

    '                mPermiso.nombrePatente = mNombrePermiso
    '                mPermiso.formulario = mNombreFormulario
    '                mPermiso.padre = mPadre.id

    '                mPermiso.Alta()

    '                mNodoNuevo.Tag = mPermiso

    '                mSelectedNode.Nodes.Add(mNodoNuevo)
    '                mPadre.Patentes.Add(mPermiso)
    '            End If
    '        End If

    '    Catch ex As Exception

    '    End Try


    'End Sub

    'Private Sub IngresarGrupoDePatentesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarGrupoDePatentesToolStripMenuItem.Click
    '    Dim mNombrePermiso As String = InputBox("Ingrese el nombre de la patente: ")

    '    If TreeView1.Nodes.Count > 0 Then
    '        Dim mSelectedNode As TreeNode = TreeView1.SelectedNode
    '        Dim mPadre As BLL.GrupoPatenteBLL = mSelectedNode.Tag
    '        AgregarNuevoNodoGrupoPatente(mNombrePermiso, mPadre, mSelectedNode)
    '    Else
    '        AgregarNuevoNodoGrupoPatente(mNombrePermiso)
    '    End If
    'End Sub

    'Private Sub AgregarNuevoNodoGrupoPatente(mNombrePermiso As String)
    '    If mNombrePermiso.Length > 0 Then
    '        Dim mgrupopatente As New BLL.GrupoPatenteBLL
    '        mgrupopatente.nombrePatente = mNombrePermiso
    '        'mgrupopatente.padre = DBNull.Value


    '        Dim mNodoNuevo As New TreeNode
    '        mNodoNuevo.Text = mgrupopatente.nombrePatente
    '        mNodoNuevo.Tag = mgrupopatente

    '        TreeView1.Nodes.Add(mNodoNuevo)
    '        'mSelectedNode.Nodes.Add(mNodoNuevo)
    '        'mPadre.Patentes.Add(mgrupopatente)

    '        mgrupopatente.Alta()
    '        TreeView1.Nodes.Clear()

    '        Patentes_Load(Nothing, Nothing)
    '        TreeView1.ExpandAll()
    '    End If
    'End Sub

    'Private Sub AgregarNuevoNodoGrupoPatente(mNombrePermiso As String, mPadre As BLL.GrupoPatenteBLL, mSelectedNode As TreeNode)
    '    If mNombrePermiso.Length > 0 Then
    '        Dim mgrupopatente As New BLL.GrupoPatenteBLL
    '        mgrupopatente.nombrePatente = mNombrePermiso
    '        mgrupopatente.padre = mPadre.id

    '        Dim mNodoNuevo As New TreeNode
    '        mNodoNuevo.Text = mgrupopatente.nombrePatente
    '        mNodoNuevo.Tag = mgrupopatente

    '        mSelectedNode.Nodes.Add(mNodoNuevo)
    '        mPadre.Patentes.Add(mgrupopatente)

    '        mgrupopatente.Alta()
    '        TreeView1.Nodes.Clear()

    '        Patentes_Load(Nothing, Nothing)
    '        TreeView1.ExpandAll()
    '    End If
    'End Sub

    'Private Sub Patentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim mPermisoRaiz As New GrupoPatenteBLL(0)
    '    mPermisoRaiz.MostrarEnTreeview(TreeView1)
    '    vTraductor.Registrar(Me)
    '    ActualizarObservador(Me)
    'End Sub

    'Private Sub btnMod_Click(sender As Object, e As EventArgs)
    '    If TypeOf (TreeView1.SelectedNode.Tag) Is BLL.PatenteBLL Then
    '        Dim mFormulario As New DialogoPatentes
    '        mFormulario.ShowDialog()
    '    ElseIf TypeOf (TreeView1.SelectedNode.Tag) Is BLL.GrupoPatenteBLL Then
    '        Dim mPermiso As BLL.GrupoPatenteBLL = TreeView1.SelectedNode.Tag
    '
    '        mPermiso.nombrePatente = InputBox("Ingrese el nuevo nombre para el grupo patente:")
    '
    '        mPermiso.Alta()
    '
    '        TreeView1.SelectedNode.Tag = mPermiso
    '        TreeView1.Nodes.Clear()
    '        Patentes_Load(Nothing, Nothing)
    '    End If
    'End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    'Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    '    If TypeOf (TreeView1.SelectedNode.Tag) Is GrupoPatenteBLL Then
    '        If MsgBox("Esta seguro que quiere eliminar este permiso y todos sus componentes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '            CType(TreeView1.SelectedNode.Tag, GrupoPatenteBLL).baja()
    '        End If
    '    ElseIf TypeOf TreeView1.SelectedNode.Tag Is PatenteBLL Then
    '        If MsgBox("Esta seguro que desea eliminar este permiso?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '            CType(TreeView1.SelectedNode.Tag, PatenteBLL).baja()
    '        End If
    '    Else
    '        MsgBox("Debe seleccionar un nodo")
    '    End If

    '    TreeView1.Nodes.Clear()
    '    Patentes_Load(Nothing, Nothing)
    '    'TreeView1.ExpandAll()


    'End Sub
End Class