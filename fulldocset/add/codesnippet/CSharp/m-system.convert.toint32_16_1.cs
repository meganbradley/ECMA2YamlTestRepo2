      uint[] numbers = { UInt32.MinValue, 121, 340, UInt32.MaxValue };
      int result;
      foreach (uint number in numbers)
      {
         try {
            result = Convert.ToInt32(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the Int32 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    Converted the UInt32 value 0 to the Int32 value 0.
      //    Converted the UInt32 value 121 to the Int32 value 121.
      //    Converted the UInt32 value 340 to the Int32 value 340.
      //    The UInt32 value 4294967295 is outside the range of the Int32 type.