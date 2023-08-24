Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Password
    Public dr As SqlDataReader
    Public cmd As New SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If text_login.Text = Nothing Then
            MessageBox.Show("Remplir Login")
        ElseIf (text_password.Text = Nothing) Then
            MessageBox.Show("Remplir Votre Mot De Pass")
        Else
            cn.Open()
            Dim str As String = "select * from Login1 where username='" & text_login.Text & "' and password='" & text_password.Text & "'"
            cmd = New SqlCommand(str, cn)
            dr = cmd.ExecuteReader

            If dr.Read Then


                Menue_g.Show()
                dr.Close()
                cn.Close()
                Me.Hide()
            Else
                MessageBox.Show("Mot de passe Incorrect")
                dr.Close()
                cn.Close()
            End If

            dr.Close()
            cn.Close()
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class