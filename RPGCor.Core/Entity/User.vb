Namespace Entity

    <Table("User")>
    Public Class User

        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property UserId As Integer
        <Required()>
        <MaxLength(64)>
        Public Property FirstName As String
        <Required()>
        <MaxLength(64)>
        Public Property LastName As String
        <Required()>
        <MaxLength(128)>
        Public Property EMail As String
        <Required()>
        <MaxLength(64)>
        Public Property Username As String
        <Required()>
        <MaxLength(128)>
        Public Property Password As String
        <Required()>
        Public Property Active As Boolean
        <Required()>
        Public Property LockedOut As Boolean
        <Required()>
        Public Property LastLogin As DateTime
        <Required()>
        Public Property Registered As DateTime

    End Class

End Namespace
