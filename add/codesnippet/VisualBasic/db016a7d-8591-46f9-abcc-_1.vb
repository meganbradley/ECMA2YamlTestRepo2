 Public Sub GetRecords()
     ' ...
     ' create dataSet and adapter
     ' ...
     adapter.Fill(dataSet, 9, 15, "Categories")
 End Sub