Public Class ScoreRepository

    Private DBC As New RPGcorContext()

    Public ReadOnly Property Scores As IQueryable(Of Entity.Score)
        Get
            Return DBC.Scores.Include("Category").Include("Picture")
        End Get
    End Property

    Public Function SearchSQL(ByVal sql_where As String) As List(Of Entity.Score)
        Return DBC.Scores.SqlQuery("SELECT * FROM [Score] WHERE " & sql_where).ToList()
    End Function

    Public Function ByPage(ByVal page As Integer) As List(Of Entity.Score)
        Return Scores.Where(Function(f) f.Category.PageNum = page).OrderBy(Function(f) f.Category.SortOrder).ToList()
    End Function

    Public Function Insert(ByRef score As Entity.Score) As Boolean
        Try
            DBC.Scores.Add(score)
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            DBC.Scores.Remove(score)
            Return False
        End Try
    End Function

    Public Function Update(ByVal score As Entity.Score) As Boolean
        Try
            Dim lscore As Entity.Score = Scores.Where(Function(f) f.ScoreId = score.ScoreId).SingleOrDefault()
            With lscore
                .PictureId = score.PictureId
                .FName = score.FName
                .LName = score.LName
                .League = score.League
                .DateAchieved = score.DateAchieved
                .Game1 = score.Game1
                .Game2 = score.Game2
                .Game3 = score.Game3
                .HDCPSeries = score.HDCPSeries
            End With
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Delete(ByVal score As Entity.Score) As Boolean
        Try
            DBC.Scores.Remove(Scores.Where(Function(f) f.ScoreId = score.ScoreId).SingleOrDefault())
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Archives scores
    ''' </summary>
    ''' <returns>T/F if successful</returns>
    ''' <remarks></remarks>
    Public Function Archive() As Boolean
        Try
            For Each score As Entity.Score In Scores.Where(Function(f) f.Archived = False)
                score.Archived = True
            Next
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
