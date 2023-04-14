Imports DAL
Imports BE

Public Class EvaluacionBLL
    
    Sub New()

    End Sub

    Sub New(evaluacion As String)
        CargarPropiedades(evaluacion)
    End Sub

    Private Sub CargarPropiedades(evaluacion As String)
        Dim mBE As BE.EvaluaciónProveedorBE = EvaluacionDAL.ObtenerEvaluacion(evaluacion)
    End Sub

    Public Sub Guardar(eBE As BE.EvaluaciónProveedorBE)
        EvaluacionDAL.GuardarNuevo(eBE)
    End Sub

    Public Sub Eliminar(evBE As BE.EvaluaciónProveedorBE)
        EvaluacionDAL.Eliminar(evBE)
    End Sub

    Public Sub EliminarPorProveedor(evBE As BE.EvaluaciónProveedorBE)
        EvaluacionDAL.EliminarPorProveedor(evBE)
    End Sub

    Public Function ListarSimple() As List(Of EvaluaciónProveedorBE)
        Return EvaluacionDAL.ListarSimple
    End Function

    Public Function ListarTodas() As List(Of EvaluaciónProveedorBE)
        Return EvaluacionDAL.ListarTodas
    End Function

    Public Function Listar(proveedor As BE.ProveedorBE) As List(Of EvaluaciónProveedorBE)
        Dim mlista As List(Of BE.EvaluaciónProveedorBE) = EvaluacionDAL.Listar(proveedor)
        Dim ev As New BE.EvaluaciónProveedorBE
        mlista.Add(ev)

        Return mlista
    End Function


End Class
