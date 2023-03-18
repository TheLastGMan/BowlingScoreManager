Namespace Entity

    <Table("UserRole")>
    Public Class UserRole

        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        <Key()>
        <Timestamp()>
        Public Property TrackingKey As Byte()
        <Required()>
        Public Property UserId As Integer
        <ForeignKey("UserId")>
        Public Property User As User
        <Required()>
        Public Property RoleId As Integer
        <ForeignKey("RoleId")>
        Public Property Role As Role

    End Class

End Namespace
