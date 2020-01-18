
Friend MustInherit Class enumerEpanallhptikos
    Inherits enumerBase


    Sub New(ByVal n As Integer, ByVal k As Integer)
        MyBase.new(n, k)
    End Sub



    Protected Overrides Sub setFirst()
        For i = 0 To Me._k - 1
            Me._current(i) = 0
        Next
    End Sub

End Class


