Imports System.Security.Cryptography
Imports System.Text
Public Class EncriptadorBLL

#Region "Singleton"
    Private Shared mInstance As EncriptadorBLL = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As EncriptadorBLL
        If mInstance Is Nothing Then
            mInstance = New EncriptadorBLL
        End If
        Return mInstance
    End Function
#End Region


    Public Function Encriptar(pTexto As String) As String
        Dim mMD5Hash As MD5 = MD5.Create
        Dim mBytes As Byte() = mMD5Hash.ComputeHash(Encoding.UTF8.GetBytes(pTexto))
        Dim mStringBuilder As New StringBuilder

        For i = 0 To mBytes.Length - 1
            mStringBuilder.Append(mBytes(i).ToString("X2"))
        Next

        Return mStringBuilder.ToString
    End Function


    Public Function ValidarHash(pTexto As String, pEncriptado As String) As Boolean
        Dim mNuevoHash As String = Encriptar(pTexto)
        If mNuevoHash = pEncriptado Then
            Return True
        Else
            Return False
        End If
    End Function

End Class

