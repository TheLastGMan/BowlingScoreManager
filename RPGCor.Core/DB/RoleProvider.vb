Public Class RoleProvider : Inherits System.Web.Security.RoleProvider

    Private DBC As New RPGcorContext()

    Public Overrides Sub AddUsersToRoles(usernames() As String, roleNames() As String)
        'loop through each users
        For Each usr As String In usernames
            Dim cusr As String = usr
            'loop through roles user does not have
            For Each role As String In roleNames
                Dim crole As String = role
                If Not New RoleProvider().IsUserInRole(cusr, crole) Then
                    Dim roled As Entity.Role = (From rolex As Entity.Role In DBC.Roles Where rolex.Description = crole).SingleOrDefault()
                    Dim userid As Integer = New UserRepository().IdByUsername(cusr)
                    Dim usrrole As New Entity.UserRole With {.RoleId = roled.RoleID, .UserId = userid}
                    DBC.UserRoles.Add(usrrole)
                End If
            Next
        Next
        Try
            DBC.SaveChanges()
        Catch ex As Data.Entity.Validation.DbEntityValidationException
            Dim err As String = ""
        Catch ex1 As Exception
            Dim err As String = ""
        End Try

    End Sub

    Public Overrides Sub RemoveUsersFromRoles(usernames() As String, roleNames() As String)
        'loop through each user
        For Each usr As String In usernames
            Dim cusr As String = usr
            'find all users roles
            For Each role As String In roleNames
                Dim crole As String = role
                If New RoleProvider().IsUserInRole(cusr, crole) Then
                    DBC.UserRoles.Remove(DBC.UserRoles.Where(Function(r) r.Role.Description = crole).Where(Function(r) r.User.Username = cusr).SingleOrDefault())
                End If
            Next
        Next
        'save changes
        DBC.SaveChanges()
    End Sub

    Public Overrides Property ApplicationName As String
        Get
            Return "RPGCor_Scores"
        End Get
        Set(value As String)

        End Set
    End Property

    Public Overrides Sub CreateRole(roleName As String)
        'add new role if it does not already exist
        If Not GetAllRoles.Contains(roleName) Then
            DBC.Roles.Add(New Entity.Role With {.Description = roleName})
            DBC.SaveChanges()
        End If
    End Sub

    Public Overrides Function DeleteRole(roleName As String, throwOnPopulatedRole As Boolean) As Boolean
        DBC.Roles.Remove(DBC.Roles.Where(Function(r) r.Description = roleName).SingleOrDefault())
        Try
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overrides Function FindUsersInRole(roleName As String, usernameToMatch As String) As String()
        Return (From ur As Entity.UserRole In DBC.UserRoles Where ur.Role.Description = roleName And ur.User.Username.StartsWith(usernameToMatch) Select ur.User.Username).ToArray()
    End Function

    Public Overrides Function GetAllRoles() As String()
        Return DBC.Roles.Select(Function(r) r.Description).ToArray()
    End Function

    Public Overrides Function GetRolesForUser(username As String) As String()
        Return DBC.UserRoles.Where(Function(ur) ur.User.Username = username).Select(Function(ur) ur.Role.Description).ToArray()
    End Function

    Public Overrides Function GetUsersInRole(roleName As String) As String()
        Return DBC.UserRoles.Where(Function(ur) ur.Role.Description = roleName).Select(Function(ur) ur.User.Username).ToArray()
    End Function

    Public Overrides Function IsUserInRole(username As String, roleName As String) As Boolean
        Return IIf((From role As Entity.UserRole In DBC.UserRoles Where role.User.Username = username And role.Role.Description = roleName).Count() > 0, True, False)
    End Function

    Public Overrides Function RoleExists(roleName As String) As Boolean
        Return IIf((From role As Entity.Role In DBC.Roles Where role.Description = roleName Select role).Count() > 0, True, False)
    End Function
End Class
