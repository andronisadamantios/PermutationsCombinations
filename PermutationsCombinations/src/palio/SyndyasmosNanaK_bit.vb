Public Class SyndyasmosNanaK_bit
    Implements IEnumerable(Of Integer())

    Public Shared Function [get](ByVal n As Integer, ByVal k As Integer) As SyndyasmosNanaK_bit
        If n < k Then
            Throw New ArgumentOutOfRangeException
        End If
        Return New SyndyasmosNanaK_bit(n, k)
    End Function


    Private _n As Integer
    Private _k As Integer

    Sub New(ByVal n As Integer, ByVal k As Integer)
        Me._n = n
        Me._k = k
    End Sub

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Integer()) Implements System.Collections.Generic.IEnumerable(Of Integer()).GetEnumerator
        Return New Enumerator_SyndyasmosNanaK_bit(Me)
    End Function

    Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function

    Class Enumerator_SyndyasmosNanaK_bit
        Implements IEnumerator(Of Integer())

        Private _owner As SyndyasmosNanaK_bit
        Private _currentState As ULong        ' bit mask, 1s einai ta selected, 0s ta not selected kai ta not used        ' mporei na exei mexri k 1s kai 64-k 0s
        Private _finished As Boolean
        Private _fores As Long

        Sub New(ByVal s As SyndyasmosNanaK_bit)
            Me._owner = s
            Me._finished = False
            Me._fores = 0
        End Sub

        Public ReadOnly Property Current() As Integer() Implements System.Collections.Generic.IEnumerator(Of Integer()).Current
            Get
                Throw New NotImplementedException
            End Get
        End Property

        ReadOnly Property Current1() As Object Implements System.Collections.IEnumerator.Current
            Get
                Return Me.Current
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext

        End Function

        Public Sub Reset() Implements System.Collections.IEnumerator.Reset

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



End Class
