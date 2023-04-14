Imports BLL
Imports BE


Public Class Familia

    'Implements iObservador

    'Dim vTraductor As Traductor = Traductor.GetInstance

    'Public Sub New()

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    For Each mControl As Control In Me.Controls
    '        Try
    '            CargarTags(mControl)
    '        Catch ex As Exception

    '        End Try
    '    Next
    'End Sub

    'Public Sub CargarTags(pControl As Control)
    '    pControl.Tag = pControl.Text

    '    If pControl.Controls.Count > 0 Then
    '        For Each mControl As Control In pControl.Controls
    '            CargarTags(mControl)
    '        Next
    '    End If
    'End Sub

    'Public Sub ActualizarObservador(Optional pControl As Control = Nothing) Implements iObservador.ActualizarObservador
    '    For Each mControl As Control In pControl.Controls
    '        Try
    '            mControl.Text = vTraductor.IdiomaSeleccionado.Diccionario.Item(mControl.Tag)
    '        Catch ex As Exception

    '        Finally
    '            If mControl.Controls.Count > 0 Then
    '                ActualizarObservador(mControl)
    '            End If
    '        End Try
    '    Next
    'End Sub


    'Public Sub GetPermisosSeleccionados(pNodos As TreeNodeCollection, pListaPermisos As List(Of BLL.PatenteAbsBLL))
    '    For Each mNode As TreeNode In pNodos
    '        If mNode.Checked Then
    '            pListaPermisos.Add(CType(mNode.Tag, BLL.PatenteAbsBLL))
    '        End If

    '        GetPermisosSeleccionados(mNode.Nodes, pListaPermisos)
    '    Next
    'End Sub

    'Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
    '    Dim familiaBLL As New BLL.FamiliaBLL

    '    Dim mListaPermisos As New List(Of BLL.PatenteAbsBLL)

    '    familiaBLL.nombreFamilia = txtNombreFamilia.Text

    '    If TreeView1.Nodes.Count > 0 AndAlso Not IsNothing(TreeView1.SelectedNode) Then
    '        familiaBLL.mlistaPatentes.Add(TreeView1.SelectedNode.Tag)
    '        familiaBLL.Alta()
    '        Me.Close()
    '    Else
    '        MessageBox.Show("Debe seleccionar una Familia")
    '    End If

    'End Sub

    'Private Sub Familia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim mPermisoRaiz As New BLL.GrupoPatenteBLL(0)
    '    mPermisoRaiz.MostrarEnTreeview(Me.TreeView1)

    '    vTraductor.Registrar(Me)
    '    ActualizarObservador(Me)
    'End Sub
End Class