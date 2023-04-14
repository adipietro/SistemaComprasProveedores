Imports BE

Public Class bitacoraDAL

    Private Shared Function CargarBE(pbitacora As BE.Bitacora, pRow As DataRow) As BE.Bitacora
        ' pbitacora.ID = pRow("id_bitacora")
        pbitacora.accion = pRow("Accion")
        pbitacora.fecha = pRow("fecha")
        pbitacora.usuario = New UsuarioBE
        pbitacora.usuario.ID = pRow("id_usuario")
        pbitacora.usuario.nombre = pRow("Usuario")
      

        Return pbitacora
    End Function


    Public Shared Function Obtenerbitacora(pID As Integer) As BE.Bitacora
        Dim mbitacora As New BE.Bitacora
        Dim mCommand As String = "SELECT * FROM bitacora2 WHERE id_bitacora = " & pID

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                mbitacora = CargarBE(mbitacora, mDataSet.Tables(0).Rows(0))
                Return mbitacora
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - BitacoraDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pbitacora As BE.Bitacora)
        Dim mCommand As String = "INSERT INTO bitacora2(accion, fecha, usuario, id_usuario)" &
                                 "VALUES ('" & pbitacora.accion & "', '" & pbitacora.fecha & "', '" & pbitacora.usuario.nombre & "', '" & pbitacora.usuario.ID & "') "

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - bitacora")
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Function Listarbitacora() As List(Of BE.Bitacora)
        Dim mLista As New List(Of BE.Bitacora)
        Dim mCommand As String = "SELECT * FROM bitacora2"
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim mbitacora As New BE.Bitacora

                    mbitacora = CargarBE(mbitacora, mRow)

                    mLista.Add(mbitacora)
                Next

                Return mLista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - bitacoraDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function




End Class
