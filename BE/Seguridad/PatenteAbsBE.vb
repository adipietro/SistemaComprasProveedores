Imports System.Windows.Forms

Public MustInherit Class PatenteAbsBE
    Inherits ID

    Public Property nombre As String


    Public Overrides Function ToString() As String
        Return Me.nombre
    End Function

    Public MustOverride Function Permite(formulario As String) As Boolean
    Public MustOverride Function ListarPatentesHojasPermitidas() As HashSet(Of PatenteBE)
End Class
