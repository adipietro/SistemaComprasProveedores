Imports System.Windows.Forms
Public MustInherit Class PermisoAbsBLL
    Public Property id As Integer
    Public Property nombrePatente
    Public Property formulario As String
    Public Property padre As Nullable(Of Integer)
    Public Property Texto As String

    Private _Select As Boolean
    Public Property Seleccion() As Boolean
        Get
            Return _Select
        End Get
        Set(ByVal value As Boolean)
            _Select = value
        End Set
    End Property

    Public MustOverride Function MostrarEnTreeView(pTreeView As Windows.Forms.TreeView) As Windows.Forms.TreeView
    Public MustOverride Sub Alta()
    Public MustOverride Sub baja()
    Public MustOverride Sub MostrarEnMenuStrip(pMenu As MenuStrip, pUsuario As UsuarioBLL, pForm As Form)
End Class
