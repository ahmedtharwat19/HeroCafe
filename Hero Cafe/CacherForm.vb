Public Class CacherForm
    Private Sub Timer1_Tick(ByVal sender As System.Object,
                            ByVal e As System.EventArgs) Handles Timer1.Tick

        labelDatetime.Text = Now()
    End Sub

    Private Sub CacherForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        labelUsername.Text = Login.txtUsername.Text

        Timer1.Start()
        labelDatetime.Text = Now()
    End Sub

    Private Sub labelUsername_Click(sender As Object, e As EventArgs) Handles labelUsername.Click

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Application.Exit()
    End Sub
End Class