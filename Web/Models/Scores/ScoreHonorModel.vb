Public Class ScoreHonorModel

    Public Property scores As New List(Of Core.Entity.Score)
    Public Property page_data As New List(Of Dictionary)
    Public Property page_selected As Integer
    Public Property cats As New List(Of Core.Entity.Category)

    Public Structure Dictionary
        Public Property Key As String
        Public Property Value As String
        Public Sub New(ByVal _key As String, ByVal _value As String)
            Key = _key
            Value = _value
        End Sub
    End Structure

End Class
