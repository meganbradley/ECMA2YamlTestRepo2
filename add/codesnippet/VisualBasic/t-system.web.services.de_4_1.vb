Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic

Public Class MyOperationFaultSample
   Public Shared Sub Main()
      Try
         ' Read the 'StockQuote_vb.wsdl' file as input.
         Dim myServiceDescription As ServiceDescription = _
                              ServiceDescription.Read("StockQuote_vb.wsdl")
         Dim myPortTypeCollection As PortTypeCollection = _
                                           myServiceDescription.PortTypes
         Dim myPortType As PortType = myPortTypeCollection(0)
         Dim myOperationCollection As OperationCollection = myPortType.Operations
         Dim myOperation As Operation = myOperationCollection(0)
         Dim myOperationFault As New OperationFault()
         myOperationFault.Name = "ErrorString"
         myOperationFault.Message = _
                        New XmlQualifiedName("s0:GetTradePriceStringFault")
         myOperation.Faults.Add(myOperationFault)
         Console.WriteLine("Added OperationFault with Name: " + _
                                                     myOperationFault.Name)
         myOperationFault = New OperationFault()
         myOperationFault.Name = "ErrorInt"
         myOperationFault.Message = _
                           New XmlQualifiedName("s0:GetTradePriceIntFault")
         myOperation.Faults.Add(myOperationFault)
         myOperationCollection.Add(myOperation)
         Console.WriteLine("Added Second OperationFault with Name: " + _
                                                    myOperationFault.Name)
         myServiceDescription.Write("StockQuoteNew_vb.wsdl")
         Console.WriteLine(ControlChars.NewLine + _
                           "The file 'StockQuoteNew_vb.wsdl' is " + _
                           "created successfully.")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " + e.Source)
         Console.WriteLine("Message : " + e.Message)
      End Try
   End Sub
End Class