Imports BE

Public Class BitacoraBLL

    Public Sub New()

    End Sub


    Public Sub Guardarnuevo(mBitacora As BE.Bitacora)

        DAL.bitacoraDAL.GuardarNuevo(mBitacora)

    End Sub


    Public Shared Function Listarbitacora() As List(Of Bitacora)
        'Dim mLista As New List(Of BitacoraBLL)
        Dim mListaDTO As List(Of BE.Bitacora) = DAL.bitacoraDAL.Listarbitacora

        'If Not IsNothing(mListaDTO) Then
        '    For Each mBE As BE.Bitacora In mListaDTO
        '        Dim bitacora As New BitacoraBLL()
        '        mLista.Add(bitacora)
        '    Next
        'End If
        Return mListaDTO
    End Function

End Class
