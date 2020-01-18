Module Module2
    Public Function synd_NM(ByVal m As Integer, ByVal n As Integer) As Integer()()
        If (m < 1) Or (n < 1) Then Throw New ArgumentOutOfRangeException
        m = System.Math.Min(m, n)
        n = System.Math.Max(m, n)
        Dim postab As New List(Of Integer())
        Dim i, j, k, fores As Integer
        Dim pos(m - 1) As Integer
        For i = 0 To m - 1
            pos(i) = i + 1
        Next
        Dim bool As Boolean = True
        Do While bool
            fores += 1
            postab.Add(pos.ToArray())
            pos(m - 1) += 1
            j = m - 1
            Do While j >= 1
                If pos(j) > n - m + 1 + j Then
                    pos(j - 1) += 1
                    k = 0
                    Do While j + k < m
                        pos(j + k) = pos(j + k - 1) + 1
                        k += 1
                    Loop
                End If
                j -= 1
            Loop
            bool = (pos(m - 1) < n + 1)
        Loop
        Return postab.ToArray
    End Function
End Module
