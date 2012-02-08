Namespace Global.TTF.Timings
  <DebuggerNonUserCode(), DebuggerStepThrough()>
  Public Class ResultTiming(Of T)
    Inherits Timing
    Private _Result As T = Nothing
    Public ReadOnly Property Result As T
      Get
        Return _Result
      End Get
    End Property
    Protected Friend Sub New(Time As TimeSpan, Result As T)
      MyBase.New(Time)
      _Result = Result
    End Sub
  End Class
End Namespace
