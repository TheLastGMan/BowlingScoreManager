Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

<DisplayName("User Info")>
Public Class RegisterModel

    <Required(ErrorMessage:="First Name is Required")>
    <DisplayName("First Name")>
    <DataType(DataType.Text)>
    Public Property FirstName As String

    <Required(ErrorMessage:="Last Name is Required")>
    <DisplayName("Last Name")>
    <DataType(DataType.Text)>
    Public Property LastName As String

    <Required(ErrorMessage:="EMail address is Required")>
    <RegularExpression("\b[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b", ErrorMessage:="Invalid EMail Address Format")>
    <DisplayName("EMail")>
    <DataType(DataType.EmailAddress)>
    Public Property email As String

    <Required(ErrorMessage:="Username is Required")>
    <DisplayName("Username")>
    <DataType(DataType.Text)>
    Public Property username As String

    <Required(ErrorMessage:="Password is Required")>
    <DisplayName("Password")>
    <DataType(DataType.Password)>
    Public Property password As String

    <Compare("password", ErrorMessage:="Passwords do not match")>
    <DisplayName("Confirm Password")>
    <DataType(DataType.Password)>
    Public Property password_confirm As String

End Class
