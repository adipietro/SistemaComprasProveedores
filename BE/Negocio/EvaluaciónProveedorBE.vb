Public Class EvaluaciónProveedorBE

    Inherits ID

    Public Property Proveedor As BE.ProveedorBE
    Public Property CalificacionTiempos As Integer
    Public Property CalificacionAtencion As Integer
    Public Property CalificacionComunicacion As Integer
    Public Property CalificacionCalidad As Integer
    Public Property Cantidad As Integer
    Public Property Fecha As String


    Public Function Promedio() As Double
        Dim prom = ((CalificacionTiempos + CalificacionComunicacion + CalificacionCalidad + CalificacionAtencion) / 4)
        Return prom
    End Function

    Sub New()

    End Sub

End Class
