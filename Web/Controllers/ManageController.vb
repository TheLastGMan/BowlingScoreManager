Namespace RPGCor.Web

    <Authorize404(Roles:="Manager")>
    <OutputCache(Duration:=0, NoStore:=True)>
    Public Class ManageController
        Inherits System.Web.Mvc.Controller

        Private UR As New Core.UserRepository()
        Private RR As New Core.RoleProvider()
        Private CR As New Core.CategoryRepository()

        Function Users() As ActionResult
            Return View(New UserModel() With {.UserList = UR.GetAll(), .EditUserId = 0})
        End Function

        Function UEdit(Optional ByVal id As Integer = 0) As ActionResult

            Dim model As New UEditModel

            Dim user As Core.Entity.User = UR.GetById(id)

            If user IsNot Nothing Then
                Dim userroles As String() = RR.GetRolesForUser(UR.GetById(id).Username)
                For Each role As String In RR.GetAllRoles()
                    model.URoles.Add(role)
                    model.UIRoles.Add(userroles.Contains(role))
                Next

                model.user = UR.GetById(id)
                model.edit_id = id

                Return View(model)
            Else
                Return RedirectToAction("Users")
            End If

        End Function

        <HttpPost()>
        Function UEdit(ByVal model As UEditModel) As ActionResult
            Dim roleadd As New List(Of String)
            Dim roledel As New List(Of String)
            For i As Integer = 1 To model.URoles.Count
                If model.UIRoles(i - 1) Then
                    roleadd.Add(model.URoles(i - 1))
                Else
                    roledel.Add(model.URoles(i - 1))
                End If
            Next
            Dim username As String = UR.GetById(model.edit_id).Username
            RR.RemoveUsersFromRoles(New String() {username}, roledel.ToArray)
            RR.AddUsersToRoles(New String() {username}, roleadd.ToArray)
            Return RedirectToAction("Users", "Manage")
        End Function

        <HttpPost()>
        Function UUnlock(ByVal username As String) As ActionResult
            UR.ActivateUser(username)
            Return RedirectToAction("Users", "Manage")
        End Function

        <HttpPost()>
        Function UActivate(ByVal username As String) As ActionResult
            UR.ActivateUser(username)
            Return RedirectToAction("Users", "Manage")
        End Function

        <HttpPost()>
        Function UDeactivate(ByVal username As String) As ActionResult
            UR.DeActivateUser(username)
            Return RedirectToAction("Users", "Manage")
        End Function

        <HttpPost()>
        Function UDelete(ByVal username As String) As ActionResult
            UR.DeleteUser(username)
            Return RedirectToAction("Users", "Manage")
        End Function

        Function Cats() As ActionResult
            Return View(New CategoryModel() With {.cats = CR.GetAll, .edit_id = 0})
        End Function

        <HttpPost()>
        Function Cats(ByVal model As CategoryModel) As ActionResult
            'add to database
            If model.new_cat.CatName IsNot Nothing AndAlso model.new_cat.CatName.Length > 0 Then
                Dim CR As New Core.CategoryRepository()
                If Not CR.AddCategory(model.new_cat) Then
                    ModelState.AddModelError("", "Category Already Exists")
                    Return View(model)
                End If
                Return RedirectToAction("Cats")
            End If

            ModelState.AddModelError("", "Please Specify a Category Name")
            model.edit_id = 0
            model.cats = CR.GetAll
            Return View(model)
        End Function

        Function CEdit(Optional ByVal id As Integer = 0) As ActionResult
            Return View("Cats", New CategoryModel() With {.cats = CR.GetAll, .edit_id = id})
        End Function

        <HttpPost()>
        Function CDelete(ByVal id As Integer) As ActionResult
            'Delete
            CR.delete(id)
            Return RedirectToAction("Cats")
        End Function

        <HttpPost()>
        Function CUpdate(ByVal model As Core.Entity.Category) As ActionResult
            'Save
            If CR.Update(model) Then
                Return RedirectToAction("Cats")
            End If

            ModelState.AddModelError("", "Error Updating Category")
            Return RedirectToAction("CEdit", "Manage", New With {.id = model.CategoryId})
        End Function

    End Class
End Namespace
