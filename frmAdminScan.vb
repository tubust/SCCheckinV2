'*****************************************************
' frmAdminScan             Version 2.09
'*****************************************************
'Version 1 Author: J.Erik Thompson
'Version 2 Author: David Schrock
'******************************************************
'Program Description: Allows Admins to scan in their rights.
'******************************************************
' This code is the property of the Oklahoma City Swing Dance
' Club and can only be used by authorized persons of the club
' or the authors.
'******************************************************
' Version 2.08: Initial Release
' Version 2.09: Fixed Cancellation Bug
'******************************************************

Imports System.Data.SqlClient
Imports System

Public Class frmAdminScan
    Private theTag As String = String.Empty
    Private theDelay As Date = Nothing
    Private theAdmin As Boolean = False
    Private fullName As String = String.Empty
    Private memberNumber As Integer = 0

    Private Sub frmAdminScan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case e.KeyChar
            Case "0"c To "9"c
                If theTag.Length = 5 Then
                    theDelay = Now
                End If
                theTag += e.KeyChar
            Case ChrW(Keys.Enter)
                If theDelay = Nothing Then
                    e.Handled = True
                End If
                Dim test As Integer = Now.Subtract(theDelay).Milliseconds

                If theTag.Length = 6 And test < 100 Then
                    Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
                    Dim strSQL As String = "SELECT * FROM KeyCardTable WHERE KeyCardNumber = '" & theTag & "'"
                    Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
                    Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
                    Dim dtTemp As DataTable = New DataTable
                    aConn.Open()
                    anAdapt.Fill(dtTemp)
                    If dtTemp.Rows.Count = 0 Then
                        MessageBox.Show("Tag is Not An Administrator Tag. You can see the Administrator List under Current Administrators in the Reports.", "Identity Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.DialogResult = Windows.Forms.DialogResult.No
                        Me.Close()
                    End If
                    For Each aRow As DataRow In dtTemp.Rows
                        If aRow.Item("IsAdmin") = True Then
                            fullName = aRow.Item("FirstName") & " " & aRow.Item("LastName")
                            memberNumber = CInt(aRow.Item("MemberID"))
                            Me.DialogResult = Windows.Forms.DialogResult.Yes
                            Me.Close()
                        Else
                            MessageBox.Show("Tag is Not An Administrator Tag. You can see the Administrator List under Current Administrators in the Reports.", "Identity Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.DialogResult = Windows.Forms.DialogResult.No
                            Me.Close()
                        End If
                    Next
                Else
                    theTag = String.Empty
                    theDelay = Nothing
                End If
        End Select
    End Sub

    Public Function getAuthorized() As String
        Return fullName
    End Function

    Public Function getId() As Integer
        Return memberNumber
    End Function

    Private Sub GetOverRideCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetOverRideCodeToolStripMenuItem.Click
        Dim theForm As New frmAdminOverride()
        If theForm.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            theTag = theForm.getKeyTagNumber
            memberNumber = theForm.getMemberID
            fullName = theForm.getKeyTagName
            Me.DialogResult = System.Windows.Forms.DialogResult.Yes
            Me.Close()
        Else
            MessageBox.Show("Over Ride Failed.", "Over Ride Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = System.Windows.Forms.DialogResult.No
            Me.Close()
        End If
    End Sub
End Class