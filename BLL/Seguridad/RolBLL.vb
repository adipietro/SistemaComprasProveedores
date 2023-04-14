Imports System.Windows.Forms
Imports DAL
Public Class RolBLL
    Public Property idusuario As Integer
    Public Property nombre As String
    Public Property Apellido As String
    Public Property usuario As String
    Public Property contraseña As String
    Public Property familia As Integer = 0

    Private _p1 As Integer

    Sub New(Id As Integer)
        CargarPropiedades(Id)
    End Sub

    Sub New()

    End Sub
    Public Property id_familia As Integer
    Public Property nombreFamilia As String

    Private Sub CargarPropiedades(Id As Integer)
        Dim FamiliaBE As BE.RolBE = RolDAL.Obtenerfamilia(Id)

        If Not IsNothing(FamiliaBE) Then
            Me.id_familia = FamiliaBE.familia_id
            Me.nombreFamilia = FamiliaBE.nombre

            If FamiliaBE.listapatentes.Count > 0 Then
                For Each mPermisoBE As BE.PermisoAbsBE In FamiliaBE.listapatentes
                    Dim mPermiso As BLL.PermisoAbsBLL

                    If TypeOf (mPermisoBE) Is BE.GrupoPermisosBE Then
                        mPermiso = New BLL.GrupoPermisosBLL(mPermisoBE)
                    Else
                        mPermiso = New BLL.PermisoBLL(mPermisoBE)
                    End If

                    Me.mlistaPatentes.Add(mPermiso)
                Next
            End If
        End If
    End Sub


    Private Sub Cargar(familiaBE As BE.RolBE)

        If Not IsNothing(familiaBE) Then
            familiaBE.familia_id = Me.id_familia
            familiaBE.nombre = Me.nombreFamilia

            If Me.mlistaPatentes.Count > 0 Then
                For Each PatenteBll As BLL.PermisoAbsBLL In Me.mlistaPatentes
                    Dim PatenteBE As BE.PermisoAbsBE

                    If TypeOf (PatenteBll) Is BLL.GrupoPermisosBLL Then
                        PatenteBE = New BE.GrupoPermisosBE
                        CType(PatenteBll, BLL.GrupoPermisosBLL).Cargar(PatenteBE)
                    Else
                        PatenteBE = New BE.PermisoBE
                        CType(PatenteBll, BLL.PermisoBLL).Cargar(PatenteBE)
                    End If

                    familiaBE.listapatentes.Add(PatenteBE)
                Next
            End If
        End If


    End Sub

    Public mlistaPatentes As New List(Of BLL.PermisoAbsBLL)

    Private _patenteRaiz As PermisoAbsBLL

    Public Property PatenteAbstracta() As PermisoAbsBLL
        Get
            Return _patenteRaiz
        End Get
        Set(ByVal value As PermisoAbsBLL)
            _patenteRaiz = value
        End Set
    End Property

    Public Sub MostrarEnTreeview(ByRef padres As TreeNodeCollection)

    End Sub

    Public Sub Alta()
        Dim mBE As New BE.RolBE
        If Me.id_familia = 0 Then

            Me.id_familia = RolDAL.proximoID
            Cargar(mBE)
            RolDAL.GuardarNuevo(mBE)
        Else
            Cargar(mBE)
            RolDAL.GuardarModificacion(mBE)
        End If

        If mBE.listapatentes.Count > 0 Then
            For Each mPermiso As BE.PermisoAbsBE In mBE.listapatentes
                If TypeOf (mPermiso) Is BE.PermisoBE Then
                    RolPermisoDAL.GuardarNuevo(mBE.familia_id, mPermiso.id)
                Else
                    RolGrupoPermisosDAL.GuardarNuevo(mBE.familia_id, mPermiso.id)
                End If
            Next
        End If
    End Sub

    Public Sub baja()
        Dim mbe As New BE.RolBE
        Cargar(mbe)
        RolDAL.Eliminar(mbe)
    End Sub

    Public Overrides Function ToString() As String
        Return Me.nombreFamilia()
    End Function




    Public Shared Function listar() As List(Of BLL.RolBLL)


        Dim mlista As New List(Of BLL.RolBLL)
        Dim mlistabe As List(Of BE.RolBE) = RolDAL.listarfamilia

        If Not IsNothing(mlistabe) Then
            For Each mfamilia As BE.RolBE In mlistabe
                If TypeOf (mfamilia) Is BE.RolBE Then
                    Dim FamiliaBE As New BLL.RolBLL(mfamilia.familia_id)
                    mlista.Add(FamiliaBE)
                End If

            Next
        End If
        Return mlista
    End Function



End Class
