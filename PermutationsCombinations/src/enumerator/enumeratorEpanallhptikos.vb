
Friend MustInherit Class enumeratorEpanallhptikos
    Inherits enumeratorBase


    Sub New(ByVal ef As EF, ByVal n As Integer, ByVal k As Integer)
        MyBase.new(ef, n, k)
    End Sub



    Protected Overrides Sub setFirst()
        For i = 0 To Me._k - 1
            Me._current(i) = 0
        Next
    End Sub

End Class


