Imports System.Web.Mvc
Imports System.Web.Routing

Public Class RouteProvider : Implements RPGCor.Core.IRouteProvider


    Public ReadOnly Property Priority As Integer Implements Core.IRouteProvider.Priority
        Get
            Return 0
        End Get
    End Property

    Public Sub RegisterRoutes(ByRef routes As System.Web.Routing.RouteCollection) Implements Core.IRouteProvider.RegisterRoutes

        routes.MapRoute("RPGCor.Reports.PreBowlScores.View", _
                        "Reports/PreBowls", _
                        New With {.controller = "Reports", .action = "Index"}, _
                        New String() {"RPGCor.Reports.PreBowlScores"})

    End Sub

End Class
