<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
	Inherits System.Windows.Forms.Form

	'Form reemplaza a Dispose para limpiar la lista de componentes.
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

	'Requerido por el Diseñador de Windows Forms
	Private components As System.ComponentModel.IContainer

	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar usando el Diseñador de Windows Forms.  
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.TextBox3 = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.TextBox4 = New System.Windows.Forms.TextBox()
		Me.SuspendLayout()
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(717, 9)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(60, 39)
		Me.Button1.TabIndex = 0
		Me.Button1.Text = "Button1"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(73, 33)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(138, 20)
		Me.TextBox1.TabIndex = 1
		Me.TextBox1.Text = "C:\toupload\PETICION_FIORI.xlsx"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 36)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(55, 13)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Ruta local"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(217, 36)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(92, 13)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Destino owncloud"
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(315, 33)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(138, 20)
		Me.TextBox2.TabIndex = 3
		Me.TextBox2.Text = "/"
		'
		'RichTextBox1
		'
		Me.RichTextBox1.Location = New System.Drawing.Point(12, 59)
		Me.RichTextBox1.Name = "RichTextBox1"
		Me.RichTextBox1.Size = New System.Drawing.Size(776, 379)
		Me.RichTextBox1.TabIndex = 5
		Me.RichTextBox1.Text = ""
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(279, 9)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(30, 13)
		Me.Label3.TabIndex = 9
		Me.Label3.Text = "Pass"
		'
		'TextBox3
		'
		Me.TextBox3.Location = New System.Drawing.Point(315, 6)
		Me.TextBox3.Name = "TextBox3"
		Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.TextBox3.Size = New System.Drawing.Size(138, 20)
		Me.TextBox3.TabIndex = 8
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(38, 9)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(29, 13)
		Me.Label4.TabIndex = 7
		Me.Label4.Text = "User"
		'
		'TextBox4
		'
		Me.TextBox4.Location = New System.Drawing.Point(73, 6)
		Me.TextBox4.Name = "TextBox4"
		Me.TextBox4.Size = New System.Drawing.Size(138, 20)
		Me.TextBox4.TabIndex = 6
		Me.TextBox4.Text = "d.mozota"
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.TextBox3)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.TextBox4)
		Me.Controls.Add(Me.RichTextBox1)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.TextBox2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.Button1)
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Button1 As Button
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents RichTextBox1 As RichTextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents TextBox3 As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents TextBox4 As TextBox
End Class
