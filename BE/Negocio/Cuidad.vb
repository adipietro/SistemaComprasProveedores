Public Class Cuidad
    Inherits ID

    Public Property Nombre As String
    Public Property CP As String
    Public Property Provincia As BE.Provincia

    Public Overrides Function ToString() As String
        Return Me.Nombre & " (CP: " & Me.CP & ")"
    End Function

    Sub New()

    End Sub


End Class
