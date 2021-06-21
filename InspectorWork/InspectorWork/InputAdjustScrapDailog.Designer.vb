<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InputAdjustScrapDailog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelDetail = New System.Windows.Forms.Panel()
        Me.dgvInspDetail = New System.Windows.Forms.DataGridView()
        Me.InspectionItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Scrap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModeNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.M12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddScrap = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.RemoveScrap = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PanelFoot = New System.Windows.Forms.Panel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxFrameScrap = New System.Windows.Forms.TextBox()
        Me.ComboBoxMultiplier = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.PanelDetail.SuspendLayout()
        CType(Me.dgvInspDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelFoot.SuspendLayout()
        Me.PanelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PanelDetail)
        Me.Panel1.Controls.Add(Me.PanelFoot)
        Me.Panel1.Controls.Add(Me.PanelHeader)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 675)
        Me.Panel1.TabIndex = 0
        '
        'PanelDetail
        '
        Me.PanelDetail.Controls.Add(Me.dgvInspDetail)
        Me.PanelDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDetail.Location = New System.Drawing.Point(0, 77)
        Me.PanelDetail.Name = "PanelDetail"
        Me.PanelDetail.Size = New System.Drawing.Size(600, 509)
        Me.PanelDetail.TabIndex = 4
        '
        'dgvInspDetail
        '
        Me.dgvInspDetail.AllowUserToAddRows = False
        Me.dgvInspDetail.AllowUserToDeleteRows = False
        Me.dgvInspDetail.AllowUserToResizeColumns = False
        Me.dgvInspDetail.AllowUserToResizeRows = False
        Me.dgvInspDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInspDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvInspDetail.ColumnHeadersHeight = 50
        Me.dgvInspDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInspDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InspectionItem, Me.Scrap, Me.LotNo, Me.ModeNo, Me.M1, Me.M2, Me.M3, Me.M4, Me.M5, Me.M6, Me.M7, Me.M8, Me.M9, Me.M10, Me.M11, Me.M12, Me.TL, Me.AddScrap, Me.RemoveScrap})
        Me.dgvInspDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInspDetail.Location = New System.Drawing.Point(0, 0)
        Me.dgvInspDetail.Name = "dgvInspDetail"
        Me.dgvInspDetail.ReadOnly = True
        Me.dgvInspDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInspDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvInspDetail.RowHeadersVisible = False
        Me.dgvInspDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dgvInspDetail.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvInspDetail.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dgvInspDetail.RowTemplate.Height = 28
        Me.dgvInspDetail.Size = New System.Drawing.Size(600, 509)
        Me.dgvInspDetail.TabIndex = 32
        '
        'InspectionItem
        '
        Me.InspectionItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.InspectionItem.DataPropertyName = "INSPECTION ITEM"
        Me.InspectionItem.HeaderText = "Inspection Item"
        Me.InspectionItem.Name = "InspectionItem"
        Me.InspectionItem.ReadOnly = True
        '
        'Scrap
        '
        Me.Scrap.DataPropertyName = "Scrap"
        Me.Scrap.HeaderText = "Scrap"
        Me.Scrap.Name = "Scrap"
        Me.Scrap.ReadOnly = True
        '
        'LotNo
        '
        Me.LotNo.DataPropertyName = "LotNo"
        Me.LotNo.HeaderText = "LotNo"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        Me.LotNo.Visible = False
        '
        'ModeNo
        '
        Me.ModeNo.DataPropertyName = "ModeNo"
        Me.ModeNo.HeaderText = "ModeNo"
        Me.ModeNo.Name = "ModeNo"
        Me.ModeNo.ReadOnly = True
        Me.ModeNo.Visible = False
        '
        'M1
        '
        Me.M1.DataPropertyName = "1M"
        Me.M1.HeaderText = "M1"
        Me.M1.Name = "M1"
        Me.M1.ReadOnly = True
        Me.M1.Visible = False
        '
        'M2
        '
        Me.M2.DataPropertyName = "2M"
        Me.M2.HeaderText = "M2"
        Me.M2.Name = "M2"
        Me.M2.ReadOnly = True
        Me.M2.Visible = False
        '
        'M3
        '
        Me.M3.DataPropertyName = "3M"
        Me.M3.HeaderText = "M3"
        Me.M3.Name = "M3"
        Me.M3.ReadOnly = True
        Me.M3.Visible = False
        '
        'M4
        '
        Me.M4.DataPropertyName = "4M"
        Me.M4.HeaderText = "M4"
        Me.M4.Name = "M4"
        Me.M4.ReadOnly = True
        Me.M4.Visible = False
        '
        'M5
        '
        Me.M5.DataPropertyName = "5M"
        Me.M5.HeaderText = "M5"
        Me.M5.Name = "M5"
        Me.M5.ReadOnly = True
        Me.M5.Visible = False
        '
        'M6
        '
        Me.M6.DataPropertyName = "6M"
        Me.M6.HeaderText = "M6"
        Me.M6.Name = "M6"
        Me.M6.ReadOnly = True
        Me.M6.Visible = False
        '
        'M7
        '
        Me.M7.DataPropertyName = "7M"
        Me.M7.HeaderText = "M7"
        Me.M7.Name = "M7"
        Me.M7.ReadOnly = True
        Me.M7.Visible = False
        '
        'M8
        '
        Me.M8.DataPropertyName = "8M"
        Me.M8.HeaderText = "M8"
        Me.M8.Name = "M8"
        Me.M8.ReadOnly = True
        Me.M8.Visible = False
        '
        'M9
        '
        Me.M9.DataPropertyName = "9M"
        Me.M9.HeaderText = "M9"
        Me.M9.Name = "M9"
        Me.M9.ReadOnly = True
        Me.M9.Visible = False
        '
        'M10
        '
        Me.M10.DataPropertyName = "10M"
        Me.M10.HeaderText = "M10"
        Me.M10.Name = "M10"
        Me.M10.ReadOnly = True
        Me.M10.Visible = False
        '
        'M11
        '
        Me.M11.DataPropertyName = "11M"
        Me.M11.HeaderText = "M11"
        Me.M11.Name = "M11"
        Me.M11.ReadOnly = True
        Me.M11.Visible = False
        '
        'M12
        '
        Me.M12.DataPropertyName = "12M"
        Me.M12.HeaderText = "M12"
        Me.M12.Name = "M12"
        Me.M12.ReadOnly = True
        Me.M12.Visible = False
        '
        'TL
        '
        Me.TL.DataPropertyName = "TL"
        Me.TL.HeaderText = "TL"
        Me.TL.Name = "TL"
        Me.TL.ReadOnly = True
        Me.TL.Visible = False
        '
        'AddScrap
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.NullValue = "+"
        Me.AddScrap.DefaultCellStyle = DataGridViewCellStyle12
        Me.AddScrap.HeaderText = "AddScrap"
        Me.AddScrap.Name = "AddScrap"
        Me.AddScrap.ReadOnly = True
        Me.AddScrap.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AddScrap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.AddScrap.Text = ""
        '
        'RemoveScrap
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.NullValue = "-"
        Me.RemoveScrap.DefaultCellStyle = DataGridViewCellStyle13
        Me.RemoveScrap.HeaderText = "RemoveScrap"
        Me.RemoveScrap.Name = "RemoveScrap"
        Me.RemoveScrap.ReadOnly = True
        Me.RemoveScrap.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RemoveScrap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.RemoveScrap.Text = ""
        '
        'PanelFoot
        '
        Me.PanelFoot.Controls.Add(Me.ButtonCancel)
        Me.PanelFoot.Controls.Add(Me.ButtonOK)
        Me.PanelFoot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFoot.Location = New System.Drawing.Point(0, 586)
        Me.PanelFoot.Name = "PanelFoot"
        Me.PanelFoot.Size = New System.Drawing.Size(600, 89)
        Me.PanelFoot.TabIndex = 2
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(408, 6)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(180, 71)
        Me.ButtonCancel.TabIndex = 0
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(10, 6)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(180, 71)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "Save Record (End Inspection)"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'PanelHeader
        '
        Me.PanelHeader.Controls.Add(Me.ComboBoxMultiplier)
        Me.PanelHeader.Controls.Add(Me.Label3)
        Me.PanelHeader.Controls.Add(Me.Label2)
        Me.PanelHeader.Controls.Add(Me.Label1)
        Me.PanelHeader.Controls.Add(Me.TextBoxFrameScrap)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(600, 77)
        Me.PanelHeader.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(367, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 31)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Frame"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "FrameScrap :"
        '
        'TextBoxFrameScrap
        '
        Me.TextBoxFrameScrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFrameScrap.Location = New System.Drawing.Point(196, 17)
        Me.TextBoxFrameScrap.Name = "TextBoxFrameScrap"
        Me.TextBoxFrameScrap.Size = New System.Drawing.Size(165, 38)
        Me.TextBoxFrameScrap.TabIndex = 0
        '
        'ComboBoxMultiplier
        '
        Me.ComboBoxMultiplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMultiplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxMultiplier.FormattingEnabled = True
        Me.ComboBoxMultiplier.Items.AddRange(New Object() {"1", "10", "100", "1000"})
        Me.ComboBoxMultiplier.Location = New System.Drawing.Point(524, 20)
        Me.ComboBoxMultiplier.Name = "ComboBoxMultiplier"
        Me.ComboBoxMultiplier.Size = New System.Drawing.Size(64, 41)
        Me.ComboBoxMultiplier.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(494, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "x"
        '
        'InputAdjustScrapDailog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 675)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "InputAdjustScrapDailog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InputAdjustScrapDailog"
        Me.Panel1.ResumeLayout(False)
        Me.PanelDetail.ResumeLayout(False)
        CType(Me.dgvInspDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelFoot.ResumeLayout(False)
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelHeader As Panel
    Friend WithEvents PanelDetail As Panel
    Friend WithEvents dgvInspDetail As DataGridView
    Friend WithEvents InspectionItem As DataGridViewTextBoxColumn
    Friend WithEvents Scrap As DataGridViewTextBoxColumn
    Friend WithEvents LotNo As DataGridViewTextBoxColumn
    Friend WithEvents ModeNo As DataGridViewTextBoxColumn
    Friend WithEvents M1 As DataGridViewTextBoxColumn
    Friend WithEvents M2 As DataGridViewTextBoxColumn
    Friend WithEvents M3 As DataGridViewTextBoxColumn
    Friend WithEvents M4 As DataGridViewTextBoxColumn
    Friend WithEvents M5 As DataGridViewTextBoxColumn
    Friend WithEvents M6 As DataGridViewTextBoxColumn
    Friend WithEvents M7 As DataGridViewTextBoxColumn
    Friend WithEvents M8 As DataGridViewTextBoxColumn
    Friend WithEvents M9 As DataGridViewTextBoxColumn
    Friend WithEvents M10 As DataGridViewTextBoxColumn
    Friend WithEvents M11 As DataGridViewTextBoxColumn
    Friend WithEvents M12 As DataGridViewTextBoxColumn
    Friend WithEvents TL As DataGridViewTextBoxColumn
    Friend WithEvents AddScrap As DataGridViewButtonColumn
    Friend WithEvents RemoveScrap As DataGridViewButtonColumn
    Friend WithEvents PanelFoot As Panel
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxFrameScrap As TextBox
    Friend WithEvents ComboBoxMultiplier As ComboBox
    Friend WithEvents Label3 As Label
End Class
