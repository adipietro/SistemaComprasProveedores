Imports BE
Imports DAL

Public Class idiomaBLL
    Public Property ID As Integer = 0
    Public Property Nombre As String
    Property Diccionario As New Dictionary(Of String, String)

    Sub New()

    End Sub

    Sub New(pidioma As String)
        CargarPropiedades(pidioma)
    End Sub

    Sub New(pId As Integer, pNombre As String, pDiccionario As Dictionary(Of String, String))
        ID = pId
        Nombre = pNombre
        Diccionario = pDiccionario
    End Sub

    Sub New(pNombre As String, pDiccionario As Dictionary(Of String, String))
        Nombre = pNombre
        Diccionario = pDiccionario
    End Sub

    Private Sub CargarPropiedades(pIdioma As String)
        Dim mBE As BE.IdiomaBE = IdiomaDAL.ObtenerIdioma(pIdioma)

        If Not IsNothing(mBE) Then
            Me.ID = mBE.id_idioma
            Me.Nombre = mBE.nombre.Trim
            Me.Diccionario = mBE.diccionario
        End If
    End Sub

    Private Sub CargarBE(mBE As BE.IdiomaBE)
        mBE.id_idioma = Me.ID
        mBE.nombre = Me.Nombre
    End Sub


    Public Sub Guardar()
        Dim mBE As New BE.IdiomaBE
        mBE.diccionario = Me.Diccionario
        mBE.id_idioma = Me.ID
        mBE.nombre = Me.Nombre

        If Me.ID = 0 Then

            'CargarBE(mBE)
            IdiomaDAL.GuardarNuevo(mBE)
        Else
            'CargarBE(mBE)
            IdiomaDAL.GuardarModificacion(mBE)
        End If

        CargarBE(mBE)
    End Sub


    Public Sub Eliminar()
        Dim mBE As New BE.IdiomaBE

        CargarBE(mBE)

        IdiomaDAL.Eliminar(mBE)
    End Sub


    Public Shared Function Listaridiomas() As List(Of idiomaBLL)
        Dim mLista As New List(Of idiomaBLL)
        Dim mListaBE As List(Of BE.IdiomaBE) = IdiomaDAL.ListarIdiomas

        For Each mBE As BE.IdiomaBE In mListaBE
            Dim midioma As New idiomaBLL(mBE.id_idioma)

            mLista.Add(midioma)
        Next

        Return mLista
    End Function


    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function


End Class
