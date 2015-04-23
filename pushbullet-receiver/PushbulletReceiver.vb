Imports WebSocketSharp
Imports Newtonsoft.Json

Public Class PushbulletReceiver
    Private _apiKey As String
    Private Const PUSHBULLET_STREAM_URL_STUB As String = "wss://stream.pushbullet.com/websocket/"
    Private Const PUSHBULLET_API_URL_STUB As String = "https://api.pushbullet.com/v2/"
    Private WithEvents _ws As WebSocket
    Public Event MessageReceived(ByVal title As String, ByVal body As String)

    Public Property apiKey() As String
        Get
            Return _apiKey
        End Get
        Set(ByVal value As String)
            _apiKey = value
        End Set
    End Property

    Public Sub New(ByVal newApiKey As String)
        apiKey = newApiKey
    End Sub

    Public Sub Connect()
        _ws = New WebSocket(PUSHBULLET_STREAM_URL_STUB & _apiKey)
        _ws.Connect()
    End Sub

    Private Sub wsErrorHandler(ByVal sender As Object, ByVal e As ErrorEventArgs) Handles _ws.OnError

    End Sub

    Private Sub wsOpenHandler(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ws.OnOpen


    End Sub

    Private Sub wsMesssageHandler(ByVal sender As Object, ByVal e As MessageEventArgs) Handles _ws.OnMessage
        If e.Data.ToString.Contains("tickle") Then
            Dim webClient As New System.Net.WebClient

            webClient.Headers("Authorization") = "Bearer " & apiKey
            Dim result As String = webClient.DownloadString(PUSHBULLET_API_URL_STUB & "/pushes?active=true")
            Dim deserializedProduct As Pushes = JsonConvert.DeserializeObject(Of Pushes)(result)
            Dim latestPush As Push
            latestPush = deserializedProduct.pushes(0)
            RaiseEvent MessageReceived(latestPush.title, latestPush.body)
        End If

    End Sub

End Class
