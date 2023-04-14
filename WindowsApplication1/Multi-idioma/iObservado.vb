Public Interface iObservado
    ReadOnly Property Registrados As List(Of iObservador)
    Sub Registrar(pObservador As iObservador)
    Sub Notificar()

End Interface
