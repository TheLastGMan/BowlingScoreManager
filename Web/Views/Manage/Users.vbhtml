@ModelType RPGCor.Web.UserModel

<table border="1" cellspacing="0" class="Grid">
    <thead class="Header">
        <tr>
            <td colspan="6">Users</td>
        </tr>
        <tr>
            <td>Full Name</td>
            <td>EMail</td>
            <td>Username</td>
            <td>Active</td>
            <td>Locked Out</td>
            <td>Delete</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.UserList.Count
            Dim row As Integer = i - 1
            With Model.UserList(row)
                @<tr class="@IIf(i mod 2, "Row", "AltRow")">
                    <td>
                        @Html.ActionLink(.FirstName & " " & .LastName, "UEdit", New With {.id = Model.UserList(row).UserId})
                    </td>
                    <td>@Html.Label("EMail", .EMail)</td>
                    <td>@Html.Label(.Username)</td>
                    <td>
                        @If .Active Then
                            Using Html.BeginForm("UDeactivate", "Manage")
                                If .Username = User.Identity.Name Then
                                    @<span>Yes</span>
                                Else
                                    @Html.Hidden("username", .Username)
                                    @<input type="submit" value="DeActivate" class="button-blue" /> 
                                End If
                            End Using
                        Else
                            Using Html.BeginForm("UActivate", "Manage")
                                If .Username = User.Identity.Name Then
                                    @<span>No</span>
                                Else
                                    @Html.Hidden("username", .Username)
                                    @<input type="submit" value="Activate" class="button-blue" />
                                End If
                            End Using
                        End If
                    </td>
                    <td>
                        @If .LockedOut Then
                            Using Html.BeginForm("UUnlock", "Manage")
                                @Html.Hidden("username", .Username)
                                @<input type="submit" value="Unlock" class="button-blue" />
                            End Using
                        Else
                            @<span>No</span>
                        End If
                    </td>
                    <td>
                        @If Not .Username = User.Identity.Name Then
                            Using Html.BeginForm("UDelete", "Manage")
                                @Html.Hidden("username", .Username)@<input type="submit" value="Delete" class="button-blue" />
                            End Using
                        End If
                    </td>
                </tr>
            End With
        Next
    </tbody>
    <tfoot class="Footer">
        <tr>
            <td colspan="6">&nbsp;</td>
        </tr>
    </tfoot>
</table>