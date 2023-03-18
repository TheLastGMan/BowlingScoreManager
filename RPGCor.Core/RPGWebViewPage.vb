Imports System
Imports System.IO
Imports System.Web.Mvc
Imports System.Web.WebPages

Public MustInherit Class RPGWebViewPage(Of TModel) : Inherits WebViewPage(Of TModel)

    Public Overrides Sub InitHelpers()
        MyBase.InitHelpers()
    End Sub

    Public Overrides Property Layout As String
        Get

            Dim mylayout = MyBase.Layout

            If Not String.IsNullOrEmpty(mylayout) Then
                Dim filename = IO.Path.GetFileNameWithoutExtension(mylayout)
                Dim VER As ViewEngineResult = ViewEngines.Engines.FindView(ViewContext.Controller.ControllerContext, filename, "")

                If (VER.View IsNot Nothing AndAlso TypeOf (VER.View) Is RazorView) Then
                    mylayout = DirectCast(VER.View, RazorView).ViewPath
                End If
            End If

            Return mylayout
        End Get
        Set(value As String)
            MyBase.Layout = value
        End Set
    End Property

End Class

Public MustInherit Class RPGWebViewPage : Inherits WebViewPage(Of Object)

    Public Overrides Sub Execute()
        Dim y As String = ""
    End Sub

End Class
