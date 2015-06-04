﻿Imports System.IO

Public Class NewProjectFile

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            FolderList.Items.Clear()
            FolderList.Items.Add("gamemodes")

            For Each Str As String In ExtremeCore.getAllFolders(MainForm.currentProject.projectPath + "/gamemodes")
                FolderList.Items.Add(Str.Replace(MainForm.currentProject.projectPath + "\", ""))
            Next

            extensionLabel.Text = ".pwn"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            FolderList.Items.Clear()
            FolderList.Items.Add("include")

            For Each Str As String In ExtremeCore.getAllFolders(MainForm.currentProject.projectPath + "/pawno/include")
                FolderList.Items.Add(Str.Replace(MainForm.currentProject.projectPath + "\pawno\", ""))
            Next

            extensionLabel.Text = ".inc"
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            FolderList.Items.Clear()
            FolderList.Items.Add("filterscripts")

            For Each Str As String In ExtremeCore.getAllFolders(MainForm.currentProject.projectPath + "/filterscripts")
                FolderList.Items.Add(Str.Replace(MainForm.currentProject.projectPath + "\", ""))
            Next

            extensionLabel.Text = ".pwn"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderList.SelectedIndex = -1 Then
            MsgBox("Please select a valid target.")
            Exit Sub
        End If

        Dim targetPath As String = MainForm.currentProject.projectPath + "/"
        If RadioButton1.Checked Then
            targetPath += "gamemodes/" + fileNameText.Text + ".pwn"
        ElseIf RadioButton2.Checked Then
            targetPath += "pawno/include/" + fileNameText.Text + ".inc"
        ElseIf RadioButton3.Checked Then
            targetPath += "filterscripts/" + fileNameText.Text + ".pwn"
        End If
        My.Computer.FileSystem.CopyFile(Application.StartupPath + "/newfileTemplate.pwn", targetPath)

        'TODO: Add code to create the tab.
        'TODO: Add code to refresh to the mainform.
        Me.Close()
    End Sub
End Class