Public Class PatenteBE
    Inherits PatenteAbsBE

    'Aca agregamos las operaciones que afectan a todos las Patentes

    Public Property formulario As String
    Public Property menu As String

    Public Overrides Function Permite(formulario As String) As Boolean
        Return Me.formulario = formulario
    End Function

    Public Overrides Function ListarPatentesHojasPermitidas() As HashSet(Of PatenteBE)
        Dim ret As New HashSet(Of PatenteBE)
        ret.Add(Me)
        Return ret
    End Function
End Class
