Imports DAL
Imports System.Windows.Forms
Public Class PermisoBLL

    Inherits PermisoAbsBLL



    Private lstPatentes As New List(Of BLL.PermisoAbsBLL)

    Sub New(mPatenteBE As BE.PermisoAbsBE)
        CargarPropiedades(mPatenteBE.id)
    End Sub

    Public Property Patentes() As List(Of BLL.PermisoAbsBLL)
        Get
            Return lstPatentes
        End Get
        Set(ByVal value As List(Of BLL.PermisoAbsBLL))
            lstPatentes = value
        End Set
    End Property



    Public Sub Cargar(ppatente As BE.PermisoAbsBE)
        ppatente.id = Me.id
        ppatente.nombre = Me.nombrePatente
        ppatente.formulario = Me.formulario
        ppatente.padre = Me.padre
    End Sub



    Private Sub CargarPropiedades(Id As Integer)
        Dim PatenteBE As BE.PermisoBE = PermisoDAL.Obtenerpatente(Id)

        If Not IsNothing(PatenteBE) Then
            Me.id = PatenteBE.id
            Me.nombrePatente = PatenteBE.nombre
            Me.formulario = PatenteBE.formulario
            Me.padre = PatenteBE.padre

        End If
    End Sub


    Public Overrides Sub Alta()

        Dim PatenteBE As New BE.PermisoBE
        If Me.id = 0 Then

            Me.id = PermisoDAL.proximoID
            Cargar(PatenteBE)
            PermisoDAL.GuardarNuevo(PatenteBE)
        Else
            Cargar(PatenteBE)
            PermisoDAL.GuardarModificacion(PatenteBE)
        End If
    End Sub

    Public Overrides Sub baja()
        Dim PatenteBE As New BE.PermisoBE
        Cargar(PatenteBE)
        PermisoDAL.Eliminar(PatenteBE)
    End Sub



    Public Sub New()

    End Sub

    Public Sub New(Id As Integer)
        CargarPropiedades(Id)

    End Sub


    Public Overrides Sub MostrarEnMenuStrip(pMenu As MenuStrip, pUsuario As UsuarioBLL, pForm As Form)

    End Sub

    Public Function listar() As List(Of PermisoBLL)

        Dim mlista As New List(Of BLL.PermisoBLL)
        Dim mlistabe As List(Of BE.PermisoBE) = PermisoDAL.Listar

        If Not IsNothing(mlistabe) Then
            For Each mpatente As BE.PermisoAbsBE In mlistabe
                If TypeOf (mpatente) Is BE.PermisoBE Then
                    Dim ppatente As New BLL.PermisoBLL(mpatente.id)
                End If

            Next
        End If
        Return mlista

    End Function

    Public Overrides Function MostrarEnTreeView(pTreeView As Windows.Forms.TreeView) As Windows.Forms.TreeView
        Return Nothing
    End Function
End Class
