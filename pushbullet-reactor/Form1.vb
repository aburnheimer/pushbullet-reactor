Imports pushbullet_receiver

Public Class Form1
    Private WithEvents pbr As PushbulletReceiver

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbr = New PushbulletReceiver("********************************")
        pbr.Connect()
    End Sub

    Private Sub ReceiveMessage(ByVal title As String, ByVal body As String) Handles pbr.MessageReceived
        Debug.Print("RM: t: " & title & ", b: " & body)
    End Sub

End Class
