Imports PermutationsCombinations

Public Module Module1


    Sub main()

        Dim langs = New String() {"el-GR"}
        Dim languages = New String() {"Greek"}
        Dim strChoice = CStr(ConsoleExtra.SelectFromList(languages, "Epilekse glosa" + vbCrLf))
        Dim strC As String = "el-GR"
        strC = langs(fixIndexInput(Array.IndexOf(languages, strChoice)))


        My.Application.ChangeCulture(strC)
        ConsoleExtra.fixConsole()


        Dim tests As New LinkedList(Of System.Action)(New System.Action() {AddressOf testAplo, AddressOf testHowMany, AddressOf testInteractive, AddressOf testThe999999999999thElement})
        Dim t = tests.First

        ConsoleExtra.PressEnterToContinue("PRESS ENTER TO START", True)

        Utilities.IndexBase = ConsoleExtra.SelectFromList(Of PermutationsCombinations.IndexBase)("select index base" + vbTab)

        While t IsNot Nothing
            t.Value.Invoke()
            If t.Next IsNot Nothing Then
                ConsoleExtra.PressEnterToContinue("PRESS ENTER FOR NEXT TEST", True)
            End If
            t = t.Next
        End While
        ConsoleExtra.PressEnterToContinue("PRESS ENTER FOR EXIT", True)

    End Sub



    Sub testAplo()
        For Each lmnt In EF.oles.ToList()
            Console.WriteLine(lmnt.Onoma + vbTab + "Aplo paradeigma (n=5, k=3)" + " (with" + If(lmnt.AreDuplicatesAllowed, "", "out") + " repetition)" + ":")
            Dim i As Integer = 0
            For Each ar In lmnt.getEnumerator(5, 3)
                i += 1
                Console.WriteLine(vbTab + vbTab + "{0})" + vbTab + ArrayToString(ar), i)
            Next
            ConsoleExtra.PressEnterToContinue(vbTab + "PRESS ENTER FOR NEXT", True)
        Next
    End Sub

    Sub testHowMany()

        Console.WriteLine("Example problems where the count of the iteration is to be found" + vbCrLf)

        Dim p1 As New problem With {.question = My.Resources.q1, .seiraImportant = True, .canMoreThanOne = False, .n = 6, .k = 6}
        Dim p2 As New problem With {.question = My.Resources.q2, .seiraImportant = False, .canMoreThanOne = False, .n = 7, .k = 5}
        Dim p3 As New problem With {.question = My.Resources.q3, .seiraImportant = True, .canMoreThanOne = True, .n = 10, .k = 6}
        Dim p4 As New problem With {.question = My.Resources.q4, .seiraImportant = False, .canMoreThanOne = True, .n = 10, .k = 6}

        Dim ps As New LinkedList(Of problem)(New problem() {p1, p2, p3, p4})
        Dim p = ps.First
        While p IsNot Nothing
            Console.WriteLine(vbTab + "problem: {0}", p.Value.question)
            Console.WriteLine(vbTab + "solution: {0}, count: {1}", p.Value.solution.EF.Onoma, p.Value.solution.Count)
            If p.Next IsNot Nothing Then
                ConsoleExtra.PressEnterToContinue(vbTab + "PRESS ENTER FOR NEXT PROBLEM" + vbCrLf)
            End If
            p = p.Next
        End While
    End Sub

    Sub testInteractive()
        If CStr(ConsoleExtra.SelectFromList(New String() {"Console", "Form"}, "Console or Form?")).Equals("console", StringComparison.InvariantCultureIgnoreCase) Then
            testInteractiveConsole()
        Else
            Dim frm As New frmMain
            frm.ShowDialog()
        End If
    End Sub

    Sub testInteractiveConsole()

        Dim n As Integer = CInt(ConsoleExtra.GetAkeraio(Nothing, 0, 300))
        Console.WriteLine("n = {0}", n)
        Dim k As Integer = CInt(ConsoleExtra.GetAkeraio(Nothing, 0, 300))
        Console.WriteLine("k = {0}", k)
        Dim seiraImportant As Boolean = ConsoleExtra.NaiOxi("einai h seira important?" + vbTab)
        Dim canMoreThanOne As Boolean = ConsoleExtra.NaiOxi("epitrepetai h epanallhpsh?" + vbTab)

        Dim ef = PermutationsCombinations.EF.get(seiraImportant, canMoreThanOne)
        Dim a = ef.getEnumerator(n, k)


        Dim c As ULong = ULong.MaxValue
        Try
            c = a.Count
            Console.WriteLine("plhthos:" + vbTab + c.ToString)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        If ef.IsIndexingImplemented(n, k) Then
            Dim x As UInteger = CUInt(ConsoleExtra.GetAkeraio("choose an index of the iteration (mexri Long.MaxValue): ", CInt(Utilities.IndexBase), CLng(c - 1 + Utilities.IndexBase)))
            Try
                Console.WriteLine("the element of the iteration at index {0} is {1}", x, ArrayToString(ef.GetElementAt(n, k, x)))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End If

        If c < 150 AndAlso ConsoleExtra.NaiOxi(String.Format("display all elements ({0})?" + vbTab, a.Count)) Then
            a.ToList.Select(Function(ar123, i123) String.Format("{0}|" + vbTab + "{1}", i123, ArrayToString(ar123))) _
            .ToList.ForEach(AddressOf Console.WriteLine)
        End If

    End Sub

    Sub testThe999999999999thElement()

        Console.WriteLine("When an iteration is big, an element with also hube index can be found using combinadic (for combinations) and factoradic (for permutations).")
        Console.WriteLine("Only implemented for non repetitive combinations and permutations.")
        Console.WriteLine("In the case of permutation (using factoradic) it is implemented only for n==k (metathesh)")

        Dim ul As ULong = 999999999999UL

        Dim metathesh = EF.diataksh : Dim n1 = 20 : Dim k1 = 20
        Dim combination = EF.syndyasmos : Dim n2 = 200 : Dim k2 = 10

        Console.Write("The 999999999999th Element of {0} for n={1} and k={2}:" + vbTab, metathesh.Onoma, n1, k1)
        Console.WriteLine(ArrayToString(metathesh.GetElementAt(n1, k1, ul)))
        Console.Write("The 999999999999th Element of {0} for n={1} and k={2}:" + vbTab, combination.Onoma, n1, k1)
        Console.WriteLine(ArrayToString(combination.GetElementAt(n2, k2, ul)))

        Console.WriteLine("They start with 0, 1, 2. 999999999999th element is close to the beginning of the iteration.")

    End Sub



    Public Function getIter(ByVal seiraImportant As Boolean, ByVal canMoreThanOne As Boolean, ByVal n As Integer, ByVal k As Integer) As enumeratorBase
        Return EF.get(seiraImportant, canMoreThanOne).getEnumerator(n, k)
    End Function

    Private Function fixIndexOutput(ByVal ar As Integer()) As Integer()
        If Utilities.IndexBase = PermutationsCombinations.IndexBase.based1 Then
            For i = 0 To ar.GetUpperBound(0)
                ar(i) += 1
            Next
        End If
        Return ar
    End Function

    Private Function fixIndexInput(ByVal i As Integer) As Integer
        If Utilities.IndexBase = PermutationsCombinations.IndexBase.based1 Then
            i -= 1
        End If
        Return i
    End Function

End Module
