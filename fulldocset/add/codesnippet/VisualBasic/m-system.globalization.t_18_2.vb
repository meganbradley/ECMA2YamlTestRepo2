Imports System
Imports System.Globalization


Public Class SamplesTaiwanCalendar   

   Public Shared Sub Main()

      ' Sets a DateTime to April 3, 2002 of the Gregorian calendar.
      Dim myDT As New DateTime(2002, 4, 3, New GregorianCalendar())

      ' Creates an instance of the TaiwanCalendar.
      Dim myCal As New TaiwanCalendar()

      ' Displays the values of the DateTime.
      Console.WriteLine("April 3, 2002 of the Gregorian calendar equals the following in the Taiwan calendar:")
      DisplayValues(myCal, myDT)

      ' Adds two years and ten months.
      myDT = myCal.AddYears(myDT, 2)
      myDT = myCal.AddMonths(myDT, 10)

      ' Displays the values of the DateTime.
      Console.WriteLine("After adding two years and ten months:")
      DisplayValues(myCal, myDT)

   End Sub 'Main

   Public Shared Sub DisplayValues(myCal As Calendar, myDT As DateTime)
      Console.WriteLine("   Era:        {0}", myCal.GetEra(myDT))
      Console.WriteLine("   Year:       {0}", myCal.GetYear(myDT))
      Console.WriteLine("   Month:      {0}", myCal.GetMonth(myDT))
      Console.WriteLine("   DayOfYear:  {0}", myCal.GetDayOfYear(myDT))
      Console.WriteLine("   DayOfMonth: {0}", myCal.GetDayOfMonth(myDT))
      Console.WriteLine("   DayOfWeek:  {0}", myCal.GetDayOfWeek(myDT))
      Console.WriteLine()
   End Sub 'DisplayValues

End Class 'SamplesTaiwanCalendar 


'This code produces the following output.

'

'April 3, 2002 of the Gregorian calendar equals the following in the Taiwan calendar:

'   Era:        1

'   Year:       91

'   Month:      4

'   DayOfYear:  93

'   DayOfMonth: 3

'   DayOfWeek:  Wednesday

'

'After adding two years and ten months:

'   Era:        1

'   Year:       94

'   Month:      2

'   DayOfYear:  34

'   DayOfMonth: 3

'   DayOfWeek:  Thursday

