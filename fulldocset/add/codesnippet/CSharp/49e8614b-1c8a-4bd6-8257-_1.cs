using System;
using System.Globalization;


public class SamplesCalendar  {

   public static void Main()  {

      // Creates an instance of every Calendar type.
      Calendar[] myCals = new Calendar[8];
      myCals[0] = new GregorianCalendar();
      myCals[1] = new HebrewCalendar();
      myCals[2] = new HijriCalendar();
      myCals[3] = new JapaneseCalendar();
      myCals[4] = new JulianCalendar();
      myCals[5] = new KoreanCalendar();
      myCals[6] = new TaiwanCalendar();
      myCals[7] = new ThaiBuddhistCalendar();

      // For each calendar, displays the current year, the number of months in that year,
      // and the number of days in each month of that year.
      int i, j, iYear, iMonth, iDay;
      DateTime myDT = DateTime.Today;

      for ( i = 0; i < myCals.Length; i++ )  {
         iYear = myCals[i].GetYear( myDT );
         Console.WriteLine();
         Console.WriteLine( "{0}, Year: {1}", myCals[i].GetType(), myCals[i].GetYear( myDT ) );
         Console.WriteLine( "   MonthsInYear: {0}", myCals[i].GetMonthsInYear( iYear ) );
         Console.WriteLine( "   DaysInYear: {0}", myCals[i].GetDaysInYear( iYear ) );
         Console.WriteLine( "   Days in each month:" );
         Console.Write( "      " );

         for ( j = 1; j <= myCals[i].GetMonthsInYear( iYear ); j++ )
            Console.Write( " {0,-5}", myCals[i].GetDaysInMonth( iYear, j ) );
         Console.WriteLine();

         iMonth = myCals[i].GetMonth( myDT );
         iDay = myCals[i].GetDayOfMonth( myDT );
         Console.WriteLine( "   IsLeapDay:   {0}", myCals[i].IsLeapDay( iYear, iMonth, iDay ) );
         Console.WriteLine( "   IsLeapMonth: {0}", myCals[i].IsLeapMonth( iYear, iMonth ) );
         Console.WriteLine( "   IsLeapYear:  {0}", myCals[i].IsLeapYear( iYear ) );

      }

   }

}


/*
This code produces the following output.  The results vary depending on the date.

System.Globalization.GregorianCalendar, Year: 2002
   MonthsInYear: 12
   DaysInYear: 365
   Days in each month:
       31    28    31    30    31    30    31    31    30    31    30    31   
   IsLeapDay:   False
   IsLeapMonth: False
   IsLeapYear:  False

System.Globalization.HebrewCalendar, Year: 5763
   MonthsInYear: 13
   DaysInYear: 385
   Days in each month:
       30    30    30    29    30    30    29    30    29    30    29    30    29   
   IsLeapDay:   False
   IsLeapMonth: False
   IsLeapYear:  True

System.Globalization.HijriCalendar, Year: 1423
   MonthsInYear: 12
   DaysInYear: 355
   Days in each month:
       30    29    30    29    30    29    30    29    30    29    30    30   
   IsLeapDay:   False
   IsLeapMonth: False
   IsLeapYear:  True

System.Globalization.JapaneseCalendar, Year: 14
   MonthsInYear: 12
   DaysInYear: 365
   Days in each month:
       31    28    31    30    31    30    31    31    30    31    30    31   
   IsLeapDay:   False
   IsLeapMonth: False
   IsLeapYear:  False

System.Globalization.JulianCalendar, Year: 2002
   MonthsInYear: 12
   DaysInYear: 365
   Days in each month:
       31    28    31    30    31    30    31    31    30    31    30    31   
   IsLeapDay:   False
   IsLeapMonth: False
   IsLeapYear:  False

System.Globalization.KoreanCalendar, Year: 4335
   MonthsInYear: 12
   DaysInYear: 365
   Days in each month:
       31    28    31    30    31    30    31    31    30    31    30    31   
   IsLeapDay:   False
   IsLeapMonth: False
   IsLeapYear:  False

System.Globalization.TaiwanCalendar, Year: 91
   MonthsInYear: 12
   DaysInYear: 365
   Days in each month:
       31    28    31    30    31    30    31    31    30    31    30    31   
   IsLeapDay:   False
   IsLeapMonth: False
   IsLeapYear:  False

System.Globalization.ThaiBuddhistCalendar, Year: 2545
   MonthsInYear: 12
   DaysInYear: 365
   Days in each month:
       31    28    31    30    31    30    31    31    30    31    30    31   
   IsLeapDay:   False
   IsLeapMonth: False
   IsLeapYear:  False

*/