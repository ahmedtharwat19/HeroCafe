Imports System.Data.OleDb
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Login

    Dim connection As New OleDbConnection(My.Settings.restaurant_dbConnectionString)
    'Private bitmap As Bitmap()

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projects\vb.net\HeroCafe\database\restaurant_db.accdb"
        Me.Show()
        txtUsername.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'Dim checker As Integer
        'Try
        '    conn.Open()
        '    cmd = conn.CreateCommand()
        '    cmd.CommandType = CommandType.Text
        '    cmd.CommandText = "Select users.user_name, users.user_password From users Where (((users.user_name) = '" + txtUsername.Text + "') And ((users.user_password) = '" + txtPassword.Text + "'));"
        '    cmd.ExecuteNonQuery()
        '    dt = New DataTable()
        '    da = New OleDbDataAdapter(cmd)
        '    da.Fill(dt)
        '    checker = Convert.ToInt32(dt.Rows.Count.ToString)
        '    If (checker = 0) Then

        '        Me.Hide()
        '        HomeForm.Show()

        '    Else
        '        txtUsername.Text = ""
        '        txtPassword.Text = ""
        '        MessageBox.Show("Not Found", "vbOK", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try

        If txtUsername.Text = Nothing Or txtPassword.Text = Nothing Then
            MsgBox("Enter Credentials ", MsgBoxStyle.Exclamation)
        Else
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim cmd As New OleDbCommand("select count(*) from users where user_name=? and user_password=?", connection)
            Dim cmda As New OleDbCommand("select form_view from users where user_name=? and user_password=?", connection)

            ' "SELECT Count(*) AS Expr1, users.form_view FROM users WHERE (((users.[user_name])=[?]) AND ((users.[user_password])=[?]));"

            cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtUsername.Text
            cmd.Parameters.AddWithValue("@2", OleDbType.VarChar).Value = txtPassword.Text

            cmda.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtUsername.Text
            cmda.Parameters.AddWithValue("@2", OleDbType.VarChar).Value = txtPassword.Text
            Dim count = Convert.ToInt32(cmd.ExecuteScalar())
            Dim getuserdata As OleDbDataReader
            getuserdata = cmda.ExecuteReader


            If (count > 0) Then
                getuserdata.Read()
                Dim formstring As String
                formstring = getuserdata("form_view")
                ' MsgBox("Login Succeed", MsgBoxStyle.Information)
                Me.Hide()
                If formstring = "mainform" Then
                    HomeForm.Show()
                Else
                    CacherForm.Show()
                End If

                connection.Close()

            Else
                MsgBox("Account not found , check your credentials", MsgBoxStyle.Critical)

            End If
        End If
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.Focus()
            'btnLogin_Click()
            ' btnLogin.Select()
        End If
    End Sub
End Class
