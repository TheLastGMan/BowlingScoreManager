Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

<DisplayName("Login")>
Public Class LoginModel

    <Required(ErrorMessage:="Username is Required")>
    <DisplayName("Username")>
    Public Property Username As String

    <Required(ErrorMessage:="Password is Required")>
    <DisplayName("Password")>
    <DataType(DataType.Password)>
    Public Property Password As String

    <DisplayName("Remember Me")>
    Public Property RememberMe As Boolean = False

End Class
