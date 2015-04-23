Public Class Pushes
    Private _pushes As List(Of Push)
    Public Property pushes() As List(Of Push)
        Get
            Return _pushes
        End Get
        Set(ByVal value As List(Of Push))
            _pushes = value
        End Set
    End Property

End Class