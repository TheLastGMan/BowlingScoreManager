Imports System.Web.Mvc
Imports System.Web.Routing

Public Class RouteProvider : Implements Core.IRouteProvider

    Public ReadOnly Property Priority As Integer Implements Core.IRouteProvider.Priority
        Get
            Return 0
        End Get
    End Property

    Public Sub RegisterRoutes(ByRef routes As System.Web.Routing.RouteCollection) Implements Core.IRouteProvider.RegisterRoutes

        routes.MapRoute("RPGCor.Reports.WeeklyReport", _
                        "Reports/Weekly/{action}", _
                        New With {.controller = "Weekly", .action = "{action}"}, _
                        New String() {"RPGCor.Reports.WeeklyReport"} _
                        )

    End Sub
End Class
