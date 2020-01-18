
Friend Class EFdiataksh
    Inherits EFnotRepetitive



    Public Shared Shadows ReadOnly instance As New EFdiataksh

    Protected Sub New()
    End Sub
    Public Overrides ReadOnly Property IsSeiraImportant() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides Function GetElementAtCore(ByVal n As Integer, ByVal k As Integer, ByVal ul As ULong) As Integer()
        If n <> k Then
            Throw New InvalidOperationException("indexing for diataksh works only for n = k (metathesh)")
        End If
        Dim result(0 To k - 1) As Integer
        Dim f = Me.factoradic(n, k, ul)
        Dim list = Enumerable.Range(0, k).ToList
        For i = 0 To k - 1
            result(i) = list.Item(f(i))
            list.RemoveAt(f(i))
        Next
        Return result
    End Function
    Private Function factoradic(ByVal n As Integer, ByVal k As Integer, ByVal ul As ULong) As Integer()
        Dim result(0 To k - 1) As Integer
        Dim i As Integer = k - 1
        Dim j As ULong = 1

        While ul > 0
            result(i) = CInt(ul Mod j)
            ul = ul \ j
            i -= 1
            j += 1UL
        End While

        Return result
    End Function

    Protected Overrides Function calculateCountCore(ByVal n As Integer, ByVal k As Integer) As ULong
        Return Counts.Diataksh(n, k)
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
            Dim index As Integer = Me._k - 1
            While index >= 0
                ' vres to teleutaio kai prospathise na to aukshseis kata 1
                Dim last As Integer = Me._current(index) + 1
                Dim j As Integer = 0
                ' den prepei na kseperasei to me._n -1 kai an vrethei se prohgoumenh thesh (h aukshmenh kata 1 timh) prepei na ksanaukshthei kai na ksanarxisei apo thn arxh to psaksimo
                While last <= Me._n - 1 AndAlso j < index
                    If Me._current(j) = last Then
                        last += 1
                        j = -1              ' gia na ginei 0 meta to if kai na ksanarxisei apo thn arxh to psaksimo
                    End If
                    j += 1
                End While

                ' an to lastNew den einai egkyro shmainei oti den mporei na aukshthei h thesh se auto to index kai epanalmvanetai h diadikasia gia to prohgoumeno index
                If last <= Me._n - 1 Then
                    ' an einai tote, kataxwreitai h timh
                    Me._current(index) = last

                    Dim a As Integer = 0        ' h timh twn epomenwn thesewn
                    ' gia oles tis epomenes theseis, prepei na mpoune kainouries times kata auksousa seira ... 
                    For i = index + 1 To Me._k - 1
                        Dim k As Integer = 0
                        ' pou na mhn yparxoun se oles tis prohgoumenes apo thn KATHE thesi
                        While k < i
                            If Me._current(k) = a Then
                                a += 1
                                k = -1      ' gia na ginei 0 meta to if kai na ksanarxisei apo thn arxh to psaksimo
                            End If
                            k += 1
                        End While
                        Me._current(i) = a
                    Next
                    Return True
                End If

                index -= 1
            End While
            Return False
        End Function


    End Class


End Class

