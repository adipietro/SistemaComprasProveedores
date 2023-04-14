Imports System.Data.SqlClient
Imports BE
Public Class PatenteDAL


    Private Shared Function CargarBE(ByRef Ppatente As PatenteAbsBE, pRow As DataRow)
        Ppatente.ID = pRow("patente_id")
        Ppatente.nombre = pRow("Nombre")
        If Ppatente.GetType() = GetType(BE.PatenteBE) Then
            Dim pat = DirectCast(Ppatente, PatenteBE)
            If TypeOf (pRow("formulario")) Is DBNull Then
                pat.formulario = ""
            Else
                pat.formulario = pRow("Formulario")
                pat.menu = pRow("Menu")
            End If
        End If
    End Function

    Public Shared Function proximoID() As Integer
        Return Conexion.ExecuteScalar("Select isnull (max(patente_id), 0) from patente")
    End Function


    Public Shared Function Obtenerpatente(pID As Integer) As PatenteBE
        Dim Mpatente As New PatenteBE
        Dim mCommand As String = "SELECT * FROM patente WHERE patente_id = " & pID

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                Mpatente = CargarBE(Mpatente, mDataSet.Tables(0).Rows(0))
                Return Mpatente
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - patenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    ' Publico
    Public Shared Sub GuardarNuevo(Ppatente As BE.PatenteBE)
        Dim mCommand As String = ""


        mCommand = "INSERT INTO patente(nombre, formulario) " &
                    "VALUES ('" & Ppatente.nombre & "' , '" & Ppatente.formulario & "');"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - PatenteDAL")
            MsgBox(ex.Message)
        End Try


    End Sub

    ' Publico
    Public Shared Sub GuardarModificacion(Ppatente As BE.PatenteBE)
        Dim mCommand As String = ""

        mCommand = "UPDATE Patente SET " &
                                                    "patente_id = " & Ppatente.ID &
                                 ", Nombre = '" & Ppatente.nombre &
                                 "', Formulario = '" & Ppatente.formulario &
                                  " WHERE patente_id = " & Ppatente.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - PatenteDAL")
            MsgBox(ex.Message)
        End Try


    End Sub

    ' Publico
    'Public Shared Sub Eliminar(Ppatente As BE.PatenteAbsBE)
    '    Dim mCommand As String = ""

    '    If TypeOf (Ppatente) Is PatenteBE Then
    '        mCommand = "DELETE FROM Patente WHERE patente_id = " & Ppatente.id
    '    ElseIf TypeOf (Ppatente) Is GrupoPatenteBE Then
    '        For Each mPermiso As PatenteAbsBE In CType(Ppatente, GrupoPatenteBE).listapatentes
    '            Eliminar(mPermiso)
    '        Next
    '        familiaGrupoPatenteDAL.EliminarPorPatente(Ppatente.id)
    '        mCommand = "DELETE FROM GrupoPatente WHERE GrupoPatente_id = " & Ppatente.id
    '    End If

    '    Try
    '        Conexion.ExecuteNonQuery(mCommand)
    '    Catch ex As Exception
    '        MsgBox("Error - Eliminacion - PatenteDAL")
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    ' Publico

    Public Shared Function listarPatentesPatente(gPatente As GrupoPatenteBE) As HashSet(Of PatenteAbsBE)
        Dim mLista As New HashSet(Of BE.PatenteAbsBE)
        Dim mCommand As String = ""
        Dim mDataSet As DataSet

        Try
            mCommand = "select p.* from PatentePatente as pp, Patente as p where pp.patente_id_hijo = p.Patente_Id and pp.patente_id_padre =" & gPatente.ID & ""
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim patente As PatenteAbsBE
                    If mRow("Tipo") = "F" Then
                        Dim grupoPatente As New GrupoPatenteBE
                        CargarBE(grupoPatente, mRow)
                        grupoPatente.Patentes = listarPatentesPatente(grupoPatente)
                        patente = grupoPatente
                    Else
                        patente = New PatenteBE
                        CargarBE(patente, mRow)
                    End If
                    mLista.Add(patente)
                Next

                Return mLista
            Else
                Return New HashSet(Of BE.PatenteAbsBE)
            End If
        Catch ex As Exception
            MsgBox("Error - listarPatentesPatente - PatentesDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Shared Function listarPatentesUsuario(usuarioSeleccionado As UsuarioBE) As HashSet(Of PatenteAbsBE)
        Dim mLista As New HashSet(Of BE.PatenteAbsBE)
        Dim mCommand As String = ""
        Dim mDataSet As DataSet

        Try
            mCommand = "select p.* from UsuarioPatente as u, Patente as p where u.patente_id = p.Patente_Id and u.usuario_id = " & usuarioSeleccionado.ID & ""
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim patente As PatenteAbsBE
                    If mRow("Tipo") = "F" Then
                        Dim grupoPatente As New GrupoPatenteBE
                        CargarBE(grupoPatente, mRow)
                        grupoPatente.Patentes = listarPatentesPatente(grupoPatente)
                        patente = grupoPatente
                    Else
                        patente = New PatenteBE
                        CargarBE(patente, mRow)
                    End If
                    mLista.Add(patente)
                Next

                Return mLista
            Else
                Return New HashSet(Of BE.PatenteAbsBE)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
            MsgBox("Error - listarPatentesUsuario - PatenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function listarPatentesTotales() As HashSet(Of PatenteAbsBE)
        Dim mLista As New HashSet(Of BE.PatenteAbsBE)
        Dim mCommand As String = ""
        Dim mDataSet As DataSet

        Try
            mCommand = "select p.* from   Patente as p"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim patente As PatenteAbsBE
                    If mRow("Tipo") = "F" Then
                        Dim grupoPatente As New GrupoPatenteBE
                        CargarBE(grupoPatente, mRow)
                        grupoPatente.Patentes = listarPatentesPatente(grupoPatente)
                        patente = grupoPatente
                    Else
                        patente = New PatenteBE
                        CargarBE(patente, mRow)
                    End If
                    mLista.Add(patente)
                Next

                Return mLista
            Else
                Return New HashSet(Of BE.PatenteAbsBE)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
            MsgBox("Error - listarPatentesTotales - PatenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function listarPatentesDeGrupoPatente(grupo_patente As BE.GrupoPatenteBE) As HashSet(Of PatenteAbsBE)
        Dim mLista As New HashSet(Of BE.PatenteAbsBE)
        Dim mCommand As String = ""
        Dim mDataSet As DataSet

        Try
            mCommand = "select p.* from Patente as p, PatentePatente pp where pp.patente_id_hijo = p.patente_id and pp.patente_id_padre = '" & grupo_patente.ID & "';"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim patente As PatenteAbsBE
                    If mRow("Tipo") = "F" Then
                        Dim grupoPatente As New GrupoPatenteBE
                        CargarBE(grupoPatente, mRow)
                        grupoPatente.Patentes = listarPatentesPatente(grupoPatente)
                        patente = grupoPatente
                    Else
                        patente = New PatenteBE
                        CargarBE(patente, mRow)
                    End If
                    mLista.Add(patente)
                Next

                Return mLista
            Else
                Return New HashSet(Of BE.PatenteAbsBE)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
            MsgBox("Error - listarTodosGruposPatentes - PatenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function listarTodosGruposPatentes() As HashSet(Of BE.GrupoPatenteBE)
        Dim mLista As New HashSet(Of BE.GrupoPatenteBE)
        Dim mCommand As String = ""
        Dim mDataSet As DataSet

        Try
            mCommand = "select p.* from Patente as p where Tipo ='F';"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim patente As PatenteAbsBE
                    If mRow("Tipo") = "F" Then
                        Dim grupoPatente As New GrupoPatenteBE
                        CargarBE(grupoPatente, mRow)
                        grupoPatente.Patentes = listarPatentesPatente(grupoPatente)
                        patente = grupoPatente
                    End If
                    mLista.Add(patente)
                Next

                Return mLista
            Else
                Return New HashSet(Of BE.GrupoPatenteBE)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
            MsgBox("Error - listarTodosGruposPatentes - PatenteDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function agregarPatenteAUsuario(usuario As BE.UsuarioBE, patente As BE.PatenteAbsBE) As Boolean
        Dim mCommand As String = ""

        mCommand = "INSERT INTO UsuarioPatente(usuario_id, patente_id) " &
                    "VALUES ('" & usuario.ID & "' , '" & patente.ID & "');"

        Try
            Conexion.ExecuteNonQuery(mCommand)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function removerPatenteAUsuario(usuario As BE.UsuarioBE, patente As BE.PatenteAbsBE) As Boolean
        Dim mCommand As String = ""

        mCommand = "DELETE FROM UsuarioPatente WHERE " &
                    " usuario_id =" & usuario.ID & " and patente_id =" & patente.ID & ";"

        Try
            Conexion.ExecuteNonQuery(mCommand)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Shared Sub altaDeGrupoPatente(nombre_patente As String)
        Dim mCommand As String = ""

        mCommand = "INSERT INTO Patente(Nombre, Tipo) " &
                    "VALUES ('" & nombre_patente & "' , 'F');"
        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function altaDePatente(nombre_patente As String, formulario As String, nombre_menu As String) As Boolean
        Dim mCommand As String = ""

        mCommand = "INSERT INTO Patente(Nombre, Formulario, Tipo, Menu) " &
                    "VALUES ('" & nombre_patente & "' , '" & formulario & "', 'P','" & nombre_menu & "');"

        Try
            Conexion.ExecuteNonQuery(mCommand)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Sub modificarPatentesHijas(patente_padre As BE.GrupoPatenteBE, patentes_hijas As HashSet(Of BE.PatenteAbsBE))
        eliminarPatentesHijas(patente_padre)
        insertarPatentesHijas(patente_padre, patentes_hijas)
    End Sub

    Public Shared Sub eliminarPatentesHijas(patente_padre As BE.PatenteAbsBE)
        Dim mCommand As String = ""

        mCommand = "DELETE FROM PatentePatente WHERE " &
                    " patente_id_padre =" & patente_padre.ID & ";"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub insertarPatentesHija(patente_padre As BE.GrupoPatenteBE, patente_hija As BE.PatenteAbsBE)
        Dim mCommand As String = ""

        mCommand = "INSERT INTO PatentePatente(patente_id_padre, patente_id_hijo) " &
                    "VALUES (" & patente_padre.ID & " , " & patente_hija.ID & ");"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub insertarPatentesHijas(patente_padre As BE.GrupoPatenteBE, patentes_hijas As HashSet(Of BE.PatenteAbsBE))
        For Each patente_hija In patentes_hijas
            insertarPatentesHija(patente_padre, patente_hija)
        Next
    End Sub
End Class
