<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnterMerchandise
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
        Dim ItemNameLabel As System.Windows.Forms.Label
        Dim ItemDescLabel As System.Windows.Forms.Label
        Dim ItemPriceLabel As System.Windows.Forms.Label
        Me.SCCheckInDataSet = New SCCheckIn.SCCheckInDataSet
        Me.MerchandiseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MerchandiseTableAdapter = New SCCheckIn.SCCheckInDataSetTableAdapters.MerchandiseTableAdapter
        Me.TableAdapterManager = New SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager
        Me.ItemNameComboBox = New System.Windows.Forms.ComboBox
        Me.ItemDescTextBox = New System.Windows.Forms.TextBox
        Me.ItemPriceTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Button1 = New System.Windows.Forms.Button
        ItemNameLabel = New System.Windows.Forms.Label
        ItemDescLabel = New System.Windows.Forms.Label
        ItemPriceLabel = New System.Windows.Forms.Label
        CType(Me.SCCheckInDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MerchandiseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ItemNameLabel
        '
        ItemNameLabel.AutoSize = True
        ItemNameLabel.Location = New System.Drawing.Point(12, 9)
        ItemNameLabel.Name = "ItemNameLabel"
        ItemNameLabel.Size = New System.Drawing.Size(61, 13)
        ItemNameLabel.TabIndex = 1
        ItemNameLabel.Text = "Item Name:"
        '
        'ItemDescLabel
        '
        ItemDescLabel.AutoSize = True
        ItemDescLabel.Location = New System.Drawing.Point(12, 35)
        ItemDescLabel.Name = "ItemDescLabel"
        ItemDescLabel.Size = New System.Drawing.Size(86, 13)
        ItemDescLabel.TabIndex = 2
        ItemDescLabel.Text = "Item Description:"
        '
        'ItemPriceLabel
        '
        ItemPriceLabel.AutoSize = True
        ItemPriceLabel.Location = New System.Drawing.Point(12, 61)
        ItemPriceLabel.Name = "ItemPriceLabel"
        ItemPriceLabel.Size = New System.Drawing.Size(57, 13)
        ItemPriceLabel.TabIndex = 4
        ItemPriceLabel.Text = "Item Price:"
        '
        'SCCheckInDataSet
        '
        Me.SCCheckInDataSet.DataSetName = "SCCheckInDataSet"
        Me.SCCheckInDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MerchandiseBindingSource
        '
        Me.MerchandiseBindingSource.DataMember = "Merchandise"
        Me.MerchandiseBindingSource.DataSource = Me.SCCheckInDataSet
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
        'ItemNameComboBox
        '
        Me.ItemNameComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MerchandiseBindingSource, "ItemName", True))
        Me.ItemNameComboBox.DataSource = Me.MerchandiseBindingSource
        Me.ItemNameComboBox.DisplayMember = "ItemName"
        Me.ItemNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemNameComboBox.FormattingEnabled = True
        Me.ItemNameComboBox.Location = New System.Drawing.Point(107, 6)
        Me.ItemNameComboBox.Name = "ItemNameComboBox"
        Me.ItemNameComboBox.Size = New System.Drawing.Size(260, 21)
        Me.ItemNameComboBox.TabIndex = 2
        '
        'ItemDescTextBox
        '
        Me.ItemDescTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MerchandiseBindingSource, "ItemDesc", True))
        Me.ItemDescTextBox.Location = New System.Drawing.Point(107, 32)
        Me.ItemDescTextBox.Name = "ItemDescTextBox"
        Me.ItemDescTextBox.ReadOnly = True
        Me.ItemDescTextBox.Size = New System.Drawing.Size(260, 20)
        Me.ItemDescTextBox.TabIndex = 3
        '
        'ItemPriceTextBox
        '
        Me.ItemPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MerchandiseBindingSource, "ItemPrice", True))
        Me.ItemPriceTextBox.Location = New System.Drawing.Point(107, 58)
        Me.ItemPriceTextBox.Name = "ItemPriceTextBox"
        Me.ItemPriceTextBox.ReadOnly = True
        Me.ItemPriceTextBox.Size = New System.Drawing.Size(260, 20)
        Me.ItemPriceTextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Quantity:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(107, 85)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(260, 20)
        Me.NumericUpDown1.TabIndex = 7
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 111)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(352, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Add To Merchandise Line"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmEnterMerchandise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 141)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(ItemPriceLabel)
        Me.Controls.Add(Me.ItemPriceTextBox)
        Me.Controls.Add(ItemDescLabel)
        Me.Controls.Add(Me.ItemDescTextBox)
        Me.Controls.Add(ItemNameLabel)
        Me.Controls.Add(Me.ItemNameComboBox)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(403, 180)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(403, 180)
        Me.Name = "frmEnterMerchandise"
        Me.ShowIcon = False
        Me.Text = "frmEnterMerchandise"
        CType(Me.SCCheckInDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MerchandiseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SCCheckInDataSet As SCCheckIn.SCCheckInDataSet
    Friend WithEvents MerchandiseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MerchandiseTableAdapter As SCCheckIn.SCCheckInDataSetTableAdapters.MerchandiseTableAdapter
    Friend WithEvents TableAdapterManager As SCCheckIn.SCCheckInDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ItemNameComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ItemDescTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ItemPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
