<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEndLotAdjust
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ButtonScrap = New System.Windows.Forms.Button()
        Me.ButtonPass = New System.Windows.Forms.Button()
        Me.dgvInspDetail = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dgvInspDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonScrap
        '
        Me.ButtonScrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonScrap.Location = New System.Drawing.Point(34, 215)
        Me.ButtonScrap.Name = "ButtonScrap"
        Me.ButtonScrap.Size = New System.Drawing.Size(139, 81)
        Me.ButtonScrap.TabIndex = 0
        Me.ButtonScrap.Text = "Scrap"
        Me.ButtonScrap.UseVisualStyleBackColor = True
        '
        'ButtonPass
        '
        Me.ButtonPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPass.Location = New System.Drawing.Point(217, 215)
        Me.ButtonPass.Name = "ButtonPass"
        Me.ButtonPass.Size = New System.Drawing.Size(182, 81)
        Me.ButtonPass.TabIndex = 0
        Me.ButtonPass.Text = "Save Record (End Inspection)"
        Me.ButtonPass.UseVisualStyleBackColor = True
        '
        'dgvInspDetail
        '
        Me.dgvInspDetail.AllowUserToAddRows = False
        Me.dgvInspDetail.AllowUserToDeleteRows = False
        Me.dgvInspDetail.AllowUserToResizeColumns = False
        Me.dgvInspDetail.AllowUserToResizeRows = False
        Me.dgvInspDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInspDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInspDetail.ColumnHeadersHeight = 50
        Me.dgvInspDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInspDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.TL})
        Me.dgvInspDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInspDetail.Location = New System.Drawing.Point(0, 0)
        Me.dgvInspDetail.Name = "dgvInspDetail"
        Me.dgvInspDetail.ReadOnly = True
        Me.dgvInspDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInspDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInspDetail.RowHeadersVisible = False
        Me.dgvInspDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dgvInspDetail.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInspDetail.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dgvInspDetail.RowTemplate.Height = 28
        Me.dgvInspDetail.Size = New System.Drawing.Size(422, 209)
        Me.dgvInspDetail.TabIndex = 33
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "InspectionItem"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Inspection Item"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'TL
        '
        Me.TL.DataPropertyName = "TotalNg"
        Me.TL.HeaderText = "TotalNg"
        Me.TL.Name = "TL"
        Me.TL.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvInspDetail)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(422, 209)
        Me.Panel1.TabIndex = 34
        '
        'FormEndLotAdjust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 312)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonPass)
        Me.Controls.Add(Me.ButtonScrap)
        Me.Name = "FormEndLotAdjust"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormEndLotAdjust"
        CType(Me.dgvInspDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonScrap As Button
    Friend WithEvents ButtonPass As Button
    Friend WithEvents dgvInspDetail As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents TL As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
End Class
