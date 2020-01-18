
''' <summary>
''' a class that iterates all the permutations or combinations for given n, k
''' </summary>
''' <remarks></remarks>
Public MustInherit Class enumeratorBase
    Implements IEnumerator(Of Integer()), IEnumerable(Of Integer())


    Protected _ef As EF
    Private _finished As Boolean
    Private _fores As ULong     'posothta
    Private _count As ULong     'posothta
    Protected _n As Integer     'posothta
    Protected _k As Integer     'posothta
    Protected _current As Integer()


    Public ReadOnly Property n() As Integer
        Get
            Return Me._n
        End Get
    End Property
    Public ReadOnly Property k() As Integer
        Get
            Return Me._k
        End Get
    End Property
    Public ReadOnly Property EF() As EF
        Get
            Return Me._ef
        End Get
    End Property

    Public ReadOnly Property EnumeratedCount() As ULong
        Get
            Return Me._fores
        End Get
    End Property

    Public ReadOnly Property MustBeAlwaysTrueWhenFinished() As Boolean
        Get
            Return Me._finished AndAlso (Me.EnumeratedCount = Me.Count)
        End Get
    End Property


    Protected Sub New(ByVal ef As EF, ByVal n As Integer, ByVal k As Integer)
        Me._ef = ef
        Me._n = n
        Me._k = k
        Me.Reset()
    End Sub


    Public ReadOnly Property Count() As ULong
        Get
            If Me._count = 0 Then
                Me._count = Me._ef.CalculateCount(Me._n, Me._k).Value
            End If
            Return Me._count
        End Get
    End Property

    Protected Overridable Sub setFirst()
        For i = 0 To Me._k - 1
            Me._current(i) = i
        Next
    End Sub

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Integer()) Implements System.Collections.Generic.IEnumerable(Of Integer()).GetEnumerator
        Return Me
    End Function

    Private Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return Me.GetEnumerator
    End Function

    Public ReadOnly Property Current() As Integer() Implements IEnumerator(Of Integer()).Current
        Get
            If Me._finished Then
                Throw New InvalidOperationException
            End If
            Dim a = CType(Array.CreateInstance(GetType(Integer), Me._k), Integer())
            Array.Copy(Me._current, a, Me._current.Length)
            Return a
        End Get
    End Property

    Private ReadOnly Property Current1() As Object Implements System.Collections.IEnumerator.Current
        Get
            Return Me.Current
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        If Me._finished Then
            Throw New InvalidOperationException
        ElseIf Me._fores = 0 Then
            Me.setFirst()
            Me._fores = 1
            Return True
        Else
            Me._finished = Not Me.MoveNextCore
            If Not Me._finished Then
                Me._fores += CULng(1)
            End If
            Return Not Me._finished
        End If
    End Function

    Protected MustOverride Function MoveNextCore() As Boolean



    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me._fores = 0
        Me._finished = False
        Me._current = CType(Array.CreateInstance(GetType(Integer), Me._k), Integer())
    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


End Class



