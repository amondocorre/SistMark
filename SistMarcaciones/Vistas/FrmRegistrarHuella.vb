Imports DPFP
Imports DPFP.Capture
Imports DPFP.Template
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmRegistrarHuella


    Implements DPFP.Capture.EventHandler

    Private Captura As DPFP.Capture.Capture
    Private Enroller As DPFP.Processing.Enrollment
    Private Delegate Sub delegadoMuestra(ByVal text As String)
    Private Delegate Sub delegadoControles()
    Private template As DPFP.Template
    Private sql As String
    Private columna As String
    Private Sub mostrarVeces(ByVal texto As String)
        If vecesDedo.InvokeRequired Then
            Dim deleg As New delegadoMuestra(AddressOf mostrarVeces)
            Me.Invoke(deleg, New Object() {texto})
        Else
            vecesDedo.Text = texto
        End If
    End Sub
    Protected Overridable Sub Init()
        Try
            Captura = New Capture()
            If Not Captura Is Nothing Then
                Captura.EventHandler = Me
                Enroller = New DPFP.Processing.Enrollment()
                Dim text As New StringBuilder()
                text.AppendFormat("Necesitas pasar el dedo {0} veces", Enroller.FeaturesNeeded)
                vecesDedo.Text = text.ToString()

            Else
                MessageBox.Show("no se pudo instanciar la captura")
            End If
        Catch ex As Exception
            MessageBox.Show("no se pudo inicializar la captura")
        End Try
    End Sub
    Protected Sub iniciarCaptura()
        If Not Captura Is Nothing Then
            Try
                Captura.StartCapture()

            Catch ex As Exception
                MessageBox.Show("no se pudo iniciar la captura")
            End Try
        End If
    End Sub
    Protected Sub pararCaptura()
        If Not Captura Is Nothing Then
            Try
                Captura.StopCapture()
            Catch ex As Exception
                MessageBox.Show("no se pudo detenet la captura")

            End Try
        End If
    End Sub
    Private Sub modificarControles()
        'If btnGuardar.InvokeRequired Then
        '    Dim deleg As New delegadoControles(AddressOf modificarControles)
        '    Me.Invoke(deleg, New Object() {})
        'Else
        '    btnGuardar.Enabled = True
        '    txtNombre1.Enabled = True
        'End If
    End Sub

    Public Sub OnComplete(Capture As Object, ReaderSerialNumber As String, Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        ponerImagen(ConvertirSampleMapaBits(Sample))
        Prosesar(Sample)
    End Sub

    Public Sub OnFingerGone(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone

    End Sub

    Public Sub OnFingerTouch(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch

    End Sub

    Public Sub OnReaderConnect(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect

    End Sub

    Public Sub OnReaderDisconnect(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect

    End Sub

    Public Sub OnSampleQuality(Capture As Object, ReaderSerialNumber As String, CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality

    End Sub

    Private Sub FrmRegistroHuella_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Init()
        iniciarCaptura()

    End Sub

    Private Sub FrmRegistroHuella_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        pararCaptura()

    End Sub

    Protected Function ConvertirSampleMapaBits(ByVal Sample As DPFP.Sample) As Bitmap
        Dim convertidor As New DPFP.Capture.SampleConversion() 'variable tipo conversor de un DPFP sample
        Dim mapaBits As Bitmap = Nothing
        convertidor.ConvertToPicture(Sample, mapaBits)
        Return mapaBits
    End Function
    Private Sub ponerImagen(ByVal bmp)
        ImagenHuellas.Image = bmp

    End Sub
    'extrae las caracteristaicas de la huella verifar si es la huella q guardo
    Protected Function extraerCaracteristicas(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction()
        Dim alimentacion As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim caracteristicas As New DPFP.FeatureSet()
        extractor.CreateFeatureSet(Sample, Purpose, alimentacion, caracteristicas)
        If alimentacion = DPFP.Capture.CaptureFeedback.Good Then
            Return caracteristicas
        Else
            Return Nothing
        End If
    End Function

    Protected Sub Prosesar(ByVal Sample As DPFP.Sample)

        Dim caracteristicas As DPFP.FeatureSet = extraerCaracteristicas(Sample, DPFP.Processing.DataPurpose.Enrollment)
        If Not caracteristicas Is Nothing Then
            Try
                Enroller.AddFeatures(caracteristicas)
            Finally
                Dim text As New StringBuilder()
                text.AppendFormat("necesitas pasar el dedo {0} veces", Enroller.FeaturesNeeded)
                mostrarVeces(text.ToString)

                If text.ToString = "necesitas pasar el dedo 0 veces" Then
                    GuardarHuella()

                End If
                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready
                        template = Enroller.Template
                        pararCaptura()
                        modificarControles()
                    Case DPFP.Processing.Enrollment.Status.Failed
                        Enroller.Clear()
                        pararCaptura()
                        iniciarCaptura()
                End Select
            End Try
        End If

    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub
    Private Sub GuardarHuella()

    End Sub

    Private Sub btnGuardar_Click_1(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        'MsgBox(" guardando huella")
        Dim sqlCon As New SqlConnection(My.Settings.Setting)
        sqlCon.Open()
        Dim cmd As New SqlCommand()
        cmd = sqlCon.CreateCommand

        Try
            cmd.CommandText = "INSERT INTO SIREPE_HUELLA (ID_EMPLEADO,DEDO,HUELLA) values(@ID_EMPLEADO,@DEDO,@HUELLA)"
            cmd.Parameters.AddWithValue("@ID_EMPLEADO", EnvioDatos.id.ToString)
            cmd.Parameters.AddWithValue("@DEDO", EnvioDatos.dedo.ToString)
            Using fm As New MemoryStream(template.Bytes)
                cmd.Parameters.AddWithValue("@HUELLA", fm.ToArray())
            End Using
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            sqlCon.Close()
            sqlCon.Dispose()
        Catch ex As Exception
            MsgBox("error al registrar la huella por favor revise el lector")
        End Try
        MsgBox("Huella registrada exitosamente", MsgBoxStyle.Information)
        Me.Close()
    End Sub
End Class