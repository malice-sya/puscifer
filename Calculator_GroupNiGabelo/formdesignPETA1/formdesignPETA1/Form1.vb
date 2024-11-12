Imports System.Drawing.Drawing2D

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetTextBoxStyle()
        SetButtonStyle()
        SetOperatorButtonStyle()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    End Sub

    ' -------------------------------------------------- '

    ' Functions ng buttons po ito '
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        TextBox1.Text = TextBox1.Text + "1"
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        TextBox1.Text = TextBox1.Text + "2"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        TextBox1.Text = TextBox1.Text + "3"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        TextBox1.Text = TextBox1.Text + "4"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        TextBox1.Text = TextBox1.Text + "5"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox1.Text = TextBox1.Text + "6"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Text = TextBox1.Text + "7"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text = TextBox1.Text + "8"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text = TextBox1.Text + "9"
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        TextBox1.Text = TextBox1.Text + "0"
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click ' Decimal
        TextBox1.Text = TextBox1.Text + "."
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click ' Add
        Label1.Text = TextBox1.Text
        Label2.Text = "+"
        TextBox1.Text = ""
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click ' Minus
        Label1.Text = TextBox1.Text
        Label2.Text = "-"
        TextBox1.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click ' Multiply
        Label1.Text = TextBox1.Text
        Label2.Text = "x"
        TextBox1.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click ' Divide
        Label1.Text = TextBox1.Text
        Label2.Text = "/"
        TextBox1.Text = ""
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click ' Clear Entry
        TextBox1.Text = ""
        Label2.Text = ""
        Label1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click ' Backspace
        If TextBox1.Text.Length > 0 Then
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1)
        End If
        Label2.Text = TextBox1.Text
    End Sub

    ' For root // limited na po sya for up to 5 decimal places
    Private Sub ButtonX_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input As Double
        If Double.TryParse(TextBox1.Text, input) Then
            TextBox1.Text = Math.Sqrt(input).ToString("F5")
        Else
            MessageBox.Show("Please enter a valid number.")
        End If
    End Sub

    ' For squaring numbers // limited to 5 decimal places (kung meron po sya)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim input As Double
        If Double.TryParse(TextBox1.Text, input) Then
            ' Calculate the square
            Dim result As Double = input * input

            ' Ito po yung extra code para po pag result is WHOLE NUMBER, hindi po sya mag aappear na may decimals po
            If result = Math.Floor(result) Then
                TextBox1.Text = result.ToString("0")
            Else
                TextBox1.Text = result.ToString("F5")
            End If
        Else
            MessageBox.Show("Please enter a valid number.")
        End If

    End Sub

    ' -------------------------------------------------- '

    ' For operators po ito '
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim result As Double

        ' For addition
        If Label2.Text = "+" Then
            result = Val(Label1.Text) + Val(TextBox1.Text)
            Label1.Text = ""
            Label2.Text = ""
            ' For subtraction
        ElseIf Label2.Text = "-" Then
            result = Val(Label1.Text) - Val(TextBox1.Text)
            Label1.Text = ""
            Label2.Text = ""
            ' For multiplication
        ElseIf Label2.Text = "x" Then
            result = Val(Label1.Text) * Val(TextBox1.Text)
            Label1.Text = ""
            Label2.Text = ""
            ' For division
        ElseIf Label2.Text = "/" Then
            If Val(TextBox1.Text) = 0 Then
                MessageBox.Show("Cannot divide by zero.")
                TextBox1.Text = ""
                Label1.Text = ""
                Label2.Text = ""
                Return
            End If
            result = Val(Label1.Text) / Val(TextBox1.Text)
            Label1.Text = ""
            Label2.Text = ""
            ' For squaring (x²)
        ElseIf Label2.Text = "x²" Then
            result = Val(Label1.Text) * Val(Label1.Text)
            Label1.Text = ""
            Label2.Text = ""
        End If
        If result = Math.Floor(result) Then
            TextBox1.Text = result.ToString("0") ' Kung whole number po yung result, di po sya mag lalagay ng decimals
        Else
            TextBox1.Text = result.ToString("F5") ' Opposite naman po :) // If decimalized yung result po nya
        End If

    End Sub

    ' -------------------------------------------------- '

    ' For design '
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim lightRed As Color = Color.FromArgb(168, 20, 42)
        Dim darkRed As Color = Color.FromArgb(128, 0, 0)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width, Me.ClientSize.Height)

        Using brush As New LinearGradientBrush(rect, lightRed, darkRed, 90.0F)
            g.FillRectangle(brush, rect)
        End Using
        MyBase.OnPaint(e)
    End Sub

    ' TextBox BG Color // Text Color '
    Private Sub SetTextBoxStyle()
        If TextBox1 IsNot Nothing Then
            TextBox1.BackColor = Color.FromArgb(255, 240, 240)
            TextBox1.ForeColor = Color.FromArgb(0, 0, 0)
            TextBox1.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    ' Misc Buttons '
    Private Sub SetButtonStyle()
        If Button1 IsNot Nothing Then
            Button1.BackColor = Color.FromArgb(255, 99, 71)
            Button1.ForeColor = Color.FromArgb(227, 220, 182)
            Button1.FlatStyle = FlatStyle.Flat
            Button1.FlatAppearance.BorderSize = 0
        End If

        If Button2 IsNot Nothing Then
            Button2.BackColor = Color.FromArgb(255, 99, 71)
            Button2.ForeColor = Color.FromArgb(227, 220, 182)
            Button2.FlatStyle = FlatStyle.Flat
            Button2.FlatAppearance.BorderSize = 0
        End If

        If Button3 IsNot Nothing Then
            Button3.BackColor = Color.FromArgb(255, 99, 71)
            Button3.ForeColor = Color.FromArgb(227, 220, 182)
            Button3.FlatStyle = FlatStyle.Flat
            Button3.FlatAppearance.BorderSize = 0
        End If

    End Sub

    ' Operator Button Colors '
    Private Sub SetOperatorButtonStyle()
        If Button13 IsNot Nothing Then
            Button13.BackColor = Color.FromArgb(178, 34, 34)
            Button13.ForeColor = Color.FromArgb(227, 220, 182)
            Button13.FlatStyle = FlatStyle.Flat
            Button13.FlatAppearance.BorderSize = 0
        End If
        If Button9 IsNot Nothing Then
            Button9.BackColor = Color.FromArgb(178, 34, 34)
            Button9.ForeColor = Color.FromArgb(227, 220, 182)
            Button9.FlatStyle = FlatStyle.Flat
            Button9.FlatAppearance.BorderSize = 0
        End If
        If Button4 IsNot Nothing Then
            Button4.BackColor = Color.FromArgb(178, 34, 34)
            Button4.ForeColor = Color.FromArgb(227, 220, 182)
            Button4.FlatStyle = FlatStyle.Flat
            Button4.FlatAppearance.BorderSize = 0
        End If
        If Button5 IsNot Nothing Then
            Button5.BackColor = Color.FromArgb(178, 34, 34)
            Button5.ForeColor = Color.FromArgb(227, 220, 182)
            Button5.FlatStyle = FlatStyle.Flat
            Button5.FlatAppearance.BorderSize = 0
        End If
    End Sub

    ' Button '
    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class

'_░▒███████
'░██▓▒░░▒▓██
'██▓▒░____░▒▓██___██████
'██▓▒░______░▓███▓____░▒▓██
'██▓▒░_____░▓██▓_______░▒▓██
'██▓▒░_________________░▒▓██
'_██▓▒░________________░▒▓██
'__██▓▒░______________░▒▓██
'___██▓▒░____________░▒▓██
'____██▓▒░__________░▒▓██
'_____██▓▒░_______░▒▓██
'______██▓▒░____░▒▓██
'_______█▓▒░░▒▓██
'_________░▒▓██
'_______░▒▓██
'_____░▒▓██
