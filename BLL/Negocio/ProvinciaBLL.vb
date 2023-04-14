Imports DAL
Imports BE

Public Class ProvinciaBLL
    Sub New()

    End Sub

    Public Function ListarEspecial(PAIS As String) As List(Of BE.Provincia)
        Return ProvinciaDAL.ListarEspecial(PAIS)
    End Function

End Class
