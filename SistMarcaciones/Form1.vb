Imports System.Net
Imports System.Net.WebClient
Public Class Form1



    Private Sub cmdIngreso_Click(sender As System.Object, e As System.EventArgs) Handles cmdIngreso.Click
        tipoMarcacion = 1 ' indica que es ingreso a la sucursal
        FrmLeerHuella.ShowDialog()

    End Sub

  
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblFecha.Text = FormatDateTime(Now(), DateFormat.LongDate) 'DateValue(Now())


        Funciones.IpPublica()
    End Sub

    Private Sub cmdSalida_Click(sender As System.Object, e As System.EventArgs) Handles cmdSalida.Click
        tipoMarcacion = 2 ' indica que es SALIDA DE la sucursal
        FrmLeerHuella.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblHora.Text = TimeOfDay
    End Sub

    Private Sub cmbSalir_Click(sender As System.Object, e As System.EventArgs) Handles cmbSalir.Click
        End
    End Sub

    Private Sub RegistroDePersonalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RegistroDePersonalToolStripMenuItem.Click
        frmInicio.ShowDialog()
    End Sub

    Private Sub cmdIngresoI_Click(sender As System.Object, e As System.EventArgs) Handles cmdIngresoI.Click
        tipoMarcacion = 3 ' indica ingreso externo
        FrmLeerHuella.ShowDialog()
    End Sub

    Private Sub cmdSalidaI_Click(sender As System.Object, e As System.EventArgs) Handles cmdSalidaI.Click
        tipoMarcacion = 4 ' indica ingreso externo
        FrmLeerHuella.ShowDialog()
    End Sub

  
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class

