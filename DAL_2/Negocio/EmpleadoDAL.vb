
Imports System.Data.SqlClient
Imports BE


Public Class EmpleadoDAL


    Public Shared Function CargarBE(EmpleadoBE As Empleado, pRow As DataRow) As Empleado
        EmpleadoBE.ID = pRow("Id_Empleado")
        EmpleadoBE.nombre = pRow("Nombre")
        EmpleadoBE.Apellido = pRow("Apellido")
        EmpleadoBE.Cargo = pRow("Cargo")
        EmpleadoBE.Area = New AreaBE
        EmpleadoBE.Area.Nombre = Convert.ToString(pRow("NombreArea"))
        Return EmpleadoBE
    End Function


    Public Shared Function ObtenerEmpleado(ID As Integer) As BE.Empleado
        Dim EmpleadoBE As New Empleado
        Dim mCommand As String = "SELECT * FROM Empleado WHERE Id_Empleado = ID"

        Try
            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                EmpleadoBE = CargarBE(EmpleadoBE, mDataSet.Tables(0).Rows(0))
                Return EmpleadoBE
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error - DataSet - EmpleadoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Sub GuardarNuevo(EmpleadoBE As Empleado)
        Dim mCommand As String = String.Empty


        mCommand = "INSERT INTO Empleado (Nombre, Apellido, NombreArea, Id_Area, Cargo) VALUES ('" & EmpleadoBE.nombre & "','" & EmpleadoBE.Apellido & "','" & EmpleadoBE.Area.Nombre & "','" & EmpleadoBE.Area.ID & "','" & EmpleadoBE.Cargo & "'); SELECT @@Identity"

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - AreaDAL")
            MsgBox(ex.Message)
        End Try


    End Sub


    Public Shared Sub GuardarModificacion(EmpleadoBE As Empleado)
        Dim mCommand As String = String.Empty

        mCommand = "UPDATE Empleado SET Nombre = '" & EmpleadoBE.nombre &
                     "',Apellido = '" & EmpleadoBE.Apellido &
                    "',Id_Area = '" & EmpleadoBE.Area.ID &
                    "',NombreArea = '" & EmpleadoBE.Area.Nombre &
                    "',Cargo = '" & EmpleadoBE.Cargo &
                    "'Where Id_Empleado = " & EmpleadoBE.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - EmpleadoDAL")
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Shared Sub Eliminar(EmpleadoBE As Empleado)
        Dim mCommand As String = "DELETE FROM Empleado WHERE Id_Empleado = " & EmpleadoBE.ID

        Try
            Conexion.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - EmpleadoDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listar() As List(Of Empleado)
        Dim mLista As New List(Of Empleado)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet

        Try
            mCommand = "SELECT * FROM Empleado"
            mDataSet = Conexion.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim Empleado As New Empleado

                    Empleado = CargarBE(Empleado, mRow)

                    mLista.Add(Empleado)
                Next

                Return mLista
            Else
                Return New List(Of Empleado)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - EmpleadoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function ListarEspecial(Area As String) As List(Of Empleado)
        Dim mLista As New List(Of Empleado)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet

        Try
            mCommand = "SELECT * FROM Empleado WHERE NombreArea = '" & Area & "'"
            mDataSet = Conexion.ExecuteDataSet(mCommand)


            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim Empleado As New Empleado

                    Empleado = CargarBE(Empleado, mRow)

                    mLista.Add(Empleado)
                Next

                Return mLista
            Else
                Return New List(Of Empleado)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - EmpleadoDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
