@ModelType RPGCor.Web.ScoreHonorModel
    
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>
<html>
<head>
    <title>@ViewData("Title")</title>
    <link href="@Url.Content("~/Content/" & ConfigurationManager.AppSettings("Theme") & "/Site.css")" rel="stylesheet" type="text/css" />
    <script src="@Url.Content("~/Scripts/jquery-1.8.0.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/modernizr-2.6.2.js")" type="text/javascript"></script>
</head>

<body>
    @For Each cat As RPGCor.Core.Entity.Category In Model.cats
        Dim lcat As RPGCor.Core.Entity.Category = cat
        @Html.Partial("_ScoreList", New RPGCor.Web.ScoreListModel With {.Category = lcat, .Scores = Model.scores.Where(Function(f) f.CategoryId = lcat.CategoryId).Take(lcat.PerPage).ToList})
     next
</body>
</html>
