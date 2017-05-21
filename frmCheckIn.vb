Imports System.Data.oledb
Imports System.Configuration.ConfigurationSettings

Public Class frmCheckIn
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

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
    Friend WithEvents cmdYearly As System.Windows.Forms.Button
    Friend WithEvents cmdClasses As System.Windows.Forms.Button
    Friend WithEvents cmdElements As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lstMembers As System.Windows.Forms.ListBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents stbMain As System.Windows.Forms.StatusBar
    Friend WithEvents pnlStatus As System.Windows.Forms.StatusBarPanel
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents cmdSingleNight As System.Windows.Forms.Button
    Friend WithEvents cboLookUpBy As System.Windows.Forms.ComboBox
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCash As System.Windows.Forms.Button
    Friend WithEvents cmdCheck As System.Windows.Forms.Button
    Friend WithEvents colMember As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCheckInDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstCheckedIn As System.Windows.Forms.ListView
    Friend WithEvents mnuCheckedIn As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuRemoveCheckedInMember As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdYearly = New System.Windows.Forms.Button
        Me.cmdClasses = New System.Windows.Forms.Button
        Me.cmdElements = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdCash = New System.Windows.Forms.Button
        Me.lstMembers = New System.Windows.Forms.ListBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.stbMain = New System.Windows.Forms.StatusBar
        Me.pnlStatus = New System.Windows.Forms.StatusBarPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPrice = New System.Windows.Forms.Label
        Me.cmdSingleNight = New System.Windows.Forms.Button
        Me.cboLookUpBy = New System.Windows.Forms.ComboBox
        Me.cmdReport = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdCheck = New System.Windows.Forms.Button
        Me.lstCheckedIn = New System.Windows.Forms.ListView
        Me.colMember = New System.Windows.Forms.ColumnHeader
        Me.colCheckInDate = New System.Windows.Forms.ColumnHeader
        Me.mnuCheckedIn = New System.Windows.Forms.ContextMenu
        Me.mnuRemoveCheckedInMember = New System.Windows.Forms.MenuItem
        CType(Me.pnlStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdYearly
        '
        Me.cmdYearly.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdYearly.Location = New System.Drawing.Point(352, 0)
        Me.cmdYearly.Name = "cmdYearly"
        Me.cmdYearly.Size = New System.Drawing.Size(62, 48)
        Me.cmdYearly.TabIndex = 3
        Me.cmdYearly.Text = "&Yearly"
        '
        'cmdClasses
        '
        Me.cmdClasses.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdClasses.Location = New System.Drawing.Point(352, 52)
        Me.cmdClasses.Name = "cmdClasses"
        Me.cmdClasses.Size = New System.Drawing.Size(62, 48)
        Me.cmdClasses.TabIndex = 4
        Me.cmdClasses.Text = "&Monthly"
        '
        'cmdElements
        '
        Me.cmdElements.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdElements.Location = New System.Drawing.Point(352, 104)
        Me.cmdElements.Name = "cmdElements"
        Me.cmdElements.Size = New System.Drawing.Size(62, 48)
        Me.cmdElements.TabIndex = 5
        Me.cmdElements.Text = "&Elements"
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdClear.Location = New System.Drawing.Point(4, 372)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(62, 48)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "&Clear"
        '
        'cmdCash
        '
        Me.cmdCash.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCash.Location = New System.Drawing.Point(352, 208)
        Me.cmdCash.Name = "cmdCash"
        Me.cmdCash.Size = New System.Drawing.Size(62, 48)
        Me.cmdCash.TabIndex = 7
        Me.cmdCash.Text = "Cas&h"
        '
        'lstMembers
        '
        Me.lstMembers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstMembers.Location = New System.Drawing.Point(4, 28)
        Me.lstMembers.Name = "lstMembers"
        Me.lstMembers.Size = New System.Drawing.Size(340, 329)
        Me.lstMembers.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(92, 4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(116, 20)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = ""
        '
        'stbMain
        '
        Me.stbMain.Location = New System.Drawing.Point(0, 422)
        Me.stbMain.Name = "stbMain"
        Me.stbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.pnlStatus})
        Me.stbMain.ShowPanels = True
        Me.stbMain.Size = New System.Drawing.Size(744, 20)
        Me.stbMain.TabIndex = 14
        '
        'pnlStatus
        '
        Me.pnlStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.pnlStatus.Width = 728
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Member &Name"
        '
        'lblPrice
        '
        Me.lblPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(220, 372)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(124, 48)
        Me.lblPrice.TabIndex = 11
        '
        'cmdSingleNight
        '
        Me.cmdSingleNight.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSingleNight.Location = New System.Drawing.Point(352, 156)
        Me.cmdSingleNight.Name = "cmdSingleNight"
        Me.cmdSingleNight.Size = New System.Drawing.Size(62, 48)
        Me.cmdSingleNight.TabIndex = 6
        Me.cmdSingleNight.Text = "Single &Night"
        '
        'cboLookUpBy
        '
        Me.cboLookUpBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLookUpBy.Items.AddRange(New Object() {"By First Name", "By Last Name"})
        Me.cboLookUpBy.Location = New System.Drawing.Point(244, 4)
        Me.cboLookUpBy.Name = "cboLookUpBy"
        Me.cboLookUpBy.Size = New System.Drawing.Size(100, 21)
        Me.cboLookUpBy.TabIndex = 13
        Me.cboLookUpBy.TabStop = False
        '
        'cmdReport
        '
        Me.cmdReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdReport.Location = New System.Drawing.Point(144, 372)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(62, 48)
        Me.cmdReport.TabIndex = 10
        Me.cmdReport.TabStop = False
        Me.cmdReport.Text = "&Report"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(212, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Sort"
        '
        'cmdCheck
        '
        Me.cmdCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCheck.Location = New System.Drawing.Point(352, 260)
        Me.cmdCheck.Name = "cmdCheck"
        Me.cmdCheck.Size = New System.Drawing.Size(62, 48)
        Me.cmdCheck.TabIndex = 8
        Me.cmdCheck.Text = "Chec&k"
        '
        'lstCheckedIn
        '
        Me.lstCheckedIn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCheckedIn.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMember, Me.colCheckInDate})
        Me.lstCheckedIn.ContextMenu = Me.mnuCheckedIn
        Me.lstCheckedIn.FullRowSelect = True
        Me.lstCheckedIn.Location = New System.Drawing.Point(420, 0)
        Me.lstCheckedIn.Name = "lstCheckedIn"
        Me.lstCheckedIn.Size = New System.Drawing.Size(324, 424)
        Me.lstCheckedIn.TabIndex = 15
        Me.lstCheckedIn.View = System.Windows.Forms.View.Details
        '
        'colMember
        '
        Me.colMember.Text = "Member Name"
        Me.colMember.Width = 200
        '
        'colCheckInDate
        '
        Me.colCheckInDate.Text = "Check In"
        Me.colCheckInDate.Width = 120
        '
        'mnuCheckedIn
        '
        Me.mnuCheckedIn.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRemoveCheckedInMember})
        '
        'mnuRemoveCheckedInMember
        '
        Me.mnuRemoveCheckedInMember.Index = 0
        Me.mnuRemoveCheckedInMember.Text = "Remove"
        '
        'frmCheckIn
        '
        Me.AcceptButton = Me.cmdCash
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdClear
        Me.ClientSize = New System.Drawing.Size(744, 442)
        Me.Controls.Add(Me.lstCheckedIn)
        Me.Controls.Add(Me.cmdCheck)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cboLookUpBy)
        Me.Controls.Add(Me.cmdSingleNight)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.stbMain)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lstMembers)
        Me.Controls.Add(Me.cmdCash)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdElements)
        Me.Controls.Add(Me.cmdClasses)
        Me.Controls.Add(Me.cmdYearly)
        Me.Name = "frmCheckIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Check In"
        CType(Me.pnlStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conMain = New OleDbConnection(AppSettings.Item("Connect"))
            cboLookUpBy.SelectedIndex = 0

            LoadCheckedInList()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        lstMembers.SelectedIndex = lstMembers.FindString(txtName.Text)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtName.Text = ""
        cmdYearly.BackColor = SystemColors.Control
        cmdClasses.BackColor = SystemColors.Control
        cmdElements.BackColor = SystemColors.Control
        lstMembers.SelectedIndex = -1
        txtName.Focus()
    End Sub

    Private Sub txtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        Select Case e.KeyData
            Case Keys.Down
                If lstMembers.SelectedIndex < lstMembers.Items.Count Then
                    lstMembers.SelectedIndex += 1
                    e.Handled = True
                End If
            Case Keys.Up
                If lstMembers.SelectedIndex > 0 Then
                    lstMembers.SelectedIndex -= 1
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub cmdYearly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYearly.Click

        Select Case cmdYearly.BackColor.Equals(Color.Yellow)
            Case True
                cmdYearly.BackColor = SystemColors.Control
            Case False
                cmdYearly.BackColor = Color.Yellow
        End Select
        CalcPrice()
    End Sub

    Private Sub cmdClasses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClasses.Click

        Select Case cmdClasses.BackColor.Equals(Color.Yellow)
            Case True
                cmdClasses.BackColor = SystemColors.Control
            Case False
                cmdClasses.BackColor = Color.Yellow
        End Select
        CalcPrice()

    End Sub

    Private Sub cmdElements_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdElements.Click

        Select Case cmdElements.BackColor.Equals(Color.Yellow)
            Case True
                cmdElements.BackColor = SystemColors.Control
            Case False
                cmdElements.BackColor = Color.Yellow
        End Select
        CalcPrice()

    End Sub

    Public Sub CalcPrice()
        Dim myMoney As Integer
        Dim aView As DataRowView
        If Not lstMembers.SelectedItem Is Nothing Then
            aView = CType(lstMembers.SelectedItem, DataRowView)
            If cmdYearly.BackColor.Equals(Color.Yellow) Then
                If Now > New Date(2005, 9, 1) Then
                    myMoney += 50
                Else
                    myMoney += 40
                End If
            End If
            If cmdClasses.BackColor.Equals(Color.Yellow) Then
                myMoney += aView.Item("LessonAmount")
            End If
            If cmdElements.BackColor.Equals(Color.Yellow) Then
                myMoney += 5
            End If
            If cmdSingleNight.BackColor.Equals(Color.Yellow) Then
                myMoney += 5
            End If
        End If
        lblPrice.Text = "$" & myMoney & ".00"

    End Sub
    Public Sub Status(ByVal Message As String)
        pnlStatus.Text = Message
    End Sub

    Private Sub lstMembers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMembers.SelectedIndexChanged
        CalcPrice()
    End Sub

    Private Sub cmdCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCash.Click
        SaveRec(enMoneyType.enCash)
    End Sub

    Private Sub cmdCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheck.Click
        SaveRec(enMoneyType.enCheck)
    End Sub
    Private Sub SaveRec(ByVal MoneyType As enMoneyType)
        Try
            Dim PaidFor As PaidItem
            If dsCheckIn Is Nothing Then
                dsCheckIn = New DataSet
            End If
            If dsCheckIn.Tables("CheckIn") Is Nothing Then
                dsCheckIn.Tables.Add(New DataTable("CheckIn"))
                dsCheckIn.Tables("CheckIn").Columns.Add("MemberName")
                dsCheckIn.Tables("CheckIn").Columns.Add("CheckInDate")
                dsCheckIn.Tables("CheckIn").Columns.Add("AmtCollected")
                dsCheckIn.Tables("CheckIn").Columns.Add("MoneyType")
                dsCheckIn.WriteXml("C:\SwingClubData\CheckIn.xml")
            Else
                dsCheckIn = New DataSet
                dsCheckIn.ReadXml("C:\SwingClubData\CheckIn.xml")
            End If

            If lstMembers.SelectedItem Is Nothing Then
                Status("No name selected")
            Else
                CalcPrice()
                Dim aRow As DataRow = dsCheckIn.Tables("CheckIn").NewRow

                Dim aView As DataRowView
                aView = CType(lstMembers.SelectedItem, DataRowView)
                Dim x As MemberCheckInItem = New MemberCheckInItem
                x.FirstName = aView.Item("Name")
                x.CheckedIn = Now

                If cmdYearly.BackColor.Equals(Color.Yellow) Then
                    PaidFor = New PaidItem
                    PaidFor.Desc = "Yearly Dues"
                    If Now > New Date(2005, 9, 1) Then
                        PaidFor.Amount = 50
                    Else
                        PaidFor.Amount = 40
                    End If
                    x.PaidFor.Add(PaidFor)
                End If
                If cmdClasses.BackColor.Equals(Color.Yellow) Then
                    PaidFor = New PaidItem
                    PaidFor.Desc = "Monthly Dues"
                    PaidFor.Amount = aView.Item("LessonAmount")
                    x.PaidFor.Add(PaidFor)
                End If
                If cmdElements.BackColor.Equals(Color.Yellow) Then
                    PaidFor = New PaidItem
                    PaidFor.Desc = "Elements"
                    PaidFor.Amount = 5
                    x.PaidFor.Add(PaidFor)
                End If
                If cmdSingleNight.BackColor.Equals(Color.Yellow) Then
                    PaidFor = New PaidItem
                    PaidFor.Desc = "Single Night"
                    PaidFor.Amount = 10
                    x.PaidFor.Add(PaidFor)
                End If
                'x.MoneyType = MoneyType

                aRow.Item("MemberName") = x.FirstName & " " & x.LastName
                aRow.Item("CheckInDate") = x.CheckedIn
                aRow.Item("AmtCollected") = x.PaidFor.Total
                Select Case MoneyType
                    Case enMoneyType.enCash
                        aRow.Item("MoneyType") = 1
                    Case enMoneyType.enCheck
                        aRow.Item("MoneyType") = 2
                End Select

                dsCheckIn.Tables("CheckIn").Rows.Add(aRow)
                dsCheckIn.WriteXml("C:\SwingClubData\CheckIn.xml")

                Dim aItem As ListViewItem = New ListViewItem
                aItem.Text = x.ToString
                aItem.SubItems.Add(x.CheckedIn)
                lstCheckedIn.Items.Add(aItem)

                Status("Entered: " & aView.Item("Name") & " with " & lblPrice.Text)
            End If
            txtName.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cmdSingleNight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSingleNight.Click

        Select Case cmdSingleNight.BackColor.Equals(Color.Yellow)
            Case True
                cmdSingleNight.BackColor = SystemColors.Control
            Case False
                cmdSingleNight.BackColor = Color.Yellow
        End Select
        CalcPrice()

    End Sub

    Private Sub cboLookUpBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLookUpBy.SelectedIndexChanged
        Dim oAdapt As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM qrySignInSheet", conMain)
        Members = New DataTable
        oAdapt.Fill(Members)

        Dim aView As DataView = New DataView(Members)
        Select Case cboLookUpBy.SelectedIndex
            Case 0 'FirstName
                If Not Members.Columns.Contains("Name2") Then
                    Members.Columns.Add(New DataColumn("Name2"))
                    Members.Columns.Item("Name2").Expression = "FirstName + ' ' + LastName "
                End If
                lstMembers.DisplayMember = "Name2"
                aView.Sort = "Name2"
            Case 1 'LastName
                lstMembers.DisplayMember = "Name"
                aView.Sort = "Name"
        End Select
        lstMembers.DataSource = aView

    End Sub

    Private Sub mnuRemoveCheckedInMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRemoveCheckedInMember.Click
        Try
            For x As Integer = 0 To lstCheckedIn.SelectedItems.Count - 1
                Dim aRow() As DataRow = dsCheckIn.Tables("CheckIn").Select("MemberName = '" & lstCheckedIn.SelectedItems(x).Text & "' AND CheckInDate = '" & lstCheckedIn.SelectedItems(x).SubItems(1).Text & "'")
                dsCheckIn.Tables("CheckIn").Rows.Remove(aRow(0))
                dsCheckIn.WriteXml("C:\SwingClubData\CheckIn.xml")
                dsCheckIn = New DataSet
                dsCheckIn.ReadXml("C:\SwingClubData\CheckIn.xml")
            Next
            LoadCheckedInList()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadCheckedInList()
        lstCheckedIn.Items.Clear()
        If System.IO.File.Exists("C:\SwingClubData\CheckIn.xml") Then
            dsCheckIn = New DataSet
            dsCheckIn.ReadXml("C:\SwingClubData\CheckIn.xml")
            If Not dsCheckIn.Tables("CheckIn") Is Nothing Then
                For Each aRow As DataRow In dsCheckIn.Tables("CheckIn").Rows
                    Dim aItem As ListViewItem = New ListViewItem
                    aItem.Text = aRow.Item("MemberName")
                    aItem.SubItems.Add(aRow.Item("CheckInDate"))
                    lstCheckedIn.Items.Add(aItem)
                Next
            End If
        End If
    End Sub

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
        Dim x As frmReport = New frmReport
        x.ShowDialog()
    End Sub
End Class
