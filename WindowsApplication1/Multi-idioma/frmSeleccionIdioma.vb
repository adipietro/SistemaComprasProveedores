Public Class frmSeleccionIdioma
    Implements iObservador
    Dim vTraductor As Traductor = Traductor.GetInstance
    Dim usuario As BLL.UsuarioBLL


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        vTraductor.IdiomaSeleccionado = ComboBox1.SelectedItem
    End Sub

    Public Sub ActualizarObservador(Optional pControl As Control = Nothing) Implements iObservador.ActualizarObservador
        For Each mControl As Control In pControl.Controls
            Try
                If Not TypeOf mControl Is MenuStrip Then
                    mControl.Text = vTraductor.IdiomaSeleccionado.Diccionario.Item(mControl.Tag)
                Else
                    For Each mItem As ToolStripMenuItem In CType(mControl, MenuStrip).Items
                        TraducirMenuItem(mItem)
                    Next
                End If
            Catch ex As Exception

            Finally
                If mControl.Controls.Count > 0 Then
                    ActualizarObservador(mControl)
                End If
            End Try
        Next
    End Sub



    Public Sub New(Optional pUsuario As BLL.UsuarioBLL = Nothing)
        InitializeComponent()
        Me.usuario = pUsuario

        For Each mControl As Control In Me.Controls
            Try
                mControl.Tag = mControl.Text
            Catch ex As Exception

            End Try
        Next
    End Sub


    Private Sub CargarIdiomas()
        For Each Idioma As BLL.idiomaBLL In BLL.idiomaBLL.Listaridiomas
            ComboBox1.Items.Add(Idioma)
        Next
    End Sub

    Private Sub frmSeleccionIdioma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarIdiomas()
        ComboBox1.SelectedItem = ComboBox1.Items(0)

        vTraductor.Registrar(Me)
        ActualizarObservador(Me)
    End Sub

    Public Sub TraducirMenuItem(pItem As ToolStripMenuItem)
        pItem.Text = vTraductor.IdiomaSeleccionado.Diccionario.Item(pItem.Tag.Texto)

        If pItem.HasDropDownItems Then
            For Each mItem As ToolStripMenuItem In pItem.DropDownItems
                TraducirMenuItem(mItem)
            Next
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        vTraductor.IdiomaSeleccionado = ComboBox1.SelectedItem
        MsgBox("Se seleccionó nuevo idioma")
    End Sub
End Class