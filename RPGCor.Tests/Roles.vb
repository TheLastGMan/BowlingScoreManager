Imports System.Text

<TestClass()>
Public Class Roles

    <TestMethod()>
    Public Sub AddRoleToUser()

    End Sub

    <TestInitialize()>
    Public Sub Init()
        
    End Sub

    <TestCleanup()>
    Public Sub Cleanup()

        Dim UR As New Core.UserRepository
        UR.DeleteUser(Common.TestUser.Username)
    End Sub

End Class
