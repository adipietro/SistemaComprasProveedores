Imports DAL
Imports System.Windows.Forms
Imports System.Reflection

Public Class GrupoPatenteBLL

    Inherits BLL.PatenteAbsBLL



    'Public Sub cargar(patenteBE As BE.PatenteAbsBE)
    '    patenteBE.ID = Me.id
    '    patenteBE.nombre = Me.nombrePatente
    '    patenteBE.formulario = Me.formulario
    'End Sub

    'Private Sub CargarPropiedades(pid As Integer)
    '    Dim grpPatenteBE As BE.GrupoPatenteBE = GrupoPatenteDAL.Obtenergrupopatente(pid)

    '    If Not IsNothing(grpPatenteBE) Then
    '        Me.id = grpPatenteBE.ID
    '        Me.nombrePatente = grpPatenteBE.nombre

    '    End If
    'End Sub

    'Private Sub CargarPropiedades(grpPatenteBE As BE.GrupoPatenteBE)

    '    If Not IsNothing(grpPatenteBE) Then
    '        Me.id = grpPatenteBE.ID
    '        Me.nombrePatente = grpPatenteBE.nombre


    '    End If
    'End Sub

    'Private lstPatentes As New List(Of BLL.PatenteAbsBLL)
    'Public Property Patentes() As List(Of BLL.PatenteAbsBLL)
    '    Get
    '        Return lstPatentes
    '    End Get
    '    Set(ByVal value As List(Of BLL.PatenteAbsBLL))
    '        lstPatentes = value
    '    End Set
    'End Property


    'Public Overrides Sub Alta()
    '    Dim grpPatenteBE As New BE.GrupoPatenteBE
    '    If Me.id = 0 Then

    '        Me.id = GrupoPatenteDAL.proximoID
    '        'cargar(grpPatenteBE)
    '        GrupoPatenteDAL.GuardarNuevo(grpPatenteBE)
    '    Else
    '        'cargar(grpPatenteBE)
    '        GrupoPatenteDAL.GuardarModificacion(grpPatenteBE)
    '    End If

    'End Sub

    'Public Overrides Sub baja()
    '    Dim grpPatenteBE As New BE.GrupoPatenteBE
    '    cargar(grpPatenteBE)
    '    'PatenteDAL.Eliminar(grpPatenteBE)

    'End Sub


    'Private Sub AgregarHijos(Padre As BLL.GrupoPatenteBLL, pTreeNode As TreeNode)
    '    For Each PatenteAbsBLL As BLL.PatenteAbsBLL In Padre.Patentes
    '        Dim mNode As New TreeNode
    '        mNode.Text = PatenteAbsBLL.nombrePatente
    '        mNode.Tag = PatenteAbsBLL
    '        pTreeNode.Nodes.Add(mNode)

    '        If TypeOf (PatenteAbsBLL) Is BLL.GrupoPatenteBLL Then
    '            mNode.Text = PatenteAbsBLL.nombrePatente

    '            Dim mgrupopatente As BLL.GrupoPatenteBLL
    '            mgrupopatente = DirectCast(PatenteAbsBLL, BLL.GrupoPatenteBLL)

    '            If mgrupopatente.Patentes.Count > 0 Then
    '                AgregarHijos(mgrupopatente, pTreeNode.LastNode)
    '            End If
    '        End If
    '    Next

    'End Sub


    'Public Function listar() As List(Of BLL.PatenteAbsBLL)

    '    Dim mlista As New List(Of BLL.PatenteAbsBLL)
    '    Dim mlistabe As List(Of BE.GrupoPatenteBE) = GrupoPatenteDAL.Listar

    '    If Not IsNothing(mlistabe) Then
    '        For Each mpatente As BE.PatenteAbsBE In mlistabe
    '            If TypeOf (mpatente) Is BE.GrupoPatenteBE Then
    '                Dim ppatente As New BLL.GrupoPatenteBLL(mpatente.ID)
    '                mlista.Add(ppatente)
    '            End If

    '        Next
    '    End If
    '    Return mlista
    'End Function






    'Public Sub AgregarToolStrip(patAbsBLL As BLL.PatenteAbsBLL, pMenuItem As ToolStripMenuItem, pFormulario As Form)
    '    Try
    '        Dim Padre As BLL.GrupoPatenteBLL = DirectCast(patAbsBLL, BLL.GrupoPatenteBLL)

    '        If Not Padre.Patentes Is Nothing Then
    '            For Each mPermisoAbs As BLL.PatenteAbsBLL In Padre.Patentes
    '                Dim mMenuItem As New ToolStripMenuItem

    '                mMenuItem.Name = mPermisoAbs.nombrePatente
    '                mMenuItem.Tag = mPermisoAbs

    '                pMenuItem.DropDownItems.Add(mMenuItem)
    '                pMenuItem.DropDownItems.Item(mMenuItem.Name).Text = mPermisoAbs.nombrePatente


    '                If TypeOf mPermisoAbs Is BLL.GrupoPatenteBLL Then
    '                    AgregarToolStrip(mPermisoAbs, mMenuItem, pFormulario)
    '                Else
    '                    AddHandler mMenuItem.Click, AddressOf Menu_Click
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub



    'Sub New(grpPatenteBE As BE.GrupoPatenteBE)
    '    CargarPropiedades(grpPatenteBE)
    '    CargarHijos()
    'End Sub

    'Sub New(ID As Integer)
    '    CargarPropiedades(ID)
    '    CargarHijos()
    'End Sub

    'Sub New(mPatenteBE As BE.PatenteAbsBE)
    '    CargarPropiedades(mPatenteBE.ID)
    '    CargarHijos()
    'End Sub

    'Sub New()

    'End Sub

    'Public Function MostrarEnTreeView(pTreeView As TreeView) As TreeView
    '    Try
    '        Dim lstPermisos As List(Of BLL.PatenteAbsBLL) = listar()

    '        Dim mNode As TreeNode = pTreeView.Nodes.Add(lstPermisos.Item(0).nombrePatente)
    '        mNode.Tag = lstPermisos.Item(0)

    '        AgregarHijos(mNode.Tag, mNode)
    '    Catch ex As Exception

    '    End Try

    '    Return pTreeView
    'End Function

    Public Overrides Sub Alta()

    End Sub

    Public Overrides Sub baja()

    End Sub
End Class
