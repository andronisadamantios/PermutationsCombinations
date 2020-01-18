Public MustInherit Class EFRepetitive
    Inherits EF



    Public Overrides ReadOnly Property AreDuplicatesAllowed() As Boolean
        Get
            Return True
        End Get
    End Property


    Protected Overrides Function GetElementAtCore(ByVal n As Integer, ByVal k As Integer, ByVal ul As ULong) As Integer()
        Throw New NotImplementedException("indexing not available for epanallhptika")
    End Function

End Class
