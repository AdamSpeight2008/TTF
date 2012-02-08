Namespace Global.TTF.Timings
  Public Class Failure
    Inherits ValidTiming
    Private _Ex As Exception
    Protected Friend Sub New(TimeTaken As TimeSpan, ex As Exception)
      MyBase.New(TimeTaken, False)
      _Ex = ex
    End Sub
    Public ReadOnly Property Exception As Exception
      Get
        Return _Ex
      End Get
    End Property
  End Class
End Namespace
