<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Patentes
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.IngresarPatenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresarGrupoDePatentesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IngresarPatenteToolStripMenuItem, Me.IngresarGrupoDePatentesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(290, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'IngresarPatenteToolStripMenuItem
        '
        Me.IngresarPatenteToolStripMenuItem.Name = "IngresarPatenteToolStripMenuItem"
        Me.IngresarPatenteToolStripMenuItem.Size = New System.Drawing.Size(104, 20)
        Me.IngresarPatenteToolStripMenuItem.Text = "Ingresar Patente"
        '
        'IngresarGrupoDePatentesToolStripMenuItem
        '
        Me.IngresarGrupoDePatentesToolStripMenuItem.Name = "IngresarGrupoDePatentesToolStripMenuItem"
        Me.IngresarGrupoDePatentesToolStripMenuItem.Size = New System.Drawing.Size(161, 20)
        Me.IngresarGrupoDePatentesToolStripMenuItem.Text = "Ingresar Grupo de Patentes"
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Location = New System.Drawing.Point(38, 27)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(221, 187)
        Me.TreeView1.TabIndex = 1
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Black
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEliminar.Location = New System.Drawing.Point(161, 220)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(95, 29)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'Patentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.WindowsApplication1.My.MySettings.Default.ColorLogin
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.Diseño_sin_título
        Me.ClientSize = New System.Drawing.Size(290, 261)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Patentes"
        Me.Text = "Patentes"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents IngresarPatenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresarGrupoDePatentesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
End Class
