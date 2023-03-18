@Code
    Layout = "~/Views/Shared/_Root.vbhtml"
End Code

<table border="0" cellpadding="0" cellspacing="0" style="margin-top:10px;">
    <tr>
        <td class="onecolumn_left">
            @Html.Action("Links", "Common")
            <div class="clear" />
            @If IsSectionDefined("left_extras") Then
                @RenderSection("left_extras")
            End If
        </td>
        <td class="onecolumn_center">
            @RenderBody()
        </td>
    </tr>
    <tr>
        <td />
        <td class="onecolumn_center_footer">&nbsp;</td>
    </tr>
</table>