
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
  
    If Not IsPostBack Then
    
      ' Retrieve the root menu item from the Items
      ' collection of the Menu control.
      Dim homeMenuItem As MenuItem = NavigationMenu.Items(0)

      ' Retrieve the Movie submenu item from the ChildItems
      ' collection of the root menu item.
      Dim movieSubMenuItem As MenuItem = NavigationMenu.FindItem("Home\Movies")

      ' Remove the Movie submenu item.
      If movieSubMenuItem IsNot Nothing Then
      
        homeMenuItem.ChildItems.Remove(movieSubMenuItem)
        
      End If
        
    End If
        
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemCollection Remove Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemCollection Remove Example</h3>
    
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
