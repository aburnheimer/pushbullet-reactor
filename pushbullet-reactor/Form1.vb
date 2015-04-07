Imports WebSocketSharp
Imports Newtonsoft.Json



Public Class Form1

    Private WithEvents ws As WebSocket

    Sub wsErrorHandler(ByVal sender As Object, ByVal e As ErrorEventArgs) Handles ws.OnError

    End Sub

    Sub wsOpenHandler(ByVal sender As Object, ByVal e As System.EventArgs) Handles ws.OnOpen


    End Sub

    Sub wsMesssageHandler(ByVal sender As Object, ByVal e As MessageEventArgs) Handles ws.OnMessage
        Debug.Print(e.Data.ToString)
        If e.Data.ToString.Contains("tickle") Then
            Dim webClient As New System.Net.WebClient

            webClient.Headers("Authorization") = "Bearer ********************************"
            Dim result As String = webClient.DownloadString("https://api.pushbullet.com/v2/pushes")
            Dim deserializedProduct As Pushes = JsonConvert.DeserializeObject(Of Pushes)(result)
            Debug.Print(deserializedProduct.pushes.Count & " pushes")
            For Each push In deserializedProduct.pushes
                Debug.Print("T: " & push.title & ", B: " & push.body)
            Next
        End If

    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ws = New WebSocket("wss://stream.pushbullet.com/websocket/********************************")
        ws.Connect()
    End Sub


End Class