Namespace Entity

    <Table("Role")>
    Public Class Role

        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property RoleId As Integer
        <Required()>
        Public Property Description As String

    End Class

End Namespace
