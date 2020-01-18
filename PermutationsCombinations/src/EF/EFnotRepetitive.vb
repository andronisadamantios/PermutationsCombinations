Public MustInherit Class EFnotRepetitive
    Inherits EF

    Public Overrides ReadOnly Property AreDuplicatesAllowed() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Function IsValidNK(ByVal n As Integer, ByVal k As Integer) As Boolean
        Return MyBase.IsValidNK(n, k) AndAlso n >= k
    End Function

    Public Overrides Sub CheckNK(ByVal n As Integer, ByVal k As Integer)
        MyBase.CheckNK(n, k)
        If n < k Then
            Throw New ArgumentException("must be n >= k")
        End If
    End Sub


End Class
