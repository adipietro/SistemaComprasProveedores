Public Class Persona
    Inherits ID

    Public Property nombre As String
    Public Property Apellido As String

    Public Overrides Function ToString() As String
        Return Me.nombre & " " & Me.Apellido
    End Function
End Class
