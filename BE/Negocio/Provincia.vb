Public Class Provincia
    Inherits ID
    Public Property Nombre As String
    Public Property Pais As BE.Pais


    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function
End Class
