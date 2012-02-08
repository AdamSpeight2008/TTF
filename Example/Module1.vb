Imports TTF.Timings
Imports TTF.Testing

Module Module1

  Sub Main()
    Dim r0 = TTF.Testing.TimeNVerify(
      MethodUnderTest:=Function(x As Integer)
                         Threading.Thread.Sleep(500)
                         Return 1 + x
                       End Function,
      args:={1},
      ReturnResult:=True,
      TestAlso:=True,
      WhatIsExpected:=2)
    Dim r1 = TTF.Testing._TimeNVerify(Of Integer)(
        MethodUnderTest:=Function(x As Integer)
                           Threading.Thread.Sleep(500)
                           Return 1 + x
                         End Function,
         args:={1},
         ReturnResult:=True,
         TestAlso:=True,
         WhatIsExpected:=1)

  End Sub

End Module
