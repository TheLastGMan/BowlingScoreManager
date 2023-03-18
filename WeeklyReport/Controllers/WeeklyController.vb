Public Class WeeklyController : Inherits Web.Mvc.Controller

    Public Function Show() As Web.Mvc.ActionResult
        Dim model As New Model.ReportModel



        Return View("RPGCor.Reports.WeeklyReport.Show", model)
    End Function

End Class