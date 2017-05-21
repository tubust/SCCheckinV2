Imports Microsoft.Office.Interop.Outlook
Imports System.Data.SqlClient
Imports System.IO
Imports System


Public Class frmMain
    Inherits System.Windows.Forms.Form


#Region "Windows Form Designer generated code"

    'Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnl2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAnnDate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtFirst As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLast As System.Windows.Forms.TextBox
    Friend WithEvents txtFirst2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnl3 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents txt1Desc As System.Windows.Forms.TextBox
    Friend WithEvents txt2Desc As System.Windows.Forms.TextBox
    Friend WithEvents txt3Desc As System.Windows.Forms.TextBox
    Friend WithEvents txt4Desc As System.Windows.Forms.TextBox
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents cboType1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboType2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboType3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboType4 As System.Windows.Forms.ComboBox
    Friend WithEvents MemberCheckInCollectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lblHappyBDay As System.Windows.Forms.Label
    Friend WithEvents txtMemberID As System.Windows.Forms.TextBox
    Friend WithEvents cmdBalance As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents stbStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrStatus As System.Windows.Forms.Timer
    Friend WithEvents dteDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdPayments As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents lstMembers As System.Windows.Forms.ListBox
    Friend WithEvents txtReferredBy As System.Windows.Forms.TextBox
    Friend WithEvents btnReferrer As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboClass As System.Windows.Forms.ComboBox
    Friend WithEvents dteDate4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dteDate3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dteDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents cmdFeeAdjust As System.Windows.Forms.Button
    Friend WithEvents TableAdapterManager1 As SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ScCheckInDataSet1 As SCCheckIn.SCCheckInDataSet
    Friend WithEvents errCheck As System.Windows.Forms.ErrorProvider
    Friend WithEvents tabDanceType As System.Windows.Forms.TabControl
    Friend WithEvents tabSwing As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lstSwingActivity As System.Windows.Forms.ListBox
    Friend WithEvents lblReminder As System.Windows.Forms.Label
    Friend WithEvents cboPayment4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboPayment3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboPayment2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboPayment1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnKeyCard As System.Windows.Forms.Button
    Friend WithEvents btnMerchandise As System.Windows.Forms.Button
    Friend WithEvents tmrLogin As System.Windows.Forms.Timer
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.pnl1 = New System.Windows.Forms.Panel()
        Me.lstMembers = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFirst = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLast = New System.Windows.Forms.TextBox()
        Me.pnl2 = New System.Windows.Forms.Panel()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMemberID = New System.Windows.Forms.TextBox()
        Me.txtFirst2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAnnDate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblHappyBDay = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.pnl3 = New System.Windows.Forms.Panel()
        Me.cboPayment4 = New System.Windows.Forms.ComboBox()
        Me.cboPayment3 = New System.Windows.Forms.ComboBox()
        Me.cboPayment2 = New System.Windows.Forms.ComboBox()
        Me.cboPayment1 = New System.Windows.Forms.ComboBox()
        Me.dteDate4 = New System.Windows.Forms.DateTimePicker()
        Me.dteDate3 = New System.Windows.Forms.DateTimePicker()
        Me.dteDate2 = New System.Windows.Forms.DateTimePicker()
        Me.btnReferrer = New System.Windows.Forms.Button()
        Me.txtReferredBy = New System.Windows.Forms.TextBox()
        Me.dteDate1 = New System.Windows.Forms.DateTimePicker()
        Me.cboType4 = New System.Windows.Forms.ComboBox()
        Me.cboType3 = New System.Windows.Forms.ComboBox()
        Me.cboType2 = New System.Windows.Forms.ComboBox()
        Me.cboType1 = New System.Windows.Forms.ComboBox()
        Me.txt3Desc = New System.Windows.Forms.TextBox()
        Me.txt4Desc = New System.Windows.Forms.TextBox()
        Me.txt3 = New System.Windows.Forms.TextBox()
        Me.txt4 = New System.Windows.Forms.TextBox()
        Me.txt1Desc = New System.Windows.Forms.TextBox()
        Me.txt2Desc = New System.Windows.Forms.TextBox()
        Me.txt1 = New System.Windows.Forms.TextBox()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmdReport = New System.Windows.Forms.Button()
        Me.cmdBalance = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.stbStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrStatus = New System.Windows.Forms.Timer(Me.components)
        Me.cmdPayments = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.cmdFeeAdjust = New System.Windows.Forms.Button()
        Me.errCheck = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tabSwing = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lstSwingActivity = New System.Windows.Forms.ListBox()
        Me.tabDanceType = New System.Windows.Forms.TabControl()
        Me.lblReminder = New System.Windows.Forms.Label()
        Me.btnKeyCard = New System.Windows.Forms.Button()
        Me.btnMerchandise = New System.Windows.Forms.Button()
        Me.TableAdapterManager1 = New SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager()
        Me.ScCheckInDataSet1 = New SCCheckIn.SCCheckInDataSet()
        Me.MemberCheckInCollectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tmrLogin = New System.Windows.Forms.Timer(Me.components)
        Me.pnl1.SuspendLayout()
        Me.pnl2.SuspendLayout()
        Me.pnl3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.errCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSwing.SuspendLayout()
        Me.tabDanceType.SuspendLayout()
        CType(Me.ScCheckInDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemberCheckInCollectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNext
        '
        Me.cmdNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNext.Location = New System.Drawing.Point(954, 573)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(84, 28)
        Me.cmdNext.TabIndex = 4
        Me.cmdNext.Text = "&Next"
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(869, 573)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(84, 28)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "&Clear"
        '
        'pnl1
        '
        Me.pnl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnl1.Controls.Add(Me.lstMembers)
        Me.pnl1.Controls.Add(Me.Label3)
        Me.pnl1.Controls.Add(Me.txtFirst)
        Me.pnl1.Controls.Add(Me.Label2)
        Me.pnl1.Controls.Add(Me.Label1)
        Me.pnl1.Controls.Add(Me.txtLast)
        Me.pnl1.Location = New System.Drawing.Point(0, 0)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(374, 573)
        Me.pnl1.TabIndex = 0
        '
        'lstMembers
        '
        Me.lstMembers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstMembers.FormattingEnabled = True
        Me.lstMembers.ItemHeight = 18
        Me.lstMembers.Location = New System.Drawing.Point(3, 94)
        Me.lstMembers.Name = "lstMembers"
        Me.lstMembers.Size = New System.Drawing.Size(368, 472)
        Me.lstMembers.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Find Member:"
        '
        'txtFirst
        '
        Me.txtFirst.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFirst.Location = New System.Drawing.Point(128, 36)
        Me.txtFirst.MaxLength = 254
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(242, 24)
        Me.txtFirst.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(28, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Last Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(28, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "First Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLast
        '
        Me.txtLast.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLast.Location = New System.Drawing.Point(128, 64)
        Me.txtLast.MaxLength = 254
        Me.txtLast.Name = "txtLast"
        Me.txtLast.Size = New System.Drawing.Size(242, 24)
        Me.txtLast.TabIndex = 4
        '
        'pnl2
        '
        Me.pnl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl2.Controls.Add(Me.cboClass)
        Me.pnl2.Controls.Add(Me.Label5)
        Me.pnl2.Controls.Add(Me.txtMemberID)
        Me.pnl2.Controls.Add(Me.txtFirst2)
        Me.pnl2.Controls.Add(Me.Label10)
        Me.pnl2.Controls.Add(Me.txtAnnDate)
        Me.pnl2.Controls.Add(Me.Label7)
        Me.pnl2.Controls.Add(Me.Label6)
        Me.pnl2.Location = New System.Drawing.Point(376, 0)
        Me.pnl2.Name = "pnl2"
        Me.pnl2.Size = New System.Drawing.Size(660, 75)
        Me.pnl2.TabIndex = 1
        '
        'cboClass
        '
        Me.cboClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Location = New System.Drawing.Point(516, 42)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(141, 26)
        Me.cboClass.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(403, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 24)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Class:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMemberID
        '
        Me.txtMemberID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMemberID.Enabled = False
        Me.txtMemberID.Location = New System.Drawing.Point(323, 35)
        Me.txtMemberID.Name = "txtMemberID"
        Me.txtMemberID.Size = New System.Drawing.Size(61, 24)
        Me.txtMemberID.TabIndex = 10
        '
        'txtFirst2
        '
        Me.txtFirst2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFirst2.Enabled = False
        Me.txtFirst2.Location = New System.Drawing.Point(60, 35)
        Me.txtFirst2.Name = "txtFirst2"
        Me.txtFirst2.Size = New System.Drawing.Size(257, 24)
        Me.txtFirst2.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(6, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 24)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Name:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAnnDate
        '
        Me.txtAnnDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAnnDate.Enabled = False
        Me.txtAnnDate.Location = New System.Drawing.Point(515, 12)
        Me.txtAnnDate.Name = "txtAnnDate"
        Me.txtAnnDate.Size = New System.Drawing.Size(142, 24)
        Me.txtAnnDate.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Location = New System.Drawing.Point(403, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 24)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Anniversary:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 24)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Verify Member:"
        '
        'lblHappyBDay
        '
        Me.lblHappyBDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHappyBDay.ForeColor = System.Drawing.Color.Firebrick
        Me.lblHappyBDay.Location = New System.Drawing.Point(766, 105)
        Me.lblHappyBDay.Name = "lblHappyBDay"
        Me.lblHappyBDay.Size = New System.Drawing.Size(270, 30)
        Me.lblHappyBDay.TabIndex = 19
        '
        'lblNotes
        '
        Me.lblNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotes.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblNotes.Location = New System.Drawing.Point(766, 136)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(270, 284)
        Me.lblNotes.TabIndex = 20
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pnl3
        '
        Me.pnl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl3.Controls.Add(Me.cboPayment4)
        Me.pnl3.Controls.Add(Me.cboPayment3)
        Me.pnl3.Controls.Add(Me.cboPayment2)
        Me.pnl3.Controls.Add(Me.cboPayment1)
        Me.pnl3.Controls.Add(Me.dteDate4)
        Me.pnl3.Controls.Add(Me.dteDate3)
        Me.pnl3.Controls.Add(Me.dteDate2)
        Me.pnl3.Controls.Add(Me.btnReferrer)
        Me.pnl3.Controls.Add(Me.txtReferredBy)
        Me.pnl3.Controls.Add(Me.dteDate1)
        Me.pnl3.Controls.Add(Me.cboType4)
        Me.pnl3.Controls.Add(Me.cboType3)
        Me.pnl3.Controls.Add(Me.cboType2)
        Me.pnl3.Controls.Add(Me.cboType1)
        Me.pnl3.Controls.Add(Me.txt3Desc)
        Me.pnl3.Controls.Add(Me.txt4Desc)
        Me.pnl3.Controls.Add(Me.txt3)
        Me.pnl3.Controls.Add(Me.txt4)
        Me.pnl3.Controls.Add(Me.txt1Desc)
        Me.pnl3.Controls.Add(Me.txt2Desc)
        Me.pnl3.Controls.Add(Me.txt1)
        Me.pnl3.Controls.Add(Me.txt2)
        Me.pnl3.Controls.Add(Me.Label18)
        Me.pnl3.Location = New System.Drawing.Point(376, 420)
        Me.pnl3.Name = "pnl3"
        Me.pnl3.Size = New System.Drawing.Size(667, 153)
        Me.pnl3.TabIndex = 3
        '
        'cboPayment4
        '
        Me.cboPayment4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPayment4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayment4.Items.AddRange(New Object() {"Cash", "Check", "Credit Card"})
        Me.cboPayment4.Location = New System.Drawing.Point(546, 118)
        Me.cboPayment4.Name = "cboPayment4"
        Me.cboPayment4.Size = New System.Drawing.Size(111, 26)
        Me.cboPayment4.TabIndex = 22
        '
        'cboPayment3
        '
        Me.cboPayment3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPayment3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayment3.Items.AddRange(New Object() {"Cash", "Check", "Credit Card"})
        Me.cboPayment3.Location = New System.Drawing.Point(546, 90)
        Me.cboPayment3.Name = "cboPayment3"
        Me.cboPayment3.Size = New System.Drawing.Size(111, 26)
        Me.cboPayment3.TabIndex = 21
        '
        'cboPayment2
        '
        Me.cboPayment2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPayment2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayment2.Items.AddRange(New Object() {"Cash", "Check", "Credit Card"})
        Me.cboPayment2.Location = New System.Drawing.Point(546, 62)
        Me.cboPayment2.Name = "cboPayment2"
        Me.cboPayment2.Size = New System.Drawing.Size(111, 26)
        Me.cboPayment2.TabIndex = 20
        '
        'cboPayment1
        '
        Me.cboPayment1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPayment1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayment1.Items.AddRange(New Object() {"Cash", "Check", "Credit Card"})
        Me.cboPayment1.Location = New System.Drawing.Point(546, 34)
        Me.cboPayment1.Name = "cboPayment1"
        Me.cboPayment1.Size = New System.Drawing.Size(111, 26)
        Me.cboPayment1.TabIndex = 19
        '
        'dteDate4
        '
        Me.dteDate4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dteDate4.CustomFormat = "MM-dd-yy"
        Me.dteDate4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dteDate4.Location = New System.Drawing.Point(439, 120)
        Me.dteDate4.Name = "dteDate4"
        Me.dteDate4.Size = New System.Drawing.Size(103, 24)
        Me.dteDate4.TabIndex = 18
        '
        'dteDate3
        '
        Me.dteDate3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dteDate3.CustomFormat = "MM-dd-yy"
        Me.dteDate3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dteDate3.Location = New System.Drawing.Point(439, 90)
        Me.dteDate3.Name = "dteDate3"
        Me.dteDate3.Size = New System.Drawing.Size(103, 24)
        Me.dteDate3.TabIndex = 17
        '
        'dteDate2
        '
        Me.dteDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dteDate2.CustomFormat = "MM-dd-yy"
        Me.dteDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dteDate2.Location = New System.Drawing.Point(439, 62)
        Me.dteDate2.Name = "dteDate2"
        Me.dteDate2.Size = New System.Drawing.Size(103, 24)
        Me.dteDate2.TabIndex = 16
        '
        'btnReferrer
        '
        Me.btnReferrer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReferrer.Location = New System.Drawing.Point(439, 9)
        Me.btnReferrer.Name = "btnReferrer"
        Me.btnReferrer.Size = New System.Drawing.Size(31, 25)
        Me.btnReferrer.TabIndex = 15
        Me.btnReferrer.Text = "..."
        Me.btnReferrer.UseVisualStyleBackColor = True
        '
        'txtReferredBy
        '
        Me.txtReferredBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReferredBy.Location = New System.Drawing.Point(137, 9)
        Me.txtReferredBy.Name = "txtReferredBy"
        Me.txtReferredBy.Size = New System.Drawing.Size(296, 24)
        Me.txtReferredBy.TabIndex = 14
        '
        'dteDate1
        '
        Me.dteDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dteDate1.CustomFormat = "MM-dd-yy"
        Me.dteDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dteDate1.Location = New System.Drawing.Point(439, 34)
        Me.dteDate1.Name = "dteDate1"
        Me.dteDate1.Size = New System.Drawing.Size(103, 24)
        Me.dteDate1.TabIndex = 13
        '
        'cboType4
        '
        Me.cboType4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType4.Location = New System.Drawing.Point(8, 120)
        Me.cboType4.Name = "cboType4"
        Me.cboType4.Size = New System.Drawing.Size(123, 26)
        Me.cboType4.TabIndex = 10
        '
        'cboType3
        '
        Me.cboType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType3.Location = New System.Drawing.Point(8, 92)
        Me.cboType3.Name = "cboType3"
        Me.cboType3.Size = New System.Drawing.Size(123, 26)
        Me.cboType3.TabIndex = 7
        '
        'cboType2
        '
        Me.cboType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType2.Location = New System.Drawing.Point(8, 64)
        Me.cboType2.Name = "cboType2"
        Me.cboType2.Size = New System.Drawing.Size(123, 26)
        Me.cboType2.TabIndex = 4
        '
        'cboType1
        '
        Me.cboType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType1.Location = New System.Drawing.Point(8, 36)
        Me.cboType1.Name = "cboType1"
        Me.cboType1.Size = New System.Drawing.Size(123, 26)
        Me.cboType1.TabIndex = 1
        '
        'txt3Desc
        '
        Me.txt3Desc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt3Desc.Location = New System.Drawing.Point(137, 92)
        Me.txt3Desc.MaxLength = 50
        Me.txt3Desc.Name = "txt3Desc"
        Me.txt3Desc.Size = New System.Drawing.Size(205, 24)
        Me.txt3Desc.TabIndex = 8
        '
        'txt4Desc
        '
        Me.txt4Desc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt4Desc.Location = New System.Drawing.Point(137, 120)
        Me.txt4Desc.MaxLength = 50
        Me.txt4Desc.Name = "txt4Desc"
        Me.txt4Desc.Size = New System.Drawing.Size(205, 24)
        Me.txt4Desc.TabIndex = 11
        '
        'txt3
        '
        Me.txt3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt3.Location = New System.Drawing.Point(348, 92)
        Me.txt3.MaxLength = 7
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(85, 24)
        Me.txt3.TabIndex = 9
        '
        'txt4
        '
        Me.txt4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt4.Location = New System.Drawing.Point(348, 120)
        Me.txt4.MaxLength = 7
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(85, 24)
        Me.txt4.TabIndex = 12
        '
        'txt1Desc
        '
        Me.txt1Desc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt1Desc.Location = New System.Drawing.Point(137, 36)
        Me.txt1Desc.MaxLength = 50
        Me.txt1Desc.Name = "txt1Desc"
        Me.txt1Desc.Size = New System.Drawing.Size(205, 24)
        Me.txt1Desc.TabIndex = 2
        '
        'txt2Desc
        '
        Me.txt2Desc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt2Desc.Location = New System.Drawing.Point(137, 64)
        Me.txt2Desc.MaxLength = 50
        Me.txt2Desc.Name = "txt2Desc"
        Me.txt2Desc.Size = New System.Drawing.Size(205, 24)
        Me.txt2Desc.TabIndex = 5
        '
        'txt1
        '
        Me.txt1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt1.Location = New System.Drawing.Point(348, 36)
        Me.txt1.MaxLength = 7
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(85, 24)
        Me.txt1.TabIndex = 3
        '
        'txt2
        '
        Me.txt2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt2.Location = New System.Drawing.Point(348, 64)
        Me.txt2.MaxLength = 7
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(85, 24)
        Me.txt2.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(8, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(160, 24)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Referred By:"
        '
        'cmdReport
        '
        Me.cmdReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdReport.Location = New System.Drawing.Point(2, 574)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(84, 28)
        Me.cmdReport.TabIndex = 7
        Me.cmdReport.Text = "&Reports"
        '
        'cmdBalance
        '
        Me.cmdBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdBalance.Location = New System.Drawing.Point(92, 574)
        Me.cmdBalance.Name = "cmdBalance"
        Me.cmdBalance.Size = New System.Drawing.Size(84, 28)
        Me.cmdBalance.TabIndex = 8
        Me.cmdBalance.Text = "&Balance"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stbStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 605)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1036, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'stbStatus
        '
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.Size = New System.Drawing.Size(1021, 17)
        Me.stbStatus.Spring = True
        Me.stbStatus.Text = "Click Here to Log Off"
        Me.stbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrStatus
        '
        Me.tmrStatus.Enabled = True
        Me.tmrStatus.Interval = 1000
        '
        'cmdPayments
        '
        Me.cmdPayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPayments.Enabled = False
        Me.cmdPayments.Location = New System.Drawing.Point(182, 574)
        Me.cmdPayments.Name = "cmdPayments"
        Me.cmdPayments.Size = New System.Drawing.Size(143, 28)
        Me.cmdPayments.TabIndex = 10
        Me.cmdPayments.Text = "Make Key Card"
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Location = New System.Drawing.Point(331, 574)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(97, 28)
        Me.cmdEdit.TabIndex = 22
        Me.cmdEdit.Text = "&Edit"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(3, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 24)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Monthly Activity:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.Location = New System.Drawing.Point(2, 28)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(347, 4)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(3, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(168, 24)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Monthly Activity:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListBox2
        '
        Me.ListBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox2.Location = New System.Drawing.Point(2, 28)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(347, 4)
        Me.ListBox2.Sorted = True
        Me.ListBox2.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(3, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(168, 24)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Monthly Activity:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListBox3
        '
        Me.ListBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox3.Location = New System.Drawing.Point(2, 28)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(347, 4)
        Me.ListBox3.Sorted = True
        Me.ListBox3.TabIndex = 18
        '
        'cmdFeeAdjust
        '
        Me.cmdFeeAdjust.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdFeeAdjust.Location = New System.Drawing.Point(434, 574)
        Me.cmdFeeAdjust.Name = "cmdFeeAdjust"
        Me.cmdFeeAdjust.Size = New System.Drawing.Size(97, 28)
        Me.cmdFeeAdjust.TabIndex = 22
        Me.cmdFeeAdjust.Text = "&Fees"
        Me.cmdFeeAdjust.UseVisualStyleBackColor = True
        '
        'errCheck
        '
        Me.errCheck.ContainerControl = Me
        '
        'tabSwing
        '
        Me.tabSwing.Controls.Add(Me.Label12)
        Me.tabSwing.Controls.Add(Me.lstSwingActivity)
        Me.tabSwing.Location = New System.Drawing.Point(4, 27)
        Me.tabSwing.Name = "tabSwing"
        Me.tabSwing.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSwing.Size = New System.Drawing.Size(380, 255)
        Me.tabSwing.TabIndex = 0
        Me.tabSwing.Text = "Swing"
        Me.tabSwing.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(3, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(168, 24)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Activity:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstSwingActivity
        '
        Me.lstSwingActivity.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSwingActivity.ItemHeight = 18
        Me.lstSwingActivity.Location = New System.Drawing.Point(2, 28)
        Me.lstSwingActivity.Name = "lstSwingActivity"
        Me.lstSwingActivity.Size = New System.Drawing.Size(375, 4)
        Me.lstSwingActivity.TabIndex = 18
        '
        'tabDanceType
        '
        Me.tabDanceType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDanceType.Controls.Add(Me.tabSwing)
        Me.tabDanceType.Location = New System.Drawing.Point(376, 81)
        Me.tabDanceType.Name = "tabDanceType"
        Me.tabDanceType.SelectedIndex = 0
        Me.tabDanceType.Size = New System.Drawing.Size(388, 286)
        Me.tabDanceType.TabIndex = 21
        '
        'lblReminder
        '
        Me.lblReminder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReminder.BackColor = System.Drawing.Color.White
        Me.lblReminder.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReminder.ForeColor = System.Drawing.Color.Red
        Me.lblReminder.Location = New System.Drawing.Point(377, 370)
        Me.lblReminder.Name = "lblReminder"
        Me.lblReminder.Size = New System.Drawing.Size(366, 39)
        Me.lblReminder.TabIndex = 23
        Me.lblReminder.Text = "Check Anniversary!"
        Me.lblReminder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblReminder.Visible = False
        '
        'btnKeyCard
        '
        Me.btnKeyCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnKeyCard.Location = New System.Drawing.Point(699, 574)
        Me.btnKeyCard.Name = "btnKeyCard"
        Me.btnKeyCard.Size = New System.Drawing.Size(133, 28)
        Me.btnKeyCard.TabIndex = 24
        Me.btnKeyCard.Text = "Remove Admin"
        Me.btnKeyCard.UseVisualStyleBackColor = True
        Me.btnKeyCard.Visible = False
        '
        'btnMerchandise
        '
        Me.btnMerchandise.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMerchandise.Location = New System.Drawing.Point(534, 575)
        Me.btnMerchandise.Name = "btnMerchandise"
        Me.btnMerchandise.Size = New System.Drawing.Size(159, 27)
        Me.btnMerchandise.TabIndex = 25
        Me.btnMerchandise.Text = "Price Merchandise"
        Me.btnMerchandise.UseVisualStyleBackColor = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.CheckInsTableAdapter = Nothing
        Me.TableAdapterManager1.Connection = Nothing
        Me.TableAdapterManager1.ContestantsTableAdapter = Nothing
        Me.TableAdapterManager1.DeletedMembersTableAdapter = Nothing
        Me.TableAdapterManager1.KeyCardTableTableAdapter = Nothing
        Me.TableAdapterManager1.MerchandiseTableAdapter = Nothing
        Me.TableAdapterManager1.OKSwingMemberListTableAdapter = Nothing
        Me.TableAdapterManager1.passwordsTableAdapter = Nothing
        Me.TableAdapterManager1.ReportDateTableAdapter = Nothing
        Me.TableAdapterManager1.tblFeesTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager1.VoidedEntriesTableAdapter = Nothing
        '
        'ScCheckInDataSet1
        '
        Me.ScCheckInDataSet1.DataSetName = "SCCheckInDataSet"
        Me.ScCheckInDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tmrLogin
        '
        Me.tmrLogin.Enabled = True
        Me.tmrLogin.Interval = 180000
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 17)
        Me.ClientSize = New System.Drawing.Size(1036, 627)
        Me.Controls.Add(Me.btnMerchandise)
        Me.Controls.Add(Me.btnKeyCard)
        Me.Controls.Add(Me.lblReminder)
        Me.Controls.Add(Me.cmdFeeAdjust)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.tabDanceType)
        Me.Controls.Add(Me.lblHappyBDay)
        Me.Controls.Add(Me.cmdPayments)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.cmdBalance)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.pnl2)
        Me.Controls.Add(Me.pnl1)
        Me.Controls.Add(Me.pnl3)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Check In"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl1.ResumeLayout(False)
        Me.pnl1.PerformLayout()
        Me.pnl2.ResumeLayout(False)
        Me.pnl2.PerformLayout()
        Me.pnl3.ResumeLayout(False)
        Me.pnl3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.errCheck, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSwing.ResumeLayout(False)
        Me.tabDanceType.ResumeLayout(False)
        CType(Me.ScCheckInDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemberCheckInCollectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    'End Region
#End Region

#Region "Global Variables"
    Private aMember As MemberCheckInItem
    Private dteStatusChanged As Date = Now
    Public QuickSaver As SavePaid
    Public AdminPassword As String = String.Empty
    Public bolPass As Boolean = False
    Private scannedNumber As String = ""
    Private isScanned As Boolean = False
    Private lastDelay As Date
    Private loggedInUser As String = String.Empty
    Private morganThread As New System.Threading.Thread(AddressOf morganReport)

#End Region

#Region "Initial Loader"

    Private Sub frmWiz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            setStatus()
            QuickSaver = New SavePaid
            QuickSaver.conPaid = conPaid

            LoadPaidTypes(cboType1)
            LoadPaidTypes(cboType2)
            LoadPaidTypes(cboType3)
            LoadPaidTypes(cboType4)
            cboPayment1.SelectedIndex = 0
            cboPayment2.SelectedIndex = 0
            cboPayment3.SelectedIndex = 0
            cboPayment4.SelectedIndex = 0

            LoadPage()
            ShowScreen(1)

            'these lines fill the class comboBox called
            'cboClass
            cboClass.Items.Add(enClassList.Unknown)
            cboClass.Items.Add(enClassList.Pink)
            cboClass.Items.Add(enClassList.Purple)
            cboClass.Items.Add(enClassList.Yellow)
            cboClass.Items.Add(enClassList.Green)
            cboClass.Items.Add(enClassList.Blue)
            cboClass.Items.Add(enClassList.Teacher)
            cboClass.Items.Add(enClassList.FloorRentalOnly)

            dteDate1.Value = Now
            Me.Top = 0
            morganThread.Start()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Private Subs"

    Private Sub lstMembers_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstMembers.MouseDoubleClick
        If Not lstMembers.SelectedItem Is Nothing Then
            Dim tempMember As New MemberCheckInItem(CType(lstMembers.SelectedItem, DataRowView).Row)
            If Not loggedInUser = String.Empty Then
                NextScreen()
            Else
                Dim fPassword As frmAdminScan = New frmAdminScan
                If Not bolPass Then
                    bolPass = (fPassword.ShowDialog() = System.Windows.Forms.DialogResult.Yes)
                End If
                If bolPass Then
                    loggedInUser = fPassword.getAuthorized()
                    tmrLogin.Start()
                    NextScreen()
                Else
                    MessageBox.Show("Only Administrators Can Enter Records. See Current Administrators in Reports for the Administrator List by Clicking the Reports Button.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            If Not loggedInUser = String.Empty Then
                NextScreen()
            Else
                Dim fPassword As frmAdminScan = New frmAdminScan
                If Not bolPass Then
                    bolPass = (fPassword.ShowDialog() = System.Windows.Forms.DialogResult.Yes)
                End If
                If bolPass Then
                    loggedInUser = fPassword.getAuthorized()
                    tmrLogin.Start()
                    NextScreen()
                Else
                    MessageBox.Show("Only Administrators Can Enter Records. See Current Administrators in Reports for the Administrator List by Clicking the Reports Button.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If

    End Sub

    Private Sub morganReport()
        Dim theMonth As Integer = Now.Month
        Dim theYear As Integer = Now.Year - 3
        If theMonth = 1 Then
            theMonth = 12
            theYear = Now.Year - 2
        End If
        Dim lastYearDate As String = New Date(theYear, theMonth, 1).ToString("MM-dd-yyyy")
        Dim currentYear As String = New Date(Now.Year, Now.Month, 1).ToString("MM-dd-yyyy")
        Dim strBuilder As New System.Text.StringBuilder
        Dim strBuilder2 As New System.Text.StringBuilder
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "Select * FROM OkSwingMemberList Where EmailAddress != ''"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New System.Data.DataTable
        Dim aConn2 As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL2 As String = "Select * FROM ReportDate"
        Dim comTemp2 As SqlCommand = New SqlCommand(strSQL2, aConn2)
        Dim anAdapt2 As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(comTemp2)
        Dim dtTemp2 As DataTable = New System.Data.DataTable
        Dim aConn3 As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL3 As String = "select LastName, FirstName, PaidAmount, PaidDesc, CreateDate from CheckIns where PaidType != 7 and CreateDate >= '" & lastYearDate & "' and CreateDate < '" & currentYear & "' order by PaidType"
        Dim comTemp3 As SqlCommand = New SqlCommand(strSQL3, aConn3)
        Dim anAdapt3 As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(comTemp3)
        Dim dtTemp3 As DataTable = New System.Data.DataTable
        Dim theWriter As StreamWriter = Nothing
        Dim theWriter2 As StreamWriter = Nothing
        Dim lastActivityList As New ArrayList()
        Dim lastSendDate As Date
        Dim lastSendDate2 As Date
        aConn.Open()
        aConn2.Open()
        aConn3.Open()
        anAdapt.Fill(dtTemp)
        anAdapt2.Fill(dtTemp2)
        anAdapt3.Fill(dtTemp3)
        Try
            For Each aRow As System.Data.DataRow In dtTemp2.Rows
                lastSendDate = aRow.Item("DateLastSent")
                lastSendDate2 = aRow.Item("DateLastSent2")
            Next
            If Now.Subtract(lastSendDate2).Days > 30 Then
                theWriter2 = New StreamWriter("SalesReport" & lastYearDate & "To" & currentYear & ".CSV")
                Dim oLook As New Microsoft.Office.Interop.Outlook.Application
                Dim theMail As MailItem = oLook.CreateItem(OlItemType.olMailItem)
                theMail.Subject = "Sales Report " & lastYearDate & " To " & currentYear
                theMail.To = "morgan5053@gmail.com"
                theWriter2.WriteLine("Checkins From: " & lastYearDate & " To " & currentYear)
                theWriter2.WriteLine("Last Name,First Name,Paid Amount,Paid Description ,Created Date")
                For Each aRow As DataRow In dtTemp3.Rows
                    theWriter2.WriteLine(aRow.Item("LastName") & "," & aRow.Item("FirstName") & "," & aRow.Item("PaidAmount") & "," & aRow.Item("PaidDesc") & "," & aRow.Item("CreateDate"))
                Next
                strBuilder2.Append("Hi Morgan," & Environment.NewLine & "Here is the latest report from the date: " & Now.ToShortDateString & Environment.NewLine)
                strBuilder2.Append(Environment.NewLine)
                strBuilder2.Append("Automatically generated by the OKC Swing Club Program")
                theMail.Body = strBuilder2.ToString()
                comTemp3.CommandText = "UPDATE ReportDate SET DateLastSent2 = '" & New Date(Now.Year, Now.Month, 1).ToString("MM-dd-yyyy") & "'"
                comTemp3.ExecuteNonQuery()
                theWriter2.Close()
                theMail.Attachments.Add(System.Windows.Forms.Application.StartupPath & "\SalesReport" & lastYearDate & "To" & currentYear & ".CSV", Type.Missing, Type.Missing, Type.Missing)
                theMail.Send()
            End If
        Catch ex As System.Exception
            If Not theWriter Is Nothing Then
                theWriter.Close()
            End If
            If File.Exists("ExpireAndMIAReport.CSV") Then
                File.Delete("ExpireAndMIAReport.CSV")
            End If
        End Try
        Try
            If Now.Subtract(lastSendDate).Days > 59 Then
                theWriter = New StreamWriter("ExpireAndMIAReport.CSV")
                Dim oLook As New Microsoft.Office.Interop.Outlook.Application
                Dim theMail As MailItem = oLook.CreateItem(OlItemType.olMailItem)
                theMail.Subject = "Expired and MIA Members Report"
                theMail.To = "morgan5053@gmail.com"
                theWriter.WriteLine("Expired Members: ")
                For Each aRow As DataRow In dtTemp.Rows
                    Dim annDate As Date = CDate(aRow.Item("Anniversary"))
                    If annDate < Now Then
                        theWriter.WriteLine(aRow.Item("FirstName") & "," & aRow.Item("LastName") & "," & "Anniversary Date: " & annDate.ToShortDateString() & "," & aRow.Item("EmailAddress"))
                    End If
                    Dim lastActivity As Date = getLastActivityDate(aRow.Item("MemberID"))
                    If Now.Subtract(lastActivity).Days > 59 Then
                        lastActivityList.Add(aRow.Item("FirstName") & "," & aRow.Item("LastName") & ",Last Activity: " & lastActivity.ToShortDateString() & "," & aRow.Item("EmailAddress"))
                    End If
                Next
                theWriter.WriteLine("Members with last activity greater than 60 Days:" & Environment.NewLine)
                For Each activity As String In lastActivityList
                    theWriter.WriteLine(activity & Environment.NewLine)
                Next
                strBuilder.Append("Hi Morgan," & Environment.NewLine & "Here is the latest report from the date: " & Now.ToShortDateString & Environment.NewLine)
                strBuilder.Append(Environment.NewLine)
                strBuilder.Append("Automatically generated by the OKC Swing Club Program")
                theMail.Body = strBuilder.ToString()
                comTemp2.CommandText = "UPDATE ReportDate SET DateLastSent = '" & New Date(Now.Year, Now.Month, 1).ToString("MM-dd-yyyy") & "'"
                comTemp2.ExecuteNonQuery()
                theWriter.Close()
                theMail.Attachments.Add(System.Windows.Forms.Application.StartupPath & "\ExpireAndMIAReport.CSV", Type.Missing, Type.Missing, Type.Missing)
                theMail.Send()
            End If
        Catch ex As System.Exception
            If Not theWriter Is Nothing Then
                theWriter.Close()
            End If
            If File.Exists("ExpireAndMIAReport.CSV") Then
                File.Delete("ExpireAndMIAReport.CSV")
            End If
        End Try

    End Sub

    Private Sub setStatus()
        Dim strSQL As String = "UPDATE OKSwingMemberList set MemberStatus = 'NONMEMBER' Status = 'INACTIVE' Type = 'REGULAR' where Anniversary < ' " & Now.ToString("yyyy-MM-dd") & "'"
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim aComm As SqlCommand = New SqlCommand(strSQL, aConn)
        Try
            aConn.Open()
            aComm.ExecuteNonQuery()
        Catch ex As System.Exception

        End Try
        If Not aConn Is Nothing Then
            If Not aConn.State = ConnectionState.Closed Then
                aConn.Close()
            End If
            aConn = Nothing
        End If
    End Sub

    Private Function getLastActivityDate(ByVal memID As Integer) As Date
        Try
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim strSQL As String = "Select CreateDate from CheckIns where MemberID = " & memID & " ORDER BY CreateDate DESC"
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            For Each aRow As System.Data.DataRow In dtTemp.Rows
                Return CDate(aRow.Item("CreateDate"))
            Next
            Return Now
        Catch ex As System.Exception
            Return Now
        End Try
    End Function

    Private Sub FixAnniversaries()
        Dim strSQL As String = "UPDATE O SET Anniversary = DATEADD(YEAR, 1, Anniversary) FROM OKSwingMemberList O WHERE Anniversary < GETDATE() AND MemberID IN (SELECT MemberID FROM CheckIns WHERE PaidType = '2' AND CreateDate > DATEADD(MONTH, -6, GETDATE()))"
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim aComm As SqlCommand = New SqlCommand(strSQL, aConn)
        Try
            aConn.Open()
            aComm.ExecuteNonQuery()
        Catch ex As System.Exception

        End Try
        If Not aConn Is Nothing Then
            If Not aConn.State = ConnectionState.Closed Then
                aConn.Close()
            End If
            aConn = Nothing
        End If
    End Sub

    Private Sub LoadPage()
        Try
            Dim aView As DataView = New DataView(Members)
            lstMembers.DisplayMember = "FullName"
            lstMembers.DataSource = aView
            ApplySort()
        Catch ex As System.Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'This sub loads the comboboxes for the boxes below the tabbed boxes
    'and lists payment options and checking in...
    'accepts a combobox data type as an input
    Private Sub LoadPaidTypes(ByVal aComboBox As ComboBox)
        aComboBox.Items.Add(PaidType.Unknown)
        aComboBox.Items.Add(PaidType.MonthlyDues)
        aComboBox.Items.Add(PaidType.YearlyDues)
        aComboBox.Items.Add(PaidType.CheckIn)
        aComboBox.Items.Add(PaidType.Raffle)
        aComboBox.Items.Add(PaidType.SpecialEvent)
        aComboBox.Items.Add(PaidType.SingleLesson)
        aComboBox.Items.Add(PaidType.Exempt)
        aComboBox.Items.Add(PaidType.Child)
        aComboBox.Items.Add(PaidType.FridayNight)
        aComboBox.Items.Add(PaidType.SaturdayNight)
        aComboBox.Items.Add(PaidType.Merchandise)
        aComboBox.Items.Add(PaidType.MonthlyMaintenence)
        aComboBox.Items.Add(PaidType.FloorRental)
        aComboBox.Items.Add(PaidType.Donations)
        aComboBox.Items.Add(PaidType.Blank)
        aComboBox.Items.Add(PaidType.MondayNight)
    End Sub

    'This sub applies filters to the name list as the user of the system
    'types it in to the first and last name textboxes
    Private Sub ApplySort()
        Try
            Dim aDataView As DataView = New DataView(Members)
            If txtLast.Text.Length > 0 Then
                aDataView.RowFilter = "LastName LIKE '" & txtLast.Text & "*'"
            End If
            If txtFirst.Text.Length > 0 Then
                If txtLast.Text.Length > 0 Then
                    aDataView.RowFilter &= " AND FirstName LIKE '" & txtFirst.Text & "*'"
                Else
                    aDataView.RowFilter &= "FirstName LIKE '" & txtFirst.Text & "*'"
                End If
            End If

            lstMembers.DataSource = aDataView

        Catch ex As System.Exception
        End Try

    End Sub

    'This sub puts the main screen to a previous state when either
    'The Clear button is pressed or F1 key is pressed.
    Private Sub BackScreen()
        Select Case True
            Case pnl1.Enabled
                txtFirst.Text = ""
                txtLast.Text = ""
                cmdEdit.Enabled = False
                cmdPayments.Enabled = False
                cmdFeeAdjust.Enabled = True
                btnKeyCard.Visible = False
                txtFirst.Focus()
                cboPayment1.SelectedIndex = 0
                cboPayment2.SelectedIndex = 0
                cboPayment3.SelectedIndex = 0
                cboPayment4.SelectedIndex = 0
            Case pnl2.Enabled
                ShowScreen(1)
            Case pnl3.Enabled
                ShowScreen(2)
        End Select
    End Sub

    Private Sub NextScreen()
        Try
            Dim twoForOneBool As Boolean = False
            Dim strToday As String = String.Empty
            'this case statement checks if the day of the week
            'is monday or sunday and fills the variable
            'strToday
            Select Case Now.DayOfWeek
                Case DayOfWeek.Sunday
                    strToday = " - S"
                Case DayOfWeek.Monday
                    strToday = " - M"
            End Select

            'This if statement tests if the first and last name
            'boxes are empty and if they are then the method
            'fillInData will be called filling in first and last
            'name from the listbox lstMembers.
            If txtFirst.Text.Length = 0 Then
                If txtLast.Text.Length = 0 Then
                    fillInData()
                End If
            End If

            Select Case True
                Case pnl1.Enabled
                    ClearPaidScreen()
                    'This if statement is executed if the selection list
                    'below the name entry is blank beginning for the entry
                    'of a new person. the else is executed if there is a person
                    'listed in the list
                    If lstMembers.SelectedItem Is Nothing Then
                        If MessageBox.Show("Is this a new person?    ", "New person?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                            Dim newMem As frmAddMember = New frmAddMember
                            newMem.setName(txtFirst.Text.Replace(" ", ""), txtLast.Text.Replace(" ", ""))
                            newMem.ShowDialog()
                            If newMem.isCanceled Then
                                BackScreen()
                                BackScreen()
                                BackScreen()
                                LoadPage()
                                newMem = Nothing
                                Exit Sub
                            Else
                                aMember = newMem.getAMember
                                aMember.LessonAmount = getFees("REGULAR")
                                aMember.Type = "INTRO"
                                aMember.MemberStatus = "ACTIVE"
                                aMember.ClassItem = enClassList.Pink
                                'This case statement sets the initial anniversary to the first
                                '2 months from now
                                Select Case Now.Month
                                    Case 11
                                        aMember.Anniversary = New Date(Now.Year + 1, 1, 1)
                                    Case 12
                                        aMember.Anniversary = New Date(Now.Year + 1, 2, 1)
                                    Case Else
                                        aMember.Anniversary = New Date(Now.Year, Now.Month + 2, 1)
                                End Select
                                twoForOneBool = newMem.get2For1()
                                newMem = Nothing
                            End If
                        Else
                            Exit Sub
                        End If
                    Else
                        'This statement loads the member information from the database.
                        aMember = New MemberCheckInItem(CType(lstMembers.SelectedItem, DataRowView).Row)
                        btnKeyCard.Visible = checkAdminForButton(aMember.MemberID)
                        cmdEdit.Enabled = True
                        cmdPayments.Enabled = True
                        cmdFeeAdjust.Enabled = False
                        btnKeyCard.Enabled = True
                    End If

                    aMember.GetInfo()

                    If aMember.InvalidAddress Then
                        MessageBox.Show("Request Address Update.", "Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        lblNotes.Text = "Invalid Address" & vbCrLf & vbCrLf
                    Else
                        lblNotes.Text = ""
                    End If
                    lblHappyBDay.Text = aMember.BirthdayText
                    If lblNotes.Text.Length > 0 Then
                        lblNotes.Text &= vbCrLf
                    End If
                    If IsDate(aMember.Anniversary) Then
                        If CDate(aMember.Anniversary).Subtract(Now).TotalDays < 31 And aMember.ClassItem <> enClassList.FloorRentalOnly Then
                            lblReminder.Visible = True
                        End If
                    End If

                    Select Case tabDanceType.SelectedTab.Name
                        Case tabSwing.Name
                            aMember = LoadMemberPage(aMember, DanceType.Swing)
                    End Select

                    txtMemberID.Text = aMember.MemberID
                    txtFirst2.Text = aMember.FirstName & " " & aMember.LastName
                    txtAnnDate.Text = aMember.Anniversary

                    cboClass.SelectedItem = aMember.ClassItem


                    If aMember.MemberID = "109" Or aMember.ClassItem = enClassList.FloorRentalOnly Then
                        cboType1.SelectedIndex = PaidType.FloorRental
                        ShowScreen(2)
                        Exit Sub
                    End If

                    Select Case Now.DayOfWeek
                        Case DayOfWeek.Friday
                            ProcessFridayNight(aMember, cboType1, txt1Desc, txt1)
                        Case DayOfWeek.Saturday
                            ProcessSaturdayNight(aMember, cboType1, txt1Desc, txt1)
                        Case Else
                            If Not aMember.Anniversary.Year > Now.Year + 5 Then
                                If aMember.MonthlyAmount < aMember.LessonAmount Then
                                    If aMember.MonthlyAmount = 0 Then
                                        If txt1.Text.Length > 0 Then
                                            If aMember.Anniversary > Now And aMember.ClassItem = enClassList.Teacher Then
                                                cboType2.SelectedIndex = PaidType.Exempt
                                                txt2Desc.Text += " Teacher"
                                            Else
                                                cboType2.SelectedIndex = PaidType.MonthlyDues
                                            End If
                                        Else
                                            If aMember.Anniversary > Now And aMember.ClassItem = enClassList.Teacher Then
                                                cboType1.SelectedIndex = PaidType.Exempt
                                                txt1Desc.Text += " Teacher"
                                            Else
                                                If twoForOneBool Then
                                                    cboType1.SelectedIndex = PaidType.MonthlyDues
                                                    cboType2.SelectedIndex = PaidType.Exempt
                                                    txt1Desc.Text = "2 Months for Price of One Special"
                                                    txt2Desc.Text = "Exempt for 2 For 1"
                                                    dteDate2.Value = dteDate2.Value.AddMonths(1)
                                                Else
                                                    cboType1.SelectedIndex = PaidType.MonthlyDues
                                                End If
                                            End If
                                        End If
                                    Else
                                        If aMember.LessonAmount - aMember.MonthlyAmount > 0 Then
                                            If txt1.Text.Length > 0 Then
                                                cboType2.SelectedIndex = PaidType.MonthlyDues
                                                txt2Desc.Text = "Monthly Dues (" & aMember.Type & ")" & strToday
                                                txt2.Text = aMember.LessonAmount - String.Format("{0}.00", aMember.MonthlyAmount)
                                            Else
                                                cboType1.SelectedIndex = PaidType.MonthlyDues
                                                txt1Desc.Text = "Monthly Dues (" & aMember.Type & ")" & strToday
                                                txt1.Text = aMember.LessonAmount - String.Format("{0}.00", aMember.MonthlyAmount) '& ".00"
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            If CDate(aMember.Anniversary) <= Now Then
                                If aMember.YearlyAmount > 0 Then
                                    If txt1.Text.Length = 0 Then
                                        cboType1.SelectedIndex = PaidType.YearlyDues
                                        txt1.Text = getFees("YEARLY DUES").ToString("0.00")
                                    Else
                                        cboType2.SelectedIndex = PaidType.YearlyDues
                                        txt2.Text = getFees("YEARLY DUES").ToString("0.00")
                                    End If
                                End If
                            End If

                            If Not aMember.CheckedIn Then
                                Select Case True
                                    Case txt1.Text.Length = 0
                                        cboType1.SelectedIndex = PaidType.CheckIn
                                    Case txt2.Text.Length = 0
                                        cboType2.SelectedIndex = PaidType.CheckIn
                                    Case txt3.Text.Length = 0
                                        cboType3.SelectedIndex = PaidType.CheckIn
                                    Case txt4.Text.Length = 0
                                        cboType4.SelectedIndex = PaidType.CheckIn
                                End Select
                            End If
                    End Select

                    cmdEdit.Enabled = True
                    cmdPayments.Enabled = True
                    cmdFeeAdjust.Enabled = False
                    btnKeyCard.Enabled = True
                    ShowScreen(2)
                    txt1.Focus()

                Case pnl3.Enabled
                    If cboType1.SelectedIndex <> -1 And Not cboType1.SelectedIndex = PaidType.Blank Then
                        If IsNumeric(txt1.Text) Then
                            errCheck.SetError(txt1, "")
                        Else
                            errCheck.SetError(txt1, "This Value has to be a Number ex: 2.00")
                            Exit Sub
                        End If
                    Else
                        txt1.Text = String.Empty
                    End If
                    If cboType2.SelectedIndex <> -1 And Not cboType2.SelectedIndex = PaidType.Blank Then
                        If IsNumeric(txt2.Text) Then
                            errCheck.SetError(txt2, "")
                        Else
                            errCheck.SetError(txt2, "This Value has to be a Number ex: 2.00")
                            Exit Sub
                        End If
                    Else
                        txt2.Text = String.Empty
                    End If
                    If cboType3.SelectedIndex <> -1 And Not cboType3.SelectedIndex = PaidType.Blank Then
                        If IsNumeric(txt3.Text) Then
                            errCheck.SetError(txt3, "")
                        Else
                            errCheck.SetError(txt3, "This Value has to be a Number ex: 2.00")
                            Exit Sub
                        End If
                    Else
                        txt3.Text = String.Empty
                    End If
                    If cboType4.SelectedIndex <> -1 And Not cboType4.SelectedIndex = PaidType.Blank Then
                        If IsNumeric(txt4.Text) Then
                            errCheck.SetError(txt4, "")
                        Else
                            errCheck.SetError(txt4, "This Value has to be a Number ex: 2.00")
                            Exit Sub
                        End If
                    Else
                        txt4.Text = String.Empty
                    End If
                    If aMember.MemberID = 0 Then
                        aMember.Save()
                        Members.Rows.Add(aMember.GetRow)
                    End If

                    aMember.ClassItem = cboClass.SelectedItem
                    aMember.Save()

                    Dim intTotal As Integer = 0
                    If txt1.Text.Length > 0 Then
                        Dim aPaidRow As DataRow = PaidItems.NewRow
                        aPaidRow.Item("MemberID") = aMember.MemberID
                        aPaidRow.Item("FullName") = aMember.LastName & " " & aMember.FirstName
                        aPaidRow.Item("FirstName") = aMember.FirstName
                        aPaidRow.Item("LastName") = aMember.LastName
                        aPaidRow.Item("PaidType") = cboType1.SelectedIndex
                        aPaidRow.Item("PaidAmount") = txt1.Text
                        aPaidRow.Item("PaidDate") = dteDate1.Value.ToString("MM-dd-yyyy")
                        If CDbl(txt1.Text) > 0 Then
                            aPaidRow.Item("PaidDesc") = txt1Desc.Text.ToUpper & " PAID BY " & cboPayment1.Text.ToUpper
                        Else
                            aPaidRow.Item("PaidDesc") = txt1Desc.Text.ToUpper
                        End If
                        Select Case tabDanceType.SelectedTab.Name
                            Case tabSwing.Name
                                aPaidRow.Item("DanceType") = 0
                        End Select
                        If txtReferredBy.Text.Length > 0 Then
                            Try
                                Dim intReferred As Integer = 0
                                Dim strTemp As String = System.Text.RegularExpressions.Regex.Match(txtReferredBy.Text, "\b\d{1,7}\b").Value
                                If IsNumeric(strTemp) Then
                                    intReferred = strTemp
                                End If
                                If intReferred > 0 Then
                                    aPaidRow.Item("ReferredBy") = intReferred
                                End If
                            Catch ex As System.Exception
                            End Try
                        End If
                        intTotal += CDec(txt1.Text)
                        If CDec(txt1.Text) > 0 Or cboType1.SelectedIndex = PaidType.CheckIn Or cboType1.SelectedIndex = PaidType.Exempt Or cboType1.SelectedIndex = PaidType.FridayNight Or cboType1.SelectedIndex = PaidType.SaturdayNight Then
                            If cboType1.SelectedIndex = PaidType.Exempt And txt1Desc.Text = "Exempt (" & aMember.Type & ")" Then
                                Dim rsonForm As frmReasonWhy = New frmReasonWhy
                                Dim redo As String
                                rsonForm.ShowDialog()
                                redo = txt1Desc.Text & " " & rsonForm.getReason()
                                txt1Desc.Text = redo
                                aPaidRow.Item("PaidDesc") = redo
                            End If
                            If cboType1.SelectedIndex = PaidType.FloorRental And aMember.MemberID = "109" And txt1Desc.Text = "Floor Rental" Then
                                Dim rsonForm As frmReasonWhy = New frmReasonWhy
                                Dim redo As String
                                rsonForm.Label1.Text = "Please Enter the Teacher's Name or Organization"
                                rsonForm.ShowDialog()
                                redo = txt1Desc.Text & " " & rsonForm.getReason()
                                txt1Desc.Text = redo
                                aPaidRow.Item("PaidDesc") = redo
                            End If
                            PaidItems.Rows.Add(aPaidRow)
                            QuickSaver.PaidRow = aPaidRow
                            QuickSaver.Save()
                            If cboType1.SelectedIndex = PaidType.YearlyDues Then
                                aMember.Anniversary = New Date(Now.Year + 1, Now.Month + 1, 1)
                                aMember.MemberStatus = "MEMBER"
                                aMember.Status = "ACTIVE"
                                If Not aMember.Type = "CHARTER" Then
                                    aMember.Type = "REGULAR"
                                End If
                                aMember.Save()
                            End If
                        End If
                    End If
                    If txt2.Text.Length > 0 Then
                        Dim aPaidRow As DataRow = PaidItems.NewRow
                        aPaidRow.Item("MemberID") = aMember.MemberID
                        aPaidRow.Item("FullName") = aMember.LastName & " " & aMember.FirstName
                        aPaidRow.Item("FirstName") = aMember.FirstName
                        aPaidRow.Item("LastName") = aMember.LastName
                        aPaidRow.Item("PaidType") = cboType2.SelectedIndex
                        aPaidRow.Item("PaidAmount") = txt2.Text
                        aPaidRow.Item("PaidDate") = dteDate2.Value.ToString("MM-dd-yyyy")
                        If CDbl(txt2.Text) > 0 Then
                            aPaidRow.Item("PaidDesc") = txt2Desc.Text.ToUpper & " PAID BY " & cboPayment2.Text.ToUpper
                        Else
                            aPaidRow.Item("PaidDesc") = txt2Desc.Text.ToUpper
                        End If
                        Select Case tabDanceType.SelectedTab.Name
                            Case tabSwing.Name
                                aPaidRow.Item("DanceType") = 0
                                'Case tabSalsa.Name
                                'aPaidRow.Item("DanceType") = 1
                        End Select
                        If txtReferredBy.Text.Length > 0 Then
                            Try
                                Dim intReferred As Integer = 0
                                Dim strTemp As String = System.Text.RegularExpressions.Regex.Match(txtReferredBy.Text, "\b\d{1,7}\b").Value
                                If IsNumeric(strTemp) Then
                                    intReferred = strTemp
                                End If
                                If intReferred > 0 Then
                                    aPaidRow.Item("ReferredBy") = intReferred
                                End If
                            Catch ex As System.Exception
                            End Try
                        End If
                        intTotal += CDec(txt2.Text)
                        If CDec(txt2.Text) > 0 Or cboType2.SelectedIndex = PaidType.CheckIn Or cboType2.SelectedIndex = PaidType.Exempt Or cboType2.SelectedIndex = PaidType.FridayNight Or cboType2.SelectedIndex = PaidType.SaturdayNight Then
                            If cboType2.SelectedIndex = PaidType.Exempt And txt2Desc.Text = "Exempt (" & aMember.Type & ")" Then
                                Dim rsonForm As frmReasonWhy = New frmReasonWhy
                                Dim redo As String
                                rsonForm.ShowDialog()
                                redo = txt2Desc.Text & " " & rsonForm.getReason()
                                txt2Desc.Text = redo
                                aPaidRow.Item("PaidDesc") = redo
                            End If
                            If cboType2.SelectedIndex = PaidType.FloorRental And aMember.MemberID = "109" And txt2Desc.Text = "Floor Rental" Then
                                Dim rsonForm As frmReasonWhy = New frmReasonWhy
                                Dim redo As String
                                rsonForm.Label1.Text = "Please Enter the Teacher's Name or Organization"
                                rsonForm.ShowDialog()
                                redo = txt2Desc.Text & " " & rsonForm.getReason()
                                txt2Desc.Text = redo
                                aPaidRow.Item("PaidDesc") = redo
                            End If
                            PaidItems.Rows.Add(aPaidRow)
                            QuickSaver.PaidRow = aPaidRow
                            QuickSaver.Save()
                            If cboType2.SelectedIndex = PaidType.YearlyDues Then
                                aMember.Anniversary = New Date(Now.Year + 1, Now.Month + 1, 1)
                                aMember.MemberStatus = "MEMBER"
                                aMember.Status = "ACTIVE"
                                If Not aMember.Type = "CHARTER" Then
                                    aMember.Type = "REGULAR"
                                End If
                                aMember.Save()
                            End If
                        End If
                    End If
                    If txt3.Text.Length > 0 Then
                        Dim aPaidRow As DataRow = PaidItems.NewRow
                        aPaidRow.Item("MemberID") = aMember.MemberID
                        aPaidRow.Item("FullName") = aMember.LastName & " " & aMember.FirstName
                        aPaidRow.Item("FirstName") = aMember.FirstName
                        aPaidRow.Item("LastName") = aMember.LastName
                        aPaidRow.Item("PaidType") = cboType3.SelectedIndex
                        aPaidRow.Item("PaidAmount") = txt3.Text
                        aPaidRow.Item("PaidDate") = dteDate3.Value.ToString("MM-dd-yyyy")
                        If CDbl(txt3.Text) > 0 Then
                            aPaidRow.Item("PaidDesc") = txt3Desc.Text.ToUpper & " PAID BY " & cboPayment3.Text.ToUpper
                        Else
                            aPaidRow.Item("PaidDesc") = txt3Desc.Text.ToUpper
                        End If
                        Select Case tabDanceType.SelectedTab.Name
                            Case tabSwing.Name
                                aPaidRow.Item("DanceType") = 0
                                'Case tabSalsa.Name
                                'aPaidRow.Item("DanceType") = 1
                        End Select
                        If txtReferredBy.Text.Length > 0 Then
                            Try
                                Dim intReferred As Integer = 0
                                Dim strTemp As String = System.Text.RegularExpressions.Regex.Match(txtReferredBy.Text, "\b\d{1,7}\b").Value
                                If IsNumeric(strTemp) Then
                                    intReferred = strTemp
                                End If
                                If intReferred > 0 Then
                                    aPaidRow.Item("ReferredBy") = intReferred
                                End If
                            Catch ex As System.Exception
                            End Try
                        End If
                        intTotal += CDec(txt3.Text)
                        If CDec(txt3.Text) > 0 Or cboType3.SelectedIndex = PaidType.CheckIn Or cboType3.SelectedIndex = PaidType.Exempt Then
                            If cboType3.SelectedIndex = PaidType.Exempt And txt3Desc.Text = "Exempt (" & aMember.Type & ")" Then
                                Dim rsonForm As frmReasonWhy = New frmReasonWhy
                                Dim redo As String
                                rsonForm.ShowDialog()
                                redo = txt3Desc.Text & " " & rsonForm.getReason()
                                txt3Desc.Text = redo
                                aPaidRow.Item("PaidDesc") = redo
                            End If
                            If cboType3.SelectedIndex = PaidType.FloorRental And aMember.MemberID = "109" And txt3Desc.Text = "Floor Rental" Then
                                Dim rsonForm As frmReasonWhy = New frmReasonWhy
                                Dim redo As String
                                rsonForm.Label1.Text = "Please Enter the Teacher's Name or Organization"
                                rsonForm.ShowDialog()
                                redo = txt3Desc.Text & " " & rsonForm.getReason()
                                txt1Desc.Text = redo
                                aPaidRow.Item("PaidDesc") = redo
                            End If
                            PaidItems.Rows.Add(aPaidRow)
                            QuickSaver.PaidRow = aPaidRow
                            QuickSaver.Save()
                            If cboType3.SelectedIndex = PaidType.YearlyDues Then
                                aMember.Anniversary = New Date(Now.Year + 1, Now.Month + 1, 1)
                                aMember.MemberStatus = "MEMBER"
                                aMember.Status = "ACTIVE"
                                If Not aMember.Type = "CHARTER" Then
                                    aMember.Type = "REGULAR"
                                End If
                                aMember.Save()
                            End If
                        End If
                    End If
                    If txt4.Text.Length > 0 Then
                        Dim aPaidRow As DataRow = PaidItems.NewRow
                        aPaidRow.Item("MemberID") = aMember.MemberID
                        aPaidRow.Item("FullName") = aMember.LastName & " " & aMember.FirstName
                        aPaidRow.Item("FirstName") = aMember.FirstName
                        aPaidRow.Item("LastName") = aMember.LastName
                        aPaidRow.Item("PaidType") = cboType4.SelectedIndex
                        aPaidRow.Item("PaidAmount") = txt4.Text
                        aPaidRow.Item("PaidDate") = dteDate4.Value.ToString("MM-dd-yyyy")
                        If CDbl(txt4.Text) > 0 Then
                            aPaidRow.Item("PaidDesc") = txt4Desc.Text.ToUpper & " PAID BY " & cboPayment4.Text.ToUpper
                        Else
                            aPaidRow.Item("PaidDesc") = txt4Desc.Text.ToUpper
                        End If
                        Select Case tabDanceType.SelectedTab.Name
                            Case tabSwing.Name
                                aPaidRow.Item("DanceType") = 0
                                'Case tabSalsa.Name
                                'aPaidRow.Item("DanceType") = 1
                        End Select
                        If txtReferredBy.Text.Length > 0 Then
                            Try
                                Dim intReferred As Integer = 0
                                Dim strTemp As String = System.Text.RegularExpressions.Regex.Match(txtReferredBy.Text, "\b\d{1,7}\b").Value
                                If IsNumeric(strTemp) Then
                                    intReferred = strTemp
                                End If
                                If intReferred > 0 Then
                                    aPaidRow.Item("ReferredBy") = intReferred
                                End If
                            Catch ex As System.Exception
                            End Try
                        End If
                        intTotal += CDec(txt4.Text)
                        If CDec(txt4.Text) > 0 Or cboType4.SelectedIndex = PaidType.CheckIn Or cboType4.SelectedIndex = PaidType.Exempt Then
                            If cboType4.SelectedIndex = PaidType.Exempt And txt4Desc.Text = "Exempt (" & aMember.Type & ")" Then
                                Dim rsonForm As frmReasonWhy = New frmReasonWhy
                                Dim redo As String
                                rsonForm.ShowDialog()
                                redo = txt4Desc.Text & " " & rsonForm.getReason()
                                txt4Desc.Text = redo
                                aPaidRow.Item("PaidDesc") = redo
                            End If
                            If cboType4.SelectedIndex = PaidType.FloorRental And aMember.MemberID = "109" And txt4Desc.Text = "Floor Rental" Then
                                Dim rsonForm As frmReasonWhy = New frmReasonWhy
                                Dim redo As String
                                rsonForm.Label1.Text = "Please Enter the Teacher's Name or Organization"
                                rsonForm.ShowDialog()
                                redo = txt1Desc.Text & " " & rsonForm.getReason()
                                txt4Desc.Text = redo
                                aPaidRow.Item("PaidDesc") = redo
                            End If
                            PaidItems.Rows.Add(aPaidRow)
                            QuickSaver.PaidRow = aPaidRow
                            QuickSaver.Save()
                            If cboType4.SelectedIndex = PaidType.YearlyDues Then
                                aMember.Anniversary = New Date(Now.Year + 1, Now.Month + 1, 1)
                                aMember.MemberStatus = "MEMBER"
                                aMember.Status = "ACTIVE"
                                If Not aMember.Type = "CHARTER" Then
                                    aMember.Type = "REGULAR"
                                End If
                                aMember.Save()
                            End If
                        End If
                    End If

                    txtFirst.Text = ""
                    txtLast.Text = ""
                    lblNotes.Text = ""
                    lblReminder.Visible = False
                    cmdEdit.Enabled = False
                    cmdPayments.Enabled = False
                    cmdFeeAdjust.Enabled = True
                    btnKeyCard.Enabled = False
                    btnKeyCard.Visible = False
                    btnMerchandise.Enabled = True

                    ClearPaidScreen()
                    tmrLogin.Stop()
                    tmrLogin.Start()

                    ShowScreen(1)
            End Select
        Catch ex As System.Exception
            MessageBox.Show(ex.ToString)
        End Try
        LoadMembers()
    End Sub

    Private Sub ClearPaidScreen()

        dteDate1.Value = Now
        dteDate2.Value = Now
        dteDate3.Value = Now
        dteDate4.Value = Now
        lblNotes.Text = ""
        lblHappyBDay.Text = ""
        lblReminder.Visible = False
        lstSwingActivity.Items.Clear()

        cboType1.SelectedIndex = -1
        cboType2.SelectedIndex = -1
        cboType3.SelectedIndex = -1
        cboType4.SelectedIndex = -1
        cboPayment1.SelectedIndex = 0
        cboPayment2.SelectedIndex = 0
        cboPayment3.SelectedIndex = 0
        cboPayment4.SelectedIndex = 0

        For Each aControl As Control In pnl2.Controls
            If aControl.Name.StartsWith("txt") Then
                aControl.Text = ""
            End If
        Next
        For Each aControl As Control In pnl3.Controls
            If aControl.Name.StartsWith("txt") Then
                aControl.Text = ""
            End If
        Next

    End Sub

    'This sub sets the main screen divided in panels pnl1, pnl2, and
    'pnl3 and enables or disables depending on if a 1 or 2 is 
    'sent to it
    Private Sub ShowScreen(ByVal ScreenNumber As Integer)
        Select Case ScreenNumber
            Case 1
                pnl1.Enabled = True
                pnl2.Enabled = False
                pnl3.Enabled = False
                cmdEdit.Enabled = False
                cmdPayments.Enabled = False
                cmdFeeAdjust.Enabled = True
                btnKeyCard.Visible = False
                btnMerchandise.Enabled = True
                ClearPaidScreen()
                txtFirst.Focus()
            Case 2
                pnl1.Enabled = False
                pnl2.Enabled = True
                pnl3.Enabled = True
                cmdEdit.Enabled = True
                cmdPayments.Enabled = True
                cmdFeeAdjust.Enabled = False
                btnMerchandise.Enabled = False
        End Select
    End Sub

    Private Sub SetDescAndAmount(ByRef cboType As ComboBox, ByRef txtDesc As TextBox, ByRef txtAmount As TextBox)
        Dim strToday As String = String.Empty
        Select Case Now.DayOfWeek
            Case DayOfWeek.Sunday
                If cboType.Name.IndexOf("1") > -1 Then
                    strToday = " - S"
                Else
                    strToday = " - M"
                End If
            Case DayOfWeek.Monday
                If cboType.Name.IndexOf("1") > -1 Then
                    strToday = " - M"
                Else
                    strToday = " - S"
                End If
        End Select
        Dim strMemberType As String = aMember.Type
        'If tabDanceType.SelectedTab.Name = tabSalsa.Name Then
        'strMemberType &= " SALSA"
        'End If
        Select Case CType(cboType.SelectedItem, PaidType)
            Case PaidType.CheckIn
                txtDesc.Text = "Check-In"
                txtAmount.Text = String.Format("{0}.00", 0)
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.Raffle
                txtDesc.Text = "Raffle"
                txtAmount.Text = getFees("RAFFLE").ToString("0.00")
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.MonthlyDues
                txtDesc.Text = "Monthly Dues (" & strMemberType & ")" & strToday
                If aMember.Anniversary < Now Then
                    txtAmount.Text = getFees("NONMEMBER").ToString("0.00")
                ElseIf aMember.Type = "CHARTER" Then
                    txtAmount.Text = getFees("CHARTER").ToString("0.00")
                Else
                    txtAmount.Text = getFees("REGULAR").ToString("0.00")
                End If
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.SingleLesson
                txtDesc.Text = "Single Lesson"
                txtAmount.Text = getFees("SINGLE LESSON").ToString("0.00")
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.SpecialEvent
                txtDesc.Text = "Special Event " & Now.Year
                If Now < New Date(Now.Year, 10, 20) Then
                    txtAmount.Text = getFees("SPECIAL EVENT 1").ToString("0.00")
                Else
                    txtAmount.Text = getFees("SPECIAL EVENT 2").ToString("0.00")
                End If
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.Unknown
                txtDesc.Text = "Unknown"
                txtAmount.Text = String.Format("{0}.00", 0)
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.YearlyDues
                txtDesc.Text = "Yearly Dues"
                txtAmount.Text = String.Format("{0}.00", getFees("YEARLY DUES"))
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.Exempt
                txtDesc.Text = "Exempt (" & strMemberType & ")"
                txtAmount.Text = String.Format("{0}.00", 0)
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.Child
                txtDesc.Text = "Monthly Child Dues (" & strMemberType & ")"
                txtAmount.Text = getFees("KID").ToString("0.00")
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.Merchandise
                Dim mEntry As New frmEnterMerchandise(txtDesc, txtAmount)
                If Not mEntry.ShowDialog() = System.Windows.Forms.DialogResult.OK Then cboType.SelectedItem = PaidType.Blank
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.Donations
                txtDesc.Text = "Donations"
                txtAmount.Text = getFees("DONATIONS").ToString("0.00")
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.MonthlyMaintenence
                txtDesc.Text = "Monthly Maintenence"
                txtAmount.Text = getFees("MONTHLY MAINTANCE").ToString("0.00")
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.FloorRental
                If aMember.MemberID = "109" Then
                    txtDesc.Text = "Floor Rental"
                Else
                    txtDesc.Text = "Floor Rental " & aMember.FirstName & " " & aMember.LastName
                End If
                txtAmount.Text = getFees("FLOOR RENTAL").ToString("0.00")
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.FridayNight
                ProcessFridayNight(aMember, cboType, txtDesc, txtAmount)
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.SaturdayNight
                ProcessSaturdayNight(aMember, cboType, txtDesc, txtAmount)
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case PaidType.MondayNight
                txtDesc.Text = "Monday Night Practice Without Class"
                txtAmount.Text = getFees("MONDAY NIGHT PRACTICE NON-CLASS").ToString("0.00")
                txtAmount.Enabled = True
                txtDesc.Enabled = True
            Case Else
                txtAmount.Enabled = False
                txtDesc.Enabled = False
                txtDesc.Text = ""
                txtAmount.Text = ""
        End Select
    End Sub

    Private Sub fillInData()
        Dim tempMember As New MemberCheckInItem(CType(lstMembers.SelectedItem, DataRowView).Row)
        txtFirst.Text = tempMember.FirstName.ToUpper
        txtLast.Text = tempMember.LastName.ToUpper
    End Sub

    Private Function checkAdminForButton(ByVal memID As Integer) As Boolean
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "SELECT * FROM KeyCardTable WHERE MemberID = " & memID
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New System.Data.DataTable
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Return aRow.Item("IsAdmin")
        Next
        Return False
    End Function

    Private Function getMember(ByVal keyCard As String) As Boolean
        If txtFirst.Text <> String.Empty Or txtLast.Text <> String.Empty Then
            Dim theResult As DialogResult = MessageBox.Show("There is Member Data Still Present. Continuing will NOT Save ANY Data. Do you wish to continue?", "Member Data Present", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If theResult = System.Windows.Forms.DialogResult.Yes Then
                BackScreen()
            Else
                Exit Function
            End If
        End If
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "SELECT * FROM KeyCardTable WHERE KeyCardNumber = '" & keyCard & "'"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New System.Data.DataTable
        Try
            aConn.Open()
            anAdapt.Fill(dtTemp)
        Catch ex As System.Exception
            MessageBox.Show("Error getting member. Enter the member manually.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        If dtTemp.Rows.Count = 0 Then
            MessageBox.Show("No member associated with this tag.", "Lookup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        For Each aRow As DataRow In dtTemp.Rows
            txtFirst.Text = aRow.Item("FirstName")
            txtLast.Text = aRow.Item("LastName")
            btnKeyCard.Visible = aRow.Item("IsAdmin")
            Return True
        Next
        Return True
    End Function

    Private Function checkForNoKeyNumber(ByVal memId As Integer) As Boolean
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "SELECT * FROM KeyCardTable WHERE MemberId = " & memId
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        Return dtTemp.Rows.Count = 0
    End Function

#End Region

#Region "Private Functions"

    Private Function getFees(ByVal feeCode As String) As Double
        Try
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim strSQL As String = "Select FeeAmount from tblFees where FeeCode = '" & feeCode & "'"
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            For Each aRow As DataRow In dtTemp.Rows
                Return CDbl(aRow.Item("FeeAmount"))
            Next
        Catch ex As System.Exception
            Debug.WriteLine(ex)
            Return 0.0
        End Try
        Return 0.0
    End Function

#End Region

#Region "Public Functions"

    Public Function LoadMemberPage(ByVal aMember As MemberCheckInItem, ByVal aDanceType As DanceType) As MemberCheckInItem

        If aMember.MemberID = 0 Then
            aMember.MemberStatus = "ACTIVE"
            aMember.Type = "INTRO"
        End If
        If aMember.LessonAmount = 0 Then
            If aMember.Type = "CHARTER" Then
                aMember.LessonAmount = getFees("CHARTER")
            Else
                aMember.LessonAmount = getFees("REGULAR")
            End If
        End If
        If aMember.Anniversary.Year < 1900 Then
            aMember.Anniversary = CDate(Now.ToString("MM-01-yyyy")).AddMonths(2)
        End If
        If aMember.Anniversary < Now Then
            aMember.LessonAmount = getFees("NONMEMBER")
        End If

        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)

        Dim strSQL As String = "SELECT * FROM CheckIns WHERE "
        If aMember.MemberID > 0 Then
            strSQL &= "MemberID = " & aMember.MemberID
        Else
            strSQL &= "MemberID = 0 AND FirstName = '" & aMember.FirstName & "' AND LastName = '" & aMember.LastName & "'"
        End If
        strSQL &= " ORDER BY PaidDate DESC, PaidDesc"

        Dim intMonthlyAmount As Decimal
        Dim intElementsAmount As Decimal
        Dim intYearlyAmount As Decimal
        Dim bolCheckedIn As Boolean = False

        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                If Not aRow.Item("ReferredBy") Is DBNull.Value Then
                    If aRow.Item("ReferredBy") > 0 Then
                        comTemp.CommandText = "SELECT LastName + ', ' + FirstName + ' (' + CAST(MemberID AS VARCHAR) + ')' FROM OKSwingMemberList WHERE MemberID = " & aRow.Item("ReferredBy")
                        txtReferredBy.Text = comTemp.ExecuteScalar
                    End If
                End If
            Catch ex As System.Exception
                Debug.WriteLine(ex.ToString)
            End Try
            Dim strTemp As String = String.Concat(CDate(aRow.Item("PaidDate")).ToString("MMM dd yyyy"), " ", aRow.Item("PaidDesc").ToString)
            If Not CType(aRow.Item("PaidType"), PaidType) = PaidType.CheckIn Then
                strTemp = String.Concat(strTemp, " ", String.Format("{0}", Convert.ToDecimal(aRow.Item("PaidAmount")).ToString("C")))
            End If
            Select Case Integer.Parse(aRow.Item("DanceType"))
                Case 0
                    lstSwingActivity.Items.Add(strTemp)
                Case 1
                    'lstSalsaActivity.Items.Add(strTemp)
            End Select
            If CDate(aRow.Item("PaidDate").ToString).Year = Now.Year Then
                If CDate(aRow.Item("PaidDate").ToString).Month = Now.Month Then
                    Select Case CType(aRow.Item("PaidType"), PaidType)
                        Case PaidType.Child
                            If Integer.Parse(aRow.Item("DanceType")) = aDanceType Then
                                intMonthlyAmount = aMember.LessonAmount
                            End If
                        Case PaidType.Exempt
                            If Integer.Parse(aRow.Item("DanceType")) = aDanceType Then
                                intMonthlyAmount = aMember.LessonAmount
                            End If
                        Case PaidType.MonthlyDues
                            If Integer.Parse(aRow.Item("DanceType")) = aDanceType Then
                                intMonthlyAmount += aRow.Item("PaidAmount")
                            End If
                        Case PaidType.YearlyDues
                            intYearlyAmount += aRow.Item("PaidAmount")
                        Case PaidType.Raffle
                            intElementsAmount += aRow.Item("PaidAmount")
                        Case PaidType.CheckIn
                            If Integer.Parse(aRow.Item("DanceType")) = aDanceType Then
                                If CDate(aRow.Item("PaidDate").ToString).Day = Now.Day Then
                                    bolCheckedIn = True
                                End If
                            End If
                        Case PaidType.MonthlyMaintenence
                            intMonthlyAmount = aMember.LessonAmount
                            MessageBox.Show(aMember.FirstName & " " & aMember.LastName & " has paid the monthly maintance fee and should not be allowed to attend classes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Select
                End If
            End If
        Next

        aMember.ElementsAmount = intElementsAmount

        If aMember.Type = "CHARTER" Then
            If aMember.LessonAmount > getFees("CHARTER") Then
                If aMember.Anniversary > Now Then
                    aMember.LessonAmount = getFees("CHARTER")
                Else
                    If intYearlyAmount >= 50 Then
                        aMember.LessonAmount = getFees("CHARTER")
                    End If
                End If
            End If
        Else
            If aMember.LessonAmount > getFees("REGULAR") Then
                If aMember.Anniversary > Now Then
                    aMember.LessonAmount = getFees("REGULAR")
                Else
                    If intYearlyAmount >= 50 Then
                        aMember.LessonAmount = getFees("REGULAR")
                    End If
                End If
            End If
        End If


        aMember.MonthlyAmount = intMonthlyAmount
        If intMonthlyAmount = aMember.LessonAmount Then
            If aMember.Anniversary < Now Then
                aMember.YearlyAmount = getFees("YEARLY DUES")
            End If
        Else
            aMember.YearlyAmount = getFees("YEARLY DUES") - intYearlyAmount
        End If
        aMember.CheckedIn = bolCheckedIn

        Return aMember
    End Function

#End Region

#Region "Friday and Saturday Handlers"

    Public Sub ProcessFridayNight(ByVal aMember As MemberCheckInItem, ByRef cboBox As ComboBox, ByRef txtdesc As TextBox, ByRef txtprice As TextBox)
        Try
            If cboType1.SelectedIndex = PaidType.FridayNight Or cboType2.SelectedIndex = PaidType.FridayNight Or cboType3.SelectedIndex = PaidType.FridayNight Or cboType4.SelectedIndex = PaidType.FridayNight Then
                Exit Try
            End If
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim strSQL As String = "Select * from CheckIns where MemberID = " & aMember.MemberID & " and PaidType = " & PaidType.FridayNight & " and PaidDate = '" & Now.Date.ToString("yyyy-MM-dd") & "'"
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            For Each aRow As DataRow In dtTemp.Rows
                Exit Sub
            Next
        Catch ex As System.Exception
            Debug.WriteLine(ex)
        End Try
        If aMember.Anniversary < Now And Not aMember.HasPaid Then
            cboBox.SelectedIndex = PaidType.FridayNight
            txtdesc.Text = "Friday Night Non Member"
            txtprice.Text = getFees("FRIDAY NIGHT NON-MEMBER").ToString("0.00")
        Else
            If aMember.HasPaid Then
                cboBox.SelectedIndex = PaidType.FridayNight
                If aMember.Anniversary < Now Then
                    txtdesc.Text = "Friday Night Non-Member With Classes"
                    txtprice.Text = getFees("FRIDAY NIGHT MEMBER WITH CLASSES").ToString("0.00")
                Else
                    txtdesc.Text = "Friday Night Member With Classes"
                    txtprice.Text = getFees("FRIDAY NIGHT MEMBER WITH CLASSES").ToString("0.00")
                End If
            Else
                cboBox.SelectedIndex = PaidType.FridayNight
                txtdesc.Text = "Friday Night Member Without Classes"
                txtprice.Text = getFees("FRIDAY NIGHT MEMBER").ToString("0.00")
            End If
        End If
    End Sub
    Public Sub ProcessSaturdayNight(ByVal aMember As MemberCheckInItem, ByRef cboBox As ComboBox, ByRef txtdesc As TextBox, ByRef txtPrice As TextBox)
        Try
            If cboType1.SelectedIndex = PaidType.SaturdayNight Or cboType2.SelectedIndex = PaidType.SaturdayNight Or cboType3.SelectedIndex = PaidType.SaturdayNight Or cboType4.SelectedIndex = PaidType.SaturdayNight Then
                Exit Try
            End If
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim strSQL As String = "Select * from CheckIns where MemberID = " & aMember.MemberID & " and PaidType = " & PaidType.SaturdayNight & " and PaidDate = '" & Now.Date.ToString("yyyy-MM-dd") & "'"
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            For Each aRow As DataRow In dtTemp.Rows
                Exit Sub
            Next
        Catch ex As System.Exception
            Debug.WriteLine(ex)
        End Try
        If aMember.Anniversary < Now Then
            cboBox.SelectedIndex = PaidType.SaturdayNight
            txtdesc.Text = "Saturday Night Non Member"
            txtPrice.Text = getFees("SATURDAY NIGHT NON-MEMBER").ToString("0.00")
        Else
            cboBox.SelectedIndex = PaidType.SaturdayNight
            txtdesc.Text = "Saturday Night Member "
            txtPrice.Text = getFees("SATURDAY NIGHT MEMBER").ToString("0.00")
        End If
    End Sub

#End Region

#Region "TextBox Handlers"

    'The next two subs call ApplySort to filter the name list
    'as the name is typed. This appears to be case insenstive
    Private Sub txtLast_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLast.TextChanged, txtFirst.TextChanged
        ApplySort()
    End Sub

    'This sub is used to allow the user to move up and down the the name list 
    'on the left.
    Private Sub txtLast_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLast.KeyDown, txtFirst.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Down
                    If lstMembers.SelectedIndex < lstMembers.Items.Count Then
                        lstMembers.SelectedIndex += 1
                    End If
                Case Keys.Up
                    If lstMembers.SelectedIndex > 0 Then
                        lstMembers.SelectedIndex -= 1
                    End If
                Case Else
            End Select
        Catch ex As System.Exception
        End Try

    End Sub

#End Region

#Region "Button Handler"

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If Not loggedInUser = String.Empty Then
            NextScreen()
        Else
            Dim fPassword As frmAdminScan = New frmAdminScan
            If Not bolPass Then
                bolPass = (fPassword.ShowDialog() = System.Windows.Forms.DialogResult.Yes)
            End If
            If bolPass Then
                loggedInUser = fPassword.getAuthorized()
                tmrLogin.Start()
                NextScreen()
            Else
                MessageBox.Show("Only Administrators Can Enter Records. See Current Administrators in Reports for the Administrator list.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        BackScreen()
    End Sub

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
        Dim x As frmReports = New frmReports
        x.Show(Me)
        txtFirst.Focus()
    End Sub

    Private Sub cmdBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBalance.Click
        Dim fBalance As frmBalance = New frmBalance
        fBalance.Show()
        txtFirst.Focus()
    End Sub

    'This sub will show the payment history of a selected member when enabled
    'it will take the full name from lstMembers and split it into individual
    'values and give the name to the class frmPayments in order to show
    'the payment history of the member.

    Private Sub cmdPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPayments.Click
        Dim NoNumberCheck As Boolean = checkForNoKeyNumber(aMember.MemberID)
        Dim keyForm As frmKeyCardEntry
        If NoNumberCheck Then
            keyForm = New frmKeyCardEntry(aMember)
            keyForm.ShowDialog()
        Else
            Dim theResult As DialogResult = MessageBox.Show("This member has a key tag number. Are you sure you want to continue?", "Number Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If theResult = System.Windows.Forms.DialogResult.Yes Then
                keyForm = New frmKeyCardEntry(aMember, True)
                keyForm.ShowDialog()
            End If
            btnKeyCard.Visible = checkAdminForButton(aMember.MemberID)
        End If
        txtFirst.Focus()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim fPassword As frmAdminScan = New frmAdminScan

        If fPassword.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            Dim x As frmEditMember = New frmEditMember
            x.getAdmin(fPassword)
            x.getMemberID(CInt(txtMemberID.Text))
            aMember.Save()
            x.EditMember = aMember
            If x.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                x.EditMember = aMember
            End If
            If x.isDeleted Then
                LoadMembers()
                LoadPage()
            End If
            If x.isModified Then
                Dim oLook As New Microsoft.Office.Interop.Outlook.Application
                Dim theMail As MailItem = oLook.CreateItem(OlItemType.olMailItem)
                theMail.Subject = aMember.MemberID & " has been modified."
                theMail.To = "tubust@hotmail.com"
                theMail.Body = x.anniversaryChanged
                theMail.Send()
            End If
            BackScreen()
        End If
        txtFirst.Focus()
    End Sub

    Private Sub btnReferrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReferrer.Click
        Dim x As New frmLookup
        x.Members = Members
        If x.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtReferredBy.Text = x.Member
        End If
        x.Dispose()
        cmdNext.Focus()
    End Sub

    Private Sub cmdFeeAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFeeAdjust.Click
        Dim fPassword As frmAdminScan = New frmAdminScan
        If fPassword.ShowDialog() = System.Windows.Forms.DialogResult.Yes Then
            Dim feeForm As frmFeeChange = New frmFeeChange
            feeForm.ShowDialog()
        End If
        txtFirst.Focus()
    End Sub

#End Region

#Region "Keyboard Handler"

    Private Sub frmWiz_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BackScreen()
                scannedNumber = String.Empty
            Case Keys.F2
                If Not loggedInUser = String.Empty Then
                    NextScreen()
                Else
                    Dim fPassword As frmAdminScan = New frmAdminScan
                    If Not bolPass Then
                        bolPass = (fPassword.ShowDialog() = System.Windows.Forms.DialogResult.Yes)
                    End If
                    If bolPass Then
                        loggedInUser = fPassword.getAuthorized()
                        tmrLogin.Start()
                        NextScreen()
                    Else
                        MessageBox.Show("Only Administrators Can Enter Records. See Current Administrators in Reports for the Administrator list.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                scannedNumber = String.Empty
            Case Keys.Enter
                Dim test As Integer = Now.Subtract(lastDelay).Milliseconds
                If scannedNumber.Length = 6 And test < 100 Then 'Scanned Tag
                    If pnl2.Enabled Or pnl3.Enabled Then
                        If txt1.Focus() Then
                            txt1.Text = String.Empty
                        ElseIf txt2.Focus() Then
                            txt2.Text = String.Empty
                        ElseIf txt3.Focus() Then
                            txt3.Text = String.Empty
                        ElseIf txt4.Focus() Then
                            txt4.Text = String.Empty
                        End If
                        lastDelay = Nothing
                        scannedNumber = String.Empty
                        e.Handled = True
                        Exit Sub
                    End If
                    If getMember(scannedNumber) Then
                        If Not loggedInUser = String.Empty Then
                            NextScreen()
                        Else
                            Dim fPassword As frmAdminScan = New frmAdminScan
                            If Not bolPass Then
                                bolPass = (fPassword.ShowDialog() = System.Windows.Forms.DialogResult.Yes)
                            End If
                            If bolPass Then
                                loggedInUser = fPassword.getAuthorized()
                                tmrLogin.Start()
                                NextScreen()
                            Else
                                MessageBox.Show("Only Administrators Can Enter Records. See Current Administrators in Reports for the Administrator list.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                    scannedNumber = String.Empty
                    lastDelay = Nothing
                ElseIf scannedNumber.Length = 6 And test > 100 Then
                    scannedNumber = String.Empty
                    lastDelay = Nothing
                    e.Handled = True
                Else
                    scannedNumber = String.Empty
                    lastDelay = Nothing
                    If Not loggedInUser = String.Empty Then
                        NextScreen()
                    Else
                        Dim fPassword As frmAdminScan = New frmAdminScan
                        If Not bolPass Then
                            bolPass = (fPassword.ShowDialog() = System.Windows.Forms.DialogResult.Yes)
                        End If
                        If bolPass Then
                            loggedInUser = fPassword.getAuthorized()
                            tmrLogin.Start()
                            NextScreen()
                        Else
                            MessageBox.Show("Only Administrators Can Enter Records. See Current Administrators in Reports for the Administrator list.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Case Keys.Escape
                BackScreen()
                scannedNumber = String.Empty
            Case Keys.D0 To Keys.D9
                If scannedNumber.Length = 6 Then
                    scannedNumber = String.Empty
                End If
                If scannedNumber.Length = 5 Then
                    lastDelay = Now
                End If
                scannedNumber += Chr(e.KeyCode)
            Case Else
                scannedNumber = String.Empty
        End Select
    End Sub

#End Region

#Region "Combobox Handler"

    Private Sub cboType1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType1.SelectedIndexChanged
        SetDescAndAmount(cboType1, txt1Desc, txt1)
    End Sub

    Private Sub cboType2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType2.SelectedIndexChanged
        SetDescAndAmount(cboType2, txt2Desc, txt2)
    End Sub

    Private Sub cboType3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType3.SelectedIndexChanged
        SetDescAndAmount(cboType3, txt3Desc, txt3)
    End Sub

    Private Sub cboType4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType4.SelectedIndexChanged
        SetDescAndAmount(cboType4, txt4Desc, txt4)
    End Sub

#End Region

#Region "Timer"

    Private Sub tmrStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStatus.Tick
        If lblReminder.Visible Then
            If lblReminder.ForeColor = Color.Red Then
                lblReminder.ForeColor = Color.White
                lblReminder.BackColor = Color.Red
            Else
                lblReminder.ForeColor = Color.Red
                lblReminder.BackColor = Color.White
            End If
        End If
    End Sub

#End Region

#Region "Validation"
    Private Sub txt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt1.KeyPress, txt2.KeyPress, txt3.KeyPress, txt4.KeyPress
        Const decimalChar As Char = "."c
        Select Case e.KeyChar
            Case decimalChar
                'This case only allows one decimal point
                Dim txt As TextBox = CType(sender, TextBox)
                If txt.Text.Contains(decimalChar) Then
                    e.Handled = True
                End If
            Case "0"c To "9"c
                'These backspace and delete are only allowed keys besides
                'one decimal point and numbers
            Case Chr(Keys.Back)
            Case Chr(Keys.Delete)
                'Every other key is handled by this case and ignored.
            Case Else
                e.Handled = True

        End Select
    End Sub

    Private Sub txtFirst_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirst.KeyPress, txtLast.KeyPress
        'No more whitespace allowed in name textbox for data accuracy.
        Dim test As Char = e.KeyChar
        If Char.IsLetter(test) Then
            Exit Sub
        End If
        If Char.IsDigit(test) Then
            e.Handled = True
            Exit Sub
        End If
        Select Case e.KeyChar
            Case "-"c
            Case Chr(Keys.Back)
            Case Chr(Keys.Delete)
            Case Else
                e.Handled = True
        End Select
    End Sub
#End Region

    Private Sub btnKeyCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyCard.Click
        Dim frmAdmin As New frmAdminScan()
        Dim theResult As DialogResult = MessageBox.Show("Are you sure you want to do this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Dim adminResult As DialogResult = frmAdmin.ShowDialog()
        If theResult = System.Windows.Forms.DialogResult.Yes And adminResult = System.Windows.Forms.DialogResult.Yes Then
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strSQL As String = "SELECT * FROM KeyCardTable WHERE isAdmin = 1"
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New System.Data.DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            Try
                If dtTemp.Rows.Count <= 2 Then
                    Throw New InvalidOperationException("Number of Administrators cannot be less than 2. Create an Administrator before you remove rights.")
                Else
                    comTemp.CommandText = "UPDATE KeyCardTable SET IsAdmin = 0, MadeAdminBy = 'REMOVED BY " & frmAdmin.getAuthorized() & "'  WHERE MemberID = " & aMember.MemberID
                End If
                comTemp.ExecuteNonQuery()
                btnKeyCard.Visible = False
            Catch ex As System.Exception
                MessageBox.Show("Unable to remove rights because of " & ex.Message, "Removal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Admin removal failed. Are you an Administrator?", "Removal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        txtFirst.Focus()
    End Sub

    Private Sub btnMerchandise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerchandise.Click
        Dim frmPassword As New frmAdminScan()
        If Not frmPassword.ShowDialog() = System.Windows.Forms.DialogResult.Yes Then Exit Sub
        Dim theForm As New frmMerchandise
        theForm.ShowDialog()
        txtFirst.Focus()
    End Sub

    Private Sub tmrLogin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLogin.Tick
        loggedInUser = String.Empty
        bolPass = False
        BackScreen()
        BackScreen()
        BackScreen()
        tmrLogin.Stop()
    End Sub

    Private Sub stbStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbStatus.Click
        loggedInUser = String.Empty
        bolPass = False
        tmrLogin.Stop()
        BackScreen()
        BackScreen()
        BackScreen()
    End Sub
End Class

Public Class SavePaid
    Public PaidRow As DataRow
    Public conPaid As SqlConnection

    Public Sub Save()

        If Not conPaid.State = ConnectionState.Open Then
            conPaid.Open()
        End If

        Dim oAdapt As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM CheckIns WHERE CheckInID = 0", conPaid)
        Dim PaidInsert As DataTable = New System.Data.DataTable
        oAdapt.Fill(PaidInsert)

        Dim cmdBuilder As SqlCommandBuilder = New SqlCommandBuilder(oAdapt)
        oAdapt.InsertCommand = cmdBuilder.GetInsertCommand
        oAdapt.UpdateCommand = cmdBuilder.GetUpdateCommand

        Dim aRow As DataRow = PaidInsert.NewRow
        aRow.ItemArray = PaidRow.ItemArray
        PaidInsert.Rows.Add(aRow)
        Try
            oAdapt.Update(PaidInsert)
        Catch ex As System.Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

End Class