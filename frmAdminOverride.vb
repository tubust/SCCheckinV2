﻿'*****************************************************
' frmAdminOverride             Version 2.09
'*****************************************************
'Version 1 Author: J.Erik Thompson
'Version 2 Author: David Schrock
'******************************************************
'Program Description: Allows Over Ride of Admin Functions
'******************************************************
' This code is the property of the Oklahoma City Swing Dance
' Club and can only be used by authorized persons of the club
' or the authors.
'******************************************************
' Version 2.08: Initial Release
'******************************************************
Imports Microsoft.Office.Interop.Outlook
Imports System.Data.SqlClient
Imports System

Public Class frmAdminOverride
    Private overRideCode As Integer
    Private theTime As Integer = 120
    Private memberID As Integer = 0
    Private clickedOnce As Boolean = False
    Private whoIsIt As String
    Private keyTagSelected As String


    Private Sub tmrCodeEntry_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCodeEntry.Tick
        If theTime < 0 Then
            Me.DialogResult = System.Windows.Forms.DialogResult.No
            Me.Close()
            Exit Sub
        ElseIf theTime > 60 Then
            lblTimer.ForeColor = Color.Black
        ElseIf theTime >= 30 And theTime <= 60 Then
            lblTimer.ForeColor = Color.Gold
        Else
            lblTimer.ForeColor = Color.Red
        End If
        If TextBox2.Text = String.Empty Then
            lblTimer.Text = "You have " & theTime & " seconds to enter the code in your email."
            lblTimer.Refresh()
            theTime -= 1
            Exit Sub
        End If
        If CInt(TextBox2.Text) <> overRideCode Then
            lblTimer.Text = "You have " & theTime & " to enter the code in your email."
        Else
            lblTimer.Text = "Press the button in " & theTime & " seconds to finish override."
        End If
        lblTimer.Refresh()
        theTime -= 1
    End Sub

    Private Sub btnCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCode.Click
        Dim theRandomizer As New Random()
        Dim theMember As String() = cboName.SelectedItem.ToString().Split(" ")
        Dim oLook As New Microsoft.Office.Interop.Outlook.Application
        Dim theMail As MailItem = oLook.CreateItem(OlItemType.olMailItem)
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "Select * from KeyCardTable Where KeyCardNumber = '" & theMember(0) & "'"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New System.Data.DataTable
        anAdapt.Fill(dtTemp)
        Try
            aConn.Open()
            If dtTemp.Rows.Count = 0 Or CBool(dtTemp.Rows(0).Item("IsAdmin")) = False Then
                MessageBox.Show("Invalid Key Card Number", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DialogResult = System.Windows.Forms.DialogResult.No
                Me.Close()
            Else
                cboName.Enabled = False
                btnCode.Enabled = False
                overRideCode = theRandomizer.Next(100000000, 999999999)
                Try
                    Dim aConn2 As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
                    Dim strSQL2 As String = "Select * from OkSwingMemberList Where MemberID = " & dtTemp.Rows(0).Item("MemberID")
                    Dim comTemp2 As SqlCommand = New SqlCommand(strSQL2, aConn2)
                    Dim anAdapt2 As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(comTemp2)
                    Dim dtTemp2 As DataTable = New System.Data.DataTable
                    aConn2.Open()
                    anAdapt2.Fill(dtTemp2)
                    whoIsIt = dtTemp2.Rows(0).Item("FirstName") & " " & dtTemp2.Rows(0).Item("LastName")
                    keyTagSelected = theMember(0)
                    memberID = dtTemp.Rows(0).Item("MemberID")
                    If dtTemp2.Rows(0).Item("EmailAddress") = String.Empty Then
                        MessageBox.Show("This Administrator does not have an E-Mail Address.", "E-Mail Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.DialogResult = System.Windows.Forms.DialogResult.No
                        Me.Close()
                        Exit Sub
                    End If
                    theMail.To = dtTemp2.Rows(0).Item("EmailAddress")
                    theMail.Body = "Your code is: " & overRideCode & Environment.NewLine & "Generated by the Swing Club Program"
                    theMail.Subject = "Administrator Over Ride Code"
                    theMail.Send()
                Catch ex As System.Exception
                    MessageBox.Show("Code did not generate.", "Code Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DialogResult = System.Windows.Forms.DialogResult.No
                    Me.Close()
                    Exit Sub
                End Try
                btnCode.Enabled = False
                tmrCodeEntry.Start()
                clickedOnce = True
            End If
        Catch ex As System.Exception
            MessageBox.Show("Code did not generate.", "Code Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = System.Windows.Forms.DialogResult.No
            Me.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = String.Empty Then
            btnOverRide.Enabled = False
            Exit Sub
        End If
        btnOverRide.Enabled = (CInt(TextBox2.Text) = overRideCode)
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        Select Case e.KeyChar
            Case "0"c To "9"c
            Case ChrW(Keys.Back)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Public Function getKeyTagName() As String
        Return whoIsIt
    End Function

    Public Function getMemberID() As Integer
        Return memberID
    End Function
    Public Function getKeyTagNumber() As String
        Return keyTagSelected
    End Function

    Private Sub frmAdminOverride_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "Select * from KeyCardTable Where IsAdmin = 1"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New System.Data.DataTable
        anAdapt.Fill(dtTemp)
        Try
            aConn.Open()
            For Each aRow As DataRow In dtTemp.Rows
                cboName.Items.Add(aRow.Item("KeyCardNumber") & " " & aRow.Item("FirstName") & " " & aRow.Item("LastName"))
            Next
            cboName.SelectedIndex = 0
        Catch ex As System.Exception
            MessageBox.Show("Error loading Admin List. Contact David Schrock.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
        aConn.Close()
    End Sub

    Private Sub btnOverRide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverRide.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub
End Class