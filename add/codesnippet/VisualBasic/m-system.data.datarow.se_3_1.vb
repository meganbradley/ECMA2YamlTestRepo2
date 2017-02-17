Private Sub SetColError(ByVal row As DataRow, _
    byVal columnIndex As Integer)
    Dim errorString As String = "Replace this text."

    ' Set the error for the specified column of the row.
    row.SetColumnError(columnIndex, errorString)
End Sub
 
Private Sub PrintColError( _
    ByVal row As DataRow, byVal columnIndex As Integer)

    ' Print the error of a specified column.
    Console.WriteLine(row.GetColumnError(columnIndex))
End Sub