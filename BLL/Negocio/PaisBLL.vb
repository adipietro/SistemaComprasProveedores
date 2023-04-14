Imports DAL
Imports BE

Public Class PaisBLL
    Sub New()

    End Sub

    Public Function Listar() As List(Of BE.Pais)
        Return PaisDAL.Listar
    End Function

End Class
