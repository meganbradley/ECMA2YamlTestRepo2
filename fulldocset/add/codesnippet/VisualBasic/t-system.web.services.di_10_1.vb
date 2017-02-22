Imports System
Imports System.Xml
Imports System.Web.Services.Discovery
Imports System.IO
Imports System.Collections
Imports MicroSoft.VisualBasic

Public Class DiscoveryDocumentReference_ctor_WriteDocument

    Public Shared Sub Main()
        Try
            Dim myDiscoveryDocument As DiscoveryDocument
            Dim myXmlTextReader As _
                 New XmlTextReader("http://localhost/Sample_vb.vsdisco")
            myDiscoveryDocument = DiscoveryDocument.Read(myXmlTextReader)

            ' Create a new instance of DiscoveryDocumentReference.
            Dim myDiscoveryDocumentReference As _
                New DiscoveryDocumentReference()
            Dim myFileStream As New FileStream("Temp.vsdisco", _
                 FileMode.OpenOrCreate, FileAccess.Write)
            myDiscoveryDocumentReference.WriteDocument( _
                 myDiscoveryDocument, myFileStream)
            myFileStream.Close()

            Dim myFileStream1 As New FileStream("Temp.vsdisco", _
                FileMode.OpenOrCreate, FileAccess.Read)
            Dim myStreamReader As New StreamReader(myFileStream1)

            ' Initialize the file pointer.
            myStreamReader.BaseStream.Seek(0, SeekOrigin.Begin)
            Console.WriteLine("The contents of the discovery document are: " _
                & ControlChars.NewLine)
            While myStreamReader.Peek() > - 1
                ' Display the contents of the discovery document.
                Console.WriteLine(myStreamReader.ReadLine())
            End While
            myStreamReader.Close()
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'DiscoveryDocumentReference_ctor_WriteDocument