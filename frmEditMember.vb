'*****************************************************
' frmEditMember             Version 2.09
'*****************************************************
'Version 1 Author: J.Erik Thompson
'Version 2 Author: David Schrock
'******************************************************
'Program Description: Allows authorized users the ability
'to edit club members to their liking.
'******************************************************
' This code is the property of the Oklahoma City Swing Dance
' Club and can only be used by authorized persons of the club
' or the authors.
'******************************************************
' Version 2.00: Initial code from Version 1 Author
' Version 2.01: Added Delete code for member removal
' Version 2.02: Added comboboxes for member updates and printing
' function to the code.
' Version 2.03: Changed birthday comboboxes to textboxes displaying data
' Version 2.04: Added code to revert anniversary if yearly dues
' are erased.
' Version 2.08: Added Key Card Validation and Moved Deleted Entries to seperate database table.
' Version 2.09: Repaired Anniversary Bug and deletions without saving
'******************************************************
Imports System.Data.SqlClient
Imports System.IO

Public Class frmEditMember
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
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
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstActivity As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbDeleteActivity As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdShowData As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkInvalidAddress As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents errName As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents pntControl As System.Drawing.Printing.PrintDocument
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboMember As System.Windows.Forms.ComboBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtBirthDay As System.Windows.Forms.TextBox
    Friend WithEvents txtBirthMonth As System.Windows.Forms.TextBox
    Friend WithEvents ppdPrintPreview As System.Windows.Forms.PrintPreviewDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditMember))
        Me.txtFirst = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLast = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMiddle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtWorkPhone = New System.Windows.Forms.TextBox()
        Me.txtHomePhone = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEMail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lstActivity = New System.Windows.Forms.ListBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbDeleteActivity = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.cmdShowData = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.chkInvalidAddress = New System.Windows.Forms.CheckBox()
        Me.errName = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pntControl = New System.Drawing.Printing.PrintDocument()
        Me.ppdPrintPreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.cboMember = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtBirthMonth = New System.Windows.Forms.TextBox()
        Me.txtBirthDay = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.errName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFirst
        '
        Me.txtFirst.Location = New System.Drawing.Point(116, 28)
        Me.txtFirst.MaxLength = 254
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(164, 24)
        Me.txtFirst.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 24)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Last Name:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 24)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "First Name:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLast
        '
        Me.txtLast.Location = New System.Drawing.Point(116, 84)
        Me.txtLast.MaxLength = 254
        Me.txtLast.Name = "txtLast"
        Me.txtLast.Size = New System.Drawing.Size(164, 24)
        Me.txtLast.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Middle Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMiddle
        '
        Me.txtMiddle.Location = New System.Drawing.Point(116, 56)
        Me.txtMiddle.MaxLength = 254
        Me.txtMiddle.Name = "txtMiddle"
        Me.txtMiddle.Size = New System.Drawing.Size(164, 24)
        Me.txtMiddle.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 24)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "City:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(116, 140)
        Me.txtCity.MaxLength = 254
        Me.txtCity.Name = "txtCity"
        Me.txtCity.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCity.Size = New System.Drawing.Size(164, 24)
        Me.txtCity.TabIndex = 10
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(116, 112)
        Me.txtAddress.MaxLength = 254
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAddress.Size = New System.Drawing.Size(164, 24)
        Me.txtAddress.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "State:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 24)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Address:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(116, 168)
        Me.txtState.MaxLength = 254
        Me.txtState.Name = "txtState"
        Me.txtState.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtState.Size = New System.Drawing.Size(164, 24)
        Me.txtState.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(310, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 24)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Work Phone:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkPhone
        '
        Me.txtWorkPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWorkPhone.Location = New System.Drawing.Point(420, 56)
        Me.txtWorkPhone.MaxLength = 254
        Me.txtWorkPhone.Name = "txtWorkPhone"
        Me.txtWorkPhone.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtWorkPhone.Size = New System.Drawing.Size(152, 24)
        Me.txtWorkPhone.TabIndex = 22
        '
        'txtHomePhone
        '
        Me.txtHomePhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHomePhone.Location = New System.Drawing.Point(420, 28)
        Me.txtHomePhone.MaxLength = 254
        Me.txtHomePhone.Name = "txtHomePhone"
        Me.txtHomePhone.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtHomePhone.Size = New System.Drawing.Size(152, 24)
        Me.txtHomePhone.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(286, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 24)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Email Address:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(310, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 24)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Home Phone:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEMail
        '
        Me.txtEMail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEMail.Location = New System.Drawing.Point(420, 84)
        Me.txtEMail.MaxLength = 254
        Me.txtEMail.Name = "txtEMail"
        Me.txtEMail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEMail.Size = New System.Drawing.Size(152, 24)
        Me.txtEMail.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 24)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Zip:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(116, 196)
        Me.txtZip.MaxLength = 254
        Me.txtZip.Name = "txtZip"
        Me.txtZip.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtZip.Size = New System.Drawing.Size(164, 24)
        Me.txtZip.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(294, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 24)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Status:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(294, 196)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 24)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Type:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(294, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 24)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Member Status:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(286, 112)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 24)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "DOB:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(-8, 224)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 24)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Anniversary:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 256)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 42)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Monthly Activity:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lstActivity)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(116, 254)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(458, 300)
        Me.Panel1.TabIndex = 43
        '
        'lstActivity
        '
        Me.lstActivity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstActivity.HorizontalScrollbar = True
        Me.lstActivity.ItemHeight = 18
        Me.lstActivity.Location = New System.Drawing.Point(0, 25)
        Me.lstActivity.Name = "lstActivity"
        Me.lstActivity.Size = New System.Drawing.Size(458, 275)
        Me.lstActivity.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDeleteActivity})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(458, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbDeleteActivity
        '
        Me.tsbDeleteActivity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDeleteActivity.Enabled = False
        Me.tsbDeleteActivity.Image = CType(resources.GetObject("tsbDeleteActivity.Image"), System.Drawing.Image)
        Me.tsbDeleteActivity.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleteActivity.Name = "tsbDeleteActivity"
        Me.tsbDeleteActivity.Size = New System.Drawing.Size(105, 22)
        Me.tsbDeleteActivity.Text = "Delete Entry"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbCancel, Me.cmdShowData, Me.ToolStripSeparator1, Me.btnDelete, Me.ToolStripSeparator2, Me.btnPrint})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(578, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(49, 22)
        Me.tsbSave.Text = "Save"
        '
        'tsbCancel
        '
        Me.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbCancel.Image = CType(resources.GetObject("tsbCancel.Image"), System.Drawing.Image)
        Me.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancel.Name = "tsbCancel"
        Me.tsbCancel.Size = New System.Drawing.Size(62, 22)
        Me.tsbCancel.Text = "Cancel"
        '
        'cmdShowData
        '
        Me.cmdShowData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdShowData.Image = CType(resources.GetObject("cmdShowData.Image"), System.Drawing.Image)
        Me.cmdShowData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdShowData.Name = "cmdShowData"
        Me.cmdShowData.Size = New System.Drawing.Size(92, 22)
        Me.cmdShowData.Text = "Show Data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(125, 22)
        Me.btnDelete.Text = "Delete Member"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnPrint
        '
        Me.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(206, 22)
        Me.btnPrint.Text = "Print Member Information"
        '
        'chkInvalidAddress
        '
        Me.chkInvalidAddress.AutoSize = True
        Me.chkInvalidAddress.Location = New System.Drawing.Point(295, 141)
        Me.chkInvalidAddress.Name = "chkInvalidAddress"
        Me.chkInvalidAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkInvalidAddress.Size = New System.Drawing.Size(140, 22)
        Me.chkInvalidAddress.TabIndex = 29
        Me.chkInvalidAddress.Text = "Invalid Address"
        Me.chkInvalidAddress.UseVisualStyleBackColor = True
        '
        'errName
        '
        Me.errName.ContainerControl = Me
        '
        'pntControl
        '
        '
        'ppdPrintPreview
        '
        Me.ppdPrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdPrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdPrintPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdPrintPreview.Document = Me.pntControl
        Me.ppdPrintPreview.Enabled = True
        Me.ppdPrintPreview.Icon = CType(resources.GetObject("ppdPrintPreview.Icon"), System.Drawing.Icon)
        Me.ppdPrintPreview.Name = "PrintPreviewDialog1"
        Me.ppdPrintPreview.Visible = False
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(116, 224)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(44, 26)
        Me.cboMonth.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(167, 227)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 18)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "/1/"
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(201, 223)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(79, 26)
        Me.cboYear.TabIndex = 18
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.cboStatus.Location = New System.Drawing.Point(420, 168)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(152, 26)
        Me.cboStatus.TabIndex = 31
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"INTRO", "REGULAR", "CHARTER"})
        Me.cboType.Location = New System.Drawing.Point(420, 196)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(152, 26)
        Me.cboType.TabIndex = 33
        '
        'cboMember
        '
        Me.cboMember.FormattingEnabled = True
        Me.cboMember.Items.AddRange(New Object() {"MEMBER", "NONMEMBER"})
        Me.cboMember.Location = New System.Drawing.Point(420, 224)
        Me.cboMember.Name = "cboMember"
        Me.cboMember.Size = New System.Drawing.Size(152, 26)
        Me.cboMember.TabIndex = 35
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(495, 118)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(13, 18)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "/"
        '
        'txtBirthMonth
        '
        Me.txtBirthMonth.Location = New System.Drawing.Point(420, 115)
        Me.txtBirthMonth.MaxLength = 2
        Me.txtBirthMonth.Name = "txtBirthMonth"
        Me.txtBirthMonth.Size = New System.Drawing.Size(69, 24)
        Me.txtBirthMonth.TabIndex = 26
        '
        'txtBirthDay
        '
        Me.txtBirthDay.Location = New System.Drawing.Point(514, 114)
        Me.txtBirthDay.MaxLength = 2
        Me.txtBirthDay.Name = "txtBirthDay"
        Me.txtBirthDay.Size = New System.Drawing.Size(57, 24)
        Me.txtBirthDay.TabIndex = 28
        '
        'frmEditMember
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 17)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(578, 558)
        Me.Controls.Add(Me.txtBirthDay)
        Me.Controls.Add(Me.txtBirthMonth)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboMember)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.chkInvalidAddress)
        Me.Controls.Add(Me.txtLast)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
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
        Me.Name = "frmEditMember"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Member Maintenance"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.errName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Global Varibles"

    Public EditMember As MemberCheckInItem
    Private MemID As Integer
    Private isDelete As Boolean = False
    Private approvingAdmin As frmAdminScan
    Private passChar As Boolean = False
    Private whatIsModified As StreamWriter
    Public isModified As Boolean = False
    Public anniversaryChanged As String = String.Empty
    Private deleteQueue As New Queue()

