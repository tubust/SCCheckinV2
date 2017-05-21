<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminOverride
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lblOverride = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.btnCode = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.tmrCodeEntry = New System.Windows.Forms.Timer(Me.components)
        Me.cboName = New System.Windows.Forms.ComboBox
        Me.btnOverRide = New System.Windows.Forms.Button
        Me.lblTimer = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblOverride
        '
        Me.lblOverride.AutoSize = True
        Me.lblOverride.Location = New System.Drawing.Point(4, 13)
        Me.lblOverride.Name = "lblOverride"
        Me.lblOverride.Size = New System.Drawing.Size(131, 13)
        Me.lblOverride.TabIndex = 1
        Me.lblOverride.Text = "Please Select Your Name:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(188, 41)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(236, 20)
        Me.TextBox2.TabIndex = 2
        '
        'btnCode
        '
        Me.btnCode.Location = New System.Drawing.Point(12, 67)
        Me.btnCode.Name = "btnCode"
        Me.btnCode.Size = New System.Drawing.Size(207, 23)
        Me.btnCode.TabIndex = 3
        Me.btnCode.Text = "Get Code"
        Me.btnCode.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Enter Over Ride Code:"
        '
        'tmrCodeEntry
        '
        Me.tmrCodeEntry.Interval = 1000
        '
        'cboName
        '
        Me.cboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboName.FormattingEnabled = True
        Me.cboName.Location = New System.Drawing.Point(188, 10)
        Me.cboName.Name = "cboName"
        Me.cboName.Size = New System.Drawing.Size(236, 21)
        Me.cboName.TabIndex = 5
        '
        'btnOverRide
        '
        Me.btnOverRide.Enabled = False
        Me.btnOverRide.Location = New System.Drawing.Point(225, 66)
        Me.btnOverRide.Name = "btnOverRide"
        Me.btnOverRide.Size = New System.Drawing.Size(198, 23)
        Me.btnOverRide.TabIndex = 6
        Me.btnOverRide.Text = "Over Ride Tag"
        Me.btnOverRide.UseVisualStyleBackColor = True
        '
        'lblTimer
        '
        Me.lblTimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimer.Location = New System.Drawing.Point(12, 95)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(411, 23)
        Me.lblTimer.TabIndex = 7
        Me.lblTimer.Text = "Click Get Code to send a Code to Your Email"
        Me.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAdminOverride
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 128)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.btnOverRide)
        Me.Controls.Add(Me.cboName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCode)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.lblOverride)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(451, 167)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(451, 167)
        Me.Name = "frmAdminOverride"
        Me.ShowIcon = False
        Me.Text = "Over Ride Key Tag"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOverride As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btnCode As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tmrCodeEntry As System.Windows.Forms.Timer
    Friend WithEvents cboName As System.Windows.Forms.ComboBox
    Friend WithEvents btnOverRide As System.Windows.Forms.Button
    Friend WithEvents lblTimer As System.Windows.Forms.Label
End Class
