<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueryWIP
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
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.rbWB = New System.Windows.Forms.RadioButton()
        Me.rbDB = New System.Windows.Forms.RadioButton()
        Me.dgWipSumDay = New System.Windows.Forms.DataGridView()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DayDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NightDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuerySumWIPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DBxDataSet = New InspectionShow.DBxDataSet()
        Me.dgListwip = New System.Windows.Forms.DataGridView()
        Me.DBWBINSQueryDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.gvDaywip = New System.Windows.Forms.DataGridView()
        Me.DeviceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReqDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestModeName1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestModeName2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateWIPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DBWBINSQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DBWBINS_QueryTableAdapter = New InspectionShow.DBxDataSetTableAdapters.DBWBINS_QueryTableAdapter()
        Me.DBWBINS_Query_DataTableAdapter = New InspectionShow.DBxDataSetTableAdapters.DBWBINS_Query_DataTableAdapter()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btQuery = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbLoad = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackageDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeviceDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestMode1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateWIPDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Day = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Night = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReqDateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DayDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTimeDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndTimeDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestModeName1DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestModeName2DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgWipSumDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QuerySumWIPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgListwip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBWBINSQueryDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDaywip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBWBINSQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(161, 23)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(36, 17)
        Me.rbAll.TabIndex = 12
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbWB
        '
        Me.rbWB.AutoSize = True
        Me.rbWB.Location = New System.Drawing.Point(92, 23)
        Me.rbWB.Name = "rbWB"
        Me.rbWB.Size = New System.Drawing.Size(43, 17)
        Me.rbWB.TabIndex = 13
        Me.rbWB.Text = "WB"
        Me.rbWB.UseVisualStyleBackColor = True
        '
        'rbDB
        '
        Me.rbDB.AutoSize = True
        Me.rbDB.Location = New System.Drawing.Point(23, 23)
        Me.rbDB.Name = "rbDB"
        Me.rbDB.Size = New System.Drawing.Size(40, 17)
        Me.rbDB.TabIndex = 14
        Me.rbDB.Text = "DB"
        Me.rbDB.UseVisualStyleBackColor = True
        '
        'dgWipSumDay
        '
        Me.dgWipSumDay.AllowUserToAddRows = False
        Me.dgWipSumDay.AllowUserToDeleteRows = False
        Me.dgWipSumDay.AutoGenerateColumns = False
        Me.dgWipSumDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgWipSumDay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.DayDataGridViewTextBoxColumn1, Me.NightDataGridViewTextBoxColumn1, Me.TotalDataGridViewTextBoxColumn})
        Me.dgWipSumDay.DataSource = Me.QuerySumWIPBindingSource
        Me.dgWipSumDay.Location = New System.Drawing.Point(682, 90)
        Me.dgWipSumDay.Name = "dgWipSumDay"
        Me.dgWipSumDay.ReadOnly = True
        Me.dgWipSumDay.Size = New System.Drawing.Size(436, 534)
        Me.dgWipSumDay.TabIndex = 11
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DayDataGridViewTextBoxColumn1
        '
        Me.DayDataGridViewTextBoxColumn1.DataPropertyName = "Day"
        Me.DayDataGridViewTextBoxColumn1.HeaderText = "Day"
        Me.DayDataGridViewTextBoxColumn1.Name = "DayDataGridViewTextBoxColumn1"
        Me.DayDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'NightDataGridViewTextBoxColumn1
        '
        Me.NightDataGridViewTextBoxColumn1.DataPropertyName = "Night"
        Me.NightDataGridViewTextBoxColumn1.HeaderText = "Night"
        Me.NightDataGridViewTextBoxColumn1.Name = "NightDataGridViewTextBoxColumn1"
        Me.NightDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'TotalDataGridViewTextBoxColumn
        '
        Me.TotalDataGridViewTextBoxColumn.DataPropertyName = "Total"
        Me.TotalDataGridViewTextBoxColumn.HeaderText = "Total"
        Me.TotalDataGridViewTextBoxColumn.Name = "TotalDataGridViewTextBoxColumn"
        Me.TotalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QuerySumWIPBindingSource
        '
        Me.QuerySumWIPBindingSource.DataMember = "Query_SumWIP"
        Me.QuerySumWIPBindingSource.DataSource = Me.DBxDataSet
        '
        'DBxDataSet
        '
        Me.DBxDataSet.DataSetName = "DBxDataSet"
        Me.DBxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgListwip
        '
        Me.dgListwip.AllowUserToAddRows = False
        Me.dgListwip.AllowUserToDeleteRows = False
        Me.dgListwip.AutoGenerateColumns = False
        Me.dgListwip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgListwip.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumberDataGridViewTextBoxColumn, Me.PackageDataGridViewTextBoxColumn1, Me.DeviceDataGridViewTextBoxColumn1, Me.LotNoDataGridViewTextBoxColumn1, Me.RequestMode1, Me.DateWIPDataGridViewTextBoxColumn1, Me.Day, Me.Night, Me.ReqDateDataGridViewTextBoxColumn1, Me.DayDataGridViewTextBoxColumn, Me.NightDataGridViewTextBoxColumn, Me.StartTimeDataGridViewTextBoxColumn1, Me.EndTimeDataGridViewTextBoxColumn1, Me.RequestModeName1DataGridViewTextBoxColumn1, Me.RequestModeName2DataGridViewTextBoxColumn1, Me.ProcessDataGridViewTextBoxColumn1, Me.StatusDataGridViewTextBoxColumn1})
        Me.dgListwip.DataSource = Me.DBWBINSQueryDataBindingSource
        Me.dgListwip.Location = New System.Drawing.Point(23, 90)
        Me.dgListwip.Name = "dgListwip"
        Me.dgListwip.ReadOnly = True
        Me.dgListwip.Size = New System.Drawing.Size(643, 534)
        Me.dgListwip.TabIndex = 10
        '
        'DBWBINSQueryDataBindingSource
        '
        Me.DBWBINSQueryDataBindingSource.DataMember = "DBWBINS_Query_Data"
        Me.DBWBINSQueryDataBindingSource.DataSource = Me.DBxDataSet
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(285, 47)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 8
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(23, 46)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 9
        '
        'gvDaywip
        '
        Me.gvDaywip.AutoGenerateColumns = False
        Me.gvDaywip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvDaywip.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DeviceDataGridViewTextBoxColumn, Me.LotNoDataGridViewTextBoxColumn, Me.PackageDataGridViewTextBoxColumn, Me.ReqDateDataGridViewTextBoxColumn, Me.StartTimeDataGridViewTextBoxColumn, Me.EndTimeDataGridViewTextBoxColumn, Me.RequestModeName1DataGridViewTextBoxColumn, Me.RequestModeName2DataGridViewTextBoxColumn, Me.ProcessDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.DateWIPDataGridViewTextBoxColumn})
        Me.gvDaywip.DataSource = Me.DBWBINSQueryBindingSource
        Me.gvDaywip.Location = New System.Drawing.Point(892, 31)
        Me.gvDaywip.Name = "gvDaywip"
        Me.gvDaywip.Size = New System.Drawing.Size(238, 154)
        Me.gvDaywip.TabIndex = 6
        Me.gvDaywip.Visible = False
        '
        'DeviceDataGridViewTextBoxColumn
        '
        Me.DeviceDataGridViewTextBoxColumn.DataPropertyName = "Device"
        Me.DeviceDataGridViewTextBoxColumn.HeaderText = "Device"
        Me.DeviceDataGridViewTextBoxColumn.Name = "DeviceDataGridViewTextBoxColumn"
        Me.DeviceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LotNoDataGridViewTextBoxColumn
        '
        Me.LotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.HeaderText = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.Name = "LotNoDataGridViewTextBoxColumn"
        '
        'PackageDataGridViewTextBoxColumn
        '
        Me.PackageDataGridViewTextBoxColumn.DataPropertyName = "Package"
        Me.PackageDataGridViewTextBoxColumn.HeaderText = "Package"
        Me.PackageDataGridViewTextBoxColumn.Name = "PackageDataGridViewTextBoxColumn"
        '
        'ReqDateDataGridViewTextBoxColumn
        '
        Me.ReqDateDataGridViewTextBoxColumn.DataPropertyName = "ReqDate"
        Me.ReqDateDataGridViewTextBoxColumn.HeaderText = "ReqDate"
        Me.ReqDateDataGridViewTextBoxColumn.Name = "ReqDateDataGridViewTextBoxColumn"
        '
        'StartTimeDataGridViewTextBoxColumn
        '
        Me.StartTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime"
        Me.StartTimeDataGridViewTextBoxColumn.HeaderText = "StartTime"
        Me.StartTimeDataGridViewTextBoxColumn.Name = "StartTimeDataGridViewTextBoxColumn"
        '
        'EndTimeDataGridViewTextBoxColumn
        '
        Me.EndTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime"
        Me.EndTimeDataGridViewTextBoxColumn.HeaderText = "EndTime"
        Me.EndTimeDataGridViewTextBoxColumn.Name = "EndTimeDataGridViewTextBoxColumn"
        '
        'RequestModeName1DataGridViewTextBoxColumn
        '
        Me.RequestModeName1DataGridViewTextBoxColumn.DataPropertyName = "RequestModeName1"
        Me.RequestModeName1DataGridViewTextBoxColumn.HeaderText = "RequestModeName1"
        Me.RequestModeName1DataGridViewTextBoxColumn.Name = "RequestModeName1DataGridViewTextBoxColumn"
        '
        'RequestModeName2DataGridViewTextBoxColumn
        '
        Me.RequestModeName2DataGridViewTextBoxColumn.DataPropertyName = "RequestModeName2"
        Me.RequestModeName2DataGridViewTextBoxColumn.HeaderText = "RequestModeName2"
        Me.RequestModeName2DataGridViewTextBoxColumn.Name = "RequestModeName2DataGridViewTextBoxColumn"
        '
        'ProcessDataGridViewTextBoxColumn
        '
        Me.ProcessDataGridViewTextBoxColumn.DataPropertyName = "Process"
        Me.ProcessDataGridViewTextBoxColumn.HeaderText = "Process"
        Me.ProcessDataGridViewTextBoxColumn.Name = "ProcessDataGridViewTextBoxColumn"
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateWIPDataGridViewTextBoxColumn
        '
        Me.DateWIPDataGridViewTextBoxColumn.DataPropertyName = "DateWIP"
        Me.DateWIPDataGridViewTextBoxColumn.HeaderText = "DateWIP"
        Me.DateWIPDataGridViewTextBoxColumn.Name = "DateWIPDataGridViewTextBoxColumn"
        '
        'DBWBINSQueryBindingSource
        '
        Me.DBWBINSQueryBindingSource.DataMember = "DBWBINS_Query"
        Me.DBWBINSQueryBindingSource.DataSource = Me.DBxDataSet
        '
        'DBWBINS_QueryTableAdapter
        '
        Me.DBWBINS_QueryTableAdapter.ClearBeforeFill = True
        '
        'DBWBINS_Query_DataTableAdapter
        '
        Me.DBWBINS_Query_DataTableAdapter.ClearBeforeFill = True
        '
        'BackgroundWorker1
        '
        '
        'btQuery
        '
        Me.btQuery.Location = New System.Drawing.Point(508, 44)
        Me.btQuery.Name = "btQuery"
        Me.btQuery.Size = New System.Drawing.Size(75, 23)
        Me.btQuery.TabIndex = 15
        Me.btQuery.Text = "Query"
        Me.btQuery.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'lbLoad
        '
        Me.lbLoad.AutoSize = True
        Me.lbLoad.Location = New System.Drawing.Point(24, 661)
        Me.lbLoad.Name = "lbLoad"
        Me.lbLoad.Size = New System.Drawing.Size(21, 13)
        Me.lbLoad.TabIndex = 16
        Me.lbLoad.Text = "0%"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(23, 635)
        Me.ProgressBar1.Maximum = 100000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1095, 23)
        Me.ProgressBar1.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(245, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "To"
        '
        'NumberDataGridViewTextBoxColumn
        '
        Me.NumberDataGridViewTextBoxColumn.DataPropertyName = "Number"
        Me.NumberDataGridViewTextBoxColumn.HeaderText = "Number"
        Me.NumberDataGridViewTextBoxColumn.Name = "NumberDataGridViewTextBoxColumn"
        Me.NumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.NumberDataGridViewTextBoxColumn.Visible = False
        '
        'PackageDataGridViewTextBoxColumn1
        '
        Me.PackageDataGridViewTextBoxColumn1.DataPropertyName = "Package"
        Me.PackageDataGridViewTextBoxColumn1.HeaderText = "Package"
        Me.PackageDataGridViewTextBoxColumn1.Name = "PackageDataGridViewTextBoxColumn1"
        Me.PackageDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DeviceDataGridViewTextBoxColumn1
        '
        Me.DeviceDataGridViewTextBoxColumn1.DataPropertyName = "Device"
        Me.DeviceDataGridViewTextBoxColumn1.HeaderText = "Device"
        Me.DeviceDataGridViewTextBoxColumn1.Name = "DeviceDataGridViewTextBoxColumn1"
        Me.DeviceDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'LotNoDataGridViewTextBoxColumn1
        '
        Me.LotNoDataGridViewTextBoxColumn1.DataPropertyName = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn1.HeaderText = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn1.Name = "LotNoDataGridViewTextBoxColumn1"
        Me.LotNoDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'RequestMode1
        '
        Me.RequestMode1.DataPropertyName = "RequestMode1"
        Me.RequestMode1.HeaderText = "RequestMode1"
        Me.RequestMode1.Name = "RequestMode1"
        Me.RequestMode1.ReadOnly = True
        '
        'DateWIPDataGridViewTextBoxColumn1
        '
        Me.DateWIPDataGridViewTextBoxColumn1.DataPropertyName = "DateWIP"
        Me.DateWIPDataGridViewTextBoxColumn1.HeaderText = "DateWIP"
        Me.DateWIPDataGridViewTextBoxColumn1.Name = "DateWIPDataGridViewTextBoxColumn1"
        Me.DateWIPDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'Day
        '
        Me.Day.DataPropertyName = "Day"
        Me.Day.HeaderText = "Day"
        Me.Day.Name = "Day"
        Me.Day.ReadOnly = True
        '
        'Night
        '
        Me.Night.DataPropertyName = "Night"
        Me.Night.HeaderText = "Night"
        Me.Night.Name = "Night"
        Me.Night.ReadOnly = True
        '
        'ReqDateDataGridViewTextBoxColumn1
        '
        Me.ReqDateDataGridViewTextBoxColumn1.DataPropertyName = "ReqDate"
        Me.ReqDateDataGridViewTextBoxColumn1.HeaderText = "ReqDate"
        Me.ReqDateDataGridViewTextBoxColumn1.Name = "ReqDateDataGridViewTextBoxColumn1"
        Me.ReqDateDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DayDataGridViewTextBoxColumn
        '
        Me.DayDataGridViewTextBoxColumn.DataPropertyName = "Day"
        Me.DayDataGridViewTextBoxColumn.HeaderText = "Day"
        Me.DayDataGridViewTextBoxColumn.Name = "DayDataGridViewTextBoxColumn"
        Me.DayDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NightDataGridViewTextBoxColumn
        '
        Me.NightDataGridViewTextBoxColumn.DataPropertyName = "Night"
        Me.NightDataGridViewTextBoxColumn.HeaderText = "Night"
        Me.NightDataGridViewTextBoxColumn.Name = "NightDataGridViewTextBoxColumn"
        Me.NightDataGridViewTextBoxColumn.ReadOnly = True
        '
        'StartTimeDataGridViewTextBoxColumn1
        '
        Me.StartTimeDataGridViewTextBoxColumn1.DataPropertyName = "StartTime"
        Me.StartTimeDataGridViewTextBoxColumn1.HeaderText = "StartTime"
        Me.StartTimeDataGridViewTextBoxColumn1.Name = "StartTimeDataGridViewTextBoxColumn1"
        Me.StartTimeDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'EndTimeDataGridViewTextBoxColumn1
        '
        Me.EndTimeDataGridViewTextBoxColumn1.DataPropertyName = "EndTime"
        Me.EndTimeDataGridViewTextBoxColumn1.HeaderText = "EndTime"
        Me.EndTimeDataGridViewTextBoxColumn1.Name = "EndTimeDataGridViewTextBoxColumn1"
        Me.EndTimeDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'RequestModeName1DataGridViewTextBoxColumn1
        '
        Me.RequestModeName1DataGridViewTextBoxColumn1.DataPropertyName = "RequestModeName1"
        Me.RequestModeName1DataGridViewTextBoxColumn1.HeaderText = "RequestModeName1"
        Me.RequestModeName1DataGridViewTextBoxColumn1.Name = "RequestModeName1DataGridViewTextBoxColumn1"
        Me.RequestModeName1DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'RequestModeName2DataGridViewTextBoxColumn1
        '
        Me.RequestModeName2DataGridViewTextBoxColumn1.DataPropertyName = "RequestModeName2"
        Me.RequestModeName2DataGridViewTextBoxColumn1.HeaderText = "RequestModeName2"
        Me.RequestModeName2DataGridViewTextBoxColumn1.Name = "RequestModeName2DataGridViewTextBoxColumn1"
        Me.RequestModeName2DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'ProcessDataGridViewTextBoxColumn1
        '
        Me.ProcessDataGridViewTextBoxColumn1.DataPropertyName = "Process"
        Me.ProcessDataGridViewTextBoxColumn1.HeaderText = "Process"
        Me.ProcessDataGridViewTextBoxColumn1.Name = "ProcessDataGridViewTextBoxColumn1"
        Me.ProcessDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'StatusDataGridViewTextBoxColumn1
        '
        Me.StatusDataGridViewTextBoxColumn1.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn1.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn1.Name = "StatusDataGridViewTextBoxColumn1"
        Me.StatusDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'QueryWIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1186, 682)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lbLoad)
        Me.Controls.Add(Me.btQuery)
        Me.Controls.Add(Me.rbAll)
        Me.Controls.Add(Me.rbWB)
        Me.Controls.Add(Me.rbDB)
        Me.Controls.Add(Me.dgWipSumDay)
        Me.Controls.Add(Me.dgListwip)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.gvDaywip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "QueryWIP"
        Me.Text = "QueryWIP"
        CType(Me.dgWipSumDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QuerySumWIPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgListwip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBWBINSQueryDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDaywip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBWBINSQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rbAll As RadioButton
    Friend WithEvents rbWB As RadioButton
    Friend WithEvents rbDB As RadioButton
    Friend WithEvents dgWipSumDay As DataGridView
    Friend WithEvents dgListwip As DataGridView
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents gvDaywip As DataGridView
    Friend WithEvents DBxDataSet As DBxDataSet
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DayDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents NightDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents TotalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QuerySumWIPBindingSource As BindingSource
    Friend WithEvents DBWBINSQueryDataBindingSource As BindingSource
    Friend WithEvents DeviceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PackageDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReqDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EndTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RequestModeName1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RequestModeName2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProcessDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateWIPDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DBWBINSQueryBindingSource As BindingSource
    Friend WithEvents DBWBINS_QueryTableAdapter As DBxDataSetTableAdapters.DBWBINS_QueryTableAdapter
    Friend WithEvents DBWBINS_Query_DataTableAdapter As DBxDataSetTableAdapters.DBWBINS_Query_DataTableAdapter
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btQuery As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lbLoad As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents NumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PackageDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DeviceDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents LotNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents RequestMode1 As DataGridViewTextBoxColumn
    Friend WithEvents DateWIPDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Day As DataGridViewTextBoxColumn
    Friend WithEvents Night As DataGridViewTextBoxColumn
    Friend WithEvents ReqDateDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DayDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NightDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartTimeDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents EndTimeDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents RequestModeName1DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents RequestModeName2DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents ProcessDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
End Class
