Imports System.Web.Hosting

' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.IgnoreRoute("favicon.ico")

        Dim rp As New Core.RoutePublisher()
        rp.RegisterRoutes(routes)

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}, _
            New String() {"RPGCor.Web"} _
        )

    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)

        Dim embeddedViewResolver = New Core.EmbeddedViewResolver
        Dim embeddedProvider = New Core.EmbeddedViewVirtualPathProvider(embeddedViewResolver.GetEmbeddedViews)
        HostingEnvironment.RegisterVirtualPathProvider(embeddedProvider)

    End Sub
End Class
