using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      AppDomain domain = AppDomain.CurrentDomain;
      // Set a timeout interval of -2 seconds.
      domain.SetData("REGEX_DEFAULT_MATCH_TIMEOUT", TimeSpan.FromSeconds(-2));

      Regex rgx = new Regex("[aeiouy]");
      Console.WriteLine("Regular expression pattern: {0}", rgx.ToString());
      Console.WriteLine("Timeout interval for this regex: {0} seconds",
                        rgx.MatchTimeout.TotalSeconds);
   }
}
// The example displays the following output:
//    Unhandled Exception: System.TypeInitializationException: 
//       The type initializer for 'System.Text.RegularExpressions.Regex' threw an exception. ---> 
//       System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values.
//       Parameter name: AppDomain data 'REGEX_DEFAULT_MATCH_TIMEOUT' contains an invalid value or 
//       object for specifying a default matching timeout for System.Text.RegularExpressions.Regex.
//       at System.Text.RegularExpressions.Regex.InitDefaultMatchTimeout()
//       at System.Text.RegularExpressions.Regex..cctor()
//       --- End of inner exception stack trace ---
//       at System.Text.RegularExpressions.Regex..ctor(String pattern)
//       at Example.Main()