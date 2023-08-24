Imports System.Data.SqlClient
Public Class Produit
    Public dr As SqlDataReader
    Public cmd As New SqlCommand

    Private Sub Afficher()
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from produit"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("code_produit"))
            listems.SubItems.Add(dr("nom_produit"))
            listems.SubItems.Add(dr("famille_produit"))
            listems.SubItems.Add(dr("prix_produit"))
            listems.SubItems.Add(dr("stock_produit"))
            listems.SubItems.Add(dr("unité_produit"))
        End While
        dr.Close()
        cn.Close()
    End Sub
    Private Sub unité_produit()
        cn.Open()
        Dim str As String = "select	distinct unité_produit from produit"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        While (dr.Read)
            Me.text_ComboBox2.Items.Add(dr("unité_produit")).ToString()
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub Produit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Afficher()
        unité_produit()
    End Sub
    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox(" Selectionner un Produit ")
        Else
            cn.Open()
            cmd.CommandText = "select * from produit where code_produit ='" & ListView1.SelectedItems(0).Text.ToString & "'"
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read Then
                Me.text_codeproduit.Text = dr.Item(0).ToString
                Me.text_nomproduit.Text = dr.Item(1).ToString
                Me.text_familleproduit.Text = dr.Item(2).ToString
                Me.text_prixproduit.Text = dr.Item(3).ToString
                Me.text_stocksproduit.Text = dr.Item(4).ToString
                Me.text_ComboBox2.Text = dr.Item(5).ToString
                dr.Close()
            End If
            cn.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If text_codeproduit.Text = Nothing Or text_nomproduit.Text = Nothing Or text_familleproduit.Text = Nothing Or text_prixproduit.Text = Nothing Or text_stocksproduit.Text = Nothing Or text_ComboBox2.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Enregistrer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "insert into produit values('" & text_codeproduit.Text & "','" & text_nomproduit.Text & "','" & text_familleproduit.Text & "','" & text_prixproduit.Text & "','" & text_stocksproduit.Text & "','" & text_ComboBox2.Text & "')"
            cmd.ExecuteNonQuery()
            MsgBox("Enregistrement avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If text_codeproduit.Text = Nothing Or text_nomproduit.Text = Nothing Or text_familleproduit.Text = Nothing Or text_prixproduit.Text = Nothing Or text_stocksproduit.Text = Nothing Or text_ComboBox2.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Modifier ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "update produit set nom_produit='" & text_nomproduit.Text & "',famille_produit='" & text_familleproduit.Text & "',prix_produit='" & text_prixproduit.Text & "',stock_produit='" & text_stocksproduit.Text & "',unité_produit='" & text_ComboBox2.Text & "'where code_produit='" & text_codeproduit.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Modifier  avec Succés")
            cn.Close()
            Afficher()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If text_codeproduit.Text = Nothing Or text_nomproduit.Text = Nothing Or text_familleproduit.Text = Nothing Or text_prixproduit.Text = Nothing Or text_stocksproduit.Text = Nothing Or text_ComboBox2.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Supprimer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "delete from produit  where code_produit='" & text_codeproduit.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Suppression  avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub Text_recherche_KeyUp(sender As Object, e As KeyEventArgs) Handles Text_recherche.KeyUp
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from produit where '" & text_ComboBox1.Text & "' Like '%' + @1 + '%'"
        cmd = New SqlCommand(str, cn)
        cmd.Parameters.AddWithValue("@1", Text_recherche.Text)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("code_produit"))
            listems.SubItems.Add(dr("nom_produit"))
            listems.SubItems.Add(dr("famille_produit"))
            listems.SubItems.Add(dr("prix_produit"))
            listems.SubItems.Add(dr("stock_produit"))
            listems.SubItems.Add(dr("unité_produit"))
        End While
        dr.Close()
        cn.Close()
    End Sub
End Class