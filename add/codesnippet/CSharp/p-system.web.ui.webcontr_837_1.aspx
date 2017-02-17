<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">

    void Page_Load()
    {
        Message.Text = String.Empty;
    }
    
    void ContactsListView_ItemDeleted(Object sender, ListViewDeletedEventArgs e)
    {
        // Determine whether an exception occurred during the delete operation.
        if (e.Exception == null)
        {
            // Ensure that a record was deleted.
            if (e.AffectedRows > 0)
            {
                Message.Text = e.AffectedRows + " item(s) deleted successfully.";
            }
            else
            {
                Message.Text = "No item was deleted.";
            }
        }
        else
        {
            // Insert the code to handle the exception here.

            // Indicate that the exception has been handled.
            e.ExceptionHandled = true;
            Message.Text = "An error occurred during the delete operation.";
        }
    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ListViewDeletedEventArgs Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListViewDeletedEventArgs Example</h3>
            
      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>
            
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        OnItemDeleted="ContactsListView_ItemDeleted"  
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" runat="server" id="tblContacts" width="640px">
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="12">
            <Fields>
              <asp:NextPreviousPagerField 
                ShowFirstPageButton="true" ShowLastPageButton="true"
                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                NextPageText=" &gt; " PreviousPageText=" &lt; " />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td valign="top">
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
            <td>
              <asp:LinkButton ID="DeleteButton" runat="server" 
                CommandName="Delete" 
                Text="Delete" 
                OnClientClick="return confirm('Are you sure?');" />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects    -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET  -->
      <!-- expression to retrieve the connection string value     -->
      <!-- from the Web.config file.                              -->            
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName], [EmailAddress] 
          FROM Person.Contact"
        DeleteCommand="DELETE FROM Person.Contact WHERE [ContactID] = @ContactID">
        <DeleteParameters>
            <asp:Parameter Name="ContactID" Type="Int32" />
        </DeleteParameters>
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>