// Class-level declaration.
 // Create a TraceSwitch.
 static TraceSwitch generalSwitch = new TraceSwitch("General", "Entire Application");
 
 static public void MyErrorMethod(Object myObject, String category) {
    // Write the message if the TraceSwitch level is set to Verbose.
    if(generalSwitch.TraceVerbose)
       Trace.Write(myObject, category);
 
    // Write a second message if the TraceSwitch level is set to Error or higher.
    if(generalSwitch.TraceError)
       Trace.WriteLine(" Object is not valid for this category.");
 }
