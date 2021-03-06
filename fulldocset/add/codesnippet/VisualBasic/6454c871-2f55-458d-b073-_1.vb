    ' Displays sending with a connected socket
    ' using the overload that takes a buffer, offset, message size, and socket flags.
    Public Shared Function SendReceiveTest4(ByVal server As Socket) As Integer 
        Dim msg As Byte() = Encoding.UTF8.GetBytes("This is a test")
        Dim bytes(255) As Byte
        Try
            ' Blocks until send returns.
            Dim byteCount As Integer = server.Send(msg, 0, msg.Length, SocketFlags.None)
            Console.WriteLine("Sent {0} bytes.", byteCount)
            
            ' Get reply from the server.
            byteCount = server.Receive(bytes, 0, server.Available, SocketFlags.None)
            
            If byteCount > 0 Then
                Console.WriteLine(Encoding.UTF8.GetString(bytes))
            End If
        Catch e As SocketException
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode)
            Return e.ErrorCode
        End Try
        Return 0
    
    End Function 'SendReceiveTest4
    