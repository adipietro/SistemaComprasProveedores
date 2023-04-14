Public Class Traductor
    Implements iObservado


    Private Shared vTraductor As Traductor

    Private Sub New()
    End Sub

    Public Shared Function GetInstance() As Traductor
        If vTraductor Is Nothing Then
            vTraductor = New Traductor
            vTraductor.IdiomaSeleccionado = vTraductor.GetIdiomas().Item(0)

        End If
        Return vTraductor
    End Function

    Public Function Traducir(pTraducible As String) As String
        If Not IsNothing(Me.IdiomaSeleccionado) AndAlso Me.IdiomaSeleccionado.Diccionario.ContainsKey(pTraducible) Then
            Return Me.IdiomaSeleccionado.Diccionario(pTraducible)
        Else
            Return pTraducible
        End If
    End Function


    Private vIdiomaSeleccionado As BLL.idiomaBLL
    Public Property IdiomaSeleccionado() As BLL.idiomaBLL
        Get
            Return vIdiomaSeleccionado
        End Get
        Set(ByVal value As BLL.idiomaBLL)
            If vIdiomaSeleccionado Is Nothing OrElse vIdiomaSeleccionado.Nombre <> value.Nombre Then
                vIdiomaSeleccionado = value
                Notificar()
            End If
        End Set
    End Property

    Dim vListaRegistrados As New List(Of iObservador)
    Dim vIdiomaBLL As New BLL.idiomaBLL

    Public ReadOnly Property Registrados As List(Of iObservador) Implements iObservado.Registrados
        Get
            Return vListaRegistrados
        End Get

    End Property

    Public Sub Notificar() Implements iObservado.Notificar
        For Each vRegistrado As iObservador In vListaRegistrados
            vRegistrado.ActualizarObservador(vRegistrado)
        Next
    End Sub

    Public Sub Registrar(pObservador As iObservador) Implements iObservado.Registrar
        If vListaRegistrados.Count > 0 Then
            For Each vRegistrado As iObservador In vListaRegistrados
                If vRegistrado.ToString = pObservador.ToString Then
                    vListaRegistrados.Remove(vRegistrado)
                    Exit For
                End If
            Next
        End If
        vListaRegistrados.Add(pObservador)
    End Sub

    Public Function GetIdiomas() As List(Of BLL.idiomaBLL)
        Dim vLista As New List(Of BLL.idiomaBLL)
        For Each vIdioma As BLL.idiomaBLL In BLL.idiomaBLL.Listaridiomas
            vLista.Add(vIdioma)
        Next
        Return vLista
    End Function

    Public Sub AltaIdioma(pNombre As String, pDiccionario As Dictionary(Of String, String))
        Dim vIdioma As New BLL.idiomaBLL()
        vIdioma.Nombre = pNombre
        vIdioma.Diccionario = pDiccionario
        vIdioma.Guardar()
    End Sub

    Public Sub BajaIdioma(pIdioma As BLL.idiomaBLL)
        pIdioma.Eliminar()
    End Sub

    Public Sub ModificacionIdioma(pIdioma As BLL.idiomaBLL)
        pIdioma.Guardar()
    End Sub



End Class
