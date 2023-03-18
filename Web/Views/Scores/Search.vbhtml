@ModelType rpgcor.Web.ScoreSearchModel

@code
    TempData("params") = Model.SearchItems
    Dim i As Integer = 0
End Code

<table class="Grid" cellspacing="0" cellpadding="2">
    <thead class="Header">
        <tr>
            <td colspan="4">Search Scores</td>
        </tr>
        <tr>
            <td>Parameter</td>
            <td>Condition</td>
            <td>Value</td>
            <td>Action</td>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model.SearchItems
            Using Html.BeginForm("SearchDelete", "Scores")
                @Html.Hidden("index", i)
                i += 1
                @<tr class="@IIf(i mod 2, "Row", "AltRow")">
                    <td>@IIf(i > 1, "and", "") @(item.key.Key)</td>
                    <td>@(item.criteria.Key)</td>
                    <td>@(item.value)</td>
                    <td><input type="submit" value="Delete" class="button-blue" /></td>
                </tr>
            End Using
        Next
    </tbody>
    <tfoot>
        <tr class="Footer">
            @Using Html.BeginForm("SearchAdd", "Scores")
                @<td>
                    @Html.DropDownList("key", New SelectList(RPGCor.Web.ScoreSearchModel.SearchPrameters, "Value", "Key"), New With {.[style] = "width:125px;"})
                </td>
                @<td>
                    @Html.DropDownList("opt", New SelectList(RPGCor.Web.ScoreSearchModel.SearchCriteria, "Value", "Key"), New With {.[style] = "width:125px;"})
                </td>
                @<td>
                    @Html.TextBox("val", "", New With {.[style] = "width:125px;"})
                </td>
                @<td>
                    <input type="submit" value="Add" class="button-green" />
                </td>                
            End Using
        </tr>
        <tr class="Footer">
            <td colspan="4">
                @Using Html.BeginForm()
                    @<input type="submit" value="search" class="button-green" />
                End Using
            </td>
        </tr>    
    </tfoot>
</table>
<br />
@For Each cat As RPGCor.Core.Entity.Category In Model.Scores.Select(Function(f) f.Category).Distinct()
    Dim lcat As RPGCor.Core.Entity.Category = cat
    @Html.Partial("_ScoreList", New RPGCor.Web.ScoreListModel With {.Category = lcat, .Scores = Model.Scores.Where(Function(f) f.CategoryId = lcat.CategoryId).Take(lcat.PerPage).ToList})
Next
