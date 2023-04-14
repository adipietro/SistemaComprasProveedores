<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRealizarPedido
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
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtTotalDesc = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Producto = New System.Windows.Forms.Label()
        Me.txtProd = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.btnAgregarDetalle = New System.Windows.Forms.Button()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.clmProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.txtCantidadDesc = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalPedido = New System.Windows.Forms.TextBox()
        Me.btnTotalDetalle = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.cmbEmpleados = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbProv = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCargarProveedor = New System.Windows.Forms.Button()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardarOC = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnSugerir = New System.Windows.Forms.Button()
        Me.txtSugerencia = New System.Windows.Forms.TextBox()
        Me.cmbProd2 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(12, 171)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(491, 270)
        Me.DataGridView2.TabIndex = 27
        '
        'btnCalcular
        '
        Me.btnCalcular.BackColor = System.Drawing.Color.DimGray
        Me.btnCalcular.Enabled = False
        Me.btnCalcular.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCalcular.Location = New System.Drawing.Point(532, 282)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(100, 27)
        Me.btnCalcular.TabIndex = 29
        Me.btnCalcular.Text = "Calcular Total"
        Me.btnCalcular.UseVisualStyleBackColor = False
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Location = New System.Drawing.Point(311, 468)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtSubTotal.TabIndex = 30
        '
        'txtTotalDesc
        '
        Me.txtTotalDesc.Enabled = False
        Me.txtTotalDesc.Location = New System.Drawing.Point(311, 510)
        Me.txtTotalDesc.Name = "txtTotalDesc"
        Me.txtTotalDesc.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDesc.TabIndex = 31
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(311, 551)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 32
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(308, 452)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "SubTotal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(308, 493)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Total Descuento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(308, 534)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Total "
        '
        'Producto
        '
        Me.Producto.AutoSize = True
        Me.Producto.Location = New System.Drawing.Point(529, 174)
        Me.Producto.Name = "Producto"
        Me.Producto.Size = New System.Drawing.Size(50, 13)
        Me.Producto.TabIndex = 58
        Me.Producto.Text = "Producto"
        '
        'txtProd
        '
        Me.txtProd.Enabled = False
        Me.txtProd.Location = New System.Drawing.Point(532, 190)
        Me.txtProd.Name = "txtProd"
        Me.txtProd.Size = New System.Drawing.Size(100, 20)
        Me.txtProd.TabIndex = 57
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.White
        Me.txtCantidad.Location = New System.Drawing.Point(532, 236)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 59
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(529, 220)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(49, 13)
        Me.lbl.TabIndex = 60
        Me.lbl.Text = "Cantidad"
        '
        'btnAgregarDetalle
        '
        Me.btnAgregarDetalle.BackColor = System.Drawing.Color.DimGray
        Me.btnAgregarDetalle.Enabled = False
        Me.btnAgregarDetalle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAgregarDetalle.Location = New System.Drawing.Point(532, 315)
        Me.btnAgregarDetalle.Name = "btnAgregarDetalle"
        Me.btnAgregarDetalle.Size = New System.Drawing.Size(100, 27)
        Me.btnAgregarDetalle.TabIndex = 61
        Me.btnAgregarDetalle.Text = "Agregar a Detalle"
        Me.btnAgregarDetalle.UseVisualStyleBackColor = False
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmProducto, Me.clmCantidad, Me.clmPrecio, Me.clmDesc, Me.clmTotal})
        Me.DataGridView3.Location = New System.Drawing.Point(648, 167)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(516, 274)
        Me.DataGridView3.TabIndex = 62
        '
        'clmProducto
        '
        Me.clmProducto.HeaderText = "Producto"
        Me.clmProducto.Name = "clmProducto"
        Me.clmProducto.ReadOnly = True
        '
        'clmCantidad
        '
        Me.clmCantidad.HeaderText = "Cantidad"
        Me.clmCantidad.Name = "clmCantidad"
        Me.clmCantidad.ReadOnly = True
        '
        'clmPrecio
        '
        Me.clmPrecio.HeaderText = "Precio"
        Me.clmPrecio.Name = "clmPrecio"
        Me.clmPrecio.ReadOnly = True
        '
        'clmDesc
        '
        Me.clmDesc.HeaderText = "Descuento"
        Me.clmDesc.Name = "clmDesc"
        '
        'clmTotal
        '
        Me.clmTotal.HeaderText = "Total"
        Me.clmTotal.Name = "clmTotal"
        '
        'txtDescuento
        '
        Me.txtDescuento.Enabled = False
        Me.txtDescuento.Location = New System.Drawing.Point(244, 517)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuento.TabIndex = 63
        '
        'txtCantidadDesc
        '
        Me.txtCantidadDesc.Enabled = False
        Me.txtCantidadDesc.Location = New System.Drawing.Point(244, 492)
        Me.txtCantidadDesc.Name = "txtCantidadDesc"
        Me.txtCantidadDesc.Size = New System.Drawing.Size(50, 20)
        Me.txtCantidadDesc.TabIndex = 64
        '
        'txtPrecio
        '
        Me.txtPrecio.Enabled = False
        Me.txtPrecio.Location = New System.Drawing.Point(244, 466)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(50, 20)
        Me.txtPrecio.TabIndex = 65
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(179, 517)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Descuento"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(61, 495)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(177, 13)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Cantidad necesario para Descuento"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(201, 469)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Precio"
        '
        'txtTotalPedido
        '
        Me.txtTotalPedido.Location = New System.Drawing.Point(1006, 468)
        Me.txtTotalPedido.Name = "txtTotalPedido"
        Me.txtTotalPedido.Size = New System.Drawing.Size(85, 20)
        Me.txtTotalPedido.TabIndex = 69
        '
        'btnTotalDetalle
        '
        Me.btnTotalDetalle.BackColor = System.Drawing.Color.DimGray
        Me.btnTotalDetalle.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnTotalDetalle.Location = New System.Drawing.Point(900, 464)
        Me.btnTotalDetalle.Name = "btnTotalDetalle"
        Me.btnTotalDetalle.Size = New System.Drawing.Size(100, 27)
        Me.btnTotalDetalle.TabIndex = 70
        Me.btnTotalDetalle.Text = "Total Detalle"
        Me.btnTotalDetalle.UseVisualStyleBackColor = False
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.Color.DimGray
        Me.btnBorrar.Enabled = False
        Me.btnBorrar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBorrar.Location = New System.Drawing.Point(647, 447)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(100, 27)
        Me.btnBorrar.TabIndex = 71
        Me.btnBorrar.Text = "Borrar registro"
        Me.btnBorrar.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button5.Location = New System.Drawing.Point(1101, 553)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(67, 37)
        Me.Button5.TabIndex = 73
        Me.Button5.Text = "Salir"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(854, 473)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(753, 473)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Se genero OC N°:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.LinkLabel2)
        Me.TabPage3.Controls.Add(Me.cmbEmpleados)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.btnImprimir)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.cmbProv)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.btnCargarProveedor)
        Me.TabPage3.Controls.Add(Me.cmbArea)
        Me.TabPage3.Controls.Add(Me.DateTimePicker1)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1148, 127)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Orden de compra"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(214, 44)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel2.TabIndex = 66
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Proveedores"
        '
        'cmbEmpleados
        '
        Me.cmbEmpleados.FormattingEnabled = True
        Me.cmbEmpleados.Location = New System.Drawing.Point(770, 73)
        Me.cmbEmpleados.Name = "cmbEmpleados"
        Me.cmbEmpleados.Size = New System.Drawing.Size(121, 21)
        Me.cmbEmpleados.TabIndex = 39
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(924, 51)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(142, 32)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "Ver Ordenes de Compra"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(27, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(482, 14)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "(*) Se recomienda acceder a pantalla                        para conocer mas info" & _
    "rmación del proveedor"
        '
        'btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Location = New System.Drawing.Point(924, 17)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(142, 28)
        Me.btnImprimir.TabIndex = 37
        Me.btnImprimir.Text = "Imprimir OC"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(709, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Solicitante:"
        '
        'cmbProv
        '
        Me.cmbProv.FormattingEnabled = True
        Me.cmbProv.Location = New System.Drawing.Point(118, 19)
        Me.cmbProv.Name = "cmbProv"
        Me.cmbProv.Size = New System.Drawing.Size(121, 21)
        Me.cmbProv.TabIndex = 63
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(53, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Proveedor"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(736, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Area:"
        '
        'btnCargarProveedor
        '
        Me.btnCargarProveedor.BackColor = System.Drawing.Color.Transparent
        Me.btnCargarProveedor.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.flecha_hacia_abajo_en_un_circulo_318_55532
        Me.btnCargarProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCargarProveedor.Location = New System.Drawing.Point(153, 73)
        Me.btnCargarProveedor.Name = "btnCargarProveedor"
        Me.btnCargarProveedor.Size = New System.Drawing.Size(48, 48)
        Me.btnCargarProveedor.TabIndex = 64
        Me.btnCargarProveedor.UseVisualStyleBackColor = False
        '
        'cmbArea
        '
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(770, 42)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(121, 21)
        Me.cmbArea.TabIndex = 30
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(643, 14)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(248, 20)
        Me.DateTimePicker1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(600, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Fecha"
        '
        'btnGuardarOC
        '
        Me.btnGuardarOC.BackColor = System.Drawing.Color.DarkGray
        Me.btnGuardarOC.Location = New System.Drawing.Point(1006, 495)
        Me.btnGuardarOC.Name = "btnGuardarOC"
        Me.btnGuardarOC.Size = New System.Drawing.Size(85, 32)
        Me.btnGuardarOC.TabIndex = 67
        Me.btnGuardarOC.Text = "Guardar OC"
        Me.btnGuardarOC.UseVisualStyleBackColor = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.btnSugerir)
        Me.TabPage1.Controls.Add(Me.txtSugerencia)
        Me.TabPage1.Controls.Add(Me.cmbProd2)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1148, 127)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Sugerencia de Proveedores"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DimGray
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(1023, 7)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 47)
        Me.Button3.TabIndex = 73
        Me.Button3.Text = "Ver evaluaciones de Proveedores"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(583, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(434, 108)
        Me.DataGridView1.TabIndex = 56
        '
        'btnSugerir
        '
        Me.btnSugerir.BackColor = System.Drawing.Color.White
        Me.btnSugerir.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.Disp
        Me.btnSugerir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSugerir.Location = New System.Drawing.Point(192, 6)
        Me.btnSugerir.Name = "btnSugerir"
        Me.btnSugerir.Size = New System.Drawing.Size(48, 48)
        Me.btnSugerir.TabIndex = 55
        Me.btnSugerir.UseVisualStyleBackColor = False
        '
        'txtSugerencia
        '
        Me.txtSugerencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSugerencia.Location = New System.Drawing.Point(255, 6)
        Me.txtSugerencia.Multiline = True
        Me.txtSugerencia.Name = "txtSugerencia"
        Me.txtSugerencia.Size = New System.Drawing.Size(313, 74)
        Me.txtSugerencia.TabIndex = 54
        '
        'cmbProd2
        '
        Me.cmbProd2.FormattingEnabled = True
        Me.cmbProd2.Location = New System.Drawing.Point(67, 18)
        Me.cmbProd2.Name = "cmbProd2"
        Me.cmbProd2.Size = New System.Drawing.Size(121, 21)
        Me.cmbProd2.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Producto"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1156, 153)
        Me.TabControl1.TabIndex = 25
        '
        'frmRealizarPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1180, 602)
        Me.Controls.Add(Me.btnGuardarOC)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnTotalDetalle)
        Me.Controls.Add(Me.txtTotalPedido)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.txtCantidadDesc)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.btnAgregarDetalle)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Producto)
        Me.Controls.Add(Me.txtProd)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtTotalDesc)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Name = "frmRealizarPedido"
        Me.Text = "Realizar Pedido"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Producto As System.Windows.Forms.Label
    Friend WithEvents txtProd As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents btnAgregarDetalle As System.Windows.Forms.Button
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidadDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPedido As System.Windows.Forms.TextBox
    Friend WithEvents btnTotalDetalle As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents clmProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents cmbEmpleados As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbProv As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCargarProveedor As System.Windows.Forms.Button
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSugerir As System.Windows.Forms.Button
    Friend WithEvents txtSugerencia As System.Windows.Forms.TextBox
    Friend WithEvents cmbProd2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btnGuardarOC As System.Windows.Forms.Button
End Class
