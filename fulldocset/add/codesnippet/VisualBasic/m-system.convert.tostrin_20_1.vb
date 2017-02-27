      Dim bases() As Integer = { 2, 8, 10, 16}
      Dim numbers() As Integer = { Int32.MinValue, -19327543, -13621, -18, 12, _
                                   19142, Int32.MaxValue }

      For Each base As Integer In bases
         Console.WriteLine("Base {0} conversion:", base)
         For Each number As Integer In numbers
            Console.WriteLine("   {0,-15}  -->  0x{1}", _
                              number, Convert.ToString(number, base))
         Next
      Next
      ' The example displays the following output:
      '    Base 2 conversion:
      '       -2147483648      -->  0x10000000000000000000000000000000
      '       -19327543        -->  0x11111110110110010001010111001001
      '       -13621           -->  0x11111111111111111100101011001011
      '       -18              -->  0x11111111111111111111111111101110
      '       12               -->  0x1100
      '       19142            -->  0x100101011000110
      '       2147483647       -->  0x1111111111111111111111111111111
      '    Base 8 conversion:
      '       -2147483648      -->  0x20000000000
      '       -19327543        -->  0x37666212711
      '       -13621           -->  0x37777745313
      '       -18              -->  0x37777777756
      '       12               -->  0x14
      '       19142            -->  0x45306
      '       2147483647       -->  0x17777777777
      '    Base 10 conversion:
      '       -2147483648      -->  0x-2147483648
      '       -19327543        -->  0x-19327543
      '       -13621           -->  0x-13621
      '       -18              -->  0x-18
      '       12               -->  0x12
      '       19142            -->  0x19142
      '       2147483647       -->  0x2147483647
      '    Base 16 conversion:
      '       -2147483648      -->  0x80000000
      '       -19327543        -->  0xfed915c9
      '       -13621           -->  0xffffcacb
      '       -18              -->  0xffffffee
      '       12               -->  0xc
      '       19142            -->  0x4ac6
      '       2147483647       -->  0x7fffffff