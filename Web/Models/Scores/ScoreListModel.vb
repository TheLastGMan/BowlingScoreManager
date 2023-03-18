Public Class ScoreListModel

    Public Property Category As New Core.Entity.Category
    Public Property Scores As New List(Of Core.Entity.Score)
    Public Property EnableEdit As Boolean = False

End Class
