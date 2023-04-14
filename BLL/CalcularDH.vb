Public Class CalcularDH
    Public Shared Function CalcularDV(pString As String) As String
        Return BLL.EncriptadorBLL.GetInstance.Encriptar(pString)
   
    End Function


    Public Shared Function VerificarDV(pString As String, pDV As String) As Boolean
        If CalcularDV(pString) = pDV Then
            Return True
        Else
            Return False
        End If
    End Function
End Class