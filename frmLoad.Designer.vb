<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoad
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lblStatus = New System.Windows.Forms.Label
        Me.chkLoadMDB = New System.Windows.Forms.CheckBox
        Me.chkLoadMonthly = New System.Windows.Forms.CheckBox
        Me.tmrStart = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(12, 9)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(117, 20)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "Loading Data..."
        '
        'chkLoadMDB
        '
        Me.chkLoadMDB.AutoSize = True
        Me.chkLoadMDB.Location = New System.Drawing.Point(16, 53)
        Me.chkLoadMDB.Name = "chkLoadMDB"
        Me.chkLoadMDB.Size = New System.Drawing.Size(145, 17)
        Me.chkLoadMDB.TabIndex = 1
        Me.chkLoadMDB.Text = "Load Members Database"
        Me.chkLoadMDB.UseVisualStyleBackColor = True
        '
        'chkLoadMonthly
        '
        Me.chkLoadMonthly.AutoSize = True
        Me.chkLoadMonthly.Location = New System.Drawing.Point(16, 76)
        Me.chkLoadMonthly.Name = "chkLoadMonthly"
        Me.chkLoadMonthly.Size = New System.Drawing.Size(116, 17)
        Me.chkLoadMonthly.TabIndex = 2
        Me.chkLoadMonthly.Text = "Load Monthly Data"
        Me.chkLoadMonthly.UseVisualStyleBackColor = True
        '
        'tmrStart
        '
        Me.tmrStart.Enabled = True
        Me.tmrStart.Interval = 1000
        '
        'frmLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(332, 125)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkLoadMonthly)
        Me.Controls.Add(Me.chkLoadMDB)
        Me.Controls.Add(Me.lblStatus)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents chkLoadMDB As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadMonthly As System.Windows.Forms.CheckBox
    Friend WithEvents tmrStart As System.Windows.Forms.Timer
End Class
