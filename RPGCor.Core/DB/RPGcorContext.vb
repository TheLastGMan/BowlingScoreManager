Imports System.Data.Entity

Public Class RPGcorContext : Inherits DbContext

    Public Sub New()
        MyBase.New("Data Source=.\SQLEXPRESS;Initial Catalog=pinz;Persist Security Info=True;Integrated Security=SSPI")
    End Sub

    Public Property Categories As DbSet(Of Entity.Category)
    Public Property Pictures As DbSet(Of Entity.Picture)
    Public Property Roles As DbSet(Of Entity.Role)
    Public Property Scores As DbSet(Of Entity.Score)
    Public Property Settings As DbSet(Of Entity.Settings)
    Public Property User As DbSet(Of Entity.User)
    Public Property UserRoles As DbSet(Of Entity.UserRole)

End Class
