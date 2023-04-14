Public Class UsuarioBE
    Inherits Persona


    Public Property usuario As String
    Public Property contraseña As String

    Public Overrides Function ToString() As String
        Return Me.nombre
    End Function


    Sub New()

    End Sub


End Class
