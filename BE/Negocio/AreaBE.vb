Public Class AreaBE
    Inherits ID

    Public Property Nombre As String
    Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function

End Class
