Imports System.Data.SqlClient
Imports BE
Public Class IdiomaDAL


    Private Shared Function CargarBE(pidioma As BE.IdiomaBE, pRow As DataRow) As BE.IdiomaBE
        pidioma.id_idioma = pRow("id_idioma")
        pidioma.nombre = pRow("Nombre")

        cargardiccionario(pidioma.diccionario, DiccionarioDAL.Listardiccionarios(pidioma.id_idioma))
        Return pidioma
    End Function


    Public Shared Function ObtenerIdioma(pid As Integer) As BE.IdiomaBE
        Dim midioma As New BE.IdiomaBE
        Dim mCommand As String = "SELECT id_idioma, nombre FROM idioma WHERE id_idioma LIKE  @pID"
        Dim sqlParams() As SqlParameter = New SqlParameter() _
            {
                 New SqlParameter("@pID", pid)
            }

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand, sqlParams)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                midioma = CargarBE(midioma, mDataSet.Tables(0).Rows(0))
                Return midioma
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet -IdiomaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(pidioma As BE.IdiomaBE)
        Dim params() As SqlParameter
        Dim mCommand As String = "INSERT INTO idioma( nombre)" &
                                 "VALUES (@pNombre);"

        params = New SqlParameter() _
                {
                     New SqlParameter("@pNombre", pidioma.nombre)
                }

        Try
            Conexion.ExecuteNonQuery(mCommand, params)

            mCommand = "SELECT ID_IDIOMA FROM IDIOMA WHERE NOMBRE = @pNombre"
            params = New SqlParameter() _
                {
                     New SqlParameter("@pNombre", pidioma.nombre)
                }

            Dim idNuevoIdioma As Integer = Conexion.ExecuteScalar(mCommand, params)

            For Each mitem In pidioma.diccionario
                mCommand = "select id_diccionario from diccionario where clave = @pClave"
                params = New SqlParameter() _
                {
                     New SqlParameter("@pClave", mitem.Key)
                }

                Dim idDiccionario As Integer = Conexion.ExecuteScalar(mCommand, params)

                Dim diccionario As New BE.Diccionario
                diccionario.id_idioma = idNuevoIdioma
                diccionario.id_diccionario = idDiccionario
                diccionario.valor = mitem.Value

                DiccionarioDAL.GuardarNuevo(diccionario)
            Next
        Catch ex As Exception
            MsgBox("Error - Nuevo - IdiomaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    'Modifica un registro de la tabla idioma
    Public Shared Sub GuardarModificacion(pidioma As BE.IdiomaBE)
        Dim mCommand As String = "update idioma_diccionario set valor = @pValor " &
                                 "From diccionario d inner Join idioma_diccionario id on d.id_diccionario = id.id_diccionario" &
                                 " Where id.id_idioma = @pIdIdioma And d.clave = @pClave"
        Try
            For Each dicPalabra As KeyValuePair(Of String, String) In pidioma.diccionario

                Dim params() As SqlParameter = New SqlParameter() _
                {
                     New SqlParameter("@pValor", dicPalabra.Value),
                     New SqlParameter("@pIdIdioma", pidioma.id_idioma),
                     New SqlParameter("@pClave", dicPalabra.Key)
                }
                Conexion.ExecuteNonQuery(mCommand, params)
            Next

        Catch ex As Exception
            MsgBox("Error - Modificacion - idiomaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    'Elimina un registro de la tabla Idioma
    Public Shared Sub Eliminar(pidioma As BE.IdiomaBE)
        Dim mCommand As String = "DELETE FROM Idioma WHERE id_idioma = @pIdIdioma"
        Dim params() As SqlParameter = New SqlParameter() _
                {
                     New SqlParameter("@pIdIdioma", pidioma.id_idioma)
                }

        Try
            DiccionarioDAL.Eliminar(pidioma.id_idioma)
            Conexion.ExecuteNonQuery(mCommand, params)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - idiomaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    'Devuelve una lista de objetos be.idioma con los datos de cada registro de la tabla idioma
    Public Shared Function ListarIdiomas() As List(Of BE.IdiomaBE)
        Dim mLista As New List(Of BE.IdiomaBE)
        Dim mCommand As String = "SELECT id_idioma, nombre FROM idioma"
        Dim mDataSet As DataSet

        Try
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim midioma As New BE.IdiomaBE

                    midioma = CargarBE(midioma, mRow)

                    mLista.Add(midioma)
                Next

                Return mLista
            Else
                Return New List(Of IdiomaBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - IdiomaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub cargardiccionario(ByRef pdiccionario As Dictionary(Of String, String), plista As List(Of BE.Diccionario))
        Dim mcommand As String = "select id.id_idioma , d.clave, id.valor" &
                                    " From diccionario d inner Join idioma_diccionario id on d.id_diccionario = id.id_diccionario" &
                                    " Where id.id_idioma = @pIdIdioma"

        Dim params() As SqlParameter = New SqlParameter() _
                {
                     New SqlParameter("@pIdIdioma", If(plista.Count() > 0, plista(0).id_idioma, 1))
                }


        Dim mdataset As DataSet
        Dim dic As New Dictionary(Of String, String)

        Try
            mdataset = Conexion.ExecuteDataSet(mcommand, params)

            If Not IsNothing(mdataset) And mdataset.Tables.Count > 0 And mdataset.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mdataset.Tables(0).Rows

                    'dic.Add(String.Format("{0}-{1}", mRow(0), mRow(1)), mRow(2))
                    dic.Add(mRow(1), mRow(2))
                Next

                pdiccionario = dic
            End If
        Catch ex As Exception
            MsgBox("Error - cargardiccionario - idiomaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
