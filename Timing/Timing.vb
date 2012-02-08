Namespace Global.TTF.Timings
  <DebuggerNonUserCode(), DebuggerStepThrough()>
  Public Class Timing
    Private _Time As TimeSpan
    Protected Friend Sub New(Time As TimeSpan)
      _Time = Time
    End Sub
    Public ReadOnly Property TimeTaken As TimeSpan
      Get
        Return _Time
      End Get
    End Property
    Public Shared Function CreateTiming(Time As TimeSpan) As Timing
      Return New Timing(Time)
    End Function
    Public Shared Function CreateValidTiming(Time As TimeSpan, Valid As Boolean) As ValidTiming
      Return New ValidTiming(Time, Valid)
    End Function
    Public Shared Function CeateFailure(time As TimeSpan, ex As Exception) As Failure
      Return New Failure(time, ex)
    End Function
    Public Shared Function CreateResultTiming(Of t)(time As TimeSpan, Result As t) As ResultTiming(Of t)
      Return New ResultTiming(Of t)(time, Result)
    End Function
    Public Shared Function CreateValidResult(Of T)(Time As TimeSpan, ByVal Valid As Boolean, Result As T)
      Return If(Valid, New ValidResultTiming(Of T)(Time, True, Result), New InvalidResultTiming(Of T)(Time, Result))
    End Function
  End Class
End Namespace