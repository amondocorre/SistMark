Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Math
Imports System.Net
Module Funciones
#Region "VARIABLES GLOBALES"
    Public intSucursal As Integer = 10
    Public strUsrId As String = ""
    Public strUsrNombre As String = ""
    Public strUsrEmail As String = ""
    Public strUsrTelefono As String = ""
    Public intArea As Integer = 0
    Public bCargandoPermisos As Boolean = False
    Public bPermiteAccesoOpciones As Boolean = False
    Public bMuestraVentanaOficinas As Boolean = False
    Public bAutentifica As Boolean = False
    Public strUsrAut As String = ""
    Public bAutorizado As Boolean = False
    Public CambioPass As Integer = 0

    Public dtJornada As New DataTable("jornada")
    Public dtEventos As New DataTable("Eventos")

    Public idSucursal As Integer = 0
    Public idMesPlanilla As Integer = 0
    Public nombreTurno As String = ""
    Public tipoTurno As String = ""
    Public asist2 As Integer = 0

#End Region

    Public Sub IpPublica()
        Dim valorIp As String
        Dim ipP As New WebClient
        Dim strSql As String
        Dim cnObj As New SqlConnection

        valorIp = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString()
        valorIp = ipP.DownloadString("http://checkip.dyndns.org/").Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", "").Replace("</body></html>", "") & vbCrLf
        'valorIp = LTrim(valorIp)
        valorIp = Replace(valorIp, vbCrLf, "")
        cnObj = conectar()
        strSql = "SELECT * FROM CENTRO_COSTO WHERE IP_PUBLICA='" & valorIp & "'"
        Dim cmdUsr As New SqlCommand(strSql, cnObj)
        Dim rdrUsr As SqlDataReader

        Try
            rdrUsr = cmdUsr.ExecuteReader()

            If rdrUsr.Read() Then
                If (rdrUsr.Item("DESCRIPCION")) <> "" Then
                    idSucursal = rdrUsr.Item("ID_CENTRO")

                Else
                    MessageBox.Show("El usuario o password son incorrectos.", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cnObj.Close()
                    Exit Sub
                End If
            Else
                MessageBox.Show("Sucursal no habilitada.", "Cierre esta ventana", MessageBoxButtons.OK, MessageBoxIcon.Information)
                idSucursal = 10
                cnObj.Close()

                Exit Sub

            End If

            rdrUsr.Close()

        Catch ex As System.Exception
            cnObj.Close()
            MessageBox.Show("Ocurrió el siguiente error: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Public Function getIdMesPlanilla(ByVal mes As Integer)
        Dim strSql As String
        Dim cnObj As New SqlConnection

        cnObj = conectar()
        strSql = "SELECT ID_MES_PLANILLA FROM SIREPE_MES_PLANILLA WHERE MES='" & mes & "'"
        Dim cmdUsr As New SqlCommand(strSql, cnObj)
        Dim rdrUsr As SqlDataReader

        Try
            rdrUsr = cmdUsr.ExecuteReader()

            If rdrUsr.Read() Then
                idMesPlanilla = rdrUsr.Item("ID_MES_PLANILLA")
                getIdMesPlanilla = idMesPlanilla
                Exit Function
            Else
                MessageBox.Show("mes no registrado.", "Cierre esta ventana", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cnObj.Close()
                End
            End If

            rdrUsr.Close()

        Catch ex As System.Exception
            cnObj.Close()
            MessageBox.Show("Ocurrió el siguiente error: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try

    End Function
    Public Function getRetraso(ByVal id As Integer, ByVal ingreso As String)
        'Dim strSql As String
        Dim cnObj As New SqlConnection
        Dim tTurno As String
        Dim horaI As String
        Dim hor0, min0 As Integer
        Dim hor1, min1, retraso As Integer
        Dim horas As Integer
        Dim read As SqlDataReader
        'cnObj = conectar()
        'strSql = "SELECT ST.TIPO_TURNO, ST.HORA_INGRESO FROM SIREPE_EMPLEADO SE, SIREPE_TURNO ST WHERE SE.ID_TURNO=ST.ID_TURNO AND SE.ID_EMPLEADO=" & id
        'Dim cmdUsr As New SqlCommand(strSql, cnObj)
        'Dim rdrUsr As SqlDataReader
        '''''''''''''''''''''''''''
        Dim cn As New SqlConnection(My.Settings.Setting)
        Dim cmd As New SqlCommand
        If turno = 0 Then
            tTurno = "Mañana"
        Else
            tTurno = "Tarde"
        End If

        cn.Open()
        cmd = New SqlCommand("getTurno", cn)
        cmd.Parameters.AddWithValue("@idEmpleado", id)
        cmd.Parameters.AddWithValue("@Turno", tTurno)
        cmd.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
        read = cmd.ExecuteReader
        ' read.Read()

        'If (read.Read()) Then
        '    hi = read.Item("HORA_INGRESO").ToString
        '    hs = read.Item("HORA_SALIDA").ToString
        '    id_asistencia = read.Item("ID_ASISTENCIA").ToString
        '    retrasoAnt = CInt(read.Item("RETRASO").ToString)
        'End If

        '''''''''''''''''''''''''''
        Try
            
            If read.Read() Then
                'tipoTurno = read.Item("TIPO_TURNO")
                horaI = (read.Item("HORA_INGRESO").ToString)
                hor1 = CInt(Mid(horaI, 1, 2))
                min1 = CInt(Mid(horaI, 4, 2))
                hor0 = CInt(Mid(ingreso, 1, 2))
                min0 = CInt(Mid(ingreso, 4, 2))
                horas = hor0 - hor1
                If (horas) >= 0 Then
                    retraso = ((hor0 - hor1) * 60) + (min0 - min1)
                    If retraso < 0 Then
                        getRetraso = 0
                        Exit Function
                    Else
                        getRetraso = retraso
                        Exit Function
                    End If

                Else
                    getRetraso = 0
                    Exit Function
                End If
            Else
                MessageBox.Show("mes no registrado.", "Cierre esta ventana", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cn.Close()
                End
            End If

            read.Close()

        Catch ex As System.Exception
            cn.Close()
            MessageBox.Show("Ocurrió el siguiente error: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Function
    Public Function getRetraso0(ByVal id As Integer, ByVal ingreso As String)
        Dim strSql As String
        Dim cnObj As New SqlConnection
        Dim tipoTurno As String
        Dim horaI As String
        Dim hor0, min0 As Integer
        Dim hor1, min1, retraso As Integer
        Dim horas As Integer
        cnObj = conectar()
        strSql = "SELECT ST.TIPO_TURNO, ST.HORA_INGRESO FROM SIREPE_EMPLEADO SE, SIREPE_TURNO ST WHERE SE.ID_TURNO=ST.ID_TURNO AND SE.ID_EMPLEADO=" & id
        Dim cmdUsr As New SqlCommand(strSql, cnObj)
        Dim rdrUsr As SqlDataReader

        Try
            rdrUsr = cmdUsr.ExecuteReader()

            If rdrUsr.Read() Then
                tipoTurno = rdrUsr.Item("TIPO_TURNO")
                horaI = (rdrUsr.Item("HORA_INGRESO").ToString)
                hor1 = CInt(Mid(horaI, 1, 2))
                min1 = CInt(Mid(horaI, 4, 2))
                hor0 = CInt(Mid(ingreso, 1, 2))
                min0 = CInt(Mid(ingreso, 4, 2))
                horas = hor0 - hor1
                If (horas) >= 0 Then
                    retraso = ((hor0 - hor1) * 60) + (min0 - min1)
                    If retraso < 0 Then
                        getRetraso0 = 0
                        Exit Function
                    Else
                        getRetraso0 = retraso
                        Exit Function
                    End If

                Else
                    getRetraso0 = 0
                    Exit Function
                End If
            Else
                MessageBox.Show("mes no registrado.", "Cierre esta ventana", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cnObj.Close()
                End
            End If

            rdrUsr.Close()

        Catch ex As System.Exception
            cnObj.Close()
            MessageBox.Show("Ocurrió el siguiente error: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Function

    Public Function getIdTurno(ByVal id As Integer)
        Dim strSql As String
        Dim cnObj As New SqlConnection

        cnObj = conectar()
        strSql = "SELECT SE.ID_TURNO, ST.NOMBRE_TURNO, ST.TIPO_TURNO FROM SIREPE_EMPLEADO SE, SIREPE_TURNO ST WHERE SE.ID_TURNO=ST.ID_TURNO AND ID_EMPLEADO=" & id
        Dim cmdUsr As New SqlCommand(strSql, cnObj)
        Dim rdrUsr As SqlDataReader

        Try
            rdrUsr = cmdUsr.ExecuteReader()

            If rdrUsr.Read() Then
                getIdTurno = rdrUsr.Item("ID_TURNO")
                nombreTurno = rdrUsr.Item("NOMBRE_TURNO")
                tipoTurno = rdrUsr.Item("TIPO_TURNO")
            Else
                MessageBox.Show("TUNO VACIO.", "Cierre esta ventana", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cnObj.Close()
                End
            End If

            rdrUsr.Close()

        Catch ex As System.Exception
            cnObj.Close()
            MessageBox.Show("Ocurrió el siguiente error: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Function

    Public Function getIdCargo(ByVal id As Integer)
        Dim strSql As String
        Dim cnObj As New SqlConnection

        cnObj = conectar()
        strSql = "SELECT ID_CARGO FROM SIREPE_EMPLEADO WHERE ID_EMPLEADO=" & id
        Dim cmdUsr As New SqlCommand(strSql, cnObj)
        Dim rdrUsr As SqlDataReader

        Try
            rdrUsr = cmdUsr.ExecuteReader()

            If rdrUsr.Read() Then
                getIdCargo = rdrUsr.Item("ID_CARGO")
            Else
                MessageBox.Show("TUNO VACIO.", "Cierre esta ventana", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cnObj.Close()
                End
            End If

            rdrUsr.Close()

        Catch ex As System.Exception
            cnObj.Close()
            MessageBox.Show("Ocurrió el siguiente error: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Function

End Module
