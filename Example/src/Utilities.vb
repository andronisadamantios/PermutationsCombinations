Module Utilities


    Public IndexBase As PermutationsCombinations.IndexBase = PermutationsCombinations.IndexBase.based0

    Public Function ArrayToString(ByVal ar As Integer(), Optional ByVal maxDigits As Integer = 5) As String
        Return String.Join(" ", ar.Select(Function(i123) String.Format("{0," + maxDigits.ToString + "}", i123 + Utilities.IndexBase)).ToArray)
    End Function

End Module
