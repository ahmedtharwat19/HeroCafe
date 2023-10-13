Public Class HomeForm
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        labelUsername.Text = Login.txtUsername.Text

        Timer1.Start()
        labelDatetime.Text = Now()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object,
                            ByVal e As System.EventArgs) Handles Timer1.Tick

        labelDatetime.Text = Now()
    End Sub


End Class