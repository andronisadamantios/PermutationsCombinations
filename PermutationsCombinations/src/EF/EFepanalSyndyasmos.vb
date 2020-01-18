Friend Class EFepanalSyndyasmos
    Inherits EFRepetitive



    Public Shared Shadows ReadOnly instance As New EFepanalSyndyasmos

    Private Sub New()
    End Sub

    Public Overrides ReadOnly Property Onoma() As String
        Get
            Return MyBase.Onoma
        End Get
    End Property

    Public Overrides ReadOnly Property IsSeiraImportant() As Boolean
        Get
            Return False
        End Get
    End Property


    Protected Overrides Function calculateCountCore(ByVal n As Integer, ByVal k As Integer) As ULong
        Return Counts.EpanalSyndyasmos(n, k)
    End Function

    Protected Overrides Function getEnumeratorCore(ByVal n As Integer, ByVal k As Integer) As enumeratorBase
        Return New enumerator(Me, n, k)
    End Function

    Private Shadows Class enumerator
        Inherits enumeratorEpanallhptikos

        Sub New(ByVal ef As EF, ByVal n As Integer, ByVal k As Integer)
            MyBase.new(ef, n, k)
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
                    Me._current(j) = Me._current(i)
                Next
                Return True
            End If
        End Function

    End Class


End Class