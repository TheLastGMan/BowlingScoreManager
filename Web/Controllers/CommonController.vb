Namespace RPGCor.Web
    Public Class CommonController
        Inherits System.Web.Mvc.Controller

        <ChildActionOnly()>
        Function Footer() As ActionResult
            Return PartialView(New FooterModel())
        End Function

        <ChildActionOnly()>
        Function Links() As ActionResult
            Return PartialView()
        End Function

        Function GetImage(Optional ByVal id As Integer = 0) As FileContentResult
            If id = 0 Then
                'return transparent
                Return File(FileContents("~/images/transparent.gif"), "image/gif")
            End If

            'try and load file
            Dim Picture As Core.Entity.Picture = New Core.PictureRepository().Pictures.Where(Function(f) f.PictureId = id).SingleOrDefault()
            If Picture IsNot Nothing Then
                Return File(Picture.Data, Picture.Mime)
            End If

            'else return default image
            Return File(FileContents("~/images/default-avatar.gif"), "image/gif")
        End Function

        <NonAction()>
        Private Function FileContents(ByRef path As String) As Byte()
            Dim fp As String = Server.MapPath(path)
            Dim IOR As New IO.StreamReader(fp)
            Dim out As Byte() = New Byte(IOR.BaseStream.Length) {}
            IOR.BaseStream.Read(out, 0, IOR.BaseStream.Length)
            Return out
        End Function

    End Class
End Namespace
