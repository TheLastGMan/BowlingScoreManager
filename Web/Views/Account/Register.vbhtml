@ModelType RPGCor.Web.RegisterModel

@Using Html.BeginForm()
    @<div class="register">
        <table class="Grid" cellspacing="0" style="width:480px;">
            <thead>
                <tr>
                    <td class="Header" colspan="2">@Html.LabelForModel</td>
                </tr>
            </thead>
            <tbody>
                <tr class="Row">
                    <td style="text-align:right; width:50%;">
                        @Html.LabelFor(Function(m) m.FirstName) :&nbsp;
                    </td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(m) m.FirstName, New With {.[placeholder] = "First Name"})
                    </td>
                </tr>
                <tr class="AltRow">
                    <td style="text-align:right;">
                        @Html.LabelFor(Function(m) m.LastName) :&nbsp;
                    </td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(m) m.LastName, New With {.[placeholder] = "Last Name"})
                    </td>
                </tr>
                <tr class="Row">
                    <td style="text-align:right;">
                        @Html.LabelFor(Function(m) m.email) :&nbsp;
                    </td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(m) m.email, New With {.[type]="email", .[placeholder]="EMail"})
                    </td>
                </tr>
                <tr class="AltRow">
                    <td style="text-align:right;">
                        @Html.LabelFor(Function(m) m.username) :&nbsp;
                    </td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(m) m.username, New With {.[placeholder] = "Username"})
                    </td>
                </tr>
                <tr class="Row">
                    <td style="text-align:right;">
                        @Html.LabelFor(Function(m) m.password) :&nbsp;
                    </td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(m) m.password, New With {.[type] = "password", .[placeholder] = "Password"})
                    </td>
                </tr>
                <tr class="AltRow">
                    <td style="text-align:right;">
                        @Html.LabelFor(Function(m) m.password_confirm) :&nbsp;
                    </td>
                    <td style="text-align:left;">
                        @Html.TextBoxFor(Function(m) m.password_confirm, New With {.[type]="password", .[placeholder]="Confirm"})
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="2" class="Footer">
                        <button type="submit" class="button-green" style="margin:auto;">Register</button>
                    </td>
                </tr>
            </tfoot>
        </table>
        @Html.ValidationSummary()
    </div>
End Using
