Imports System.Data.SqlClient

Public Class frmMerchandise
    Private errPro As New ErrorProvider


    Private Sub AddItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemToolStripMenuItem.Click
        MerchandiseBindingSource.AddNew()
    End Sub

    Private Sub SaveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveItemToolStripMenuItem.Click
        If Not IsNumeric(ItemPriceTextBox.Text) Then
            errPro.SetError(ItemPriceTextBox, "This value must be Numeric EX: 2.00")
            Exit Sub
        ElseIf ItemNameTextBox.Text = String.Empty Then
            errPro.SetError(ItemNameTextBox, "This value cant be empty")
            Exit Sub
        ElseIf ItemDescTextBox.Text = String.Empty Then
            errPro.SetError(ItemDescTextBox, "This value must be Numeric EX: 2.00")
            Exit Sub
        Else
            errPro.Clear()
        End If
        If ItemIDComboBox.Text < 0 Then
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strSQL As String = "INSERT INTO Merchandise VALUES('" & ItemNameTextBox.Text & "','" & ItemDescTextBox.Text & "'," & CDbl(ItemPriceTextBox.Text) & ")"
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Try
                aConn.Open()
                comTemp.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        Else
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strSQL As String = "UPDATE Merchandise SET ItemName = '" & ItemNameTextBox.Text & "',ItemDesc = '" & ItemDescTextBox.Text & "',ItemPrice = " & CDbl(ItemPriceTextBox.Text) & " WHERE ItemID = " & ItemIDComboBox.Text
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Try
                aConn.Open()
                comTemp.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
        Me.MerchandiseTableAdapter.Fill(Me.SCCheckInDataSet.Merchandise)
        DeleteItemToolStripMenuItem.Enabled = SaveItemToolStripMenuItem.Enabled = True
    End Sub

    Private Sub frmMerchandise_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'SCCheckInDataSet.Merchandise' table. You can move, or remove it, as needed.
        Me.MerchandiseTableAdapter.Fill(Me.SCCheckInDataSet.Merchandise)
        errPro.BlinkStyle = ErrorBlinkStyle.NeverBlink
        If ItemIDComboBox.Items.Count <= 0 Then
            DeleteItemToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub DeleteItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteItemToolStripMenuItem.Click
        If ItemIDComboBox.Text > 0 Then
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strSQL As String = "DELETE FROM Merchandise WHERE ItemID = " & ItemIDComboBox.Text
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Try
                aConn.Open()
                comTemp.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        Me.MerchandiseTableAdapter.Fill(Me.SCCheckInDataSet.Merchandise)
        If ItemIDComboBox.Items.Count = 0 Then
            SaveItemToolStripMenuItem.Enabled = DeleteItemToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class