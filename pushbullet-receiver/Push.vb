Public Class Push
    Private _type As String
    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Private _title As String
    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    Private _body As String
    Public Property body() As String
        Get
            Return _body
        End Get
        Set(ByVal value As String)
            _body = value
        End Set
    End Property

End Class
