Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class Form1
    Public comand As New MySqlConnection
    Public selection As MySqlCommand = New MySqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = " " Or TextBox2.Text = " ") Then
            MsgBox("ERROR, Porfavor completar los dos campos", MsgBoxStyle.Critical, "ERROR")
        Else
            Dim comando = New MySqlCommand("SELECT * FROM Usuarios WHERE username='" + TextBox1.Text + "';", Conex)
            Dim resultado = comando.ExecuteReader
            resultado.Read()
            If (resultado.HasRows) Then
                resultado.Close()
                Dim com = New MySqlCommand("SELECT * FROM Usuarios WHERE username='" + TextBox1.Text + "'AND password='" + TextBox2.Text + "';", Conex)
                Dim resul = com.ExecuteReader
                resul.Read()
                If (resul.HasRows) Then
                    resul.Close()
                    MsgBox("Welcome " + TextBox1.Text, MsgBoxStyle.DefaultButton1, "Bienvenido")
                    Me.Hide()
                    Principal.Show()
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                Else
                    resul.Close()
                    MsgBox("ERROR, Contraseña Incorrecta", MsgBoxStyle.Critical, "ERROR")
                End If

            Else
                MsgBox("ERROR, Usuario No existe", MsgBoxStyle.Critical, "ERROR")
            End If
        End If

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Registrar.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Conectar()

    End Sub



End Class
