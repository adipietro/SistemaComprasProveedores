Imports DAL
Imports System.Windows.Forms

Public Class PatenteBLL



    'Private lstPatentes As New List(Of BLL.PatenteAbsBLL)

    'Sub New(mPatenteBE As BE.PatenteAbsBE)
    '    CargarPropiedades(mPatenteBE.ID)
    'End Sub

    'Public Property Patentes() As List(Of BLL.PatenteAbsBLL)
    '    Get
    '        Return lstPatentes
    '    End Get
    '    Set(ByVal value As List(Of BLL.PatenteAbsBLL))
    '        lstPatentes = value
    '    End Set
    'End Property



    'Public Sub Cargar(ppatente As BE.PatenteAbsBE)
    '    ppatente.ID = Me.id
    '    ppatente.nombre = Me.nombrePatente
    '    ppatente.formulario = Me.formulario
    '    ppatente.padre = Me.padre
    'End Sub

    'Private Sub CargarPropiedades(Id As Integer)
    '    Dim PatenteBE As BE.PatenteBE = PatenteDAL.Obtenerpatente(Id)

    '    If Not IsNothing(PatenteBE) Then
    '        Me.id = PatenteBE.ID
    '        Me.nombrePatente = PatenteBE.nombre
    '        Me.formulario = PatenteBE.formulario
    '        Me.padre = PatenteBE.padre

    '    End If
    'End Sub

    'Public Overrides Sub Alta()

    '    Dim PatenteBE As New BE.PatenteBE
    '    If Me.id = 0 Then

    '        Me.id = PatenteDAL.proximoID
    '        Cargar(PatenteBE)
    '        PatenteDAL.GuardarNuevo(PatenteBE)
    '    Else
    '        Cargar(PatenteBE)
    '        PatenteDAL.GuardarModificacion(PatenteBE)
    '    End If
    'End Sub

    'Public Overrides Sub baja()
    '    Dim PatenteBE As New BE.PatenteBE
    '    Cargar(PatenteBE)
    '    PatenteDAL.Eliminar(PatenteBE)
    'End Sub



    'Public Sub New()

    'End Sub

    'Public Sub New(Id As Integer)
    '    CargarPropiedades(Id)

    'End Sub



    'Public Function listar() As List(Of PatenteBLL)

    '    Dim mlista As New List(Of BLL.PatenteBLL)
    '    Dim mlistabe As List(Of BE.PatenteBE) = PatenteDAL.Listar

    '    If Not IsNothing(mlistabe) Then
    '        For Each mpatente As BE.PatenteAbsBE In mlistabe
    '            If TypeOf (mpatente) Is BE.PatenteBE Then
    '                Dim ppatente As New BLL.PatenteBLL(mpatente.ID)
    '            End If

    '        Next
    '    End If
    '    Return mlista

    'End Function

    
    ' Nuevos

    Public Shared Function listarPatentesTotales() As HashSet(Of BE.PatenteAbsBE)
        Return PatenteDAL.listarPatentesTotales()
    End Function

    Public Shared Function listarPatentesUsuario(usuarioSeleccionado As BE.UsuarioBE) As HashSet(Of BE.PatenteAbsBE)
        Return PatenteDAL.listarPatentesUsuario(usuarioSeleccionado)
    End Function


    Public Shared Function agregarPatenteAUsuario(usuario As BE.UsuarioBE, patente As BE.PatenteAbsBE) As Boolean
        Return PatenteDAL.agregarPatenteAUsuario(usuario, patente)
    End Function


    Public Shared Function removerPatenteAUsuario(usuarioSeleccionado As BE.UsuarioBE, patenteUsuario As BE.PatenteAbsBE) As Boolean
        Return PatenteDAL.removerPatenteAUsuario(usuarioSeleccionado, patenteUsuario)
    End Function

    Public Shared Function altaDePatente(nombre_patente As String, formulario As String, nombre_menu As String) As Boolean
        Return PatenteDAL.altaDePatente(nombre_patente, formulario, nombre_menu)
    End Function

    Public Shared Function listarTodosGruposPatentes() As HashSet(Of BE.GrupoPatenteBE)
        Return PatenteDAL.listarTodosGruposPatentes()
    End Function

    Public Shared Function listarPatentesDeGrupoPatente(grupo_patente As BE.GrupoPatenteBE) As HashSet(Of BE.PatenteAbsBE)
        Return PatenteDAL.listarPatentesDeGrupoPatente(grupo_patente)
    End Function

    Public Shared Sub modificarPatentesHijas(patente_padre As BE.PatenteAbsBE, patentes_hijas As HashSet(Of BE.PatenteAbsBE))
        PatenteDAL.modificarPatentesHijas(patente_padre, patentes_hijas)
    End Sub

    Public Shared Sub altaDeGrupoPatente(nombre_patente As String)
        PatenteDAL.altaDeGrupoPatente(nombre_patente)
    End Sub

End Class
