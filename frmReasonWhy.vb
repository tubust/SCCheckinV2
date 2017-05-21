Public Class frmReasonWhy

#Region "Global Variables"
    Private reasonWhy As String
#End Region

#Region "Validation"
    Private Sub txtReason_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReason.TextChanged
        If txtReason.Text.Length > 0 Then
            btnEnter.Enabled = True
        Else
            btnEnter.Enabled = False
        End If
    End Sub

    Public Function getReason() As String
        Return reasonWhy
    End Function

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        reasonWhy = txtReason.Text
        Me.Close()
    End Sub
#End Region

End Class