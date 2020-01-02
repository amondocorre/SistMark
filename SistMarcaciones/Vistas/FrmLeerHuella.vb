Imports DPFP
Imports DPFP.Capture
'Imports DPFP.Template
'Imports System.Text
'Imports System.Data.SqlClient
'Imports System.IO

Public Class FrmLeerHuella

    Implements DPFP.Capture.EventHandler
    Private template As DPFP.Template
    Private Captura As DPFP.Capture.Capture
    Private verificador As DPFP.Verification.Verification

    Protected Overridable Sub Init()
        Try
            'Captura = New Capture()
            Captura = New Capture()
            If Not Captura Is Nothing Then
                Captura.EventHandler = Me
                verificador = New Verification.Verification()
                template = New Template()
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
                'MessageBox.Show("no se pudo iniciar la captura")

            End Try
        End If
    End Sub
    Protected Sub pararCaptura()
        If Not Captura Is Nothing Then
            Try
                Captura.StopCapture()
            Catch ex As Exception
                'MessageBox.Show("no se pudo detener la captura")
            End Try
        End If
    End Sub
    Private Sub ponerImagen(ByVal bmp)
        ImagenHuellas.Image = bmp

    End Sub
    Private Sub limpiarImagen()

        ImagenHuellas.Image.Dispose()
        ImagenHuellas.Image = Nothing

    End Sub
    Protected Function ConvertirSampleMapaBits(ByVal Sample As DPFP.Sample) As Bitmap
        Dim convertidor As New DPFP.Capture.SampleConversion() 'variable tipo conversor de un DPFP sample
        Dim mapaBits As Bitmap = Nothing
        convertidor.ConvertToPicture(Sample, mapaBits)
        Return mapaBits
    End Function


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


    Public Sub OnComplete(Capture As Object, ReaderSerialNumber As String, Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete

        ponerImagen(ConvertirSampleMapaBits(Sample))
        Dim caracteristicas As DPFP.FeatureSet = extraerCaracteristicas(Sample, DPFP.Processing.DataPurpose.Verification)

        Try
            If Not caracteristicas Is Nothing Then
                registroMarcacion(caracteristicas)
            End If
        Catch ex As Exception
            'MsgBox("Lo siento servidor desconectado")
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub OnFingerGone(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone
        If Not Captura Is Nothing Then
            Try
                Captura.StopCapture()
                limpiarImagen()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
                'Captura.StartCapture()

            Catch ex As Exception
                'MessageBox.Show("limpiando captura")
            End Try
        End If
    End Sub

    Public Sub OnFingerTouch(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
        'MsgBox("huella2")
    End Sub

    Public Sub OnReaderConnect(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
        'MsgBox("huella3")
    End Sub

    Public Sub OnReaderDisconnect(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
        'MsgBox("huella4")
    End Sub

    Public Sub OnSampleQuality(Capture As Object, ReaderSerialNumber As String, CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
        'MsgBox("huella5")
    End Sub




    Private Sub FrmRegistroHuella_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Init()
        iniciarCaptura()


    End Sub

End Class