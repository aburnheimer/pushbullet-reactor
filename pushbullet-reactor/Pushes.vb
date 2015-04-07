Public Class Pushes
    Private _pushes As List(Of aPush)
    Public Property pushes() As List(Of aPush)
        Get
            Return _pushes
        End Get
        Set(ByVal value As List(Of aPush))
            _pushes = value
        End Set
    End Property

End Class