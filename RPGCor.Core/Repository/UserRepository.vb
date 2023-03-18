Imports System.Data
Public Class UserRepository

    Private DBC As New RPGcorContext()

    Public ReadOnly Property Users As IQueryable(Of Entity.User)
        Get
            Return DBC.User
        End Get
    End Property

    Public Enum LoginResponse As Integer
        Invalid = 0
        Valid = 1
        Locked_Out = 2
        Inactive = 3
    End Enum

    Public Function GetAll() As List(Of Entity.User)
        Return Users.ToList()
    End Function

    Public Function IdByUsername(ByVal username As String) As Integer
        Return DBC.User.Where(Function(u) u.Username = username).Select(Function(u) u.UserId).Single()
    End Function

    Public Function GetById(ByVal id As Integer) As Entity.User
        Return Users.Where(Function(u) u.UserId = id).FirstOrDefault()
    End Function

    Public Function CheckUser(ByVal username As String, ByRef password As String) As LoginResponse
        Dim enc As String = Security.Encrypt(password)

        Dim usr = (From u As Entity.User In Users Where u.Username = username And u.Password = enc Take 1 Select u).FirstOrDefault()

        If usr Is Nothing Then
            Return LoginResponse.Invalid
        ElseIf Not usr.Active Then
            Return LoginResponse.Inactive
        ElseIf usr.LockedOut Then
            Return LoginResponse.Locked_Out
        End If

        UpdateLogin(usr.Username)
        Return LoginResponse.Valid
    End Function

    Public Function RegisterUser(ByRef user As Entity.User) As Boolean
        user.Password = Security.Encrypt(user.Password)
        user.Active = False
        user.LockedOut = False
        user.Registered = Now()
        user.LastLogin = New DateTime(1900, 1, 1)

        DBC.User.Add(user)

        Try
            DBC.SaveChanges()
        Catch ex As Exception
            'violation, remove from table cache
            DBC.User.Remove(user)
            Return False
        End Try

        Return True
    End Function

    Public Function UpdateLogin(ByRef username As String) As Boolean
        Try
            Dim user = UserByUsername(username)
            user.LastLogin = Now
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UserByUsername(ByVal username As String) As Entity.User
        Return DBC.User.Where(Function(u) u.Username = username).SingleOrDefault()
    End Function

    Public Function DeActivateUser(ByRef username As String) As Boolean
        Try
            Dim user = UserByUsername(username)
            user.Active = False
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ActivateUser(ByRef username As String) As Boolean
        Try
            Dim user = UserByUsername(username)
            user.LockedOut = False
            user.Active = True
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function LockOutUser(ByRef username As String) As Boolean
        Try
            Dim user = UserByUsername(username)
            user.LockedOut = True
            DBC.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ChangePass(ByVal userId As Integer, ByRef OldPass As String, ByRef NewPass As String) As Boolean
        Dim enc As String = Security.Encrypt(NewPass)
        Dim oenc As String = Security.Encrypt(OldPass)
        Dim usr As Entity.User = DBC.User.Where(Function(u) u.UserId = userId).Where(Function(u) u.Password = oenc).SingleOrDefault()

        If usr Is Nothing Then
            Return False
        Else
            usr.Password = enc
            DBC.SaveChanges()
            Return True
        End If
    End Function

    Public Function DeleteUser(ByVal username As String) As Boolean
        Dim user = DBC.User.Where(Function(u) u.Username = username).SingleOrDefault()
        If user IsNot Nothing Then
            DBC.User.Remove(user)
            DBC.SaveChanges()
            Return True
        Else
            Return False
        End If
    End Function

End Class
