Public Class UserRoleRepository

    Private DBC As New RPGcorContext()

    Public ReadOnly Property UserRoles As IQueryable(Of Entity.UserRole)
        Get
            Return DBC.UserRoles.Include("User").Include("Role")
        End Get
    End Property

End Class
