Imports System.Threading

Public Class WriteLockDisposable : Implements IDisposable

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    Private ReadOnly _rwLock As ReaderWriterLockSlim

    Public Sub New(ByRef rwLock As ReaderWriterLockSlim)
        _rwLock = rwLock
        _rwLock.EnterWriteLock()
    End Sub

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                _rwLock.ExitWriteLock()
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
