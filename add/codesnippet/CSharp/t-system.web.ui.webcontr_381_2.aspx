
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  void Page_Load(Object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      // Retrieve the root menu item from the Items
      // collection of the Menu control using the indexer.
      MenuItem homeMenuItem = NavigationMenu.Items[0];

      // Create the submenu item.
      MenuItem newSubMenuItem = new MenuItem("New Category");

      // Add the submenu item to the ChildItems
      // collection of the root menu item.
      homeMenuItem.ChildItems.Add(newSubMenuItem);
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemCollection Add Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemCollection Add Example</h3>
    
      <asp:menu id="NavigationMenu"
        orientation="Vertical"
        target="_blank" 
        runat="server">
        
        <items>
          <asp:menuitem text="Home"
            tooltip="Home">
            <asp:menuitem text="Music"
              tooltip="Music">
              <asp:menuitem text="Classical"
                tooltip="Classical"/>
              <asp:menuitem text="Rock"
                tooltip="Rock"/>
              <asp:menuitem text="Jazz"
                tooltip="Jazz"/>
            </asp:menuitem>
            <asp:menuitem text="Movies"
              tooltip="Movies">
              <asp:menuitem text="Action"
                tooltip="Action"/>
              <asp:menuitem text="Drama"
                tooltip="Drama"/>
              <asp:menuitem text="Musical"
                tooltip="Musical"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>

      </asp:menu>

    </form>
  </body>
</html>
