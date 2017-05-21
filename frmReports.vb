'*****************************************************
' frmReports             Version 2.08
'*****************************************************
'Version 1 Author: J.Erik Thompson
'Version 2 Author: David Schrock
'******************************************************
'Program Description: Gives various reports to the club
'administrators in order to run club functions
'******************************************************
' This code is the property of the Oklahoma City Swing Dance
' Club and can only be used by authorized persons of the club
' or the authors.
'******************************************************
' Version 2.00: First Post 1.00 version
' Version 2.01: Fixed Year to Date
' Version 2.02: Added Betas for Dancer color and reworked year to date
' Version 2.03: Made Betas from 2.03 permenant and added Dancer lists 2, 10, and Full
' Version 2.04: Added New and Renew Members, Renamed Year to date Members for Drawing and added dancer counter,
' Added paid members List, changed todays payers and summary to go off of PaidDate instead of CreateDate
' Version 2.05: Added members currently in classes and labels for post cards.
' Version 2.08: Removed 2 year back and 10 year back list to replace with Voided Entries and Deleted Members
'******************************************************
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class frmReports

#Region "Private Global Variables"
    Private bolPass As Boolean = False
    'Indicates if we are changing the selected node of the treeview programmatically
    Private ChangingSelectedNode As Boolean
    Private Header As String
    Private ReportItems As DataTable
    Private DateRangeTurnedOn As Boolean = False

#End Region

#Region "Initial Loader"
    Private Sub frmReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the UI
        LoadReportList()
        TreeView.ExpandAll()
        CreateReports()
        Try
            Dim aThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateTodaysDancers)
            aThread.Start()

            Dim bThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateTodaysPayers)
            bThread.Start()

            Dim cThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateYearlyPayments)
            cThread.Start()

            Dim dThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateBirthdays)
            dThread.Start()

            Dim eThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateEMailList)
            eThread.Start()

            Dim fThread As System.Threading.Thread = New System.Threading.Thread(AddressOf DisplayAdmins)
            fThread.Start()

            Dim gThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateModifiedMembers)
            gThread.Start()

            Dim hThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateNonReturningMembers)
            hThread.Start()

            Dim iThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateExpiringMembers)
            iThread.Start()

            Dim jThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateTodaysSummary)
            jThread.Start()

            Dim kThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateNewDancers)
            kThread.Start()

            Dim lThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateState)
            lThread.Start()

            Dim mThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateNewMembers)
            mThread.Start()

            Dim nThread As System.Threading.Thread = New System.Threading.Thread(AddressOf ListPinkDancers)
            nThread.Start()

            Dim oThread As System.Threading.Thread = New System.Threading.Thread(AddressOf ListPurpleDancers)
            oThread.Start()

            'Dim pThread As System.Threading.Thread = New System.Threading.Thread(AddressOf ListRedDancers)
            'pThread.Start()

            Dim qThread As System.Threading.Thread = New System.Threading.Thread(AddressOf ListYellowDancers)
            qThread.Start()

            Dim rThread As System.Threading.Thread = New System.Threading.Thread(AddressOf ListGreenDancers)
            rThread.Start()

            Dim sThread As System.Threading.Thread = New System.Threading.Thread(AddressOf ListBlueDancers)
            sThread.Start()

            Dim tThread As System.Threading.Thread = New System.Threading.Thread(AddressOf ListTeachers)
            tThread.Start()

            Dim uThread As System.Threading.Thread = New System.Threading.Thread(AddressOf ListUnknownDancers)
            uThread.Start()

            Dim vThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateVoidedEntriesList)
            vThread.Start()

            Dim wThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateDeletedMembersList)
            wThread.Start()

            Dim xThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateFullList)
            xThread.Start()

            Dim yThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateSpecialEvents)
            yThread.Start()

            Dim zThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateReNewMembers)
            zThread.Start()

            Dim aaThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreatePaidMemberList)
            aaThread.Start()

            Dim abThread As System.Threading.Thread = New System.Threading.Thread(AddressOf CreateDancersInLessons)
            abThread.Start()
        Catch ex As Exception

        End Try
        Web.Navigate(Application.CommonAppDataPath & "\MonthlyDancers.html")

    End Sub

#End Region

#Region "Report Loader"
    Private Sub LoadReportList()
        ' TODO: Add code to add items to the treeview
        Dim tvRoot As TreeNode
        ' These lines of code create the selectable items
        ' on the reports list
        tvRoot = Me.TreeView.Nodes.Add("Basic Reports")
        tvRoot.Nodes.Add("Basic Reports", "Monthly Dancers")
        tvRoot.Nodes.Add("Basic Reports", "Dancers Currently In Lessons")
        tvRoot.Nodes.Add("Basic Reports", "Todays Dancers")
        tvRoot.Nodes.Add("Basic Reports", "Todays Paying Dancers")
        tvRoot.Nodes.Add("Basic Reports", "Todays Summary")
        tvRoot.Nodes.Add("Basic Reports", "Yearly Dues")
        tvRoot.Nodes.Add("Basic Reports", "Email")
        tvRoot.Nodes.Add("Basic Reports", "Current Administrators")
        tvRoot.Nodes.Add("Basic Reports", "Special Events")
        tvRoot.Nodes.Add("Basic Reports", "Unknown Dancers")
        tvRoot.Nodes.Add("Basic Reports", "Pink Dancers")
        tvRoot.Nodes.Add("Basic Reports", "Purple Dancers")
        tvRoot.Nodes.Add("Basic Reports", "Yellow Dancers")
        tvRoot.Nodes.Add("Basic Reports", "Green Dancers")
        tvRoot.Nodes.Add("Basic Reports", "Blue Dancers")
        tvRoot.Nodes.Add("Basic Reports", "Teachers")
        tvRoot = Me.TreeView.Nodes.Add("Admin Reports")
        tvRoot.Nodes.Add("Admin Reports", "Birthdays")
        tvRoot.Nodes.Add("Admin Reports", "Members Modified in Database")
        tvRoot.Nodes.Add("Admin Reports", "Non Returning Members")
        tvRoot.Nodes.Add("Admin Reports", "Expiring Members")
        tvRoot.Nodes.Add("Admin Reports", "New Dancers")
        tvRoot.Nodes.Add("Admin Reports", "State")
        tvRoot.Nodes.Add("Admin Reports", "New Members")
        tvRoot.Nodes.Add("Admin Reports", "Renewing Members")
        tvRoot.Nodes.Add("Admin Reports", "Voided Entries")
        tvRoot.Nodes.Add("Admin Reports", "Deleted Members")
        tvRoot.Nodes.Add("Admin Reports", "Currently Paid Members")
        tvRoot.Nodes.Add("Admin Reports", "Complete Member List")
        'tvRoot.Nodes.Add("Admin Reports", "Labels for Postcards (3months)")
    End Sub
#End Region

