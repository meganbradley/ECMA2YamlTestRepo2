Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


' Implements a custom WebFailureAuditEvent class. 

Public Class SampleWebFailureAuditEvent
    Inherits System.Web.Management.WebFailureAuditEvent
    Private customCreatedMsg, customRaisedMsg As String
    
    
    
    ' Invoked in case of events identified only by their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, ByVal eventCode As Integer)
        MyBase.New(msg, eventSource, eventCode)
        ' Perform custom initialization.
        customCreatedMsg = String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

    End Sub 'New
    
    
    ' Invoked in case of events identified by their event code and 
    ' event detailed code.
    Public Sub New(ByVal msg As String, ByVal eventSource As Object, _
    ByVal eventCode As Integer, ByVal detailedCode As Integer)
        MyBase.New(msg, eventSource, eventCode, detailedCode)
        ' Perform custom initialization.
        customCreatedMsg = String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

    End Sub 'New
    
    
    
    ' Raises the SampleWebFailureAuditEvent.
    Public Overrides Sub Raise() 
        ' Perform custom processing.
        customRaisedMsg = String.Format("Event raised at: {0}", _
        DateTime.Now.TimeOfDay.ToString())
        
        ' Raise the event.
        WebBaseEvent.Raise(Me)
    
    End Sub 'Raise
    
    
    ' Obtains the current thread information.
    Public Function GetRequestInformation() As WebRequestInformation 
        ' No customization is allowed.
        Return RequestInformation
    
    End Function 'GetRequestInformation
    
    
    'Formats Web request event information.
    'This method is invoked indirectly by the provider 
    'using one of the overloaded ToString methods.
    Public Overrides Sub FormatCustomEventDetails(ByVal formatter _
    As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine("")

        formatter.IndentationLevel += 1
        formatter.AppendLine("******** SampleWebFailureAuditEvent Start ********")
        formatter.AppendLine(String.Format("Request path: {0}", _
        RequestInformation.RequestPath))
        formatter.AppendLine(String.Format("Request Url: {0}", _
        RequestInformation.RequestUrl))

        ' Display custom event timing.
        formatter.AppendLine(customCreatedMsg)
        formatter.AppendLine(customRaisedMsg)

        formatter.AppendLine("******** SampleWebFailureAuditEvent End ********")

        formatter.IndentationLevel -= 1

    End Sub 'FormatCustomEventDetails 

End Class 'SampleWebFailureAuditEvent
