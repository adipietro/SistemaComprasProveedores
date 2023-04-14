Imports System.Windows.Forms


Public Class GrupoPatenteBE
    Inherits PatenteAbsBE


    Private setPatentes As New HashSet(Of BE.PatenteAbsBE)

    Public Property Patentes() As HashSet(Of BE.PatenteAbsBE)
        Get
            Return setPatentes
        End Get
        Set(ByVal value As HashSet(Of BE.PatenteAbsBE))
            setPatentes = value
        End Set
    End Property


    Public Overrides Function Permite(formulario As String) As Boolean
        For Each patente In setPatentes
            If patente.Permite(formulario) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Overrides Function ListarPatentesHojasPermitidas() As HashSet(Of PatenteBE)
        Dim ret As New HashSet(Of PatenteBE)
        For Each patente In setPatentes
            ret.UnionWith(patente.ListarPatentesHojasPermitidas())
        Next
        Return ret
    End Function
End Class