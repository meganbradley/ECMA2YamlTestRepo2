using System;
using System.Diagnostics;
using System.Threading;

namespace Process_Sample
{
   class MyProcessClass
   {
      public static void Main()
      {
         try
         {

            Process myProcess;
            myProcess = Process.Start("NotePad.exe");

            while(!myProcess.HasExited)
            {
               Console.WriteLine();

               // Get physical memory usage of the associated process.
               Console.WriteLine("Process's physical memory usage: " + myProcess.WorkingSet);
               // Get base priority of the associated process.
               Console.WriteLine("Base priority of the associated process: " + myProcess.BasePriority);
               // Get priority class of the associated process.
               Console.WriteLine("Priority class of the associated process: " + myProcess.PriorityClass);
               // Get user processor time for this process.
               Console.WriteLine("User Processor Time: " + myProcess.UserProcessorTime);
               // Get privileged processor time for this process.
               Console.WriteLine("Privileged Processor Time: " + myProcess.PrivilegedProcessorTime);
               // Get total processor time for this process.
               Console.WriteLine("Total Processor Time: " + myProcess.TotalProcessorTime);
               // Invoke overloaded ToString function.
               Console.WriteLine("Process's Name: " + myProcess.ToString());
               Console.WriteLine("-------------------------------------");

               if(myProcess.Responding)
               {
                  Console.WriteLine("Status:  Responding to user interface");
                  myProcess.Refresh();
               }
               else
               {
                  Console.WriteLine("Status:  Not Responding");
               }
               Thread.Sleep(1000);

            }

            Console.WriteLine();
            Console.WriteLine("Process exit code: {0}", myProcess.ExitCode);
         }
         catch(Exception e)
         {
            Console.WriteLine("The following exception was raised: " + e.Message);
         }
      }

   }
}