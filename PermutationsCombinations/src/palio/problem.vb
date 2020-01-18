Imports PermutationsCombinations

Public Class problem
    Private _solution As enumeratorBase

    Public question As String
    Public n, k As Integer
    Public seiraImportant, canMoreThanOne As Boolean

    Public ReadOnly Property solution() As enumeratorBase
        Get
            If Me._solution Is Nothing Then
                Me._solution = EF.get(Me.seiraImportant, Me.canMoreThanOne).getEnumerator(Me.n, Me.k)
            End If
            Return Me._solution
        End Get
    End Property
End Class