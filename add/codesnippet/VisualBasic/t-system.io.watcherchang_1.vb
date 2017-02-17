Imports System.IO

Module Module1
    Sub Main()
        ' Create a FileSystemWatcher to monitor all files on drive C.
        Dim fsw As New FileSystemWatcher("C:\")

        ' Watch for changes in LastAccess and LastWrite times, and
        ' the renaming of files or directories. 
        fsw.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite _ 
            Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)

        ' Register a handler that gets called when a 
        ' file is created, changed, or deleted.
        AddHandler fsw.Changed, New FileSystemEventHandler(AddressOf OnChanged)

        ' The commented line of code below is a shorthand of the above line.
        ' AddHandler fsw.Changed, AddressOf OnChanged

        ' NOTE: The shorthand version is used in the remainder of this code.
        ' FileSystemEventHandler
        AddHandler fsw.Created, AddressOf OnChanged 
        ' FileSystemEventHandler
        AddHandler fsw.Deleted, AddressOf OnChanged

        ' Register a handler that gets called when a file is renamed.
        ' RenamedEventHandler
        AddHandler fsw.Renamed, AddressOf OnRenamed

        ' Register a handler that gets called if the 
        ' FileSystemWatcher needs to report an error.
        ' ErrorEventHandler
        AddHandler fsw.Error, AddressOf OnError

        ' Begin watching.
        fsw.EnableRaisingEvents = True

        ' Wait for the user to quit the program.
        Console.WriteLine("Press 'Enter' to quit the sample.")
        Console.ReadLine()
    End Sub

    ' This method is called when a file is created, changed, or deleted.
    Private Sub OnChanged(ByVal source As Object, ByVal e As FileSystemEventArgs)

        ' Show that a file has been created, changed, or deleted.
        Dim wct As WatcherChangeTypes = e.ChangeType
        Console.WriteLine("File {0} {1}", e.FullPath, wct.ToString())
    End Sub

    ' This method is called when a file is renamed.
    Private Sub OnRenamed(ByVal source As Object, ByVal e As RenamedEventArgs)

        ' Show that a file has been renamed.
        Dim wct As WatcherChangeTypes = e.ChangeType
        Console.WriteLine("File {0} {2} to {1}", e.OldFullPath, e.FullPath, wct.ToString())
    End Sub

    ' This method is called when the FileSystemWatcher detects an error.
    Private Sub OnError(ByVal source As Object, ByVal e As ErrorEventArgs)

        ' Show that an error has been detected.
        Console.WriteLine("The FileSystemWatcher has detected an error")

        ' Give more information if the error is due to an internal buffer overflow.
        If TypeOf e.GetException Is InternalBufferOverflowException Then
            ' This can happen if Windows is reporting many file system events quickly 
            ' and internal buffer of the  FileSystemWatcher is not large enough to handle this
            ' rate of events. The InternalBufferOverflowException error informs the application
            ' that some of the file system events are being lost.
            Console.WriteLine( _
                "The file system watcher experienced an internal buffer overflow: " _
                + e.GetException.Message)
        End If
    End Sub
End Module