@ModelType RPGCor.Web.ScoreInsertModel

@section left_extras
<div class="clear">&nbsp;</div>
<div class="modbody">
    <script type="text/javascript">
        $(function () {
            $("#catid_dd").change(function () {
                $("#id").val($(this).attr("value"));
                $(this).parents('form').submit();
            });
        });
    </script>
    <div class="modtop">
        Options
    </div>
    <div class="modbody" style="text-align:center;">
        <p style="vertical-align:middle;">
        @Using Html.BeginForm()
            @Html.Hidden("id", Model.CatSelected)
            @Html.Hidden("pb", True)
            @<span>View Category</span>
            @Html.DropDownList("catid_dd", New SelectList(Model.Categories, "CategoryId", "CatName", Model.CatSelected), New With {.[style] = "width:125px; margin:auto;"})
            End Using
        </p>
        <p>
            @Using Html.BeginForm("Add", "Scores", nothing, FormMethod.Get)
                @<input type="submit" value="Add Score" class="button-blue" />
            End Using
        </p>
        @If User.IsInRole("Manager") Then
            @<p>
                @Using Html.BeginForm("NewSeason", "Scores", nothing, FormMethod.Get)
                    @<input type="submit" value="New Season" class="button-blue" />
                End Using
            </p>
        End If
    </div>
</div>
End Section

@Html.Partial("_ScoreList", New RPGCor.Web.ScoreListModel With {.Category = Model.Categories.Where(Function(f) f.CategoryId = Model.CatSelected).SingleOrDefault(), .Scores = Model.Scores, .EnableEdit=True})