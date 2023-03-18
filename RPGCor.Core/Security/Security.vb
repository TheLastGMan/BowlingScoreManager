Public Class Security

    Public Shared Function Encrypt(ByVal password As String) As String
        Dim encpassx As New System.Security.Cryptography.SHA512Cng
        Return Convert.ToBase64String(encpassx.ComputeHash(Text.UTF8Encoding.UTF8.GetBytes(password)))
    End Function

End Class
