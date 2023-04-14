Imports System.Reflection
Imports BLL
Public Class DialogoPatentes
    Implements iObservador

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Asm As Assembly = Reflection.Assembly.GetExecutingAssembly()

        For Each t As Type In Asm.GetTypes()
            If t.IsSubclassOf(GetType(Form)) Then
                Me.cmbForm.Items.Add(t.FullName)
            End If

        Next
    End Sub

    Dim vTraductor As Traductor = Traductor.GetInstance


    Public Sub CargarTags(pControl As Control)
        pControl.Tag = pControl.Text

        If pControl.Controls.Count > 0 Then
            For Each mControl As Control In pControl.Controls
                CargarTags(mControl)
            Next
        End If
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

    '
    Public Function Nombre() As String
        Return Me.txtNombrePatente.Text
    End Function

    Public Function Formulario() As String
        Return Me.cmbForm.Text
    End Function
    
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim nombre_patente = txtNombrePatente.Text
        Dim formulario = cmbForm.SelectedItem
        Dim nombre_menu = txtMenu.Text
        PatenteBLL.altaDePatente(nombre_patente, formulario, nombre_menu)
        Me.Close()
    End Sub


    Private Sub DialogoPatentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vTraductor.Registrar(Me)
        ActualizarObservador(Me)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class