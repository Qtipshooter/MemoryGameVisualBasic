' MainMenu
' Quinton Graham
' Runs the Main Menu for the game

Option Strict On
Option Explicit On
Public Class MainMenu
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        If radEasy.Checked Then
            Dim frmEasy As New MemoryEasy
            Me.Hide()
            frmEasy.ShowDialog()
            Me.Show()
        ElseIf radMedium.Checked Then
            Dim frmMedium As New MemoryMedium
            Me.Hide()
            frmMedium.ShowDialog()
            Me.Show()
        End If
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        radEasy.Select()
    End Sub

    Private Sub Help_Click(sender As Object, e As EventArgs) Handles Help.Click
        Dim frmHelp As New HelpWindow
        frmHelp.ShowDialog()
    End Sub
End Class
