Imports System.Data.SqlClient
Public Class frmPassword

#Region "Button Handler"

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If checkPass(txtPassword.Text.ToUpper) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MessageBox.Show("That Password Is Incorrect", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        Dim x As frmPassChange = New frmPassChange()
        x.ShowDialog()
    End Sub

#End Region

#Region "Private Functions"
    Private Function checkPass(ByVal potPass As String) As Boolean
        Try
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim strSQL As String = "Select * from passwords where thePassword = '" & potPass & "'"
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            For Each aRow As DataRow In dtTemp.Rows
                Return True
            Next
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try
        Return False
    End Function
#End Region

End Class