#Region "Button and click handlers"
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView.AfterSelect
        ' TODO: Add code to change the listview contents based on the currently-selected node of the treeview
        LoadWebReport()
    End Sub

    Private Shared Function SortMembers(ByVal x As MemberCheckInItem, ByVal y As MemberCheckInItem) As Integer
        Dim intReturn As Integer = String.Compare(x.LastName, y.LastName)
        If intReturn = 0 Then
            intReturn = String.Compare(x.FirstName, y.FirstName)
        End If
        Return intReturn
    End Function

    Private Sub dteDateEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dteDateEnd.ValueChanged, dteDate.ValueChanged
        If DateRangeOffToolStripMenuItem.Text = "Date Range On" And dteDateEnd.Value < dteDate.Value Then
            dteDate.Value = dteDateEnd.Value.AddDays(-1)
        End If
        CreateReports()
        LoadWebReport()
    End Sub

    Private Sub DateRangeOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateRangeOffToolStripMenuItem.Click
        If DateRangeOffToolStripMenuItem.Text = "Date Range Off" Then
            DateRangeOffToolStripMenuItem.Text = "Date Range On"
            dteDateEnd.Enabled = True
            dteDateEnd.Value = dteDate.Value.AddDays(1)
            DateRangeTurnedOn = True
        Else
            DateRangeOffToolStripMenuItem.Text = "Date Range Off"
            dteDateEnd.Enabled = False
            DateRangeOffToolStripMenuItem.Enabled = True
            DateRangeTurnedOn = False
        End If
        CreateReports()
        LoadWebReport()
    End Sub
#End Region

