Imports System.Web.Mvc

Public Class ReportsController : Inherits Controller

    Function Index() As ActionResult

        Return View("RPGCor.Reports.PreBowlScores.Index")
    End Function

End Class
