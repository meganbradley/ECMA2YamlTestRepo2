
<%@ Page language="VB" %>
<%@ import namespace="System.IO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

    ' Record the delete operation in a log file.

    ' Create the log text. 
    Dim logText As String = ""

    ' Append the values of the key fields to the log text.
    Dim i As Integer
    For i = 0 To e.Keys.Count - 1
    
      logText &= e.Keys(i).ToString() & ";"
      
    Next

    ' Append the values of the non-key fields to the log text.
    For i = 0 To e.Values.Count - 1
    
      If e.Values(i) IsNot Nothing Then
        logText &= e.Values(i).ToString() & ";"
      Else
        logText &= "Nothing" & ";"
      End If
      
    Next
    
    ' Display the log content.
    LogTextLabel.Text = logText

    ' Append the text to a log file.
    Try
    
      Dim sw As StreamWriter
      sw = File.AppendText(Server.MapPath(Nothing) & "\deletelog.txt")
      sw.WriteLine(logText)
      sw.Flush()
      sw.Close()
    
    Catch ex As UnauthorizedAccessException
    
      ' You must provide read/write access to the file using ACLs.
      LogErrorLabel.Text = "You do not have permission to write to the log."
    
    End Try

  End Sub
    
  Sub CustomersGridView_RowDeleted(ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)
    
    If e.Exception Is Nothing Then
    
      ' The delete operation succeeded. Clear the message label.
      Message.Text = ""
    
    Else
    
      ' The delete operation failed. Display an error message.
      Message.Text = e.AffectedRows.ToString() & " rows deleted. " & e.Exception.Message
      e.ExceptionHandled = True
      
    End If
        
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewDeleteEventArgs Keys and Values Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewDeleteEventArgs Keys and Values Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"          
        runat="server"/>
        
      <br/>
      
      <asp:label id="LogTextLabel"
        forecolor="Red"          
        runat="server"/>
        
      <br/>
        
      <asp:label id="LogErrorLabel"
        forecolor="Red"          
        runat="server"/>
                
      <br/>

      <asp:gridview id="CustomersGridView" 
        allowpaging="true"
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="true"
        autogeneratedeletebutton="true" 
        datakeynames="CustomerID"
        onrowdeleted="CustomersGridView_RowDeleted"
        onrowdeleting="CustomersGridView_RowDeleting"   
        runat="server">
        
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        deletecommand="Delete from Customers where CustomerID = @CustomerID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>