#End Region

#Region "Initial Loader"

    Private Sub frmNewMember_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For a As Integer = 1 To 12 Step 1
            cboMonth.Items.Add(a)
        Next
        For b As Integer = 1900 To Now.Year + 1500 Step 1
            cboYear.Items.Add(b)
        Next
        If Not EditMember Is Nothing Then
            'Display only?
            EditMember.GetInfo()

            txtFirst.Text = EditMember.FirstName
            txtMiddle.Text = EditMember.MiddleName
            txtLast.Text = EditMember.LastName
            txtAddress.Text = EditMember.Address
            txtCity.Text = EditMember.City
            txtState.Text = EditMember.State
            txtZip.Text = EditMember.Zip
            cboMonth.SelectedIndex = EditMember.Anniversary.Month - 1
            cboYear.SelectedIndex = EditMember.Anniversary.Year - 1900
            txtHomePhone.Text = EditMember.HomePhone
            txtWorkPhone.Text = EditMember.WorkPhone
            txtEMail.Text = EditMember.EMailAddress
            If EditMember.Status = "ACTIVE" Then
                cboStatus.SelectedIndex = 0
            Else
                cboStatus.SelectedIndex = 1
            End If
            If EditMember.Type = "INTRO" Then
                cboType.SelectedIndex = 0
            ElseIf EditMember.Type = "REGULAR" Then
                cboType.SelectedIndex = 1
            Else
                cboType.SelectedIndex = 2
            End If
            If EditMember.MemberStatus = "MEMBER" Then
                cboMember.SelectedIndex = 0
            Else
                cboMember.SelectedIndex = 1
            End If

            If Not EditMember.Birthday.Date = Nothing Then
                txtBirthMonth.Text = EditMember.Birthday.Month.ToString()
                txtBirthDay.Text = EditMember.Birthday.Day.ToString()
            End If

            chkInvalidAddress.Checked = EditMember.InvalidAddress

            lstActivity.Items.Clear()
            EditMember.LoadPaidItems()
            For Each aPaidItem As PaidItem In EditMember.PaidFor
                lstActivity.Items.Add(aPaidItem)
            Next
        End If
    End Sub

