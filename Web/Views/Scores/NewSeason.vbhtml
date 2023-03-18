<h1>New Season</h1>

The Following Action Will :
<ul style="width:50%; text-align:left; margin:10px auto;">
    <li><i>Archive</i> all scores for the Current Season</li>
    <li><i>Clear all Honor Scores</i></li>
    <li><i>Scores will still be searchable</i></li>
    <li><i><b>This Actions Can Not Be Undone</b></i></li>
</ul>

@Using Html.BeginForm
    @Html.CheckBox("StartNewSeason", False) @<span>I Agree</span>@<br />
    @<input type="submit" value="Start Season" class="button-green" style="margin-top:5px;" />
End Using

<br />
@Html.ValidationSummary