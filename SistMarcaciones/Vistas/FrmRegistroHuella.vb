Imports DPFP
Imports DPFP.Capture
Imports System.Text
Imports System.Data.SqlClient

Public Class FrmRegistroHuella
    Private sql As String
    Private columna As String


    Private Sub cmbCI_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCI.KeyPress
        If Asc(e.KeyChar) = 13 Then
            LlenandoDatosUsuario()
        End If
    End Sub
    Private Sub cmbCI_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCI.SelectedIndexChanged
        LlenandoDatosUsuario()

    End Sub
    Sub LlenandoDatosUsuario()
        Abrir()
        'MsgBox(cmbCI.Text)
        sql = "SELECT * FROM SIREPE_EMPLEADO WHERE CI='" & cmbCI.Text & "'"
        columna = "NOMBRE"
        BuscarDato(txtNombre, sql, columna)
        columna = "AP_PATERNO"
        BuscarDato(txtApPaterno, sql, columna)
        columna = "AP_MATERNO"
        BuscarDato(txtApMaterno, sql, columna)
        columna = "FECHA_NACIMIENTO"
        BuscarDato(txtFechaN, sql, columna)
        columna = "FECHA_INGRESO"
        BuscarDato(txtFechaI, sql, columna)
        columna = "ID_EMPLEADO"
        BuscarDato(txtIdEmpleado, sql, columna)
        ' verificando que huellas se encuentran registradas
        sql = " SELECT DEDO FROM SIREPE_HUELLA WHERE ID_EMPLEADO=" & txtIdEmpleado.Text
        PintarDedo(sql, "DEDO")

    End Sub

    Private Sub cmbBuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmbBuscar.Click
        LlenandoDatosUsuario()
    End Sub


    Private Sub cmd1_Click(sender As System.Object, e As System.EventArgs) Handles cmd1.Click
        If (cmd1.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd1.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd1.Text
            tipoMarcacion = 3 ' indica que se tiene q insertar una huella a rer registrada
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub



    Private Sub FrmRegistroHuella_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Abrir()
        'Dim cii As String
        'cii = "13474526CB"
        'sql = "SELECT CI FROM SIREPE_EMPLEADO where ci='" & cii & "'"
        sql = "SELECT CI FROM SIREPE_EMPLEADO"
        columna = "CI"
        LlenarComboBox(cmbCI, sql, columna)

    End Sub



    Private Sub cmd2_Click(sender As System.Object, e As System.EventArgs) Handles cmd2.Click
        If (cmd2.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd2.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd2.Text
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub

    Private Sub cmd3_Click(sender As System.Object, e As System.EventArgs) Handles cmd3.Click
        If (cmd3.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd3.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd3.Text
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub

    Private Sub cmd4_Click(sender As System.Object, e As System.EventArgs) Handles cmd4.Click
        If (cmd4.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd4.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd4.Text
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub

    Private Sub cmd5_Click(sender As System.Object, e As System.EventArgs) Handles cmd5.Click
        If (cmd5.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd5.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd5.Text
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub


   
    Private Sub cmd6_Click(sender As System.Object, e As System.EventArgs) Handles cmd6.Click
        If (cmd6.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd6.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd6.Text
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub

    Private Sub cmd7_Click(sender As System.Object, e As System.EventArgs) Handles cmd7.Click
        If (cmd7.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd7.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd7.Text
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub

    Private Sub cmd8_Click(sender As System.Object, e As System.EventArgs) Handles cmd8.Click
        If (cmd8.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd8.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd8.Text
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub

    Private Sub cmd9_Click(sender As System.Object, e As System.EventArgs) Handles cmd9.Click
        If (cmd9.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd9.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd9.Text
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub

    Private Sub cmd10_Click(sender As System.Object, e As System.EventArgs) Handles cmd10.Click
        If (cmd10.BackColor = Color.GreenYellow) Then
            MsgBox("Huella registrada")
        Else
            cmd10.BackColor = Color.GreenYellow
            EnvioDatos.id = txtIdEmpleado.Text
            EnvioDatos.dedo = cmd10.Text
            FrmRegistrarHuella.ShowDialog()
        End If
    End Sub
End Class