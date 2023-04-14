Public Class ProductoBE
    Inherits ID


    Public Property Categoría As BE.CategoríaProductoBE
    Public Property Nombre As String

    Sub New()

    End Sub

    Sub New(id As Integer)
        id = id
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function

End Class
