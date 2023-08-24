Imports System.Data.SqlClient
Public Class client
    Public dr As SqlDataReader
    Public cmd As New SqlCommand

    Private Sub Afficher()
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from clients"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("id_client"))
            listems.SubItems.Add(dr("nom_client"))
            listems.SubItems.Add(dr("prénom_client"))
            listems.SubItems.Add(dr("num_client"))
            listems.SubItems.Add(dr("ville_client"))
            listems.SubItems.Add(dr("idfiscale_client"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If text_idclient.Text = Nothing Or text_nomclient.Text = Nothing Or text_prénomclient.Text = Nothing Or text_numclient.Text = Nothing Or text_villeclient.Text = Nothing Or text_idfiscaleclient.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment enregistrer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "insert into clients values('" & text_idclient.Text & "','" & text_prénomclient.Text & "','" & text_prénomclient.Text & "','" & text_numclient.Text & "','" & text_villeclient.Text & "','" & text_villeclient.Text & "','" & text_idfiscaleclient.Text & "')"
            cmd.ExecuteNonQuery()
            MsgBox("enregistrer avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub
    Private Sub client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Afficher()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If text_idclient.Text = Nothing Or text_nomclient.Text = Nothing Or text_prénomclient.Text = Nothing Or text_numclient.Text = Nothing Or text_villeclient.Text = Nothing Or text_idfiscaleclient.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Modifier ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "update clients set nom_client='" & text_nomclient.Text & "',prénom_client='" & text_prénomclient.Text & "',num_client='" & text_numclient.Text & "',ville_client='" & text_villeclient.Text & "',idfiscale_client='" & text_idfiscaleclient.Text & "' where id_client=(" & text_idclient.Text & ")"
            cmd.ExecuteNonQuery()
            MsgBox("Modifier  avec Succés")
            cn.Close()
            Afficher()

        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If text_idclient.Text = Nothing Or text_nomclient.Text = Nothing Or text_prénomclient.Text = Nothing Or text_numclient.Text = Nothing Or text_villeclient.Text = Nothing Or text_idfiscaleclient.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Supprimer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "delete from clients  where id_client ='" & text_idclient.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Suppression  avec Succés")
            cn.Close()
            Afficher()

        End If
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click

        If ListView1.SelectedItems.Count = 0 Then
            MsgBox(" Selectionner un client ")
        Else
            cn.Open()
            cmd.CommandText = "select * from clients where id_client ='" & ListView1.SelectedItems(0).Text.ToString & "'"
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read Then
                Me.text_idclient.Text = dr.Item(0).ToString
                Me.text_nomclient.Text = dr.Item(1).ToString
                Me.text_prénomclient.Text = dr.Item(2).ToString
                Me.text_numclient.Text = dr.Item(3).ToString
                Me.text_villeclient.Text = dr.Item(4).ToString
                Me.text_idfiscaleclient.Text = dr.Item(5).ToString
                dr.Close()
            End If
            cn.Close()
        End If
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from clients where '" & TextBox1.Text & "' Like '%' '" & TextBox1.Text & "' '%'"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("id_client"))
            listems.SubItems.Add(dr("nom_client"))
            listems.SubItems.Add(dr("prénom_client"))
            listems.SubItems.Add(dr("num_client"))
            listems.SubItems.Add(dr("ville_client"))
            listems.SubItems.Add(dr("idfiscale_client"))
        End While
        dr.Close()
        cn.Close()
    End Sub


End Class