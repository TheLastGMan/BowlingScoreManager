Public Class RoleRepository

    Private DBC As New RPGcorContext()

    Private ReadOnly Property Roles As IQueryable(Of Entity.Role)
        Get
            Return DBC.Roles
        End Get
    End Property

    Public Function LoadRoles() As List(Of Entity.Role)
        Return Roles.OrderBy(Function(r) r.Description).ToList()
    End Function

    Public Function GetRole(ByVal RoleID As Integer) As Entity.Role
        Return Roles.Where(Function(r) r.RoleID = RoleID).Single()
    End Function

    Public Function GetId(ByVal Description As String) As Integer
        Return DBC.Roles.Where(Function(r) r.Description = Description).Select(Function(r) r.RoleId).Single()
    End Function

End Class
