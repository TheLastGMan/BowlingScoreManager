@ModelType RPGCor.Web.UEditModel
    
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

@Using Html.BeginForm()
@<div><h1>@Model.user.FirstName @Model.user.LastName's Information</h1></div>
@<table width="100%">
    <tr style="vertical-align:top;">
        <td style="width:50%;">
            <table class="Grid" width="100%" cellspacing="0">
                <thead>
                    <tr class="Header">
                        <td colspan="2">Roles</td>
                    </tr>
                </thead>
                <tbody>
                    @(Html.HiddenFor(Function(m) m.edit_id))
                    @For i As Integer = 1 To Model.URoles.Count
                        Dim row As Integer = i - 1
                        Dim role As String = Model.URoles(row)
                        @<tr class="@IIf(i mod 2, "Row", "AltRow")">
                            @Html.HiddenFor(Function(f) f.URoles(row), New With {.id = role, .name = .id, .for = .id})
                            <td style="text-align:right; width:50%;">@role :&nbsp;</td>
                            <td style="text-align:left;">
                                @If Not Model.user.Username = User.Identity.Name Then
                                    @Html.CheckBoxFor(Function(m) m.UIRoles(row), New With {.id = role, .name = .id, .for = .id})
                                Else
                                    @<span>@IIf(model.UIRoles(row),"Yes","No")</span>
                                End If
                            </td>
                        </tr>
                    Next
                </tbody>
                <tfoot>
                    <tr class="Footer">
                        <td colspan="2">
                            @If Not Model.user.Username = User.Identity.Name Then
                                @<input type="submit" value="Save" class="button-green" />@Html.Raw("&nbsp;&nbsp;&nbsp;")
                            End If
                            <input type="submit" value="Cancel" id="cancel_button" form="cancel_form" class="button-green" />
                        </td>
                    </tr>
                </tfoot>
            </table>   
        </td>
        <td>
            <table class="Grid" width="100%" cellspacing="0">
                <thead>
                    <tr class="Header">
                        <td colspan="2">Profile</td>
                    </tr>                
                </thead>
                <tbody>
                    <tr class="Row">
                        <td style="text-align:right; width:50%;">First Name :&nbsp;</td>
                        <td style="text-align:left;">@Model.user.FirstName</td>
                    </tr>
                    <tr class="AltRow">
                        <td style="text-align:right;">Last Name :&nbsp;</td>
                        <td style="text-align:left;">@model.user.LastName</td>
                    </tr>
                    <tr class="Row">
                        <td style="text-align:right;">E-Mail :&nbsp;</td>
                        <td style="text-align:left;">@model.user.EMail</td>
                    </tr>
                    <tr class="AltRow">
                        <td style="text-align:right;">Username :&nbsp;</td>
                        <td style="text-align:left;">@model.user.Username</td>
                    </tr>
                    <tr class="Row">
                        <td style="text-align:right;">Active :&nbsp;</td>
                        <td style="text-align:left;">@IIf(Model.user.Active, "Yes", "No")</td>
                    </tr>
                    <tr class="AltRow">
                        <td style="text-align:right;">Locked Out :&nbsp;</td>
                        <td style="text-align:left;">@IIf(model.user.LockedOut, "Yes", "No")</td>
                    </tr>
                    <tr class="Row">
                        <td style="text-align:right;">Last Login :&nbsp;</td>
                        <td style="text-align:left;">@model.user.LastLogin</td>
                    </tr>
                    <tr class="AltRow">
                        <td style="text-align:right;">Registered :&nbsp;</td>
                        <td style="text-align:left;">@model.user.Registered</td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr class="Footer">
                        <td colspan="2">&nbsp;</td>
                    </tr>
                </tfoot>
            </table>
        </td>
    </tr>
</table>
End Using
@Using Html.BeginForm("Users", "Manage", Nothing, FormMethod.Get, New With {.[id] = "cancel_form"})
    
End Using