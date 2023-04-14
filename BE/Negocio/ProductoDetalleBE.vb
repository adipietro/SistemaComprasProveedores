Public Class ProductoDetalleBE
    Inherits ID

    Sub New()

    End Sub

    Public Property Proveedor As ProveedorBE
    Public Property Producto As ProductoBE
    Public Property Precio As Double
    Public Property DescuentoCantidad As Integer
    Public Property CantidadDescuento As Integer


    'Public Overrides Function ToString() As String
    '    Return Me.ID
    'End Function

End Class
