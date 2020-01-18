<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.sc = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gbIndexing = New System.Windows.Forms.GroupBox
        Me.tlpIndexing = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtIndex = New System.Windows.Forms.TextBox
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.tlpNameCount = New System.Windows.Forms.TableLayoutPanel
        Me.lblName = New System.Windows.Forms.Label
        Me.lblCount = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtCount = New System.Windows.Forms.TextBox
        Me.tlpInput = New System.Windows.Forms.TableLayoutPanel
        Me.lblN = New System.Windows.Forms.Label
        Me.lblK = New System.Windows.Forms.Label
        Me.lblOrder = New System.Windows.Forms.Label
        Me.lblRepetition = New System.Windows.Forms.Label
        Me.cbOrder = New System.Windows.Forms.CheckBox
        Me.cbRepetition = New System.Windows.Forms.CheckBox
        Me.nudN = New System.Windows.Forms.NumericUpDown
        Me.nudK = New System.Windows.Forms.NumericUpDown
        Me.lb = New System.Windows.Forms.ListBox
        Me.btnListAll = New System.Windows.Forms.Button
        Me.sc.Panel1.SuspendLayout()
        Me.sc.Panel2.SuspendLayout()
        Me.sc.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbIndexing.SuspendLayout()
        Me.tlpIndexing.SuspendLayout()
        Me.tlpNameCount.SuspendLayout()
        Me.tlpInput.SuspendLayout()
        CType(Me.nudN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sc
        '
        resources.ApplyResources(Me.sc, "sc")
        Me.sc.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.sc.Name = "sc"
        '
        'sc.Panel1
        '
        Me.sc.Panel1.Controls.Add(Me.Panel1)
        Me.sc.Panel1.Controls.Add(Me.tlpInput)
        resources.ApplyResources(Me.sc.Panel1, "sc.Panel1")
        '
        'sc.Panel2
        '
        Me.sc.Panel2.Controls.Add(Me.lb)
        Me.sc.Panel2.Controls.Add(Me.btnListAll)
        resources.ApplyResources(Me.sc.Panel2, "sc.Panel2")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gbIndexing)
        Me.Panel1.Controls.Add(Me.tlpNameCount)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'gbIndexing
        '
        resources.ApplyResources(Me.gbIndexing, "gbIndexing")
        Me.gbIndexing.Controls.Add(Me.tlpIndexing)
        Me.gbIndexing.Name = "gbIndexing"
        Me.gbIndexing.TabStop = False
        '
        'tlpIndexing
        '
        resources.ApplyResources(Me.tlpIndexing, "tlpIndexing")
        Me.tlpIndexing.Controls.Add(Me.Label1, 0, 0)
        Me.tlpIndexing.Controls.Add(Me.Label2, 0, 1)
        Me.tlpIndexing.Controls.Add(Me.txtIndex, 1, 0)
        Me.tlpIndexing.Controls.Add(Me.txtResult, 1, 1)
        Me.tlpIndexing.Name = "tlpIndexing"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtIndex
        '
        resources.ApplyResources(Me.txtIndex, "txtIndex")
        Me.txtIndex.Name = "txtIndex"
        '
        'txtResult
        '
        resources.ApplyResources(Me.txtResult, "txtResult")
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        '
        'tlpNameCount
        '
        resources.ApplyResources(Me.tlpNameCount, "tlpNameCount")
        Me.tlpNameCount.Controls.Add(Me.lblName, 0, 0)
        Me.tlpNameCount.Controls.Add(Me.lblCount, 0, 1)
        Me.tlpNameCount.Controls.Add(Me.txtName, 1, 0)
        Me.tlpNameCount.Controls.Add(Me.txtCount, 1, 1)
        Me.tlpNameCount.Name = "tlpNameCount"
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'lblCount
        '
        resources.ApplyResources(Me.lblCount, "lblCount")
        Me.lblCount.Name = "lblCount"
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        '
        'txtCount
        '
        resources.ApplyResources(Me.txtCount, "txtCount")
        Me.txtCount.Name = "txtCount"
        Me.txtCount.ReadOnly = True
        '
        'tlpInput
        '
        resources.ApplyResources(Me.tlpInput, "tlpInput")
        Me.tlpInput.Controls.Add(Me.lblN, 0, 0)
        Me.tlpInput.Controls.Add(Me.lblK, 0, 1)
        Me.tlpInput.Controls.Add(Me.lblOrder, 0, 2)
        Me.tlpInput.Controls.Add(Me.lblRepetition, 0, 3)
        Me.tlpInput.Controls.Add(Me.cbOrder, 1, 2)
        Me.tlpInput.Controls.Add(Me.cbRepetition, 1, 3)
        Me.tlpInput.Controls.Add(Me.nudN, 1, 0)
        Me.tlpInput.Controls.Add(Me.nudK, 1, 1)
        Me.tlpInput.Name = "tlpInput"
        '
        'lblN
        '
        resources.ApplyResources(Me.lblN, "lblN")
        Me.lblN.Name = "lblN"
        '
        'lblK
        '
        resources.ApplyResources(Me.lblK, "lblK")
        Me.lblK.Name = "lblK"
        '
        'lblOrder
        '
        resources.ApplyResources(Me.lblOrder, "lblOrder")
        Me.lblOrder.Name = "lblOrder"
        '
        'lblRepetition
        '
        resources.ApplyResources(Me.lblRepetition, "lblRepetition")
        Me.lblRepetition.Name = "lblRepetition"
        '
        'cbOrder
        '
        resources.ApplyResources(Me.cbOrder, "cbOrder")
        Me.cbOrder.Name = "cbOrder"
        Me.cbOrder.UseVisualStyleBackColor = True
        '
        'cbRepetition
        '
        resources.ApplyResources(Me.cbRepetition, "cbRepetition")
        Me.cbRepetition.Name = "cbRepetition"
        Me.cbRepetition.UseVisualStyleBackColor = True
        '
        'nudN
        '
        resources.ApplyResources(Me.nudN, "nudN")
        Me.nudN.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.nudN.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudN.Name = "nudN"
        Me.nudN.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'nudK
        '
        resources.ApplyResources(Me.nudK, "nudK")
        Me.nudK.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.nudK.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudK.Name = "nudK"
        Me.nudK.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'lb
        '
        resources.ApplyResources(Me.lb, "lb")
        Me.lb.FormattingEnabled = True
        Me.lb.Name = "lb"
        '
        'btnListAll
        '
        resources.ApplyResources(Me.btnListAll, "btnListAll")
        Me.btnListAll.Name = "btnListAll"
        Me.btnListAll.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.sc)
        Me.Name = "frmMain"
        Me.sc.Panel1.ResumeLayout(False)
        Me.sc.Panel1.PerformLayout()
        Me.sc.Panel2.ResumeLayout(False)
        Me.sc.Panel2.PerformLayout()
        Me.sc.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gbIndexing.ResumeLayout(False)
        Me.gbIndexing.PerformLayout()
        Me.tlpIndexing.ResumeLayout(False)
        Me.tlpIndexing.PerformLayout()
        Me.tlpNameCount.ResumeLayout(False)
        Me.tlpNameCount.PerformLayout()
        Me.tlpInput.ResumeLayout(False)
        Me.tlpInput.PerformLayout()
        CType(Me.nudN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpInput As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblN As System.Windows.Forms.Label
    Friend WithEvents lblK As System.Windows.Forms.Label
    Friend WithEvents lblOrder As System.Windows.Forms.Label
    Friend WithEvents lblRepetition As System.Windows.Forms.Label
    Friend WithEvents cbOrder As System.Windows.Forms.CheckBox
    Friend WithEvents cbRepetition As System.Windows.Forms.CheckBox
    Friend WithEvents nudN As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudK As System.Windows.Forms.NumericUpDown
    Friend WithEvents lb As System.Windows.Forms.ListBox
    Friend WithEvents btnListAll As System.Windows.Forms.Button
    Friend WithEvents tlpNameCount As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents sc As System.Windows.Forms.SplitContainer
    Friend WithEvents tlpIndexing As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents gbIndexing As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
