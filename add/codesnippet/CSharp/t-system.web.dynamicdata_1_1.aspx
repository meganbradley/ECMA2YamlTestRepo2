<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  protected void Page_Init(object sender, EventArgs e)
  {
    DynamicDataManager1.RegisterControl(CustomersGridView);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>DynamicField Sample</title>
  <link href="~/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
  <form id="form1" runat="server">
    <div>
    
      <h2><%= CustomersDataSource.TableName%> Table</h2>
      
      <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
        AutoLoadForeignKeys="true" />
        
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true" 
        HeaderText="List of validation errors"  />
      <asp:DynamicValidator runat="server" ID="DynamicValidator1"
        ControlToValidate="CustomersGridView" Display="None" />
        
      <asp:GridView ID="CustomersGridView" runat="server"
        AutoGenerateColumns="false"
        AutoGenerateEditButton="true"
        AutoGenerateDeleteButton="true"
        DataSourceID="CustomersDataSource"
        AllowPaging="true"
        AllowSorting="true"
        CssClass="gridview">
        <Columns>
          <asp:DynamicField DataField="CustomerID" />
          <asp:DynamicField DataField="FirstName" />
          <asp:DynamicField DataField="LastName" />
        </Columns>        
      </asp:GridView>

      <!-- This example uses Microsoft SQL Server and connects   -->
      <!-- to the AdventureWorksLT sample database.              -->
      <asp:LinqDataSource ID="CustomersDataSource" runat="server" 
        TableName="Customers"
        ContextTypeName="AdventureWorksLTDataContext"
        EnableUpdate="true"
        EnableDelete="true" >
      </asp:LinqDataSource>
      
    </div>
  </form>
</body>
</html>