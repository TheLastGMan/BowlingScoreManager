@ModelType RPGCor.Web.InstallModel
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div style="text-align:center;">
        <table border="0" cellspacing="0" width="80%" style="margin:auto; text-align:left;">
            <tr>
                <td style="text-align:right; width:50%;">
                    @Html.LabelFor(Function(m) m.User.FirstName) :&nbsp;
                </td>
                <td>
                    @Html.EditorFor(Function(m) m.User.FirstName) :&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    @Html.LabelFor(Function(m) m.User.LastName) :&nbsp;
                </td>
                <td>@Html.EditorFor(Function(m) m.User.LastName)</td>
            </tr>
        </table>
    </div>
</body>
</html>
