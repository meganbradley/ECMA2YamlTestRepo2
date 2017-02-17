Private Sub GetAllErrs(ByVal row As DataRow)
    ' Declare an array variable for DataColumn objects.
    Dim colArr() As DataColumn 

    ' If the Row has errors, check use GetColumnsInError.
    Dim i As Integer
    If row.HasErrors Then 
       ' Get the array of columns in error.
       colArr = row.GetColumnsInError()
       For i = 0 to colArr.Length - 1
          ' Insert code to fix errors on each column.
          Console.WriteLine(colArr(i).ColumnName)
       Next i

    ' Clear errors after reconciling.
    row.ClearErrors()
    End If
End Sub