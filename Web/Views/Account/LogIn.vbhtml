@ModelType RPGCor.Web.LoginModel

@Using Html.BeginForm()
    @<div class="login">
        <table class="Grid" style="width:480px;" cellspacing="0">
            <thead>
                <tr>
                    <td colspan="2" class="Header">
                        @Html.LabelForModel()
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr class="Row">
                    <td style="text-align:right; width:50%;">
                        @Html.LabelFor(Function(m) m.Username) :&nbsp;
                    </td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(m) m.Username, New With {.[class] = "textbox", .[placeholder] = "UserName"})
                    </td>
                </tr>
                <tr class="AltRow">
                    <td style="text-align:right;">
                        @Html.LabelFor(Function(m) m.Password) :&nbsp;
                    </td>
                    <td style="text-align:left;">
                        @Html.PasswordFor(Function(m) m.Password, New With {.[class] = "textbox", .[placeholder] = "Password"})
                    </td>
                </tr>
                <tr class="Row">
                    <td colspan="2">
                        @Html.LabelFor(Function(m) m.RememberMe) @Html.CheckBoxFor(Function(m) m.RememberMe)
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr class="Footer">
                    <td colspan="2">
                        <button type="submit" class="button-green">Log On</button>
                    </td>
                </tr>
            </tfoot>
        </table>
        @Html.ValidationSummary()
    </div>
End Using
