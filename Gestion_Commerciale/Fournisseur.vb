Imports System.Data.SqlClient
Public Class Fournisseur
    Public dr As SqlDataReader
    Public cmd As New SqlCommand
    Private Sub Afficher()
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from fournisseur"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("N_fournisseur"))
            listems.SubItems.Add(dr("nom_fournisseur"))
            listems.SubItems.Add(dr("prenom_fournisseur"))
            listems.SubItems.Add(dr("ville_fournisseur"))
            listems.SubItems.Add(dr("idfiscale_fournisseur"))
        End While
        dr.Close()
        cn.Close()
    End Sub
    Private Sub client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Afficher()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If text_Nfournisseur.Text = Nothing Or text_nomfournisseur.Text = Nothing Or text_prénomfournisseur.Text = Nothing Or text_villefournisseur.Text = Nothing Or text_idfiscalefournisseur.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Enregistrer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "insert into fournisseur values('" & text_Nfournisseur.Text & "','" & text_nomfournisseur.Text & "','" & text_prénomfournisseur.Text & "','" & text_villefournisseur.Text & "','" & text_idfiscalefournisseur.Text & "')"
            cmd.ExecuteNonQuery()
            MsgBox("Enregistrer avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If text_Nfournisseur.Text = Nothing Or text_nomfournisseur.Text = Nothing Or text_prénomfournisseur.Text = Nothing Or text_villefournisseur.Text = Nothing Or text_idfiscalefournisseur.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If

        If MsgBox("Voulez Vous  Vraiment Modifier ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "update fournisseur set nom_fournisseur='" & text_nomfournisseur.Text & "',prenom_fournisseur='" & text_prénomfournisseur.Text & "',ville_fournisseur='" & text_villefournisseur.Text & "',idfiscale_fournisseur='" & text_idfiscalefournisseur.Text & "' where N_fournisseur=(" & text_Nfournisseur.Text & ")"
            cmd.ExecuteNonQuery()
            MsgBox("Modifier  avec Succés")
            cn.Close()
            Afficher()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If text_Nfournisseur.Text = Nothing Or text_nomfournisseur.Text = Nothing Or text_prénomfournisseur.Text = Nothing Or text_villefournisseur.Text = Nothing Or text_idfiscalefournisseur.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Supprimer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "delete from fournisseur  where N_fournisseur ='" & text_Nfournisseur.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Suppression  avec Succés")
            cn.Close()
            Afficher()

        End If
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox(" Selectionner un fournisseur ")
        Else
            cn.Open()
            cmd.CommandText = "select * from fournisseur  where N_fournisseur ='" & ListView1.SelectedItems(0).Text.ToString & "'"
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read Then
                Me.text_Nfournisseur.Text = dr.Item(0).ToString
                Me.text_nomfournisseur.Text = dr.Item(1).ToString
                Me.text_prénomfournisseur.Text = dr.Item(2).ToString
                Me.text_villefournisseur.Text = dr.Item(3).ToString
                Me.text_idfiscalefournisseur.Text = dr.Item(4).ToString
                dr.Close()
            End If
            cn.Close()
        End If
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles Text_rech1.KeyUp
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from fournisseur where '" & Text_rech1.Text & "' like '%' + @1 + '%'"
        cmd = New SqlCommand(str, cn)
        cmd.Parameters.AddWithValue("@1", Combo_rech1.Text)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("N_fournisseur"))
            listems.SubItems.Add(dr("nom_fournisseur"))
            listems.SubItems.Add(dr("prenom_fournisseur"))
            listems.SubItems.Add(dr("ville_fournisseur"))
            listems.SubItems.Add(dr("idfiscale_fournisseur"))
        End While
        dr.Close()
        cn.Close()
    End Sub


End Class