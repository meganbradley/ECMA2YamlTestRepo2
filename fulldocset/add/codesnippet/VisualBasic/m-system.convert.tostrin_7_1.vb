      Dim numbers() As UShort = { UInt16.MinValue, 103, 1045, UInt16.MaxValue }
      Dim result As String
      
      For Each number As UShort In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the UInt16 value 0 to the String value 0.
      '    Converted the UInt16 value 103 to the String value 103.
      '    Converted the UInt16 value 1045 to the String value 1045.
      '    Converted the UInt16 value 65535 to the String value 65535.