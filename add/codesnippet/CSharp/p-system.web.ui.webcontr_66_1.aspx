
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomersGridView_RowDeleting(Object sender, GridViewDeleteEventArgs e)
  {
    
    // Get the country/region of the record being deleted.
    GridViewRow row = CustomersGridView.Rows[e.RowIndex];
    String region = row.Cells[6].Text;
    
    // Cancel the delete operation if the country/region is "USA".
    if(region == "USA")
    {
      e.Cancel = true;
      Message.Text = "You cannot delete a record from " + region + ".";
    }
    
  }

  void CustomersGridView_RowDeleted(Object sender, GridViewDeletedEventArgs e)
  {
    
    if (e.Exception == null)
    {
      // The delete operation succeeded. Clear the message label.
      Message.Text = "";
    }
    else
    {
      // The delete operation failed. Display an error message.
      Message.Text = "An error occurred during the delete operation. " +
        e.AffectedRows.ToString() + " rows deleted.";
    }
        
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewDeleteEventArgs RowIndex Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewDeleteEventArgs RowIndex Example</h3>
            
      <asp:label id="Message"
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
