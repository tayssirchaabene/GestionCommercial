Imports System.Data.SqlClient
Public Class Commande
    Public dr As SqlDataReader
    Public cmd As New SqlCommand

    Private Sub Afficher()
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from commande"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("N_commande"))
            listems.SubItems.Add(dr("id_client"))
            listems.SubItems.Add(dr("code_produit"))
            listems.SubItems.Add(dr("quantité_commande"))
            listems.SubItems.Add(dr("prix_commande"))
            listems.SubItems.Add(dr("totale_commande"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub Achat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Afficher()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If text_Ncommande.Text = Nothing Or text_idclient.Text = Nothing Or text_codeproduit.Text = Nothing Or text_qantitécommande.Text = Nothing Or text_prixcommande.Text = Nothing Or text_totalecommande.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Enregistrer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "insert into commande values('" & text_Ncommande.Text & "','" & text_idclient.Text & "','" & text_codeproduit.Text & "','" & text_qantitécommande.Text & "','" & text_prixcommande.Text & "','" & text_totalecommande.Text & "')"
            cmd.ExecuteNonQuery()
            MsgBox("Enregistrer avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If text_Ncommande.Text = Nothing Or text_idclient.Text = Nothing Or text_codeproduit.Text = Nothing Or text_qantitécommande.Text = Nothing Or text_prixcommande.Text = Nothing Or text_totalecommande.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Modifier ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "update commande set id_client ='" & text_idclient.Text & "',code_produit='" & text_codeproduit.Text & "',quantité_commande='" & text_qantitécommande.Text & "',prix_commande='" & text_prixcommande.Text & "',totale_commande='" & text_totalecommande.Text & "' where N_commande=(" & text_Ncommande.Text & ")"
            cmd.ExecuteNonQuery()
            MsgBox("Modifier  avec Succés")
            cn.Close()
            Afficher()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If text_Ncommande.Text = Nothing Or text_idclient.Text = Nothing Or text_codeproduit.Text = Nothing Or text_qantitécommande.Text = Nothing Or text_prixcommande.Text = Nothing Or text_totalecommande.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Supprimer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "delete from commande  where N_commande='" & text_Ncommande.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Suppression  avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub Text_recherche_KeyUp(sender As Object, e As KeyEventArgs) Handles Text_recherche.KeyUp
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from commande where '" & text_ComboBox1.Text & "' Like '%' + @1 + '%'"
        cmd = New SqlCommand(str, cn)
        cmd.Parameters.AddWithValue("@1", Text_recherche.Text)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("N_commande"))
            listems.SubItems.Add(dr("id_client"))
            listems.SubItems.Add(dr("code_produit"))
            listems.SubItems.Add(dr("quantité_commande"))
            listems.SubItems.Add(dr("prix_commande"))
            listems.SubItems.Add(dr("totale_commande"))
        End While
        dr.Close()
        cn.Close()
    End Sub



    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox(" Selectionner une commande ")
        Else
            cn.Open()
            cmd.CommandText = "select * from commande  where N_commande ='" & ListView1.SelectedItems(0).Text.ToString & "'"
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read Then
                Me.text_Ncommande.Text = dr.Item(0).ToString
                Me.text_idclient.Text = dr.Item(1).ToString
                Me.text_codeproduit.Text = dr.Item(2).ToString
                Me.text_qantitécommande.Text = dr.Item(3).ToString
                Me.text_prixcommande.Text = dr.Item(4).ToString
                Me.text_totalecommande.Text = dr.Item(5).ToString
                dr.Close()
            End If
            cn.Close()
        End If
    End Sub
End Class