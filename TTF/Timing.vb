Namespace Timings
  <DebuggerNonUserCode(), DebuggerStepThrough()>
  Public Class Timing
    Private _Time As TimeSpan
    Public Sub New(Time As TimeSpan)
      _Time = Time
    End Sub
    Public ReadOnly Property TimeTaken As TimeSpan
      Get
        Return _Time
      End Get
    End Property
  End Class
  Public Class Failure
    Inherits ValidTiming
    Private _Ex As Exception
    Public Sub New(TimeTaken As TimeSpan, ex As Exception)
      MyBase.New(TimeTaken, False)
      _Ex = ex
    End Sub
    Public ReadOnly Property Exception As Exception
      Get
        Return _Ex
      End Get
    End Property
  End Class

  <DebuggerNonUserCode(), DebuggerStepThrough()>
  Public Class ValidTiming
    Inherits Timing
    Private _Valid As Boolean
    Public Sub New(Time As TimeSpan, Valid As Boolean)
      MyBase.New(Time)
      _Valid = Valid
    End Sub
    Public ReadOnly Property Valid As Boolean
      Get
        Return _Valid
      End Get
    End Property
  End Class
  <DebuggerNonUserCode(), DebuggerStepThrough()>
  Public Class ResultTiming(Of T)
    Inherits Timing
    Private _Result As T = Nothing
    Public ReadOnly Property Result As T
      Get
        Return _Result
      End Get
    End Property
    Public Sub New(Time As TimeSpan, Result As T)
      MyBase.New(Time)
      _Result = Result
    End Sub
  End Class
  <DebuggerNonUserCode(), DebuggerStepThrough()>
  Public Class ValidResultTiming(Of T)
    Inherits ResultTiming(Of T)
    Private _Valid As Boolean
    ReadOnly Property Valid As Boolean
      Get
        Return _Valid
      End Get
    End Property
    Public Sub New(Time As TimeSpan, ByVal Valid As Boolean, Result As T)
      MyBase.New(Time, Result)
      _Valid = Valid
    End Sub


  End Class
End Namespace