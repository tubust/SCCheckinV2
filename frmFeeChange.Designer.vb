<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFeeChange
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
        Dim FeeIDLabel As System.Windows.Forms.Label
        Dim FeeCodeLabel As System.Windows.Forms.Label
        Dim FeeAmountLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFeeChange))
        Me.TblFeesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TblFeesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.FeeIDTextBox = New System.Windows.Forms.TextBox
        Me.FeeCodeTextBox = New System.Windows.Forms.TextBox
        Me.FeeAmountTextBox = New System.Windows.Forms.TextBox
        Me.DBErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TblFeesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SCCheckInDataSet = New SCCheckIn.SCCheckInDataSet
        Me.TblFeesTableAdapter = New SCCheckIn.SCCheckInDataSetTableAdapters.tblFeesTableAdapter
        Me.TableAdapterManager = New SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager
        FeeIDLabel = New System.Windows.Forms.Label
        FeeCodeLabel = New System.Windows.Forms.Label
        FeeAmountLabel = New System.Windows.Forms.Label
        CType(Me.TblFeesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TblFeesBindingNavigator.SuspendLayout()
        CType(Me.DBErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblFeesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SCCheckInDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FeeIDLabel
        '
        FeeIDLabel.AutoSize = True
        FeeIDLabel.Location = New System.Drawing.Point(12, 36)
        FeeIDLabel.Name = "FeeIDLabel"
        FeeIDLabel.Size = New System.Drawing.Size(42, 13)
        FeeIDLabel.TabIndex = 1
        FeeIDLabel.Text = "Fee ID:"
        '
        'FeeCodeLabel
        '
        FeeCodeLabel.AutoSize = True
        FeeCodeLabel.Location = New System.Drawing.Point(12, 62)
        FeeCodeLabel.Name = "FeeCodeLabel"
        FeeCodeLabel.Size = New System.Drawing.Size(56, 13)
        FeeCodeLabel.TabIndex = 3
        FeeCodeLabel.Text = "Fee Code:"
        '
        'FeeAmountLabel
        '
        FeeAmountLabel.AutoSize = True
        FeeAmountLabel.Location = New System.Drawing.Point(12, 88)
        FeeAmountLabel.Name = "FeeAmountLabel"
        FeeAmountLabel.Size = New System.Drawing.Size(67, 13)
        FeeAmountLabel.TabIndex = 5
        FeeAmountLabel.Text = "Fee Amount:"
        '
        'TblFeesBindingNavigator
        '
        Me.TblFeesBindingNavigator.AddNewItem = Nothing
        Me.TblFeesBindingNavigator.BindingSource = Me.TblFeesBindingSource
        Me.TblFeesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TblFeesBindingNavigator.DeleteItem = Nothing
        Me.TblFeesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.TblFeesBindingNavigatorSaveItem})
        Me.TblFeesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TblFeesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TblFeesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TblFeesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TblFeesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TblFeesBindingNavigator.Name = "TblFeesBindingNavigator"
        Me.TblFeesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TblFeesBindingNavigator.Size = New System.Drawing.Size(275, 25)
        Me.TblFeesBindingNavigator.TabIndex = 0
        Me.TblFeesBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TblFeesBindingNavigatorSaveItem
        '
        Me.TblFeesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TblFeesBindingNavigatorSaveItem.Image = CType(resources.GetObject("TblFeesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.TblFeesBindingNavigatorSaveItem.Name = "TblFeesBindingNavigatorSaveItem"
        Me.TblFeesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.TblFeesBindingNavigatorSaveItem.Text = "Save Data"
        '
        'FeeIDTextBox
        '
        Me.FeeIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblFeesBindingSource, "FeeID", True))
        Me.FeeIDTextBox.Location = New System.Drawing.Point(85, 33)
        Me.FeeIDTextBox.Name = "FeeIDTextBox"
        Me.FeeIDTextBox.ReadOnly = True
        Me.FeeIDTextBox.Size = New System.Drawing.Size(167, 20)
        Me.FeeIDTextBox.TabIndex = 2
        '
        'FeeCodeTextBox
        '
        Me.FeeCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblFeesBindingSource, "FeeCode", True))
        Me.FeeCodeTextBox.Location = New System.Drawing.Point(85, 59)
        Me.FeeCodeTextBox.Name = "FeeCodeTextBox"
        Me.FeeCodeTextBox.ReadOnly = True
        Me.FeeCodeTextBox.Size = New System.Drawing.Size(167, 20)
        Me.FeeCodeTextBox.TabIndex = 4
        '
        'FeeAmountTextBox
        '
        Me.FeeAmountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblFeesBindingSource, "FeeAmount", True))
        Me.FeeAmountTextBox.Location = New System.Drawing.Point(85, 85)
        Me.FeeAmountTextBox.Name = "FeeAmountTextBox"
        Me.FeeAmountTextBox.Size = New System.Drawing.Size(167, 20)
        Me.FeeAmountTextBox.TabIndex = 6
        '
        'DBErrorProvider
        '
        Me.DBErrorProvider.ContainerControl = Me
        '
        'TblFeesBindingSource
        '
        Me.TblFeesBindingSource.DataMember = "tblFees"
        Me.TblFeesBindingSource.DataSource = Me.SCCheckInDataSet
        '
        'SCCheckInDataSet
        '
        Me.SCCheckInDataSet.DataSetName = "SCCheckInDataSet"
        Me.SCCheckInDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblFeesTableAdapter
        '
        Me.TblFeesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CheckInsTableAdapter = Nothing
        Me.TableAdapterManager.ContestantsTableAdapter = Nothing
        Me.TableAdapterManager.DeletedMembersTableAdapter = Nothing
        Me.TableAdapterManager.KeyCardTableTableAdapter = Nothing
        Me.TableAdapterManager.MerchandiseTableAdapter = Nothing
        Me.TableAdapterManager.OKSwingMemberListTableAdapter = Nothing
        Me.TableAdapterManager.passwordsTableAdapter = Nothing
        Me.TableAdapterManager.tblFeesTableAdapter = Me.TblFeesTableAdapter
        Me.TableAdapterManager.UpdateOrder = SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VoidedEntriesTableAdapter = Nothing
        '
        'frmFeeChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 117)
        Me.Controls.Add(FeeIDLabel)
        Me.Controls.Add(Me.FeeIDTextBox)
        Me.Controls.Add(FeeCodeLabel)
        Me.Controls.Add(Me.FeeCodeTextBox)
        Me.Controls.Add(FeeAmountLabel)
        Me.Controls.Add(Me.FeeAmountTextBox)
        Me.Controls.Add(Me.TblFeesBindingNavigator)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(291, 156)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(291, 156)
        Me.Name = "frmFeeChange"
        Me.Text = "Fee Changing Console"
        CType(Me.TblFeesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TblFeesBindingNavigator.ResumeLayout(False)
        Me.TblFeesBindingNavigator.PerformLayout()
        CType(Me.DBErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblFeesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SCCheckInDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SCCheckInDataSet As SCCheckIn.SCCheckInDataSet
    Friend WithEvents TblFeesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblFeesTableAdapter As SCCheckIn.SCCheckInDataSetTableAdapters.tblFeesTableAdapter
    Friend WithEvents TableAdapterManager As SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TblFeesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TblFeesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents FeeIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FeeCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FeeAmountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DBErrorProvider As System.Windows.Forms.ErrorProvider
End Class
