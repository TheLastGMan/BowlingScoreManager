Public Class PluginInfo : Implements RPGCor.Core.IPluginInfo

    Public ReadOnly Property Author As String Implements Core.IPluginInfo.Author
        Get
            Return "RPGCor"
        End Get
    End Property

    Public ReadOnly Property DisplayName As String Implements Core.IPluginInfo.DisplayName
        Get
            Return "PreBowl Scores"
        End Get
    End Property

    Public ReadOnly Property DisplayOrder As Byte Implements Core.IPluginInfo.DisplayOrder
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property Group As String Implements Core.IPluginInfo.Group
        Get
            Return "Reports"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements Core.IPluginInfo.Version
        Get
            Return "1.0.0"
        End Get
    End Property

End Class
