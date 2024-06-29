Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Registrar



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (TextBox1.Text = " " Or TextBox2.Text = " " Or TextBox3.Text = " " Or TextBox4.Text = " ") Then
            MsgBox("ERROR, Porfavor completar los  campos", MsgBoxStyle.Critical, "ERROR")
        Else

            If (TextBox2.Text = TextBox3.Text) Then

                Dim checkUserCommand As MySqlCommand = Conex.CreateCommand()
                checkUserCommand.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE username ='" + TextBox1.Text + "';"
                Dim existingUserCount As Integer = checkUserCommand.ExecuteScalar()
                If existingUserCount > 0 Then
                    MsgBox("ERROR, El nombre de usuario ya existe. Intente otro.", MsgBoxStyle.Critical, "ERROR")
                Else
                    Try
                        Dim comando = New MySqlCommand("INSERT INTO usuarios(username,password,fullname) VALUES ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "');", Conex)
                        Dim resultado = comando.ExecuteNonQuery
                        MsgBox("Registro Exitoso")
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                        TextBox3.Text = ""
                        TextBox4.Text = ""

                    Catch ex As Exception
                        MsgBox("ERROR: " + ex.Message)

                    End Try

                End If
            Else
                MsgBox("ERROR,PContraseña y confirmacion de contraseña no son iguales", MsgBoxStyle.Critical, "ERROR")
            End If

        End If
    End Sub

    Private Sub Registrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class