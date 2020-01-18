Public Class FactoryEnumer

    Public Sub create(ByVal IsSeiraImportant As Boolean, ByVal AreDuplicatesAllowed As Boolean, ByVal n As Integer, ByVal k As Integer)
        If IsSeiraImportant Then
            If AreDuplicatesAllowed Then
                Return New enumerDiatakshEpanal(n, k)
            Else
                Return New enumerDiataksh(n, k)
            End If
        Else
            If AreDuplicatesAllowed Then
                Return New enumerSyndyasmosEpanal(n, k)
            Else
                Return New enumerSyndyasmos(n, k)
            End If
        End If
    End Sub

End Class
