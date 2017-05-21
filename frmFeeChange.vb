'*****************************************************
' frmFeeChange             Version 1.01
'*****************************************************
'Author: David Schrock
'******************************************************
'Program Description: Gives authorized club members the
'ability to change fees charged by the swing club
'******************************************************
' This code is the property of the Oklahoma City Swing Dance
' Club and can only be used by authorized persons of the club
' or the authors.
'******************************************************
Public Class frmFeeChange

#Region "Button Handler"

    'This Sub saves any changes to the club fee structure. If invalid data is entered
    'an error provider points out the bad data and closes the sub before data damage occors.
    'if the data is good example: 2.00 then the data is saved in the database.
    Private Sub TblFeesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TblFeesBindingNavigatorSaveItem.Click

        If Me.Validate() Then 'checks if the data in the fee textbox is valid data
            DBErrorProvider.SetError(FeeAmountTextBox, "")
            Me.TblFeesBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.SCCheckInDataSet)
            LoadMembers()
            Me.Close()
        Else
            DBErrorProvider.SetError(FeeAmountTextBox, "Box must be numeric. Ex: 2.00")
        End If


    End Sub

#End Region

#Region "Initial Loader"


    Private Sub frmFeeChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SCCheckInDataSet.tblFees' table. You can move, or remove it, as needed.
        Me.TblFeesTableAdapter.Fill(Me.SCCheckInDataSet.tblFees)

    End Sub

#End Region

End Class