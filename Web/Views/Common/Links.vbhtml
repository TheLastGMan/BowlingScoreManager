<div class="modbody">
    <div class="modtop">
        Links
    </div>
    <div class="modbody">
        <div class="links">
            <ul>
                <li>@Html.ActionLink("Home", "Index", "Home")</li>
                @If Not User.Identity.IsAuthenticated Then
                    'user not logged
                    @<li>@Html.ActionLink("Log In", "LogIn", "Account")</li>
                    @<li>@Html.ActionLink("Register", "Register", "Account")</li>
                Else
                    @<li>@Html.ActionLink("Log Out", "LogOut", "Account")</li>
                    @<li>@Html.ActionLink("Scores", "Views", "Scores")</li>
                End If
                <li>@Html.ActionLink("Search", "Search", "Scores")</li>
                <li>@Html.ActionLink("Honor Scores", "ViewPages", "Scores")</li>
                @If User.Identity.IsAuthenticated Then
                    If User.IsInRole("Reporter") Then
                        @<li>@Html.ActionLink("Reports", "", "Report")</li>
                    End If
                    If User.IsInRole("Manager") Then
                        @<li>@Html.ActionLink("Manage Users", "Users", "Manage")</li>
                        @<li>@Html.ActionLink("Manage Categories", "Cats", "Manage")</li>
                    End If
                    If User.IsInRole("Configurer") Then
                        @<li>@Html.ActionLink("Configuration", "", "Config")</li>
                    End If
                End If

            </ul>
        </div>
    </div>
</div>