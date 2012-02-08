Namespace Global.TTF.Timings
  <DebuggerNonUserCode(), DebuggerStepThrough()>
    Public Class ValidTiming
    Inherits Timing
    Private _Valid As Boolean
    Protected Friend Sub New(Time As TimeSpan, Valid As Boolean)
      MyBase.New(Time)
      _Valid = Valid
    End Sub
    Public ReadOnly Property Valid As Boolean
      Get
        Return _Valid
      End Get
    End Property
  End Class
End Namespace
