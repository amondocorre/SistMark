<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLeerHuella
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grupoIII = New System.Windows.Forms.GroupBox()
        Me.vecesDedo = New System.Windows.Forms.Label()
        Me.ImagenHuellas = New System.Windows.Forms.PictureBox()
        Me.grupoIII.SuspendLayout()
        CType(Me.ImagenHuellas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grupoIII
        '
        Me.grupoIII.Controls.Add(Me.vecesDedo)
        Me.grupoIII.Controls.Add(Me.ImagenHuellas)
        Me.grupoIII.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grupoIII.Location = New System.Drawing.Point(3, 2)
        Me.grupoIII.Name = "grupoIII"
        Me.grupoIII.Size = New System.Drawing.Size(198, 206)
        Me.grupoIII.TabIndex = 27
        Me.grupoIII.TabStop = False
        Me.grupoIII.Text = "Por favor Coloque su dedo"
        '
        'vecesDedo
        '
        Me.vecesDedo.AutoSize = True
        Me.vecesDedo.Location = New System.Drawing.Point(12, 180)
        Me.vecesDedo.Name = "vecesDedo"
        Me.vecesDedo.Size = New System.Drawing.Size(121, 13)
        Me.vecesDedo.TabIndex = 12
        Me.vecesDedo.Text = "Necesitas pasar el dedo"
        '
        'ImagenHuellas
        '
        Me.ImagenHuellas.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ImagenHuellas.Location = New System.Drawing.Point(15, 19)
        Me.ImagenHuellas.Name = "ImagenHuellas"
        Me.ImagenHuellas.Size = New System.Drawing.Size(168, 158)
        Me.ImagenHuellas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImagenHuellas.TabIndex = 7
        Me.ImagenHuellas.TabStop = False
        '
        'FrmLeerHuella
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(213, 209)
        Me.Controls.Add(Me.grupoIII)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(280, 200)
        Me.Name = "FrmLeerHuella"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Leer Huella"
        Me.grupoIII.ResumeLayout(False)
        Me.grupoIII.PerformLayout()
        CType(Me.ImagenHuellas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grupoIII As System.Windows.Forms.GroupBox
    Friend WithEvents vecesDedo As System.Windows.Forms.Label
    Friend WithEvents ImagenHuellas As System.Windows.Forms.PictureBox
End Class
