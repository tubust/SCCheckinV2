' frmAddMember.vb              Version 1.02
'**********************************************************
' Author: David Schrock
'**********************************************************
' Program Description: This form adds nessesary information
' for the program to enter into the database.
'**********************************************************
' This code is the property of the Oklahoma City Swing Dance
' Club and can only be used by authorized persons of the club
' or the authors.
'***********************************************************
' Changes from 1.00: Changed tabs for save and cancel to buttons
' and made OK and Cancel Buttons. Changed DOB to exclude year(not needed)
' and uses textboxes instead of comboboxes for DOB.
'***********************************************************
Imports System.Data.SqlClient

Public Class frmAddMember
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFirst As System.Windows.Forms.TextBox
    Friend WithEvents txtLast As System.Windows.Forms.TextBox
    Friend WithEvents txtMiddle As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtHomePhone As System.Windows.Forms.TextBox
    Friend WithEvents txtEMail As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkTwoForOne As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtFirst = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtLast = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMiddle = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtState = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtWorkPhone = New System.Windows.Forms.TextBox
        Me.txtHomePhone = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtEMail = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.txtDay = New System.Windows.Forms.TextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.chkTwoForOne = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'txtFirst
        '
        Me.txtFirst.Location = New System.Drawing.Point(116, 12)
        Me.txtFirst.MaxLength = 254
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.ReadOnly = True
        Me.txtFirst.Size = New System.Drawing.Size(164, 24)
        Me.txtFirst.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 24)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Last Name:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 24)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "First Name:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLast
        '
        Me.txtLast.Location = New System.Drawing.Point(116, 72)
        Me.txtLast.MaxLength = 254
        Me.txtLast.Name = "txtLast"
        Me.txtLast.ReadOnly = True
        Me.txtLast.Size = New System.Drawing.Size(164, 24)
        Me.txtLast.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Middle Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMiddle
        '
        Me.txtMiddle.Location = New System.Drawing.Point(116, 42)
        Me.txtMiddle.MaxLength = 254
        Me.txtMiddle.Name = "txtMiddle"
        Me.txtMiddle.Size = New System.Drawing.Size(164, 24)
        Me.txtMiddle.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 24)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "City:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(116, 132)
        Me.txtCity.MaxLength = 254
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(164, 24)
        Me.txtCity.TabIndex = 9
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(116, 102)
        Me.txtAddress.MaxLength = 254
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(164, 24)
        Me.txtAddress.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "State:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Address:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(116, 161)
        Me.txtState.MaxLength = 254
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(164, 24)
        Me.txtState.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(297, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 24)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Work Phone:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWorkPhone
        '
        Me.txtWorkPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWorkPhone.Location = New System.Drawing.Point(420, 42)
        Me.txtWorkPhone.MaxLength = 254
        Me.txtWorkPhone.Name = "txtWorkPhone"
        Me.txtWorkPhone.Size = New System.Drawing.Size(152, 24)
        Me.txtWorkPhone.TabIndex = 17
        '
        'txtHomePhone
        '
        Me.txtHomePhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHomePhone.Location = New System.Drawing.Point(420, 12)
        Me.txtHomePhone.MaxLength = 254
        Me.txtHomePhone.Name = "txtHomePhone"
        Me.txtHomePhone.Size = New System.Drawing.Size(152, 24)
        Me.txtHomePhone.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(286, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 24)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Email Address:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(297, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 24)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Home Phone:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEMail
        '
        Me.txtEMail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEMail.Location = New System.Drawing.Point(420, 72)
        Me.txtEMail.MaxLength = 254
        Me.txtEMail.Name = "txtEMail"
        Me.txtEMail.Size = New System.Drawing.Size(152, 24)
        Me.txtEMail.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 24)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Zip:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(116, 191)
        Me.txtZip.MaxLength = 254
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(164, 24)
        Me.txtZip.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(297, 99)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 24)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "DOB:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(493, 105)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 18)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "/"
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(420, 102)
        Me.txtMonth.MaxLength = 2
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(67, 24)
        Me.txtMonth.TabIndex = 21
        '
        'txtDay
        '
        Me.txtDay.Location = New System.Drawing.Point(512, 102)
        Me.txtDay.MaxLength = 2
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(59, 24)
        Me.txtDay.TabIndex = 23
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(324, 161)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(117, 55)
        Me.btnSave.TabIndex = 24
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(447, 161)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(119, 55)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkTwoForOne
        '
        Me.chkTwoForOne.AutoSize = True
        Me.chkTwoForOne.Location = New System.Drawing.Point(324, 134)
        Me.chkTwoForOne.Name = "chkTwoForOne"
        Me.chkTwoForOne.Size = New System.Drawing.Size(242, 22)
        Me.chkTwoForOne.TabIndex = 26
        Me.chkTwoForOne.Text = "Apply 2 Months for 1 Special"
        Me.chkTwoForOne.UseVisualStyleBackColor = True
        '
        'frmAddMember
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 17)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(578, 228)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkTwoForOne)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtDay)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtLast)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtWorkPhone)
        Me.Controls.Add(Me.txtHomePhone)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtEMail)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtZip)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtState)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMiddle)
        Me.Controls.Add(Me.txtFirst)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(594, 267)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(594, 267)
        Me.Name = "frmAddMember"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add A New Member"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Global Variables"

    Private AddMember As MemberCheckInItem = New MemberCheckInItem
    Private isCancel As Boolean = False
    Private Fname As String
    Private LName As String
    Private isFilled As Boolean = False
    Private twoForOne As Boolean = False