#End Region

#Region "Button and Tab Handler"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub tsbDeleteActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleteActivity.Click

        Dim paidTpe As Integer = 0
        Dim previousYearly As Integer = 2000

        If Not lstActivity.SelectedItem Is Nothing Then
            Dim delPaidItem As PaidItem = lstActivity.SelectedItem
            paidTpe = delPaidItem.PaidType
            deleteQueue.Enqueue(delPaidItem)
            lstActivity.Items.Clear()
            EditMember.LoadPaidItems()
            For Each aPaidItem As PaidItem In EditMember.PaidFor
                If aPaidItem.CheckInID <> delPaidItem.CheckInID Then
                    lstActivity.Items.Add(aPaidItem)
                End If
            Next
            tsbDeleteActivity.Enabled = False
        End If

    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        If txtFirst.Text.Length = 0 Then
            errName.SetError(txtFirst, "This Field Cannot Be Empty")
            Exit Sub
        ElseIf txtLast.Text.Length = 0 Then
            errName.SetError(txtLast, "This Field Cannot Be Empty")
            Exit Sub
        ElseIf Not txtBirthMonth.Text = String.Empty And txtBirthDay.Text = String.Empty Then
            errName.SetError(txtBirthDay, "Both of these must be filled or empty")
            Exit Sub
        ElseIf txtBirthMonth.Text = String.Empty And Not txtBirthDay.Text = String.Empty Then
            errName.SetError(txtBirthMonth, "Both of these must be filled or empty")
            Exit Sub
        ElseIf cboType.Text = "CHARTER" And cboMonth.Text <> "9" Then
            errName.SetError(cboType, "Charter Member anniversary MUST be September per Club Bylaws.")
            errName.SetError(cboMonth, "Charter Member anniversary month MUST be 9 per Club Bylaws.")
            Exit Sub
        Else
            errName.SetError(txtFirst, "")
            errName.SetError(txtLast, "")
            errName.SetError(cboType, "")
            errName.SetError(cboMonth, "")
            If Not txtBirthMonth.Text = String.Empty And Not txtBirthDay.Text = String.Empty Then
                If CInt(txtBirthMonth.Text) < 1 Or CInt(txtBirthMonth.Text) > 12 Then
                    errName.SetError(txtBirthMonth, "This value must be between 1 and 12")
                    errName.SetError(txtBirthDay, "")
                    Exit Sub
                Else
                    Select Case txtBirthMonth.Text
                        Case "1", "3", "5", "7", "8", "10", "12"
                            If (CInt(txtBirthDay.Text) < 1 Or CInt(txtBirthDay.Text) > 31) Then
                                errName.SetError(txtBirthDay, "Value must be between 1 and 31")
                                Exit Sub
                            End If
                        Case "2"
                            If (CInt(txtBirthDay.Text) < 1 Or CInt(txtBirthDay.Text) > 29) Then
                                errName.SetError(txtBirthDay, "Value must be between 1 and 29")
                                Exit Sub
                            End If
                        Case "4", "6", "9", "11"
                            If (CInt(txtBirthDay.Text) < 1 Or CInt(txtBirthDay.Text) > 30) Then
                                errName.SetError(txtBirthDay, "Value must be between 1 and 30")
                                Exit Sub
                            End If
                        Case Else
                            MessageBox.Show("Unknown Error")
                            Exit Sub
                    End Select
                End If
            End If
        End If
        errName.SetError(txtBirthMonth, "")
        errName.SetError(txtBirthDay, "")
        If Not Directory.Exists("C:\SystemLogs") Then
            Directory.CreateDirectory("C:\SystemLogs")
        End If
        Dim thePath As String = "C:\SystemLogs\" & EditMember.MemberID & "Modified" & Now.Month & Now.Day & Now.Year & Now.Hour & Now.Minute & Now.Second & ".txt"
        whatIsModified = New StreamWriter(thePath)
        whatIsModified.WriteLine(EditMember.FirstName & " " & EditMember.LastName & " Before:")
        whatIsModified.WriteLine("First Name: " & EditMember.FirstName)
        whatIsModified.WriteLine("Middle Name: " & EditMember.MiddleName)
        whatIsModified.WriteLine("Last Name: " & EditMember.LastName)
        whatIsModified.WriteLine("Address: " & EditMember.Address)
        whatIsModified.WriteLine("City: " & EditMember.City)
        whatIsModified.WriteLine("State: " & EditMember.State)
        whatIsModified.WriteLine("Zip: " & EditMember.Zip)
        whatIsModified.WriteLine("Anniversary: " & EditMember.Anniversary)
        whatIsModified.WriteLine("Home Phone: " & EditMember.HomePhone)
        whatIsModified.WriteLine("Work Phone: " & EditMember.WorkPhone)
        whatIsModified.WriteLine("Email Address: " & EditMember.EMailAddress)
        whatIsModified.WriteLine("Birthday: " & EditMember.Birthday)
        While deleteQueue.Count > 0
            Dim delItem As PaidItem = deleteQueue.Dequeue
            Dim delType As Integer = delItem.PaidType
            delItem.Delete(approvingAdmin.getAuthorized())
            If delType = 2 Then
                EditMember.Anniversary = getLastAnniversaryIfDeleted()
                cboMonth.SelectedText = EditMember.Anniversary.Month
                cboYear.SelectedText = EditMember.Anniversary.Year
            End If
        End While
        EditMember.FirstName = txtFirst.Text.ToUpper
        EditMember.MiddleName = txtMiddle.Text.ToUpper
        EditMember.LastName = txtLast.Text
        EditMember.Address = txtAddress.Text
        EditMember.City = txtCity.Text
        EditMember.State = txtState.Text
        EditMember.Zip = txtZip.Text
        EditMember.HomePhone = txtHomePhone.Text
        EditMember.WorkPhone = txtWorkPhone.Text
        EditMember.EMailAddress = txtEMail.Text
        EditMember.Status = cboStatus.SelectedItem
        EditMember.Type = cboType.SelectedItem
        EditMember.MemberStatus = cboMember.SelectedItem
        If Not txtBirthMonth.Text = String.Empty And Not txtBirthDay.Text = String.Empty Then
            EditMember.Birthday = New Date(2000, CInt(txtBirthMonth.Text), CInt(txtBirthDay.Text))
        End If
        EditMember.InvalidAddress = chkInvalidAddress.Checked
        whatIsModified.WriteLine(EditMember.FirstName & " " & EditMember.LastName & " After:")
        whatIsModified.WriteLine("First Name: " & EditMember.FirstName)
        whatIsModified.WriteLine("Middle Name: " & EditMember.MiddleName)
        whatIsModified.WriteLine("Last Name: " & EditMember.LastName)
        whatIsModified.WriteLine("Address: " & EditMember.Address)
        whatIsModified.WriteLine("City: " & EditMember.City)
        whatIsModified.WriteLine("State: " & EditMember.State)
        whatIsModified.WriteLine("Zip: " & EditMember.Zip)
        whatIsModified.WriteLine("Anniversary: " & EditMember.Anniversary)
        whatIsModified.WriteLine("Home Phone: " & EditMember.HomePhone)
        whatIsModified.WriteLine("Work Phone: " & EditMember.WorkPhone)
        whatIsModified.WriteLine("Email Address: " & EditMember.EMailAddress)
        whatIsModified.WriteLine("Birthday: " & EditMember.Birthday)
        whatIsModified.WriteLine("Modified By: " & approvingAdmin.getAuthorized())
        whatIsModified.Close()


        If EditMember.Save Then
            Try
                Dim sqlConnection As New SqlConnection(My.Settings.SCCheckInConnectionString)
                Dim sqlCommand1 As SqlCommand = New SqlCommand
                Dim comTempMember As SqlCommand = New SqlCommand(sqlCommand1.CommandText, sqlConnection)
                sqlCommand1.CommandType = CommandType.Text
                sqlCommand1.Connection = sqlConnection
                sqlCommand1.CommandText = "UPDATE OKSwingMemberList SET LastUpdatedBy ='" & approvingAdmin.getAuthorized & "', DateLastUpdated = '" & Now.ToString & "' WHERE MemberID = " & MemID
                sqlConnection.Open()
                sqlCommand1.ExecuteNonQuery()
                sqlConnection.Close()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As Exception
                MessageBox.Show("Error Saving Member", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Error Saving Member", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        LoadMembers()
    End Sub

    Private Sub tsbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdShowData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowData.Click
        passChar = True
        txtAddress.PasswordChar = ""
        txtCity.PasswordChar = ""
        txtState.PasswordChar = ""
        txtZip.PasswordChar = ""
        txtHomePhone.PasswordChar = ""
        txtWorkPhone.PasswordChar = ""
        txtEMail.PasswordChar = ""
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim admin2 As String = String.Empty
        Dim sqlConnection As New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim sqlCommand1 As SqlCommand = New SqlCommand
        Dim comTempMember As SqlCommand = New SqlCommand(sqlCommand1.CommandText, sqlConnection)
        Dim anAdaptMember As SqlDataAdapter = New SqlDataAdapter(comTempMember)
        Dim dtTempMember As DataTable = New DataTable
        Dim comTempMemberRecords As SqlCommand = New SqlCommand(sqlCommand1.CommandText, sqlConnection)
        Dim anAdaptMemberRecords As SqlDataAdapter = New SqlDataAdapter(comTempMember)
        Dim dtTempMemberRecords As DataTable = New DataTable
        sqlCommand1.CommandType = CommandType.Text
        sqlCommand1.Connection = sqlConnection
        If MemID = 109 Then
            MessageBox.Show("Floor Rental cannot be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim adminCheck As Windows.Forms.DialogResult = MessageBox.Show("2 Administrator Approval Required. Are you sure you want to continue?", "2 Administrator Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If adminCheck = Windows.Forms.DialogResult.Yes Then
            Dim admin2Check As New frmAdminScan
            admin2Check.ShowDialog()
            If admin2Check.DialogResult = Windows.Forms.DialogResult.Yes And approvingAdmin.getId <> admin2Check.getId Then
                admin2 = admin2Check.getAuthorized()
            Else
                MessageBox.Show("2 Administrator Verification Failed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        Dim result As Windows.Forms.DialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS MEMBER? IF YOU CLICK YES THE MEMBER WILL BE PERMENTALLY DELETED AND THEIR HISTORY WILL BE DELETED WITH NO HOPE OF RECOVERY!", "Confirm Delete of Member", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = Windows.Forms.DialogResult.Yes Then

            Try
                sqlCommand1.CommandText = "INSERT INTO DeletedMembers(MemberID,FirstName,MiddleName,LastName,Address,City,State,Zip,HomePhone,WorkPhone,FaxNumber,EmailAddress,Status,DateJoined,Type,LastPaid,Dues,InputDate,MemberStatus,Organization,DOB,Anniversary,DataEaseMemberNumber,BirthMonth,BirthDay,Charter,NewMemberDate,DateLastUpdated,LastUpdatedBy,Dateadded,AddedBy,Comments,CellPhone,InvalidAddress,IsDeleted,ClassID,isPromoted,currentMonth) SELECT MemberID,FirstName,MiddleName,LastName,Address,City,State,Zip,HomePhone,WorkPhone,FaxNumber,EmailAddress,Status,DateJoined,Type,LastPaid,Dues,InputDate,MemberStatus,Organization,DOB,Anniversary,DataEaseMemberNumber,BirthMonth,BirthDay,Charter,NewMemberDate,DateLastUpdated,LastUpdatedBy,Dateadded,AddedBy,Comments,CellPhone,InvalidAddress,IsDeleted,ClassID,isPromoted,currentMonth FROM OkSwingMemberList WHERE MemberID =" & MemID & "" 'Move data to Voided Tables.
                comTempMember.CommandText = sqlCommand1.CommandText
                sqlConnection.Open()
                sqlCommand1.ExecuteNonQuery()
                sqlCommand1.CommandText = "UPDATE DeletedMembers SET AuthorizedBy = '" & approvingAdmin.getAuthorized() & ", " & admin2 & "' WHERE MemberID = " & MemID
                comTempMember.CommandText = sqlCommand1.CommandText
                sqlCommand1.ExecuteNonQuery()
                sqlCommand1.CommandText = "INSERT INTO VoidedEntries(CheckInID,MemberID,FullName,FirstName,LastName,PaidType,PaidAmount,PaidDate,PaidDesc,DanceType,CreateDate,ReferredBy) SELECT CheckInID,MemberID,FullName,FirstName,LastName,PaidType,PaidAmount,PaidDate,PaidDesc,DanceType,CreateDate,ReferredBy FROM CheckIns WHERE MemberID =" & MemID & ""
                comTempMemberRecords.CommandText = sqlCommand1.CommandText
                sqlCommand1.ExecuteNonQuery()
                sqlCommand1.CommandText = "UPDATE VoidedEntries SET AuthorizedBy = '" & approvingAdmin.getAuthorized() & ", " & admin2 & "' WHERE MemberID = " & MemID
                comTempMemberRecords.CommandText = sqlCommand1.CommandText
                sqlCommand1.ExecuteNonQuery()
                sqlCommand1.CommandText = "DELETE FROM OKSwingMemberList where MemberID =" & MemID & "" 'Delete Member from Main Records.
                sqlCommand1.ExecuteNonQuery()
                sqlCommand1.CommandText = "DELETE FROM CheckIns where MemberID =" & MemID & ""
                sqlCommand1.ExecuteNonQuery()
                sqlConnection.Close()
                isDelete = True
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("Member Delete Failed Because " & ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If passChar Then
            pntControl.Print()
        Else
            MessageBox.Show("Show Member Data Needs To Be Shown First", "Procedure Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lstActivity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstActivity.SelectedIndexChanged
        tsbDeleteActivity.Enabled = True
    End Sub

#End Region

#Region "Functions and other Subs"

    Public Sub getMemberID(ByVal number As Integer)
        MemID = number
    End Sub

    Public Function isDeleted() As Boolean
        Return isDelete
    End Function

    Public Sub getAdmin(ByVal theAdmin As frmAdminScan)
        approvingAdmin = theAdmin
    End Sub

    Private Function getLastAnniversaryIfDeleted() As Date
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim strSQL As String = "Select * from CheckIns where MemberID = " & EditMember.MemberID & " and PaidType = 2 order by CreateDate DESC"
        Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
        Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
        Dim dtTemp As DataTable = New DataTable
        aConn.Open()
        anAdapt.Fill(dtTemp)
        For Each aRow As DataRow In dtTemp.Rows
            Dim tempDate As Date = CDate(aRow.Item("CreateDate"))
            Return New Date(tempDate.Year + 1, tempDate.Month, 1)
        Next
    End Function

#End Region

#Region "Printing Control"

    Private Sub pntControl_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pntControl.PrintPage
        Dim tempString As String = ""
        Dim fnt As Font = New Font("Courier New", 14)
        Dim yCoord As Integer = 16
        Dim adder As Integer = 16
        For a As Integer = 0 To 600 Step 1
            tempString += "_"
        Next
        e.Graphics.DrawString("OKSwingDanceClub Member Information", fnt, Brushes.Black, 200, 0)
        e.Graphics.DrawString(tempString, fnt, Brushes.Black, 0, 6)
        yCoord += adder
        e.Graphics.DrawString("First Name: " & txtFirst.Text, fnt, Brushes.Black, 0, yCoord)
        yCoord += adder
        e.Graphics.DrawString("Middle Name: " & txtMiddle.Text, fnt, Brushes.Black, 0, yCoord)
        yCoord += adder
        e.Graphics.DrawString("Last Name: " & txtLast.Text, fnt, Brushes.Black, 0, yCoord)
        yCoord += adder
        e.Graphics.DrawString("Address: " & txtAddress.Text, fnt, Brushes.Black, 0, yCoord)
        yCoord += adder
        e.Graphics.DrawString("City: " & txtCity.Text, fnt, Brushes.Black, 0, yCoord)
        yCoord += adder
        e.Graphics.DrawString("State: " & txtState.Text, fnt, Brushes.Black, 0, yCoord)
        yCoord += adder
        e.Graphics.DrawString("Zip: " & txtZip.Text, fnt, Brushes.Black, 0, yCoord)
        yCoord += adder
        e.Graphics.DrawString("Home Phone: " & txtHomePhone.Text, fnt, Brushes.Black, 0, yCoord)
        yCoord += adder
        e.Graphics.DrawString("Work Phone: " & txtWorkPhone.Text, fnt, Brushes.Black, 0, yCoord)
        yCoord += adder
        If Not EditMember.Birthday.Date = Nothing Then
            e.Graphics.DrawString("Date of Birth: " & txtBirthMonth.Text & "/" & txtBirthDay.Text, fnt, Brushes.Black, 0, yCoord)
        End If

    End Sub

#End Region

#Region "Validation"

    Private Sub frmEditMember_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBirthMonth.KeyPress, txtBirthDay.KeyPress
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

    Private Sub frmEditMember_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If deleteQueue.Count <> 0 Then
            Dim dialogResult As DialogResult = MessageBox.Show("You Have Modified Some Records. Are You Sure You Want To Continue Without Saving?", "Changes Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dialogResult = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

End Class
