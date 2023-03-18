Public Class CategoryRepository

    Private DBC As New RPGcorContext()

    Friend ReadOnly Property Categories As IQueryable(Of Entity.Category)
        Get
            Return DBC.Categories
        End Get
    End Property

    Public Function GetAll() As List(Of Entity.Category)
        Return Categories.ToList()
    End Function

    ''' <summary>
    ''' List of categories sorted by Page, SortOrder
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CategoryListSorted() As List(Of Entity.Category)
        Return Categories.OrderBy(Function(f) f.PageNum).OrderBy(Function(f) f.SortOrder).ToList
    End Function

    ''' <summary>
    ''' Get a category by its Id
    ''' </summary>
    ''' <param name="id">Category Id</param>
    ''' <returns>Category or Nothing</returns>
    ''' <remarks></remarks>
    Public Function CategoryById(ByVal id As Integer) As Entity.Category
        Return Categories.Where(Function(f) f.CategoryId = id).FirstOrDefault
    End Function

    ''' <summary>
    ''' Categories for Page, sorted by SortOrder
    ''' </summary>
    ''' <param name="page">Page Number</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ForPage(ByVal page As Integer) As List(Of Entity.Category)
        Return Categories.Where(Function(f) f.PageNum = page).OrderBy(Function(f) f.SortOrder).ToList
    End Function

    Public Function PageInstances() As List(Of SPageInstances)
        Dim lst As New List(Of SPageInstances)
        For Each itm In (From x As Entity.Category In Categories Let PageName = "Page " & x.PageNum Order By x.PageNum Select x.PageNum, PageName Distinct).ToList
            lst.Add(New SPageInstances With {.Name = itm.PageName, .value = itm.PageNum})
        Next
        Return lst
    End Function
    Public Structure SPageInstances
        Public Name As String
        Public value As Integer
    End Structure
    Public Function Delete(ByVal id As Integer) As Boolean
        Try
            DBC.Categories.Remove(Categories.Where(Function(f) f.CategoryId = id).SingleOrDefault())
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddCategory(ByRef cat As Entity.Category) As Boolean
        Try
            DBC.Categories.Add(cat)
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Update(ByRef model As Entity.Category) As Boolean
        Try
            Dim id As Integer = model.CategoryId
            With DBC.Categories.Where(Function(f) f.CategoryId = id).SingleOrDefault()
                .CatName = model.CatName
                .SortOrder = model.SortOrder
                .ShowDateAchieved = model.ShowDateAchieved
                .ShowPicture = model.ShowPicture
                .ShowGame1 = model.ShowGame1
                .ShowGame2 = model.ShowGame2
                .ShowGame3 = model.ShowGame3
                .ShowHDCPSeries = model.ShowHDCPSeries
                .ShowSeries = model.ShowSeries
                .PerPage = model.PerPage
            End With
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
