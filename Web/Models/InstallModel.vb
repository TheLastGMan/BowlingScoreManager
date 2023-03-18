Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

<DisplayName("Install")>
Public Class InstallModel

    Public Property User As RegisterModel

    <Required(ErrorMessage:="Server Required")>
    <DisplayName("SQL Server Name")>
    Public Property SQL_Server As String

    <Required(ErrorMessage:="Database Required")>
    <DisplayName("Database Name")>
    Public Property SQL_Database As String

    <Required(ErrorMessage:="SQL Username Required")>
    <DisplayName("SQL Username")>
    Public Property SQL_UserName As String

    <Required(ErrorMessage:="SQL Password Required")>
    <DisplayName("SQL Password")>
    Public Property SQL_PassWord As String

End Class