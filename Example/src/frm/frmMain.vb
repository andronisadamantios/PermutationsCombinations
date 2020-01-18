Imports PermutationsCombinations
Imports System.Windows.Forms

Public Class frmMain

    Private Shared MAX_LB_ITMES As Integer = 10000

    Private _n, _k As Integer
    Private _ef As EF

    Private Property n() As Integer
        Get
            If Me._n = 0 Then
                Me._n = CInt(Me.nudN.Value)
            End If
            Return Me._n
        End Get
        Set(ByVal value As Integer)
            If Me._n <> value Then
                Me._n = value
                Me.updateDetails()
            End If
        End Set
    End Property
    Private Property k() As Integer
        Get
            If Me._k = 0 Then
                Me._k = CInt(Me.nudK.Value)
            End If
            Return Me._k
        End Get
        Set(ByVal value As Integer)
            If value <> Me._k Then
                Me._k = value
                Me.updateDetails()
            End If
        End Set
    End Property
    Private Property ef() As EF
        Get
            If Me._ef Is Nothing Then
                Me.ef = PermutationsCombinations.EF.get(False, False)
            End If
            Return Me._ef
        End Get
        Set(ByVal value As EF)
            If Not Object.ReferenceEquals(value, Me._ef) Then
                Me._ef = value
                Me.updateDetails()
            End If
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler cbOrder.CheckedChanged, AddressOf cb_CheckedChanged
        AddHandler cbRepetition.CheckedChanged, AddressOf cb_CheckedChanged
        AddHandler nudN.ValueChanged, AddressOf nudN_ValueChanged
        AddHandler nudK.ValueChanged, AddressOf nudK_ValueChanged

    End Sub

    ' todo: write mathimatika
    Private Sub updateDetails()
        Me.txtName.Text = Me.ef.Onoma
        If Not Me.ef.IsValidNK(Me.n, Me.k) Then
            Me.txtCount.Text = "invalid input"
        ElseIf Me.ef.IsBigNK(Me.n, Me.k) Then
            Me.txtCount.Text = "too big to calculate"
        Else
            Me.txtCount.Text = Me.ef.CalculateCount(Me.n, Me.k).ToString
        End If
        Me.gbIndexing.Enabled = Me.ef.IsIndexingImplemented(Me.n, Me.k)
    End Sub


    Private Sub btnListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListAll.Click
        Try
            Me.ef.CheckNK(Me.n, Me.k)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

        Dim ul As ULong = 0UL
        If Me.ef.IsBigNK(Me.n, Me.k) Then
            MessageBox.Show(String.Format("cannot calculate {0} for n = {1}, k = {2}", Me.ef.Onoma, Me.n, Me.k), "huge number", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        Else
            ul = Me.ef.CalculateCount(Me.n, Me.k).Value
            If ul > MAX_LB_ITMES Then
                MessageBox.Show(ul.ToString("g"), "big number", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            End If
        End If


        Me.lb.Items.Clear()
        Me.lb.BeginUpdate()
        Dim it = Me.ef.getEnumerator(Me.n, Me.k)
        Dim c = CInt(Math.Min(ul, MAX_LB_ITMES))
        Dim strFmt = "{0," + c.ToString.Length.ToString + "}|" + vbTab + "{1}"
        Dim i = 0
        While i < c And it.MoveNext
            i += 1
            Me.lb.Items.Add(String.Format(strFmt, i, ArrayToString(it.Current)))
        End While
        Me.lb.EndUpdate()
    End Sub

    Private Sub cb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ef = ef.get(Me.cbOrder.Checked, Me.cbRepetition.Checked)
    End Sub

    Private Sub nudN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.n = CInt(Me.nudN.Value)
    End Sub

    Private Sub nudK_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.k = CInt(Me.nudK.Value)
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.updateDetails()
    End Sub

    Private Sub txtIndex_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIndex.TextChanged
        If Not Me.ef.IsIndexingImplemented(Me.n, Me.k) Then
            'MessageBox.Show(String.Format(My.Resources.IndexingNotImplementedFor, Me.ef.Onoma, Me.n, Me.k))
            Return
        End If
        Dim index As ULong = 0
        If ULong.TryParse(Me.txtIndex.Text, index) Then
            Dim ar As Integer()
            Try
                ar = Me.ef.GetElementAt(Me.n, Me.k, index)
            Catch ex As Exception
                Dim strMsg As String = String.Format(My.Resources.CouldNotFindElementAt, New Object() {index, Me.ef.Onoma, Me.n, Me.k})
                MessageBox.Show(strMsg, My.Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return
            End Try
            Me.txtResult.Text = ArrayToString(ar)
        Else
            'MessageBox.Show("Wrong Input. Number Expected.", My.Resources.WrongInput, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If
    End Sub
End Class