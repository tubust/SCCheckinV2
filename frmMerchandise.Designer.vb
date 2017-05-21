<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMerchandise
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
        Dim ItemIDLabel As System.Windows.Forms.Label
        Dim ItemNameLabel As System.Windows.Forms.Label
        Dim ItemDescLabel As System.Windows.Forms.Label
        Dim ItemPriceLabel As System.Windows.Forms.Label
        Me.ItemIDComboBox = New System.Windows.Forms.ComboBox
        Me.MerchandiseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SCCheckInDataSet = New SCCheckIn.SCCheckInDataSet
        Me.ItemNameTextBox = New System.Windows.Forms.TextBox
        Me.ItemDescTextBox = New System.Windows.Forms.TextBox
        Me.ItemPriceTextBox = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MerchandiseTableAdapter = New SCCheckIn.SCCheckInDataSetTableAdapters.MerchandiseTableAdapter
        Me.TableAdapterManager = New SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager
        ItemIDLabel = New System.Windows.Forms.Label
        ItemNameLabel = New System.Windows.Forms.Label
        ItemDescLabel = New System.Windows.Forms.Label
        ItemPriceLabel = New System.Windows.Forms.Label
        CType(Me.MerchandiseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SCCheckInDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ItemIDLabel
        '
        ItemIDLabel.AutoSize = True
        ItemIDLabel.Location = New System.Drawing.Point(12, 43)
        ItemIDLabel.Name = "ItemIDLabel"
        ItemIDLabel.Size = New System.Drawing.Size(44, 13)
        ItemIDLabel.TabIndex = 0
        ItemIDLabel.Text = "Item ID:"
        '
        'ItemNameLabel
        '
        ItemNameLabel.AutoSize = True
        ItemNameLabel.Location = New System.Drawing.Point(12, 70)
        ItemNameLabel.Name = "ItemNameLabel"
        ItemNameLabel.Size = New System.Drawing.Size(61, 13)
        ItemNameLabel.TabIndex = 2
        ItemNameLabel.Text = "Item Name:"
        '
        'ItemDescLabel
        '
        ItemDescLabel.AutoSize = True
        ItemDescLabel.Location = New System.Drawing.Point(12, 96)
        ItemDescLabel.Name = "ItemDescLabel"
        ItemDescLabel.Size = New System.Drawing.Size(86, 13)
        ItemDescLabel.TabIndex = 4
        ItemDescLabel.Text = "Item Description:"
        '
        'ItemPriceLabel
        '
        ItemPriceLabel.AutoSize = True
        ItemPriceLabel.Location = New System.Drawing.Point(12, 122)
        ItemPriceLabel.Name = "ItemPriceLabel"
        ItemPriceLabel.Size = New System.Drawing.Size(57, 13)
        ItemPriceLabel.TabIndex = 6
        ItemPriceLabel.Text = "Item Price:"
        '
        'ItemIDComboBox
        '
        Me.ItemIDComboBox.DataSource = Me.MerchandiseBindingSource
        Me.ItemIDComboBox.DisplayMember = "ItemID"
        Me.ItemIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemIDComboBox.FormattingEnabled = True
        Me.ItemIDComboBox.Location = New System.Drawing.Point(104, 40)
        Me.ItemIDComboBox.Name = "ItemIDComboBox"
        Me.ItemIDComboBox.Size = New System.Drawing.Size(249, 21)
        Me.ItemIDComboBox.TabIndex = 1
        Me.ItemIDComboBox.ValueMember = "ItemID"
        '
        'MerchandiseBindingSource
        '
        Me.MerchandiseBindingSource.DataMember = "Merchandise"
        Me.MerchandiseBindingSource.DataSource = Me.SCCheckInDataSet
        '
        'SCCheckInDataSet
        '
        Me.SCCheckInDataSet.DataSetName = "SCCheckInDataSet"
        Me.SCCheckInDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ItemNameTextBox
        '
        Me.ItemNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MerchandiseBindingSource, "ItemName", True))
        Me.ItemNameTextBox.Location = New System.Drawing.Point(104, 67)
        Me.ItemNameTextBox.Name = "ItemNameTextBox"
        Me.ItemNameTextBox.Size = New System.Drawing.Size(249, 20)
        Me.ItemNameTextBox.TabIndex = 3
        '
        'ItemDescTextBox
        '
        Me.ItemDescTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MerchandiseBindingSource, "ItemDesc", True))
        Me.ItemDescTextBox.Location = New System.Drawing.Point(104, 93)
        Me.ItemDescTextBox.Name = "ItemDescTextBox"
        Me.ItemDescTextBox.Size = New System.Drawing.Size(249, 20)
        Me.ItemDescTextBox.TabIndex = 5
        '
        'ItemPriceTextBox
        '
        Me.ItemPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MerchandiseBindingSource, "ItemPrice", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.ItemPriceTextBox.Location = New System.Drawing.Point(104, 119)
        Me.ItemPriceTextBox.Name = "ItemPriceTextBox"
        Me.ItemPriceTextBox.Size = New System.Drawing.Size(249, 20)
        Me.ItemPriceTextBox.TabIndex = 7
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AddItemToolStripMenuItem, Me.SaveItemToolStripMenuItem, Me.DeleteItemToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(365, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'AddItemToolStripMenuItem
        '
        Me.AddItemToolStripMenuItem.Name = "AddItemToolStripMenuItem"
        Me.AddItemToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.AddItemToolStripMenuItem.Text = "Add Item"
        '
        'SaveItemToolStripMenuItem
        '
        Me.SaveItemToolStripMenuItem.Name = "SaveItemToolStripMenuItem"
        Me.SaveItemToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.SaveItemToolStripMenuItem.Text = "Save Item"
        '
        'DeleteItemToolStripMenuItem
        '
        Me.DeleteItemToolStripMenuItem.Name = "DeleteItemToolStripMenuItem"
        Me.DeleteItemToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.DeleteItemToolStripMenuItem.Text = "Delete Item"
        '
        'MerchandiseTableAdapter
        '
        Me.MerchandiseTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CheckInsTableAdapter = Nothing
        Me.TableAdapterManager.ContestantsTableAdapter = Nothing
        Me.TableAdapterManager.DeletedMembersTableAdapter = Nothing
        Me.TableAdapterManager.KeyCardTableTableAdapter = Nothing
        Me.TableAdapterManager.MerchandiseTableAdapter = Me.MerchandiseTableAdapter
        Me.TableAdapterManager.OKSwingMemberListTableAdapter = Nothing
        Me.TableAdapterManager.passwordsTableAdapter = Nothing
        Me.TableAdapterManager.tblFeesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VoidedEntriesTableAdapter = Nothing
        '
        'frmMerchandise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(365, 158)
        Me.Controls.Add(ItemIDLabel)
        Me.Controls.Add(Me.ItemIDComboBox)
        Me.Controls.Add(ItemNameLabel)
        Me.Controls.Add(Me.ItemNameTextBox)
        Me.Controls.Add(ItemDescLabel)
        Me.Controls.Add(Me.ItemDescTextBox)
        Me.Controls.Add(ItemPriceLabel)
        Me.Controls.Add(Me.ItemPriceTextBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(381, 197)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(381, 197)
        Me.Name = "frmMerchandise"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Add or Edit Merchandise"
        CType(Me.MerchandiseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SCCheckInDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SCCheckInDataSet As SCCheckIn.SCCheckInDataSet
    Friend WithEvents ItemIDComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ItemNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ItemDescTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ItemPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MerchandiseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MerchandiseTableAdapter As SCCheckIn.SCCheckInDataSetTableAdapters.MerchandiseTableAdapter
    Friend WithEvents TableAdapterManager As SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DeleteItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
