@ModelType RPGCor.Web.ScoreEditModel

<script type="text/javascript">
    $(function () {
        $("#Score_Game1").change(function () {
            AddScores($(this).val(), $("#Score_Game2").val(), $("#Score_Game3").val());
        });
        $("#Score_Game2").change(function () {
            AddScores($("#Score_Game1").val(), $(this).val(), $("#Score_Game3").val());
        });
        $("#Score_Game3").change(function () {
            AddScores($("#Score_Game1").val(), $("#Score_Game2").val(), $(this).val());
        });
        $("#NewScore_HDCPSeries").change(function () {
            if ($(this).val() < parseInt($("#series").html())) {
                $(this).val(parseInt($("#series").html()));
            }
        });
        $("#cancel_button").click(function (event) {
            if ($.browser.msie) {
                event.preventDefault();
                $("#" + $(this).attr("form")).submit();
            }
        });
        $("#delete_button").click(function (event) {
            if ($.browser.msie) {
                event.preventDefault();
                $("#" + $(this).attr("form")).submit();
            }
        });
    });
    function AddScores(x, y, z) {
        var total = parseInt(x) + parseInt(y) + parseInt(z);
        $("#series").html(total);
        var hdcps = $("#Score_HDCPSeries");
        if (hdcps.val() < total) {
            hdcps.val(total);
        };
    };
</script>

@Using Html.BeginForm
    @<table class="Grid" cellspacing="0">
        <thead>
            <tr class="Header">
                <td colspan="2" style="text-align:center;">Score Info</td>
            </tr>
        </thead>
        <tbody>
            @With Model.Score
                @Html.HiddenFor(Function(f) f.Score.ScoreId)
                @<tr class="Row">
                    @Html.HiddenFor(Function(f) f.Score.CategoryId)
                    <td style="text-align:right; width:50%;">Category :&nbsp;</td>
                    <td style="text-align:left;">@model.Score.Category.CatName</td>
                    @Html.HiddenFor(Function(f) f.Score.Category.CatName)
                </tr>
                @<tr class="AltRow">
                    @Html.HiddenFor(Function(f) f.Score.PictureId)
                    <td style="text-align:right;">Picture :&nbsp;</td>
                    <td style="text-align:left;">
                        <img style="width:90%; margin-left:18px;" src="@Url.Action("GetImage", "Common", New With {.[id] = Model.Score.PictureId})" alt="" /><br />
                        <input type="file" id="file" name="file" for="file" />
                    </td>
                </tr>
                @<tr class="Row">
                    <td style="text-align:right;">First Name :&nbsp;</td>
                    <td style="text-align:left;">
                        @If .Editable And Not .Archived Then
                            @Html.TextBoxFor(Function(f) f.Score.FName, New With {.[placeholder] = "First Name"}) 
                        Else
                            @(.FName)
                        End If
                    </td>
                </tr>
                @<tr class="AltRow">
                    <td style="text-align:right;">Last Name :&nbsp;</td>
                    <td style="text-align:left;">
                        @If .Editable And Not .Archived Then
                            @Html.TextBoxFor(Function(f) f.Score.LName, New With {.[placeholder] = "Last Name"})        
                        Else
                            @(.LName) 
                        End If
                    </td>
                </tr>
                @<tr class="Row">
                    <td style="text-align:right;">League :&nbsp;</td>
                    <td style="text-align:left;">
                        @If .Editable And Not .Archived Then
                            @Html.TextBoxFor(Function(f) f.Score.League, New With {.[placeholder] = "League"})  
                        Else
                            @(.League)
                        End If
                    </td>
                </tr>
                @<tr class="AltRow">
                    <td style="text-align:right;">Date :&nbsp;</td>
                    <td style="text-align:left;">
                        @If .Editable And Not .Archived Then
                            @Html.TextBoxFor(Function(f) f.Score.DateAchieved, New With {.[type] = "date", .[placeholder] = "yyyy-mm-dd"}) 
                        Else
                            @(.DateAchieved.ToShortDateString)
                        End If
                    </td>
                </tr>
                @<tr class="Row">
                    <td style="text-align:right;">Game 1 :&nbsp;</td>
                    <td style="text-align:left;">
                        @If .Editable And Not .Archived Then
                            @Html.TextBoxFor(Function(f) f.Score.Game1, New With {.[style] = "width:125px;", .[type] = "number", .[min] = "0", .[max] = "300"})   
                        Else
                            @(.Game1)
                        End If 
                    </td>
                </tr>
                @<tr class="AltRow">
                    <td style="text-align:right;">Game 2 :&nbsp;</td>
                    <td style="text-align:left;">
                        @If .Editable And Not .Archived Then
                            @Html.TextBoxFor(Function(f) f.Score.Game2, New With {.[style] = "width:125px;", .[type] = "number", .[min] = "0", .[max] = "300"})  
                        Else
                            @(.Game2)    
                        End If
                    </td>
                </tr>
                @<tr class="Row">
                    <td style="text-align:right;">Game 3 :&nbsp;</td>
                    <td style="text-align:left;">
                        @If .Editable And Not .Archived Then
                            @Html.TextBoxFor(Function(f) f.Score.Game3, New With {.[style] = "width:125px;", .[type] = "number", .[min] = "0", .[max] = "300"})
                        Else
                            @(.Game3)
                        End If
                    </td>
                </tr>
                @<tr class="AltRow">
                    <td style="text-align:right;">Series :&nbsp;</td>
                    <td style="text-align:left;">
                        <span id="series">@Model.Score.Series</span>
                    </td>
                </tr>
                @<tr class="Row">
                    <td style="text-align:right;">HDCP Series :&nbsp;</td>
                    <td style="text-align:left;">
                        @If .Editable And Not .Archived Then
                            @Html.TextBoxFor(Function(f) f.Score.HDCPSeries, New With {.[style] = "width:125px;", .[type] = "number", .[min] = "0", .[max] = "1200"})
                        Else
                            @(.HDCPSeries)
                        End If
                    </td>
                </tr>
                @Html.HiddenFor(Function(f) f.score.Editable)
                @Html.HiddenFor(Function(f) f.Score.Archived)
            End With
        </tbody>
        <tfoot>
            <tr class="Footer">
                <td colspan="2">
                    <input type="submit" value="Save" class="button-green" />&nbsp;&nbsp;&nbsp;
                    <input type="submit" id="cancel_button" form="cancel_form" value="Cancel" class="button-green" />&nbsp;&nbsp;&nbsp;
                    <input type="submit" id="delete_button" form="delete_form" value="Delete" class="button-green" /> 
                </td>
            </tr>
        </tfoot>
    </table>
 End Using
 @Using Html.BeginForm("Views", "Scores", New With {.[id] = Model.Score.CategoryId}, FormMethod.Get, New With {.[id] = "cancel_form"})
     
 End Using
 @Using Html.BeginForm("SDelete", "Scores", New With {.[id] = Model.Score.ScoreId, .[catid]=Model.Score.CategoryId}, FormMethod.Post, New With {.[id] = "delete_form"})
     
 End Using