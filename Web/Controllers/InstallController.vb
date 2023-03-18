Namespace RPGCor.Web
    Public Class InstallController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Install

        Function Index() As ActionResult
            'check if db is installed
            If IsDBInstalled() Then
                'redirect to homepage
                Return RedirectToAction("", "Home")
            End If

            'not installed
            Return View()
        End Function

        Private Function IsDBInstalled() As Boolean
            Return False
        End Function

    End Class
End Namespace
