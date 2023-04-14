Public Class CategoríaProductoBE
    Inherits ID

    Public Property NombreCategoria As String

    Public Overrides Function ToString() As String
        Return Me.NombreCategoria
    End Function
  

End Class
