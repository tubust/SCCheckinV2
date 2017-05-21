<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeyCardEntry
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
        Me.lblScan = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.chkAdmin = New System.Windows.Forms.CheckBox
        Me.tmrReset = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblScan
        '
        Me.lblScan.AutoSize = True
        Me.lblScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScan.Location = New System.Drawing.Point(12, 9)
        Me.lblScan.Name = "lblScan"
        Me.lblScan.Size = New System.Drawing.Size(156, 20)
        Me.lblScan.TabIndex = 1
        Me.lblScan.Text = "Scan In The Keycard"
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(12, 39)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(389, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'chkAdmin
        '
        Me.chkAdmin.AutoSize = True
        Me.chkAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAdmin.Location = New System.Drawing.Point(174, 9)
        Me.chkAdmin.Name = "chkAdmin"
        Me.chkAdmin.Size = New System.Drawing.Size(227, 24)
        Me.chkAdmin.TabIndex = 4
        Me.chkAdmin.Text = "Key Card is an Administrator"
        Me.chkAdmin.UseVisualStyleBackColor = True
        '
        'tmrReset
        '
        Me.tmrReset.Enabled = True
        Me.tmrReset.Interval = 2500
        '
        'frmKeyCardEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 69)
        Me.Controls.Add(Me.chkAdmin)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblScan)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(430, 108)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(430, 108)
        Me.Name = "frmKeyCardEntry"
        Me.ShowIcon = False
        Me.Text = "Key Card Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblScan As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents chkAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents tmrReset As System.Windows.Forms.Timer
End Class
