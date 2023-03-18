Public Class CDEParser

    Public Shared Function S00(ByRef FileLines As List(Of String)) As List(Of CDEScoreStructure)

    End Function

    Public Shared Function S00(ByRef FileStream As IO.StreamReader) As List(Of CDEScoreStructure)
        Return S00(FileLines(FileStream))
    End Function

    Private Shared Function FileLines(ByRef FileStream As IO.StreamReader) As List(Of String)
        Dim filelinesout As New List(Of String)

        While Not FileStream.EndOfStream
            filelinesout.Add(FileStream.ReadLine())
        End While

        Return filelinesout
    End Function

End Class
