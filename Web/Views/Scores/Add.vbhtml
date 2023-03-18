@ModelType RPGCor.Web.ScoreInsertModel

<script type="text/javascript">
    $(function () {
        $("#NewScore_Game1").change(function () {
            AddScores($(this).val(), $("#NewScore_Game2").val(), $("#NewScore_Game3").val());
        });
        $("#NewScore_Game2").change(function () {
            AddScores($("#NewScore_Game1").val(), $(this).val(), $("#NewScore_Game3").val());
        });
        $("#NewScore_Game3").change(function () {
            AddScores($("#NewScore_Game1").val(), $("#NewScore_Game2").val(), $(this).val());
        });
        $("#NewScore_HDCPSeries").change(function () {
            if ($(this).val() < parseInt($("#series").html())) {
                $(this).val(parseInt($("#series").html()));
            }
        });
        $("#category").change(function () {
            //update category id
            $("#NewScore_CategoryId").val($(this).attr("value"));
        });
        $("#cancel_button").click(function (event) {
            if ($.browser.msie) {
                event.preventDefault();
                $("#" + $(this).attr("form")).submit();
            }
        });
    });
    function AddScores(x, y, z) {
        var total = parseInt(x) + parseInt(y) + parseInt(z);
        $("#series").html(total);
        var hdcps = $("#NewScore_HDCPSeries");
        if (hdcps.val() < total) {
            hdcps.val(total);
        };
    };
</script>

@Using Html.BeginForm("Add", "Scores", FormMethod.Post, New With {.[enctype]="multipart/form-data"})
    With Model.NewScore
        @<table class="Grid" cellspacing="0">
            <thead>
                <tr class="Header">
                    <td colspan="2" style="text-align:center;">Score Info</td>
                </tr>
            </thead>
            <tbody>
                <tr class="Row">
                    @Html.HiddenFor(Function(f) f.NewScore.CategoryId)
                    <td style="text-align:right; width:50%;">Category :&nbsp;</td>
                    <td style="text-align:left;">@Html.DropDownList("category", New SelectList(Model.Categories, "CategoryId", "CatName", Model.CatSelected))</td>
                </tr>
                <tr class="AltRow">
                    @Html.HiddenFor(Function(f) f.NewScore.PictureId)
                    <td style="text-align:right;">Picture :&nbsp;</td>
                    <td style="text-align:left;">
                        <input type="file" id="file" for="file" name="file" />
                    </td>
                </tr>
                <tr class="Row">
                    <td style="text-align:right;">First Name :&nbsp;</td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(f) f.NewScore.FName, New With {.[placeholder] = "First Name"}) 
                    </td>
                </tr>
                <tr class="AltRow">
                    <td style="text-align:right;">Last Name :&nbsp;</td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(f) f.NewScore.LName, New With {.[placeholder] = "Last Name"})        
                    </td>
                </tr>
                <tr class="Row">
                    <td style="text-align:right;">League :&nbsp;</td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(f) f.NewScore.League, New With {.[placeholder] = "League"})  
                    </td>
                </tr>
                <tr class="AltRow">
                    <td style="text-align:right;">Date :&nbsp;</td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(f) f.NewScore.DateAchieved, New With {.[type] = "date", .[placeholder]="yyyy-mm-dd", .[value]=Now.Year & "-" & Now.Month & "-" & Now.Day}) 
                    </td>
                </tr>
                <tr class="Row">
                    <td style="text-align:right;">Game 1 :&nbsp;</td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(f) f.NewScore.Game1, New With {.[style] = "width:125px;", .[type] = "number", .[min] = "0", .[max] = "300"})   
                    </td>
                </tr>
                <tr class="AltRow">
                    <td style="text-align:right;">Game 2 :&nbsp;</td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(f) f.NewScore.Game2, New With {.[style] = "width:125px;", .[type] = "number", .[min] = "0", .[max] = "300"})  
                    </td>
                </tr>
                <tr class="Row">
                    <td style="text-align:right;">Game 3 :&nbsp;</td>
                    <td style="text-align:left;">
                       @Html.TextBoxFor(Function(f) f.NewScore.Game3, New With {.[style] = "width:125px;", .[type] = "number", .[min] = "0", .[max] = "300"})
                    </td>
                </tr>
                <tr class="AltRow">
                    <td style="text-align:right;">Series :&nbsp;</td>
                    <td style="text-align:left;">
                        <span id="series">@Model.NewScore.Series</span>
                    </td>
                </tr>
                <tr class="Row">
                    <td style="text-align:right;">HDCP Series :&nbsp;</td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(f) f.NewScore.HDCPSeries, New With {.[style] = "width:125px;", .[type] = "number", .[min] = "0", .[max] = "1200"})
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr class="Footer">
                    <td colspan="2">
                        <input type="submit" value="Insert" class="button-green" />&nbsp;&nbsp;&nbsp;
                        <input type="submit" id="cancel_button" form="cancel_form" value="Cancel" class="button-green" />
                    </td>
                </tr>
            </tfoot>
        </table>
    End With
End Using
@Html.ValidationSummary
@Using Html.BeginForm("Views", "Scores", Nothing, FormMethod.Get, New With {.[id] = "cancel_form"})
    
End Using