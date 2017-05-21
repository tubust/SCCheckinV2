Imports System.Data.SqlClient

Public Class frmKeyCardEntry
    Private theID As String
    Private aMember As MemberCheckInItem
    Private theDelay As Date
    Private entryEntered As Boolean = False
    Private alreadyHasNumber As Boolean = False
    Private isAnAdmin As Boolean = False


    Public Sub New(ByVal theMember As MemberCheckInItem, Optional ByVal alreadyHasCard As Boolean = False)
        InitializeComponent()
        aMember = theMember
        alreadyHasNumber = alreadyHasCard
        isAnAdmin = checkForAdmin(aMember.MemberID)
        chkAdmin.Checked = isAnAdmin
        Me.Focus()
    End Sub

    Private Sub frmKeyCardEntry_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case e.KeyChar
            Case "0"c To "9"c
                If entryEntered Then 'Disables all keyboard or scanning after successful keytag is entered
                    e.Handled = True
                Else
                    theID += e.KeyChar
                    If theID = 5 Then
                        theDelay = Now
                    End If
                End If

                If theID.Length = 6 Then
                    tmrReset.Stop()
                    btnOK.Enabled = True
                    lblScan.Text = "Key Card Scanned"
                    lblScan.Refresh()
                    entryEntered = True
                    e.Handled = True
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim firstNameString As String = aMember.FirstName.Replace("'", "''")
        Dim lastNameString As String = aMember.LastName.Replace("'", "''")
        Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection(My.Settings.SCCheckInConnectionString)

        Dim cmd As New System.Data.SqlClient.SqlCommand
        If checkForDuplicateCard(theID) Then
            MessageBox.Show("Card Already In the Database. Key Card Not Created.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If
        cmd.CommandType = System.Data.CommandType.Text
        If alreadyHasNumber Then
            cmd.CommandText = "UPDATE KeyCardTable SET KeyCardNumber = '" & theID & "' WHERE MemberID = " & aMember.MemberID
        Else
            cmd.CommandText = "INSERT INTO KeyCardTable(KeyCardNumber,LastName,FirstName,MemberID,IsAdmin,MadeAdminBy) "
        End If
        cmd.Connection = sqlConnection1
        If chkAdmin.Checked And Not isAnAdmin Then
            Dim theResult As DialogResult = MessageBox.Show("This requires 2 Administrator Validation. Do you want to continue?", "Administrator Check", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If theResult = Windows.Forms.DialogResult.Yes Then
                Dim admin1 As frmAdminScan = New frmAdminScan
                Dim admin2 As frmAdminScan = New frmAdminScan
                admin1.ShowDialog()
                admin2.ShowDialog()
                If admin1.DialogResult = Windows.Forms.DialogResult.Yes And admin2.DialogResult = Windows.Forms.DialogResult.Yes Then
                    If admin1.getId <> admin2.getId Then
                        Dim adminString1 As String = admin1.getAuthorized().Replace("'", "''")
                        Dim adminString2 As String = admin2.getAuthorized().Replace("'", "''")
                        If Not alreadyHasNumber Then
                            cmd.CommandText += "VALUES('" & theID & "','" & lastNameString & "','" & firstNameString & "'," & aMember.MemberID & ",1,'" & adminString1 & ", " & adminString2 & "')"
                        Else
                            cmd.CommandText = "UPDATE KeyCardTable SET KeyCardNumber ='" & theID & "', IsAdmin = 1, MadeAdminBy ='" & admin1.getAuthorized() & " " & admin2.getAuthorized() & "' WHERE MemberID = " & aMember.MemberID
                        End If
                    Else
                        MessageBox.Show("The Approving Administrators cannot be the same. Tag will not be entered. You can see the Administrator List under Current Administrators in the Reports.", "Same Admin Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.DialogResult = Windows.Forms.DialogResult.No
                        Me.Close()
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("2 Administrators were not successfully entered. You can see the Administrator List under Current Administrators in the Reports. Tag will not be entered.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DialogResult = Windows.Forms.DialogResult.No
                    Me.Close()
                    Exit Sub
                End If
            End If
        Else
            If Not alreadyHasNumber Then
                cmd.CommandText += "VALUES('" & theID & "','" & lastNameString & "','" & firstNameString & "'," & aMember.MemberID & ",0,'')"
            End If
        End If
        Try
            sqlConnection1.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Key card was not registered successfully.", "Create Key Card", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sqlConnection1.Close()
            Me.Close()
            Exit Sub
        Finally
            sqlConnection1.Close()
        End Try
        MessageBox.Show("Key card registered successfully.", "Create Key Card", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Function getID() As String
        Return theID
    End Function

    Private Sub tmrReset_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReset.Tick
        If entryEntered Then
            Exit Sub
        Else
            theID = String.Empty
        End If
    End Sub

    Private Function checkForDuplicateCard(ByVal IdCard As String) As Boolean
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "SELECT * FROM KeyCardTable WHERE KeyCardNumber = '" & IdCard & "'"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        Try
            aConn.Open()
            anAdapt.Fill(dtTemp)
        Catch ex As Exception
            MessageBox.Show("Error getting member. Enter the member manually.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        If dtTemp.Rows.Count = 0 Then
            Return False
        Else
            If dtTemp.Rows(0).Item("MemberID") = aMember.MemberID Then
                Return False
            End If
            Return True
        End If
    End Function

    Private Function checkForAdmin(ByVal IdCard As Integer) As Boolean
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "SELECT * FROM KeyCardTable WHERE MemberID = " & IdCard
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        Try
            aConn.Open()
            anAdapt.Fill(dtTemp)
        Catch ex As Exception
            MessageBox.Show("Error getting member. Enter the member manually.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        If dtTemp.Rows.Count = 0 Then
            Return False
        Else
            For Each aRow As DataRow In dtTemp.Rows
                Return aRow.Item("IsAdmin")
            Next
            Return False
        End If
    End Function
End Class