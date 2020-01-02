Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class frmInicio

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
    
        If Len(Trim(txtUsr.Text & "")) = 0 Then

            MessageBox.Show("Falta especificar el Usuario.", "FALTA INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUsr.Focus()
            Exit Sub

        Else

            If Len(Trim(txtPwd.Text & "")) = 0 Then

                MessageBox.Show("Falta especificar el Password.", "FALTA INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPwd.Focus()
                Exit Sub
            Else
                Dim cnObj As New SqlConnection
                Dim strSql As String
                'Valido el usuario
                cnObj = conectar()

                If Not cnObj Is Nothing Then
                    strSql = "SELECT * FROM SIREPE_ACCESO WHERE USUARIO='" & txtUsr.Text & "' AND PASWORD='" & txtPwd.Text & "'"

                    Dim cmdUsr As New SqlCommand(strSql, cnObj)
                    Dim rdrUsr As SqlDataReader

                    Try
                        rdrUsr = cmdUsr.ExecuteReader()

                        If rdrUsr.Read() Then
                            'MsgBox(rdrUsr.Item("USUARIO"))
                            Me.Close()
                            FrmRegistroHuella.ShowDialog()
                            If (rdrUsr.Item("USUARIO")) <> "" Then

                                strUsrId = rdrUsr.Item("ID_ACCESO")
                                strUsrNombre = rdrUsr.Item("USUARIO")
                                'CambioPass = rdrUsr.Item("PASWORD")

                            Else

                                MessageBox.Show("El usuario o password son incorrectos.", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                cnObj.Close()
                                Exit Sub

                            End If

                        Else

                            txtUsr.Text = ""
                            txtPwd.Text = ""

                            txtUsr.Focus()

                            MessageBox.Show("El usuario o password son incorrectos.", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            cnObj.Close()
                            Exit Sub

                        End If

                        rdrUsr.Close()

                    Catch ex As System.Exception
                        cnObj.Close()
                        MessageBox.Show("Ocurrió el siguiente error: '" & ex.Message & "'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try

                    cnObj.Close()

                Else

                    Exit Sub

                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End If

    End Sub


  
    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class
