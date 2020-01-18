
Friend Class EFsyndyasmos
    Inherits EFnotRepetitive


    Public Shared Shadows ReadOnly instance As New EFsyndyasmos

    Protected Sub New()
    End Sub
    Public Overrides ReadOnly Property IsSeiraImportant() As Boolean
        Get
            Return False
        End Get
    End Property

    Protected Overrides Function calculateCountCore(ByVal n As Integer, ByVal k As Integer) As ULong
        Return Counts.Syndyasmos(n, k)
    End Function

    ''' <summary>
    ''' combinadic
    ''' </summary>
    ''' <param name="ul"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Combinadic(ByVal n As Integer, ByVal k As Integer, ByVal ul As ULong) As Integer()
        Dim result(0 To k - 1) As Integer
        Dim i As Integer = n
        Dim j As Integer = k
        Dim c As ULong
        While j > 0
            Do
                i -= 1
                If i < j Then
                    c = 0
                Else
                    c = Me.CalculateCount(i, j).Value
                End If
            Loop While c > ul
            result(k - j) = i
            ul -= c
            j -= 1
        End While
        Return result
    End Function

    Protected Overrides Function GetElementAtCore(ByVal n As Integer, ByVal k As Integer, ByVal ul As ULong) As Integer()
        Dim a = Me.CalculateCount(n, k)
        Dim dual = CULng(a - ul - 1)
        Dim cDual = Combinadic(n, k, dual)
        For i = 0 To k - 1
            cDual(i) = n - 1 - cDual(i)
        Next
        Return cDual
    End Function

    Protected Overrides Function getEnumeratorCore(ByVal n As Integer, ByVal k As Integer) As enumeratorBase
        Return New enumerator(Me, n, k)
    End Function

    Private Shadows Class enumerator
        Inherits enumeratorBase


        Sub New(ByVal ef As EF, ByVal n As Integer, ByVal k As Integer)
            MyBase.New(ef, n, k)
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

End Class