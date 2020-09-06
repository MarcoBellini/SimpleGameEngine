
Imports System.ComponentModel

Public Class MainForm

    Private TestGame As New ShooterTest

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TestGame.Start(Me, Width, Height)
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        TestGame.Close()
    End Sub
End Class