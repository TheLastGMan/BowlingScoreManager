Public Class SettingsRepository

    Private DBC As New RPGcorContext()

    Public ReadOnly Property Settings As IQueryable(Of Entity.Settings)
        Get
            Return DBC.Settings
        End Get
    End Property

End Class
