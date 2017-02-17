
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

Public Class App

    Public Shared Sub Main()
        CollectSamples()
    End Sub

    Private Shared Sub CollectSamples()

        Dim categoryName As String = "ElapsedTimeSampleCategory"
        Dim counterName As String = "ElapsedTimeSample"

        If Not PerformanceCounterCategory.Exists(categoryName) Then

            Dim CCDC As New CounterCreationDataCollection()

            ' Add the counter.
            Dim ETimeData As New CounterCreationData()
            ETimeData.CounterType = PerformanceCounterType.ElapsedTime
            ETimeData.CounterName = counterName
            CCDC.Add(ETimeData)

            ' Create the category.
            PerformanceCounterCategory.Create(categoryName, _
               "Demonstrates ElapsedTime performance counter usage.", _
                   PerformanceCounterCategoryType.SingleInstance, CCDC)

        Else
            Console.WriteLine("Category exists - {0}", categoryName)
        End If

        ' Create the counter.
        Dim PC As PerformanceCounter
        PC = New PerformanceCounter(categoryName, counterName, False)

        ' Initialize the counter.
        PC.RawValue = Stopwatch.GetTimestamp()

        Dim Start As DateTime = DateTime.Now

        ' Loop for the samples.
        Dim j As Integer
        For j = 0 To 99
            ' Output the values.
            If j Mod 10 = 9 Then
                Console.WriteLine(("NextValue() = " _
                    + PC.NextValue().ToString()))
                Console.WriteLine(("Actual elapsed time = " _
                    + DateTime.Now.Subtract(Start).ToString()))
                OutputSample(PC.NextSample())
            End If

            ' Reset the counter every 20th iteration.
            If j Mod 20 = 0 Then
                PC.RawValue = Stopwatch.GetTimestamp()
                Start = DateTime.Now
            End If
            System.Threading.Thread.Sleep(50)
        Next j

        Console.WriteLine(("Elapsed time = " + _
              DateTime.Now.Subtract(Start).ToString()))
    End Sub


    Private Shared Sub OutputSample(ByVal s As CounterSample)
        Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "+++++++")

        Console.WriteLine("Sample values - " + ControlChars.Cr _
              + ControlChars.Lf)
        Console.WriteLine(("   BaseValue        = " _
              + s.BaseValue.ToString()))
        Console.WriteLine(("   CounterFrequency = " + _
              s.CounterFrequency.ToString()))
        Console.WriteLine(("   CounterTimeStamp = " + _
              s.CounterTimeStamp.ToString()))
        Console.WriteLine(("   CounterType      = " + _
              s.CounterType.ToString()))
        Console.WriteLine(("   RawValue         = " + _
              s.RawValue.ToString()))
        Console.WriteLine(("   SystemFrequency  = " + _
              s.SystemFrequency.ToString()))
        Console.WriteLine(("   TimeStamp        = " + _
              s.TimeStamp.ToString()))
        Console.WriteLine(("   TimeStamp100nSec = " + _
              s.TimeStamp100nSec.ToString()))

        Console.WriteLine("+++++++")
    End Sub
End Class