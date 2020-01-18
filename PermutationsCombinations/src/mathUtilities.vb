Module mathUtilities


    Public Function PartialFactorial(ByVal n As Integer, ByVal k As Integer) As ULong
        If n < 0 Or k < 0 Or k > n Then
            Throw New ArgumentOutOfRangeException
        ElseIf n = 0 Or k = 0 Then
            Return 1
        End If
        Dim result As ULong = CULng(1)
        Dim a As ULong = CULng(n)
        For i = 1 To k
            result *= a
            a -= CULng(1)
        Next
        Return result
    End Function

    Public Function Factorial(ByVal n As Integer) As ULong
        If n < 0 Then
            Throw New ArgumentOutOfRangeException
        ElseIf n = 0 Then
            Return 1
        End If
        Dim result As ULong = CULng(1)
        Dim a As ULong = CULng(n)
        For i = 1 To n
            result *= a
            a -= CULng(1)
        Next
        Return result
    End Function

    Public Function DywnymoCount2(ByVal n As Integer, ByVal k As Integer) As ULong
        '' todo: 
        Return CULng(mathUtilities.Factorial(n) / (mathUtilities.Factorial(k) * mathUtilities.Factorial(n - k)))
    End Function
    Public Function BinomialCount(ByVal n As Integer, ByVal k As Integer) As ULong
        If n < 0 Or k < 0 Or n < k Then
            Throw New ArgumentOutOfRangeException
        ElseIf n = 0 Or k = 0 Then
            Return 1
        End If

        Dim a = Enumerable.Range(1, n)
        Dim b = Enumerable.Range(1, k)
        Dim c = Enumerable.Range(1, n - k)
        Dim d = Enumerable.Union(b, c)
        Dim e = Enumerable.Intersect(b, c)
        Dim f = a.Except(d)

        Dim onomasths = f
        Dim paronomasths = e

        For Each lmnt In paronomasths
            Dim lmnt1 = lmnt
            Dim g = onomasths.FirstOrDefault(Function(l) l Mod lmnt1 = 0)
            If g <> 0 Then
                paronomasths = paronomasths.Except(New Integer() {lmnt1})
                onomasths = onomasths.Except(New Integer() {g})
                onomasths = onomasths.Union(New Integer() {g \ lmnt1})
            End If
        Next

        Dim o = If(onomasths.Count = 0, 1UL, onomasths.Aggregate(CULng(1), Function(l, i) l * CULng(i)))
        Dim p = If(paronomasths.Count = 0, 1UL, paronomasths.Aggregate(CULng(1), Function(l, i) l * CULng(i)))
        Return CULng(o / p)
    End Function

    Public Function Power(ByVal b As Integer, ByVal p As Integer) As Long
        If b = 0 Then
            Return 0
        ElseIf p = 0 Then
            Return 1
        End If
        Dim result As Long = CLng(b)
        Dim ap = System.Math.Abs(p)
        For i = 2 To ap
            result *= b
        Next

        If p > 0 Then
            Return result
        Else
            Return -result
        End If
    End Function


    Public Function MaxPos(ByVal ar As Integer()) As Integer
        MaxPos = 0
        Dim max As Integer = ar(MaxPos)
        For i = 1 To ar.GetUpperBound(0)
            If ar(i) > max Then
                MaxPos = i
            End If
        Next
    End Function



End Module
