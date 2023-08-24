Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Stocks
    Public dr As SqlDataReader
    Public cmd As New SqlCommand

    Private Sub Afficher()
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from stocks"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("code_produit"))
            listems.SubItems.Add(dr("totale_entrée"))
            listems.SubItems.Add(dr("totale_sortie"))
            listems.SubItems.Add(dr("totale_stocks"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub Achat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Afficher()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If text_codeproduit.Text = Nothing Or text_totaleentrée.Text = Nothing Or text_totalesortie.Text = Nothing Or text_totalestocks.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Enregistrer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "insert into stocks values('" & text_codeproduit.Text & "','" & text_totaleentrée.Text & "','" & text_totalesortie.Text & "','" & text_totalestocks.Text & "')"
            cmd.ExecuteNonQuery()
            MsgBox("Enregistrer avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If text_codeproduit.Text = Nothing Or text_totaleentrée.Text = Nothing Or text_totalesortie.Text = Nothing Or text_totalestocks.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Modifier ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "update stocks set code_produit ='" & text_codeproduit.Text & "',totale_entrée='" & text_totaleentrée.Text & "',totale_sortie='" & text_totalesortie.Text & "',totale_stocks='" & text_totalestocks.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Modification avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If text_codeproduit.Text = Nothing Or text_totaleentrée.Text = Nothing Or text_totalesortie.Text = Nothing Or text_totalestocks.Text = Nothing Then
            MsgBox(" Attention! remplir votre champs ")
        End If
        If MsgBox("Voulez Vous  Vraiment Supprimer ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
            cn.Open()
            cmd.CommandText = "delete from  stocks  where code_produit ='" & text_codeproduit.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Suppression  avec Succés")
            cn.Close()
            Afficher()
        End If
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox(" Selectionner un Stocks ")
        Else
            cn.Open()
            cmd.CommandText = "select * from stocks  where code_produit ='" & ListView1.SelectedItems(0).Text.ToString & "'"
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read Then
                Me.text_codeproduit.Text = dr.Item(0).ToString
                Me.text_totaleentrée.Text = dr.Item(1).ToString
                Me.text_totalesortie.Text = dr.Item(2).ToString
                Me.text_totalestocks.Text = dr.Item(3).ToString
                dr.Close()
            End If
            cn.Close()
        End If
    End Sub

    Private Sub Text_recherche_KeyUp(sender As Object, e As KeyEventArgs) Handles Text_recherche.KeyUp
        cn.Open()
        Dim listems As ListViewItem
        Dim str As String = "select * from stocks where '" & text_ComboBox1.Text & "' Like '%' + @1 + '%'"
        cmd = New SqlCommand(str, cn)
        cmd.Parameters.AddWithValue("@1", Text_recherche.Text)
        dr = cmd.ExecuteReader
        ListView1.Items.Clear()
        While (dr.Read)
            listems = Me.ListView1.Items.Add(dr("code_produit"))
            listems.SubItems.Add(dr("totale_entrée"))
            listems.SubItems.Add(dr("totale_sortie"))
            listems.SubItems.Add(dr("totale_stocks"))
        End While
        dr.Close()
        cn.Close()
    End Sub
End Class

