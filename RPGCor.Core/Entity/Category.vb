Namespace Entity

    <Table("Category")>
    Public Class Category
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property CategoryId As Integer
        <Required()>
        <MaxLength(64)>
        Public Property CatName As String
        <Required()>
        Public Property PageNum As Integer
        <Required()>
        Public Property SortOrder As Integer
        <Required()>
        Public Property ShowDateAchieved As Boolean
        <Required()>
        Public Property ShowPicture As Boolean
        <Required()>
        Public Property ShowGame1 As Boolean
        <Required()>
        Public Property ShowGame2 As Boolean
        <Required()>
        Public Property ShowGame3 As Boolean
        <Required()>
        Public Property ShowSeries As Boolean
        <Required()>
        Public Property ShowHDCPSeries As Boolean
        <Required()>
        Public Property PerPage As Integer

        <NotMapped()>
        Public Property Scores As New List(Of Entity.Score)
    End Class

End Namespace
