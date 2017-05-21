
Public Class frmLookup
#Region "Global Variables"

    Public Member As String = String.Empty
    Public Members As DataTable = New DataTable

#End Region

#Region "Initial Loader"

    Private Sub frmLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstMembers.DisplayMember = "FullName"
        ApplySort()
    End Sub

#End Region

#Region "Button Handler"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Member = DirectCast(lstMembers.SelectedItem, DataRowView).Item("FirstName") & (" " & DirectCast(lstMembers.SelectedItem, DataRowView).Item("MiddleName").ToString).Trim & " " & DirectCast(lstMembers.SelectedItem, DataRowView).Item("LastName") & " (" & DirectCast(lstMembers.SelectedItem, DataRowView).Item("MemberID") & ")"
        Member = Member.Replace("  ", " ")
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub lstMembers_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstMembers.MouseDoubleClick
        Member = DirectCast(lstMembers.SelectedItem, DataRowView).Item("FirstName") & (" " & DirectCast(lstMembers.SelectedItem, DataRowView).Item("MiddleName").ToString).Trim & " " & DirectCast(lstMembers.SelectedItem, DataRowView).Item("LastName") & " (" & DirectCast(lstMembers.SelectedItem, DataRowView).Item("MemberID") & ")"
        Member = Member.Replace("  ", " ")
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

#End Region

#Region "List Handler"

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

        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtFirst_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFirst.KeyDown, txtLast.KeyDown
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
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Validation"

    Private Sub txtFirst_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirst.TextChanged, txtLast.TextChanged
        If txtFirst.Text.Length > 0 Or txtLast.Text.Length > 0 Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If
        ApplySort()
    End Sub

#End Region

End Class