Public Class Authorize404Attribute : Inherits AuthorizeAttribute

    Public Overrides Sub OnAuthorization(filterContext As System.Web.Mvc.AuthorizationContext)
        If filterContext.HttpContext.User.Identity.IsAuthenticated AndAlso New Core.RoleProvider().GetRolesForUser(filterContext.HttpContext.User.Identity.Name).Intersect(Roles.Split(",")).Count > 0 Then
            'authorized, no need to do anything
        Else
            filterContext.Result = New HttpNotFoundResult("404")
        End If

    End Sub

End Class
