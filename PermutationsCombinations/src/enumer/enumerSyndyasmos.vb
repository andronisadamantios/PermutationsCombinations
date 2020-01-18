Friend Class enumerSyndyasmos
    Inherits enumerBase


    Sub New(ByVal n As Integer, ByVal k As Integer)
        MyBase.New(n, k)
    End Sub

    Protected Overrides Function MoveNextCore() As Boolean

        ' vres teleutaia thesi pou den einai sto maximum ths
        Dim a As Integer = -1
        For i = Me._k - 1 To 0 Step -1
            If Me._current(i) < Me._n - Me._k + i Then
                a = i
                Exit For
            End If
        Next

        If a = -1 Then
            Return False
        Else
            Me._current(a) += 1
            For i = a + 1 To Me._k - 1
                Me._current(i) = Me._current(i - 1) + 1
            Next
            Return True
        End If
    End Function

End Class
