Imports DAL
Imports BE

Public Class ProveedorBLL

   
    Sub New()

    End Sub

   
    Public Sub Guardar(mBE As BE.ProveedorBE)
        If mBE.ID = 0 Then
            ProveedorDAL.GuardarNuevo(mBE)
        Else
            ProveedorDAL.GuardarModificacion(mBE)
        End If
    End Sub

    Public Sub Eliminar(mbe As BE.ProveedorBE)
        ProveedorDAL.Eliminar(mbe)
    End Sub


    Public Function Listar() As List(Of ProveedorBE)
        'Dim mLista As New List(Of ProveedorBLL)
        Dim mListaBE As List(Of BE.ProveedorBE) = ProveedorDAL.Listar

        'For Each mBE As BE.ProveedorBE In mListaBE
        '    Dim mProveedor As New ProveedorBLL
        '    mLista.Add(mProveedor)
        'Next

        Return mListaBE
    End Function

    
End Class
