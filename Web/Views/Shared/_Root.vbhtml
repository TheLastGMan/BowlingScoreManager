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
    <div class="master_column">
        @Html.Partial("Header")
        @RenderBody()
        @Html.Action("Footer", "Common")
    </div>
</body>
</html>
