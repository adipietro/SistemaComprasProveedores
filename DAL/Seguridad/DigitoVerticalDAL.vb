Public Class digitoverticalDAL
    Public Shared Sub GuardarDigito(pTabla As String, pDigito As String)
        Dim mCommand As String = "insert into digitovertical(nombretabla, digito, fecha) values('" & pTabla & "', '" & pDigito & "', '" & Date.Now.Date.ToString("yyy-MM-dd") & "')"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - digitovertical")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Sub ModificarDigito(pTabla As String, pDigito As String)
        Dim mCommand As String = "update digitovertical set digito = '" & pDigito & "', fecha = '" & Date.Now.Date.ToString("yyyy-MM-dd") & "' where nombretabla like '" & pTabla & "'"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificar - digitovertical")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Obtenerdigitovertical(pTabla As String) As String
        Dim mdigitovertical As Integer
        Dim mDataSet As DataSet
        Dim mCommand As String = "select digito from DigitoVertical where nombretabla like '" & pTabla & "'"

        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) Then
                If mDataSet.Tables.Count > 0 Then
                    If mDataSet.Tables(0).Rows.Count > 0 Then
                        mdigitovertical = mDataSet.Tables(0).Rows(0)("digito")
                    End If
                End If
            End If

            Return mdigitovertical
        Catch ex As Exception
            MsgBox("Error - Obtener - digitovertical")
            MsgBox(ex.Message)

            Return Nothing
        End Try
    End Function
End Class