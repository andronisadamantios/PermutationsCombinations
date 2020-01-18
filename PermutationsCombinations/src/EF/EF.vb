''' <summary>
''' Enumerator Factory
''' factory class that creates <see cref="enumeratorBase"></see>
''' </summary>
''' <remarks></remarks>
Public MustInherit Class EF


    Public Shared ReadOnly oles As EF() = New EF() {EFdiataksh.instance, EFepanalDiataksh.instance, EFsyndyasmos.instance, EFepanalSyndyasmos.instance}

    Public Shared ReadOnly diataksh As EF = EFdiataksh.instance
    Public Shared ReadOnly epanalDiataksh As EF = EFepanalDiataksh.instance
    Public Shared ReadOnly syndyasmos As EF = EFsyndyasmos.instance
    Public Shared ReadOnly epanalSyndyasmos As EF = EFepanalSyndyasmos.instance

    Public Shared Function [get](ByVal IsSeiraImportant As Boolean, ByVal AreDuplicatesAllowed As Boolean) As EF
        If IsSeiraImportant Then
            If AreDuplicatesAllowed Then
                Return EFepanalDiataksh.instance
            Else
                Return EFdiataksh.instance
            End If
        Else
            If AreDuplicatesAllowed Then
                Return EFepanalSyndyasmos.instance
            Else
                Return EFsyndyasmos.instance
            End If
        End If
    End Function



    Public Overridable ReadOnly Property Onoma() As String
        Get
            Return My.Resources.ResourceManager.GetString(Me.GetType.Name, My.Application.Culture)
        End Get
    End Property

    Public MustOverride ReadOnly Property IsSeiraImportant() As Boolean

    Public MustOverride ReadOnly Property AreDuplicatesAllowed() As Boolean


    Protected Sub New()

    End Sub


    Public Overridable Function IsValidNK(ByVal n As Integer, ByVal k As Integer) As Boolean
        Return (n > 0 AndAlso k > 0)
    End Function

    Public Overridable Sub CheckNK(ByVal n As Integer, ByVal k As Integer)
        If Not Me.IsValidNK(n, k) Then
            Throw New Exception("must be n > 0 , k > 0")
        End If
    End Sub

    Public Function IsIndexingImplemented(ByVal n As Integer, ByVal k As Integer) As Boolean
        Dim b1 = TypeOf Me Is EFsyndyasmos OrElse (TypeOf Me Is EFdiataksh AndAlso n = k)
        Dim b2 As Boolean = True
        Try
            Me.GetElementAt(n, k, 0)
        Catch
            b2 = False
        End Try
        'Trace.Assert(b1 = b2)
        Return b1
    End Function

    Public Function GetElementAt(ByVal n As Integer, ByVal k As Integer, ByVal ul As ULong) As Integer()
        If ul < 0 OrElse ul > Me.CalculateCount(n, k) - 1 Then
            Throw New ArgumentOutOfRangeException("invalid index")
        End If
        Return GetElementAtCore(n, k, ul)
    End Function
    Protected MustOverride Function GetElementAtCore(ByVal n As Integer, ByVal k As Integer, ByVal ul As ULong) As Integer()



    Public Function getEnumerator(ByVal n As Integer, ByVal k As Integer) As enumeratorBase
        Me.CheckNK(n, k)
        Return getEnumeratorCore(n, k)
    End Function

    Protected MustOverride Function getEnumeratorCore(ByVal n As Integer, ByVal k As Integer) As enumeratorBase


    Public Function IsBigNK(ByVal n As Integer, ByVal k As Integer) As Boolean
        Try
            Me.calculateCountCore(n, k)
        Catch ex As OverflowException
            Return True
        End Try
        Return False
    End Function

    Public Function CalculateCount(ByVal n As Integer, ByVal k As Integer) As ULong?
        If IsBigNK(n, k) Then
            Return Nothing
        Else
            Return Me.calculateCountCore(n, k)
        End If
    End Function

    ''' <summary>
    ''' Ο τύπος υπολογισμού του πλήθος των συνδυασμών ή διατάξεων
    ''' </summary>
    ''' <param name="n"></param>
    ''' <param name="k"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function calculateCountCore(ByVal n As Integer, ByVal k As Integer) As ULong




End Class