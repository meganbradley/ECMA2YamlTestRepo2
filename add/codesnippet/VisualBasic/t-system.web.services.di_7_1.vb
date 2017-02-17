Imports System
Imports System.Xml
Imports System.IO
Imports System.Web.Services.Discovery
Imports System.Collections


Public Class DiscoveryDocument_Example
   
   Shared Sub Main()
      Try
         ' Create an object of the 'DiscoveryDocument'.
         Dim myDiscoveryDocument As New DiscoveryDocument()
         
         ' Create an XmlTextReader with the sample file.
         Dim myXmlTextReader As New XmlTextReader("http://localhost/example_vb.disco")
         
         ' Read the given XmlTextReader.
         myDiscoveryDocument = DiscoveryDocument.Read(myXmlTextReader)
         
         ' Write the DiscoveryDocument into the 'TextWriter'.
         Dim myFileStream As New FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write)
         Dim myStreamWriter As New StreamWriter(myFileStream)
         myDiscoveryDocument.Write(myStreamWriter)

         myStreamWriter.Flush()
         myStreamWriter.Close()
         ' Display the contents of the DiscoveryDocument onto the console.
         Dim myFileStream1 As New FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Read)
         Dim myStreamReader As New StreamReader(myFileStream1)
         
         ' Set the file pointer to the begin.
         myStreamReader.BaseStream.Seek(0, SeekOrigin.Begin)
         Console.WriteLine("The contents of the DiscoveryDocument are-")
         While myStreamReader.Peek() > - 1
            Console.WriteLine(myStreamReader.ReadLine())
         End While
         myStreamReader.Close()
      Catch e As Exception
         Console.WriteLine("Exception raised : {0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'DiscoveryDocument_Example