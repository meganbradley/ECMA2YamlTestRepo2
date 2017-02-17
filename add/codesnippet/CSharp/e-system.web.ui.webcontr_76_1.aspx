
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void CustomerDetailView_ModeChanged(Object sender, EventArgs e)
  {
    // Display the current mode in the header row.
      switch (CustomerDetailView.CurrentMode)
    {
      case DetailsViewMode.Edit:
        CustomerDetailView.HeaderText = "Edit Mode";
        CustomerDetailView.HeaderStyle.ForeColor = System.Drawing.Color.Red;
        CustomerDetailView.HeaderStyle.BackColor = System.Drawing.Color.LightGray;
        break;
      case DetailsViewMode.Insert:
        CustomerDetailView.HeaderText = "Insert Mode";
        CustomerDetailView.HeaderStyle.ForeColor = System.Drawing.Color.Green;
        CustomerDetailView.HeaderStyle.BackColor = System.Drawing.Color.Yellow;
        break;
      case DetailsViewMode.ReadOnly:
        CustomerDetailView.HeaderText = "Read-Only Mode";
        CustomerDetailView.HeaderStyle.ForeColor = System.Drawing.Color.Blue;
        CustomerDetailView.HeaderStyle.BackColor = System.Drawing.Color.White;
        break;
      default:
          CustomerDetailView.HeaderText = "Error!";
        break;
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView ModeChanged Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView ModeChanged Example</h3>      
                
        <asp:detailsview id="CustomerDetailView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogeneraterows="true"
          autogenerateeditbutton="true"
          autogenerateinsertbutton="true"  
          allowpaging="true"
          headertext="Read-Only Mode" 
          onmodechanged="CustomerDetailView_ModeChanged" 
          runat="server">
               
          <fieldheaderstyle backcolor="Navy"
            forecolor="White"/>
            
          <headerstyle forecolor="Blue"/>
                    
        </asp:detailsview>
        
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:SqlDataSource ID="DetailsViewSource" runat="server" 
          ConnectionString=
            "<%$ ConnectionStrings:NorthWindConnectionString%>"
            InsertCommand="INSERT INTO [Customers]([CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country]) VALUES (@CustomerID, @CompanyName, @Address, @City, @PostalCode, @Country)"
          SelectCommand="Select [CustomerID], [CompanyName], 
            [Address], [City], [PostalCode], [Country] From 
            [Customers]">
        </asp:SqlDataSource>
    </form>
  </body>
</html>
