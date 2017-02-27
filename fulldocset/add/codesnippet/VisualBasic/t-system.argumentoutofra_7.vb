Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim list As New List(Of String) 
      list.AddRange( { "A", "B", "C" } )
      Try
         ' Display the elements in the list by index.
         For ctr As Integer = 0 To list.Count 
            Console.WriteLine("Index {0}: {1}", ctr, list(ctr)) 
         Next   
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine(e.Message)
      End Try
   End Sub
End Module
' The example displays the following output:
'   Index 0: A
'   Index 1: B
'   Index 2: C
'   Index was out of range. Must be non-negative and less than the size of the collection.
'   Parameter name: index