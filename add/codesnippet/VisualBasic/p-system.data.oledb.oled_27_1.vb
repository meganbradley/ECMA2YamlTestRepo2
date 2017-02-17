    Public Sub CreateParamCollection(command As OleDbCommand)
        Dim paramCollection As OleDbParameterCollection = _
            command.Parameters
        paramCollection.Add("@CategoryName", OleDbType.Char)
        paramCollection.Add("@Description", OleDbType.Char)
        paramCollection.Add("@Picture", OleDbType.Binary)
        Dim parameterNames As String = ""
        Dim i As Integer
        For i = 0 To paramCollection.Count - 1
            parameterNames += paramCollection(i).ToString() & _
                ControlChars.Cr
        Next i
        Console.WriteLine(parameterNames)
        paramCollection.Clear()
    End Sub 