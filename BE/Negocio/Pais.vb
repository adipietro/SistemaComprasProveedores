Public Class Pais
    Inherits ID
    Public Property NombrePais As String

    Public Overrides Function ToString() As String
        Return Me.NombrePais
    End Function
End Class
