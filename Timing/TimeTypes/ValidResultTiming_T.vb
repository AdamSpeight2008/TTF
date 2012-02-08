Namespace Global.TTF.Timings
 <DebuggerNonUserCode(), DebuggerStepThrough()>
  Public Class ValidResultTiming(Of T)
    Inherits ResultTiming(Of T)
    Private _Valid As Boolean
    Overridable ReadOnly Property Valid As Boolean
      Get
        Return _Valid
      End Get
    End Property
    Protected Friend Sub New(Time As TimeSpan, ByVal Valid As Boolean, Result As T)
      MyBase.New(Time, Result)
      _Valid = Valid
    End Sub
  End Class
End Namespace