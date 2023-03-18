Namespace Entity

    <Table("Picture")>
    Public Class Picture

        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property PictureId As Integer
        <Column("Data", TypeName:="image")>
        <Required()>
        Public Property Data As Byte()
        <Required()>
        Public Property Mime As String
        <Required()>
        Public Property Extension As String

    End Class


End Namespace
