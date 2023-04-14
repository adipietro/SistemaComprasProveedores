Public Class frmIdioma

    Implements iObservador
    Dim vTraductor As Traductor = Traductor.GetInstance
    Dim vIdiomaDinamico As New BLL.idiomaBLL
    Dim vIdioma As BE.IdiomaBE


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each mControl As Control In Me.Controls
            Try
                CargarTags(mControl)
            Catch ex As Exception

            End Try
        Next
    End Sub
    Public Sub CargarTags(pControl As Control)
        pControl.Tag = pControl.Text

        If pControl.Controls.Count > 0 Then
            For Each mControl As Control In pControl.Controls
                CargarTags(mControl)
            Next
        End If
    End Sub


    Private Sub Idiomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vTraductor.Registrar(Me)
        AgregarIdiomas()
        Me.ActualizarObservador(Me)

    End Sub

    Private Sub AgregarIdiomas()
        cmbIdioma.Items.Clear()

        For Each Idioma As BLL.idiomaBLL In vTraductor.GetIdiomas
            'Dim d As New Dictionary(Of String, String)
            'd.Add(Idioma.Nombre, Idioma.ID)
            cmbIdioma.Items.Add(Idioma)
        Next

        cmbIdioma.Items.Add(vTraductor.Traducir("Crear idioma"))
    End Sub


    Private Sub Actualizar(pIdioma As BLL.idiomaBLL)
        Dim vLista As New List(Of Diccionario)
        For Each Item In pIdioma.Diccionario
            vLista.Add(New Diccionario(Item.Key, Item.Value))
        Next
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = vLista
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ActualizarObservador(DataGridView1)
    End Sub



    Public Sub ActualizarObservador(Optional pControl As Control = Nothing) Implements iObservador.ActualizarObservador
        For Each mControl As Control In pControl.Controls
            Try
                mControl.Text = vTraductor.IdiomaSeleccionado.Diccionario.Item(mControl.Tag)
            Catch ex As Exception

            Finally
                If mControl.Controls.Count > 0 Then
                    ActualizarObservador(mControl)
                End If
            End Try
        Next
    End Sub



    Private Function CrearDiccionario() As Dictionary(Of String, String)
        Dim vDiccionario As New Dictionary(Of String, String)
        For i = 0 To DataGridView1.Rows.Count - 1
            vDiccionario.Add(DataGridView1.Rows(i).Cells(0).Value, DataGridView1.Rows(i).Cells(1).Value)
        Next
        Return vDiccionario
    End Function
    Private Sub cmbIdioma_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIdioma.SelectedIndexChanged
        If cmbIdioma.SelectedItem.ToString().ToLower().Trim() = vTraductor.IdiomaSeleccionado.Diccionario.Item("Crear Idioma").ToLower().Trim Then
            Actualizar(vTraductor.IdiomaSeleccionado)
        Else
            Actualizar(cmbIdioma.SelectedItem)
        End If
    End Sub

    Private Sub Idiomas_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnGuardar.PerformClick()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            Dim traducir As BLL.idiomaBLL = cmbIdioma.SelectedItem

            For Each row As DataGridViewRow In DataGridView1.Rows
                traducir.Diccionario.Item(row.Cells(0).Value.Trim()) = row.Cells(1).Value.Trim()

            Next

            traducir.Guardar()

        Catch ex As Exception

        End Try
    End Sub



    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If cmbIdioma.SelectedItem.ToString().Trim.ToLower = vTraductor.IdiomaSeleccionado.Diccionario.Item("Crear Idioma").Trim().ToLower() Then
                Dim vNombreIdioma As String = InputBox("Ingrese el nombre del idioma")
                If vNombreIdioma.Length > 0 Then
                    Dim vidioma As New BLL.idiomaBLL
                    vidioma.Nombre = vNombreIdioma
                    vidioma.Diccionario = CrearDiccionario()
                    vidioma.Guardar()
                    AgregarIdiomas()
                    cmbIdioma.Text = vidioma.Nombre.Trim()

                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            txtPalabra.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            txtTraduccion.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTraduccion_Leave(sender As Object, e As EventArgs) Handles txtTraduccion.Leave
        DataGridView1.Rows(DataGridView1.SelectedCells.Item(0).RowIndex).Cells(1).Value = txtTraduccion.Text

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class