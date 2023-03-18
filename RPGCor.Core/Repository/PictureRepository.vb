Public Class PictureRepository

    Private DBC As New RPGcorContext()

    Public ReadOnly Property Pictures As IQueryable(Of Entity.Picture)
        Get
            Return DBC.Pictures
        End Get
    End Property

    Public Function Delete(ByVal id As Integer) As Boolean
        Dim pic = Pictures.Where(Function(u) u.PictureId = id).SingleOrDefault()
        If pic IsNot Nothing Then
            DBC.Pictures.Remove(pic)
            DBC.SaveChanges()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetPic(ByVal id As Integer) As Entity.Picture
        Return Pictures.where(Function(f) F.PictureId = id).SingleOrDefault()
    End Function

    Public Function Insert(ByVal pic As Entity.Picture) As Boolean
        Try
            DBC.Pictures.Add(pic)
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
