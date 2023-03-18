Public Class RouteProvider : Implements Core.IRouteProvider

    Public ReadOnly Property Priority As Integer Implements Core.IRouteProvider.Priority
        Get
            Return 0
        End Get
    End Property

    Public Sub RegisterRoutes(ByRef routes As System.Web.Routing.RouteCollection) Implements Core.IRouteProvider.RegisterRoutes

        'Account
        routes.MapRoute("Web.LogIn", "LogIn", New With {.controller = "Account", .action = "LogIn"})
        routes.MapRoute("Web.LogOut", "LogOut", New With {.controller = "Account", .action = "LogOut"})
        routes.MapRoute("Web.Register", "Register", New With {.controller = "Account", .action = "Register"})

        'Scores
        routes.MapRoute("Web.ScoreSearch", "Search", New With {.controller = "Scores", .action = "Search"})

        'Honors
        routes.MapRoute("Web.Honors", "Honors/{id}", New With {.controller = "Scores", .action = "Honors", .id = UrlParameter.Optional})

    End Sub

End Class
