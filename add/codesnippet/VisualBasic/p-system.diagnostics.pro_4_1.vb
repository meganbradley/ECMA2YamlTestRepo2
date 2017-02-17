         Dim myProcess As New Process()
         ' Get the process start information of notepad.
         Dim myProcessStartInfo As New ProcessStartInfo("notepad.exe")
         ' Assign 'StartInfo' of notepad to 'StartInfo' of 'myProcess' object.
         myProcess.StartInfo = myProcessStartInfo
         ' Create a notepad.
         myProcess.Start()
         System.Threading.Thread.Sleep(1000)
         Dim myProcessModule As ProcessModule
         ' Get all the modules associated with 'myProcess'.
         Dim myProcessModuleCollection As ProcessModuleCollection = myProcess.Modules
         Console.WriteLine("Entry point addresses of the modules " + _
                        "associated with 'notepad' are:")
         ' Display the 'EntryPointAddress' of each of the modules.
         Dim i As Integer
         For i = 0 To myProcessModuleCollection.Count - 1
            myProcessModule = myProcessModuleCollection(i)
            Console.WriteLine(myProcessModule.ModuleName + " : " + _
                                    myProcessModule.EntryPointAddress.ToString())
         Next i
         ' Get the main module associated with 'myProcess'.
         myProcessModule = myProcess.MainModule
         Console.WriteLine("The process's main module's EntryPointAddress is: " + _
                              myProcessModule.EntryPointAddress.ToString())
         myProcess.CloseMainWindow()