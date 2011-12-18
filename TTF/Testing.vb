Imports TTF.Timings
Imports TTF.Testing
Imports System.Runtime.CompilerServices
Imports System.Collections.Generic
'Namespace Global.TTF.Testing
<HideModuleName(), DebuggerNonUserCode(), DebuggerStepThrough()>
Public Module Testing
  <Extension()>
  Public Function _TimeNVerify(Of TReturn) _
    (MethodUnderTest As [Delegate], args() As Object,
     Optional ReturnResult As Boolean = False,
     Optional TestAlso As Boolean = False,
     Optional ByVal WhatIsExpected As TReturn = Nothing) As Timing
    ' Define and initailise the Results
    Dim Results As TReturn = Nothing
    ' Define a new instance of the stopwatch
    Dim sw As New Diagnostics.Stopwatch
    Try
      ' Create and Start a New instance of the Stopwatch class
      sw = Diagnostics.Stopwatch.StartNew()
      '  Invoke the MethodUnderTest with the arhuments provided
      Results = CType(MethodUnderTest.DynamicInvoke(args), TReturn)
    Catch ex As Exception
      ' Catch the exception and return a Failure
      Return New Timings.Failure(sw.Elapsed, ex)
    Finally
      ' Stop the stopwatch
      sw.Stop()
    End Try
    ' The user requested that the method be tested also and they have provided what the expected results are to be.
    If TestAlso AndAlso (WhatIsExpected IsNot Nothing) Then
      ' Then veriy the results.
      Dim Verified = Results.VerifiedAgainst(WhatIsExpected)
      ' If the user request the results return from the method be returned. the return a ValidResultTiming 
      If ReturnResult Then Return New Timings.ValidResultTiming(Of TReturn)(sw.Elapsed, Verified, Results)
      ' Otherwise return a ValidTiming
      Return New ValidTiming(sw.Elapsed, Verified)
    Else
      ' else if the user requested no testing, (just timing).
      ' If the user requested the Results be returned then return a ResultTiming<T>
      If ReturnResult Then Return New ResultTiming(Of TReturn)(sw.Elapsed, Results)
      ' Otherwise just return the timing.
      Return New Timing(sw.Elapsed)
    End If
  End Function

  Function Is_T_a_U(Of T, U)(First As T, second As T) As Boolean
    Return {First, second}.All(Function(x As T) TypeOf x Is U)
  End Function

  <Extension()> Public Function VerifiedAgainst(Of T)(ByVal Result As T, ByVal Expected As T) As Boolean
    If Is_T_a_U(Of T, IEnumerable)(Result, Expected) Then Return Match(Of T)(CType(Result, IEnumerable), CType(Expected, IEnumerable))
    If TypeOf Result Is IComparable Then Return CType(Result, IComparable).CompareTo(Expected) = 0
    Return False
  End Function
  <Extension()> Friend Function Match(Of T)(first As IEnumerable, second As IEnumerable) As Boolean
    ' Create an array containing the Enumerators of the params first and second
    Dim Enumerators = {first.GetEnumerator, second.GetEnumerator}
    While True
      ' Create a boolean array containing the MoveNext states of the enumerators
      Dim MoveNextsValid = {Enumerators(0).MoveNext, Enumerators(1).MoveNext}
      ' If neither move is unvalid return true.
      If MoveNextsValid(0).Nor(MoveNextsValid(1)) Then Return True
      ' Is the second Move Next Not Valid, then return false. (Seqs are mismatch lenghts)
      If MoveNextsValid(1).Not Then Return False
      ' Try and cast then current value of the first enumerator to IComparable
      Dim ComparableObj = TryCast(Enumerators(0).Current, IComparable)
      ' Was it castable? and did it equal the seconds enumerators current value? If so continue to loop
      If (ComparableObj IsNot Nothing) AndAlso ComparableObj.IsEqualTo(Enumerators(1).Current) Then Continue While
      ' return false.
      Return False
    End While
    Return True
  End Function
  <Extension()> Friend Function [Not](x As Boolean) As Boolean
    Return Not (x)
  End Function
  <Extension()> Friend Function Nor(x As Boolean, y As Boolean) As Boolean
    Return Not (x) AndAlso Not (y)
  End Function
  <Extension()> Friend Function IsEqualTo(Of T As IComparable)(x As T, y As T) As Boolean
    Return x.CompareTo(y) = 0
  End Function
End Module
'End Namespace
