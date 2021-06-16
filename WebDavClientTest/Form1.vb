Public Class Form1
	Dim cloud As New OwnCloudWebDav.API
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

		RichTextBox1.Text &= "CONNECTING" & Environment.NewLine
		RichTextBox1.Text &= cloud.Connect(TextBox4.Text, TextBox3.Text) & Environment.NewLine
		RichTextBox1.Text &= "LISTING FILES" & Environment.NewLine
		RichTextBox1.Text &= cloud.EnumerateFiles(TextBox2.Text)
		RichTextBox1.Text &= "DOWNLOADING FILES" & Environment.NewLine
		RichTextBox1.Text &= cloud.GetFiles(TextBox1.Text, TextBox2.Text)
		RichTextBox1.Text &= "UPLOADING FILES" & Environment.NewLine
		RichTextBox1.Text &= cloud.PutFiles(TextBox1.Text, TextBox2.Text)
		RichTextBox1.Text &= "UPLOADING FILES" & Environment.NewLine
		RichTextBox1.Text &= cloud.OpenFile(TextBox1.Text, TextBox2.Text)
		RichTextBox1.Text &= cloud.GetUsers(TextBox4.Text, TextBox3.Text)
	End Sub
End Class
