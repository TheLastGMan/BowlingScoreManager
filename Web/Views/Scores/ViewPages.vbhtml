@ModelType RPGCor.Web.ScoreHonorModel
    
@section left_extras
<div class="clear">&nbsp;</div>
<div class="modbody">
    <script type="text/javascript">
        $(function () {
            $("#pageid_dd").change(function () {
                $("#id").val($(this).attr("value"));
                $(this).parents('form').submit();
            });
        });
    </script>
    <div class="modtop">
        View Page
    </div>
    <div class="modbody" style="text-align:center;">
        <p style="vertical-align:middle;">
        @Using Html.BeginForm()
            @Html.Hidden("id", Model.page_selected)
            @Html.Hidden("pb", True)
            @Html.DropDownList("pageid_dd", New SelectList(Model.page_data, "Value", "Key", Model.page_selected), New With {.[style] = "width:125px; margin:auto;"})
        End Using
        </p>
    </div>
</div>
End Section
@For Each cat As RPGCor.Core.Entity.Category In Model.cats
    Dim lcat As RPGCor.Core.Entity.Category = cat
    @Html.Partial("_ScoreList", New RPGCor.Web.ScoreListModel With {.Category = cat, .Scores = Model.scores.Where(Function(f) f.CategoryId = lcat.CategoryId).Take(lcat.PerPage).ToList})
 next