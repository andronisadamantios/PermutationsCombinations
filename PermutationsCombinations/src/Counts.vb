Module Counts
    '' (n)
    '' (k)
    Public Function Syndyasmos(ByVal n As Integer, ByVal k As Integer) As ULong
        Return mathUtilities.BinomialCount(n, k)
    End Function
    '' (n)_k
    Public Function Diataksh(ByVal n As Integer, ByVal k As Integer) As ULong
        Return mathUtilities.PartialFactorial(n, k)
    End Function
    '' [n]
    '' [k]
    Public Function EpanalSyndyasmos(ByVal n As Integer, ByVal k As Integer) As ULong
        Return mathUtilities.BinomialCount(n + k - 1, k)
    End Function
    '' n^k
    Public Function EpanalDiataksh(ByVal n As Integer, ByVal k As Integer) As ULong
        'Return CULng(System.Math.Pow(Me._n, Me._k))
        Return CULng(mathUtilities.Power(n, k))
    End Function
End Module
