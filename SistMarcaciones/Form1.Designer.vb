<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ControlAsistenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDePersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.cmbSalir = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSalidaI = New System.Windows.Forms.Button()
        Me.cmdIngresoI = New System.Windows.Forms.Button()
        Me.cmdSalida = New System.Windows.Forms.Button()
        Me.cmdIngreso = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(133, 26)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(132, 22)
        Me.ToolStripMenuItem2.Text = "Empleados"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ControlAsistenciaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(496, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ControlAsistenciaToolStripMenuItem
        '
        Me.ControlAsistenciaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistroDePersonalToolStripMenuItem})
        Me.ControlAsistenciaToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.ControlAsistenciaToolStripMenuItem.Name = "ControlAsistenciaToolStripMenuItem"
        Me.ControlAsistenciaToolStripMenuItem.Size = New System.Drawing.Size(115, 20)
        Me.ControlAsistenciaToolStripMenuItem.Text = "Control Asistencia"
        '
        'RegistroDePersonalToolStripMenuItem
        '
        Me.RegistroDePersonalToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RegistroDePersonalToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.RegistroDePersonalToolStripMenuItem.Name = "RegistroDePersonalToolStripMenuItem"
        Me.RegistroDePersonalToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.RegistroDePersonalToolStripMenuItem.Text = "Registro de Personal"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.MenuText
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(67, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(393, 33)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CONTROL DE ASISTENCIA"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblFecha.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblFecha.Location = New System.Drawing.Point(12, 491)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(151, 32)
        Me.lblFecha.TabIndex = 12
        Me.lblFecha.Text = "01/01/2000"
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblHora.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblHora.Font = New System.Drawing.Font("Arial Rounded MT Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHora.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblHora.Location = New System.Drawing.Point(12, 448)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(175, 43)
        Me.lblHora.TabIndex = 11
        Me.lblHora.Text = "00:00:00"
        '
        'cmbSalir
        '
        Me.cmbSalir.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmbSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmbSalir.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmbSalir.Location = New System.Drawing.Point(466, 0)
        Me.cmbSalir.Name = "cmbSalir"
        Me.cmbSalir.Size = New System.Drawing.Size(30, 27)
        Me.cmbSalir.TabIndex = 2
        Me.cmbSalir.Text = "X"
        Me.cmbSalir.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(430, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 27)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "_"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmdSalidaI
        '
        Me.cmdSalidaI.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdSalidaI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalidaI.Image = CType(resources.GetObject("cmdSalidaI.Image"), System.Drawing.Image)
        Me.cmdSalidaI.Location = New System.Drawing.Point(18, 367)
        Me.cmdSalidaI.Name = "cmdSalidaI"
        Me.cmdSalidaI.Size = New System.Drawing.Size(176, 60)
        Me.cmdSalidaI.TabIndex = 7
        Me.cmdSalidaI.Text = "SALIDA INT"
        Me.cmdSalidaI.UseVisualStyleBackColor = False
        '
        'cmdIngresoI
        '
        Me.cmdIngresoI.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdIngresoI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdIngresoI.Image = CType(resources.GetObject("cmdIngresoI.Image"), System.Drawing.Image)
        Me.cmdIngresoI.Location = New System.Drawing.Point(18, 301)
        Me.cmdIngresoI.Name = "cmdIngresoI"
        Me.cmdIngresoI.Size = New System.Drawing.Size(176, 60)
        Me.cmdIngresoI.TabIndex = 6
        Me.cmdIngresoI.Text = "INGRESO INT"
        Me.cmdIngresoI.UseVisualStyleBackColor = False
        '
        'cmdSalida
        '
        Me.cmdSalida.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdSalida.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalida.Image = CType(resources.GetObject("cmdSalida.Image"), System.Drawing.Image)
        Me.cmdSalida.Location = New System.Drawing.Point(20, 235)
        Me.cmdSalida.Name = "cmdSalida"
        Me.cmdSalida.Size = New System.Drawing.Size(176, 60)
        Me.cmdSalida.TabIndex = 5
        Me.cmdSalida.Text = "SALIDA"
        Me.cmdSalida.UseVisualStyleBackColor = False
        '
        'cmdIngreso
        '
        Me.cmdIngreso.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdIngreso.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdIngreso.Image = CType(resources.GetObject("cmdIngreso.Image"), System.Drawing.Image)
        Me.cmdIngreso.Location = New System.Drawing.Point(19, 169)
        Me.cmdIngreso.Name = "cmdIngreso"
        Me.cmdIngreso.Size = New System.Drawing.Size(176, 60)
        Me.cmdIngreso.TabIndex = 4
        Me.cmdIngreso.Text = "INGRESO"
        Me.cmdIngreso.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SistMarcaciones.My.Resources.Resources.huella1
        Me.PictureBox1.Location = New System.Drawing.Point(0, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(484, 515)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(496, 523)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblHora)
        Me.Controls.Add(Me.cmbSalir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdSalidaI)
        Me.Controls.Add(Me.cmdIngresoI)
        Me.Controls.Add(Me.cmdSalida)
        Me.Controls.Add(Me.cmdIngreso)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sistema de Marcaciones"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ControlAsistenciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroDePersonalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdIngreso As System.Windows.Forms.Button
    Friend WithEvents cmdSalida As System.Windows.Forms.Button
    Friend WithEvents cmdIngresoI As System.Windows.Forms.Button
    Friend WithEvents cmdSalidaI As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbSalir As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
