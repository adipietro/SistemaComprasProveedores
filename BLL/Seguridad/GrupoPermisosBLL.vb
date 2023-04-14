Imports DAL
Imports System.Windows.Forms
Imports System.Reflection

Public Class GrupoPermisosBLL
    Inherits BLL.PermisoAbsBLL


    Public Sub cargar(patenteBE As BE.PermisoAbsBE)
        patenteBE.id = Me.id
        patenteBE.nombre = Me.nombrePatente
        patenteBE.formulario = Me.formulario
        patenteBE.padre = Me.padre
    End Sub

    Private Sub CargarPropiedades(pid As Integer)
        Dim grpPatenteBE As BE.GrupoPermisosBE = GrupoPermisosDAL.Obtenergrupopatente(pid)

        If Not IsNothing(grpPatenteBE) Then
            Me.id = grpPatenteBE.id
            Me.nombrePatente = grpPatenteBE.nombre
            Me.padre = grpPatenteBE.padre

        End If
    End Sub

    Private Sub CargarPropiedades(grpPatenteBE As BE.GrupoPermisosBE)

        If Not IsNothing(grpPatenteBE) Then
            Me.id = grpPatenteBE.id
            Me.nombrePatente = grpPatenteBE.nombre
            Me.padre = grpPatenteBE.padre

        End If
    End Sub

    Private lstPatentes As New List(Of BLL.PermisoAbsBLL)
    Public Property Patentes() As List(Of BLL.PermisoAbsBLL)
        Get
            Return lstPatentes
        End Get
        Set(ByVal value As List(Of BLL.PermisoAbsBLL))
            lstPatentes = value
        End Set
    End Property


    Public Overrides Sub Alta()
        Dim grpPatenteBE As New BE.GrupoPermisosBE
        If Me.id = 0 Then

            Me.id = GrupoPermisosDAL.proximoID
            cargar(grpPatenteBE)
            GrupoPermisosDAL.GuardarNuevo(grpPatenteBE)
        Else
            cargar(grpPatenteBE)
            GrupoPermisosDAL.GuardarModificacion(grpPatenteBE)
        End If

    End Sub

    Public Overrides Sub baja()
        Dim grpPatenteBE As New BE.GrupoPermisosBE
        cargar(grpPatenteBE)
        PermisoDAL.Eliminar(grpPatenteBE)

    End Sub

    Public Overrides Function MostrarEnTreeview(pTreeView As TreeView) As TreeView
        Try
            Dim lstPermisos As List(Of BLL.PermisoAbsBLL) = listar()


            Dim mNode As TreeNode = pTreeView.Nodes.Add(lstPermisos.Item(0).nombrePatente)
            mNode.Tag = lstPermisos.Item(0)

            AgregarHijos(mNode.Tag, mNode)
        Catch ex As Exception

        End Try

        Return pTreeView
    End Function

    Private Sub AgregarHijos(Padre As BLL.GrupoPermisosBLL, pTreeNode As TreeNode)
        For Each PatenteAbsBLL As BLL.PermisoAbsBLL In Padre.Patentes
            Dim mNode As New TreeNode
            mNode.Text = PatenteAbsBLL.nombrePatente
            mNode.Tag = PatenteAbsBLL
            pTreeNode.Nodes.Add(mNode)

            If TypeOf (PatenteAbsBLL) Is BLL.GrupoPermisosBLL Then
                mNode.Text = PatenteAbsBLL.nombrePatente

                Dim mgrupopatente As BLL.GrupoPermisosBLL
                mgrupopatente = DirectCast(PatenteAbsBLL, BLL.GrupoPermisosBLL)

                If mgrupopatente.Patentes.Count > 0 Then
                    AgregarHijos(mgrupopatente, pTreeNode.LastNode)
                End If
            End If
        Next

    End Sub


    Public Function listar() As List(Of BLL.PermisoAbsBLL)


        Dim mlista As New List(Of BLL.PermisoAbsBLL)
        Dim mlistabe As List(Of BE.GrupoPermisosBE) = GrupoPermisosDAL.Listar

        If Not IsNothing(mlistabe) Then
            For Each mpatente As BE.PermisoAbsBE In mlistabe
                If TypeOf (mpatente) Is BE.GrupoPermisosBE Then
                    Dim ppatente As New BLL.GrupoPermisosBLL(mpatente.id)
                    mlista.Add(ppatente)
                End If

            Next
        End If
        Return mlista
    End Function

    Private Sub CargarHijos()
        Dim ListaA As List(Of BE.GrupoPermisosBE) = GrupoPermisosDAL.Listar(Me.id)
        Dim ListaB As List(Of BE.PermisoBE) = PermisoDAL.Listar(Me.id)

        If Not IsNothing(ListaA) Then
            For Each mPermisoAbs As BE.PermisoAbsBE In ListaA
                Dim mPermisoBLL As New BLL.GrupoPermisosBLL(mPermisoAbs)
                Me.Patentes.Add(mPermisoBLL)
            Next
        End If

        If Not IsNothing(ListaB) Then
            For Each mPermisoAbs As BE.PermisoAbsBE In ListaB
                Dim mPatentebll As New BLL.PermisoBLL(mPermisoAbs)
                Me.Patentes.Add(mPatentebll)
            Next
        End If
    End Sub


    Public Overrides Sub MostrarEnMenuStrip(MenuStrip As MenuStrip, usuarioBLL As UsuarioBLL, pFormulario As Form)
        Dim Rol As New BLL.RolBLL(usuarioBLL.rol)

        For Each mPermisoAbs As BLL.PermisoAbsBLL In Rol.mlistaPatentes
            Dim mMenuItem As New ToolStripMenuItem()

            mMenuItem.Name = mPermisoAbs.nombrePatente
            mMenuItem.Tag = mPermisoAbs

            MenuStrip.Items.Add(mMenuItem)
            MenuStrip.Items.Item(mMenuItem.Name).Text = mPermisoAbs.nombrePatente

            If TypeOf mPermisoAbs Is BLL.GrupoPermisosBLL Then
                AgregarToolStrip(mPermisoAbs, mMenuItem, pFormulario)
            Else
                AddHandler mMenuItem.Click, AddressOf Menu_Click
            End If
        Next
    End Sub

    Public Sub AgregarToolStrip(patAbsBLL As BLL.PermisoAbsBLL, pMenuItem As ToolStripMenuItem, pFormulario As Form)
        Try
            Dim Padre As BLL.GrupoPermisosBLL = DirectCast(patAbsBLL, BLL.GrupoPermisosBLL)

            If Not Padre.Patentes Is Nothing Then
                For Each mPermisoAbs As BLL.PermisoAbsBLL In Padre.Patentes
                    Dim mMenuItem As New ToolStripMenuItem

                    mMenuItem.Name = mPermisoAbs.nombrePatente
                    mMenuItem.Tag = mPermisoAbs

                    pMenuItem.DropDownItems.Add(mMenuItem)
                    pMenuItem.DropDownItems.Item(mMenuItem.Name).Text = mPermisoAbs.nombrePatente


                    If TypeOf mPermisoAbs Is BLL.GrupoPermisosBLL Then
                        AgregarToolStrip(mPermisoAbs, mMenuItem, pFormulario)
                    Else
                        AddHandler mMenuItem.Click, AddressOf Menu_Click
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mMenuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Click(mMenuItem)
    End Sub


    Private Sub Click(pMenuItem As ToolStripItem)
        Dim mFormName As String = DirectCast(pMenuItem.Tag, BLL.PermisoBLL).formulario.ToString
        Dim mAssembly As Assembly = Assembly.GetEntryAssembly
        Dim mType As Type = mAssembly.GetType(mFormName)
        Dim mForm = Activator.CreateInstance(mType)
        mForm.ShowDialog()
    End Sub

    Sub New(grpPatenteBE As BE.GrupoPermisosBE)
        CargarPropiedades(grpPatenteBE)
        CargarHijos()
    End Sub

    Sub New(ID As Integer)
        CargarPropiedades(ID)
        CargarHijos()
    End Sub

    Sub New(mPatenteBE As BE.PermisoAbsBE)
        CargarPropiedades(mPatenteBE.id)
        CargarHijos()
    End Sub

    Sub New()

    End Sub

End Class
