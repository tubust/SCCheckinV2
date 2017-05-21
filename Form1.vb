Public Class EndOfMonthReport

    Private Sub EndOfMonthReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tmpreport As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("PaidMembers")
        tmpreport.Value = PaidMembers
        ReportViewer1.LocalReport.DataSources.Add(tmpReport)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class