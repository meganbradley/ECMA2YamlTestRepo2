#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
int main()
{
   try
   {
      
      // Create an instance of process component.
      Process^ myProcess = gcnew Process;
      
      // Create an instance of 'myProcessStartInfo'.
      ProcessStartInfo^ myProcessStartInfo = gcnew ProcessStartInfo;
      myProcessStartInfo->FileName = "notepad";
      myProcess->StartInfo = myProcessStartInfo;
      
      // Start process.
      myProcess->Start();
      
      // Allow the process to finish starting.
      myProcess->WaitForInputIdle();
      Console::Write( "Main window Title : {0}", myProcess->MainWindowTitle );
      myProcess->CloseMainWindow();
      myProcess->Close();
   }
   catch ( Exception^ e ) 
   {
      Console::Write( " Message : {0}", e->Message );
   }

}
