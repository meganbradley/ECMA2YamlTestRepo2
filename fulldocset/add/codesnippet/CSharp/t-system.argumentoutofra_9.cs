using System;

public class Example
{
   public static void Main()
   {
       String[] words = { "the", "today", "tomorrow", " ", "" };
       foreach (var word in words)
          Console.WriteLine("First character of '{0}': '{1}'", 
                            word, GetFirstCharacter(word));
   }
   
   private static char GetFirstCharacter(String s)
   {
      return s[0];
   }
}
// The example displays the following output:
//    First character of //the//: //t//
//    First character of //today//: //t//
//    First character of //tomorrow//: //t//
//    First character of // //: // //
//    
//    Unhandled Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.
//       at Example.Main()