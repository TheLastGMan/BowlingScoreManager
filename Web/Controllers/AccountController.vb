Imports RPGCor.Core

Namespace RPGCor.Web
    Public Class AccountController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Account

        Function LogIn() As ActionResult
            If HttpContext.User.Identity.IsAuthenticated Then
                Return RedirectToAction("", "Home")
            End If
            Return View(New LoginModel)
        End Function

        <HttpPost()> _
        Function LogIn(ByVal model As LoginModel) As ActionResult
            If ModelState.IsValid Then
                'try loggin in
                Dim UR As New UserRepository()
                Select Case UR.CheckUser(model.Username, model.Password)
                    Case UserRepository.LoginResponse.Inactive
                        ModelState.AddModelError("", "Account is InActive, Please contact your manager for assistance")
                    Case UserRepository.LoginResponse.Invalid
                        ModelState.AddModelError("", "Username or Password is incorrect")
                    Case UserRepository.LoginResponse.Locked_Out
                        ModelState.AddModelError("", "Account is Locked, Please contact your manager for assistance")
                    Case UserRepository.LoginResponse.Valid
                        FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe)
                        Return RedirectToAction("", "Home")
                End Select

                Return View(model)
            End If

            Return View()
        End Function

        Function LogOut() As ActionResult
            FormsAuthentication.SignOut()
            Return RedirectToAction("Index", "Home")
        End Function

        Function Register() As ActionResult
            If HttpContext.User.Identity.IsAuthenticated Then
                Return RedirectToAction("", "Home")
            End If
            Return View(New RegisterModel)
        End Function

        <HttpPost()>
        Function Register(ByVal model As RegisterModel) As ActionResult
            If ModelState.IsValid Then
                'try and register user
                Dim UR As New UserRepository()

                Dim UM As New Entity.User
                With UM
                    .FirstName = model.FirstName
                    .LastName = model.LastName
                    .EMail = model.email
                    .Username = model.username
                    .Password = model.password
                End With

                If UR.RegisterUser(UM) Then
                    Return View("RegisterResponse")
                Else
                    ModelState.AddModelError("", "Username is already in use")
                End If
            End If

            'did not pass
            Return View(model)
        End Function

    End Class
End Namespace
