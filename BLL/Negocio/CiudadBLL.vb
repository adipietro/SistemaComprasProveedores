Imports DAL
Imports BE

Public Class CIUDADBLL
    Sub New()

    End Sub

    Public Function Listar(provincia As String) As List(Of BE.Cuidad)
        Return CiudadDAL.Listar(provincia)
    End Function

End Class