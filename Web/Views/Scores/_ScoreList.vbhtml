@ModelType rpgcor.Web.ScoreListModel

@code
    Dim i As Integer = 0
    Dim lcat As RPGCor.Core.Entity.Category = Model.Category
End Code

<table border="1" cellspacing="0" class="Grid" style="margin:0 auto 15px auto;">
    <thead class="Header">
        <tr>
            <td colspan="9">@Model.Category.CatName</td>
        </tr>
        <tr>
            <td>Name</td>
            <td>League</td>
            @With Model.Category
                If .ShowPicture Then
                    @<td>Picture</td>
                End If
                If .ShowGame1 Then
                    @<td>Game 1</td>
                End If
                If .ShowGame2 Then
                    @<td>Game 2</td>
                End If
                If .ShowGame3 Then
                    @<td>Game 3</td>
                End If
                If .ShowSeries Then
                    @<td>Series</td>
                End If
                If .ShowHDCPSeries Then
                    @<td>HDCP Series</td>
                End If
                If .ShowDateAchieved Then
                    @<td>Date</td>
                End If
            End With
        </tr>
    </thead>
    <tbody>
        @For Each score As RPGCor.Core.Entity.Score In Model.Scores
            i += 1
            With score
                @<tr class="@IIf(i mod 2,"Row", "AltRow")">
                    <td>
                        @If Model.EnableEdit Then
                            @Html.ActionLink(.FullName, "Edit", New With {.[id] = score.ScoreId})
                        Else
                            @(.FullName)
                        End If
                    </td>
                    <td>@(.League)</td>
                    @If lcat.ShowPicture Then
                        @<td><img width="150" src="@Url.Action("GetImage", "Common", New With {.id = score.PictureId})" alt="" /></td>
                    End If
                    @If lcat.ShowGame1 Then
                        @<td>@(.Game1)</td>
                    End If
                    @If lcat.ShowGame2 Then
                        @<td>@(.Game2)</td>
                    End If
                    @If lcat.ShowGame3 Then
                        @<td>@(.Game3)</td>
                    End If
                    @If lcat.ShowSeries Then
                        @<td>@(.Series)</td>
                    End If
                    @If lcat.ShowHDCPSeries Then
                        @<td>@(.HDCPSeries)</td>
                    End If
                    @If lcat.ShowDateAchieved Then
                        @<td>@(String.Format("{0:MMM/dd/yyyy}", .DateAchieved))</td>
                    End If
                </tr>
            End With
        Next
    </tbody>
    <tfoot class="Footer">
        <tr>
            <td colspan="9">&nbsp;</td>
        </tr>
    </tfoot>
</table>