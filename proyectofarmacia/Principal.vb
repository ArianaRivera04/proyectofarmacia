Imports MySql.Data.MySqlClient

Public Class Principal

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Visible = False
        Panel1.Visible = False
        Panel2.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False
        DataGridView2.Visible = False
        Panel5.Visible = False

    End Sub

    Private Sub ListaDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeProductosToolStripMenuItem.Click
        DataGridView1.Visible = True
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        DataGridView2.Visible = False
        Panel5.Visible = False

        Try
            Dim adap = New MySqlDataAdapter("SELECT * FROM producto", Conex)
            Dim Tabla = New DataTable
            adap.Fill(Tabla)
            DataGridView1.DataSource = Tabla


        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message)

        End Try
    End Sub

    Private Sub ListasDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListasDeUsuariosToolStripMenuItem.Click
        DataGridView1.Visible = True
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        DataGridView2.Visible = False
        Panel5.Visible = False
        Try
            Dim adap = New MySqlDataAdapter("SELECT * FROM usuarios", Conex)
            Dim Tabla = New DataTable
            adap.Fill(Tabla)
            DataGridView1.DataSource = Tabla


        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = " " Or TextBox2.Text = " " Or TextBox3.Text = " " Or TextBox4.Text = " " Or TextBox5.Text = " ") Then
            MsgBox("ERROR, Porfavor completar los  campos", MsgBoxStyle.Critical, "ERROR")
        Else

            Dim checkUserCommand As MySqlCommand = Conex.CreateCommand()
            checkUserCommand.CommandText = "SELECT COUNT(*) FROM producto WHERE codigo ='" + TextBox5.Text + "';"
            Dim existingUserCount As Integer = checkUserCommand.ExecuteScalar()
            If existingUserCount > 0 Then
                MsgBox("ERROR, Elcodigo del producto ya existe. Intente otro.", MsgBoxStyle.Critical, "ERROR")
            Else Try
                    Dim comando = New MySqlCommand("INSERT INTO producto(Nombre,tipo,cantidad_stock,precio,codigo) VALUES ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "');", Conex)
                    Dim resultado = comando.ExecuteNonQuery
                    MsgBox("Registro Exitoso")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""
                Catch ex As Exception
                    MsgBox("ERROR: " + ex.Message)

                End Try


            End If
        End If
    End Sub

    Private Sub AgregarProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarProductosToolStripMenuItem.Click
        DataGridView1.Visible = False
        Panel1.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        DataGridView2.Visible = False
        Panel5.Visible = False

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Visible = True
        Panel1.Visible = False
        Panel3.Visible = False
        DataGridView1.Visible = False
        Panel4.Visible = False
        DataGridView2.Visible = False
        Panel5.Visible = False


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If (TextBox1.Text = " " Or TextBox2.Text = " " Or TextBox3.Text = " " Or TextBox4.Text = " ") Then
            MsgBox("ERROR, Por  Favor completar los  campos", MsgBoxStyle.Critical, "ERROR")
        Else

            If (TextBox2.Text = TextBox3.Text) Then

                Dim checkUserCommand As MySqlCommand = Conex.CreateCommand()
                checkUserCommand.CommandText = "SELECT * FROM Usuarios WHERE username ='" + TextBox9.Text + "';"
                Dim existusr As Integer = checkUserCommand.ExecuteScalar()
                If existusr > 0 Then
                    MsgBox("ERROR, El nombre de usuario ya existe. Intente otro.", MsgBoxStyle.Critical, "ERROR")
                Else Try
                        Dim comando = New MySqlCommand("INSERT INTO usuarios(username,password,fullname) VALUES ('" + TextBox9.Text + "','" + TextBox8.Text + "','" + TextBox6.Text + "');", Conex)
                        Dim resultado = comando.ExecuteNonQuery
                        MsgBox("Registro Exitoso")
                        TextBox9.Text = ""
                        TextBox8.Text = ""
                        TextBox7.Text = ""
                        TextBox6.Text = ""
                        TextBox5.Text = ""
                    Catch ex As Exception
                        MsgBox("ERROR: " + ex.Message)

                    End Try


                End If
            Else
                MsgBox("ERROR,Contraseña y confirmacion de contraseña no son iguales", MsgBoxStyle.Critical, "ERROR")
            End If

        End If
    End Sub

    Private Sub AgregarUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarUsuarioToolStripMenuItem.Click
        Panel2.Visible = False
        Panel1.Visible = False
        Panel3.Visible = True
        DataGridView1.Visible = False
        Panel4.Visible = False
        DataGridView2.Visible = False
        Panel5.Visible = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Visible = True
        Panel1.Visible = False
        Panel3.Visible = False
        DataGridView1.Visible = False
        Panel4.Visible = False
        DataGridView2.Visible = False
        Panel5.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (TextBox10.Text = "") Then
            MsgBox("error, esta vacio")
        Else
            Dim checkUserCommand As MySqlCommand = Conex.CreateCommand()
            checkUserCommand.CommandText = "SELECT * FROM producto WHERE codigo=" + TextBox10.Text + ";"
            Dim existingUserCount As Integer = checkUserCommand.ExecuteScalar()
            If existingUserCount > 0 Then
                Dim resultado = checkUserCommand.ExecuteReader
                resultado.Read()
                If (resultado.HasRows) Then
                    resultado.Close()
                    DataGridView2.Visible = True
                    Panel5.Visible = True
                    Try
                        Dim adap = New MySqlDataAdapter("SELECT Nombre,Tipo,Producto_id,cantidad_stock,precio,codigo  FROM producto WHERE  codigo= " + TextBox10.Text + ";", Conex)
                        Dim Tabla = New DataTable
                        adap.Fill(Tabla)
                        DataGridView2.DataSource = Tabla

                    Catch ex As Exception
                        MsgBox("ERROR: " + ex.Message)

                    End Try
                Else
                End If
            Else
                MsgBox("error el codigo no existe")
            End If

        End If

    End Sub

    Private Sub EditarProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarProductoToolStripMenuItem.Click
        Panel2.Visible = False
        Panel1.Visible = False
        Panel3.Visible = False
        DataGridView1.Visible = False
        Panel4.Visible = True
        DataGridView2.Visible = True
        Panel5.Visible = False


    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel2.Visible = True
        Panel1.Visible = False
        Panel3.Visible = False
        DataGridView1.Visible = False
        Panel4.Visible = False
        DataGridView2.Visible = False
        Panel5.Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim checkUserCommand As MySqlCommand = Conex.CreateCommand()

        Try
            checkUserCommand = New MySqlCommand("UPDATE producto SET Nombre='" + TextBox15.Text + "',tipo='" + TextBox14.Text + "',cantidad_stock=" + TextBox13.Text + ",precio=" + TextBox12.Text + ",codigo=" + TextBox11.Text + " WHERE codigo=" + TextBox10.Text + ";", Conex)

            Dim resultado = checkUserCommand.ExecuteReader
            resultado.Read()
            MsgBox("Registro Exitoso")
            resultado.Close()

            TextBox15.Text = ""
            TextBox14.Text = ""
            TextBox13.Text = ""
            TextBox12.Text = ""
            TextBox11.Text = ""
            TextBox10.Text = ""
        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message)

        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim cerrar As String
        cerrar = MsgBox("¿Desea salir?", vbYesNo, "Confirmar")
        If (cerrar = vbYes) Then
            Me.Close()
            Form1.Show()
        End If
    End Sub
End Class