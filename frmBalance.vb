'frmBalance.vb       Version 2.01
'******************************************************
'Version 1 Author: J.Erik Thompson
'Version 2 Author: David Schrock
'******************************************************
'Program Description: Takes values from checks and cash
'and their quantity and gives a total based on the numbers
'******************************************************
' This code is the property of the Oklahoma City Swing Dance
' Club and can only be used by authorized persons of the club
' or the authors.
'******************************************************

Public Class frmBalance

#Region "Button Handlers"

    'This Sub either resets a previous calculation or uses a method called AddEmUp to
    'Calculate a total for the user.
    Private Sub cmdCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculate.Click
        If (cmdCalculate.Text = "Reset") Then
            buttonEnabler(True)
            cmdCalculate.Text = "Calculate"
        Else
            AddEmUp()
            buttonEnabler(False)
            cmdCalculate.Text = "Reset"
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close() 'Closes the form
    End Sub

#End Region

#Region "Functions"

    'This sub uses the function addToTotal and displays the grand total in the
    'textboxes at the bottom of the form in currency format.
    Private Sub AddEmUp()
        Dim chkTotal As Decimal = 0
        Dim cshTotal As Decimal = 0
        Dim grandTotal As Decimal = 0
        chkTotal += addToTotal(txtQ1.Text, txtA1.Text)
        chkTotal += addToTotal(txtQ2.Text, txtA2.Text)
        chkTotal += addToTotal(txtQ3.Text, txtA3.Text)
        chkTotal += addToTotal(txtQ4.Text, txtA4.Text)
        chkTotal += addToTotal(txtQ5.Text, txtA5.Text)
        chkTotal += addToTotal(txtQ6.Text, txtA6.Text)
        chkTotal += addToTotal(txtQ7.Text, txtA7.Text)
        cshTotal += addToTotal(txt1.Text, "1")
        cshTotal += addToTotal(txt5.Text, "5")
        cshTotal += addToTotal(txt10.Text, "10")
        cshTotal += addToTotal(txt20.Text, "20")
        cshTotal += addToTotal(txt50.Text, "50")
        cshTotal += addToTotal(txt100.Text, "100")
        grandTotal = chkTotal + cshTotal
        txtCashTotal.Text = cshTotal.ToString("C")
        txtChecksTotal.Text = chkTotal.ToString("C")
        txtGrandTotal.Text = grandTotal.ToString("C")
    End Sub

    'This function takes the numberic text (restricted to numbers by previous code)
    'and if a or amt are blank strings returns 0 to the calculation. If there are
    'numbers in the strings it multiplies them and returns the result.
    Private Function addToTotal(ByVal a As String, ByVal amt As String) As Decimal
        Dim x, y As Decimal
        If a = String.Empty Or amt = String.Empty Then
            Return 0
        Else
            x = Decimal.Parse(a)
            y = Decimal.Parse(amt)
            Return (x * y)
        End If
    End Function

#End Region

#Region "Validation"

    'This code only allows numbers and the backspace and delete in the cash textboxes
    'and textboxes txtQ1-txtQ7

    Private Sub frmBalance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt1.KeyPress, _
                                                                                                                        txt10.KeyPress, _
                                                                                                                        txt100.KeyPress, _
                                                                                                                        txt20.KeyPress, _
                                                                                                                        txt5.KeyPress, _
                                                                                                                        txt50.KeyPress, _
                                                                                                                        txtQ1.KeyPress, _
                                                                                                                        txtQ2.KeyPress, _
                                                                                                                        txtQ3.KeyPress, _
                                                                                                                        txtQ4.KeyPress, _
                                                                                                                        txtQ5.KeyPress, _
                                                                                                                        txtQ6.KeyPress, _
                                                                                                                        txtQ7.KeyPress


        Select Case e.KeyChar
            Case "."c
                e.Handled = True
            Case "0"c To "9"c
            Case Chr(Keys.Back)
            Case Chr(Keys.Delete)
            Case Else
                e.Handled = True
        End Select
    End Sub

    'This Sub restricts the amount textboxes txtA1-txtA7 to only numbers, backspace and delete and
    'if there is a decimal point present only allows 2 numbers after that.
    Private Sub frmBalance_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtA1.KeyPress, _
                                                                                                                        txtA2.KeyPress, _
                                                                                                                        txtA3.KeyPress, _
                                                                                                                        txtA4.KeyPress, _
                                                                                                                        txtA5.KeyPress, _
                                                                                                                        txtA6.KeyPress, _
                                                                                                                        txtA7.KeyPress
        Const decimalChar As Char = "."c
        Select Case e.KeyChar
            Case decimalChar
                'This case only allows one decimal point
                Dim txt As TextBox = CType(sender, TextBox)
                If txt.Text.Contains(decimalChar) Then
                    e.Handled = True
                End If
            Case "0"c To "9"c
                'This code only allows numbers and only 2 digits after the
                'decimal point
                Dim txtTemp As TextBox = CType(sender, TextBox)
                Dim s As Integer = -1
                If (txtTemp.Text.Contains(".")) Then
                    s = txtTemp.Text.IndexOf(".")
                End If
                If (s > -1) Then
                    If (txtTemp.Text.Length > (s + 2)) Then
                        e.Handled = True
                    End If
                End If
                'These backspace and delete are only allowed keys besides
                'one decimal point and numbers
            Case Chr(Keys.Back)
            Case Chr(Keys.Delete)
                'Every other key is handled by this case and ignored.
            Case Else
                e.Handled = True

        End Select
    End Sub

#End Region

#Region "Button Handler"

    'This Sub disables boxes during calculation and clears them when reset
    'When b is True the cash and check textboxes are cleared and enabled
    'When b is False all cash ans check textboxes are disabled from editing
    Private Sub buttonEnabler(ByVal b As Boolean)
        txt1.Enabled = b
        txt5.Enabled = b
        txt10.Enabled = b
        txt20.Enabled = b
        txt50.Enabled = b
        txt100.Enabled = b
        txtQ1.Enabled = b
        txtQ2.Enabled = b
        txtQ3.Enabled = b
        txtQ4.Enabled = b
        txtQ5.Enabled = b
        txtQ6.Enabled = b
        txtQ7.Enabled = b
        txtA1.Enabled = b
        txtA2.Enabled = b
        txtA3.Enabled = b
        txtA4.Enabled = b
        txtA5.Enabled = b
        txtA6.Enabled = b
        txtA7.Enabled = b
        If b Then
            txtQ1.Clear()
            txtQ2.Clear()
            txtQ3.Clear()
            txtQ4.Clear()
            txtQ5.Clear()
            txtQ6.Clear()
            txtQ7.Clear()
            txtA1.Clear()
            txtA2.Clear()
            txtA3.Clear()
            txtA4.Clear()
            txtA5.Clear()
            txtA6.Clear()
            txtA7.Clear()
            txt1.Clear()
            txt5.Clear()
            txt10.Clear()
            txt20.Clear()
            txt50.Clear()
            txt100.Clear()
            txtCashTotal.Clear()
            txtChecksTotal.Clear()
            txtGrandTotal.Clear()
        End If
    End Sub

#End Region

End Class