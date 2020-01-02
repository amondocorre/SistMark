Imports System.Data.SqlClient

Public Class Huellas
    Dim cn As New SqlConnection(My.Settings.Setting)
    Dim cmd As New SqlCommand

    Public Function ValidarIngreso(ByVal fecha As Date, ByVal idEmpleado As Integer) As Boolean
        'cn = conectar()
        Dim read As SqlDataReader
        Dim hi, hs As String

        Try
            'fecha = Format(Now(), "yyyy-MM-dd") 'FormatDateTime(Now(), DateFormat.ShortDate)
            'idEmpleado = read("ID_EMPLEADO")
            cn.Open()
            cmd = New SqlCommand("VerificarIngreso", cn)
            cmd.Parameters.AddWithValue("@fecha", fecha)
            cmd.Parameters.AddWithValue("@idusuario", idEmpleado)
            cmd.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
            read = cmd.ExecuteReader
            ' read.Read()
            turno = 0
            If (read.Read()) Then
                hi = read.Item("HORA_INGRESO").ToString
                hs = read.Item("HORA_SALIDA").ToString
                id_asistencia = read.Item("ID_ASISTENCIA").ToString
                retrasoAnt = CInt(read.Item("RETRASO").ToString)
                If hi = "" And hs = "" Then
                    asist2 = 0
                    Return False
                Else
                    If hi <> "" Then
                        'If read.Read() Then

                        If hs <> "" Then
                            asist2 = 0
                            turno = 1  ' indica turno tarde
                            Return False
                        End If
                        Return True
                    Else
                        asist2 = 1
                        Return False
                    End If
                End If
            Else
                asist2 = 1
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try
    End Function


    Public Function ValidarSalida(ByVal fecha As Date, ByVal idEmpleado As Integer) As Boolean
        'cn = conectar()
        Dim read As SqlDataReader
        Dim hs, hit As String
        Try
            'fecha = Format(Now(), "yyyy-MM-dd") 'FormatDateTime(Now(), DateFormat.ShortDate)
            'idEmpleado = read("ID_EMPLEADO")
            cn.Open()
            cmd = New SqlCommand("VerificarSalida", cn)
            cmd.Parameters.AddWithValue("@fecha", fecha)
            cmd.Parameters.AddWithValue("@idusuario", idEmpleado)
            cmd.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
            read = cmd.ExecuteReader
            'read.Read()
            If (read.Read()) Then
                hs = read.Item("HORA_SALIDA").ToString
                hit = read.Item("HORA_INGRESO_T").ToString

                If hs <> "" And hit <> "" Then
                    turno = 1
                    Return False
                Else
                    If hs <> "" Then
                        Return True
                    Else
                        asist2 = 0
                        Return False

                    End If
                End If
            Else
                'MsgBox(" No tiene ingresos registrados", MsgBoxStyle.Critical)
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try
    End Function

    Public Function ValidarSalidaInterno(ByVal fecha As Date, ByVal idEmpleado As Integer) As Boolean
        'cn = conectar()
        Dim read As SqlDataReader
        Dim hi, hs As String

        Try
            'fecha = Format(Now(), "yyyy-MM-dd") 'FormatDateTime(Now(), DateFormat.ShortDate)
            'idEmpleado = read("ID_EMPLEADO")
            cn.Open()
            cmd = New SqlCommand("VerificarSalidaInterno", cn)
            cmd.Parameters.AddWithValue("@fecha", fecha)
            cmd.Parameters.AddWithValue("@idusuario", idEmpleado)
            cmd.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
            read = cmd.ExecuteReader
            ' read.Read()
            If (read.Read()) Then
                hi = read.Item("HORA_SALIDA_T").ToString
                If hi <> "" Then
                    'If read.Read() Then
                    hs = read.Item("HORA_INGRESO_T").ToString
                    If hs <> "" Then
                        asist2 = 0
                        Return False

                    End If
                    Return True
                Else
                    asist2 = 0
                    Return False
                End If
            Else
                asist2 = 0
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try
    End Function

    Public Function ValidarIngresoInterno(ByVal fecha As Date, ByVal idEmpleado As Integer) As Boolean
        'cn = conectar()
        Dim read As SqlDataReader
        Dim hs As String
        Try
           
            cn.Open()
            cmd = New SqlCommand("VerificarIngresoInterno", cn)
            cmd.Parameters.AddWithValue("@fecha", fecha)
            cmd.Parameters.AddWithValue("@idusuario", idEmpleado)
            cmd.CommandType = CommandType.StoredProcedure ' indica que es un procedimiento
            read = cmd.ExecuteReader
            read.Read()
            hs = read.Item("HORA_INGRESO_T").ToString
            If hs <> "" Then
                Return True
            Else
                asist2 = 0
                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try
    End Function

   


End Class
