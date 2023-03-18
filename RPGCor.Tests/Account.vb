Imports System.Text
Imports RPGCor.Core
Imports RPGCor.Tests.Common

<TestClass()>
Public Class Account : Inherits BaseTest

    Private UR As New Core.UserRepository()

    <TestMethod()>
    Public Sub RegisterUser()
        'Arrange
        Dim user As Entity.User = TestUser()
        'Act
        Dim result As Boolean = UR.RegisterUser(user)
        'Assert
        Assert.IsTrue(result)
    End Sub

    <TestMethod()>
    Public Sub Register_Duplicate_Users()
        'Arrange
        Dim U1 As Entity.User = TestUser()
        Dim U2 As Entity.User = TestUser()
        'Act
        Dim R1 As Boolean = UR.RegisterUser(U1)
        Dim R2 As Boolean = UR.RegisterUser(U2)
        'Assert
        Assert.IsTrue(R1)
        Assert.IsFalse(R2)
    End Sub

    <TestCleanup()>
    Public Sub DeleteUser()
        UR.DeleteUser(TestUser.Username)
    End Sub

    <TestMethod()>
    Public Sub CreateDeleteUser()
        'Arrange
        Dim user As Entity.User = TestUser()
        'Act
        Dim result As Boolean = UR.RegisterUser(user)
        'Assert
        Assert.IsTrue(result)
    End Sub

    <TestMethod()>
    Public Sub LoginProcess()
        'Arrange
        Dim user As Entity.User = TestUser()
        Dim user_login As Entity.User = TestUser()
        Dim user_after_validate As Entity.User = TestUser()
        'Act
        Dim result = UR.RegisterUser(user)
        Dim inactive As UserRepository.LoginResponse = UR.CheckUser(user_login.Username, user_login.Password)
        UR.ActivateUser(TestUser.Username)
        Dim success As UserRepository.LoginResponse = UR.CheckUser(user_after_validate.Username, user_after_validate.Password)
        'Assert
        Assert.IsTrue(result)
        Assert.AreEqual(inactive, UserRepository.LoginResponse.Inactive)
        Assert.AreEqual(success, UserRepository.LoginResponse.Valid)
    End Sub

End Class