#Region "Selected Actions"

    Private Sub LoadWebReport()
        Dim fPassword As frmAdminScan = New frmAdminScan
        Dim tvRoot As TreeNode = Me.TreeView.SelectedNode
        'The next two if statements prevent the form's focus from
        'either Basic Reports or Admin Reports
        If tvRoot.Text = "Basic Reports" Then
            Me.TreeView.SelectedNode = Me.TreeView.SelectedNode.FirstNode
            LoadWebReport()
            Exit Sub
        End If
        If tvRoot.Text = "Admin Reports" Then
            Me.TreeView.SelectedNode = Me.TreeView.SelectedNode.FirstNode
            LoadWebReport()
            Exit Sub
        End If
        Select Case tvRoot.Text
            Case "Monthly Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(True)
                End If
                CreateMonthly()
                Web.Navigate(Application.CommonAppDataPath & "\MonthlyDancers.html")
            Case "Dancers Currently In Lessons"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                CreateDancersInLessons()
                Web.Navigate(Application.CommonAppDataPath & "\DancerInLesson.html")
            Case "Todays Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                CreateTodaysDancers()
                Web.Navigate(Application.CommonAppDataPath & "\TodaysDancers.html")
            Case "Todays Paying Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                CreateTodaysPayers()
                Web.Navigate(Application.CommonAppDataPath & "\TodaysPayingDancers.html")
            Case "Todays Summary"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                CreateTodaysSummary()
                Web.Navigate(Application.CommonAppDataPath & "\TodaysSummary.html")
            Case "Yearly Dues"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                CreateYearlyPayments()
                Web.Navigate(Application.CommonAppDataPath & "\YearlyDues.html")
            Case "Email"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                CreateEMailList()
                Web.Navigate(Application.CommonAppDataPath & "\EmailAddresses.html")
            Case "Current Administrators"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                DisplayAdmins()
                Web.Navigate(Application.CommonAppDataPath & "\Admins.html")
            Case "Special Events"
                If DateRangeTurnedOn Then
                    enableDateRange(True)
                End If
                CreateSpecialEvents()
                Web.Navigate(Application.CommonAppDataPath & "\SpecialEvents.html")
            Case "Members Modified in Database"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(True)
                    End If
                    CreateModifiedMembers()
                    Web.Navigate(Application.CommonAppDataPath & "\ModifiedMembers.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(True)
                        End If
                        bolPass = True
                        CreateModifiedMembers()
                        Web.Navigate(Application.CommonAppDataPath & "\ModifiedMembers.html")
                    End If
                End If
            Case "Unknown Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                Web.Navigate(Application.CommonAppDataPath & "\UnknownDancers.html")
            Case "Pink Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                Web.Navigate(Application.CommonAppDataPath & "\PinkDancers.html")
            Case "Purple Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                Web.Navigate(Application.CommonAppDataPath & "\PurpleDancers.html")
            Case "Red Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                Web.Navigate(Application.CommonAppDataPath & "\RedDancers.html")
            Case "Yellow Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                Web.Navigate(Application.CommonAppDataPath & "\YellowDancers.html")
            Case "Green Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                Web.Navigate(Application.CommonAppDataPath & "\GreenDancers.html")
            Case "Blue Dancers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                Web.Navigate(Application.CommonAppDataPath & "\BlueDancers.html")
            Case "Teachers"
                If DateRangeTurnedOn Then
                    enableDateRange(False)
                End If
                Web.Navigate(Application.CommonAppDataPath & "\Teachers.html")
            Case "Birthdays"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(True)
                    End If
                    CreateBirthdays()
                    Web.Navigate(Application.CommonAppDataPath & "\Birthdays.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(True)
                        End If
                        bolPass = True
                        CreateBirthdays()
                        Web.Navigate(Application.CommonAppDataPath & "\Birthdays.html")
                    End If
                End If
            Case "Non Returning Members"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(False)
                    End If
                    CreateNonReturningMembers()
                    Web.Navigate(Application.CommonAppDataPath & "\NonReturningMembers.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(False)
                        End If
                        bolPass = True
                        CreateNonReturningMembers()
                        Web.Navigate(Application.CommonAppDataPath & "\NonReturningMembers.html")
                    End If
                End If
            Case "Expiring Members"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(False)
                    End If
                    CreateExpiringMembers()
                    Web.Navigate(Application.CommonAppDataPath & "\ExpiringMembers.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(False)
                        End If
                        bolPass = True
                        CreateExpiringMembers()
                        Web.Navigate(Application.CommonAppDataPath & "\ExpiringMembers.html")
                    End If
                End If
            Case "New Dancers"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(False)
                    End If
                    CreateNewDancers()
                    Web.Navigate(Application.CommonAppDataPath & "\NewDancers.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(False)
                        End If
                        bolPass = True
                        CreateNewDancers()
                        Web.Navigate(Application.CommonAppDataPath & "\NewDancers.html")
                    End If
                End If
            Case "New Members"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(False)
                    End If
                    CreateNewMembers()
                    Web.Navigate(Application.CommonAppDataPath & "\NewMembers.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(False)
                        End If
                        bolPass = True
                        CreateNewMembers()
                        Web.Navigate(Application.CommonAppDataPath & "\NewMembers.html")
                    End If
                End If
            Case "Renewing Members"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(False)
                    End If
                    CreateReNewMembers()
                    Web.Navigate(Application.CommonAppDataPath & "\RenewMembers.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(False)
                        End If
                        bolPass = True
                        CreateReNewMembers()
                        Web.Navigate(Application.CommonAppDataPath & "\RenewMembers.html")
                    End If
                End If
            Case "State"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(True)
                    End If
                    CreateState()
                    Web.Navigate(Application.CommonAppDataPath & "\State.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(True)
                        End If
                        bolPass = True
                        CreateState()
                        Web.Navigate(Application.CommonAppDataPath & "\State.html")
                    End If
                End If
            Case "Voided Entries"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(False)
                    End If
                    Web.Navigate(Application.CommonAppDataPath & "\VoidedEntries.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(False)
                        End If
                        bolPass = True
                        Web.Navigate(Application.CommonAppDataPath & "\VoidedEntries.html")
                    End If
                End If
            Case "Deleted Members"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(False)
                    End If
                    Web.Navigate(Application.CommonAppDataPath & "\DeletedMembers.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(False)
                        End If
                        bolPass = True
                        Web.Navigate(Application.CommonAppDataPath & "\DeletedMembers.html")
                    End If
                End If
            Case "Currently Paid Members"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(False)
                    End If
                    Web.Navigate(Application.CommonAppDataPath & "\PaidMemList.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(False)
                        End If
                        bolPass = True
                        Web.Navigate(Application.CommonAppDataPath & "\PaidMemList.html")
                    End If
                End If
            Case "Complete Member List"
                If bolPass Then
                    If DateRangeTurnedOn Then
                        enableDateRange(False)
                    End If
                    Web.Navigate(Application.CommonAppDataPath & "\FullList.html")
                Else
                    Dim aResult As DialogResult = fPassword.ShowDialog()
                    If aResult = Windows.Forms.DialogResult.Yes Then
                        If DateRangeTurnedOn Then
                            enableDateRange(False)
                        End If
                        bolPass = True
                        Web.Navigate(Application.CommonAppDataPath & "\FullList.html")
                    End If
                End If
            Case Else
                Debug.WriteLine(tvRoot.Text)
        End Select
    End Sub
#End Region

#Region "Menu Methods"

    Private Sub CreateMonthly()
        Dim grandTotal As Decimal = 0
        Dim aView As DataView = New DataView(ReportItems)
        Dim StartDate As Date = CDate(dteDate.Value.ToString("MM-01-yyyy"))
        Dim EndDate As Date = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
        Dim strCheckIns As String = ""
        Dim LastMember As String = ""
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder

        If DateRangeOffToolStripMenuItem.Text = "Date Range On" Then
            StartDate = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
            EndDate = CDate(dteDateEnd.Value.ToString("MM-dd-yyyy"))
        End If

        'Monthly Dancers
        aView.Sort = "LastName, FirstName"
        aView.RowFilter = "PaidDate >= '" & StartDate.ToString("MM-dd-yyyy") & "' AND PaidDate <= '" & EndDate.ToString("MM-dd-yyyy") & "'"
        For Each aRow As DataRowView In aView
            If Not LastMember = aRow.Item("LastName") & aRow.Item("FirstName") Then
                If strCheckIns.Length > 0 Then
                    strBuilder.Append("&nbsp;</TD>")
                    strBuilder.Append("<TD>" & strCheckIns & "</TD></TR>")
                End If
                LastMember = aRow.Item("LastName") & aRow.Item("FirstName")
                strCheckIns = ""

                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(", ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B> (")
                If aRow.Item("MemberID") > 0 Then
                    strBuilder.Append(aRow.Item("MemberID"))
                Else
                    strBuilder.Append("New")
                End If
                strBuilder.Append(")</TD><TD>")
            End If
            Select Case aRow.Item("PaidDesc").ToString.IndexOf("Check-IN".ToUpper) > -1
                Case True
                    If strCheckIns.Length = 0 Then
                        strCheckIns &= "Check In Dates "
                    Else
                        strCheckIns &= ", "
                    End If
                    strCheckIns &= CDate(aRow.Item("PaidDate").ToString).Day
                Case Else
                    strBuilder.Append(aRow.Item("PaidDesc").ToString)
                    If aRow.Item("PaidAmount") > 0 Then
                        'strBuilder.Append(" ($" & String.Format("{0}.00", aRow.Item("PaidAmount")) & ")")
                        strBuilder.Append(" ($" & Convert.ToDecimal(aRow.Item("PaidAmount")).ToString("0.00") & ")")
                        grandTotal += Convert.ToDecimal(aRow.Item("PaidAmount"))
                    End If
                    strBuilder.Append(" " & aRow.Item("PaidDate") & "<BR>")
            End Select
        Next
        If strCheckIns.Length > 0 Then
            strBuilder.Append("&nbsp;</TD>")
            strBuilder.Append("<TD>" & strCheckIns & "</TD></TR>")
        End If
        strBuilder.Append("<TR><TD>Grand Total</TD><TD>" & grandTotal.ToString("C") & "</TD><TD></TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\MonthlyDancers.html", Header.Replace("%REPORTDESC%", "Monthly Dancers") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)
    End Sub
    Private Sub CreateDancersInLessons()
        Dim intDancerNumber As Integer = 0
        Dim DuplicateChecker As String = ""
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select MemberID, FirstName, LastName FROM checkins where (PaidType = 1 OR PaidType = 7) AND (MONTH(PaidDate) = " & _
        Now.Month & " AND YEAR(PaidDate) = " & Now.Year & ") ORDER BY LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                If CStr(aRow.Item("MemberID")) = DuplicateChecker Then
                    Continue For
                End If
                DuplicateChecker = CStr(aRow.Item("MemberID"))
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\DancerInLesson.html", Header.Replace("%REPORTDESC%", "Dancers In Lessons") & strBuilder.ToString & "</font></body></html>", False)
    End Sub
    Private Sub CreateTodaysDancers()
        Dim aView As DataView = New DataView(ReportItems)
        Dim EndDate As Date = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
        Dim strCheckIns As String = ""
        Dim LastMember As String = ""

        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'Todays Dancers
        strBuilder = New System.Text.StringBuilder
        aView.Sort = "LastName, FirstName"
        aView.RowFilter = "PaidDate = '" & EndDate.ToString("MM-dd-yyyy") & "'"
        For Each aRow As DataRowView In aView
            If Not LastMember = aRow.Item("LastName") & aRow.Item("FirstName") Then
                If strCheckIns.Length > 0 Then
                    strBuilder.Append("&nbsp;</TD>")
                    strBuilder.Append("<TD>" & strCheckIns & "</TD></TR>")
                End If
                LastMember = aRow.Item("LastName") & aRow.Item("FirstName")
                strCheckIns = ""

                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(", ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B> (")
                If aRow.Item("MemberID") > 0 Then
                    strBuilder.Append(aRow.Item("MemberID"))
                Else
                    strBuilder.Append("New")
                End If
                strBuilder.Append(")</TD><TD>")
            End If
            Select Case aRow.Item("PaidDesc").ToString.IndexOf("Check-IN".ToUpper) > -1
                Case True
                    If strCheckIns.Length = 0 Then
                        strCheckIns &= "Check In Dates "
                    Else
                        strCheckIns &= ", "
                    End If
                    strCheckIns &= CDate(aRow.Item("PaidDate").ToString).Day
                Case Else
                    strBuilder.Append(aRow.Item("PaidDesc").ToString)
                    If aRow.Item("PaidAmount") > 0 Then
                        strBuilder.Append(" (" & Convert.ToDecimal(aRow.Item("PaidAmount")).ToString("C") & ")")
                    End If
                    strBuilder.Append(" " & aRow.Item("PaidDate") & "<BR>")
            End Select
        Next
        If strCheckIns.Length > 0 Then
            strBuilder.Append("&nbsp;</TD>")
            strBuilder.Append("<TD>" & strCheckIns & "</TD></TR>")
        End If
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\TodaysDancers.html", Header.Replace("%REPORTDESC%", "Todays Dancers") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)
    End Sub
    Private Sub CreateTodaysPayers()
        Try
            Dim aView As DataView = New DataView(ReportItems)
            Dim EndDate As Date = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
            Dim strCheckIns As String = ""
            Dim LastMember As String = ""

            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            ''Todays Paying Dancers
            strBuilder = New System.Text.StringBuilder
            Dim MemberView As DataView = New DataView(ReportItems)
            MemberView.Sort = "PaidDesc, LastName, FirstName"
            MemberView.RowFilter = "PaidAmount <> '0.00' AND CreateDate >= '" & EndDate.ToString("yyyy-MM-dd") & "' AND CreateDate <= '" & EndDate.ToString("yyyy-MM-dd 23:59:59") & "'"
            Dim LastDesc As String = ""
            Dim intTotal As Decimal
            Dim intPageTotal As Decimal
            Dim bolTotalNow As Boolean = False
            For x As Integer = 0 To MemberView.Count - 1
                If Not LastDesc = MemberView.Item(x).Item("PaidDesc") Then
                    If LastDesc.Length > 0 Then
                        strBuilder.Append("<TR><TD align=right>" & LastDesc & " Total</TD><TD valign=center alighn=center><B>" & intTotal.ToString("C") & "</B></TD><TD>&nbsp;</TD></TR>")
                        intPageTotal += intTotal
                        intTotal = 0
                    End If
                    strBuilder.Append("<TR><TD><B>")
                    strBuilder.Append(MemberView.Item(x).Item("PaidDesc"))
                    LastDesc = MemberView.Item(x).Item("PaidDesc")
                Else
                    strBuilder.Append("<TR><TD><B>")
                End If
                strBuilder.Append("</B>")
                strBuilder.Append("</TD><TD>")
                strBuilder.Append(MemberView.Item(x).Item("PaidAmount"))
                intTotal += MemberView.Item(x).Item("PaidAmount")
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>" & MemberView.Item(x).Item("LastName") & ", " & MemberView.Item(x).Item("FirstName") & "</TD></TR>")
                If bolTotalNow Then
                    bolTotalNow = False
                End If
            Next
            strBuilder.Append("<TR><TD align=right>" & LastDesc & " Total</TD><TD valign=center alighn=center><B>" & intTotal.ToString("C") & "</B></TD><TD>&nbsp;</TD></TR>")
            intPageTotal += intTotal
            strBuilder.Append("<TR><TD align=right><B>Page Total</B></TD><TD valign=center alighn=center><B>" & intPageTotal.ToString("C") & "</B></TD><TD>&nbsp;</TD></TR>")
            My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\TodaysPayingDancers.html", Header.Replace("%REPORTDESC%", "Todays Paying Dancers") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try


    End Sub
    Private Sub CreateTodaysSummary()
        Try
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim StartDate As Date = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
            Dim strSQL As String = "SELECT PaidDesc, SUM(PaidAmount) AS PaidAmount FROM Checkins WHERE DATEDIFF(DAY, '" & StartDate.ToString("yyyy-MM-dd") & "', CreateDate) = 0 AND PaidAmount > 0 GROUP BY PaidDesc ORDER BY PaidDesc"
            Dim cashList As New List(Of DataRow)
            Dim checkList As New List(Of DataRow)
            Dim creditList As New List(Of DataRow)
            Dim cashTotal As Decimal = 0
            Dim checkTotal As Decimal = 0
            Dim creditTotal As Decimal = 0

            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            ''Todays Paying Dancers
            strBuilder = New System.Text.StringBuilder
            Dim intPageTotal As Double
            For Each aRow As DataRow In dtTemp.Rows
                intPageTotal += aRow.Item("PaidAmount")
                If aRow.Item("PaidDesc").ToString.Contains("PAID BY CASH") Then
                    cashList.Add(aRow)
                ElseIf aRow.Item("PaidDesc").ToString.Contains("PAID BY CHECK") Then
                    checkList.Add(aRow)
                Else
                    creditList.Add(aRow)
                End If
            Next

            For Each cashRow As DataRow In cashList
                cashTotal += cashRow.Item("PaidAmount")
                strBuilder.Append("<TR><TD><B>" & cashRow.Item("PaidDesc").ToString & "</TD><TD align=right>" & Convert.ToDecimal(cashRow.Item("PaidAmount")).ToString("C") & "</TD></TR>")
            Next
            strBuilder.Append("<TR><TD align=right><B>Cash Total</B></TD><TD valign=center alighn=center><B>" & cashTotal.ToString("C") & "</B></TD></TR>")
            For Each checkRow As DataRow In checkList
                checkTotal += checkRow.Item("PaidAmount")
                strBuilder.Append("<TR><TD><B>" & checkRow.Item("PaidDesc").ToString & "</TD><TD align=right>" & Convert.ToDecimal(checkRow.Item("PaidAmount")).ToString("C") & "</TD></TR>")
            Next
            strBuilder.Append("<TR><TD align=right><B>Check Total</B></TD><TD valign=center alighn=center><B>" & checkTotal.ToString("C") & "</B></TD></TR>")
            For Each creditRow As DataRow In creditList
                creditTotal += creditRow.Item("PaidAmount")
                strBuilder.Append("<TR><TD><B>" & creditRow.Item("PaidDesc").ToString & "</TD><TD align=right>" & Convert.ToDecimal(creditRow.Item("PaidAmount")).ToString("C") & "</TD></TR>")
            Next
            strBuilder.Append("<TR><TD align=right><B>Credit Total</B></TD><TD valign=center alighn=center><B>" & creditTotal.ToString("C") & "</B></TD></TR>")
            strBuilder.Append("<TR><TD align=right><B>Grand Total</B></TD><TD valign=center alighn=center><B>" & intPageTotal.ToString("C") & "</B></TD></TR>")
            My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\TodaysSummary.html", Header.Replace("%REPORTDESC%", "Todays Summary") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try


    End Sub

    Private Sub CreateSpecialEvents()
        Dim StartDate As Date = New Date(dteDate.Value.Year, dteDate.Value.Month, 1)
        Dim EndDate As Date = dteDate.Value
        If DateRangeOffToolStripMenuItem.Text = "Date Range On" Then
            StartDate = dteDate.Value
            EndDate = dteDateEnd.Value
        End If
        Dim grandTotal As Decimal = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select * from CheckIns where PaidDesc LIKE '%SPECIAL%' and PaidDate >= '" & StartDate & "' and PaidDate <= '" & EndDate & "'"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        strBuilder.Append("<TR><TD>NAME</TD><TD>DESCRIPTION</TD><TD>DATE</TD><TD>AMOUNT</TD></TR>")
        For Each aRow As DataRow In dtTemp.Rows
            Try
                strBuilder.Append("<TR><TD>")
                strBuilder.Append(aRow.Item("FirstName") & " , " & aRow.Item("LastName"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("PaidDesc"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("PaidDate"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                If aRow.Item("PaidAmount") > 0 Then
                    strBuilder.Append(" $" & Convert.ToDecimal(aRow.Item("PaidAmount")).ToString("0.00") & "")
                    grandTotal += Convert.ToDecimal(aRow.Item("PaidAmount")).ToString("0.00")
                End If
                strBuilder.Append("</TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<tr><td>Grand Total:</td><td></td><td></td><td>" & grandTotal.ToString("C") & "</td></tr>")

        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\SpecialEvents.html", Header.Replace("%REPORTDESC%", "Special Events") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)
    End Sub
    Private Sub CreateEMailList()
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'This months Birthdays
        strBuilder = New System.Text.StringBuilder
        Dim EmailView As DataView = New DataView(Members)
        EmailView.RowFilter = "EmailAddress > ''"
        EmailView.Sort = "LastName, FirstName"
        For x As Integer = 0 To EmailView.Count - 1
            Dim aRow As DataRow = EmailView.Item(x).Row
            If Not aRow.Item("Anniversary") Is DBNull.Value Then
                If aRow.Item("Anniversary") > Now.AddMonths(-2) Then
                    strBuilder.Append("<TR><TD><B>")
                    strBuilder.Append(aRow.Item("LastName"))
                    strBuilder.Append(", ")
                    strBuilder.Append(aRow.Item("FirstName"))
                    strBuilder.Append("</B>")
                    strBuilder.Append("</TD><TD align=center>" & aRow.Item("EmailAddress"))
                    strBuilder.Append("</TD></TR>")
                End If
            End If
        Next
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\EmailAddresses.html", Header.Replace("%REPORTDESC%", "Email Addresses") & strBuilder.ToString & "</font></body></html>", False)
    End Sub
    Private Sub DisplayAdmins()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select * from KeyCardTable where IsAdmin = 1 order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</TD><TD>")
                strBuilder.Append("Made Admin By: " + aRow.Item("MadeAdminBy"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\Admins.html", Header.Replace("%REPORTDESC%", "Current Administrators") & strBuilder.ToString & "</font></body></html>", False)
    End Sub
    Private Sub CreateBirthdays()
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'This months Birthdays
        strBuilder = New System.Text.StringBuilder
        Dim BirthDayView As DataView = New DataView(Members)
        BirthDayView.Sort = "LastName, FirstName"
        'BirthDayView.RowFilter = "MemberID = 6946"

        For x As Integer = 0 To BirthDayView.Count - 1
            Try

                Dim intMonth As Integer = 0
                Dim intDay As Integer = 0


                Dim aRow As DataRow = BirthDayView.Item(x).Row
                If (Not aRow.Item("DOB") Is DBNull.Value) AndAlso IsDate(aRow.Item("DOB")) Then
                    intMonth = CDate(aRow.Item("DOB")).Month
                    intDay = CDate(aRow.Item("DOB")).Day
                Else
                    If Not aRow.Item("BirthMonth") Is DBNull.Value Then
                        If Not aRow.Item("BirthDay") Is DBNull.Value Then
                            If IsNumeric(aRow.Item("BirthMonth")) Then
                                intMonth = CDate(aRow.Item("BirthMonth")).Month
                            End If
                            If IsNumeric(aRow.Item("BirthDay")) Then
                                intDay = CDate(aRow.Item("BirthDay")).Year
                            End If
                        End If
                    End If
                End If

                If Not aRow.Item("Anniversary") Is DBNull.Value Then
                    If aRow.Item("Anniversary") > Now.AddMonths(-1) Then
                        If intMonth = dteDate.Value.Month Then
                            strBuilder.Append("<TR><TD><B>" & aRow.Item("LastName") & ", " & aRow.Item("FirstName") & "</B></TD>")
                            strBuilder.Append("<TD align=center>" & intMonth & "/" & intDay & "</TD>")
                            strBuilder.Append("<TD align=center>" & aRow.Item("Address") & "</TD>")
                            strBuilder.Append("<TD align=center>" & aRow.Item("City") & "</TD>")
                            strBuilder.Append("<TD align=center>" & aRow.Item("State") & "</TD>")
                            strBuilder.Append("<TD align=center>" & aRow.Item("Zip") & "</TD>")
                            strBuilder.Append("</TR>")
                        End If
                    End If
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.ToString)
            End Try
        Next
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\Birthdays.html", Header.Replace("%REPORTDESC%", "Birthdays") & strBuilder.ToString & "</font></body></html>", False)
    End Sub
    Private Sub CreateNonReturningMembers()
        Try
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            'Members that were not here this month but they were here last month
            Dim StartDate As Date = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
            Dim strSQL As String = "SELECT * FROM OKSwingMemberList WHERE Anniversary > '" & StartDate.ToString("yyyy-MM-dd") & "' AND Address > '' AND MemberID NOT IN (SELECT MemberID FROM CheckIns WHERE DATEDIFF(MONTH, PaidDate, '" & StartDate.ToString("yyyy-MM-dd") & "') <= 2) ORDER BY LastName, FirstName"
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, conMain)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            anAdapt.Fill(dtTemp)
            For Each aRow As DataRow In dtTemp.Rows
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(", ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD align=center>" & aRow.Item("HomePhone").ToString & "</TD> ")
                strBuilder.Append("<TD align=center>" & aRow.Item("Address") & ", " & aRow.Item("City") & ", " & aRow.Item("State") & ", " & aRow.Item("Zip") & "</TD>")
                strBuilder.Append("</TR>")
            Next
            comTemp.Dispose()
            anAdapt.Dispose()

            My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\NonReturningMembers.html", Header.Replace("%REPORTDESC%", "Non Returning Members") & strBuilder.ToString & "</font></body></html>", False)
            Debug.WriteLine(Application.CommonAppDataPath & "\NonReturningMembers.html")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CreateExpiringMembers()
        Try
            Dim dancerCounter As Integer = 0
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            'Members that were not here this month but they were here last month
            Dim StartDate As Date = CDate(dteDate.Value.ToString("MM-01-yyyy"))
            Dim strSQL As String = "SELECT * FROM OKSwingMemberList WHERE DATEDIFF(MONTH, Anniversary, '" & StartDate & "') = 0 AND NOT MemberID IN (SELECT MemberID FROM CheckIns WHERE PaidType = 2 AND PaidDate > DATEADD(MONTH, -6, '" & StartDate & "')) and Type = 'REGULAR' ORDER BY LastName, FirstName"

            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            For Each aRow As DataRow In dtTemp.Rows
                If Not aRow.Item("Address") Is Nothing Then
                    If aRow.Item("Address").ToString.Length > 0 Then
                        strBuilder.Append("<TR><TD><B>")
                        strBuilder.Append(aRow.Item("LastName"))
                        strBuilder.Append(", ")
                        strBuilder.Append(aRow.Item("FirstName"))
                        strBuilder.Append("</B></TD>")
                        strBuilder.Append("<TD align=center>" & Convert.ToDateTime(aRow.Item("Anniversary")).ToString("MMM dd, yyyy") & "</TD> ")
                        strBuilder.Append("<TD align=center>" & aRow.Item("HomePhone").ToString & "</TD> ")
                        strBuilder.Append("<TD align=center>" & aRow.Item("Address") & ", " & aRow.Item("City") & ", " & aRow.Item("State") & ", " & aRow.Item("Zip") & "</TD>")
                        strBuilder.Append("</TR>")
                        dancerCounter += 1
                    End If
                End If
            Next
            strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD></TD><TD></TD><TD align=center>" & dancerCounter & "</TD></TR>")
            aConn.Close()
            comTemp.Dispose()
            anAdapt.Dispose()

            My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\ExpiringMembers.html", Header.Replace("%REPORTDESC%", "Expiring Members") & strBuilder.ToString & "</font></body></html>", False)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CreateNewDancers()
        Try
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            'Members that were not here this month but they were here last month
            Dim StartDate As Date = CDate(dteDate.Value.ToString("MM-01-yyyy"))
            Dim strSQL As String = "SELECT * FROM dbo.OKSwingMemberList WHERE DATEDIFF(MONTH, DateJoined, '" & dteDate.Value.ToString("yyyy-MM-dd") & "') = 0 ORDER BY LastName, FirstName"

            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            For Each aRow As DataRow In dtTemp.Rows
                If Not aRow.Item("Address") Is Nothing Then
                    If True Or aRow.Item("Address").ToString.Length > 0 Then
                        strBuilder.Append("<TR><TD><B>")
                        strBuilder.Append(aRow.Item("LastName"))
                        strBuilder.Append(", ")
                        strBuilder.Append(aRow.Item("FirstName"))
                        strBuilder.Append("</B></TD>")
                        strBuilder.Append("<TD align=center>" & Convert.ToDateTime(aRow.Item("Anniversary")).ToString("MMM dd, yyyy") & "</TD> ")
                        strBuilder.Append("<TD align=center>" & aRow.Item("HomePhone").ToString & "</TD> ")
                        strBuilder.Append("<TD align=center>" & aRow.Item("Address") & ", " & aRow.Item("City") & ", " & aRow.Item("State") & ", " & aRow.Item("Zip") & "</TD>")
                        strBuilder.Append("</TR>")
                    End If
                End If
            Next
            aConn.Close()
            comTemp.Dispose()
            anAdapt.Dispose()

            My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\NewDancers.html", Header.Replace("%REPORTDESC%", "New Dancers") & strBuilder.ToString & "</font></body></html>", False)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub CreateModifiedMembers()
        Dim StartDate As Date = CDate(dteDate.Value.ToString("MM-01-yyyy"))
        Dim EndDate As Date = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder

        If DateRangeOffToolStripMenuItem.Text = "Date Range On" Then
            StartDate = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
            EndDate = CDate(dteDateEnd.Value.ToString("MM-dd-yyyy"))
        End If

        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "Select * from OKSwingMemberList where DateLastUpdated >= '" & StartDate & "' AND DateLastUpdated <= '" & EndDate.AddDays(1).AddSeconds(-1) & "'"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        strBuilder.Append("<TR><TD><B>Member Modified</B></TD><TD><B>Member Modified By</B></TD></TR>")
        For Each aRow As DataRow In dtTemp.Rows
            If aRow.Item("LastUpdatedBy") <> String.Empty Then
                strBuilder.Append("<TR><TD>")
                strBuilder.Append(aRow.Item("MemberID") & " " & aRow.Item("FirstName") & " " & aRow.Item("LastName"))
                strBuilder.Append("</TD><TD>")
                strBuilder.Append(aRow.Item("LastUpdatedBy"))
                strBuilder.Append("</TD></TR>")
            End If
        Next
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\ModifiedMembers.html", Header.Replace("%REPORTDESC%", "Members That Have Been Modified") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)
    End Sub

    Private Sub ListUnknownDancers()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select FirstName, LastName, ClassID from OKSwingMemberList where ClassID = 0 order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD> UNKNOWN </TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\UnknownDancers.html", Header.Replace("%REPORTDESC%", "Unknown Dancers") & strBuilder.ToString & "</font></body></html>", False)
    End Sub

    Private Sub ListPinkDancers()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select FirstName, LastName, ClassID from OKSwingMemberList where ClassID = 1 order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD> PINK </TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\PinkDancers.html", Header.Replace("%REPORTDESC%", "Pink Dancers") & strBuilder.ToString & "</font></body></html>", False)
    End Sub

    Private Sub ListPurpleDancers()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select FirstName, LastName, ClassID from OKSwingMemberList where ClassID = 2 order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD> PURPLE </TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\PurpleDancers.html", Header.Replace("%REPORTDESC%", "Purple Dancers") & strBuilder.ToString & "</font></body></html>", False)
    End Sub

    Private Sub ListYellowDancers()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select FirstName, LastName, ClassID from OKSwingMemberList where ClassID = 4 order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD> YELLOW </TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\YellowDancers.html", Header.Replace("%REPORTDESC%", "Yellow Dancers") & strBuilder.ToString & "</font></body></html>", False)
    End Sub

    Private Sub ListGreenDancers()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select FirstName, LastName, ClassID from OKSwingMemberList where ClassID = 5 order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD> GREEN </TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\GreenDancers.html", Header.Replace("%REPORTDESC%", "Green Dancers") & strBuilder.ToString & "</font></body></html>", False)
    End Sub

    Private Sub ListBlueDancers()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select FirstName, LastName, ClassID from OKSwingMemberList where ClassID = 6 order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD> BLUE </TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\BlueDancers.html", Header.Replace("%REPORTDESC%", "Blue Dancers") & strBuilder.ToString & "</font></body></html>", False)
    End Sub

    Private Sub ListTeachers()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select FirstName, LastName, ClassID from OKSwingMemberList where ClassID = 7 order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD> TEACHER </TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\Teachers.html", Header.Replace("%REPORTDESC%", "Teachers") & strBuilder.ToString & "</font></body></html>", False)
    End Sub

    Private Sub CreateState()
        Try
            Dim intTotal As Integer = 0
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            'Members that were not here this month but they were here last month
            Dim StartDate As Date = CDate(dteDate.Value.ToString("MM-01-yyyy"))
            Dim strSQL As String = "SELECT * FROM CheckIns  C JOIN OKSwingMemberList M ON C.MemberID = M.MemberID WHERE PaidType = 5 AND DATEDIFF(YEAR, PaidDate, '" & dteDate.Value.ToString("yyyy-MM-dd") & "') = 0 ORDER BY M.LastName, M.FirstName DESC"

            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            For Each aRow As DataRow In dtTemp.Rows
                Try
                    intTotal += aRow.Item("PaidAmount")
                    strBuilder.Append("<TR><TD><B>")
                    strBuilder.Append(aRow.Item("LastName"))
                    strBuilder.Append(", ")
                    strBuilder.Append(aRow.Item("FirstName"))
                    strBuilder.Append("</B></TD>")
                    strBuilder.Append("<TD align=center>" & aRow.Item("PaidAmount").ToString & "</TD> ")
                    strBuilder.Append("<TD align=center>" & CDate(aRow.Item("PaidDate")).ToString("MMM dd, yyyy") & "</TD> ")
                    strBuilder.Append("<TD align=center>" & aRow.Item("HomePhone").ToString & "</TD> ")
                    strBuilder.Append("<TD align=center>" & aRow.Item("Address").ToString & ", " & aRow.Item("City").ToString & ", " & aRow.Item("State").ToString & ", " & aRow.Item("Zip").ToString & "</TD>")
                    strBuilder.Append("</TR>")
                Catch ex As Exception
                    Debug.WriteLine(ex.ToString)
                End Try
            Next
            strBuilder.Append("<TR><TD align=right><B>")
            strBuilder.Append("Total")
            strBuilder.Append("</B></TD>")
            strBuilder.Append("<TD colspan=4 align=left>" & intTotal & "</TD> ")
            strBuilder.Append("</TR>")
            aConn.Close()
            comTemp.Dispose()
            anAdapt.Dispose()

            My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\State.html", Header.Replace("%REPORTDESC%", "State") & strBuilder.ToString & "</font></body></html>", False)
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub CreateYearlyPayments()
        Dim aView As DataView = New DataView(ReportItems)
        Dim StartDate As Date = CDate(dteDate.Value.ToString("MM-01-yyyy"))
        Dim EndDate As Date = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
        Dim strCheckIns As String = ""
        Dim LastMember As String = ""

        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder

        If DateRangeOffToolStripMenuItem.Text = "Date Range On" Then
            StartDate = CDate(dteDate.Value.ToString("MM-dd-yyyy"))
            EndDate = CDate(dteDateEnd.Value.ToString("MM-dd-yyyy"))
        End If
        'Yearly Payments
        strBuilder = New System.Text.StringBuilder
        aView.Sort = "LastName, FirstName"
        aView.RowFilter = "PaidDate >= '" & StartDate.ToString("MM-dd-yyyy") & "' AND PaidDate <= '" & EndDate & "'"
        For Each aRow As DataRowView In aView
            If aRow.Item("PaidDesc").ToString.ToLower.IndexOf("yearly") > -1 Then
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(", ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B> (")
                If aRow.Item("MemberID") > 0 Then
                    strBuilder.Append(aRow.Item("MemberID"))
                Else
                    strBuilder.Append("New")
                End If
                strBuilder.Append(")</TD><TD>")
                strBuilder.Append(aRow.Item("PaidDesc").ToString)
                If aRow.Item("PaidAmount") > 0 Then
                    strBuilder.Append(" ($" & Convert.ToDecimal(aRow.Item("PaidAmount")).ToString("0.00") & ")")
                End If
                strBuilder.Append(" " & aRow.Item("PaidDate") & "<BR>")
            End If
        Next
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\YearlyDues.html", Header.Replace("%REPORTDESC%", "Yearly Dues") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)
    End Sub

    Private Sub CreateNewMembers()
        Dim StartDate As Date = New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 1)
        Dim EndDate As Date
        Select Case dteDate.Value.Month
            Case 1, 3, 5, 7, 8, 10, 12
                EndDate = CDate(New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 31))
            Case 2
                'This If statement covers leap years
                If ((Now.Year Mod 4) = 0) Then
                    EndDate = CDate(New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 29))
                Else
                    EndDate = CDate(New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 28))
                End If
            Case 4, 6, 9, 11
                EndDate = CDate(New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 30))
        End Select
        Dim strCheckIns As String = ""
        Dim LastMember As String = ""

        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'Members that were not here this month but they were here last month
        Dim strSQL As String = "Select * from OKSwingMemberList A where (select Count(PaidType) as YearlyCount from CheckIns B where A.MemberID = B.MemberID and PaidType = 2) = 1 and Anniversary >= '" & StartDate & "' and Anniversary <= '" & EndDate & "' order by LastName"

        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        strBuilder.Append("<TR><TD>Last Name</TD><TD>First Name</TD><TD>Date Joined</TD></TR>")
        For Each aRow As DataRow In dtTemp.Rows
            strBuilder.Append("<TR><TD>" & aRow.Item("Lastname") & "</TD><TD>" & aRow.Item("Firstname") & "</TD><TD>" & aRow.Item("DateJoined") & "</TD></TR>")
        Next
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\NewMembers.html", Header.Replace("%REPORTDESC%", "New Members") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)
    End Sub

    Private Sub CreateReNewMembers()
        Dim StartDate As Date = New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 1)
        Dim EndDate As Date
        Select Case dteDate.Value.Month
            Case 1, 3, 5, 7, 8, 10, 12
                EndDate = CDate(New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 31))
            Case 2
                'This If statement covers leap years
                If ((Now.Year Mod 4) = 0) Then
                    EndDate = CDate(New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 29))
                Else
                    EndDate = CDate(New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 28))
                End If
            Case 4, 6, 9, 11
                EndDate = CDate(New Date(dteDate.Value.Year + 1, dteDate.Value.Month, 30))
        End Select
        Dim strCheckIns As String = ""
        Dim LastMember As String = ""

        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'Members that were not here this month but they were here last month
        Dim strSQL As String = "Select * from OKSwingMemberList A where (select Count(PaidType) as YearlyCount from CheckIns B where A.MemberID = B.MemberID and PaidType = 2) > 1 and Anniversary >= '" & StartDate & "' and Anniversary <= '" & EndDate & "' order by LastName"

        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        strBuilder.Append("<TR><TD>Last Name</TD><TD>First Name</TD><TD>Date Joined</TD></TR>")
        For Each aRow As DataRow In dtTemp.Rows
            strBuilder.Append("<TR><TD>" & aRow.Item("Lastname") & "</TD><TD>" & aRow.Item("Firstname") & "</TD><TD>" & aRow.Item("DateJoined") & "</TD></TR>")
        Next
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\RenewMembers.html", Header.Replace("%REPORTDESC%", "Renewing Members") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)
    End Sub
    Private Sub CreateVoidedEntriesList()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select * from VoidedEntries order by CreateDate DESC"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        strBuilder.Append("<TR><TD>Name</TD><TD>Member ID</TD><TD>Date Created</TD><TD>Authorizing Admin</TD><TD>Item Description</TD><TD>Amount of Item</TD></TR>")
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("MemberID"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("CreateDate"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("AuthorizedBy"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("PaidDesc"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                If aRow.Item("PaidAmount") > 0 Then
                    strBuilder.Append(CDec(aRow.Item("PaidAmount")).ToString("C"))
                Else
                    strBuilder.Append("0")
                End If
                strBuilder.Append("</TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Items</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\VoidedEntries.html", Header.Replace("%REPORTDESC%", "Voided Entries") & strBuilder.ToString & "</font></body></html>", False)
    End Sub

    Private Sub CreateDeletedMembersList()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select FirstName, LastName, Address, City, State, Zip, HomePhone, WorkPhone, EmailAddress, DateJoined, AuthorizedBy  from DeletedMembers order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        strBuilder.Append("<TR><TD>Name</TD><TD>Address</TD><TD>Home Phone</TD><TD>Work Number</TD><TD>E-Mail</TD><TD>Join Date</TD><TD>Authorized By</TD></TR>")
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("Address"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("City"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("State"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("Zip"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("HomePhone"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("WorkPhone"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("EmailAddress"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("DateJoined"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("AuthorizedBy"))
                strBuilder.Append("</TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\DeletedMembers.html", Header.Replace("%REPORTDESC%", "Deleted Members List") & strBuilder.ToString & "</font></body></html>", False)
    End Sub

    Private Sub CreatePaidMemberList()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select * from OKSwingMemberList where Anniversary > GETDATE() order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        strBuilder.Append("<TR><TD>NAME</TD><TD>ADDRESS</TD><TD>HOME PHONE</TD><TD>ANNIVERSARY</TD></TR>")
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("Address"))
                strBuilder.Append(", ")
                strBuilder.Append(aRow.Item("City"))
                strBuilder.Append(", ")
                strBuilder.Append(aRow.Item("State"))
                strBuilder.Append(", ")
                strBuilder.Append(aRow.Item("Zip"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>" & aRow.Item("HomePhone") & "</TD>")
                strBuilder.Append("<TD>" & aRow.Item("Anniversary") & "</TD>")
                strBuilder.Append("</TR>")
                intDancerNumber += 1
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")

        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\PaidMemList.html", Header.Replace("%REPORTDESC%", "Current Paid Member List") & strBuilder.ToString.Replace("<BR>&nbsp;", "") & "</font></body></html>", False)
    End Sub

    Private Sub CreateFullList()
        Dim intDancerNumber As Integer = 0
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim strSQL As String = "Select FirstName, LastName, Address, City, State, Zip, HomePhone, WorkPhone, EmailAddress, DateJoined  from OKSwingMemberList order by LastName"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        strBuilder.Append("<TR><TD>Name</TD><TD>Address</TD><TD>Home Phone</TD><TD>Work Number</TD><TD>E-Mail</TD><TD>Join Date</TD></TR>")
        For Each aRow As DataRow In dtTemp.Rows
            Try
                intDancerNumber += 1
                strBuilder.Append("<TR><TD><B>")
                strBuilder.Append(aRow.Item("LastName"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("FirstName"))
                strBuilder.Append("</B></TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("Address"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("City"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("State"))
                strBuilder.Append(" , ")
                strBuilder.Append(aRow.Item("Zip"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("HomePhone"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("WorkPhone"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("EmailAddress"))
                strBuilder.Append("</TD>")
                strBuilder.Append("<TD>")
                strBuilder.Append(aRow.Item("DateJoined"))
                strBuilder.Append("</TD>")
                strBuilder.Append("</TR>")
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        Next
        strBuilder.Append("<TR><TD>Total Number of Dancers</TD><TD>" & intDancerNumber & "</TD></TR>")
        My.Computer.FileSystem.WriteAllText(Application.CommonAppDataPath & "\FullList.html", Header.Replace("%REPORTDESC%", "Full Member List") & strBuilder.ToString & "</font></body></html>", False)
    End Sub
#End Region

#Region "Report Creator with threads"
    Private Sub CreateReports()
        Try
            Try
                Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
                Dim aComm As SqlCommand
                If DateRangeOffToolStripMenuItem.Text = "Date Range Off" Then
                    aComm = New SqlCommand("SELECT * FROM CheckIns WHERE CreateDate <= '" & dteDate.Value.AddDays(1).ToString("yyyy-MM-dd") & "' AND DATEDIFF(Month, CreateDate,  '" & dteDate.Value.ToString("yyyy-MM-dd") & "') = 0", aConn)
                Else
                    aComm = New SqlCommand("SELECT * FROM CheckIns WHERE CreateDate >= '" & dteDate.Value.ToString("MM-dd-yyyy") & "' AND CreateDate <= '" & dteDateEnd.Value.ToString("MM-dd-yyyy") & "'", aConn)
                End If
                Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(aComm)
                aConn.Open()
                ReportItems = New DataTable
                anAdapt.Fill(ReportItems)
                aConn.Close()
            Catch ex As Exception

            End Try

            If DateRangeOffToolStripMenuItem.Text = "Date Range Off" Then
                Header = "<html><head><title>%REPORTDESC% (" & dteDate.Value.ToString("MMM dd yyyy") & ")</title></head><body><font size=5><h3><u>%REPORTDESC% " & dteDate.Value.ToString("MMM dd yyyy") & "</u></h3><table style='font-size: 12px' border=1 width=100%>"
            Else
                Header = "<html><head><title>%REPORTDESC% (" & dteDate.Value.ToString("MMM dd yyyy") & " To " & dteDateEnd.Value.ToString("MMM dd yyy") & "</title></head><body><font size=5><h3><u>%REPORTDESC% " & dteDate.Value.ToString("MMM dd yyyy") & " To " & dteDateEnd.Value.ToString("MMM dd yyyy") & "</u></h3><table style='font-size: 12px' border=1 width=100%>"
            End If
            CreateMonthly()

        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Print handler"
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Web.Print()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Web.ShowPrintPreviewDialog()
    End Sub
#End Region

#Region "Private Subs"
    Private Sub enableDateRange(ByVal state As Boolean)
        If state Then
            DateRangeOffToolStripMenuItem.Text = "Date Range On"
        Else
            DateRangeOffToolStripMenuItem.Text = "Date Range Off"
        End If
        DateRangeOffToolStripMenuItem.Enabled = state
        dteDateEnd.Enabled = state
    End Sub
#End Region

End Class
