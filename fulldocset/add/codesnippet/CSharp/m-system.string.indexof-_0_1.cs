using System;

public class Example
{
   public static void Main()
   {
      string searchString = "\u00ADm";
      string s1 = "ani\u00ADmal" ;
      string s2 = "animal";

      Console.WriteLine(s1.IndexOf(searchString, 2, 4));
      Console.WriteLine(s2.IndexOf(searchString, 2, 4));
   }
}
// The example displays the following output:
//       4
//       3