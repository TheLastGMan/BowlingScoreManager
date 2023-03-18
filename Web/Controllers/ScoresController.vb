Namespace RPGCor.Web
    Public Class ScoresController
        Inherits System.Web.Mvc.Controller

        Private SR As New Core.ScoreRepository()
        Private CR As New Core.CategoryRepository()
        Private PR As New Core.PictureRepository()

        <Authorize(Roles:="Editor")>
        Public Function Index() As ActionResult
            'redirect to proper page
            Return RedirectToAction("Views", "Scores")
        End Function

        <Authorize(Roles:="Editor")>
        Public Function Add(Optional ByVal id As Integer = 0) As ActionResult
            Dim model As New ScoreInsertModel()

            model.Categories = CR.CategoryListSorted
            model.NewScore = New Core.Entity.Score()
            model.CatSelected = CR.CategoryListSorted.FirstOrDefault().CategoryId
            model.NewScore.CategoryId = model.CatSelected

            Return View(model)
        End Function

        <Authorize(Roles:="Editor")>
        <HttpPost()>
        Public Function Add(ByVal model As ScoreInsertModel, ByVal file As HttpPostedFileBase) As ActionResult
            model.Categories = CR.CategoryListSorted

            If Not ModelState.IsValid Then
                ModelState.AddModelError("", "Please Fill Out the Required Fields")
                Return View(model)
            End If

            If file IsNot Nothing Then
                'upload file
                Dim PIC As New Core.Entity.Picture With {.Data = New Byte(file.ContentLength) {}}
                PIC.Mime = file.ContentType
                Dim start As Integer = PIC.Mime.LastIndexOf("/") + 1
                PIC.Extension = PIC.Mime.Substring(start, PIC.Mime.Length - start)
                file.InputStream.Read(PIC.Data, 0, file.ContentLength)
                PR.Insert(PIC)
                model.NewScore.PictureId = PIC.PictureId
            End If

            'manual add - enable editing and ensure it is not archived
            model.NewScore.Archived = False
            model.NewScore.Editable = True
            If Not SR.Insert(model.NewScore) Then
                ModelState.AddModelError("", "Error Adding Score")
                model.Categories = CR.CategoryListSorted
                Return View(model)
            End If

            'success
            Return RedirectToAction("Views", New With {.id = model.NewScore.CategoryId})
        End Function

        <Authorize(Roles:="Editor")>
        Public Function Edit(Optional ByVal id As Integer = 0) As ActionResult
            Dim score As Core.Entity.Score = SR.Scores.Where(Function(f) f.ScoreId = id).SingleOrDefault
            If score IsNot Nothing Then
                'valid
                Return View(New ScoreEditModel() With {.Score = score})
            End If
            'not valid
            Return RedirectToAction("Views")
        End Function

        <Authorize(Roles:="Editor")>
        <HttpPost()>
        Public Function Edit(ByVal model As ScoreEditModel, ByVal file As HttpPostedFileBase) As ActionResult
            If ModelState.IsValid Then
                'check picture
                If file IsNot Nothing Then
                    'upload new picture
                    Dim PIC As New Core.Entity.Picture With {.Data = New Byte(file.ContentLength) {}}
                    PIC.Mime = file.ContentType
                    Dim start As Integer = PIC.Mime.LastIndexOf("/") + 1
                    PIC.Extension = PIC.Mime.Substring(start, PIC.Mime.Length - start)
                    file.InputStream.Read(PIC.Data, 0, file.ContentLength)
                    PR.Insert(PIC)
                    model.Score.PictureId = PIC.PictureId
                End If

                If SR.Update(model.Score) Then
                    Return RedirectToAction("Views", New With {.id = model.Score.CategoryId})
                End If
                ModelState.AddModelError("", "Error Updating Score")
            Else
                ModelState.AddModelError("", "Please fill out the required fields")
            End If

            Return View(model)
        End Function

        <Authorize(Roles:="Editor")>
        <HttpPost()>
        Public Function SDelete(ByVal id As Integer, ByVal catid As Integer) As ActionResult
            SR.Delete(SR.Scores.Where(Function(f) f.ScoreId = id).SingleOrDefault())
            Return RedirectToAction("Views", "Scores", New With {.[id] = catid})
        End Function

        <Authorize(Roles:="Editor")>
        <HttpPost()>
        Public Function DeletePicture(ByVal model As ScoreEditModel) As ActionResult
            PR.Delete(model.Score.PictureId)
            Return RedirectToAction("Edit", New With {.id = model.Score.ScoreId})
        End Function

        <Authorize(Roles:="Editor")>
        Public Function Views(Optional ByVal id As Integer = 0) As ActionResult
            Dim model As New ScoreInsertModel

            model.Categories = CR.CategoryListSorted

            If CR.CategoryById(id) IsNot Nothing Then
                'category exists
                model.CatSelected = id
            Else
                'find default category
                model.CatSelected = model.Categories.Select(Function(f) f.CategoryId).FirstOrDefault
            End If

            model.Scores = SR.Scores.Where(Function(f) f.Archived = False).Where(Function(f) f.Category.CategoryId = model.CatSelected).OrderByDescending(Function(f) f.DateAchieved).ToList

            Return View(model)
        End Function

        <Authorize(Roles:="Editor")>
        <HttpPost()>
        Public Function Views(ByVal id As Integer, ByVal pb As Boolean) As ActionResult
            'redirect to user friendly url
            Return RedirectToAction("Views", "Scores", New With {.id = id})
        End Function

        Public Function ViewPages(Optional ByVal id As Integer = 0) As ActionResult
            Dim model As New ScoreHonorModel

            Dim table As New List(Of ScoreHonorModel.Dictionary)
            For Each itm As Core.CategoryRepository.SPageInstances In CR.PageInstances
                table.Add(New ScoreHonorModel.Dictionary(itm.Name, itm.value))
            Next
            model.page_data = table

            model.page_selected = id
            If id = 0 Then
                model.page_selected = table.Item(0).Value
            End If

            model.cats = CR.ForPage(model.page_selected)
            'select scores by page and not archived
            model.scores = SR.Scores.Where(Function(f) f.Category.PageNum = model.page_selected).Where(Function(f) f.Archived = False).OrderBy(Function(f) f.Category.SortOrder).OrderByDescending(Function(f) f.DateAchieved).ToList

            Return View(model)
        End Function

        Public Function Honors(Optional ByVal id As Integer = 0) As ActionResult
            Dim model As New ScoreHonorModel

            Dim table As New List(Of ScoreHonorModel.Dictionary)
            For Each itm As Core.CategoryRepository.SPageInstances In CR.PageInstances
                table.Add(New ScoreHonorModel.Dictionary(itm.Name, itm.value))
            Next
            model.page_data = table

            model.page_selected = id
            If id = 0 Then
                model.page_selected = table.Item(0).Value
            End If

            model.cats = CR.ForPage(model.page_selected)
            'select scores by page and not archived
            model.scores = SR.Scores.Where(Function(f) f.Category.PageNum = model.page_selected).Where(Function(f) f.Archived = False).OrderBy(Function(f) f.Category.SortOrder).OrderByDescending(Function(f) f.DateAchieved).ToList

            Return View(model)
        End Function

        <HttpPost()>
        Public Function ViewPages(ByVal id As Integer, ByVal pb As Boolean) As ActionResult
            'redirect to user friendly url
            Return RedirectToAction("ViewPages", "Scores", New With {.id = id})
        End Function

        Public Property params As List(Of ScoreSearchModel.SearchParameter)
            Get
                If TempData("params") IsNot Nothing Then
                    Return TempData("params")
                Else
                    Return New List(Of ScoreSearchModel.SearchParameter)
                End If
            End Get
            Set(value As List(Of ScoreSearchModel.SearchParameter))
                TempData("params") = value
            End Set
        End Property

        Public Function Search() As ActionResult
            Dim SSM As New ScoreSearchModel
            SSM.SearchItems = params
            Return View(SSM)
        End Function

        <HttpPost()>
        Public Function Search(ByVal model As ScoreSearchModel)
            model.SearchItems = params

            If model.SearchItems.Count > 0 Then
                'generate sql
                Dim SB As New StringBuilder()
                For Each itm In model.SearchItems
                    SB.Append(" " & itm.key.Value & " " & String.Format(itm.criteria.Value, itm.value) & " AND")
                Next
                Dim sql As String = SB.ToString
                sql = sql.Substring(0, sql.Length - 3)
                model.Scores = SR.SearchSQL(sql)

                For Each score In model.Scores
                    Dim lscore = score
                    score.Category = CR.CategoryById(lscore.CategoryId)
                    score.Picture = PR.Pictures.Where(Function(f) f.PictureId = lscore.PictureId).SingleOrDefault
                Next
            Else
                ModelState.AddModelError("", "Search info not found")
            End If

            Return View(model)
        End Function

        <HttpPost()>
        Public Function SearchAdd(ByVal model As ScoreSearchModel, ByVal key As String, ByVal opt As String, ByVal val As String) As ActionResult
            model.SearchItems = params

            Dim ssm As New ScoreSearchModel.SearchParameter
            Dim itmk = ScoreSearchModel.SearchPrameters.Where(Function(f) f.Value = key).Single
            ssm.key = New DictionaryEntry(itmk.Key.Replace("'", ""), itmk.Value)
            ssm.value = val
            Dim itm = ScoreSearchModel.SearchCriteria.Where(Function(f) f.Value = opt).Single
            ssm.criteria = New DictionaryEntry(itm.Key, itm.Value)

            model.SearchItems.Add(ssm)
            params = model.SearchItems

            Return RedirectToAction("Search")
        End Function

        <HttpPost()>
        Public Function SearchDelete(ByVal model As ScoreSearchModel, ByVal index As Integer) As ActionResult
            model.SearchItems = params

            model.SearchItems.RemoveAt(index)

            params = model.SearchItems

            Return RedirectToAction("Search")
        End Function

        <Authorize404(Roles:="Manager")>
        Public Function NewSeason() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        <Authorize404(Roles:="Manager")>
        Public Function NewSeason(ByVal StartNewSeason As Boolean) As ActionResult
            If StartNewSeason Then
                'new season
                If Not SR.Archive() Then
                    ModelState.AddModelError("", "Error Archiving Scores")
                    Return View()
                End If
            Else
                ModelState.AddModelError("", "Please Accept the Terms")
                Return View()
            End If

            Return RedirectToAction("Views")
        End Function

        <Authorize(Roles:="Editor")>
        Public Function CDEImport() As ActionResult
            Dim model As New CDEImportModel



            Return View(model)
        End Function

        <Authorize404(Roles:="Manager")>
        <HttpPost()>
        Public Function CDEImport(ByVal model As CDEImportModel) As ActionResult

            Return View("CDEImport", model)
        End Function

        <Authorize(Roles:="Editor")>
        <HttpPost()>
        Public Function CDEUpload(ByVal model As CDEImportModel, ByVal file As HttpPostedFileBase) As ActionResult

            Return View("CDEImport", model)
        End Function


        <Authorize404(Roles:="Manager")>
        Public Function CDEConfig() As ActionResult
            Dim model As New CDEConfigModel



            Return View(model)
        End Function

        <Authorize404(Roles:="Manager")>
        <HttpPost()>
        Public Function CDEConfig(ByVal model As CDEConfigModel) As ActionResult

            Return CDEConfig()
        End Function

    End Class
End Namespace
