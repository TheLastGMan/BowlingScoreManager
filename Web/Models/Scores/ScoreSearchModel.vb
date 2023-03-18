Public Class ScoreSearchModel

    Public Property SearchItems As New List(Of SearchParameter)
    Public Property Scores As New List(Of Core.Entity.Score)

    Public Structure SearchParameter
        Public key As DictionaryEntry
        Public criteria As DictionaryEntry
        Public value As String
    End Structure

    Public Shared ReadOnly Property SearchCriteria As Dictionary(Of String, String)
        Get
            Dim DL As New Dictionary(Of String, String)
            DL.Add("Starts With", "LIKE '{0}%'")
            DL.Add("Ends With", "LIKE '%{0}'")
            DL.Add("Contains", "LIKE '%{0}%'")
            DL.Add("Equals", "LIKE '{0}'")
            DL.Add("Greater Than", ">= '{0}'")
            DL.Add("Less Than", "<= '{0}'")
            Return DL
        End Get
    End Property

    Public Shared ReadOnly Property SearchPrameters As Dictionary(Of String, String)
        Get
            Dim DL As New Dictionary(Of String, String)
            DL.Add("First Name", "FName")
            DL.Add("Last Name", "LName")
            DL.Add("League", "League")
            DL.Add("Date", "DateAchieved")
            DL.Add("Game 1", "Game1")
            DL.Add("Game 2", "Game2")
            DL.Add("Game 3", "Game3")
            DL.Add("Series", "Series")
            Return DL
        End Get
    End Property

End Class
