Imports System.Data.SqlClient

Public Class frmLoad

#Region "Initial Loader"
    Private Sub tmrStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStart.Tick

        'UpdateAnniversaries()
        Try

            lblStatus.Text = "Opening database connection"
            lblStatus.Refresh()

            'conMain = New sqlConnection(My.Settings.OKCSCProgramConnectionString)
            conMain = New SqlConnection(My.Settings.SCCheckInConnectionString)
            'conPaid = New SQLConnection(My.Settings.PaidItemsConnectionString)
            conPaid = New SqlConnection(My.Settings.SCCheckInConnectionString)

            lblStatus.Text = "Loading Member Database"
            lblStatus.Refresh()

            LoadMembers()
            chkLoadMDB.Checked = True
            chkLoadMDB.Refresh()

            lblStatus.Text = "Loading Monthly Activity"
            lblStatus.Refresh()

            LoadNewMembers()
            chkLoadMonthly.Checked = True
            chkLoadMonthly.Refresh()

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

End Class