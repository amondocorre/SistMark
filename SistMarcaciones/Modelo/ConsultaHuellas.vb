Imports DPFP
Imports DPFP.Capture
Imports DPFP.Template
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO

Module ConsultaHuellas
    Public template As New DPFP.Template
    Dim verificador As New DPFP.Verification.Verification
    'Public tipoMarcacion As Integer

    Sub registroMarcacion(caracteristicas As DPFP.FeatureSet)
        Select Case tipoMarcacion
            Case 1
                registrarIngreso(caracteristicas)
            Case 2
                registrarSalida(caracteristicas)
            Case 3
                registrarIngresoInterno(caracteristicas)
            Case 4
                registrarSalidaInterno(caracteristicas)
        End Select

    End Sub
    Sub registrarIngreso(caracteristicas As DPFP.FeatureSet)
        Dim sqlCon, sqlCon1 As New SqlConnection
        Dim cmd, cmd1 As SqlCommand
        Dim read, read1 As SqlDataReader
        Dim result As New DPFP.Verification.Verification.Result()
        Dim fecha As Date
        Dim idEmpleado As Integer
        Dim nombre As String = ""
        Dim tipoAsistencia As Integer
        Dim mes As Integer
        Dim idMesP As Integer
        Dim horasExtra As Integer
        Dim retraso As Integer
        Dim idUbicacion As Integer
        Dim idTurno As Integer
        Dim editable As Integer
        Dim idCreador As Integer
        Dim fechacreacion As Date
        Dim idModificacion As Integer
        Dim idCargo As Integer
        Dim horaIngreso As String

        sqlCon = conectar()
        sqlCon1 = conectar()

        Try
            If Not sqlCon Is Nothing Then
                ' se llama al procedimiento para extaer todas las huellas de los usuarios
                cmd = New SqlCommand("LeerHuellas", sqlCon)
                cmd.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                read = cmd.ExecuteReader

                While (read.Read())
                    ' se extrae la huella y se comprara con la ingresada por el lector UAre
                    Dim memoria As New MemoryStream(CType(read("HUELLA"), Byte()))
                    template.DeSerialize(memoria.ToArray())
                    verificador.Verify(caracteristicas, template, result)

                    If result.Verified Then
                        fecha = Format(Now(), "yyyy-MM-dd") 'FormatDateTime(Now(), DateFormat.ShortDate)
                        idEmpleado = read("ID_EMPLEADO")
                        Dim huellas As New Huellas

                        If huellas.ValidarIngreso(fecha, idEmpleado) Then
                            MsgBox("Ingreso ya registrado", MsgBoxStyle.Information)
                            Exit While
                        Else
                            nombre = read("NOMBRE") & " " & read("AP_PATERNO") & " " & read("AP_MATERNO")
                            horaIngreso = Format(Now(), "HH:mm:ss")
                            tipoAsistencia = 1

                            mes = Month(fecha)
                            idMesP = Funciones.getIdMesPlanilla(mes)
                            horasExtra = 0
                            retraso = Funciones.getRetraso(idEmpleado, horaIngreso)
                            idUbicacion = idSucursal
                            idTurno = Funciones.getIdTurno(idEmpleado)
                            editable = 0
                            idCreador = idEmpleado
                            fechacreacion = fecha
                            idModificacion = idEmpleado
                            idCargo = Funciones.getIdCargo(idEmpleado)
                            ' editableSem = 1
                            read.Dispose()
                            cmd.Dispose()
                            sqlCon.Close()
                            sqlCon.Dispose()

                            If turno = 0 Then
                                cmd1 = New SqlCommand("RegistroMarcacionIngreso", sqlCon1)
                                cmd1.Parameters.AddWithValue("@ID_EMPLEADO", idEmpleado)
                                cmd1.Parameters.AddWithValue("@ID_TIPO_ASISTENCIA", tipoAsistencia)
                                cmd1.Parameters.AddWithValue("@ID_MES_PLANILLA", idMesPlanilla)
                                cmd1.Parameters.AddWithValue("@FECHA", fecha)
                                cmd1.Parameters.AddWithValue("@HORAS_EXTRAS", horasExtra)
                                cmd1.Parameters.AddWithValue("@RETRASO", retraso)
                                cmd1.Parameters.AddWithValue("@ID_UBICACION", idUbicacion)
                                cmd1.Parameters.AddWithValue("@ID_TURNO", idTurno)
                                cmd1.Parameters.AddWithValue("@EDITABLE", editable)
                                cmd1.Parameters.AddWithValue("@ID_CREADOR", idCreador)
                                cmd1.Parameters.AddWithValue("@FECHA_CREACION", fecha)
                                cmd1.Parameters.AddWithValue("@ID_CARGO", idCargo)
                                cmd1.Parameters.AddWithValue("@HORA_INGRESO", horaIngreso)
                                cmd1.Parameters.AddWithValue("@ASIST2", asist2)

                                cmd1.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                                read1 = cmd1.ExecuteReader
                                MsgBox(nombre & " MARCASTE A: " & horaIngreso, MsgBoxStyle.Information)
                                ' verificando el ingreso de la huella
                            Else
                                retraso = retraso + retrasoAnt
                                cmd1 = New SqlCommand("RegistroMarcacionIngresoTarde", sqlCon1)
                                cmd1.Parameters.AddWithValue("@ID_ASISTENCIA", id_asistencia)
                                cmd1.Parameters.AddWithValue("@RETRASO", retraso)
                                cmd1.Parameters.AddWithValue("@HORA_INGRESO", horaIngreso)
                                
                                cmd1.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                                read1 = cmd1.ExecuteReader
                                MsgBox(nombre & " MARCASTE A: " & horaIngreso, MsgBoxStyle.Information)

                            End If

                            read1.Dispose()
                            cmd1.Dispose()
                            sqlCon1.Close()
                            sqlCon1.Dispose()

                            Exit While
                            'End If

                        End If
                    End If
                End While

            End If

        Catch ex As System.Exception
            sqlCon1.Close()
            MessageBox.Show("Ocurrió el siguiente error:: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End Try

    End Sub

    Sub registrarSalida(caracteristicas As DPFP.FeatureSet)
        Dim sqlCon, sqlCon1 As New SqlConnection
        Dim cmd, cmd1 As SqlCommand
        Dim read, read1 As SqlDataReader
        Dim result As New DPFP.Verification.Verification.Result()
        Dim fecha As Date
        Dim idEmpleado As Integer
        Dim horaSalida As String

        sqlCon = conectar()
        sqlCon1 = conectar()

        Try
            If Not sqlCon Is Nothing Then
                ' se llama al procedimiento para extaer todas las huellas de los usuarios
                cmd = New SqlCommand("LeerHuellas", sqlCon)
                cmd.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                read = cmd.ExecuteReader

                While (read.Read())
                    ' se extrae la huella y se comprara con la ingresada por el lector UAre
                    Dim memoria As New MemoryStream(CType(read("HUELLA"), Byte()))
                    template.DeSerialize(memoria.ToArray())
                    verificador.Verify(caracteristicas, template, result)

                    If result.Verified Then
                        fecha = Format(Now(), "yyyy-MM-dd") 'FormatDateTime(Now(), DateFormat.ShortDate)
                        idEmpleado = read("ID_EMPLEADO")
                        Dim huellas As New Huellas

                        If huellas.ValidarSalida(fecha, idEmpleado) Then
                            MsgBox("Salida ya registrado", MsgBoxStyle.Information)
                            Exit While
                        Else

                            horaSalida = Format(Now(), "HH:mm:ss")
                            read.Dispose()
                            cmd.Dispose()
                            sqlCon.Close()
                            sqlCon.Dispose()
                            If turno = 0 Then
                                cmd1 = New SqlCommand("RegistroMarcacionSalida", sqlCon1)
                                cmd1.Parameters.AddWithValue("@ID_EMPLEADO", idEmpleado)
                                cmd1.Parameters.AddWithValue("@FECHA", fecha)
                                cmd1.Parameters.AddWithValue("@HORA_SALIDA", horaSalida)

                                cmd1.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                                read1 = cmd1.ExecuteReader
                                MsgBox("MARCACION DE SALIDA A: " & horaSalida, MsgBoxStyle.Information)
                            Else
                                cmd1 = New SqlCommand("RegistroMarcacionSalidaTarde", sqlCon1)
                                cmd1.Parameters.AddWithValue("@ID_EMPLEADO", idEmpleado)
                                cmd1.Parameters.AddWithValue("@FECHA", fecha)
                                cmd1.Parameters.AddWithValue("@HORA_SALIDA", horaSalida)

                                cmd1.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                                read1 = cmd1.ExecuteReader
                                MsgBox("MARCACION DE SALIDA A: " & horaSalida, MsgBoxStyle.Information)
                            End If

                            ' verificando el ingreso de la huella
                            read1.Dispose()
                            cmd1.Dispose()
                            sqlCon1.Close()
                            sqlCon1.Dispose()
                            Exit While
                        End If
                    End If
                End While

            End If
            turno = 0
        Catch ex As System.Exception
            sqlCon1.Close()
            MessageBox.Show("Ocurrió el siguiente error:: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End Try

    End Sub

    Sub registrarSalidaInterno(caracteristicas As DPFP.FeatureSet)
        Dim sqlCon, sqlCon1 As New SqlConnection
        Dim cmd, cmd1 As SqlCommand
        Dim read, read1 As SqlDataReader
        Dim result As New DPFP.Verification.Verification.Result()
        Dim fecha As Date
        Dim idEmpleado As Integer
        Dim nombre As String = ""
        Dim tipoAsistencia As Integer
        Dim mes As Integer
        Dim idMesP As Integer
        Dim horasExtra As Integer
        Dim retraso As Integer
        Dim idUbicacion As Integer
        Dim idTurno As Integer
        Dim editable As Integer
        Dim idCreador As Integer
        Dim fechacreacion As Date
        Dim idModificacion As Integer
        Dim idCargo As Integer
        Dim horaIngreso As String

        sqlCon = conectar()
        sqlCon1 = conectar()

        Try
            If Not sqlCon Is Nothing Then
                ' se llama al procedimiento para extaer todas las huellas de los usuarios
                cmd = New SqlCommand("LeerHuellas", sqlCon)
                cmd.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                read = cmd.ExecuteReader

                While (read.Read())
                    ' se extrae la huella y se comprara con la ingresada por el lector UAre
                    Dim memoria As New MemoryStream(CType(read("HUELLA"), Byte()))
                    template.DeSerialize(memoria.ToArray())
                    verificador.Verify(caracteristicas, template, result)

                    If result.Verified Then
                        fecha = Format(Now(), "yyyy-MM-dd") 'FormatDateTime(Now(), DateFormat.ShortDate)
                        idEmpleado = read("ID_EMPLEADO")
                        Dim huellas As New Huellas

                        If huellas.ValidarSalidaInterno(fecha, idEmpleado) Then
                            MsgBox("Ingreso ya registrado", MsgBoxStyle.Information)
                            Exit While
                        Else
                            nombre = read("NOMBRE") & " " & read("AP_PATERNO") & " " & read("AP_MATERNO")
                            horaIngreso = Format(Now(), "HH:mm:ss")
                            tipoAsistencia = 1

                            mes = Month(fecha)
                            idMesP = Funciones.getIdMesPlanilla(mes)
                            horasExtra = 0
                            retraso = 0 'Funciones.getRetraso(idEmpleado, horaIngreso)
                            idUbicacion = idSucursal
                            idTurno = Funciones.getIdTurno(idEmpleado)
                            editable = 0
                            idCreador = idEmpleado
                            fechacreacion = fecha
                            idModificacion = idEmpleado
                            idCargo = Funciones.getIdCargo(idEmpleado)
                            ' editableSem = 1
                            read.Dispose()
                            cmd.Dispose()
                            sqlCon.Close()
                            sqlCon.Dispose()

                            cmd1 = New SqlCommand("RegistroMarcacionSalidaInterno", sqlCon1)
                            cmd1.Parameters.AddWithValue("@ID_EMPLEADO", idEmpleado)
                            cmd1.Parameters.AddWithValue("@ID_TIPO_ASISTENCIA", tipoAsistencia)
                            cmd1.Parameters.AddWithValue("@ID_MES_PLANILLA", idMesPlanilla)
                            cmd1.Parameters.AddWithValue("@FECHA", fecha)
                            cmd1.Parameters.AddWithValue("@HORAS_EXTRAS", horasExtra)
                            cmd1.Parameters.AddWithValue("@RETRASO", retraso)
                            cmd1.Parameters.AddWithValue("@ID_UBICACION", idUbicacion)
                            cmd1.Parameters.AddWithValue("@ID_TURNO", idTurno)
                            cmd1.Parameters.AddWithValue("@EDITABLE", editable)
                            cmd1.Parameters.AddWithValue("@ID_CREADOR", idCreador)
                            cmd1.Parameters.AddWithValue("@FECHA_CREACION", fecha)
                            cmd1.Parameters.AddWithValue("@ID_CARGO", idCargo)
                            cmd1.Parameters.AddWithValue("@HORA_SALIDA_T", horaIngreso)
                            cmd1.Parameters.AddWithValue("@ASIST2", 0)

                            cmd1.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                            read1 = cmd1.ExecuteReader
                            MsgBox(nombre & " MARCASTE A: " & horaIngreso, MsgBoxStyle.Information)
                            ' verificando el ingreso de la huella
                            read1.Dispose()
                            cmd1.Dispose()
                            sqlCon1.Close()
                            sqlCon1.Dispose()
                            Exit While
                            'End If

                        End If
                    End If
                End While

            End If

        Catch ex As System.Exception
            sqlCon1.Close()
            MessageBox.Show("Ocurrió el siguiente error:: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End Try

    End Sub

    Sub registrarIngresoInterno(caracteristicas As DPFP.FeatureSet)
        Dim sqlCon, sqlCon1 As New SqlConnection
        Dim cmd, cmd1 As SqlCommand
        Dim read, read1 As SqlDataReader
        Dim result As New DPFP.Verification.Verification.Result()
        Dim fecha As Date
        Dim idEmpleado As Integer
        Dim horaSalida As String

        sqlCon = conectar()
        sqlCon1 = conectar()

        Try
            If Not sqlCon Is Nothing Then
                ' se llama al procedimiento para extaer todas las huellas de los usuarios
                cmd = New SqlCommand("LeerHuellas", sqlCon)
                cmd.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                read = cmd.ExecuteReader

                While (read.Read())
                    ' se extrae la huella y se comprara con la ingresada por el lector UAre
                    Dim memoria As New MemoryStream(CType(read("HUELLA"), Byte()))
                    template.DeSerialize(memoria.ToArray())
                    verificador.Verify(caracteristicas, template, result)

                    If result.Verified Then
                        fecha = Format(Now(), "yyyy-MM-dd") 'FormatDateTime(Now(), DateFormat.ShortDate)
                        idEmpleado = read("ID_EMPLEADO")
                        Dim huellas As New Huellas

                        If huellas.ValidarIngresoInterno(fecha, idEmpleado) Then
                            MsgBox("Ingreso ya registrado", MsgBoxStyle.Information)
                            Exit While
                        Else
                            horaSalida = Format(Now(), "HH:mm:ss")
                            read.Dispose()
                            cmd.Dispose()
                            sqlCon.Close()
                            sqlCon.Dispose()
                            cmd1 = New SqlCommand("RegistroMarcacionIngresoInterno", sqlCon1)
                            cmd1.Parameters.AddWithValue("@ID_EMPLEADO", idEmpleado)
                            cmd1.Parameters.AddWithValue("@FECHA", fecha)
                            cmd1.Parameters.AddWithValue("@HORA_INGRESO_T", horaSalida)

                            cmd1.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
                            read1 = cmd1.ExecuteReader
                            MsgBox("MARCACION DE INGRESO A: " & horaSalida, MsgBoxStyle.Information)
                            ' verificando el ingreso de la huella
                            read1.Dispose()
                            cmd1.Dispose()
                            sqlCon1.Close()
                            sqlCon1.Dispose()
                            Exit While
                        End If
                    End If
                End While

            End If

        Catch ex As System.Exception
            sqlCon1.Close()
            MessageBox.Show("Ocurrió el siguiente error:: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End Try

    End Sub

    Sub registrarHuella(caracteristicas As DPFP.FeatureSet)
        MsgBox("registrando huella")
    End Sub

End Module
