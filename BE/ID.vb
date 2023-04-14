Public MustInherit Class ID
    Public Property ID As Integer


    ' -- Quiero que dos objetos con igual ID caigan en el mismo Bucket del HashSet
    Public Overrides Function GetHashCode() As Integer
        Return ID
    End Function

    ' -- Cuando compare objetos en HashSet, quiero asegurarme de que sean del mismo tipo y que tengan el mismo valir de ID.
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj.GetType() = Me.GetType() Then
            Return Me.ID = DirectCast(obj, ID).ID
        End If
        Return False
    End Function

    Public Overrides Function ToString() As String
        Return Me.ID
    End Function


End Class
