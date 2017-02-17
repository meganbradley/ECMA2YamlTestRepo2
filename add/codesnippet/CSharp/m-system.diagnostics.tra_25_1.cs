// Class-level declaration.
 // Create a TraceSwitch.
 static TraceSwitch generalSwitch = new TraceSwitch("General", "Entire Application");
 
 static public void MyErrorMethod(String category) {
    // Write the message if the TraceSwitch level is set to Error or higher.
    if(generalSwitch.TraceError)
       Trace.Write("My error message. ");
 
    // Write a second message if the TraceSwitch level is set to Verbose.
    if(generalSwitch.TraceVerbose)
       Trace.WriteLine("My second error message.", category);
 }
