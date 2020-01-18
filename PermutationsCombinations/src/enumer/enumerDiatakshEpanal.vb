Friend Class enumerDiatakshEpanal
    Inherits enumerEpanallhptikos


    Sub New(ByVal n As Integer, ByVal k As Integer)
        MyBase.New(n, k)
    End Sub

    Protected Overrides Function MoveNextCore() As Boolean
        Dim i As Integer = Me._k - 1
        While i >= 0 AndAlso Me._current(i) >= Me._n - 1
            i -= 1
        End While
        If i < 0 Then
            Return False
        Else
            Me._current(i) += 1
            For j = i + 1 To Me._k - 1
                Me._current(j) = 0
            Next
            Return True
        End If
    End Function

End Class
