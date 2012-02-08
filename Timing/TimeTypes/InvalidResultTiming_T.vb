Namespace Global.TTF.Timings
  Public Class InvalidResultTiming(Of T)
    Inherits ValidResultTiming(Of T)
    Protected Friend Sub New(Time As TimeSpan, Result As T)
      MyBase.New(Time, False, Result)
    End Sub
  End Class
End Namespace