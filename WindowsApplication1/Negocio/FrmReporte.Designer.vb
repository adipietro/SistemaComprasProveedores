<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporte
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.RegistroCompraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New WindowsApplication1.DataSet1()
        Me.OrdenCompraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.RegistroCompraTableAdapter = New WindowsApplication1.DataSet1TableAdapters.RegistroCompraTableAdapter()
        Me.OrdenCompraTableAdapter = New WindowsApplication1.DataSet1TableAdapters.OrdenCompraTableAdapter()
        CType(Me.RegistroCompraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdenCompraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RegistroCompraBindingSource
        '
        Me.RegistroCompraBindingSource.DataMember = "RegistroCompra"
        Me.RegistroCompraBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OrdenCompraBindingSource
        '
        Me.OrdenCompraBindingSource.DataMember = "OrdenCompra"
        Me.OrdenCompraBindingSource.DataSource = Me.DataSet1
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.RegistroCompraBindingSource
        ReportDataSource2.Name = "DataSet2"
        ReportDataSource2.Value = Me.OrdenCompraBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "WindowsApplication1.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(479, 382)
        Me.ReportViewer1.TabIndex = 0
        '
        'RegistroCompraTableAdapter
        '
        Me.RegistroCompraTableAdapter.ClearBeforeFill = True
        '
        'OrdenCompraTableAdapter
        '
        Me.OrdenCompraTableAdapter.ClearBeforeFill = True
        '
        'FrmReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 406)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FrmReporte"
        Me.Text = "FrmReporte"
        CType(Me.RegistroCompraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdenCompraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RegistroCompraBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet1 As WindowsApplication1.DataSet1
    Friend WithEvents RegistroCompraTableAdapter As WindowsApplication1.DataSet1TableAdapters.RegistroCompraTableAdapter
    Friend WithEvents OrdenCompraBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrdenCompraTableAdapter As WindowsApplication1.DataSet1TableAdapters.OrdenCompraTableAdapter
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
