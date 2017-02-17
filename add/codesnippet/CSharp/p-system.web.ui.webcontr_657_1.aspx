    <form id="form1" runat="server">
    <div>
    <asp:objectdatasource
          ID="ObjectDataSource1"
          runat="server"
          SelectMethod="GetFullNamesAndIDs"
          TypeName="Samples.AspNet.CS.EmployeeLogic" />
          
        <p>
        <asp:dropdownlist
          ID="DropDownList1"
          runat="server" 
          DataSourceID="ObjectDataSource1"
          DataTextField="FullName"
          DataValueField="EmployeeID" 
          AutoPostBack="True" 
          AppendDataBoundItems="true">
            <asp:ListItem Text="Select One" Value=""></asp:ListItem>
        </asp:dropdownlist>
        </p>
        
     <asp:objectdatasource
          ID="ObjectDataSource2"
          runat="server"
          SelectMethod="GetEmployee"
          TypeName="Samples.AspNet.CS.EmployeeLogic" 
          EnableCaching="true"
          CacheKeyDependency="EmployeeDetails" >
          <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="-1" Name="empID" />
          </SelectParameters>
        </asp:objectdatasource>
        
        <asp:DetailsView
            ID="DetailsView1"
            runat="server"
            DataSourceID="ObjectDataSource2" 
            AutoGenerateRows="false">  
            <Fields>
                <asp:BoundField HeaderText="Address" DataField="Address" />
                <asp:BoundField HeaderText="City" DataField="City" />
                <asp:BoundField HeaderText="Postal Code" DataField="PostalCode" />
            </Fields>  
        </asp:DetailsView>
        
        <asp:Button 
        ID="Button1" 
        runat="server" 
        Text="Check for latest data" 
        OnClick="Button1_Click" />
        
    </div>
    </form>