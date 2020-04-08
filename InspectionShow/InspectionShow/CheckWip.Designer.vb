<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckWip
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
        Me.components = New System.ComponentModel.Container()
        Me.btQuery = New System.Windows.Forms.Button()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.rbWB = New System.Windows.Forms.RadioButton()
        Me.rbDB = New System.Windows.Forms.RadioButton()
        Me.lbLoad = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.dgListwip = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DBWBINS_Query_DataTableAdapter = New InspectionShow.DBxDataSetTableAdapters.DBWBINS_Query_DataTableAdapter()
        Me.QuerySumWIPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DBWBINS_QueryTableAdapter = New InspectionShow.DBxDataSetTableAdapters.DBWBINS_QueryTableAdapter()
        Me.InspDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PackageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MachineNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeviceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestMode1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestMode2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestModeName1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestModeName2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotStartTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotEndTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotRequestTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalQtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GoodQtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NgQtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgListwip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.QuerySumWIPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InspDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btQuery
        '
        Me.btQuery.Location = New System.Drawing.Point(229, 39)
        Me.btQuery.Name = "btQuery"
        Me.btQuery.Size = New System.Drawing.Size(75, 23)
        Me.btQuery.TabIndex = 28
        Me.btQuery.Text = "Query"
        Me.btQuery.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(150, 16)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(36, 17)
        Me.rbAll.TabIndex = 25
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbWB
        '
        Me.rbWB.AutoSize = True
        Me.rbWB.Location = New System.Drawing.Point(81, 16)
        Me.rbWB.Name = "rbWB"
        Me.rbWB.Size = New System.Drawing.Size(43, 17)
        Me.rbWB.TabIndex = 26
        Me.rbWB.Text = "WB"
        Me.rbWB.UseVisualStyleBackColor = True
        '
        'rbDB
        '
        Me.rbDB.AutoSize = True
        Me.rbDB.Location = New System.Drawing.Point(12, 16)
        Me.rbDB.Name = "rbDB"
        Me.rbDB.Size = New System.Drawing.Size(40, 17)
        Me.rbDB.TabIndex = 27
        Me.rbDB.Text = "DB"
        Me.rbDB.UseVisualStyleBackColor = True
        '
        'lbLoad
        '
        Me.lbLoad.AutoSize = True
        Me.lbLoad.Location = New System.Drawing.Point(13, 654)
        Me.lbLoad.Name = "lbLoad"
        Me.lbLoad.Size = New System.Drawing.Size(21, 13)
        Me.lbLoad.TabIndex = 29
        Me.lbLoad.Text = "0%"
        '
        'dgListwip
        '
        Me.dgListwip.AllowUserToAddRows = False
        Me.dgListwip.AllowUserToDeleteRows = False
        Me.dgListwip.AutoGenerateColumns = False
        Me.dgListwip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgListwip.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PackageDataGridViewTextBoxColumn, Me.LotNoDataGridViewTextBoxColumn, Me.MachineNoDataGridViewTextBoxColumn, Me.DeviceDataGridViewTextBoxColumn, Me.RequestMode1DataGridViewTextBoxColumn, Me.RequestMode2DataGridViewTextBoxColumn, Me.RequestModeName1DataGridViewTextBoxColumn, Me.RequestModeName2DataGridViewTextBoxColumn, Me.LotStartTimeDataGridViewTextBoxColumn, Me.LotEndTimeDataGridViewTextBoxColumn, Me.LotRequestTimeDataGridViewTextBoxColumn, Me.LotStatusDataGridViewTextBoxColumn, Me.ProcessNameDataGridViewTextBoxColumn, Me.TotalQtyDataGridViewTextBoxColumn, Me.GoodQtyDataGridViewTextBoxColumn, Me.NgQtyDataGridViewTextBoxColumn})
        Me.dgListwip.DataSource = Me.InspDataBindingSource
        Me.dgListwip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgListwip.Location = New System.Drawing.Point(0, 0)
        Me.dgListwip.Name = "dgListwip"
        Me.dgListwip.ReadOnly = True
        Me.dgListwip.Size = New System.Drawing.Size(1153, 588)
        Me.dgListwip.TabIndex = 23
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 39)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgListwip)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1153, 588)
        Me.Panel1.TabIndex = 32
        '
        'DBWBINS_Query_DataTableAdapter
        '
        Me.DBWBINS_Query_DataTableAdapter.ClearBeforeFill = True
        '
        'DBWBINS_QueryTableAdapter
        '
        Me.DBWBINS_QueryTableAdapter.ClearBeforeFill = True
        '
        'InspDataBindingSource
        '
        Me.InspDataBindingSource.DataSource = GetType(InspectionShow.InspData)
        '
        'PackageDataGridViewTextBoxColumn
        '
        Me.PackageDataGridViewTextBoxColumn.DataPropertyName = "Package"
        Me.PackageDataGridViewTextBoxColumn.HeaderText = "Package"
        Me.PackageDataGridViewTextBoxColumn.Name = "PackageDataGridViewTextBoxColumn"
        Me.PackageDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LotNoDataGridViewTextBoxColumn
        '
        Me.LotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.HeaderText = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.Name = "LotNoDataGridViewTextBoxColumn"
        Me.LotNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MachineNoDataGridViewTextBoxColumn
        '
        Me.MachineNoDataGridViewTextBoxColumn.DataPropertyName = "MachineNo"
        Me.MachineNoDataGridViewTextBoxColumn.HeaderText = "MachineNo"
        Me.MachineNoDataGridViewTextBoxColumn.Name = "MachineNoDataGridViewTextBoxColumn"
        Me.MachineNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DeviceDataGridViewTextBoxColumn
        '
        Me.DeviceDataGridViewTextBoxColumn.DataPropertyName = "Device"
        Me.DeviceDataGridViewTextBoxColumn.HeaderText = "Device"
        Me.DeviceDataGridViewTextBoxColumn.Name = "DeviceDataGridViewTextBoxColumn"
        Me.DeviceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RequestMode1DataGridViewTextBoxColumn
        '
        Me.RequestMode1DataGridViewTextBoxColumn.DataPropertyName = "RequestMode1"
        Me.RequestMode1DataGridViewTextBoxColumn.HeaderText = "RequestMode1"
        Me.RequestMode1DataGridViewTextBoxColumn.Name = "RequestMode1DataGridViewTextBoxColumn"
        Me.RequestMode1DataGridViewTextBoxColumn.ReadOnly = True
        '
        'RequestMode2DataGridViewTextBoxColumn
        '
        Me.RequestMode2DataGridViewTextBoxColumn.DataPropertyName = "RequestMode2"
        Me.RequestMode2DataGridViewTextBoxColumn.HeaderText = "RequestMode2"
        Me.RequestMode2DataGridViewTextBoxColumn.Name = "RequestMode2DataGridViewTextBoxColumn"
        Me.RequestMode2DataGridViewTextBoxColumn.ReadOnly = True
        '
        'RequestModeName1DataGridViewTextBoxColumn
        '
        Me.RequestModeName1DataGridViewTextBoxColumn.DataPropertyName = "RequestModeName1"
        Me.RequestModeName1DataGridViewTextBoxColumn.HeaderText = "RequestModeName1"
        Me.RequestModeName1DataGridViewTextBoxColumn.Name = "RequestModeName1DataGridViewTextBoxColumn"
        Me.RequestModeName1DataGridViewTextBoxColumn.ReadOnly = True
        '
        'RequestModeName2DataGridViewTextBoxColumn
        '
        Me.RequestModeName2DataGridViewTextBoxColumn.DataPropertyName = "RequestModeName2"
        Me.RequestModeName2DataGridViewTextBoxColumn.HeaderText = "RequestModeName2"
        Me.RequestModeName2DataGridViewTextBoxColumn.Name = "RequestModeName2DataGridViewTextBoxColumn"
        Me.RequestModeName2DataGridViewTextBoxColumn.ReadOnly = True
        '
        'LotStartTimeDataGridViewTextBoxColumn
        '
        Me.LotStartTimeDataGridViewTextBoxColumn.DataPropertyName = "LotStartTime"
        Me.LotStartTimeDataGridViewTextBoxColumn.HeaderText = "LotStartTime"
        Me.LotStartTimeDataGridViewTextBoxColumn.Name = "LotStartTimeDataGridViewTextBoxColumn"
        Me.LotStartTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LotEndTimeDataGridViewTextBoxColumn
        '
        Me.LotEndTimeDataGridViewTextBoxColumn.DataPropertyName = "LotEndTime"
        Me.LotEndTimeDataGridViewTextBoxColumn.HeaderText = "LotEndTime"
        Me.LotEndTimeDataGridViewTextBoxColumn.Name = "LotEndTimeDataGridViewTextBoxColumn"
        Me.LotEndTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LotRequestTimeDataGridViewTextBoxColumn
        '
        Me.LotRequestTimeDataGridViewTextBoxColumn.DataPropertyName = "LotRequestTime"
        Me.LotRequestTimeDataGridViewTextBoxColumn.HeaderText = "LotRequestTime"
        Me.LotRequestTimeDataGridViewTextBoxColumn.Name = "LotRequestTimeDataGridViewTextBoxColumn"
        Me.LotRequestTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LotStatusDataGridViewTextBoxColumn
        '
        Me.LotStatusDataGridViewTextBoxColumn.DataPropertyName = "LotStatus"
        Me.LotStatusDataGridViewTextBoxColumn.HeaderText = "LotStatus"
        Me.LotStatusDataGridViewTextBoxColumn.Name = "LotStatusDataGridViewTextBoxColumn"
        Me.LotStatusDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProcessNameDataGridViewTextBoxColumn
        '
        Me.ProcessNameDataGridViewTextBoxColumn.DataPropertyName = "ProcessName"
        Me.ProcessNameDataGridViewTextBoxColumn.HeaderText = "ProcessName"
        Me.ProcessNameDataGridViewTextBoxColumn.Name = "ProcessNameDataGridViewTextBoxColumn"
        Me.ProcessNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TotalQtyDataGridViewTextBoxColumn
        '
        Me.TotalQtyDataGridViewTextBoxColumn.DataPropertyName = "TotalQty"
        Me.TotalQtyDataGridViewTextBoxColumn.HeaderText = "TotalQty"
        Me.TotalQtyDataGridViewTextBoxColumn.Name = "TotalQtyDataGridViewTextBoxColumn"
        Me.TotalQtyDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GoodQtyDataGridViewTextBoxColumn
        '
        Me.GoodQtyDataGridViewTextBoxColumn.DataPropertyName = "GoodQty"
        Me.GoodQtyDataGridViewTextBoxColumn.HeaderText = "GoodQty"
        Me.GoodQtyDataGridViewTextBoxColumn.Name = "GoodQtyDataGridViewTextBoxColumn"
        Me.GoodQtyDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NgQtyDataGridViewTextBoxColumn
        '
        Me.NgQtyDataGridViewTextBoxColumn.DataPropertyName = "NgQty"
        Me.NgQtyDataGridViewTextBoxColumn.HeaderText = "NgQty"
        Me.NgQtyDataGridViewTextBoxColumn.Name = "NgQtyDataGridViewTextBoxColumn"
        Me.NgQtyDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CheckWip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 654)
        Me.Controls.Add(Me.btQuery)
        Me.Controls.Add(Me.rbAll)
        Me.Controls.Add(Me.rbWB)
        Me.Controls.Add(Me.rbDB)
        Me.Controls.Add(Me.lbLoad)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "CheckWip"
        Me.Text = "CheckWip"
        CType(Me.dgListwip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.QuerySumWIPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InspDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DBWBINS_Query_DataTableAdapter As DBxDataSetTableAdapters.DBWBINS_Query_DataTableAdapter
    Friend WithEvents btQuery As Button
    Friend WithEvents rbAll As RadioButton
    Friend WithEvents rbWB As RadioButton
    Friend WithEvents rbDB As RadioButton
    Friend WithEvents QuerySumWIPBindingSource As BindingSource
    Friend WithEvents lbLoad As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgListwip As DataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DBWBINS_QueryTableAdapter As DBxDataSetTableAdapters.DBWBINS_QueryTableAdapter
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PackageDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MachineNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DeviceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RequestMode1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RequestMode2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RequestModeName1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RequestModeName2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotStartTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotEndTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotRequestTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotStatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProcessNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalQtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GoodQtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NgQtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InspDataBindingSource As BindingSource
End Class
