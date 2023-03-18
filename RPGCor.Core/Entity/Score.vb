Namespace Entity

    <Table("Score")>
    Public Class Score

        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property ScoreId As Integer
        <Required()>
        Public Property CategoryId As Integer
        <ForeignKey("CategoryId")>
        Public Property Category As Category
        Public Property PictureId As Integer?
        <ForeignKey("PictureId")>
        Public Property Picture As Picture
        <Required()>
        <MaxLength(64)>
        Public Property FName As String
        <Required()>
        <MaxLength(64)>
        Public Property LName As String
        <Required()>
        <MaxLength(64)>
        Public Property League As String
        <Required()>
        Public Property DateAchieved As Date
        <Required()>
        Public Property Game1 As Integer
        <Required()>
        Public Property Game2 As Integer
        <Required()>
        Public Property Game3 As Integer
        <DatabaseGenerated(DatabaseGeneratedOption.Computed)>
        Public ReadOnly Property Series As Integer
            Get
                Return Game1 + Game2 + Game3
            End Get
        End Property
        <Required()>
        Public Property HDCPSeries As Integer
        <Required()>
        Public Property Archived As Boolean
        <Required()>
        Public Property Editable As Boolean

        <NotMapped()>
        Public ReadOnly Property FullName As String
            Get
                Return FName & " " & LName
            End Get
        End Property

    End Class

End Namespace