Public Class frmEnterMerchandise
    Private desText, desPrice As TextBox

    Public Sub New(ByRef txtDesc As TextBox, ByRef thePrice As TextBox)
        InitializeComponent()
        desText = txtDesc
        desPrice = thePrice
    End Sub

    Private Sub frmEnterMerchandise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SCCheckInDataSet.Merchandise' table. You can move, or remove it, as needed.
        Me.MerchandiseTableAdapter.Fill(Me.SCCheckInDataSet.Merchandise)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        desText.Text = "MERCHANDISE " & ItemDescTextBox.Text
        desPrice.Text = (CDbl(ItemPriceTextBox.Text) * NumericUpDown1.Value).ToString("0.00")
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class