#End Region

#Region "Button Handlers"

    'This Sub saves the data needed to be put into the club database. The minimum data
    'needed to do a save is values in the first name or last name textboxes. All values
    'are converted to upper case for entry into the database.
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (txtFirst.TextLength > 0) Then
            If (txtLast.TextLength > 0) Then
                If (txtMonth.Text = String.Empty And txtDay.Text = String.Empty) Then
                    AddMember.FirstName = txtFirst.Text.ToUpper
                    AddMember.MiddleName = txtMiddle.Text.ToUpper
                    AddMember.LastName = txtLast.Text.ToUpper
                    AddMember.Address = txtAddress.Text.ToUpper
                    AddMember.City = txtCity.Text.ToUpper
                    AddMember.State = txtState.Text.ToUpper
                    AddMember.Zip = txtZip.Text.ToUpper
                    AddMember.HomePhone = txtHomePhone.Text.ToUpper
                    AddMember.WorkPhone = txtWorkPhone.Text.ToUpper
                    AddMember.EMailAddress = txtEMail.Text
                ElseIf Not txtMonth.Text = String.Empty And txtDay.Text = String.Empty Then
                    MessageBox.Show("Birthday Incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtDay.Focus()
                    Exit Sub
                ElseIf txtMonth.Text = String.Empty And Not txtDay.Text = String.Empty Then
                    MessageBox.Show("Birthday Incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtMonth.Focus()
                    Exit Sub
                Else
                    Select Case txtMonth.Text
                        Case "1", "3", "5", "7", "8", "10", "12"
                            If (CInt(txtDay.Text) < 1 Or CInt(txtDay.Text) > 31) Then
                                MessageBox.Show("Birthday Incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtDay.Focus()
                                Exit Sub
                            End If
                            AddMember.FirstName = txtFirst.Text.ToUpper
                            AddMember.MiddleName = txtMiddle.Text.ToUpper
                            AddMember.LastName = txtLast.Text.ToUpper
                            AddMember.Address = txtAddress.Text.ToUpper
                            AddMember.City = txtCity.Text.ToUpper
                            AddMember.State = txtState.Text.ToUpper
                            AddMember.Zip = txtZip.Text.ToUpper
                            AddMember.HomePhone = txtHomePhone.Text.ToUpper
                            AddMember.WorkPhone = txtWorkPhone.Text.ToUpper
                            AddMember.EMailAddress = txtEMail.Text
                            AddMember.Birthday = New Date(2000, CInt(txtMonth.Text), CInt(txtDay.Text))
                        Case "2"
                            If (CInt(txtDay.Text) < 1 Or CInt(txtDay.Text) > 29) Then
                                MessageBox.Show("Birthday Incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtDay.Focus()
                                Exit Sub
                            End If
                            AddMember.FirstName = txtFirst.Text.ToUpper
                            AddMember.MiddleName = txtMiddle.Text.ToUpper
                            AddMember.LastName = txtLast.Text.ToUpper
                            AddMember.Address = txtAddress.Text.ToUpper
                            AddMember.City = txtCity.Text.ToUpper
                            AddMember.State = txtState.Text.ToUpper
                            AddMember.Zip = txtZip.Text.ToUpper
                            AddMember.HomePhone = txtHomePhone.Text.ToUpper
                            AddMember.WorkPhone = txtWorkPhone.Text.ToUpper
                            AddMember.EMailAddress = txtEMail.Text
                            AddMember.Birthday = New Date(2000, CInt(txtMonth.Text), CInt(txtDay.Text))
                        Case "4", "6", "9", "11"
                            If (CInt(txtDay.Text) < 1 Or CInt(txtDay.Text) > 30) Then
                                MessageBox.Show("Birthday Incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtDay.Focus()
                                Exit Sub
                            End If
                            AddMember.FirstName = txtFirst.Text.ToUpper
                            AddMember.MiddleName = txtMiddle.Text.ToUpper
                            AddMember.LastName = txtLast.Text.ToUpper
                            AddMember.Address = txtAddress.Text.ToUpper
                            AddMember.City = txtCity.Text.ToUpper
                            AddMember.State = txtState.Text.ToUpper
                            AddMember.Zip = txtZip.Text.ToUpper
                            AddMember.HomePhone = txtHomePhone.Text.ToUpper
                            AddMember.WorkPhone = txtWorkPhone.Text.ToUpper
                            AddMember.EMailAddress = txtEMail.Text
                            AddMember.Birthday = New Date(2000, CInt(txtMonth.Text), CInt(txtDay.Text))
                        Case Else
                            MessageBox.Show("Birthday Incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtMonth.Focus()
                            Exit Sub
                    End Select
                End If
            Else
                MessageBox.Show("First Name and Last Name Must Be Entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLast.Focus()
                Exit Sub
            End If
        Else
            MessageBox.Show("First Name and Last Name Must Be Entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFirst.Focus()
            Exit Sub
        End If
        twoForOne = chkTwoForOne.Checked

        Me.Close()
    End Sub

    'This sub will set the isCancel boolean value to true causing the person not to be entered into the database.
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        isCancel = True
        Me.Close()
    End Sub

#End Region

#Region "Initial Loader"

    'This Sub Loads the first and last name textboxes from the main form. the values are
    'called from a method in this code called setName.
    Private Sub frmAddMember_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFirst.Text = Fname
        txtLast.Text = LName
    End Sub

#End Region

#Region "Other Subs"

    Public Sub setName(ByVal f As String, ByVal l As String)
        Fname = f
        LName = l
    End Sub

#End Region

#Region "Functions"

    'This function sends the filled out information to frmMain for database entry.
    Public Function getAMember() As MemberCheckInItem
        Return AddMember
    End Function

    'This function tells frmMain if the user clicked the cancel button.
    Public Function isCanceled() As Boolean
        Return isCancel
    End Function

    Public Function get2For1() As Boolean
        Return twoForOne
    End Function

#End Region

#Region "Validation"

    'This Sub only allows numbers to be entered into the birthday month and day fields
    Private Sub frmAddMember_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonth.KeyPress, txtDay.KeyPress
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

#End Region

End Class
