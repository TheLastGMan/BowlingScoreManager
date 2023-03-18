Public Class Common

    Public Shared Function TestUser() As Core.Entity.User
        Return New Core.Entity.User With {
            .FirstName = "Test",
            .LastName = "User",
            .EMail = "test@user.com",
            .Username = "testuser",
            .Password = "testing"
        }
    End Function

End Class
