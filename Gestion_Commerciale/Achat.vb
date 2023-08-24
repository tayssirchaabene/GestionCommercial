Imports System.Data.SqlClient
Public Class Achat
    Public dr As SqlDataReader
    Public cmd As New SqlCommand
    Private Sub Afficher()
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from Achat"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("N_achat"))
            listems.SubItems.Add(dr("N_fournisseur"))
            listems.SubItems.Add(dr("date_achat"))
            listems.SubItems.Add(dr("code_produit"))
            listems.SubItems.Add(dr("quantité_produit"))
            listems.SubItems.Add(dr("prix_achat"))
            listems.SubItems.Add(dr("total_ttc"))
        End While
        dr.Close()
        cn.Close()
    End Sub
    Private Sub Achat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Afficher()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If text_Nfournisseur.Text = Nothing Or text_Nachat.Text = Nothing Or text_Nfournisseur.Text = Nothing Or DateTimePicker1.Text = Nothing Or text_codeproduit.Text = Nothing Or text_quantitéproduit.Text = Nothing Or text_prixachat.Text = Nothing Or text_totalttc.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Enregistrer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "insert into Achat values('" & text_Nachat.Text & "','" & text_Nfournisseur.Text & "','" & DateTimePicker1.Text & "','" & text_codeproduit.Text & "','" & text_quantitéproduit.Text & "','" & text_prixachat.Text & "','" & text_totalttc.Text & "')"
            cmd.ExecuteNonQuery()
            MsgBox("Enregistrement avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If text_Nfournisseur.Text = Nothing Or text_Nachat.Text = Nothing Or text_Nfournisseur.Text = Nothing Or DateTimePicker1.Text = Nothing Or text_codeproduit.Text = Nothing Or text_quantitéproduit.Text = Nothing Or text_prixachat.Text = Nothing Or text_totalttc.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Modifier ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "update produit set N_fournisseur='" & text_Nfournisseur.Text & "',date_achat='" & DateTimePicker1.Text & "',code_produit='" & text_codeproduit.Text & "',quantité_produit='" & text_quantitéproduit.Text & "',prix_achat='" & text_prixachat.Text & "',total_ttc='" & text_totalttc.Text & "'where N_achat=(" & text_Nachat.Text & ")"
            cmd.ExecuteNonQuery()
            MsgBox("Modification avec Succés")
            cn.Close()
            Afficher()
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If text_Nfournisseur.Text = Nothing Or text_Nachat.Text = Nothing Or text_Nfournisseur.Text = Nothing Or DateTimePicker1.Text = Nothing Or text_codeproduit.Text = Nothing Or text_quantitéproduit.Text = Nothing Or text_prixachat.Text = Nothing Or text_totalttc.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Supprimer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "delete from  Achat  where N_achat='" & text_Nachat.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Suppression  avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox(" Selectionner un Achat ")
        Else
            cn.Open()
            cmd.CommandText = "select * from Achat where N_achat ='" & ListView1.SelectedItems(0).Text.ToString & "'"
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read Then
                Me.text_Nachat.Text = dr.Item(0).ToString
                Me.text_Nfournisseur.Text = dr.Item(1).ToString
                Me.DateTimePicker1 = dr.Item(2)
                Me.text_codeproduit.Text = dr.Item(3).ToString
                Me.text_quantitéproduit.Text = dr.Item(4).ToString
                Me.text_prixachat.Text = dr.Item(5).ToString
                Me.text_totalttc.Text = dr.Item(6).ToString
                dr.Close()
            End If
            cn.Close()
        End If
    End Sub

    Private Sub Text_recherche_KeyUp(sender As Object, e As KeyEventArgs) Handles Text_recherche.KeyUp
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from Achat where '" & text_ComboBox1.Text & "' Like '%' + @1 + '%'"
        cmd = New SqlCommand(str, cn)
        cmd.Parameters.AddWithValue("@1", Text_recherche.Text)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("N_achat"))
            listems.SubItems.Add(dr("N_fournisseur"))
            listems.SubItems.Add(dr("date_achat"))
            listems.SubItems.Add(dr("code_produit"))
            listems.SubItems.Add(dr("quantité_produit"))
            listems.SubItems.Add(dr("prix_achat"))
            listems.SubItems.Add(dr("total_ttc"))
        End While
        dr.Close()
        cn.Close()
    End Sub
End Class