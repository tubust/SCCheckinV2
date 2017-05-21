Imports System.Data.SqlClient

Public Class frmPassChange

#Region "Button Handlers"
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If checkPass(txtCurrent.Text.ToUpper) Then
            If txtNew.Text.ToUpper = txtReNew.Text.ToUpper Then
                Dim sqlConnection As New SqlConnection(My.Settings.SCCheckInConnectionString)
                Dim sqlCommand1 As SqlCommand = New SqlCommand
                sqlCommand1.CommandType = CommandType.Text
                sqlCommand1.CommandText = "UPDATE passwords set thePassword = '" & txtNew.Text.ToUpper & "' where PassID = 1"
                sqlCommand1.Connection = sqlConnection
                sqlConnection.Open()
                sqlCommand1.ExecuteNonQuery()
                sqlConnection.Close()
                MessageBox.Show("Password Changed Successfully", "Password Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("New and Retype Passwords do not match", "New Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNew.Focus()
            End If
        Else
            MessageBox.Show("Current Password is Incorrect", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCurrent.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
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