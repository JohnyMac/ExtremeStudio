﻿Imports ExtremeStudio.My.Resources

Public Class ObjectExplorerDockItems

    Private Sub Ref()
        itemsList.Items.Clear()

        For Each itm In MainForm.currentProject.objectExplorerItems
            itemsList.Items.Add(itm.Name)
        Next
    End Sub

    Private Function GetId(nme As String)
        For i As Integer = 0 To MainForm.currentProject.objectExplorerItems.Count - 1
            If MainForm.currentProject.objectExplorerItems(i).Name = nme Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub ObjectExplorerDockItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Ref()
    End Sub

    Private Sub itemsList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles itemsList.SelectedIndexChanged
        If itemsList.SelectedIndex = -1 Then Exit Sub

        infoName.Text = itemsList.SelectedItem
        infoIden.Text = MainForm.currentProject.objectExplorerItems(GetID(itemsList.SelectedItem)).Identifier
    End Sub

    Private Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click
        If MsgBox(translations.ObjectExplorerDockItems_deleteBtn_Click_YouWantDelete, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Try
            MainForm.currentProject.objectExplorerItems.RemoveAt(GetID(infoName.Text))
            Ref()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        If addName.Text = "" Or addIden.Text = "" Then
            MsgBox(translations.ObjectExplorerDockItems_addBtn_Click_PleaseEnterDetials)
        Else
            MainForm.currentProject.objectExplorerItems.Add(New objectExplorerItem(addName.Text, addIden.Text))
            Ref()
        End If
    End Sub
End Class

Public Class ObjectExplorerItem
    Public Sub New(name As String, iden As String)
        Me.Name = name
        Identifier = iden
    End Sub

    Public Property Name As String
    Public Property Identifier As String
End Class