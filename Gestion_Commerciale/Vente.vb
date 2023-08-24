Imports System.Data.SqlClient
Public Class Vente
    Public dr As SqlDataReader
    Public cmd As New SqlCommand

    Private Sub Afficher()
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from vente"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("N_vente"))
            listems.SubItems.Add(dr("id_client"))
            listems.SubItems.Add(dr("prix_unt"))
            listems.SubItems.Add(dr("date_facture"))
            listems.SubItems.Add(dr("quantité_vente"))
            listems.SubItems.Add(dr("code_produit"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub Achat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Afficher()
    End Sub


    Private Sub Text_recherche_KeyUp(sender As Object, e As KeyEventArgs) Handles Text_recherche.KeyUp
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from vente where '" & text_ComboBox1.Text & "' Like '%' + @1 + '%'"
        cmd = New SqlCommand(str, cn)
        cmd.Parameters.AddWithValue("@1", Text_recherche.Text)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("N_vente"))
            listems.SubItems.Add(dr("id_client"))
            listems.SubItems.Add(dr("prix_unt"))
            listems.SubItems.Add(dr("date_facture"))
            listems.SubItems.Add(dr("quantité_vente"))
            listems.SubItems.Add(dr("code_produit"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox(" Selectionner une vente ")
        Else
            cn.Open()
            cmd.CommandText = "select * from vente where N_vente ='" & ListView1.SelectedItems(0).Text.ToString & "'"
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read Then
                Me.text_Nvente.Text = dr.Item(0).ToString
                Me.text_idclient.Text = dr.Item(1).ToString
                Me.text_prixunt.Text = dr.Item(2).ToString
                Me.DateTimePicker1.Text = dr.Item(3).ToString
                Me.text_quantitévente.Text = dr.Item(4).ToString
                Me.text_codeproduit.Text = dr.Item(5).ToString
                dr.Close()
            End If
            cn.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If text_Nvente.Text = Nothing Or text_idclient.Text = Nothing Or text_prixunt.Text = Nothing Or DateTimePicker1.Text = Nothing Or text_quantitévente.Text = Nothing Or text_codeproduit.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Enregistrer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "insert into produit values('" & text_Nvente.Text & "','" & text_idclient.Text & "','" & text_prixunt.Text & "','" & DateTimePicker1.Text & "','" & text_quantitévente.Text & "','" & text_codeproduit.Text & "')"
            cmd.ExecuteNonQuery()
            MsgBox("Enregistrement avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If text_Nvente.Text = Nothing Or text_idclient.Text = Nothing Or text_prixunt.Text = Nothing Or DateTimePicker1.Text = Nothing Or text_quantitévente.Text = Nothing Or text_codeproduit.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Modifier ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "update vente set id_client='" & text_idclient.Text & "',prix_unt='" & text_prixunt.Text & "',date_facture='" & DateTimePicker1.Text & "',quantité_vente='" & text_quantitévente.Text & "',code_produit='" & text_codeproduit.Text & "'where N_vente=(" & text_Nvente.Text & ")"
            cmd.ExecuteNonQuery()
            MsgBox("Modifier  avec Succés")
            cn.Close()
            Afficher()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If text_Nvente.Text = Nothing Or text_idclient.Text = Nothing Or text_prixunt.Text = Nothing Or DateTimePicker1.Text = Nothing Or text_quantitévente.Text = Nothing Or text_codeproduit.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Supprimer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "delete from vente  where N_vente ='" & text_Nvente.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Suppression  avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub
End Class