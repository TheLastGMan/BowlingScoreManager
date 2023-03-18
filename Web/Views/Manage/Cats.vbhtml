@ModelType RPGCor.Web.CategoryModel
    
<script type="text/javascript">
    $(function () {
        $("#cancel_button").click(function (event) {
            if ($.browser.msie) {
                event.preventDefault();
                $("#" + $(this).attr("form")).submit();
            }
        });
    });
</script>

<table border="1" cellspacing="0" class="Grid">
    <thead class="Header">
        <tr>
            <td colspan="11">Categories</td>
        </tr>
        <tr>
            <td>Category</td>
            <td>Picture</td>
            <td>Game 1</td>
            <td>Game 2</td>
            <td>Game 3</td>
            <td>Series</td>
            <td>HDCP Series</td>
            <td>Date</td>
            <td>Page</td>
            <td>Order</td>
            <td>Limit</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.cats.Count
            Dim row As Integer = i - 1
            With Model.cats(row)
                If Not .CategoryId = Model.edit_id Then
                    @<tr class="@IIf(i Mod 2, "Row", "AltRow")">
                        <td>@Html.ActionLink(.CatName, "CEdit", New With {.id = Model.cats(row).CategoryId})</td>
                        <td>@IIf(.ShowPicture, "Yes", "No")</td>
                        <td>@IIf(.ShowGame1, "Yes", "No")</td>
                        <td>@IIf(.ShowGame2, "Yes", "No")</td>
                        <td>@IIf(.ShowGame3, "Yes", "No")</td>
                        <td>@IIf(.ShowSeries, "Yes", "No")</td>
                        <td>@IIf(.ShowHDCPSeries, "Yes", "No")</td>
                        <td>@IIf(.ShowDateAchieved, "Yes", "No")</td>
                        <td>@Html.Label(.PageNum)</td>
                        <td>@Html.Label(.SortOrder)</td>
                        <td>@Html.Label(.PerPage)</td>
                    </tr>
                Else
                    @<tr class="Edit">
                        @Using Html.BeginForm("CUpdate", "Manage")
                            @<td>
                                @Html.Hidden("CategoryId", .CategoryId)
                                @Html.TextBox("CatName", .CatName)<br />
                                <input type="submit" value="Update" class="button-green" />
                            </td>
                            @<td>@Html.CheckBox("ShowPicture", .ShowPicture)</td>
                            @<td>@Html.CheckBox("ShowGame1", .ShowGame1)</td>
                            @<td>@Html.CheckBox("ShowGame2", .ShowGame2)</td>
                            @<td>@Html.CheckBox("ShowGame3", .ShowGame3)</td>
                            @<td>@Html.CheckBox("ShowSeries", .ShowSeries)</td>
                            @<td>@Html.CheckBox("ShowHDCPSeries", .ShowHDCPSeries)</td>
                            @<td>@Html.CheckBox("ShowDateAchieved", .ShowDateAchieved)</td>
                            @<td>@Html.TextBox("PageNum", .PageNum, New With {.[style] = "width:25px;", .[min] = "1", .[type]="number"})</td>
                            @<td>@Html.TextBox("SortOrder", .SortOrder, New With {.[style] = "width:25px;", .[min] = "1", .[type]="number"})</td>
                            @<td>@Html.TextBox("PerPage", .PerPage, New With {.[style] = "width:25px;", .[min] = "1", .[type]="number"})</td>
                        End Using
                    </tr>
                    @<tr class="Edit">
                        <td colspan="12">
                            @Using Html.BeginForm("CDelete", "Manage")
                                @Html.Hidden("id", .CategoryId)
                                @<input type="submit" value="Delete" class="button-green" />
                                @<span>&nbsp;&nbsp&nbsp;</span>
                                @<input type="submit" id="cancel_button" form="cancel_form" value="Cancel" class="button-green" />
                            End Using
                        </td>
                    </tr>
                End If
            End With
        Next
    </tbody>
    <tfoot>
        @Using Html.BeginForm("Cats", "Manage")
            @<tr class="Footer">
                <td>@Html.TextBoxFor(function(f) f.new_cat.CatName)</td>
                <td>@Html.CheckBoxFor(function(f) f.new_cat.ShowPicture)</td>
                <td>@Html.CheckBoxFor(function(f) f.new_cat.ShowGame1)</td>
                <td>@Html.CheckBoxFor(function(f) f.new_cat.ShowGame2)</td>
                <td>@Html.CheckBoxFor(function(f) f.new_cat.ShowGame3)</td>
                <td>@Html.CheckBoxFor(function(f) f.new_cat.ShowSeries)</td>
                <td>@Html.CheckBoxFor(function(f) f.new_cat.ShowHDCPSeries)</td>
                <td>@Html.CheckBoxFor(function(f) f.new_cat.ShowDateAchieved)</td>
                <td>@Html.TextBoxFor(Function(f) f.new_cat.PageNum, New With {.[style] = "width:25px;", .[type] = "number", .[min] = "0"})</td>
                <td>@Html.TextBoxFor(Function(f) f.new_cat.SortOrder, New With {.[style] = "width:25px;", .[type] = "number", .[min] = "0"})</td>
                <td>@Html.TextBoxFor(Function(f) f.new_cat.PerPage, New With {.[style] = "width:25px;", .[type] = "number", .[min] = "0"})</td>
            </tr>
            @<tr class="Footer">
                <td colspan="12"><input type="submit" value="Add" class="button-green" /></td>
            </tr>
        End Using
    </tfoot>
</table>
@Using Html.BeginForm("Cats", "Manage", Nothing, FormMethod.Get, New With {.[id] = "cancel_form"})
    
End Using