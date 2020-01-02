Imports System.Data.Sql
Imports System.Data.SqlClient

Module Conexion
    Public conexion As SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader

    'modulo que permite conectar a la BD
    Public Function conectar() As SqlConnection
        Dim cn As New SqlConnection
        cn.ConnectionString = "Data Source=capresso.database.windows.net;Initial Catalog=BDCapresso;Persist Security Info=True;User ID=capresso;Password=Qwerty123"

        Try
            cn.Open()
            Return cn
        Catch ex As Exception
            MessageBox.Show(" No se pudo conectar a la BD " + ex.Message)
            End
            Return Nothing
            Exit Function

        End Try

    End Function
    Sub Abrir()
        Try
            conexion = New SqlConnection(My.Settings.Setting)
            conexion.Open()
            ' MsgBox("Conectado")
        Catch ex As Exception
            MsgBox(" Error de conexion con el servidor por favor intente nuevamente")
        End Try
    End Sub
    Sub BuscarDato(ByVal campo As TextBox, consulta As String, columna As String)
        Try
            enunciado = New SqlCommand(consulta, conexion)
            respuesta = enunciado.ExecuteReader
            'While respuesta.Read
            '    MsgBox(respuesta.Item(columna))
            'End While
            respuesta.Read()
            campo.Text = respuesta.Item(columna)
            respuesta.Close()
        Catch ex As Exception
            MsgBox("error de consulta buscarDato")
            'Finally
            '    If conexion.State = ConnectionState.Open Then
            '        conexion.Close()
            '    End If
        End Try
    End Sub
    Sub PintarDedo(consulta As String, columna As String)
        Try
            enunciado = New SqlCommand(consulta, conexion)
            respuesta = enunciado.ExecuteReader

            While respuesta.Read

                Select Case respuesta.Item(columna)
                    Case 1
                        FrmRegistroHuella.cmd1.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd1.Enabled = False
                    Case 2
                        FrmRegistroHuella.cmd2.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd2.Enabled = False
                    Case 3
                        FrmRegistroHuella.cmd3.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd3.Enabled = False
                    Case 4
                        FrmRegistroHuella.cmd4.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd4.Enabled = False
                    Case 5
                        FrmRegistroHuella.cmd5.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd5.Enabled = False
                    Case 6
                        FrmRegistroHuella.cmd6.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd6.Enabled = False
                    Case 7
                        FrmRegistroHuella.cmd7.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd7.Enabled = False
                    Case 8
                        FrmRegistroHuella.cmd8.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd8.Enabled = False
                    Case 9
                        FrmRegistroHuella.cmd9.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd9.Enabled = False
                    Case 10
                        FrmRegistroHuella.cmd10.BackColor = Color.GreenYellow
                        FrmRegistroHuella.cmd10.Enabled = False
                End Select

            End While
            respuesta.Read()
            'campo.Text = respuesta.Item(columna)
            respuesta.Close()
        Catch ex As Exception
            MsgBox("error de consulta buscarDato")
            'Finally
            '    If conexion.State = ConnectionState.Open Then
            '        conexion.Close()
            '    End If
        End Try
    End Sub

    Sub LlenarComboBox(ByVal cb As ComboBox, consulta As String, columna As String)
        Try
            enunciado = New SqlCommand(consulta, conexion)
            respuesta = enunciado.ExecuteReader

            While respuesta.Read
                cb.Items.Add(respuesta.Item(columna))
            End While
            respuesta.Close()
        Catch ex As Exception
            MsgBox("error de consulta")
            'Finally
            '    If conexion.State = ConnectionState.Open Then
            '        conexion.Close()
            '    End If
        End Try
    End Sub
End Module
